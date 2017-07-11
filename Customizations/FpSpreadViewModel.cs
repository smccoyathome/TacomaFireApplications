// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="FpSpreadViewModel.cs" >
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
    using System.Collections.Generic;

    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     View Model for FarPoint Spread
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class FpSpreadViewModel : ControlBaseViewModel
    {
        private SheetViewModel _activeSheet;

        [Obsolete]
        public FPActionConstants Action { get; set; }

        /// <summary>
        ///     Gets or sets the active sheet.
        /// </summary>
        /// <value>
        ///     The active sheet.
        /// </value>
        public virtual SheetViewModel ActiveSheet
        {
            get
            {
                if (this._activeSheet == null && this.Sheets.Count > 0)
                {
                    this._activeSheet = this.Sheets[0];
                }

                return this._activeSheet;
            }

            set
            {
                this._activeSheet = value;
            }
        }

        [StateManagement(StateManagementValues.None)]
        public override Color ForeColor
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).ForeColor;
            }
            set
            {
                if (BlockMode)
                {
                    for (var i = 0; i < Col2; i++)
                        ActiveSheet.Cells.Get(Row, i).ForeColor = value;
                }
                else
                    ActiveSheet.Cells.Get(Row, Col).ForeColor = value;
                ReloadData();
            }
        }

        [StateManagement(StateManagementValues.None)]
        public override Color BackColor
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).BackColor;
            }
            set
            {
                if (BlockMode)
                {
                    for (var i = 0; i < Col2; i++)
                        ActiveSheet.Cells.Get(Row, i).BackColor = value;
                }
                else
                    ActiveSheet.Cells.Get(Row, Col).BackColor = value;
            }
        }

      



        public bool BlockMode { get; set; }

        public Color CellBorderColor { get; set; }

        [Obsolete]
        public object CellBorderStyle { get; set; }

        public int CellBorderType { get; set; }

        public string CellNote { get; set; }

        public bool CellNoteIndicator { get; set; }

        [StateManagement(StateManagementValues.Both, null)]
        public bool AllowDrop { get; set; }

        public Cells.FpCellType CellType { get; set; }

        public int Col { get; set; }

        public int Col2 { get; set; }

        [Obsolete]
        public void SetSelection(int ICol, int iRow, int ICol2, int iRow2)
        {
            throw new NotImplementedException();
        }
        public UpgradeHelpers.Helpers.BorderStyle BorderStyle { get; set; }

        /// <summary>
        ///     Returns the last row that contains data in the spreadsheet
        /// </summary>
        [StateManagement(StateManagementValues.None)]
        public int DataRowCnt
        {
            get
            {
                return this.ActiveSheet.GetLastNonEmptyRow(NonEmptyItemFlag.Data) + 1;
            }
        }

        public bool EditMode { get; set; }

        [StateManagement(StateManagementValues.None)]
        public bool FontBold
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).Font.Bold;
            }
            set
            {
                ActiveSheet.Cells.Get(Row, Col).Font.Bold = value;
                ReloadData();
            }
        }

        [StateManagement(StateManagementValues.None)]
        public bool FontItalic
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).Font.Italic;
            }
            set
            {
                ActiveSheet.Cells.Get(Row, Col).Font.Italic = value;
                ReloadData();
            }
        }

        [StateManagement(StateManagementValues.None)]
        public float FontSize
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).Font.Size;
            }
            set
            {
                ActiveSheet.Cells.Get(Row, Col).Font.Size = value;
                ReloadData();
            }
        }

        [StateManagement(StateManagementValues.None)]
        public bool FontUnderline
        {
            get
            {
                return ActiveSheet.Cells.Get(Row, Col).Font.Underline;
            }
            set
            {
                ActiveSheet.Cells.Get(Row, Col).Font.Underline = value;
                ReloadData();
            }
        }

        public virtual bool Lock { get; set; }

        public int MaxCols { get; set; } = 500;


        public virtual int MaxRows { get; set; }

        /// <summary>
        ///     Gets or sets the named styles.
        /// </summary>
        /// <value>
        ///     The named styles.
        /// </value>
        public virtual IList<NamedStyle> NamedStyles { get; set; }

        public bool Protect { get; set; }

        public int Row { get; set; }

        public int Row2 { get; set; }

        public bool SelModeSelected { get; set; }

        /// <summary>
        ///     Gets or sets the sheets.
        /// </summary>
        /// <value>
        ///     The sheets.
        /// </value>
        public virtual IList<SheetViewModel> Sheets { get; set; }

        public TextTipPolicy TextTip { get; set; }

        public string TypeButtonText { get; set; }

        public bool TypeCheckCenter { get; set; }

        public int TypeComboBoxIndex { get; set; }

        public string TypeComboBoxString { get; set; }

        public bool TypeEditMultiLine { get; set; }

        public CellHorizontalAlignment TypeHAlign { get; set; }

        /// <summary>
        ///     This property points to the value in the cell located in the Col and Row properties positions
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        ///     Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public override void Build(IIocContainer ctx)
        {
            this.Sheets = ctx.Resolve<IList<SheetViewModel>>();
            this.NamedStyles = ctx.Resolve<IList<NamedStyle>>();

            // Win Forms Sheets collection loads by default with one sheet
            //Needs to be added explicitly.
            //this.Sheets.Add(ctx.Resolve<SheetViewModel>());
            base.Build(ctx);
        }

        [StateManagement(StateManagementValues.None)]
        public override string Text
        {
            get
            {
                return ActiveSheet.Rows[Row].cells[Row, Col].Value as string;
            }
            set
            {
                ActiveSheet.Rows[Row].cells[Row, Col].Value = value;
                ReloadData();
            }
        }
        private bool changed = false;
        public virtual bool RefreshSource { get; set; }
        public virtual bool HideCellBorders { get; set; }
        public virtual bool HideLeftRightBorders { get; set; }

        public void ReloadData()
        {
            if (!changed)
            {
                RefreshSource = !RefreshSource;
                changed = true;
            }
        }

        /// <summary>
        ///     Clear a specific range of cells
        /// </summary>
        /// <param name="Row1"></param>
        /// <param name="Col1"></param>
        /// <param name="Row2"></param>
        /// <param name="Col2"></param>
        /// <param name="DataOnly"></param>
        public void ClearRange(int Row1, int Col1, int Row2, int Col2, bool DataOnly)
        {
            this.ActiveSheet.ClearRange(Row1 - 1, Col1 - 1, Row2 - Row1 + 1, Col2 - Col1 + 1, DataOnly);
        }

        /// <summary>
        ///     Clears selection
        /// </summary>
        public void ClearSelection()
        {
            this.Row2 = this.Row;
            this.Col2 = this.Col;
            this.ActiveSheet.ClearSelection();
        }

        /// <summary>
        ///     Insert a row or rows after indicated Row
        /// </summary>
        /// <param name="Row">Row number</param>
        /// <returns></returns>
        public void InsertRows(int row, int count)
        {
            if (row >= 1 && row <= this.MaxRows)
            {
                this.ActiveSheet.Rows.Add(row, count);
                this.MaxRows -= count;
            }
        }

        [Obsolete]
        public void SetCellBorder(
            int i1,
            int iRowA1,
            int i2,
            int iRowA2,
            int v,
            Color color,
            BorderStyle cellBorderStyle)
        {
            throw new NotImplementedException();
        }

        [Obsolete]

        /// <summary>
        /// Sets the column sort indicator
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sort"></param>
        public void SetColUserSortIndicator(int col, SortIndicator sort)
        {
            this.ActiveSheet.Columns[col].SortIndicator = sort;
        }

        /// <summary>
        ///     Sets the column width value
        /// </summary>
        /// <param name="col"></param>
        /// <param name="width"></param>
        public void SetColWidth(int col, float width)
        {
            this.ActiveSheet.Columns[col].Width = width;
        }

        /// <summary>
        ///     Sets the row height value
        /// </summary>
        /// <param name="row"></param>
        /// <param name="height"></param>
        public void SetRowHeight(int row, float height)
        {
            this.ActiveSheet.Rows[row].Height = height;
        }

        public void SetSortKey(int nIndex, int value)
        {
            throw new NotImplementedException();
        }

        public void SetSortKeyOrder(int v, SortKeyOrderConstants sortKeyOrderDescending)
        {
            throw new NotImplementedException();
        }

        public void ClearAllCells()
        {
            ActiveSheet.Rows.Clear();
            ActiveSheet.Cells.Clear();
            ReloadData();
        }
    }

    public class SheetView : IDependentModel
    {
        public string UniqueID { get; set; }
    }

    /// <summary>
    ///     Action constants
    /// </summary>
    public enum FPActionConstants
    {
        /// <summary>
        ///     Active cell
        /// </summary>
        ActionActiveCell = 0,

        /// <summary>
        ///     Goto cell
        /// </summary>
        ActionGotoCell = 1,

        /// <summary>
        ///     Select block
        /// </summary>
        ActionSelectBlock = 2,

        /// <summary>
        ///     Clear
        /// </summary>
        ActionClear = 3,

        /// <summary>
        ///     Clear
        /// </summary>
        ActionDeleteCol = 4,

        /// <summary>
        ///     Delete Row
        /// </summary>
        ActionDeleteRow = 5,

        /// <summary>
        ///     Insert column
        /// </summary>
        ActionInsertCol = 6,

        /// <summary>
        ///     Insert row
        /// </summary>
        ActionInsertRow = 7,

        /// <summary>
        ///     ActionReCalc
        /// </summary>
        ActionReCalc = 11,

        /// <summary>
        ///     Clear text
        /// </summary>
        ActionClearText = 12,

        /// <summary>
        ///     ActionPrint
        /// </summary>
        ActionPrint = 13,

        /// <summary>
        ///     Deselect Block
        /// </summary>
        ActionDeselectBlock = 14,

        /// <summary>
        ///     ActionDSave
        /// </summary>
        ActionDSave = 15,

        /// <summary>
        ///     ActionSetCellBorder
        /// </summary>
        ActionSetCellBorder = 16,

        /// <summary>
        ///     Add multiselect block
        /// </summary>
        ActionAddMultiSelBlock = 17,

        /// <summary>
        ///     Gets multi selection
        /// </summary>
        ActionGetMultiSelection = 18,

        /// <summary>
        ///     ActionCopyRange
        /// </summary>
        ActionCopyRange = 19,

        /// <summary>
        ///     ActionModeRange
        /// </summary>
        ActionModeRange = 20,

        /// <summary>
        ///     ActionSwapRange
        /// </summary>
        ActionSwapRange = 21,

        /// <summary>
        ///     Clipboard copy
        /// </summary>
        ActionClipboardCopy = 22,

        /// <summary>
        ///     ActionClipboardCut copy
        /// </summary>
        ActionClipboardCut = 23,

        /// <summary>
        ///     Clipboard paste
        /// </summary>
        ActionClipboardPaste = 24,

        /// <summary>
        ///     Sort
        /// </summary>
        ActionSort = 25,

        /// <summary>
        ///     ActionComboClear
        /// </summary>
        ActionComboClear = 26,

        /// <summary>
        ///     ActionComboRemove
        /// </summary>
        ActionComboRemove = 27,

        /// <summary>
        ///     ActionReset
        /// </summary>
        ActionReset = 28,

        /// <summary>
        ///     ActionSelModeClear
        /// </summary>
        ActionSelModeClear = 29,

        /// <summary>
        ///     ActionVModeRefresh
        /// </summary>
        ActionVModeRefresh = 30,

        /// <summary>
        ///     Smart print
        /// </summary>
        ActionSmartPrint = 32
    }


    /// <summary>
    ///     Sort by constants
    /// </summary>
    public enum SortByConstants
    {
        /// <summary>
        ///     By row
        /// </summary>
        SortByRow = 0,

        /// <summary>
        ///     By column
        /// </summary>
        SortByCol = 1
    }

    /// <summary>
    ///     Sort key order constants
    /// </summary>
    public enum SortKeyOrderConstants
    {
        /// <summary>
        ///     No order
        /// </summary>
        SortKeyOrderNone = 0,

        /// <summary>
        ///     Order Ascending
        /// </summary>
        SortKeyOrderAscending = 1,

        /// <summary>
        ///     Order Descending
        /// </summary>
        SortKeyOrderDescending = 2
    }

    // cell note is displayed.
    /// <summary>
    ///     Specifies how the text tip of a cell in the view is displayed, and also how the
    /// </summary>
    public enum TextTipPolicy
    {
        /// <summary>
        ///     Does not display the text tip
        /// </summary>
        Off = 0,

        /// <summary>
        ///     Aligns it to the top-left corner of the cell for which it appears at any time
        /// </summary>
        Fixed = 1,

        /// <summary>
        ///     Aligns it to the pointer location at any time
        /// </summary>
        Floating = 2,

        // control has the focus
        /// <summary>
        ///     Aligns it to the top-left corner of the cell for which it appears only when the
        /// </summary>
        FixedFocusOnly = 3,

        /// <summary>
        ///     Aligns it to the pointer location only when the control has the focus
        /// </summary>
        FloatingFocusOnly = 4
    }
}