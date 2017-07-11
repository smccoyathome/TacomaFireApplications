using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.BasicViewModels.Interfaces
{
	// Allows the GridDataSourceController to access the grid Rows collection 
	public interface IDataGrid
	{
		int RowCount();
		IEnumerable<IGridRow> GetRows(int skip, int take);
	}

	public interface IGridRow
	{
		object[] ItemContent { get; set; }
		void SetColumnValue(int column, string value);
	}
}
