
namespace UpgradeHelpers.Interfaces
{
    public interface IValueList
    {
        int ItemCount { get; set; }
        int SelectedItemIndex { get; set; }

        string GetText(int index);
        string GetText(object dataValue, ref int index);
        object GetValue(int index);
        object GetValue(string text, ref int index);
    }

}
