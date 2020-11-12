/**
 * Javascript TranslatoR 组件 JTR 的基础库.
 *
 * @module J
 * @author zhangyc
 */

/**
 * 实现一个轻量级的 JavaScript 库
 *
 * @class J
 * @namespace outfox.translate.JTR
 */
(function() {
    var J = {
        /**
         * 浏览器类型及版本号判断
         */
        browser:function() {
            var bro = {};
            var ua = navigator.userAgent.toLowerCase();
            var s;
            (s = ua.match(/msie ([\d.]+)/)) ? bro.msie = s[1] :
                    (s = ua.match(/firefox\/([\d.]+)/)) ? bro.firefox = s[1] :
                            (s = ua.match(/chrome\/([\d.]+)/)) ? bro.chrome = s[1] :
                                    (s = ua.match(/opera.([\d.]+)/)) ? bro.opera = s[1] :
                                            (s = ua.match(/version\/([\d.]+).*safari/)) ? bro.safari = s[1] : 0;
            return bro;
        }(),
        /**
         * 判断元素是否是 DOM 结点
         *
         * @method isDOM
         * @static
         * @param {Object}elem
         * @return {Boolean}
         */

        isDOM : function(elem) {
            return Boolean(elem && elem.nodeType === 1);
        },
        /**
         * 判断元素是否是 数组
         *
         * @method isArray
         * @static
         * @param {Object}obj 待判断元素
         * @return {Boolean} 是否数组 true 为数组
         */
        isArray: function(obj) {
            return Object.prototype.toString.call(obj) === '[object Array]';
        },
        /**
         * 判断一个 object 是否是一个 Function
         *
         * @method isFunction
         * @static
         * @param {Object}obj
         * @return {Boolean}
         */
        isFunction :function(obj) {
            return Object.prototype.toString.call(obj) === "[object Function]";
        },
        /**
         * 迭代器
         *
         * @method each
         * @static
         * @param {Object}object
         * @param {Function}callback 回调函数
         * 回调格式：当object为对象时，callback(key,value) 上下文为 context, 若 context 未定义，那么上下文为 value。
         * 当object为数组或含length属性的htmlcollection时，callback(idx,object[idx])，上下文同上。
         * 回调中断：当某个回调返回值是false时，中断each
         */
        each: function(object, callback, context) {
            if (object === undefined || object === null) {
                return;
            }
            if (object.length === undefined || J.isFunction(object)) {
                for (var name in object) {
                    if (object.hasOwnProperty(name)) {  //只有此元素本身属性调用回调
                        if (callback.call(context || object[name], name, object[name]) === false) {
                            break;
                        }
                    }
                }
            } else {
                for (var i = 0; i < object.length; i++) {
                    if (callback.call(context || object[i], i, object[i]) === false) {
                        break;
                    }
                }
            }
            return object;
        },
        /**
         * 返回数组或对象中第一个值为 val 对象的 index 或 key
         * @param obj 对象或数组
         * @param val 待检测值
         */
        indexOf:function indexOf(obj, val) {
            if (obj.indexOf) {
                return obj.indexOf(val);
            } else {
                var result = -1;
                J.each(obj, function(idx) {
                    if (this === val) {
                        result = idx;
                        return false;
                    }
                });
                return result;
            }
        },

        /**
         * 事件绑定
         *
         * @method bind
         * @param {Object}object
         * @param {String}eventName
         * @param {Function}callback
         */
        bind : function(object, eventName, callback) {
            if (!callback) {
                return;
            }
            if (object.addEventListener) {
                object.addEventListener(eventName, callback, false);
            } else if (object.attachEvent) {
                object.attachEvent('on' + eventName, callback);
            } else {
                object['on' + eventName] = callback;
            }
            return this;
        },

        /**
         * 解除事件绑定函数
         *
         * @method unbind
         * @static
         * @param {Object}object
         * @param {String}eventName
         * @param {Function}callback
         */
        unbind : function(object, eventName, callback) {
            if (!callback) {
                return;
            }
            if (object.removeEventListener) {
                object.removeEventListener(eventName, callback, false);
            } else if (object.detachEvent) {
                object.detachEvent('on' + eventName, callback);
            } else {
                object['on' + eventName] = function() {
                };
            }
            return this;
        },

        /**
         * 为数据做 Percentage Encoding
         * 将参数对象序列化成字符串
         * @method param
         * @static
         * @param {Object}data
         * @return {String}
         */
        param : function(data) {
            var param = [];
            J.each(data, function(index, value) {
                if (value) {
                    // 翻译服务器会对传入的数据先做一次 ISO-8859-1 解码
                    // 然后再对数据按照 ue 做一次解码
                    // Firefox 3 会在 content-type 后面强制加入 charset=UTF-8
                    // 导致服务器在做 ISO-8859-1 解码前先做 UTF-8 解码
                    // 会导致中文乱码
                    // 所以对于 Firefox 3，需要将数据强制转换成 ISO-8859-1 格式
                    value = encodeURIComponent(value);
                    if (J.browser.firefox) {
                        value = encodeURIComponent(unescape(value)); // 将数据转换成 ISO-8859-1 格式
                    }
                    param.push(encodeURIComponent(index) + '=' + value);
                }
            });
            return param.join('&');
        },

        /**
         * 将任意对象转化为数组
         *
         * @method makeArray
         * @static
         * @param {Object}obj
         * @return {Array}
         */
        makeArray : function(obj) {
            return Array.prototype.slice.call(obj, 0);
        },

        /**
         * 获取页面编码
         *
         * @method getDocumentCharset
         * @static
         * @return {String}
         */
        getDocumentCharset : function() {
            J.log("document.characterSet || document.charset:::" + document.characterSet || document.charset);
            return document.characterSet || document.charset;
        },

        /**
         * 控制台 Log
         *
         * @method log
         * @static
         */
        log : function() {
            if (window.console) {
                var args = J.makeArray(arguments);
                args.unshift('[J]');
                try {
                    window.console.log.apply(window.console, args);
                } catch(e) {
                    if (arguments.length === 3) {
                        window.console.log(arguments[0], arguments[1], arguments[2]);
                    } else if (arguments.length === 2) {
                        window.console.log(arguments[0], arguments[1]);
                    } else {
                        window.console.log(arguments[0]);
                    }
                }
            }
        },
        /**
         * 发送日志请求
         * @param params
         * action 日志记录类型
         * 现有 land  打开到landing页
         *      try   尝试翻译插件
         *      howto 使用教程
         *      install 安装
         */
        sendLog : function(params) {
            var image = new Image();
            image.src = '@HOST@/rl.do?' + J.param(params) + '&' + new Date();
        },

        /**
         * 设置或获取元素样式
         *
         * @method css
         * @static
         * @param {Object}elem
         * @param {Object}styles
         * @return {Object}
         */
        css : function() {
            /**
             * 获取一个元素的样式
             * @param elem
             * @param styleName
             */
            var getStyle = function(elem, styleName) {
                var value = '';
                if (styleName == 'float') {
                    document.defaultView ? styleName = 'float'/*cssFloat*/ : styleName = 'styleFloat';
                }
                if (elem.style[styleName]) {//内联样式
                    value = elem.style[styleName];
                } else if (elem.currentStyle) {//IE
                    value = elem.currentStyle[styleName];
                } else if (document.defaultView && document.defaultView.getComputedStyle) {//W3 DOM
                    styleName = styleName.replace(/([A-Z])/g, '-$1').toLowerCase();
                    var s = document.defaultView.getComputedStyle(elem, '');
                    value = s && s.getPropertyValue(styleName);
                } else { //other,for example, Safari
                    value = null;
                }
                //处理width 和 height 出现 auto 的情况
                if (value == "auto" && ('width' === styleName.toLowerCase() || 'height' === styleName.toLowerCase()) && elem.style.display != "none") {
                    value = elem["offset" + styleName.charAt(0).toUpperCase() + styleName.substring(1).toLowerCase()] + "px";
                }
                if (styleName == "opacity") {
                    try {
                        value = elem.filters['DXImageTransform.Microsoft.Alpha'].opacity;
                        value = value / 100;
                    } catch(e) {
                        try {
                            value = elem.filters('alpha').opacity;
                        } catch(err) {
                        }
                    }
                }
                return value;
            };
            return function(elem, styles) {
                if (typeof styles === 'string') {
                    return getStyle(elem, styles);
                } else {
                    J.each(styles, function(key, value) {
                        elem.style[key] = value;
                    });
                }
            };
        }(),
        /**
         * 获取窗口的尺寸
         */
        getPageSize:function() {
            var xScroll, yScroll;
            if (window.innerHeight && window.scrollMaxY) {
                xScroll = document.body.scrollWidth;
                yScroll = window.innerHeight + window.scrollMaxY;
            } else { // all but Explorer Mac
                xScroll = Math.max(document.body.scrollWidth, document.body.offsetWidth);
                yScroll = Math.max(document.body.scrollHeight, document.body.offsetHeight);
            }
            var windowWidth, windowHeight;
            windowWidth = document.documentElement.clientWidth || document.body.clientWidth;
            windowHeight = document.documentElement.clientHeight || document.body.clientHeight;

            var pageHeight = Math.max(yScroll, windowHeight);
            var pageWidth = Math.max(xScroll, windowWidth);
            return {
                page:{
                    width: pageWidth,
                    height: pageHeight
                },
                window:{
                    width:windowWidth,
                    height:windowHeight
                }
            };
        },
        /**
         * 获取一个元素相对于页面左上角的位置
         *
         * @method findPos
         * @static
         * @param {Object} element
         * @return {Array}
         */
        findPos : function(elem) {
            var offset = {
                x:0,
                y:0
            };
            while (elem) {
                offset.x += elem.offsetLeft;
                offset.y += elem.offsetTop;
                elem = elem.offsetParent;
            }
            return offset;
        },
        /**
         * 遍历 DOM 结点
         *
         * @method walkTheDOM
         * @static
         * @param {DOMNode}node
         * @param {Function}func  对遍历出的节点所做的操作，上下文为当前 node
         * @param {Function}filter  遍历节点时，忽略不符合过滤条件的元素
         * TODO:研究更加精准的dom遍历方法
         */
        walkTheDOM : function(node, func, filter) {
            if (filter && !filter(node)) {
                return;
            }
            func(node);
            if (node.tagName === 'IFRAME' || node.tagName === 'FRAME') { //对于frame 和iframe，遍历其中节点
                try {
                    try {
                        node = node.contentDocument.body;
                    } catch(e) {
                        node = node.contentWindow.document.body;
                    }
                } catch(e) {
                    node = node.firstChild;
                }
            } else {
                node = node.firstChild;
            }
            while (node) {
                arguments.callee(node, func, filter); //函数对象本身迭代调用
                node = node.nextSibling;
            }
        },
        /**
         * 获取所有文本节点
         * @param node   遍历DOM树时的起始节点
         * @param filter 遍历DOM树时的过滤器
         * @return textNodes 所有文本节点组成的数组
         */
        getTextNodes : function(node, filter) {
            var textNodes = [];

            J.walkTheDOM(node, function(child) {
                if (child.nodeType === 3 && J.trim(child.nodeValue)) {
                    textNodes.push(child);
                }
            }, filter);

            return textNodes;
        },
        /**
         * Get elements by class name
         *
         * @method getElementsByClassName
         * @static
         * @param {DOMNode}node
         * @param {String}className
         * @return {Array}
         * todo:两种返回结果类型不一致，node.getElementsByClassName(className)返回的是nodelist，后者是数组
         */
        getElementsByClassName : function(node, className) {
            if (node.getElementsByClassName) {
                return node.getElementsByClassName(className);
            } else {
                var results = [];
                J.walkTheDOM(node, function (node) {
                    if (J.hasClass(node, className)) {
                        results.push(node);
                    }
                });
                return results;
            }
        },
        /**
         * 根据选择器查找出元素
         */
        query:function(selector, root) {
            var chunker = new RegExp('(?:^.?([^()]*))(?:^#?([^()]*))');
            var result=chunker.exec(selector);
            var sRoot = root || document;
            if (!!!result) {
                return null;
            } else {
                if (result[1] !== '') {
                    var className = result[1];
                    if (sRoot.getElementsByClassName) {
                        return sRoot.getElementsByClassName(className);
                    } else {
                        var results = [];
                        J.walkTheDOM(sRoot, function (node) {
                            if (J.hasClass(node, className)) {
                                results.push(node);
                            }
                        });
                        return results;
                    }
                }
                if (result[2] !== '') {
                    return sRoot.getElementById(result[2]);
                }
            }
        },
        /**
         * 去除字符串头尾空白字符
         *
         * @method trim
         * @static
         * @param {String}str
         * @return {String}
         */
        trim : function(str) {
            return str.replace(/^\s*/, "").replace(/\s*$/, "");
        },

        /**
         * Format template string to HTML element
         *
         * @method formatTemplate
         * @static
         * @param {String}template well-formed html string
         * @param {Object}data
         * @return {DOMNode}
         */
        formatTemplate : function(template, data) {
            var tempContainer = document.createElement('div');
            for (var key in data) {
                if (data.hasOwnProperty(key)) {
                    template = template.replace(new RegExp('{' + key + '}', 'g'), data[key]);
                }
            }
            tempContainer.innerHTML = template;
            var result = tempContainer.firstChild;
            tempContainer.removeChild(result);
            return result;
        },

        /**
         * 判断元素是否含某个 className
         *
         * @method hasClass
         * @static
         * @param {Object}elem
         * @param {String}className
         * @return {Boolean}
         */

        hasClass : function(elem, className) {
            if (J.isDOM(elem)) {
                if (elem.className === className) {
                    return true;
                }

                var classes = elem.className.split(' '), i = 0, len = classes.length;
                for (; i < len; i++) {
                    if (className === classes[i]) {
                        return true;
                    }
                }
            }
            return false;
        },



        /**
         * 动态载入 CSS
         *
         * @method loadCSS
         * @static
         * @param {Object}doc Document object
         * @param {String}url CSS URL
         */
        loadCSS : function(doc, csses) {
            var load = function(single) {
                if (doc && doc.createElement) {
                    var timestamp = Date.parse(new Date()),
                            css = doc.createElement('link');
                    var url = single.indexOf('?') === -1 ? single + '?@REV@' : single + '&@REV@';
                    css.setAttribute('rel', 'stylesheet');
                    css.setAttribute('href', url);
                    css.setAttribute('type', 'text/css');

                    var parent = doc.getElementsByTagName('head')[0] || doc.body;
                    parent.appendChild(css);
                }
            };
            if (J.isArray(csses)) {
                J.each(csses, function(idx, css) {
                    load(css);
                });
            } else if (typeof csses === 'string') {
                load(csses);
            }
        },

        /**
         * 为一个 DOM 元素添加 Class
         *
         * @method addClass
         * @static
         * @param {DOMNode}elem
         * @param {String}className
         */
        addClass : function(elem, className) {
            if (J.isDOM(elem)) {
                var classes = elem.className.split(' '), i = 0, len = classes.length;
                for (; i < len; i++) {
                    if (className === classes[i]) {
                        return;
                    }
                }
                classes[i] = className;
                elem.className = classes.join(' ');
            }
        },

        /**
         * 为一个 DOM 元素删除一个 Class
         *
         * @method removeClass
         * @static
         * @param {DOMNode}elem
         * @param {String}className
         */
        removeClass : function(elem, className) {
            if (J.isDOM(elem)) {
                var classes = elem.className.split(' '), i = 0, len = classes.length, newClasses = [];
                for (; i < len; i++) {
                    if (className !== classes[i]) {
                        newClasses.push(classes[i]);
                    }
                }
                elem.className = newClasses.join(' ');
            }
        },

        /**
         * 当一个 DOM 元素包含指定的 class 时，删除该 class；若不含，则增加该 class
         *
         * @method toggleClass
         * @static
         * @param {DOMNode}elem
         * @param {String}className
         */
        toggleClass : function(elem, className) {
            if (J.isDOM(elem)) {
                var classes = elem.className.split(' '), i = 0, len = classes.length, newClasses = [], action = 'add';
                for (; i < len; i++) {
                    if (className === classes[i]) {
                        action = 'remove';
                    } else {
                        newClasses.push(classes[i]);
                    }
                }

                if (action === 'add') {
                    classes[i] = className;
                } else {
                    classes = newClasses;
                }
                elem.className = classes.join(' ');
            }
        },



        /**
         * 生成 GUID
         *
         * @method guid
         * @static
         * @return {String}GUID
         */
        guid : function() {
            // 生成 GUID 的辅助函数
            var _S4 = function() {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            return function() {
                return (_S4() + _S4() + "-" + _S4() + "-" + _S4() + "-" + _S4() + "-" + _S4() + _S4() + _S4());
            };
        }(),

        /**
         * 原型继承
         *
         * @method protoExtend
         * @static
         * @param {Object}obj
         * @return {Object}
         */
        protoExtend : function(obj, constructor) {
            var F = J.isFunction(constructor) ? constructor : function() {
            };
            F.prototype = obj;
            return new F();
        },


        /**
         * 取消事件冒泡
         * @param e 事件对象
         */
        stopPropagation : function(e) {
            var evt = e || window.event;
            if (evt.stopPropagation) {
                evt.stopPropagation();
            }
            evt.cancelBubble = true;
            return evt;
        },
        /**
         * cookie 操作
         * @param name
         * @param value
         */
        cookie:function(name, value) {
            function setCookies(name, value) {
                var Days = 30; //此 cookie 将被保存 30 天
                var exp = new Date(); //new Date("December 31, 9998");
                exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
                document.cookie = name + "=" + value + ";expire=" + exp.toGMTString();
            }

            function getCookies(name) {
                var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
                if (arr != null) return decodeURIComponent(arr[2]);
                return null;
            }

            if (!!value) {
                setCookies(name, value);
            } else {
                return getCookies(name);
            }
        }
    };

    window.J = J;
})();

