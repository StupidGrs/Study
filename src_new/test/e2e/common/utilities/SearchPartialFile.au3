#Include <WinAPI.au3>
#include <Array.au3>
#include <WinAPIShPath.au3>
#include <AutoItConstants.au3>

      	 Dim $file=$CmdLine[1]

		   Dim $array = StringSplit($file, "\")
		   Dim $iBound=UBound($array)
		   Dim $fileDir=StringLeft($file,StringLen($file)-StringLen($array [$iBound-1]))
		   $search = FileFindFirstFile($fileDir & "*.partial")

         MsgBox(0, "Search Partial File", $search ,1)
If ($search=-1) then

      ;MsgBox(0, "Search Paritial File", "Partial File not exist, search="&$search ,1)
 Else
	  MsgBox( "Search Paritial File", "Partial File exists,Please Delete it from here: "&$fileDir, 'search='&$search )

;~ 	      ; Delete the temporary file.
;~     Local $iDelete = FileDelete($fileDir )

;~     ; Display a message of whether the file was deleted.
;~     If $iDelete Then
;~         MsgBox(0,"", "The file was successfuly deleted.",3)
;~     Else
;~         MsgBox($MB_SYSTEMMODAL, "", "An error occurred whilst deleting the file.")
;~     EndIf


EndIf