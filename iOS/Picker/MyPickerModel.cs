using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;


namespace AppleTableView.iOS
{
	public class MyPickerModel : UIPickerViewModel
	{
		#region Address Data Base
		List<AddressData> addressData = new List<AddressData>()
		{
			new AddressData()
			{
				componentIndex = 0,
				componentPath = new List<int>()
				{
					0
				},
				title = "台北市"
			},
			new AddressData()
			{
				componentIndex = 0,
				componentPath = new List<int>()
				{
					1
				},
				title = "新北市"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 0
				},
				title = "信義區"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 1
				},
				title = "中山區"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					0, 2
				},
				title = "大同區"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 0
				},
				title = "新店區"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 1
				},
				title = "文山區"
			},
			new AddressData()
			{
				componentIndex = 1,
				componentPath = new List<int>()
				{
					1, 2
				},
				title = "烏來區"
			}
		};
		#endregion

		private int componentCount;
		private List<int> selectedRow = new List<int>();
		public List<int> cancelSelectedRow = new List<int>();

		public MyPickerModel(int _comonentCount)
		{
			this.componentCount = _comonentCount;

			for (int i = 0; i < this.componentCount; i++)
			{
				this.selectedRow.Add(0);
				this.cancelSelectedRow.Add(0);
			}
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return this.componentCount;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			if (component == 0)
			{
				var rowsCount = addressData.Where(val => val.componentIndex == component);
				return rowsCount.Count();
			} else {
				var rowsCount = addressData.Where(val => val.componentIndex == component);
				for (int i = 0; i < (int)component; i++)
				{
					rowsCount = rowsCount.Where(val => val.componentPath[0].Equals(0));
				}
				return rowsCount.Count();
			}

		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			int i = 0;
			List<AddressData> tmp;

			if (component == 0)
			{
				var selectAddressData = addressData.Where(val => val.componentIndex == component);
				selectAddressData.OrderBy(val => val.componentPath[0]);

				tmp = selectAddressData.ToList();
				return tmp[(int)row].title;
			} else {
				var selectAddressData = addressData.Where(val => val.componentIndex == component);

				for (i = 0; i < (int)component; i++)
				{
					selectAddressData = selectAddressData.Where(val => val.componentPath[0].Equals(selectedRow[0]));
				}
				selectAddressData = selectAddressData.OrderBy(val => val.componentPath[i]);

				tmp = selectAddressData.ToList();

				return tmp[(int)row].title;
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
					pickerView.ReloadComponent(i+1);
					pickerView.Select(0, i+1, true);
					selectedRow[i + 1] = 0;
				}
			}
		}

		//public string selectAddr(UIPickerView pickerView)
		//{
		//	for (int i = 0; i < cancelSelectedRow.Count; i++)
		//	{
		//		cancelSelectedRow[i] = pickerView.SelectedRowInComponent(i);
		//	}

		//	return cityList[(int)pickerView.SelectedRowInComponent(0)]
		//			+ " "
		//			+ areaList[(int)pickerView.SelectedRowInComponent(0)][(int)pickerView.SelectedRowInComponent(1)];
		//}
	}
}