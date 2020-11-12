@Echo OFF

ECHO Copy Start.............

Set NetDir_From="\\USDFW14WS52V\Stu Drop\QA3\WB_TMP"
Set NetDir_To="\\USDFW14WS52V\Stu Drop\QA3\WB_TMP\destination"

Set File_Name_1="readme.txt"
Set File_Name_2="readme_1.txt"


copy %NetDir_From%\%File_Name_1%  %NetDir_To%\%File_Name_1%
copy %NetDir_From%\%File_Name_2%  %NetDir_To%\%File_Name_2%

ECHO Copy Finished..................
pause







