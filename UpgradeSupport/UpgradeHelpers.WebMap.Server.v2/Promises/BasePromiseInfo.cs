using Fasterflect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Promises;

namespace UpgradeHelpers.WebMap.Server
{

	public enum PromiseState
	{
		Blocked, //The promise can't be executed at this time.
		Pending,//The result is now complete a possible sibling might be found and executed if that is the case.
		Rejected,//The execution failed.
		Resolved,//The promise was executed successfully, if thats the case any possible sibling won't be executed.
        Unblocked,//Ready to be consumed.
		Exploited,//Added new promises
		Default,//Initial state for AsyncBuilder
        Skipped,//The promise will not be executed. A prior promise was a return.
        Pinned, //State that is holded depending on conditions
        Unpinned, //State that is any longer holded and must be removed and not resolved
        LoopBreak, //State to stop the current pinned promise
        LoopContinue, //State to restart the current pinned promise

	}
	/// <summary>
	/// The type of the promise.
	/// </summary>
	public enum PromiseType
	{
		CodeExecution,
		Return,
		Catch,
		Finally
	}

#if WEBMAPVS && DEBUG
	[System.Diagnostics.DebuggerVisualizer(typeof(UpgradeHelpers.WebMap.Server.DebugEx.PromiseDebugVisualizer))]
#endif
	[Serializable]
	internal abstract class BasePromiseInfo<T> : BasePromiseInfo, IPromise<T>, NoInterception
	{
        public abstract T ResolvedValue { get; set; }
    }




#if (WEBMAPVS2013 || WEBMAPVS2015) && DEBUG

	public class PromiseLocationObjectSource : Microsoft.VisualStudio.DebuggerVisualizers.VisualizerObjectSource
	{
		public override void GetData(object target, System.IO.Stream outgoingData)
		{
			var writer = new System.IO.StreamWriter(outgoingData);
			writer.WriteLine(((BasePromiseInfo)target).UserCodeInfo);
			writer.Flush();
		}
	}

	 [DebuggerVisualizer(
		typeof(UpgradeHelpers.WebMap.Server.DebugEx.PromiseDebugVisualizer),
		typeof(PromiseLocationObjectSource))]

	
#endif
    internal abstract class BasePromiseInfo : Helpers.Promise, IPromise, IStateObject, IInternalData, NoInterception, IDependentsContainer
	{
		 public List<string> Dependents
		 {
			 get;
			 set;
		 }

#if DEBUG
        public string UserCodeInfo { get; set; }
#endif


        #region State

        public bool NeedsSerialization;
        public object CodeTarget;
        public string ContinuationID;

        private IStateObject _objectContainingMethod;

        [JsonIgnore]
        public IStateObject ObjectContainingMethod
        {
            get
            {
                if (_objectContainingMethod == null)
                {
                    if (!string.IsNullOrWhiteSpace(StateObjectUniqueId))
                    {
                        _objectContainingMethod = StateManager.Current.GetObject(StateObjectUniqueId);
                    }
                }
                return _objectContainingMethod;
            }
            set { _objectContainingMethod = value; }

        }

        public IStateObject GetObjectContainingMethod(IStateManager stateManager)
        {
            if (_objectContainingMethod == null)
            {
                if (!string.IsNullOrWhiteSpace(StateObjectUniqueId))
                {
                    _objectContainingMethod = stateManager.GetObject(StateObjectUniqueId);
                }
            }
            return _objectContainingMethod;
        }

        public void SetObjectContainingMethod(IStateObject value)
        {
            _objectContainingMethod = value;
        }

        private string _iStateObjectUniqueId;
        

        public string StateObjectUniqueId
        {
            get
            {
                if (_objectContainingMethod != null)
                    return _objectContainingMethod.UniqueID;
                return _iStateObjectUniqueId;
            }
            set { _iStateObjectUniqueId = value; }
        } /* For viewmodel associated with logic containing method */

        public string ContinuationFields { get; set; }
        public string ModalUniqueId { get; set; }
        public string DeclaringType { get; set; }
        public string MethodName { get; set; }
        public string TargetType { get; set; }
        public string DelegateType { get; set; }
		public PromiseType PromiseType { get; set; }

        #endregion


        /// <summary>
        /// Performs the call to the method thru reflection and catches and rethrows any exceptions
        /// </summary>
        /// <param name="method">MethodInfo of the method to be invoked</param>
        /// <param name="logic">and instance of the object that has the definition of the method</param>
        /// <param name="parameters">the parameters needed by that method</param>
        private static object InvokeMethodEx(MethodInfo method, object logic, object[] parameters)
        {
            try
            {
                return method.Invoke(logic, parameters);
            }
			catch (TargetInvocationException tiex)
            {
				var baseException = tiex.GetBaseException();
				PreserveStackTrace(baseException);
				throw baseException;
            }
        }

        /// <summary>
		/// This method implements a workaround to return the appropiate stack trace.
		/// Keep in mind that this may break at any time, as private fields are not part of API
		/// This is used to properly setup the stack trace for the inner exception.
		/// Works on 4.0 and 4.5 and 4.5.1 it might not work on other versions of the framework
		/// </summary>
		/// <param name="e"></param>
		private static void PreserveStackTrace(Exception e)
        {
            try
            {
                var ctx =
                    new System.Runtime.Serialization.StreamingContext(
                        System.Runtime.Serialization.StreamingContextStates.CrossAppDomain);
                var mgr = new System.Runtime.Serialization.ObjectManager(null, ctx);
                var si = new System.Runtime.Serialization.SerializationInfo(e.GetType(),
                    new System.Runtime.Serialization.FormatterConverter());

                e.GetObjectData(si, ctx);
                mgr.RegisterObject(e, 1, si); // prepare for SetObjectData
                mgr.DoFixups(); // ObjectManager calls SetObjectData

                // voila, e is unmodified save for _remoteStackTraceString
            }
            catch
            {
                //If it doesnt work then, just do as always. There is nothing else we can do
            }
        }


        internal Type GetArgumentType()
        {
            Type result = null;
            var classType = TypeCacheUtils.GetType(DeclaringType);
            var method = classType.Method(MethodName,
               BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            var parameters = method.Parameters();
            if (parameters.Count != 0)
            {
                result = parameters[0].ParameterType;
            }
            return result;
        }


        /// <summary>
        /// Executes the continuation
        /// </summary>
        protected override object Execute(params object[] parameters)
        {
            var classType = TypeCacheUtils.GetType(DeclaringType);
            object execute=null;
            ExecuteDelegate(parameters, classType, out execute);
            return execute;
        }

        

        /// <summary>
        /// This is wrapper to setup make the delegate invocation with Reflection
        /// <C>IModel</C>, <c>IDependentModel</c> or <c>IUserControl</c>
        /// </summary>
        /// <returns>Return <value>true</value> if Method was excecuted</returns>
        private bool ExecuteDelegate(object[] parameters, Type classType, out object execute)
        {
            MethodInfo method;
            var targetType = classType;
            execute = null;
            object instance = null;
            if (TargetType != null)
            {
                var oldTargetType = targetType;
                targetType = TypeCacheUtils.GetType(TargetType) ?? oldTargetType;
            }
            if (TypeCacheUtils.IsSpecialClass(classType))
            {
                if (NeedsSerialization /*Data is still in memory*/)
                {
                    instance = CodeTarget;
                }
                else
                {
                    var displayInstanceSurrogate = ObjectContainingMethod as StateObjectSurrogate;
                    if (displayInstanceSurrogate != null)
                        instance = displayInstanceSurrogate.Value;
                }
            }
            else if (typeof(ILogicWithViewModel<IStateObject>).IsAssignableFrom(classType))
            {
                SetupFormInformationForDelegateInvocation(classType, targetType, out instance);
            }

            //Is this a method on a class or an userControl?
            else if (typeof(IStateObject).IsAssignableFrom(classType))
            {
                if (StateObjectUniqueId == null)
                {
                    //This means that the method is static
                    instance = null;
                }
                else
                {
                    //In the case of classes and usercontrols the logic will be in the same class instance
                    instance = StateManager.Current.GetObject(StateObjectUniqueId) ??
                            (IStateObject)
                                IocContainerImplWithUnity.Current.Resolve(classType, parameters: null,
                                    flags: IIocContainerFlags.NoView);
                }
            }
            method = classType.Method(MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            execute = InvokeMethodEx(method, instance, parameters);
            return true;
        }

        private void SetupFormInformationForDelegateInvocation(Type classType, Type targetType, out object logic)
        {
            if (StateObjectUniqueId == null)
            {
                //This means that the method is static
                logic = null;
                //method = classType.Method(MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            }
            else
            {
                var vm = StateManager.Current.GetObject(StateObjectUniqueId);
                logic = IocContainerImplWithUnity.Current.Resolve(targetType, new object[] { vm });
                //method = classType.Method(MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                try
                {
                    if (((ILogicWithViewModel<IStateObject>)logic).ViewModel == null)
                    {
                        PropertyInfo pInfo = logic.GetType().Property("ViewModel");
                        if (pInfo != null && pInfo.CanWrite)
                        {
                            pInfo.SetValue(logic, vm, null);
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        internal static BasePromiseInfo BuildContinuationInfo(StateManager stateManager, BasePromiseInfo promise, Delegate code, string continuationid = null, object target = null)
        {
            object instance = target ?? code.Target;
            string methodArgs = null;
            var parameters = code.Method.GetParameters();
            if (parameters.Length > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var parameter in parameters)
                {
                    builder.Append(parameter.ParameterType.AssemblyQualifiedNameCache());
                    builder.Append("|");
                }
                methodArgs = builder.ToString();
            }


            if (instance == null)
            {
                //This might be an static method
                Type declaringType = code.Method.DeclaringType;
                string methodName = code.Method.Name;
                Debug.Assert(declaringType != null, "declaringType != null");
                promise.DeclaringType = declaringType.AssemblyQualifiedNameCache();
                promise.SetObjectContainingMethod(null);
                promise.TargetType = null;
                promise.MethodName = methodName;
                promise.ModalUniqueId = continuationid;
				promise.UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID();
                promise.MethodArgs = methodArgs;
                return promise;
            }

            var instanceTyped = instance as ILogicWithViewModel<IStateObject>;
            if (instanceTyped != null)
            {
                IStateObject viewModel = instanceTyped.ViewModel;
                Type declaringType = code.Method.DeclaringType;
                string methodName = code.Method.Name;
                //Pushing a new continuation
                Debug.Assert(declaringType != null, "declaringType != null");

                promise.DeclaringType = declaringType.AssemblyQualifiedNameCache();
                promise.SetObjectContainingMethod(viewModel);
                promise.TargetType = instanceTyped.GetType().AssemblyQualifiedNameCache();
                promise.MethodName = methodName;
                promise.ModalUniqueId = continuationid ?? (viewModel != null ? viewModel.UniqueID : null);
				promise.UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID();
                promise.MethodArgs = methodArgs;
                return promise;
            }
            if (instance is IModel || instance is IDependentModel || instance is IUserControl)
            {
                //Both LogicClasses and Usercontrols are a mix between code and logic
                //and they have an UniqueID because they are state objects
                IStateObject viewModel = (IStateObject)instance;
                Type declaringType = code.Method.DeclaringType;
                string methodName = code.Method.Name;
                //Pushing a new continuation
                Debug.Assert(declaringType != null, "declaringType != null");

                promise.DeclaringType = declaringType.AssemblyQualifiedNameCache();
                promise.SetObjectContainingMethod(viewModel);
                promise.MethodName = methodName;
                promise.ModalUniqueId = continuationid ?? viewModel.UniqueID;
				promise.UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID();
                promise.MethodArgs = methodArgs;
                return promise;
            }
            else
            {
                Type codePromiseType = instance.GetType();
                if (TypeCacheUtils.IsSpecialClass(codePromiseType))
                {
                    
                    string methodName = code.Method.Name;
                    promise.NeedsSerialization = true;
                    promise.CodeTarget = code.Target;
                    promise.DeclaringType = codePromiseType.AssemblyQualifiedNameCache();
                    promise.ContinuationID = continuationid;
                    promise.MethodName = methodName;
                    promise.UniqueID = stateManager.UniqueIDGenerator.GetPromiseUniqueID();
                    promise.MethodArgs = methodArgs;
                    promise.PreProcess(StateManager.Current.surrogateManager);
                    return promise;

                }
            }
            throw new PromisesOnlySupportDelegatesFromClassesImplementingILogic();
        }

        public virtual void PreProcess(SurrogateManager surrogateManager)
        {
            if (this.NeedsSerialization)
            {
                var codethisType = TypeCacheUtils.GetType(this.DeclaringType);
                PromiseUtils.RegisterSurrogateForDisplayClass(codethisType, this.CodeTarget);
                var objectContainingMethod = surrogateManager.GetSurrogateFor(this.CodeTarget, generateIfNotFound: true);
                this.SetObjectContainingMethod(objectContainingMethod);
                this.ModalUniqueId = this.ContinuationID ?? (objectContainingMethod != null ? objectContainingMethod.UniqueID : null);
                surrogateManager.AddSurrogateReference(objectContainingMethod, this.UniqueID);
            }
        }

        public string MethodArgs { get; set; }
        public abstract void Resolve(params object[] parameters);
        public virtual void SetState()
        {
            // (PromisesInsertionIndex > 0) => (New promises registered in Execute)
            if (State != PromiseState.Pending && State != PromiseState.LoopBreak && State != PromiseState.LoopContinue)
                State = ViewManager.Instance.State.PromisesInsertionIndex > 0 ? PromiseState.Exploited : PromiseState.Resolved;
        }

        public string UniqueID { get; set; }

		public PromiseState State { get; set; }
       
		public string ParentId { get; set; }

		public string FamilyId { get; set; }

        public string ThenUniqueID { get; set; }

		public override IPromise Then(Action code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise(code, index + 1);
		}
		public IPromise Then(Delegate code)
		{
			var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
			return CreatePromise(code, index + 1);
		}

		public override IPromise Then<TP>(Action<TP> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise(code, index + 1);
		}

		public override IPromise ThenWithLogic(Action<ILogicWithViewModel<IViewModel>> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise(code, index + 1);
		}

		public override IPromise<TR> Then<TP, TR>(Func<TP, TR> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise<TR>(code, index + 1);
		}

		public override IPromise<TR> ThenWithLogic<TP, TR>(Func<ILogicWithViewModel<IViewModel>, TP, TR> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise<TR>(code, index + 1);
		}

		public override IPromise<TR> Then<TR>(Func<TR> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise<TR>(code, index + 1);
		}

		public override IPromise<TR> ThenWithLogic<TR>(Func<ILogicWithViewModel<IViewModel>, TR> code)
		{
            var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
            return CreatePromise<TR>(code, index + 1);
		}

		public override IPromise<TR> ResolvedThen<TR>(TR value)
		{
			return new UnblockedPromiseInfo<TR>(value);
		}

        public override IPromise Fail(Action<Exception> onRejected)
		{
			throw new NotImplementedException();
		}

        public override IPromise<TR> Fail<TR>(Func<Exception, TR> onRejected)
		{
			throw new NotImplementedException();
		}

        public override IPromise Always(Action<Exception> onRejected)
		{
			throw new NotImplementedException();
		}

        public override IPromise<TR> Always<TR>(Func<Exception, TR> onRejected)
		{
			throw new NotImplementedException();
		}

		protected virtual IPromise CreatePromise(Delegate code, int insertionIndex = -1)
		{
			var result = PromiseInfo.CreateInstance(code, state: State, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
		}

        protected virtual IPromise CreatePromise(Func<bool> condition, Action body, Action increment, int insertionIndex = -1)
        {
            var result = LoopPromiseInfo.CreateInstance(condition, body, increment, state: State, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
        }

        protected virtual IPromise CreatePromise<T>(IPromiseCollectionInfo<T> collection, Action<T> body, int insertionIndex = -1)
        {
            var result = LoopPromiseInfo<T>.CreateInstance<T>(collection, body, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
        }

		protected virtual IPromise<TR> CreatePromise<TR>(Delegate code, int insertionIndex = -1)
		{
            var result = PromiseInfo<TR>.CreateInstance(code, state: State, insertionIndex: insertionIndex);
            ThenUniqueID = result.UniqueID;
            return result;
		}

		public override IPromise Then<T>(IPromiseCollectionInfo<T> collection, Action<T> body)
		{
			var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
			return CreatePromise(collection, body, index + 1);
		}

		public override IPromise Then(Func<bool> condition, Action body, Action increment)
		{
			var index = ViewManager.Instance.State.Promises.IndexOf((BasePromiseInfo)this);
			return CreatePromise(condition, body, increment, index + 1);
		}

	}

}