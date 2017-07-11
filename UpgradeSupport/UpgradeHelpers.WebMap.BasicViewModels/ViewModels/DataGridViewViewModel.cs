using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using UpgradeHelpers.BasicViewModels.Interfaces;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.BasicViewModels
{
	public enum DataGridViewSelectionMode
	{
		CellSelect, ColumnHeaderSelect, FullColumnSelect, FullRowSelect, RowHeaderSelect
	}
	public enum DataGridViewTriState
	{
		False, NotSet, True
	}
	public class DataGridColumnsViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<ColumnHeaderViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<ColumnHeaderViewModel> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<ColumnHeaderViewModel>>();
		}

	}

	public class DataGridRowsViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<DataGridRowViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<DataGridRowViewModel> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<DataGridRowViewModel>>();
		}
	}
	public class DataGridViewViewModel :  ControlViewModel, IDataGrid
	{
		/// <summary>
		/// Build Method
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			Columns = ctx.Resolve<DataGridColumnsViewModel>();
			Rows = ctx.Resolve<IList<DataGridRowViewModel>>();
			SelectedRowsIndices = ctx.Resolve<IList<int>>();
			SelectedColumnsIndices = ctx.Resolve<IList<int>>();
			GridPosition = new int[2];
			AllowUserToAddRows = true;
			AllowUserToDeleteRows = true;
			DataSourceVersion = 0;
			this.Enabled = true;
			this.Visible = true;
		}
		
		/// <summary>
		///  Gets or sets the current column definitions  for this control
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual DataGridColumnsCollection DataGridColumns
		{
			get { return new DataGridColumnsCollection(this); }
		}

		public virtual DataGridColumnsViewModel Columns { get; set; }

		[StateManagement(StateManagementValues.None)]
		public DataGridViewSelectedColumnsCollection SelectedColumns => new DataGridViewSelectedColumnsCollection(this);

		/// <summary>
		/// Gets or sets the current rows definition for this control
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual DataGridRowsCollection DataGridRows
		{
			get { return new DataGridRowsCollection(this); }
		}

		public virtual IList<DataGridRowViewModel> Rows { get; set; }

		[StateManagement(StateManagementValues.None)]
		public DataGridViewSelectedRowCollection SelectedRows
		{
			get { return new DataGridViewSelectedRowCollection(this); }
		}

		/// <summary>
		/// Gets or Sets SelectionMode property
		/// </summary>
		public virtual DataGridViewSelectionMode SelectionMode { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the user can edit the cells of the control.
		/// </summary>
		/// 
		[DefaultValue(false)]
		public virtual bool ReadOnly { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[DefaultValue(true)]
		public virtual bool AllowUserToAddRows { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[DefaultValue(false)]
		public virtual bool AllowUserToDeleteRows { get; set; }

		/// <summary>
		/// Stores the selected rows
		/// </summary>
		public virtual int[] SelectedIndices { get; set; }

		public virtual IList<int> SelectedRowsIndices { get; set; }
		public virtual IList<int> SelectedColumnsIndices { get; set; }

		public virtual int[] SelectedCoordinates
		{
			get { return SelectedIndices; }
			set
			{
				//CellSelect, ColumnHeaderSelect, FullColumnSelect, FullRowSelect, RowHeaderSelect
				SelectedIndices = value;
				if (SelectedIndices == null || SelectedColumnsIndices == null || SelectedRowsIndices == null) return;
				switch (SelectionMode)
				{
					case DataGridViewSelectionMode.CellSelect:
						if (SelectedIndices.Length >= 2)
						{
							SelectedRowsIndices.Clear();
							SelectedColumnsIndices.Clear();
							var row = SelectedIndices[0];
							var col = SelectedIndices[1];
							SelectedColumnsIndices.Insert(0, col);
							SelectedRowsIndices.Insert(0, row);
						}
						break;
					case DataGridViewSelectionMode.FullRowSelect:
					case DataGridViewSelectionMode.RowHeaderSelect:
						SelectedRowsIndices.Clear();
						SelectedColumnsIndices.AddRange(value);
						break;
					case DataGridViewSelectionMode.ColumnHeaderSelect:
					case DataGridViewSelectionMode.FullColumnSelect:
						SelectedRowsIndices.Clear(); ;
						SelectedColumnsIndices.AddRange(value);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}



		//Gets or sets the value on an specific datagrid cell
		[StateManagement(StateManagementValues.None)]
		public DataGridViewCellViewModel this[int columnIndex, int rowIndex]
		{
			get
			{
				if (rowIndex < this.Rows.Count)
				{
					//Check rowIndex
					var selectedRow = this.Rows[rowIndex];
					if (columnIndex < selectedRow.ItemContent.Length)
					{
						var cell = StaticContainer.Instance.Resolve<DataGridViewCellViewModel>();
						cell.Value = selectedRow.ItemContent[columnIndex];
						return cell;
					}
					else
						return null;
				}
				else
					return null;
			}
			set
			{
				if (rowIndex < this.Rows.Count)
				{
					//Check rowIndex
					var selectedRow = this.Rows[rowIndex];
					if (columnIndex < selectedRow.ItemContent.Length)
					{
						selectedRow.ItemContent[columnIndex] = value.Value.ToString();
					}
				}
			}
		}

		/// <summary>
		/// Sets the cell inner value
		/// </summary>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <param name="value"></param>
		public void SetCellValue(int column = -1, int row = -1, object value = null)
		{
			if (column <= -1 || row <= -1 || value == null) return;
			var cellValue = value as DataGridViewCellViewModel;
			if (cellValue != null)
				value = cellValue.Value.ToString();
			var selectedRow = this.Rows[row];
			if (column < selectedRow.ItemContent.Length)
			{
				selectedRow.SetColumnValue(column, value.ToString());
			}
		}


		[StateManagement(StateManagementValues.None)]
		public DataGridViewCellViewModel this[string columnName, int rowIndex]
		{
			get
			{
				if (rowIndex < this.Rows.Count)
				{
					//Check rowIndex
					var selectedColumn = DataGridColumns.IndexOf(columnName);
					if (selectedColumn > -1)
					{
						return this[selectedColumn, rowIndex];
					}
					return null;
				}
				return null;
			}
			set
			{
				if (rowIndex < this.Rows.Count)
				{
					//Check rowIndex
					var selectedRow = this.Rows[rowIndex];
					var selectedColumn = DataGridColumns.IndexOf(columnName);
					if (selectedColumn > -1)
					{
						selectedRow.ItemContent[selectedColumn] = value.Value.ToString();
					}
				}
			}
		}

		//Gets the row containing the current cell.
		[StateManagement(StateManagementValues.ServerOnly)]
		public DataGridRowViewModel CurrentRow
		{
			get
			{
				if (DataGridRows.Count > GridPosition[0])
					return this.DataGridRows[GridPosition[0]];
				return null;
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "This method is hidden by design")]
		int IDataGrid.RowCount()
		{
			if (DataSource != null)
			{
				return ((DataTable)DataSource).Rows.Count;
			}
			return Rows.Count;
		}

		public IEnumerable<IGridRow> GetRows(int skip, int take)
		{
			var current = skip;
			var rowsCount = this._dataSource.DefaultView.Count;
			Rows = StaticContainer.Instance.Resolve<IList<DataGridRowViewModel>>();
			;
			for (var i = 0; i < take; i++)
			{
				if (i < rowsCount && current < rowsCount)
				{
					var dataRowView = this._dataSource.DefaultView[current];
					var dr = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
					dr.ItemContent = dataRowView.Row.ItemArray;
					Rows.Add(dr);
				}
				else
				{
					break;
				}
				current++;
			}
			return Rows;
		}

		public virtual int DataSourceVersion { get; set; }


		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual System.Data.DataTable _dataSource { get; set; }

		//Gets or sets the data source that the DataGridView is displaying data for.
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual object DataSource
		{
			get { return _dataSource; }
			set
			{
				if (value is System.Data.DataTable)
				{
					_dataSource = value as DataTable;
					DataGridColumns.Clear();
					DataSourceVersion++;
					foreach (var column in _dataSource.Columns)
					{
						DataGridColumns.Add(column.ToString(), column.ToString());
					}
				}
			}
		}

		//	Gets or sets the number of rows displayed in the DataGridView.
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual int RowCount
		{
			get { return this.DataGridRows.Count; }
		}

		public virtual int[] GridPosition { get; set; }


		public virtual int ColumnCount
		{
			get { return this.Columns.Items.Count; }
		}

		[Handler()]
		public void AddNewRow(Object eventSender, EventArgs eventArgs)
		{
			this.DataGridRows.Add(1);
		}

		[Handler()]
		public void RemoveRow(int rowID)
		{
			this.DataGridRows.RemoveAt(rowID);
		}

		[Handler()]
		public void UpdateRow(int row, int col, string value)
		{
			this.DataGridRows.UpdateContent(row, col, value);
		}

		[Handler()]
		public void UpdateRowSelectedStatus(int row, bool isSelected)
		{
			this.DataGridRows[row].IsSelected = isSelected;
		}

		[Handler()]
		public void UpdateColumnSelectedStatus(int column, bool isSelected)
		{
			this.DataGridColumns[column].IsSelected = isSelected;
		}

	}

	//Wrapper class Columns list View Model

	#region ColumnsCollection

	public class DataGridColumnsCollection : IEnumerable
	{
		DataGridViewViewModel _viewModel;

		internal DataGridColumnsCollection(DataGridViewViewModel viewModel)
		{
			this._viewModel = viewModel;
		}

		private IEnumerable<ColumnHeaderViewModel> AllItems()
		{
			for (int i = 0; i < this._viewModel.Columns.Items.Count; i++)
			{
				yield return _viewModel.Columns.Items[i];
			}
		}

		private IEnumerable<ColumnHeaderViewModel> SelectedItems()
		{
			for (int i = 0; i < this._viewModel.Columns.Items.Count; i++)
			{
				yield return _viewModel.Columns.Items[i];
			}
		}

		public int IndexOf(object item)
		{
			if (item is ColumnHeaderViewModel)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem == item)
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}
			else if (item is string)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem.Text.Equals(item) || innerItem.Name.Equals(item))
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}
			else
				return -1;
		}

		public void Insert(int index, ColumnHeaderViewModel item)
		{
			_viewModel.Columns.Items.Insert(index, item);
			InsertNewItem(index);
		}

		private void InsertNewItem(int index, string item = "")
		{
			foreach (var row in _viewModel.DataGridRows)
			{
				var newArray = new string[row.ItemContent.Length + 1];
				row.ItemContent.CopyTo(newArray, 0);
				for (var i = index; i < newArray.Length; i++)
				{
					var currVal = newArray[i];
					newArray[i] = item;
					item = currVal;
				}
				row.ItemContent = newArray;
			}
		}

		public void Insert(int index, string item)
		{
			ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
			newItem.Text = item.ToString();
			newItem.Name = item.ToString();
			_viewModel.Columns.Items.Insert(index, newItem);
			InsertNewItem(index, item);
		}

		private int IndexOfItem(ColumnHeaderViewModel item)
		{
			int innerIndex = -1;
			for (int i = 0; i < this._viewModel.Columns.Items.Count; i++)
			{
				if (item == _viewModel.Columns.Items[i])
				{
					innerIndex = i;
				}
			}
			return innerIndex;
		}

		public void RemoveAt(int index)
		{
			if (_viewModel.Columns.Items.Count > 0)
			{
				_viewModel.Columns.Items.RemoveAt(index);
				_viewModel.DataGridRows.RemoveColumn(index);
			}
		}

		public ColumnHeaderViewModel this[int index]
		{
			get { return SelectedItems().ElementAt(index); }
			set { throw new NotImplementedException(); }
		}

		public ColumnHeaderViewModel this[string name]
		{
			get { return SelectedItems().FirstOrDefault(col => col.Name.Equals(name)); }
			set { throw new NotImplementedException(); }
		}

		public void Add(Object item)
		{
			if (item is ColumnHeaderViewModel)
			{
				var column = (ColumnHeaderViewModel)item;
				ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
				newItem.Name = column.Name;
				newItem.Text = column.Text;
				newItem.Width = column.Width;
				newItem.Index = _viewModel.Columns.Items.Count;
				newItem.ReadOnly = column.ReadOnly;
				_viewModel.Columns.Items.Add(newItem);
				ResizeItems();
			}
			else
			{
				ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
				newItem.Text = item.ToString();
				newItem.Name = item.ToString();
				_viewModel.Columns.Items.Add(newItem);
				ResizeItems();
			}
		}

		public void Add(string columnName, string headerText)
		{
			ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
			newItem.Name = columnName;
			newItem.Text = headerText;
			_viewModel.Columns.Items.Add(newItem);
			ResizeItems();
		}

		private void ResizeItems()
		{
			foreach (var row in _viewModel.DataGridRows)
			{
				row.Resize(_viewModel.DataGridColumns.Count);
			}
		}

		public void AddRange(object[] Columns)
		{
			foreach (var item in Columns)
			{
				if (item is string)
				{
					ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
					newItem.Name = item.ToString();
					newItem.Text = item.ToString();
					_viewModel.Columns.Items.Add(newItem);
				}
				else if (item is ColumnHeaderViewModel)
				{
					var column = (ColumnHeaderViewModel)item;
					ColumnHeaderViewModel newItem = StaticContainer.Instance.Resolve<ColumnHeaderViewModel>();
					newItem.Name = column.Name;
					newItem.Text = column.Text;
					newItem.Width = column.Width;
					newItem.ReadOnly = column.ReadOnly;
					_viewModel.Columns.Items.Add(newItem);
				}
			}
			ResizeItems();
		}

		public void Clear()
		{
			_viewModel.Columns.Items.Clear();
			ResizeItems();
		}

		public bool Contains(ColumnHeaderViewModel item)
		{
			return SelectedItems().Any(innerItem => innerItem == item);
		}

		public bool Contains(string item)
		{
			return SelectedItems().Any(innerItem => innerItem.Text.Equals(item));
		}

		public void CopyTo(ColumnHeaderViewModel[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return SelectedItems().Count(); }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public bool Remove(ColumnHeaderViewModel item)
		{
			this.RemoveAt(IndexOfItem(item));
			return true;
		}

		public IEnumerator<ColumnHeaderViewModel> GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}
	}

	#endregion

	//Wrapper class Rows list view Model

	#region RowsCollection

	public class DataGridRowsCollection : IEnumerable
	{
		DataGridViewViewModel _viewModel;

		internal DataGridRowsCollection(DataGridViewViewModel viewModel)
		{
			this._viewModel = viewModel;
		}

		private IEnumerable<DataGridRowViewModel> SelectedItems()
		{
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				yield return _viewModel.Rows[i];
			}
		}

		public int IndexOf(object item)
		{
			if (item is DataGridRowViewModel)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem == item)
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}
			else if (item is string)
			{
				int result = -1;
				int i = 0;
				foreach (var innerItem in SelectedItems())
				{
					if (innerItem.Text.Equals(item))
					{
						result = i;
						break;
					}
					i++;
				}
				return result;
			}
			else
				return -1;
		}

		public void Insert(int index, DataGridRowViewModel item)
		{
			_viewModel.Rows.Insert(index, item);
		}

		public void Insert(int index, string item)
		{
			DataGridRowViewModel newItem = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
			newItem.Text = item.ToString();
			newItem.Name = item.ToString();
			_viewModel.Rows.Insert(index, newItem);
		}

		private int IndexOfItem(DataGridRowViewModel item)
		{
			int innerIndex = -1;
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				if (item == _viewModel.Rows[i])
				{
					innerIndex = i;
				}
			}
			return innerIndex;
		}

		public void RemoveAt(int index)
		{
			if (_viewModel.Rows.Count > 0)
				_viewModel.Rows.RemoveAt(index);
		}

		public void RemoveColumn(int colIndex)
		{
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				for (int a = colIndex; a < this._viewModel.Rows[i].ItemContent.Length - 1; a++)
				{
					// moving elements downwards, to fill the gap at [index]
					this._viewModel.Rows[i].ItemContent[a] = this._viewModel.Rows[i].ItemContent[a + 1];
				}
				// finally, let's decrement Array's size by one
				var itemContent = this._viewModel.Rows[i].ItemContent;
				Array.Resize(ref itemContent, this._viewModel.Rows[i].ItemContent.Length - 1);
				this._viewModel.Rows[i].ItemContent = itemContent;
			}
		}

		public DataGridRowViewModel this[int index]
		{
			get { return SelectedItems().ElementAt(index); }
			set { throw new NotImplementedException(); }
		}

		public void Add(Object item)
		{
			if (item is DataGridRowViewModel)
			{
				DataGridRowViewModel value = ((DataGridRowViewModel)item);
				_viewModel.Rows.Add(value);
			}
			else if (item is int)
			{
				var length = (int)item;
				for (var i = 0; i < length; i++)
				{
					DataGridRowViewModel newItem = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
					newItem.Text = "";
					newItem.Name = "";
					newItem.Resize(_viewModel.Columns.Items.Count);
					_viewModel.Rows.Add(newItem);
				}
			}
			else
			{
				DataGridRowViewModel newItem = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
				newItem.Text = item.ToString();
				newItem.Name = item.ToString();
				_viewModel.Rows.Add(newItem);
			}
		}

		public void Add(params object[] values)
		{
			DataGridRowViewModel newItem = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
			newItem.Text = "";
			newItem.Name = "";
			newItem.Resize(_viewModel.Columns.Items.Count);
			var i = 0;
			foreach (var p in values)
			{
				if (i < _viewModel.Columns.Items.Count)
					newItem.SetColumnValue(i, p.ToString());
				i++;
			}
			_viewModel.Rows.Add(newItem);
		}

		public void AddRange(object[] rows)
		{
			foreach (var item in rows)
			{
				if (item is string)
				{
					DataGridRowViewModel newItem = StaticContainer.Instance.Resolve<DataGridRowViewModel>();
					newItem.Name = item.ToString();
					newItem.Text = item.ToString();
					_viewModel.Rows.Add(newItem);
				}
				else if (item is DataGridRowViewModel)
				{
					_viewModel.Rows.Add((DataGridRowViewModel)item);
				}
			}
		}

		public void Clear()
		{
			if (_viewModel.Rows != null)
				_viewModel.Rows.Clear();
		}

		public void UpdateContent(int row, int col, string value)
		{
			_viewModel.Rows[row].SetColumnValue(col, value);
		}

		public bool Contains(DataGridRowViewModel item)
		{
			return SelectedItems().Any(innerItem => innerItem == item);
		}

		public bool Contains(string item)
		{
			return SelectedItems().Any(innerItem => innerItem.Text.Equals(item));
		}

		public void CopyTo(DataGridRowViewModel[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return SelectedItems().Count(); }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public bool Remove(DataGridRowViewModel item)
		{
			this.RemoveAt(IndexOfItem(item));
			return true;
		}

		public IEnumerator<DataGridRowViewModel> GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}
	}

	#endregion

	#region RowViewModel

	public class DataGridRowViewModel : IDependentViewModel, IGridRow
    {
		public string UniqueID { get; set; }

		private object[] _itemContent = new string[1] { "" };

		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual object[] Cells
		{
			get { return ItemContent; }
			set { ItemContent = value; }
		}

		public virtual int Width { get; set; }

		public virtual int Height { get; set; }

		public virtual int Index { get; set; }

		public virtual object[] ItemContent
		{
			get { return _itemContent; }
			set
			{
				var tmp = value;
				if (tmp != null)
				{
					if (tmp.Length > _itemContent.Length)
					{
						object[] bckup = _itemContent;
						object[] newArray = new object[tmp.Length];
						Array.Copy(bckup, newArray, bckup.Length);
						string[] items = newArray.Select(toString).ToArray();
						// ReSharper disable once CoVariantArrayConversion
						_itemContent = items;
					}
					for (var i = 0; i < tmp.Length; i++)
					{
						if (tmp[i] == null) continue;
						_itemContent[i] = tmp[i].ToString();
					}
				}
			}
		}

		private string toString(object val)
		{
			if (val != null)
			{
				return val.ToString();
			}
			return string.Empty;
		}

		public virtual string Name { get; set; }
		public virtual string Text { get; set; }

		public virtual bool IsSelected { get; set; }

		public void Build(IIocContainer ctx)
		{
			ItemContent = new string[1];
		}

		public void SetColumnValue(int item, string value)
		{
			if (ItemContent.Length > item)
			{
				var tmpArray = ItemContent;
				tmpArray[item] = value;
				// Force marking this property as 'dirty'
				ItemContent = null;
				ItemContent = tmpArray;
			}
			else
			{
				object[] tmp = ItemContent;
				string[] newArray = new string[item + 1];
				Array.Copy(tmp, newArray, tmp.Length);
				newArray[item] = value;
				ItemContent = newArray;
			}
		}


		internal void Resize(int colCont)
		{
			if (ItemContent.Length != colCont)
			{
				if (ItemContent.Length > colCont)
				{
					object[] tmp = ItemContent;
					string[] newArray = new string[colCont];
					Array.Copy(tmp, newArray, colCont);
					ItemContent = newArray;
				}
				else if (ItemContent.Length < colCont)
				{
					object[] tmp = ItemContent;
					string[] newArray = new string[colCont];

					Array.Copy(tmp, newArray, tmp.Length);
					for (int i = tmp.Length; i < colCont; i++)
					{
						newArray[i] = "";
					}
					ItemContent = newArray;
				}
			}
		}
	}

	#endregion

	#region SelectedRowsCollection

	public class DataGridViewSelectedRowCollection : IList<DataGridRowViewModel>
	{
		DataGridViewViewModel _viewModel;

		internal DataGridViewSelectedRowCollection(DataGridViewViewModel viewModel)
		{
			this._viewModel = viewModel;
		}

		private IEnumerable<DataGridRowViewModel> AllItems()
		{
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				yield return _viewModel.Rows[i];
			}
		}

		private IEnumerable<DataGridRowViewModel> SelectedItems()
		{
			for (int i = 0; i < this._viewModel.SelectedRowsIndices.Count; i++)
			{
				yield return _viewModel.Rows[_viewModel.SelectedRowsIndices[i]];
			}
		}

		public int IndexOf(DataGridRowViewModel item)
		{
			int result = -1;
			int i = 0;
			foreach (var innerItem in SelectedItems())
			{
				if (innerItem == item)
				{
					result = i;
					break;
				}
				i++;
			}
			return result;
		}

		public void Insert(int index, DataGridRowViewModel item)
		{
			int innerIndex = IndexOfItem(item);
			_viewModel.SelectedRowsIndices.Add(innerIndex);
			this._viewModel.Rows[innerIndex].IsSelected = true;
		}

		public int IndexOfItem(DataGridRowViewModel item)
		{
			int innerIndex = -1;
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				if (item == _viewModel.Rows[i])
				{
					innerIndex = i;
				}
			}
			return innerIndex;
		}

		public void RemoveAt(int index)
		{
			_viewModel.SelectedRowsIndices.Remove(index);
			this._viewModel.Rows[index].IsSelected = false;
		}

		public DataGridRowViewModel this[int index]
		{
			get { return SelectedItems().ElementAt(index); }
			set { throw new NotImplementedException(); }
		}

		public void Add(DataGridRowViewModel item)
		{
			int innerIndex = IndexOfItem(item);
			_viewModel.SelectedRowsIndices.Add(innerIndex);
			this._viewModel.Rows[innerIndex].IsSelected = true;
		}

		public void Clear()
		{
			for (int i = 0; i < this._viewModel.Rows.Count; i++)
			{
				if (this._viewModel.Rows[i].IsSelected)
				{
					_viewModel.Rows[i].IsSelected = false;
				}
			}
		}

		public bool Contains(DataGridRowViewModel item)
		{
			return SelectedItems().Any(innerItem => innerItem == item);
		}

		public void CopyTo(DataGridRowViewModel[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return SelectedItems().Count(); }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public bool Remove(DataGridRowViewModel item)
		{
			var innerIndex = IndexOfItem(item);
			this.RemoveAt(innerIndex);
			return true;
		}

		public IEnumerator<DataGridRowViewModel> GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}
	}

	#endregion

	#region SelectedColumnsCollection

	public class DataGridViewSelectedColumnsCollection : IList<ColumnHeaderViewModel>
	{
		DataGridViewViewModel _viewModel;

		internal DataGridViewSelectedColumnsCollection(DataGridViewViewModel viewModel)
		{
			this._viewModel = viewModel;
		}

		private IEnumerable<ColumnHeaderViewModel> AllItems()
		{
			for (int i = 0; i < this._viewModel.DataGridColumns.Count; i++)
			{
				yield return _viewModel.DataGridColumns[i];
			}
		}

		private IEnumerable<ColumnHeaderViewModel> SelectedItems()
		{
			for (int i = 0; i < this._viewModel.SelectedColumnsIndices.Count; i++)
			{
				yield return _viewModel.DataGridColumns[_viewModel.SelectedColumnsIndices[i]];
			}
		}

		public int IndexOf(ColumnHeaderViewModel item)
		{
			int result = -1;
			int i = 0;
			foreach (var innerItem in SelectedItems())
			{
				if (innerItem == item)
				{
					result = i;
					break;
				}
				i++;
			}
			return result;
		}

		public void Insert(int index, ColumnHeaderViewModel item)
		{
			int innerIndex = IndexOfItem(item);
			_viewModel.SelectedColumnsIndices.Add(innerIndex);
			this._viewModel.DataGridColumns[innerIndex].IsSelected = true;
		}

		public int IndexOfItem(ColumnHeaderViewModel item)
		{
			int innerIndex = -1;
			for (int i = 0; i < this._viewModel.DataGridColumns.Count; i++)
			{
				if (item == _viewModel.DataGridColumns[i])
				{
					innerIndex = i;
				}
			}
			return innerIndex;
		}

		public void RemoveAt(int index)
		{
			_viewModel.SelectedColumnsIndices.Remove(index);
			this._viewModel.DataGridColumns[index].IsSelected = false;
		}

		public ColumnHeaderViewModel this[int index]
		{
			get { return SelectedItems().ElementAt(index); }
			set { throw new NotImplementedException(); }
		}

		public void Add(ColumnHeaderViewModel item)
		{
			int innerIndex = IndexOfItem(item);
			_viewModel.SelectedColumnsIndices.Add(innerIndex);
			this._viewModel.DataGridColumns[innerIndex].IsSelected = true;
		}

		public void Clear()
		{
			_viewModel.SelectedColumnsIndices.Clear();
			for (int i = 0; i < this._viewModel.DataGridColumns.Count; i++)
			{
				if (this._viewModel.DataGridColumns[i].IsSelected)
				{
					_viewModel.DataGridColumns[i].IsSelected = false;
				}
			}
		}

		public bool Contains(ColumnHeaderViewModel item)
		{
			return SelectedItems().Any(innerItem => innerItem == item);
		}

		public void CopyTo(ColumnHeaderViewModel[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return SelectedItems().Count(); }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		public bool Remove(ColumnHeaderViewModel item)
		{
			this.RemoveAt(IndexOfItem(item));
			return true;
		}

		public IEnumerator<ColumnHeaderViewModel> GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.SelectedItems().GetEnumerator();
		}
	}

	#endregion
}
