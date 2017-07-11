using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.WebMap.Server.Interfaces;

namespace UpgradeHelpers.Interfaces
{
    // Summary:
    //     Represents a static page.
    public interface IProjectionPage
    {
        // Summary:
        //     Gets the height of the page in points.
        //
        // Remarks:
        //      Note: The Infragistics.Documents.Reports.Utils.Converter.PointsToPixels(System.Single)
        //     method can be used to convert this value into pixels.
        float Height { get; }

        //
        // Summary:
        //     Gets the width of the page in points.
        //
        // Remarks:
        //      Note: The Infragistics.Documents.Reports.Utils.Converter.PointsToPixels(System.Single)
        //     method can be used to convert this value into pixels.
        float Width { get; }

        // Summary:
        //     Draws the content of this page to a graphics surface that implements the
        //     Infragistics.Documents.Reports.Graphics.IGraphics interface.
        //
        // Parameters:
        //   graphics:
        //     A graphics surface that implements the Infragistics.Documents.Reports.Graphics.IGraphics
        //     interface.
        //void Draw(IGraphics graphics);
    }
}
