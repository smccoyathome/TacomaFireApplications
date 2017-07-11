using System;
using Stubs._FarPoint.Win.Spread.CellType;

namespace Stubs._FarPoint.Win.Spread.CellType
{

	public class NumberCellType
		: EditBaseCellType
	{

		public int DecimalPlaces { get; set; }

		public string DecimalSeparator { get; set; }

		public string Separator { get; set; }

		public bool SpinWrap { get; set; }

	}

}