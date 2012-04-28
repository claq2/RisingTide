@echo on
setlocal EnableDelayedExpansion
set fail=
for /f "tokens=*" %%a in (fail.txt) do set fail=!fail!\n%%a
echo !fail!
"c:\utils\growl for windows\growlnotify.exe" "!fail!"

