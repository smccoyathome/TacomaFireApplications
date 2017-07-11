using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace UpgradeHelpers.WebMap.Server.Common
{
	/// <summary>
	/// Provides a generic IDictionry implementation that implmeents <c>INotifyCollectionChanged</c> in order to
	/// nofify when the list changes.
	/// </summary>
	/// <typeparam name="TK">Type of the dictionary key</typeparam>
	/// <typeparam name="TV">Type of the dictionary value</typeparam>
	public class ObservableDictionary<TK, TV> : IDictionary<TK, TV>, INotifyCollectionChanged
	{
		private readonly IDictionary<TK, TV> _dictionary;

		public ObservableDictionary()
		{
			_dictionary = new Dictionary<TK, TV>();
		}

		public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		public void Add(KeyValuePair<TK, TV> item)
		{
			_dictionary.Add(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item.Value);
		}

		public void Clear()
		{
			_dictionary.Clear();
			NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
		}

		public bool Contains(KeyValuePair<TK, TV> item)
		{
			return _dictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
		{
			_dictionary.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return _dictionary.Count; }
		}

		public bool Remove(KeyValuePair<TK, TV> item)
		{
			var removed = _dictionary.Remove(item);
			if (removed)
				NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item.Value);
			return removed;
		}

		public bool IsReadOnly
		{
			get { return _dictionary.IsReadOnly; }
		}

		public bool ContainsKey(TK key)
		{
			return _dictionary.ContainsKey(key);
		}

		public void Add(TK key, TV value)
		{
			_dictionary.Add(key, value);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, value);
		}

		public bool Remove(TK key)
		{
			if (_dictionary.ContainsKey(key))
			{
				var item = _dictionary[key];
				_dictionary.Remove(key);
				NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
				return true;
			}
			return false;
		}

		public bool TryGetValue(TK key, out TV value)
		{
			return _dictionary.TryGetValue(key, out value);
		}

		public TV this[TK key]
		{
			get { return _dictionary[key]; }
			set { _dictionary[key] = value; }
		}

		public ICollection<TK> Keys
		{
			get { return _dictionary.Keys; }
		}

		public ICollection<TV> Values
		{
			get { return _dictionary.Values; }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void NotifyCollectionChanged(NotifyCollectionChangedAction action)
		{
			if (CollectionChanged != null)
			{
				CollectionChanged.Invoke(this, new NotifyCollectionChangedEventArgs(action));
			}
		}

		private void NotifyCollectionChanged(NotifyCollectionChangedAction action, TV item)
		{
			if (CollectionChanged != null)
			{
				CollectionChanged.Invoke(this, new NotifyCollectionChangedEventArgs(action, item));
			}
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;
	}
}
