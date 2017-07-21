// *************************************************************************************
// <copyright company="Mobilize" file="RowsCollection.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
	/// <summary>
	/// Class RowsCollection.
	/// </summary>
	public class RowsCollection : IDependentViewModel, ICreatesObjects, IInitializable<CustomGrid>
    {
		public string UniqueID { get; set; }

		public virtual IList<UltraGridRow> Items { get; set; }

		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual CustomGrid Grid { get; set; }

		public void Build(IIocContainer ctx)
		{
			Items = ctx.Resolve<IList<UltraGridRow>>();
		}

		public UltraGridRow this[int index]
		{
			get
			{
				if (Grid.DataSource != null)
					return RowByIndex(index);
				return Items[index];
			}
			set
			{
				Items[index] = value;
			}
		}


		[StateManagement(StateManagementValues.None)]
		public int Count => Grid.DataSource != null ? Grid.DataSourceCount : Items.Count;

		private UltraGridRow RowByIndex(int index)
		{
			var rowSelected = Grid.Selected.SelectedRowsIndices.Contains<int>(index);
			var selectCells = Grid.Selected.SelectedCells.Where<UltraGridCell>(x => x != null && x.RowIndex == index).ToList();
			if (Grid.DataSource is IList)
			{
				var dsCollection = (IList)Grid.DataSource;
				var currentRow = dsCollection[index];
				var dr = Container.Resolve<UltraGridRow>(this);
				dr.Selected = rowSelected;
				dr.Index = index;
				var props = Grid.Columns.Items.Select(col => col.Key).Distinct();
				var propIndex = 0;
				foreach (var prop in props)
				{
					var info = string.Empty;
					if (currentRow is JObject)
					{
                        var value = ((JObject)currentRow).GetValue(prop);
                        info = value != null ? value.ToString() : string.Empty;
                    }
					else
					{
						info = currentRow.GetType().GetProperty(prop).GetValue(currentRow, null) as string;
					}
					if (selectCells.Any())
					{
						var selectedCell = selectCells.Any<UltraGridCell>(x => x.Key == prop);
						dr.SetCellValue(propIndex, index, info, prop, selectedCell);
					}
					else
					{
						dr.SetCellValue(propIndex, index, info, prop);
					}
					propIndex++;
				}
				Grid.Rows[index] = dr;
				return dr;
			}
			return null;
		}

		public IIocContainer Container { get; set; }

		/// <summary>
		/// Returns the index of the item in the collection that has the passed in key or -1 if key not found.
		/// </summary>
		/// <param name="obj">The object whose index in the collection will be determined.</param>
		/// <returns>The index of the item in the collection that has the passed in key, or -1 if no item is found.</returns>
		public int IndexOf(object obj)
		{
			return Items.IndexOf(Items.FirstOrDefault(x => x.ItemContent == obj));
		}
		/// <summary>
		/// Clear this collection
		/// </summary>
		public void Clear()
		{
			Items.Clear();
		}
		public void Init(CustomGrid p1)
        {
            Grid = p1;
        }

        public void Init()
        {
        }
    }
}