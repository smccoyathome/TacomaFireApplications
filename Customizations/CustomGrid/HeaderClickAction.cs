namespace Custom.ViewModels.Grid
{
    public enum HeaderClickAction
    {
        /// <summary>
        /// Use Default. The setting of the object's parent will be used (or 'Select' if not parent is set to default).
        /// </summary>
        Default = 0,
        /// <summary>
        /// Select. Selects the column or group (based on the setting of the SelectTypeCol property).
        /// </summary>
        Select = 1,
        /// <summary>
        /// Single Selection Sort. Changes the sort indicator for the column after clearing all other columns' sort indicators.
        /// </summary>
        SortSingle = 2,
        /// <summary>
        ///  Multiple Selection Sort. Changes the sort indicator for the column. If the
        ///  shift key is pressed does not clear other columns sort indicators.
        /// </summary>
        SortMulti = 3,
        /// <summary>
        /// Same as SortSingle except with ExternalSortSingle UltraGrid won't perform the sort itself. 
        /// </summary>
        ExternalSortSingle = 4,
        /// <summary>
        /// Same as SortMulti except with ExternalSortMulti UltraGrid won't perform the sort itself.
        /// </summary>
        ExternalSortMulti = 5
    }
}