using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.Events
{
	/// <summary>
	///     Event args class for TrueDBGrid RowColChange event handlers.  This class is provided for compilation purposes only,
	///     because the events are not server propagated to server side, instead they are
	///     converted to client side events (such as JavaScript)
	/// </summary>
	public class RowColChangeEventArgs : EventArgs
	{
		public RowColChangeEventArgs(int lastCol, int lastRow)
		{
			this.LastCol = lastCol;
			this.LastRow = lastRow;
		}

		public int LastCol { get; set; }
		public int LastRow { get; set; }
	}
}
