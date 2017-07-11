using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class DataGridViewCellViewModel : IDependentViewModel
	{
		/// <summary>
		/// Gets or sets the value associated with this cell.
		/// </summary>
		public virtual object Value { get; set; }
		/// <summary>
		/// Gets the column index for this cell
		/// </summary>
		public virtual int ColumnIndex { get; set; }
		/// <summary>
		/// Gets the RowIndex
		/// </summary>
		public virtual int RowIndex { get; set; }

		/// Gets or sets the value datatype
		/// </summary>
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual Type ValueType { get; set; }

		/// <summary>
		/// Get or sets the style value for the cell
		/// </summary>
		public virtual Style Style { get; set; }

		public void Build(IIocContainer ctx)
		{
			Value = string.Empty;
			ColumnIndex = -1;
			RowIndex = -1;
			Style = ctx.Resolve<Style>();
		}
		//CellUniqueID
		public string UniqueID { get; set; }
	}
}

