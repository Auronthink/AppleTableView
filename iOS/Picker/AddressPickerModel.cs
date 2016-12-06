using System;
using System.Collections.Generic;
using UIKit;

namespace AppleTableView.iOS
{
	public class AddressPickerModel : UIPickerViewModel
	{
		private List<string> cityList;
		private List<List<string>> areaList;
		private nint selectedRow;
		public List<nint> cancelSelectedRow;

		public AddressPickerModel(List<string> _cityList, List<List<string>> _areaList)
		{
			this.cityList = _cityList;
			this.areaList = _areaList;
			this.selectedRow = 0;
			this.cancelSelectedRow = new List<nint>()
			{
				0,
				0
			};
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 2;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			switch (component)
			{
				case 0:
					return cityList.Count;
				case 1:
					return areaList[(int)selectedRow].Count;
				default:
					return 0;
			}
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			switch (component)
			{
				case 0:
					return cityList[(int)row];
				case 1:
					return areaList[(int)selectedRow][(int)row];
				default:
					return String.Empty;
			}
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			if (component == 0)
			{
				selectedRow = pickerView.SelectedRowInComponent(component);
				pickerView.ReloadComponent(1);
				pickerView.Select(0, 1, true);
			}
		}

		public string selectAddr(UIPickerView pickerView)
		{
			//這裡用foreach會掛掉
			//foreach (var doneRow in cancelSelectedRow)
			//{
			//	cancelSelectedRow[cancelSelectedRow.IndexOf(doneRow)] = pickerView.SelectedRowInComponent(cancelSelectedRow.IndexOf(doneRow));
			//}
			for (int i = 0; i < cancelSelectedRow.Count; i++)
			{
				cancelSelectedRow[i] = pickerView.SelectedRowInComponent(i);
			}

			return cityList[(int)pickerView.SelectedRowInComponent(0)]
					+ " "
					+ areaList[(int)pickerView.SelectedRowInComponent(0)][(int)pickerView.SelectedRowInComponent(1)];
		}
	}
}
