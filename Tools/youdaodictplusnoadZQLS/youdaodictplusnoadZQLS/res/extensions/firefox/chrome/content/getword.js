/*
* @file getword.js
* @desc Get Word From Firefox 4+;
* @author  Dongxu Huang <huangdx@rd.netease.com>
* @date    2011-5-13
* 
*/
var eventRangeParent = null;
var eventTarget = null;
var eventRangeOffset = null;
var clientX = 0;
var clientY = 0;
var monX = 0;
var monY = 0;
var lastWord = null;
var currentDoc = null;
var consoleService = Components.classes["@mozilla.org/consoleservice;1"].getService(Components.interfaces.nsIConsoleService);

var obj;
function init()
{
		try {
              const cid = "@cidian.youdao.com/getword;1";
              obj = Components.classes[cid].createInstance();
              obj = obj.QueryInterface(Components.interfaces.IYoudaoFFGetWordHelper);

       } catch (err) {
              //alert(err);
              return;
       }
}
init();
var gPos  =0;
function getWord (parent, offset , target)
{
    try{
        if (parent.parentNode != target) {
            return null;
        }
    }
    catch (e) {
        return null;
    }
    
    if (parent.nodeType != Node.TEXT_NODE) {
        return null;
    }
    
    var container = parent.parentNode;
    if (container) {
        var foundNode = false;
        for (var c = container.firstChild; c !== null; c = c.nextSibling) {
            if (c == parent) {
                foundNode = true;
                break;
            }
        }
        if (!foundNode) {
            return null;
        }
    }
    var range = parent.ownerDocument.createRange();
    range.selectNode(parent);
    var str = range.toString();
    if (offset < 0 || offset >= str.length) {
          return null;
    }
    var start = offset;
    var end = offset + 1;
	/*
    var valid_chars = /\w/;
    if (!valid_chars.test(str.substring(start, start + 1))) {
         return null;
    }
	
    while (start > 0) { 
        if (valid_chars.test(str.substring(start - 1, start))) {
            start--;
        } else {
            break;
        }    
    }
    while (end < str.length) {
        if (valid_chars.test(str.substring(end, end + 1))) {
            end++;
        } else {
            break;
        }
    }
	*/
	space_cnt = 0;
	while (start > 0)
	{
		if (str.substring(start-1, start) == ' ')
			space_cnt++;
		if (space_cnt == 3)
			break;
		start--;
	}
	gPos = offset - start - 2 < 0?0:offset - start - 2;
	while(str[++gPos] == ' ');
	space_cnt = 0;
	while (end < str.length) {
        if (str.substring(end, end + 1) == ' ') {
            space_cnt++;
        }
        if (space_cnt == 3)
			break;
		end++;
    }
	
    var text = str.substring(start, end);
    return text.toLowerCase();
}

function on_mousemove(event)
{
    var eventDoc = null;
    var doc = event.target.ownerDocument;
    if (String(doc).indexOf("[object HTMLDocument]") != -1)
    {
        eventDoc = doc;
    }
    if (eventDoc != null)
    {
        if (currentDoc != eventDoc)
        {
            currentDoc = eventDoc;
        }
        eventTarget = event.target;
        if (eventTarget.tagName != "TEXTAREA" || eventTarget.tagName != "INPUT"  || eventTarget.tagName != "SELECT")
        {
            eventRangeParent = event.rangeParent;
            eventRangeOffset = event.rangeOffset;
            clientX = event.clientX;
            clientY = event.clientY;   
        }
    }
};

function get_mouse_word() {

  word = getWord(eventRangeParent, eventRangeOffset, eventTarget);
  if (word != null)
  {
	  return word;
  }
  return '';
}
function mouse_move_mon()
{
	word = get_mouse_word();
	if (word != '')
	{
		SendToDict(word,gPos);
	}
	window.setTimeout(mouse_move_mon, 80);
}
window.setTimeout(mouse_move_mon, 80);

function SendToDict(word, pos)
{
    var res = obj.sendWordToDict(word, pos);
}
