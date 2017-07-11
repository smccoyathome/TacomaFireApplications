using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
    /// <summary>
    /// This class is used to store a cache of IStateObjects and keep track of the children of the IStateObjects added
    /// to have a very inexpesive getChildren method.
    /// There are public methods for the common operations applied on a Dictionary, that basically just encapsulate the use of the
    /// intenal dictionary of IStateObjects.
    /// </summary>
    [Serializable]
    class HierarchyTracker<T> : System.Runtime.Serialization.ISerializable  
    {
        #region Public Members
        public Dictionary<String, T>.ValueCollection Values
        {
            get { 
                return cache.Values; 
            }
        }

        public Dictionary<String, T>.KeyCollection Keys
        {
            get { return cache.Keys; }
        }

        public Dictionary<string, T> KeyValuePairs
        {
            get { return cache; }
        }

        public int Count
        {
            get { return cache.Count; }
        }

		public bool IsObjectIndexingAvailable
		{
			get { return useObjectIndexing; }
		}
        #endregion


        #region Private Members
        private Dictionary<string, T> cache = new Dictionary<string, T>(StringComparer.Ordinal);

        private Dictionary<string, HashSet<string>> childrenTracker = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal);

		private Dictionary<T, string> keyTracker = null;

		private bool useObjectIndexing = false;

        private object _cacheLock = new object();

        #endregion

        private IStateManager stateManager;
        #region Public Methods
		public HierarchyTracker(IStateManager stateManager, bool addObjectIndexing = false)
		{
			this.stateManager = stateManager;
			if (addObjectIndexing)
			{
				keyTracker = new Dictionary<T, string>(ComparerByReferenceGeneric<T>.CommonInstance);
				useObjectIndexing = true;
			}
		}
		public IStateManager StateManager { set { this.stateManager = value; } get { return this.stateManager;  } }

		internal virtual string GetParentKey(string key)
		{
			return stateManager.GetParentKeyEx(key);
		}

        public void AddOrReplace(string key, T value)
        {
            bool passedByKeyTracker = false;
            string oldParent = null;
            string oldKey = null;
			// Object Indexing
			if (useObjectIndexing)
 			{
				
				T oldKeyTrackerEntry = default(T);
				// First lets say we have two object X and Y 
				// and two uniqueuds UID1 and UID2
				//
				// The first condition is caused when I will set the id for something that was previously registered  
				// The object is already registered by reference with another id
				// CURRENT STATE IS:
				// cache
				// | key | value |
				// | UID1|  X    |
				//
				// keytracker
				// | key | value |
				// | X   |  UID1 |
				// but parameter key is UID2 and parameter value is X
				// if i dont remove from cache I will end up with
				// WITHOUT THIS CHECK THE RESULT STATE WILL BE:
				// cache
				// | key | value |
				// | UID1|  X    |
				// | UID2|  X    |
				//
				// keytracker
				// | key | value |
				// | X   |  UID2 |
				//
				// THEREFORE WE MUST REMOVE FROM CACHE FIRST THE OLD ENTRY
                
                lock (_cacheLock)
                {
                    if (keyTracker.TryGetValue(value, out oldKey))
                    {
                        passedByKeyTracker = true;
                        if (cache.TryGetValue(oldKey, out oldKeyTrackerEntry))
                        {
                            cache.Remove(oldKey);
                            if (oldKeyTrackerEntry != null)
                            {
                                keyTracker.Remove(oldKeyTrackerEntry);
                            }
                        }
                        // CURRENT STATE IS:
                        // cache
                        // | key | value |
                        // | UID1|  X    |
                        // | UID2|  Y    |
                        //
                        // keytracker
                        // | key | value |
                        // | X   |  UID1 |
                        // | Y   |  UID1 |
                        ///but parameter key is UID1 and parameter value is Y
                        /// if we done remove based on key also we get to this
                        // cache
                        // | key | value |
                        // | UID1|  Y    |
                        //
                        // keytracker
                        // | key | value |
                        // | X   |  UID1 |
                        // | Y   |  UID1 |
                        if (cache.TryGetValue(key, out oldKeyTrackerEntry) && oldKeyTrackerEntry != null)
                        {
                            keyTracker.Remove(oldKeyTrackerEntry);
                        }

                    }
                    // CURRENT STATE IS:
                    // cache
                    // | key | value |
                    // | UID1|  X    |
                    //
                    // keytracker
                    // | key | value |
                    // | X   |  UID1 |
                    //
                    // but parameter key is UID1 and parameter value is Y
                    // WITHOUT THIS CHECK THE RESULT STATE WILL BE:
                    // cache
                    // | key | value |
                    // | UID1|  y    |
                    //
                    // keytracker
                    // | key | value |
                    // | X   |  UID1 |
                    // | y   |  UID1 |
                    //
                    // THEREFORE WE MUST REMOVE FROM CACHE FIRST THE OLD ENTRY
                    else if (cache.TryGetValue(key, out oldKeyTrackerEntry)) //To avoid two values with the same key
                    {
                        keyTracker.Remove(oldKeyTrackerEntry);
                    }
                }
                
                if (passedByKeyTracker)
                {
                    oldParent = GetParentKey(oldKey);
                }
              
            }
            string parent = GetParentKey(key);
            lock (_cacheLock)
            {
                if (passedByKeyTracker)
                {
                    HashSet<string> oldParentChildrenTracker;
                    if (oldParent != null && childrenTracker.TryGetValue(oldParent, out oldParentChildrenTracker))
                        oldParentChildrenTracker.Remove(oldKey);
                }
                if (useObjectIndexing)
                {
                    keyTracker[value] = key;
                }
                cache[key] = value;
                if (parent != null)
                {
                    HashSet<string> parentSet;
                    if (!childrenTracker.TryGetValue(parent, out parentSet))
                    {
                        parentSet = new HashSet<string>(StringComparer.Ordinal);
                        childrenTracker.Add(parent, parentSet);
                    }
                    parentSet.Add(key);
                }
            }
        }

		/// <summary>
		/// Removes an element from the Tracker
		/// </summary>
		/// <param name="key"></param>
		/// <param name="isRoot">It means that the element being removed is the Root of Children being removed.</param>
		public virtual void Remove(string key, bool removeChildren = false)
		{
			lock (_cacheLock)
			{
				// Object Indexing
				if (useObjectIndexing)
					keyTracker.Remove(cache[key]);
				// Lets remove the Key from the cache and
				//from the childrenTracker as well in case it has children.
				cache.Remove(key);
				if(removeChildren)
					childrenTracker.Remove(key);
			}
			// This check is required in case we know the parent is not being removed
			//otherwise it doesnt make any sense to go and remove the element from the parent 
			//and after that remove the parent.(To much work for nothing.)
 			string parent = GetParentKey(key);
			HashSet<string> parentChildren = null;
			lock (_cacheLock)
			{
				if (parent != null && childrenTracker.TryGetValue(parent, out parentChildren))
				{
					parentChildren.Remove(key);
					if (!removeChildren && parentChildren.Count == 0)
						childrenTracker.Remove(parent);
				}
			}
		}

        public T Get(string key)
        {
            lock (_cacheLock)
            {
                return cache[key];
            }
        }

        public bool TryGetValue(string key, out T value)
        {
            lock (_cacheLock)
            {
                return cache.TryGetValue(key, out value);
            }
        }

        /// <summary>
        /// Gets the elements from the cache that belongs to the object identified by the given key.
        /// In this improved version the method only iterates over the specific hierarchy of the object identified by the "key" parameter, and
        /// ignores the rest of the elements in the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IList<KeyValuePair<string, T>> GetAllDependentItems(string key)
        {
            return GetAllDependentItemsIterative(key);
        }

		private static IList<string> EMPTYDEPENDENTS2 = new List<string>();
		public IList<string> GetAllDependentItems2(IStateObject elementObj, List<string> result = null)
		{
			var dependentsContainer = elementObj as IDependentsContainer;
			if (dependentsContainer != null)
			{
				var count = dependentsContainer.Dependents != null ? dependentsContainer.Dependents.Count : 0;
				if (count > 0)
				{
					if (result == null)
						result = new List<string>(count);
					else
						result.Capacity += count;

					for (int i = 0; i < count; i++)
					{
						var childKey = dependentsContainer.Dependents[i];
						var childUniqueID = childKey + UniqueIDGenerator.UniqueIdSeparatorStr + elementObj.UniqueID;
						T childValue;
						if (cache.TryGetValue(childUniqueID, out childValue))
						{
							result.Add(childUniqueID);
							GetAllDependentItems2((IStateObject)childValue, result);
						}
						else
						{
							var c = "";
						}
						
					}
				}
			}
			return result ?? EMPTYDEPENDENTS2;
		}

		public IList<string> GetAllDependentItems2(string uniqueID, List<string> result = null)
		{
			T element;
			if(cache.TryGetValue(uniqueID, out element))
			{
				return GetAllDependentItems2((IStateObject)element);
			}
			return result ?? EMPTYDEPENDENTS2;
		}

		
        public HashSet<string> GetAllDependentKeys(string key)
        {
			var result = new HashSet<string>();
            return GetAllDependentKeysIterative(key, result);
        }

		/// <summary>
		/// Gets the key of the specified object. This function requires the HierarchyTracker was constructed with support for object indexing.
		/// </summary>
		/// <param name="value">The reference to the IStateObject</param>
		/// <returns>If the IStateObject reference parameter isn't found, the returned string is null</returns>
		public string GetIndexedKeyByValue(T value)
		{
			if (useObjectIndexing)
			{
				string uniqueId = null;
				keyTracker.TryGetValue(value, out uniqueId);
				return uniqueId;
			}
			else
			{
				throw new NotSupportedException("This instance of the HierarchyTracker doesn't use the Object Indexer functionality");
			}
		}
        #endregion


        #region Private Methods
        private static IList<KeyValuePair<string, T>> EMPTYDEPENDENTS = new List<KeyValuePair<string, T>>();
        private IList<KeyValuePair<string, T>> GetAllDependentItemsIterative(string key, IList<KeyValuePair<string, T>> result = null)
        {
            HashSet<string> directChildren;
            bool found = childrenTracker.TryGetValue(key, out directChildren);
            if (found)
            {
				if (result != null)
					((List<KeyValuePair<string, T>>)result).Capacity += directChildren.Count;
                foreach (string childKey in directChildren)
                {
                    T objectToRemove;
                    cache.TryGetValue(childKey, out objectToRemove);
                    if (objectToRemove != null)
                    {
						if (result == null)
							result = new List<KeyValuePair<string, T>>(directChildren.Count);
                        result.Add(new KeyValuePair<string, T>(childKey, cache[childKey]));
                        GetAllDependentItemsIterative(childKey, result);
                    }
                }
            }
            return result ?? EMPTYDEPENDENTS;;
        }

		private HashSet<string> GetAllDependentKeysIterative(string key, HashSet<string> result)
        {
            HashSet<string> directChildren;
            bool found = childrenTracker.TryGetValue(key, out directChildren);
            if (found)
            {
				foreach (string childKey in directChildren)
                {
                    bool newElement = result.Add(childKey);
					//The element already exists, cycle detected.
					if (newElement)
						GetAllDependentKeysIterative(childKey, result);
                }
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetParent(string key)
        {
            var indexOfSeparator = key.IndexOf(UniqueIDGenerator.UniqueIdSeparator);
			if(indexOfSeparator != -1)
				return key.Substring(indexOfSeparator + 1);
            else
				return null;
        }
        #endregion

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            System.Diagnostics.Debug.WriteLine("Hierarchy tracker contains " + Keys.Count + " keys ");
        }

		internal void Dispose()
		{
			cache.Clear();
			childrenTracker.Clear();
			if (keyTracker != null)
			{
				keyTracker.Clear();
				keyTracker = null;
			}
			cache = null;
			childrenTracker = null;
			stateManager = null;
		}
	}

	[Serializable]
	class HierarchyTracker2<T> : System.Runtime.Serialization.ISerializable
	{
		#region Public Members
		public Dictionary<String, T>.ValueCollection Values
		{
			get
			{
				return cache.Values;
			}
		}

		public Dictionary<String, T>.KeyCollection Keys
		{
			get { return cache.Keys; }
		}

		public Dictionary<string, T> KeyValuePairs
		{
			get { return cache; }
		}

		public int Count
		{
			get { return cache.Count; }
		}

		#endregion

		#region Private Members
		private Dictionary<string, T> cache = new Dictionary<string, T>(StringComparer.Ordinal);
		
		private object _cacheLock = new object();

		#endregion

		#region Public Methods
		public HierarchyTracker2()
		{
		}
		
		public void AddOrReplace(string key, T value)
		{
			lock (_cacheLock)
			{
				cache[key] = value;
			}
		}

		/// <summary>
		/// Removes an element from the Tracker
		/// </summary>
		/// <param name="key"></param>
		/// <param name="isRoot">It means that the element being removed is the Root of Children being removed.</param>
		public virtual void Remove(string key, bool removeChildren = false)
		{
			lock (_cacheLock)
			{
				cache.Remove(key);
			}
		}

		public T Get(string key)
		{
			lock (_cacheLock)
			{
				return cache[key];
			}
		}

		public bool TryGetValue(string key, out T value)
		{
			lock (_cacheLock)
			{
				return cache.TryGetValue(key, out value);
			}
		}

		private static IList<KeyValuePair<string, IStateObject>> EMPTYDEPENDENTS2 = new List<KeyValuePair<string, IStateObject>>();
		public IList<KeyValuePair<string, IStateObject>> GetAllDependentItems(IStateObject elementObj, List<KeyValuePair<string, IStateObject>> result = null)
		{
			var dependentsContainer = elementObj as IDependentsContainer;
			if (dependentsContainer != null)
			{
				var count = dependentsContainer.Dependents != null ? dependentsContainer.Dependents.Count : 0;
				if (count > 0)
				{
					if (result == null)
						result = new List<KeyValuePair<string, IStateObject>>(50);
					
					var uniqueIDPart = UniqueIDGenerator.UniqueIdSeparatorStr + elementObj.UniqueID;
					for (int i = 0; i < count; i++)
					{
						var childKey = dependentsContainer.Dependents[i];
						var childUniqueID = childKey + uniqueIDPart;
						T childValue;
						if (cache.TryGetValue(childUniqueID, out childValue))
						{
							result.Add(new KeyValuePair<string, IStateObject>(childUniqueID, (IStateObject)childValue));
							GetAllDependentItems((IStateObject)childValue, result);
						}
					}
				}
			}
			return result ?? EMPTYDEPENDENTS2;
		}

		public IList<KeyValuePair<string, IStateObject>> GetAllDependentItems(string uniqueID, IList<KeyValuePair<string, IStateObject>> result = null)
		{
			T element;
			if (cache.TryGetValue(uniqueID, out element))
			{
				return GetAllDependentItems((IStateObject)element);
			}
			return result ?? EMPTYDEPENDENTS2;
		}

		private static IList<string> EMPTYDEPENDENKEYS = new List<string>();
		public IList<string> GetAllDependentKeys(string uniqueID, IList<string> result = null)
		{
			T element;
			if (cache.TryGetValue(uniqueID, out element))
			{
				return GetAllDependentKeys((IStateObject)element);
			}
			return result ?? EMPTYDEPENDENKEYS;
		}
		public IList<string> GetAllDependentKeys(IStateObject elementObj, List<string> result = null)
		{
			var dependentsContainer = elementObj as IDependentsContainer;
			if (dependentsContainer != null)
			{
				var dependents = dependentsContainer.Dependents;
				var count = dependents != null ? dependents.Count : 0;
				if (count > 0)
				{
					if (result == null)
						result = new List<string>(50);

					var uniqueIDPart = UniqueIDGenerator.UniqueIdSeparatorStr + elementObj.UniqueID;
					for (int i = 0; i < count; i++)
					{
						var childKey = dependents[i];
						var childUniqueID = childKey + uniqueIDPart;
						T childValue;
						if (cache.TryGetValue(childUniqueID, out childValue))
						{
							result.Add(childUniqueID);
							GetAllDependentKeys((IStateObject)childValue, result);
						}
					}
				}
			}
			return result ?? EMPTYDEPENDENKEYS;
		}
		#endregion

		#region Private Methods
		private static IList<KeyValuePair<string, T>> EMPTYDEPENDENTS = new List<KeyValuePair<string, T>>();
		

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static string GetParent(string key)
		{
			var indexOfSeparator = key.IndexOf(UniqueIDGenerator.UniqueIdSeparator);
			if (indexOfSeparator != -1)
				return key.Substring(indexOfSeparator + 1);
			else
				return null;
		}
		#endregion

		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			System.Diagnostics.Debug.WriteLine("Hierarchy tracker contains " + Keys.Count + " keys ");
		}

		internal void Dispose()
		{
			cache.Clear();
			cache = null;
		}
	}
}
