using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Fasterflect;
using Newtonsoft.Json;
using UpgradeHelpers.Interfaces;
using System.Runtime.CompilerServices;
using System.IO;
using UpgradeHelpers.WebMap.Server.Common;
using UpgradeHelpers.WebMap.List;
using UpgradeHelpers.WebMap.EventAggregator;
using System.Threading;

namespace UpgradeHelpers.WebMap.Server
{

    /// <summary>
    ///     This object only lives during the request execution lifecycle
    ///     This is mostly like a managed memory.
    ///     All object used by the business logic will be cached in this object during a request process
    /// </summary>
    internal partial class StateManager: IStateManager
    {
        internal const string Statecachekey = "@@STATECACHE";
        internal const string BindingKey = "^Binding";
		internal HierarchicalStorage<IStateObject> _cache;
		internal PlainStorage<IStateObject> _tempcache; // Adding support for Object Indexing in the cache, used in the PromoteObject function.
        private object surrogateManagerLock = new object();
        internal readonly SurrogateManager surrogateManager;
        private Dictionary<object, Action> _postActions = new Dictionary<object, Action>(ComparerByReference.CommonInstance);
        private bool _postActionAdded = false;
        private Dictionary<IStateObject, string> _switchedIDsDictionary = new Dictionary<IStateObject, string>(ComparerByReference.CommonInstance);
        object _elementsToRemoveLock = new object();
		private HashSet<string> _elementsToRemove = new HashSet<string>(StringComparer.Ordinal);
        internal HashSet<IStateObject> isServerSideOnly = new HashSet<IStateObject>(ComparerByReference.CommonInstance);
        private object _objectsInResolutionLock = new object();
		private HashSet<string> _objectsInResolution = new HashSet<string>(StringComparer.Ordinal);
		internal HashSet<string> _objectsToBeValidatedAfterDisposeHashSet = new HashSet<string>(StringComparer.Ordinal);


        public IStateObject GetParentEx(IStateObject stateObj)
        {
            //We verify stateobject and that it has a valid UniqueID
            if (stateObj != null && stateObj.UniqueID != null)
            {
                if (UniqueIDGenerator.IsListItem(stateObj.UniqueID))
                {
                    var refTableUniqueId = UniqueIDGenerator.GetReferenceTableRelativeUniqueID(stateObj.UniqueID);
                    IReferenceTable table = this.GetObject(refTableUniqueId) as IReferenceTable;
                    if (table == null)
                        table = this.GetObject(refTableUniqueId, includeDeleted: true, getObjectFromTempCache: true) as IReferenceTable;
                    if (table != null)
                    {
                    foreach (var i in table.References)
                    {
                        if (UniqueIDGenerator.IsPage(i.TargetUniqueID))
                        {
                            Page p = PageManager.LoadPage(i.TargetUniqueID);
                                if (p != null)
                                {
                            if (p.Parent.GetType() == typeof(string))
                                return GetObject(p.Parent as string);
                            else if (p.Parent is IWebMapList)
                                return p.Parent as IStateObject;
                        }
                    }
                }
                }
                }
                else
                {
                    var accessPath = stateObj.UniqueID;
                    var accessPathIndex = accessPath.IndexOf(UniqueIDGenerator.UniqueIdSeparator);
                    if (accessPathIndex > 0)
                    {
                        var ancestorUID = accessPath.Substring(accessPathIndex + 1);
                        return GetObject(ancestorUID);
                    }
                }
            }
            return null;
        }

		public string GetParentKeyEx(string key)
		{
			if (UniqueIDGenerator.IsListItem(key))
			{
                var refTableUniqueId = UniqueIDGenerator.GetReferenceTableRelativeUniqueID(key);
                IReferenceTable table = this.GetObject(refTableUniqueId) as IReferenceTable;
                if (table == null)
                    table = this.GetObject(refTableUniqueId, includeDeleted: true, getObjectFromTempCache: true) as IReferenceTable;

				if (table != null)
				{
					foreach (var i in table.References)
					{
						if (UniqueIDGenerator.IsPage(i.TargetUniqueID))
						{
							Page p = PageManager.LoadPage(i.TargetUniqueID);
                            if (p != null)
                            {
							var parentStr = p.Parent as string;
							if (parentStr != null)
								return parentStr;
							else
							{
								var parentVirtualList = p.Parent as IWebMapList;
								if (parentVirtualList != null)
									return parentVirtualList.UniqueID;
							}
						}
					}
				}
			}
            }
			else
			{
				var indexOfSeparator = key.IndexOf(UniqueIDGenerator.UniqueIdSeparator);
				if (indexOfSeparator != -1)
					return key.Substring(indexOfSeparator + 1);
			}
			return null;
		}

        /// <summary>
        /// Recursive method that returns the real UniqueID that we are interested in the ValidateReferences
        /// </summary>
        internal string BuildFullPathUniqueID(string uniqueID, string lastParentTopModel = "")
        {
            var topModel = UniqueIDGenerator.GetTopLevelUniqueID(uniqueID);
            if (lastParentTopModel == "") lastParentTopModel = topModel;
            if (UniqueIDGenerator.IsListItem(topModel))
            {
                var parent = GetParentKeyEx(topModel);
                if (parent != null && parent.IndexOf(topModel, StringComparison.Ordinal) == -1 && parent.IndexOf(lastParentTopModel, StringComparison.Ordinal) == -1)
                    return uniqueID + "#" + BuildFullPathUniqueID(parent, topModel);
                else
                    return uniqueID;
            }
            else
                return uniqueID;
        }

        internal void AddIDInResolution(string uniqueID)
		{
			lock (_objectsInResolutionLock)
			{
				_objectsInResolution.Add(uniqueID);
			}
		}

		internal bool IsIDInResolution(string uniqueID)
		{
			return _objectsInResolution.Contains(uniqueID);
		}

		internal void RemoveIDInResolution(string uniqueID)
		{
			lock (_objectsInResolutionLock)
			{
				_objectsInResolution.Remove(uniqueID);
			}
		}

		internal IStorageManager StorageManager;
		//internal read only DeltaTracker _tracker = new DeltaTracker();
		internal DeltaTracker Tracker;

        private UniqueIDGenerator _uniqueIDGenerator;

        internal UniqueIDGenerator UniqueIDGenerator
        {
            get
            {
                if (_uniqueIDGenerator == null)
                {
                    var item = GetObject(UniqueIDGenerator.UniqueIdGeneratorCacheId) as UniqueIDGenerator;
                    if (item == null)
                    {
                        item = new UniqueIDGenerator();
                        AddNewObject(item);
                    }
                    _uniqueIDGenerator = item;
                }
                return _uniqueIDGenerator;
            }
        }

        private ReferencesManager _referencesManager;

        internal ReferencesManager ReferencesManager
        {
            get
            {
                if (_referencesManager==null)
                {
                    _referencesManager = new ReferencesManager(this);
                }
                return _referencesManager;
            }
        }

        private StateManager()
        {
			_cache = new HierarchicalStorage<IStateObject>(this);
			_tempcache = new PlainStorage<IStateObject>(this); // Adding support for Object Indexing in the cache, used in the PromoteObject function.
            surrogateManager = new SurrogateManager(this);
            StorageManager = StorageManagerFactory.CreateInstance(this, surrogateManager);
            Tracker = new DeltaTracker(this);
            if (!TypePropertiesCache.ALIAS_ENABLED)
            {
                _serializer.NullValueHandling = NullValueHandling.Include;
                _serializer.DefaultValueHandling = DefaultValueHandling.Include;
                _serializerIndex.NullValueHandling = NullValueHandling.Include;
                _serializerIndex.DefaultValueHandling = DefaultValueHandling.Include;
            }
        }

        public bool AllDependenciesAreProcessed { get { return surrogateManager.AllDependenciesAreProcessed; } }

        internal VirtualPageManager pageManager;
        internal VirtualPageManager PageManager
        {
            get
            {
                if (pageManager == null)
                    pageManager = new VirtualPageManager(this, this.UniqueIDGenerator, UpgradeHelpers.Helpers.StaticContainer.Instance);
                return pageManager;
            }
        }
        /// <summary>
        /// This serializer is used to serialize AppChanges messages which are sent as responses from
        /// sendAction calls from the client
        /// </summary>
        internal static JsonSerializer _serializer = JsonSerializer.Create(
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.None,
                            ContractResolver = PropertySkipperContractResolver.CommonInstanceClient,
							NullValueHandling = NullValueHandling.Ignore,
							DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,
                            Converters = new JsonConverter[] {
								new EventPromiseInfoClientConverter(),
                                new ViewsStateDeltaConverter(),
                                new VirtualListSerializerClient(),
							  new StateObjectPointerConverter(false),
							  
                            }
                        });

        /// <summary>
        /// This serializer is used to serialize the current application state.
        /// This serialization is used when the page is first loaded or after a page refresh (F5 in most browsers)
        /// </summary>						
        internal static JsonSerializer _serializerIndex = JsonSerializer.Create(
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = PropertySkipperContractResolver.CommonInstanceClient,
					DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,
					NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    Converters = new JsonConverter[] {
						new EventPromiseInfoClientConverter(),
                        new ViewsStateDeltaConverter(),
                        new VirtualListSerializerClient(),
                      new StateObjectPointerConverter(false)
                    }
                });




        /// <summary>
        /// Calculates the state delta message that contains the information that need to be applied on
        /// the client side to sync information state with server side
        /// </summary>
        /// <param name="piggyBackResult"></param>
        /// <returns></returns>
        internal static void GenerateAppChanges(TextWriter writer, PiggyBackResult piggyBackResult)
        {
            var current = StateManager.Current;
            ViewsStateDelta viewStateDelta = ViewManager.Instance.EndStateDelta;
            var switchedIds = current.GetSwitchedIds(toClient:true);
            var idsToRemove = current.GetElementsToRemoveForClient();
            int[] modelStateDeltaTypes=null;
			string isNewString = null;
			var modelStateDelta = current.GetDeltasForClientSync(ref modelStateDeltaTypes, ref isNewString);
            object res;
            res = 
				new AppChangesResponse()
				{
                VD = viewStateDelta,
                MD = modelStateDelta,
                MDT = modelStateDeltaTypes,
                SW = switchedIds,
				RM = idsToRemove,
				NV = isNewString
				};
            if (piggyBackResult != null)
            {
                res = piggyBackResult(res);
            }
			using (var jsonTextWriter = new JsonTextWriter(writer))
			{
				jsonTextWriter.ArrayPool = JsonArrayPool.Instance;
				_serializer.Serialize(jsonTextWriter, res);
			}
        }

        /// <summary>
        ///     This method is meant to make sure that all required levels for a model are loaded
        /// </summary>
        /// <param name="model"></param>
        private void LoadRequiredSublevels(IStateObject model, HashSet<object> visited)
        {
            if (visited.Contains(model)) return;
            visited.Add(model);
            if (TypeCacheUtils.IsControlArray(model.GetType()))
            {
                dynamic m = model;
                dynamic count = m.Count;
                for (int i = 0; i < count; i++)
                {
                    dynamic testVal = m[i];
                    if (testVal is IStateObject)
                    {
                        LoadRequiredSublevels(testVal, visited);
                    }
                    testVal = null;
                }
            }
            else
            {
                //Get Properties to load from cache
                var props = TypeCacheUtils.GetPropertiesForAppState(model.GetType());

                //Lets iterate through all properties to force a load if necessary
                foreach (var prop in props)
                {
                    //This will load the property
                    var value = prop.GetValue(model, null) as IStateObject;
                    if (value != null)
                        LoadRequiredSublevels(value, visited);
                }

            }
        }

        /// <summary>
        /// Loads into the statecache memory all the models and its dependent models
        /// When all models are loaded, it returns a JSON dump of the complete application state
        /// </summary>
        /// <returns>
        ///   VD = current view state. for example which viewmodels are loaded, 
        ///   MD = all models and its dependencies
        ///   MT = if client side is being used then provides information to mark model types
        /// }
        /// </returns>
        public void GenerateCurrentStateAsJSON(TextWriter writer)
        {
            ViewsState viewState = ViewManager.Instance.State;
            //We need to disable events to avoid side effects caused
            //we reading some properties
            ViewManager.Instance.Events.Suspend();

            IEnumerable<IStateObject> models = from v in viewState.LoadedViews select (IStateObject)StateManager.Current.GetObject(v.UniqueID);
            //We need to force loading all dependencies 
            foreach (IStateObject model in models)
            {
                LoadRequiredSublevels(model, new HashSet<object>());
            }

            var cacheModelEntries = StateManager.Current.GetModelEntries();
			//All entries are new.
			var newString = new String('1', cacheModelEntries.Count);


            object res;
            //we assume that if there is ClientSideMappingInfo we are using the FrontEndTyping feature
            if (TypeCacheUtils.ClientSideMappingInfo != null)
            {
				res = new CurrentState { VD = viewState, MD = cacheModelEntries, MDT = GetModelTypes(cacheModelEntries), NV = newString };
            }
            else
            {
				res = new CurrentState { VD = viewState, MD = cacheModelEntries, NV = newString };
            }
            using (var jsonTextWriter = new JsonTextWriter(writer))
            {
                jsonTextWriter.ArrayPool = JsonArrayPool.Instance;
                _serializerIndex.Serialize(jsonTextWriter, res);
            }
            //We re-enable the events management
            ViewManager.Instance.Events.Resume();
        }


        /// <summary>
        /// Returns an array where each entry corresponds to the model type value
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static object GetModelTypes(IList<IStateObject> models)
        {
            IEnumerable<int> res = (from m in models
                                    let mappedType = TypeCacheUtils.GetModelTypedInt(m)
                                    select mappedType);
            return res;
        }




        public static bool IsAvailable
		{
			get
			{
                 return _instance != null;
			}
		}



        /// <summary>
        /// is cleared on DoDefaultInjectionInController to make sure that is 
        /// null at the start of the request
        /// </summary>
        [ThreadStatic]
        private static StateManager _instance;
		public static StateManager Current
		{
			get
			{
                return _instance ??
                    (_instance = new StateManager());
            }
            internal set
            {
                _instance = value;
            }
        }


        public static IStateManager GetCurrent()
        {
            return Current;
        }
		/// <summary>
		/// Checks if the TopLevel object is a valid parent to go to the client.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		private bool IsValidTopLevel(IStateObject obj)
		{
			var topLevelUniqueID = UniqueIDGenerator.GetTopLevelUniqueID(obj.UniqueID);
			return !UniqueIDGenerator.IsModel(topLevelUniqueID) && !UniqueIDGenerator.IsSharedState(topLevelUniqueID) && topLevelUniqueID[0] != '^'
				&& !UniqueIDGenerator.IsUnAttached(topLevelUniqueID) && !UniqueIDGenerator.IsSurrogate(topLevelUniqueID);
		}

        private bool IsValidCollection(IStateObject obj)
        {
            bool breturn = true;
            var obj_check =  obj as IWebMapList;

            if (obj_check != null){
                breturn = obj_check.Count > 0 || this.StorageManager.HasObject(obj.UniqueID);
                //breturn = obj_check.Count > 0 || _dettachObjects.Contains(obj.UniqueID);
            }

            return breturn;
        }
        
		public bool ShouldGoToClient(IStateObject obj, IStateManager sm)
		{
			return
				(obj is IViewModel || obj is IDependentViewModel || obj is StateObjectPointerReference) &&
				!(obj is StateObjectSurrogate) && //Surrogates are not sent to the client                                                   
                IsValidCollection(obj) &&
				!isServerSideOnly.Contains(obj) &&
				CheckIfNeedsToBePersisted(obj) &&
				IsValidTopLevel(obj)//Is it a pointer reference that might go to the client
				&& (sm == null || (sm != null && !sm.IsInElementsToRemove(obj.UniqueID)));
				
		}


        public IList<DirtyEntry> GetDirtyEntriesForClient()
        {
			var modifiedObjects = Tracker.getModifiedObjectDeltas(ShouldGoToClient);
            foreach (var element in justPromoted.Values)
            {
                if (ShouldGoToClient(element, null))
                {
                    modifiedObjects.Add(new DirtyEntry(element, element, true));
                }
            }
            modifiedObjects.Sort(DirtyEntryComparer.CommonInstance);
            return modifiedObjects;
        }


        public static bool ShouldGoToServer(IStateObject obj, IStateManager sm)
        {
			if (!AllBranchesAttached(obj) || (obj is StateObjectSurrogate) || 
                (obj is StateObjectPointer && !CheckIfNeedsToBePersisted(obj))
				|| sm != null && sm.IsInElementsToRemove(obj.UniqueID))
				
                return false;
            return true;
        }

        //Loading the target property of a pointer has a side effect.
        //of introducing objects in the cache
        //We need to do this before the dependencies calculation
        //To avoid issues with surrogate references
        public void ForcePointerTargetPreload()
        {
            var currentEntries = new IStateObject[Tracker.bitArrays.Count];
			Tracker.bitArrays.Keys.ToList().CopyTo(currentEntries);
            foreach(var item in currentEntries)
            {
                if (item is StateObjectPointer)
                {
                    if (!(item is StateObjectPointerReferenceSuperValueBase))
                    {
                        var temp = ((StateObjectPointer)item).Target;
                    }
                }
            }
        }


        public List<IStateObject> GetDirtyEntriesForServer()
        {
            var modifiedObjects = Tracker.getModifiedObjects(ShouldGoToServer);
            foreach (var element in justPromoted.Values)
            {
                if (ShouldGoToServer(element, null))
                {
                    modifiedObjects.Add(element);
                }
            }
            return modifiedObjects;

        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRootLevelObject(IStateObject obj)
		{
			return obj is ITopLevelStateObject;
		}

		/// <summary>
		/// Determines if the specified obj is attached. It does not need that
		/// the object is attached to an element on the StateManager.Current._stateManager
		/// it could also be any object on the temp stateManager
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAttached(IStateObject obj)
		{
			if (obj.UniqueID == null)
				return false;
			return !(obj.UniqueID[0] == UniqueIDGenerator.TEMPPrefix[0]) || obj.UniqueID.LastIndexOf('$') > 0;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetLastPartOfUniqueID(IStateObject obj)
		{
			var uniqueID = obj.UniqueID;
            if (UniqueIDGenerator.IsListItem(uniqueID)) return obj.UniqueID;
            for (int i = 0; i < uniqueID.Length; i++)
            {
                if (uniqueID[i] == UniqueIDGenerator.UniqueIdSeparator)
                {
                    return uniqueID.Substring(0, i);
                }
            }
            return null;


        }

        /// <summary>
        /// This method is to verify that we are not trying to promote an object
        /// whose parent has not been promoted yet
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AllBranchesAttached(IStateObject obj)
		{
			return AllBranchesAttached(obj.UniqueID);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AllBranchesAttached(string uniqueId)
		{
            return uniqueId != null && uniqueId.LastIndexOf(UniqueIDGenerator.TEMPPrefixChar) == -1;
        }

		internal Dictionary<string, IStateObject> justPromoted = new Dictionary<string, IStateObject>(StringComparer.Ordinal);
		private object justPromotedLock = new object();
		/// <summary>
		/// Promote moves object to an upper level stateManager
		/// Search is done by reference. After finding instance on temp stateManager it will remove its old key
		/// And object will be put on the upper level stateManager (StateManager) using the current UniqueID
		/// 
		/// Prior to calling this method, the uniqueID is update, that is why the search is performed by reference not id
		/// </summary>
		/// <param name="obj"></param>
		public void PromoteObject(IStateObject obj, string newUniqueID = null, bool inAdoption = false)
		{
			try
			{
				// If promoting an id that is marked to be deleted, 
				// then remove it from the elements-to-remove list
				UndoRemove(newUniqueID);
				string keyToRemove = obj.UniqueID;
				if (!String.IsNullOrEmpty(keyToRemove)) //Mobilize.MLO: keyToRemove cannot be null
				{
					Debug.Assert(keyToRemove != null);
					//Find all children of this key
					SwitchOrPromoteAllDependends(obj, newUniqueID, promote: true, inAdoption: inAdoption);
					surrogateManager.UpdateReference(obj);
					RemoveEntryFromTempCache(keyToRemove);
					AddInCache(obj.UniqueID, obj, true);
				}
			}
			catch (Exception)
			{
				//Log the error
			}
		}

        IServerEventAggregator _serverEventAggregator;
        public IServerEventAggregator ServerEventAggregator
        {
            get
            {
                if (_serverEventAggregator == null)
                    _serverEventAggregator = new ServerEventAggregator();
                return _serverEventAggregator;
            }
        }

		public void SwitchOrPromoteAllDependends(IStateObject obj, string newUniqueID, bool promote = true, bool inAdoption = false)
		{
			//Gets all the Dependents of the Object
			var dependents = _tempcache.GetAllDependentItems(obj);
			foreach (var child in dependents)
			{
				//For each child of Object lets update the uniqueID.
				var childValue = child.Value;
				childValue.UniqueID = ComputeNewDependantUniqueID(obj.UniqueID, child.Key, newUniqueID);
				//If it's fully attached, the entry goes to the cache.
				if (promote && AllBranchesAttached(childValue.UniqueID))
				{
					UndoRemove(childValue.UniqueID);
					AddInCache(childValue.UniqueID, childValue, true);
                }
                else
					AddInTempCache(childValue.UniqueID, childValue);
				RemoveEntryFromTempCache(child.Key);
				surrogateManager.UpdateReference(childValue);
            }
			obj.UniqueID = newUniqueID;
        }

		/// <summary>
		/// Used during state cache SwitchUniqueIds
		/// </summary>
		/// <param name="currentKey"></param>
		/// <param name="newKey"></param>
		public void SwitchAllDependendsInStateCache(string currentKey, string newKey)
		{
			foreach (var pair in GetDependentItemsInCache(currentKey))
			{
				bool justPromoted;
				RemoveObjectReference(pair.Key, out justPromoted);
				pair.Value.UniqueID = ComputeNewDependantUniqueID(currentKey, pair.Key, newKey);
				surrogateManager.UpdateDependantSurrogatePointerReferences(pair.Key, pair.Value.UniqueID, pair.Value);
				UndoRemove(pair.Value.UniqueID);
				//There is the risk that entries from the old object remain in the cache.
				AddInCache(pair.Value.UniqueID, pair.Value, true);
			}
		}





		internal static List<JsonConverter> serverSideConverters = new List<JsonConverter>();

		internal static void AddServerSideConverter(JsonConverter jsonConverter)
		{
			serverSideConverters.Add(jsonConverter);
		}

		

		//This collection is maintained only during the duration of the Request
		//It is reset on RequestStart and on RequestEnd



		
		AdoptionInformation adoptionInformation;
		private object adoptionInformationLock = new object();

        public AdoptionInformation AdoptionInformation
        {
            get
            {
                lock (adoptionInformationLock)
                {
                    if (adoptionInformation == null)
                    {
                        adoptionInformation = new AdoptionInformation(this);
                    }
                }
                return adoptionInformation;
            }
        }




        /// <summary>
        /// Register parent object as candidate foster parent for obj
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="obj"></param>
        /// <param name="godparent"></param>
        public void RegisterPossibleOrphan(IStateObject parent, IStateObject obj)
        {
            AdoptionInformation.RegisterPossibleOrphan(parent, obj);
        }

        public void ClearOrphans()
		{
            lock (adoptionInformationLock)
            {
                adoptionInformation = null;
            }
		}

        public void HandleOrphans()
        {
            lock (adoptionInformationLock)
            {
                if (adoptionInformation == null) return;
                adoptionInformation.HandleOrphansEx();
            }
        }



		public void Persist()
		{
			surrogateManager.CalculateSurrogatesToBePersisted();

			/// Step 1 : Apply id switches
			foreach (var valuePair in this.GetSwitchedIds(toClient:false))
			{
				StorageManager.SwitchUniqueIDsFrom(itemUID: valuePair[0], lastUID: valuePair[1]);
			}

            //We precalculate all the list of dirty entries
            var dirtyModels = GetDirtyEntriesForServer();

            // Step 2: Apply property changes to storage
            foreach (var dirtyEntry in dirtyModels)
            {
                StorageManager.SaveObject(dirtyEntry);
            }

			// Step 3: Remove elements from storage
			foreach (var idOfElementToRemove in _elementsToRemove)
			{
				StorageManager.RemoveObject(idOfElementToRemove);
			}

			surrogateManager.Persist();
            
            StorageManager.SaveObject(UniqueIDGenerator);
        }

		


		/// <summary>
		/// If the given object *IS NOT* a Reference or *IS* a Reference and
		/// it fulfills the requirements to be serialized it returns true. 
		/// Otherwise false.
		/// </summary>
		/// <param name="entry"></param>
		/// <returns></returns>
		private static bool CheckIfNeedsToBePersisted(object entry, bool isForClient = false)
		{
			var pointer = entry as StateObjectPointer;
			//This is avoid issues with pointers
			//It they are not attached we will not persist them
			if (pointer == null)
			{
				return true;
			}
			else
			{
				var target = pointer is StateObjectPointerReferenceSuperValueBase ? ((StateObjectPointerReferenceSuperValueBase)pointer).SuperTarget : pointer.Target;
				if (target != null && StateManager.AllBranchesAttached(pointer))
				{
                    if (isForClient && (/*target is IModel ||*/ target is IDependentModel || StateManager.Current.isServerSideOnly.Contains(target)))
						return false;
                    if (isForClient && target is IStateObject && StateManager.IsChild(((IStateObject)target).UniqueID, pointer.UniqueID))
                        return false;
					return true;
				}
			}
			return false;
		}



		/// <summary>
		/// Calculates the delta object that requires client synchronization.
		/// <p>Objects that does not qualified to be synchronized are:</p>
		/// <list type="bullet">
		/// <item>IInternalData objects</item>
		/// <item>Objects contained by an IInternalData object</item>
		/// <Item>ILogincSinglenton objects that has no serializable state</Item>
		/// </list>
		/// </summary>
		/// <returns></returns>
		internal System.Collections.IList GetDeltasForClientSync(ref int[] typeInfo, ref string isNewBitArray)
		{
			var dirties = GetDirtyEntriesForClient();
            typeInfo = new int[dirties.Count];
            var result = new object[dirties.Count];
			var bitArray = new char[dirties.Count];
            for (int i = 0; i < dirties.Count;i++)
            {
                var dirty = dirties[i];
                var modelId = TypeCacheUtils.GetModelTypedInt(dirty.Value);
                typeInfo[i] = modelId;

                //We need to include the uniqueId in the delta
				var converter = DeltaTracker.GetConverter(modelId);
				if (converter != null)
				{
                    result[i] = converter(null, dirty.Value, dirty.Delta);
				}
                else
                {
                    result[i] = dirty.Delta;
                }
				//Bit array of new entries.
				bitArray[i] = dirty.IsNew ? '1' : '0';
			}
			isNewBitArray = new String(bitArray);
			return result;
		}

        internal string[] GetElementsToRemoveForClient()
		{
            var elementsToRemove = new List<string>();
            foreach (var val in this._elementsToRemove)
            {
                //At the client side, there is no need to send the reference table as an element to be removed at client side
                //because there is no Reference Table.
                if (!UniqueIDGenerator.IsRefencesTable(val))
                    elementsToRemove.Add(val);
            }
            return elementsToRemove.ToArray();
		}

        /// <summary>
        /// Returns the list of switched ids.
        /// </summary>
        internal string[][] GetSwitchedIds(bool toClient = false)
        {
            List<string[]> result = new List<string[]>(this._switchedIDsDictionary.Keys.Count);
            for (var i = 0; i < this._switchedIDsDictionary.Keys.Count; i++)
            {
                var obj = this._switchedIDsDictionary.Keys.ElementAt(i);
                var oldUniqueID = this._switchedIDsDictionary.Values.ElementAt(i);
                var finalUniqueID = obj.UniqueID;
                //We have to check always if the final uniqueId is allbranchesattached
                //otherwise it is an object that has never been adopted or promoted to cache.

                if (toClient)
                {
                    //We don't have to send switched ids that are IDependentModels, which is never sent to client.
                    if (obj is IDependentViewModel && AllBranchesAttached(finalUniqueID))
                    {
                        result.Add(new string[] { oldUniqueID, finalUniqueID });
                    }
                }
                else
		{
                    if (AllBranchesAttached(finalUniqueID))
                        result.Add(new string[] { oldUniqueID, finalUniqueID });
            }
            }
            return result.ToArray();
        }
        internal IStateObject DettachObject(string uid, bool registerSwitchID = true)
        {
            var obj = GetObject(uid);
            if (obj != null)
                return DettachObject(obj, registerSwitchID);
            else
                return null;
        }
        /// <summary>
        /// In some scenarios it's required to Detach an object from another one being removed.
        /// </summary>
        public IStateObject DettachObject(IStateObject obj, bool registerSwitchID = true)
        {
            //We need to give the element a new non attached id.
            var newDettachedParent = UniqueIDGenerator.GetUniqueIDForTemporaryObject();

            var uniqueID = obj.UniqueID;
            if (
                //We should never change the uniqueID of a Page, because this is a TopLevel UniqueID
                UniqueIDGenerator.IsPage(obj.UniqueID))
            {
                bool justPromotedValue;
                RemoveObjectReference(uniqueID, out justPromotedValue,removeEntryFromCache:false);

            }
            else if (
                //We should never change the uniqueID of a List Item, because the list item is TopLevel UniqueID
                UniqueIDGenerator.IsListItem(obj.UniqueID))
            {
                //Do nothing
            }
            else if (
            // If the element is fully attached to a IStateObject
            //then we need to retrieve all the entities from the 
            //_cache and insert them in to the _tempCache
                AllBranchesAttached(obj.UniqueID))
            {
                //All the Dependants for the object
                bool justPromotedValue;
                RemoveObjectReference(uniqueID, out justPromotedValue);
                var dependants = GetAllChildrenKeys(obj.UniqueID, justPromotedValue);
                IStateObject element = null;
                HashSet<string> alreadyProcessed = new HashSet<string>();
                foreach (var oldUniqueID in dependants)
                {
                    if (!alreadyProcessed.Add(oldUniqueID))
                        continue;
                    //We get the element or instance
                    element = GetObject(oldUniqueID);
                    //If the Key is in the Dependants it shouldn't be null, but for sanity.
                    if (element != null)
                    {
                        //If the element to be detached is a list item
                        // we should handle it in a special way.
                        // This is because the list items are top level objects.
                        if (UniqueIDGenerator.IsListItem(oldUniqueID))
                        {
                            //We are going to get the dependents of the key.
                            var subdependants = GetAllChildrenKeys(oldUniqueID, justPromotedValue);
                            //For each subdependants' subkeys, we have to modify its uniqueid
                            // in order to be promoted/adopted/switched once the key is promoted/adopted/switched.
                            foreach (var subkey in subdependants)
                            {
                                alreadyProcessed.Add(subkey);
                            }
                            continue;
                        }
                        else
                        {
                            var newID = UniqueIDGenerator.ReplaceParent(oldUniqueID, uniqueID, newDettachedParent);
                            //A new ID is calculated by replacing the old parent.
                            element.UniqueID = newID;
                        }

                        bool justPromoted;
                        RemoveObjectReference(oldUniqueID, out justPromoted);                        
                        if (CanRegisterIDSwitch( justPromoted, registerSwitchID))
                        {
                            RegisterIdSwitch(element, oldUniqueID, element.UniqueID);
                        }
                        //The entry is added to the _tempCache in order to make it fully 'unttached.'
                        AddInTempCache(element.UniqueID, element);
						//Updates all references poiting to the old UniqueID
						ReferencesManager.UpdateReferencesTables(oldUniqueID, element.UniqueID);
                        ReferencesManager.UpdateRefTableInDettachObject(element, oldUniqueID, oldUniqueID);
                    }
                }
                //A new ID is calculated by replacing the old parent.
                obj.UniqueID = UniqueIDGenerator.ReplaceParent(obj.UniqueID, uniqueID, newDettachedParent);
                if (CanRegisterIDSwitch(justPromotedValue,registerSwitchID))
                {
                    RegisterIdSwitch(obj, uniqueID, obj.UniqueID);
                }
                ReferencesManager.UpdateRefTableInDettachObject(obj, obj.UniqueID, uniqueID);
                AddInTempCache(obj.UniqueID, obj);
            }
            else
            {
                //If the Keys are not fully attached then we just need to change the UniqueIDs.
                SwitchUniqueIds(obj,obj.UniqueID, newDettachedParent);
            }
            return obj;
        }

        /// <summary>
        /// Dettaching a List Item will only remove it from cache, insert it to tempcache waiting someone to promote it again
        /// otherwise, it will be removed, since it is in the ElementsToRemove collection
        /// Note: this is a recursive method that detaches itself and all its dependents.
        /// </summary>
        internal void DettachListItem(string uniqueID, string rootUniqueID = "")
        {
            bool justPromotedValue;
            RemoveObjectReference(uniqueID, out justPromotedValue,removeEntryFromCache:false);

            var dependants = GetAllChildrenKeys(uniqueID, justPromotedValue);
            foreach (var oldUniqueID in dependants)
            {
                TryRemovePage(oldUniqueID, rootUniqueID);
                DettachListItem(oldUniqueID, rootUniqueID);
            }
        }
        private bool CanRegisterIDSwitch(bool justPromoted, bool registerId)
        {
            //We have to register a Switched ID when it meets the following conditions:
            return // If the element is an item that has been promoted in the previous request.
                   // The way to check this condition is asking if the element is not in JustPromoted list.
                !justPromoted &&
                 // The RegisterSwithcedID flag is true if and only if DettachObject is invoked when
                 // we aren't within the Disposing process, in other words,
                 //any operation within the Dispose method will make this flag as False
                 registerId;
           
        }
        /// <summary>
        ///  In some cases we just need to make sure that the reference to an object is removed from
        /// either the Storage or the justPromoted elements 
        /// </summary>
        /// <param name="uniqueID"></param>
        public void RemoveObjectReference(string uniqueID, out bool isJustPromoted, bool addToElementsToRemove = true, bool removeEntryFromCache = true)
		{
            if(removeEntryFromCache)
			    RemoveEntryFromCache(uniqueID);
			isJustPromoted = false;
			lock (justPromotedLock)
			{
				isJustPromoted = justPromoted.Remove(uniqueID);
			}
			lock (_elementsToRemoveLock)
			{
                if (addToElementsToRemove)
                {
                    _elementsToRemove.Add(uniqueID);
                }
                else if (!addToElementsToRemove && !isJustPromoted)
                {
                    _elementsToRemove.Add(uniqueID);
			}
		}
		}
       
        /// <summary>
		/// Does not directly remove element but registers it for deletion
		/// </summary>
		/// <param name="uniqueId"></param>
		/// <param name="deep"></param>
		/// <returns></returns>
        private enum object_location{ _none, _tempCache, _cache, _other };
		public bool RemoveObject(string uniqueId, bool mustDetach, bool deep = true, string rootUniqueID = null, bool isDispose = false, object formBaseVM = null)
		{
			bool somethingRemoved = false;
			IStateObject objToRemove;
			rootUniqueID = rootUniqueID ?? uniqueId;
			bool isAllBranchesAttached = true;
			bool isJustPromoted = false;
            object_location location = object_location._none;
            if (_tempcache.TryGetValue(uniqueId, out objToRemove))
			{
                location = object_location._tempCache;
				isAllBranchesAttached = false;
			}
			else if (_cache.TryGetValue(uniqueId, out objToRemove))
			{

                location = object_location._cache;
			}
			else
			{
                location = object_location._other;
			}

			bool rescue = false;

            if (location > 0)
            {
                rescue = ReferencesManager.RescueValue(uniqueId, rootUniqueID, isDispose: isDispose, formBaseViewModel: formBaseVM as IFormBaseViewModel, _objectsToBeValidatedAfterDisposeHashSet: _objectsToBeValidatedAfterDisposeHashSet);
                if (rescue) return somethingRemoved;
            }

            if (deep)
            {
                //First, we have to remove all the dependents that is in the Cache. (Those that were already promoted)
                //Second, we have to remove all the dependents that is in the TempCache. (Those that are not promoted yet)
                HashSet<string> dependants = null;
                if (isAllBranchesAttached)
                    dependants = GetAllChildrenKeys(uniqueId, isJustPromoted);
                else
                    dependants = GetAllChildrenKeysInTempCache(uniqueId);

                foreach (var idToDelete in dependants)
                {
                    if (idToDelete != uniqueId)
                    {
                        var removed = RemoveObject(idToDelete, true, deep: false, rootUniqueID: rootUniqueID, isDispose: isDispose, formBaseVM:formBaseVM);
                        if(removed) somethingRemoved = true;
                    }
                }
            }
            if (!rescue)
            switch (location)
            {
                case object_location._tempCache:
                    {
                        RemoveEntryFromTempCache(uniqueId);
                        somethingRemoved = true;
                    }
                    break;
				case object_location._cache:
					{
                        if (mustDetach)
						{
							this.Tracker.DetachModel(objToRemove);
						}
							TryRemoveSurrogateOrPage(uniqueId, rootUniqueID, isDispose);
                        RemoveObjectReference(uniqueId, out isJustPromoted);
						somethingRemoved = true;
					}
					break;
                case object_location._other:
                    {
                        // lets check for surrogates and binding objects first
                        if (IsBindingObject(uniqueId))
                        {
                            RemoveBindingObject(uniqueId);
                            somethingRemoved = true;
                        }
                            TryRemoveSurrogateOrPage(uniqueId, rootUniqueID, isDispose);
                        //Avoid removing the object at this moment
                        //If AllTheBranches are not attached we should not add the element to the elementsToRemove 
                        //collection, that collection is supposedly made to interact or delete objects that are already 
                        //in the session.
                        if (AllBranchesAttached(uniqueId))
                        {
                            lock (_elementsToRemoveLock)
                            {
                                _elementsToRemove.Add(uniqueId);
                            }
                            somethingRemoved = true;
                        }
                    }
                    break;
                default: break;
            }
            
			return somethingRemoved;
		}

        private void TryRemoveSurrogateOrPage(string uniqueId, string rootUniqueID = "", bool isDispose = false)
		{
			object value = null;
			// First check if the unique id corresponds to a surrogate
			//or a pointer to a surrogate 
			if (UniqueIDGenerator.IsPointer(uniqueId))
			{
				//if it a pointer then retrieve
				// the target which can be a surrogate 
				// in which case needs to be retrieved
				//to make sure that surrogate metadata is loaded
				var pointer = (StateObjectPointer)GetObject(uniqueId, true);
				if (pointer != null && IsSurrogate(pointer.TargetUniqueId))
				{
					// lets try to get the surrogate just to remove reference
                    try
                    {
                        GetObject(pointer.TargetUniqueId);
                    }
                    catch
                    {
                        Trace.TraceError("Error while removing Pointer " + pointer.UniqueID + " there was an error while loading the pointed surrogate");
                    }
				}
				else if (pointer != null && UniqueIDGenerator.IsPage(pointer.TargetUniqueId))
				{
					value = GetObject(pointer.TargetUniqueId);
				}
			}
			var valueAsPage = value as IVirtualPage;
			if (valueAsPage != null)
			{
                bool shouldCleanUpPage = false;
                var parentUniqueID = ReferencesManager.GetPageParentUniqueID(valueAsPage);
                var fullPathParentUniqueID = BuildFullPathUniqueID(parentUniqueID);

				// We should cleanUpPage if and only if the List is not AllBranchesAttached or if List is in ElementsToRemove
                shouldCleanUpPage =
                        fullPathParentUniqueID.IndexOf(rootUniqueID) != -1 ||
                        !AllBranchesAttached(parentUniqueID) ||
                        IsInElementsToRemove(parentUniqueID);


                if (shouldCleanUpPage) 
                    pageManager.CleanUpPage(this, ReferencesManager, valueAsPage, rootUniqueID, isDispose);
			}
			else
			{
				//the object might be a surrogate in which case
				//we need to wipe all references. if it is not nothing will happen
				//RemoveFromAllSurrugateReferences(uniqueId);
				//Finally remove it
				IStateObject objectToDetach;
				if (_cache.TryGetValue(uniqueId, out objectToDetach))
				{
					Tracker.DetachModel(objectToDetach);
					RemoveEntryFromCache(uniqueId);
				}
			}
		}

        private void TryRemovePage(string uniqueId, string rootUniqueID = "")
        {
            object value = null;
            // First check if the unique id corresponds to a surrogate
            //or a pointer to a surrogate 
            if (UniqueIDGenerator.IsPointerPage(uniqueId))
            {
                //if it a pointer then retrieve
                // the target which can be a surrogate 
                // in which case needs to be retrieved
                //to make sure that surrogate metadata is loaded
                var pointer = (StateObjectPointer)GetObject(uniqueId, true);
                if (pointer != null)
                {
                    value = GetObject(pointer.TargetUniqueId);
                    var valueAsPage = value as IVirtualPage;
                    if (valueAsPage != null)
                    {
                        bool shouldCleanUpPage = false;
                        var parentUniqueID = ReferencesManager.GetPageParentUniqueID(valueAsPage);
                        var fullPathParentUniqueID = BuildFullPathUniqueID(parentUniqueID);

                        // We should cleanUpPage if and only if the List is not AllBranchesAttached or if List is in ElementsToRemove
                        shouldCleanUpPage =
                                fullPathParentUniqueID.IndexOf(rootUniqueID) != -1 ||
                                !AllBranchesAttached(parentUniqueID) ||
                                IsInElementsToRemove(parentUniqueID);

                        if (shouldCleanUpPage) 
                            pageManager.CleanUpPage(this, ReferencesManager, valueAsPage, rootUniqueID);
                    }
                }
            }
        }

        /// <summary>
        /// If the Page has been detached previously ( put it to tempCache ) , 
        /// we have to recover it from tempache, and promote it again to cache
        /// </summary>
        private void TryRecoverPage(string uniqueId, string rootUniqueID = "", HashSet<string> alreadyPromotedHashSet= null)
        {
            object value = null;
            // First check if the unique id corresponds to a surrogate
            //or a pointer to a surrogate 
            if (UniqueIDGenerator.IsPointer(uniqueId))
            {
                //if it a pointer then retrieve
                // the target which can be a surrogate 
                // in which case needs to be retrieved
                //to make sure that surrogate metadata is loaded
                var pointer = (StateObjectPointer)GetObject(uniqueId, true);
                if (pointer != null && UniqueIDGenerator.IsPage(pointer.TargetUniqueId))
                {
                    value = GetObject(pointer.TargetUniqueId, includeDeleted: true);
                    var valueAsPage = value as IVirtualPage;
                    if (valueAsPage != null)
                    {
                        _elementsToRemove.Remove(valueAsPage.UniqueID);

                        lock (justPromotedLock)
                        {
                            justPromoted[valueAsPage.UniqueID] = valueAsPage;
                        }
                        pageManager.RestorePage(this, this.ReferencesManager, valueAsPage, alreadyPromotedHashSet);

                    }
                }
            }
        }
		/// <summary>
		/// Rebind the old binding with the new <see cref= "StateObjectSurrogate" />
		/// </summary>
		/// <seealso cref="surrogate"/>
		/// <param name="oldsurrogate">surrogate to remove</param>
		/// <param name="surrogate">The new surrogate</param>
		/// <param name="pointer">pointer to remove</param>
		public void RebindSurrogateReference(StateObjectSurrogate oldsurrogate, StateObjectSurrogate surrogate, StateObjectPointer pointer)
		{
			var binding = GetObject(UniqueIDGenerator.GetRelativeUniqueID(oldsurrogate, BindingKey));
			if (binding != null)
			{
				GetAllChildrenKeys(binding.UniqueID)
					.Select(GetDataBinding).ToList()
					.ForEach(bind => Rebind(surrogate, bind));
			}

			surrogateManager.RemoveSurrogateReference(oldsurrogate, pointer);
		}

		private static void Rebind(StateObjectSurrogate surrogate, DataBinding bind)
		{
			IocContainerImplWithUnity.Current.Bind(bind.ObjProperty, bind.ObjReference, bind.DataSourceProperty,
				surrogate.Value);
		}

		private DataBinding GetDataBinding(string uniqueId)
		{
			var actualPointer = (StateObjectPointer)GetObject(uniqueId);
			var target = (StateObjectSurrogate)actualPointer.Target;
			var bind = (DataBinding)target.Value;
			return bind;
		}
		private void RemoveBindingObject(string uniqueId)
		{
			var pointer = GetObject(uniqueId) as StateObjectPointer;
			if (pointer != null && pointer.TargetUniqueId != null)
			{
				//This is executed after its parent surrogate has been removed,
				//so the GetObject invoked within the Target property won't return a value.
				var surrogate = GetObject(pointer.TargetUniqueId, includeDeleted: true) as StateObjectSurrogate;
				if (surrogate == null && pointer.Target is StateObjectPointer)
				{
					RemoveBindingObject(pointer.Target.UniqueID);
				}
				else
				{
					var dataBindingToDelete = surrogate.Value as DataBinding;
					// simple case, removing the only binding left
					if (dataBindingToDelete.PreviousBinding != null ||
						dataBindingToDelete.NextBinding != null)
					{
						// lets adjust the previous  pointer in order to update previous element
						// next pointer
						if (dataBindingToDelete.PreviousBinding != null)
						{
							var pPointer = (StateObjectPointer)GetObject(dataBindingToDelete.PreviousBinding);
							// checking if deleting first element (previous pointing to "first element pointer"
							if (pPointer.Target is StateObjectPointer)
							{
								pPointer.TargetUniqueId = dataBindingToDelete.NextBinding;
								if (pPointer.TargetUniqueId == null)
								{
									RemoveObject(pPointer.UniqueID, true);
								}
								else
								{
									StorageManager.SaveObject(pPointer);
								}
							}
							else
							{
								((DataBinding)((StateObjectSurrogate)pPointer.Target).Value).NextBinding = dataBindingToDelete.NextBinding;
							}
						}
						if (dataBindingToDelete.NextBinding != null)
						{
							var pPointer = GetObject(dataBindingToDelete.NextBinding);
							((DataBinding)((StateObjectSurrogate)((StateObjectPointer)pPointer).Target).Value).PreviousBinding =
								dataBindingToDelete.PreviousBinding;
						}
					}

					lock (surrogateManagerLock)
					{
						surrogateManager.RemoveEntry(reference: surrogate.Value, uniqueId: surrogate.UniqueID);
					}
				}
			}
		}


        public IStateObject GetObject(string uniqueId, bool includeDeleted = false, bool isOkForSurrogateToBeMissing = false, bool getObjectFromTempCache = false, bool isNew = false)
		{
			IStateObject obj;
			if (!AllBranchesAttached(uniqueId))
			{
			if (_tempcache.TryGetValue(uniqueId, out obj))
			{
				return obj;
			}
				else
				return null;
			}
            if (getObjectFromTempCache && _tempcache.TryGetValue(uniqueId, out obj))
            {
                return obj;
            }
			if (!includeDeleted && _elementsToRemove.Contains(uniqueId))
			{
				return null;
			}
			if (_cache.TryGetValue(uniqueId, out obj))
			{
				return obj;
			}
			try
			{
				if (isNew)
					return null;
				ViewManager.Instance.Events.Suspend();
				if (IsSurrogate(uniqueId))
				{

                    StateObjectSurrogate surrogate = surrogateManager.GetObject(uniqueId, isOkForSurrogateToBeMissing);
                    if (surrogate!=null)
					    AddInCache(uniqueId, surrogate, isDirty: false);
					return surrogate;
				}

				obj = StorageManager.GetObject(uniqueId);
				if (obj is IWebMapList)
				{
					(obj as IVirtualListSerializable).InitializeTheList(
								this,
								PageManager,
								ReferencesManager,
								surrogateManager,
								UniqueIDGenerator,
								ServerEventAggregator);
				}
			}
			finally
			{
				ViewManager.Instance.Events.Resume();
			}
			if (obj != null)
			{
				AddInCache(uniqueId, obj, isDirty: false);
				return obj;
			}
			return null;
		}

		/// <summary>
		/// Indicates whether the object identified by the given id is a surrogate or not.
		/// </summary>
		/// <param name="uniqueId">The id of the object to test for.</param>
		/// <returns><c>true</c> if the object is a surrogate.</returns>
		private static bool IsSurrogate(string uniqueId)
		{
			return uniqueId != null && uniqueId.Length >0 && uniqueId[0] == '!';
		}


		/// <summary>
		/// Returns all instances currently in the StateManager that might need to be sent to the client 
		/// during a state initialization message
		/// </summary>
		/// <returns></returns>
		internal IList<IStateObject> GetModelEntries()
		{
			var modelEntries = new List<IStateObject>();
			foreach (var value in _cache.Values)
			{
				if (ShouldGoToClient(value, null))
				{
					modelEntries.Add(value);
		}
			}
			return modelEntries;
		}

		public void SwitchOrPromoteObject(IStateObject newValue, string newValueRelativeUid, bool inAdoption = false)
		{
			var oldUniqueID = newValue.UniqueID;
			if (StateManager.AllBranchesAttached(newValueRelativeUid))
			{
				PromoteObject(newValue,newValueRelativeUid, inAdoption: inAdoption);
				ExecutePostResolveAction(newValue);
			}
			else
				SwitchUniqueIds(newValue,oldUniqueID, newValueRelativeUid);
		}
	
		/// <summary>
		/// Move entry at the same stateManager level. 
		/// Removes entry with the old id from stateManager and
		/// re-register it at the same stateManager cacheLevel with the newId
		/// NOTE: this method will update the UniqueID. 
		/// </summary>
		/// <param name="currentId"></param>
		/// <param name="newId"></param>
		internal void SwitchUniqueIds(IStateObject obj, string currentId, string newId)
		{
			IStateObject currentObject = obj;
			if (!AllBranchesAttached(currentId))
			{
				//This entry is in the _tempcache	
				//This entry is going to be moved. We just remove the slot from the temp stateManager 
				//because it is no longer going to be used.
				SwitchOrPromoteAllDependends(currentObject, newId, promote: false);
				RemoveEntryFromTempCache(currentId);
				AddInTempCache(newId, currentObject);	//Don't merge this change to the trunk. This was changed due an error that needs to be identified
				return;
			}
			else if (_cache.TryGetValue(currentId, out currentObject))
			{
				currentObject.UniqueID = newId;
				AddInCache(newId, currentObject, true);
				//We cannot do a call to RemoveObject because we are not removing the entries but
				//just renaming them. However the currentId must be removed
				bool justPromoted;
                RemoveObjectReference(currentId, out justPromoted);
				//Now we rename all <childsuffix>#currentId matching descendants
				SwitchAllDependendsInStateCache(currentId, newId);
				RegisterIdSwitch(obj,currentId, newId);
				return;
			}
			else
			{
				//This case is for elements that are not yet on the stateManager but they are on
				//the storage (e.g Session)
				//Switch will then be applied on persist
				RegisterIdSwitch(obj, currentId, newId);
			}
		}

        static HashSet<string> EMPTY = new HashSet<string>();

		/// <summary>
		/// Gets Keys of all dependent objects both in the state cache and the storage
		/// </summary>
		/// <returns></returns>
		public HashSet<string> GetAllChildrenKeys(string uniqueId, bool isJustPromoted = false)
		{
            //Get all children from Cache
			var childrenInCache = GetDependentItemsInCache(uniqueId);
			HashSet<string> result = null;
			if (childrenInCache.Count > 0)
				result = new HashSet<string>(StringComparer.Ordinal);
			foreach (var child in childrenInCache)
				result.Add(child.Key);
			if (!isJustPromoted)
			{
				var storageChildren = StorageManager.GetChildren(uniqueId);
				if (storageChildren.Count() > 0 && result == null)
					result = new HashSet<string>(StringComparer.Ordinal);
				foreach (var key in storageChildren)
					result.Add(key);
			}
			return result ?? EMPTY;
		}

		internal HashSet<string> GetAllChildrenKeysInTempCache(string uniqueId)
		{
 			//Get all children from tempcache
			HashSet<string> result = null;
			var childrenInTempCache = _tempcache.GetAllDependentKeys(uniqueId);
			if (childrenInTempCache.Count > 0)
				result = new HashSet<string>(StringComparer.Ordinal);
            foreach (var child in childrenInTempCache)
                result.Add(child);
			return result ?? EMPTY;
		}

		private void RegisterIdSwitch(IStateObject element, string currentId, string newId)
		{
            string switchedId = null;
            this._switchedIDsDictionary.TryGetValue(element, out switchedId);
            if(switchedId == null)
            {
                _switchedIDsDictionary.Add(element, currentId);                
            }
            // if we are switching to an id to be removed then, 
            // remove the id from  the elements to be removed
            UndoRemove(newId);
		}

		/// <summary>
		/// Gets the parent object for the given state object
		/// </summary>
		/// <param name="stateObject">State object to get parent for</param>
		/// <returns>The state object</returns>
		internal static string GetParentUniqueID(string uniqueID)
		{
			var index = uniqueID.IndexOf(UniqueIDGenerator.UniqueIdSeparator);
			if (index != -1)
				return uniqueID.Substring(index + 1);
			return null;
		}



		/// <summary>
		/// Adds the given object to the stateManager
		/// </summary>
		/// <param name="uniqueId">The id identifying the object to add</param>
		/// <param name="stateObject">The state object to add.</param>
		internal void AddInCache(string uniqueId, IStateObject stateObject, bool addToJustPromoted = false, bool isDirty = true)
		{
			Debug.Assert(uniqueId != null && AllBranchesAttached(stateObject));
			_cache.AddOrReplace(uniqueId, stateObject);
			Tracker.AttachModel(stateObject);
				if (addToJustPromoted)
				{
					lock (justPromotedLock)
					{
						justPromoted[uniqueId] = stateObject;
					}
				}
			}

		/// <summary>
		/// Adds an entry into _tempCache Cache
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <param name="stateObject"></param>
		internal void AddInTempCache(string uniqueID, IStateObject stateObject)
		{
				_tempcache.AddOrReplace(uniqueID, stateObject);
			}

		internal void RemoveEntryFromTempCache(string uniqueID)
		{
				_tempcache.Remove(uniqueID);
			}

		/// <summary>
		/// Checks if the given id matches a first level object
		/// </summary>
		/// <param name="uniqueId">The id identifying the object to test for</param>
		/// <returns><c>true</c> if the object is a first level one, otherwise <c>false</c></returns>
		private static bool IsRootLevelObject(string uniqueId)
		{
			return !uniqueId.Contains(UniqueIDGenerator.UniqueIdSeparator);
		}

		/// <summary>
		/// Indicates whether the given unique id identifies a binding object or not.
		/// </summary>
		/// <param name="uniqueId">The unique id to test for</param>
		/// <returns><c>true</c> if the given unique id matches a binding object.</returns>
		private static bool IsBindingObject(string uniqueId)
		{
			return uniqueId.StartsWith(BindingKey,StringComparison.Ordinal);
		}


		/// <summary>
		/// Creates a dependent unique id for the object identified by <c>uniqueId</c>
		/// </summary>
		/// <param name="keyToRemove"></param>
		/// <param name="uniqueId"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		private string ComputeNewDependantUniqueID(string keyToRemove, string uniqueId, string newParentUniqueId)
		{
			return uniqueId.Replace(keyToRemove, newParentUniqueId);
		}

		public IDictionary<IStateObject, List<DataBinding>> Bindings = new Dictionary<IStateObject, List<DataBinding>>();
		public bool flagInBind = false;

		public void Bind(IIocContainer container, IStateObject obj, string objProperty, object dataSource,
			string dataSourceProperty)
		{
			try
			{
				flagInBind = true;
			var uuidgen = UniqueIDGenerator;

			if (dataSource == null)
				throw new ArgumentException("Datasource argument cannot be null");

			if (obj == null)
				throw new ArgumentException("Binded object cannot be null");

			if (string.IsNullOrWhiteSpace(objProperty) || string.IsNullOrWhiteSpace(dataSourceProperty))
				throw new ArgumentException("Missing or invalid property names for binding");

			//The DataSource can be a surrogate.
			//When this happens then we need to create two pointers.
			//One that will be used from the surrogate to the Databinding
			if (SurrogatesDirectory.IsSurrogateRegistered(dataSource.GetType()))
			{
				var dsSurrogate = surrogateManager.GetSurrogateFor(dataSource, false);
				if (dsSurrogate == null)
					throw new InvalidOperationException("Invalid state a surrogate should exist for object at this point");

				var uidBindingForDsSurrogate = UniqueIDGenerator.GetRelativeUniqueID(dsSurrogate, BindingKey);

				//First lets find if there is already a binding 
				//We need a deterministic ID that we can use to find the databinding from the surrogate

				var pointerToFirst = GetObject(uidBindingForDsSurrogate) as StateObjectPointer;
				DataBinding currentLastBinding = null;
				StateObjectPointer currentLastBindingPointer = null;
				bool firstElement = false;
				if (pointerToFirst == null)
				{
					// the pointer to the first element was not found, lets create it and point it to first element
					pointerToFirst = container.Resolve<StateObjectPointer>();
					pointerToFirst.UniqueID = uidBindingForDsSurrogate;
					firstElement = true;
				}
				else
				{
					if (pointerToFirst.TargetUniqueId == null)
					{
						firstElement = true;
					}
					else
					{

						// lets find the last node
						currentLastBindingPointer = (StateObjectPointer)pointerToFirst.Target;
						bool doWhile;
						do
						{
							var surrogate = (StateObjectSurrogate)currentLastBindingPointer.Target;
							currentLastBinding = (DataBinding)surrogate.Value;
							doWhile = (currentLastBinding.NextBinding != null);
							if (doWhile)
								currentLastBindingPointer =
									(StateObjectPointer)GetObject(currentLastBinding.NextBinding);
						} while (doWhile);
					}
				}

				// lets create the binding and its surrogate object
				var newDatabinding = new DataBinding
				{
					ObjReference = obj,
					ObjProperty = objProperty,
					DataSourceProperty = dataSourceProperty,
					PreviousBinding = firstElement ? null : currentLastBindingPointer.UniqueID,
					DataSourceReference = dsSurrogate
				};
				var newDatabindingSurrogate = surrogateManager.GetSurrogateFor(newDatabinding, true);

				// lets create the new pointer to the binder
				var newBindingPointer = container.Resolve<StateObjectPointer>();
				newBindingPointer.UniqueID = uuidgen.GetRelativeUniqueID(pointerToFirst);
				//Now keep track that the DS surrogate has a pointer to the DataBinding surrogate (this is for reference counting)
				surrogateManager.AddSurrogateReference(newDatabindingSurrogate, newBindingPointer);

				if (firstElement)
				{
					pointerToFirst.TargetUniqueId = newBindingPointer.UniqueID;
					newDatabinding.PreviousBinding = pointerToFirst.UniqueID;
					AddNewObject(pointerToFirst);
				}
				else
				{
					currentLastBinding.NextBinding = newBindingPointer.UniqueID;
					newDatabinding.PreviousBinding = currentLastBindingPointer.UniqueID;
				}

				////Now we need also reference counting but for the datasource surrogate
				var pointerObjectToBinding = container.Resolve<StateObjectPointer>();
				pointerObjectToBinding.UniqueID = UniqueIDGenerator.GetRelativeUniqueID(obj, objProperty + BindingKey);
                surrogateManager.AddSurrogateReference(newDatabindingSurrogate, pointerObjectToBinding);



				var getter = SurrogatesDirectory.GetPropertyGetter(dataSource);
				if (getter == null)
					throw new InvalidOperationException("No getter was registered for dataSource " + dataSource.GetType());
				var value = getter(dataSource, newDatabinding.DataSourceProperty);
				var target = newDatabinding.ObjReference;
				var propInfo = target.GetType().Property(newDatabinding.ObjProperty);
				propInfo.SetValue(target, Convert.ChangeType(value, propInfo.PropertyType), null);
				int count = RegisterBinding(newDatabinding, dsSurrogate);
				if (count == 1)
				{
					this.AttachBindingBehaviourForSurrogate(dsSurrogate, dataSource);
				}
				return;
			}
			throw new NotImplementedException();
		}
			finally
			{
				flagInBind = false;
			}
		}


		internal HashSet<IStateObject> skip = null;

		internal bool IsSkip(IStateObject model)
		{
			if (skip == null)
				return false;
			else
				return skip.Contains(model);
		}

		private void AddSkip(IStateObject model)
		{
			if (skip == null)
			{
				skip = new HashSet<IStateObject>();
			}
			skip.Add(model);
		}

		internal bool ContainsSkip(IStateObject model)
		{
			if (skip == null)
				return false;
			return skip.Contains(model);
		}

		private void RemoveSkip(IStateObject model)
		{
			if (skip != null)
			{
				skip.Remove(model);
			}
		}

		//Currently there is a limitation that bindings added this method will not be seen	
		private void RestoreDataBindings(StateObjectSurrogate surrogate)
		{
			StateManager stateCache = this;
			string relativeUidForBinding = UniqueIDGenerator.GetRelativeUniqueID(surrogate, "^Binding");
			var pointerToFirstBinding = stateCache.GetObject(relativeUidForBinding) as StateObjectPointer;
			if (pointerToFirstBinding != null)
			{
				// 
				var pointerToDataBinding = pointerToFirstBinding.Target as StateObjectPointer;
				bool more = true;
				//
				do
				{
					var dataBindingSurrogate = pointerToDataBinding.Target as StateObjectSurrogate;
					more = dataBindingSurrogate != null;
					if (more)
					{
						var dataBinding = dataBindingSurrogate.Value as DataBinding;
						stateCache.RegisterBinding(dataBinding, surrogate);
						if (dataBinding.NextBinding != null)
						{
							pointerToDataBinding =
								stateCache.GetObject(dataBinding.NextBinding) as StateObjectPointer;
						}
						else
							more = false;
					}

				} while (more);
			}
		}

		internal void AttachBindingBehaviourForSurrogate(StateObjectSurrogate surrogate, object cachedValue)
		{
			if (!SurrogatesDirectory.SupportsBinding(cachedValue)) return;
			StateManager stateCache = this;
			var getter = SurrogatesDirectory.GetPropertyGetter(cachedValue);

			var setter = SurrogatesDirectory.GetPropertySetter(cachedValue);
			//var setter = SurrogatesDirectory.GetPropertySetter(cachedValue);
			Func<Action<bool>> temp = () =>
			{
				string relativeUidForBinding = UniqueIDGenerator.GetRelativeUniqueID(surrogate, "^Binding");
				bool firstTime = true;
				return (bool isAfter) =>
				{
					if (firstTime)
					{
						//Load bindings
						firstTime = false;
						RestoreDataBindings(surrogate);
					}
					var bindings = stateCache.GetRegisteredBindings(surrogate);
					if (!isAfter)
					{

						foreach (var binding in bindings)
						{
							TraceUtil.WriteLine("Binding " + binding.ObjProperty + " >> " + binding.ReferencedUniqueID);

							var target = binding.ObjReference;
							try
							{
								stateCache.AddSkip(target);
								var propInfo = target.GetType().Property(binding.ObjProperty);
								object val = propInfo.GetValue(target, null);
								setter(cachedValue, binding.DataSourceProperty, val);
								TraceUtil.WriteLine("Getting from element to DS [" + val + "]");
							}
							finally
							{
								stateCache.RemoveSkip(target);
							}
						}
					}
					else
					{
						foreach (var binding in bindings)
						{
							TraceUtil.WriteLine("Binding " + binding.ObjProperty + " << " + binding.ReferencedUniqueID);
							var target = binding.ObjReference;
							try
							{
								stateCache.AddSkip(target);
								var propInfo = target.GetType().Property(binding.ObjProperty);
								object val = getter(cachedValue, binding.DataSourceProperty);
								object valueToSet;
								if (DBNull.Value.Equals(val) && !propInfo.PropertyType.IsValueType)
								{
									valueToSet = null;
								}
								else
								{
									valueToSet = Convert.ChangeType(val, propInfo.PropertyType);
								}
								TraceUtil.WriteLine("Getting from DataSource [" + valueToSet + "]");
								propInfo.SetValue(target, valueToSet, null);
							}
							finally
							{
								stateCache.RemoveSkip(target);
							}
						}
					}
					//TriggerEvent
				};
			};
			SurrogatesDirectory.ApplyBindingHandlers(cachedValue, temp());
			//Is there a binding?
		}



		internal int RegisterBinding(DataBinding dataBinding, IStateObject ds)
		{
			Debug.Assert(ds != null);
			Debug.Assert(dataBinding != null);
			List<DataBinding> bindings = null;
			if (!Bindings.TryGetValue(ds, out bindings))
			{
				bindings = new List<DataBinding>();
				Bindings[ds] = bindings;
			}
			bindings.Add(dataBinding);
			return bindings.Count();
		}

		internal IEnumerable<DataBinding> GetRegisteredBindings(IStateObject ds)
		{

			List<DataBinding> bindings = null;
			if (!Bindings.TryGetValue(ds, out bindings))
			{
				bindings = new List<DataBinding>();
			}
			return bindings;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsChild(string parentId, string childId)
		{
			return childId.EndsWithExForChild(parentId);
		}
		/// <summary>
		/// Removes an entry from _tempCache.
		/// </summary>
		/// <param name="uniqueId"></param>
		internal void RemoveEntryFromCache(string uniqueId)
		{
				this._cache.Remove(uniqueId);
			}

		/// <summary>
		/// Cancel a possible removal from Session.
		/// </summary>
		/// <param name="uniqueId"></param>
		public void UndoRemove(string uniqueId)
		{
			lock(_elementsToRemoveLock)
			{
				this._elementsToRemove.Remove(uniqueId);
			}
		}

        /// <summary>
        /// Promotes the list item and its dependents that has been inserted into TempCache previously
        /// </summary>
        public void PromoteListItem(string uniqueId, IStateObject obj, bool deep = true, HashSet<string> alreadyPromotedHashSet = null)
		{
			lock (_elementsToRemoveLock)
			{
                if (alreadyPromotedHashSet.Contains(uniqueId))
                    return;
				_elementsToRemove.Remove(uniqueId);


                lock (justPromotedLock)
                {
                    justPromoted[uniqueId] = obj;
                }
                
                TryRecoverPage(uniqueId, alreadyPromotedHashSet: alreadyPromotedHashSet);
                alreadyPromotedHashSet.Add(uniqueId);
                if (deep)
                {
                    foreach (var childUniqueID in GetAllChildrenKeys(uniqueId))
				{
                        var child = GetObject(childUniqueID, includeDeleted: true);
                        if (child != null)
                            PromoteListItem(childUniqueID, child, true, alreadyPromotedHashSet);
                    }
				}
			}
		}

		internal void AddPostResolveAction(object newValue, Action postAction)
		{
			this._postActionAdded = true;
			this._postActions.Add(newValue, postAction);
			}

		internal void ExecutePostResolveAction(object newValue)
		{
			if (_postActionAdded && this._postActions.ContainsKey(newValue))
			{
				var action = this._postActions[newValue];
				this._postActions.Remove(newValue);
					action.Invoke();
				_postActionAdded = this._postActions.Count > 0;
			}
		}
		/// <summary>
		/// Verifies if the object is in the list of elements set to be removed from the session
		/// </summary>
		public bool IsInElementsToRemove(string objectRefID)
		{
			return _elementsToRemove.Contains(objectRefID);
		}

		public void SubscribeReference(IStateObject referenceObject, IStateObject referencedObject)
		{
			string propName = referencedObject.UniqueID;
			var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(referenceObject, propName);

			StateObjectPointerReference reference = null;
			reference = new StateObjectPointerReference();
			LazyBehaviours.AddDependent(referenceObject, UniqueIDGenerator.REFERENCEPrefix + propName);
			StateObjectPointer.AssignUniqueIdToPointer(referenceObject, relativeUid, reference);
            bool shouldAddReference = !(referencedObject is Page);
			LazyBehaviours.UpdateReferenceValue(this, reference, referenceObject, referencedObject, shouldAddReference);
		}

        #region IStateManager Implementation
        public bool IsStateObjectAllAttached(IStateObject obj)
        {
            return AllBranchesAttached(obj);
        }

        public bool IsStateObjectAttached(IStateObject obj)
        {
            return IsAttached(obj);
        }

        public void MarkAsDirty(IStateObject model, string property)
        {
            this.Tracker.MarkAsModified(model, property);
        }

        public void MarkAllAsDirty(IStateObject model)
        {
            this.Tracker.MarkAllAsModified(model);
        }

        public IStateObject GetObject(string uniqueId)
        {
            return this.GetObject(uniqueId,false);
        }

        /// <summary>
		///     It is assumed that this method is ONLY called for new objects
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public IStateObject AddNewObject(IStateObject obj)
        {
            if (!IsRootLevelObject(obj) && !AllBranchesAttached(obj))
			{
				AddInTempCache(obj.UniqueID, obj); //Don't merge this change to the trunk. This was changed due an error that needs to be identified
            }
            else
            {
				AddInCache(obj.UniqueID, obj, true);
			}
            UndoRemove(obj.UniqueID);
            return obj;
        }


		/// <summary>
		///     It is assumed that this method is ONLY called for new objects
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public IStateObject AddNewTemporaryObject(IStateObject obj, bool generateID = false)
		{
			if (generateID)
				obj.UniqueID = UniqueIDGenerator.GetUniqueIDForTemporaryObject();
			AddInTempCache(obj.UniqueID, obj); //Don't merge this change to the trunk. This was changed due an error that needs to be identified
			return obj;
		}

		/// <summary>
		///     It is assumed that this method is ONLY called for new objects
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public IStateObject AddNewAttachedObject(IStateObject obj)
		{
			AddInCache(obj.UniqueID, obj, true); //Don't merge this change to the trunk. This was changed due an error that needs to be identified
			UndoRemove(obj.UniqueID);
			return obj;
		}

        public object GetObjectRaw(string uniqueId)
        {
            return GetObjectRaw(uniqueId, isOKForSurrogateToBeMissing: false);
        }
        public object GetObjectRaw(string uniqueId, bool isOKForSurrogateToBeMissing)
		{
            var raw = StorageManager.GetRaw(uniqueId);
            if (raw == null)
            {
                if (isOKForSurrogateToBeMissing) return null;
                Debug.WriteLine("No data on GetObjectRaw for uniqueID " + uniqueId);
                throw new Exception("No data was found for the given uniqueId");
            }

			var context = surrogateManager.GetSurrogateContext(uniqueId);
			var obj = SurrogatesDirectory.RawToObject(raw, context);
            if (surrogateManager.AllDependenciesAreProcessed)
            {

                surrogateManager._surrogateDependencyManager.AddDependencies(obj, context.Dependencies);
            }
            return obj;
		}
        #endregion

		internal void Dispose()
		{
			this._cache.Dispose();
			this._cache =  null;
			this._tempcache.Dispose();
			this._tempcache = null;
			this._elementsToRemove.Clear();
			this._elementsToRemove = null;
			this._objectsInResolution.Clear();
			this._objectsInResolution = null;
			this._postActions.Clear();
			this._postActions = null;
			this._serverEventAggregator = null;
			this._switchedIDsDictionary.Clear();
			this._switchedIDsDictionary = null;
			this._uniqueIDGenerator = null;
			this.isServerSideOnly.Clear();
			this.isServerSideOnly = null;
			this.justPromoted.Clear();
			this.justPromoted = null;
            this._objectsToBeValidatedAfterDisposeHashSet.Clear();
            this._objectsToBeValidatedAfterDisposeHashSet = null;

			this.pageManager.Dispose();
			this.StorageManager.Dispose();
			this.surrogateManager.Dispose();
			this.Tracker.Dispose();
			this.adoptionInformation.Dispose();
			this._referencesManager.Dispose();
		}

        /// <summary>
        /// There may be some objects that wasn't removed in the first run because in that moment, 
        /// some reference is pointing the object
        /// So we need to re-validate those objects and try to remove it again
        /// </summary>
        internal void TryRemoveObjectThatInThePastHadValidReferences()
        {
            var somethingRemoved = TryRemoveObjectThatInThePastHadValidReferences_aux();
            if (somethingRemoved)
                TryRemoveObjectThatInThePastHadValidReferences();
        }

        private bool TryRemoveObjectThatInThePastHadValidReferences_aux()
        {
            bool result = false;
            ReferencesManager.RescuedValueUniqueIdHashSet.Clear();
            foreach (var id in _objectsToBeValidatedAfterDisposeHashSet)
            {
                if (!IsInElementsToRemove(id))
                {
                    if (RemoveObject(id, true, true))
                        result = true;
                }
            }
            return result;
        }

		public void AddNewJustPromotedObject(IStateObject obj)
		{
			 justPromoted.Add(obj.UniqueID, obj);
		}

		public bool IsNewObject(IStateObject obj)
		{
			return justPromoted.ContainsKey(obj.UniqueID);
		}


		public void AddDependent(IStateObject parent, string child)
		{
			LazyBehaviours.AddDependent(parent, child);
		}

		internal IList<KeyValuePair<string, IStateObject>> GetDependentItemsInCache(string uniqueID)
		{
			return _cache.GetAllDependentItems(uniqueID);
		}
	}
}
