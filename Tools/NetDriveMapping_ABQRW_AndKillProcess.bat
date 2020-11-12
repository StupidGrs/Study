REM @Echo OFF

net use A: /delete
net use Q: /delete
net use W: /delete
net use R: /delete
net use B: /delete


net use A: \\AUME13V0128\Shanghai_Shared_Drive\Projects\RTG_QA_Automation_Framework
net use R: \\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA
net use Q: \\mercer.com\US_Data\Shared\Dfl\Data1\RSS\SQA\RETIRE_STUDIO_BENCHMARK_CLIENTS_2\QTP_MasterExecution\QDrive
net use W: \\AUME13V0128\Shanghai_Shared_Drive\Personal\Webber_Ling
net use B: \\USDFW14WS52V



TaskKill /F /IM BaofengPlatform.exe
TaskKill /F /IM BFOnlineR.exe
TaskKill /F /IM BFVDesktop.exe
TaskKill /F /IM BFVServer.exe
TaskKill /F /IM stormpop.exe


REM ECHO: You ARE READY TO GO!!!!!
REM pause