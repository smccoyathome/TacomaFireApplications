// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridCell.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
	/// <summary>
	/// Class UltraGridCell.
	/// </summary>
	public class UltraGridCell : IDependentViewModel, IInitializable<UltraGridRow>
	{
		/// <summary>
		/// Cancels the update.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool CancelUpdate()
		{
			return false;
		}

		/// <summary>
		/// Enters the edit mode.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool EnterEditMode()
		{
			return false;
		}

		/// <summary>
		/// Exits the edit mode.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool ExitEditMode()
		{
			return false;
		}

		/// <summary>
		/// Hides the drop down.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool HideDropDown()
		{
			return false;
		}

		/// <summary>
		/// Shows the drop down.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool ShowDropDown()
		{
			return false;
		}

		/// <summary>
		/// Toggles the CheckBox.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool ToggleCheckBox()
		{
			return false;
		}

		/// <summary>
		/// Toggles the drop down.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool ToggleDropDown()
		{
			return false;
		}

		/// <summary>
		/// Toggles the edit mode.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public bool ToggleEditMode()
		{
			return false;
		}

		public void Activate()
		{
			Activated = true;
		}

		/// <summary>
		/// Gets or sets the key value
		/// </summary>
		public virtual string Key { get; set; }

		/// <summary>
		/// Indicates whether this is the active cell  
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual bool Activated
		{
			get { return Selected; }
			set { Selected = true; }
		}

		/// <summary>
		/// Get IsActiveCell
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual bool IsActiveCell => Activated;

		public string UniqueID { get; set; }

		/// <summary>
		/// Returns or sets a value that determines how an object will behave when it is activated.
		/// </summary>
		public virtual Activation Activation { get; set; }

		/// <summary>
		/// Returns or sets the Appearance object that controls the object's formatting.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual AppearanceViewModel Appearance { get; set; }

		/// <summary>
		/// Returns the band to which this cell belongs
		/// </summary>
		public virtual UltraGridBand Band { get; set; }

		/// <summary>
		/// Specifies what to display in cells associated with this column.
		/// </summary>
		public virtual CellDisplayStyle CellDisplayStyle { get; set; }

		/// <summary>
		/// Returns the UltraGridColumn object associated with the cell. This property is not available at design-time.
		/// </summary>
		public virtual UltraGridColumn Column { get; set; }

		/// <summary>
		/// Returns the UltraGridRow object associated with the cell. This property is not available at design time. This property is read-only at run time.
		/// </summary>
		[Reference]
		[StateManagement(StateManagementValues.ServerOnly)]
		public virtual UltraGridRow Row { get; set; }

		public virtual int RowIndex { get; set; }
		/// <summary>
		/// Returns or sets a value that determines whether the cell is selected.
		/// </summary>
		public virtual bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				if (_selected)
					Row.RowsCollection.Grid.Selected.AddSelectedCell(this);
			}
		}
		public virtual bool _selected { get; set; }

		/// <summary>
		/// Returns a value that determines whether a cell in the grid is currently being edited. This property is read-only at run-time. 
		/// This property is not available at design-time.
		/// </summary>
		public virtual bool IsInEditMode { get; set; }

		/// <summary>
		/// Returns the text of the cell. If the cell is in edit mode, it returns the text in the editor being used for editing the cell.
		/// </summary>
		public virtual string Text { get; set; }

		/// <summary>
		/// Returns or sets the selected text of the cell being edited
		/// </summary>
		public virtual string SelText { get; set; }

		/// <summary>
		/// Gets or sets the value property for the UltraGridCell
		/// </summary>
		public virtual object Value { get; set; }

		/// <summary>
		/// Gets or sets the cell specific value list.
		/// </summary>
		public virtual ValueListItem ValueList { get; set; }

		public void Build(IIocContainer ctx)
		{
			Band = ctx.Resolve<UltraGridBand>();
			Column = ctx.Resolve<UltraGridColumn>();
			Row = ctx.Resolve<UltraGridRow>();
		}

		public void Init(UltraGridRow row)
		{
			Row = row;
		}

		public void Init()
		{
		}
	}
}