// *************************************************************************************
// <copyright company="Mobilize" file="SelectedColsCollection.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Class SelectedColsCollection.
    /// </summary>
    public class SelectedColsCollection : IDependentViewModel, ICreatesObjects, IInitializable<CustomGrid>
    {
        [StateManagement(StateManagementValues.None)]
        public virtual UltraGridColumn[] All => this.ColumnsList.ToArray<UltraGridColumn>();

        [StateManagement(StateManagementValues.None)]
        /// <summary>
        /// Returns the number of elements in this collection.
        /// </summary>
        public int Count
        {
            get
            {
                var _ColumnsList = ColumnsList;
                return _ColumnsList == null ? 0 : _ColumnsList.Count;
            }
            set { }
        }

        [StateManagement(StateManagementValues.None)]
        public IList<UltraGridColumn> ColumnsList
        {
            get { return GetSelectedColumns(); }
            set { }
        }

        [StateManagement(StateManagementValues.None)]
        public virtual UltraGridColumn this[int index]
        {
            get { return this.ColumnsList[index]; }
            set { this.ColumnsList[index] = value; }
        }

        private IList<UltraGridColumn> GetSelectedColumns()
        {
            IList<UltraGridColumn> list = null;
            if (this.Grid != null)
            {
                list = Container.Resolve<IList<UltraGridColumn>>();
                foreach (var col in this.Grid.Selected.SelectedColumnsIndices)
                {

                    var selectedColumns = Grid.Columns[col];
                    selectedColumns.Selected = true;
                    list.Add(selectedColumns);

                }
            }
            return list;
        }

        public string UniqueID { get; set; }

        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; set; }

        public IIocContainer Container { get; set; }

        public void Build(IIocContainer ctx)
        {

        }

        public void Clear()
        {
            this.Grid.Selected.SelectedColumnsIndices = new int[0];
        }

        public IEnumerator<UltraGridColumn> GetEnumerator()
        {
            return this.ColumnsList.GetEnumerator();
        }

        public void Init()
        {

        }

        public void Init(CustomGrid grid)
        {
            Grid = grid;
        }
    }
}