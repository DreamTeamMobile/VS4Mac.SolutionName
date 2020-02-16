using System.Reflection;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
    "DT.VS4Mac.SolutionName",
    Namespace = "DT.VS4Mac.SolutionName",
    Version = "1.1"
)]

[assembly: AddinName("DT.VS4Mac.SolutionName")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("Shows solution name in Mac app switcher and doc")]
[assembly: AddinAuthor("DreamTeam Mobile, LLC")]

[assembly: AssemblyTitle("DT.SolutionName")]
[assembly: AssemblyDescription("Visual Studio for Mac Add-in to show current solution name")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("DreamTeam Mobile, LLC")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.1.*")]

[assembly: AddinDependency("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly: AddinDependency("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]