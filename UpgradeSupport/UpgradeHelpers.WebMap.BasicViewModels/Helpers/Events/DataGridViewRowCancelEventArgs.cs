namespace UpgradeHelpers.Events
{
    using Helpers;
    using Interfaces;
    using UpgradeHelpers.BasicViewModels;

   public delegate void DataGridViewRowCancelEventHandler(object sender, UpgradeHelpers.Events.DataGridViewRowCancelEventArgs e);

    public class DataGridViewRowCancelEventArgs : IDependentModel, IInitializable<DataGridRowViewModel, DataGridViewViewModel>
    {
        public virtual bool cancel { get; set; }

        public string UniqueID { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.DataGridRowViewModel Row { get; set; }

        public virtual UpgradeHelpers.BasicViewModels.DataGridViewViewModel DataGrid { get; set; }

        [StateManagement(StateManagementValues.None)]
        public bool Cancel
        {
            get
            {
                return this.cancel;
            }

            set
            {
                if (value)
                {
                    this.cancel = value;
                }
            }
        }

        void IInitializable<DataGridRowViewModel, DataGridViewViewModel>.Init(DataGridRowViewModel row, DataGridViewViewModel dataGrid)
        {
            this.Row = row;
            this.DataGrid = dataGrid;
        }

        void IInitializable.Init()
        {
        }
    }
}
