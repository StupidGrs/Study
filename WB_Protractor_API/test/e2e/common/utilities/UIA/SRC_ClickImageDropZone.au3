#include <AutoItConstants.au3>




Example()

Func Example()


    ; Wait 10 seconds for the Notepad window to appear.
    Local $hWnd = WinWait("[CLASS:ApplicationFrameInputSinkWindow]", "", 30)
     ;$hWnd = WinGetHandle("Open")
   WinSetState($hWnd, "", @SW_RESTORE)
    ; Activate the Notepad window using the handle returned by WinWait.
    WinActivate($hWnd)
	  MouseClick("left", 0, 975, 200)

	  Sleep(1000)

EndFunc   ;==>Example
