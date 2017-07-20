// *************************************************************************************
// <copyright company="Mobilize" file="SelectedCellsCollection.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Class SelectedCellsCollection.
    /// </summary>
    public class SelectedCellsCollection : IDependentViewModel, ICreatesObjects, IInitializable<CustomGrid>, IEnumerable<UltraGridCell>
    {
        public IIocContainer Container { get; set; }

        public string UniqueID { get; set; }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
        [StateManagement(StateManagementValues.None)]
        public virtual UltraGridCell[] All => this.CellsList.ToArray<UltraGridCell>();

        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; set; }

        [StateManagement(StateManagementValues.None)]
        /// <summary>
        /// Returns the number of elements in this collection.
        /// </summary>
        public int Count
        {
            get
            {
                var _CellsList = CellsList;
                return _CellsList == null ? 0 : _CellsList.Count;
            }
            set { }
        }

        public UltraGridCell this[int idx]
        {
            get
            {
                var _CellsList = CellsList;
                if (_CellsList == null) return null;
                return CellsList[idx];
            }
        }

        [StateManagement(StateManagementValues.None)]
        public IList<UltraGridCell> CellsList
        {
            get { return GetSelectedCells(); }
            set { }
        }

        private IList<UltraGridCell> GetSelectedCells()
        {
            IList<UltraGridCell> list = null;
            if (this.Grid != null && this.Grid.Rows != null)
            {
                list = Container.Resolve<IList<UltraGridCell>>();
                foreach (var cell in this.Grid.Selected.SelectedCells)
                {

                    var selectedCell = Grid.Rows[cell.RowIndex].Cells[cell.Key];
                    selectedCell.Selected = true;
                    list.Add(selectedCell);
                }
            }
            return list;
        }

        public void Build(IIocContainer ctx)
        {
        }

        public void Init(CustomGrid viewModel)
        {
            Grid = viewModel;
        }

        public void Init()
        {
        }

        public IEnumerator<UltraGridCell> GetEnumerator()
        {
            return CellsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CellsList.GetEnumerator();
        }
    }
}