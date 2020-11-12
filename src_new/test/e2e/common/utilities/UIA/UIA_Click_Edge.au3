;~ *** Standard code maintainable ***
#include "UIAWrappers.au3"
AutoItSetOption("MustDeclareVars", 1)


;MsgBox(0, "", $Cmdline[1])


If $Cmdline[1]=="OK" Then
    ;_UIA_setVar("oUIElement","Title:=" & $Cmdline[1] & ";controltype:=UIA_ButtonControlTypeId;class:=")
    _UIA_setVar("oUIElement","Title:=OK;controltype:=UIA_ButtonControlTypeId;class:=") ;ControlType:=UIA_ButtonControlTypeId;classname:=")
 ElseIf $Cmdline[1]=="Upload" Then
    _UIA_setVar("oUIElement","Title:=Upload;controltype:=UIA_ButtonControlTypeId;class:=")
 ElseIf $Cmdline[1]=="Browse" Then
    _UIA_setVar("oUIElement","Title:=Browse;controltype:=UIA_TextControlTypeId;class:=")
 ElseIf $Cmdline[1]=="SaveAs" Then
    _UIA_setVar("oUIElement","Title:=Save as;controltype:=UIA_ButtonControlTypeId;class:=Button")
 ElseIf $Cmdline[1]=="Close" Then
    _UIA_setVar("oUIElement","Title:=Close;controltype:=UIA_ButtonControlTypeId;class:=")
 ElseIf $Cmdline[1]=="Cancel" Then
_UIA_setVar("oUIElement","Title:=Cancel;controltype:=UIA_ButtonControlTypeId;class:=Button")
 Else
    MsgBox(0, "Error", "Incorrect input parameter: " & $Cmdline[1])
    Exit
EndIf



_UIA_action("oUIElement","highlight")
_UIA_action("oUIElement","click")