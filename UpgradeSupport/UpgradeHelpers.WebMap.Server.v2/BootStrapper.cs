
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;


namespace UpgradeHelpers.WebMap.Server
{
    public static class Bootstrapper
    {

        static bool initialized = false;
        /// <summary>
        /// Performs several initialization tasks, related to the IoCContainer setup
        /// All types are registered here for interception.
        /// </summary>
        /// <returns></returns>
		public static void Initialize(Assembly mainAssembly = null)
        {
            //System.Web.HttpContext.Current.ApplicationInstance.BeginRequest -= ApplicationInstance_BeginRequest;
            //System.Web.HttpContext.Current.ApplicationInstance.BeginRequest += ApplicationInstance_BeginRequest;


            if (initialized) return;

            Debug.WriteLine("WebMap Application not initialized. Starting initialization");
            TypePropertiesCache.SetupInterceptionDelegates(
               new InterceptionDelegates()
               {
                   isASupportedValueTypeForIListDelegate = TypeCacheUtils.IsSupportedGenericTypeForList,
				   ProcessGetterNoAction = LazyBehaviours.ProcessGetterNoAction,
				   ProcessGetterNonTopLevelIStateObject = LazyBehaviours.ProcessGetterNonTopLevelIStateObject,
				   ProcessGetterStrongReference = LazyBehaviours.ProcessGetterStrongReference,
				   ProcessGetterSurrogate = LazyBehaviours.ProcessGetterSurrogate,
				   ProcessGetterTopLevelIStateObject = LazyBehaviours.ProcessGetterTopLevelIStateObject,
				   ProcessGetterWeakReference = LazyBehaviours.ProcessGetterWeakReference,
				   ProcessSetterMostCases = LazyBehaviours.ProcessSetterMostCases,
				   ProcessSetterObjectReference = LazyBehaviours.ProcessSetterObjectReference,
				   ProcessSetterSimpleTypes = LazyBehaviours.ProcessSetterSimpleTypes,
				   ProcessSetterStrongReference = LazyBehaviours.ProcessSetterStrongReference,
				   ProcessSetterSurrogate = LazyBehaviours.ProcessSetterSurrogate,
				   ProcessSetterWeakReference = LazyBehaviours.ProcessSetterWeakReference,
				   ProcessSetterVisibleState = LazyBehaviours.ProcessSetterVisibleState
               });
            SurrogatesDirectory.TypeToContractedString = TypeCacheUtils.AssemblyQualifiedNameCache;
            SurrogatesDirectory.ContractedStringToType = TypeCacheUtils.GetType;

            var aliasConfig = System.Configuration.ConfigurationManager.AppSettings["UniqueIDAliasEnabled"];
            var aliasEnabled = false;
            if (aliasConfig != null)
                aliasEnabled = Convert.ToBoolean(aliasConfig);
            TypePropertiesCache.ALIAS_ENABLED = aliasEnabled;

            //Connect delegates that are required by Dictionary implementations
            DictionaryUtils.Current = StateManager.GetCurrent;
            DictionaryUtils.CreatePromise = EventPromiseInfo.CreateEventInstancePromise;
            DictionaryUtils.RetrieveDelegateFromPromise = PromiseUtils.RetrieveDelegateFromPromise;
            DictionaryUtils.GetObjectContainingMethod = EventPromiseInfo.GetObjectContainingMethod;

            MEFManager.PlatformInitializer().Initialize();

			BaseClassFindInit._findMethod = (_baseType, parameters, types) =>
            {
                Type[] paramsTypes = new Type[] { };
                if (types != null)
                    paramsTypes = types;
                var initCandidates = new List<MethodInfo>();

                var methods = _baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var methodInfo in methods)
                {
                    if (InitializationHelpers.IsMethodValidCandidate(methodInfo, paramsTypes)) //explicit interface implementation
                    {
                        initCandidates.Add(methodInfo);
                    }
                }
                var selectedInit = InitializationHelpers.GetSelectedInit(initCandidates, paramsTypes);
                return selectedInit;
            };

			IocContainerImplWithUnity.InitializeResolver();
			var container = IocContainerImplWithUnity.Current;

			
            RegisterAllTypes(container, mainAssembly);
            TypeCacheUtils.LoadClientTypeMetadataTable();
            initialized = true;
            Debug.WriteLine("WebMap Runtime Initialization DONE!");
        }



        /// <summary>
        /// Safely gets all types from an assembly. It catches any Type Reflection errors 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static IList<Type> GetAssemblyTypes(System.Reflection.Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (Exception ex)
            {
                TraceUtil.TraceError("Bootstrapper::GetAssemblyTypes problem while getting type from assembly " + assembly.FullName + " Message [" + ex.Message + "]");
                return new Type[] { };
            }
        }

        /// <summary>
        /// Holds a list of all assemblies that will be processed to register types for interception
        /// </summary>
        internal static List<Assembly> _assembliesToExtractTypesForRegistration = null;

        /// <summary>
        /// 
        /// Registers all types.
        /// This process is very important.
        /// For example if you have a multi node setup. All nodes must have the same assemblies
        /// Having an inconsistent assembly list can produce inconsistent types tables
        /// </summary>
        /// <param name="container">Container.</param>
		public static void RegisterAllTypes(IocContainerImplWithUnity container, Assembly mainAssembly = null)
        {


            IEnumerable<Type> typesToRegister;
            var coreAssemblyName = typeof(IStateObject).Assembly.GetName();
            _assembliesToExtractTypesForRegistration = _assembliesToExtractTypesForRegistration ??
                        new List<Assembly>(
                            System.Web.Compilation.BuildManager.GetReferencedAssemblies()
                            .Cast<Assembly>()
                            .Where(x => x.GetReferencedAssemblies().Any(y => y.Name == coreAssemblyName.Name) && !x.IsDynamic));
            if (mainAssembly != null)
                _assembliesToExtractTypesForRegistration.Add(mainAssembly);



            typesToRegister = from assemblyFile in _assembliesToExtractTypesForRegistration
                              from t in GetAssemblyTypes(assemblyFile)

                              select t;
            var sw = new Stopwatch();
            sw.Start();

            TraceUtil.TraceInformation("Start Registering all surrogates");
            SurrogateManager.RegisterSurrogates(typesToRegister);
            RegisterAppStateConverters(typesToRegister);
            TraceUtil.TraceInformation("Start Registering Types for interception");
            container.RegisterTypes(typesToRegister);


            //We will force loding the tables with information about autowire metadata. That is registing events for methods
            //with the [Handler] attribute
        //    TypeCacheUtils.NeedsAutoWire(typesToRegister);

            RegisterDeltaTrackerConverters();
            StateManager.AddConverters();
            sw.Stop();
            TraceUtil.TraceInformation(string.Format("End Registering Types. Elapsed Time {0} ms", sw.ElapsedMilliseconds));
        }

        /// <summary>
        /// TODO Review if this feature is used, becuase no references are found
        /// </summary>
        private static void RegisterDeltaTrackerConverters()
        {
            foreach (var deltaConverteAtt in DeltaTracker.deltaTrackerConverters)
            {
                DeltaTracker.RegisterDeltaTrackerConverter(deltaConverteAtt.Item1, deltaConverteAtt.Item2);
            }
        }

        internal static void RegisterAppStateConverters(IEnumerable<Type> typesToRegister)
        {
            foreach (var typeToRegister in typesToRegister)
            {
                var stateconverterAtt = Attribute.GetCustomAttribute(typeToRegister, typeof(AppStateJsonConverter), false) as AppStateJsonConverter;
                ///Register a converter so it will be used when deserializing data from the client requests
                if (stateconverterAtt != null)
                {
                    try
                    {
                        var converter = Activator.CreateInstance(typeToRegister) as Newtonsoft.Json.JsonConverter;
                        if (stateconverterAtt.ConverterKind == StateConverterKind.Client || stateconverterAtt.ConverterKind == StateConverterKind.Both)
                            StateManager.AddConverter(converter);

                        if (stateconverterAtt.ConverterKind == StateConverterKind.Server || stateconverterAtt.ConverterKind == StateConverterKind.Both)
                            StateManager.AddServerSideConverter(converter);
                    }
                    catch (Exception e)
                    {
                        TraceUtil.TraceError("Bootstrapper::RegisterAllTypes Error registering converter type " + typeToRegister.FullName + " message " + e.Message);
                    }
                }
            }
        }


    }
}