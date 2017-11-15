SolutionName extension for Visual Studio for Mac
====

This extension shows current solution name in the Visual Studio for Mac dock and app switcher (Cmd-Tab) tile.

Helps navigating between multiple projects.

### Preview

<img src="Meta/screenshot.png?raw=true" width="760" />


<img src="Meta/large-screenshot.png?raw=true" width="760" />

#### Download

Download .mpack file from [Releases](https://github.com/DreamTeamMobile/VS4Mac.SolutionName/releases/tag/1.1) 

Then install it in Visual Studio for Mac -> Extensions.. -> Install from file


#### Other notes

To update .mpack file, update version, compile in Release and then run:	

`mono /Applications/Visual\ Studio.app/Contents/Resources/lib/monodevelop/bin/vstool.exe setup pack SolutionName/bin/Release/DT.VS4Mac.SolutionName.dll`


#### Helpful links:

https://blog.lextudio.com/how-to-write-add-ins-of-visual-studio-for-mac-ee6113db5ddf

https://github.com/mrward?tab=repositories

#### Check our other extensions

https://github.com/alexsorokoletov/VisualStudioMac.SortRemoveUsings