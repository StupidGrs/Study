#Include <WinAPI.au3>
#include <Array.au3>
#include <WinAPIShPath.au3>
#include <AutoItConstants.au3>

      	 Dim $file=$CmdLine[1]

		   Dim $array = StringSplit($file, "\")
		   Dim $iBound=UBound($array)
		   Dim $fileDir=StringLeft($file,StringLen($file)-StringLen($array [$iBound-1]))
		   $search = FileFindFirstFile($fileDir & "*.partial")

            For $iWait1=1 to 40

			   $search = FileFindFirstFile($fileDir & "*.partial")
			   ;  MsgBox(0, "Search Partial File", $search ,1)
			   ;  MsgBox(0, "Check File exists", FileExists($file),2)

				  If FileExists($file)=1 And $search =-1 Then
					  ;close the bottom bar
                     MsgBox(0, "File exist & partial file not found", "Close the bottom bar",1)
					  ExitLoop
				  Else
					 sleep (8000)
				  EndIf

			Next