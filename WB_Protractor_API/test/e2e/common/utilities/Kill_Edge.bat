@echo off

QPROCESS "MicrosoftEdge.exe" >nul 2>&1 && (
    TaskKill /F /IM MicrosoftEdge.exe

)|| (
    exit /b 0
)

