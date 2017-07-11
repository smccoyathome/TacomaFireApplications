using System;

namespace UpgradeHelpers.Reports.Helpers
{
	// Summary:
	//     Represents a full style hash key.
	//
	// Remarks:
	//     This class takes into account the Infragistics.Documents.Reports.Report.Text.StyleHashKey.Font,
	//     Infragistics.Documents.Reports.Report.Text.StyleHashKey.Brush, Infragistics.Documents.Reports.Report.Text.StyleHashKey.FontVariant,
	//     Infragistics.Documents.Reports.Report.Text.StyleHashKey.Highlight, Infragistics.Documents.Reports.Report.Text.StyleHashKey.CharSpacing,
	//     and Infragistics.Documents.Reports.Report.Text.StyleHashKey.WordSpacing when
	//     determining the hash key. If this level of precision is not necessary, consider
	//     the Infragistics.Documents.Reports.Report.Text.ShortStyleHashKey class.
	public class StyleHashKey
    {
        // Summary:
        //     Initializes a new instance of the Infragistics.Documents.Reports.Report.Text.Style.HashKey
        //     class.
        //
        // Parameters:
        //   font:
        //     A reference to a Infragistics.Documents.Reports.Graphics.Font object.
        //
        //   fontVariant:
        //     Defines the font variant.
        //
        //   brush:
        //     A reference to a Infragistics.Documents.Reports.Graphics.Brush object.
        //
        //   highlight:
        //     A reference to a Infragistics.Documents.Reports.Graphics.Brush object that
        //     defines the highlight.
        //
        //   charSpacing:
        //     Defines spacings between characters.
        //
        //   wordSpacing:
        //     Defines spacings between words.
        //public StyleHashKey(Font font, FontVariant fontVariant, Brush brush, Brush highlight, float charSpacing, float wordSpacing)
        //{
        //    throw new NotImplementedException();
        //}

        // Summary:
        //     Gets the reference to the Infragistics.Documents.Reports.Graphics.Brush object.
        //public Brush Brush { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the value that defines spacings between characters.
        public float CharSpacing { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the reference to the Infragistics.Documents.Reports.Graphics.Font object.
        //public Font Font { get { throw new NotImplementedException(); } }

        ////
        //// Summary:
        ////     Gets the font variant.
        //public FontVariant FontVariant { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the reference to the Infragistics.Documents.Reports.Graphics.Brush object
        //     that defines the highlight.
        //public Brush Highlight { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the value that defines spacings between words.
        public float WordSpacing { get { throw new NotImplementedException(); } }


        // Summary:
        //     Compares this hash key object to the specified one.
        //
        // Parameters:
        //   key:
        //     A reference to the hash key object.
        //
        // Returns:
        //     A boolean value indicating whether the objects are equal.
        public override bool Equals(object key)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Gets the hash code for this object.
        //
        // Returns:
        //     The hash code value.
        public override int GetHashCode() {
            throw new NotImplementedException();
        }
    }
}
