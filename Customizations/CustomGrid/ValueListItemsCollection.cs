using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace Custom.ViewModels.Grid
{
    public class ValueListItemsCollection : IDependentViewModel, ICreatesObjects
    {
        public IIocContainer Container { get; set; }

        public string UniqueID { get; set; }

        public void Build(IIocContainer ctx)
        {
            Items = ctx.Resolve<IList<ValueListItem>>();
        }

        public ValueListItem this[int index]
        {
            get
            {
                return Items[index];
            }
        }

        public virtual IList<ValueListItem> Items { get; set; }
        public IEnumerator<ValueListItem> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        public int Count => Items.Count;
        public ValueListItem Add(object dataValue, string displayText)
        {
            var item = Container.Resolve<ValueListItem>();
            item.DataValue = dataValue;
            item.DisplayText = displayText;
            Items.Add(item);
            return item;
        }
    }
}