using System;
using Foundation;
using UIKit;

namespace AppleTableView.iOS
{
	public class MyDatePicker : UIDatePicker
	{
		public NSDate initDate { get; set; }

		public MyDatePicker()
		{
			this.initDate = this.Date;
		}

		public override bool Selected
		{
			get
			{
				return base.Selected;
			}
			set
			{
				base.Selected = value;
			}
		}
	}
}
