namespace Custom.ViewModels
{
    public enum UIElementBorderStyle
    {
        /// <summary>
        /// The default border style
        /// </summary>
        Default = 0,
        /// <summary>
        /// No borders
        /// </summary>
        None = 1,
        /// <summary>
        /// Dotted line
        /// </summary>
        Dotted = 2,
        /// <summary>
        /// Dashed line
        /// </summary>
        Dashed = 3,
        /// <summary>
        /// A solid line
        /// </summary>
        Solid = 4,
        /// <summary>
        /// A 2 pixel wide inset border
        /// </summary>
        Inset = 5,
        /// <summary>
        /// A 2 pixel wide raised border
        /// </summary>
        Raised = 6,
        /// <summary>
        /// A 1 pixel wide inset border
        /// </summary>
        InsetSoft = 7,
        /// <summary>
        /// A 1 pixel wide raised border
        /// </summary>
        RaisedSoft = 8,
        /// <summary>
        /// A 2 pixel wide etched line
        /// </summary>
        Etched = 9,
        /// <summary>
        /// A 1 pixel wide rounded border with a rounding radius of 1.
        /// </summary>
        Rounded1 = 10,
        /// <summary>
        /// A 2 pixel wide etched rounded border with a rounding radius of 1.
        /// </summary>
        Rounded1Etched = 11,
        /// <summary>
        /// A 1 pixel wide rounded border with a rounding radius of 4.
        /// </summary>
        Rounded4 = 12,
        /// <summary>
        /// A 2 pixel wide rounded border with a rounding radius of 4.
        /// </summary>
        Rounded4Thick = 13,
        /// <summary>
        /// A 2 pixel wide line with two different colors
        /// </summary>
        TwoColor = 14,
        /// <summary>
        /// A Windows Vista style border. BorderColor is used as the top border, and
        /// the other three borders sides are drawn with varying (ligher) shades of the
        /// BorderColor.
        /// </summary>
        WindowsVista = 15,
        /// <summary>
        /// A 1 pixel wide rounded border with a rounding radius of 3.
        /// </summary>
        Rounded3 = 16
    }
}
