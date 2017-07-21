namespace Custom.ViewModels.Grid
{
    public enum Activation
    {
        /// <summary>
        /// Allow Edit. The grid will attempt to edit the content of the object.
        /// </summary>
        AllowEdit = 0,
        /// <summary>
        /// Activate Only. The object may be selected (text highlighted) but may not be edited.
        /// </summary>
        ActivateOnly = 1,
        /// <summary>
        /// Disabled. The object may not be activated and text may not be selected or edited.
        /// </summary>
        Disabled = 2,
        /// <summary>
        /// No Edit. The object may be activated, but cells cannot be edited.
        /// </summary>
        NoEdit = 3
    }
}
