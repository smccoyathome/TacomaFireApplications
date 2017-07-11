using System;
using Stubs._FarPoint.Win.Spread;

namespace Stubs._FarPoint.Win.Spread
{

	public class CellClickEventArgs
		: System.EventArgs
	{

		public int Column
		{
            get;set;
		}

		public int Row
		{
            get; set;
		}


		public CellClickEventArgs(int row, int column)
		{
            Row = row;
            Column = column;
		}
	}

}