// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridLayout.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    /// <summary>
    /// Class UltraGridLayout.
    /// </summary>
    public class UltraGridLayout : IDependentViewModel, IInitializable<CustomGrid>
    {
        /// <summary>
        /// The bands
        /// </summary>
        private BandsCollection _bands { get; set; }

        /// <summary>
        /// The grid
        /// </summary>
        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; set; }

        public virtual CustomGridOverride Override { get; set; }

        /// <summary>
        /// Specifies whether the AutoFitColumns feature is enabled. This feature automatically resizes the column widths proportionally to fit the visible area of the grid.
        /// </summary>
        public virtual AutoFitStyle AutoFitStyle { get; set; }

        /// <summary>
        /// Gets or sets the bands.
        /// </summary>
        /// <value>The bands.</value>
        public virtual BandsCollection Bands
        {
            get
            {
                if (_bands == null)
                    _bands = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<BandsCollection>(Grid);
                return _bands;
            }
            set
            {
                _bands = value;
            }
        }
        //=> this.bands ??
        //    (this.bands = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<BandsCollection>(Grid));

        public string UniqueID { get; set; }
        public dynamic Appearance { get; set; }
        public dynamic EmptyRowSettings { get; set; }

        public void Build(IIocContainer ctx)
        {
            Override = ctx.Resolve<CustomGridOverride>();
        }

        public void Init(CustomGrid grid)
        {
            Grid = grid;
            Bands = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<BandsCollection>(Grid);
        }

        public void Init()
        {

        }
    }
}