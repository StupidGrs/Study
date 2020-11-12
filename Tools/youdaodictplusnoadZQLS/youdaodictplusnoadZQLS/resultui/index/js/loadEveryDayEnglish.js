/**
 * Created by 武利剑.
 * User: Administrator
 * Date: 10-11-11
 * Time: 下午12:11
 * To change this template use File | Settings | File Templates.
 */
var index = {};
index.loader = {
    isIE6:function() {
        return $.browser.msie && $.browser.version <= 6;
    },
    imgContext:"CSS/index/",
    setImgPath:function(path) {
        if (path.indexOf('default') > 0) {
            this.imgContext = "CSS/index/";
        } else if (!!path) {
            this.imgContext = path;
        }
    },
    refreshImg:function(path) {
        this.setImgPath(path);
        $(".background").html('<img src="' + this.imgContext + 'index.png">');
        $(".viewComparesTranslation .canvas").html('<img src="' + this.imgContext + 'button.png" >' +
                '<img src="' + this.imgContext + 'hover.png" >' +
                '<img src="' + this.imgContext + 'down.png" >');
        $(".hover-status").html('<img src="' + this.imgContext + 'button_hover.png">');
        $(".down-status").html('<img src="' + this.imgContext + 'button_down.png');
        if (this.isIE6()) {
            $('img').pngfix();
        }
    },
    initFeedback:function() {
        var strParams = "";
        try {
            strParams = window.location.search;
            if (strParams != "") {
                strParams = strParams.substr(1);
            }
        } catch (e) {
            strParams = "";
        }
        $(".feedback").attr('href', 'http://cidian.youdao.com/feedback.html?' + strParams);
    },
    initBackground:function() {
        $(".background").html('<img src="' + this.imgContext + 'index.png">');
    },
    init:function(data) {
        if (!!this[data.type]) this[data.type](data);
        this.initBackground();
        this.initFeedback();
    },
	
    /**
     * 初始化内部推广
     */
    initInnerSpread:function(spreadData) {
		var filterLink=function(link){
			return link;
		};
        try {
            var self = this;
            var rsd = spreadData.innerSpread.sort(function() {
                return Math.random() > 0.5 ? -1 : 1;
            });
            var isNew = function(sd) {
                return sd.isNew ? '<img class="new" src="' + self.imgContext + 'new.png">' : '';
            };
            var sd1 = rsd.pop();
            $('<a style="width:223px" href="' + filterLink(sd1.link) + '" onclick="ctlog(this, \'inneread\' , 0, \'firstpage.innerEAD\' , 1, \'CLICK\', \'点击innerEAD\');">' + sd1.des + isNew(sd1) + '</a>').appendTo($('.innerSpread'));
            var sd2 = rsd.pop();
            $('<a style="width:206px" href="' + filterLink(sd2.link) + '" onclick="ctlog(this, \'inneread\' , 0, \'firstpage.innerEAD\' , 1, \'CLICK\', \'点击innerEAD\');">' + sd2.des + isNew(sd2) + '</a>').appendTo($('.innerSpread'));
        } catch(err) {
        }
    },
    /**
     * 初始化外部推广
     */
    initOuterSpread:function(spreadData) {
        if (typeof(ead_ads) === 'undefined' || ead_ads.length === 0) {
            return;
        }
        $('.outerSpread').show();
        for (var i = 0; i < ead_ads.length; i = i + 1) {
            (function() {
                var spread = '<div class="business">' +
                        '<p><a href="' + ead_ads[i].url + '" onclick="ctlog(this, \'ead\' , 0, \'firstpage.EAD\' , 1, \'CLICK\', \'点击EAD\');">' + ead_ads[i].title + '</a></p>' +
                        '<p class="additional">' + ead_ads[i].desc + '</p>' +
                        '</div>';
                $('.outerSpread').append(spread);
            })();
        }
    },
    /**
     * 处理测试数据
     * @param testTopic
     */
    "TEST":function(testTopic) {
        var self = this;
        /**
         * 根据数据，创建一个测试题
         */
        var creatTheTest = function() {
            //处理被当做题空的下划线
            testTopic.questionSentence = testTopic.question.replace(/_/, ' ' + testTopic[testTopic.right] + ' ');
            testTopic.question = testTopic.question.replace(/_/, '<span class="space">&nbsp;<a class="right-answer">' + testTopic.right + '</a>&nbsp;</span>');

            $(".everydayEnglish").addClass("testing").append(
                    '<h3>' + testTopic.question + '</h3>' +
                            '<table>' +
                            '<tr>' +
                            '<td hidefocus class="A"><a href="javascript:void(0);" onclick="ctlog(\'\', \'test\' , 0, \'firstpage.test\' , 1, \'CLICK\', \'点击测试\');">A. ' + testTopic.A + '</a></td>' +
                            '<td hidefocus class="B"><a href="javascript:void(0);" onclick="ctlog(\'\', \'test\' , 0, \'firstpage.test\' , 1, \'CLICK\', \'点击测试\');">B. ' + testTopic.B + '</a></td>' +
                            '</tr>' +
                            '<tr>' +
                            '<td hidefocus class="C"><a href="javascript:void(0);" onclick="ctlog(\'\', \'test\' , 0, \'firstpage.test\' , 1, \'CLICK\', \'点击测试\');">C. ' + testTopic.C + '</a></td>' +
                            '<td hidefocus class="D"><a href="javascript:void(0);" onclick="ctlog(\'\', \'test\' , 0, \'firstpage.test\' , 1, \'CLICK\', \'点击测试\');">D. ' + testTopic.D + '</a></td>' +
                            '</tr>' +
                            '</table>');
            $('body').append('<div class="viewComparesTranslation"><div class="canvas"><img src="' + self.imgContext + 'button.png" >' +
                    '<img src="' + self.imgContext + 'hover.png" >' +
                    '<img src="' + self.imgContext + 'down.png" ><div></div>');
        };

        /**
         *IE6 中使用 png24 的 img 图片来代替鼠标悬停状态、按下状态的背景
         * 利用了浏览器判断，仅 IE6 中有效
         */
        var showHoverAndActiveStatus = (function() {
            //选项所用状态背景图片，由于 IE6 下z-index 默认值会创建新的层叠上下文的 bug，只能加到 .index 下
            var hoverStatus = $('<div class="hover-status" style="position:absolute;z-index:0;top:-1000px;"><img src="' + self.imgContext + 'button_hover.png"></div>')
                    .appendTo($('.index'));
            var downStatus = $('<div class="down-status" style="position:absolute;z-index:0;top:-1000px;"><img src="' + self.imgContext + 'button_down.png"></div>')
                    .appendTo($('.index'));
            /**
             * 获取 el 相对于 .index 的坐标值
             * @param el 参照元素
             */
            var show = function(el) {
                return {
                    top:(el.offset().top - $('.index').offset().top + 4) + 'px',
                    left:(el.offset().left - $('.index').offset().left) + 'px'
                };
            };
            /**
             * 不显示此背景
             */
            var hide = function() {
                return {
                    top:"-2000px"
                };
            };

            return function() {
                //将鼠标状态注册在单元格的内容元素 a 上
                $(".testing td a").bind('mouseover.showHover', function() {
                    hoverStatus.css(show($(this)));
                }).bind('mouseout', function() {
                    hoverStatus.css(hide());
                }).bind('mousedown.showDown', function() {
                    downStatus.css(show($(this)));
                }).bind('mouseup', function() {
                    downStatus.css(hide());
                }).bind('click.check', function() {
                    $(".testing td a").unbind('mouseover.showHover')
                            .unbind("mousedown.showDown");
                });
            }
        })();
        /**
         * IE6 中使用 png24 的 img 图片来代替原正确错误背景图片
         * 利用了浏览器判断，仅 IE6 中有效
         */
        var checkTheAnswer = (function() {
            //判题背景图片，由于 IE6 下z-index 默认值会创建新的层叠上下文的 bug，只能加到 .index 下
            var wrong = $('<div style="position:absolute;z-index:0;top:-1000px;"><img src="' + self.imgContext + 'wrong.png"></div>').appendTo($('.index'));
            var right = $('<div style="position:absolute;z-index:0;top:-1000px;"><img src="' + self.imgContext + 'right.png"></div>').appendTo($('.index'));
            /**
             * 获取 el 相对于 .index 的坐标值
             * @param el 参照元素
             */
            var show = function(el) {
                return {
                    top:(el.offset().top - $('.index').offset().top + 6) + 'px',
                    left:(el.offset().left - $('.index').offset().left) + 'px'
                };
            };

            return function() {
                //点击时显示测试结果图片
                $(".testing td").bind('click.check', function() {
                    if (!$(this).hasClass("right")) {
                        wrong.css(show($(this)));
                    }
                    right.css(show($(".testing .right")));
                });
            }
        })();
        /**
         * 根据预设，判题，通过选择器 .check 限定上下文
         */
        var clickToCheckTheAnswer = (function() {
            /**
             * 初始化跳转到对照翻译按钮的形态
             */
            var viewComparesTranslation = function() {
                /**
                 * 在鼠标当前的水平位置处，显示提示按钮
                 * @param ev 事件对象，用于获取鼠标相对于 body 的坐标值
                 */
                var showTips = function(ev) {
                    $(".viewComparesTranslation").css({'top':($('.testing h3').offset().top + 16) + 'px','left':(ev.pageX - 48) + 'px'});
                };
                /**
                 * 隐藏提示按钮
                 */
                var hideTips = function() {
                    $(".viewComparesTranslation").css({'top':'-1000px'});
                };
                /**
                 * 设置按钮的状态
                 * @param status
                 * normal:正常状态
                 * down: 鼠标按下状态
                 * hover:鼠标悬停状态
                 */
                var setStatusAs = function(status) {
                    var pos = {
                        "hover":'-31px',
                        "down":'-62px',
                        'normal':0
                    };
                    $('.viewComparesTranslation .canvas').css({'margin-top':pos[status]});
                };

                //将正文背景色改变
                $('.testing h3').hover(function(ev) {
                    $(this).css({'background-color':"#f5f3dd"});
                }, function() {
                    $(this).css({'background-color':"transparent"});
                });

                //鼠标移动时，提示按钮出现并在水平方向跟随鼠标移动
                $('.testing h3').bind('mousemove', function(ev) {
                    showTips(ev);
                }).bind('mouseout', function(ev) {
                    hideTips();
                });

                //注册按钮状态变化函数
                $(".viewComparesTranslation").hover(function(ev) {
                    showTips(ev);
                    setStatusAs("hover");
                }, function() {
                    setStatusAs("normal");
                    hideTips();
                }).bind('mousedown', function() {
                    setStatusAs("down");
                }).bind('mouseup', function() {
                    setStatusAs("hover");
                });
                $(".viewComparesTranslation").click(function() {
					ctlog('', '' , 0, 'firstpage.test' , 1, 'CLICK', '点击每日测试对照翻译');
                    window.location.href = "app:trans:" + encodeURIComponent(testTopic.questionSentence);
                });
            };
            return function() {
                //给正确的题目添加正确标识
                $("." + testTopic.right).addClass("right");
                $(".testing td").bind('click.check', function() {
                    //确定当前点击答案是否正确，若不正确则添加错误标识
                    if (!$(this).hasClass("right")) {
                        $(this).addClass("wrong");
                    }
                    //更换上下文，显示答案提示
                    $(".testing").addClass("check");
                    $(".testing td").unbind('click.check');

                    //点击后，初始化对照翻译按钮的显示以及背景的悬停状态
                    viewComparesTranslation();
                });
            };
        })();

        //根据数据，创建一个测试题
        creatTheTest();
        //初始化内部推广
        this.initInnerSpread(testTopic);
        //初始化外部推广
        this.initOuterSpread(testTopic);
        //针对 IE6 中 png24 的 img 的特殊处理
        if (self.isIE6()) {
            showHoverAndActiveStatus();
            checkTheAnswer();
        }
        //根据预设，判题，通过选择器 .check 限定上下文
        clickToCheckTheAnswer();
    },
    "WORD":function(wordData) {
        $(".everydayEnglish").addClass("word").append(
                '<h3 class="title"><a href="app:ds:' + wordData.word + '" onclick="ctlog(this, \'word\' , 0, \'firstpage.word\' , 1, \'CLICK\', \'点击每日一词\');">' + wordData.word + '</a></h3>' +
                        '<p class="des">' + wordData.des + '</p>' +
                        '<p class="detail">' + wordData.detail + '</p>');
        this.initInnerSpread(wordData);
        this.initOuterSpread(wordData);
    },
    "EXAMPLE":function(exampleData) {
        $(".everydayEnglish").addClass("example").append(
                '<p class="sen">' + exampleData.sen + '</p>' +
                        '<p class="trans">' + exampleData.trans + '</p>' +
                        '<a class="rel" href="app:lj:' + encodeURIComponent(exampleData.rel) + '?ljtype=mdia&ljmdia=0"  ' + ' onclick="ctlog(this, \'example\' , 0, \'firstpage.example\' , 1, \'CLICK\', \'点击每日例句\');">' + '<img src="' + this.imgContext + 'original_sound.png" onclick="ctlog(this, \'yuansheng\' , 0, \'firstpage.lj.yuansheng\' , 1, \'CLICK\', \'点击原声例句\');">查看原声例句</a>');
        this.initInnerSpread(exampleData);
        this.initOuterSpread(exampleData);
    }
};