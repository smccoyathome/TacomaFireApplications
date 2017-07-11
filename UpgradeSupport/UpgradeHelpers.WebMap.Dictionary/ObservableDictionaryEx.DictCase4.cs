using System;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase4<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries
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
			return (System.Collections.IDictionary)internalDictCase4;
		}
		public void DeltaTrackerNotifications (bool onOff)
		{
			throw new System.NotImplementedException ();
		}
		#endregion


		internal Dictionary<CollectionStateObjectReference,CollectionStateObjectReference> internalDictCase4 = new Dictionary<CollectionStateObjectReference, CollectionStateObjectReference> ();

		#region IDictionary implementation

		public void Add (TKey key, TValue value)
		{
			internalDictCase4.Add(new CollectionStateObjectReference((IStateObject)key),
				new CollectionStateObjectReference((IStateObject)value));
		}

		public bool ContainsKey (TKey key)
		{
			return internalDictCase4.ContainsKey (new CollectionStateObjectReference ((IStateObject)key));
		}

		public bool Remove (TKey key)
		{
			return internalDictCase4.Remove (new CollectionStateObjectReference ((IStateObject)key));
		}

		public bool TryGetValue (TKey key, out TValue value)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase4.TryGetValue (new CollectionStateObjectReference ((IStateObject)key), out internalValue);
			if (ret) {
				value = (TValue)internalValue.Target;
				return true;
			}
			value = default(TValue);
			return false;
		}

		public TValue this [TKey key] {
			get {
				var internalValue = internalDictCase4 [new CollectionStateObjectReference ((IStateObject)key)];
				if (internalValue.IsNull != null)
					return (TValue)internalValue.Target;
				return default(TValue);
			}
			set {
				internalDictCase4 [new CollectionStateObjectReference ((IStateObject)key)] = 
					new CollectionStateObjectReference ((IStateObject)value);
			}
		}

		internal class Case4DictionaryStateObjectReferenceEnumerator<TElement> : IEnumerator<TElement> {
			IEnumerator<CollectionStateObjectReference> enumerator;
			public Case4DictionaryStateObjectReferenceEnumerator(Dictionary<CollectionStateObjectReference,CollectionStateObjectReference> parent,bool keysOrValues) 

			{
				if (keysOrValues)
					enumerator = parent.Keys.GetEnumerator();
				else
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
					var key = current.Target;
					if (key == null)
						throw new System.InvalidOperationException ("Key is no longer on the session");
					
					return (TKey)current.Target;
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
			public TElement Current {
				get {
					var current = enumerator.Current;
					var key = current.Target;
					if (key == null)
						throw new System.InvalidOperationException ("Element is no longer on the session");

					return (TElement)current.Target;
				}
			}
			#endregion
		
		}

		internal class Case4DictionaryStateObjectReferenceCollection<TElement> : ICollection<TElement>
		{
			readonly Dictionary<CollectionStateObjectReference,CollectionStateObjectReference> _parent;
			readonly bool isForKeys;
			public Case4DictionaryStateObjectReferenceCollection(Dictionary<CollectionStateObjectReference,CollectionStateObjectReference> parent,bool isForKeys) {
				_parent = parent;
				this.isForKeys = isForKeys;
			}
			#region ICollection implementation
			public void Add (TElement item)
			{
				throw new System.NotImplementedException ("This is a readonly collection");
			}
			public void Clear ()
			{
				throw new System.NotImplementedException ("This is a readonly collection");
			}
			public bool Contains (TElement item)
			{
				if (isForKeys)
					return _parent.ContainsKey(new CollectionStateObjectReference((IStateObject)item));
				else
					return _parent.ContainsValue(new CollectionStateObjectReference((IStateObject)item));
			}
			public void CopyTo (TElement[] array, int arrayIndex)
			{
				throw new System.NotImplementedException ();
			}
			public bool Remove (TElement item)
			{
						throw new System.NotImplementedException ("This is a readonly key collection");
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
			public IEnumerator<TElement> GetEnumerator ()
			{
				return new Case4DictionaryStateObjectReferenceEnumerator<TElement> (_parent,isForKeys);
			}
			#endregion
			#region IEnumerable implementation
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
			{
				return new Case4DictionaryStateObjectReferenceEnumerator<TElement> (_parent,isForKeys);
			}
			#endregion
		}


		public ICollection<TKey> Keys {
			get {
				return new Case4DictionaryStateObjectReferenceCollection<TKey> (this.internalDictCase4,true);
			}
		}

		public ICollection<TValue> Values {
			get {
				return new Case4DictionaryStateObjectReferenceCollection<TValue> (this.internalDictCase4,false);
			}
		}

		#endregion

		#region ICollection implementation

		public void Add (KeyValuePair<TKey, TValue> item)
		{
			internalDictCase4.Add (
				new CollectionStateObjectReference ((IStateObject)item.Key),
				new CollectionStateObjectReference ((IStateObject)item.Value)
			);

		}

		public void Clear ()
		{
			internalDictCase4.Clear ();
		}

		public bool Contains (KeyValuePair<TKey, TValue> item)
		{
			CollectionStateObjectReference internalValue;
			var ret = internalDictCase4.TryGetValue (new CollectionStateObjectReference ((IStateObject)item.Key), out internalValue);
			if (ret) {
				return internalValue.Equals (item);
			}
			return false;
		}

		public void CopyTo (KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new System.NotImplementedException ();
		}

		public bool Remove (KeyValuePair<TKey, TValue> item)
		{
			return internalDictCase4.Remove (new CollectionStateObjectReference((IStateObject)item.Key));
		}

		public int Count {
			get {
				return internalDictCase4.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return false;
			}
		}

		#endregion


		internal class Case4Enumerator<TKeyEnumerator, TValueEnumerator> : IEnumerator<KeyValuePair<TKeyEnumerator, TValueEnumerator>>
		{

			internal IEnumerator<KeyValuePair<CollectionStateObjectReference,CollectionStateObjectReference>> enumerator;

			public Case4Enumerator(Dictionary<CollectionStateObjectReference,CollectionStateObjectReference> parent)
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
					if (current.Key.Target == null || current.Value.Target == null)
						throw new System.InvalidOperationException ();

					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>((TKeyEnumerator)current.Key.Target,
						(TValueEnumerator)current.Value.Target);
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

					if (current.Key.Target == null)
						throw new System.InvalidOperationException ();
					return new KeyValuePair<TKeyEnumerator, TValueEnumerator>((TKeyEnumerator)current.Key.Target,
						(TValueEnumerator)current.Value.Target);
				}
			}
			#endregion

		}

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator ()
		{
			return new Case4Enumerator<TKey,TValue> (this.internalDictCase4);
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return new Case4Enumerator<TKey,TValue> (this.internalDictCase4);
		}

		#endregion
	}
}
