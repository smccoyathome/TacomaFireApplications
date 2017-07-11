using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Specifies the mouse capture policies.
    public enum CaptureMode
    {
        // Summary:
        //     No mouse capture. Mouse input goes to the element under the mouse.
        None = 0,

        //
        // Summary:
        //     Mouse capture is applied to a single element. Mouse input goes to the captured
        //     element.
        Element = 1,

        //
        // Summary:
        //     Mouse capture is applied to a subtree of elements. If the mouse is over a
        //     child of the element with capture, mouse input is sent to the child element.
        //     Otherwise, mouse input is sent to the element with mouse capture.
        SubTree = 2
    }
}
