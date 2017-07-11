namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    /// Determines which records will be affected by the operation.
    /// </summary>
    public enum AffectEnum
    {
        /// <summary>
        /// Affect Current
        /// </summary>
        adAffectCurrent = 1,

        /// <summary>
        /// Affect Group
        /// </summary>
        adAffectGroup,

        /// <summary>
        /// Affect All
        /// </summary>
        adAffectAll,

        /// <summary>
        /// Affect All Chapters
        /// </summary>
        adAffectAllChapters
    }
}