using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class NumericUpDownViewModel : ControlViewModel
	{
		/// <summary>
		///     Setup the model properties with its default values
		/// </summary>
		public override void Build(IIocContainer ctx)
		{
			base.Build(ctx);
			// ReadOnly DefaultValue
			ReadOnly = false;

			//Maximum DefaultValue
			Maximum = 100;

			//Minimum DefaultValue
			Minimum = 0;

			//DecimalPlaces DefaultValue
			DecimalPlaces = 0;

			//Increment Default Value;
			Increment = 1;

		}

		#region Data Members

		/// <summary>
		///     Gets or sets a value indicating whether in the view the element that represents this model can modified the Text.
		/// </summary>
		[DefaultValue(false)]
		public virtual bool ReadOnly { get; set; }

		/// <summary>
		///     Gets or sets the value associated with this model
		/// </summary>
		public virtual decimal Value { get; set; }

		/// <summary>
		///     Gets or sets the maximum value associated with this model
		/// </summary>
		public virtual decimal Maximum { get; set; }

		/// <summary>
		///     Gets or sets the minimum value associated with this model
		/// </summary>
		public virtual decimal Minimum { get; set; }

		/// <summary>
		///     Gets or sets the increment or decrement value associated with this model.
		/// </summary>
		public virtual decimal Increment { get; set; }

		/// <summary>
		///     Gets or sets the number of decimal places to be displayed 
		///     by the element of the view that represents this model
		/// </summary>
		public virtual int DecimalPlaces { get; set; }

		#endregion

		#region events
		/// <summary>
		///  Increases the value of the control when the Upbutton is pressed
		/// </summary>
		///
		public void UpButton()
		{
			Value += Increment;
		}

		/// <summary>
		///  Decreases the value of the control when the Downbutton is pressed
		/// </summary>
		///
		public void DownButton()
		{
			Value -= Increment;
		}


		#endregion
	}
}