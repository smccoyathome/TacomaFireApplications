#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;

using UpgradeHelpers.BasicViewModels.Extensions;

#endregion

namespace UpgradeHelpers.WebMap.Server
{
    [JsonObject(MemberSerialization.OptIn)]
	internal class ViewsState : IStateObject, IInternalData, NoInterception, IViewsState
	{
		internal const string UniqueIdViewmanagerState = "@@ViewsStateSinglenton";
		[NonSerialized]
		[JsonIgnore]
		private ViewsStateDelta _viewsDelta;

        /// <summary>
        /// Remove all commands with the flag "isOneway" in false, because we neeed to remove all commands after sending them.
        /// </summary>
        public void PruneOneWayCommands()
        {
            for(var i=Commands.Count-1;i>= 0;i--)
            {
                var current = Commands[i];
                if (current.isOneWay)
                {
                    Commands.RemoveAt(i);
                }
            }
        }


        private IList<BasePromiseInfo> CreatePromises()
        {
            var stateCache = StateManager.Current;
            var uid = UniqueIDGenerator.GetRelativeUniqueID(this, "Promises");
            var promises = IocContainerImplWithUnity.Current.Resolve<IList<BasePromiseInfo>>();
			stateCache.PromoteObject((IStateObject)promises, uid);
            return promises;
        }

        public ViewsState()
		{
			LoadedViews = new List<ViewInfo>();
			Commands = new List<ClientCommand>();
//			Promises = UpgradeHelpers.Helpers.StaticContainer.Instance.Resolve<IList<BasePromiseInfo>>();
			InPromiseExecution = false;
			ModalViews = new List<string>();
		}

		[JsonProperty]
		public string CurrentCulture { get; set; }

		[JsonProperty]
		public List<ViewInfo> LoadedViews { get; set; }

		[JsonProperty]
		public List<ClientCommand> Commands { get; set; }

		[JsonProperty]
        public List<string> CurrentFocusedControl { get; set; }

		[JsonProperty]
		public List<string> ModalViews { get; set; }

		#region IStateObject Members

		public string UniqueID
		{
			get { return UniqueIdViewmanagerState; }
			set { }
		}

		#endregion

		public void Start()
		{
			_viewsDelta = new ViewsStateDelta();
		}

		public ViewsStateDelta End()
		{
			ViewsStateDelta res = _viewsDelta;
			_viewsDelta = null;
			return res;
		}

        /// <summary>
        /// Sets the UniqueId of the control that will be focused
        /// </summary>
        /// <param name="uniqueId">Unique ID of the control</param>
        public void SetCurrentFocusedControl(List<string> uniqueId)
        {
            CurrentFocusedControl = uniqueId;
            _viewsDelta.CurrentFocusedControl = uniqueId;
        }

		internal void NavigateToView(ILogicWithViewModel<IViewModel> logic, StateManager stateManager, bool isModal = false )
		{
			IViewModel view = logic.ViewModel;
			view.Visible = true;
			if (!LoadedViews.Any(x => x.UniqueID == view.UniqueID))
			{
				_viewsDelta.AddNewView(view, isModal);

				if (isModal)
				{
					ModalViews.Add(view.UniqueID);
				}

				LoadedViews.Add(new ViewInfo { UniqueID = view.UniqueID, Visible = view.Visible, ZOrder = 0 });
				// Added to support promises in the first request(SKS Demo Splash)
				// The view is created but is not sent to the client because it is not loaded by the first request
				// Therefore the navigateToView requires to send the view's viewmodel completely. 
				stateManager.Tracker.DetachModel(view);
				stateManager.Tracker.MarkAllAsModified(view);
				stateManager.AddInCache(view.UniqueID, view, true);
				// Lets fire the load event
				//Load can have no parameters or some parameters
				InvokeLifeCycleStartup(logic);
			}
			else
			{
				var currentView = LoadedViews.FirstOrDefault(v => v.UniqueID == view.UniqueID);
				currentView.Visible = view.Visible;
				currentView.ZOrder = 0;
			}
			stateManager.Tracker.MarkAsModified(this, "LoadedViews");
		}
		///// <summary>
		///// Invoke the parent forms load method first
		///// </summary>
		///// <param name="logic">instance object</param>
		///// <param name="logicType">current type object</param>
		//[Obsolete("InvokeLoadMethod is deprecated, all the Load methods should be handled by the ILoadable elements.")]
		//private static void InvokeLoadMethod(ILogicWithViewModel<IViewModel> logic, Type logicType)
		//{
		//	var parent = logicType.BaseType;
		//	if (parent != null && parent.Implements(typeof(ILogicView<>)))
		//	{
		//		InvokeLoadMethod(logic, parent);
		//	}

		//	if (logicType.Implements(typeof(ILogicView<>)))
		//	{
		//		InvokeInnerLoadMethods(logic.ViewModel, new HashSet<object>(ComparerByReference.CommonInstance));

		//		MethodInfo method = logicType.Method("Load", new Type[0]);
		//		if (method != null)
		//		{
		//			method.Invoke(logic, new object[0]);
		//		}
		//		else
		//		{
		//			method = logic.GetType().Method("Load", new[] { typeof(object), typeof(EventArgs) });
		//			if (method != null)
		//			{
		//				method.Invoke(logic, new object[] { null, null });
		//			}
		//		}
		//	}
		//}

		/// <summary>
		/// Invokes LifeCycle startup method for parent form, the parent form
		/// should also handle the startup method for inner User Controls.
		/// </summary>
		/// <param name="logic">instance object</param>
		/// <param name="logicType">current type object</param>
		private static void InvokeLifeCycleStartup(ILogicWithViewModel<IViewModel> logic)
		{
			// The View being displayed must implement ILifeCycle interface
			//in order to execute any desided logic once the View is Built 
			//and added to the LoadedViews collection
			var ilifeCycleOBj = logic as ILifeCycle;
            if (ilifeCycleOBj != null)
            {
                ilifeCycleOBj.LifeCycleStartup();
            }
            else
            {
                var iloadableOBj = logic as ILoadable;
                if (iloadableOBj != null)
                    iloadableOBj.Load();
                //else
                    //TODO  kesanchez: The call to this method MUST be removed and the method as well.
                    //InvokeLoadMethod(logic, logic.GetType());
            }
		}

//		/// <summary>
//		/// Executes the "Load" method which is the WebMap equivalent of the Load Event on the usercontrols of a Form (recursively)
//		/// </summary>
//		/// <param name="parentControl"></param>
//		/// <param name="visited">This is passed to avoid graph cycles</param>
		
//		private static void InvokeInnerLoadMethods(IStateObject parentControl, HashSet<object> visited)
//		{
//			//Visited is to avoid cycles
//			if (visited.Contains(parentControl))
//			{
//				return;
//			}

//			visited.Add(parentControl);
//			Type logicType = parentControl.GetType();
//			//Gets Information from the cache
//			var cachedTypePropertiesInfo = TypeCacheUtils.GetPropertyInfoExFor(logicType);
//#if DEBUG
//			Debug.Assert(cachedTypePropertiesInfo != null, "Cached Type Properties info was not present");
//#endif
//			if (cachedTypePropertiesInfo == null) return;

			
//			///Transverse all properties to find children that might need their Load methods to be called
//			foreach (PropertyInfoEx propInfoEx in cachedTypePropertiesInfo)
//			{
//				IStateObject propertyValue = null;
//				if (propInfoEx.prop.PropertyType.IsInterface)
//				{
//					//TODO get value
//					//TODO get typeFromValue
//					//TODO get PropertyInfoEx for property
//				}
//				else
//				{
//					//Load method can only be inside DependantViewModels
//					if (propInfoEx.isAssignableFromIDependantViewModel)
//					{
//						if (propertyValue==null && propInfoEx.MemberGetter!=null)
//							propertyValue = (IStateObject)propInfoEx.MemberGetter(parentControl);
//						//Deep first call of load method on dependants
//						if (propertyValue != null)
//						{
//							//Recursive call
//							InvokeInnerLoadMethods(propertyValue, visited);
//							//Now call the property LoadEvent
//							if (propInfoEx.LoadEvent != null)
//							{
//								var method = propInfoEx.LoadEvent;
//								method.Invoke(propertyValue, new object[0]);
//							}
//						}
//					}
//				}
//			}
//		}
		

		internal void HideView(ILogicWithViewModel<IViewModel> logicObjectWithView)
		{
			IViewModel view = logicObjectWithView.ViewModel;
			view.Visible = false;
		}

		/// <summary>
		/// Disposes the view bound to the given <c>ILogicView</c> object.
		/// </summary>
		/// <param name="logic">The <c>ILogicView</c> object bound to the view to dispose.</param>
		internal void DisposeView(ILogicWithViewModel<IViewModel> logic)
		{
			IViewModel view = logic.ViewModel;
			int count = LoadedViews.RemoveAll(x => x.UniqueID == view.UniqueID);
			_viewsDelta.RemoveView(view);
            var stateManager = StateManager.Current;
			stateManager.RemoveObject(view.UniqueID,true, isDispose: true, formBaseVM: view as UpgradeHelpers.Helpers.FormBaseViewModel);
            stateManager.Tracker.MarkAsModified(this, "LoadedViews");
			ModalViews.Remove(view.UniqueID);
			Debug.Assert(count <= 1, "Exactly one view must be removed");
		}
		/// <summary>
		/// It is used to sync the ViewsState from the client.
		/// When a form is removed on the client side, it will make sure to remove that view from the loaded views
		/// It does not remove it from the state.
		/// </summary>
		/// <param name="viewId"></param>
		internal void DisposeViewInternal(string viewId)
		{
			LoadedViews.RemoveAll(x => x.UniqueID == viewId);
            var stateManager = StateManager.Current;
            stateManager.RemoveObject(viewId,true);
			stateManager.Tracker.MarkAsModified(this, "LoadedViews");
		}

		internal string AddClientCommand(string commandId, object parameters, bool isOneWay)
		{
			string id = StateManager.Current.UniqueIDGenerator.GetUniqueID();
			var newCommand = new ClientCommand
			{
				id = commandId,
				UniqueID = id,
				parameters = parameters,
                isOneWay = isOneWay

				};
			Commands.Add(newCommand);
			_viewsDelta.Commands.Add(newCommand);
			return id;
		}

        #region Promises

        IList<BasePromiseInfo> _promises;
		[JsonIgnore]
        public IList<BasePromiseInfo> Promises
        {
            get
            {
                if (_promises == null)
                {
                    var uid = UniqueIDGenerator.GetRelativeUniqueID(this, "Promises");
                    _promises = StateManager.Current.GetObject(uid) as IList<BasePromiseInfo>;
                    if (_promises==null)
                    {
                        _promises = CreatePromises();
                    }
                    StateManager.Current.isServerSideOnly.Add((IStateObject)_promises);
                }
                return _promises;
            }
        }

        [JsonProperty]
		internal bool InPromiseExecution { get; set; }

		[JsonProperty]
		internal int PromisesInsertionIndex { get; set; }

		internal void BeginPromiseExecution(BasePromiseInfo promise)
		{
			LastPromise = null;
			ExecutingPromiseInfo = promise;
			InPromiseExecution = true;
			PromisesInsertionIndex = 0;
		}

		internal void EndPromiseExecution()
		{
			ExecutingPromiseInfo = null;
			InPromiseExecution = false;
			PromisesInsertionIndex = 0;
			LastPromise = Promises.LastOrDefault();
		}

		internal IPromise LastPromise;
		internal BasePromiseInfo ExecutingPromiseInfo;
		internal void RegisterPromise(BasePromiseInfo promise, int insertionIndex = -1)
		{
            //If we are currently in a execution, all the promises need to be on the top
			if (InPromiseExecution)
			{
				Promises.Insert(PromisesInsertionIndex++, promise);
			}
            else if (insertionIndex != -1)
                Promises.Insert(insertionIndex, promise);
            else
            {
                var index = -1;
                var lastDelimiter = Promises.Where((p) => p is IDelimiterPromise).FirstOrDefault();
                if (lastDelimiter != null)
                    index = Promises.IndexOf(lastDelimiter);
                if (index != -1)
                    Promises.Insert(index, promise);
                else
                    Promises.Add(promise);
            }

			// Promise must be stored in the cache to create a valid reference for its surrogate
			StateManager.Current.AddNewObject(promise);

			LastPromise = promise;
            StateManager.Current.Tracker.MarkAsModified(this, "Promises");
		}

        internal void RemoveContinuation(BasePromiseInfo oldPromise)
        {   
            var index = Promises.FindIndex(x => x.UniqueID.Equals(oldPromise.UniqueID, StringComparison.Ordinal));
            if (index != -1)
            {
                Promises.RemoveAt(index);
            }
            StateManager.Current.Tracker.MarkAsModified(this, "Promises");

        }

		internal void RemoveTopContinuation()
		{
			if (Promises.Count > 0)
			{
				Promises.RemoveAt(0);
			}
            StateManager.Current.Tracker.MarkAsModified(this, "Promises");
		}
		#endregion
        }
}