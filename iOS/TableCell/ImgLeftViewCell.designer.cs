// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AppleTableView.iOS
{
    [Register ("ImgLeftViewCell")]
    partial class ImgLeftViewCell
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
            if (btnBuy != null) {
                btnBuy.Dispose ();
                btnBuy = null;
            }

            if (btnInfo != null) {
                btnInfo.Dispose ();
                btnInfo = null;
            }

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
        }
    }
}