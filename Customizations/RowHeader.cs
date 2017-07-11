// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="RowHeader.cs" >
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
    ///     Model for Row Header
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class RowHeader : IDependentModel, IInitializable<Columns>, ICreatesObjects
    {
        /// <summary>
        ///     Gets the Cells.
        /// </summary>
        /// <value>
        ///     The cells.
        /// </value>
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Cells Cells { get; set; }

        /// <summary>
        ///     Gets the columns.
        /// </summary>
        /// <value>
        ///     The columns.
        /// </value>
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual Columns Columns { get; set; }

        public IIocContainer Container { get; set; }

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

        public void Init(Columns columns)
        {
            this.Cells = columns.cells;
            this.Columns = columns;
        }
    }
}