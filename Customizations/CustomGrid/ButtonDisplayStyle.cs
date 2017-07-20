namespace Custom.ViewModels.Grid
{
	public enum ButtonDisplayStyle
	{
		/// <summary>
		/// always display buttons
		/// </summary>
		OnMouseEnter = 0,
		/// <summary>
		/// display only when the cell is activated
		/// </summary>
		Always = 1,
		/// <summary>
		/// display button whenever the mouse enters the cell ui element
		/// </summary>
		OnCellActivate = 2,
		/// <summary>
		/// display when the row the cell belongs to is activated
		/// </summary>
		OnRowActivate = 3,
	}
}
