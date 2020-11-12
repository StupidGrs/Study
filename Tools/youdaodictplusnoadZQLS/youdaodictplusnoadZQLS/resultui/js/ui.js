// JavaScript Document
//functions
var g_strCurTab = "CURTABINRESULTPAGE";
var g_strCurWebTranStatus = "WT_1_STATUS";

var q_strWebTransFirstSubStatus = "FIRSTSUBSTATUS";
var q_strToggleStatus = "TOGGLESTATUS";

function showLoadMsg() {
    $('#actionTips').fadeIn();
}
function hideLoadMsg() {
    $('#actionTips').fadeOut();
}
function toggleFav(bl) {
    var word = $('.add-fav').attr('ref');
    bl ? $('.add-fav').addClass('add-faved').attr({href:'app:modword:' + word,title:'单词[' + word + ']已添加到单词本，点击修改'}) : $('.add-fav').removeClass('add-faved').attr({href:'app:addword:' + word,title:'添加到单词本'});
}

function changeWebTranFirstItemState(obj, id) {
    if (id == 1) {
        if (obj > -1)
            window.external.saveString(g_strCurWebTranStatus, "1");
        else
            window.external.saveString(g_strCurWebTranStatus, "0");
    }
}
var saveToggleStatus = function(el) {
    var allToggle = $(".toggle");
    var indexOfCurrentToggle = allToggle.index(el);
    if (el.attr("class").indexOf("toggleOpen") < 0) {
        window.external.saveString(q_strToggleStatus + el.attr("rel"), "close");
    } else {
        window.external.saveString(q_strToggleStatus + el.attr("rel"), "open");
    }
};

$.fn.extend({
    hasSubMenu:function(t, c) {
        this.each(function() {
            var $this = $(this);
            var $title = $(this).find(t);
            $title.css('cursor', 'pointer').click(function() {
                if ($title.index($(this)) === 0) {
                    $(this).addClass();
                }
                $this.toggleClass(c);
                $title.blur();
                return false;
            });
        });
        return this;
    }
    ,hasTab:function(tab, content, cc, def) {
        this.each(function() {
            var self = this;
            var $tab = $(this).find(tab);
            var $toggle = $(this).find(".toggle");
            // load the tab num saved last time
            var openContent = function() {
                $toggle.removeClass("toggleClose").addClass("toggleOpen");
                $($toggle.attr("rel")).show();
                saveToggleStatus($toggle);
            };
            var cur_tab = window.external.loadString(g_strCurTab + "_" + $(this).attr('id'));
            var real_def = (($("a[rel='" + cur_tab + "']").length == 0 || cur_tab === "") ? $tab.eq(def).attr("rel") : cur_tab);
            if (real_def === undefined) return;
            var $tabCurrent = $("a[rel='" + real_def + "']").addClass(cc);
            var $tabContent = $(this).find(content).hide();
            $(real_def).show();
            $tab.click(function() {
                $tabCurrent.removeClass(cc);
                $tabContent.hide();
                var $t = $(this).addClass(cc);
                $tabCurrent = $t;
                $($t.attr('rel')).show();
                $t.blur();
                openContent();
                // save current tab,if it has the class name "dontRemember", dont save
                if ($(self).attr('class').indexOf("dontRemember") < 0)
                    window.external.saveString(g_strCurTab + "_" + $(self).attr('id'), $t.attr('rel'));
                return false;
            });
        });
        return this;
    }
});


function InitLj() {
    if (document.getElementById('example_navigator')) {
        document.getElementById('example_content').focus();

        var drawer = new UI.Drawer("example_navigator");

        var getType = function(el) {
            var typeArr = ["ljblng", "ljblngcont_0", "ljblngcont_1", "ljblngcont_2", "ljblngcont_3",
                "ljmdia", "ljmdia_0", "ljmdia_1", "ljmdia_2", "ljauth"];
            var className = $(el).attr("class");
            for (var i = 0; i < typeArr.length; i++) {
                if (!(className.indexOf(typeArr[i] + " ") < 0)) {
                    return typeArr[i];
                }
            }
        }

        drawer.init({
            mainFn:function(el) {
                OnClickLjTab(getType(el));
            },
            subFn:function(el) {
                OnClickLjTab(getType(el));
            }
        });

        var lj_tab_id = document.getElementById('param_ljtype').innerText;
        if (lj_tab_id == 'mdia') { // 原声例句
            drawer.setMainCatalogSelectedStatus(2);
            var lj_mdia_tab_id = document.getElementById('param_ljmdia').innerText;
            if (lj_mdia_tab_id != '0' && lj_mdia_tab_id != '1' && lj_mdia_tab_id != '2') {
                lj_mdia_tab_id = '0';
            }
            drawer.setSubCatalogSelectedStatus("ljmdia_" + lj_mdia_tab_id);
        }
        else if (lj_tab_id == 'auth') { // 权威例句
            drawer.setMainCatalogSelectedStatus(3);
        }
        else { // 双语例句
            drawer.setMainCatalogSelectedStatus(1);
            var lj_cont_tab_id = document.getElementById('param_ljblngcont').innerText;
            if (lj_cont_tab_id != 0 && lj_cont_tab_id != 1 && lj_cont_tab_id != 2 && lj_cont_tab_id != 3) {
                lj_cont_tab_id = 0;
            }
            drawer.setSubCatalogSelectedStatus("ljblngcont_" + lj_cont_tab_id);
        }

        $("#see_originalSound").click(function() {
            $("#example_navigator .ljmdia").click();
        });
        $("#see_authority").click(function() {
            $("#example_navigator .ljauth").click();
        });
        $("#see_bilingual").click(function() {
            $("#example_navigator .ljblng").click();
        });
    }

}

function OnClickLjTab(tab_id) {
    var query = document.getElementById('queryword').innerText;
    query = encodeURI(query);
    var query_tran = "";
    var query_tran_tag = document.getElementById('querytran');
    if (query_tran_tag) {
        query_tran = '&ljtran=' + encodeURI(query_tran_tag.innerText);
    }
    if (tab_id == 'ljblng') {
        window.location.href = "app:lj:" + query + "?ljtype=blng&ljblngcont=0" + query_tran;
    }
    else if (tab_id == 'ljblngcont_0' || tab_id == 'ljblngcont_1' || tab_id == 'ljblngcont_2' || tab_id == 'ljblngcont_3') {
        window.location.href = "app:lj:" + query + "?ljtype=blng&ljblngcont=" + tab_id.substr(11) + query_tran;
    }
    else if (tab_id == 'ljmdia') {
        window.location.href = "app:lj:" + query + "?ljtype=mdia&ljmdia=0";
    }
    else if (tab_id == 'ljmdia_0' || tab_id == 'ljmdia_1' || tab_id == 'ljmdia_2') {
        window.location.href = "app:lj:" + query + "?ljtype=mdia&ljmdia=" + tab_id.substr(7);
    }
    else if (tab_id == 'ljauth') {
        window.location.href = "app:lj:" + query + "?ljtype=auth";
    }
}

function LjHighlightAlign(items_string) {
    $(items_string).addClass("highLight");
}

function LjUnhighlightAlign(items_string) {
    $(items_string).removeClass("highLight");
}

var UI = {};//命名空间
(function($) {
    UI.Drawer = function(id) {
        this.id = id;
    };
    UI.Drawer.prototype = {
        /**
         * 取Jquery的方法名，只能是 show 或者 hide
         * @param status
         */
        toggleCatalog:function(status) {
            var self = this;
            $("#" + self.id + " .main-catalog").each(function(i) {
                if (status === "show" || status === "hide") {
                    $("#" + self.id + " .group_" + (i + 1))[status]();
                }
            });
        },
        setMainCatalogSelectedStatus:function(catalog) {
            this.toggleCatalog('hide');
            if ($("#" + this.id + " .group_" + catalog).length > 0) {
                $($("#" + this.id + " .main-catalog")[catalog - 1]).addClass("main-catalog-selected-has-sub");
                $("#" + this.id + " .group_" + catalog).show();
            } else {
                $($("#" + this.id + " .main-catalog")[catalog - 1]).addClass("main-catalog-selected");
            }
        },
        setSubCatalogSelectedStatus:function() {
            $("#" + this.id + " .sub-catalog").each(function(i) {
                $($(this).find("li")).removeClass("sub-catalog-selected");
            });
            for (var idx = 0; idx < arguments.length; idx++) {
                $("#" + this.id + " ." + arguments[idx]).addClass("sub-catalog-selected");
            }
        },
        /**
         * 打开catalog 组
         * @param catalog type
         */
        openMainCatalog:function(type) {
            $("#" + this.id + " ." + type).click();
        },
        /**
         * 打开子选项
         * @param type
         */
        openSubCatalogs:function() {
            for (var idx = 0; idx < arguments.length; idx++) {
                $("#" + this.id + " ." + arguments[idx]).click();
            }
        },
        /**
         * 初始化主标题事件
         * @param mainClickfn
         * @param args
         */
        initMain:function(mainFn) {
            var self = this;
            var allMainCatalog = $("#" + self.id + " .main-catalog");
            allMainCatalog.each(function(i) {
                if ($("#" + self.id + " .group_" + (i + 1)).length > 0) {
                    $(this).addClass("hasSub");
                }
                $(this).click(function() {
                    allMainCatalog.removeClass("main-catalog-selected");
                    allMainCatalog.removeClass("main-catalog-selected-has-sub");
                    if ($("#" + self.id + " .group_" + (i + 1)).length > 0) {
                        $(this).addClass("main-catalog-selected-has-sub");
                    } else {
                        $(this).addClass("main-catalog-selected");
                    }
                    self.setMainCatalogSelectedStatus(i + 1);
                    mainFn(this);//传入当前点击的 element
                });
            });
        },
        /**
         * 初始化
         * @param subClickfn
         */
        initSubSelected:function(subFn) {
            $("#" + this.id + " .sub-catalog").each(function(i) {
                var self = this;
                var liInThisSubCatalog = $(this).find("li");
                //set selected status of sub catalog
                liInThisSubCatalog.click(function() {
                    liInThisSubCatalog.each(function() {
                        $(this).removeClass("sub-catalog-selected");
                    });
                    $(this).addClass("sub-catalog-selected");
                    subFn(this);//传入当前点击的 element
                });
            });
        },
        init:function(param) {
            this.toggleCatalog('hide');
            var mainFn = $.isFunction(param.mainFn) ? param.mainFn : function() {
            };
            var subFn = $.isFunction(param.subFn) ? param.subFn : function() {
            };
            this.initMain(mainFn);
            this.initSubSelected(subFn);
            if (!!param.main && !!param.main > 0) {
                this.setMainCatalogSelectedStatus(param.main);
            }
            if (!!param.sub) {
                this.setSubCatalogSelectedStatus(param.sub);
            }
            if ($(".dont_show_nav").length == 0) $("#" + this.id).show();
        }
    };
    UI.toggle = function() {
        $(".toggle").click(function() {
            if ($(this).attr("class").indexOf("toggleOpen") < 0) {
                $(this).removeClass("toggleClose");
                $(this).addClass("toggleOpen");
                $($(this).attr("rel")).show();
            } else {
                $(this).removeClass("toggleOpen");
                $(this).addClass("toggleClose");
                $($(this).attr("rel")).hide();
            }
            return false;
        });
    };
    UI.toggle_ss = function(module) {
		var backup = module;
        module = !!module ? ('#' + module) : '';
        $(module + " .toggle").unbind('click.toggleIt');
        $(module + " .toggle").bind('click.toggleIt', function() {
            window.location.href = 'app:' + backup;
            if ($(this).attr("class").indexOf("toggleOpen") < 0) {
                $(this).removeClass("toggleClose");
                $(this).addClass("toggleOpen");
                $($(this).attr("rel")).show();
            } else {
                $(this).removeClass("toggleOpen");
                $(this).addClass("toggleClose");
                $($(this).attr("rel")).hide();
            }
            return false;
        });
    };
})(jQuery);

var timeFoo = {};
$.fn.extend({
    isVideo:function() {//播放器路径，自动播放
        var swfStr = function(path) {
            var swf = '<div style="width:320px;height:240px;" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" type="application/x-shockwave-flash" id="simplayer" name="simplayer" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab">'
                    + '<param name="movie" value="' + path + '">'
                    + '<param name="menu" value="false">'
                    + '<param name="scale" value="noScale">'
                    + '<param name="allowFullscreen" value="true">'
                    + '<param name="allowScriptAccess" value="always">'
                    + '<param name="bgcolor" value="#FFFFFF">'
                    + '<embed  src="' + path + '" quality="high" bgcolor="#ffffff" width="320" height="240" name="simplayer" align="middle" play="true" loop="false" quality="high" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>'
                    + '</div>';
            return $(swf);
        };
        var $play = $(this).find('.play');
        var $close = $(this).find('.close').hide();

        $play.click(function() {
            stopVoice();
            $('#simplayer').siblings('.close').click();
            $(this).hide();
            $(this).parent().append(swfStr($(this).attr('href')));
            $(this).siblings('.close').show();
            return false;
        });
        $close.click(function() {
            $('#simplayer').remove();
            $(this).siblings('.play').show();
            $(this).hide();
            return false;
        });
    }
});
$.extend({
    stopVideo:function() {
        $('#simplayer').siblings('.close').click();
    }
});
function playVoice(path) {
    $.stopVideo();
    window.external.playSound(path);
}
function stopVoice() {
    window.external.stopSound();
}
function isFalshReady() {
	window.external.isFlashReady();
}
