
using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
	/// <summary>
	///     Event args class for key event handlers.  This class is provided for compilation purposes only,
	///     because key events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public class ListViewItemSelectionChangedEventArgs : EventArgs
	{
		public ListViewItemSelectionChangedEventArgs(IDependentViewModel item, int itemIndex, bool isSelected)
		{
			// TODO: Complete member initialization
			IsSelected = isSelected;
			Item = item;
			ItemIndex = itemIndex;
		}


		public bool IsSelected { get; set; }

		public IDependentViewModel Item { get; set; }

		public int ItemIndex { get; set; }
	}
}

