REM @Echo OFF

net use x: /delete

Set LocalDir="C:\Documents and Settings\webber-ling\Desktop\tmp"
net use X: \\10.197.49.95\test

xcopy %LocalDir%  X: /s /e

net use x: /delete

ECHO: You ARE READY TO GO!!!!!
pause