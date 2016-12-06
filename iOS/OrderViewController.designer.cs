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
    [Register ("OrderViewController")]
    partial class OrderViewController
    {
        [Outlet]
        UIKit.UIImageView imgProduct { get; set; }


        [Outlet]
        UIKit.UILabel lblName { get; set; }


        [Outlet]
        UIKit.UILabel lblPrice { get; set; }


        [Outlet]
        UIKit.UILabel lblTotalPrice { get; set; }


        [Outlet]
        UIKit.UITextField txtAddress { get; set; }


        [Outlet]
        UIKit.UITextField txtAmount { get; set; }


        [Outlet]
        UIKit.UITextField txtDate { get; set; }

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

            if (lblTotalPrice != null) {
                lblTotalPrice.Dispose ();
                lblTotalPrice = null;
            }

            if (txtAddress != null) {
                txtAddress.Dispose ();
                txtAddress = null;
            }

            if (txtAmount != null) {
                txtAmount.Dispose ();
                txtAmount = null;
            }

            if (txtDate != null) {
                txtDate.Dispose ();
                txtDate = null;
            }
        }
    }
}