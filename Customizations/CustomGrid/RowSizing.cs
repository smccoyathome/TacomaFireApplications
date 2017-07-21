namespace Custom.ViewModels.Grid
{
    public enum RowSizing
    {
        /// <summary>
        /// The setting of the object's parent will be used.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Rows cannot be resized by the user and will not be by the control.
        /// </summary>
        Fixed = 1,
        /// <summary>
        /// Rows can be resized by the user on a row-by-row basis.
        /// </summary>
        Free = 2,
        /// <summary>
        /// Synchronized. All rows will have the same height. Rows can be resized simultaneously resizing a single row resizes all rows.
        /// </summary>
        Sychronized = 3,
        /// <summary>
        /// Auto-Sizing Fixed. The control will resize each row to the size of the largest
        /// cell in that row.  The user is not allowed to resize the rows.
        /// </summary>
        AutoFixed = 4,
        /// <summary>
        /// Auto-Sizing Free. The control will resize each row to the size of the largest
        /// cell in that row.  The user is allowed to resize the rows.
        /// </summary>
        AutoFree = 5
    }
}