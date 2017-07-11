namespace UpgradeHelpers.WebMap.Server
{

    internal interface IObservableCollectionMarkerInterface
    {
        string UniqueID { get; }
        int Count { get; }
        int CaseType { get; }

        System.Collections.IEnumerator GetEnumerator();

    }
}