using System;
using Stubs._Microsoft.Office.Interop.Word;

namespace Stubs._Microsoft.Office.Interop.Word
{

	public interface _Application
	{

		Documents Documents { get; }

		Selection Selection { get; }

		void Quit(ref object SaveChanges, ref object OriginalFormat, ref object RouteDocument);

		int Top { get; set; }

		WdWindowState WindowState { get; set; }

		void PrintOut(ref object Background, ref object Append, ref object Range, ref object OutputFileName, ref object
			From, ref object To, ref object Item, ref object Copies, ref object Pages, ref object
			PageType, ref object PrintToFile, ref object Collate, ref object FileName, ref object ActivePrinterMacGX
			, ref object ManualDuplexPrint, ref object PrintZoomColumn, ref object PrintZoomRow, ref object PrintZoomPaperWidth, ref object PrintZoomPaperHeight);

	}

}