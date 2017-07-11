using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class Style : IDependentViewModel
	{
		/// <summary>
		///   Gets or sets the background color associated with a Style.
		/// </summary>
		public virtual Color BackColor { get; set; }
		/// <summary>
		///   Gets or sets the foreground color associated with a Style.
		/// </summary>
		public virtual Color ForeColor { get; set; }
		/// <summary>
		/// Gets or sets the Alignment value associated with a Style
		/// </summary>
		public virtual DataGridViewContentAlignment Alignment { get; set; }
		public string UniqueID { get; set; }
		public void Build(IIocContainer ctx)
		{
		}
	}
}