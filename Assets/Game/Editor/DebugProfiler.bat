@echo on
adb forward --remove-all
pause
adb kill-server
pause
adb start-server
adb forward tcp:34999 localabstract:Unity-com.Company.ProductName
pause