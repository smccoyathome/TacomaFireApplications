namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     The System.Drawing.Drawing2D.InterpolationMode enumeration specifies the
	//     algorithm that is used when images are scaled or rotated.
	public enum InterpolationMode
    {
        // Summary:
        //     Equivalent to the System.Drawing.Drawing2D.QualityMode.Invalid element of
        //     the System.Drawing.Drawing2D.QualityMode enumeration.
        Invalid = -1,
        //
        // Summary:
        //     Specifies default mode.
        Default = 0,
        //
        // Summary:
        //     Specifies low quality interpolation.
        Low = 1,
        //
        // Summary:
        //     Specifies high quality interpolation.
        High = 2,
        //
        // Summary:
        //     Specifies bilinear interpolation. No prefiltering is done. This mode is not
        //     suitable for shrinking an image below 50 percent of its original size.
        Bilinear = 3,
        //
        // Summary:
        //     Specifies bicubic interpolation. No prefiltering is done. This mode is not
        //     suitable for shrinking an image below 25 percent of its original size.
        Bicubic = 4,
        //
        // Summary:
        //     Specifies nearest-neighbor interpolation.
        NearestNeighbor = 5,
        //
        // Summary:
        //     Specifies high-quality, bilinear interpolation. Prefiltering is performed
        //     to ensure high-quality shrinking.
        HighQualityBilinear = 6,
        //
        // Summary:
        //     Specifies high-quality, bicubic interpolation. Prefiltering is performed
        //     to ensure high-quality shrinking. This mode produces the highest quality
        //     transformed images.
        HighQualityBicubic = 7,
    }
}
