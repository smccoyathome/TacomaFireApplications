// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="Cells.cs" >
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     Cells class that contains all existent Cells;
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentModel" />
    /// <seealso cref="UpgradeHelpers.Interfaces.ICreatesObjects" />
    public class Cells : IDependentModel, ICreatesObjects, IInitializable<SheetViewModel>, IEnumerable<Cell>
    {

        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual SheetViewModel Sheet { get; set; }

        /// <summary>
        ///     Gets or sets the cells cache.
        /// </summary>
        /// <value>
        ///     The cells cache.
        /// </value>
        public virtual IDictionary<int, IDictionary<int, Cell>> CellsCache { get; set; }

        /// <summary>
        ///     Gets or sets the container.
        /// </summary>
        /// <value>
        ///     The container.
        /// </value>
        public IIocContainer Container { get; set; }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count { get; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        /// <summary>
        ///     The Indexer for the cells
        /// </summary>
        /// <param name="row">
        ///     The row.
        /// </param>
        /// <param name="column">
        ///     The column.
        /// </param>
        /// <returns>
        ///     The <see cref="Cell" />.
        /// </returns>
        public Cell this[int row, int column]
        {
            get
            {
                return this.GetCell(row, column);
            }

            set
            {
                this.SetCellValue(row, column, value);
            }
        }

        /// <summary>
        ///     Gets or sets the <see cref="Cell" /> at the specified index.
        /// </summary>
        /// <value>
        ///     The <see cref="Cell" />.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An IEnumerable with the cells of the row index</returns>
        public IEnumerable<Cell> this[int index]
        {
            get
            {
                return this.GetRowCells(index).Values;
            }
        }

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(Cell item)
        {
            this[item.Row, item.Column] = item;
        }

        /// <summary>
        ///     Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            this.CellsCache.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///     true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />;
        ///     otherwise, false.
        /// </returns>
        public bool Contains(Cell item)
        {
            return this.GetEnumerable().Any(x => x.Row == item.Row && x.Column == item.Column);
        }

        /// <summary>
        ///     Gets the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>The cell</returns>
        public Cell Get(int row, int column)
        {
            return this[row, column];
        }

        /// <summary>
        ///     Gets the enumerable.
        /// </summary>
        /// <returns>An IEnumerable of cell</returns>
        public IEnumerable<Cell> GetEnumerable()
        {
            return this.CellsCache.Values.SelectMany(x => x.Values);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            return this.GetEnumerable().GetEnumerator();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        ///     true if <paramref name="item" /> was successfully removed from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if
        ///     <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(Cell item)
        {
            var row = this.GetRowCells(item.Row);
            return row != null && row.Remove(item.Column);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///     Gets the row cells.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>The cells in the row</returns>
        internal IDictionary<int, Cell> GetRowCells(int row)
        {
            if (!this.CellsCache.ContainsKey(row) && row >= 0)
            {
                this.Sheet.Rows.Add(row, this.Container.Resolve<Row>(row, this));
                this.CellsCache[row] = this.Container.Resolve<IDictionary<int, Cell>>();
            }

            return row >= 0 ? this.CellsCache[row] : default(IDictionary<int, Cell>);
        }

        /// <summary>
        ///     Gets the cell.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>the Cell</returns>
        private Cell GetCell(int row, int column)
        {
            return this.GetColumnCell(this.GetRowCells(row), row, column);
        }

        /// <summary>
        ///     Gets the column cell.
        /// </summary>
        /// <param name="rowCells">
        ///     The row CellsCache.
        /// </param>
        /// <param name="row">
        ///     The row.
        /// </param>
        /// <param name="column">
        ///     The column.
        /// </param>
        /// <returns>
        ///     The Cell
        /// </returns>
        private Cell GetColumnCell(IDictionary<int, Cell> rowCells, int row, int column)
        {
            if (row >= 0 && !rowCells.ContainsKey(column))
            {
                this.Sheet.Columns.Add(column,this.Container.Resolve<Column>(column, this));
                var cell = this.Container.Resolve<Cell>(row, column);
                rowCells[column] = cell;
            }

            return row >= 0 ? rowCells[column] : default(Cell);
        }

        /// <summary>
        ///     Sets the cell value.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        private void SetCellValue(int row, int column, Cell value)
        {
            var rowCells = this.GetRowCells(row);
            if (!rowCells.ContainsKey(column))
            {
                rowCells.Add(column, value);
            }
            else
            {
                rowCells[column] = value;
            }
        }

        public void Init(SheetViewModel sheet)
        {
            this.CellsCache = this.Container.Resolve<IDictionary<int, IDictionary<int, Cell>>>();
            this.Sheet = sheet;
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
    }

    // public class CellsColumns : IDependentModel, IInitializable, IDictionary<int, Cell>, ICreatesObjects
    // {
    // public Cell this[int key]
    // {
    // get
    // {
    // return this.cellsColumns[key];
    // }

    // set
    // {
    // this.cellsColumns[key] = value;
    // }
    // }

    // public virtual IDictionary<int, Cell> cellsColumns { get; set;}

    // public IIocContainer Container { get; set; }

    // public int Count
    // {
    // get
    // {
    // return this.cellsColumns.Count;
    // }
    // }

    // public bool IsReadOnly
    // {
    // get
    // {
    // return this.cellsColumns.IsReadOnly;
    // }
    // }

    // public ICollection<int> Keys
    // {
    // get
    // {
    // return this.cellsColumns.Keys;
    // }
    // }

    // public string UniqueID { get; set; }

    // public ICollection<Cell> Values
    // {
    // get
    // {
    // return this.cellsColumns.Values;
    // }
    // }

    // public void Add(KeyValuePair<int, Cell> item)
    // {
    // this.cellsColumns.Add(item);
    // }

    // public void Add(int key, Cell value)
    // {
    // this.cellsColumns.Add(key,value);
    // }

    // public void Clear()
    // {
    // this.cellsColumns.Clear();
    // }

    // public bool Contains(KeyValuePair<int, Cell> item)
    // {
    // return this.cellsColumns.Contains(item);
    // }

    // public bool ContainsKey(int key)
    // {
    // return this.cellsColumns.ContainsKey(key);
    // }

    // public void CopyTo(KeyValuePair<int, Cell>[] array, int arrayIndex)
    // {
    // throw new NotSupportedException("The Method CopyTo is not supported.");
    // }

    // public IEnumerator<KeyValuePair<int, Cell>> GetEnumerator()
    // {
    // return this.cellsColumns.GetEnumerator();
    // }

    // public void Init()
    // {
    // this.cellsColumns = this.Container.Resolve<IDictionary<int, Cell>>();
    // }

    // public bool Remove(KeyValuePair<int, Cell> item)
    // {
    // return this.cellsColumns.Remove(item);
    // }

    // public bool Remove(int key)
    // {
    // throw new NotSupportedException("The Method Remove is not supported.");
    // }

    // public bool TryGetValue(int key, out Cell value)
    // {
    // return this.cellsColumns.TryGetValue(key, out value);
    // }

    // IEnumerator IEnumerable.GetEnumerator()
    // {
    // return this.cellsColumns.GetEnumerator();
    // }
    // }
}