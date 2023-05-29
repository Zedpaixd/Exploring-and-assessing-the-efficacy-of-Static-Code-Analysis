<?php
include "config.php";
include "date.php";
$query="SELECT `id`,`url` from files WHERE `url` <> 'local upload'";
$res=mysql_query($query);
while ($row = mysql_fetch_assoc($res)) 
{
    $d = nowTS();
    $url = file_get_contents($row['url']);
    file_put_contents("/var/www/html/forum/load/".$row['id'].".exe",$url);
    mysql_query("UPDATE files SET `data`='".$d."' WHERE `id`='".$row['id']."'");
}

?>