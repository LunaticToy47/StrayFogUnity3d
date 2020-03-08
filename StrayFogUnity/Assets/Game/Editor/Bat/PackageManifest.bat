@echo on
set srcFolder=C:\Users\Bzl\AppData\LocalLow\StrayFog\StrayFogUnity3d\ab_win
set destFolder=C:\Users\Bzl\AppData\LocalLow\StrayFog\StrayFogUnity3d\ab_win_manifest
RMDIR /s/q %destFolder%
MD %destFolder%
setlocal enabledelayedexpansion
FOR /r %srcFolder% %%F in (*.manifest) do ( 
set "file=%%F"
set "dir=%%~dpF"
if exist %%F (
set "file=!file:%srcFolder%=%destFolder%!"
set "dir=!dir:%srcFolder%=%destFolder%!"
MD !dir!
MOVE %%F !file!
)
)
setlocal disabledelayedexpansion
ping -n 3 127.1>nul & exit