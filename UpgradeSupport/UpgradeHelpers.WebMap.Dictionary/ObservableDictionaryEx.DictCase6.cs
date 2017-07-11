using System.Collections.Generic;
using UpgradeHelpers.Interfaces;
using System.Linq;
using System;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase6<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries
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
			return (System.Collections.IDictionary)internalDictCase6;
		}
		public void DeltaTrackerNotifications(bool onOff)
		{
			throw new System.NotImplementedException();
		}
		#endregion

		internal Dictionary<TKey, CollectionStateObjectReference> internalDictCase6 = new Dictionary<TKey, CollectionStateObjectReference>();

		IStateObject _parent;
        readonly IStateManager _stateManager;
        readonly IReferenceManager referencesManager;
        readonly ISurrogateManager surrogateManager;
        internal DictCase6(IStateManager stateManager,ISurrogateManager surrogateManager,IReferenceManager referencesManager)
        {
            _stateManager = stateManager;
            this.surrogateManager = surrogateManager;
            this.referencesManager = referencesManager;
        }


		/// <summary>
		/// Setups the parent. This must be done for Object Adoption
		/// </summary>
		/// <param name="parent"></param>
		public void SetParent(IStateObject parent)
		{
			_parent = parent;
		}

		#region IDictionary implementation

		public void Add(TKey key, TValue value)
		{
			var surrogate = surrogateManager.GetStateObjectSurrogate(value, true);
			//TODO: There is a risk of having the UniqueId become invalid.
            surrogateManager.AddSurrogateReference(surrogate, _parent);

			internalDictCase6.Add(key, new CollectionStateObjectReference((IStateObject)surrogate));
			//The surrogate might not have a parent and the dictionary might need to adopt it.
			var stateObject = (IStateObject)surrogate;
			if (stateObject != null)
			{
				if (!_stateManager.IsStateObjectAllAttached(stateObject))
				{
                    _stateManager.RegisterPossibleOrphan(_parent, stateObject);
				}
                referencesManager.Subscribe(valueObject:_parent, referenceObject:stateObject);
			}
		}

		public bool ContainsKey(TKey key)
		{
			return internalDictCase6.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
            CollectionStateObjectReference valueRef;
            if (internalDictCase6.TryGetValue(key, out valueRef))
            {
                referencesManager.UnSubscribe(valueObject: _parent, UniqueID: valueRef.Target.UniqueID);
                return internalDictCase6.Remove(key);
            }
            return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			CollectionStateObjectReference internalValue;
			//Retrieve surrogate 
			var ret = internalDictCase6.TryGetValue(key, out internalValue);
			//Value will hold the Surrogate
			var surrogate = ret ? (IStateObjectSurrogate)internalValue.Target : null;
			if (surrogate != null)
				value = (TValue)surrogate.Value;
			else
				value = default(TValue);
			return ret;
		}

		public TValue this[TKey key]
		{
			get
			{
				var entry = internalDictCase6[key];
				var surrogate = entry.Target as IStateObjectSurrogate;
				if (surrogate != null)
				{
					return (TValue)surrogate.Value;
				}
				return default(TValue);

			}
			set
			{

                CollectionStateObjectReference valueRef;
                if (internalDictCase6.TryGetValue(key, out valueRef) /*&& valueRef!=null*/)
                {
                    if (!valueRef.IsNull/* != NullCollectionStateObjectReference.CommonInstance*/)
                    {
                        referencesManager.UnSubscribe(valueObject: _parent, UniqueID: valueRef.Target.UniqueID);
                    }
                }


                var surrogate = surrogateManager.GetStateObjectSurrogate(value, true);
				//TODO: There is a risk of having the UniqueId become invalid.
                surrogateManager.AddSurrogateReference(surrogate, _parent);


				internalDictCase6[key] = new CollectionStateObjectReference((IStateObject)surrogate);
				var stateObject = (IStateObject)surrogate;
				//Possible orphan
				if (stateObject != null)
				{
					if (!_stateManager.IsStateObjectAllAttached(stateObject))
					{
                        _stateManager.RegisterPossibleOrphan(_parent, stateObject);
					}
                    referencesManager.Subscribe(_parent, stateObject);
				}


			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return internalDictCase6.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				var tempArray = new CollectionStateObjectReference[internalDictCase6.Values.Count];
				internalDictCase6.Values.CopyTo(tempArray, 0);
				return tempArray.Select<CollectionStateObjectReference, TValue>((obj) =>
				{
					var surrogate = obj.Target as IStateObjectSurrogate;
					if (surrogate != null)
					{
						return (TValue)surrogate.Value;
					}
					return default(TValue);
				}).ToList();
			}
		}

		#endregion

		#region ICollection implementation

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Clear()
		{
			internalDictCase6.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase6.TryGetValue(item.Key, out internalValue);
			if (ret)
			{
				var surrogate = internalValue.Target as IStateObjectSurrogate;
				if (surrogate == null) return false;
				var value = (TValue)surrogate.Value;

				if (value == null && item.Value == null)
					return true;
				if (value != null && item.Value != null)
					return value.Equals(item.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new System.NotImplementedException();
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new System.NotImplementedException();
		}

		public int Count
		{
			get
			{
				return internalDictCase6.Count;
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
					var surrogate = current.Value.Target as IStateObjectSurrogate;
					return new KeyValuePair<TKey, TValue>(current.Key, (TValue)surrogate.Value);

				}
			}
			#endregion
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return new Case2IEnumerator(this.internalDictCase6);
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return new Case2IEnumerator(this.internalDictCase6);
		}



        #endregion
    }
}
