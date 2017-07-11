namespace UpgradeHelpers.Helpers
{
	public enum SortSettingsViewModel
	{
		/// <summary>
		/// Generic ascending sort
		/// </summary>
		SortGenericAscending = 1,
		/// <summary>
		/// Generic descending sort
		/// </summary>
		SortGenericDescending = 2,
		/// <summary>
		/// No Sort
		/// </summary>
		SortNone = 0,
		/// <summary>
		/// Numeric ascending sort
		/// </summary>
		SortNumericAscending = 3,
		/// <summary>
		/// Numeric descending sort
		/// </summary>
		SortNumericDescending = 4,
		/// <summary>
		///  String ascending sort, case-sensitive
		/// </summary>
		SortStringAscending = 7,
		/// <summary>
		/// String descending sort, case-sensitive
		/// </summary>
		SortStringDescending = 8,
		/// <summary>
		/// String ascending sort, case-insensitive
		/// </summary>
		SortStringNoCaseAscending = 5,
		/// <summary>
		/// String descending sort, case-insensitive
		/// </summary>
		SortStringNoCaseDescending = 6
	}
}
