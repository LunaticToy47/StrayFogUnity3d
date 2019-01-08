@echo on
sqlite3 Game.db<ImportExcelToSQLite.bat
ping -n 3 127.1>nul & exit