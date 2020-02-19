#!/bin/bash

VSTOOL_PATH="/Applications/Visual Studio.app/Contents/Resources/lib/monodevelop/bin/vstool.exe"
DLL_PATH="SolutionName/bin/Release/DT.VS4Mac.SolutionName.dll"

mono "$VSTOOL_PATH" setup pack "$DLL_PATH" -d:Releases
