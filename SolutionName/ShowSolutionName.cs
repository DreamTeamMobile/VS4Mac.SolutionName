using AppKit;
using Foundation;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace DT.VS4Mac.SolutionName
{
    public static class SolutionNameMonitor
    {
        private static string _lastSolutionName = string.Empty;
        private static NSImage _defaultImage;

        static void CurrentSelectedSolution_NameChanged(object sender, WorkspaceItemRenamedEventArgs e)
        {
            RefreshSolutionName();
        }

        static void Workspace_SolutionUnloaded(object sender, SolutionEventArgs e)
        {
            UnsubscribeFromNameChange(e.Solution);
            RefreshSolutionName();
        }

        private static void Workspace_SolutionLoaded(object sender, SolutionEventArgs e)
        {
            SubscribeForNameChange(e.Solution);
            RefreshSolutionName(e.Solution);
        }

        private static void SubscribeForNameChange(Solution solution)
        {
            if (solution == null)
                return;
            solution.NameChanged += CurrentSelectedSolution_NameChanged;
        }

        private static void UnsubscribeFromNameChange(Solution solution)
        {
            if (solution == null)
                return;
            solution.NameChanged -= CurrentSelectedSolution_NameChanged;
        }

        public static void Initialize()
        {
            IdeApp.Workspace.SolutionLoaded += Workspace_SolutionLoaded;
            IdeApp.Workspace.SolutionUnloaded += Workspace_SolutionUnloaded;
            PreserveOriginalIcon();
            RefreshSolutionName();
        }

        private static void PreserveOriginalIcon()
        {
            var original = NSApplication.SharedApplication.ApplicationIconImage;
            _defaultImage = new NSImage(original.AsTiff());
        }

        private static void RefreshSolutionName(Solution solution = null)
        {
            var currentSolution = solution ?? IdeApp.ProjectOperations.CurrentSelectedSolution;
            var solutionName = currentSolution == null ? string.Empty : currentSolution.Name;
            if (solutionName != _lastSolutionName)
            {
                _lastSolutionName = solutionName;
                RenderSolutionNameIcon(solutionName);
            }
        }

        private static void RenderSolutionNameIcon(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                const float margin = 5;
                NSString text = (NSString)name;
                var attributes = new NSStringAttributes()
                {
                    Font = NSFont.SystemFontOfSize(16),
                    ForegroundColor = NSColor.White,
                    ParagraphStyle = NSParagraphStyle.DefaultParagraphStyle,
                };
                var textRect = new CoreGraphics.CGSize(_defaultImage.Size.Width - margin * 2, _defaultImage.Size.Height - 2 * margin);
                var rect = text.BoundingRectWithSize(textRect, NSStringDrawingOptions.UsesLineFragmentOrigin, attributes.Dictionary);
                rect.Offset(margin, margin);
                var brandedImage = NSImage.ImageWithSize(_defaultImage.Size, false, (dstRect) =>
                {
                    _defaultImage.Draw(dstRect);
                    text.DrawInRect(rect, attributes);
                    return true;
                });
                NSApplication.SharedApplication.ApplicationIconImage = brandedImage;
            }
            else
            {
                NSApplication.SharedApplication.ApplicationIconImage = _defaultImage;
            }
        }
    }
}
