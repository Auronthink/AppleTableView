using Foundation;
using System;
using UIKit;
using ObjCRuntime;

namespace AppleTableView.iOS
{
    public partial class PickerToolbarView : UIView
    {
		public event EventHandler<EventArgs> DoneEvent;
		public event EventHandler<EventArgs> CancelEvent;

        public PickerToolbarView (IntPtr handle) : base (handle)
        {
        }

		public static PickerToolbarView Create()
		{
			var arr = NSBundle.MainBundle.LoadNib("PickerToolbarView", null, null);
			return Runtime.GetNSObject<PickerToolbarView>(arr.ValueAt(0));
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			btnDone.TouchUpInside += (sender, e) =>
			{
				DoneEvent(sender, e);
			};

			btnCancel.TouchUpInside += (sender, e) =>
			{
				CancelEvent(sender, e);
			};
		}
    }
}