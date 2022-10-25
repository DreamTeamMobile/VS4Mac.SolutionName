using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace DT.VS4Mac.SolutionName
{
    public static class SolutionNameRenderer
    {
        public static NSImage CreateIconWithSolutionName(string name, NSImage baseImage)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return baseImage;
            }

            const float margin = 4;
            var text = (NSString)name;

            // setup text styles
            var paragraphStyle = (NSParagraphStyle)NSParagraphStyle.Default.MutableCopy();
            paragraphStyle.Alignment = NSTextAlignment.Center;
            var attributes = new NSStringAttributes
            {
                Font = NSFont.SystemFontOfSize(19, NSFontWeight.Regular),
                ForegroundColor = NSColor.White,
                ParagraphStyle = paragraphStyle
            };

            // setup rect
            var textRect = new CGSize(baseImage.Size.Width - margin * 2, baseImage.Size.Height - 2 * margin);
            var rect = text.BoundingRectWithSize(textRect, NSStringDrawingOptions.UsesLineFragmentOrigin, attributes.Dictionary);
            var centerAdjustment = baseImage.Size.Width - rect.Width - 2 * margin;
            rect.Offset(margin + centerAdjustment / 2, margin);

            // create image
            var brandedImage = NSImage.ImageWithSize(baseImage.Size, false, dstRect =>
            {
                baseImage.Draw(dstRect);
                DrawBackgroundInRect(rect);
                text.DrawInRect(rect, attributes);
                return true;
            });

            return brandedImage;
        }

        public static void DrawBackgroundInRect(CGRect rect)
        {
            var backgroundColor = NSColor.FromRgba(50, 50, 50, 240).CGColor;
            var borderColor = NSColor.FromRgba(100, 100, 100, 240).CGColor;
            float radius = 6;

            var context = NSGraphicsContext.CurrentContext.CGContext;
            context.SaveState();

            // set colors
            context.SetStrokeColor(borderColor);
            context.SetFillColor(backgroundColor);

            // add border with corner radius
            var path = NSBezierPath.FromRoundedRect(rect, radius, radius);
            path.LineWidth = 2;
            path.Stroke();
            path.Fill();

            context.RestoreState();
        }
    }
}