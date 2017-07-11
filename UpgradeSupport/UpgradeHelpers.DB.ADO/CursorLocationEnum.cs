namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    /// Determines if server-side or client-side cursors are used (which cursor engine used).
    /// </summary>
    public enum CursorLocationEnum
    {
        /// <summary>
        /// Use None
        /// </summary>
        adUseNone = 1,

        /// <summary>
        /// Use Server
        /// </summary>
        adUseServer = 2,

        /// <summary>
        /// Use Client
        /// </summary>
        adUseClient = 3
    }
}