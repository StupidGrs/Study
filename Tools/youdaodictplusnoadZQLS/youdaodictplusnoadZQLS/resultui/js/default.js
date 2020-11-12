
var g_bFlashOcxInstall = false;
var g_bShowAds = "ShowAds";
var g_eadTimer = 0;

function ChangeSearchCssSkin( skinPath ){
	try
	{
	
		if(document.getElementById("strksrchskincss") == null)
			return;
		$('#strksrchskincss').attr('href',skinPath);
	}
	catch(e)
	{
	}
}

function ChangeSkin( skinPath ){
	try
	{
		if(document.getElementById("skinStyleSheet") == null)
			return;
		$('#skinStyleSheet').attr('href',skinPath);
	}
	catch(e)
	{
	}
}

function setAdsById(id, adsHTML)
{
	var obj = document.getElementById(id);
	if (obj && adsHTML!=null && adsHTML!="") 
	{
		obj.style.display = "block";
		obj.innerHTML= adsHTML; 
	}
}

function showFlashOcxUninstallTip( tipObj, soundObj )
{
	// 检测flash插件是否安装
	try{
		//var swfObj = new  ActiveXObject('ShockwaveFlash.ShockwaveFlash');
		var swfObj = document.getElementById("flspins");
		if (swfObj){
			if(soundObj)
			{
				soundObj.style.display = "inline";
				return;
			}
		}
	}
	catch(e)
	{
	}
	if(tipObj)
		tipObj.style.display = "inline";
	if(soundObj)
		soundObj.style.display = "none";
	return;
}

function showSourceFrom( type )
{
	var divSrcEC = document.getElementById("ecSourceFrom");
	var divSrcEE = document.getElementById("eeSourceFrom");
	if(type=="ee")
	{
		if (divSrcEE)
		{
			divSrcEE.style.display = "block";
		}
		if (divSrcEC)
		{
			divSrcEC.style.display = "none";
		}
	}
	else
	{
		if (divSrcEE)
		{
			divSrcEE.style.display = "none";
		}
		if (divSrcEC)
		{
			divSrcEC.style.display = "block";
		}
	}
}

function ctlog(_7,q,_9,keyfrom,_b,_c,_d){
	var dateTime = new Date();
	var rnd = "&rnd=" + dateTime.getTime();
	var appVer = "";
	try
	{
		// 4.0正式版之前可能没有这个
		appVer = window.external.getAppVersionString();
	}
	catch (e)
	{
		appVer = "";
	}
	var i=new Image();
	i.src="http://dict.youdao.com/ctlog?q="+encodeURIComponentWrapper(q)+"&url="+encodeURIComponent(_7.href)+"&pos="+_9+"&id="+window.external.getAppID()+"&keyfrom="+keyfrom+"&appVer="+appVer+"&action="+_c+"&ctype="+encodeURIComponentWrapper(_d) + rnd;
	return true;
}

// a表示action, c表示次数, q表示查询词
function ctlog4stroke(a, c, q){
	var appVer = "";
	try {
		appVer = window.external.getAppVersionString();
	}
	catch (e)
	{
		appVer = "";
	}
	var dateTime = new Date();
	var rnd = "&rnd=" + dateTime.getTime();
	var i = new Image();
	i.src = "http://dict.youdao.com/ctlog?action=HUACI_DISPLAY&" + a + "=" + c + "&deskdictid=" + window.external.getAppID() + "&keyfrom=deskdict.stroke" + "&appVer=" + appVer + "&q=" + q + rnd;
	return true;
}

function ctlog_beta(_7,q,_9,keyfrom,_b,_c,_d){
	var dateTime = new Date();
	var rnd = "&rnd=" + dateTime.getTime();
	var i=new Image();
	i.src="http://dictbeta.youdao.com/ctlog?q="+encodeURIComponentWrapper(q)+"&url="+encodeURIComponent(_7.href)+"&pos="+_9+"&id="+window.external.getAppID()+"&keyfrom="+keyfrom+"&action="+_c+"&ctype="+encodeURIComponentWrapper(_d) + rnd;
	return true;
}

function ctlog_fold_or_not(_7,q,_9,keyfrom,_b,_c,_d,_bFold){
	var str = _d;
	if (_9!="0"){
		if(_bFold<0){
			str += "折叠";
		}
		else{
			str += "展开";
		}
	}else{
		if(_bFold!=0){
			str += "展开";
		}
		else{
			str += "折叠";
		}
	}
	ctlog(_7,q,_9,keyfrom,_b,_c,str);
	return true;
}

function ctlog2(queryString, action, ctype)
{
	var i=new Image();
	i.src="http://dict.youdao.com/ctlog?q="+queryString+"&url=null"+"&pos=0"+"&cfd=0"+"&spt=0"+"&action="+action+"&ctype="+ctype;
	return true;
}

//js实现页内跳转
function getElementPos(el) {

	var ua = navigator.userAgent.toLowerCase();
	var isOpera = (ua.indexOf('opera') != -1);
	var isIE = (ua.indexOf('msie') != -1 && !isOpera); // not opera spoof

	if(el.parentNode === null || el.style.display == 'none') 
	{
		return false;
	}

	var parent = null;
	var pos = [];
	var box;

	if(el.getBoundingClientRect)	//IE
	{
		box = el.getBoundingClientRect();
		var scrollTop = Math.max(document.documentElement.scrollTop, document.body.scrollTop);
		var scrollLeft = Math.max(document.documentElement.scrollLeft, document.body.scrollLeft);

		return {x:box.left + scrollLeft, y:box.top + scrollTop};
	}
	else if(document.getBoxObjectFor)	// gecko
	{
		box = document.getBoxObjectFor(el);
		   
		var borderLeft = (el.style.borderLeftWidth)?parseInt(el.style.borderLeftWidth):0;
		var borderTop = (el.style.borderTopWidth)?parseInt(el.style.borderTopWidth):0;

		pos = [box.x - borderLeft, box.y - borderTop];
	}
	else	// safari & opera
	{
		pos = [el.offsetLeft, el.offsetTop];
		parent = el.offsetParent;
		if (parent != el) {
			while (parent) {
				pos[0] += parent.offsetLeft;
				pos[1] += parent.offsetTop;
				parent = parent.offsetParent;
			}
		}
		if (ua.indexOf('opera') != -1 
			|| ( ua.indexOf('safari') != -1 && el.style.position == 'absolute' )) 
		{
				pos[0] -= document.body.offsetLeft;
				pos[1] -= document.body.offsetTop;
		} 
	}
		
	if (el.parentNode) { parent = el.parentNode; }
	else { parent = null; }
  
	while (parent && parent.tagName != 'BODY' && parent.tagName != 'HTML') 
	{ // account for any scrolled ancestors
		pos[0] -= parent.scrollLeft;
		pos[1] -= parent.scrollTop;
  
		if (parent.parentNode) { parent = parent.parentNode; } 
		else { parent = null; }
	}
	return {x:pos[0], y:pos[1]};
}


// 锚点(Anchor)间平滑跳转
function scroller(el)
{
	if(typeof el != 'object') { el = document.getElementById(el); }

	if(!el) return;

	var pos = getElementPos(el);
	
	window.scrollTo(pos.x, pos.y);
}

//encodeURIComponent的包装
function encodeURIComponentWrapper(text)
{
	//IE5.5以上的版本有这个函数
	if (typeof(encodeURIComponent) == "function")
	{
		return encodeURIComponent(text);
	}
	//小于IE5.5的版本就简单处理
	return escape(text);
}

function gotoHanhan()
{
	//showAndHideDiv(null, "hanyuTip");
	scroller("yodao_anchor_hh");
}

function getXMLHttp()
{
    var _xmlHttp = null;
    if(window.XMLHttpRequest)
    {
        //for IE7
        _xmlHttp = new XMLHttpRequest();
    }
    else if(window.ActiveXObject)
    {
        //for IE5, IE6
        _xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    return _xmlHttp;
}

var xmlHttp = null;
   
function handleResult(responseText)
{
	try{
		var xmlDom = new ActiveXObject("Microsoft.XMLDOM");
		xmlDom.async = "false";
		xmlDom.loadXML(responseText);
		
		var Rootnode = xmlDom.documentElement;
		var nodes = Rootnode.selectNodes("content");
	  for (var i = 0; i < nodes.length; i++ )  
	  {
	      var id = nodes[i].getAttribute("id");
	      setAdsById(id, nodes[i].text);
	  }
	}
	catch(e)
	{
	}
}

function handler() 
{
    if(xmlHttp.readyState == 4 && xmlHttp.status == 200) 
    {
        handleResult(xmlHttp.responseText);
    }
}

function GetAds()
{
	if (g_eadTimer!=0)
	{
		clearInterval(g_eadTimer);
		g_eadTimer = 0;
	}

	var offers = GetAdsIdsOffered();
	if (offers=="")
		return;
	offers = "&offers=" + offers;


	var query = "";
	if (document.getElementById("queryword"))
		query = "&query=" + encodeURIComponentWrapper(document.getElementById("queryword").innerText);
	var uid = "&uid=" + window.external.getAppID();
	var dateTime = new Date();
	var rnd = "&rnd=" + dateTime.getTime();
	var appver = "&appVer=" + window.external.getAppVersionString(); // 4.0以后带上版本号
	var url = "http://impservice.dictapp.youdao.com/imp/request.s?req=-&adnum=1&syndid=52&posid=102&doctype=xml" + rnd + query + uid + offers + appver;
	xmlHttp = getXMLHttp();

	if (xmlHttp != null)
	{
		xmlHttp.onreadystatechange = handler;
		xmlHttp.open("GET", url, true);
		xmlHttp.send();
	}
}

function GetAdsIdsOffered()
{
	try{
		var idsOffered = "";
		var idArray = new Array("ead_dictr_top", "ead_dictr_right", "ead_dictr_1", "ead_dictr_2", "ead_dictr_3", "ead_dictr_4", "ead_dictr_5", "ead_dictr_result_bottom", "ead_dictr_example_bottom", "ead_dictr_wiki_bottom");
		for(i=0;i<idArray.length;i++)
		{
			var divObj = document.getElementById(idArray[i]);
			if( divObj != null)
			{
				idsOffered += idArray[i]+ " ";
			}
		}
	
		if (idsOffered == "" && document.getElementById("ead_dictr_ins") != null) {
			var bShowInsAds = window.external.loadString(g_bShowAds);
			if (document.getElementById("show_ins_adv") != null || bShowInsAds=="true")
			{
				if (bShowInsAds!="true")
					window.external.saveString(g_bShowAds, "true");
				idsOffered = "ead_dictr_ins";
			}
			else
			{
				window.external.saveString(g_bShowAds, "false");
			}
		}
		return idsOffered;

	}
	catch(e)
	{
	}

}

function GetAdsByTimer()
{
	if (g_eadTimer!=0)
	{
		clearInterval(g_eadTimer);
		g_eadTimer = 0;
	}
	if (document.getElementById("queryword"))
	{
		GetAds();		
	}
	else
	{
		g_eadTimer = setInterval( "GetAds()", 800 );
	}
}

function GetDate()
{
	var date = new Date();
	document.write(date.toLocaleDateString());
}

function getXMLHttp()
{
    var _xmlHttp = null;
    if(window.XMLHttpRequest)
    {
        //for IE7
        _xmlHttp = new XMLHttpRequest();
    }
    else if(window.ActiveXObject)
    {
        //for IE5, IE6
        _xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    return _xmlHttp;
}

function encode(text) {
	if (typeof(encodeURIComponent) == "function") {
		return encodeURIComponent(text);
	}
	return text;
}
function clickAnchor(object) {
    t = new Date() - 0;
	var url = "http://cidian.youdao.com/track/click.jsp?click=" + encode(object.href) + "&t=" + t;
	var r = getXMLHttp();
	if (r) {
	  r.open('GET', url, true);
	  r.send(null);
	}
}

