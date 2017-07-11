namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Specifies the file format of the image. Not inheritable.
	// [TypeConverter(typeof(ImageFormatConverter))] Mobilize.KMM [NOTUPGRADED]
	public class ImageFormat
    {
        public static ImageFormat Png { get; set; }

        public static ImageFormat Jpeg { get; set; }

        public static ImageFormat Bmp { get; set; }
        public static ImageFormat Tiff { get; set; }
    }
}
