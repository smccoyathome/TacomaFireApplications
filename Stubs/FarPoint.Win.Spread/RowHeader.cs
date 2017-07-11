using System;
using Stubs._FarPoint.Win.Spread;
using FarPoint.ViewModels;

namespace Stubs._FarPoint.Win.Spread
{

	public class RowHeader
	{

		public FarPoint.ViewModels.Columns Columns { get; set; }

		public bool Visible { get; set; }

		public Rows Rows { get; set; }

		public StyleInfo DefaultStyle { get; set; }

		public HeaderAutoText AutoText { get; set; }

		public Cells Cells { get; set; }

	}

}