using Newtonsoft.Json;
using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
	using System.Runtime.InteropServices.ComTypes;

	using Newtonsoft.Json.Converters;

	using UpgradeHelpers.WebMap.WFBaseViewModels.Dependencies.Helpers;

    /// <summary>
	///     Class to be used for the viewModels to be bound
	/// </summary>
	public class Font
		: IDependentViewModel, IInitializableCommon, IInitializable,IDisposable,
		IInitializable<string, float, FontStyle>,
        IInitializable<string, Int32, FontStyle>,
		IInitializable<FontFamily, float, FontStyle>,
        IInitializable<FontFamily, Int32, FontStyle>,
		IInitializable<string, float>,
        IInitializable<string, int>,
		IInitializable<Font, FontStyle>,
        IInitializable<string, float, FontStyle, GraphicsUnit>,
		IInitializable<string, float, FontStyle, GraphicsUnit, int>,
        IInitializable<string, float, FontStyle, GraphicsUnit, byte, bool>,
        IInitializable<Font>,
        IInitializable<UpgradeHelpers.Helpers.Font.DefaultFontValues, FontStyle>
    {
		public virtual void Build(IIocContainer ctx)
		{
			
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializableCommon.Common()
		{
			Weight = string.Empty;
			Name = string.Empty;
		}

		public void Dispose()
		{
		}

		#region Constructors

		/// <summary>
        /// Initializes a new instance of the Font class.
		/// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializable.Init()
		{
		}

		/// <summary>
        /// Initializes a new Font using a specified size and style.
		/// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializable<string, float, FontStyle>.Init(string familyName, float emSize, FontStyle style)
		{
			Name = familyName;
			Size = emSize;
			Style = style;
		}

        /// <summary>
        /// Initializes a new Font using a specified size and style.
        /// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<string, Int32, FontStyle>.Init(string familyName, Int32 emSize, FontStyle style)
        {
            Name = familyName;
            Size = emSize;
            Style = style;
        }

        /// <summary>
        /// Initializes a new Font using a specified size and style.
        /// </summary>
        /// <param name="fontFamily">The FontFamily of the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        [Obsolete("Avoid using FontFamily. This class is just a wrapper used for compilation. It is better to use the other constructors")]
        void IInitializable<FontFamily, float, FontStyle>.Init(FontFamily fontFamily, float emSize, FontStyle style)
        {
            Name = fontFamily.Name;
            Size = emSize;
            Style = style;
        }

        /// <summary>
        /// Initializes a new Font using a specified size and style.
        /// </summary>
        /// <param name="fontFamily">The FontFamily of the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        [Obsolete("Avoid using FontFamily. This class is just a wrapper used for compilation. It is better to use the other constructors")]
        void IInitializable<FontFamily, Int32, FontStyle>.Init(FontFamily fontFamily, Int32 emSize, FontStyle style)
        {
            Name = fontFamily.Name;
            Size = emSize;
            Style = style;
        }

        /// <summary>
        /// Initializes a new Font using a specified size.
        /// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<string, float>.Init(string familyName, float emSize)
		{
			Name = familyName;
			Size = emSize;
		}

        /// <summary>
        /// Initializes a new Font using a specified size.
        /// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size, in points, of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<string, int>.Init(string fontFamily, int emSize)
        {
            Name = fontFamily;
            Size = emSize;
        }

        /// <summary>
        /// Initializes a new Font that uses the specified existing Font and FontStyle enumeration.
		/// </summary>
        /// <param name="prototype">The existing Font from which to create the new Font.</param>
        /// <param name="newStyle">The FontStyle to apply to the new Font. Multiple values of the FontStyle enumeration can be combined with the OR operator.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializable<Font, FontStyle>.Init(Font prototype, FontStyle newStyle)
		{
            prototype = DefaultFontUtility(prototype) as Font;
			Name = prototype.Name;
			Size = prototype.Size;
            Style = newStyle;
            GdiCharSet = prototype.GdiCharSet;
            _graphicsUnit = prototype._graphicsUnit;
		}

		/// <summary>
        /// Initializes a new Font using a specified size, style, unit, and character set.
		/// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size of the new font in the units specified by the unit parameter.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        /// <param name="unit">The GraphicsUnit of the new font.</param>
        /// <param name="gdiCharSet">A Byte that specifies a GDI character set to use for this font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializable<string, float, FontStyle, GraphicsUnit, int>.Init(string familyName, float emSize,
			FontStyle style, GraphicsUnit unit, int gdiCharSet)
		{
			Name = familyName;
			Size = emSize;
			Style = style;
			_graphicsUnit = unit;
			GdiCharSet = (byte)gdiCharSet;
		}

		/// <summary>
        /// Initializes a new Font using a specified size, style, and unit.
        /// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size of the new font in the units specified by the unit parameter.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        /// <param name="unit">The GraphicsUnit of the new font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<string, float, FontStyle, GraphicsUnit>.Init(string familyName, float emSize,
            FontStyle style, GraphicsUnit unit)
        {
            this.CallBaseInit(familyName, emSize, style, unit, 1, Font.IsVerticalName(familyName));
        }

        /// <summary>
        /// Initializes a new Font using the specified size, style, unit, and character set.
        /// </summary>
        /// <param name="familyName">A string representation of the FontFamily for the new Font.</param>
        /// <param name="emSize">The em-size of the new font in the units specified by the unit parameter.</param>
        /// <param name="style">The FontStyle of the new font.</param>
        /// <param name="unit">The GraphicsUnit of the new font.</param>
        /// <param name="gdiCharSet">A Byte that specifies a GDI character set to use for this font.</param>
        /// <param name="gdiVerticalFont">A Boolean value indicating whether the new Font is derived from a GDI vertical font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<string, float, FontStyle, GraphicsUnit, byte, bool>.Init(string familyName, float emSize, FontStyle style, GraphicsUnit unit, byte gdiCharSet, bool gdiVerticalFont)
        {
            Name = familyName;
            Size = emSize;
            Style = style;
            _graphicsUnit = unit;
            GdiCharSet = gdiCharSet;
        }

        /// <summary>
        /// Initializes a new Font that uses the specified existing Font.
		/// </summary>
        /// <param name="font">The existing Font from which to create the new Font.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
		void IInitializable<Font>.Init(Font font)
        {
            Name = font.Name;
            Size = font.Size;
            Style = font.Style;
        }

        /// <summary>
        /// Initializes a new Font that uses the specified existing Font and FontStyle enumeration.
        /// </summary>
        /// <param name="prototype">The existing Font from which to create the new Font.</param>
        /// <param name="newStyle">The FontStyle to apply to the new Font. Multiple values of the FontStyle enumeration can be combined with the OR operator.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "Interface methods are hidden to child types by webmap's design")]
        void IInitializable<DefaultFontValues, FontStyle>.Init(DefaultFontValues prototype, FontStyle newStyle)
        {
            Name = prototype.Name;
            Size = prototype.Size;
            Style = newStyle;
        }
        #endregion

      
		#region Properties to bind
		public virtual string Weight { get; set; }

		#endregion

		/// <summary>
		///     This properties will be serialized but can't be used for binding
		/// </summary>

		#region .NET properties
		/// <summary>
		/// Only client-side code should change this values
		/// </summary>
		public virtual string Decoration { get; set; }
		/// <summary>
		/// </summary>
		FontFamily _fontFamily;

        [StateManagement(StateManagementValues.None)]
        public FontFamily FontFamily
        {
            get 
            {
                if (_fontFamily==null)
                {
                    _fontFamily = new FontFamily(this);
                }
                return _fontFamily;
            }
        }

        [JsonProperty(PropertyName = "Style")]
		[JsonConverter(typeof(StringEnumConverter))]
		public virtual FontStyle _style { get; set; }



        /// <summary>
        ///     Only server-side code should change this values
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        [JsonIgnore]
        public FontStyle Style
		{
			get { return _style; }
			set
			{
				var hasFontDecoration = false;
				_style = value;
				if ((_style & FontStyle.Bold) == FontStyle.Bold)
				{
					Weight = "bold";
					Bold = true;
				}
				else
					Weight = "normal";

				if ((_style & FontStyle.Italic) == FontStyle.Italic)
				{
					Italic = true;
				}

				if ((_style & FontStyle.Strikeout) == FontStyle.Strikeout)
				{
					this.Decoration = "line-through";
					Strikeout = true;
					hasFontDecoration = true;
				}

				if ((_style & FontStyle.Underline) == FontStyle.Underline)
				{
					this.Decoration = "underline";
					Underline = true;
					hasFontDecoration = true;
				}

                if((_style & FontStyle.Italic) != FontStyle.Italic )
                {
                    _style = FontStyle.Normal;
                }

                if (!hasFontDecoration)
				{
					this.Decoration = "none";
				}
			}
		}

		public virtual string Name { get; set; }


        [StateManagement(StateManagementValues.ServerOnly)]
		public virtual GraphicsUnit _graphicsUnit { get; set; }

        [JsonConverter(typeof(FontSizeConverter))]
        public virtual float Size { get; set; }
		public virtual bool Bold { set; get; }
		public virtual bool Italic { set; get; }
		public virtual bool Strikeout { set; get; }
		public virtual bool Underline { set; get; }

        [StateManagement(StateManagementValues.None)]
		public float SizeInPoints { set { Size = value; }  get { return Size; } }

        [Obsolete("This property is only left for compilation purposes")]
        [StateManagement(StateManagementValues.None)]
		public virtual int Height { get; set; }

		#endregion

        #region Default Font Values
        public class DefaultFontValues
        {
            public string Name { get { return "Arial"; } }
            public float SizeInPoints { get { return 8.25f; } }
            public UpgradeHelpers.Helpers.FontFamily FontFamily { get { return new UpgradeHelpers.Helpers.FontFamily(new UpgradeHelpers.Helpers.Font()); } }
            public float Size { get { return 8.25f; } }
            public float emSize { get { return 8.25f; } }
            public FontStyle style { get { return FontStyle.Regular; } }
            public GraphicsUnit unit { get { return GraphicsUnit.Display; } }
            public byte gdiCharSet { get { return Byte.MinValue; } }
        }
        #endregion

        #region Utils

        private object DefaultFontUtility(UpgradeHelpers.Helpers.Font font)
        {
            if (font == null)
            {
                DefaultFontValues dfv = new DefaultFontValues();
                font = new Font();
                font.Name = dfv.Name;
                font.Size = dfv.emSize;
                font.Style = dfv.style;
                font._graphicsUnit = dfv.unit;
                font.GdiCharSet = dfv.gdiCharSet;
            }
            return font;
        }
        #endregion

        private static bool IsVerticalName(string familyName)
        {
            return familyName != null && familyName.Length > 0 && familyName[0] == '@';
        }
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual bool GdiVerticalFont { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual byte GdiCharSet { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual GraphicsUnit Unit { get; set; }

		public string UniqueID { get; set; }
    }

	// Summary:
	//     Specifies style information applied to text.
	[Flags]
	public enum FontStyle
	{
		Normal = 32,
		// Summary:
		//     Normal text.
		Regular = 16,
		//
		// Summary:
		//     Bold text.
		Bold = 1,
		//
		// Summary:
		//     Italic text.
		Italic = 2,
		//
		// Summary:
		//     Underlined text.
		Underline = 4,
		//
		// Summary:
		//     Text with a line through the middle.
		Strikeout = 8
	}

	// Summary:
	//     Specifies the unit of measure for the given data.
	public enum GraphicsUnit
	{
		// Summary:
		//     Specifies the world coordinate system unit as the unit of measure.
		World = 0,
		//
		// Summary:
		//     Specifies the unit of measure of the display device. Typically pixels for
		//     video displays, and 1/100 inch for printers.
		Display = 1,
		//
		// Summary:
		//     Specifies a device pixel as the unit of measure.
		Pixel = 2,
		//
		// Summary:
		//     Specifies a printer's point (1/72 inch) as the unit of measure.
		Point = 3,
		//
		// Summary:
		//     Specifies the inch as the unit of measure.
		Inch = 4,
		//
		// Summary:
		//     Specifies the document unit (1/300 inch) as the unit of measure.
		Document = 5,
		//
		// Summary:
		//     Specifies the millimeter as the unit of measure.
		Millimeter = 6
	}
}