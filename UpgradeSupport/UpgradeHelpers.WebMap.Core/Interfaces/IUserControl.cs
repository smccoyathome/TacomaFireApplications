namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// Defines an object containing business logic and state of WebMAP converted user control.
	/// IUserControl objects have special considerations thru the application cycle:
	/// <list type="bullet">
	/// <item>Its methods can be work as event handlers for server side events, see <see cref="IEventAggregator"/> for more details</item>
	/// <item>All its instances must be created by using the <see cref="IIocContainer"/> factory object.</item>
	/// </list>
	/// </summary>
	public interface IUserControl : ILogic, IDependentViewModel, IInteractsWithView, ICreatesObjects, IDisposableDependencyControl
    {
	}

	/// <summary>
	/// Defines an object containing business logic of WebMAP converted user control. WebMAP splits original control in two:
	/// <list type="bullet">
	/// <item>SubViewModel.  Class that contains all state of the original control</item>
	/// <item>Control Logic class.  Class implementing <c>ILogicControl</c> that contains the logic defined by the original control.</item>
	/// </list>
	/// ILogicControl objects have special considerations thru the application cycle:
	/// <list type="bullet">
	/// <item>Its methods can be work as event handlers for server side events, see <see cref="IEventAggregator"/> for more details</item>
	/// <item>All its instances must be created by using the <see cref="IIocContainer"/> factory object.</item>
	/// <item>It defines a <c>ViewModel</c> property which type is the matching generated sub view model class.  This property is automatically
	/// set by the IoC container.</item>
	/// </list>
	/// </summary>
	/// <typeparam name="TVM">Type of its matching sub view model class.</typeparam>
	public interface ILogicControl<TVM> : ILogicWithViewModel<TVM>, IInteractsWithView where TVM : IDependentViewModel
	{
	}
}