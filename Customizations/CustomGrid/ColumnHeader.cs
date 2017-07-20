// *************************************************************************************
// <copyright company="Mobilize" file="ColumnHeader.cs" >
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
     /// <summary>
    /// Class ColumnHeader.
    /// </summary>
    public class ColumnHeader
    {
        /// <summary>
        /// The column
        /// </summary>
        private UltraGridColumn column;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnHeader"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        public ColumnHeader(UltraGridColumn column)
        {
            this.column = column;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return this.column.Caption;
            }

            set
            {
                this.column.Caption = value;
            }
        }

        /// <summary>
        /// Gets or sets the visible position.
        /// </summary>
        /// <value>The visible position.</value>
        public int VisiblePosition
        {
            get
            {
                return this.column.Position;
            }
            set
            {
                this.column.Position = value;
            }
        }

	     public AppearanceViewModel Appearance { get; set; }
        public bool Fixed { get; set; }
    }
}