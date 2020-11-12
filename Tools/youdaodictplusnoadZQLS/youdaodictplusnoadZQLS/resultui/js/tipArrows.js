/**
 * Created by LiJian.
 * User: Administrator
 * Date: 11-1-11
 * Time: 下午4:03
 * @requires jQuery lib
 */
(function($) {
    window.$t = TipArrows;
    function TipArrows(config) {
        if (!!!config.el) {
            throw new Error('The el parameter should not be null.');
        }
        this.config = config;
        this.init();
    }

    $.fn.extend({
        /**
         * @param param
         type:        "right","left","bottom","top"
         size:{
         left:     按顺时针方向，前面的是left
         right:    后面的是left
         height:   决定整个arrows的长度
         },
         offPos:       根据上，左的位移
         borderColor:  arrows的border的颜色
         borderWidth:  arrows的border的宽度
         paddingColor: arrows的填充的宽度

         example:
         $("#test").tipArrows({
         type:"right",
         size:{
         left:4,
         right:4,
         height:8
         },
         offPos:10,
         borderColor:'#CFC7BC',
         borderWidth:1,
         paddingColor:'#fffcd7'
         });
         */
        "tipArrows":function(param) {
            var config = param || {};
            this.each(function(){
                config.el=$(this);
                return new TipArrows(config);
            });
        }
    });

    TipArrows.bind = function(config) {
        return new TipArrows(config);
    };
    TipArrows.prototype = {
        constructor:TipArrows,
        /**
         * 初始化箭头
         */
        init:function() {
            this.initConfig();
            this.addIn();
            this.setBorderWidth();
            this.setBorderStyle();
            this.setColor();
            this.setOffPos();
            this.setMarginOffset();
        },
        /**
         * 初始化配置
         */
        initConfig:function() {
            this.el = this.config.el;
            this.type = this.config.type || 'up'
        },
        /**
         * 将箭头增加到目标元素上
         */
        addIn:function() {
            var self = this;
            var type = self.type;
            self.tipArrow = $('<div style="position: absolute; font-size: 0; line-height:0;">\
                         <span class="border" style="position: absolute;border-style: dashed;border-color: transparent;_border-color:tomato;_filter:chroma(color=tomato);"></span>\
                         <span class="padding" style="position: absolute;border-style: dashed;border-color: transparent;_border-color:tomato; _filter:chroma(color=tomato);"></span>\
                        </div>');
            self.tipBorder = self.tipArrow.find('.border');
            self.tipPadding = self.tipArrow.find('.padding');
            self.el.append(self.tipArrow);
        },
        /**
         * 根据规律，设置border-width
         */
        setBorderWidth:function() {
            var size = this.config.size;
            var borderWidth = this.config.borderWidth;
            var borderWidthMap = {
                up:[0,'right','height','left'],
                right:['left',0,'right','height'],
                down:['height','left',0,'right'],
                left:['right','height','left',0]
            }[this.type];
            var border = [];
            var padding = [];
            for (var i = 0; i < 4; i++) {
                (function(m) {
                    var item = borderWidthMap[m];
                    if (item !== 0) {
                        border.push(size[item] + 'px');
                        padding.push((size[item] - borderWidth) + "px");
                    } else {
                        border.push(0);
                        padding.push(0);
                    }
                })(i);
            }
            this.tipBorder.css({'border-width':border.join(' ')});
            this.tipPadding.css({'border-width':padding.join(' ')});
        } ,
        /**
         * 根据规律，设置border-style
         */
        setBorderStyle:function() {
            var borderStyleMap = {
                'left':'right',
                'right':'left',
                'down':'top',
                'up':'bottom'
            };
            var borderStyle = 'border-' + borderStyleMap[this.type] + '-style';
            this.tipBorder.css(borderStyle, 'solid');
            this.tipPadding.css(borderStyle, 'solid');
        },
        /**
         * 根据规律，设置颜色
         */
        setColor:function() {
            var borderStyleMap = {
                'left':'right',
                'right':'left',
                'down':'top',
                'up':'bottom'
            };
            var borderStyle = 'border-' + borderStyleMap[this.type] + '-color';
            this.tipBorder.css(borderStyle, this.config.borderColor);
            this.tipPadding.css(borderStyle, this.config.paddingColor);
        },
        /**
         * 根据规律，设置箭头相对于目标元素的位置，以从上到下，从左到右的规则设置
         */
        setOffPos:function() {
            var posOff = this.config.offPos + 'px';
            var offPos = -(this.config.size.height - this.config.borderWidth) + 'px';
            if (this.type === 'up' && $.browser.msie && $.browser.version <= 6) {
                offPos = -(this.config.size.height - this.config.borderWidth + 2) + 'px';
            }
            var posMap = {
                'left':{
                    top: posOff,
                    left:offPos
                },
                'up': {
                    left: posOff,
                    top: offPos
                },
                'right':{
                    top: posOff,
                    right: 0
                },
                'down':{
                    left: posOff,
                    bottom: 0
                }
            };
            if (!!this.config.pos) {
                this.tipArrow.css(this.config.pos);
            } else if (!!posMap[this.type]) {
                this.tipArrow.css(posMap[this.type]);
            }
        },
        /**
         * 设置位移，产生边缘效果
         */
        setMarginOffset:function() {
            var offset = -this.config.borderWidth + 'px';
            var offsetMap = {
                'left':{
                    'margin-left': offset,
                    'margin-top': offset
                },
                'up': {
                    'margin-left': offset,
                    'margin-top': offset
                },
                'right':{
                    'margin-top': offset
                },
                'down':{
                    'margin-left': offset
                }
            };
            this.tipBorder.css(offsetMap[this.type]);
        }
    };
})(jQuery);
