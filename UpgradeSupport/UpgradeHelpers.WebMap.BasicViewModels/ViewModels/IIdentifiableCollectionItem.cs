namespace UpgradeHelpers.BasicViewModels
{
	/// <summary>
	/// Defines an object that can be identified by a given key.
	/// </summary>
	public interface IIdentifiableCollectionItem
	{
		/// <summary>
		/// Gets the key used to identify the object.
		/// </summary>
		string Key { get; }
	}
}
