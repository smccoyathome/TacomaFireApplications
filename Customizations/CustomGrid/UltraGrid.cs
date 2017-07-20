// *************************************************************************************
// <copyright company="Mobilize" file="UltraGrid.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System.Collections;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Custom.ViewModels.Grid
{
    using System;
    using System.Collections.Generic;
    using System.Data;


    using Newtonsoft.Json;

    using UpgradeHelpers.Interfaces;
    using UpgradeHelpers.BasicViewModels.Interfaces;
    using UpgradeHelpers.BasicViewModels;
    using UpgradeHelpers.Helpers;

    /// <summary>
    /// Class UltraGrid.
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class CustomGrid : UltraGridBase
    {
        /// <summary>
        /// Returns a reference to a Selected object containing collections of all the selected objects in the grid. 
        /// This property is read-only at run-time. This property is not available at design-time
        /// </summary>
        public virtual Selected Selected { get; set; }

        /// <summary>
        /// Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
            Selected = ctx.Resolve<Selected>(this);
        }



        /// <summary>
        /// Performs the action.
        /// </summary>
        /// <param name="actionCode">The action code.</param>
        /// <param name="shift">if set to <c>true</c> [shift].</param>
        /// <param name="control">if set to <c>true</c> [control].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool PerformAction(UltraGridAction actionCode, bool shift = false, bool control = false)
        {
            return this.ExecuteAction(actionCode, shift, control) ?? false;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        private void Clear()
        {
        }

        /// <summary>
        /// Deletes the selected rows.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool DeleteSelectedRows()
        {
            return false;
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="actionCode">The action code.</param>
        /// <param name="shift">if set to <c>true</c> [shift].</param>
        /// <param name="control">if set to <c>true</c> [control].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">the actionCode - null</exception>
        private bool? ExecuteAction(UltraGridAction actionCode, bool shift, bool control)
        {
            switch (actionCode)
            {
                case UltraGridAction.ToggleEditMode:
                    return this.ActiveCell.ToggleEditMode();
                case UltraGridAction.ToggleDropdown:
                    return this.ActiveCell.ToggleDropDown();
                case UltraGridAction.UndoCell:
                    return this.ActiveCell?.CancelUpdate();
                case UltraGridAction.UndoRow:
                    return this.ActiveRow.CancelUpdate();
                case UltraGridAction.CloseDropdown:
                    return this.ActiveCell.HideDropDown();
                case UltraGridAction.EnterEditMode:
                    return this.ActiveCell.EnterEditMode();
                case UltraGridAction.EnterEditModeAndDropdown:
                    return this.ActiveCell.ShowDropDown();
                case UltraGridAction.ExpandRow:
                    return this.ActiveRow.Expand();
                case UltraGridAction.DeleteRows:
                    return this.DeleteSelectedRows();
                case UltraGridAction.DeactivateCell:
                    return this.InactiveCell();
                case UltraGridAction.ActivateCell:
                    return this.SetActiveCell();
                case UltraGridAction.CollapseRow:
                    return this.ActiveRow.Collapse();
                case UltraGridAction.ToggleCheckbox:
                    return this.ActiveCell.ToggleCheckBox();
                case UltraGridAction.ExitEditMode:
                    return this.ActiveCell.ExitEditMode();
                case UltraGridAction.CommitRow:
                    return this.ActiveRow.CommitRow();
                case UltraGridAction.Copy:
                    return this.ExecuteCopyCellsActions();
                case UltraGridAction.Cut:
                    return this.ExecuteCutCellsActions();
                case UltraGridAction.DeleteCells:
                    return this.ExecuteDeleteCellsActions();
                case UltraGridAction.Paste:
                    return this.ExecutePasteCellsActions();
                case UltraGridAction.Undo:
                    return this.ExecuteUndoCellsActions();
                case UltraGridAction.Redo:
                    return this.ExecuteRedoCellsActions();
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionCode), actionCode, null);
            }
        }

        /// <summary>
        /// Executes the copy cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecuteCopyCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Executes the cut cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecuteCutCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Executes the delete cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecuteDeleteCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Executes the paste cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecutePasteCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Executes the redo cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecuteRedoCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Executes the undo cells actions.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExecuteUndoCellsActions()
        {
            return false;
        }

        /// <summary>
        /// Inactive the cell.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool InactiveCell()
        {
            return false;
        }

        /// <summary>
        /// Processes the data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        private void ProcessDataTable(DataTable dataTable)
        {
            var band = this.Container.Resolve<UltraGridBand>();
            foreach (System.Data.DataColumn column in dataTable.Columns)
            {
                band.Columns.Add(column);
            }

            this.Bands.Add(band);
        }

        /// <summary>
        /// Sets the active cell.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool SetActiveCell()
        {
            return false;
        }

        public int RowCount()
        {
            if (DataSource != null)
                return DataSourceCount;
            return this.Rows.Count;
        }

        public IEnumerable<UltraGridRow> GetRows(int skip, int take)
        {
	        Rows.Clear();
            var rows = Container.Resolve<IList<UltraGridRow>>();

            if (this._dataSource != null)
            {

                var rowsCount = DataSourceCount;
                if (DataSource is IList)
                {
                    rows = SetRowsFromListDataSource(take, rowsCount, skip, (IList)DataSource);
                }
                if (DataSource is DataTable)
                {
                    rows = SetRowsFromDataTableSource(take, rowsCount, skip, (DataTable)DataSource);
                }

            }
            Rows.Items = rows;
            return rows;
        }

        private IList<UltraGridRow> SetRowsFromDataTableSource(int take, int rowsCount, int current, DataTable dataSource)
        {
            var dsRows = Container.Resolve<IList<UltraGridRow>>();
            for (var i = 0; i < take; i++)
            {
                if (i < rowsCount && current < rowsCount)
                {
                    var dataRowView = dataSource.DefaultView[current];
                    var dr = Container.Resolve<UltraGridRow>();
                    dr.ItemContent = dataRowView.Row.ItemArray;
                    dsRows.Add(dr);
                }
                else
                {
                    break;
                }
                current++;
            }
            return dsRows;
        }

        private IList<UltraGridRow> SetRowsFromListDataSource(int take, int rowsCount, int current, IList dsCollection)
        {
            var dsRows = Container.Resolve<IList<UltraGridRow>>();
            for (var i = 0; i < take; i++)
            {
                if (i < rowsCount && current < rowsCount)
                {
                    var dataRowView = dsCollection[current];
                    var dr = Container.Resolve<UltraGridRow>();
                    var props = Columns.Items.Select(col => col.Key).Distinct();
                    var propIndex = 0;
                    foreach (var prop in props)
                    {
                        var info = string.Empty;
                        if (dataRowView is JObject)
                        {
                            var value = ((JObject)dataRowView).GetValue(prop);
                            info = value != null ? value.ToString() : (Columns[prop].ValueList.ValueListItems != null ? Columns[prop].ValueList.ValueListItems[0].Text : string.Empty);
                        }
                        else
                        {
                            info = dataRowView.GetType().GetProperty(prop).GetValue(dataRowView, null) as string;
                        }

                        dr.SetColumnValue(propIndex, info);
                        propIndex++;
                    }
                    dsRows.Add(dr);
                }
                else
                {
                    break;
                }
                current++;
            }
            return dsRows;
        }

        public void UpdateDataSource(int rowIndex, string[] content)
        {
            if (this._dataSource != null)
            {

                var rowsCount = DataSourceCount;
                if (DataSource is IList)
                {
                    UpdateListDataSource(rowIndex, content, (IList)DataSource);
                }
                if (DataSource is DataTable)
                {
                    UpdateDataTableSource(rowIndex, content, (DataTable)DataSource);
                }

            }
        }

        private void UpdateDataTableSource(int rowIndex, string[] content, DataTable dataSource)
        {
            if (rowIndex < dataSource.Rows.Count)
            {
                dataSource.Rows[rowIndex].ItemArray = content;
                DataSource = dataSource;
            }
        }

        private void UpdateListDataSource(int rowIndex, string[] content, IList dataSource)
        {
            if (rowIndex < dataSource.Count)
            {
                var dataRowView = dataSource[rowIndex];
                var props = Columns.Items.Select(col => col.Key).Distinct();
                var propIndex = 0;
                foreach (var prop in props)
                {
                    var info = string.Empty;
                    if (dataRowView is JObject)
                    {
                        ((JObject)dataRowView)[prop] = content[propIndex];
                    }
                    else
                    {
                        dataRowView.GetType().GetProperty(prop).SetValue(dataRowView, content[propIndex]);
                    }
                    propIndex++;
                }
                dataSource[rowIndex] = dataRowView;
                AvoidSelectColumns = true;
                DataSource = dataSource;
                AvoidSelectColumns = false;
            }
        }

        public void PerformAfterEnterEditModeEvent()
        {
            ViewManager.Events.Publish("AfterEnterEditMode", this, this, new EventArgs());
        }
    }
}