echo off
REM Use instructions:

REM Place this in the same file as the .apk file you want to install.
REM Replace the stuff in this file that is surrounded by <> with the paths specific to your system.
REM (You should only need to do this once unless you move things or change file names.)
REM Things that are outside the <> need to stay there, but the <> themselves should not stay.

REM Whenever you want to deploy the program to the emulator, start up the emulator and then double click this file.

echo copying apk
pushd "D:\Dev\Android\adt-bundle-windows-x86_64-20130729\sdk\platform-tools"
copy "%~dp0\example.apk"  %CD%

echo installing apk...
echo -uninstalling old apk 
echo If this fails it probably means this is your first time installing the apk and there is nothing to uninstall.
adb uninstall com.unity3d.player
echo -installing new apk
adb install example.apk

popd
pause