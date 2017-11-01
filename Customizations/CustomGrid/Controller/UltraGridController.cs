// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridController.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;

namespace Custom.ViewModels.Grid.Controller
{
	public class UltraGridController : System.Web.Mvc.Controller
	{
		private class EditedCellInfo
		{
			int index { get; set; }
			string[] ItemContent { get; set; }
		}

		public IViewManager ViewManager { get; set; }
		/// <summary>
		/// Gets the rows of the specific page that belongs to an UltraGrid.
		/// </summary>
		/// <param name="gridUid">UltraGrid UniqueID.</param>
		/// <param name="take">The page size</param>
		/// <param name="skip"></param>
		/// <returns></returns>
		public ActionResult GetDataSource(string gridUid, int? take, int? skip, int page, int pageSize)
		{
			if (!skip.HasValue)
				skip = 0;
			if (!take.HasValue)
				take = 25;

			var grid = GetUltraGrid(gridUid);
			int count = 0;
			List<object> rowList = new List<object>();
            List<object> columnList = new List<object>();

            if (grid != null)
			{
				IEnumerable<UltraGridRow> rows = grid.GetRows(skip.Value, take.Value);
				count = grid.DataSourceCount;
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].ValueList.ValueListItems.Count > 0)
                    {
                        List<object> comboValues = new List<object>();
                        foreach (var value in grid.Columns[i].ValueList.ValueListItems)
                        {
                            var newComboVal = new { DisplayText = value.DisplayText, DataValue = value.DataValue };
                            comboValues.Add(newComboVal);
                        }
                        var valueList = new
                        {
                            ColumnKey = grid.Columns[i].Key,
                            Position = i,
                            ValueList = comboValues
                        };
                        columnList.Add(valueList);
                    }
                }

                foreach (UltraGridRow row in rows)
				{
					List<object> cellList = new List<object>();

					foreach (UltraGridCell cell in row.Cells.Items)
					{
						cellList.Add(cell);
					}

					var obj = new
					{
						UniqueID = row.UniqueID,
						//Activation = row.Activation,
						//VisibleIndex = row.VisibleIndex,
						Selected = row.Selected,
						ItemContent = row.ItemContent,
						//ListIndex = row.ListIndex,
						//IsFilteredOut = row.IsFilteredOut,
						//IsExpandable = row.IsExpandable,
						//IsDeleted = row.IsDeleted,
						//IsDataRow = row.IsDataRow,
						//InInitializeRowEvent = row.InInitializeRowEvent,
						//Hidden = row.Hidden,
						//CardCaption = row.CardCaption,
						ToolTipText = row.ToolTipText,
						Index = row.Index,
						Cells = cellList
					};

					rowList.Add(obj);
				}
			}

			var res = Json(new { data = rowList, total = count, columnList }, "application/json", JsonRequestBehavior.AllowGet);
			res.MaxJsonLength = int.MaxValue;
			return res;

		}

		public ActionResult UpdateSelectedRows(string gridUid, string selectedRows)
		{
			var grid = GetUltraGrid(gridUid);
			var selectedIndices = selectedRows.Split(',').Select(int.Parse).ToArray();
			grid.Selected.SelectedRowsIndices = selectedIndices;
			int i = grid.Selected.Rows.Count;
			return new AppChanges();
		}

		/// <summary>
		/// Update the content of the edited cell
		/// </summary>
		/// <param name="gridUid"></param>
		/// <param name="editedCell"></param>
		/// <returns></returns>
		public ActionResult UpdateEditedCells(string gridUid, string editedCell)
		{
			var grid = GetUltraGrid(gridUid);
			var cell = JObject.Parse(editedCell);
			var rowIndex = cell["index"].ToObject<int>();
			var content = cell["ItemContent"].ToObject<string[]>();
			grid.UpdateDataSource(rowIndex, content);
			return new AppChanges();
		}

		/// <summary>
		/// Update the edit mode for the current cell
		/// </summary>
		/// <param name="gridUid"></param>
		/// <param name="editedCell"></param>
		/// <returns></returns>
		public ActionResult UpdateEditMode(string gridUid, int column, int row)
		{
			var grid = GetUltraGrid(gridUid);
			grid.Rows[row].Cells[column].IsInEditMode = true;
			grid.PerformAfterEnterEditModeEvent();
			return new AppChanges();
		}

		/// <summary>
		/// Update the grid's selected cells collection
		/// </summary>
		/// <param name="gridUid"></param>
		/// <param name="selectedCells"></param>
		/// <returns></returns>
		public ActionResult UpdateSelectedCells(string gridUid, string selectedCells)
		{
			var grid = GetUltraGrid(gridUid);
			IList<UltraGridCell> cells = JArray.Parse(selectedCells).ToObject<IList<UltraGridCell>>();
			grid.Selected.SelectedCells = cells.ToList();
			int i = grid.Selected.Cells.Count;
			return new AppChanges();
		}

		public ActionResult UpdateSelectedColumns(string gridUid, string columnIndices)
		{
			var grid = GetUltraGrid(gridUid);
			var selectedIndices = columnIndices.Split(',').Select(int.Parse).ToArray();
			grid.Selected.SelectedColumnsIndices = selectedIndices;
			return new AppChanges();
		}

		/// <summary>
		/// Gets the UltraGridViewModel that corresponds
		/// to the UniqueID passed as parameter.
		/// </summary>
		/// <param name="uniqueID">UltraGrid UniqueID</param>
		/// <returns></returns>
		private CustomGrid GetUltraGrid(string uniqueID)
		{
			var obj = (object)ViewManager.GetObject(uniqueID);
			if (obj != null)
			{
				CustomGrid ultraGrid = obj as CustomGrid;
				if (ultraGrid != null)
					return ultraGrid;
			}

			// Warning: No grid was found.
			return null;
		}
	}
}
