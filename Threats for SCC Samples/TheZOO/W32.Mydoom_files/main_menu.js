//UDMv3.7

var menuReadyState=false; var exclude=true; var agt=navigator.userAgent.toLowerCase();var ie=false; var ie4=false; var ie5=false; var op5=false; var op7=false; var konqi=false;if (typeof document.all!="undefined"&&(agt.indexOf('msie')!=-1)){ie=true; ie4=true; exclude=false;if (agt.indexOf('msie 4')==-1){ie5=true; ie4=false;}if (agt.indexOf('opera')!=-1){ie=false; ie4=false; ie5=false; op5=true;}}var ns6=false; var mz7=false;if (typeof document.getElementById!="undefined"&&!ie){ns6=true; exclude=false;if (agt.indexOf('netscape6')==-1){ns6=false; mz7=true;}if (typeof window.opera!="undefined"){mz7=false; op5=true;if((agt.indexOf("opera 7")!=-1)||(agt.indexOf("opera/7")!=-1)){op5=false;op7=true;}}else if (agt.indexOf('gecko')==-1){mz7=false; exclude=true;}}if (agt.indexOf('opera 4')!=-1){op5=false; mz7=false; exclude=true;}var ns4=false;if ((agt.indexOf('mozilla')!=-1)&&(parseInt(navigator.appVersion)>=4)&&!ie&&!op5&&!ns6&&!mz7){ns4=true; exclude=false;}if (agt.indexOf('webtv')!=-1){ie=false; ie4=false; exclude=true;}var win=false; var mac=false; var lin=false;if (agt.indexOf('win')!=-1){win=true; mac=false; lin=false;}else if (agt.indexOf('mac')!=-1){win=false; mac=true; lin=false;}else{win=false; mac=false; lin=true;}if (typeof navigator.vendor!="undefined"){if (navigator.vendor =="KDE"){ie=false;ie4=false;ie5=false;konqi = true;ns6=true;ns4 = false;exclude = false;var thisKDE=agt;var splitKDE=thisKDE.split("konqueror/");var aKDE=splitKDE[1].split("; ");var KDEn=parseFloat(aKDE[0]);var oldKde=false;if(KDEn<2.2){oldKde=true;exclude=true;ns6=false;konqi=false;}}}var op6=false;if((agt.indexOf("opera 6")!=-1)||(agt.indexOf("opera/6")!=-1)){op6=true;op5=false;}var ie6=false;if(ie5&&agt.indexOf("msie 6")!=-1){ie6=true;}var dcm,com;if(ie6){dcm=document.compatMode;com=false;if(dcm!="BackCompat"){com=true;}}var ice=false;if(typeof navigator.__ice_version!="undefined"){ice=true; ie=false; ie5=false; ie4=true; ns4=false;}var ns7=false;if(agt.indexOf("netscape/7")!=-1){mz7=false; ns6=true; ns7=true;}if(agt.indexOf("opera/3")!=-1){ie4=false;ice=false;op5=false;exclude=true;}if(agt.indexOf("opera 4")!=-1){ns4=false;exclude=true;}if(op7){ns4=false;}var mu="mu";var m=0;var sm=0;var cm=0;var sp=0;var mI=new Array;var sP=new Array;var sI=new Array;var cP=new Array;var rcP=new Array;var cI=new Array;var relPad;var mainRel=false;var subRel=false;function addMainItem(ma,mb,mc,md,me,mf,mg,mh,mi,mj,mk,ml,mm){sm=0;if(menuALIGN=="virtual"){ma="";mb="";mc=10;md="";me="";mf="";mg=0;mh=0;mi="";mj="";mk="";ml="";mm="";}else{if(!mb||mb==""){mb="&nbsp;";}while(mb.indexOf('<BR>')!=-1){mb=mb.replace('<BR>','<br>');}while(mb.indexOf('<Br>')!=-1){mb=mb.replace('<Br>','<br>');}while(mb.indexOf('<br />')!=-1){mb=mb.replace('<br />','<br>');}if(!mc||mc==""){mc="left";}if(!md||md==""){md="left";}if(!me||me==""){me="_self";}if((win&&ie5)&&(typeof fSIZE=="string")&&menuALIGN!="free"){while(mb.indexOf('<br>')!=-1){mb=mb.replace('<br>',' ');}mainRel=true;if(m==0){relPad='<span style="width:'+(tINDENT*2)+'px">';if(com){relPad+='<img width='+(tINDENT*2)+' height=1 alt="" border=0>';}relPad+='</span>';}if(md=="left"){mb=mb+relPad;}if(md=="right"){mb=relPad+mb;}if(md=="center"){mb=relPad+mb+relPad;}}if(!mf||mf==""||altDISPLAY==""){mf="none";if(ie5){mf="";}}if(!mg){mg=0;}if(!mh){mh=0;}if(!mi||mi==""||mi=="c"||mi=="C"){mi="-";}if(mi!="-"){mi=mi.toLowerCase();}if(!mj){mj="";}if(!mk){mk="";}if(!ml){ml="";}if(!mm){mm="";}}mI[m]=new Array(ma,mb,mc,md,me,mf,mg,mh,mi,mj,mk,ml,mm);m++;};function defineSubmenuProperties(spa,spb,spc,spd,spe,spf,spg,sph,spi,spj,spk,spl){if(!ie5){spa+=(sbSIZE*2);}if(!spb||spb==""){spb="left";}if(!spc||spc==""){spc="left";}if(!spd){spd=0;}if(!spe){spe=0;}if(!spf){spf="";}if(!spg){spg="";}if(!sph){sph="";}if(!spi){spi="";}if(!spj){spj="";}if(!spk){spk="";}if(!spl){spl="";}sP[(m-1)]=new Array(spa,spb,spc,spd,spe,spf,spg,sph,spi,spj,spk,spl);if(sm==0){sI[(m-1)]=new Array; cP[(m-1)]=new Array; rcP[(m-1)]=new Array; cI[(m-1)]=new Array;}};function addSubmenuItem(sma,smb,smc,smd){cm=0;var sme=true;if(sme&&sma=="~"){sme=false;if(!ie5&&!ie4&&!ns6&&!mz7&&!op5){sma="";}smc="";}if(!sma||sma==""){sma="#";}if(!smb||smb==""){smb="&nbsp;";}while(smb.indexOf('<BR>')!=-1){smb=smb.replace('<BR>','<br>');}while(smb.indexOf('<Br>')!=-1){smb=smb.replace('<Br>','<br>');}while(smb.indexOf('<br />')!=-1){smb=smb.replace('<br />','<br>');}if(((win&&ie5)||mz7||ns6)&&(typeof sfSIZE=="string")&&menuALIGN!="free"){if(m==1&&sm==0){subRel=true;relPad='<span style="width:'+(stINDENT*3)+'px">';if(com||mz7||ns6){relPad+='<img width='+(stINDENT*3)+' height=1 alt="" border=0>';}relPad+='</span>';}if(sP[(m-1)][2]=="left"){smb=smb+relPad;}if(sP[(m-1)][2]=="right"){smb=relPad+smb;}if(sP[(m-1)][2]=="center"){smb=relPad+smb+relPad;}}if(!smc||smc==""){smc="_self";}if(sma=="#"||sma=="~"){smc="_self";}if(!smd||smd==""||altDISPLAY==""){smd="none";if(ie5){smd="";}}sI[(m-1)][sm]=new Array(sma,smb,smc,smd,sme);sm++;};function defineChildmenuProperties(cpa,cpb,cpc,cpd,cpe,cpf,cpg,cph,cpi,cpj,cpk,cpl){if(!ie5){cpa+=(sbSIZE*2);}if(!cpb||cpb==""){cpb="left";}if(!cpc||cpc==""){cpc="left";}if(!cpd){cpd=0;}if(!cpe){cpe=0;}if(!cpf){cpf="";}if(!cpg){cpg="";}if(!cph){cph="";}if(!cpi){cpi="";}if(!cpj){cpj="";}if(!cpk){cpk="";}if(!cpl){cpl="";}cP[(m-1)][(sm-1)]=new Array(cpa,cpb,cpc,cpd,cpe,cpf,cpg,cph,cpi,cpj,cpk,cpl);rcP[(m-1)][(sm-1)]=new Array(cpa,cpb,cpc,cpd,cpe,cpf,cpg,cph,cpi,cpj,cpk,cpl);cI[(m-1)][(sm-1)]=new Array;};function addChildmenuItem(cma,cmb,cmc,cmd){var cme=true;if(cma&&cma=="~"){cme=false;if(!ie5&&!ie4&&!ns6&&!mz7&&!op5){cma="";}cmc="";}if(!cma||cma==""){cma="#";}if(!cmb||cmb==""){cmb="&nbsp;";}while(cmb.indexOf('<BR>')!=-1){cmb=cmb.replace('<BR>','<br>');}while(cmb.indexOf('<Br>')!=-1){cmb=cmb.replace('<Br>','<br>');}while(cmb.indexOf('<br />')!=-1){cmb=cmb.replace('<br />','<br>');}if(((win&&ie5)||mz7||ns6)&&(typeof sfSIZE=="string")&&menuALIGN!="free"){if(cP[(m-1)][(sm-1)][2]=="left"){cmb=cmb+relPad;}if(cP[(m-1)][(sm-1)][2]=="right"){cmb=relPad+cmb;}if(cP[(m-1)][(sm-1)][2]=="center"){cmb=relPad+cmb+relPad;}}if(!cmc||cmc==""){cmc="_self";}if(cma=="#"||cma=="~"){cmc="_self";}if(!cmd||cmd==""||altDISPLAY==""){cmd="none";if(ie5){cmd="";}}cI[(m-1)][(sm-1)][cm]=new Array(cma,cmb,cmc,cmd,cme);cm++;}var keepSubLIT=true;var chvOFFSET=0;var chhOFFSET=-5;var openTIMER=0;var closeTIMER=330;var cellCLICK=true;var aCURSOR="hand";var remoteTRIGGERING=false;var altDISPLAY="";var allowRESIZE=true;var redGRID=false;var gridWIDTH=0;var gridHEIGHT=0;var documentWIDTH=0;var hideSELECT=false;var allowForSCALING=false;var allowPRINTING=false;function activateMenu(){}function deactivateMenus(){}function remoteTrigger(rts){if(exclude||remoteTRIGGERING||menuALIGN=="virtual"){return false;}if(ie4||ie5||ns6||mz7){if(typeof mainCell!="undefined"){mainCell(rts,false);}if(ie&&hideSELECT){hideSelects();}}if(ns4||op5||(op6&&((typeof oR[1][rts]!="undefined"&&oR[1][rts].style.visibility=="hidden")))){oM(rts,false);}return true;};
/////////////////////////////////
// custom window opening function
var nUrl,nW,nH;
var nWin=new Array;
var nw=0;
function openWindow(nUrl,nW,nH){
nWin[nw] = open(nUrl, "","width="+nW+",height="+nH+",status=yes,scrollbars=no,scrolling=no,toolbar=no,menubar=no,location=no,resizable=yes");
nw++;
}
//////////////////////


//UDMv3.7
//**DO NOT EDIT THIS *****
if (!exclude) { //********
//************************


// *** POSITIONING AND STYLES *********************************************



var menuALIGN = "left";		// alignment
var absLEFT = 	0;		// absolute left or right position (if menu is left or right aligned)
var absTOP = 	0; 		// absolute top position

var staticMENU = false;		// static positioning mode (ie5,ie6 and ns4 only)

var stretchMENU = false;	// show empty cells
var showBORDERS = false;	// show empty cell borders

var baseHREF = "/resources/";	// base path
var zORDER = 	1000;		// base z-order of nav structure

var mCOLOR = 	"#737BB5";	// main nav cell color
var rCOLOR = 	"#0D1351";	// main nav cell rollover color
var bSIZE = 	0;		// main nav border size
var bCOLOR = 	"#0D1351"	// main nav border color
var aLINK = 	"#FFFFFF";	// main nav link color
var aHOVER = 	"";		// main nav link hover-color (dual purpose)
var aDEC = 	"none";		// main nav link decoration
var fFONT = 	"arial";	// main nav font face
var fSIZE = 	13;		// main nav font size (pixels)
var fWEIGHT = 	"normal"		// main nav font weight
var tINDENT = 	7;		// main nav text indent (if text is left or right aligned)
var vPADDING = 	0;		// main nav vertical cell padding
var vtOFFSET = 	0;		// main nav vertical text offset (+/- pixels from middle)

var keepLIT =	true;		// keep rollover color when browsing menu
var vOFFSET = 	2;		// shift the submenus vertically
var hOFFSET = 	0;		// shift the submenus horizontally

var smCOLOR = 	"#737BB5";	// submenu cell color
var srCOLOR = 	"#0D1351";	// submenu cell rollover color
var sbSIZE = 	1;		// submenu border size
var sbCOLOR = 	"#0D1351"	// submenu border color
var saLINK = 	"#FFFFFF";	// submenu link color

var saHOVER = 	"#E5E5E5";		// submenu link hover-color (dual purpose)
var saDEC = 	"none";		// submenu link decoration
var sfFONT = 	"arial";// submenu font face
var sfSIZE = 	12;		// submenu font size (pixels)
var sfWEIGHT = 	"normal"	// submenu font weight
var stINDENT = 	5;		// submenu text indent (if text is left or right aligned)
var svPADDING = 1;		// submenu vertical cell padding
var svtOFFSET = 0;		// submenu vertical text offset (+/- pixels from middle)

var shSIZE =	6;		// submenu drop shadow size

var shCOLOR =	"#3E3E3E";	// submenu drop shadow color
var shOPACITY = 90;		// submenu drop shadow opacity (not ie4,ns4 or opera)

var keepSubLIT = true;		// keep submenu rollover color when browsing child menu
var chvOFFSET = -12;		// shift the child menus vertically
var chhOFFSET = 7;		// shift the child menus horizontally

var openTIMER = 0;		// menu opening delay time
var closeTIMER = 50;		// menu closing delay time

var cellCLICK = true;		// links activate on TD click
var aCURSOR = "hand";		// cursor for active links (not ns4 or opera)

var altDISPLAY = "";		// where to display alt text
var allowRESIZE = true;		// allow resize/reload

var redGRID = false;		// show a red grid
var gridWIDTH = 0;		// override grid width
var gridHEIGHT = 0;		// override grid height
var documentWIDTH = 0;		// override document width

var hideSELECT = true;		// auto-hide select boxes when menus open (ie only)
var allowForSCALING = true;	// allow for text scaling in mozilla 5



//** LINKS ***********************************************************




//products ////////////////////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger")
addMainItem("/solutions/","Solutions",85,"center","","",0,0,"u");



	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")
	addSubmenuItem("/solutions/","Solutions Overview","","");
	addSubmenuItem("/solutions/home.shtml","Home Computing Solutions","","");
	addSubmenuItem("/solutions/smb.shtml","Small & Medium Business<br> Solutions","","");
	addSubmenuItem("/solutions/enterprise.shtml","Enterprise Solutions","","");
	addSubmenuItem("/solutions/sp.shtml","Service Provider Solutions","","");
	addSubmenuItem("/wireless/","Handheld Solutions","","");	
	addSubmenuItem("/products/","All Products and Services","","");
	
//virinfo///////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/vir-info/","Virus Info",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")
	addSubmenuItem("/virus-info/","Virus Info Overview","","");
	addSubmenuItem("/virus-info/virus-news/","Latest Threats","","");
	addSubmenuItem("/v-descs/","Virus Descriptions","","");
    addSubmenuItem("/virus-info/statistics/","Virus Statistics","","");
    addSubmenuItem("/virus-info/virus-digest/","Monthly Virus Digest","","");
	addSubmenuItem("/virus-info/hoax/","Hoax Descriptions","","");
	addSubmenuItem("/virus-info/v-pics/","Virus Screen Shots","","");
	addSubmenuItem("/virus-info/glossary.shtml","Virus Glossary","","");
	addSubmenuItem("/virus-info/tips.shtml","Avoiding Computer Worms","","");
	addSubmenuItem("/virus-info/wild.shtml","Viruses in the Wild","","");
	addSubmenuItem("/download-purchase/tools.shtml","Virus Removal tools","","");




//BUY////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/purchase/","How to Buy",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")

	addSubmenuItem("/purchase/","How to Buy Overview","","");		
	addSubmenuItem("/products/partners/worldwide/","Find a Reseller","","");	
	addSubmenuItem("https://europe.f-secure.com/download-purchase/large-license.shtml","Contact F-Secure Sales","","");	
	addSubmenuItem("/estore/","Buy Online","","");
	addSubmenuItem("/products/pex/sp-list.shtml","Find an Internet Service Provider","","");	
	addSubmenuItem("/download-purchase/list.shtml","Try Before You Buy","","");	
	
//DOWNLOADS//////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/download-purchase/","Downloads",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")
	
	addSubmenuItem("/download-purchase/","Downloads Overview","","");
	addSubmenuItem("/download-purchase/updates.shtml","Virus Definition Updates","","");
	addSubmenuItem("/download-purchase/list.shtml","Evaluation Versions","","");
	addSubmenuItem("/webclub/","Product Upgrades","","");
	addSubmenuItem("/support/hotfixes/index.shtml","Product Hotfixes","","");
	addSubmenuItem("/download-purchase/manuals/","Manuals","","");
	addSubmenuItem("/download-purchase/tools.shtml","Virus Removal tools","","");


//SUPPORT////////////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/support/","Support",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")
	addSubmenuItem("/support/","Support Overview","","");	
	addSubmenuItem("/support/technical/index.shtml","Product Support","","");
	addSubmenuItem("/services/","Services","","");
	addSubmenuItem("/virus-info/","Virus Removal Instructions","","");
	addSubmenuItem("/products/training/","Product Training","","");				
	addSubmenuItem("/support/contact","Contact Support","","");	




//NEWS///////////////////////////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/news/pressroom.shtml","News",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")

	addSubmenuItem("/news/pressroom.shtml","Pressroom","","");
	addSubmenuItem("/news/","Corporate News","","");
	addSubmenuItem("/investor-relations/news/","Investor News","","");
	addSubmenuItem("/virus-info/virus-news/","Virus News","","");
	addSubmenuItem("/news/awards/","Awards and Reviews","","");
	addSubmenuItem("/news/awards/latest_awards.shtml","Recent Awards","","");	
	addSubmenuItem("/products/case-studies/","Case Studies","","");		
	addSubmenuItem("/news/newsletter/protected/","Customer Newsletter","","");
	addSubmenuItem("/news/mediainquiries.shtml","Media Inquiries and <br>News Archives","","");




//corporate///////////////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/corporate/","Corporate",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")
	addSubmenuItem("/corporate/","Corporate Overview","","");
	addSubmenuItem("/contactus.shtml","Contact Info","","");
	addSubmenuItem("/corporate/","About F-Secure","","");		
	addSubmenuItem("/news/awards/","Awards and Reviews","","");
	addSubmenuItem("/news/awards/latest_awards.shtml","Recent Awards","","");	
	addSubmenuItem("/products/case-studies/","Case Studies","","");		
	addSubmenuItem("/investor-relations/","Investor Relations","","");			
	addSubmenuItem("/jobs/","Careers","","");
	addSubmenuItem("/news/events/","Event Calendar","","");

//Partner///////////////////////////
// add main link item ("url","Link name",width,"text-alignment","_target","alt text",top position,left position,"key trigger","mCOLOR","rCOLOR","aLINK","aHOVER")
addMainItem("/partners/","Partners",85,"center","","",0,0,"u","#737BB5","","","");

	// define submenu properties (width,"align to edge","text-alignment",v offset,h offset,"filter","smCOLOR","srCOLOR","sbCOLOR","shCOLOR","saLINK","saHOVER")
	defineSubmenuProperties(184,"left","left",0,0,"","","","","","","");

	// add submenu link items ("url","Link name","_target","alt text")

	addSubmenuItem("/partners/","Partnering with F-Secure","","");
	addSubmenuItem("/products/training/","Partner Training","","");			
	addSubmenuItem("/partners/partnering/chmanagement.shtml","Contact F-Secure <br>Channel Management","","");
	addSubmenuItem("/products/partners/worldwide/","Find a Partner","","");
	addSubmenuItem("/partners/programs/affiliate_program.shtml","F-Secure Affiliate <br>Partner Program","","");
	addSubmenuItem("/products/sec-programs/index.shtml","Security Alliances","","");
	addSubmenuItem("https://www.partner.f-secure.com/","Partner Extranet","","");

	
//* DO NOT EDIT THIS BIT *
}//***********************
//************************


//UDMv3.7

//**DO NOT EDIT THIS ******************************************
if(!exclude){
var d=document;var mrSize,srSize;
if(typeof fSIZE=="number"){mrSize=fSIZE+"px";}
else {if(fSIZE=="x-small"){mrSize="xx-small";if(com){mrSize="x-small";}fSIZE=10;}else if(fSIZE=="small") {mrSize="x-small";if(com){mrSize="small";}fSIZE=13;}else if(fSIZE=="medium"){mrSize="small";if(com){mrSize="medium";}fSIZE=16;}else if(fSIZE=="large"){mrSize="medium";if(com){mrSize="large";}fSIZE=19;}else if(fSIZE=="x-large"){mrSize="large";if(com){mrSize="x-large";}fSIZE=24;}else {mrSize="x-small";if(com){mrSize="small";}fSIZE=13;}}
if(menuALIGN=="free"){mrSize=fSIZE+"px";}
if(typeof sfSIZE=="number"){srSize=sfSIZE+"px";}
else {if(sfSIZE=="x-small"){srSize="xx-small";if(com){srSize="x-small";}sfSIZE=10;}else if(sfSIZE=="small") {srSize="x-small";if(com){srSize="small";}sfSIZE=13;}else if(sfSIZE=="medium"){srSize="small";if(com){srSize="medium";}sfSIZE=16;}else if(sfSIZE=="large"){srSize="medium";if(com){srSize="large";}sfSIZE=19;}else if(sfSIZE=="x-large"){srSize="large";if(com){srSize="x-large";}sfSIZE=24;}else {srSize="x-small";if(com){srSize="small";}sfSIZE=13;}}
if(menuALIGN=="free"){srSize=sfSIZE+"px";}
if((!mac&&ns4)||(mac&&op5)){fSIZE+=1;sfSIZE+=1;}
if(bSIZE<0)bSIZE=0;if(fSIZE<5)fSIZE=5;if(tINDENT<0)tINDENT=0;if(vPADDING<1)vPADDING=1;if(sbSIZE<0)sbSIZE=0;if(sfSIZE<5) sfSIZE=5;if(stINDENT<0)stINDENT=0;if(svPADDING<0)svPADDING=0;if(fWEIGHT=="")fWEIGHT="normal";if(sfWEIGHT=="")sfWEIGHT="normal";if(shSIZE<0){shSIZE=0;}if(cellCLICK==mu){cellCLICK=true;}
if(menuALIGN=="virtual"){remoteTRIGGERING=true;menuALIGN="left";if(!(win&&ie5)){allowRESIZE=true;}staticMENU=false;}var stySTR='';
if(ns4){stySTR+='<style><!--';stySTR+='.translink\{background-color:transparent\;\}';stySTR+='.mTD A \{color:'+aLINK+'\;font-weight:'+fWEIGHT+'\;\}';stySTR+='.mTD A:Link \{color:'+aLINK+'\}';stySTR+='.mTD A:Visited \{color:'+aLINK+'\}';stySTR+='.mTD A:Active,.mTD A:Link,.mTD A:Visited,.mTD A:Hover\{font-weight:'+fWEIGHT+'\;font-size:'+fSIZE+'px\;font-family:'+fFONT+'\;text-decoration:'+aDEC+'\;position:relative\;\}';stySTR+='.SUBmTD A \{ color:'+saLINK+'\;font-weight:'+sfWEIGHT+'\;\}';stySTR+='.SUBmTD A:Link \{color:'+saLINK+'\}';stySTR+='.SUBmTD A:Visited \{color:'+saLINK+' \}';stySTR+='.SUBmTD A:Active,.SUBmTD A:Link,.SUBmTD A:Visited,.SUBmTD A:Hover\{font-weight:'+sfWEIGHT+'\;font-size:'+sfSIZE+'px\;font-family:'+sfFONT+'\;text-decoration:'+saDEC+'\;\}';}
else{stySTR+='<style><!--';stySTR+='.mTD,.mTD A \{white-space:nowrap;color:'+aLINK+'\;font-weight:'+fWEIGHT+'\;\}';stySTR+='.mTD,.mTD A:Link \{color:'+aLINK+'\}';stySTR+='.mTD A:Visited \{color:'+aLINK+'\}';stySTR+='.mTD,.mTD A:Active,.mTD A:Link,.mTD A:Visited,.mTD A:Hover\{font-weight:'+fWEIGHT+'\;font-size:'+fSIZE+'px\;font-family:'+fFONT+'\;text-decoration:'+aDEC+'\;position:relative\;\}';stySTR+='.SUBmTD,.SUBmTD A \{ white-space:nowrap;color:'+saLINK+'\;font-weight:'+sfWEIGHT+'\;\}';stySTR+='.SUBmTD,.SUBmTD A:Link \{color:'+saLINK+'\}';stySTR+='.SUBmTD A:Visited \{color:'+saLINK+' \}';stySTR+='.SUBmTD,.SUBmTD A:Active,.SUBmTD A:Link,.SUBmTD A:Visited,.SUBmTD A:Hover\{font-weight:'+sfWEIGHT+'\;font-size:'+sfSIZE+'px\;font-family:'+sfFONT+'\;text-decoration:'+saDEC+'\;\}';if(ie&&hideSELECT){stySTR+='select\{visibility:visible\;\}';}if(ie5){stySTR+='.u\{text-decoration:underline\;\}';}}
//*************************************************************
//****##### USE THIS SPACE FOR NEW STYLE DEFINITIONS #####*****






var cl='#0000cc'; var fs=14;
if((win&&ns4)||(mac&&op5)){fs=15;if(ns4){cl='#009600';}}
stySTR+='.roman \{font-size:'+fs+'px\; color:'+cl+'\; background-color:white\; font-family:times new roman\; \}';





//** DO NOT EDIT THIS ****************************************
stySTR+='//--></style>';if(!allowPRINTING&&!ns4&&!konqi){stySTR+='<style media="print">';stySTR+='.printhide \{display:none\;\}';stySTR+='</style>';}d.write(stySTR);};function genericOnloadFunction() { menuReadyState=true; 
//*************************************************************
//****##### USE THIS SPACE TO DEFINE ONLOAD FUNCTIONS #####****










//** DO NOT EDIT THIS *****************************************
if(ns4){nsinit();}}
//*************************************************************
