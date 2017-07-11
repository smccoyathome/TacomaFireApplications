namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// Provides a filter option object used to narrow paging data queries.
	/// </summary>
    public class GridFilterOptions
    {
		/// <summary>
		/// Name of the column to filter
		/// </summary>
        public string ColumnName { get; set; }

		/// <summary>
		/// Value to compare column value against to.
		/// </summary>
        public string Value { get; set; }

		/// <summary>
		/// Operator to apply when comparing.
		/// </summary>
        public string OperatorType { get; set; }
    }
}
