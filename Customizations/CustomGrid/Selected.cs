// *************************************************************************************
// <copyright company="Mobilize" file="Selected.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Class Selected.
    /// </summary>
    public class Selected : IDependentViewModel, ICreatesObjects, IInitializable<UltraGridBase>
    {


        #region Properties
        public string UniqueID { get; set; }

        /// <summary>
        /// Returns a reference to a collection of the selected UltraGridCell objects
        /// </summary>
		public virtual SelectedCellsCollection Cells { get; set; }

        /// <summary>
        /// Returns a reference to a collection of the selected UltraGridColumn objects.
        /// </summary>
		public virtual SelectedColsCollection Columns { get; set; }
        public IIocContainer Container { get; set; }
        public virtual Type ElementType { get; set; }
        public virtual Expression Expression { get; set; }
        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual UltraGridBase Grid { get; set; }
        public virtual IQueryProvider Provider { get; set; }

        /// <summary>
        /// Returns a reference to a collection of the selected UltraGridRow objects.
        /// </summary>
		public virtual SelectedRowsCollection Rows { get; set; }

        public virtual int[] _selectedRows { get; set; }

        public virtual int[] SelectedRowsIndices
        {
            get { return _selectedRows; }
            set { _selectedRows = value; }
        }

        /// <summary>
        /// Gets or sets the selected Cells list
        /// </summary>
        public virtual IList<UltraGridCell> SelectedCells { get; set; }

        /// <summary>
        /// Gets or sets the selected Columns list
        /// </summary>
        public virtual int[] _selectedColumnsIndices { get; set; }

        public virtual int[] SelectedColumnsIndices
        {
            get { return _selectedColumnsIndices; }
            set
            {
                _selectedColumnsIndices = value;
                if (Grid != null && Grid.Rows.Items.Count() > 0)
                {
                    SelectedCells.Clear();
                    for (int i = 0; i < Grid.Rows.Items.Count; i++)
                    {
                        for (int j = 0; j < _selectedColumnsIndices.Length; j++)
                        {
                            Grid.Rows[i].Cells[_selectedColumnsIndices[j]].Activate();
                        }
                    }
                }
            }
        }

        public void AddSelectedCell(UltraGridCell cell)
        {
            if (SelectedCells.Where(x => x.RowIndex == cell.RowIndex && x.Key == cell.Key).Count() == 0)
            {
                var cloneCell = Container.Resolve<UltraGridCell>(cell.Row);
                cloneCell.Key = cell.Key;
                cloneCell.RowIndex = cell.RowIndex;
                SelectedCells.Add(cloneCell);
            }
        }

        #endregion

        #region Methods
        public void Clear()
        {
            SelectedCells = Container.Resolve<IList<UltraGridCell>>();
            this.Cells = Container.Resolve<SelectedCellsCollection>();
            this.Columns = Container.Resolve<SelectedColsCollection>();
            this.Rows = Container.Resolve<SelectedRowsCollection>();
        }
        #endregion

        public void Build(IIocContainer ctx)
        {
            this.Columns = ctx.Resolve<SelectedColsCollection>();
            SelectedCells = ctx.Resolve<IList<UltraGridCell>>();
            _selectedRows = new int[0];
        }
        public void Init(UltraGridBase viewModel)
        {
            this.Grid = viewModel;
            this.Cells = this.Container.Resolve<SelectedCellsCollection>(this.Grid);
            this.Rows = this.Container.Resolve<SelectedRowsCollection>(this.Grid);
            this.Columns = this.Container.Resolve<SelectedColsCollection>(this.Grid);
        }

        public void Init()
        {
        }
    }

}