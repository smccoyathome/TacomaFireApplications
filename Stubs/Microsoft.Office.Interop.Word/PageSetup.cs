using System;
using Stubs._Microsoft.Office.Interop.Word;

namespace Stubs._Microsoft.Office.Interop.Word
{

	public interface PageSetup
	{

		LineNumbering LineNumbering { get; set; }

		WdOrientation Orientation { get; set; }

		float TopMargin { get; set; }

		float BottomMargin { get; set; }

		float LeftMargin { get; set; }

		float RightMargin { get; set; }

		float Gutter { get; set; }

		float HeaderDistance { get; set; }

		float FooterDistance { get; set; }

		float PageWidth { get; set; }

		float PageHeight { get; set; }

		WdPaperTray FirstPageTray { get; set; }

		WdPaperTray OtherPagesTray { get; set; }

		WdSectionStart SectionStart { get; set; }

		int OddAndEvenPagesHeaderFooter { get; set; }

		int DifferentFirstPageHeaderFooter { get; set; }

		WdVerticalAlignment VerticalAlignment { get; set; }

		int SuppressEndnotes { get; set; }

		int MirrorMargins { get; set; }

		bool TwoPagesOnOne { get; set; }

		WdGutterStyle GutterPos { get; set; }

	}

}