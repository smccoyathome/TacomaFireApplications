// *************************************************************************************
// <copyright company="Mobilize" file="BandsCollection.cs" >
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
    /// Class BandsCollection.
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class BandsCollection : IDependentViewModel, IInitializable<CustomGrid>
    {
        /// <summary>
        /// The grid
        /// </summary>
        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; set; }

        /// <summary>
        /// Gets the <see cref="UltraGridBand"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The UltraGridBand.</returns>
        public UltraGridBand this[int index]
        {
            get
            {
                return this.Grid.Bands[0];
            }
        }

        public string UniqueID { get; set; }
        public void Build(IIocContainer ctx)
        {

        }

        public void Init(CustomGrid grid)
        {
            Grid = grid;
        }

        public void Init()
        {
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}