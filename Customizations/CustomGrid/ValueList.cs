
using System;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    public class ValueList: IDependentViewModel
    {
        public string UniqueID { get; set; }

        /// <summary>
        /// Returns a reference to a ValueListItems collection
        /// </summary>
        public virtual ValueListItemsCollection ValueListItems { get; set; }

        public void Build(IIocContainer ctx)
        {
            ValueListItems = ctx.Resolve<ValueListItemsCollection>();
        }
    }


}
