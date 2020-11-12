function sendkey

dim WShell

 

for i=0 to 9000


Set WShell = CreateObject("WScript.Shell")


WShell.SendKeys "{SCROLLLOCK}"

WScript.Sleep 1000

WShell.SendKeys "{SCROLLLOCK}"
 

WScript.Sleep 600000
 

Next

 

 

end function

 

call sendkey
