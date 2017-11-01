using System;
using System.Collections;
using System.Collections.Generic;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class DataGridViewSelectedCellCollection : IDependentViewModel, IEnumerable
	{
		public virtual IList<DataGridViewCellViewModel> Items { get; set; }

		public string UniqueID { get; set; }

		/// <summary>
		/// Gets the cell at the specified index.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public DataGridViewCellViewModel this[int index]
		{
			get { return this.Items[index]; }
			set { this.Items[index] = value; }
		}

		public void Build(IIocContainer ctx)
		{
			Items = ctx.Resolve<IList<DataGridViewCellViewModel>>();
		}

		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual int Count
		{
			get
			{
				return Items.Count;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return Items.GetEnumerator();
		}


	}
}