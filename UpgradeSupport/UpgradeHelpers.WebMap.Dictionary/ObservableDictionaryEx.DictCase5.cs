using System.Collections.Generic;
using UpgradeHelpers.Interfaces;
using System;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase5<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries
	{

        private readonly IStateManager stateManager;
        private readonly ISurrogateManager surrogateManager;
        internal DictCase5(IStateManager stateManager,ISurrogateManager surrogateManager) { this.stateManager = stateManager;this.surrogateManager = surrogateManager; }

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
        public System.Collections.IDictionary GetInternalDictionary (int caseType)
		{
			return (System.Collections.IDictionary)internalDictCase5;
		}
		public void DeltaTrackerNotifications (bool onOff)
		{
			throw new System.NotImplementedException ();
		}
		#endregion

		internal Dictionary<TKey,CollectionStateObjectReference> internalDictCase5 = new Dictionary<TKey, CollectionStateObjectReference>();

		#region IDictionary implementation

		public void Add (TKey key, TValue value)
		{
			//This is multicast delegate create contiuation
			var val = DictionaryUtils.CreatePromise(stateManager,((Delegate)(object)value));
            internalDictCase5.Add(key, new CollectionStateObjectReference((IStateObject)val));
            AddReferenceIntoStateObjectSurrogate(val);
        }

        /// <summary>
        /// Adding a Reference to the event promise info. If we don't add the reference, the surrogate will no be persisted
        /// </summary>
        /// <param name="val"></param>
        private void AddReferenceIntoStateObjectSurrogate(IPromise val)
        {
            var stateObjectSurrogate = DictionaryUtils.GetObjectContainingMethod(val) as IStateObjectSurrogate;
            if (stateObjectSurrogate != null)
            {
                surrogateManager.AddSurrogateReference(stateObjectSurrogate, (IStateObject)val);
            }
        }



		public bool ContainsKey (TKey key)
		{
			return internalDictCase5.ContainsKey (key);
		}

		public bool Remove (TKey key)
		{
            CollectionStateObjectReference internalValue;
            var ret = internalDictCase5.TryGetValue(key, out internalValue);
            if (ret)
            {
                stateManager.RemoveObject(internalValue.TargetUniqueID,mustDetach: true,deep:true);
                RemoveReferenceFromStateObjectSurrogate(internalValue);
                internalDictCase5.Remove(key);
                return true;
            }
            return false;
		}

		public bool TryGetValue (TKey key, out TValue value)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase5.TryGetValue (key, out internalValue);
			if (ret) {

				var cont = internalValue.Target as IPromise;
				if (cont != null) {
					value = (TValue)DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValue), cont);
				} else
					value = default(TValue);
				return true;
			}
			value = default(TValue);
			return false;
		}

		public TValue this [TKey key] {
			get {
				var entry5 = internalDictCase5[key];
				TValue retEntry5 = (TValue)DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValue),(IPromise) entry5.Target);
				return retEntry5;
			}
			set {
                //Erase old reference
                CollectionStateObjectReference internalValue;
                if (internalDictCase5.TryGetValue(key, out internalValue) /*&& internalValue !=null*/)
                {
                    if (!internalValue.IsNull)
                    {
                        stateManager.RemoveObject(internalValue.TargetUniqueID, mustDetach: true, deep: true);
                        RemoveReferenceFromStateObjectSurrogate(internalValue);
                    }
                }
                //This is multicast delegate create contiuation
                var val = DictionaryUtils.CreatePromise(stateManager,((Delegate)(object)value));
				internalDictCase5 [key] = new CollectionStateObjectReference ((IStateObject)val);
                AddReferenceIntoStateObjectSurrogate(val);
			}
		}

		public ICollection<TKey> Keys {
			get {
				return internalDictCase5.Keys;
			}
		}

		internal class Case5ValueCollection<TValueCollection> : ICollection<TValueCollection>
		{
			Dictionary<TKey,CollectionStateObjectReference> _parent;
			public Case5ValueCollection(Dictionary<TKey,CollectionStateObjectReference> parent) {
				_parent = parent;
			}
			#region ICollection implementation
			public void Add(TValueCollection item)
			{
				throw new InvalidOperationException ("This is a readonly collection");
			}
			public void Clear ()
			{
				throw new InvalidOperationException ("This is a readonly collection");
			}
			public bool Contains(TValueCollection item)
			{
				throw new NotImplementedException ("This is not supported for the Value Type");
			}
			public void CopyTo(TValueCollection[] array, int arrayIndex)
			{
				throw new NotImplementedException ();
			}
			public bool Remove(TValueCollection item)
			{
				throw new InvalidOperationException ("This is a readonly collection");
			}
			public int Count {
				get {
					return _parent.Count;
				}
			}
			public bool IsReadOnly {
				get {
					return true;
				}
			}
			#endregion

			internal class Case5ValueEnumerator<TValueEnumerator> : IEnumerator<TValueEnumerator>
			{
				IEnumerator<CollectionStateObjectReference> enumerator;
				public Case5ValueEnumerator(Dictionary<TKey,CollectionStateObjectReference> parent) 
				{
					enumerator = parent.Values.GetEnumerator();
				}

				#region IEnumerator implementation
				public bool MoveNext ()
				{
					return enumerator.MoveNext ();
				}
				public void Reset ()
				{
					enumerator.Reset ();
				}
			 object System.Collections.IEnumerator.Current {
					get {
						var current = enumerator.Current;
						var cont = current.Target as IPromise;
						if (cont == null)
							throw new InvalidOperationException ();
						TValueEnumerator res = (TValueEnumerator)
                            DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValueEnumerator), cont);
						return res;
					}
				}
				#endregion
				#region IDisposable implementation
				public void Dispose ()
				{
					enumerator.Dispose ();
				}
				#endregion
				#region IEnumerator implementation
				public TValueEnumerator Current
				{
					get {
						var current = enumerator.Current;
						var cont = current.Target as IPromise;
						if (cont == null)
							throw new InvalidOperationException ();
						TValueEnumerator res = (TValueEnumerator)
                            
                            DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValueEnumerator), cont);
						return res;
					}
				}
				#endregion
			}
			#region IEnumerable implementation
			public IEnumerator<TValueCollection> GetEnumerator()
			{
				return new Case5ValueEnumerator<TValueCollection>(this._parent);
			}
			#endregion
			#region IEnumerable implementation
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
			{
				throw new NotImplementedException ();
			}
			#endregion

		}


		public ICollection<TValue> Values {
			get {
				throw new System.NotImplementedException ();
			}
		}

		#endregion

		#region ICollection implementation

		public void Add (KeyValuePair<TKey, TValue> item)
		{
			//This is multicast delegate create contiuation
			var val = DictionaryUtils.CreatePromise(stateManager,(Delegate)(object)item.Value);
			internalDictCase5.Add (item.Key, new CollectionStateObjectReference ((IStateObject)val));
            AddReferenceIntoStateObjectSurrogate(val);
		}

		public void Clear ()
		{
            foreach (var val in internalDictCase5.Keys)
            {
                CollectionStateObjectReference internalValue;
                var ret = internalDictCase5.TryGetValue(val, out internalValue);
                if (ret)
                {
                    stateManager.RemoveObject(internalValue.TargetUniqueID,mustDetach: true,deep:true);
                    RemoveReferenceFromStateObjectSurrogate(internalValue);
                    
                }
            }
			internalDictCase5.Clear ();
		}

		public bool Contains (KeyValuePair<TKey, TValue> item)
		{
			return internalDictCase5.ContainsKey (item.Key);
		}

		public void CopyTo (KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new System.NotImplementedException ();
		}

		public bool Remove (KeyValuePair<TKey, TValue> item)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase5.TryGetValue (item.Key, out internalValue);
            if (ret)
            {
                RemoveReferenceFromStateObjectSurrogate(internalValue);
                stateManager.RemoveObject(internalValue.TargetUniqueID, mustDetach: true,deep:true);
                internalDictCase5.Remove(item.Key);
                return true;
            }
			return false;
		}

        /// <summary>
        /// Removing the reference from the surrogate.
        /// </summary>
        /// <param name="internalValue"></param>
        private void RemoveReferenceFromStateObjectSurrogate(CollectionStateObjectReference internalValue)
        {
            var obj = internalValue.Target as IPromise;
            if (obj != null)
            {
                var surrogate = DictionaryUtils.GetObjectContainingMethod(obj) as IStateObjectSurrogate;
                if (surrogate != null)
                {
                    surrogateManager.RemoveSurrogateReference(surrogate, (IStateObject)obj);
                }
            }
        }

		public int Count {
			get {
				return internalDictCase5.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return false;
			}
		}

		#endregion


		internal class Case5Enumerator<TKeyEnumerator, TValueEnumerator> : IEnumerator<KeyValuePair<TKeyEnumerator, TValueEnumerator>>
		{

			IEnumerator<KeyValuePair<TKeyEnumerator, CollectionStateObjectReference>> enumerator;
			public Case5Enumerator(Dictionary<TKeyEnumerator, CollectionStateObjectReference> parent)
			{
				enumerator = parent.GetEnumerator();
			}
			#region IEnumerator implementation
			public bool MoveNext ()
			{
				return enumerator.MoveNext ();
			}
			public void Reset ()
			{
				enumerator.Reset ();
			}
			object System.Collections.IEnumerator.Current {
				get {
					var current = enumerator.Current;
					var target = current.Value.Target;
					TValueEnumerator value = default(TValueEnumerator);
					var cont = current.Value.Target as IPromise;
					if (cont == null)
						throw new InvalidOperationException ();

					value = (TValueEnumerator)DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValueEnumerator), cont);
					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>(current.Key, value);
				}
			}
			#endregion
			#region IDisposable implementation
			public void Dispose ()
			{
				enumerator.Dispose ();
			}
			#endregion
			#region IEnumerator implementation
			public KeyValuePair<TKeyEnumerator, TValueEnumerator> Current
			{
				get {
					var current = enumerator.Current;
					var target = current.Value.Target;
					TValueEnumerator value = default(TValueEnumerator);
					var cont = current.Value.Target as IPromise;
					if (cont == null)
						throw new InvalidOperationException ();

					value = (TValueEnumerator)DictionaryUtils.RetrieveDelegateFromPromise(typeof(TValueEnumerator), cont);
					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>(current.Key, value);

				}
			}
			#endregion
		}


		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator ()
		{
			return new Case5Enumerator<TKey,TValue > (this.internalDictCase5);
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return new Case5Enumerator<TKey,TValue > (this.internalDictCase5);
		}

		#endregion
	}
}

