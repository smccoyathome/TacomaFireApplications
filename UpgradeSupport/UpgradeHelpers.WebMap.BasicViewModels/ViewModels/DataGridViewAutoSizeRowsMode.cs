namespace UpgradeHelpers.BasicViewModels
{
	public enum DataGridViewAutoSizeRowsMode
	{
		/// <summary>
		/// The row heights do not automatically adjust.
		/// </summary>
		None = 0,
		/// <summary>
		/// The row heights adjust to fit the contents of the row header.
		/// </summary>
		AllHeaders = 5,
		/// <summary>
		/// The row heights adjust to fit the contents of all cells in the rows, excluding header cells.
		/// </summary>
		AllCellsExceptHeaders = 6,
		/// <summary>
		/// The row heights adjust to fit the contents of all cells in the rows, including header cells.
		/// </summary>
		AllCells = 7,
		/// <summary>
		/// The row heights adjust to fit the contents of the row headers currently displayed onscreen.
		/// </summary>
		DisplayedHeaders = 9,
		/// <summary>
		/// The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, excluding header cells.
		/// </summary>
		DisplayedCellsExceptHeaders = 10,
		/// <summary>
		/// The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, including header cells.
		/// </summary>
		DisplayedCells = 11
	}
}