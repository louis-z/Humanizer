@echo off
setlocal

set cache=
for /f "usebackq tokens=2* delims= " %%p in (`dotnet nuget locals -l global-packages`) do (
    set cache=%%p
)

if not defined cache (
    echo ERROR: Unable to determine NuGet cache
    exit /b 1
)

if not exist %cache% (
    echo ERROR: Cache '%cache%' not found
    exit /b 1
)

set NEWDLL=%~dp0..\Humanizer\bin\Release\netstandard2.0\Humanizer.dll
if not exist %NEWDLL% (
    echo ERROR: %NEWDLL% not found
    exit /b 1
)

set SRCNUGET=%cache%humanizer.core\2.8.26\
set DSTNUGET=%cache%humanizer.core\2.8.99\
if not exist %SRCNUGET% (
    echo ERROR: %SRCNUGET% not found
    exit /b 1
)

xcopy /E /Q /H /R /Y %SRCNUGET% %DSTNUGET%
xcopy /Q /R /Y %NEWDLL% %DSTNUGET%lib\netstandard2.0\Humanizer.dll

exit /b 0