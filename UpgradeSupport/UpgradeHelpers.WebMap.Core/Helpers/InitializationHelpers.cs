using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UpgradeHelpers.Helpers
{
	public static class InitializationHelpers
	{
		/// <summary>
		/// Validates that the given method is compatible with the input parameters.
		/// </summary>
		/// <param name="m"></param>
		/// <param name="paramsTypes"></param>
		/// <returns></returns>
		public static bool IsMethodValidCandidate(MethodInfo m, IEnumerable<Type> paramsTypes)
		{
			if (m.Name.EndsWith("Init") &&
               //When MethodInfo was getting from Interface MethodInfo.Name doesn't contains the interface name, but its DeclaringType is the Interface
               ((m.DeclaringType != null && m.DeclaringType.FullName.IndexOf("UpgradeHelpers.Interfaces.IInitializable") == 0) ||
                 //When MethodInfo was getting from the class Type MethodInfo.Name contains the interface name, but its DeclaringType is the class
                 m.Name.IndexOf("UpgradeHelpers.Interfaces.IInitializable") == 0))
            {
				if (m.GetParameters().Length != paramsTypes.Count()) return false;

				var InitParameters = m.GetParameters();
				var i = 0;
				foreach (var initParameter in InitParameters)
				{
					if (initParameter.ParameterType != paramsTypes.ElementAt(i))
					{
						if (paramsTypes.ElementAt(i).Equals(typeof (Nullable)))
						{
							var type = initParameter.ParameterType;
							if (!type.IsValueType)
							{
								i++;
								continue;
							}
						}
						if (!initParameter.ParameterType.IsAssignableFrom(paramsTypes.ElementAt(i)))
							return false;
					}
					i++;
				}
				return true;
			}
			return false;
		}


        //Cached interfaces 
        private static ConcurrentDictionary<Tuple<Type, string>, MethodInfo> cachedInterfaces = new ConcurrentDictionary<Tuple<Type, string>, MethodInfo>();

        /// <summary>
        /// Runs over the Ilogic item interfaces
        /// collects and select the init method best candidate
        /// also updates the entries on the cachedInterfaces dictionary 
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="logicType"></param>
        /// <param name="paramsTypes"></param>
        /// <param name="paramsSignature"></param>
        /// <returns></returns>
        private static MethodInfo SelectInitMethod(Type logicType, Type[] paramsTypes, string paramsSignature)
        {
            var interfaces = logicType.GetInterfaces(); // "IInitializable`"+parameters.Length);
            var initCandidates = new List<MethodInfo>();


            foreach (var @interface in interfaces)
            {
                if (typeof(Interfaces.IInitializable).IsAssignableFrom(@interface) &&
                    @interface.GetGenericArguments().Length == paramsTypes.Length)
                {
                    var method = @interface.GetMethods().FirstOrDefault(m => InitializationHelpers.IsMethodValidCandidate(m, paramsTypes));
                    if (method != null)
                    {
                        initCandidates.Add(method);
                    }
                }
            }
            if (initCandidates.Count > 0)
            {
                var initBestCandidate = InitializationHelpers.GetSelectedInit(initCandidates, paramsTypes);
                cachedInterfaces.TryAdd(new Tuple<Type, string>(logicType, paramsSignature), initBestCandidate);
                return initBestCandidate;
            }
            return null;
        }

        private static readonly object InitializableCommonExecutionHierachyLock = new object();
        private static readonly IDictionary<Type, IList<Type>> InitializableCommonExecutionHierachy = new Dictionary<Type, IList<Type>>();

        internal static void SetInitializableCommonExecutionHierachy(Type type, IList<Type> hierachy)
        {
            if (hierachy != null)
                InitializableCommonExecutionHierachy.Add(type, hierachy);
        }

        internal static bool TryGetInitializableCommonExecutionHierachy(Type type, out IList<Type> hierachy)
        {
            return InitializableCommonExecutionHierachy.TryGetValue(type, out hierachy);
        }

        static string CommonMethodName = typeof(Interfaces.IInitializableCommon).FullName + ".Common";


        static bool IsEmptyMethod(MethodInfo mi)
        {
            var il = mi.GetMethodBody().GetILAsByteArray();
            if (il.Length == 1 && il[1] == 42)
                return true;
            else if (il.Length == 2 && il[0] == 0 && il[1] == 42)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Obtains or loads into cache a list of the class hierarchy.
        /// This is needed because the IInitializableCommon.Common methods must be called following that order.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<Type> LoadTypeHierarchy(Type type, bool checkforEmptyMethods = false)
        {
            IList<Type> baseList;
            lock (InitializableCommonExecutionHierachyLock)
            {
                if (!TryGetInitializableCommonExecutionHierachy(type, out baseList))
                {
                    baseList = new List<Type>();
                    var current = type;
                    while (current != null && typeof(Interfaces.IInitializableCommon).IsAssignableFrom(current))
                    {
                        if (checkforEmptyMethods)
                        {
                            var method = current.GetMethod(CommonMethodName, BindingFlags.NonPublic | BindingFlags.Instance);
                            if (!IsEmptyMethod(method))
                            {
                                baseList.Insert(0, current);
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            baseList.Insert(0, current);
                        }
                        current = current.BaseType;
                    }
                    SetInitializableCommonExecutionHierachy(type, baseList);
                }
            }
            return baseList;
        }

        public static void CallInitializeCommon(object logic, Type logicType)
        {
            var baseList = LoadTypeHierarchy(logicType);            
            foreach (var typeToExecuteCommon in baseList)
            {
                MethodInfo fieldInitializer = typeToExecuteCommon.GetMethod("UpgradeHelpers.Interfaces.IInitializableCommon.Common", BindingFlags.Instance | BindingFlags.NonPublic);
                if (fieldInitializer != null)
                {
                    fieldInitializer.Invoke(logic, new object[] { });
                }
            }
        }

        /// Selects an Init method for the given parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="logicType"></param>
        /// <returns></returns>
        public static void CallInitMethod(Interfaces.IInitializable logic, object[] parameters)
        {
            if (logic == null) return;
            if (parameters != null && parameters.Length > 0)
            {
                //We need to determine the parameter types because we will use them
                //to do two things:
                // 1. Determine from possible Initializable.Init<T1,...,T2> methods which should be called
                // 2. calculate a parameter signature to the possible init
                var parameterTypes = new Type[parameters.Length];
                StringBuilder parametersSignatureBuilder = new StringBuilder();
                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    var parameter = parameters[i];
                    parameterTypes[i] = (parameter == null) ? typeof(Nullable) : parameter.GetType();
                    parametersSignatureBuilder.Append(parameterTypes[i].ToString());
                }
                var paramsSignature = parametersSignatureBuilder.ToString();
                Type logicType = logic.GetType();
                MethodInfo initMethod = null;
                if (!cachedInterfaces.TryGetValue(new Tuple<Type, string>(logicType, paramsSignature), out initMethod))
                {
                    initMethod = SelectInitMethod(logicType, parameterTypes, paramsSignature);

                }
                if (initMethod != null)
                    initMethod.Invoke(logic, parameters);
            }
            else
            {
                logic.Init();
            }
        }


		/// <summary>
		/// This method looks for the best Init candidate
		/// for the given parameters.
		/// </summary>
		/// <param name="initCandidates">A list with the Init Candidates</param>
		/// <param name="parameters">An array with the parameters</param>
		/// <returns>Best Init Candidate method</returns>
		public static MethodInfo GetSelectedInit(List<MethodInfo> initCandidates, IEnumerable<Type> parameters)
		{
			if (initCandidates.Count > 1)
			{
				List<Tuple<MethodInfo, int>> qualifiedCandidates = new List<Tuple<MethodInfo, int>>();
                var indexHierarchy = 0;
                foreach (var initCandidate in initCandidates)
				{
					var initParams = initCandidate.GetParameters();
					var grade = 0;
					var index = 0;
					foreach (var @param in initParams)
					{
                        if (@param.ParameterType == parameters.ElementAt(index)
                            //If the parameter is an instrumented class, 
                            //it will be a Unity Wrapped Class that extends from the original class.
                            //So we have to check it against its BaseType, which is the correct candidate to be compared.
                            || (@param.ParameterType == parameters.ElementAt(index).BaseType && ValidateIfImplementsUnity(((TypeInfo)parameters.ElementAt(index)).ImplementedInterfaces)))
                        {
                            //Those that matches with the parameter type will have a greater grade.
                            grade++;
                        }
                        index++;
                    }
                    //qualifiedCandidates.Add(new Tuple<MethodInfo, int>(initCandidate, indexHierarchy + (grade * 100))); //MOBILIZE,11/16/2016,TODO,JAQR,"this sentence add support to correct return of the Hierarchy when include N-leves in class, sample class Atalasot->FreehandHotSpotData,TWFreehandHotSpotAnnotation"
                    qualifiedCandidates.Add(new Tuple<MethodInfo, int>(initCandidate, grade));
                    indexHierarchy++;
                }
                //We are going to sort it using the Item2 (the grade), so the one that has higher grade, will be at the end of the list.

                qualifiedCandidates.Sort((x, y) => x.Item2.CompareTo(y.Item2));
				return qualifiedCandidates.Last().Item1;
			}
			if (initCandidates.Count == 1)
			{
				return initCandidates.First();
			}
			return null;
		}
        public static bool ValidateIfImplementsUnity(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                if (String.CompareOrdinal(type.FullName, "Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy") == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}