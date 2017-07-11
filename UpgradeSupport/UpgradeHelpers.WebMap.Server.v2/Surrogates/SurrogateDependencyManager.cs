using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	internal class SurrogateDependencyManager : ISurrogateDependencyManager, ISurrogateDependenciesContext
    {
		private StateManager _stateManager;
		internal Dictionary<object, List<object>> Dependencies;

		public SurrogateDependencyManager(StateManager stateManager)
		{
			this._stateManager = stateManager;
			this.Dependencies = new Dictionary<object, List<object>>(ComparerByReference.CommonInstance);
		}
		/// <summary>
		/// Gets the loaded dependencies for the object.
		/// </summary>
		public List<object> GetDependencies(object obj)
		{
			List<object> result = null;
			Dependencies.TryGetValue(obj, out result);
			return result;
		}

		public void WriteDependencies(object obj, Action<string> callback)
		{
			List<object> result = null;
			if (Dependencies.TryGetValue(obj, out result))
			{
				foreach (var dependency in result)
				{
					var events = dependency as ISurrogateEventsInfo;
					if (events != null)
					{
						callback(events.EventId + UpgradeHelpers.WebMap.Server.Surrogates.SurrogateContext.EventsSeparator + events.EventName);
					}
					else if(dependency != null)
						callback((dependency as IStateObject).UniqueID);
					else
						callback(String.Empty);
				}
			}

		}

        public class DependencyParentInfo
        {
            public StateObjectSurrogate ParentSurrogate;
            public object ParentValue;
            public DependencyResolutionInfo child;
        }


        public class DependencyResolutionInfo
        {
            public object value;
            public object ResolvedValue;
            public StateObjectSurrogate ResolvedSurrogate;
            public bool IsStateObject;
            public bool canBeAnOrphan;
            public bool isEventsInfo;
        }


        public class DependenciesQueue : Dictionary<object,DependencyResolutionInfo>
        {
			Queue<object> justAdded = new Queue<object>();
            List<DependencyParentInfo> pendingParents;
            public DependenciesQueue() : base(ComparerByReference.CommonInstance) { }

            public new void Add(object dependencyValue, DependencyResolutionInfo dependencyResolutionInfo) {
                base.Add(dependencyValue, dependencyResolutionInfo);
                dependencyResolutionInfo.value = dependencyValue;
                justAdded.Enqueue(dependencyValue);
            }

            public int PendingCount { get { return justAdded.Count; } }
            public DependencyResolutionInfo Pop()
            {
				return this[justAdded.Dequeue()];
            }

            internal void RegisterParentDependency(DependencyParentInfo dependencyParentInfo)
            {
                if (pendingParents == null) pendingParents = new List<DependencyParentInfo>();
                pendingParents.Add(dependencyParentInfo);
            }

            static IList<DependencyParentInfo> NOPARENTS = new DependencyParentInfo[0];
            internal IList<DependencyParentInfo> PendingParents
            {
                get
                {
                    if (pendingParents == null)
                        return NOPARENTS;
                    return pendingParents;
                }
            }
        }

        public void ProcessDependencies()
        {

            //Lets get the current surrogates
            var surrogatesDictionary = _stateManager.surrogateManager.GetSurrogates();
            if (surrogatesDictionary.Count == 0) return;
            var queue = new DependenciesQueue();
            //First step: Populate the queue with the surrogates list
            foreach (var surrKeyValuePair in surrogatesDictionary)
            {
                var objectValue = surrKeyValuePair.Key;
                queue.Add(objectValue, new DependencyResolutionInfo() { ResolvedSurrogate = surrKeyValuePair.Value, ResolvedValue = surrKeyValuePair.Value });
            }
            //Second step: Expand this queue by calculating dependencies
            ExpandDependencies(queue);
            foreach (var resolutionInfo in queue.Values)
            {
                GetResolvedValueEx(resolutionInfo);
            }
            foreach(var pendingParent in queue.PendingParents)
            {
                ProcessPendingParent(pendingParent);
            }
            _stateManager.surrogateManager.AllDependenciesAreProcessed = true;
        }

        private void ProcessPendingParent(DependencyParentInfo pendingParent)
        {
            var dependency = pendingParent.child;
            if (dependency == null)
            {
                AddDependency(parent: pendingParent.ParentValue, value: null);

            }
            else
            {
                var surrogateManager = _stateManager.surrogateManager;
                var parentAsIStateObject = pendingParent.ParentValue as IStateObject;
                if (parentAsIStateObject != null)
                {   //Parent is an STATEOBJECT
                    if (pendingParent.child.canBeAnOrphan)
                        _stateManager.AdoptionInformation.RegisterPossibleOrphan(parentAsIStateObject, (IStateObject)dependency.ResolvedValue);
                    surrogateManager.AddSurrogateReference(dependency.ResolvedSurrogate, parentAsIStateObject);
                    //StateObject do not have dependencies
                }
                else
                {   //Parent is a SURROGATE
                    var parentAsSurrogate = pendingParent.ParentSurrogate ?? surrogateManager.GetSurrogateFor(pendingParent.ParentValue, generateIfNotFound: true);
                    if (parentAsSurrogate == null) throw new ArgumentException("A surrogate could not be gotten for value of type " + pendingParent.ParentValue.GetType().FullName);
                    if (dependency.IsStateObject)
                    {
                        if (dependency.canBeAnOrphan)
                            _stateManager.AdoptionInformation.RegisterPossibleOrphan(parent: parentAsSurrogate, obj: (IStateObject)dependency.ResolvedValue);
                    }
                    else
                    {
                        if (!dependency.isEventsInfo)
                            surrogateManager.AddSurrogateReference(dependency.ResolvedSurrogate, parentAsSurrogate);
                    }
                    AddDependency(parent: pendingParent.ParentValue, value: dependency.ResolvedValue);
                }
            }

        }

        /// <summary>
        /// Iterates on the dependencies queue expanding all calculated dependendies inside
        /// this same queue
        /// </summary>
        /// <param name="queue"></param>
        private void ExpandDependencies(DependenciesQueue queue)
        {
            //Process all generated dependencies.
            while (queue.PendingCount != 0)
            {
                var resolutionInfo = queue.Pop();
                var objectValue = resolutionInfo.value;
                var dependencyValues = SurrogatesDirectory.GetObjectDependencies(objectValue, _stateManager, _stateManager.surrogateManager, this);
                foreach (var dependencyValue in dependencyValues)
                {
                    if (dependencyValue != null)
                    {
                        DependencyResolutionInfo resolutionInfoForDependency;
                        if (!queue.TryGetValue(dependencyValue, out resolutionInfoForDependency))
                        {
                            queue.Add(dependencyValue, resolutionInfoForDependency = new DependencyResolutionInfo());
                        }
                        queue.RegisterParentDependency(new DependencyParentInfo() { child = resolutionInfoForDependency, ParentValue = objectValue, ParentSurrogate = resolutionInfo.ResolvedSurrogate });
                    }
                    else
                    {
                        queue.RegisterParentDependency(new DependencyParentInfo() { child = null, ParentValue = objectValue, ParentSurrogate = resolutionInfo.ResolvedSurrogate });
                    }
                }
            }
        }



        private void GetResolvedValueEx(DependencyResolutionInfo dependency)
        {
            var surrogateManager = _stateManager.surrogateManager;
            var value = dependency.value;
            var istateObjectValue = dependency.value as IStateObject;
             if (istateObjectValue != null)
            {
                //The value is an state object
                if (_stateManager.IsInElementsToRemove(istateObjectValue.UniqueID))
                {
                    //If the object is present in the elements it is detached from so its UniqueID
                    //is changed to a temporal one. 
                    //The current in the session must be removed
                    _stateManager.DettachObject(istateObjectValue);
                }
                dependency.canBeAnOrphan = !StateManager.AllBranchesAttached(istateObjectValue);
                dependency.ResolvedValue = istateObjectValue;
                dependency.IsStateObject = true;
            }
            else if (value is ISurrogateEventsInfo)
            {
                dependency.ResolvedValue = value;
                dependency.isEventsInfo = true;
            }
             else 
            {
                //if (surrogateManager.IsSurrogateRegistered(value.GetType())) Commented for performance
                StateObjectSurrogate currentSurrogate = null;
                //Get the surrogate instance from the surrogates that are already loaded in memory or create one
                dependency.ResolvedValue = currentSurrogate = dependency.ResolvedSurrogate = surrogateManager.GetSurrogateFor(value, generateIfNotFound: true);

                if (currentSurrogate == null) throw new ArgumentException("A surrogate could not be gotten for value of type " + value.GetType().FullName);

                if (_stateManager.IsInElementsToRemove(currentSurrogate.UniqueID))
                {
                    //If the object is present in the elements it is restored,
                    //since it is a top element no adoption needs to be performed
                    _stateManager.UndoRemove(currentSurrogate.UniqueID);
                    //We must unremove the Value surrogate
                    var valueUniqueID = UniqueIDGenerator.GetRelativeUniqueID(currentSurrogate,StateObjectSurrogate.VALUE_PREFIX);
                    _stateManager.UndoRemove(valueUniqueID);
                }
                else
                { 
                    //OK
                }

            }

        }







        private object GetResolvedValue(object value)
        {
			if (value == null) return value;
            if (_stateManager.surrogateManager.IsSurrogateRegistered(value.GetType()))
            {
                StateObjectSurrogate currentSurrogate = null;
                if (_stateManager.surrogateManager.GetSurrogates().TryGetValue(value, out currentSurrogate))
                {
                    return currentSurrogate;
                }
                else
                {
                    return null;
                }
            }
            else
                return value;
        }


        /// <summary>
        /// This method is used to keep the old list of dependencies
        /// </summary>
        public void AddDependencies(object parent, List<object> dependencies)
        {
            List<object> currentDependencies;
            if (!Dependencies.TryGetValue(parent, out currentDependencies))
            {
                this.Dependencies.Add(parent, currentDependencies = new List<object>());
                foreach (var d in dependencies)
                {
                    currentDependencies.Add(GetResolvedValue(d));
                }

            }
            else
            {
                //There are already depencies so leave the dependecies list that is there
            }
        }
		/// <summary>
		/// Adds or creates a dependency list associated to the parent value
		/// </summary>
		private void AddDependency(object parent, object value)
		{
			if (Dependencies.ContainsKey(parent))
				this.Dependencies[parent].Add(value);
			else
				this.Dependencies.Add(parent, new List<object>() { value });
		}
		public int DependencyCount(object value)
		{
			return Dependencies.ContainsKey(value) ? Dependencies[value].Count : 0;
		}

		/// <summary>
		/// Saves an event handler to the storage
		/// </summary>
		/// <param name="fieldName">The name of the field that contains the event handler</param>
		/// <param name="eventName">The mane of the event</param>
		/// <param name="value">The instance of the object</param>
		public ISurrogateEventsInfo ProcessEventDelegate<T>(string fieldName, string eventName, object value)
		{
			var events = (EventAggregator)ViewManager.Instance.Events;
			var surrogateValue = _stateManager.surrogateManager.GetSurrogateFor(value, generateIfNotFound: false);
			ISurrogateEventsInfo result = null;

			//We need to get the event handler.
			var eventDelegate = (Delegate)typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(value);

			if (eventDelegate != null)
			{
				var eventId = String.Empty;
				events.Subscribe(eventName, surrogateValue, eventDelegate, out eventId);
				result = new SurrogateEventsInfo()
				{
					EventId = eventId,
					EventName = eventName
				};
			}

			return result;
		}

		internal void Dispose()
		{
			this._stateManager = null;
			this.Dependencies = null;
		}
	}

	public class SurrogateEventsInfo : ISurrogateEventsInfo
	{
		public string EventId { get; set; }
		public string EventName { get; set; }
	}
}
