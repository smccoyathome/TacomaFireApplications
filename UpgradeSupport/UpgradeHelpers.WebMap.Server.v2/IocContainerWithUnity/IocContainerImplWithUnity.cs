#define BACKGROUNDTASK
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Helpers;
using System.Data.Common;
using System.Reflection;
using Fasterflect;
using UpgradeHelpers.WebMap.Server.Common;
using System.Threading;
using UpgradeHelpers.WebMap.List;
using System.Linq.Expressions;

namespace UpgradeHelpers.WebMap.Server
{

	public partial class IocContainerImplWithUnity : IIocContainer
	{

		public static class DefaultResolutionStrategy<T>
		{
			public static Func<object[], IIocContainerFlags, T> Strategy = DetermineStrategy();

			static Func<object[], IIocContainerFlags, T> DetermineStrategy()
			{
				var type = typeof(T);
				if (typeof(ILogic).IsAssignableFrom(type))
					return (object[] parameters, IIocContainerFlags flags) => _current.ResolveNonSinglentonLogic<T>(parameters, flags);
				if (typeof(IStateObject).IsAssignableFrom(type))
					return (object[] parameters, IIocContainerFlags flags) => _current.ResolveNonSinglentonIStateObject<T>(parameters, flags);
				if (typeof(T).IsGenericType)
				{
					if (typeof(T).GetGenericTypeDefinition() == typeof(IList<>))
					{
						var listType = typeof(VirtualList<>).MakeGenericType(typeof(T).GetGenericArguments());
						var func = Expression.Lambda<Func<object>>(Expression.Convert(Expression.New(listType), typeof(object))).Compile();
						return (object[] parameters, IIocContainerFlags flags) => (T)_current.ResolveList(listType, func, parameters, flags);
					}
					if (typeof(T).GetGenericTypeDefinition() == typeof(IDictionary<,>))
					{
						var dictionaryType = typeof(ObservableDictionaryEx<,>).MakeGenericType(typeof(T).GetGenericArguments());
						var func = Expression.Lambda<Func<object>>(Expression.Convert(Expression.New(dictionaryType), typeof(object))).Compile();
						return (object[] parameters, IIocContainerFlags flags) => (T)_current.ResolveDictionary(dictionaryType, func, parameters, flags);
					}
				}
				if (SurrogatesDirectory.IsSurrogateRegistered(typeof(T)))
					return (object[] parameters, IIocContainerFlags flags) => _current.ResolveSurrogate<T>(parameters);
				if (typeof(T).GetCustomAttributes(typeof(Singleton), false).Length > 0)
					return (object[] parameters, IIocContainerFlags flags) => _current.ResolveSinglenton<T>(parameters, flags);
				return (object[] parameters, IIocContainerFlags flags) => (T)_current.ResolveReduced(typeof(T), parameters, flags);
			}
		}



		private static IocContainerImplWithUnity _current;


		static IocContainerImplWithUnity()
		{
			RegisterStandardSurrogates();
		}

		private IocContainerImplWithUnity()
		{
		}



		/// <summary>
		/// Register basic surrogates
		/// </summary>
		private static void RegisterStandardSurrogates()
		{
			SurrogatesDirectory.defaultApplyBindingChangedAction = (string targetUniqueId, string targetProperty, object value) =>
			{
				var stateCache = StateManager.Current;
				var target = (IStateObject)stateCache.GetObject(targetUniqueId);
				var property = target.GetType().Property(targetProperty);
				if (property != null)
				{
					var convertedValue = System.Convert.ChangeType(value, property.PropertyType);
					property.SetValue(target, convertedValue, null);
				}
			};
			SurrogatesDirectory.GetUniqueIDForSurrogateDelegate = (obj, parent,generateIfNotFound) =>
			{
				var sur = StateManager.Current.surrogateManager.GetSurrogateFor(newValueObject:obj,generateIfNotFound:true,parentSurrogate:parent);
				return sur.UniqueID;
			};

			SurrogatesDirectory.RestoreSurrogateDelegate = (uniqueId) =>
			{
				var sur = StateManager.Current.GetObject(uniqueId) as StateObjectSurrogate;
				if (sur != null)
				{
					return sur.Value;
				}
				return null;
			};
            SurrogateForSurrogate.RegisterSurrogateForSurrogate();
            DataBindingSurrogate.RegisterSurrogateForDataBinding();
			SortedlistSurrogate.RegisterSurrogate();
		}


		internal static void InitializeResolver()
		{
			StaticContainer.InitContainer = () => IocContainerImplWithUnity.Current;
			ConventionBasedHelper.Container = IocContainerImplWithUnity.Current;
			//REgister ContinuationInfo for shorten type info on JSON
			TypeCacheUtils.AddToTypeContractorCache(typeof(PromiseInfo));
			TypeCacheUtils.AddToTypeContractorCache(typeof(UniqueIDGenerator));
			TypeCacheUtils.AddToTypeContractorCache(typeof(ViewsState));
			TypeCacheUtils.AddToTypeContractorCache(typeof(List<ViewInfo>));
			TypeCacheUtils.AddToTypeContractorCache(typeof(List<ClientCommand>));
			TypeCacheUtils.AddToTypeContractorCache(typeof(List<PromiseInfo>));
			TypeCacheUtils.AddToTypeContractorCache(typeof(List<string>));
			TypeCacheUtils.AddAssemblyToTypeContractorCache(typeof(int).Assembly);
			TypeCacheUtils.AddAssemblyToTypeContractorCache(typeof(Bootstrapper).Assembly);
		}

		static VirtualMethodInterceptor _typeInterceptor = new VirtualMethodInterceptor();
		static IInterceptionBehavior _lazyBehavior = new LazyBehaviour();
		static IInterceptionBehavior _lazyBehaviorNewInstance = new LazyBehaviourNewInstance();



		internal List<Type> interceptedTypes = new List<Type>();
		internal List<Type> non_interceptedTypes = new List<Type>();


		public static CountdownEvent backgroundPauser = new CountdownEvent(0);

		/// <summary>
		/// Processes all given types to register metadata and interception information needed by the 
		/// WebMap Helpers infraestructure
		/// </summary>
		/// <param name="typesToRegister"></param>
		internal void RegisterTypes(IEnumerable<Type> typesToRegister)
		{
			foreach (var typeToRegister in typesToRegister)
			{
				if (!typeToRegister.IsAbstract || typeToRegister.IsInterface)
					RegisterType(typeToRegister);
			}
			var copyOfinterceptedTypes = interceptedTypes.ToArray();
#if !BACKGROUNDTASK
            System.Threading.Tasks.Task.Run(() =>
            {
                backgroundPauser.Wait();
                Trace.WriteLine("Starting background generation of proxy types");
                List<Type> interceptedTypesEx = new List<Type>();
                int counter = 0;
                foreach (var typeToRegister in copyOfinterceptedTypes)
                {
                    backgroundPauser.Wait();
                    Type interceptedType = null;
                    try
                    {
                        Trace.WriteLine("Building proxy for " + (counter++) + " of " + copyOfinterceptedTypes.Length + " " +  typeToRegister.FullName);
                        interceptedType = Intercept.PreLoadProxyType(typeToRegister);
                        interceptedTypesEx.Add(interceptedType);
                    }
                    catch
                    {
                        //Trace.WriteLine("Error Building proxy for " + typeToRegister.FullName);
                    }

                    //ThreadPool.QueueUserWorkItem((a) => {
			//	backgroundPauser.Wait();
                    //    try
                    //    {
                    //        foreach(var prop in TypePropertiesCache.GetArrayPropertiesOrderedByIndex(interceptedType))
                    //        {
                    //            var temp = prop.JsonProperty;
                    //        }
			//		}
			//		catch
			//		{

			//		}
                    //    Trace.WriteLine("Done processing jsonproperties for " + typeToRegister.FullName);
			//});

                    try
                    {
                        //Trace.WriteLine("Registering TypeHierarchy for " + typeToRegister.FullName);
                        if (!typeToRegister.IsGenericType)
                            InitializationHelpers.LoadTypeHierarchy(typeToRegister);
                    }
                    catch
                    {
                        //Trace.WriteLine("Error TypeHierarchy for " + typeToRegister.FullName);
                    }
                }
            });
#endif
			//    Trace.WriteLine("End background generation of proxy types");
			//    /* System.Threading.Tasks.Parallel.ForEach(interceptedTypes,(interceptedType) =>
			//     { 
			//             try
			//             {
			//                PropertySkipperContractResolver.CommonInstanceClient.ResolveContract(interceptedType);
			//             }
			//             catch
			//             {
			//                 Trace.WriteLine("Error with property skipper preload");
			//             }
			//     });*/

			//});
		}

		internal void RegisterType(Type typeToRegister)
		{
#if DETAILED_DEBUG
				Trace.TraceInformation("Processing type " + typeToRegister.FullName);
#endif

			if (typeToRegister != null && typeof(IStateObject).IsAssignableFrom(typeToRegister) && //This is to make eliminating false cases faster
								(typeof(IDependentModel).IsAssignableFrom(typeToRegister)
									|| typeof(IDependentViewModel).IsAssignableFrom(typeToRegister)
									|| typeof(IViewModel).IsAssignableFrom(typeToRegister)
									|| (typeof(IModel).IsAssignableFrom(typeToRegister))))
			{
				try
				{
					if (!typeToRegister.IsAbstract && !typeToRegister.IsInterface)
					{
						if (typeof(NoInterception).IsAssignableFrom(typeToRegister))
						{
							TraceUtil.TraceInformation("Excluding type from interception " + typeToRegister.FullName);
							non_interceptedTypes.Add(typeToRegister);
						}
						else
						{
							interceptedTypes.Add(typeToRegister);
							if (!typeToRegister.IsGenericType)
								InitializationHelpers.LoadTypeHierarchy(typeToRegister);
						}
                        TypeCacheUtils.AddClientTypeRegistration(typeToRegister);
					}
				}
				catch (Exception registerTypeException)
				{
					Trace.TraceError("Bootstrapper::RegisterAllTypes problem while registering type " + typeToRegister.FullName + " Message " + registerTypeException.Message);
				}

			}

		}







		public static IocContainerImplWithUnity Current
		{
			get { return _current ?? (_current = new IocContainerImplWithUnity()); }
		}

		#region IIocContainer Members

		public T[] CreateInstance<T>(params object[] parameters)
		{

			int size = 0;
			if (parameters != null)
			{
				size = (int)parameters.FirstOrDefault(x => x is int);
			}
			var array = new T[size];

			if (typeof(IStateObject).IsAssignableFrom(typeof(T)))
			{
				for (var i = 0; i < size; i++)
				{
					array[i] = Resolve<T>();
					var obj  = array[i] as IStateObject;
					StateManager.Current.PromoteObject(obj, obj.UniqueID);
				}
			}
			else
			{
				for (var i = 0; i < size; i++)
				{
					array[i] = default(T);
				}
			}

			return array;

		}

		public T Resolve<T>(params object[] parameters)
		{
			return DefaultResolutionStrategy<T>.Strategy(parameters, IIocContainerFlags.None);
		}

		public T ResolveSurrogate<T>(object[] parameters = null)
		{
			T newInstance;
			//Surrogates are created as top level objects
			//however reference tracking is important because surrogates with no references
			//are not persisted
			if (parameters == null || parameters.Length == 0)
			{
				//We must create a new instance, instance creation mechanism must be located from
				//the surrogates directory
				newInstance = Activator.CreateInstance<T>();
			}
			else
			{
				newInstance = (T)parameters[0];
			}
			var surrogate = StateManager.Current.surrogateManager.GetSurrogateFor(newInstance, generateIfNotFound: true);
			return newInstance;
		}

		public T ResolveNonSinglentonLogic<T>(object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var t = typeof(T);
			T newInstance = default(T);
			var stateManager = StateManager.Current;
			try
			{
				var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
				if (newInstance != null) { }
				else newInstance = (T)ResolveUnPrepared(t, isRecoveredFromStorage);
				if (!isRecoveredFromStorage)
					InitializeObject(stateManager, this, (ILogic)newInstance, parameters, t, isRecoveredFromStorage, flags);

			}
			finally
			{
				if (newInstance is IStateObject)
					stateManager.RemoveIDInResolution(((IStateObject)newInstance).UniqueID);
			}
			return newInstance;
		}

		public T ResolveNonSinglentonIStateObject<T>(object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var t = typeof(T);
			T newInstance = default(T);
			var stateManager = StateManager.Current;
			try
			{
				var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
				if (newInstance != null) { }
				else newInstance = (T)ResolveUnPrepared(t, isRecoveredFromStorage);
				if (!isRecoveredFromStorage)
					InitializeObject(stateManager, this, (IStateObject)newInstance, parameters, t, flags);
			}
			finally
			{
				if (newInstance is IStateObject)
					stateManager.RemoveIDInResolution(((IStateObject)newInstance).UniqueID);
			}
			return newInstance;
		}

		public object ResolveList(Type type, Func<object> lambdaCreation, object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var stateManager = StateManager.Current;
			IStateObject newInstance = (IStateObject)lambdaCreation();
			stateManager.AddNewTemporaryObject(newInstance, true);
			(newInstance as IVirtualListSerializable).InitializeTheList(
								stateManager as IStateManager,
								stateManager.PageManager as IPageManager,
								stateManager.ReferencesManager as IReferenceManager,
								stateManager.surrogateManager as ISurrogateManager,
								stateManager.UniqueIDGenerator as IUniqueIDGenerator,
								stateManager.ServerEventAggregator);
			if (newInstance is IDependentViewModel && (flags & IIocContainerFlags.NoBuild) != IIocContainerFlags.NoBuild)
			{
				((IDependentViewModel)newInstance).Build(this);
				/* IDependants are now iLogic so this properties are injected in ILogic resolve code */
			}
			var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
			if (!isRecoveredFromStorage)
			{
				if ((flags & IIocContainerFlags.ExtraLean) != IIocContainerFlags.ExtraLean)
				{
					InitializationHelpers.CallInitializeCommon(newInstance, type);
				}
				//First we check to avoid unnecessary calls to GetInitMethod
				if (newInstance is IInitializable && !isRecoveredFromStorage && ((flags & IIocContainerFlags.Lean) != IIocContainerFlags.Lean))
				{
					//Get Init must be done on the instance type, because logicType might refer to an interface
					InitializationHelpers.CallInitMethod((IInitializable)newInstance, parameters);
				}
			}
			return newInstance;
		}


		public object ResolveDictionary(Type type, Func<object> lambdaCreation, object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var stateManager = StateManager.Current;
			IStateObject newInstance = (IStateObject)lambdaCreation();
            ((IObservableDictionaryEntries)newInstance).Initialize(stateManager, stateManager.ReferencesManager, stateManager.surrogateManager);
			stateManager.AddNewTemporaryObject(newInstance, true);
			if (newInstance is IDependentViewModel && (flags & IIocContainerFlags.NoBuild) != IIocContainerFlags.NoBuild)
			{
				((IDependentViewModel)newInstance).Build(this);
				/* IDependants are now iLogic so this properties are injected in ILogic resolve code */
			}
			var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
			if (!isRecoveredFromStorage)
			{
				if ((flags & IIocContainerFlags.ExtraLean) != IIocContainerFlags.ExtraLean)
				{
					InitializationHelpers.CallInitializeCommon(newInstance, type);
				}
				//First we check to avoid unnecessary calls to GetInitMethod
				if (newInstance is IInitializable && !isRecoveredFromStorage && ((flags & IIocContainerFlags.Lean) != IIocContainerFlags.Lean))
				{
					//Get Init must be done on the instance type, because logicType might refer to an interface
					InitializationHelpers.CallInitMethod((IInitializable)newInstance, parameters);
				}
			}
			return newInstance;
		}


		public T ResolveSinglenton<T>(object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var t = typeof(T);
			T newInstance = default(T);
			var stateManager = StateManager.Current;
			try
			{
				var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
				if (!isRecoveredFromStorage)
				{
					flags = flags | IIocContainerFlags.IsSinglenton;
					newInstance = (T)stateManager.GetObject(UniqueIDGenerator.GetSinglentonUniqueId(t));
					if (newInstance != null)
						return newInstance;
					if ((flags & IIocContainerFlags.SinglentonNonReturnIfExisting) == IIocContainerFlags.SinglentonNonReturnIfExisting)
						return default(T);
					//At this point the object was recovered from storage and it the RecoveredFromStorageFlags must
					//added to avoid unnecessary further processing of this object
					isRecoveredFromStorage = (newInstance != null);
				}
				if (newInstance == null) newInstance = (T)ResolveUnPrepared(t, isRecoveredFromStorage);
				if (newInstance is ILogic)
				{
					InitializeObject(stateManager, this, (ILogic)newInstance, parameters, t, isRecoveredFromStorage, flags);
				}
				else if (newInstance is IStateObject)
				{
					if (!isRecoveredFromStorage)
						InitializeObject(stateManager, this, (IStateObject)newInstance, parameters, t, flags);
				}
			}
			finally
			{
				if (newInstance is IStateObject)
					stateManager.RemoveIDInResolution(((IStateObject)newInstance).UniqueID);
			}
			return newInstance;
		}

		public object ResolveReduced(Type t, object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var typeofT = t;
			object newInstance = null;
			var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
			newInstance = newInstance ?? ResolveUnPrepared(t, isRecoveredFromStorage);
			if (newInstance is IViewManager)
			{
				//Nothing to do
			}
			else
			{
				if (!alreadyAssertedTypes.Contains(t))
				{
					alreadyAssertedTypes.Add(t);
					Trace.TraceError("IocContainerImplWithUInity::Resolve WARNING: Type to resolved [" + t.FullName + "] is not an IStateObject, so there is no tracking or serialization available for that object");
				}
			}
			return newInstance;
		}

		public object Resolve(Type t, object[] parameters = null, IIocContainerFlags flags = IIocContainerFlags.None)
		{
			var typeofT = t;
			object newInstance = null;
			var stateManager = StateManager.Current;
			if (SurrogatesDirectory.IsSurrogateRegistered(typeofT))
			{
				//Surrogates are created as top level objects
				//however reference tracking is important because surrogates with no references
				//are not persisted
				if (parameters == null || parameters.Length == 0)
				{
					//We must create a new instance, instance creation mechanism must be located from
					//the surrogates directory
					newInstance = SurrogatesDirectory.CreateInstanceFor(typeofT);
				}
				else
				{
					newInstance = parameters[0];
				}
				var surrogate = stateManager.surrogateManager.GetSurrogateFor(newInstance, generateIfNotFound: true);
				return newInstance;
			}
			try
			{
				var isRecoveredFromStorage = (flags & IIocContainerFlags.RecoveredFromStorage) == IIocContainerFlags.RecoveredFromStorage;
				if (!isRecoveredFromStorage)
				{
					if (t.GetCustomAttributes(typeof(Singleton), false).Length > 0)
					{
						flags = flags | IIocContainerFlags.IsSinglenton;
						newInstance = StateManager.Current.GetObject(UniqueIDGenerator.GetSinglentonUniqueId(t));
						if ((flags & IIocContainerFlags.SinglentonNonReturnIfExisting) == IIocContainerFlags.SinglentonNonReturnIfExisting)
							if (newInstance != null)
								return null;
						if ((flags & IIocContainerFlags.SinglentonReturnIfExisting) == IIocContainerFlags.SinglentonReturnIfExisting)
							if (newInstance != null)
								return newInstance;
						//At this point the object was recovered from storage and it the RecoveredFromStorageFlags must
						//added to avoid unnecessary further processing of this object
						isRecoveredFromStorage = (newInstance != null);
					}
				}
				newInstance = newInstance ?? ResolveUnPrepared(t, isRecoveredFromStorage);
				if (newInstance is IViewManager)
				{
					//Nothing to do
				}
				else if (newInstance is ILogic)
				{
					InitializeObject(stateManager, this, (ILogic)newInstance, parameters, t, isRecoveredFromStorage, flags);
				}
				else if (newInstance is IStateObject)
				{
					if (!isRecoveredFromStorage)
						InitializeObject(stateManager, this, (IStateObject)newInstance, parameters, t, flags);
				}
				else
				{
					if (!alreadyAssertedTypes.Contains(t))
					{
						alreadyAssertedTypes.Add(t);
						Trace.TraceError("IocContainerImplWithUInity::Resolve WARNING: Type to resolved [" + t.FullName + "] is not an IStateObject, so there is no tracking or serialization available for that object");
					}
				}
			}
			finally
			{
				if (newInstance is IStateObject)
					stateManager.RemoveIDInResolution(((IStateObject)newInstance).UniqueID);
			}
			return newInstance;
		}

		static HashSet<Type> alreadyAssertedTypes = new HashSet<Type>();


		#endregion

		internal static void ResetSingleton()
		{
			_current = null;
		}

		public object ResolveUnPrepared(Type t, bool isRecoveredFromStorage = false)
		{
			object newInstance;
			try
			{
				if (typeof(IStateObject).IsAssignableFrom(t))
				{
					if (typeof(NoInterception).IsAssignableFrom(t))
					{
						newInstance = Activator.CreateInstance(t);
					}
					else
						newInstance = Intercept.NewInstance(t, isRecoveredFromStorage ? _lazyBehavior : _lazyBehaviorNewInstance);
				}
				else
				{
					if (typeof(IViewManager) == t)
					{
						return ViewManager.Instance;
					}

					//It is not an state object. Only instrument if IList o IDictionary
					if (t.IsSupportedCollectionType())
					{
						newInstance = Intercept.NewInstance(t, isRecoveredFromStorage ? _lazyBehavior : _lazyBehaviorNewInstance);
					}
					else //no. just create plain instance
						newInstance = t.CreateInstance();
				}
			}
			catch (NotSupportedException)
			{
				newInstance = Activator.CreateInstance(t);
				TraceUtil.WriteLine(String.Format("Warning unregistered type instance for type {0}", t.AssemblyQualifiedName));
			}
			return newInstance;
		}


		/// <summary>
		/// NOTE: this method is called *ONLY* if the object DOES not come from storage
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="parameters"></param>
		/// <param name="t"></param>
		/// <param name="isRecovedFromStorage"></param>
		private static void InitializeObject(StateManager stateManager, IIocContainer container, IStateObject obj, object[] parameters, Type t, IIocContainerFlags flags)
		{
			if ((flags & IIocContainerFlags.IsSinglenton) == IIocContainerFlags.IsSinglenton)
			{
				//Unique ID 
				obj.UniqueID = UniqueIDGenerator.GetSinglentonUniqueId(t);
			}
			else
			{
				//If it doesn't come from storage we must setup the UniqueID
				//that will be use later on for persistance
				if (!StateManager.IsRootLevelObject(obj))
				{
					obj.UniqueID = stateManager.UniqueIDGenerator.GetUniqueIDForTemporaryObject();
					//A new temparary object was created and it's in resolution.
					stateManager.AddIDInResolution(obj.UniqueID);
				}
				else
				{
					if (obj is IModel)
						obj.UniqueID = stateManager.UniqueIDGenerator.GetUniqueIDForModel();
					else
						obj.UniqueID = stateManager.UniqueIDGenerator.GetUniqueID();
				}
			}
			stateManager.AddNewObject(obj);
			if (obj is IDependentViewModel && (flags & IIocContainerFlags.NoBuild) != IIocContainerFlags.NoBuild)
			{
				try
				{
					ViewManager.Instance.Events.Suspend();
					((IDependentViewModel)obj).Build(container);
				}
				finally
				{
					ViewManager.Instance.Events.Resume();
				}
				/* IDependants are now iLogic so this properties are injected in ILogic resolve code */
			}
		}

		static object[] EmptyArgs = new object[0];


		private static void InitializeObject(StateManager stateManager, IIocContainer container, ILogic logic, object[] parameters, Type logicType, bool isRecoveredFromStorage, IIocContainerFlags flags)
		{
			var isNewLogic = true;
			bool autoWired = false;
			bool isNoView = false;
			//Was this an ILogicView<T>
			if (logic is ILogicView<IViewModel>)
			{
				IViewModel viewModel = null;
				isNoView = (flags & IIocContainerFlags.NoView) == IIocContainerFlags.NoView;
				//Do we need to create a view for this logic object???
				if (isNoView)
				{
					isNewLogic = false;
				}
				else
				{
					PropertyInfo viewModelProp = logicType.Property("ViewModel"); //This type is fix but arbitrary
					//Is there a view parameter? it should be the first one. If not we will consider that is a constructor parameter
					if (parameters != null && parameters.Length > 0 && parameters[0] is IViewModel)
					{
						viewModel = (IViewModel)parameters[0];
						//In case we are providing aditional parameter it determines if the logic instance is new
						//this case can't be determine within the this method so it needs to be passed as an aditional value in the parameters 
						isNewLogic = parameters.Length > 1 ? (bool)parameters[1] : false;
					}
					else
					{   //Ok. We still dont have a view so we need to create one. We require the property to get the actual PropertyType of the logic
						viewModel = (IViewModel)container.Resolve(viewModelProp.PropertyType);
						try
						{
							ViewManager.Instance.Events.Suspend();
							viewModel.Build(container);
						}
						finally
						{
							ViewManager.Instance.Events.Resume();
						}

					}
					viewModelProp.SetValue(logic, viewModel, null);
					if (!isRecoveredFromStorage)
					{
						autoWired = true;
						ViewManager.Instance.Events.AutoWireEvents(logic);
					}
				}
			}
			// lets inject the container
			if (logic is ICreatesObjects)
			{
				((ICreatesObjects)logic).Container = container;
			}
			if (logic is IInteractsWithView)
			{
				((IInteractsWithView)logic).ViewManager = ViewManager.Instance;
			}

			if (!isRecoveredFromStorage)
			{
				// lets inject all IViewModel properties  
				if (logic is IStateObject)
				{
					InitializeObject(stateManager, container, (IStateObject)logic, parameters, logicType, flags);
					//Only Visual objects need autowire.
					if (!autoWired && logic is IDependentViewModel)
						ViewManager.Instance.Events.AutoWireEvents(logic);
				}
				if (isNewLogic)
				{
					if ((flags & IIocContainerFlags.ExtraLean) != IIocContainerFlags.ExtraLean)
					{
						InitializationHelpers.CallInitializeCommon(logic, logicType);
					}
					//First we check to avoid unnecessary calls to GetInitMethod
					if (logic is IInitializable && !isRecoveredFromStorage && !isNoView && ((flags & IIocContainerFlags.Lean) != IIocContainerFlags.Lean))
					{
						//Get Init must be done on the instance type, because logicType might refer to an interface
						InitializationHelpers.CallInitMethod((IInitializable)logic, parameters);
					}
				}
			}
            else
            {
                var dict = logic as IObservableDictionaryEntries;
                if (dict!=null)
                {
                    dict.Initialize(stateManager, stateManager.ReferencesManager, stateManager.surrogateManager);
                }
            }
		}


		public void Bind(string objproperty, IStateObject obj, string dsproperty, object ds)
		{
			StateManager.Current.Bind(this, obj, objproperty, ds, dsproperty);
		}


		public void AddPostResolveAction(object newValue, Action postAction)
		{
			StateManager.Current.AddPostResolveAction(newValue, postAction);
		}

		public XmlReferenceWrapper GetXmlReference(IStateObject obj)
		{
			return new XmlReferenceWrapperImpl(obj);
		}

		public XmlReferenceWrapper GetXmlReference(object parentCandidate, IStateObject obj)
		{
			return new XmlReferenceWrapperImpl(parentCandidate, obj);
		}

	}
}
