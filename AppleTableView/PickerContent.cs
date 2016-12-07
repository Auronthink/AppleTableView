using System;
using System.Collections.Generic;
namespace AppleTableView
{
	public class PickerContent
	{
		public PickerContent()
		{
		}

		public int componentIndex { get; set;}
		public List<int> componentPath { get; set;}
		public string title { get; set;}
	}
}
