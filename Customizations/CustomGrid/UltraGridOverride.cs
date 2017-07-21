using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using Custom.ViewModels.Enums;

namespace Custom.ViewModels.Grid
{
	public class CustomGridOverride : IDependentViewModel
    {
		public virtual CellClickAction CellClickAction { get; set; }

        public AppearanceViewModel ActiveCellAppearance { get; set; }

        public AppearanceViewModel ActiveRowAppearance { get; set; }

        public AllowAddNew AllowAddNew { get; set; }

        public AllowColMoving AllowColMoving { get; set; }

        public AllowColSwapping AllowColSwapping { get; set; }

        public DefaultableBoolean AllowDelete { get; set; }

        public DefaultableBoolean AllowUpdate { get; set; }

        public UIElementBorderStyle BorderStyleCell { get; set; }

        public UIElementBorderStyle BorderStyleRow { get; set; }

        /// <summary>
        /// Determines the formatting attributes that will be applied to the card area in a band or the grid.
        /// </summary>
        public AppearanceViewModel CardAreaAppearance { get; set; }

        /// <summary>
        /// Determines the formatting attributes that will be applied to the cells in a band or the grid.
        /// </summary>
        public AppearanceViewModel CellAppearance { get; set; }

        /// <summary>
        /// Returns or sets the amount of spacing, in pixels, between the cell's border and the cell's contents.
        /// </summary>
        public int CellPadding { get; set; }

        /// <summary>
        /// Returns the default GroupByRowAppearance
        /// </summary>
        public AppearanceViewModel GroupByRowAppearance { get; set; }

        /// <summary>
        /// Returns or sets the Appearance object used to set the header formatting attributes.
        /// </summary>
        public AppearanceViewModel HeaderAppearance { get; set; }

        /// <summary>
        /// Returns or sets a value that determines what will occur when the user clicks on a header.
        /// </summary>
        public HeaderClickAction HeaderClickAction { get; set; }

        /// <summary>
        /// Gets/sets the visual style of the column headers.
        /// </summary>
        public HeaderStyle HeaderStyle { get; set; }

        /// <summary>
        /// Returns or sets the Appearance object for non-alternate rows.
        /// </summary>
        public AppearanceViewModel RowAppearance { get; set; }

        /// <summary>
        /// Returns or sets a value that determines whether row selectors will be displayed.
        /// </summary>
        public DefaultableBoolean RowSelectors { get; set; }

        /// <summary>
        /// Returns or sets a value that determines the type of row sizing.
        /// </summary>
        public RowSizing RowSizing { get; set; }

        /// <summary>
        /// Returns or sets a value that determines the cell selection type.
        /// </summary>
        public SelectType SelectTypeCell { get; set; }

		public string UniqueID { get; set; }
        public int CardSpacing { get; set; }
        public UIElementBorderStyle BorderStyleCardArea { get; set; }
        public dynamic SelectedCardCaptionAppearance { get; set; }
        public dynamic ActiveCardCaptionAppearance { get; set; }
        public dynamic SelectTypeRow { get; set; }
        public dynamic SelectTypeCol { get; set; }

        public void Build(IIocContainer ctx)
		{
		}
    }
}
