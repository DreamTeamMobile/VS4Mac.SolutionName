#!/bin/bash

VS_ICONS_PATH="/Applications/Visual Studio.app/Contents/Resources/VisualStudio.icns"
TMP_FOLDER_NAME="tmp_old_icons"

# cleanup
rm -rf "$TMP_FOLDER_NAME"

# copy VS icons
cp "$VS_ICONS_PATH" VisualStudio.icns
#cp /Applications/Android\ Studio.app/Contents/Resources/studio.icns VisualStudio.icns

# split icons
iconutil --convert iconset VisualStudio.icns

# backup previous
mkdir "$TMP_FOLDER_NAME" && cp Assets.xcassets/AppIcon.appiconset/* "$TMP_FOLDER_NAME"

# set to app
cp -rf VisualStudio.iconset/* Assets.xcassets/AppIcon.appiconset/

# cleanup
rm -rf VisualStudio.icns
rm -rf VisualStudio.iconset