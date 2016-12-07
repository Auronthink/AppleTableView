using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;


namespace AppleTableView.iOS
{
	public class MyPickerModel : UIPickerViewModel
	{

		private int componentCount;
		private List<PickerContent> PickerContentList;
		private List<int> selectedRow = new List<int>();
		public  List<int> originalSelectedRow = new List<int>();

		public MyPickerModel(int _comonentCount, List<PickerContent> _pickerContentList)
		{
			this.componentCount		= _comonentCount;
			this.PickerContentList  = _pickerContentList;

			for (int i = 0; i < this.componentCount; i++)
			{
				this.selectedRow.Add(0);
				this.originalSelectedRow.Add(0);
			}
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return this.componentCount;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			List<PickerContent> rowsCount = new List<PickerContent>();

			// 取出屬於該Component層級的Data
			rowsCount = PickerContentList.Where(val => val.componentIndex == component).ToList();
			// 依照ComponentPath層級相依抓Data
			for (int i = 0; i < component; i++)
			{
				rowsCount = rowsCount.Where(val => val.componentPath[i].Equals(selectedRow[i])).ToList();
			}
			return rowsCount.Count;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			List<PickerContent> selectAddressData = new List<PickerContent>();

			// 取出屬於該Component層級的Data
			selectAddressData = PickerContentList.Where(val => val.componentIndex == component).ToList();
			// 依照ComponentPath層級相依抓Data
			for (int i = 0; i < component; i++)
			{
				selectAddressData = selectAddressData.Where(val => val.componentPath[i].Equals(selectedRow[i])).ToList();
			}
			// 依照自身層級的rowIndex排序
			selectAddressData = selectAddressData.OrderBy(val => val.componentPath[(int)component]).ToList();

			if (selectAddressData.Count != 0)
			{
				return selectAddressData[(int)row].title;
			} else {
				return string.Empty;
			}
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			this.selectedRow[(int)component] = (int)row;

			if ((int)component < this.componentCount-1)
			{
				selectedRow[(int)component] = (int)pickerView.SelectedRowInComponent(component);
				for (int i = (int)component; i < componentCount-1; i++)
				{
					pickerView.ReloadComponent(i + 1);
					pickerView.Select(0, i + 1, true);
					selectedRow[i + 1] = 0;
				}
			}
		}

		public List<string> pickerSelectDone(UIPickerView pickerView)
		{
			List<string> selectedDataList = new List<string>();
			// update CancelSelectedRow & set selected Data List
			for (int i = 0; i < pickerView.NumberOfComponents; i++)
			{
				originalSelectedRow[i] = (int)pickerView.SelectedRowInComponent(i);

				selectedDataList.Add(this.GetTitle(pickerView, pickerView.SelectedRowInComponent(i), i));
			}
			return selectedDataList;
		}

		public void pickerSelectCancel(UIPickerView pickerView)
		{
			for (int i = 0; i < pickerView.NumberOfComponents; i++)
			{
				pickerView.Select(this.originalSelectedRow[i], i, false);
				if (i < pickerView.NumberOfComponents-1)
				{
					// 觸發selected去reload component
					this.Selected(pickerView, this.originalSelectedRow[i], i);
				}
			}
		}
	}
}