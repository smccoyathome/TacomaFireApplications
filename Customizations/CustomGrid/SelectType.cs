namespace Custom.ViewModels.Grid
{
    public enum SelectType
    {
        /// <summary>
        /// Use Default. The setting of the object's parent will be used.
        /// </summary>
        Default = 0,
        /// <summary>
        /// None. Objects may not be selected.
        /// </summary>
        None = 1,
        /// <summary>
        /// Single Select. Only one object may be selected at any time.
        /// </summary>
        Single = 2,
        /// <summary>
        /// Extended Select. Multiple objects may be selected at once.
        /// </summary>
        Extended = 3,
        /// <summary>
        /// When multiple items can be selected but pressing the left button and dragging does not 
        /// select other items but instead starts dragging the selected item immediately.
        /// </summary>
        ExtendedAutoDrag = 4,
        /// <summary>
        /// When only a single item can be selected and pressing the left button and dragging does 
        /// not select other items but instead starts dragging the selected item immediately.
        /// </summary>
        SingleAutoDrag = 5
    }
}