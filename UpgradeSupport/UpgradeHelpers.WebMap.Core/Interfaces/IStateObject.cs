namespace UpgradeHelpers.Interfaces
{

	/// <summary>
	/// Defines an object containing state that must be kept between server requests.  An <c>IStateObject</c> object must be
	/// uniquely identified in order to be able to store/restore its state between requests.  
	/// <para>Unique ids are handled by <see cref="IIocContainer"/> object, it implies that all instances of objects implementing
	/// this interface must be created by one of <c>IIocContainer.Resolve</c> methods.
	/// </para>
	/// 
	/// </summary>
	/// <seealso cref="IIocContainer"/> 
	/// <seealso cref="IViewModel"/>
	/// <seealso cref="IDependentViewModel"/>
	/// <seealso cref="IStateObjectWithInitialization"/>
	public interface IStateObject
	{
		/// <summary>
		/// Gets/Sets the unique identifier of this <c>IStateObject</c> object.
		/// </summary>
		string UniqueID { get; set; }
	}

	public interface IDependentStateObject : IStateObject, ILogic
	{

	}

	public interface ITopLevelStateObject : IStateObject { }

	public interface IEnumerableException { }

    /// <summary>
    /// This interface is used to mark Controls that should be disposed when its parent is being disposed.
    /// This is important to model windows forms behaviour
    /// NOTE: Without this mark, controls could be 'rescued' when its parent is being disposed if there are any other reference 
    /// and this can cause sever side leaks.
    /// </summary>
    public interface IDisposableDependencyControl { }
}
