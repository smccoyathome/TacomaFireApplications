using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server.Interfaces
{

	/// <summary>
	/// This interface is used by items which are part of a IViewModelCollection
	/// When you try to add an item that already belongs to a Collection, by default it will fail
	/// unless the object is ICopyable. If it is an ICopyable object the runtime will
	/// create a new instance and copy the contents from the argument
	/// </summary>
	public interface ICopyable<T>
	{
		void CopyFrom(T oldInstance);
	}

	public interface IViewModelCollection : IDependentViewModel, IInteractsWithView, ICreatesObjects
	{
		IModelList<IStateObject> _items { get; set; }
	}
}