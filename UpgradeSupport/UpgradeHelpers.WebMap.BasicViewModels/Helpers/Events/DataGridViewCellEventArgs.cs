using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{
	/// <summary>
	///     Event args class for DataGridCell event handlers.  This class is provided for compilation purposes only,
	///     because DataGridCell events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public class DataGridViewCellEventArgs : EventArgs
	{
		public DataGridViewCellEventArgs(int columnIndex, int rowIndex)
		{
			// TODO: Complete member initialization
			this.ColumnIndex = columnIndex;
			this.RowIndex = rowIndex;
		}


		public int ColumnIndex { get; set; }

		public int RowIndex { get; set; }
	}
}
