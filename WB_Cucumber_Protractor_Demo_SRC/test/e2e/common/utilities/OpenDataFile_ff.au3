#include <AutoItConstants.au3>




Example()

Func Example()


    ; Wait 10 seconds for the Notepad window to appear.
    Local $hWnd = WinWait("[CLASS:#32770]", "", 30)
     $hWnd = WinGetHandle("File Upload")
   WinSetState($hWnd, "", @SW_RESTORE)
    ; Activate the Notepad window using the handle returned by WinWait.
    WinActivate($hWnd)
	  ControlClick($hWnd, "", "Edit1")
      ControlSetText($hWnd, "", "Edit1", $Cmdline[1])
      ControlClick($hWnd, "", "Button1")
	  ;Send($Cmdline[1])
	  ;Send($Cmdline[1] & "{TAB}")
	  ;Send("{ENTER}")
	  Sleep(1000)
    ; Close the Notepad window using the handle returned by WinWait.
    ;WinClose($hWnd)
EndFunc   ;==>Example





