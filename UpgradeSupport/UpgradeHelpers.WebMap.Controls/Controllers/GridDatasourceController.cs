using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UpgradeHelpers.BasicViewModels;
using UpgradeHelpers.BasicViewModels.Interfaces;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace UpgradeHelpers.WebMap.Controls.Controllers
{
	public class GridDatasourceController : Controller
	{
		public class ModifiedRow
		{
			public string[] ItemContent { get; set; }
			public string UniqueID { get; set; }
			public int RecordSetIndex { get; set; }
		}
		public IViewManager ViewManager { get; set; }

		/// <summary>
		/// Gets the rows of the specific page that belongs to a Grid.
		/// </summary>
		/// <param name="gridUid">Grid UniqueID.</param>
		/// <param name="take">The page size</param>
		/// <param name="skip"></param>
		/// <returns></returns>
		public ActionResult GetDataSource(string gridUid, int take, int skip, int page, int pageSize)
		{
			var grid = getGrid(gridUid);
			int count = 0;
			List<object> rowList = new List<object>();

			if (grid != null)
			{
				var rows = grid.GetRows(skip, take);
				count = grid.RowCount();
				rowList.AddRange(rows);
			}

			var res = Json(new { data = rowList, total = count }, "application/json", JsonRequestBehavior.AllowGet);
			res.MaxJsonLength = int.MaxValue;
			return res;

		}

		public ActionResult UpdateDataSourceRecord(string uniqueID, int rowIndex, int columnIndex, string value)
		{
			var control = (C1TrueDBGridViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.UpdateRecord(rowIndex, columnIndex, value);
			return new AppChanges();
		}

		public ActionResult DeleteRecord(string uniqueID, int rowIndex)
		{
			var control = (C1TrueDBGridViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.RemoveRecord(rowIndex);
			return new AppChanges();
		}

		/// <summary>
		/// Gets the Grid viewModel that corresponds
		/// to the UniqueID passed as parameter.
		/// </summary>
		/// <param name="uniqueID">Grid UniqueID</param>
		/// <returns></returns>
		private IDataGrid getGrid(string uniqueID)
		{
			var obj = (object)ViewManager.GetObject(uniqueID);
			if (obj != null)
			{
				IDataGrid grid = obj as IDataGrid;
				if (grid != null)
					return grid;
			}
			// Warning: No grid was found.
			return null;
		}

		#region RecordSet Management

		public ActionResult UpdateRecordSet(string uniqueID, int selectedRow = 0)
		{
			var control = (C1TrueDBGridViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			if (control.RecordSet != null && control.RecordSet.RecordCount > 0)
			{
				MoveToRecord(selectedRow, control.RecordSet);
			}
			return new AppChanges();
		}

		private void MoveToRecord(int position, ADORecordSetHelper recordSet)
		{
			if (position == recordSet.CurrentPosition) return;
			var offSet = position - recordSet.CurrentPosition;
			recordSet.Move(offSet);
		}
		#endregion

	}
}
