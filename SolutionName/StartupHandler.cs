using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;

namespace DT.VS4Mac.SolutionName
{
    public class StartupHandler : CommandHandler
    {
        protected override void Run()
        {
            try
            {
                SolutionNameMonitor.Initialize();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("Error during ShowSolutionName startup", ex);
            }
        }
    }


}
