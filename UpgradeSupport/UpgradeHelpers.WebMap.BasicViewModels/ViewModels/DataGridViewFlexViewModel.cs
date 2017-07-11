using System;
using System.Collections.ObjectModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.BasicViewModels;
using UpgradeHelpers.Events;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server;
using Newtonsoft.Json;


namespace UpgradeHelpers.BasicViewModels
{
	// Summary:
	//     Defines constants that indicate the alignment of content within a System.Windows.Forms.DataGridView
	//     cell.
	public enum DataGridViewContentAlignment
	{
		NotSet = 0,
		TopLeft = 1,
		TopCenter = 2,
		TopRight = 4,
		MiddleLeft = 16,
		MiddleCenter = 32,
		MiddleRight = 64,
		BottomLeft = 256,
		BottomCenter = 512,
		BottomRight = 1024,
	}
	/// <summary>
	///  ViewModel for DataGridViewFlex grids
	/// </summary>
	public class DataGridViewFlexViewModel
		: ControlViewModel
	{


		/// <summary>
		///   Fixed rows number ( only 0 and 1 are supported in this version)
		/// </summary>
		public virtual int FixedRowsCount { get; set; }

		/// <summary>
		///   Fixed column number ( only 0 is supported in this version)
		/// </summary>
		public virtual System.Int32 FixedColumns { get; set; }

		/// <summary>
		///   Rows of this grid
		/// </summary>
		public virtual GridContent Content { get; set; }
		
		/// <summary>
		/// Gets or sets the CellBackColor for the flexgrid
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual Color CellBackColor
		{
			get
			{
				if (GridPosition == null || CurrentRowIndex < 0 || CurrentColumnIndex < 0)
				{
					return Color.Transparent;
				}
				return CellColors == null ? Color.Transparent : CellColors[CurrentRowIndex, CurrentColumnIndex];
			}
			set
			{
				if (CellColors == null)
				{
					CellColors = new Color[_rowCount, _colCount];
				}
				CellColors[CurrentRowIndex, CurrentColumnIndex] = value;
				UpdateCellColor();
			}
		}

		/// <summary>
		/// Forces an update of the GridPosition property by setting to null and then back to the original value
		/// </summary>
		private void UpdateCellColor()
		{
			var tmp = CellColors;
			CellColors = null;
			CellColors = tmp;
		}

		/// <summary>
		/// Saves the current background color for each grid's cell
		/// </summary>
		public virtual Color[,] CellColors { get; set; }

		/// <summary>
		///   Storage attribute for rows count
		/// </summary>
		public virtual int _rowCount { get; set; }

		/// <summary>
		///   Storage attribute for columnscount
		/// </summary>
		public virtual int _colCount { get; set; }

		/// <summary>
		///  Flag to indicate if the grid's data must be refreshed 
		/// </summary>
		public virtual bool NeedsRefresh { get; set; }
		public virtual int[] GridPosition { get; set; }


		

	

		/// <summary>
		///   Grid coordinates
		///   
		///   This propery holds an array of two element with the position of the current cell
		/// </summary>
		public virtual int[] GridCellCoordinates { get; set; }

		/// <summary>
		/// Grid Selected cells
		/// </summary>
		public virtual int[,] GridSelectedCells { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual int[] GridEndSelectionCoordinates { get; set; }


		/// <summary>
		///   Additional data associated with each column
		/// </summary>
		public virtual int[] ColData { get; set; }


	
		/// <summary>
		/// Gets or sets the ColAlignment for the control
		/// </summary>
		private DataGridViewContentAlignment[] _colAlignment = new DataGridViewContentAlignment[0];
		public virtual DataGridViewContentAlignment[] ColAlignment
		{
			get
			{
				if (_colAlignment.Length < ColumnsCount)
				{
					return new DataGridViewContentAlignment[ColumnsCount];
				}
				return _colAlignment;
			}
			set
			{
				_colAlignment = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DataGridViewFlexViewModel()
		{
		}

		/// <summary>
		///  Control initalization
		/// </summary>
		/// <param name="ctx"></param>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// Name DefaultValue
			Name = "DataGridViewFlexViewModel";
			Columns = ctx.Resolve<FlexGridColumnsViewModel>();
			Content = ctx.Resolve<GridContent>();
			GridPosition = new int[2];
			GridEndSelectionCoordinates = new int[2];
			GridCellCoordinates = new int[4];
			GridSelectedCells = new int[0, 0];
			FixedRowsCount = 1;
			Visible = true;


		}

		[StateManagement(StateManagementValues.None)]
		public virtual System.Int32 FixedRows
		{
			get
			{
				return FixedRowsCount;
			}
			set
			{
				if (FixedRowsCount != value)
				{

					FixedRowsCount = value;
					if (FixedRowsCount == 0)
					{
						RemoveColumnDefinitions();
					}
					else
					{
						//WARNING only FixedRows == 1 is supported
						FixedRowsCount = value;
						TakeFirstRowAsHeaders();
					}
					NeedsRefresh = true;
				}

			}
		}

		/// <summary>
		/// Add a new selected cell to the GridSelectedCell structure
		/// </summary>
		/// <param name="row">The row index of the selected cell</param>
		/// <param name="column">The column index of the selected cell</param>
		public void AddSelectedCell(int row, int column)
		{
			int selectedItem;
			if (IsSelected(row, column, out selectedItem)) return;
			var tmp = GridSelectedCells;
			var newArray = new int[tmp.GetLength(0) + 1, 2];
			newArray[tmp.GetLength(0), 0] = row;
			newArray[tmp.GetLength(0), 1] = column;
			Array.Copy(tmp, newArray, tmp.Length);
			GridSelectedCells = newArray;
		}

		/// <summary>
		/// Delte a selected cell from the GridSelectedCells collection.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		public void DeleteFromSelectedCells(int row, int column)
		{
			int selectedItem;
			if (IsSelected(row, column, out selectedItem))
			{
				var tmp = GridSelectedCells;
				var newArray = new int[tmp.GetLength(0) - 1, 2];
				var currentIndex = 0;
				for (int i = 0; i < tmp.GetLength(0); i++)
				{
					if (i != selectedItem)
					{
						newArray[currentIndex, 0] = tmp[i, 0];
						newArray[currentIndex, 1] = tmp[i, 1];
						currentIndex++;
					}

				}
				GridSelectedCells = newArray;
			}
		}

		/// <summary>
		/// Verifies if the current cell is selected
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <param name="selectedItem"></param>
		/// <returns></returns>
		private bool IsSelected(int row, int column, out int selectedItem)
		{
			selectedItem = -1;
			for (int i = 0; i < GridSelectedCells.GetLength(0); i++)
			{
				if (GridSelectedCells[i, 0] == row && GridSelectedCells[i, 1] == column)
				{
					selectedItem = i;
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Fills column definitions with the values of the first row
		/// </summary>
		private void TakeFirstRowAsHeaders()
		{
			if (this.Items.Count > 0)
			{
				for (int i = 0; i < this.Columns.Items.Count; i++)
				{
					var columnDefinition = this.Columns.Items[i];
					columnDefinition.Text = this.Items[0].RowContent[i];
				}

				// Reorganize rows

				for (int i = 0; i < _rowCount; i++)
				{
					if ((i + 1) < _rowCount)
					{
						for (int j = 0; j < _colCount; j++)
						{
							this.Items[i].SetColumnValue(j, this.Items[i + 1].RowContent[j]);
						}
					}
				}

				for (int j = 0; j < _colCount; j++)
				{
					this.Items[_rowCount - 1].SetColumnValue(j, "");
				}

			}
		}

		private void RemoveColumnDefinitions()
		{
			if (this.Items.Count >= 1)
			{
				// Reorganize rows
				for (int i = _rowCount - 1; i > 0; i--)
				{
					if ((i - 1) >= 0)
					{
						for (int j = 0; j < _colCount; j++)
						{
							this.Items[i].SetColumnValue(j, this.Items[i - 1].RowContent[j]);
						}
					}
				}

				for (int i = 0; i < this.Columns.Items.Count; i++)
				{
					var columnDefinition = this.Columns.Items[i];
					this.Items[0].SetColumnValue(i, columnDefinition.Text);
					columnDefinition.Text = "\t";
				}
			}
		}




		[StateManagement(StateManagementValues.None)]
		public int RowsCount
		{
			get
			{
				return _rowCount;
			}
			set
			{
				_rowCount = value;
				SyncRowsWithRowCount();

			}
		}

		private void SyncRowsWithRowCount()
		{
			if ((this.Items.Count + this.FixedRows) != _rowCount)
			{
				if ((this.Items.Count + this.FixedRows) > _rowCount)
				{
					while (Items.Count > 0 && (Items.Count) > (_rowCount - this.FixedRows))
					{
						Items.RemoveAt(Items.Count - 1);
					}
					if (FixedRows > _rowCount)
					{
						for (int i = 0; i < this.Columns.Items.Count; i++)
						{
							var columnDefinition = this.Columns.Items[i];
							columnDefinition.Text = " ";
						}
					}
				}
				else if ((this.Items.Count + this.FixedRows) < _rowCount)
				{
					var elementsToAdd = _rowCount - (this.Items.Count + this.FixedRows);
					for (int i = 0; i < elementsToAdd; i++)
					{
						var newRow = Container.Resolve<FlexGridRowViewModel>();
						newRow.Resize(_colCount);
						Items.Add(newRow);
					}
				}
				NeedsRefresh = true;
			}
		}

		[StateManagement(StateManagementValues.None)]
		public int ColumnsCount
		{
			get
			{
				return _colCount;
			}
			set
			{
				if (_colCount != value)
				{
					_colCount = value;
					for (int i = 0; i < this.Items.Count; i++)
					{
						var row = this.Items[i];
						row.Resize(_colCount);
					}

					SyncColumnDefinitions();

					AdjustColumnData();
					NeedsRefresh = true;

				}

			}
		}

		private void AdjustColumnData()
		{
			var newColumnCount = this.ColumnsCount;
			var newColumnData = new int[newColumnCount];
			if (ColData != null)
			{
				Array.Copy(ColData,
						newColumnData,
						Math.Min(ColData.Length, newColumnData.Length));
			}

			ColData = newColumnData;
		}

		private void SyncColumnDefinitions()
		{
			if (_colCount != Columns.Items.Count)
			{
				if (_colCount < Columns.Items.Count && _colCount > 0)
				{
					var columnCountToRemove = Columns.Items.Count - _colCount;
					for (int i = 0; i < columnCountToRemove; i++)
					{
						Columns.Items.RemoveAt(Columns.Items.Count - 1);
					}
				}
				else if (_colCount > Columns.Items.Count)
				{
					var columnCountToAdd = _colCount - Columns.Items.Count;
					for (int i = 0; i < columnCountToAdd; i++)
					{
						var columnDefinition = Container.Resolve<FlexGridColumnViewModel>();
						Columns.Items.Add(columnDefinition);
						columnDefinition.Text = " ";
					}
				}
			}
		}


		public virtual FlexGridColumnsViewModel Columns
		{
			get;
			set;
		}


		[StateManagement(StateManagementValues.None)]
		public int CellWidth
		{
			get
			{
				return GetGridCellCoordinatesValue(2);
			}
			set
			{
				SetGridCellCoordinatesValue(value, 2);
			}
		}
		[StateManagement(StateManagementValues.None)]
		public int CellHeight
		{
			get
			{
				return GetGridCellCoordinatesValue(3);
			}
			set
			{
				SetGridCellCoordinatesValue(value, 3);
			}
		}

		[StateManagement(StateManagementValues.None)]
		public int CellTop
		{
			get
			{
				return GetGridCellCoordinatesValue(1);
			}
			set
			{
				SetGridCellCoordinatesValue(value, 1);
			}
		}
		[StateManagement(StateManagementValues.None)]
		public int CellLeft
		{
			get
			{
				return GetGridCellCoordinatesValue(0);
			}
			set
			{
				SetGridCellCoordinatesValue(value, 0);
			}
		}

		private int GetGridCellCoordinatesValue(int idx)
		{
			return this.GridCellCoordinates != null && this.GridCellCoordinates.Length > idx ? this.GridCellCoordinates[idx] : 0;
		}

		private void SetGridCellCoordinatesValue(int value, int idx)
		{
			if (this.GridCellCoordinates != null && this.GridCellCoordinates.Length > idx)
			{
				this.GridCellCoordinates[idx] = value;
			}
		}

		#region Events
		private event System.EventHandler _EnterCell;
		public event System.EventHandler EnterCell
		{
			add
			{
				_EnterCell += value;
			}
			remove
			{
				_EnterCell -= value;
			}
		}

		public void OnEnterCell()
		{
			if (_EnterCell != null)
			{
				_EnterCell(this, new System.EventArgs());
			}
		}

		#endregion



		internal void AddItem(string lineToAdd, object p2)
		{
			var parts = lineToAdd.Split('\t');
			var newRow = Container.Resolve<FlexGridRowViewModel>();
			newRow.Resize(_colCount);
			for (int i = 0; i < _colCount && i < parts.Length; i++)
			{
				newRow.SetColumnValue(i, parts[i]);
			}
			Items.Add(newRow);

		}

		[StateManagement(StateManagementValues.None)]
		public DataGridViewCellViewModel this[int i, int j]
		{
			get
			{
				int index = i;
				if (this.FixedRows > 0 && index > 0)
				{
					index = index - this.FixedRows;
				}
				var cell = Container.Resolve<DataGridViewCellViewModel>();
				cell.Value = Items[index].RowContent[j];
				return cell;
			}
			set
			{
				set_TextMatrix(i, j, value.Value.ToString());
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
				set_TextMatrix(column, row, cellValue.Value.ToString());
			else
				set_TextMatrix(column, row, value.ToString());
		}


		internal void set_TextMatrix(int i, int j, string p)
		{
			if (FixedRows == 1 && i == 0)
			{
				this.Columns.Items[j].Text = p;
			}
			else
			{
				var index = i;
				if (this.FixedRows > 0 && index > 0)
				{
					index = index - this.FixedRows;
				}
				this.Items[index].SetColumnValue(j, p);
			}
			NeedsRefresh = true;
		}



		public void SetColumnWidth(int j, double p)
		{
			this.Columns.Items[j].Width = Convert.ToInt32(p);
		}

	
		[StateManagement(StateManagementValues.None)]
		public IList<FlexGridRowViewModel> Items
		{
			get
			{
				return this.Content.Items;
			}
			set
			{
			}
		}

		[StateManagement(StateManagementValues.None)]
		public int[] SelectedRows
		{
			get
			{
				if (GridPosition.Length > 0)
				{
					var selectedRows = GridPosition.Where((item, index) => index % 2 == 0); //Extract even positions
					return selectedRows.ToArray();
				}
				return new[] { -1 };
			}
		}

		[StateManagement(StateManagementValues.None)]
		public int[] SelectedColumns
		{
			get
			{
				if (GridPosition.Length > 0)
				{
					var selectedCols = GridPosition.Where((item, index) => index % 2 != 0); //Extract odd positions
					return selectedCols.ToArray();
				}
				return new[] { -1 };
			}
		}

		/// <summary>
		/// Clear the grid's selection
		/// </summary>
		public void ClearSelection()
		{
			GridPosition = new int[2];
		}

		[StateManagement(StateManagementValues.None)]
		public int CurrentColumnIndex
		{
			get
			{
				return GridPosition[1];
			}
			set
			{
				ColSel = value;
				GridPosition[1] = value;
				UpdateGridPosition();
			}
		}

		/// <summary>
		/// Forces an update of the GridPosition property by setting to null and then back to the original value
		/// </summary>
		private void UpdateGridPosition()
		{
			var tmp = GridPosition;
			GridPosition = null;
			GridPosition = tmp;
		}

		[StateManagement(StateManagementValues.None)]
		public int CurrentRowIndex
		{
			get
			{
				return GridPosition[0];
			}
			set
			{
				RowSel = value;
				GridPosition[0] = value;
				UpdateGridPosition();
			}
		}


		[StateManagement(StateManagementValues.None)]
		public int ColSel
		{
			get
			{
				return GridEndSelectionCoordinates[1];
			}
			set
			{

				GridEndSelectionCoordinates[1] = value;
				UpdateEndSelectionCoordinates();

			}
		}

		[StateManagement(StateManagementValues.None)]
		public int RowSel
		{
			get
			{
				return GridEndSelectionCoordinates[0];
			}
			set
			{

				GridEndSelectionCoordinates[0] = value;
				UpdateEndSelectionCoordinates();

			}
		}

		/// <summary>
		/// Forcing an update of GridEndSelectionCoordinates
		/// by setting to null and then setting the value it will mark the property as 'dirty'
		/// this is done becaue the property is an array, and there is no other way (except maybe using a Watchable)
		/// to track if an element in the array was modified and therefore the content must be updated between client and server
		/// </summary>
		private void UpdateEndSelectionCoordinates()
		{

			var tmp = GridEndSelectionCoordinates;
			GridEndSelectionCoordinates = null;
			GridEndSelectionCoordinates = tmp;
		}


		public void AddItem(string data)
		{
			var parts = data.Split('\t');
			this.RowsCount = this.RowsCount + 1;
			var newRow = this.RowsCount - 1;
			var columnsCount = this.ColumnsCount;
			for (int i = 0; i < parts.Length && i < columnsCount; i++)
			{
				SetCellValue(newRow, i, parts[i]);
			}
		}


		/// <summary>
		/// Sets the content of all cells in the first row to " " and all other cells to String.Empty
		/// </summary>
		public void Clear()
		{
			var rows = this.RowsCount;
			var cols = this.ColumnsCount;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					this[i, j].Value = i == 0 ? " " : String.Empty;
				}
			}
		}

		public void RemoveItem(int rowNumber)
		{
			rowNumber = rowNumber - FixedRows;
			if (rowNumber < RowsCount)
			{
				var rows = RowsCount - FixedRows;
				for (int i = rowNumber; i < rows - 1; i++)
				{
					this.Items[i].RowContent = this.Items[i + 1].RowContent;
				}
				RowsCount = RowsCount - 1;
				NeedsRefresh = true;
			}
		}

		#region Handlers


		[Handler()]
		public void UpdateSelectionCoordinates(int row, bool isSelected)
		{
			if (isSelected)
			{
				this.GridEndSelectionCoordinates[0] = row;
			}
			else
			{
				if (this.GridEndSelectionCoordinates[0] == row)
				{
					this.GridEndSelectionCoordinates[0] = -1;
				}
			}
		}

		#endregion


	}

	public class GridContent : IDependentViewModel
	{

		public string UniqueID { get; set; }
		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<FlexGridRowViewModel> _items { get; set; }
		[StateManagement(StateManagementValues.None)]
		public IList<FlexGridRowViewModel> Items
		{
			get
			{
				return _items;
			}
		}
		public virtual int version { get; set; }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<FlexGridRowViewModel>>();
		}
	}
	public class FlexGridColumnViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }
		public virtual string Name { get; set; }
		public virtual string Text { get; set; }
		public virtual object Tag { get; set; }
		public virtual int Width { get; set; }

		public void Build(IIocContainer ctx)
		{
			Name = "";
			Width = 65;
		}

	}


	public class FlexGridColumnsViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }

		[JsonProperty("@k")]
		public int k = 1;

		public virtual IList<FlexGridColumnViewModel> _items { get; set; }

		[StateManagement(StateManagementValues.None)]
		public IList<FlexGridColumnViewModel> Items { get { return _items; } }

		public void Build(IIocContainer ctx)
		{
			_items = ctx.Resolve<IList<FlexGridColumnViewModel>>();
		}
	}


	/// <summary>
	/// </summary>
	public class FlexGridRowViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }

		public virtual string Name { get; set; }

		public virtual string[] RowContent { get; set; }

		[StateManagement(StateManagementValues.ClientOnly)]
		public virtual int RowIndex
		{
			get
			{
				int index = -1;
				var viewManager = StaticContainer.Instance.Resolve<IViewManager>();

				//Am I part of the grid?
				var parent = viewManager.GetParent(this) as IList<FlexGridRowViewModel>;
				if (parent != null)
				{
					//Calculated the row position based on its position within the list
					index = parent.IndexOf(this);
				}
				return index;
			}
		}

		public void Build(IIocContainer ctx)
		{
			RowContent = new string[0];
		}


		public void SetColumnValue(int item, string value)
		{
			if (RowContent.Length > item)
			{
				var tmpArray = RowContent;
				tmpArray[item] = value;
				// Force marking this property as 'dirty'
				RowContent = null;
				RowContent = tmpArray;
			}
			else
			{
				string[] tmp = RowContent;
				string[] newArray = new string[item + 1];
				Array.Copy(tmp, newArray, tmp.Length);
				newArray[item] = value;
				RowContent = newArray;
			}

		}


		internal void Resize(int ColCont)
		{
			if (RowContent.Length != ColCont)
			{
				if (RowContent.Length > ColCont)
				{
					string[] tmp = RowContent;
					string[] newArray = new string[ColCont];
					Array.Copy(tmp, newArray, ColCont);
					RowContent = newArray;
				}
				else if (RowContent.Length < ColCont)
				{
					string[] tmp = RowContent;
					string[] newArray = new string[ColCont];

					Array.Copy(tmp, newArray, tmp.Length);
					RowContent = newArray;
					for (int i = tmp.Length; i < ColCont; i++)
					{
						newArray[i] = "";
					}

				}
			}

		}


	}
}
