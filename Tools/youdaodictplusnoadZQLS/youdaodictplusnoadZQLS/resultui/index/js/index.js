/**
 * Created by .
 * User: Administrator
 * Date: 10-11-11
 * Time: 下午4:58
 * To change this template use File | Settings | File Templates.
 */
(function() {
    window.onload = function() {
        window.onresize = function() {
            $("body").height($(window).height());
        };
        $("body").height($(window).height());
        index.loader.init(index.datas[new Date().getDay()]);
        if ($.browser.msie) {
            $('.background').css({visibility:'visible'});
            $('img').pngfix();
        }
    };
})();
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