// *************************************************************************************
// <copyright company="Mobilize" file="InitializeLayoutEventArgs.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid.Event
{
    using System;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    /// Class AfterSelectChangeEventArgs
    /// </summary>
    public class AfterSelectChangeEventArgs : IDependentViewModel
    {
        public Type Type { get; set; }

        public string UniqueID { get; set; }

        public void Build(IIocContainer ctx)
        {
            Type = ctx.Resolve<Type>();
        }
    }
}
