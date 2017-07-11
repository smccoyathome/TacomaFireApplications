namespace UpgradeHelpers.WebMap.Server
{
	internal interface IStorageSerializer
	{
		object ObjectToRaw(object obj);
		object RawToObject(string uniqueId, object rawData);
	}
}