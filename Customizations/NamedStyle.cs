// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="NamedStyle.cs" >
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
    ///     Named Style model.
    /// </summary>
    /// <seealso cref="UpgradeHelpers.Interfaces.IDependentViewModel" />
    public class NamedStyle : IDependentViewModel
    {
        /// <summary>
        ///     Gets or sets the color of the back.
        /// </summary>
        /// <value>
        ///     The color of the back.
        /// </value>
        public virtual Color BackColor { get; set; }

        public Border Border { get; set; }

        public ICellType CellType { get; set; }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public virtual Font Font { get; set; }

        /// <summary>
        ///     Gets or sets the color of the fore.
        /// </summary>
        /// <value>
        ///     The color of the fore.
        /// </value>
        public virtual Color ForeColor { get; set; }

        public virtual CellHorizontalAlignment HorizontalAlignment { get; set; }

        public bool Locked { get; set; }

        public Color NoteIndicatorColor { get; set; }

        public string Parent { get; set; }

        public IRenderer Renderer { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        ///     The unique identifier.
        /// </value>
        public string UniqueID { get; set; }

        public virtual CellVerticalAlignment VerticalAlignment { get; set; }

        /// <summary>
        ///     Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
        }
    }
}