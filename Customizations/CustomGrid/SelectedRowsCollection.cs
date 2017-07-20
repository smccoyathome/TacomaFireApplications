// *************************************************************************************
// <copyright company="Mobilize" file="SelectedRowsCollection.cs" >
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
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
	public class SelectedRowsCollection : IDependentViewModel, ICreatesObjects, IInitializable<CustomGrid>
	{
		public IIocContainer Container { get; set; }

		public string UniqueID { get; set; }

		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual CustomGrid Grid { get; set; }

		public void Build(IIocContainer ctx)
		{

		}

		#region Properties
		[StateManagement(StateManagementValues.None)]
		public virtual UltraGridRow[] All => this.RowsList.ToArray<UltraGridRow>();

		[StateManagement(StateManagementValues.None)]
		public int Count
		{
			get
			{
				var _RowsList = RowsList;
				return _RowsList == null ? 0 : _RowsList.Count;
			}
			set { }
		}
		public virtual Type ElementType { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<UltraGridRow> RowsList
		{
			get { return GetSelectedRows(); }
			set { }
		}
		[StateManagement(StateManagementValues.None)]
		public virtual UltraGridRow this[int index]
		{
			get { return this.RowsList[index]; }
			set { this.RowsList[index] = value; }
		}
		#endregion

		#region Methods
		public void Add(UltraGridRow ultraGridRow)
		{
			ultraGridRow.Selected = true;
		}
		public void AddRange(UltraGridRow[] ultraGridRows)
		{
			foreach (var row in ultraGridRows)
			{
				row.Selected = true;
			}
		}
		public void Clear()
		{
			this.Grid.Selected.SelectedRowsIndices = new int[0];
		}
		public IEnumerator<UltraGridRow> GetEnumerator()
		{
			return this.RowsList.GetEnumerator();
		}
		private IList<UltraGridRow> GetSelectedRows()
		{
			IList<UltraGridRow> list = null;
			if (this.Grid != null && this.Grid.Rows != null)
			{
				list = Container.Resolve<IList<UltraGridRow>>();
				foreach (var row in this.Grid.Selected.SelectedRowsIndices)
				{

					var selectedRow = Grid.Rows[row];
					selectedRow.Selected = true;
					list.Add(selectedRow);

				}
			}
			return list;
		}
		#endregion

		public void Init()
		{

		}

		public void Init(CustomGrid viewModel)
		{
			Grid = viewModel;
		}
	}
}
