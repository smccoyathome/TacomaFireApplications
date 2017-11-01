using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class DataGridViewCellCollectionViewModel : IDependentViewModel, IEnumerable, IInitializable<DataGridRowViewModel>
	{
		public string UniqueID { get; set; }

		public void Build(IIocContainer ctx)
		{
			Cells = ctx.Resolve<IList<DataGridViewCellViewModel>>();
		}

		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual IList<DataGridViewCellViewModel> Cells { get; set; }


		public IEnumerator<DataGridViewCellViewModel> GetEnumerator()
		{
			return this.Cells.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual int Count {
			get
			{
				return Cells.Count();
			}
		}

		[Reference]
		public DataGridRowViewModel Row { get; set; }

		public virtual DataGridViewCellViewModel this[int index]
		{
			get { return Cells.ElementAt(index); }
			set
			{
				Cells[index] = value;
				Cells[index].ColumnIndex = index;
				if (Row.DataGridView != null)
				{
					Cells[index].DataGridView = Row.DataGridView;
				}

			}
		}

		/// <summary>
		/// Gets o sets a cell value
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public virtual DataGridViewCellViewModel this[string key]
		{
			get
			{
				if (this.Row.DataGridView != null)
				{
					return this.Cells[this.Row.DataGridView.DataGridColumns[key].Index];
				}
				return null;
			}
			set
			{
				if (this.Row.DataGridView != null)
				{
					this.Cells[this.Row.DataGridView.DataGridColumns[key].Index] = value;
				}
			}
		}

		/// <summary>
		/// This method sets the cell value
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		public void SetCellValue(int column = -1, object value = null)
		{
			if (column <= -1 ||  value == null)
				return;
			var cellValue = value as DataGridViewCellViewModel;
			if (cellValue != null)
				value = cellValue.Value.ToString();
			var selectedRow = Row;
			if (column < selectedRow.ItemContent.Length)
			{
				selectedRow.Cells[column].Value = value;
			}
		}

		/// <summary>
		/// This method sets the cell value
		/// </summary>
		/// <param name="columnKey"></param>
		/// <param name="value"></param>
		public void SetCellValue(string columnKey = null, object value = null)
		{
			if (columnKey == null|| value == null)
				return;
			var cellValue = value as DataGridViewCellViewModel;
			if (cellValue != null)
				value = cellValue.Value.ToString();
			var selectedRow = Row;
			if (selectedRow.DataGridView != null)
			{
				int columnIndex = selectedRow.DataGridView.DataGridColumns[columnKey].Index;
				if (columnIndex < selectedRow.ItemContent.Length)
				{
					selectedRow.Cells[columnIndex].Value = value;
				}
			}
		}

		public void Init(DataGridRowViewModel row)
		{
			this.Row = row;
		}

		public void Init()
		{
		}

		public void Add(DataGridViewCellViewModel cell)
		{
			Cells.Add(cell);
		}
	}
}
