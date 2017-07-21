//-----------------------------------------------------------------------
// <copyright file="UltraComboViewModel.cs" company="Mobilize.net">
//
//  MOBILIZE CONFIDENTIAL
// _______________________________________________________________________
//
//  Mobilize Company
//  All Rights Reserved.
//  
//  NOTICE: All helper classes are provided for customers use only;
//  all other use is prohibited without prior written consent from Mobilize.Net.
//  no warranty express or implied;
//  use at own risk.
// </copyright>
//-----------------------------------------------------------------------

using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels
{
	public class AppearanceViewModel : IDependentViewModel
	{
		public string UniqueID { get; set; }
		public void Build(IIocContainer ctx)
		{
			Image = string.Empty;
		}
		//Gets or sets the image attribute for this appearance
		public virtual object Image { get; set; }

        public virtual Color BackColor { get; set; }

		public virtual Color ForeColor { get; set; }

		public virtual Font FontData { get; set; }

        public virtual object ImageVAlign { get; set; }
    }
}
