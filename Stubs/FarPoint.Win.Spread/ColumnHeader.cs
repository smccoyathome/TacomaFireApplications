using System;
using Stubs._FarPoint.Win.Spread;
using FarPoint.ViewModels;

namespace Stubs._FarPoint.Win.Spread
{

	public class ColumnHeader
	{

		public HeaderAutoText AutoText { get; set; }

		public FarPoint.ViewModels.Columns Columns { get; set; }

		public Rows Rows { get; set; }

		public bool Visible { get; set; }

		public StyleInfo DefaultStyle { get; set; }

		public Cells Cells { get; set; }

	}

}