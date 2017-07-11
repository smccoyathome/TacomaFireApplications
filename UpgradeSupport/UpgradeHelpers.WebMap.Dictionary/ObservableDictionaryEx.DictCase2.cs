using System;
using System.Collections.Generic;
using System.Linq;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase2<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries, IReferenceWatcher
	{
        #region IObservableDictionaryEntries implementation

        public int CaseType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        void IObservableDictionaryEntries.Initialize(IStateManager stateManager, IReferenceManager referenceManager, ISurrogateManager surrogateManager)
        {
            throw new NotImplementedException();
        }
        public System.Collections.IDictionary GetInternalDictionary(int caseType)
		{
			return (System.Collections.IDictionary)internalDictCase2;
		}
		public void DeltaTrackerNotifications(bool onOff)
		{
			throw new System.NotImplementedException();
		}
		#endregion

		internal Dictionary<TKey, CollectionStateObjectReference> internalDictCase2 = new Dictionary<TKey, CollectionStateObjectReference>();

		IStateObject _parent;

		/// <summary>
		/// Setups the parent. This must be done for Object Adoption
		/// </summary>
		/// <param name="parent"></param>
		public void SetParent(IStateObject parent)
		{
			_parent = parent;
		}

        readonly IStateManager _stateManager;
        readonly IReferenceManager _referencesManager;
        internal DictCase2(IStateManager stateManager,IReferenceManager referenceManager) 
        { 
            _stateManager = stateManager;
            _referencesManager = referenceManager;
        }


		#region IDictionary implementation

		public void Add(TKey key, TValue value)
		{
			var collectionStateObjectReference = value == null ? CollectionStateObjectReference.NullInstance: new CollectionStateObjectReference((IStateObject)value); 
			internalDictCase2.Add(key, collectionStateObjectReference);
			var stateObject = (IStateObject)value;
			if (stateObject != null)
			{
				if (!_stateManager.IsStateObjectAllAttached(stateObject))
				{
					_stateManager.RegisterPossibleOrphan(_parent, stateObject);
				}
                _referencesManager.Subscribe(_parent, stateObject);
			}
		}

		public bool ContainsKey(TKey key)
		{
			return internalDictCase2.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			var referencedObject = (IStateObject)this[key];
            var stateobject = referencedObject as IStateObject;
            if(stateobject != null)
                _referencesManager.UnSubscribe(_parent, stateobject.UniqueID);
			return internalDictCase2.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase2.TryGetValue(key, out internalValue);
			value = ret ? (TValue)internalValue.Target : default(TValue);
			return ret;
		}

		public TValue this[TKey key]
		{
			get
			{
				var entry = internalDictCase2[key];
				return (TValue)entry.Target;
			}
			set
			{
                //Was there a value
                CollectionStateObjectReference oldCollectionReference;
                if (internalDictCase2.TryGetValue(key, out oldCollectionReference))
                {
                    if (!oldCollectionReference.IsNull)
                    {
                        _referencesManager.UnSubscribe(_parent, oldCollectionReference.TargetUniqueID);
                    }
                }
                //Now we can assign the new value
                internalDictCase2[key] = new CollectionStateObjectReference((IStateObject)value);
				var stateObject = (IStateObject)value;
				if (stateObject != null)
				{
					if (!_stateManager.IsStateObjectAllAttached(stateObject))
					{
						_stateManager.RegisterPossibleOrphan(_parent, stateObject);
					}
                    _referencesManager.Subscribe(_parent, stateObject);
				}
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return internalDictCase2.Keys;
			}
		}

		internal class Case2DictionaryStateObjectReferenceValuesEnumerator<TElement> : IEnumerator<TElement>
		{
			IEnumerator<CollectionStateObjectReference> enumerator;
			public Case2DictionaryStateObjectReferenceValuesEnumerator(Dictionary<TKey, CollectionStateObjectReference> parent)
			{
				enumerator = parent.Values.GetEnumerator();
			}
			#region IEnumerator implementation
			public bool MoveNext()
			{
				return enumerator.MoveNext();
			}
			public void Reset()
			{
				enumerator.Reset();
			}
			object System.Collections.IEnumerator.Current
			{
				get
				{
					var current = enumerator.Current;
					var key = current.Target;
					if (!current.IsNull && key == null)
						throw new System.InvalidOperationException("Element is no longer on the session");

					return (TElement)current.Target;
				}
			}
			#endregion
			#region IDisposable implementation
			public void Dispose()
			{
				enumerator.Dispose();
			}
			#endregion
			#region IEnumerator implementation
			public TElement Current
			{
				get
				{
					var current = enumerator.Current;
					var key = current.Target;
					if (!current.IsNull && key == null)
						throw new System.InvalidOperationException("Element is no longer on the session");

					return (TElement)current.Target;
				}
			}
			#endregion

		}
		internal class Case2DictionaryStateObjectReferenceValuesCollection<TElement> : ICollection<TElement>
		{
			readonly Dictionary<TKey, CollectionStateObjectReference> _parent;
			public Case2DictionaryStateObjectReferenceValuesCollection(Dictionary<TKey, CollectionStateObjectReference> parent)
			{
				_parent = parent;
			}
			#region ICollection implementation
			public void Add(TElement item)
			{
				throw new System.NotImplementedException("This is a readonly collection");
			}
			public void Clear()
			{
				throw new System.NotImplementedException("This is a readonly collection");
			}
			public bool Contains(TElement item)
			{
				return _parent.ContainsValue(new CollectionStateObjectReference((IStateObject)item));
			}
			public void CopyTo(TElement[] array, int arrayIndex)
			{
				throw new System.NotImplementedException();
			}
			public bool Remove(TElement item)
			{
				throw new System.NotImplementedException("This is a readonly key collection");
			}
			public int Count
			{
				get
				{
					return _parent.Count;
				}
			}
			public bool IsReadOnly
			{
				get
				{
					return true;
				}
			}
			#endregion
			#region IEnumerable implementation
			public IEnumerator<TElement> GetEnumerator()
			{
				return new Case2DictionaryStateObjectReferenceValuesEnumerator<TElement>(_parent);
			}
			#endregion
			#region IEnumerable implementation
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return new Case2DictionaryStateObjectReferenceValuesEnumerator<TElement>(_parent);
			}
			#endregion
		}

		public ICollection<TValue> Values
		{
			get { return new Case2DictionaryStateObjectReferenceValuesCollection<TValue>(internalDictCase2); }
		}

		#endregion

		#region ICollection implementation

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			internalDictCase2.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase2.TryGetValue(item.Key, out internalValue);
			if (ret)
			{
				var value = internalValue.Target;
				if (value == null && item.Value == null)
					return true;
				if (value != null && item.Value != null)
					return value.UniqueID == ((IStateObject)item.Value).UniqueID;
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
            //, MOBILIZE,09/26/2016,TODO,mvega,"Manually changed", "implementing this method to avoid exception when viewing some Lab Orders" 
            var arraySource = (from e in internalDictCase2 select new KeyValuePair<TKey, TValue>(e.Key, (TValue)(e.Value.Target))).ToArray();
            arraySource.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new System.NotImplementedException();
		}

		public int Count
		{
			get
			{
				return internalDictCase2.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		#endregion







		#region IEnumerable implementation



		internal class Case2IEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
		{
			public Dictionary<TKey, CollectionStateObjectReference> _parent;
			public IEnumerator<KeyValuePair<TKey, CollectionStateObjectReference>> iterator;

			public Case2IEnumerator(Dictionary<TKey, CollectionStateObjectReference> parent)
			{
				this._parent = parent;
				iterator = _parent.GetEnumerator();
			}

			#region IEnumerator implementation
			public bool MoveNext()
			{
				return iterator.MoveNext();
			}
			public void Reset()
			{
				iterator.Reset();
			}
			object System.Collections.IEnumerator.Current
			{
				get
				{
					var current = iterator.Current;

					return new KeyValuePair<TKey, TValue>(current.Key, (TValue)current.Value.Target);
				}
			}
			#endregion
			#region IDisposable implementation
			public void Dispose()
			{
				iterator.Dispose();
			}
			#endregion
			#region IEnumerator implementation
			public KeyValuePair<TKey, TValue> Current
			{
				get
				{

					var current = iterator.Current;

					return new KeyValuePair<TKey, TValue>(current.Key, (TValue)current.Value.Target);

				}
			}
			#endregion
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Case2IEnumerator(this.internalDictCase2);
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return new Case2IEnumerator(this.internalDictCase2);
		}

		#endregion

		public void UpdateReference(string oldUniqueID, string newUniqueID)
		{
            TKey key = default(TKey);
            bool found=false;
            foreach (var pair in internalDictCase2)
			{
				if (pair.Value.TargetUniqueID == oldUniqueID)
				{
                    key = pair.Key;
                    found = true;
                    break;
				}
			}
            if (found)
            {
                internalDictCase2[key] = new CollectionStateObjectReference(newUniqueID);

            }

        }
    }
}