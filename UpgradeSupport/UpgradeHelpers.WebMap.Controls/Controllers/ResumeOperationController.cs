

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UpgradeHelpers.BasicViewModels;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;


namespace UpgradeHelpers.WebMap.Controls.Controllers
{

	public class ResumeOperationController : Controller
	{
		public IViewManager ViewManager { get; set; }

		public ActionResult ResumePendingOperation(string dialogResult, string requestedInput)
		{
			ViewManager.ResumePendingOperation(dialogResult, requestedInput);
			return new AppChanges();
		}

		public ActionResult CollectionPendingResults(string coluid, int skip, int take)
		{
			int count;
			var rows = ViewManager.GetCollectionPage(coluid, take, skip, out count); //new AppChanges();
			var res = Json(new { data = rows, total = count });
			res.MaxJsonLength = int.MaxValue;
			return res;
		}

		public ActionResult GetGridPage(string uniqueId, string rowIndexParamName, string pageSizeParamName,
			string orderByParamName,
			string filterParamName, string option)
		{
			var control = ViewManager.GetDataPageableViewModel(uniqueId);
			if (control != null)
			{
				if (control is IInteractsWithView)
				{
					((IInteractsWithView)control).ViewManager = ViewManager;
				}
				int total;
				int addRows;
				var take = Convert.ToInt32(Request[pageSizeParamName]);
				var skip = Convert.ToInt32(Request[rowIndexParamName]);
				var orderBy = Request["orderBy[0][property]"];
				var orderByAsc = Convert.ToBoolean(Request["orderBy[0][asc]"]);

				//filtering
				var filters = new List<GridFilterOptions>();
				if (!String.IsNullOrEmpty(filterParamName))
				{
					var filterValue = Request[filterParamName];
					if (!Request[filterParamName].Equals("null"))
					{
						var filterObjs = JObject.Parse(filterValue);

						foreach (var filterObj in filterObjs)
						{
							var filter = new GridFilterOptions();
							dynamic dynamicFilterOptions = filterObj.Value;

							filter.ColumnName = filterObj.Key;
							filter.Value = Convert.ToString(dynamicFilterOptions.value);
							filter.OperatorType = Convert.ToString(dynamicFilterOptions.@operator);
							filters.Add(filter);
						}
					}
				}
				var data = control.GetPageData(take, skip, out total, orderBy, orderByAsc, filters, out addRows, option);
				return new AppChanges
				{
					PiggyBackResult =
						changes => new { data = new { items = data, totalRowCount = total, totalAddRows = addRows }, delta = changes }
				};
			}
			return new AppChanges
			{
				PiggyBackResult = changes => new { data = new { totalRowCount = 0, totalAddRows = 0 }, delta = changes }
			};
		}

		public ActionResult GetCellComboBox(string uniqueId, string columnsId)
		{
			string[] listsIDs = uniqueId.Split(',');
			string[] columnsIDs = columnsId.Split(',');
			List<object> result = new List<object>();
			for (int i = 0; i < listsIDs.Length; i++)
			{
				var control = ViewManager.GetDataPageableViewModel(listsIDs[i]);
				List<GridFilterOptions> filters = new List<GridFilterOptions>();
				int total = 0;
				int addRows = 0;
				var data = control.GetPageData(Convert.ToInt32(columnsIDs[i]), 0, out total, "", false, filters, out addRows, "");
				result.Add(data);
			}
			var res = Json(new { items = result }, JsonRequestBehavior.AllowGet);
			res.MaxJsonLength = int.MaxValue;
			return res;
		}

		public ActionResult UpdateGridCell(string uniqueId, string value, string col, string row)
		{
			var control = ViewManager.GetDataPageableViewModel(uniqueId);
			if (control != null)
			{
				var c = Convert.ToInt32(col);
				var r = Convert.ToInt32(row);
				control.UpdateDataCell(value, c, r);
			}
			return new AppChanges();
		}

		public void InsertGridRow(string uniqueId)
		{
			var control = ViewManager.GetDataPageableViewModel(uniqueId);
			if (control != null)
			{
				control.InsertRow();
			}
		}
		public ActionResult DataGridViewAddNewRow(DataGridViewViewModel viewFromClient)
		{
			viewFromClient.AddNewRow(null, null);
			return new AppChanges();
		}
		public ActionResult DataGridViewDeleteRow(string uniqueID, int rowIndex)
		{
			var control = (DataGridViewViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.RemoveRow(rowIndex);
			return new AppChanges();
		}

		public ActionResult DataGridViewUpdateRow(string uniqueID, int rowIndex, int colIndex, string newValue)
		{
			var control = (DataGridViewViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.UpdateRow(rowIndex, colIndex, newValue);
			return new AppChanges();
		}

		public ActionResult DataGridViewUpdatedSelectedRowStatus(string uniqueID, int rowIndex, bool isSelected)
		{
			var control = (DataGridViewViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.UpdateRowSelectedStatus(rowIndex, isSelected);
			return new AppChanges();
		}

		/***************** DataGridViewFlex **************************/
		public ActionResult DataGridViewFlexUpdatedSelectedRowStatus(string uniqueID, int rowIndex, bool isSelected, int fixedRows = 0)
		{
			var control = (DataGridViewFlexViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.UpdateSelectionCoordinates(rowIndex, isSelected);
			control.GridPosition = isSelected ? new[] { rowIndex + fixedRows, 0 } : new[] { -1, 0 };
			return new AppChanges();
		}
        public ActionResult TreeNodeInitialization(string uniqueID)
        {
            TreeViewViewModel treeViewViewModel = (TreeViewViewModel)this.ViewManager.GetParentViewModel(() => uniqueID);
            treeViewViewModel.ClearCollection();
            return new AppChanges();
        }

        /***************************************************************/
        /*******************CheckedListBox******************************/
        public ActionResult CheckedListBoxUpdate(string uniqueID, int index, bool isSelected)
		{
			var control = (CheckedListBoxViewModel)ViewManager.GetParentViewModel(() => uniqueID);
			control.SetItemChecked(index, isSelected);
			control.SetItemSelected(index, isSelected);
			return new AppChanges();
		}
		public ActionResult StartDownload()
		{
			var fileToDownload = Session["filenameForDownload"] as String;
			var fileToDownloadContentType = Session["filenameForDownloadContentType"] as String;
			return File(fileToDownload, fileToDownloadContentType, System.IO.Path.GetFileName(fileToDownload));
		}
	}
}
