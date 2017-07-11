using System;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase3<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries
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
        public System.Collections.IDictionary GetInternalDictionary (int caseType)
		{
			return (System.Collections.IDictionary)internalDictCase3;
		}
		public void DeltaTrackerNotifications (bool onOff)
		{
			throw new System.NotImplementedException ();
		}
		#endregion


		internal Dictionary<CollectionStateObjectReference,TValue> internalDictCase3 = new Dictionary<CollectionStateObjectReference, TValue> ();

		#region IDictionary implementation
		public void Add (TKey key, TValue value)
		{
			internalDictCase3.Add (new CollectionStateObjectReference ((IStateObject)key), value);
		}
		public bool ContainsKey (TKey key)
		{
			return internalDictCase3.ContainsKey (new CollectionStateObjectReference ((IStateObject)key));
		}
		public bool Remove (TKey key)
		{
			return internalDictCase3.Remove (new CollectionStateObjectReference ((IStateObject)key));
		}
		public bool TryGetValue (TKey key, out TValue value)
		{
			return internalDictCase3.TryGetValue(new CollectionStateObjectReference((IStateObject)key),out value);
		}
		public TValue this [TKey key] {
			get {
				return internalDictCase3 [new CollectionStateObjectReference ((IStateObject)key)];
			}
			set {
				internalDictCase3 [new CollectionStateObjectReference ((IStateObject)key)] = value;
			}
		}

		internal class Case3KeyEnumerator<TKeyEnumerator> : IEnumerator<TKeyEnumerator>
		{
			IEnumerator<CollectionStateObjectReference> enumerator;
			public Case3KeyEnumerator(Dictionary<CollectionStateObjectReference,TValue> parent) {
				enumerator = parent.Keys.GetEnumerator();
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
					return (TKeyEnumerator)current.Target;
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
			public TKeyEnumerator Current
			{
				get {
					var current = enumerator.Current;
					return (TKeyEnumerator)current.Target;
				}
			}
			#endregion
		}

		internal class Case3KeyCollection<TKeyCollection> : ICollection<TKeyCollection>
		{
			Dictionary<CollectionStateObjectReference,TValue> _parent;

			public Case3KeyCollection(Dictionary<CollectionStateObjectReference,TValue> parent)
			{
				_parent = parent;
			}
			#region ICollection implementation
			public void Add(TKeyCollection item)
			{
				throw new System.NotImplementedException ("This is a readonly Key collection");
			}
			public void Clear ()
			{
				throw new System.NotImplementedException ("This is a readonly Key collection");
			}
			public bool Contains(TKeyCollection item)
			{
				return _parent.ContainsKey (new CollectionStateObjectReference ((IStateObject)item));
			}
			public void CopyTo(TKeyCollection[] array, int arrayIndex)
			{
				throw new System.NotImplementedException ();
			}
			public bool Remove(TKeyCollection item)
			{
				throw new System.NotImplementedException ("This is a readonly Key collection");

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

			#region IEnumerable implementation
			public IEnumerator<TKeyCollection> GetEnumerator()
			{
				return new Case3KeyEnumerator<TKeyCollection>(this._parent);
			}
			#endregion
			#region IEnumerable implementation
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
			{
				return new Case3KeyEnumerator<TKeyCollection>(this._parent);
			}
			#endregion
		}



		public ICollection<TKey> Keys {
			get {
				return new Case3KeyCollection<TKey> (internalDictCase3);
			}
		}



		public ICollection<TValue> Values {
			get {
				return internalDictCase3.Values;
			}
		}
		#endregion
		#region ICollection implementation
		public void Add (KeyValuePair<TKey, TValue> item)
		{
			internalDictCase3.Add (new CollectionStateObjectReference((IStateObject)item.Key), item.Value);
		}
		public void Clear ()
		{
			internalDictCase3.Clear ();
		}
		public bool Contains (KeyValuePair<TKey, TValue> item)
		{
			TValue val;
			bool ret = internalDictCase3.TryGetValue (new CollectionStateObjectReference((IStateObject)item.Key),out val);
			if (ret) {
				return val.Equals(item.Value);
			}
			return false;
		}
		public void CopyTo (KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new System.NotImplementedException ();
		}
		public bool Remove (KeyValuePair<TKey, TValue> item)
		{
			return internalDictCase3.Remove (new CollectionStateObjectReference((IStateObject)item.Key));
		}
		public int Count {
			get {
				return internalDictCase3.Count;
			}
		}
		public bool IsReadOnly {
			get {
				return false;
			}
		}
		#endregion


		internal class Case3Enumerator<TKeyEnumerator, TValueEnumerator> : IEnumerator<KeyValuePair<TKeyEnumerator, TValueEnumerator>>
		{
			readonly Dictionary<CollectionStateObjectReference, TValueEnumerator> _parent;
			readonly IEnumerator<KeyValuePair<CollectionStateObjectReference, TValueEnumerator>> enumerator;

			public Case3Enumerator(Dictionary<CollectionStateObjectReference, TValueEnumerator> parent)
			{
				_parent   = parent;
				enumerator = _parent.GetEnumerator();
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
					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>((TKeyEnumerator)current.Key.Target, current.Value);
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
					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>((TKeyEnumerator)current.Key.Target, current.Value);

				}
			}
			#endregion
		}


		#region IEnumerable implementation
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator ()
		{
			return new Case3Enumerator<TKey,TValue > (this.internalDictCase3);
		}
		#endregion
		#region IEnumerable implementation
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return new Case3Enumerator<TKey,TValue > (this.internalDictCase3);
		}
		#endregion
	}
}