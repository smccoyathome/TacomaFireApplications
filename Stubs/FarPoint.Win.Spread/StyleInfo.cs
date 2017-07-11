using System;
using Stubs._FarPoint.Win.Spread.CellType;

namespace Stubs._FarPoint.Win.Spread
{

	public class StyleInfo
	{

		public FarPoint.ViewModels.CellHorizontalAlignment HorizontalAlignment { get; set; }

		public UpgradeHelpers.Helpers.Color NoteIndicatorColor { get; set; }

		public string Parent { get; set; }

		public FarPoint.ViewModels.CellVerticalAlignment VerticalAlignment { get; set; }

		public Stubs._FarPoint.Win.Spread.CellType.ICellType CellType { get; set; }

		public Stubs._FarPoint.Win.Spread.CellType.IRenderer Renderer { get; set; }

	}

}