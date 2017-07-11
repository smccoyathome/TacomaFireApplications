namespace UpgradeHelpers.Helpers
{
	public class FontFamily {

        readonly Font font;


		#region Constructors
        public FontFamily(Font font)
        {
            this.font = font;
        }

		#endregion

		#region Properties

		public  string Name {
            get {
                return this.font.Name;
            }
            set
            {
                this.font.Name = value;
            }

        }

        #endregion
        public const string GenericMonospace = "monospace";
        public const string GenericSansSerif =  "sans-serif";
        public const string GenericSerif = "serif";

        public static FontFamily[] Families { get; set; }
    }
}