namespace UpgradeHelpers.BasicViewModels
{
	public enum DataGridViewColumnHeadersHeightSizeMode
	{
		/// <summary>
		/// Users can adjust the column header height with the mouse.
		/// </summary>
		EnableResizing = 0,
		/// <summary>
		/// Users cannot adjust the column header height with the mouse.
		/// </summary>
		DisableResizing = 1,
		/// <summary>
		/// The column header height adjusts to fit the contents of all the column header cells.
		/// </summary>
		AutoSize = 2
	}
}