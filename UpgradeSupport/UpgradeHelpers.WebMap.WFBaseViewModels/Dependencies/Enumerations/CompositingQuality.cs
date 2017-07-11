using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    // Summary:
    //     Specifies the quality level to use during compositing.
    public enum CompositingQuality
    {
        // Summary:
        //     Invalid quality.
        Invalid = -1,
        //
        // Summary:
        //     Default quality.
        Default = 0,
        //
        // Summary:
        //     High speed, low quality.
        HighSpeed = 1,
        //
        // Summary:
        //     High quality, low speed compositing.
        HighQuality = 2,
        //
        // Summary:
        //     Gamma correction is used.
        GammaCorrected = 3,
        //
        // Summary:
        //     Assume linear values.
        AssumeLinear = 4,
    }
}
