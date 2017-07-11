using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.BasicViewModels
{
	public class ProgressBarViewModel : ControlViewModel
	{
		/// <summary>
		/// Gets / Sets the current progress value
		/// </summary>
		public virtual int Value { get; set; }

		/// <summary>
		/// Gets/Sets the maximum progress value
		/// </summary>
		public virtual int Maximum { get; set; }


		/// <summary>
		/// Gets/Sets the minimum progress value
		/// </summary>
		public virtual int Minimum { get; set; }

        [DefaultValue(true)]
		public virtual bool Enable { get; set; }
	}
}
