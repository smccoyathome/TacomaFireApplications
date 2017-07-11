using System;

namespace UpgradeHelpers.Reports.Helpers
{
	// Summary:
	//     Represents a short style hash key.
	//
	// Remarks:
	//     This class generates a hash key based on the Infragistics.Documents.Reports.Report.Text.ShortStyleHashKey.Font
	//     and Infragistics.Documents.Reports.Report.Text.ShortStyleHashKey.Brush properties,
	//     as opposed to the Infragistics.Documents.Reports.Report.Text.StyleHashKey,
	//     which takes into consideration more properties.
	public class ShortStyleHashKey
    {
        // Summary:
        //     Initializes a new instance of the Infragistics.Documents.Reports.Report.Text.Style.ShortHashKey
        //     class.
        //
        // Parameters:
        //   font:
        //     A reference to a Infragistics.Documents.Reports.Graphics.Font object.
        //
        //   brush:
        //     A reference to a Infragistics.Documents.Reports.Graphics.Brush object.
        //public ShortStyleHashKey(Font font, Brush brush) {
        //    throw new NotImplementedException();
        //}

        // Summary:
        //     Gets the reference to the Infragistics.Documents.Reports.Graphics.Brush object.
        //public Brush Brush { get { throw new NotImplementedException(); } }

        //
        // Summary:
        //     Gets the reference to the Infragistics.Documents.Reports.Graphics.Font object.
        //public Font Font { get { throw new NotImplementedException(); } }

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
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
