using System;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{

	/// <summary>
	/// ViewModel to represent the state of a component on the view
	/// that allows the user to select a true or false condition.
	/// </summary>
	public class CheckBoxViewModel : ControlViewModel, IStateObjectWithInitialization
	{
		CheckState _checkState;
		bool _checked;


		#region Data Members
		/// <summary>
		/// Gets or sets the index value of the image that is displayed on the item.
		/// </summary>
		[DefaultValue(-1)]
		public virtual int ImageIndex { get; set; }


		/// <summary>
		/// Gets or sets the image list that is displayed on the item.
		/// </summary>
		public virtual object ImageList { get; set; }

		/// <summary>
		/// Indicates whether the element on the view is checked or unchecked
		/// </summary>
		public virtual CheckState CheckState
		{
			get
			{
				return _checkState;
			}
			set
			{
				if (_checkState != value)
				{

					_checkState = value;
					ViewManager.Events.Publish("CheckStateChanged", this, this, new System.EventArgs());
					if (!IsCompatibleCheckState(_checked, _checkState))
					{
						this.Checked = _checkState == UpgradeHelpers.Helpers.CheckState.Checked;
					}
				}
			}
		}

		public virtual bool Checked
		{
			get
			{
				return _checked;
			}
			set
			{
				if (_checked != value)
				{
					_checked = value;
					if (!IsCompatibleCheckState(_checked, _checkState))
					{
						this.CheckState = value ? UpgradeHelpers.Helpers.CheckState.Checked : UpgradeHelpers.Helpers.CheckState.Unchecked;
					}
				}
			}
		}

		private bool IsCompatibleCheckState(bool checkedFlag, UpgradeHelpers.Helpers.CheckState checkState)
		{
			if (checkedFlag)
			{
				return checkState == UpgradeHelpers.Helpers.CheckState.Checked;
			}
			else
			{
				return checkState != UpgradeHelpers.Helpers.CheckState.Checked;
			}
		}



		#endregion

		#region Events
		private event EventHandler _CheckStateChanged;

		/// <summary>
		/// Occurs when the value of the CheckState property changes.
		/// </summary>
		public new event EventHandler CheckStateChanged
		{
			add
			{
				_CheckStateChanged += value;
			}
			remove
			{
				_CheckStateChanged -= value;
			}
		}

		/// <summary>
		/// Triggers the CheckStateChanged event
		/// </summary>
		public void OnCheckStateChanged()
		{
			if (_CheckStateChanged != null)
			{
				_CheckStateChanged(this, new System.EventArgs());
			}
		}

		#endregion


		/// <summary>
		/// Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);

			// CheckState DefaultValue
			CheckState = CheckState.Unchecked;
		}
	}
}
