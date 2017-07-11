// *************************************************************************************
// <copyright company="Mobilize" file="RadioButtonViewModel.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// ************************************************************************************* 
namespace UpgradeHelpers.BasicViewModels
{
    using UpgradeHelpers.Helpers;

    /// <summary>
    /// The RadioButtonViewModels is a wrap class to simulate the control RadioButton from Windows.Forms
    /// </summary>
    public class RadioButtonViewModel : ControlViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the control is checked
        /// </summary>
        public virtual bool Checked { get; set; }
    }
}
