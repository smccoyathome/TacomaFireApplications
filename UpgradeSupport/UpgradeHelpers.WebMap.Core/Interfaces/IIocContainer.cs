using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Interfaces
{

    [Flags]
    public enum IIocContainerFlags : short
    {
        None = 0,
        //These flags are mostly for internal use
        RecoveredFromStorage = 1,
        NoView = 2,
        //This flags indicates that the object will be create without calling the .Init methods
        Lean = 4,
        //This flags indicates that the object will be create without event calling the .CommonInit methods
        ExtraLean = 8,
        //For internal use
        IsSinglenton = 16,
        //For internal use
        NoBuild = 32,
        //For Internal use
        SinglentonNonReturnIfExisting = 64,

        SinglentonReturnIfExisting = 128
    }



    /// <summary>
    /// This class is used as a wrapper when a DataTable has columns which point to IDependantViewModels or IDependantModels
    /// This is important if DataTable serialization is needed
    /// It is not allowed to create an instance of this type, it has a contructor just because serialization requirments
    /// </summary>
    [Serializable]
    public class XmlReferenceWrapper : System.Xml.Serialization.IXmlSerializable, System.Runtime.Serialization.ISerializable
    {
        public virtual object Value { get; set; }

        public XmlReferenceWrapper() { }

        protected XmlReferenceWrapper(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            InvokeDeserialization(info);
        }

        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            throw new NotImplementedException();
        }
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
        public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            throw new NotImplementedException();
        }

        protected virtual void InvokeDeserialization(System.Runtime.Serialization.SerializationInfo info)
        {
            throw new NotImplementedException();
        }


    }



    /// <summary>
    ///     Defines an object that implments the Dependency Injection pattern in order to provide WebMap
    ///     object instances.
    ///     <para>
    ///         All objects that are involved in their synchronization must be created by
    ///         calling any of the Resolve methods of this object.  Depending on its type, several new object properties
    ///         are injected with its values.
    ///     </para>
    ///     <para>
    ///         All created object are given an unique identifier, that helps in keeping track of the new object state for
    ///         synchronization purposes.
    ///     </para>
    ///     <para>Following are the types that can be be resolved using this object:</para>
    ///     <list type="bullet">
    ///         <item>
    ///             <see cref="IViewManager" />
    ///         </item>
    ///         <item>
    ///             <see cref="IDefaults" />
    ///         </item>
    ///         <item>
    ///             <see cref="ILogic" />.  Following properties are injected for new object:
    ///             <list type="bullet">
	///                 <item>Defaults, if the logic class implements <c>IDefaultInstances</c> interface</item>
	///                 <item>ViewModel, if the logic class implements <c>ILogicWithViewModel</c> interface</item>
	///                 <item>ViewManager, if the logic class implements <c>IInteractsWithView</c> interface</item>
	///                 <item>Container, if the logic class implements <c>ICreatesObjects</c> interface</item>
    ///             </list>
    ///             Additionally, if the concrete object type defines an Init method it is invoked./>
    ///         </item>
    ///         <item>
    ///             <see cref="IStateObject" />Object initialization depends on other interfaces implementation:
    ///             <list type="bullet">
    ///                 <item>
	///                     <see cref="IStateObjectWithInitialization" /> when it represents an <see cref="IModelList{T}" /> collection of <c>IStateObjectWithInitialization</c> objects then its size and <c>Container</c> properties
    ///                     are set.  Additionally if it is not an <see cref="IDependentViewModel"/> object then <c>Build</c> method is invoked.
    ///                 </item>
    ///                 <item>
    ///                     <see cref="IDependentViewModel" />Depending in other implemented interfaces:
    ///                     <list type="bullet">
    ///                         <item>
    ///                             <see cref="IInteractsWithView" /> then <c>ViewManager</c> property is injected.
    ///                         </item>
    ///                         <item>
    ///                             <see cref="ICreatesObjects" /> then <c>Container</c> property is injected.
    ///                         </item>
    ///                     </list>
    ///                 </item>
    ///             </list>
    ///         </item>
    ///     </list>
    /// </summary>
    public interface IIocContainer
    {

        /// <summary>
        /// REturns a wrapper for an IDependentViewModel or IDepedentViewModel that can be used if those values are needed inside 
        /// a class DataRow or an event args.
        /// However if the class has fields for which an XmlReference is registered those fields must be public in order for the
        /// dependencies analysis to be able to determine if this object might require adoption        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        XmlReferenceWrapper GetXmlReference(IStateObject obj);

		/// <summary>
		/// Returns wrapper for an  IDependentViewModel or IDepedentViewModel that can be used if those values are inside a surrogate collection
		/// </summary>
		/// <param name="parentCandidate">Surrogate object that might contain a reference to an IDependentViewModel or IDependendModel</param>
		/// <param name="obj"></param>
		/// <returns></returns>
		XmlReferenceWrapper GetXmlReference(object parentCandidate,IStateObject obj);


        /// <summary>
        ///     Creates a new object of the given type <c>t</c>.  New object properties are
        ///     injected according to the type of object being created.
        ///     <para>
        ///         Object id is assigned by using the unique id generated returned by <c>UniqueIDGenerator.Current</c>
        ///     </para>
        /// </summary>
        /// <param name="t">Type of the desired object.</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <seealso cref="UpgradeHelpers.WebMap.Server.UniqueIDGenerator" />
        object Resolve(Type t, object[] parameters=null, IIocContainerFlags flags= IIocContainerFlags.None);

        /// <summary>
        ///     Creates a new object of the given type <c>T</c>.  New object properties are
        ///     injected according to the type of object being created.
        ///     <para>
        ///         Object id is assigned by using the unique id generated returned by <c>UniqueIDGenerator.Current</c>
        ///     </para>
        /// </summary>
        /// <typeparam name="T">Type of the desired object.</typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>s
        /// <seealso cref="UpgradeHelpers.WebMap.Server.UniqueIDGenerator" />
        T Resolve<T>(params object[] parameters);

		/// <summary>
		///     Creates a new object of the given type <c>T</c>.  New object properties are
		///     injected according to the type of object being created.
		///     <para>
		///         Object id is assigned by using the unique id generated returned by <c>UniqueIDGenerator.Current</c>
		///     </para>
		/// </summary>
		/// <typeparam name="T">Type of the desired object array.</typeparam>
		/// <param name="parameters"></param>
		/// <returns>An array of the desired Object</returns>
		T[] CreateInstance<T>(params object[] parameters);


        /// <summary>
        /// Binds a property from <c>obj</c> to a property of <c>ds</c>.  Once property is bound then its values
        /// are synchronized.
        /// </summary>
		/// <param name="objproperty">Name of the <see cref="IStateObject"/> object property to bind.  This property can be sent to the client tier in order to
        /// show value to customers.</param>
		/// <param name="obj">The <c>IStateObject</c> object owning the property to bind.</param>
        /// <param name="dsproperty">Name of the datasource property to bind.</param>
        /// <param name="ds">Datasource object</param>
		void Bind(string objproperty, IStateObject obj, string dsproperty, object ds);
		void AddPostResolveAction(object newValue, Action postAction);
    }
}
