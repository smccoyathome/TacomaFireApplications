namespace UpgradeHelpers.BasicViewModels
{

    /// <summary>
    /// A ListViewMode holds a list of items.
    /// </summary>
    public class ListViewSubItem
    {
        ListViewItemViewModel vm;
        public int subItemIndex { get; set; }
        public string _text { get; set; }
        internal ListViewSubItem(ListViewItemViewModel vm, int subItemIndex)
        {
            this.vm = vm;

            this.subItemIndex = subItemIndex;

            this.Name = "";
        }

        public ListViewSubItem(ListViewItemViewModel item, string p)
        {
            this.vm = item;
            this.Name = "";
            this._text = p;

        }
        public string Text
        {
            get
            {
                return vm.ItemContent[this.subItemIndex];
            }
            set
            {
                vm.SetSubItem(this.subItemIndex, value);
            }
        }

        /// <summary>
        /// Gets or Sets the SubItem name
        /// </summary>
        public string Name { get; set; }
    }
}