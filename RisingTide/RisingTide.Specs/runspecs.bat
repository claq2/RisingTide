@echo on
setlocal EnableDelayedExpansion
C:\utils\Machine.Specifications-Release\mspec-clr4.exe --html .\specs.html %1|find "FAIL">fail.txt
set fail=
for /f "tokens=*" %%a in (fail.txt) do set fail=!fail!\n%%a
echo !fail!
if not "!fail!"=="" "c:\utils\growl for windows\growlnotify.exe" /t:Build /i:.\red.jpg "!fail!"
if "!fail!"=="" "c:\utils\growl for windows\growlnotify.exe" /t:Build /i:.\green.jpg "All passed"
