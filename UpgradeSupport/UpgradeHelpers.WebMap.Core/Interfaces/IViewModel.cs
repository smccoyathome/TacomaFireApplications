using System.Collections.Generic;
using System.ComponentModel;

namespace UpgradeHelpers.Interfaces
{

    /// <summary>
    /// State object which requires initilization of its state.
    /// This initialization will be performed with the Build method
    /// </summary>
    public interface IStateObjectWithInitialization : IStateObject
    {
        /// <summary>
        /// Build method is very important in the modeling architecture.
        /// In general object factories are concentrated inside the IIocContainer as well as Property Injection and AOP 
        /// techniques used for adding fucntionality like Lazy Loading and Caching
        /// This is an infraestructure method and is not meant to be called directly
        /// </summary>
        /// <param name="ctx"></param>
        void Build(IIocContainer ctx);
    }

    public interface IViewModel : ITopLevelStateObject, IStateObjectWithInitialization
    {
        string Name { get; set; }
        bool Visible { get; set; }
    }

    public interface IDependentViewModel : IStateObjectWithInitialization, IDependentStateObject
    {

    }

    public interface ICreatesObjects
    {
        IIocContainer Container { get; set; }
    }


    public interface IInteractsWithView
    {
        IViewManager ViewManager { get; set; }
    }

    public interface IModelList<T> : IList<T>, IDependentViewModel
    {
        void AddRange(IList<T> list);
    }
	public interface ILoadable
	{
		void Load();
	}
}