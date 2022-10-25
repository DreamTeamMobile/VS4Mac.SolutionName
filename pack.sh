#!/bin/bash

FULL_PATH="$( cd -- "$(dirname "$0")" > /dev/null 2>&1 ; pwd -P )"
DLL_PATH="$FULL_PATH/SolutionName/bin/Release/net6.0-macos/osx-x64/DT.VS4Mac.SolutionName.dll"
OUTPUT_PATH="$FULL_PATH/Releases"

/Applications/Visual\ Studio.app/Contents/MacOS/vstool setup pack $DLL_PATH -d:$OUTPUT_PATH
