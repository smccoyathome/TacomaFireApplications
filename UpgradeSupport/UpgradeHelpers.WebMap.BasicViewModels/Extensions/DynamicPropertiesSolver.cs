using System.Dynamic;
using UpgradeHelpers.Interfaces;

// ReSharper disable CheckNamespace
namespace UpgradeHelpers.BasicViewModels
// ReSharper restore CheckNamespace
{
    public class DynamicPropertiesSolver : DynamicObject
    {
        private readonly IStateObject _parent;

        public DynamicPropertiesSolver(IStateObject parent)
        {
            this._parent = parent;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var propName = binder.Name;
            var prop = _parent.GetType().GetProperty(propName);
            if (prop != null)
            {
                result = prop.GetValue(_parent, null);
            }
            else
            {
                result = 0;
            }
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var propName = binder.Name;
            var prop = _parent.GetType().GetProperty(propName);
            if (prop != null)
            {
                prop.SetValue(_parent, value, null);
            }
            return true;
        }
    }
}
