#include <windows.h>

#include "wahook.h"
#include "disasm.h"

#if defined _WIN64
  #define WRITE_JMP(mem, thisAddress, to) {*((LPWORD)(mem)) = OPCODE_JMP; *((DWORD *)(((LPBYTE)mem) + 2)) = 0x00000000; *((DWORD64 *)(((LPBYTE)(mem)) + OPCODE_JMP_SIZE)) = (DWORD64)((DWORD_PTR)(to));}
  #define OPCODE_JMP      0x25FF
  #define OPCODE_JMP_SIZE 6 
  #define JMP_ADDR_SIZE   (sizeof(DWORD64) + OPCODE_JMP_SIZE)
  #define INJECT_SIZE     JMP_ADDR_SIZE
  #define OPCODE_MAX_SIZE 16  
#else
  #define WRITE_JMP(mem, thisAddress, to) {*((LPBYTE)(mem)) = OPCODE_JMP; *((DWORD *)(((LPBYTE)(mem)) + OPCODE_JMP_SIZE)) = (DWORD)((DWORD_PTR)(to) - (DWORD_PTR)(thisAddress) - INJECT_SIZE);}
  #define OPCODE_JMP      0xE9
  #define OPCODE_JMP_SIZE 1 
  #define JMP_ADDR_SIZE   (sizeof(DWORD) + OPCODE_JMP_SIZE)
  #define INJECT_SIZE     JMP_ADDR_SIZE
  #define OPCODE_MAX_SIZE 15
#endif

/*
  ���������, ������� �������� ���� ��� ���������.

  IN process - �������.
  IN address - �����.

  Return     - ���. ��������� ����.
*/
static DWORD_PTR checkAvalibleBytes(HANDLE process, void *address)
{
  DWORD_PTR avalibeBytes = 0;
  MEMORY_BASIC_INFORMATION mbi;
  if(CWA(kernel32, VirtualQueryEx)(process, address, &mbi, sizeof(MEMORY_BASIC_INFORMATION)) != 0 && mbi.State == MEM_COMMIT && (mbi.Protect & (PAGE_NOACCESS | PAGE_GUARD)) == 0)
  {
    DWORD_PTR tmp = (DWORD_PTR)((LPBYTE)address - (LPBYTE)mbi.BaseAddress);
    if(mbi.RegionSize > tmp/*�������*/)avalibeBytes = mbi.RegionSize - tmp;
  }
  return avalibeBytes;
}

void WaHook::init(void)
{

}

void WaHook::uninit(void)
{

}

DWORD WaHook::_hook(HANDLE process, void *functionForHook, void *hookerFunction, void *originalFunction, HOTPATCHCALLBACK hotPatchCallback)
{
  DWORD retVal = 0;

  DWORD oldProtect;
  DWORD_PTR avalibeBytes = checkAvalibleBytes(process, functionForHook);

  //���� ��� ����� ������������� ���������.
  if(avalibeBytes >= OPCODE_MAX_SIZE * 2 && CWA(kernel32, VirtualProtectEx)(process, functionForHook, OPCODE_MAX_SIZE * 2, PAGE_EXECUTE_READWRITE, &oldProtect) != 0)
  {
    //��������� ������ ���.
    BYTE buf[OPCODE_MAX_SIZE * 2 + JMP_ADDR_SIZE];
    Mem::_set(buf, (char)0x90, sizeof(buf));/*�������*/

    if(CWA(kernel32, ReadProcessMemory)(process, functionForHook, buf, OPCODE_MAX_SIZE * 2, NULL) == 0)goto END;

    //������ ������, ���� �� ��������� ����� �� ��������� INJECT_SIZE.
    DWORD_PTR opcodeOffset = 0;
    for(;;)
    {
      LPBYTE currentOpcode = buf + opcodeOffset;
      DWORD currentOpcodeLen = Disasm::_getOpcodeLength(currentOpcode);

      //����������� �����.
      if(currentOpcodeLen == (DWORD)-1)
      {
        #if defined(WDEBUG2)
        WDEBUG2(WDDT_ERROR, "Bad opcode detected at offset %u for function 0x%p", opcodeOffset, functionForHook);
        #endif

        goto END; 
      }

      opcodeOffset += currentOpcodeLen;

      if(opcodeOffset > sizeof(buf) - JMP_ADDR_SIZE)
      {
        #if defined(WDEBUG2)
        WDEBUG2(WDDT_ERROR, "Very long opcode detected at offset %u for function 0x%p", opcodeOffset - currentOpcodeLen, functionForHook);
        #endif
        
        goto END; 
      }
#     if !defined _WIN64      
      //������������� call � jmp.
      if((currentOpcode[0] == 0xE9 || currentOpcode[0] == 0xE8) && currentOpcodeLen == 1 + sizeof(DWORD)) //FIXME: �� ������ ��� x64.
      {
#       if defined(WDEBUG0)
        WDEBUG1(WDDT_INFO, "Relative JMP/CALL(%02X) detected.", currentOpcode[0]);
#       endif

        DWORD *relAddrSet = (DWORD *)(currentOpcode + 1);
        DWORD_PTR to = (*relAddrSet) + ((DWORD_PTR)functionForHook + opcodeOffset);
        *relAddrSet = (DWORD)(to - ((DWORD_PTR)originalFunction + opcodeOffset));
      }
#else
	  //FIXME
#     endif
      
      if(opcodeOffset >= INJECT_SIZE)break;
    }

    //��������� ������������ ������ � originalFunction.
    {
      //���������� � ����� ������, jump �� ����������� functionForHook.
      LPBYTE pjmp = buf + opcodeOffset;
#if defined _WIN64	  
      WRITE_JMP(pjmp, originalFunction/* + opcodeOffset*/, (LPBYTE)functionForHook + opcodeOffset);
#else	  
      WRITE_JMP(pjmp, originalFunction/* + opcodeOffset*/, functionForHook/* + opcodeOffset*/);
#endif
      if(CWA(kernel32, WriteProcessMemory)(process, originalFunction, buf, opcodeOffset + JMP_ADDR_SIZE, NULL) == 0)goto END;
    }

    //����� ������ � �������.
    {
      WRITE_JMP(buf, functionForHook, hookerFunction);
      hotPatchCallback(functionForHook, originalFunction);
      if(CWA(kernel32, WriteProcessMemory)(process, functionForHook, buf, INJECT_SIZE, NULL) == 0)goto END;
    }

    retVal = opcodeOffset + JMP_ADDR_SIZE; //������ ���������� ���������.

END:
    //�������������� �����.
    CWA(kernel32, VirtualProtectEx)(process, functionForHook, OPCODE_MAX_SIZE * 2, oldProtect, &oldProtect);
  }
  
  return retVal;
}

bool WaHook::_unhook(HANDLE process, void *hookedFunction, void *originalFunction, DWORD size)
{
  bool ret = false;
  DWORD oldProtect;
  DWORD_PTR avalibeBytes = checkAvalibleBytes(process, hookedFunction);

  //���� ��� ����� ������������� ���������.
  if(avalibeBytes >= OPCODE_MAX_SIZE * 2 && CWA(kernel32, VirtualProtectEx)(process, hookedFunction, OPCODE_MAX_SIZE * 2, PAGE_EXECUTE_READWRITE, &oldProtect) != 0)
  {
    if(CWA(kernel32, WriteProcessMemory)(process, hookedFunction, originalFunction, size - JMP_ADDR_SIZE, NULL) != 0)ret = true;
    
    //�������������� �����.
    CWA(kernel32, VirtualProtectEx)(process, hookedFunction, OPCODE_MAX_SIZE * 2, oldProtect, &oldProtect);
  }

  return ret;
}

bool WaHook::_isHooked(HANDLE process, void *function)
{
#if defined _WIN64 
  WORD opcode = 0; 
  if(CWA(kernel32, ReadProcessMemory)(process, function, &opcode, 2, NULL) != FALSE && opcode == OPCODE_JMP)return true;
  return false;
#else
  BYTE opcode = 0; 
  if(CWA(kernel32, ReadProcessMemory)(process, function, &opcode, 1, NULL) != FALSE && opcode == OPCODE_JMP)return true;
  return false;
#endif  
}

void *WaHook::_allocBuffer(HANDLE process, DWORD maxFunctions)
{
  return CWA(kernel32, VirtualAllocEx)(process, NULL, maxFunctions * ((OPCODE_MAX_SIZE * 2) + JMP_ADDR_SIZE), MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
}
