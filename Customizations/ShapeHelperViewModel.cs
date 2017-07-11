// *************************************************************************************
// <copyright company="Mobilize" file="ShapeHelperViewModel.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// ************************************************************************************* 
namespace VB6Helpers.ViewModels
{
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    /// Shape Helper ViewModel
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class ShapeHelperViewModel : ControlViewModel
    {
        /// <summary>
        /// Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public override void Build(IIocContainer ctx)
        {
            base.Build(ctx);
            this.Visible = true;
            this.Enabled = true;
        }
    }
}