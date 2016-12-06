using System;
using System.Collections.Generic;
using UIKit;

namespace AppleTableView.iOS
{
	public class AmountPickerModel : UIPickerViewModel
	{
		public int selectedIndex;
		public List<nint> cancelSelectedRow;

		List<string> items = new List<string>();

		public AmountPickerModel(List<string> _items)
		{
			this.items = _items;
			this.cancelSelectedRow = new List<nint>()
			{
				0
			};
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return items.Count;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return items[(int)row];
		}

		//需要選單停下後立即處理事件，才需用selected。
		//public override void Selected(UIPickerView pickerView, nint row, nint component)
		//{
		//	selectedIndex = (int)row;
		//	if (SelectChange != null)
		//	{
		//		SelectChange(this, new EventArgs());
		//	}
		//}

		public string selectItem(UIPickerView pickerView)
		{
			cancelSelectedRow[0] = pickerView.SelectedRowInComponent(0);
			return items[(int)pickerView.SelectedRowInComponent(0)];
		}
	}
}
