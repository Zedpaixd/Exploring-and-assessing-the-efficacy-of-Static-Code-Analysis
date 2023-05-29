//----------------------------------------------------------------------------
//  ������ ���������
//  ������ �� ������������ ���������� � ������������� �� ��� �������������
//----------------------------------------------------------------------------


#ifndef KeepAliveH
#define KeepAliveH

//----------------------------------------------------------------------------


// ������� �� �������� ����� ������� ������ ���������

#define PROCESS_SVCHOST  1 /* ������� �� ��������� svchost*/
#define PROCESS_VIDEO	 2 //������� �� ����� ���������

//---------------------------------------------------------------------
//  ������� �������������� ������� �������� ������ ����������
//  ��������. ���������� �� �������� �� ������� ����� �������
//  ����������
//---------------------------------------------------------------------
bool KeepAliveInitializeProcess(DWORD ProcessNomber);


//---------------------------------------------------------------------
//  ������� ��������� ����� �������� �� ������ ���������� ��������
//  ���������� �� ���������� ��������
//---------------------------------------------------------------------
void KeepAliveCheckProcess(DWORD ProcessNomber);

//----------------------------------------------------------------------------
#endif 