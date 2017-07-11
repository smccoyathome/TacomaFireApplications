using System;
using Stubs._FarPoint.Win.Spread;

namespace Stubs._FarPoint.Win.Spread
{

	public class PrintInfo
	{

		public string Footer { get; set; }

		public string Header { get; set; }

		public string JobName { get; set; }

		public PrintMargin Margin { get; set; }

		public NoPrinterPrintInfo NoPrinterSetting { get; set; }

		public int PageEnd { get; set; }

		public int PageStart { get; set; }

		public PrintHeader ShowColumnHeader { get; set; }

		public PrintHeader ShowRowHeader { get; set; }

		public PrintOrientation Orientation { get; set; }

		public bool ShowColor { get; set; }

	}

}