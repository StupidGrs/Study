
(function(){
    function getarg(id)
    {
        var url = unescape(window.location.href);
        var allargs = url.split("?")[1];
        var args = allargs.split("&");
        for(var i=0; i<args.length; i++)
        {
            var arg = args[i].split("=");
            if(id == arg[0]) return arg[1];
        }
        return 0;
    } 

    var d=document;
    var b=document.body;
    var resize= function(){
        var w=d.getElementById("wrapper");
        var height = w.offsetHeight;                            //展示区域的大小，    
        var wheight = d.documentElement.clientHeight;           //可视面积大小，
        w.style.marginTop =(wheight-height)/2 + 'px';           //居中    
    };

    window.onload=resize;
    window.onresize=resize;

    var count=d.getElementById("count"); 
    if(count){
        var count=getarg("count");
        var info=d.getElementById("count");      
        info.innerHTML = count;
    }
    
    
    var mask = d.getElementById("mask");                                //遮罩区
    var toggle_description = d.getElementById("toggle-description");   //“点击显示释义”
    var description = d.getElementById("description");                  //被遮罩区挡住的释义区

    var action = d.getElementById("action");
    var disable_action = d.getElementById("disable-action");
    var remember = d.getElementById("remember");
    var forget = d.getElementById("forget");
    var next = d.getElementById("next");
    var pre = d.getElementById("pre");
    //点击“点击显示释义”之后遮罩区消失，显示释义区
    if(toggle_description){
        toggle_description.onclick = function(){
            description.style.display = "block";
            mask.style.display = "none";
            if(disable_action) disable_action.style.display = "none";
            action.style.display = "block";
        };
    }
    
    if(action){
        action.onclick = function(event){
            event = event||window.event;
            target = event.target ||event.srcElement;
            switch(target.id){
				case "next":
				case "pre":
                    description.style.display = "none";
                    mask.style.display = "block";
                    break;          
				case "forget":                
                case "remember":
                    description.style.display = "none";
                    mask.style.display = "block";
                    disable_action.style.display = "block";
                    action.style.display = "none";
                    break;
            }
        };
    }
    
    d.onkeydown = function(event){
        event = event||window.event;
        target = event.target ||event.srcElement;
        var key;
        if (typeof event.charCode == "number"){
            key =  event.charCode;
        } else{
            key = event.keyCode;
        }
        var e = document.createEventObject();
        
        if(key == 32 && toggle_description){
            toggle_description.fireEvent("onclick",e);
        }
        if(action && action.style.display == "none") return false;  //如果action区没有激活就不要这个处理函数了。
        
        if(key == 37) {
			if (remember)
            {
                remember.fireEvent("onclick",e);
				location.href = remember.href;
            }
			if (pre)
			{
                pre.fireEvent("onclick",e);
				location.href = pre.href;
			}
		}
		if(key == 39){
			if (forget)
            {
                forget.fireEvent("onclick",e);
				location.href = forget.href;
            }
			if (next)
			{
                next.fireEvent("onclick",e);
				location.href = next.href;
			}			
		}
    }
    
    
})();