namespace UpgradeHelpers.Interfaces
{

    public interface ILogic
    {
    }

    /// <summary>
    /// NOTE: This is an implementation interface and should not be used directly in migrated code
    /// </summary>
    /// <typeparam name="TVM">Type for the ViewModel property</typeparam>
    public interface ILogicWithViewModel<out TVM> : ILogic // where TVM : IViewModel 
    {
        TVM ViewModel { get; }
    }

    /// <summary>
    /// Defines an object containing business logic of WebMAP converted Form. WebMAP splits original form in two:
    /// <list type="bullet">
    /// <item>ViewModel.  Class that contains all state of the original Form</item>
    /// <item>Logic Class. Class implementing <c>ILogicView</c> that contains the logic defined by the original form.</item>
    /// </list>
    /// ILogicView objects have special considerations thru the application cycle:
    /// <list type="bullet">
    /// <item>Its methods can be work as event handlers for server side events, see <see cref="IEventAggregator"/> for more details</item>
    /// <item>All its instances must be created by using the <see cref="IIocContainer"/> factory object.</item>
    /// <item>It defines a <c>ViewModel</c> property which type is the matching generated view model class.  This property is automatically
    /// set by the IocContainer.</item>
    /// </list>
    /// </summary>
    /// <typeparam name="TVM">Type of its matching view model class.</typeparam>
    public interface ILogicView<out TVM> : ILogicWithViewModel<TVM>, IInteractsWithView, ICreatesObjects where TVM : IViewModel
    {
    }

	public interface ILogicViewEx<TVM>  where TVM : IViewModel
	{
		void SetupViewModel(TVM IViewModel);
	}


}

