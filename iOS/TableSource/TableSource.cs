using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
namespace AppleTableView.iOS
{
	public class TableSource : UITableViewSource
	{
		List<List<Product>> productList;

		public TableSource(List<List<Product>> _productList)
		{
			this.productList = _productList;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return productList.Count;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return productList[(int)section].Count;
		}

		#region Header
		public override string TitleForHeader(UITableView tableView, nint section)
		{
			switch ((int)section)
			{
				case 0:
					return "iPhone";
				case 1:
					return "Mac";
				case 2:
					return "iPad";
				case 3:
					return "iwatch";
				default:
					return String.Empty;
			}
		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			switch ((int)section % 2)
			{
				case 0:
					((UITableViewHeaderFooterView)headerView).TextLabel.TextColor = UIColor.White;
					headerView.TintColor = UIColor.Gray;
					break;
				case 1:
					headerView.TintColor = UIColor.Gray;
					break;
				default:
					break;
			}
		}
		#endregion

		#region Get Cell
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			Product product = productList[indexPath.Section][indexPath.Row];

			switch(indexPath.Section % 2)
			{
				case 0:
					ImgLeftViewCell leftCell = tableView.DequeueReusableCell("ImgLeftViewCell") as ImgLeftViewCell;
					leftCell.updateUI(product);
					leftCell.url		= product.URL;
					leftCell.indexPath	= indexPath;

					leftCell.setInfoEvent(SelectTableInfo);
					leftCell.setBuyEvent(SelectTableBuy);

					return leftCell;
				case 1:
					ImgRightViewCell rightCell = tableView.DequeueReusableCell("ImgRightViewCell") as ImgRightViewCell;
					rightCell.updateUI(product);
					rightCell.url		= product.URL;
					rightCell.indexPath = indexPath;

					rightCell.setInfoEvent(SelectTableInfo);
					rightCell.setBuyEvent(SelectTableBuy);

					return rightCell;
				default:
					return null;
			}
		}
		#endregion

		#region TableSourceCellBtn Event
		public event EventHandler<NSIndexPath> SelectTableInfo;
		public event EventHandler<NSIndexPath> SelectTableBuy;
		#endregion
	}
}
