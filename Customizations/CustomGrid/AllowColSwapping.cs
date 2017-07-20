namespace Custom.ViewModels.Grid
{
    public enum AllowColSwapping
    {
        /// <summary>
        /// Default AllowColSwapping style
        /// </summary>
        Default = 0,
        /// <summary>
        /// Disable col swapping
        /// </summary>
        NotAllowed = 1,
        /// <summary>
        /// Allow col swapping within a group
        /// </summary>
        WithinGroup = 2,
        /// <summary>
        /// Allow col swapping within a band
        /// </summary>
        WithinBand = 3
    }
}
