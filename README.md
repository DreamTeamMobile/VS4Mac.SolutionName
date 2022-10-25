SolutionName extension for Visual Studio for Mac
====

This extension shows current solution name in the Visual Studio for Mac dock and app switcher (Cmd-Tab) tile.

Helps navigating between multiple projects.

### How it looks

<img src="Meta/large-screenshot.png?raw=true" width="1024" />

More screenshots [here](Meta).


### Preview builds

The repo now has Github actions configured to build each commit in `preview/*` branches and pack an extension and attach it to the action job.

This should help making minor changes and ensure that the package is built from the actual Github source.


#### Download

Download `.mpack` file from [Releases](https://github.com/DreamTeamMobile/VS4Mac.SolutionName/releases/)

Then install it in **Visual Studio for Mac > Extensions... > Install from file...**

#### Other notes 

To update `.mpack` file, update version:

1. Compile in Release
2. Run bash script: `pack.sh`

To fast apply any changes to this extension you can follow these steps:

1. Add any changes to `SolutionName/SolutionNameRenderer.cs` to change app icon view;
2. Run **SolutionName.PreviewApp** (macOS app);
3. When VS4Mac will update application icon you can update new app icon for *PreviewApp* via script: `SolutionName/SolutionName.PreviewApp/get-vs-icons.sh`

> **IMPORTANT**: Changes in `SolutionNameRenderer` are shared with extension logic.


#### Helpful links:

https://blog.lextudio.com/how-to-write-add-ins-of-visual-studio-for-mac-ee6113db5ddf

https://github.com/mrward?tab=repositories

#### Check our other extensions

https://github.com/alexsorokoletov/VisualStudioMac.SortRemoveUsings
