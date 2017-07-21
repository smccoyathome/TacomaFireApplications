// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridBand.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid
{
	using System.Collections.Generic;

	using Newtonsoft.Json;

    using UpgradeHelpers.Interfaces;
    using UpgradeHelpers.Helpers;
    using System;

    /// <summary>
    /// Class UltraGridBand.
    /// </summary>
    public class UltraGridBand : IDependentViewModel, IInitializable<CustomGrid>, ICreatesObjects
    {
        /// <summary>
        /// Gets or sets the card settings.
        /// </summary>
        /// <value>The card settings.</value>
        public virtual UltraGridCardSettings CardSettings { get; set; }

		/// <summary>
		/// Gets or sets the columns.
		/// </summary>
		/// <value>The columns.</value>
		public virtual ColumnsCollection Columns { get; set; }

        public IIocContainer Container { get; set; }

        /// <summary>
        /// The grid
        /// </summary>
        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; internal set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public virtual string UniqueID { get; set; }

		/// <summary>
		/// Gets or sets the band columns.
		/// </summary>
		/// <value>The band columns.</value>
		[JsonProperty]
		internal virtual IList<UltraGridColumn> ColumnList { get; set; }

        /// <summary>
		/// Determines if column headers are visible. 
		/// </summary>
		public virtual bool ColHeadersVisible { get; set; }
        /// <summary>
        /// Determines if group headers are visible.
        /// </summary>
        public virtual bool GroupHeadersVisible { get; set; }
        /// <summary>
        /// Determines if band headers are visible.
        /// </summary>
        public virtual bool HeaderVisible { get; set; }

        public virtual ColumnHeader Header { get; set; }
        public bool Hidden { get; set; }
        public bool CardView { get; set; }

        /// <summary>
        /// Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
            this.ColumnList = ctx.Resolve<IList<UltraGridColumn>>();
            this.CardSettings = ctx.Resolve<UltraGridCardSettings>();
        }

        public void Init()
        {
        }

        public void Init(CustomGrid ultraGrid)
        {
            Grid = ultraGrid;
            this.Columns = Container.Resolve<ColumnsCollection>(this);
        }
    }
}