@Echo OFF

REM *set the local directory to copy the build file to
Set LocalDir=C:\Documents and Settings\webber-ling\Desktop
cd LocalDir

REM * Ask for user input for the build version
:UserInputBuildVersion
ECHO Please type in the builder version, e.g. QA1:
SET /P USRINPUTVersion=

REM * Ask for user input for the build number
:UserInputBuildNumer
ECHO Please type in the builder number, e.g. 20110228.1:
SET /P USRINPUT=


REM *net use a: \\USDFW14WS52V\stu drop\QA1
Set NetDir="\\USDFW14WS52V\stu drop\%USRINPUTVersion%"


REM * Check the input builder zip file exist in network dirve or not
If NOT Exist %NetDir%\%USRINPUTVersion%_%USRINPUT%\%USRINPUTVersion%_%USRINPUT%.zip GOTO :NetZipFileNOTExist
ECHO File "%NetDir%\%USRINPUTVersion%_%USRINPUT%\%USRINPUTVersion%_%USRINPUT%.zip" Exists! 
GOTO :NetZipFileExist

REM *go back to user input if the input build file NOT exist
:NetZipFileNOTExist
ECHO File "%NetDir%\%USRINPUTVersion%_%USRINPUT%\%USRINPUTVersion%_%USRINPUT%.zip" NOT Exists!
Echo Please double check and re-enter the builder number!
Echo *********************************************************
Echo.
ECHO Retry........
GOTO :UserInputBuildVersion


REM *If the build file exists, go ahead to copy it to local directory which is predifined
:NetZipFileExist
REM * IF zip file exist, copy the zip file to local drive
ECHO: Copying file: "%NetDir%\%USRINPUTVersion%_%USRINPUT%\%USRINPUTVersion%_%USRINPUT%.zip" to local drive: %LocalDir%\%USRINPUTVersion%_%USRINPUT%.zip
ECHO: Please wait...........
Copy /Y %NetDir%\%USRINPUTVersion%_%USRINPUT%\%USRINPUTVersion%_%USRINPUT%.zip %USRINPUTVersion%_%USRINPUT%.zip

REM *wait 10 seconds to make sure the file is properly copied to local drive
REM *PING -n 10 127.0.0.1 >NUL
IF NOT Exist %USRINPUTVersion%_%USRINPUT%.zip GOTO :ERRORNetFileCopy  
GoTo :ZipFileCopiedToLocal

REM *Exit the batch run if failed to copy the build file to local
:ERRORNetFileCopy  
ECHO: Failed to copy build from Network drive!
pause
GOTO :Stop

REM *Unzip the local build file 
:ZipFileCopiedToLocal
ECHO: File "%LocalDir%\%USRINPUTVersion%_%USRINPUT%.zip" successfully copied!
ECHO: Extracting zip file "%LocalDir%\%USRINPUTVersion%_%USRINPUT%.zip" to "%LocalDir%\%USRINPUTVersion%_%USRINPUT%"......
"C:\Program Files (x86)\WinZip\winzip32.exe" -min -e -o %USRINPUTVersion%_%USRINPUT%.zip %USRINPUTVersion%_%USRINPUT%
IF NOT Exist %USRINPUTVersion%_%USRINPUT%\Client\RetirementStudio.exe GOTO :ERRORExtractZipFile
GOTO :END

REM *Exit the batch run if expected file not unzip correctly
:ERRORExtractZipFile
ECHO: Failed to extract local file: %LocalDir%\%USRINPUTVersion%_%USRINPUT%.zip
pause
GOTO :Stop
  

REM *Print congratulation if build file successfully copied from network drive and unzipped into local directory
:End
ECHO: Delete zip file "%LocalDir%\%USRINPUTVersion%_%USRINPUT%.zip"
Del /F %USRINPUTVersion%_%USRINPUT%.zip
ECHO: Congratulaions !!!!!
ECHO: You ARE READY TO GO!!!!!
REM *pause

REM *Exit the batch run
:Stop
Exit

