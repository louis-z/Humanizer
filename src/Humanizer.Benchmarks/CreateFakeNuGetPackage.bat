@echo off
setlocal

if /i "%~1" neq "release" (
    echo [%~nx0] Will only create fake NuGet package in Release configuration
    exit /b 0
)

set pkgCacheLocation=
for /f "usebackq tokens=2* delims= " %%p in (`dotnet nuget locals -l global-packages`) do (
    set pkgCacheLocation=%%p
)

if not defined pkgCacheLocation (
    set ERRMSG=Unable to determine NuGet package cache location
    goto EXIT_FAILURE
)

if not exist %pkgCacheLocation% (
    set ERRMSG=Cache '%pkgCacheLocation%' not found
    goto EXIT_FAILURE
)

set NEWDLL=%~dp0..\Humanizer\bin\%~1\netstandard2.0\Humanizer.dll
if not exist %NEWDLL% (
    set ERRMSG=%NEWDLL% not found
    goto EXIT_FAILURE
)

set SRCNUGET=%pkgCacheLocation%humanizer.core\2.8.26\
set DSTNUGET=%pkgCacheLocation%humanizer.core\2.8.99\
if not exist %SRCNUGET% (
    set ERRMSG=%SRCNUGET% not found
    goto EXIT_FAILURE
)

xcopy /E /Q /H /R /Y %SRCNUGET% %DSTNUGET%
xcopy /Q /R /Y %NEWDLL% %DSTNUGET%lib\netstandard2.0\Humanizer.dll

exit /b 0


:EXIT_FAILURE
echo [%~nx0] ERROR: %ERRMSG%
exit /b 1