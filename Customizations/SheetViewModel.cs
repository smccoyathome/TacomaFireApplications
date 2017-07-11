// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="SheetViewModel.cs" >
// //      Copyright (c) 2017 Mobilize, Inc. All Rights Reserved.
// //      All classes are provided for customer use only,
// //      all other use is prohibited without prior written consent from Mobilize.Net.
// //      no warranty express or implied,
// //      use at own risk.
// // </copyright>
// // <summary></summary>
// // ************************************************************************************* 

namespace FarPoint.ViewModels
{
    using System;
    using System.Linq;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     Model for Sheet View
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class SheetViewModel : IDependentViewModel
    {
        /// <summary>
        ///     Gets the cells.
        /// </summary>
        /// <value>
        ///     The cells.
        /// </value>
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Cells Cells { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual ColumnHeader ColumnHeader { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Columns Columns { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual RowHeader RowHeader { get; set; }

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Rows Rows { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sheet.
        /// </summary>
        /// <value>
        ///     The name of the sheet.
        /// </value>
        public virtual string SheetName { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }
        public bool HideCellBorders { get; set; }

        /// <summary>
        ///     Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
            this.Cells = ctx.Resolve<Cells>(this);
            this.Rows = ctx.Resolve<Rows>(this.Cells);
            this.Columns = ctx.Resolve<Columns>(this.Cells);
            this.RowHeader = ctx.Resolve<RowHeader>(this.Columns);
            this.ColumnHeader = ctx.Resolve<ColumnHeader>(this.Rows);
            this.SheetName = "Sheet1";
        }

        /// <summary>
        ///     Clears selection
        /// </summary>
        public void ClearSelection()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Clear Range
        /// </summary>
        /// <param name="Row1">Left Row to look at</param>
        /// <param name="Col1">Top column to look at</param>
        /// <param name="Row2">Right Row to look at</param>
        /// <param name="Col2">Bottom column to look at</param>
        /// <param name="DataOnly">if only data</param>
        internal void ClearRange(int Row1, int Col1, int Row2, int Col2, bool DataOnly)
        {
            for (int y = Row1; y <= Row2; y++)
            {
                for (int x = Col1; x <= Col1; x++)
                {
                    this.Cells[y, x].Value = null;
                }
            }
        }

        /// <summary>
        ///     Return the last row index containing data or styles
        /// </summary>
        /// <param name="dataFlag"></param>
        /// <returns></returns>
        internal int GetLastNonEmptyRow(NonEmptyItemFlag dataFlag)
        {
            if (dataFlag == NonEmptyItemFlag.Data)
            {
                var cell = this.Cells[this.Cells.ToList().FindLastIndex(FindLasNonEmptyCell), 0];
                return cell != null ? cell.Row : -1;
            }

            throw new NotImplementedException();
        }

        // Explicit predicate delegate to find the last non empty cell.
        private static bool FindLasNonEmptyCell(Cell cell)
        {
            if (!string.IsNullOrEmpty(cell.Value))
            {
                return true;
            }

            return false;
        }
    }

    /// <summary>
    ///     Specifies the type of contents of a cell.
    /// </summary>
    public enum NonEmptyItemFlag
    {
        /// <summary>
        ///     Indicates that a cell contains data
        /// </summary>
        Data = 1,

        /// <summary>
        ///     Indicates that a cell contains formatting information
        /// </summary>
        Style = 2
    }
}