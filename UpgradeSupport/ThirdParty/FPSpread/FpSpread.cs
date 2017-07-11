namespace UpgradeHelpers.Spread
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Drawing;
    using System.Security.Cryptography;
    using System.Windows.Forms;
    using FarPoint.Win.Spread;
    using FarPoint.Win.Spread.CellType;
    using FarPoint.Win.Spread.Model;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.Devices;
    using Appearance = FarPoint.Win.Spread.Appearance;
    using System.Reflection;

    /// <summary>
    /// Farpoint Helper Class for VB6 control equivalence
    /// </summary>
    public partial class FpSpread : FarPoint.Win.Spread.FpSpread
    {
        private IComparer _Comparer;
        private SortInfo[] _SortInfo;
        private string _ToolTipText;
        private Graphics graficsObject;

        private bool _RunLocalEvents;
        private FpUserResizeEnum _UserResizeCol;

        // remember the last 3 sort orders and active cell to be able to reinstate them 
        // last active cell is remembered on .Persist 
        // sort order and active cell restored on .Reinstate 

        private int _SortCol1;
        private int _SortCol2;
        private int _SortCol3;
        private SortKeyOrderConstants _SortKeyOrder1;
        private SortKeyOrderConstants _SortKeyOrder2;
        private SortKeyOrderConstants _SortKeyOrder3;
        private SortByConstants _SortBy;

        private ScrollBarPolicy _SavedHScrollBarPolicy;
        private ScrollBarPolicy _SavedVScrollBarPolicy;
        private ItemDataList<int> _RowItemData = new ItemDataList<int>(501);
        private ItemDataList<int> _ColItemData = new ItemDataList<int>(501);

        /// <summary>
        /// Change event handler
        /// </summary>
        public new event ChangeEventHandler Change;
        /// <summary>
        /// CellClick event handler
        /// </summary>
        public new event CellClickEventHandler CellClick;
        /// <summary>
        /// Occurs when the user presses the left mouse button down twice (double-clicks) in a cell
        /// </summary>
        public event CellClickEventHandler CellDoubleClick;
        /// <summary>
        /// Cell Right click event handler
        /// </summary>
        public event CellClickEventHandler CellRightClick;
        /// <summary>
        /// Leave Cell event handler
        /// </summary>
        public new event LeaveCellEventHandler LeaveCell;
        /// <summary>
        /// Leave Row event handler
        /// </summary>
        public event LeaveRowEventHandler LeaveRow;
        /// <summary>
        /// TextTip Fetch Event handler
        /// </summary>
        public new event TextTipFetchEventHandler TextTipFetch;
        /// <summary>
        /// Top Left Change event handler
        /// </summary>
        public event TopLeftChangeEventHandler TopLeftChange;

        private Cursor defaultCursor;
        private Color _shadowColor = Color.Empty;
        private Color _shadowText = Color.Empty;
        private Color _shadowDark = Color.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        public FpSpread()
            : base()
        {
            InitializeSpread();
        }

        /// <summary>
        /// Get/Set a cell note
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CellNote
        {
            get
            {
                if (this.Row != -1 && this.Col != -1)
                {
                    return ActiveSheet.Cells[this.Row, this.Col].Note;
                }
                return String.Empty;
            }
            set
            {
                if (this.Row != -1 && this.Col != -1)
                {
                    ActiveSheet.Cells[this.Row, this.Col].Note = value;
                }

            }
        }

        /// <summary>
        /// Gets the column sort indicator for a given column index.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public FarPoint.Win.Spread.Model.SortIndicator GetColUserSortIndicator(int col)
        {
            if (col > -1 && col < this.ActiveSheet.ColumnCount)
            {
                return this.ActiveSheet.Columns[col].SortIndicator;
            }
            else
            {
                return FarPoint.Win.Spread.Model.SortIndicator.None;
            }
        }

        /// <summary>
        /// Sets the column sort indicator
        /// </summary>
        /// <param name="col"></param>
        /// <param name="sort"></param>
        public void SetColUserSortIndicator(int col, FarPoint.Win.Spread.Model.SortIndicator sort)
        {
            this.ActiveSheet.Columns[col].SortIndicator = sort;
        }

        /// <summary>
        /// Get/Set the control TextTip policy
        /// </summary>
        public TextTipPolicy TextTip
        {
            get
            {
                return this.TextTipPolicy;
            }
            set
            {
                this.TextTipPolicy = value;
            }
        }

        /// <summary>
        /// Get/Set whether the cell note indicator is displayed. If the Cell note is displayed, the ToolTipFetch event will be fired.
        /// </summary>
        public bool CellNoteIndicator
        {
            get
            {
                return this.CellNoteIndicatorVisible;
            }
            set
            {
                this.CellNoteIndicatorVisible = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).ForeColor = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).ForeColor = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).ForeColor = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).ForeColor = value;
                }
            }
            get
            {
                StyleInfo si = GetCompositeInfo(Row, Col);
                if (si != null)
                {
                    return si.ForeColor;
                }
                else
                {
                    return default(Color);
                }
            }
        }
        /// <summary>
        /// Get/Set Back color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).BackColor = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).BackColor = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).BackColor = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).BackColor = value;
                }
            }
            get
            {
                StyleInfo si = GetCompositeInfo(Row, Col);
                if (si != null)
                {
                    return si.BackColor;
                }
                else
                {
                    return default(Color);
                }
            }
        }

        /// <summary>
        /// Get/Set Active Row Index. This property is 1-based
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ActiveRowIndex
        {
            get
            {
                if (this.ActiveSheet == null)
                    return -1;
                else
                    return this.ActiveSheet.ActiveRowIndex + 1;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.ActiveRowIndex = value - 1;
                }
            }
        }

        /// <summary>
        /// Get/Set Active column index. This property is 1-based
        /// </summary>        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ActiveColumnIndex
        {
            get
            {
                if (this.ActiveSheet == null)
                    return -1;
                else
                    return this.ActiveSheet.ActiveColumnIndex + 1;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.ActiveColumnIndex = value - 1;
                }
            }
        }

        /// <summary>
        /// Initialize Sheet View
        /// </summary>
        /// <param name="sheet">SheetView to set</param>
        public void InitializeSheetView(SheetView sheet)
        {
            sheet.Rows.Default.Height = 15;
            sheet.ColumnHeader.Rows.Default.Height = 15;
            sheet.ColumnHeaderVisible = true;
            sheet.RowHeaderVisible = true;
            sheet.GrayAreaBackColor = SystemColors.Control;
            sheet.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.None;

            Appearance app = new Appearance();
            sheet.GetStyleInfo(0, 0).GetAppearance(app);
            app.SelectionForeColor = SystemColors.HighlightText;
            app.SelectionBackColor = SystemColors.Highlight;

            sheet.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            sheet.ColumnHeader.DefaultStyle.HorizontalAlignment = CellHorizontalAlignment.Left;
            sheet.ColumnHeader.DefaultStyle.VerticalAlignment = CellVerticalAlignment.Top;
        }

        /// <summary>
        /// Initialize default parameters for FP Spread
        /// </summary>
        private void InitializeSpread()
        {
            // Newer style grids run common events for resizing, sorting, exporting, 
            // etc. Older style grids set this to false and have their own custom events 
            _RunLocalEvents = true;

            //Initialise properties for remebering sort order, last active cell 
            _SortCol1 = 0;
            _SortCol2 = 0;
            _SortCol3 = 0;

            //Me.MaxRows = 0 
            Row = -1;
            Col = -1;
            ReDraw = true;
            FocusRenderer = new SolidFocusIndicatorRenderer();
            // These features on spread don't seem to work 
            // so use the Windows default for now 
            CausesValidation = true;
            //.TabStop = False 
            //.ProcessTab = True 
            TextTipDelay = 250;

            BorderStyle = BorderStyle.None;
            CellBorderColor = Color.Black;

            EditModeReplace = true;

            //.NoBeep = True 
            HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
            ScrollBarTrackPolicy = ScrollBarTrackPolicy.Both;

            //.BackColorStyle = BackColorStyleConstants.BackColorStyleUnderGrid 
            //.SortBy = FPSpreadADO.SortByConstants.SortByRow 
            ClipboardOptions = ClipboardOptions.AllHeaders;
            // copy row and column headers, do not paste them 

            //CursorType = CursorTypeConstants.CursorTypeDefault;
            //SetCursor(FarPoint.Win.Spread.CursorType.LockedCell, Cursors.Default);
            //SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Default);

            TipAppearance TipAppearance1 = new TipAppearance();
            TipAppearance1.BackColor = SystemColors.Info;
            //TipAppearance1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point,
            TipAppearance1.Font = new Font("MS Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point,
                                           (byte)0);
            TipAppearance1.ForeColor = SystemColors.InfoText;
            this.TextTipAppearance = TipAppearance1;


            _Comparer = new CellComparer();
            _SortInfo = new SortInfo[]
                            {
                                new SortInfo(-1, false, _Comparer), new SortInfo(-1, false, _Comparer),
                                new SortInfo(-1, false, _Comparer)
                            };

            Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;

            defaultCursor = this.GetCursor(FarPoint.Win.Spread.CursorType.Normal);

            base.Change += new FarPoint.Win.Spread.ChangeEventHandler(FpSpread_Change);
            base.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(FpSpread_CellClick);
            base.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(FpSpread_CellDoubleClick);
            base.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(FpSpread_LeaveCell);
            base.TextTipFetch += new FarPoint.Win.Spread.TextTipFetchEventHandler(FpSpread_TextTipFetch);
            base.LeftChange += new LeftChangeEventHandler(FpSpread_LeftChange);
            base.TopChange += new TopChangeEventHandler(FpSpread_TopChange);

            TypeCheckPicture = new CheckBoxPicture(this);
            UnitType = FpUnitType.VGABase;
            this.Sheets.Changed += Sheets_Changed;

            ProcessTab = false;
        }

        private void Sheets_Changed(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                if (e.Element is SheetView)
                {
                    (e.Element as SheetView).SelectionStyle = SelectionStyles.SelectionColors;
                    _shadowColor = (e.Element as SheetView).DefaultStyle.BackColor;
                    _shadowText = (e.Element as SheetView).DefaultStyle.ForeColor;
                    _shadowDark = (e.Element as SheetView).ColumnHeader.HorizontalGridLine.Color;

                    GeneralCellType colHeaderCellType = new GeneralCellType();
                    colHeaderCellType.WordWrap = false;
                    colHeaderCellType.StringTrim = StringTrimming.Character;
                    (e.Element as SheetView).ColumnHeader.DefaultStyle.CellType = colHeaderCellType;

                    if (RowHeaderDisplay != this.ActiveSheet.RowHeaderAutoText)
                    {
                        this.ActiveSheet.RowHeaderAutoText = RowHeaderDisplay;
                    }
                    if (ColHeaderDisplay != this.ActiveSheet.ColumnHeaderAutoText)
                    {
                        this.ActiveSheet.ColumnHeaderAutoText = ColHeaderDisplay;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the shortcut key or navigation key assigned to a specified action. 
        /// </summary>
        /// <param name="action">0 = Clears the active cell. 1 = displays the current date and time. 2 = displays the cell editor</param>
        /// <param name="shift"></param>
        /// <param name="ctrl"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool SetActionKey(short action, bool shift, bool ctrl, Keys Key)
        {
            InputMap im = base.GetInputMap(InputMapMode.WhenFocused);
            Keys modifiers = Keys.None;
            if (shift)
            {
                modifiers = Keys.Shift;
            }
            if (ctrl)
            {
                modifiers = modifiers | Keys.Control;
            }

            switch (action)
            {
                case 0:
                    im.Put(new FarPoint.Win.Spread.Keystroke(Key, modifiers), FarPoint.Win.Spread.SpreadActions.ClearCell);
                    break;
                case 1:
                    im.Put(new FarPoint.Win.Spread.Keystroke(Key, modifiers), FarPoint.Win.Spread.SpreadActions.DateTimeNow);
                    break;
                case 2:
                    im.Put(new FarPoint.Win.Spread.Keystroke(Key, modifiers), FarPoint.Win.Spread.SpreadActions.ShowSubEditor);
                    break;
            }
            return true;
        }


        /// <summary>
        /// Sets or returns whether to display the year as a four-digit value in a date cell.
        /// </summary>
        public bool TypeDateCentury
        {
            get
            {
                bool typeDateCentury = true;
                DateTimeCellType dateTimeCellType = GetCellType<DateTimeCellType>();
                if (dateTimeCellType != null)
                {
                    if (dateTimeCellType.DateTimeFormat == DateTimeFormat.UserDefined &&
                        dateTimeCellType.UserDefinedFormat == System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern.Replace("yyyy", "yy"))
                    {
                        typeDateCentury = false;
                    }
                }
                return typeDateCentury;
            }
            set
            {
                DateTimeCellType dateTimeCellType = GetCellType<DateTimeCellType>();
                if (dateTimeCellType != null)
                {
                    if (!value)
                    {
                        dateTimeCellType.DateTimeFormat = DateTimeFormat.UserDefined;
                        dateTimeCellType.UserDefinedFormat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern.Replace("yyyy", "yy");
                    }
                    else
                    {
                        dateTimeCellType.DateTimeFormat = DateTimeFormat.ShortDate;
                    }
                }
            }
        }

        private object GetSpreadObjectAtRange()
        {
            object spreadObject = null;
            try
            {
                if (ActiveSheet != null)
                {
                    if (Col == -1 && Row == -1)
                    {
                        spreadObject = this.ActiveSheet.DefaultStyle;
                    }
                    else if (Col == -1 && Row == 0)
                    {
                        spreadObject = this.ActiveSheet.ColumnHeader.Rows[Row];
                    }
                    else if (ValidCol(Col) && Row == 0)
                    {
                        spreadObject = this.ActiveSheet.ColumnHeader.Columns[Col - 1];
                    }
                    else if (Col == -1 && ValidRow(Row))
                    {
                        spreadObject = this.ActiveSheet.Rows[Row - 1];
                    }
                    else if (Col == 0 && Row == -1)
                    {
                        spreadObject = this.ActiveSheet.RowHeader.Columns[Col];
                    }
                    else if (Col == 0 && ValidRow(Row))
                    {
                        spreadObject = this.ActiveSheet.RowHeader.Rows[Row - 1];
                    }
                    else if (Row == -1 && ValidCol(Col))
                    {
                        spreadObject = this.ActiveSheet.Columns[Col - 1];
                    }
                    else if (ValidRowAndCol(Row, Col))
                    {
                        if (BlockMode && ValidRowAndCol(Row2, Col2))
                        {
                            spreadObject = this.ActiveSheet.Cells[Row - 1, Col - 1, Row2 - 1, Col2 - 1];
                        }
                        else
                        {
                            spreadObject = this.ActiveSheet.Cells[Row - 1, Col - 1];
                        }
                    }
                    else if (Col == 0 && Row == 0)
                    {
                        if (BlockMode && !(Row2 == 0 && Col2 == 0))
                        {
                            if (Row2 == 0 && ValidCol(Col2))
                            {
                                spreadObject = this.ActiveSheet.ColumnHeader.Cells[Row, Col, Row2, Col2 - 1];
                            }
                            else if (ValidRow(Row2) && Col2 == 0)
                            {
                                spreadObject = this.ActiveSheet.RowHeader.Cells[Row, Col, Row2 - 1, Col2];
                            }
                            else if (Row2 == -1 && Col2 == -1)
                            {
                                spreadObject = this.ActiveSheet.SheetCorner.Cells[0, 0];
                            }
                        }
                        else
                        {
                            spreadObject = this.ActiveSheet.SheetCorner.Cells[Row, Col];
                        }
                    }
                }
            }
            catch
            {
            }
            return spreadObject;
        }

        internal StyleInfo GetCompositeInfo(int Row, int Col)
        {
            StyleInfo si = null;
            if (ActiveSheet != null)
            {
                if (Row >= -1 && Col >= -1)
                {
                    if (Row == 0 && Col == -1)
                    {
                        si = this.ActiveSheet.Models.ColumnHeaderStyle.GetCompositeInfo(Row, Col, 0, null);
                    }
                    else if (Row == 0 && ValidCol(Col))
                    {
                        si = this.ActiveSheet.Models.ColumnHeaderStyle.GetCompositeInfo(Row, Col - 1, 0, null);
                    }
                    else if (Row == -1 && Col == 0)
                    {
                        si = this.ActiveSheet.Models.RowHeaderStyle.GetCompositeInfo(Row, Col, 0, null);
                    }
                    else if (Row == -1 && ValidCol(Col))
                    {
                        si = this.ActiveSheet.Models.Style.GetCompositeInfo(Row, Col - 1, 0, null);
                    }
                    else if (ValidRow(Row) && Col == 0)
                    {
                        si = this.ActiveSheet.Models.RowHeaderStyle.GetCompositeInfo(Row - 1, Col, 0, null);
                    }                    
                    else if (Row <= MaxRows && Col <= MaxCols)
                    {
                        if (BlockMode && !(Row2 == 0 && Col2 == 0))
                        {
                            if (Row2 == 0 && ValidCol(Col2))
                            {
                                si = this.ActiveSheet.Models.ColumnHeaderStyle.GetCompositeInfo(Row, -1, 0, null);
                            }
                            else if (ValidRow(Row2) && Col2 == 0)
                            {
                                si = this.ActiveSheet.Models.RowHeaderStyle.GetCompositeInfo(Row, -1, 0, null);
                            }
                            else if (Row2 == -1 && Col2 == -1)
                            {
                                si = this.ActiveSheet.Models.SheetCornerStyle.GetCompositeInfo(0, 0, 0, null);
                            }
                        }
                        else
                        {
                            if (Row == 0 && Col == 0)
                            {
                                si = this.ActiveSheet.Models.SheetCornerStyle.GetCompositeInfo(0, 0, 0, null);
                            }
                            else
                            {
                                if (Row > 0)
                                {
                                    Row = Row - 1;
                                }
                                if (Col > 0)
                                {
                                    Col = Col - 1;
                                }
                                si = this.ActiveSheet.Models.Style.GetCompositeInfo(Row, Col, 0, null);
                            }
                        }
                    }
                }
            }

            return si;
        }

        /// <summary>
        /// Cell Border Style value
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CellBorderStyleConstants CellBorderStyle
        {
            get;
            set;
        }

        private int _cellBorderType = 0;
        /// <summary>
        /// Cell Border Type. VB6 style.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CellBorderType
        {
            get
            {
                return _cellBorderType;
            }
            set
            {
                _cellBorderType = value;
            }
        }

        /// <summary>
        /// Gets/sets a specific row or specifies the first row of a block of cells on which an operation is to occur
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Row
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/sets a specific colum or specifies the first row of a block of cells on which an operation is to occur
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Col
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/sets the last row of a block of cells on which an operation is to occur
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Row2
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/sets the last column of a block of cells on which an operation is to occur
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Col2
        {
            get;
            set;
        }

        /// <summary>
        /// Column index of the top left cell in the destination block for a swap action
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DestCol
        {
            get;
            set;
        }

        /// <summary>
        /// Row index of the top left cell in the destination block for a swap action
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DestRow
        {
            get;
            set;
        }

        /// <summary>
        /// Validates if a Row,Col pair is within the bounds of the Grid 
        /// </summary>
        /// <param name="Row">Row to validate</param>
        /// <param name="Col">Column to validate</param>
        /// <returns></returns>
        private bool ValidRowAndCol(int Row, int Col)
        {
            return ValidRow(Row) && ValidCol(Col);
        }

        private bool ValidRow(int Row)
        {
            return Row > 0 && Row <= MaxRows;
        }

        int _visibleCols = 0;
        /// <summary>
        /// Visible Columns
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VisibleCols
        {
            get
            {
                return _visibleCols;
            }
            set
            {
                if (AutoSize && !this.DesignMode)
                {
                    _visibleCols = value;
                    int cols = _visibleCols;
                    if (this.MaxCols < (_visibleCols + 1))
                    {
                        cols = this.MaxCols;
                    }
                    else
                    {
                        cols++;
                    }
                    float width = 0;
                    for (int i = 0; i < cols; i++)
                    {
                        width += this.ActiveSheet.Columns[i].Width;
                    }
                    this.Width = (int)width;
                }
            }
        }

        private int _visibleRows = 0;
        /// <summary>
        /// Visible Rows
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VisibleRows
        {
            get
            {
                return _visibleRows;
            }
            set
            {
                if (AutoSize && !this.DesignMode)
                {
                    _visibleRows = value;
                    int rows = _visibleRows;
                    if (this.MaxRows < (_visibleRows + 2))
                    {
                        rows = this.MaxRows;
                    }
                    else
                    {
                        rows += 2;
                    }
                    double height = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        height += this.GetRowHeight(i);
                    }
                    this.Height = (int)height;
                }
            }
        }
        /// <summary>
        /// Left Column displayed
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LeftCol
        {
            get
            {
                return this.GetViewportLeftColumn(this.GetActiveColumnViewportIndex()) + 1;
            }
            set
            {
                this.SetViewportLeftColumn(this.GetActiveColumnViewportIndex(), value - 1);
            }
        }

        private bool ValidCol(int Col)
        {
            return Col > 0 && Col <= MaxCols;
        }

        /// <summary>
        /// Get/Set Max of Columns
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MaxCols
        {
            get { return ((this.ActiveSheet != null) ? this.ActiveSheet.ColumnCount : 0); }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.ColumnCount = value;
                    AdjustScrollBars();
                }
            }
        }

        /// <summary>
        /// Get/Set Max of Rows
        /// </summary>
        [DefaultValue(500)]
        public int MaxRows
        {
            get
            {
                return ((this.ActiveSheet != null) ? this.ActiveSheet.RowCount : 0);
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    CellRange[] cellRangeList = new CellRange[0];
                    if (value < MaxRows && value > 0)
                    {
                        cellRangeList = ActiveSheet.GetSelections();
                    }
                    this.ActiveSheet.RowCount = value;
                    AdjustScrollBars();
                    //
                    if (cellRangeList.Length > 0)
                    {
                        SaveSelectionRows(cellRangeList, value);
                    }
                }
            }
        }

        private void SaveSelectionRows(CellRange[] cellRangeList, int rowDelete)
        {
            if (cellRangeList.Length > 0 && ActiveSheet.RowCount > 0)
            {
                switch (ActiveSheet.OperationMode)
                {
                    case OperationMode.RowMode:
                    case OperationMode.SingleSelect:
                        if (cellRangeList[0].Row >= ActiveSheet.RowCount)
                        {
                            ActiveSheet.AddSelection(ActiveSheet.RowCount - 1, cellRangeList[0].Column, 1, cellRangeList[0].ColumnCount);
                        }
                        break;
                    case OperationMode.Normal:
                    case OperationMode.ReadOnly:
                    case OperationMode.ExtendedSelect:
                        foreach (CellRange cellRange in cellRangeList)
                        {
                            if ((cellRange.Row <= rowDelete - 1) && ((cellRange.Row + cellRange.RowCount) > rowDelete - 1) && cellRange.RowCount > 1)
                            {
                                ActiveSheet.AddSelection(cellRange.Row, cellRange.Column, Math.Min((cellRange.RowCount - 1), (ActiveSheet.RowCount - cellRange.Row)), cellRange.ColumnCount);
                            }
                            //if ((cellRange.Row <= value - 1) && ((cellRange.Row + cellRange.RowCount) > value - 1) && cellRange.RowCount > 1)
                            //{
                            //    ActiveSheet.AddSelection(cellRange.Row, cellRange.Column, value - cellRange.Row, cellRange.ColumnCount);
                            //}
                        }
                        break;
                    default:
                        //case OperationMode.MultiSelect:
                        ;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets Row Height
        /// </summary>
        /// <param name="Row">row to look at</param>
        /// <returns></returns>
        public double GetRowHeight(int Row)
        {
            //if (ActiveSheet != null)
            {
                if (Row == 0)
                {
                    return this.ActiveSheet.ColumnHeader.Rows[Row].Height;
                }
                else if ((Row == -1))
                {
                    return this.ActiveSheet.Rows.Default.Height;
                }
                else if (Row > 0)
                {
                    return this.ActiveSheet.Rows[Row - 1].Height;
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets Cell Height
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <param name="Col">Column to look at</param>
        /// <returns></returns>
        public float GetCellHeight(int Row, int Col)
        {
            string s = this.Value.ToString();

            Font defaultFont = null;
            defaultFont = this.ActiveSheet.Cells[Row, Col].Font;
            if (defaultFont == null)
                defaultFont = this.ActiveSheet.Rows[Row].Font;

            if (defaultFont == null)
                defaultFont = this.Font;
            if (graficsObject != null)
                graficsObject = CreateGraphics();

            SizeF sf = graficsObject.MeasureString(s, defaultFont);
            return sf.Height;
        }

        /// <summary>
        /// This method is the equivalent to. Backcolor of farpoint 3.0
        /// </summary>
        /// <param name="setColor"></param>
        public void SetBackColor(Color setColor)
        {
            int endCol = (this.Col2 == -1) ? this.MaxCols : this.Col2;
            int endRow = (this.Row2 == -1) ? this.MaxRows : this.Row2;
            int startRow = this.Row;
            int startCol = this.Col;

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    this.Col = col;
                    this.Row = row;
                    this.BackColor = setColor;
                }
            }
        }

        /// <summary>
        /// Returns the Preferred RowHeight
        /// This method might behave diferently than the VB6 version of it.
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <returns></returns>
        public float MaxTextRowHeight(int Row)
        {
            if (Row == 0 || Row == -1)
            {
                return this.ActiveSheet.GetPreferredRowHeight(Row);
            }
            else
            {
                return this.ActiveSheet.GetPreferredRowHeight(Row - 1, true);
            }
        }
        /// <summary>
        /// Sets the Height for a row using the value
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <param name="Value">Value to set</param>
        public void SetRowHeight(int Row, float Value)
        {

            if (Row == 0)
            {
                this.ActiveSheet.ColumnHeader.Rows[Row].Height = Value * 1.05F;
            }
            else if ((Row == -1))
            {
                this.ActiveSheet.Rows.Default.Height = Value * 1.05F;
            }
            else if (Row > 0)
            {
                this.ActiveSheet.Rows[Row - 1].Height = Value * 1.05F;
            }
        }

        /// <summary>
        /// Sets or returns the units used for the column width and row height. 
        /// </summary>
        public FpUnitType UnitType
        {
            get;
            set;
        }

        private HeaderAutoText _rowHeaderDisplay = HeaderAutoText.Numbers;
        public HeaderAutoText RowHeaderDisplay
        {
            get { return _rowHeaderDisplay; }
            set
            {
                _rowHeaderDisplay = value;
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.RowHeaderAutoText = value;
                }
            }
        }

        private HeaderAutoText _colHeaderDisplay = HeaderAutoText.Letters;
        public HeaderAutoText ColHeaderDisplay
        {
            get { return _colHeaderDisplay; }
            set
            {
                _colHeaderDisplay = value;
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.ColumnHeaderAutoText = value;
                }
            }
        }

        /// <summary>
        /// Gets Column Width
        /// </summary>
        /// <param name="Col">Column to look at</param>
        /// <returns></returns>
        public float GetColWidth(int Col)
        {
            float Width = 0;
            if (Col == 0)
            {
                Width = this.ActiveSheet.RowHeader.Columns[Col].Width;
            }
            else if (ValidCol(Col))
            {
                Width = this.ActiveSheet.GetColumnWidth(Col - 1);
            }
            return ColWidthFromPixels(Width);
        }

        /// <summary>
        /// Sets Column Width
        /// </summary>
        /// <param name="Col">Column to look at</param>
        /// <param name="Value">Value to set</param>
        public void SetColWidth(int Col, float Value)
        {
            if (Col == 0)
            {
                this.ActiveSheet.RowHeader.Columns[Col].Width = ColWidthToPixels(Value);
            }
            else if (ValidCol(Col))
            {
                this.ActiveSheet.SetColumnWidth(Col - 1, Convert.ToInt32(ColWidthToPixels(Value)));
            }
        }

        /// <summary>
        /// Gets hidden condition for a specific row
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <returns></returns>
        public bool GetRowHidden(int Row)
        {
            if (ActiveSheet != null)
            {
                if (Row == 0)
                {
                    return !this.ActiveSheet.ColumnHeader.Visible;
                }
                else if (Row > 0)
                {
                    return !this.ActiveSheet.Rows[Row - 1].Visible;
                }
            }
            return false;
        }

        /// <summary>
        /// Sets hidden state for a specific row
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <param name="Value">Value to set</param>
        public void SetRowHidden(int Row, bool Value)
        {
            if (Row == 0)
            {
                this.ActiveSheet.ColumnHeader.Visible = !Value;
            }
            else if (Row > 0)
            {
                this.ActiveSheet.Rows[Row - 1].Visible = !Value;
            }

        }

        /// <summary>
        /// Get/Set Row Hidden state, using the actual Row value
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RowHidden
        {
            get { return GetRowHidden(Row); }
            set { SetRowHidden(Row, value); }
        }

        /// <summary>
        /// Gets Column Hidden state for a specific Column
        /// </summary>
        /// <param name="Col">Column to look at</param>
        /// <returns>True if column specified has visible false state</returns>
        public bool GetColHidden(int Col)
        {
            if (Col == 0)
            {
                return !this.ActiveSheet.RowHeader.Visible;
            }
            else if (ValidCol(Col))
            {
                return !this.ActiveSheet.Columns[Col - 1].Visible;
            }
            return false;
        }

        /// <summary>
        /// Sets Column Hidden state for specified column
        /// </summary>
        /// <param name="Col">Column to look at</param>
        /// <param name="Value">Value to set</param>
        public void SetColHidden(int Col, bool Value)
        {
            if (Col == 0)
            {
                this.ActiveSheet.RowHeader.Visible = !Value;
            }
            else if (ValidCol(Col))
            {
                this.ActiveSheet.Columns[Col - 1].Visible = !Value;
            }
        }

        /// <summary>
        /// Get/Set Column Hidden state
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ColHidden
        {
            get { return GetColHidden(Col); }
            set { SetColHidden(Col, value); }
        }

        /// <summary>
        /// full width of the grid object (in pixels) based on displayed column widths 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float GridWidth
        {
            get
            {
                float result = 0;

                int w;

                for (int Col = 0; Col <= this.ActiveSheet.ColumnCount; Col++)
                {
                    if (!GetColHidden(Col))
                    {
                        result += ColWidthToPixels(GetColWidth(Col)) + 1;
                    }
                }

                //The Spread COM GetClientArea method returned the area of the control excluding the scroll bars; 
                //the ClientRectangle method in .NET returns the area of the component including the scroll bars 
                w = this.ClientRectangle.Width;

                if (this.Width > w)
                {
                    result += this.Width - w;
                    // adjust for vertical scrollbar width 
                }
                return result;
            }
        }

        /// <summary>
        /// Gets Last non empty Row using the NonEmptyItemFlag
        /// </summary>
        /// <param name="dataFlag">NonEmptyItemFlag to use</param>
        /// <returns></returns>
        public int GetLastNonEmptyRow(NonEmptyItemFlag dataFlag)
        {
            return this.ActiveSheet.GetLastNonEmptyRow(dataFlag) + 1;
        }

        /// <summary>
        /// Gets Last non Empty Column using the NonEmptyItemFlag
        /// </summary>
        /// <param name="dataFlag">NonEmptyItemFlag to use</param>
        /// <returns></returns>
        public int GetLastNonEmptyColumn(NonEmptyItemFlag dataFlag)
        {
            return this.ActiveSheet.GetLastNonEmptyColumn(dataFlag) + 1;
        }

        /// <summary>
        /// Converts a pixel width to Column Width
        /// </summary>
        /// <param name="Width">value to convert</param>
        /// <returns></returns>
        public float ColWidthFromPixels(float Width)
        {
            if (UnitType == FpUnitType.Twips)
            {
                return Width * 15;
            }
            else
            {
                return Width / GetFixedFont().SizeInPoints;
            }
        }

        /// <summary>
        /// Convert Width Column to Pixels
        /// </summary>
        /// <param name="Width">value to convert</param>
        /// <returns></returns>
        public float ColWidthToPixels(float Width)
        {
            if (UnitType == FpUnitType.Twips)
            {
                return Width / 15;
            }
            else //UnitType == FpUnitType.VGABase || UnitType == FpUnitType.Normal
            {
                return GetFixedFont().SizeInPoints * Width;
            }
        }

        private static Font fixedFont = new Font("Courier", 8.25f);

        private Font GetFixedFont()
        {
            return fixedFont;
        }

        private void AdjustScrollBars()
        {
            //This method is a workaround for a bug in the Spread component. When ScrollBarPolicy = AsNeeded and 
            //the spread's height is less than 4 rows the vertical and horizontal scrollbars dissapear. This was 
            //confirmed by FarPoint as a bug and in theory will be fixed in a future release (later than 3.0.2005.2005) 
            if (!(HorizontalScrollBarPolicy == ScrollBarPolicy.Never))
            {
                int Col = this.Col;
                int Row = this.Row;
                float height = this.ActiveSheet.ColumnHeader.Rows[0].Height + this.ActiveSheet.Rows.Default.Height * 4;
                if (HorizontalScrollBarPolicy == ScrollBarPolicy.AsNeeded & base.ClientRectangle.Width < GridWidth &
                    base.ClientRectangle.Height < height)
                {
                    HorizontalScrollBarPolicy = ScrollBarPolicy.Always;
                    _SavedHScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                }
                else if (base.ClientRectangle.Width >= GridWidth & _SavedHScrollBarPolicy == ScrollBarPolicy.AsNeeded &
                         HorizontalScrollBarPolicy == ScrollBarPolicy.Always)
                {
                    HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                }

                float height2 = this.ActiveSheet.ColumnHeader.Rows[0].Height +
                                this.ActiveSheet.Rows.Default.Height * MaxRows;
                if (VerticalScrollBarPolicy == ScrollBarPolicy.AsNeeded & base.ClientRectangle.Height < height &
                    base.ClientRectangle.Height < height2)
                {
                    VerticalScrollBarPolicy = ScrollBarPolicy.Always;
                    _SavedVScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                }
                else if (base.ClientRectangle.Height >= height2 & _SavedVScrollBarPolicy == ScrollBarPolicy.AsNeeded &
                         VerticalScrollBarPolicy == ScrollBarPolicy.Always)
                {
                    VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                }
                this.Col = Col;
                this.Row = Row;
            }
        }

        /// <summary>
        /// Sets Active Cell
        /// </summary>
        /// <param name="Row">row to look at</param>
        /// <param name="Col">column to look at</param>
        /// <param name="VPosition">vertical position</param>
        /// <param name="HPosition">horizontal position</param>
        private void SetActiveCell(int Col, int Row, VerticalPosition VPosition, HorizontalPosition HPosition)
        {
            this.ShowCell(0, 0, Row, Col, VPosition, HPosition);
        }

        /// <summary>
        /// Sets Active Cell
        /// </summary>
        /// <param name="Row">row to look at</param>
        /// <param name="Col">column to look at</param>
        public void SetActiveCell(int Col, int Row)
        {
            this.ActiveSheet.SetActiveCell(Row - 1, Col - 1);
            this.ShowActiveCell(VerticalPosition.Bottom, HorizontalPosition.Right);
        }

        /// <summary>
        /// Clear Range
        /// </summary>
        /// <param name="Row">row to look at</param>
        /// <param name="Col">column to look at</param>
        public void ClearRange(int Row, int Col)
        {
            if ((Row > 0 & Col == -1))
            {
                this.ActiveSheet.ClearRange(Row - 1, 0, 1, this.MaxCols, true);
            }
            else if (Row == -1 & Col > 0)
            {
                this.ActiveSheet.ClearRange(0, Col - 1, this.MaxRows, 1, true);
            }
        }

        /// <summary>
        /// Clear Range
        /// </summary>
        /// <param name="Row1">Left Row to look at</param>
        /// <param name="Col1">Top column to look at</param>
        /// <param name="Row2">Right Row to look at</param>
        /// <param name="Col2">Bottom column to look at</param>
        /// <param name="DataOnly">if only data</param>
        public void ClearRange(int Row1, int Col1, int Row2, int Col2, bool DataOnly)
        {
            this.ActiveSheet.ClearRange(Row1 - 1, Col1 - 1, Row2 - Row1 + 1, Col2 - Col1 + 1, DataOnly);
        }

        /// <summary>
        /// Clears selection
        /// </summary>
        public void ClearSelection()
        {
            this.ActiveSheet.ClearSelection();
        }

        /// <summary>
        /// Clip
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Clip
        {
            get
            {
                string result = "";
                if (this.Sheets != null && this.Sheets.Count > 0)
                {
                    int rowsCount = this.Sheets[0].NonEmptyRowCount;
                    int colsCount = this.Sheets[0].NonEmptyColumnCount;
                    for (int i = 0; i < rowsCount; i++)
                    {
                        result += ControlChars.Tab;
                        for (int j = 0; j < colsCount; j++)
                        {
                            result += this.Sheets[0].Cells[i, j].Text + ControlChars.Tab;
                        }
                        result += ControlChars.VerticalTab;
                    }
                }
                return result;
            }
            set
            {
                string[] rows = value.Split(new char[] { '\r', '\n' });
                int row = 0;
                if (this.Sheets.Count > 0)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        string currentRow = rows[i];
                        if (currentRow.Length > 0)
                        {
                            string[] cols = currentRow.Split(ControlChars.Tab);
                            for (int j = 0; j < cols.Length; j++)
                            {
                                this.Sheets[0].Cells[row, j].Text = cols[j];
                            }
                            row++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Selects a block of cells if the AllowMultiBlocks property is set to true.
        /// </summary>
        /// <param name="Col"></param>
        /// <param name="Row"></param>
        /// <param name="Col2"></param>
        /// <param name="Row2"></param>
        public void AddSelection(int Col, int Row, int Col2, int Row2)
        {
            if (ActiveSheet.SelectionPolicy == SelectionPolicy.MultiRange)
            {
                SetSelection(Col, Row, Col2, Row2, false);
            }
            else
            {
                SetSelection(Col, Row, Col2, Row2, true);
            }
        }

        /// <summary>
        /// Selects a block of cells in the spreadsheet
        /// </summary>
        /// <param name="Col">Top Column</param>
        /// <param name="Row">Left Row</param>
        /// <param name="Col2">Bottom Column</param>
        /// <param name="Row2">Right Row</param>
        public void SetSelection(int Col, int Row, int Col2, int Row2, bool clearSelection = true)
        {
            int adjustedCol = 0, adjustedRow = 0, colCount = 0, rowCount = 0;

            adjustedCol = Col == -1 ? 0 : Col - 1;
            adjustedRow = Row == -1 ? 0 : Row - 1;
            colCount = Col2 - adjustedCol;
            rowCount = Row2 - adjustedRow;
            if (clearSelection)
            {
                ClearSelection();
            }
            this.ActiveSheet.ActiveRowIndex = adjustedRow;
            this.ActiveSheet.ActiveColumnIndex = adjustedCol;
            ActiveSheet.AddSelection(adjustedRow, adjustedCol, rowCount, colCount);
        }

        /// <summary>
        /// Gets Selection
        /// </summary>
        /// <param name="BlockNo">Block number</param>
        /// <param name="Col">returned top column</param>
        /// <param name="Row">returned left row</param>
        /// <param name="Col2">returned bottom column</param>
        /// <param name="Row2">returned right row</param>
        public void GetSelection(int BlockNo, ref int Col, ref int Row, ref int Col2, ref int Row2)
        {
            CellRange selection = ActiveSheet.GetSelection(BlockNo);

            if ((selection != null))
            {
                Col = selection.Column + 1;
                Row = selection.Row + 1;
                Col2 = selection.Column + selection.ColumnCount;
                Row2 = selection.Row + selection.RowCount;
            }
            else
            {
                Col = -1;
                Row = -1;
                Col2 = -1;
                Row2 = -1;
            }
        }

        /// <summary>
        /// Gets Multi Selection items
        /// </summary>
        /// <param name="SelPrev">Selected Previous</param>
        /// <returns></returns>
        public int GetMultiSelItem(int SelPrev)
        {
            int ret = -1;
            List<CellRange> rangeOfSelections = new List<CellRange>();
            rangeOfSelections.AddRange(this.ActiveSheet.GetSelections());
            rangeOfSelections.Sort(delegate(CellRange cellRange1, CellRange cellRange2)
            {
                return cellRange1.Row.CompareTo(cellRange2.Row);
            });

            for (int i = 0; i < rangeOfSelections.Count; ++i)
            {
                if (SelPrev == 0)
                {
                    ret = rangeOfSelections[i].Row + 1;
                    break;
                }

                if ((rangeOfSelections[i].Row + rangeOfSelections[i].RowCount + 1) > SelPrev)
                {
                    if ((rangeOfSelections[i].Row + rangeOfSelections[i].RowCount) == SelPrev)
                    {
                        if (rangeOfSelections.Count > i + 1)
                        {
                            ret = rangeOfSelections[i + 1].Row + 1;
                        }
                        break;
                    }
                    ret = SelPrev + 1;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Deletes the row or rows on this sheet at the specified index.
        /// </summary>
        /// <param name="row">Index of first row to be removed</param>
        /// <param name="count">Number of rows to be removed</param>
        public void DeleteRows(int row, int count)
        {
            if (ValidRow(row) && ValidRow(row - 1 + count))
            {
                CellRange[] cellRangeList = this.ActiveSheet.GetSelections();
                ActiveSheet.RemoveRows(row - 1, count);
                this.Row = Math.Min(MaxRows, row);
                SaveSelectionRows(cellRangeList, row);
            }
        }

        /// <summary>
        /// Insert a row or rows after indicated Row
        /// </summary>
        /// <param name="Row">Row number</param>
        /// <returns></returns>
        public void InsertRows(int row, int count)
        {
            if (row >= 1 && row <= MaxRows)
            {
                this.ActiveSheet.Rows.Add(row - 1, count);
                MaxRows -= count;
            }
        }

        /// <summary>
        /// Sets Action from Action Constants
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FPActionConstants Action
        {
            set
            {
                switch (value)
                {
                    case FPActionConstants.ActionActiveCell:
                        SetActiveCell(Col, Row);
                        if (ActiveSheet.OperationMode == OperationMode.ExtendedSelect ||
                            ActiveSheet.OperationMode == OperationMode.MultiSelect ||
                            ActiveSheet.OperationMode == OperationMode.SingleSelect ||
                            ActiveSheet.OperationMode == OperationMode.RowMode)
                        {
                            ActiveSheet.AddSelection(Row - 1, 0, 1, MaxCols);
                            ActiveColumnIndex = Col;
                            ActiveRowIndex = Row;
                        }
                        break;
                    case FPActionConstants.ActionGotoCell:
                        SetActiveCell(Col, Row, VerticalPosition.Top, HorizontalPosition.Right);
                        break;
                    case FPActionConstants.ActionSelectBlock:
                        SetSelection(Col, Row, Col2, Row2);
                        break;
                    case FPActionConstants.ActionClear:
                        ClearRange(Row, Col, Row2, Col2, false);
                        break;
                    case FPActionConstants.ActionClearText:
                        ClearRange(Row, Col);
                        break;
                    case FPActionConstants.ActionClipboardCopy:
                        ActiveSheet.ClipboardCopy();
                        break;
                    case FPActionConstants.ActionClipboardPaste:
                        ActiveSheet.ClipboardPaste();
                        break;
                    case FPActionConstants.ActionDeselectBlock:
                        ActiveSheet.ClearSelection();
                        break;
                    case FPActionConstants.ActionInsertCol:
                        ActiveSheet.Columns[Col - 1].Add();
                        //Need to decrement MaxCols because it gets incremented twice: first by the client before inserting and then here by Columns.Add() 
                        MaxCols -= 1;
                        break;
                    case FPActionConstants.ActionInsertRow:
                        //Inserts before the indicated row 
                        ActiveSheet.Rows[Row - 1].Add();
                        //Need to decrement MaxRows because it gets incremented twice: first by the client before inserting and then here by Rows.Add() 
                        MaxRows -= 1;
                        break;
                    case FPActionConstants.ActionDeleteCol:
                        ActiveSheet.Columns[Col - 1].Remove();
                        //Need to increment MaxCols because it gets incremented twice: first by the client before deleting and then here by Columns.Add() 
                        MaxCols += 1;
                        break;
                    case FPActionConstants.ActionDeleteRow:
                        DeleteRows(Row, 1);
                        //Need to increment MaxRows because it gets decremented twice: first here by DeleteRow and then by the client after the call to Action 
                        MaxRows += 1;
                        break;
                    case FPActionConstants.ActionSmartPrint:
                        PrintSheet(ActiveSheet);
                        break;
                    case FPActionConstants.ActionSort:
                        bool sort = SortBy == SortByConstants.SortByRow ? true : false;
                        ActiveSheet.SortRange(Row - 1, Col - 1, MaxRows, MaxCols, sort, _SortInfo);
                        break;
                    case FPActionConstants.ActionSetCellBorder:
                        SetCellBorder();
                        break;
                    case FPActionConstants.ActionSelModeClear:
                        break;
                    case FPActionConstants.ActionSwapRange:
                        if (ValidCol(Col) && ValidCol(Col2) && ValidCol(DestCol) && ValidRow(Row) && ValidRow(Row2) && ValidRow(DestRow))
                        {
                            IRangeSupport irs = (IRangeSupport)this.ActiveSheet.Models.Data;
                            this.ActiveSheet.SwapRange(Row - 1, Col - 1, DestRow - 1, DestCol - 1, Row2 - Row + 1, Col2 - Col + 1, true);
                        }
                        break;
                    default:
                        throw new ArgumentException(String.Format("Action {0} is not implemented", value.ToString()));
                }
            }
        }

        /// <summary>
        /// Gets Cell Type for specified row and column
        /// </summary>
        /// <param name="Row">row to look at</param>
        /// <param name="Col">column to look at</param>
        /// <returns>ICellType</returns>
        public ICellType GetCellType(int Row, int Col)
        {
            StyleInfo si = GetCompositeInfo(Row, Col);
            if (si != null)
            {
                return si.CellType;
            }
            return null;
        }

        /// <summary>
        /// Cell Border Color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color CellBorderColor
        {
            get;
            set;
        }

        private void SetCellBorder()
        {
            FarPoint.Win.ComplexBorderSideStyle borderStyle = FarPoint.Win.ComplexBorderSideStyle.None;
            switch (CellBorderStyle)
            {
                case CellBorderStyleConstants.CellBorderStyleBlank: borderStyle = FarPoint.Win.ComplexBorderSideStyle.None; break;
                case CellBorderStyleConstants.CellBorderStyleDash: borderStyle = FarPoint.Win.ComplexBorderSideStyle.Dashed; break;
                case CellBorderStyleConstants.CellBorderStyleDashDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.DashDot; break;
                case CellBorderStyleConstants.CellBorderStyleDashDotDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.DashDotDot; break;
                case CellBorderStyleConstants.CellBorderStyleDefault: borderStyle = FarPoint.Win.ComplexBorderSideStyle.ThinLine; break;
                case CellBorderStyleConstants.CellBorderStyleDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.Dotted; break;
                case CellBorderStyleConstants.CellBorderStyleFineDash: borderStyle = FarPoint.Win.ComplexBorderSideStyle.MediumDashed; break;
                case CellBorderStyleConstants.CellBorderStyleFineDashDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.MediumDashDot; break;
                case CellBorderStyleConstants.CellBorderStyleFineDashDotDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.MediumDashDotDot; break;
                case CellBorderStyleConstants.CellBorderStyleFineDot: borderStyle = FarPoint.Win.ComplexBorderSideStyle.SlantedDashDot; break;
                case CellBorderStyleConstants.CellBorderStyleFineSolid: borderStyle = FarPoint.Win.ComplexBorderSideStyle.HairLine; break;
                case CellBorderStyleConstants.CellBorderStyleSolid: borderStyle = FarPoint.Win.ComplexBorderSideStyle.MediumLine; break;
            }

            FarPoint.Win.ComplexBorderSide borderSide = new FarPoint.Win.ComplexBorderSide(borderStyle, CellBorderColor);
            FarPoint.Win.ComplexBorderSide left = null;
            FarPoint.Win.ComplexBorderSide top = null;
            FarPoint.Win.ComplexBorderSide right = null;
            FarPoint.Win.ComplexBorderSide bottom = null;

            if ((CellBorderType & 1) == 1)
                left = borderSide;
            if ((CellBorderType & 2) == 2)
                right = borderSide;
            if ((CellBorderType & 4) == 4)
                top = borderSide;
            if ((CellBorderType & 8) == 8)
                bottom = borderSide;
            if (CellBorderType == 16)
            {
                left = borderSide;
                right = borderSide;
                top = borderSide;
                bottom = borderSide;
            }

            FarPoint.Win.ComplexBorder border = new FarPoint.Win.ComplexBorder(left, top, right, bottom);

            if (this.Row == -1 && this.Col == -1)
            {
                ActiveSheet.SetInsideBorder(new CellRange(0, 0, MaxRows, MaxCols), border);
            }
            else if (this.Row == -1)
            {
                ActiveSheet.SetOutlineBorder(new CellRange(this.Row, 0, 1, MaxCols), border);
            }
            else if (this.Col == -1)
            {
                ActiveSheet.SetOutlineBorder(new CellRange(0, this.Col, MaxRows, 1), border);
            }
            else
            {
                ActiveSheet.SetOutlineBorder(new CellRange(this.Row - 1, this.Col - 1, 1, 1), border);
            }
        }

        /// <summary>
        /// Get/Set CellType for actual Row and Column
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FpCellType CellType
        {
            get
            {
                FpCellType cellType = default(FpCellType);
                StyleInfo si = GetCompositeInfo(Row, Col);
                if (si != null)
                {
                    cellType = MapCellTypeToEnum(si.CellType);
                }
                return cellType;
            }
            set
            {
                ICellType cellType = MapEnumToCellType(value);
                SetCellType(cellType);
            }
        }

        private void SetCellType(ICellType cellType)
        {
            object gridElement = GetSpreadObjectAtRange();
            if (gridElement is Column)
            {
                (gridElement as Column).CellType = cellType;
            }
            else if (gridElement is Row)
            {
                (gridElement as Row).CellType = cellType;
            }
            else if (gridElement is StyleInfo)
            {
                (gridElement as StyleInfo).CellType = cellType;
            }
            else if (gridElement is Cell)
            {
                (gridElement as Cell).CellType = cellType;
            }
        }

        /*
            0 - Date Creates date cell SS_CELL_TYPE_DATE  
            1 - Edit (Default) Creates edit cell SS_CELL_TYPE_EDIT  
            2 - Float Creates float cell SS_CELL_TYPE_FLOAT  
            3 - Integer Creates integer cell SS_CELL_TYPE_INTEGER  
            4 - PIC Creates PIC cell SS_CELL_TYPE_PIC  
            5 - Static Text Creates static text cell SS_CELL_TYPE_STATIC_TEXT  
            6 - Time Creates time cell SS_CELL_TYPE_TIME  
            7 - Button Creates button cell SS_CELL_TYPE_BUTTON  
            8 - Combo Box Creates combo box cell SS_CELL_TYPE_COMBOBOX  
            9 - Picture Creates picture cell SS_CELL_TYPE_PICTURE  
            10 - Check Box Creates check box cell SS_CELL_TYPE_CHECKBOX  
            11 - Owner-Drawn Creates owner-drawn cell SS_CELL_TYPE_OWNER_DRAWN  
        */
        private FpCellType MapCellTypeToEnum(ICellType cellType)
        {
            FpCellType cellTypeEnum = default(FpCellType);

            if (cellType is DateTimeCellType)
            {
                if ((cellType as DateTimeCellType).DateTimeFormat == DateTimeFormat.UserDefined && (cellType as DateTimeCellType).UserDefinedFormat == "hh:mm")
                {
                    cellTypeEnum = FpCellType.CellTypeTime;
                }
                else
                {
                    cellTypeEnum = FpCellType.CellTypeDate;
                }
            }
            else if (cellType is TextCellType)
            {
                if ((cellType as TextCellType).ReadOnly)
                {
                    cellTypeEnum = FpCellType.CellTypeStaticText;
                }
                else
                {
                    cellTypeEnum = FpCellType.CellTypeEdit;
                }
            }
            else if (cellType is NumberCellType)
            {
                if ((cellType as NumberCellType).DecimalPlaces == 0)
                {
                    cellTypeEnum = FpCellType.CellTypeInteger;
                }
                else
                {
                    cellTypeEnum = FpCellType.CellTypeFloat;
                }
            }
            else if (cellType is ImageCellType)
            {
                //todo: afallas How to diferentiate between CellTypePic and CellTypePicture
                cellTypeEnum = FpCellType.CellTypePicture; //or CellTypePic or CellTypeOwnerDrawn
            }
            else if (cellType is ButtonCellType)
            {
                cellTypeEnum = FpCellType.CellTypeButton;
            }
            else if (cellType is ComboBoxCellType)
            {
                cellTypeEnum = FpCellType.CellTypeComboBox;
            }
            else if (cellType is CheckBoxCellType)
            {
                cellTypeEnum = FpCellType.CellTypeCheckBox;
            }

            return cellTypeEnum;
        }

        private ICellType MapEnumToCellType(FpCellType cellType)
        {
            ICellType newCellType = null;
            switch (cellType)
            {
                case FpCellType.CellTypeDate:
                    newCellType = new DateTimeCellType();
                    break;
                case FpCellType.CellTypeEdit:
                    newCellType = new TextCellType();
                    break;
                case FpCellType.CellTypeFloat:
                    newCellType = new NumberCellType();
                    break;
                case FpCellType.CellTypeInteger:
                    newCellType = new NumberCellType();
                    (newCellType as NumberCellType).DecimalPlaces = 0;
                    break;
                case FpCellType.CellTypePic:
                    newCellType = new ImageCellType();
                    break;
                case FpCellType.CellTypeStaticText:
                    newCellType = new TextCellType();
                    (newCellType as TextCellType).ReadOnly = true;
                    break;
                case FpCellType.CellTypeTime:
                    newCellType = new DateTimeCellType();
                    (newCellType as DateTimeCellType).DateTimeFormat = DateTimeFormat.UserDefined;
                    (newCellType as DateTimeCellType).UserDefinedFormat = "hh:mm";
                    break;
                case FpCellType.CellTypeButton:
                    newCellType = new ButtonCellType();
                    break;
                case FpCellType.CellTypeComboBox:
                    newCellType = new ComboBoxCellType();
                    break;
                case FpCellType.CellTypePicture:
                    newCellType = new ImageCellType();
                    break;
                case FpCellType.CellTypeCheckBox:
                    newCellType = new CheckBoxCellType();
                    break;
                case FpCellType.CellTypeOwnerDrawn:
                    newCellType = new ImageCellType();
                    break;
            }
            return newCellType;
        }

        /// <summary>
        /// Whether the button cell behaves as a one-state or two-state button.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FpButtonType TypeButtonType
        {
            get
            {
                FpButtonType buttonType = default(FpButtonType);
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    buttonType = buttonCellType.TwoState ? FpButtonType.TypeButtonTypeTwoState : FpButtonType.TypeButtonTypeNormal;
                }
                return buttonType;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Picture so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.TwoState = value == FpButtonType.TypeButtonTypeTwoState;
                    SetCellType(clonedCellType);
                }
            }
        }

        /// <summary>
        /// The image displayed when a button is down.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image TypeButtonPictureDown
        {
            get
            {
                Image image = null;
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    image = buttonCellType.PictureDown;
                }
                return image;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Picture so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.PictureDown = value;
                    SetCellType(clonedCellType);
                }
            }
        }

        /// <summary>
        /// The image for the button.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image TypeButtonPicture
        {
            get
            {
                Image image = null;
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    image = buttonCellType.Picture;
                }
                return image;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Picture so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.Picture = value;
                    SetCellType(clonedCellType);
                }
            }
        }

        private void SetFontAtObject(object spreadElement, Font newFont)
        {
            if (spreadElement is Column)
            {
                (spreadElement as Column).Font = newFont;
            }
            else if (spreadElement is Row)
            {
                (spreadElement as Row).Font = newFont;
            }
            else if (spreadElement is StyleInfo)
            {
                (spreadElement as StyleInfo).Font = newFont;
            }
            else if (spreadElement is Cell)
            {
                (spreadElement as Cell).Font = newFont;
            }
        }

        /// <summary>
        /// Get/Set FontName to use
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FontName
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return font.Name;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(value, newFont.Size, newFont.Style);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        /// <summary>
        /// Font Bold for current row, col
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FontBold
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return font.Bold;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(newFont.FontFamily, newFont.Size,
                    value ? newFont.Style | System.Drawing.FontStyle.Bold : newFont.Style & ~System.Drawing.FontStyle.Bold);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FontSize
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return (int)font.Size;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(newFont.Name, value, newFont.Style);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        /// <summary>
        /// Get/Set Font Italic
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FontItalic
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return font.Italic;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(newFont.FontFamily, newFont.Size,
                   value ? newFont.Style | System.Drawing.FontStyle.Italic : newFont.Style & ~System.Drawing.FontStyle.Italic);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        /// <summary>
        /// Get/Set Font Underline
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FontUnderline
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return font.Underline;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(newFont.FontFamily, newFont.Size,
                   value ? newFont.Style | System.Drawing.FontStyle.Underline : newFont.Style & ~System.Drawing.FontStyle.Underline);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        /// <summary>
        /// Get/Set Font Underline
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FontStrikethru
        {
            get
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font font = base.Font;
                if (si != null && si.Font != null)
                {
                    font = si.Font;
                }
                return font.Strikeout;
            }
            set
            {
                StyleInfo si = GetCompositeInfo(this.Row, this.Col);
                Font newFont = base.Font;
                if (si != null && si.Font != null)
                {
                    newFont = si.Font;
                }
                newFont = new Font(newFont.FontFamily, newFont.Size,
                    value ? newFont.Style | System.Drawing.FontStyle.Strikeout : newFont.Style & ~System.Drawing.FontStyle.Strikeout);
                object spreadElement = GetSpreadObjectAtRange();
                SetFontAtObject(spreadElement, newFont);
            }
        }

        /// <summary>
        /// Gray Area Back Color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GrayAreaBackColor
        {
            get
            {
                return ActiveSheet != null ? this.ActiveSheet.GrayAreaBackColor : default(Color);
            }
            set
            {
                if (ActiveSheet != null)
                {
                    this.ActiveSheet.GrayAreaBackColor = value;
                }
            }
        }
        /// <summary>
        /// Get/Set Grid Color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GridColor
        {
            get { return ((this.ActiveSheet != null) ? this.ActiveSheet.HorizontalGridLine.Color : Color.LightGray); }
            set
            {
                if (this.ActiveSheet != null)
                {
                    GridLine line = new GridLine(GridLineType.Flat, value);
                    this.ActiveSheet.HorizontalGridLine = line;
                    this.ActiveSheet.VerticalGridLine = line;
                }
            }
        }

        /// <summary>
        /// Gets/sets the background color of the column and row headers
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ShadowColor
        {
            get
            {
                return _shadowColor;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    _shadowColor = value;
                    this.ActiveSheet.ColumnHeader.DefaultStyle.BackColor = value;
                    this.ActiveSheet.RowHeader.DefaultStyle.BackColor = value;
                    this.ActiveSheet.SheetCorner.DefaultStyle.BackColor = value;
                }
            }
        }

        /// <summary>
        /// Gets/sets the text color used for the column and row headers
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ShadowText
        {
            get
            {
                return _shadowText;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    _shadowColor = value;
                    this.ActiveSheet.ColumnHeader.DefaultStyle.ForeColor = value;
                    this.ActiveSheet.RowHeader.DefaultStyle.ForeColor = value;
                    this.ActiveSheet.SheetCorner.DefaultStyle.ForeColor = value;
                }
            }
        }

        /// <summary>
        /// Gets/sets the color of the bottom and right borders of the column and row headers
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ShadowDark
        {
            get
            {
                return _shadowDark;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    _shadowDark = value;
                    GridLine line = new GridLine(GridLineType.Flat, value);
                    this.ActiveSheet.ColumnHeader.HorizontalGridLine = line;
                    this.ActiveSheet.ColumnHeader.VerticalGridLine = line;
                    this.ActiveSheet.RowHeader.HorizontalGridLine = line;
                    this.ActiveSheet.RowHeader.VerticalGridLine = line;
                    this.ActiveSheet.SheetCorner.HorizontalGridLine = line;
                    this.ActiveSheet.SheetCorner.VerticalGridLine = line;
                }
            }
        }

        private GridLine m_HGridLineWidth = new GridLine(GridLineType.Flat);

        /// <summary>
        /// Get/Set Grid Show Horizontal Grid Lines
        /// </summary>
        [DefaultValue(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GridShowHoriz
        {
            get
            {
                return ((this.ActiveSheet != null)
                            ? (this.ActiveSheet.HorizontalGridLine.Width != 0 ? true : false)
                            : true);
            }
            set
            {
                if (value)
                {
                    this.ActiveSheet.HorizontalGridLine = m_HGridLineWidth;
                }
                else
                {
                    m_HGridLineWidth = ((this.ActiveSheet != null) ? this.ActiveSheet.HorizontalGridLine : null);
                    this.ActiveSheet.HorizontalGridLine = new GridLine(GridLineType.None);
                }
            }
        }

        private GridLine m_VGridLineWidth = new GridLine(GridLineType.Flat);

        /// <summary>
        /// Get/Set Grid Show Vertical Lines
        /// </summary>
        [DefaultValue(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GridShowVert
        {
            get
            {
                return ((this.ActiveSheet != null)
                            ? (this.ActiveSheet.VerticalGridLine.Width != 0 ? true : false)
                            : true);
            }
            set
            {
                if (value)
                {
                    this.ActiveSheet.VerticalGridLine = m_VGridLineWidth;
                }
                else
                {
                    m_VGridLineWidth = ((this.ActiveSheet != null) ? this.ActiveSheet.VerticalGridLine : null);
                    this.ActiveSheet.VerticalGridLine = new GridLine(GridLineType.None);
                }
            }
        }

        /// <summary>
        /// Lock the Grid
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Lock
        {
            get
            {
                StyleInfo si = GetCompositeInfo(Row, Col);
                bool locked = false;
                if (si != null)
                {
                    locked = si.Locked;
                }
                return locked;
            }
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).Locked = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).Locked = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).Locked = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).Locked = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of locked cells.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LockForeColor
        {
            get
            {
                StyleInfo si = GetCompositeInfo(Row, Col);
                Color lockForeColor = default(Color);
                if (si != null)
                {
                    lockForeColor = si.LockForeColor;
                }
                return lockForeColor;
            }
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).LockForeColor = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).LockForeColor = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).LockForeColor = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).LockForeColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color of locked cells.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color LockBackColor
        {
            get
            {
                StyleInfo si = GetCompositeInfo(Row, Col);
                Color lockBackColor = default(Color);
                if (si != null)
                {
                    lockBackColor = si.LockBackColor;
                }
                return lockBackColor;
            }
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).LockBackColor = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).LockBackColor = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).LockBackColor = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).LockBackColor = value;
                }
            }
        }

        /// <summary>
        /// Gets Selected Block Row
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelBlockRow
        {
            get
            {
                int BlockRow = 0;
                if (ActiveSheet != null)
                {
                    CellRange Selection = this.ActiveSheet.GetSelection(0);
                    if ((Selection != null))
                    {
                        if (Selection.Row == -1)
                        {
                            BlockRow = -1;
                        }
                        else
                        {
                            //add 1 to change 0 based to 1 based rows-columns 
                            BlockRow = Selection.Row + 1;
                        }
                    }
                }
                return BlockRow;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets Selected Block Row 2
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelBlockRow2
        {
            get
            {
                CellRange Selection = this.ActiveSheet.GetSelection(0);
                int BlockRow = 0;
                if ((Selection != null))
                {
                    if (Selection.Row == -1)
                    {
                        BlockRow = Selection.Row;
                    }
                    else if (Selection.RowCount == 1)
                    {
                        BlockRow = Selection.Row + 1;
                    }
                    else
                    {
                        BlockRow = Selection.Row + Selection.RowCount;
                    }
                }
                return BlockRow;
            }
        }

        /// <summary>
        /// Gets Selected Mode Selection Count
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelModeSelCount
        {
            get
            {
                int m_SelModeSelCount = 0;
                if (ActiveSheet != null)
                {
                    foreach (CellRange range in this.ActiveSheet.GetSelections())
                    {
                        m_SelModeSelCount += range.RowCount;
                    }
                }
                return m_SelModeSelCount;
            }
            set
            {
            }
        }

        /// <summary>
        /// Sets or returns the selection state of a row when the spreadsheet is in extended- or multiple-selection operation mode.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SelModeSelected
        {
            get
            {
                return this.ActiveSheet != null ? this.ActiveSheet.IsSelected(Row - 1, Col - 1) : false;
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    if (this.ActiveSheet.OperationMode == OperationMode.ExtendedSelect || this.ActiveSheet.OperationMode == OperationMode.MultiSelect)
                    {
                        int selRow = Row <= 0 ? -1 : Row - 1;
                        int selCol = Col <= 0 ? -1 : Col - 1;

                        if (value)
                        {
                            this.ActiveSheet.AddSelection(selRow, selCol, 1, this.MaxCols);
                        }
                        else
                        {
                            this.ActiveSheet.RemoveSelection(selRow, selCol, 1, this.MaxCols);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Get/Set SortBy constant
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SortByConstants SortBy
        {
            get { return _SortBy; }

            set { _SortBy = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public int GetSortKey(int nIndex)
        {
            if (nIndex <= _SortInfo.Length)
            {
                return _SortInfo[nIndex - 1].Index + 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Sets Sort Key for index
        /// </summary>
        /// <param name="nIndex">index in sort list</param>
        /// <param name="value">value to set</param>
        /// <returns></returns>
        public int SetSortKey(int nIndex, int value)
        {
            if (nIndex <= _SortInfo.Length)
            {
                _SortInfo[nIndex - 1].Index = value - 1;
            }
            if (nIndex == 1)
            {
                _SortCol1 = value;
            }
            if (nIndex == 2)
            {
                _SortCol2 = value;
            }
            if (nIndex == 3)
            {
                _SortCol3 = value;
            }
            return 0;
        }

        /// <summary>
        /// Gets Sort Key Order constant
        /// </summary>
        /// <param name="nIndex">index in sort list</param>
        /// <returns>SortKeyOrderConstants constant</returns>
        public SortKeyOrderConstants GetSortKeyOrder(int nIndex)
        {
            if (nIndex >= 1 & nIndex <= 3)
            {
                return (_SortInfo[nIndex - 1].Ascending
                            ? SortKeyOrderConstants.SortKeyOrderAscending
                            : SortKeyOrderConstants.SortKeyOrderDescending);
            }
            else
            {
                return SortKeyOrderConstants.SortKeyOrderNone;
            }
        }

        /// <summary>
        /// Sets Sort Key Order with SortKeyOrderConstants constant
        /// </summary>
        /// <param name="nIndex">index in sort list</param>
        /// <param name="value">constant</param>
        public void SetSortKeyOrder(int nIndex, SortKeyOrderConstants value)
        {
            if (nIndex >= 1 & nIndex <= 3)
            {
                _SortInfo[nIndex - 1].Ascending = (value == SortKeyOrderConstants.SortKeyOrderAscending ? true : false);
            }
            if (nIndex == 1)
            {
                _SortKeyOrder1 = value;
            }
            if (nIndex == 2)
            {
                _SortKeyOrder2 = value;
            }
            if (nIndex == 3)
            {
                _SortKeyOrder3 = value;
            }
        }

        /// <summary>
        /// Set Text to the col, row index
        /// </summary>
        /// <param name="col">column</param>
        /// <param name="row">row</param>
        /// <param name="text">text to set</param>
        public void SetText(int col, int row, object text)
        {
            Cell cellRange = GetCellRange(row, col, -1, -1);
            cellRange.Text = Convert.ToString(text);
        }

        /// <summary>
        /// Gets the Text at col and row
        /// </summary>
        /// <param name="col">column</param>
        /// <param name="row">row</param>
        /// <param name="text">text to set</param>
        public string GetText(int col, int row)
        {
            string value = string.Empty;
            Cell cellRange = GetCellRange(row, col, -1, -1);
            if (cellRange != null)
            {
                value = cellRange.Text;
                CheckBoxCellType checkBoxCellType = GetCellType<CheckBoxCellType>();
                if (checkBoxCellType != null)
                {
                    value = value == "False" || String.IsNullOrEmpty(value) ? "0" : "1";
                }
            }
            return value;
        }

        /// <summary>
        /// Get/Set Text in Row, Col, Row2, Col2
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                string value = null;
                Cell cellRange = GetCellRange(Row, Col, Row2, Col2);
                if (cellRange != null)
                {
                    value = cellRange.Text;
                    CheckBoxCellType checkBoxCellType = GetCellType<CheckBoxCellType>();
                    if (checkBoxCellType != null)
                    {
                        value = value == "False" || String.IsNullOrEmpty(value)? "0" : "1";
                    }
                }
                return value ?? string.Empty;
            }
            set
            {
                Cell cellRange = GetCellRange(Row, Col, Row2, Col2);
                if (cellRange != null)
                {
                    cellRange.Text = value ?? string.Empty;
                }
            }
        }

        /// <summary>
        /// Top Row
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TopRow
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set ToolTip text
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ToolTipText
        {
            get { return _ToolTipText; }
            set { _ToolTipText = value; }
        }

        private T GetCellType<T>() where T : BaseCellType
        {
            StyleInfo si = GetCompositeInfo(Row, Col);
            if (si != null)
            {
                return si.CellType as T;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Sets Type combobox List using a string separated by tabs
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeComboBoxList
        {
            set
            {
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    comboCellType.Items = value.Split(Strings.Chr(9));
                }
            }
            get
            {
                string comboList = string.Empty;
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    comboList = string.Join(Strings.Chr(9).ToString(), comboCellType.Items);
                }
                return comboList;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TypeComboBoxCurSel
        {
            get
            {
                int selectedIndex = 0;
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    selectedIndex = Array.IndexOf<string>(comboCellType.Items, Text);
                }
                return selectedIndex;
            }
            set
            {
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    string[] items = comboCellType.Items;
                    if (items != null && value < items.Length)
                    {
                        Text = items[value];
                    }
                }
            }
        }

        /// <summary>
        /// Type Button Text
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeButtonText
        {
            get
            {
                string buttonText = string.Empty;
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    buttonText = buttonCellType.Text;
                }
                return buttonText;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Text so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.Text = value;
                    SetCellType(clonedCellType);
                }
            }
        }
        /// <summary>
        /// Type Button Text Color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TypeButtonTextColor
        {
            get
            {
                Color textColor = Color.Empty;
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    textColor = buttonCellType.TextColor;
                }
                return textColor;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Text so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.TextColor = value;
                    SetCellType(clonedCellType);
                }
            }
        }

        /// <summary>
        /// Type Button Text Color
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TypeButtonColor
        {
            get
            {
                Color buttonColor = Color.Empty;
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    buttonColor = buttonCellType.ButtonColor;
                }
                return buttonColor;
            }
            set
            {
                ButtonCellType buttonCellType = GetCellType<ButtonCellType>();
                if (buttonCellType != null)
                {
                    //The cellType is usually assigned at the column level so we need to clone the cellType before setting the Text so that it applies only to the current cell
                    ButtonCellType clonedCellType = buttonCellType.Clone() as ButtonCellType;
                    clonedCellType.ButtonColor = value;
                    SetCellType(clonedCellType);
                }
            }
        }

        private bool _typeCheckCenter = false;
        /// <summary>
        /// Get or Set when is there a checkbox in the current Row/Col are checkboxes centers them in the cell
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TypeCheckCenter
        {
            get
            {
                return _typeCheckCenter;
            }
            set
            {
                _typeCheckCenter = value;
                CellHorizontalAlignment align = (value) ? CellHorizontalAlignment.Center : CellHorizontalAlignment.Left;

                if (Row <= -1 && Col <= -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int row = 0; row < this.ActiveSheet.RowCount; row++)
                        {
                            for (int col = 0; col < this.ActiveSheet.ColumnCount; col++)
                            {
                                if (GetCellType(row + 1, col + 1) is CheckBoxCellType)
                                {
                                    this.ActiveSheet.Cells[row, col].HorizontalAlignment = align;
                                }
                            }
                        }
                    }
                }
                else if (Row == -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int row = 0; row <= this.ActiveSheet.RowCount; row++)
                        {
                            if (GetCellType(row, this.Col) is CheckBoxCellType)
                            {
                                this.ActiveSheet.Cells[row - 1, this.Col - 1].HorizontalAlignment = align;
                            }
                        }
                    }
                }
                else if (Col == -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int col = 0; col <= this.ActiveSheet.ColumnCount; col++)
                        {
                            if (GetCellType(this.Row, col) is CheckBoxCellType)
                            {
                                this.ActiveSheet.Cells[this.Row - 1, col - 1].HorizontalAlignment = align;
                            }
                        }
                    }
                }
                else
                {
                    if (ActiveSheet != null)
                    {
                        if (GetCellType(this.Row, this.Col) is CheckBoxCellType)
                        {
                            this.ActiveSheet.Cells[this.Row - 1, this.Col - 1].HorizontalAlignment = align;
                        }
                    }
                }
            }
        }

        TypeCheckTypeConstants _typeCheckType = TypeCheckTypeConstants.TypeCheckTypeNormal;
        /// <summary>
        /// Type Check Type
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TypeCheckTypeConstants TypeCheckType
        {
            get
            {
                return _typeCheckType;
            }
            set
            {
                _typeCheckType = value;
                bool isThreeState = _typeCheckType == TypeCheckTypeConstants.TypeCheckTypeThreeState ? true : false;
                if (Row <= -1 && Col <= -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int row = 0; row < this.ActiveSheet.RowCount; row++)
                        {
                            for (int col = 0; col < this.ActiveSheet.ColumnCount; col++)
                            {
                                if (GetCellType(row + 1, col + 1) is CheckBoxCellType)
                                {
                                    CheckBoxCellType cellType = (CheckBoxCellType)GetCellType(Row, Col);
                                    cellType.ThreeState = isThreeState;
                                }
                            }
                        }
                    }
                }
                else if (Row == -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int row = 0; row <= this.ActiveSheet.RowCount; row++)
                        {
                            if (GetCellType(row, this.Col) is CheckBoxCellType)
                            {
                                CheckBoxCellType cellType = (CheckBoxCellType)GetCellType(Row, Col);
                                cellType.ThreeState = isThreeState;
                            }
                        }
                    }
                }
                else if (Col == -1)
                {
                    if (ActiveSheet != null)
                    {
                        for (int col = 0; col <= this.ActiveSheet.ColumnCount; col++)
                        {
                            if (GetCellType(this.Row, col) is CheckBoxCellType)
                            {
                                CheckBoxCellType cellType = (CheckBoxCellType)GetCellType(Row, Col);
                                cellType.ThreeState = isThreeState;
                            }
                        }
                    }
                }
                else
                {
                    if (GetCellType(this.Row, this.Col) is CheckBoxCellType)
                    {
                        CheckBoxCellType cellType = (CheckBoxCellType)GetCellType(Row, Col);
                        cellType.ThreeState = isThreeState;
                    }
                }
            }
        }

        /// <summary>
        /// Sets or returns the picture used for each state of a check box
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckBoxPicture TypeCheckPicture
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the number of items in the combo box list.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TypeComboBoxCount
        {
            get
            {
                int comboBoxCount = 0;
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    if (comboCellType.Items != null)
                    {
                        comboBoxCount = comboCellType.Items.Length;
                    }
                }
                return comboBoxCount;
            }
        }


        /// <summary>
        /// Gets/sets whether users can edit the text in a combo box cell
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TypeComboBoxEditable
        {
            get
            {
                bool editable = false;
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    return comboCellType.Editable;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    comboCellType.Editable = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the combo box item on which to perform an operation
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeComboBoxString
        {
            get
            {
                string comboBoxString = string.Empty;
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    if (comboCellType.Items != null && TypeComboBoxIndex < comboCellType.Items.Length)
                    {
                        comboBoxString = comboCellType.Items[TypeComboBoxIndex < 0 ? 0 : TypeComboBoxIndex];
                    }
                }
                return comboBoxString;
            }
            set
            {
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null)
                {
                    if (comboCellType.Items != null && (TypeComboBoxIndex <= comboCellType.Items.Length || TypeComboBoxIndex == -1))
                    {
                        var itemList = comboCellType.Items.ToList();
                        if (TypeComboBoxIndex == -1)
                        {
                            itemList.Add(value);
                        }
                        else
                        {
                            itemList.Insert(TypeComboBoxIndex, value);
                        }
                        comboCellType.Items = itemList.ToArray<string>();
                    }
                }
            }
        }

        /// <summary>
        /// Gets Set Type Edit Multiline state
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TypeEditMultiLine
        {
            get
            {
                if (GetCellType(Row, Col) is TextCellType)
                {
                    return ((TextCellType)GetCellType(Row, Col)).Multiline;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (GetCellType(Row, Col) is TextCellType)
                {
                    ((TextCellType)GetCellType(Row, Col)).Multiline = value;
                }
            }
        }

        /// <summary>
        /// Gets/sets whether a spin button is displayed in a date, time, or integer cell
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool TypeSpin
        {
            get
            {
                bool typeSpin = false;
                ICellType cellType = GetCellType<BaseCellType>();
                if (cellType is NumberCellType && (cellType as NumberCellType).DecimalPlaces == 0)
                {
                    //Float cells also use NumberCellType so we assume is an int cell if DecimalPlaces is 0
                    typeSpin = (cellType as NumberCellType).SpinButton;
                }
                else if (cellType is DateTimeCellType) //Date and Time cells are converted to DateTimeCellType
                {
                    typeSpin = (cellType as DateTimeCellType).SpinButton;
                }
                return typeSpin;
            }
            set
            {
                ICellType cellType = GetCellType<BaseCellType>();
                if (cellType is NumberCellType && (cellType as NumberCellType).DecimalPlaces == 0)
                {
                    (cellType as NumberCellType).SpinButton = value;
                }
                else if (cellType is DateTimeCellType)
                {
                    (cellType as DateTimeCellType).SpinButton = value;
                }
            }
        }

        /// <summary>
        /// Returns the last row that contains data in the spreadsheet
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DataRowCnt
        {
            get
            {
                return ActiveSheet.GetLastNonEmptyRow(FarPoint.Win.Spread.NonEmptyItemFlag.Data) + 1;
            }
        }

        /// <summary>
        /// Get/Set Type Float Decimal Char Separator
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeFloatDecimalChar
        {
            get
            {
                string decimalSeparator = string.Empty;
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    decimalSeparator = numberCellType.DecimalSeparator;
                }
                return decimalSeparator;
            }
            set
            {
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    numberCellType.DecimalSeparator = value;
                }
            }
        }

        /// <summary>
        /// Decimal Places
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TypeFloatDecimalPlaces
        {
            get
            {
                int decimalPlaces = 0;
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    decimalPlaces = numberCellType.DecimalPlaces;
                }
                return decimalPlaces;
            }
            set
            {
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    numberCellType.DecimalPlaces = value;
                }
            }
        }


        /// <summary>
        /// Type Float Max
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double TypeFloatMax
        {
            get
            {
                double maxValue = Double.MaxValue;
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    maxValue = numberCellType.MaximumValue;
                }
                return maxValue;
            }
            set
            {
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    numberCellType.MaximumValue = value;
                }
            }
        }

        /// <summary>
        /// Type Float Min
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double TypeFloatMin
        {
            get
            {
                double maxValue = Double.MinValue;
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    maxValue = numberCellType.MinimumValue;
                }
                return maxValue;
            }
            set
            {
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    numberCellType.MinimumValue = value;
                }
            }
        }

        /// <summary>
        /// Get/Set Type Float Separator Char for thousands
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeFloatSepChar
        {
            get
            {
                string separator = string.Empty;
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    separator = numberCellType.Separator;
                }
                return separator;
            }
            set
            {
                NumberCellType numberCellType = GetCellType<NumberCellType>();
                if (numberCellType != null)
                {
                    numberCellType.Separator = value;
                }
            }
        }

        /// <summary>
        /// Sets Type Horizontal Alignment
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CellHorizontalAlignment TypeHAlign
        {
            get
            {
                CellHorizontalAlignment hAlign = default(CellHorizontalAlignment);
                StyleInfo si = GetCompositeInfo(Row, Col);
                if (si != null)
                {
                    hAlign = si.HorizontalAlignment;
                }
                return hAlign;
            }
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).HorizontalAlignment = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).HorizontalAlignment = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).HorizontalAlignment = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).HorizontalAlignment = value;
                }
            }
        }

        /// <summary>
        /// Sets Type Vertical Align
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CellVerticalAlignment TypeVAlign
        {
            get
            {
                CellVerticalAlignment vAlign = default(CellVerticalAlignment);
                StyleInfo si = GetCompositeInfo(Row, Col);
                if (si != null)
                {
                    vAlign = si.VerticalAlignment;
                }
                return vAlign;
            }
            set
            {
                object gridElement = GetSpreadObjectAtRange();
                if (gridElement is Column)
                {
                    (gridElement as Column).VerticalAlignment = value;
                }
                else if (gridElement is Row)
                {
                    (gridElement as Row).VerticalAlignment = value;
                }
                else if (gridElement is StyleInfo)
                {
                    (gridElement as StyleInfo).VerticalAlignment = value;
                }
                else if (gridElement is Cell)
                {
                    (gridElement as Cell).VerticalAlignment = value;
                }
            }
        }

        /// <summary>
        /// Gets Integer Value in Row, Column, if is not a number return 0
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <param name="Col">Column to look at</param>
        /// <param name="value">Reference to variable to return integer value</param>
        /// <returns>Boolean true if value is returned</returns>
        public bool GetInteger(int Row, int Col, out int value)
        {
            bool ret = false;
            value = 0;
            try
            {
                if (ValidRowAndCol(Row, Col))
                {
                    value = (int)this.ActiveSheet.Cells[Row - 1, Col - 1].Value;
                    ret = true;
                }
            }
            catch
            {
            }
            return ret;
        }

        /// <summary>
        /// Gets the Value (unformatted data) at the cell range given by Row, Col, Row2 and Col2
        /// </summary>
        /// <param name="Row">Specificies a row or the first row of a block of cells on which an operation is to occur</param>
        /// <param name="Col">Specificies a col or the first col of a block of cells on which an operation is to occur</param>
        /// <param name="Row2">Last row of a block of cells on which an operation is to occur</param>
        /// <param name="Col2">Last column of a block of cells on which an operation is to occur</param>
        /// <returns>Object value</returns>
        private object GetValue(int Row, int Col, int Row2, int Col2)
        {
            Cell cellsRange = GetCellRange(Row, Col, Row2, Col2);
            object value = null;
            if (cellsRange != null)
            {
                value = cellsRange.Value;
            }
            return value;
        }

        /// <summary>
        /// Sets Value (unformatted data) at the cell range given by Row, Col, Row2 and Col2
        /// </summary>
        /// <param name="Row">Specificies a row or the first row of a block of cells on which an operation is to occur</param>
        /// <param name="Col">Specificies a col or the first col of a block of cells on which an operation is to occur</param>
        /// <param name="Row2">Last row of a block of cells on which an operation is to occur</param>
        /// <param name="Col2">Last column of a block of cells on which an operation is to occur</param>
        /// <param name="value">Value to set</param>
        private void SetValue(int Row, int Col, int Row2, int Col2, object value)
        {
            Cell cellsRange = GetCellRange(Row, Col, Row2, Col2);
            if (cellsRange != null)
            {
                cellsRange.Value = value;
            }
        }

        /// <summary>
        /// Gets a cell range given by Row, Col, Row2 and Col2
        /// </summary>
        internal Cell GetCellRange(int Row, int Col, int Row2, int Col2)
        {
            Cell cellsRange = null;
            if (Col == -1 && Row == -1)
            {
                cellsRange = this.ActiveSheet.Cells[0, 0, this.ActiveSheet.Rows.Count - 1, this.ActiveSheet.Columns.Count - 1];
            }
            else if (Col == 0 && Row == 0)
            {
                if (BlockMode && !(Row2 == 0 && Col2 == 0))
                {
                    if (Row2 == 0 && ValidCol(Col2))
                    {
                        cellsRange = this.ActiveSheet.ColumnHeader.Cells[Row, Col, Row2, Col2 - 1];
                    }
                    else if (ValidRow(Row2) && Col2 == 0)
                    {
                        cellsRange = this.ActiveSheet.RowHeader.Cells[Row, Col, Row2 - 1, Col2];
                    }
                    else if (Row2 == -1 && Col2 == -1)
                    {
                        cellsRange = this.ActiveSheet.SheetCorner.Cells[0, 0];
                    }
                }
                else
                {
                    cellsRange = cellsRange = this.ActiveSheet.SheetCorner.Cells[Row, Col];
                }
            }
            else if (Col == 0 && ValidRow(Row))
            {
                cellsRange = this.ActiveSheet.RowHeader.Cells[Row - 1, Col];
            }
            else if (ValidCol(Col) && Row == 0)
            {
                cellsRange = this.ActiveSheet.ColumnHeader.Cells[Row, Col - 1];
            }
            else if (ValidRowAndCol(Row, Col))
            {
                if (BlockMode && ValidRowAndCol(Row2, Col2))
                {
                    cellsRange = this.ActiveSheet.Cells[Row - 1, Col - 1, Row2 - 1, Col2 - 1];
                }
                else
                {
                    cellsRange = this.ActiveSheet.Cells[Row - 1, Col - 1];
                }
            }
            else if (Col == -1 && Row == 0)
            {
                cellsRange = this.ActiveSheet.ColumnHeader.Cells[Row, 0, Row, this.ActiveSheet.Columns.Count - 1];
            }
            else if (Col == -1 && ValidRow(Row))
            {
                if (MaxCols > 0)
                {
                    cellsRange = this.ActiveSheet.Cells[Row - 1, 0, Row - 1, this.ActiveSheet.Columns.Count - 1];
                }
            }
            else if (Col == 0 && Row == -1)
            {
                cellsRange = this.ActiveSheet.RowHeader.Cells[0, Col, this.ActiveSheet.Rows.Count - 1, Col];
            }
            else if (ValidCol(Col) && Row == -1)
            {
                if (MaxRows > 0)
                {
                    cellsRange = this.ActiveSheet.Cells[0, Col - 1, this.ActiveSheet.Rows.Count - 1, Col - 1];
                }
            }

            return cellsRange;

        }

        /// <summary>
        /// Gets/Sets unformatted data.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                return GetValue(Row, Col, Row2, Col2);
            }
            set
            {
                SetValue(Row, Col, Row2, Col2, value);
            }
        }

        /// <summary>
        /// Get/Set Rows Frozen state
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowsFrozen
        {
            get { return ((this.ActiveSheet != null) ? this.ActiveSheet.FrozenRowCount : 0); }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.FrozenRowCount = value;
                }
            }
        }

        /// <summary>
        /// Get/Set Columns Frozen state
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ColsFrozen
        {
            get { return ((this.ActiveSheet != null) ? this.ActiveSheet.FrozenColumnCount : 0); }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.FrozenColumnCount = value;
                }
            }
        }


        private CursorStyleConstants _cursorStyle;

        /// <summary>
        /// Cursor Style
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CursorStyleConstants CursorStyle
        {
            get
            {
                return _cursorStyle;
            }
            set
            {
                _cursorStyle = value;
                this.UpdateCursor();
            }
        }

        private CursorTypeConstants _cursorType;
        /// <summary>
        /// Cursor Type
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CursorTypeConstants CursorType
        {
            get
            {
                return _cursorType;
            }
            set
            {
                _cursorType = value;
                this.UpdateCursor();
            }
        }

        private FarPoint.Win.Spread.CursorType MapToFpCursorType(CursorTypeConstants _cursorType)
        {
            FarPoint.Win.Spread.CursorType FpCursorType = FarPoint.Win.Spread.CursorType.Normal;

            switch (_cursorType)
            {
                case CursorTypeConstants.CursorTypeButton:
                    //cursorType = FarPoint.Win.Spread.CursorType.; //no equivalent 
                    break;
                case CursorTypeConstants.CursorTypeColHeader:
                    FpCursorType = FarPoint.Win.Spread.CursorType.ColumnHeader;
                    break;
                case CursorTypeConstants.CursorTypeColResize:
                    FpCursorType = FarPoint.Win.Spread.CursorType.ColumnResize;
                    break;
                case CursorTypeConstants.CursorTypeDefault:
                    FpCursorType = FarPoint.Win.Spread.CursorType.Normal;
                    break;
                case CursorTypeConstants.CursorTypeDragDrop:
                    FpCursorType = FarPoint.Win.Spread.CursorType.DragFill;
                    break;
                case CursorTypeConstants.CursorTypeDragDropArea:
                    FpCursorType = FarPoint.Win.Spread.CursorType.DragDropArea;
                    break;
                case CursorTypeConstants.CursorTypeGrayArea:
                    FpCursorType = FarPoint.Win.Spread.CursorType.GrayArea;
                    break;
                case CursorTypeConstants.CursorTypeLockedCell:
                    FpCursorType = FarPoint.Win.Spread.CursorType.LockedCell;
                    break;
                case CursorTypeConstants.CursorTypeRowHeader:
                    FpCursorType = FarPoint.Win.Spread.CursorType.RowHeader;
                    break;
                case CursorTypeConstants.CursorTypeRowResize:
                    FpCursorType = FarPoint.Win.Spread.CursorType.RowResize;
                    break;
            }
            return FpCursorType;
        }

        private Cursor MapToCursor(CursorStyleConstants style)
        {
            Cursor cursor = this.GetCursor(FarPoint.Win.Spread.CursorType.Normal);
            switch (style)
            {
                case CursorStyleConstants.CursorStyleArrow:
                    cursor = Cursors.Arrow;
                    break;
                case CursorStyleConstants.CursorStyleDefault:
                    cursor = defaultCursor;
                    break;
                case CursorStyleConstants.CursorStyleDefColResize:
                    cursor = Cursors.VSplit;
                    break;
                case CursorStyleConstants.CursorStyleDefRowResize:
                    cursor = Cursors.HSplit;
                    break;
                case CursorStyleConstants.CursorStyleUserDefined:
                    cursor = Cursors.Default;
                    break;
            }
            return cursor;
        }

        private void UpdateCursor()
        {
            FarPoint.Win.Spread.CursorType cursorType = MapToFpCursorType(CursorType);
            Cursor cursor = MapToCursor(CursorStyle);
            base.SetCursor(cursorType, cursor);
        }

        /// <summary>
        /// Gets Cell from screen coordinate
        /// </summary>
        /// <param name="Col">returned column</param>
        /// <param name="Row">returned row</param>
        /// <param name="X">X pixel position</param>
        /// <param name="Y">Y pixel position</param>
        /// <returns>Cell Range at X,Y position</returns>
        public CellRange GetCellFromScreenCoord(ref int Col, ref int Row, float X, float Y)
        {
            CellRange Range = GetCellFromPixel(X, Y);
            Col = Range.Column + 1;
            Row = Range.Row + 1;
            return Range;
        }

        /// <summary>
        /// Gets Cell from pixel
        /// </summary>
        /// <param name="X">X pixel position</param>
        /// <param name="Y">Y pixel position</param>
        /// <returns>Cell Range at X,Y position</returns>
        public CellRange GetCellFromPixel(float X, float Y)
        {
            CellRange Range;
            Range = this.GetRootWorkbook().GetCellFromPixel(0, 0, Convert.ToInt32(X), Convert.ToInt32(Y));
            if (Range.Column == -1 & Range.Row == -1 & RowsFrozen > 0)
            {
                Range = this.GetRootWorkbook().GetCellFromPixel(-1, 0, Convert.ToInt32(X), Convert.ToInt32(Y));
            }
            if (Range.Column == -1 & Range.Row == -1 & ColsFrozen > 0)
            {
                Range = this.GetRootWorkbook().GetCellFromPixel(0, -1, Convert.ToInt32(X), Convert.ToInt32(Y));
            }
            if (Range.Column == -1 & Range.Row == -1 & ColsFrozen > 0 & RowsFrozen > 0)
            {
                Range = this.GetRootWorkbook().GetCellFromPixel(-1, -1, Convert.ToInt32(X), Convert.ToInt32(Y));
            }
            return Range;
        }

        /// <summary>
        /// Gets Cell Position
        /// </summary>
        /// <param name="Col">Column</param>
        /// <param name="Row">Row</param>
        /// <param name="l">Left position</param>
        /// <param name="t">Right position</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public void GetCellPos(int Col, int Row, ref int l, ref int t, ref int w, ref int h)
        {
            Rectangle r = this.GetCellRectangle(0, 0, Row - 1, Col - 1);
            l = r.Left;
            t = r.Right;
            w = r.Width;
            h = r.Height;
        }

        /// <summary>
        /// Get/Set Redraw action
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReDraw
        {
            get { return !this.IsLayoutSuspended; }
            set
            {
                if (value)
                {
                    this.ResumeLayout();
                }
                else
                {
                    this.SuspendLayout();
                }
            }
        }

        /// <summary>
        /// Sets RunLocalEvents status
        /// </summary>
        public bool RunLocalEvents
        {
            set { _RunLocalEvents = value; }
        }

        /// <summary>
        /// ItemData is stored in a generic collection instead of the Tag property to avoid boxing/unboxing 
        /// which has a performance hit
        /// </summary>
        /// <param name="Col">Column to set at</param>
        /// <param name="value">value to set</param>
        public void SetColItemData(ref int Col, ref int value)
        {
            //this.ActiveSheet.Columns(Col - 1).Tag = value 
            _ColItemData[Col] = value;
        }

        /// <summary>
        /// Sets Row Item Data at Row
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <param name="value">value to set</param>
        public void SetRowItemData(ref int Row, ref int value)
        {
            //this.ActiveSheet.Rows(Row - 1).Tag = value 
            _RowItemData[Row] = value;
        }

        /// <summary>
        /// Gets Column Item Data
        /// </summary>
        /// <param name="Col">Column to look at</param>
        /// <returns>Data in column position</returns>
        public int GetColItemData(int Col)
        {
            //Return this.ActiveSheet.Columns(Col - 1).Tag 
            return _ColItemData[Col];
        }

        /// <summary>
        /// Gets Row Item data
        /// </summary>
        /// <param name="Row">Row to look at</param>
        /// <returns>Data in Row position</returns>
        public int GetRowItemData(int Row)
        {
            //Return this.ActiveSheet.Rows(Row - 1).Tag 
            return _RowItemData[Row];
        }

        /// <summary>
        /// Returns whether a cell has been marked as changed. 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool GetCellDirtyFlag(int col, int row)
        {
            Cell cellRange = GetCellRange(row, col, -1, -1);
            return Convert.ToBoolean(cellRange.Tag);
        }

        /// <summary>
        /// Flags a cell as modified.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns>TRUE if successfull, otherwise false</returns>
        public bool SetCellDirtyFlag(int col, int row, bool dirty)
        {
            Cell cellRange = GetCellRange(row, col, -1, -1);
            cellRange.Tag = dirty;
            return true;
        }
        private void FpSpread_Change(object sender, ChangeEventArgs eventArgs)
        {
            this.ActiveRowIndex = eventArgs.Row + 1;
            this.ActiveColumnIndex = eventArgs.Column + 1;
            if (Change != null)
            {
                Change(this, new ChangeEventArgs(eventArgs.View, eventArgs.Row + 1, eventArgs.Column + 1));
            }
        }

        private void FpSpread_CellDoubleClick(object sender, CellClickEventArgs eventArgs)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(this, new CellClickEventArgs(eventArgs.View, eventArgs.Row + 1, eventArgs.Column + 1, eventArgs.X, eventArgs.Y, eventArgs.Button, eventArgs.ColumnHeader, eventArgs.RowHeader));
            }
        }

        private void FpSpread_CellClick(object sender, CellClickEventArgs eventArgs)
        {
            int adjustedColIndex = eventArgs.RowHeader ? 0 : eventArgs.Column + 1;
            int adjustedRowIndex = eventArgs.ColumnHeader ? 0 : eventArgs.Row + 1;

            if (eventArgs.Button == MouseButtons.Right)
            {
                if (CellRightClick != null)
                {
                    CellRightClick(this, new CellClickEventArgs(eventArgs.View, adjustedRowIndex, adjustedColIndex, eventArgs.X, eventArgs.Y, eventArgs.Button, eventArgs.ColumnHeader, eventArgs.RowHeader));
                }
            }
            else
            {
                if (CellClick != null)
                {
                    CellClick(this, new CellClickEventArgs(eventArgs.View, adjustedRowIndex, adjustedColIndex, eventArgs.X, eventArgs.Y, eventArgs.Button, eventArgs.ColumnHeader, eventArgs.RowHeader));
                }
            }
        }

        /// <summary>
        /// LeaveCell event
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="eventArgs">Event arguments</param>
        public void FpSpread_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs eventArgs)
        {
            //Trigger LeaveRow
            if (this.ActiveSheet.OperationMode == OperationMode.RowMode && eventArgs.Row != eventArgs.NewRow)
            {
                if (LeaveRow != null)
                {
                    LeaveRow(sender, new LeaveCellEventArgs(null, this.ActiveRowIndex, this.ActiveColumnIndex, eventArgs.NewRow + 1, eventArgs.NewColumn + 1));
                }
            }
            else if (this.ActiveSheet.OperationMode != OperationMode.RowMode)
            {
                if (LeaveCell != null)
                {
                    LeaveCell(sender, new LeaveCellEventArgs(null, eventArgs.Row + 1, eventArgs.Column + 1, eventArgs.NewRow + 1, eventArgs.NewColumn + 1));
                }
            }
            this.ActiveRowIndex = eventArgs.NewRow + 1;
            this.ActiveColumnIndex = eventArgs.NewColumn + 1;
        }

        private void FpSpread_TextTipFetch(object sender, FarPoint.Win.Spread.TextTipFetchEventArgs eventArgs)
        {
            eventArgs.ShowTip = true;
            eventArgs.TipText = ToolTipText;
            if (TextTipFetch != null)
            {
                TextTipFetch(sender, new TextTipFetchEventArgs(eventArgs));
            }
        }

        /// <summary>
        /// Left Change event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="eventArgs">Event arguments</param>
        public void FpSpread_LeftChange(object sender, LeftChangeEventArgs eventArgs)
        {
            if (TopLeftChange != null)
            {
                TopLeftChange(sender,
                              new TopLeftChangeEventArgs(
                                  this.GetRootWorkbook().GetActiveWorkbook().GetSpreadView(this.ActiveSheet, -1,
                                                                                           eventArgs.ColumnViewportIndex),
                                  eventArgs.OldLeft, eventArgs.NewLeft, this.Top, this.Top, -1,
                                  eventArgs.ColumnViewportIndex));
            }
        }

        /// <summary>
        /// Top Change event
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="eventArgs">Event Arguments</param>
        public void FpSpread_TopChange(object sender, TopChangeEventArgs eventArgs)
        {
            if (TopLeftChange != null)
            {
                TopLeftChange(sender,
                              new TopLeftChangeEventArgs(
                                  this.GetRootWorkbook().GetActiveWorkbook().GetSpreadView(this.ActiveSheet,
                                                                                           eventArgs.RowViewportIndex,
                                                                                           -1), this.Left, this.Left,
                                  eventArgs.OldTop, eventArgs.NewTop, eventArgs.RowViewportIndex, -1));
            }
        }

        private bool Pasting = false;
        private int LinesPasted;
        /// <summary>
        /// For Pasting purposes with Clipboard
        /// </summary>
        public bool PastingHandled = false;

        private void Spread_ClipboardPasting(object sender, ClipboardPastingEventArgs e)
        {
            if (!PastingHandled)
            {
                Pasting = true;
                e.Handled = PastingHandled;
                PastingHandled = false;

                //Count how many lines are to be pasted to raise as many Change events as lines 
                string[] lines = new Computer().Clipboard.GetText().Split(new string[] { Constants.vbCrLf },
                                                                          StringSplitOptions.None);
                LinesPasted = 0;
                foreach (string line in lines)
                {
                    if (line.Trim().Length > 0)
                    {
                        LinesPasted += 1;
                    }
                }
            }
        }

        private bool ModelChanging = false;
        private void DataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            //This.Changed is not raised on a paste. DataModel.Changed is raised when data is changed by the 
            //user, by code or paste. We need to raise the Change event only with paste or user changes. 
            //User changes are caught on Me.Change, paste changes are caught here 
            if (Pasting & !PastingHandled & !ModelChanging)
            {
                ModelChanging = true;
                if (Change != null)
                {
                    Change(this, new ChangeEventArgs(null, e.Column + 1, e.Row + 1));
                }
                LinesPasted -= 1;
                ModelChanging = false;
                if (!(LinesPasted > 0))
                {
                    Pasting = false;
                }
            }

            if (e.Type == SheetDataModelEventType.RowsAdded)
            {
                _RowItemData.InsertItems(e.Row + 1, e.RowCount);
            }
            else if (e.Type == SheetDataModelEventType.RowsRemoved)
            {
                _RowItemData.RemoveRange(e.Row + 1, e.RowCount);
            }
            else if (e.Type == SheetDataModelEventType.ColumnsAdded)
            {
                _ColItemData.InsertItems(e.Column + 1, e.ColumnCount);
            }
            else if (e.Type == SheetDataModelEventType.ColumnsRemoved)
            {
                _ColItemData.RemoveRange(e.Column + 1, e.ColumnCount);
            }
        }

        private bool _FirstPaint = true;
        private void FpSpread_Paint(object sender, PaintEventArgs e)
        {
            if (_FirstPaint)
            {
                InitializeSpread();
                _FirstPaint = false;
            }
        }

        /// <summary>
        /// Position
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PositionConstants Position
        {
            get;
            set;
        }

        /// <summary>
        /// Protect
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Protect
        {
            get
            {
                if (this.ActiveSheet != null)
                {
                    return this.ActiveSheet.Protect;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (this.ActiveSheet != null)
                {
                    this.ActiveSheet.Protect = value;
                }
            }
        }

        bool _processTab = false;
        /// <summary>
        /// ProcessTab
        /// </summary>
        [DefaultValue(false)]
        public bool ProcessTab
        {
            get
            {
                return _processTab;
            }
            set
            {
                _processTab = value;
                if (_processTab)
                {
                    FarPoint.Win.Spread.InputMap inputMap;
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.Normal);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.ExtendedSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.MultiSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.ReadOnly);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.RowMode);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.SingleSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.Normal);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.ExtendedSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.MultiSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.ReadOnly);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.RowMode);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.SingleSelect);
                    inputMap.Remove(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None));
                }
                else 
                {
                    FarPoint.Win.Spread.InputMap inputMap;
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.Normal);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.ExtendedSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.MultiSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.ReadOnly);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.RowMode);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, OperationMode.SingleSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.Normal);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.ExtendedSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.MultiSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.ReadOnly);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.RowMode);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                    inputMap = base.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, OperationMode.SingleSelect);
                    inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
                }
            }
        }

        BackColorStyleConstants _backcolorstyle = BackColorStyleConstants.BackColorStyleOverGrid;
        /// <summary>
        /// BackColorStyle sets the way backcolor shows in the grid.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BackColorStyleConstants BackColorStyle
        {
            get { return _backcolorstyle; }

            set { _backcolorstyle = value; }
        }

        /// <summary>
        /// BlockMode blocks the grid or column or row or single cell to be modified. 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool BlockMode
        {
            get;
            set;
        }

        private bool _changeMade = false;
        /// <summary>
        /// Get/Set wether the user has made any change to data in the grid.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeMade
        {
            get
            {
                return _changeMade;
            }
            set
            {
                _changeMade = value;
            }
        }

        /// <summary>
        /// Handle
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr TypeComboBoxHwnd
        {
            get
            {
                IntPtr handle = new IntPtr(0);
                ComboBoxCellType comboCellType = GetCellType<ComboBoxCellType>();
                if (comboCellType != null && comboCellType.ListControl != null)
                {
                    handle = comboCellType.ListControl.Handle;
                }
                return handle;
            }
        }

        /// <summary>
        /// Gets or sets the combo box item on which to perform an operation
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TypeComboBoxIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Type Date Format
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TypeDateFormatConstants TypeDateFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum number of characters allowed in the text or combo cells.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int TypeEditLen
        {
            get
            {
                return TypeMaxEditLen;
            }
            set
            {
                TypeMaxEditLen = value;
            }
        }

        private const string dateFormat = "MMddyyyy";
        private readonly DateTime defaultMaxDate = new DateTime(2100, 12, 31);
        private readonly DateTime defaultMinDate = new DateTime(1990, 1, 1);
        /// <summary>
        /// Gets or sets the maximum date allowed in a datetime cell.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string TypeDateMax
        {
            get
            {
                DateTime maxDate = defaultMaxDate;
                DateTimeCellType cellType = GetCellType<DateTimeCellType>();
                if (cellType != null)
                {
                    maxDate = cellType.MaximumDate;
                }
                return maxDate.ToString(dateFormat);
            }
            set
            {
                DateTimeCellType cellType = GetCellType<DateTimeCellType>();
                if (cellType != null)
                {
                    DateTime newMaxDate = defaultMaxDate;
                    if (DateTime.TryParseExact(value, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out newMaxDate))
                    {
                        cellType.MaximumDate = newMaxDate;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum date allowed in a datetime cell.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string TypeDateMin
        {
            get
            {
                DateTime minDate = defaultMinDate;
                DateTimeCellType cellType = GetCellType<DateTimeCellType>();
                if (cellType != null)
                {
                    minDate = cellType.MinimumDate;
                }
                return minDate.ToString(dateFormat);
            }
            set
            {
                DateTimeCellType cellType = GetCellType<DateTimeCellType>();
                if (cellType != null)
                {
                    DateTime newMinDate = defaultMinDate;
                    if (DateTime.TryParseExact(value, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out newMinDate))
                    {
                        cellType.MinimumDate = newMinDate;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of characters allowed in the text or combo cells.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int TypeMaxEditLen
        {
            get
            {
                int maxEditLen = 0;
                ICellType cellType = GetCellType<BaseCellType>();
                if (cellType is TextCellType)
                {
                    maxEditLen = (cellType as TextCellType).MaxLength;
                }
                else if (cellType is ComboBoxCellType)
                {
                    maxEditLen = (cellType as ComboBoxCellType).MaxLength;
                }
                return maxEditLen;
            }
            set
            {
                ICellType cellType = GetCellType<BaseCellType>();
                if (cellType is TextCellType)
                {
                    (cellType as TextCellType).MaxLength = value;
                }
                else if (cellType is ComboBoxCellType)
                {
                    (cellType as ComboBoxCellType).MaxLength = value;
                }
            }
        }

        /// <summary>
        /// TypeEditCharSet
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TypeEditCharSetConstants TypeEditCharSet
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set FormulaSync has no equivalent en FPSpread.Net
        /// </summary>
        [Obsolete("No equivalent in FpSpread.NET")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FormulaSync
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Get/Set NoBeep has no equivalent en FPSpread.Net
        /// </summary>
        [Obsolete("No equivalent in FpSpread.NET")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NoBeep
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Creates a copy of the format FpSpread.
        /// </summary>
        /// <returns></returns>
        public FpSpread Clone()
        {
            FpSpread fpSpreadClone = new FpSpread();
            if (fpSpreadClone.Sheets.Count <= 0)
            {
                fpSpreadClone.Sheets.AddRange(new SheetView[] { new SheetView() });
            }

            if (Sheets.Count > 0)
            {
                fpSpreadClone.Sheets[0].RowCount = 0;// fpSpreadFather.Sheets[0].RowCount;
                fpSpreadClone.Sheets[0].ColumnCount = this.Sheets[0].ColumnCount;
                //Clone the property(Sheet)
                foreach (PropertyInfo propertyInfo in this.Sheets[0].GetType().GetProperties())
                {
                    if (propertyInfo.Name != "RowCount" && propertyInfo.Name != "Models")
                    {
                        if (propertyInfo.CanRead && propertyInfo.CanWrite)
                        {
                            try
                            {
                                object[] index = new object[0];
                                if (propertyInfo.GetValue(this.Sheets[0], index) == null)
                                {
                                    propertyInfo.SetValue(fpSpreadClone.Sheets[0], null, index);
                                }
                                else if (!propertyInfo.GetValue(this.Sheets[0], index).Equals(propertyInfo.GetValue(fpSpreadClone.Sheets[0], index)))
                                {
                                    propertyInfo.SetValue(fpSpreadClone.Sheets[0], propertyInfo.GetValue(this.Sheets[0], index), index);
                                }
                            }
                            catch { }
                        }
                    }
                }

                fpSpreadClone.Sheets[0].Rows.Default.Height = this.Sheets[0].Rows.Default.Height;
                fpSpreadClone.Sheets[0].Rows.Default.Font = this.Sheets[0].Rows.Default.Font;
                fpSpreadClone.Sheets[0].ColumnHeader.Rows.Default.Height = this.Sheets[0].ColumnHeader.Rows.Default.Height;
                fpSpreadClone.Sheets[0].RowHeader.Columns.Default.Resizable = this.Sheets[0].RowHeader.Columns.Default.Resizable;

                for (int col = 0; col < this.Sheets[0].ColumnCount; col++)
                {
                    fpSpreadClone.Sheets[0].Columns[col].Label = this.Sheets[0].Columns[col].Label;
                    fpSpreadClone.Sheets[0].Columns[col].StyleName = this.Sheets[0].Columns[col].StyleName;
                    fpSpreadClone.Sheets[0].Columns[col].Width = this.Sheets[0].Columns[col].Width;
                    fpSpreadClone.Sheets[0].Columns[col].Resizable = this.Sheets[0].Columns[col].Resizable;
                    fpSpreadClone.Sheets[0].Columns[col].Visible = this.Sheets[0].Columns[col].Visible;
                }

                for (int colRowHeader = 0; colRowHeader < this.Sheets[0].RowHeader.ColumnCount; colRowHeader++)
                {
                    fpSpreadClone.Sheets[0].RowHeader.Columns.Get(colRowHeader).Width = this.Sheets[0].RowHeader.Columns.Get(colRowHeader).Width;
                    fpSpreadClone.Sheets[0].RowHeader.Columns.Get(colRowHeader).Visible = this.Sheets[0].RowHeader.Columns.Get(colRowHeader).Visible;
                }

                fpSpreadClone.Row = 0;
                fpSpreadClone.Col = this.Col;

                foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType.Name != "SheetView" && propertyInfo.Name != "VerticalScrollBar" && propertyInfo.Name != "WindowTarget" && propertyInfo.Name != "BackColor" && propertyInfo.Name != "Row" && propertyInfo.Name != "Col" && propertyInfo.Name != "MaxRows")
                    {
                        if (propertyInfo.CanRead && propertyInfo.CanWrite)
                        {
                            try
                            {
                                object[] index = new object[0];
                                if (propertyInfo.GetValue(this, index) == null)
                                {
                                    propertyInfo.SetValue(fpSpreadClone, null, index);
                                }
                                else if (!propertyInfo.GetValue(this, index).Equals(propertyInfo.GetValue(fpSpreadClone, index)))
                                {
                                    propertyInfo.SetValue(fpSpreadClone, propertyInfo.GetValue(this, index), index);
                                }
                            }
                            catch { }
                        }
                    }
                }

                ////Bind the same events set in the base control to the new control
                //Delegate[] EventDelegates = null;
                //foreach (EventInfo eInfo in GetType().GetEvents())
                //{
                //    EventDelegates = GetEventSubscribers(this, eInfo.Name);

                //    //The event in the new control will be bound to the same delegates of the base control
                //    if (EventDelegates != null)
                //    {
                //        foreach (Delegate del in EventDelegates)
                //        {
                //            try
                //            {
                //                this.GetType().GetEvent("").EventHandlerType.
                //                eInfo.AddEventHandler(fpSpreadClone, del);
                //            }
                //            catch { }
                //        }
                //    }
                //}
            }
            return fpSpreadClone;
        }

        /// <summary>
        /// Gets the delegates bound to an event in an object
        /// </summary>
        /// <param name="Target">The object</param>
        /// <param name="EventName">The event name</param>
        /// <returns>Null if no delegates or event where found</returns>
        private static Delegate[] GetEventSubscribers(object Target, string EventName)
        {
            Delegate del = null;
            string[] WinFormsEventsName = new string[] { "Event" + EventName, "Event_" + EventName
                , "EVENT" + EventName.ToUpper(), "EVENT_" + EventName.ToUpper()};
            Type TargetType = Target.GetType();
            FieldInfo fInfo = null;

            while (TargetType != null)
            {
                //Look for a field in the Target with the name of the event
                fInfo = TargetType.GetField(EventName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                if (fInfo != null)
                {
                    //Gets the current value in the Target instance
                    del = (Delegate)fInfo.GetValue(Target);
                    if (del != null)
                    {
                        return del.GetInvocationList();
                    }
                }
                else
                {
                    foreach (string winEventName in WinFormsEventsName)
                    {
                        //Look for a field in the Target with the name of the event as defined in some cases
                        fInfo = TargetType.GetField(winEventName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                        if (fInfo != null)
                        {
                            EventHandlerList eHandlerList = (EventHandlerList)Target.GetType().GetProperty("Events", (BindingFlags.FlattenHierarchy | (BindingFlags.NonPublic | BindingFlags.Instance))).GetValue(Target, null);

                            del = eHandlerList[fInfo.GetValue(Target)];
                            if (del != null)
                            {
                                return del.GetInvocationList();
                            }
                        }
                    }
                }

                //Repeats the process in the base types if nothing has been found so far
                TargetType = TargetType.BaseType;
            }

            return null;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FpUserResizeEnum UserResizeCol
        {
            get
            {
                return _UserResizeCol;
            }
            set
            {
                if (ValidCol(Col))
                {
                    this.ActiveSheet.Columns[Col - 1].Resizable = value == FpUserResizeEnum.UserResizeDefault || value == FpUserResizeEnum.UserResizeOn ? true : false;
                    _UserResizeCol = value;
                }
            }
        }
    }

    public class CheckBoxPicture
    {
        private FpSpread _spread = null;

        public CheckBoxPicture(FpSpread spread)
        {
            _spread = spread;
        }

        public Image this[int index]
        {
            get
            {
                StyleInfo si = _spread.GetCompositeInfo(_spread.Row, _spread.Col);
                Image image = null;
                if (si != null)
                {
                    CheckBoxCellType checkboxCellType = si.CellType as CheckBoxCellType;
                    if (checkboxCellType != null)
                    {
                        switch (index)
                        {
                            case 0:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.False];
                                break;
                            case 1:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.True];
                                break;
                            case 2:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.FalsePressed];
                                break;
                            case 3:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.TruePressed];
                                break;
                            case 4:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.Indeterminate];
                                break;
                            case 5:
                                image = checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.IndeterminatePressed];
                                break;
                            default:
                                throw new System.ArgumentException("Invalid image index (must be between 0 and 5");
                        }
                    }
                }
                return image;
            }
            set
            {
                StyleInfo si = _spread.GetCompositeInfo(_spread.Row, _spread.Col);
                if (si != null)
                {
                    CheckBoxCellType checkboxCellType = si.CellType as CheckBoxCellType;
                    if (checkboxCellType != null)
                    {
                        switch (index)
                        {
                            case 0:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.False] = value;
                                break;
                            case 1:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.True] = value;
                                break;
                            case 2:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.FalsePressed] = value;
                                break;
                            case 3:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.TruePressed] = value;
                                break;
                            case 4:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.Indeterminate] = value;
                                break;
                            case 5:
                                checkboxCellType.Picture[FarPoint.Win.CheckBoxPictureIndex.IndeterminatePressed] = value;
                                break;
                            default:
                                throw new System.ArgumentException("Invalid image index (must be between 0 and 5");
                        }
                    }
                }
            }
        }
    }

    #region ItemDataList

    internal class ItemDataList<T> : List<T>
    {
        public ItemDataList(int Capacity)
        {
            for (int i = 0; i <= Capacity - 1; i++)
            {
                this.Insert(i, default(T));
            }
        }

        public void InsertItems(int StartIndex, int Count)
        {
            int index = StartIndex + 1;
            if (index > this.Count)
            {
                index = StartIndex;
            }
            for (int i = 1; i <= Count; i++)
            {
                this.Insert(index, default(T));
                index += 1;
            }
        }
    }

    #endregion

    #region CellComparer

    /// <summary>
    /// Class for Cell comparison purposes
    /// </summary>
    public class CellComparer : IComparer
    {
        private Comparer DefaultComparer = Comparer.Default;

        int IComparer.Compare(object x, object y)
        {
            int CompareResult = 0;
            if (x is Bitmap & y is Bitmap)
            {
                CompareResult = CompareBitmaps((Bitmap)x, (Bitmap)y);
            }
            else
            {
                CompareResult = DefaultComparer.Compare(x, y);
            }
            return CompareResult;
        }

        private int CompareBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null & bmp2 == null)
            {
                return 0;
            }
            else if (bmp1 == null & (bmp2 != null))
            {
                return 1;
            }
            else if ((bmp1 != null) & bmp2 == null)
            {
                return -1;
            }
            else if (bmp1.Equals(bmp2))
            {
                return 0;
            }
            else if (bmp1.Width * bmp1.Height > bmp2.Width * bmp2.Height)
            {
                return 1;
            }
            else if (bmp1.Width * bmp1.Height < bmp2.Width * bmp2.Height)
            {
                return -1;
            }
            else
            {
                //Convert each image to a byte array 
                ImageConverter ic = new ImageConverter();
                byte[] btImage1 = new byte[2];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[2];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image 
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values 
                for (int i = 0; i <= hash1.Length - 1 & i < hash2.Length; i++)
                {
                    if (hash1[i] > hash2[i])
                    {
                        return -1;
                    }
                    else if (hash1[i] < hash2[i])
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
    }

    #endregion

    #region EventHandlers

    /// <summary>
    /// Leave Row event handler
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">Leave cell event arguments</param>
    public delegate void LeaveRowEventHandler(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e);

    /// <summary>
    /// TextTip Fetch event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TextTipFetchEventHandler(object sender, TextTipFetchEventArgs e);

    /// <summary>
    /// Top Left Change event handler
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">Top Left change event arguments</param>
    public delegate void TopLeftChangeEventHandler(object sender, TopLeftChangeEventArgs e);

    #endregion

    #region LeaveCellEventArgs

    /// <summary>
    /// Leave Cell Event Arguments Class, implemented from Farpoint Leave Cell Event Args
    /// </summary>
    public sealed class LeaveCellEventArgs : FarPoint.Win.Spread.LeaveCellEventArgs
    {
        /// <summary>
        /// Constructor passing all parameter to Farpoint class
        /// </summary>
        /// <param name="view">view</param>
        /// <param name="row">row</param>
        /// <param name="column">column</param>
        /// <param name="newRow">new row</param>
        /// <param name="newColumn">new column</param>
        public LeaveCellEventArgs(SpreadView view, int row, int column, int newRow, int newColumn)
            : base(view, row, column, newRow, newColumn)
        {
        }
    }

    #endregion

    #region TextTipFetchEventArgs

    /// <summary>
    /// TextTip Fetch Event Arguments
    /// </summary>
    public sealed class TextTipFetchEventArgs : EventArgs
    {
        private FarPoint.Win.Spread.TextTipFetchEventArgs _eventArgs;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eventArgs"></param>
        public TextTipFetchEventArgs(FarPoint.Win.Spread.TextTipFetchEventArgs eventArgs)
            : base()
        {
            _eventArgs = eventArgs;
        }

        /// <summary>
        /// Gets Column
        /// </summary>
        public int Col
        {
            get { return (_eventArgs.RowHeader ? _eventArgs.Column : _eventArgs.Column + 1); }
        }

        /// <summary>
        /// Gets Row
        /// </summary>
        public int Row
        {
            get { return (_eventArgs.ColumnHeader ? _eventArgs.Row : _eventArgs.Row + 1); }
        }

        /// <summary>
        /// Gets Sets Multiline state
        /// </summary>
        public int MultiLine
        {
            get { return Convert.ToInt32(_eventArgs.WrapText); }
            set { _eventArgs.WrapText = Convert.ToBoolean(value); }
        }

        /// <summary>
        /// Get/Set TipWidth value
        /// </summary>
        public int TipWidth
        {
            get { return _eventArgs.TipWidth; }
            set { _eventArgs.TipWidth = value; }
        }

        /// <summary>
        /// Get/Set Tip Text value
        /// </summary>
        public string TipText
        {
            get { return _eventArgs.TipText; }
            set { _eventArgs.TipText = value; }
        }

        /// <summary>
        /// Get/Set Show Tip
        /// </summary>
        public bool ShowTip
        {
            get { return _eventArgs.ShowTip; }
            set { _eventArgs.ShowTip = value; }
        }
    }

    #endregion

    #region TopLeftChangeEventArgs

    /// <summary>
    /// Top Left Change Event Arguments class
    /// </summary>
    public class TopLeftChangeEventArgs : EventArgs
    {
        // Fields
        private SpreadView _SpreadView;
        private int _OldLeft;
        private int _NewLeft;
        private int _OldTop;
        private int _NewTop;
        private int _RowViewportIndex;
        private int _ColumnViewportIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">SpredView</param>
        /// <param name="oldLeft">old left</param>
        /// <param name="newLeft">new left</param>
        /// <param name="oldTop">old top</param>
        /// <param name="newTop">new top</param>
        /// <param name="rowViewportIndex">row view port index</param>
        /// <param name="columnViewportIndex">column view port index</param>
        public TopLeftChangeEventArgs(SpreadView view, int oldLeft, int newLeft, int oldTop, int newTop,
                                      int rowViewportIndex, int columnViewportIndex)
        {
            this._SpreadView = view;
            this._OldTop = oldTop;
            this._NewTop = newTop;
            this._OldLeft = oldLeft;
            this._NewLeft = newLeft;
            this._RowViewportIndex = rowViewportIndex;
            this._ColumnViewportIndex = columnViewportIndex;
        }

        /// <summary>
        /// New Left
        /// </summary>
        public int NewLeft
        {
            get { return this._NewLeft; }
        }

        /// <summary>
        /// Old Left
        /// </summary>
        public int OldLeft
        {
            get { return this._OldLeft; }
        }

        /// <summary>
        /// New Top
        /// </summary>
        public int NewTop
        {
            get { return this._NewTop; }
        }

        /// <summary>
        /// Old Top
        /// </summary>
        public int OldTop
        {
            get { return this._OldTop; }
        }

        /// <summary>
        /// Row view port index
        /// </summary>
        public int RowViewportIndex
        {
            get { return this._RowViewportIndex; }
        }

        /// <summary>
        /// Column view port index
        /// </summary>
        public int ColumnViewportIndex
        {
            get { return this._ColumnViewportIndex; }
        }
    }

    #endregion

    #region Enums
    /// <summary>
    /// Back Color style constants
    /// </summary>
    public enum BackColorStyleConstants
    {
        /// <summary>
        /// Over Grid
        /// </summary>
        BackColorStyleOverGrid = 0,
        /// <summary>
        /// Under Grid
        /// </summary>
        BackColorStyleUnderGrid = 1,
        /// <summary>
        /// Over Horizantal Grid only
        /// </summary>
        BackColorStyleOverHorzGridOnly = 2,
        /// <summary>
        /// Over Vertical Grid only
        /// </summary>
        BackColorStyleOverVertGridOnly = 3
    }

    /// <summary>
    /// Cell Border Style constants
    /// </summary>
    public enum CellBorderStyleConstants
    {
        /// <summary>
        /// CellBorderStyleBlank
        /// </summary>
        CellBorderStyleBlank,
        /// <summary>
        /// CellBorderStyleDash
        /// </summary>
        CellBorderStyleDash,
        /// <summary>
        /// CellBorderStyleDashDot
        /// </summary>
        CellBorderStyleDashDot,
        /// <summary>
        /// CellBorderStyleDashDotDot
        /// </summary>
        CellBorderStyleDashDotDot,
        /// <summary>
        /// CellBorderStyleDefault
        /// </summary>
        CellBorderStyleDefault,
        /// <summary>
        /// CellBorderStyleDot
        /// </summary>
        CellBorderStyleDot,
        /// <summary>
        /// CellBorderStyleFineDash
        /// </summary>
        CellBorderStyleFineDash,
        /// <summary>
        /// CellBorderStyleFineDashDot
        /// </summary>
        CellBorderStyleFineDashDot,
        /// <summary>
        /// CellBorderStyleFineDashDotDot
        /// </summary>
        CellBorderStyleFineDashDotDot,
        /// <summary>
        /// CellBorderStyleFineDot
        /// </summary>
        CellBorderStyleFineDot,
        /// <summary>
        /// CellBorderStyleFineSolid
        /// </summary>
        CellBorderStyleFineSolid,
        /// <summary>
        /// CellBorderStyleSolid
        /// </summary>
        CellBorderStyleSolid
    }

    /// <summary>
    /// Cursor kinds
    /// </summary>
    public enum CursorStyleConstants
    {
        /// <summary>
        /// Arrow cursor
        /// </summary>
        CursorStyleArrow,
        /// <summary>
        /// Default cursor
        /// </summary>
        CursorStyleDefault,
        /// <summary>
        /// Default Column Resize
        /// </summary>
        CursorStyleDefColResize,
        /// <summary>
        /// Default Row Resize
        /// </summary>
        CursorStyleDefRowResize,
        /// <summary>
        /// User defined cursor
        /// </summary>
        CursorStyleUserDefined
    }

    /// <summary>
    /// Cursor Type Constants
    /// </summary>
    public enum CursorTypeConstants
    {
        /// <summary>
        /// Type Button
        /// </summary>
        CursorTypeButton,
        /// <summary>
        /// Column Header
        /// </summary>
        CursorTypeColHeader,
        /// <summary>
        /// Column Resize
        /// </summary>
        CursorTypeColResize,
        /// <summary>
        /// Type Default
        /// </summary>
        CursorTypeDefault,
        /// <summary>
        /// Type Drag Drop
        /// </summary>
        CursorTypeDragDrop,
        /// <summary>
        /// Type Drag Drop Area
        /// </summary>
        CursorTypeDragDropArea,
        /// <summary>
        /// Gray Area
        /// </summary>
        CursorTypeGrayArea,
        /// <summary>
        /// Locked Cell
        /// </summary>
        CursorTypeLockedCell,
        /// <summary>
        /// Type Row Header
        /// </summary>
        CursorTypeRowHeader,
        /// <summary>
        /// Type Row Resize
        /// </summary>
        CursorTypeRowResize
    }

    /// <summary>
    /// Sort key order constants
    /// </summary>
    public enum SortKeyOrderConstants
    {
        /// <summary>
        /// No order
        /// </summary>
        SortKeyOrderNone = 0,
        /// <summary>
        /// Order Ascending
        /// </summary>
        SortKeyOrderAscending = 1,
        /// <summary>
        /// Order Descending
        /// </summary>
        SortKeyOrderDescending = 2
    }

    /// <summary>
    /// Action constants
    /// </summary>
    public enum FPActionConstants
    {
        /// <summary>
        /// Active cell
        /// </summary>
        ActionActiveCell = 0,
        /// <summary>
        /// Goto cell
        /// </summary>
        ActionGotoCell = 1,
        /// <summary>
        /// Select block
        /// </summary>
        ActionSelectBlock = 2,
        /// <summary>
        /// Clear
        /// </summary>
        ActionClear = 3,
        /// <summary>
        /// Clear
        /// </summary>
        ActionDeleteCol = 4,
        /// <summary>
        /// Delete Row
        /// </summary>
        ActionDeleteRow = 5,
        /// <summary>
        /// Insert column
        /// </summary>
        ActionInsertCol = 6,
        /// <summary>
        /// Insert row
        /// </summary>
        ActionInsertRow = 7,
        /// <summary>
        /// ActionReCalc 
        /// </summary>
        ActionReCalc = 11,
        /// <summary>
        /// Clear text
        /// </summary>
        ActionClearText = 12,
        /// <summary>
        /// ActionPrint 
        /// </summary>
        ActionPrint = 13,
        /// <summary>
        /// Deselect Block
        /// </summary>
        ActionDeselectBlock = 14,
        /// <summary>
        /// ActionDSave 
        /// </summary>
        ActionDSave = 15,
        /// <summary>
        /// ActionSetCellBorder  
        /// </summary>
        ActionSetCellBorder = 16,
        /// <summary>
        /// Add multiselect block
        /// </summary>
        ActionAddMultiSelBlock = 17,
        /// <summary>
        /// Gets multi selection
        /// </summary>
        ActionGetMultiSelection = 18,
        /// <summary>
        /// ActionCopyRange 
        /// </summary>
        ActionCopyRange = 19,
        /// <summary>
        /// ActionModeRange 
        /// </summary>
        ActionModeRange = 20,
        /// <summary>
        /// ActionSwapRange  
        /// </summary>
        ActionSwapRange = 21,
        /// <summary>
        /// Clipboard copy
        /// </summary>
        ActionClipboardCopy = 22,
        /// <summary>
        /// ActionClipboardCut copy
        /// </summary>
        ActionClipboardCut = 23,
        /// <summary>
        /// Clipboard paste
        /// </summary>
        ActionClipboardPaste = 24,
        /// <summary>
        /// Sort
        /// </summary>
        ActionSort = 25,
        /// <summary>
        /// ActionComboClear 
        /// </summary>
        ActionComboClear = 26,
        /// <summary>
        /// ActionComboRemove  
        /// </summary>
        ActionComboRemove = 27,
        /// <summary>
        /// ActionReset   
        /// </summary>
        ActionReset = 28,
        /// <summary>
        /// ActionSelModeClear 
        /// </summary>
        ActionSelModeClear = 29,
        /// <summary>
        /// ActionVModeRefresh 
        /// </summary>
        ActionVModeRefresh = 30,
        /// <summary>
        /// Smart print
        /// </summary>
        ActionSmartPrint = 32
    }

    /// <summary>
    /// Click Type constants
    /// </summary>
    public enum ClickType
    {
        /// <summary>
        /// Down
        /// </summary>
        Down = 0,
        /// <summary>
        /// Up
        /// </summary>
        Up,
        /// <summary>
        /// Double click
        /// </summary>
        DoubleClick
    }

    /// <summary>
    /// Position Constants
    /// </summary>
    public enum PositionConstants
    {
        /// <summary>
        /// Upper left
        /// </summary>
        PositionUpperLeft,
        /// <summary>
        /// Upper center
        /// </summary>
        PositionUpperCenter,
        /// <summary>
        /// Upper right
        /// </summary>
        PositionUpperRight,
        /// <summary>
        /// Center left
        /// </summary>
        PositionCenterLeft,
        /// <summary>
        /// Center
        /// </summary>
        PositionCenter,
        /// <summary>
        /// Center right
        /// </summary>
        PositionCenterRight,
        /// <summary>
        /// Bottom left
        /// </summary>
        PositionBottomLeft,
        /// <summary>
        /// Bottom center
        /// </summary>
        PositionBottomCenter,
        /// <summary>
        /// Bottom right
        /// </summary>
        PositionBottomRight
    }

    /// <summary>
    /// Scroll bars constants
    /// </summary>
    public enum FPScrollBarsConstants
    {
        /// <summary>
        /// None
        /// </summary>
        ScrollBarsNone,
        /// <summary>
        /// Horizontal
        /// </summary>
        ScrollBarsHorizontal,
        /// <summary>
        /// Vertical
        /// </summary>
        ScrollBarsVertical,
        /// <summary>
        /// Both
        /// </summary>
        ScrollBarsBoth
    }

    /// <summary>
    /// Standard Aggregate Column
    /// </summary>
    public enum enumStdAggregateColumn
    {
        /// <summary>
        /// First
        /// </summary>
        colFirst = 1,
        /// <summary>
        /// Name
        /// </summary>
        colName = colFirst,
        /// <summary>
        /// Index Percent
        /// </summary>
        colIndexPercent,
        /// <summary>
        /// Index value
        /// </summary>
        colIndexValue,
        /// <summary>
        /// Benchmark count
        /// </summary>
        colBenchmarkCount,
        /// <summary>
        /// Fund count
        /// </summary>
        colFundCount,
        /// <summary>
        /// Fund value pretrade
        /// </summary>
        colFundValuePreTrade,
        /// <summary>
        /// Fund percent pretrade
        /// </summary>
        colFundPercentPreTrade,
        /// <summary>
        /// Missing weight percent pretrade
        /// </summary>
        colMisweightPercentPreTrade,
        /// <summary>
        /// Missing weight value pretrade
        /// </summary>
        colMisweightValuePreTrade,
        /// <summary>
        /// Fund value post trade
        /// </summary>
        colFundValuePostTrade,
        /// <summary>
        /// Fund percent post trade
        /// </summary>
        colFundPercentPostTrade,
        /// <summary>
        /// Missing weight percent post trade
        /// </summary>
        colMisweightPercentPostTrade,
        /// <summary>
        /// Missing weight value post trade
        /// </summary>
        colMisweightValuePostTrade,
        /// <summary>
        /// Order value
        /// </summary>
        colOrderValue,
        /// <summary>
        /// Column Id
        /// </summary>
        ColID,
        /// <summary>
        /// Last column
        /// </summary>
        colLast = ColID
    }

    /// <summary>
    /// Cell Image constants
    /// </summary>
    public enum enumCellImage
    {
        /// <summary>
        /// Checked
        /// </summary>
        Checked = 1,
        /// <summary>
        /// Minus
        /// </summary>
        Minus = 2,
        /// <summary>
        /// Plus
        /// </summary>
        Plus = 3,
        /// <summary>
        /// Unchecked
        /// </summary>
        Unchecked = 4
    }

    /// <summary>
    /// Sort by constants
    /// </summary>
    public enum SortByConstants
    {
        /// <summary>
        /// By row
        /// </summary>
        SortByRow = 0,
        /// <summary>
        /// By column
        /// </summary>
        SortByCol = 1
    }

    /// <summary>
    /// Type Date Format
    /// </summary>
    public enum TypeDateFormatConstants
    {
        /// <summary>
        /// D M Y
        /// </summary>
        TypeDateFormatDDMMYY,
        /// <summary>
        /// D Month Y
        /// </summary>
        TypeDateFormatDDMONYY,
        /// <summary>
        /// M D Y
        /// </summary>
        TypeDateFormatMMDDYY,
        /// <summary>
        /// Y M D
        /// </summary>
        TypeDateFormatYYMMDD
    }

    /// <summary>
    /// Type Edit CharSet Constants
    /// </summary>
    public enum TypeEditCharSetConstants
    {
        /// <summary>
        /// Alpha
        /// </summary>
        TypeEditCharSetAlpha,
        /// <summary>
        /// AlphaNumeric
        /// </summary>
        TypeEditCharSetAlphaNumeric,
        /// <summary>
        /// ASCII
        /// </summary>
        TypeEditCharSetASCII,
        /// <summary>
        /// Numeric
        /// </summary>
        TypeEditCharSetNumeric
    }

    /// <summary>
    /// Type Check Type
    /// </summary>
    public enum TypeCheckTypeConstants
    {
        /// <summary>
        /// Normal
        /// </summary>
        TypeCheckTypeNormal,
        /// <summary>
        /// ThreeState
        /// </summary>
        TypeCheckTypeThreeState
    }

    /// <summary>
    /// Cell types
    /// </summary>
    public enum FpCellType
    {
        CellTypeDate,
        CellTypeEdit,
        CellTypeFloat,
        CellTypeInteger,
        CellTypePic,
        CellTypeStaticText,
        CellTypeTime,
        CellTypeButton,
        CellTypeComboBox,
        CellTypePicture,
        CellTypeCheckBox,
        CellTypeOwnerDrawn
    }

    public enum FpUnitType
    {
        Normal, //Column width and row height are based on system fixed font
        VGABase, //Column width and row height are based on predetermined value
        Twips //Units are in twips
    }

    /// <summary>
    /// Button types for button cells
    /// </summary>
    public enum FpButtonType
    {
        TypeButtonTypeNormal,
        TypeButtonTypeTwoState
    }

    public enum FpUserResizeEnum
    {
        UserResizeDefault,
        UserResizeOn,
        UserResizeOff
    }

    #endregion
}
