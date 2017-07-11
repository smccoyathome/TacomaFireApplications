using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Fasterflect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpgradeHelpers.Events;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;
using UpgradeHelpers.WebMap.Server.Promises;
using UpgradeHelpers.WebMap.Helpers;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.WebMap.List;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace UpgradeHelpers.WebMap.Server
{
    public partial class ViewManager : IViewManager
    {
		IStateManager _stateManager;
		IIocContainer _container;
		IViewTypeResolver _viewTypeSolver;
        /// <summary>
        /// It is used to control that continuation code is not executed more times than needed
        /// </summary>
        internal HashSet<string> DisposedView = new HashSet<string>(StringComparer.Ordinal);

        internal const string ViewManagerStateCacheUid = "@@ViewManager";
        internal ViewsState _state;
        internal IAsyncBuilderManager _asyncBuilderManager;


        private HashSet<string> _executedPromises;
        private List<Task> parallelTasks = new List<Task>();
        private object parallelTasksLock = new object();
        private Dictionary<string, IStateObject> VisualParentTable = new Dictionary<string, IStateObject>();

		private IEventAggregator _events;
		public IEventAggregator Events
		{
			get { return _events ?? (_events = new EventAggregator((StateManager)_stateManager,this)); }
		}

        public string RequestedInput { get; set; }

		internal ViewsState State
		{
			get
			{
				if (_state == null)
				{
					_state = (ViewsState)_stateManager.GetObject(ViewsState.UniqueIdViewmanagerState);
					if (_state == null)
					{
						//There is no previous one
						_state = new ViewsState { UniqueID = ViewsState.UniqueIdViewmanagerState };
                        _stateManager.AddNewObject(_state);
                    }
                }
                return _state;
            }
        }

		public IAsyncBuilderManager AsyncBuilderManager
		{
			get
			{
				if (_asyncBuilderManager == null)
				{
					//There is no previous one
					_asyncBuilderManager = new AsyncBuilderManager((StateManager)_stateManager, this);
				}
				return _asyncBuilderManager;
			}
		}

        /// <summary>
        /// This instance is reset on DoDefaultInjectionInController
        /// to make sure that it is null when any request is processed
        /// </summary>
        [ThreadStatic]
        internal static ViewManager _instance;

        public static ViewManager Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new ViewManager(StateManager.Current, IocContainerImplWithUnity.Current, new ViewTypeResolver());
                }
                return _instance;
            }
        }

        internal ViewManager(IStateManager stateManager, IIocContainer container, IViewTypeResolver viewTypeSolver)
        {
            this._stateManager = stateManager;
			this._container = container;
			this._viewTypeSolver = viewTypeSolver;
        }

        #region IViewManager Members

		public IPromise<DialogResult> NavigateToView(ILogicWithViewModel<IViewModel> view, bool isModal=false)
		{
			State.NavigateToView(view, (StateManager)_stateManager, isModal);
			if (isModal)
			{
				(view.ViewModel as IControlWithState).State |= ControlState.IsModal;
				State.LastPromise = ShowDialogPromiseInfo.CreateDialogPromise(view.ViewModel.UniqueID);
				return (IPromise<DialogResult>)State.LastPromise;
			}
			else
				return null;
		}

        public void HideView(ILogicWithViewModel<IViewModel> view)
        {
            view.ViewModel.Visible = false;
        }


        /// <summary>
        /// If a view was registered as needing to postpone the Dispose. Then it will be called here
        /// return true if there was at least one pending dispose;
        /// </summary>
        internal bool DisposePendingViews()
        {
            ILogicWithViewModel<IViewModel>[] disposeLaterArray = null;
            //Get lock and extract value to avoid concurrency errors
            lock (formsThatWillBeDisposedLaterLock) {
                if (formsThatWillBeDisposedLater.Count > 0) {
                    //we copy the list of views
                    disposeLaterArray = new ILogicWithViewModel<IViewModel>[formsThatWillBeDisposedLater.Count];
                    formsThatWillBeDisposedLater.CopyTo(disposeLaterArray);
                    //And reset the hashset so further calls have no conflict with previous lists
                    formsThatWillBeDisposedLater = new HashSet<ILogicWithViewModel<IViewModel>>(ComparerByReference.CommonInstance);
                }
            }
            if (disposeLaterArray != null)
            {
                for (int i = 0; i < disposeLaterArray.Length; i++)
                {
                    var view = (ILogicWithViewModel<IViewModel>)disposeLaterArray[i];
                    if (!DisposedView.Contains(view.ViewModel.UniqueID))
                    {
                        DisposeView(view, false);
                    }
                }
                return true;
            }
            return false;
        }

        object formsThatWillBeDisposedLaterLock = new object();
        HashSet<ILogicWithViewModel<IViewModel>> formsThatWillBeDisposedLater = new HashSet<ILogicWithViewModel<IViewModel>>();

        static LazyBehaviourNoSetters lazyBehaviourForDispose = new LazyBehaviourNoSetters();
        static Type[] CLOSING_TYPES = new Type[1] { typeof(CloseReason) };
        static Type[] DISPOSE_TYPES = new Type[1] { (typeof(bool)) };
        static object[] DISPOSE_PARAMETERS = new object[1] { true };

        private void ChangeInterceptionBehaviour(IStateObject view)
        {
            IInterceptingProxy proxy = view as IInterceptingProxy;
            if (proxy != null)
                //Let's disable the interception
                proxy.AddInterceptionBehavior(lazyBehaviourForDispose);
            var iterator = view as UpgradeHelpers.Interfaces.IControlContainerIterator;
            if (iterator != null)
            {
                foreach (var ctl in iterator.GetControlsIterator())
                {
                    var children = iterator.GetControlsIterator(ctl);
                    foreach (var child in children)
                        ChangeInterceptionBehaviour(child);
                    ChangeInterceptionBehaviour(ctl);
                }
            }
        }
        public void DisposeView(ILogicWithViewModel<IViewModel> view, bool later = false)
        {
            if (later)
            {
                lock (formsThatWillBeDisposedLaterLock) {
                    formsThatWillBeDisposedLater.Add(view);
                }
                return;
            }
            var wrappedView = view as ILifeCycle;
            var formBaseViewModel = view.ViewModel as FormBaseViewModel;

            if (formBaseViewModel != null) formBaseViewModel.IsDisposing = true;
            if (wrappedView != null)
            {
                ChangeInterceptionBehaviour(formBaseViewModel);
                var closed = wrappedView.ExecuteLifeCycleShutdown();
                if (closed)
                {
                    if (!DisposedView.Contains(view.ViewModel.UniqueID))
                    {
                        DisposedView.Add(view.ViewModel.UniqueID);
                        ResumeAfterShowDialog(view);
                        wrappedView.Dispose();
                        State.DisposeView(view);
                    }
                    DisposedView.Remove(view.ViewModel.UniqueID);
                    (view.ViewModel as IControlWithState).State &= ~ControlState.IsModal;
                }
            }
            else
            {
                // lets fire the closing event
                MethodInfo method = view.GetType().Method("OnClosing");
                if (method != null)
                {
                    method.Invoke(view, new object[1] { null });
                }
                method = view.GetType().Method("Closing", CLOSING_TYPES);
                bool cancel = false;
                var parameters = new object[2] { cancel, CloseReason.UserClosing };
                if (method != null)
                {
                    method.Invoke(view, parameters);
                }
                // lets fire the form closing event
                method = view.GetType().Method("FormClosing", CLOSING_TYPES);
                if (method != null)
                {
                    method.Invoke(view, parameters);
                }
                if (!(bool)parameters[0])
                {
                    // lets fired the closed events
                    // lets fire the Closed event
                    method = view.GetType().Method("Closed", CLOSING_TYPES);
                    if (method != null)
                    {
                        method.Invoke(view, parameters);
                    }
                    // lets fire the Closed event
                    method = view.GetType().Method("FormClosed", CLOSING_TYPES);
                    if (method != null)
                    {
                        method.Invoke(view, parameters);
                    }
                    // lets close the form
                    if (!DisposedView.Contains(view.ViewModel.UniqueID))
                    {
                        DisposedView.Add(view.ViewModel.UniqueID);
                        ResumeAfterShowDialog(view);
                        // lets fire the Dispose method
                        method = view.GetType().Method("Dispose", DISPOSE_TYPES);
                        if (method != null)
                        {
                            method.Invoke(view, DISPOSE_PARAMETERS);
                        }
                        State.DisposeView(view);
                    }

                    DisposedView.Remove(view.ViewModel.UniqueID);
                }
            }
            if (formBaseViewModel != null) formBaseViewModel.IsDisposing = false;

        }


        /// <summary>
        /// Sets the focus to the desired item, optionally pass parent with disambiguation is needed
        /// </summary>
        /// <param name="item">The item that will be focused</param>
        public void SetCurrent(IDependentViewModel item)
        {
            var fieldid = item.UniqueID;
            if (fieldid != null)
            {
                var fieldsInfo = new List<string>();
                fieldsInfo.Add(fieldid);
                State.SetCurrentFocusedControl(fieldsInfo);
            }
            else
                throw new ArgumentException("Invalid field" + item.UniqueID);
        }

        public void SetCurrent(IDependentViewModel item, IDependentViewModel parent = null)
        {
            var fieldid = item.UniqueID;
            if (fieldid != null)
            {
                var fieldsInfo = new List<string>();
                fieldsInfo.Add(fieldid);
                if (parent != null)
                    fieldsInfo.Add(parent.UniqueID);
                State.SetCurrentFocusedControl(fieldsInfo);
            }
            else
                throw new ArgumentException("Invalid field" + item.UniqueID);
        }

        /// <summary>
        /// Sets the focus to the desired view
        /// </summary>
        /// <param name="item">The item that will be focused</param>
        public void SetCurrentView(IViewModel item)
        {
            var fieldid = item.UniqueID;
            if (fieldid != null)
            {
                var fieldsInfo = new List<string>();
                fieldsInfo.Add(fieldid);
                State.SetCurrentFocusedControl(fieldsInfo);
            }
            else
                throw new ArgumentException("Invalid field" + item.UniqueID);
        }

        /// <summary>
        /// One way commands are not persisted on the server side, so they must be removed prior to the server side serialization
        /// </summary>
        public void PruneOneWayCommands()
        {
            State.PruneOneWayCommands();
        }

		public IPromise<T> ExecOnClient<T>(string commandId, object parameters, bool registerPromise = true,bool isOneWay = false)
		{
			string cmduid = State.AddClientCommand(commandId, parameters,isOneWay);
			if (registerPromise)
				return ClientCommandPromiseInfo<T>.CreateClientPromise((StateManager)_stateManager, this, cmduid);
			else
				//We are not going to insert any promise
				//Even though there is not registered promise the result value could still be used
				return new ClientCommandPromiseInfo<T>();
		}

		public IEnumerable<IViewModel> LoadedViews
		{
			get
			{
				foreach (IViewModel view in State.LoadedViews.Select(loadedView => (IViewModel)_stateManager.GetObject(loadedView.UniqueID)))
				{
					Debug.Assert(view != null, "Abnormal state. Missing view model");
					yield return view;
				}
			}
		}

		#endregion

		internal void UpdateViewManager(JObject jsonObj)
		{
			var closedViews = jsonObj["closedViews"];
			if (closedViews != null)
			{
				var array = (JArray)closedViews;
				foreach (var view in array)
				{
					State.DisposeViewInternal(view.Value<String>());
				}
			}
		}



        



		internal ViewsStateDelta EndStateDelta;

		public void ExecuteAnyPendingWork()
		{
			DisposePendingViews();
		}



		public IDataPageableViewModel GetDataPageableViewModel(string controlId)
		{
			var control = _stateManager.GetObject(controlId);
			return control as IDataPageableViewModel;
		}

		/// <summary>
		/// Get the ViewModel associated with the Unique ID
		/// </summary>
		/// <param name="uid"></param>
		/// <returns></returns>
		public IStateObject GetParentViewModel(Func<string> getUniqueIdentifier)
		{
			return _stateManager.GetObject(getUniqueIdentifier());
		}

		/// <summary>
		/// Gets the page of the collection which UniqueID is passed as parameter.
		/// </summary>
		/// <param name="collectionUid">The UniqueID of the collection.</param>
		/// <param name="take">The amount of items to take (aka: the page size).</param>
		/// <param name="skip">The amount of items to skip.</param>
		/// <param name="total">The collection total number of items.</param>
		/// <returns></returns>
		public IStateObject[] GetCollectionPage(string collectionUid, int take, int skip, out int total)
		{
			var res = (object)_stateManager.GetObject(collectionUid);

			if (res == null)
			{
				Trace.TraceWarning("ViewManager::GetCollectionPage: Collection not found. UniqueID: " + collectionUid);
				total = 0;
				return new IStateObject[0];
			}

			// Check if the result is an IEnumerable
			var enumerable = res as IEnumerable<IStateObject>;
			if (enumerable != null)
			{
			total = enumerable.Count();
			return enumerable.Skip(skip).Take(take).ToArray();
		}
			var dynamicObj = res as dynamic;
			dynamic obj = dynamicObj.Items;
			total = obj.Count;
			var objs = new List<IStateObject>();

			for (int i = skip; i < skip + take && i < total; i++)
			{
				objs.Add(obj[i]);
			}
			return objs.ToArray();
		}

		public IStateObject GetObject(string rowUniqueID)
		{
			return _stateManager.GetObject(rowUniqueID);
		}


		public bool IsViewInLoadedViews(IViewModel viewModel)
		{
			for (int i = 0; i < State.LoadedViews.Count; i++)
			{
				var viewInfo = State.LoadedViews[i];
				if (viewInfo.UniqueID.Equals(viewModel.UniqueID, StringComparison.Ordinal))
				{
					return true;
				}
			}
			return false;
		}

        public Dictionary<string, IStateObject> GetVisualParentDictionary() {
            return VisualParentTable;
        }
		public IStateObject GetParent(IStateObject stateObj)
		{
            return ((StateManager)_stateManager).GetParentEx(stateObj);
		}

		public IStateObject GetTopLevelObject(IStateObject stateObj)
		{
			if (stateObj != null && stateObj.UniqueID != null)
			{
				var accessPath = stateObj.UniqueID;
                if (UniqueIDGenerator.IsListItem(accessPath))
                {
                    var p = this.GetParent(stateObj);
                    return GetTopLevelObject(p);
                }
                var accessPathIndex = accessPath.LastIndexOf(UniqueIDGenerator.UniqueIdSeparator);
				if (accessPathIndex > 0)
				{
					var ancestorUID = accessPath.Substring(accessPathIndex + 1);
                    if (UniqueIDGenerator.IsListItem(ancestorUID))
                    {
                        var p = this.GetParent(_stateManager.GetObject(ancestorUID));
                        return GetTopLevelObject(p);
                    }
                    else
                        return _stateManager.GetObject(ancestorUID);
                }
			}
			return null;
		}


		public ILogicView<IViewModel> GetTopLevelForm(IStateObject stateObj)
		{
			var topLevelViewModel = GetTopLevelObject(stateObj) as IViewModel;
			if (topLevelViewModel != null)
			{
				return GetLogicForViewModel(topLevelViewModel);
			}
			return null;
		}

		private ILogicView<IViewModel> GetLogicForViewModel(IViewModel topLevelViewModel)
		{
			Type logicType = _viewTypeSolver.GetLogicTypeFromAttribute(topLevelViewModel);
			var form = _container.Resolve(logicType, null, IIocContainerFlags.NoView) as ILogicView<IViewModel>;

			var viewModelProperty = form.GetType().GetProperty("ViewModel");
			if (viewModelProperty.CanWrite)
				viewModelProperty.SetValue(form,topLevelViewModel);
			return form;
		}

		

		public IEnumerable<ILogicView<IViewModel>> GetOpenForms()
		{
			foreach (var viewInfo in this.State.LoadedViews)
			{
				var viewModel = _stateManager.GetObject(viewInfo.UniqueID) as IViewModel;
				if (viewModel != null)
				{
					yield return GetLogicForViewModel(viewModel);
				}
			}
		}

		public ILogicView<IViewModel> GetOpenFormAt(int index)
		{
			ILogicView<IViewModel> loadedForm = null;
			if(State.LoadedViews.Count > index)
			{
				var viewModel = _stateManager.GetObject(State.LoadedViews[index].UniqueID) as IViewModel;
				loadedForm = GetLogicForViewModel(viewModel);
			}
			return loadedForm;
		}

		public int OpenFormsCount
		{
			get
			{
				return State.LoadedViews.Count;
			}
		}

		public void PendingResult()
		{
			if (State.InPromiseExecution)
				State.ExecutingPromiseInfo.State = PromiseState.Pending;
		}

		/// <summary>
		/// Waits for all the parallel task running.
		/// </summary>
		public void WaitForAsyncActions()
		{
			Task[] tasks;
            bool thereWherePendingViewsToDispose;
            do {

                ////Do we have any completed tasks?
                ////If so, then call all those completed
                if (/*Checks the list of pending finalization callbacks*/syncronizationContext.callbacks != null)
                {
                    var current = syncronizationContext.callbacks;
                    syncronizationContext.callbacks = null;
                    foreach (var callbackTuple in current)
                    {
                        //Calls finalization callback
                        callbackTuple.Item1(callbackTuple.Item2);
                    }
                }
                //Get the list of parallelTasks to check if they are all finished
                tasks = null;
                lock (parallelTasksLock)
                {
                    tasks = parallelTasks.ToArray();
                }
                thereWherePendingViewsToDispose = this.DisposePendingViews();
            } while (
                /*Are we missing any tasks?*/!Task.WaitAll(tasks,1) ||
                thereWherePendingViewsToDispose //||
                /*Have we finished with all Completed Tasks?
                if we have CompletedTasks syncronizationContext == null*/
              //  (syncronizationContext != null && syncronizationContext.callbacks != null)
                );
		}

		/// <summary>
		/// In order to be able to Run a Task in WebMap correctly we need to set a context to the Thread.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		private Task GetContextedTask(Action code)
		{
			//Let's store the Singleton instance references.
			var viewManager = this;
			var context = HttpContext.Current;
			var staticContainer = StaticContainer.Instance;
			var sharedItems = StaticContainer.SharedItems;
            var currentCulture = System.Globalization.CultureInfo.CurrentCulture;

            var theTask = new Task(() =>
            {
                //Let's update this Thread Context.
                System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
                StateManager.Current = (StateManager)_stateManager;
                ViewManager._instance = viewManager;
                StaticContainer.instance = staticContainer;
                StaticContainer.SharedItems = sharedItems;
                //Executes the required logic
                code();
				viewManager.Events.Reset();//Let's ensure the suspendedStateCollection is cleared.
            });
			return theTask;
		}

        //System.Threading.SynchronizationContext syncronizationContext;



        WebMapAsyncSyncronizationContext syncronizationContext = new WebMapAsyncSyncronizationContext(null);
        public class WebMapAsyncSyncronizationContext : System.Threading.SynchronizationContext
        {
            ViewManager manager;
            internal List<Tuple<System.Threading.SendOrPostCallback, object>> callbacks = null;
            public WebMapAsyncSyncronizationContext(ViewManager viewManager) {
                //manager = viewManager;
            }
            public override void Post(System.Threading.SendOrPostCallback d, object state)
            {
                if (callbacks==null)
                {
                    callbacks = new List<Tuple<System.Threading.SendOrPostCallback, object>>();
                }
                callbacks.Add(new Tuple<System.Threading.SendOrPostCallback, object>(d, state));
            }

            public void Dispose()
            {
                manager = null;
                callbacks.Clear();
                callbacks = null;
            }
        }

        /// <summary>
        /// Returns a syncronization context that can be used to post tasks to be executed at the end of all the completed tasks
        /// or it can be used as a lock for syncronization
        /// </summary>
        public System.Threading.SynchronizationContext CurrentSyncronizationContext { 
            get 
            { 
                return syncronizationContext; 
            } 
        }


        /// <summary>
        /// Executes an Action in a parallel mode, avoiding to wait until it finishes to continue with the Request.
        /// </summary>
        /// <param name="code">Action to execute.</param>
        /// <param name="wait">If true the Request won't end until this finishes, otherwise it will continue in background.</param>
        public void ExecParallel(Action code, bool wait = true)
		{
            //syncronizationContext = System.Threading.SynchronizationContext.Current;
			//Lets get the Task.
			var theTask = GetContextedTask(code);
			////Let's register the Task only if we have to wait for it.
			lock (parallelTasksLock)
			{
				if (wait)
					parallelTasks.Add(theTask);
			}
			//Starts the Task execution.
			theTask.Start();
		}

		/// <summary>
		/// Execute a list of actions and a callback afterwards.
		/// </summary>
		/// <param name="actions"></param>
		/// <param name="callback"></param>
		public void ExecParallel(List<Action> actions, Action callback)
		{
			
            var tasks = new List<Task>();
			var viewManager = this;
			var context = HttpContext.Current;
			foreach (var code in actions)
			{
				var theTask = GetContextedTask(code);
				tasks.Add(theTask);
				theTask.Start();
			}
			var whenAllTasks = Task.WhenAll(tasks.ToArray());
			var callBackTask = GetContextedTask(callback);
			lock (parallelTasksLock)
			{
                parallelTasks.AddRange(tasks);
                parallelTasks.Add(whenAllTasks);
                parallelTasks.Add(callBackTask);
			}
			whenAllTasks.ContinueWith((x) => 
			{ 
				callBackTask.Start(); 
			});
		}

		internal void Dispose()
		{
			this._stateManager = null;
			this._state = null;
			this.syncronizationContext = null;
			this.parallelTasks = null;
			this.formsThatWillBeDisposedLater = null;
			this.Events.Dispose();
			this._asyncBuilderManager = null;
			this._executedPromises = null;
			this.EndStateDelta = null;
		}
	}

	//Here we have the promises related members
	public partial class ViewManager
	{
		public IPromise Then(Action code)
		{
			return PromiseInfo.CreateInstance(code);
		}

        public DialogResult InteractionResult { get; set; }

        public IPromise Async(Func<bool> delCondition, Action delBody, Action delIncrement)
        {
            if (State.LastPromise != null)
            {
                return State.LastPromise.Then(delCondition, delBody, delIncrement);
            }
            return LoopPromiseInfo.CreateInstance(delCondition, delBody, delIncrement, insertionIndex: 0);
        }

        public IPromise Async<T>(ForEachCollectionInfo<T> collectionInfo, Action<T> delBody)
        {
            if (State.LastPromise != null)
            {
                return State.LastPromise.Then(collectionInfo, delBody);
            }
            return LoopPromiseInfo<T>.CreateInstance<T>(collectionInfo, delBody, insertionIndex: 0);
        }

        public IPromise Async(Action code)
		{
			if (State.LastPromise != null)
			{
				return State.LastPromise.Then(code);
			}
			return AsyncPromiseInfo.CreateInstance(code, insertionIndex: 0);
		}
		internal IPromise Async(Delegate code)
		{
			if (State.LastPromise != null)
			{
				return ((BasePromiseInfo)State.LastPromise).Then(code);
			}
			return AsyncPromiseInfo.CreateInstance(code, insertionIndex: 0);
		}

		public IPromise Async<TP>(Action<TP> code)
		{
			if (State.LastPromise != null)
			{
				return State.LastPromise.Then(code);
			}
			return AsyncPromiseInfo.CreateInstance(code, insertionIndex: 0);
		}

		public IPromise<TR> Async<TR>(Func<TR> code)
		{
			if (State.LastPromise != null)
			{
				return State.LastPromise.Then(code);
			}
			return AsyncPromiseInfo<TR>.CreateInstance(code, insertionIndex: 0);
		}

		public IPromise<TR> Async<TP, TR>(Func<TP, TR> code)
		{
			if (State.LastPromise != null)
			{
				return State.LastPromise.Then(code);
			}
			return AsyncPromiseInfo<TR>.CreateInstance(code, insertionIndex: 0);
		}

		public TR PendingResult<TR>()
		{
			if (State.InPromiseExecution)
			{
				State.ExecutingPromiseInfo.State = PromiseState.Pending;
				return default(TR);
			}
			throw new InvalidOperationException("PendingResult method can only be invoked inside executing promise.");
		}

		public TR Resolve<TR>(TR value)
		{
			if (State.InPromiseExecution)
			{
				//State.ExecutingPromiseInfo.State = PromiseState.Exit;
				return (TR)value;
			}
			throw new InvalidOperationException("PendingResult method can only be invoked inside executing promise.");
		}

        private static bool IsClientPromise(BasePromiseInfo promise)
        {
            return promise.GetType().IsGenericType && promise.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(ClientCommandPromiseInfo<>));
        }

		public void ResumePendingOperation(string dialogResult, string requestedInput)
		{
			RequestedInput = requestedInput;
            InteractionResult = (DialogResult)Enum.Parse(typeof(DialogResult), dialogResult, ignoreCase: true);
            
			if (State.Promises.Count > 0)
			{
				var promiseInfo = State.Promises[0];
				if (IsClientPromise(promiseInfo))
				{
					State.RemoveContinuation(promiseInfo);
                    var property = promiseInfo.GetType().GetProperty("ResolvedValue",BindingFlags.Instance | BindingFlags.Public);
                    var expectedReturnType = property.PropertyType;
                    //This is left for backward compatibility until interaction result is removed on newer version of WebMap
                    if (promiseInfo is IPromise<DialogResult>)
                    {
                        promiseInfo.Resolve(InteractionResult);
                    }
                    else
                    {
                        //In this case we know for sure that the requestInput is not a Dialog Result
                        //We will try to parse it and resolve the promise;
                        object returnValue = null;
                        if (!String.IsNullOrWhiteSpace(requestedInput))
                        {
                            try
                            {
                                returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject(requestedInput, expectedReturnType);
                            }
                            catch
                            {
                                Trace.TraceError("Error while deserialing promise return value Expected type {0}, return value {1} ", expectedReturnType, requestedInput);
                            }
                            property.SetValue(promiseInfo, returnValue);
                        }
                        promiseInfo.Resolve(returnValue);
                    }
					
				}
				if (promiseInfo.State == PromiseState.Resolved)
				{
					object resolvedValue;
					if (promiseInfo.TryGetResolvedValue(out resolvedValue))
						ProcessPromises(resolvedValue, promiseInfo);
					else
						ProcessPromises(promiseInfo);
				}
				// Removes the current command in order to avoid to execute it again if the
				//page is refreshed 
				if (State.Commands.Count > 0)
				{
					State.Commands.RemoveAt(0);
			}
			}
			else
			{
				TraceUtil.WriteLine("WARNING: trying to resume continuation, but none was available");
			}
		}

		/// <summary>
		/// Tries to resume the execution once a view is closed by checking if top delegate
		/// matches the given unique id.
		/// </summary>
		/// <param name="logic">Logic related to view</param>
		private void ResumeAfterShowDialog(ILogicWithViewModel<IViewModel> logic)
		{
			if (State.Promises.Count > 0)
			{
				var promiseInfo = State.Promises[0];
				if (promiseInfo is ShowDialogPromiseInfo)
				{
					State.RemoveContinuation(promiseInfo);
					promiseInfo.Resolve(InteractionResult);
				}
				if (promiseInfo.State == PromiseState.Resolved)
				{
					object resolvedValue;
					if (promiseInfo.TryGetResolvedValue(out resolvedValue))
						ProcessPromises(resolvedValue, promiseInfo);
					else
						ProcessPromises(promiseInfo);
				}
			}
		}
		static char[] TYPE_SEPARATOR = new[] { '|' };
        private void ResolvePromise(BasePromiseInfo promiseInfo, object promiseInput = null, ILogicWithViewModel<IViewModel> logic = null
#if DEBUG
, BasePromiseInfo oldPromise = null
#endif
)
        {
            State.BeginPromiseExecution(promiseInfo);
            if (promiseInfo.PromiseType == PromiseType.Catch)
            {
                var temp = promiseInput;
                promiseInput = null;
                promiseInfo.Resolve(temp);
            }
            else
                if (promiseInfo.MethodArgs != null)
                {
                    var paramsTypes = promiseInfo.MethodArgs.Split(TYPE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                    if (paramsTypes.Length > 0)
                    {
                        if (paramsTypes.Length == 1 && AreValuesCompatible(promiseInput, TypeCacheUtils.GetType(paramsTypes[0])))
                        {
                            promiseInfo.Resolve(promiseInput);
                        }
                        else if (paramsTypes.Length == 2 &&
                                 paramsTypes[0] == typeof(ILogicWithViewModel<IViewModel>).AssemblyQualifiedNameCache() &&
                                 paramsTypes[1] == promiseInput.GetType().AssemblyQualifiedNameCache())
                            promiseInfo.Resolve(logic, promiseInput);
                        else
                        {
                            //Error mismatch
#if DEBUG
                            StringBuilder locationInfo = new StringBuilder();
                            if (oldPromise != null)
                            {
                                locationInfo.AppendLine("Previous promise location " + oldPromise.UserCodeInfo);
                            }
                            locationInfo.AppendLine("Current promise location " + promiseInfo.UserCodeInfo);

#endif
                            var expectedTypes = new StringBuilder();
                            expectedTypes.Append("expected parameter types [");
                            for (int i = 0; i < paramsTypes.Length; i++)
                            {
                                var type = TypeCacheUtils.GetType(paramsTypes[i]).FullName;
                                expectedTypes.Append(type);
                                expectedTypes.Append(",");
                            }
                            expectedTypes.Append("]");
                            throw new InvalidOperationException("Promises mismatch. Arguments do not match between promises." + expectedTypes.ToString()
#if DEBUG
 + locationInfo.ToString()
#endif
);
                        }
                    }
                }
                else
                    promiseInfo.Resolve();


            if (promiseInfo.PromiseType == PromiseType.Return)
            {
                //Discard the following promises in the same family
                SkipRelatedPromises(promiseInfo.FamilyId);
            }
            State.EndPromiseExecution();
        }


        private bool AreValuesCompatible(object parameterValue, Type expectedParameterType)
        {
            if (expectedParameterType.IsValueType)
            {
                return expectedParameterType.IsAssignableFrom(parameterValue.GetType());
            }
            else
            {
                //Value can be null;
                if (parameterValue == null) return true;
                else
                    return expectedParameterType.IsAssignableFrom(parameterValue.GetType());
            }
        }

		/// <summary>
		/// It's required to go through the Promises collection to 
		/// check if there is any Promise ready to be consumed(Resolved).
		/// </summary>
		/// <param name="promiseInput"></param>
		public void FulfillPromises()
		{
			ProcessPromises();
			RemoveExecutedPromises();
            PreprocessForSerialization();
		}

        private void PreprocessForSerialization()
        {
            foreach(var promise in State.Promises)
            {
                promise.PreProcess(StateManager.Current.surrogateManager);
            }
        }

        /// <summary>
        /// Removes the executed promises from the storage
        /// </summary>
        internal void RemoveExecutedPromises()
		{
			if (this._executedPromises == null)
			{
				return;
			}

			foreach (var promiseId in this._executedPromises)
			{
				_stateManager.RemoveObject(promiseId, false);
			}
			this._executedPromises = null;
		}
		internal void RemoveSkippedPromises()
		{
			var promises = State.Promises;

			for (int i = promises.Count; i >= 0; i--)
			{
				var promise = promises[i];
				if (promise.State == PromiseState.Skipped)
				{
					_stateManager.RemoveObject(promise.UniqueID, false);
					promises.Remove(promise);
				}
			}
			this._executedPromises = null;
		}

		/// <summary>
		/// Adds a promise to the list of executed promises
		/// </summary>
		/// <param name="promiseID"></param>
		private void AddExecutedPromise(string promiseID)
		{
			if (_executedPromises == null)
			{
				_executedPromises = new HashSet<string>(StringComparer.Ordinal);
			}
			if (promiseID != null && !_executedPromises.Contains(promiseID))
			{
				_executedPromises.Add(promiseID);
			}
		}

		private void ProcessPromises(object promiseInput = null, BasePromiseInfo inputPromise = null)
		{
			//Only if we have any promise in the Promises Queue.
			if (State.Promises.Count > 0)
			{
				//Lets retrieve the first promise
				BasePromiseInfo continuationPromise = null;
				BasePromiseInfo oldPromise = null;
				if (inputPromise != null)
					oldPromise = inputPromise;
				//Condition for consumption iteration
				Func<bool> shouldResolve = () =>
				{
					//If the promise is a delimiter....We should not continue because we reach a different execution context.
					if (continuationPromise is IDelimiterPromise)
						return false;
					//If we got an input promise then we are executing a context related to a user interaction
					if (inputPromise != null)
						return oldPromise.State == PromiseState.Resolved || oldPromise.State == PromiseState.Pending || oldPromise.State == PromiseState.Exploited || oldPromise.State == PromiseState.Default
						|| oldPromise.State == PromiseState.Pinned || oldPromise.State == PromiseState.LoopBreak || oldPromise.State == PromiseState.LoopContinue;
					else
						//We are not in a executing context...We must execute only promises unblocked(Than can be consumed immediately.)
						return continuationPromise.State == PromiseState.Unblocked || continuationPromise.State == PromiseState.Default || continuationPromise.State == PromiseState.Skipped
							|| continuationPromise.State == PromiseState.Pinned || continuationPromise.State == PromiseState.LoopBreak || continuationPromise.State == PromiseState.LoopContinue;
				};
				//The Promise can receive an Input value.
				object resolvedValue = promiseInput;
				//Lets execute until the next promise is not ready to be consumed.
				continuationPromise = State.Promises[0];
				//Determines if the next promise is a sibling.
				bool hasSibling = false;
				//Determines whether or not a sibling must be executed.
				bool mustResolve = false;
				while (shouldResolve())
				{
					//By default we should always resolve
                    mustResolve = true;
					
					bool forceOldPromiseUpdate = false;
					if (continuationPromise.State != PromiseState.Pinned)
					{
						//We need to remove the promise from the Queue
						State.RemoveContinuation(continuationPromise);

						if (oldPromise != null && (oldPromise.State == PromiseState.LoopContinue || oldPromise.State == PromiseState.LoopBreak))
						{
							continuationPromise.State = PromiseState.Skipped;
						}
					}
					else if (oldPromise != null)
					{
						if (oldPromise.State == PromiseState.LoopBreak)
						{
							//We need to remove the promise from the Queue
							State.RemoveContinuation(continuationPromise);
							mustResolve = false;
							forceOldPromiseUpdate = true;
						}
					}
					
                    if (continuationPromise.State == PromiseState.Skipped)
                    {
                        //Since the current promise has been skipped we compare the old promise with the next one.
                        hasSibling = CheckForSibling(oldPromise);
                        if (State.Promises.Count != 0)
                        {
                            continuationPromise = State.Promises[0];
                            continue;
                        }
                        else
                            break;
                    }
					// Case 1. We now the promises are siblings and we determine that the sibling 
					//must not be executed.
					if (hasSibling && !hasToResolveSibling(oldPromise, continuationPromise))
						mustResolve = false;
					//Let's resolve our Promise
					if (mustResolve)
					{
						try
						{
							//The Promise is resolved and the resolved value is retrieved.
							ResolvePromise(continuationPromise, resolvedValue
#if DEBUG
, oldPromise: oldPromise
#endif
);
							continuationPromise.TryGetResolvedValue(out resolvedValue);
                            if (continuationPromise.State != PromiseState.Pinned)
                            {
                                if (continuationPromise.State == PromiseState.Unpinned)
                                {
                                    State.RemoveContinuation(continuationPromise);
                                }
                                AddExecutedPromise(continuationPromise.UniqueID);
                            }
                            

						}
						catch (Exception)
						{
							// The exception must be handled if a catch promise has been registered for it
						}
					}
					//Is the next promise a sibling?
					// What is a sibling?
					// Promises declared inside of a Promise delegate.
					// Example
					// Async(()=>
					//{ 
					// if(value)
					//    Async(()=> SelectPatient()).Then(
					//   ()=>{ 
					//    ProcessPatientSelected();
					//    ViewManager.Pending();
					//     });
					// Async(()=> ImportantMethod());
					//}
					//As you can see the ImportantMethod must be called regardless the value is True or not
					//but if True it must be called only if the Then delegate doesn't break the execution
					//using a return statement(Thats why the ViewManager.Pending is used for to indicate the sibling
					//that it stills need to be executed).
					hasSibling = CheckForSibling(continuationPromise);
					//Do we have promises to execute?
					if (State.Promises.Count > 0)
					{
						//Previous promise is stored and next promise is calculated as well.

						// If (mustResolve == false) this means that we skip resolving the continuationPromise, and we will use
						// the previous resolved.
						if (mustResolve || forceOldPromiseUpdate)
						{
							oldPromise = continuationPromise;
						}
						continuationPromise = State.Promises[0];
					}
					else
						//Nothing to do...Let's go!
						break;
				}
			}
			//Lets obtain the current promises Count( Additional promises might be added in the subsequent line.)
			int currentPromisesCount = State.Promises.Count;
			//A ViewModel could be disposed during the execution of a promise
			this.DisposePendingViews();
			//If there is any difference between the old size and the new size of the promises List, lets execute the method again...
			if (currentPromisesCount != State.Promises.Count)
				ProcessPromises();
		}
		/// <summary>
		/// Mark the related promises as Skipped.
		/// </summary>
		/// <param name="FamilyID">The ID of the family to be skipped.</param>
		internal void SkipRelatedPromises(string FamilyId)
		{
			//Once a method has executed its return the following promises (if any) must be ignored.
			foreach (var promise in State.Promises)
			{
				if (!String.IsNullOrEmpty(promise.FamilyId) && promise.IsFamily(FamilyId) && promise.PromiseType != PromiseType.Finally)
				{
					promise.State = PromiseState.Skipped;
                }
                else
                {
                    break;
                }
			}
		}
		
		/// <summary>
		/// Evaluates if two promises belong to the same family (context).
		/// </summary>
        private bool? ConsiderFamilyTies(BasePromiseInfo possibleRelative1,BasePromiseInfo possibleRelative2)
        {
			//First step: verify if the promises have a family, if not no need to compare
            if (string.IsNullOrWhiteSpace(possibleRelative1.FamilyId) || string.IsNullOrWhiteSpace(possibleRelative2.FamilyId))
                return null;
			//Second step: The 
            return IsSiblingPromise(possibleRelative1, possibleRelative2);
        }
		/// <summary>
		/// Verifies if the promises are siblings and need to need resolved during the current request.
		/// </summary>
		// Added resolvedSibling.ThenUniqueID != null validation to resolve
		//promises that are siblings but are not linked to each other.
		private bool hasToResolveSibling(BasePromiseInfo resolvedSibling, BasePromiseInfo siblingToResolve)
		{
            bool? familyTiesCheck = null;
            if ((resolvedSibling.ThenUniqueID != null && (string.Equals(resolvedSibling.ThenUniqueID,siblingToResolve.UniqueID,StringComparison.Ordinal))
            || (familyTiesCheck = ConsiderFamilyTies(resolvedSibling, siblingToResolve)).HasValue && familyTiesCheck.Value))
            {
                return true;
            }
            else
                return false;
		}
		private bool CheckForSibling(BasePromiseInfo continuationPromise)
		{
			if (State.Promises.Count > 0)
			{
				var possibleSibling = State.Promises[0];
				if (IsSiblingPromise(continuationPromise, possibleSibling))
					return true;
			}
			return false;
		}
		/// <summary>
		/// Verifies if the promises are siblings.
		/// Two promises are siblings if the then UniqueId from the first is the same as the UniqueId of the second one 
		/// or both have the same FamilyId
		/// </summary>
		private bool IsSiblingPromise(BasePromiseInfo oldPromise, BasePromiseInfo continuationPromise)
		{
			return oldPromise.IsFamily(continuationPromise.FamilyId) || !string.IsNullOrEmpty(oldPromise.ParentId) && 
                string.Equals(oldPromise.ParentId,continuationPromise.ParentId,StringComparison.Ordinal);
		}
	}
}