// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="Columns.cs" >
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

    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     This class contains all the columns
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentModel" />
    public class Columns : IEnumerable<Column>, IDependentModel, ICreatesObjects, IInitializable<Cells>
    {
        public Columns()
        {
        }

        /// <summary>
        ///     Constructor with cells in order to have a reference to the possible count of columns and indexes
        /// </summary>
        /// <param name="cells"></param>
        public Columns(Cells cells)
        {
            this.cells = cells;
        }

        /// <summary>
        ///     The cells
        /// </summary>
        [StateManagement(StateManagementValues.ServerOnly)]

        public virtual Cells cells { get; set; }

        /// <summary>
        ///     Internal dictionary of columns using the index as the key
        /// </summary>
        public virtual IDictionary<int, Column> columns { get; set; }

        /// <summary>
        ///     Gets or sets the container.
        /// </summary>
        /// <value>
        ///     The container.
        /// </value>
        public IIocContainer Container { get; set; }

        /// <summary>
        ///     Gets the number of elements contained in the collection of columns.
        /// </summary>
        public int Count
        {
            get
            {
                return this.columns.Count;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly { get; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        /// <summary>
        ///     Returns or sets a column by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Column this[int index]
        {
            get
            {
                if (!this.columns.ContainsKey(index))
                {
                    Column newColumn = this.Container.Resolve<Column>(index, cells);
                    this.columns.Add(index, newColumn);
                }

                return this.columns[index];
            }

            set
            {
                if (this.columns.ContainsKey(index))
                {
                    this.columns[index] = value;
                }
                else
                {
                    this.columns.Add(index, value);
                }
            }
        }

        /// <summary>
        ///     Adds a new column at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        public void Add(int index, Column column)
        {
            if (!this.columns.ContainsKey(index))
                this.columns.Add(index, column);
        }


        /// <summary>
        ///     Clears the columns collection
        /// </summary>
        public void Clear()
        {
            this.columns.Clear();
        }


        /// <summary>
        ///     Returns a column by index
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public Column Get(int column)
        {
            return this[column];
        }

        /// <summary>
        ///     Enumerator implementation
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Column> GetEnumerator()
        {
            return this.columns.Values.GetEnumerator();
        }


        public void Init(Cells cells)
        {
            this.columns = this.Container.Resolve<IDictionary<int, Column>>();
            this.cells = cells;
        }

        public void Init()
        {
        }


        /// <summary>
        ///     Remove columns starting in a given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public void Remove(int index, int count)
        {
            int currIndex = index;
            for (int i = 0; i < count; i++)
            {
                this.columns.Remove(currIndex);
                currIndex++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Column : IDependentModel, IInitializable<int, Cells>
    {
        [StateManagement(StateManagementValues.ServerOnly)]

        public virtual Cells cells { get; set; }
        /// <summary>
        ///     Gets or sets the color of the back.
        /// </summary>
        /// <value>
        ///     The color of the back.
        /// </value>
        public virtual Color BackColor { get; set; }

        /// <summary>
        ///     Gets or sets the cell type of the column.
        /// </summary>
        /// <value>
        ///     The cell type of the column.
        /// </value>
        public virtual ICellType CellType { get; set; }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public virtual Font Font { get; set; }

        /// <summary>
        ///     Gets or sets the color of the fore.
        /// </summary>
        /// <value>
        ///     The color of the fore.
        /// </value>
        public virtual Color ForeColor { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal alignment.
        /// </summary>
        /// <value>
        ///     The horizontal alignment.
        /// </value>
        public virtual CellHorizontalAlignment HorizontalAlignment { get; set; }

        /// <summary>
        ///     Gets or sets the label.
        /// </summary>
        /// <value>
        ///     The label.
        /// </value>
        public virtual string Label { get; set; }

        /// <summary>
        /// Gets or sets the locked of the column.
        /// </summary>
        public virtual bool Locked { get; set; }

        /// <summary>
        ///     Gets or sets the resizable option
        /// </summary>
        /// <value>
        ///     The resizable value.
        /// </value>
        public virtual bool Resizable { get; set; }

        /// <summary>
        ///     Gets or sets the sort indicator.
        /// </summary>
        /// <value>
        ///     The sort indicator.
        /// </value>
        [Obsolete]
        public virtual SortIndicator SortIndicator { get; set; }

        /// <summary>
        ///     Gets or sets the name of the style.
        /// </summary>
        /// <value>
        ///     The name of the style.
        /// </value>
        public virtual string StyleName { get; set; }

        public string UniqueID { get; set; }

        /// <summary>
        ///     Gets or sets the vertical alignment.
        /// </summary>
        /// <value>
        ///     The vertical alignment.
        /// </value>
        public virtual CellVerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Column" /> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Visible { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        public virtual float Width { get; set; }

        public virtual int Index { get; set; }

        public void Init(int column, Cells cells)
        {
            this.cells = cells;
            this.Index = column;
        }

        public void Init()
        {
        }
    }

    public enum SortIndicator
    {
        SortIndicator,

        Descending,

        Ascending
    }
}