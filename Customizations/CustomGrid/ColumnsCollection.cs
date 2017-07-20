// *************************************************************************************
// <copyright company="Mobilize" file="ColumnsCollection.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid
{
    using System.Data;
    using System.Linq;

    using Custom.ViewModels.Grid.Extensions;
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Class ColumnsCollection.
    /// </summary>
    public class ColumnsCollection : IDependentViewModel, ICreatesObjects, IInitializable<UltraGridBand>
    {
        [Reference]
        [StateManagement(StateManagementValues.None)]
        /// <summary>
        /// The band
        /// </summary>
        public virtual UltraGridBand Band { get; set; }

        public virtual IList<UltraGridColumn> Items { get; set; }

        /// <summary>
        /// Gets the <see cref="UltraGridColumn"/> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>the UltraGridColumn.</returns>
        public UltraGridColumn this[string key]
        {
            get
            {
                return this.Items.FirstOrDefault(c => c.Key == key);
            }
            set
            {
                var index = Items.IndexOf(this.Items.FirstOrDefault(c => c.Key == key));
                if (index > -1)
                {
                    Items[index] = value;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UltraGridColumn this[int index]
        {
            get { return Items.ElementAt(index); }
            set
            {
                Items[index] = value;

            }
        }

        [StateManagement(StateManagementValues.None)]
        /// <summary>
        /// Returns the number of elements in this collection.
        /// </summary>
        public int Count => Items.Count;

        public IIocContainer Container { get; set; }

        public string UniqueID { get; set; }

        public void Build(IIocContainer ctx)
        {
            Items = Container.Resolve<IList<UltraGridColumn>>();
        }
        public IEnumerator<UltraGridColumn> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        /// <summary>
        /// Adds the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        internal void Add(System.Data.DataColumn column)
        {
            this.Band.ColumnList.Add(
                new UltraGridColumn
                {
                    Caption = column.Caption,
                    Key = column.ColumnName,
                    Style = column.DataType.ToStyle(),
                    Position = column.Ordinal
                });
        }
        public void Init(UltraGridBand band)
        {
            Band = band;
        }

        public void Init()
        {
        }
    }
}