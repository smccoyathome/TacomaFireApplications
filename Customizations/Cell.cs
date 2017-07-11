// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="Cell.cs" >
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
    using System.Globalization;

    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     Cell of FarPoint Spread
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class Cell : IDependentModel, IInitializable<int, int>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        public Cell()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        ///     Gets or sets the color of the back.
        /// </summary>
        /// <value>
        ///     The color of the back.
        /// </value>
        public virtual Color BackColor { get; set; }

        /// <summary>
        ///     Gets or sets the type border.
        /// </summary>
        /// <value>
        ///     The type of border.
        /// </value>
        public virtual int Border { get; set; }

        /// <summary>
        ///     Gets or sets the cell type.
        /// </summary>
        /// <value>
        ///     The cell type.
        /// </value>
        public virtual ICellType CellType { get; set; }

        /// <summary>
        ///     Gets or sets the column.
        /// </summary>
        /// <value>
        ///     The column.
        /// </value>
        public virtual int Column { get; set; }

        /// <summary>
        ///     Gets or sets the number of columns used by the cell.
        /// </summary>
        /// <value>
        ///     The column span.
        /// </value>
        [Obsolete]
        public int ColumnSpan { get; set; }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public Font Font
        { get
            {
                if (_font == null)
                    _font = StaticContainer.Instance.Resolve<Font>();
                return _font;
            }
        }

        public virtual Font _font { get; set; }

        /// <summary>
        ///     Gets or sets the color of the fore.
        /// </summary>
        /// <value>
        ///     The color of the fore.
        /// </value>
        public virtual Color ForeColor { get; set; }
        
        /// <summary>
        /// Gets or sets the formula of the cell.
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        ///     Gets or sets the number of columns used by the cell.
        /// </summary>
        /// <value>
        ///     The column span.
        /// </value>
        public float Height { get; set; }

        /// <summary>
        ///     Gets or sets the number of columns used by the cell.
        /// </summary>
        /// <value>
        ///     The column span.
        /// </value>
        public CellHorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        /// Gets or sets the locked of the cell.
        /// </summary>
        public virtual bool Locked { get; set; }

        /// <summary>
        /// Gets or sets the parse format information.
        /// </summary>
        /// <value>
        /// The parse format information.
        /// </value>
        [Obsolete]
        public NumberFormatInfo ParseFormatInfo { get; set; }

        /// <summary>
        /// Gets or sets the parse format string.
        /// </summary>
        /// <value>
        /// The parse format string.
        /// </value>
        [Obsolete]
        public string ParseFormatString { get; set; }

        /// <summary>
        ///     Gets or sets the row.
        /// </summary>
        /// <value>
        ///     The row.
        /// </value>
        public virtual int Row { get; set; }

        /// <summary>
        /// Gets or sets the row span.
        /// </summary>
        /// <value>
        /// The row span.
        /// </value>
        [Obsolete]
        public int RowSpan { get; set; }

        /// <summary>
        ///     Gets or sets the name of the style.
        /// </summary>
        /// <value>
        ///     The name of the style.
        /// </value>
        public virtual string StyleName { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public virtual string Value { get; set; }

        /// <summary>
        ///     Gets or sets the vertical alignment.
        /// </summary>
        /// <value>
        ///     The vertical alignment.
        /// </value>
        public CellVerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        public float Width { get; set; }

        /// <summary>
        ///     Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        /// Initializes the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public void Init(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}