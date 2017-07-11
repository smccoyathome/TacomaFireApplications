namespace UpgradeHelpers.DB
{
    /// <summary>
    /// Enum to describe the different edition modes for the Recordset
    /// </summary>
    public enum EditModeEnum
    {
        /// <summary>
        /// No edition is in progress
        /// </summary>
        EditNone = 0,

        /// <summary>
        /// Edition is in progress
        /// </summary>
        EditInProgress = 1,

        /// <summary>
        /// Addition is in progress
        /// </summary>
        EditAdd = 2,

        /// <summary>
        /// Delete is in progress
        /// </summary>
        EditDelete = 4
    }
}