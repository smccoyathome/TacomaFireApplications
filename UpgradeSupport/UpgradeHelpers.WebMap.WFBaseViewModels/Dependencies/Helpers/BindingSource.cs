

using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
    public class BindingSource
    {
        public BindingSource()
        { }

        public BindingSource(IContainer container)
        { }

        public BindingSource(object dataSource, string dataMember)
        { }

        public object DataSource { get; set; }
    }
}
