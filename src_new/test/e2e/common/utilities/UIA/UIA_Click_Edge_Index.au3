;~ *** Standard code maintainable ***
#include "UIAWrappers.au3"
AutoItSetOption("MustDeclareVars", 1)


;MsgBox(0, "", $Cmdline[1])


If $Cmdline[1]=="OK" Then
    _UIA_setVar("oUIElement","Title:=OK;controltype:=UIA_ButtonControlTypeId;class:=;INSTANCE:=" & $Cmdline[2])
 ElseIf $Cmdline[1]=="Upload" Then
    _UIA_setVar("oUIElement","Title:=Upload;controltype:=UIA_ButtonControlTypeId;class:=;INSTANCE:=" & $Cmdline[2])
 ElseIf $Cmdline[1]=="Browse" Then
    _UIA_setVar("oUIElement","Title:=Browse;controltype:=UIA_TextControlTypeId;class:=;INSTANCE:=" & $Cmdline[2])
 ElseIf $Cmdline[1]=="SaveAs" Then
    _UIA_setVar("oUIElement","Title:=Save as;controltype:=UIA_ButtonControlTypeId;class:=Button;INSTANCE:=" & $Cmdline[2])
 ElseIf $Cmdline[1]=="Close" Then
    _UIA_setVar("oUIElement","Title:=Close;controltype:=UIA_ButtonControlTypeId;class:=;INSTANCE:=" & $Cmdline[2])
 Else
    MsgBox(0, "Error", "Incorrect input parameter: " & $Cmdline[1])
    Exit
EndIf


_UIA_action("oUIElement","highlight")
_UIA_action("oUIElement","click")