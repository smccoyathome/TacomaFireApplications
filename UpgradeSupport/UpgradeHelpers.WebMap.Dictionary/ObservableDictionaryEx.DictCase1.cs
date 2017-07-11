using System;
using System.Collections.Generic;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{
	public class DictCase1<TKey, TValue> : IDictionary<TKey, TValue>, IObservableDictionaryEntries
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
			return (System.Collections.IDictionary)internalDictCase1;
		}
		public void DeltaTrackerNotifications (bool onOff)
		{
			throw new System.NotImplementedException ();
		}
		#endregion

		internal Dictionary<TKey,TValue> internalDictCase1 = new Dictionary<TKey, TValue>();

		#region IDictionary implementation

		public void Add (TKey key, TValue value)
		{
			internalDictCase1.Add (key, value);
		}

		public bool ContainsKey (TKey key)
		{
			return internalDictCase1.ContainsKey (key);
		}

		public bool Remove (TKey key)
		{
			return internalDictCase1.Remove (key);
		}

		public bool TryGetValue (TKey key, out TValue value)
		{
			return internalDictCase1.TryGetValue (key, out value);
		}

		public TValue this [TKey index] {
			get {
				return internalDictCase1 [index];
			}
			set {
				internalDictCase1 [index] = value;
			}
		}

		public ICollection<TKey> Keys {
			get {
				return internalDictCase1.Keys;
					
			}
		}

		public ICollection<TValue> Values {
			get {
				return internalDictCase1.Values;
			}
		}

		#endregion

		#region ICollection implementation

		public void Add (KeyValuePair<TKey, TValue> item)
		{
			internalDictCase1.Add (item.Key, item.Value);
		}

		public void Clear ()
		{
			internalDictCase1.Clear ();
		}

		public bool Contains (KeyValuePair<TKey, TValue> item)
		{
			return internalDictCase1.ContainsKey (item.Key) && item.Value.Equals(item.Value);
		}

		public void CopyTo (KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new System.NotImplementedException ();
		}

		public bool Remove (KeyValuePair<TKey, TValue> item)
		{
			return internalDictCase1.Remove (item.Key);
		}

		public int Count {
			get {
				return internalDictCase1.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return false;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator ()
		{
			return internalDictCase1.GetEnumerator ();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return internalDictCase1.GetEnumerator ();
		}

		#endregion

	}
}