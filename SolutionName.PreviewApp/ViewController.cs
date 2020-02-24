using System;
using AppKit;
using CoreGraphics;
using Foundation;

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

            // Do any additional setup after loading the view.

            PreserveOriginalIcon();

            nameInput.Changed += NameInput_Changed;
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();

            UpdateImages();
        }

        private void NameInput_Changed(object sender, EventArgs e)
        {
            UpdateImages();
        }

        private void UpdateImages()
        {
            var text = nameInput.StringValue;

            var image = RenderSolutionNameIcon(text);

            bigImgView.Image = image;
            centerImageView.Image = image;
            middleImgView.Image = image;
            smallImageView.Image = image;

            NSApplication.SharedApplication.ApplicationIconImage = image;
        }

        private void PreserveOriginalIcon()
        {
            var original = NSApplication.SharedApplication.ApplicationIconImage;
            _defaultImage = new NSImage(original.AsTiff());
        }

        private NSImage RenderSolutionNameIcon(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                const float margin = 4;
                NSString text = (NSString)name;
                var paragraphStyle = (NSParagraphStyle)NSParagraphStyle.DefaultParagraphStyle.MutableCopy();
                paragraphStyle.Alignment = NSTextAlignment.Center;
                var attributes = new NSStringAttributes()
                {
                    Font = NSFont.SystemFontOfSize(19, NSFontWeight.Regular),
                    ForegroundColor = NSColor.White,
                    ParagraphStyle = paragraphStyle
                };

                var textRect = new CoreGraphics.CGSize(_defaultImage.Size.Width - margin * 2, _defaultImage.Size.Height - 2 * margin);
                var rect = text.BoundingRectWithSize(textRect, NSStringDrawingOptions.UsesLineFragmentOrigin, attributes.Dictionary);

                var centerAdjustment = _defaultImage.Size.Width - rect.Width - 2 * margin;
                rect.Offset(margin + centerAdjustment / 2, margin);

                var brandedImage = NSImage.ImageWithSize(_defaultImage.Size, false, (dstRect) =>
                {
                    _defaultImage.Draw(dstRect);
                    DrawBackgroundInRect(rect);
                    text.DrawInRect(rect, attributes);
                    return true;
                });

                return brandedImage;
            }
            else
            {
                return _defaultImage;
            }
        }

        private static void DrawBackgroundInRect(CGRect rect)
        {
            var backgroundColor = NSColor.FromRgba(50, 50, 50, 240).CGColor;
            var borderColor = NSColor.FromRgba(100, 100, 100, 240).CGColor;
            nfloat radius = 6;

            var context = NSGraphicsContext.CurrentContext.CGContext;
            context.SaveState();
            context.SetFillColor(backgroundColor);
            context.SetStrokeColor(borderColor);
            var path = NSBezierPath.FromRoundedRect(rect, radius, radius);
            path.LineWidth = 2;
            path.Stroke();
            path.Fill();
            context.RestoreState();
        }
    }
}
