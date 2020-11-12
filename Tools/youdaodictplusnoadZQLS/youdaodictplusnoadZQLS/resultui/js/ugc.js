/**
 * ugc
 * @author: wulj
 * @date: 11-7-26
 * @version: 1.0
 */

////////////////////////////////////
// 公共函数

function trimAndReplace(val, s, l){// 将val由s分割，同时对val中的s去头去尾去重，再由l连接
	var noSpace = val.split(s);
	val="";
	for (i=0; i<noSpace.length; i++){
		if (noSpace[i].length>0){
			if (val != "" && i > 0 && i <= noSpace.length-1 ){
				val += l;
			}
			val += noSpace[i];					
		}
	}
	return val;
}

function spaceTrim(val){// 空格去重去头去尾，全角空格将转为半角
	val = trimAndReplace(trimAndReplace(val, " ", " "), "　", " ");
	return trimAndReplace(trimAndReplace(val, " 　", " "), "　 ", " ");
}

function contribute_wordCount(str){// 根据空格判断单词数
	var spaceE=str.split(" ");
	var spaceECount=0;
	for (j=0; j<spaceE.length; j++){
		if (spaceE[j].length>0){
			spaceECount++;
		}
	}
	return spaceECount;
}

function submitContent(content, keyfrom, ctype, callback){// 内容提交
    var data = {'q':content,
                'keyfrom':keyfrom, 
                'ctype':ctype,
                'pos':0, 
                'id':window.external.getAppID(), 
                'appVer':window.external.getAppVersionString(), 
                'action':'CLICK'};

    $.post('http://dict.youdao.com/ctlog', 
            data, 
            callback);
}
////////////////////////////////////

(function() {
    var lbox = {};

    var fillText = function() {
		var query = spaceTrim($("#queryword").text());
		$('#currentWord').text(query);
		var res = window.external.getUgcRes(query);
		var arrVal = res.split("#");
		for (i=0; i<arrVal.length; i++){
			if (arrVal[i] == "YDSEP_PARA"){
				$('#inputTrans').val(arrVal[i+1]);
				i++;
			}
			if (arrVal[i] == "YDSEP_REF"){
				$('#source').val(arrVal[i+1]);
		        $('#source').trigger('check');
				i++;
			}
			if (arrVal[i] == "YDSEP_CON"){
				$('#contact').val(arrVal[i+1]);
		        $('#contact').trigger('check');
				i++;
			}
		}
    };
    /**
     * 初始化释义编辑事件
     */
    var initDevotion = function() {
        var trans = $('#transDevotion');
        $('#transDevotion .contributeBtn').click(function() {
            $('#transDevotion .error-message').text('');
			var query = spaceTrim($("#queryword").text());
			$('#currentWord').text(query);
            trans.removeClass('showDevotion');
            ctlog('', '' , 0, 'deskdict.main.ugc.contribute' , 0, 'CLICK',  '点击贡献');
        });
        $("#transDevotion .cancel").click(function() {
            trans.addClass('showDevotion');
			var query = spaceTrim($("#queryword").text());
			var res = window.external.getUgcRes(query);
			if (res.length > 0){
				$('#ugcContentEdit').show();
			}
            return false;
        });
        $('#transDevotion .returnEdit').click(function() {
            $('#transDevotion .error-message').text('');
            fillText();
            trans.removeClass('showDevotion');
			$('#ugcContentEdit').hide();
            return false;
        });
		var bFocusInput = false;
		var bFocusSource = false;
		var bFocusContact = false;
		$('#inputTrans').focus(function(){
			bFocusInput = true;
			window.external.ugcInput();
		});
		$('#inputTrans').blur(function(){
			if (bFocusInput)
			{
				bFocusInput = false;
				window.external.ugcCancel();
			}
		});
		$('#source').focus(function(){
			bFocusSource = true;
			window.external.ugcInput();
		});
		$('#source').blur(function(){
			if (bFocusSource)
			{
				bFocusSource = false;
				window.external.ugcCancel();
			}
		})
		$('#contact').focus(function(){
			bFocusContact = true;
			window.external.ugcInput();
		});
		$('#contact').blur(function(){
			if (bFocusContact)
			{
				bFocusContact = false;
				window.external.ugcCancel();
			}
		})
    };
    /**
     * 初始化数据
     */
    var initPreData = function() {
        $('#contact').searchExample({
            info:'请输入Email'
        });
        $('#source').searchExample({
            info:'请输入释义来源'
        });
    };
    /**
     * 简单的数据校验
     */
    var CheckData = function(configSet) {
        this.configSet = configSet;
        this.config();
    };
    (function() {
        var trim = function(value) {
            return value.replace(/(^\s*)|(\s*$)/g, "");
        };
        var chunkers = {
            'email':/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
            'url':/^(http|https|ftp):\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\/:+!]*([^<>\""])*$/,
            'mobile':/^((\(\d{2,3}\))|(\d{3}\-))?(1[35][0-9]|189)\d{8}$/,
            'null':/.+/
        };
        var errorMsgs = [];
        var isRight = {
            'or':function(elem, types, value) {
                for (var type in types) {
                    if (type == "email"){
                        var val = elem.val();
                        if (val.indexOf("@")<0){ // 无@时，认为输入的是其他联系方式，也接受
                            return true;
                        }
                    }
                    if (chunkers[type].exec(value)) {
                        return true;
                    } else {
                        errorMsgs.push(types[type]);
                    }
                }
                return errorMsgs;
            },
            'and':function(elem, types, value) {
                for (var type in types) {
                    if (type == "email"){
                        var val = elem.val();
                        if (val.indexOf("@")<0){ // 无@时，认为输入的是其他联系方式，也接受
                            continue;
                        }
                    }
                    if (!chunkers[type].exec(value)) {
                        errorMsgs.push(types[type]);
                        return errorMsgs;
                    }
                }
                return true;
            }
        };
        var getErrorMsgs = function(msgs) {
            var msgsCode = "";
            for (var i = 0; i < msgs.length; i++) {
                msgsCode += '<span class="error-message">' + msgs[i] + '</span>'
            }
            return msgsCode;
        };
        var isValid = function(config) {
            if (!!config.additional && config.additional()) {
                return true;
            }
            errorMsgs = [];
            var types = config.types;
            var elem = config.elem;
            var concat = config.concat || 'or';
            var value = trim(elem.val());

            $(elem.parent()).find('.error-message').remove();
            var checkResult = isRight[concat](elem, types, value);
            if ($.isArray(checkResult)) {
                elem.after(getErrorMsgs(checkResult));
                return false;
            } else {
                return true;
            }
        };
        var configElem = function(configSet) {
            var configs = configSet.configs;
            for (var i = 0; i < configs.length; i++) {
                (function(idx) {
                    var conf = configs[idx];
                    conf.elem.bind('change', function() {
                        isValid(conf);
                    });
                })(i);
            }
        };
        var checkAll = function(configSet) {
            var callback = configSet.callback;
            var configs = configSet.configs;
            var isAllValid = true;
            for (var i = 0; i < configs.length; i++) {
                if (!isValid(configs[i])) {
                    isAllValid = false;
                }
            }
            if (isAllValid) {
                callback();
            }
        };
        CheckData.prototype = {
            constructor:CheckData,
            config:function() {
                configElem(this.configSet);
            },
            run:function() {
                checkAll(this.configSet);
            }
        };
    })();

    $.fn.extend({
        /**
         * 自动提示
         * @param config
         * info:提示文案
         */
        searchExample:function(config) {
            var self = $(this);
            var preColor = $(this).css('color');
            var init = function() {
                self.css('color', (config.color || '#999999'));
                self.val(config.info || '例如');
            };
            init();
            self.bind('focus.clearIt', function() {
                if (self.val() === config.info) {
                    self.val('');
                }
            });
            self.bind('blur.restoreIt', function() {
                if (self.val() === '') {
                    init();
                }
            });
            self.bind('keydown', function() {
                self.css('color', preColor);
            });
            self.bind('check', function() {
                self.css('color', preColor);
            });
        },
        lightBox:function() {
            var pageHeight = $(document.body).outerHeight();
            var box = $('<div class="light-box"></div>').appendTo('body');
            var content = $(this);
            var setBoxHeight = function() {
                box.css({
                    height:pageHeight
                });
            };
            setBoxHeight();
            var outerInterface = {
                open:function() {
                    box.show();
                    fixIEPbug();
                    content.fadeIn();
                },
                close:function() {
                    box.hide();
                    content.fadeOut();
                }
            };
			var fixIEPbug = function() {
                if (box.css('display') == 'none') {
                    return;
                }
                var height = $(window).height();
                var width = $(window).width();
                if ($.browser.msie && $.browser.version == '6.0') {
                    var scrollTop = document.body.scrollTop || document.documentElement.scrollTop;
                    content.css({
                        'top':(height - content.height()) / 2 + scrollTop,
                        'left':(width - content.width()) / 2
                    });
                }
            };
            fixIEPbug();
            $(window).resize(function() {
                fixIEPbug();
                setBoxHeight();
            });

            $(window).scroll(function() {
                fixIEPbug();
            });

            $(document).click(function() {
                outerInterface.close();
            });
            content.click(function(ev) {
                ev.stopPropagation();
            });
            return outerInterface;
        }
    });
    var initReportError = function() {
        $('#phrsListTab .rptErrLink').click(function() {
			$("input:checked").each(function (){
				this.checked = false;
			});
			$('#reportError .trans-content').text("");
			$('#reportError .error-message').text("");
            lbox.open();
            ctlog('', '' , 0, 'deskdict.main.ugc.feedback' , 0, 'CLICK',  '点击报错');
            return false;
        });
        $('#reportError .cancel').click(function() {
            lbox.close();
            return false;
        });
    };

	var testQueryWord = function(){
		var lang=spaceTrim($("#lang").text());
		if (lang=="eng"){// 只处理中英互译
			var query = spaceTrim($("#queryword").text());
			var res = window.external.getUgcRes(query);
			if (res.length > 0){// 已经提交过结果
				var arrVal = res.split("#");
				for (i=0; i<arrVal.length; i++){
					if (arrVal[i] == "YDSEP_PARA"){
						$("#ugcCotent").text(arrVal[i+1]);
						break;
					}
				}
				$('#ugcContentEdit').show();
			}
			else{// 判断是否符合新提交条件
				var eng = true;
				for (i=0; i<query.length; i++){// 是否存在非英文字符
					if (query.charCodeAt(i) > 255 && query.charCodeAt(i) < 65280){
						eng = false;
					}
				}
				if ((!eng && query.length <= 4) || (eng && contribute_wordCount(query) <= 3)){// 中文不多于四字 或 英文不多于三词
					$('#ugcReportButton').show();
				}
			}
		}

	}

    window.initUGC=function() {
        /**
         * 构造帮助示意图
         */
		window.external.ugcCancel();

		$('#ugcReportButton').hide();
		$('#ugcContentEdit').hide();
		testQueryWord();

		if ($('.light-box').length > 0) {
            $('.light-box').hide();
        }
        lbox = $('#reportError').lightBox();
        initPreData();
        initDevotion();
        initReportError();

        var reportErrorCallback = function() { // 用户报错数据提交
			var val="";
            var word = spaceTrim($("#queryword").text());
            var lang = spaceTrim($("#lang").text());
            if (word.length > 0){
                val += "#YDSEP_WORD#" + word + "#YDSEP_LANG#" + lang;
                var reason="";
                $("input:checked").each(function (){
                    if (reason == ""){
                        reason += "#YDSEP_REASON#" + $('#'+this.id+'Label').text();
                    }
                    else{
                        reason += "#" + $('#'+this.id+'Label').text();
                    }
                });
                var des = spaceTrim($('#reportError .trans-content').text());
                if (des.length > 0){
                    if (des.length < 256){
                        reason += "#YDSEP_DES#" + des;
                    }
                    else{
                        reason += "#YDSEP_DES#" + des.slice(0, 256);
                    }
                }
                if (reason.length > 0){
                    val += reason;
                }
                else{
                    val = "";
                }
            }
			if (val.length > 0){
                function cbf(){
                    $('#phrsListTab .rptErrLink').hide();
                    var rptErrS=$('#rptErrSucceed');
                    rptErrS.text("已提交");
                    rptErrS.css("color", "#959595");
                    rptErrS.show();
                }
                submitContent(spaceTrim(val), 'deskdict.main.ugc.feedback', '用户报错', cbf);
			}
            lbox.close();
        };

        $('#transDevotion .ensure').click(function() {
			var conf=[];
			var contact = $('#contact').val();
			if (contact.indexOf("@")>=0){
				conf=[
					{elem:$('#inputTrans'),types:{'null':'不能为空'}},
					{elem:$('#contact'),concat:'or',types:{'email':'请输入正确的Email'},additional:function() {
						return $('#contact').css('color') == 'rgb(221, 221, 221)';
					}}
					];
			} else {
				conf=[{elem:$('#inputTrans'),types:{'null':'不能为空'}}];
			}
			
			var checkDev = new CheckData({
				callback:function() {
					$('#transDevotion').addClass('showDevotion');// 释义贡献数据提交
					var word = spaceTrim($("#currentWord").text());
					var para = spaceTrim($("#inputTrans").text());
					var ref = spaceTrim($("#source").val());
					var contact = spaceTrim($("#contact").val());
                    var lang = spaceTrim($("#lang").text());
                    var val="";
                    if (word.length > 0){
                        val += "#YDSEP_WORD#" + word + "#YDSEP_LANG#" + lang;
                        if (para.length > 0){
                            if ( para.length < 256){
                                val+="#YDSEP_PARA#" + para;
                            }
                            else{
                                val+="#YDSEP_PARA#" + para.slice(0, 256);
                            }
                            if (ref != "请输入释义来源" && ref.length > 0){
                                if (ref.length < 256){
                                    val+="#YDSEP_REF#" + ref;
                                }
                                else{
                                    val+="#YDSEP_REF#" + ref.slice(0, 256);
                                }
                            }
                            if (contact != "请输入Email" && contact.length > 0){
                                if (contact.length < 256){
                                    val+="#YDSEP_CON#" + contact;
                                }
                                else{
                                    val+="#YDSEP_CON#" + contact.slice(0, 256);
                                }
                            }
                        }                    
                    }
					if (val.length > 0){
						$("#ugcCotent").text(para);
						$('#ugcReportButton').hide();
						$('#ugcContentEdit').show();
						var res = window.external.getUgcRes(word);
						if (res != val){
                            submitContent(spaceTrim(val), 'deskdict.main.ugc.contribute', '用户贡献');
						}
						window.external.ugcSubmit(word, val);
					}
					else{
						$('#ugcReportButton').show();
						$('#ugcContentEdit').hide();
						val="";
					}
				},
				configs:conf
			});

            checkDev.run();
            return false;
        });
        $('#reportError .ensure').click(function() {
            if ($('#others').attr('checked')) {
                var checkError = new CheckData({
                    callback:function() {
                        reportErrorCallback();
                        },
                    configs:[
                            {elem:$('#reportError .trans-content'),types:{'null':'不能为空'}}
                            ]
                });
                checkError.run();
            } else {
                reportErrorCallback();
            }
            return false;
        });
		var bInputErr = false;
		$('#inputRepoertError').focus(function(){
			bInputErr = true;
			window.external.ugcInput();
		});
		$('#inputRepoertError').blur(function(){
			if (bInputErr)
			{
				window.external.ugcCancel();
				bInputErr = false;
			}
		});
    };
})();
