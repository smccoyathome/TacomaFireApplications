namespace UpgradeHelpers.DB.ADO
{
    /// <summary>Sets or returns the type of cursor to use in this Recordset.</summary>
    public enum CursorTypeEnum
    {
        /// <summary>
        /// Not specific Cursor, value -1
        /// </summary>
        adOpenUnspecified = -1,

        /// <summary>
        /// Open Forward Only Cursor, value 0
        /// </summary>
        adOpenForwardOnly = 0,

        /// <summary>
        /// Open Keyset Cursor, value 1
        /// </summary>
        adOpenKeyset = 1,

        /// <summary>
        /// Open Dynamic Cursor, value 2
        /// </summary>
        adOpenDynamic = 2,

        /// <summary>
        /// Open Static Cursor, value 3
        /// </summary>
        adOpenStatic = 3
    }
}