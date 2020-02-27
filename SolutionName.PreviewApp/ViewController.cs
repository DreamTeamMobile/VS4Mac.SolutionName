using System;
using AppKit;

namespace DT.VS4Mac.SolutionName.PreviewApp
{
    public partial class ViewController : NSViewController
    {
        private static NSImage _defaultImage;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PreserveOriginalIcon();

            nameInput.Changed += NameInput_Changed;
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();

            UpdateImages();
        }
        
        private static void PreserveOriginalIcon()
        {
            var original = NSApplication.SharedApplication.ApplicationIconImage;
            _defaultImage = new NSImage(original.AsTiff());
        }

        private void NameInput_Changed(object sender, EventArgs e)
        {
            UpdateImages();
        }

        private void UpdateImages()
        {
            var text = nameInput.StringValue;
            var image = SolutionNameRenderer.CreateIconWithSolutionName(text, _defaultImage);

            bigImgView.Image = image;
            centerImageView.Image = image;
            middleImgView.Image = image;
            smallImageView.Image = image;

            NSApplication.SharedApplication.ApplicationIconImage = image;
        }
    }
}
