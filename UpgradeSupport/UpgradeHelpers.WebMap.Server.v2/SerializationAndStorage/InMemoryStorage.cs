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
    /// This class is used to store a cache of Keys and keep track of the children of those Keys added
    /// to have a very inexpensive getChildren method.
    /// </summary>
    [Serializable]
    class ChildrenTracker
    {
        #region Private Members

        private Dictionary<string, List<string>> childrenTracker = new Dictionary<string, List<string>>(2000,StringComparer.Ordinal);

        #endregion

        private IStateManager stateManager;
        #region Public Methods
		public ChildrenTracker(IStateManager stateManager, bool addObjectIndexing = false)
		{
			this.stateManager = stateManager;
		}
		internal virtual string GetParentKey(string key)
		{
			return stateManager.GetParentKeyEx(key);
		}

		private object _cacheLock = new object();
        public void Add(string key)
        {
            string parent = GetParentKey(key);
            lock (_cacheLock)
            {
                if (parent != null)
                {
                    List<string> parentSet;
                    if (!childrenTracker.TryGetValue(parent, out parentSet))
                    {
						parentSet = new List<string>();
                        childrenTracker.Add(parent, parentSet);
                    }
                    parentSet.Add(key);
                }
            }
        }

		public bool Remove(string key)
		{
			bool result = false;
			string parent = GetParentKey(key);
			List<string> parentChildren = null;
			lock (_cacheLock)
			{
				if (parent != null && childrenTracker.TryGetValue(parent, out parentChildren))
				{
					parentChildren.Remove(key);
					if (parentChildren.Count == 0)
						childrenTracker.Remove(parent);
					result = true;
				}
			}
			return result;
		}
		private static IList<string> EMPTYDEPENDENTS = new List<string>();

        public List<string> GetAllDependentKeys(string key)
        {
			var result = new List<string>();
            return GetAllDependentKeysIterative(key, result);
        }

        #endregion

        #region Private Methods
		private List<string> GetAllDependentKeysIterative(string key, List<string> result)
        {
            List<string> directChildren;
            bool found = childrenTracker.TryGetValue(key, out directChildren);
            if (found)
            {
				result.AddRange(directChildren);
				foreach (string childKey in directChildren)
						GetAllDependentKeysIterative(childKey, result);
            }
            return result;
        }

        #endregion
		internal void Dispose()
		{
			childrenTracker.Clear();
			childrenTracker = null;
			stateManager = null;
		}
	}

	/// <summary>
	/// This class is used to store a cache of IStateObjects and keep track of the children of the IStateObjects added
	/// to have a very inexpensive getChildren method.
	/// There are public methods for the common operations applied on a Dictionary, that basically just encapsulate the use of the
	/// internal dictionary of IStateObjects.
	/// </summary>
	[Serializable]
	class HierarchicalStorage<T> : System.Runtime.Serialization.ISerializable
	{
		#region Public Members
        public Dictionary<String, T>.ValueCollection Values
        {
            get { 
                return storage.Values; 
            }
        }
        public Dictionary<String, T>.KeyCollection Keys
        {
            get { return storage.Keys; }
        }
        public Dictionary<string, T> KeyValuePairs
        {
            get { return storage.KeyValuePairs; }
        }
        public int Count
        {
            get { return storage.Count; }
        }
        #endregion

        #region Private Members
        private PlainStorage<T> storage;

		private ChildrenTracker childrenTracker;

        #endregion

        #region Public Methods
		public HierarchicalStorage(IStateManager stateManager)
		{
			childrenTracker = new ChildrenTracker(stateManager);
			storage = new PlainStorage<T>(stateManager);
		}

        public void AddOrReplace(string key, T value)
        {
			storage.AddOrReplace(key, value);
			childrenTracker.Add(key);
        }

		/// <summary>
		/// Removes an element from the Tracker
		/// </summary>
		/// <param name="key"></param>
		/// <param name="isRoot">It means that the element being removed is the Root of Children being removed.</param>
		public virtual void Remove(string key)
		{
			storage.Remove(key);
			childrenTracker.Remove(key);
		}

        public T Get(string key)
        {
            return storage.Get(key);
        }

        public bool TryGetValue(string key, out T value)
        {
            return storage.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets the elements from the cache that belongs to the object identified by the given key.
        /// In this improved version the method only iterates over the specific hierarchy of the object identified by the "key" parameter, and
        /// ignores the rest of the elements in the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
		/// 
		private static IList<KeyValuePair<string, T>> EMPTYDEPENDENTS = new List<KeyValuePair<string, T>>();
        public IList<KeyValuePair<string, T>> GetAllDependentItems(string key)
        {
            IList<KeyValuePair<string, T>> result = null;
			var keys = childrenTracker.GetAllDependentKeys(key);
			foreach (var childKey in keys)
			{ 
				T outValue;
				if(storage.TryGetValue(childKey, out outValue))
				{
					result = result ?? new List<KeyValuePair<string, T>>();
					result.Add(new KeyValuePair<string, T>(childKey, outValue));
				}
			}
			return result ?? EMPTYDEPENDENTS;
        }
		
        #endregion
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            System.Diagnostics.Debug.WriteLine("Hierarchy tracker contains " + Keys.Count + " keys ");
        }

		internal void Dispose()
		{
			storage.Dispose();
			childrenTracker.Dispose();
			storage = null;
			childrenTracker = null;
		}
	}

	[Serializable]
	class PlainStorage<T> : System.Runtime.Serialization.ISerializable
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
		private Dictionary<string, T> cache = new Dictionary<string, T>(500,StringComparer.Ordinal);
		
		private object _cacheLock = new object();

		#endregion

		#region Public Methods
		
		private IStateManager stateManager;
		public PlainStorage(IStateManager stateManager)
		{
			this.stateManager = stateManager;
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
						var childUniqueID = childKey;
						if(!UniqueIDGenerator.IsListItem(childKey))
						 childUniqueID += uniqueIDPart;
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
						var childUniqueID = childKey;
						if (!UniqueIDGenerator.IsListItem(childKey))
							childUniqueID += uniqueIDPart;
						var childValue = stateManager.GetObject(childUniqueID);
						if (childValue != null)
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
