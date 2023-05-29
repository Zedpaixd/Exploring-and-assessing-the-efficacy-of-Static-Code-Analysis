<?php if(!defined('__CP__'))die();

define('LNG_TITLE',          'CP');
define('LNG_YES',            'Yes');
define('LNG_NO',             'No');
define('LNG_ACCESS_DEFINED', 'Access defined.');
define('LNG_ACTION_APPLY',   '&#62;&#62;');

//Форматы данных.
define('LNG_FORMAT_DATE',   'd.m.Y');
define('LNG_FORMAT_TIME',   'H:i:s');
define('LNG_FORMAT_DT',     'd.m.Y H:i:s');
define('LNG_FORMAT_NOTIME', '--:--:--');

//Список ботнетов.
define('LNG_BOTNET_ALL',   '[All]');
define('LNG_BOTNET_APPLY', '&#62;&#62;');

//Список страниц.
define('LNG_PAGELIST_TITLE', 'Pages:');
define('LNG_PAGELIST_NEXT',  'Next');
define('LNG_PAGELIST_PREV',  'Prev');
define('LNG_PAGELIST_FIRST', '&#171;');
define('LNG_PAGELIST_LAST',  '&#187;');

//Меню действий.
define('LNG_MBA_SEPARATOR',         '----------------------------------------------');

define('LNG_MBA_FULLINFO',        'Full information');
define('LNG_MBA_FULLINFOSS',      'Full information + screenshot');
define('LNG_MBA_TODAY_DBREPORTS', 'Today reports');
define('LNG_MBA_WEEK_DBREPORTS',  'Reports for last 7 days');
define('LNG_MBA_FILES',           'Files');

define('LNG_MBA_REMOVE',          'Remove from database');
define('LNG_MBA_REMOVE_REPORTS',  'Remove from database including reports');

define('LNG_MBA_PORT_SOCKS',      'Check socks');
define('LNG_MBA_BACKCONNECT',     'Gateway open [BC \ VNC]');
define('LNG_MBA_PORT_VNC',        'Quick VNC');
define('LNG_MBA_NEWSCRIPT',       'Create new script');

define('LNG_BA_FULLINFO_TITLE',       'Full information about bots');
define('LNG_BA_FULLINFO_EMPTY',       '-- Information not founded --');
define('LNG_BA_FULLINFO_BOTID',       'Bot ID:');
define('LNG_BA_FULLINFO_BOTNET',      'Botnet:');
define('LNG_BA_FULLINFO_VERSION',     'Version:');
define('LNG_BA_FULLINFO_OS',          'OS Version:');
define('LNG_BA_FULLINFO_OSLANG',      'OS Language:');
define('LNG_BA_FULLINFO_TIMEBIAS',    'GMT:');
define('LNG_BA_FULLINFO_COUNTRY',     'Country:');
define('LNG_BA_FULLINFO_IPV4',        'IPv4:');
define('LNG_BA_FULLINFO_LATENCY',     'Latency:');
define('LNG_BA_FULLINFO_TCPPORT_S1',  'Socks/LC port:');
define('LNG_BA_FULLINFO_TFIRST',      'Time of first report:');
define('LNG_BA_FULLINFO_TLAST',       'Time of last report:');
define('LNG_BA_FULLINFO_TONLINE',     'Online time:');
define('LNG_BA_FULLINFO_NEW',         'In the list of new bots:');
define('LNG_BA_FULLINFO_USED',        'In the list of used:');
define('LNG_BA_FULLINFO_COMMENT',     'Comment:');
define('LNG_BA_FULLINFO_SCREENSHOT',  'Screenshot:');
define('LNG_BA_FULLINFO_ACTION_SAVE', 'Save');

define('LNG_BA_REMOVE_TITLE',    'Removing bots from database');
define('LNG_BA_REMOVE_Q1',       'You really want to remove %u bots from database?');
define('LNG_BA_REMOVE_Q2',       'You really want to remove %u bots from database, including reports?');
define('LNG_BA_REMOVE_ABORTED',  'Removing aborted by user.');
define('LNG_BA_REMOVE_REMOVED',  'Removed %u rows.');
define('LNG_BA_REMOVE_FREMOVED', 'Removed.');
define('LNG_BA_REMOVE_FERROR',   'ERROR.');

define('LNG_BA_PORT_SOCKS_TITLE',    'Check socks');
define('LNG_BA_PORT_VNC_TITLE',      'Check vnc');
define('LNG_BA_PORT_SOCKS_CHECKING', 'CHECKING...');
define('LNG_BA_PORT_SOCKS_SUCCESS',  'SUCCESSFULLY.');
define('LNG_BA_PORT_SOCKS_FAILED',   'FAILED.');
define('LNG_BA_PORT_SOCKS_ERROR',    'ERROR!');
define('LNG_BA_BACKCONNECT_TITLE',   'Quick BC');
define('LNG_BA_BACKCONNECT_SUCCESS', 'SUCCESS');
define('LNG_BA_BACKCONNECT_FAILED',  'FAILED');

//Информация.
define('LNG_INFO',          '');
define('LNG_INFO_USERNAME', '');
define('LNG_INFO_DATE',     '');
define('LNG_INFO_TIME',     '');

//Главное меню.
define('LNG_MM_STATS',          '');
define('LNG_MM_STATS_MAIN',     '');
define('LNG_MM_STATS_OS',       '');

define('LNG_MM_BOTNET',         '');
define('LNG_MM_BOTNET_BOTS',    '');
define('LNG_MM_BOTNET_SCRIPTS', '');

define('LNG_MM_REPORTS',        '');
define('LNG_MM_REPORTS_DB',     '');
define('LNG_MM_REPORTS_FILES',  '');
define('LNG_MM_REPORTS_JN',     '');

define('LNG_MM_SYSTEM',         '');
define('LNG_MM_SYSTEM_INFO',    '');
define('LNG_MM_SYSTEM_OPTIONS', '');
define('LNG_MM_SYSTEM_USER',    '');
define('LNG_MM_SYSTEM_USERS',   '');

define('LNG_MM_LOGOUT',         '');

define('LNG_DIV_HISTORY_PAID',     'Crypt');

//Типы отчетов.
define('LNG_BLT_UNKNOWN',               'Unknown report');
define('LNG_BLT_COOKIES',               'Cookies of browsers');
define('LNG_BLT_FILE',                  'File');
define('LNG_BLT_HTTPX_REQUEST',         'HTTP + HTTPS request');
define('LNG_BLT_HTTP_REQUEST',          'HTTP request');
define('LNG_BLT_HTTPS_REQUEST',         'HTTPS request');
define('LNG_BLT_REQUEST_WITH_CC',       'Bank card hunter');
define('LNG_BLT_CMDPARSER',             'CMD Parser');
define('LNG_BLT_KEYLOGGER',             'Keylogger for process');
define('LNG_BLT_LOGIN_FTP',             'FTP login');
define('LNG_BLT_LOGIN_POP3',            'POP3 login');
define('LNG_BLT_GRABBED_X',             'All grabbed data');
define('LNG_BLT_GRABBED_UI',            'Grabbed data [UI]');
define('LNG_BLT_GRABBED_HTTP',          'Grabbed data [HTTP(S)]');
define('LNG_BLT_GRABBED_WSOCKET',       'Grabbed data [WinSocket]');
define('LNG_BLT_GRABBED_FTPSOFTWARE',   'Grabbed data [FTP client]');
define('LNG_BLT_GRABBED_EMAILSOFTWARE', 'Grabbed data [E-mail]');
define('LNG_BLT_GRABBED_OTHER',         'Grabbed data [Other]');
?>