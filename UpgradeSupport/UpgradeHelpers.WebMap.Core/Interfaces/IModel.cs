namespace UpgradeHelpers.Interfaces
{
    /// <summary>
    /// Defines an object containing business logic of Converted Class. This new class can be an the object implements the singleton pattern. <see cref="IIocContainer" /> implementation will return same instance
    /// everything its <see cref="IIocContainer.Resolve{T}"/> method is called. This implementation of singleton pattern will be applied when the class contains the attribute <c>Singleton</c>
    /// <para>
    /// A specific case of classes implementing this interfaces are VB6 modules converted to C#, it contains methods and static variables.  These static variables are converted to
    /// instance ones but singleton pattern ensure having same variable values every time they are referenced.
    /// </para>
    /// <para>
    /// As mentioned before, <c>IModel</c> objects have special treatment by <c>IIocContainer</c> object including injection of <c>ViewManager</c>
    /// properties.  For more details see <see cref="IIocContainer"/>
    /// </para>
    /// </summary>
    /// <seealso cref="IIocContainer"/>
    public interface IModel : ILogic, ITopLevelStateObject
    {
    }

    /// <summary>
    /// Defines an object containing business logic of Converted Class.
    /// <para>
    /// A specific case of classes implementing this interfaces contains methods and and state
    /// </para>
    /// <para>
    /// As mentioned before, <c>IDependentModel</c> objects have special treatment by <c>IIocContainer</c> object including injection of <c>ViewManager</c>
    /// properties.  For more details see <see cref="IIocContainer"/>
    /// </para>
    /// </summary>
    /// <seealso cref="IIocContainer"/>
    public interface IDependentModel : IDependentStateObject
    {
    }
}