// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DT.VS4Mac.SolutionName.PreviewApp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSImageView bigImgView { get; set; }

		[Outlet]
		AppKit.NSImageView centerImageView { get; set; }

		[Outlet]
		AppKit.NSImageView middleImgView { get; set; }

		[Outlet]
		AppKit.NSTextField nameInput { get; set; }

		[Outlet]
		AppKit.NSImageView smallImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bigImgView != null) {
				bigImgView.Dispose ();
				bigImgView = null;
			}

			if (middleImgView != null) {
				middleImgView.Dispose ();
				middleImgView = null;
			}

			if (smallImageView != null) {
				smallImageView.Dispose ();
				smallImageView = null;
			}

			if (centerImageView != null) {
				centerImageView.Dispose ();
				centerImageView = null;
			}

			if (nameInput != null) {
				nameInput.Dispose ();
				nameInput = null;
			}
		}
	}
}
