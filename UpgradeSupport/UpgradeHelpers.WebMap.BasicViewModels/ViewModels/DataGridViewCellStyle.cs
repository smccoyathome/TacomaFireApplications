using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.BasicViewModels
{
	public class DataGridViewCellStyle : ControlViewModel
	{
		/// <summary>
		/// Gets or sets a value indicating the position of the cell content within a System.Windows.Forms.DataGridView cell.
		/// </summary>
		public virtual DataGridViewContentAlignment Alignment { get; set; }

		/// <summary>
		/// Gets or sets the System.Windows.Forms.DataGridView cell display value corresponding to a cell value of System.DBNull.Value or null.
		/// </summary>
		public virtual object NullValue { get; set; }

		/// <summary>
		/// Gets or sets the foreground color used by a System.Windows.Forms.DataGridView cell when it is selected.
		/// </summary>
		public virtual Color SelectionForeColor { get; set; }

		/// <summary>
		/// Gets or sets the background color used by a System.Windows.Forms.DataGridView cell when it is selected.
		/// </summary>
		public virtual Color SelectionBackColor { get; set; }

		/// <summary>
		/// Gets or sets the background color of a System.Windows.Forms.DataGridView cell.
		/// </summary>
		public virtual Color BackColor { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether textual content in a cell is wrapped
		/// </summary>
		public virtual DataGridViewTriState WrapMode { get; set; }

		/// <summary>
		/// Gets or sets the format string applied to the textual content
		/// </summary>
		public virtual string Format { get; set; }
	}
}