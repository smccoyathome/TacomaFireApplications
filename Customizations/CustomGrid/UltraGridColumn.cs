// *************************************************************************************
// <copyright company="Mobilize" file="UltraGridColumn.cs" >
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
	using System;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using UpgradeHelpers.Helpers;
	using UpgradeHelpers.Interfaces;
	using System.Collections;

	/// <summary>
	/// Class UltraGridColumn.
	/// </summary> 
	public class UltraGridColumn : IDependentViewModel, IInitializable<CustomGrid>
    {
		/// <summary>
		/// Gets or Sets ButtonDisplayStyle value
		/// </summary>
		/// /// <value>The ButtonDisplayStyle value.</value>
		public virtual ButtonDisplayStyle ButtonDisplayStyle { get; set; }

		/// <summary>
		/// The column header
		/// </summary>
		public Activation CellActivation;

		/// <summary>
		/// Gets or Sets CellDisplayStyle value
		/// </summary>
		/// /// <value>The CellDisplayStyle value.</value>
		public virtual CellDisplayStyle CellDisplayStyle { get; set; }
		/// <summary>
		/// The column header
		/// </summary>
		private ColumnHeader columnHeader;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public virtual string Caption { get; set; }

		/// <summary>
		/// Gets or sets the format.
		/// </summary>
		/// <value>The format.</value>
		public virtual string Format { get; set; }

		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <value>The header.</value>
		public ColumnHeader Header => this.columnHeader ?? (this.columnHeader = new ColumnHeader(this));

		/// <summary>
		/// Gets or sets the when the columns should be hidden.
		/// </summary>
		/// <value>The hidden value.</value>
		public virtual bool Hidden { get; set; }
		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		public virtual string Key { get; set; }

		/// <summary>
		/// The column layout
		/// </summary>
		public UltraGridLayout Layout;

		public void Activate()
        {
            Activated = true;
        }

		/// <summary>
		/// Gets or sets the locked width of the column.
		/// </summary>
		/// <value>The locked width value.</value>
		public virtual bool LockedWidth { get; set; }

		/// <summary>
		/// Gets or sets the max value of the column.
		/// </summary>
		/// <value>The max value.</value>
		public virtual object MaxValue { get; set; }

		/// <summary>
		/// Gets or sets the max width of the column.
		/// </summary>
		/// <value>The max width value.</value>
		public virtual int MaxWidth { get; set; }

		/// <summary>
		/// Gets or sets the min width of the column.
		/// </summary>
		/// <value>The min width value.</value>
		public virtual int MinWidth { get; set; }

		/// <summary>
		/// Gets or sets the Nullable value.
		/// </summary>
		/// <value>The Nullable value.</value>
		public virtual Nullable Nullable { get; set; }

		/// <summary>
		/// Gets or sets the prompt char.
		/// </summary>
		/// <value>The prompt char value.</value>
		public virtual char PromptChar { get; set; }

		/// <summary>
		/// Gets or sets the sort comparer.
		/// </summary>
		/// <value>The sort comparer value.</value>
		public virtual IComparer SortComparer { get; set; }

		/// <summary>
		/// Indicates whether this is the active cell  
		/// </summary>
		[StateManagement(StateManagementValues.None)]
        public virtual bool Activated
        {
            get { return Selected; }
            set { Selected = true; }
        }

        /// <summary>
        /// Gets/sets whether the row is selected.
        /// </summary>
        public virtual bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public virtual bool _selected { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public virtual ColumnStyle Style { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueID { get; set; }

        /// <summary>
        /// Gets or sets the visible position.
        /// </summary>
        /// <value>The visible position.</value>
        [JsonProperty]
        internal virtual int Position { get; set; }

        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public CellsCollection CellsCollection { get; set; }

        [Reference]
        [StateManagement(StateManagementValues.ServerOnly)]
        public virtual CustomGrid Grid { get; set; }

        /// <summary>
        /// Determines the width of the column.
        /// </summary>
        public virtual int Width { get; set; }

        /// <summary>
        /// Returns a reference to a ValueList object containing the list of values used by a column.
        /// </summary>
        public virtual ValueList ValueList { get; set; }

        /// <summary>
        /// Builds the specified CTX.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public void Build(IIocContainer ctx)
        {
            ValueList = ctx.Resolve<ValueList>();
        }

        public void Init(CustomGrid grid)
        {
            Grid = grid;
        }

        public void Init()
        {
        }
    }
}