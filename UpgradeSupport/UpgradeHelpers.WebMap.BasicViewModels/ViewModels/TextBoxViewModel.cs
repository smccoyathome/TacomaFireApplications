#region

using System;
using System.ComponentModel;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

#endregion

namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	///     Represents a model that can be used on the view to display or edit unformatted text
	/// </summary>
	public class TextBoxViewModel : ControlViewModel
	{
		private const string TextChangedEvent = "TextChanged";
		/// <summary>
		///     Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			//ReadOnly DefaultValue
			ReadOnly = false;

			// SelectedRange DefaultValue
			SelectedRange = new int[] { 0, 0 };

			Text = String.Empty;
		}

		#region Data Members

		/// <summary>
		///     Gets or sets a value indicating whether in the view the element that represents this model can modified the Text.
		/// </summary>
		[DefaultValue(false)]
		public virtual bool ReadOnly { get; set; }

		/// <summary>
		///     Gets or sets generic data
		/// </summary>
		public virtual int MaxLength { get; set; }

		public virtual int[] SelectedRange { get; set; }

		/// <summary>
		///     Gets or sets a value indicating the currently selected text in the control.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public string SelectedText
		{
			get
			{
				return Text.Substring(SelectedRange[0], SelectedRange[1] - SelectedRange[0]);
			}
			set
			{
				Text.Remove(SelectedRange[0], SelectedRange[1] - SelectedRange[0]);
				Text.Insert(SelectedRange[0], value);
				SelectedRange[1] = SelectedRange[0] + value.Length;
			}
		}

		/// <summary>
		///     Gets or sets the starting point of text selected in the text box.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual int SelectionStart
		{
			get
			{
				return SelectedRange[0];
			}
			set
			{
				var tmpLength = SelectionLength;
				SelectedRange[0] = value;
				SelectedRange[1] = value + tmpLength;
				UpdateSelectedRangeToSetModified();
			}
		}

		private void UpdateSelectedRangeToSetModified()
		{
			var tmp = SelectedRange;
			SelectedRange = null;
			SelectedRange = tmp;
		}

		/// <summary>
		///     Gets or sets the number of characters selected in the text box.
		/// </summary>
		[StateManagement(StateManagementValues.None)]
		public virtual int SelectionLength
		{
			get
			{
				return SelectedRange[1] - SelectedRange[0];
			}
			set
			{
				SelectedRange[1] = SelectedRange[0] + value;
				UpdateSelectedRangeToSetModified();
			}
		}

		public virtual string _text { get; set; }

		/// <summary>
		///     Gets or sets the text associated with this model
		/// </summary>
		public override string Text
		{
			get { return _text; }
			set
			{
				if (_text != value)
				{
					_text = value;
					ViewManager.Events.Publish(TextChangedEvent, this, this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Appends a new string to the current Text value
		/// </summary>
		/// <param name="p">new string to append</param>
		public void AppendText(string p)
		{
			this.Text += p;
		}

		public bool Get_CausesValidation()
		{
			return CausesValidation;
		}

		#endregion

		#region Events

		private event EventHandler _TextChanged;

		public event EventHandler TextChanged
		{
			add { _TextChanged += value; }
			remove { _TextChanged -= value; }
		}

		public void OnTextChanged()
		{
			if (_TextChanged != null)
			{
				_TextChanged(this, new EventArgs());
			}
		}

		#endregion
	}
}