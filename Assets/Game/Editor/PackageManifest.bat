@echo on
set srcFolder=C:\Users\7Cool\AppData\LocalLow\StrayFog\StrayFogUnity3d\ab_win\
set destFolder=C:\Users\7Cool\AppData\LocalLow\StrayFog\StrayFogUnity3d\ab_win_manifest\
RMDIR /s/q %destFolder%
MD %destFolder%
FOR %%F IN (%srcFolder%*.manifest) DO (MOVE %%F  %destFolder%)
ping -n 3 127.1>nul & exit
