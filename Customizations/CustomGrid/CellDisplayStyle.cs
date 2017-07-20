namespace Custom.ViewModels.Grid
{
    public enum CellDisplayStyle
    {
        /// <summary>
        /// Default is resolved to FullEditorDisplay.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Plain text without any formatting.
        /// </summary>
        PlainText = 1,
        /// <summary>
        /// Formatted text.
        /// </summary>
        FormattedText = 2,
        /// <summary>
        /// Embeddable editor element.
        /// </summary>
        FullEditorDisplay = 3
    }
}
