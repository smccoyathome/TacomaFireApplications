using System;

namespace UpgradeHelpers.Helpers
{
    public enum PixelOffsetMode
    {
        // Summary:
        //     Specifies an invalid mode.
        Invalid = -1,
        //
        // Summary:
        //     Specifies the default mode.
        Default = 0,
        //
        // Summary:
        //     Specifies high speed, low quality rendering.
        HighSpeed = 1,
        //
        // Summary:
        //     Specifies high quality, low speed rendering.
        HighQuality = 2,
        //
        // Summary:
        //     Specifies no pixel offset.
        None = 3,
        //
        // Summary:
        //     Specifies that pixels are offset by -.5 units, both horizontally and vertically,
        //     for high speed antialiasing.
        Half = 4,
    }
}
