namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Defines a map for converting colors. Several methods of the System.Drawing.Imaging.ImageAttributes
	//     class adjust image colors by using a color-remap table, which is an array
	//     of System.Drawing.Imaging.ColorMap structures. Not inheritable.
	public sealed class ColorMap
    {
        // Summary:
        //     Initializes a new instance of the System.Drawing.Imaging.ColorMap class.
        public ColorMap() { }

        // Summary:
        //     Gets or sets the new System.Drawing.Color structure to which to convert.
        //
        // Returns:
        //     The new System.Drawing.Color structure to which to convert.
        public Color NewColor { get; set; }
        //
        // Summary:
        //     Gets or sets the existing System.Drawing.Color structure to be converted.
        //
        // Returns:
        //     The existing System.Drawing.Color structure to be converted.
        public Color OldColor { get; set; }
    }
}
