using Fasterflect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradeHelpers.WebMap.Surrogates.BasicSurrogates
{

	internal class SurrogateUtils
	{
		static MemberGetter fieldRowIDGetter = typeof(DataRow).DelegateForGetFieldValue("_rowID");
		/// <summary>
		/// Retrieves a Row in a Datatable with an specific RowID.
		/// </summary>
		/// <param name="dataTable">The source DataTable</param>
		/// <param name="rowIndex">RowIndex of the Row when it was saved originally.</param>
		/// <param name="rowID">RowID of the Row when it was saved</param>
		/// <returns> Returns the DataRow if not found returns null.</returns>
		internal static DataRow GetRowInDataTable(DataTable dataTable, int rowIndex, int rowID)
		{
			DataRow res = null;
            DataRow rowCandidate = null;
            if (rowIndex < dataTable.Rows.Count)
               rowCandidate = dataTable.Rows[rowIndex];
            var rowCanditateID = -1;
            if(rowCandidate != null)
                rowCanditateID = Convert.ToInt32(fieldRowIDGetter(rowCandidate));
            if (rowCanditateID != -1 && rowCanditateID == rowID)
				res = rowCandidate;
			else
			{
				int index = -1;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					rowCandidate = dataTable.Rows[i];
					if (Convert.ToInt32(fieldRowIDGetter(rowCandidate)) == rowID)
					{
						res = rowCandidate;
						index = i;
						break;
					}
				}
				if (index != -1)
					res = dataTable.Rows[index];
			}
			return res;
		}

		internal static int GetRowID(DataRow dataRow)
		{
			return Convert.ToInt32(fieldRowIDGetter(dataRow));
		}
	}
}
