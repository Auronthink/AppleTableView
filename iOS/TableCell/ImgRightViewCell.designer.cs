// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppleTableView.iOS
{
	[Register ("ImgRightViewCell")]
	partial class ImgRightViewCell
	{
		[Outlet]
		UIKit.UIButton btnBuy { get; set; }

		[Outlet]
		UIKit.UIButton btnInfo { get; set; }

		[Outlet]
		UIKit.UIImageView imgProduct { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UILabel lblPrice { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgProduct != null) {
				imgProduct.Dispose ();
				imgProduct = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (lblPrice != null) {
				lblPrice.Dispose ();
				lblPrice = null;
			}

			if (btnInfo != null) {
				btnInfo.Dispose ();
				btnInfo = null;
			}

			if (btnBuy != null) {
				btnBuy.Dispose ();
				btnBuy = null;
			}
		}
	}
}
