<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Fragus</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">

<link href="style.css" rel="stylesheet" type="text/css">
<center>
<style>
		BODY
 {
			background-color: black;
			font-family: Trebuchet MS, Verdana, Arial;
			color: white;
			font-size: 12px;
			background: black url('./images/bg1.png');
		}
		TD {
			font-family: Trebuchet MS, Verdana, Arial;
			color: white;
			font-size: 15px;
		}
		INPUT, TEXTAREA, SELECT {
			font-family: Trebuchet MS, Verdana, Arial;
			font-size: 12px;
			width: 180px;
		}
		A:link, A:visited, A:active {
			text-decoration: underline;
			color: white;
		}
		A:hover {
			color: #e3e3e3;
			text-decoration: none;
		}
		H1 {
			color: white;
			font-size: 18px;
		}
		</style>
	</head>
	<body>
	<div class="background"><div class="transbox">	<br>
		<center>
		<center><table width="911" cellpadding="0" cellspacing="0" height="95">
			<tr>
				<td width="118"><a href="<?php echo $_SERVER['PHP_SELF']; ?>"></a></td>
				<td align="right" valign="bottom">
					&nbsp;
				</td>
			</tr>
		</table>

		<br><br>
		<table width="400" cellpadding="0" cellspacing="0">
		<tr>
			<td width="24"><img src="./images/tl.png" width="24" height="27"></td>
			<td background="./images/tc.png">&nbsp;</td>
			<td width="24"><img src="./images/tr.png" width="24" height="27"></td>
		</tr>
		<tr>
			<td background="./images/lc.png">&nbsp;</td>
			<td background="./images/cbg.png">
				<h1>Administracion</h1>
				
					<?php
					if (isset($_Errors['FailsLogin'])){
					?>
					<b style="color: red;">Invalid login or password</b><br><br>
					<?php
					}
					?>
					<form method="post" id="auth" action="<?php echo $_SERVER['PHP_SELF']; ?>">
					<input type="hidden" name="auth" value="1">
					<table cellpadding="0" cellspacing="0">
					<tr>
						<td height="35" width="80">Login:</td>
						<td><input type="text" id="login" name="login"<?php echo isset($_POST['login']) ? " value=\"" . trim(htmlspecialchars($_POST['login'])) . "\"" : ""; ?>></td>
					</tr>
					<tr>
						<td height="35">Password:</td>
						<td><input type="password" name="password"></td>
					</tr>
					<tr>
						<td height="35"></td>
											</tr>
					</table>
					<input type="image" src="./images/button.png" style="width: 160px; height: 25px; margin-left: 35px; margin-bottom: -20px; margin-top: 20px;"><a href="javascript:document.getElementById('auth').submit();" style="color: white; text-decoration: none; font-weight: bold; position: relative; top: 12px; left: -95px; font-size: 12px;">Login</a>
					</form>
				</center>
				<script language="JavaScript">
				document.onload = document.getElementById('login').focus();
				</script>
			</td>
			<td background="./images/rc.png">&nbsp;</td>
		</tr>
		<tr>
			<td width="24"><img src="./images/bl.png" width="24" height="27"></td>
			<td background="./images/bc.png">&nbsp;</td>
			<td width="24"><img src="./images/br.png" width="24" height="27"></td>
		</tr>
		</table>
	</center>
 <div class="background">
<div id="wb_Text1" style="margin:0;padding:0;position:absolute;left:680px;top:83px;width:397px;height:103px;text-align:left;z-index:1;">
<font style="font-size:50px" color="#ffffff" face="Impact">Fragus</font></div>
<div id="" style="margin:0;padding:0;position:absolute;left:740px;top:143px;width:397px;height:103px;text-align:left;z-index:1;">
<font style="font-size:13px" color="#ffffff" face="Arial">Black Edition</font></div>
</body>
</html>