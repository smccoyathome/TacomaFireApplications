// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="ColumnHeader.cs" >
// //      Copyright (c) 2017 Mobilize, Inc. All Rights Reserved.
// //      All classes are provided for customer use only,
// //      all other use is prohibited without prior written consent from Mobilize.Net.
// //      no warranty express or implied,
// //      use at own risk.
// // </copyright>
// // <summary></summary>
// // ************************************************************************************* 

namespace FarPoint.ViewModels
{
    using UpgradeHelpers.Helpers;
    using UpgradeHelpers.Interfaces;

    /// <summary>
    ///     Model for Column Header
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class ColumnHeader : IDependentModel, IInitializable<Rows>, ICreatesObjects
    {
        /// <summary>
        ///     Gets the cells.
        /// </summary>
        /// <value>
        ///     The cells.
        /// </value>
        [StateManagement(StateManagementValues.ServerOnly)]

        public virtual Cells Cells { get; set; }

        public IIocContainer Container { get; set; }

        /// <summary>
        ///     Gets the rows.
        /// </summary>
        /// <value>
        ///     The rows.
        /// </value>
        [StateManagement(StateManagementValues.ServerOnly)]

        public virtual Rows Rows { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        public void Init()
        {
        }

        public void Init(Rows rows)
        {
            this.Cells = rows.cells;
            this.Rows = rows;
        }
    }
}