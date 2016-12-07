using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;


namespace AppleTableView.iOS
{
	public class MyPickerModel : UIPickerViewModel
	{
		#region Data Base
		List<PickerContent> addressData = new List<PickerContent>()
		{
			new PickerContent()
			{
				componentIndex = 0,
				componentPath = new List<int>()
				{
					0
				},
				title = "台北市"
			},
			new PickerContent()
			{
				componentIndex = 0,
				componentPath = new List<int>()
				{
					1
				},
				title = "新北市"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 0
				},
				title = "信義區"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 1
				},
				title = "中山區"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 2
				},
				title = "大同區"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 0
				},
				title = "新店區"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 1
				},
				title = "文山區"
			},
			new PickerContent()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 2
				},
				title = "烏來區"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					0, 0, 0
				},
				title = "信義路"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					0, 0, 1
				},
				title = "忠孝東路"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					0, 0, 2
				},
				title = "敦化北路"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					1, 0, 0
				},
				title = "中正路"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					1, 0, 1
				},
				title = "北新路"
			},
			new PickerContent()
			{
				componentIndex = 2,
				componentPath = new List<int>()
				{
					1, 0, 2
				},
				title = "民權路"
			},
			new PickerContent()
			{
				componentIndex = 3,
				componentPath = new List<int>()
				{
					0, 0, 0, 0
				},
				title = "東區"
			}
		};
		#endregion

		private int componentCount;
		private List<int> selectedRow = new List<int>();
		public  List<int> originalSelectedRow = new List<int>();

		public MyPickerModel(int _comonentCount)
		{
			this.componentCount = _comonentCount;

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
			rowsCount = addressData.Where(val => val.componentIndex == component).ToList();
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
			selectAddressData = addressData.Where(val => val.componentIndex == component).ToList();
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