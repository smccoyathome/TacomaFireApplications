using UpgradeHelpers.Interfaces;

// ReSharper disable CheckNamespace
namespace UpgradeHelpers.BasicViewModels.Extensions
// ReSharper restore CheckNamespace
{
    public static class ControlPropertiesExtensions
    {
        public static dynamic ControlProperties(this IStateObject obj)
        {
            return new DynamicPropertiesSolver(obj);
        }
    }
}