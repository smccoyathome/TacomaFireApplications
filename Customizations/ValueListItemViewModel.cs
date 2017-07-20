namespace Custom.ViewModels
{
    using UpgradeHelpers.Interfaces;

    public class ValueListItemViewModel : IDependentViewModel
    {
        public virtual string DisplayText { get; set; }

        public virtual object DataValue { get; set; }

        public string UniqueID { get; set; }

        public void Build(IIocContainer ctx)
        {
        }
    }
}
