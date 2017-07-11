// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="Rows.cs" >
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
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    public class Rows : IEnumerable<Row>, IDependentModel, IInitializable<Cells>, ICreatesObjects
    {
        /// <summary>
        ///     The cells
        /// </summary>
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Cells cells { get; set; }

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
                return this.rows.Count;
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
        ///     Internal dictionary of columns using the index as the key
        /// </summary>
        public virtual IDictionary<int, Row> rows { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        /// <summary>
        ///     Returns or sets a row by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Row this[int index]
        {
            get
            {
                if (this.rows.ContainsKey(index))
                {
                    return this.rows[index];
                }

                Row newRow = this.Container.Resolve<Row>(index, this.cells);
                this.rows.Add(index, newRow);
                return newRow;
            }

            set
            {
                if (this.rows.ContainsKey(index))
                {
                    this.rows[index] = value;
                }
                else
                {
                    this.rows.Add(index, value);
                }
            }
        }

        //public void Add(Row item)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        ///     Adds a new row at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        public void Add(int index, Row row)
        {
            if(!this.rows.ContainsKey(index))
                this.rows.Add(index, row);
        }

        /// <summary>
        ///     Clears the rows collection
        /// </summary>
        public void Clear()
        {
            this.rows.Clear();
        }

        public bool Contains(Row item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a row by index
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public Row Get(int row)
        {
            return this[row];
        }

        public IEnumerator<Row> GetEnumerator()
        {
            return this.rows.Values.GetEnumerator();
        }


        public void Init(Cells cells)
        {
            this.rows = this.Container.Resolve<IDictionary<int, Row>>();
            this.cells = cells;
        }

        public void Init()
        {
        }

        public void Insert(int index, Row item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Row item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Remove rows starting in a given index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public void Remove(int index, int count)
        {
            int currIndex = index;
            for (int i = 0; i < count; i++)
            {
                this.rows.Remove(currIndex);
                currIndex++;
            }
        }
        public void RemoveAt(int index)
        {
            this.rows.Remove(index);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void Add(int row, int count)
        {
            int rowIndex = row;
            for (int i = 0; i < count; i++)
            {
                this.Add(rowIndex, this.Container.Resolve<Row>(rowIndex, this.cells));
                rowIndex++;
            }
        }
    }

    public class Row : IDependentModel, IInitializable<int, Cells>
    {
        [StateManagement(StateManagementValues.ServerOnly)]

        public virtual Cells cells { get; set; }

        public virtual float Height { get; set; }

        public virtual string Label { get; set; }

        /// <summary>
        /// Gets or sets the locked of the row.
        /// </summary>
        public virtual bool Locked { get; set; }

        public virtual int Index { get; set; }

        [StateManagement(StateManagementValues.None)]
        [JsonIgnore]
        public IEnumerable<Cell> RowCells
        {
            get
            {
                return this.cells[this.Index];
            }
        }

        public virtual string StyleName { get; set; }

        public string UniqueID { get; set; }

        public virtual bool Visible { get; set; }
        
        public void Init(int row, Cells cells)
        {
            this.cells = cells;
            this.Index = row;
            Height = 16F;
        }

        public void Init()
        {
        }
    }
}