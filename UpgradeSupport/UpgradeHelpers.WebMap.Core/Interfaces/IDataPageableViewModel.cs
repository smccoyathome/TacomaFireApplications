using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.WebMap.Server.Interfaces
{
    /// <summary>
    /// Defines  an object that provides pages of data.
    /// </summary>
    public interface IDataPageableViewModel
    {
	    /// <summary>
	    /// Gets a specific page of data, starting in <c>skip</c> row and returning <c>take</c> data.
	    /// </summary>
	    /// <param name="take">Size of the page or number of elements to return.</param>
	    /// <param name="skip">starting record.</param>
	    /// <param name="total">Total of rows to process</param>
	    /// <param name="orderBy"></param>
	    /// <param name="orderByAsc"></param>
	    /// <param name="filter"></param>
	    /// <returns></returns>
	    IEnumerable<IDictionary<string, object>> GetPageData(int take, int skip, out int total, string orderBy, bool orderByAsc,
			List<GridFilterOptions> filter, out int addRows, string option);
        //IEnumerable<IDictionary<string, object>> GetCellComboBoxData(int columnId);


		void UpdateDataCell(string value, int col, int row);

		void InsertRow();

    }

}
