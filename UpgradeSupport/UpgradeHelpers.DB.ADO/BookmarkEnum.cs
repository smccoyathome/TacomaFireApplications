namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    /// Enum to describe the bookmark prosition to be used by the GetRows method
    /// </summary>
    public enum BookmarkEnum
    {
        /// <summary>
        /// Uses the current position 
        /// </summary>
        adBookmarkCurrent = 0,

        /// <summary>
        /// Starts at the first record
        /// </summary>
        adBookmarkFirst,

        /// <summary>
        /// Starts at the last record
        /// </summary>
        adBookmarkLast
    }
}