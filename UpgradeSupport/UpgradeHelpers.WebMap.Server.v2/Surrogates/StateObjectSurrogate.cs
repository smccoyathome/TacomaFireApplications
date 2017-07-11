using System;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
    internal class StateObjectSurrogate : IStateObjectSurrogate, IInternalData
    {
        public StateObjectSurrogate() { }

        internal List<LazyStateObjectReference> objectRefs = new List<LazyStateObjectReference>();

        private object _value;
        public object Value
        {
            get
            {
                if (_value == null )
                {
                    var uid = UniqueIDGenerator.GetRelativeUniqueID(this, VALUE_PREFIX);
                    if (Parent.AllDependenciesAreProcessed)
                    {
                        this.ShouldSerializeValue = false;
                    }
                    else
                    {
                        this.ShouldSerializeValue = true;
                    }
                    _value = Parent.GetObjectRaw(uid);

				}
                return _value;
            }
            set { _value = value; }
        }
        public string UniqueID { get; set; }
        public Type SurrogateType { get; set; }


        public void AddReference(LazyStateObjectReference newValue)
        {
            objectRefs.Add(newValue);
        }

        bool queueOperations = false;
        List<string> queuedRemoves;
        public const string VALUE_PREFIX = "!Value";
        public bool ShouldSerializeValue = true;
        internal void RemoveReference(string uniqueId)
        {
            if (queueOperations)
            {
                if (queuedRemoves == null) queuedRemoves = new List<string>();
                queuedRemoves.Add(uniqueId);
            }
            else
            {
                var result = new List<LazyStateObjectReference>(objectRefs.Count);
                foreach (var lazyStateObjectReference in objectRefs)
                {
                    if (lazyStateObjectReference.UniqueID.Equals(uniqueId))
                        result.Add(lazyStateObjectReference);
                }
                lock (objectRefs)
                {
                    foreach (var lazyStateObjectReference in result)
                    {
                        objectRefs.Remove(lazyStateObjectReference);
                    }
                }
            }
        }


        

        /// <summary>
        /// Returns true if object exists in the storage.
        /// It also turns on flags to queue operations if needed
        /// </summary>
        bool ValidateIfObjectExists(StateManager stateManager, string uniqueId)
        {
            // GetObject can trigger an RemoveReference 
            try {
                queueOperations = true;
                return stateManager.GetObject(uniqueId,false,true) == null;
            }
            finally {
                queueOperations = false;
            }
        }
		/// <summary>
		/// Verifies if the references are valid (not set to be deleted and have a value)
		/// </summary>
		/// <returns></returns>
        public bool ShouldBeSerialized()
        {

            var objectsToBeRemoved = new List<LazyStateObjectReference>(objectRefs.Count);
            var stateManager = StateManager.Current;
            foreach (var lazyStateObjectRefaerence in objectRefs.ToArray())
            {
                var objectRef = lazyStateObjectRefaerence;
                var objectRefID = objectRef.UniqueID;


                if (StateManager.AllBranchesAttached(objectRefID))
                {
                    //Verifies if the object reference is set to be removed, if so is deleted as a reference
                    //If the reference exist but has no value it is removed
                    try
                    {
                        if (stateManager.IsInElementsToRemove(objectRefID) || ValidateIfObjectExists(stateManager, objectRefID) || isSelfContainedReference(objectRefID))
                        {
                            objectsToBeRemoved.Add(objectRef);
                        }
                    }
                    catch (Exception ex)
                    {
                        objectsToBeRemoved.Add(objectRef);
                        System.Diagnostics.Debug.Write("WepMap Issue: Remove corrupt object. TODO " + ex.Message);
                        System.Diagnostics.Debug.Write(ex.StackTrace);
                    }
                }
                else
                {
                    objectsToBeRemoved.Add(objectRef);
                }
            }
            ProcessQueuedOperations(stateManager,objectsToBeRemoved);
            foreach (var lazyStateObjectReference in objectsToBeRemoved)
            {
                objectRefs.Remove(lazyStateObjectReference);
            }
			return objectRefs.Count > 0;
		}

        private void ProcessQueuedOperations(IStateManager stateManager,IList<LazyStateObjectReference> objectsToBeRemoved)
        {
            if (queuedRemoves != null)
                foreach (var queuedRemove in queuedRemoves)
                {
                    objectsToBeRemoved.Add(new LazyStateObjectReference(null,queuedRemove));
                }
        }

		private bool isSelfContainedReference(string uniqueId)
		{
			return uniqueId.IndexOf(this.UniqueID, StringComparison.Ordinal) != -1;
		}

        public IStateManager Parent { get; set; }

		public List<string> Dependents
		{
			get;
			set;
		}
	}
}