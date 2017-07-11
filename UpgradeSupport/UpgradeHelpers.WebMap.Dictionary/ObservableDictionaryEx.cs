using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UpgradeHelpers.WebMap.Server
{

	/// <summary>
	/// Helper interface to facilitate interacting with the dictionary
	/// without the complication of the generic types
	/// </summary>
	#region ObservableDictionary
    [JsonConverter(typeof(ObservableDictionaryExSerializer))]
	public class ObservableDictionaryEx<TKey, TValue> :
				IDictionary<TKey, TValue>,
				IDependentModel,
				ICreatesObjects,
				IObservableDictionaryEntries, IInternalData, IInitializable, NoInterception, INotAutoWire, IReferenceWatcher, IDependentsContainer
    {

		IDictionary<TKey, TValue> implementation;
		public int CaseType { get; set; }
		public bool NotifyDeltas = true;
        private IStateManager stateManager;
        private IReferenceManager referenceManager;
        private ISurrogateManager surrogateManager;
		public void DeltaTrackerNotifications(bool onOff)
		{
			NotifyDeltas = onOff;
		}

        void IInitializable.Init()
        {
            //Init is only called on first object creation. The first time the Dictionary Header must be marked as dirty
            //TODO remove does not seem to be needed stateManager.Tracker.AttachModel(this, isDirty: true);
            Attached = true;
            NotifyDeltas = false;
        }


        private bool Attached;

        //Marks the list header (the one with the object count as dirty)
        private void MarkDictionaryHeaderAsDirty()
        {
            if (NotifyDeltas)
            {
                if (!Attached)
                {
                    //TODO remove does not seem to be needed stateManager.Tracker.AttachModel(this, isDirty: false);
                    Attached = true;
                }
                stateManager.MarkAsDirty(this, "Count");
            }
        }

        public IDictionary GetInternalDictionary(int caseType)
		{
			return ((IObservableDictionaryEntries)implementation).GetInternalDictionary(caseType);
		}



		public ObservableDictionaryEx()
		{
		}

        public void Initialize(IStateManager stateManager, IReferenceManager referenceManager, ISurrogateManager surrogateManager)
        {
            this.stateManager = stateManager;
            this.referenceManager = referenceManager;
            this.surrogateManager = surrogateManager;
            var tkey = typeof(TKey);
            var tvalue = typeof(TValue);

            var tkeyIsValueTypeOrStringOrTypeNotStruct = IsValueTypeOrStringOrTypeNotStruct(tkey);
            var tvalueIsValueTypeOrString = IsValueTypeOrStringOrType(tvalue);

            if (tkeyIsValueTypeOrStringOrTypeNotStruct && tvalueIsValueTypeOrString)
            {
                implementation = new DictCase1<TKey, TValue>();
                CaseType = 1;
            }
            else if (tkeyIsValueTypeOrStringOrTypeNotStruct &&
                                    (typeof(IStateObject).IsAssignableFrom(tvalue)
                                    || TypeCacheUtils.IsIListOrIDictionary(tvalue))


                                    )
            {
                implementation = new DictCase2<TKey, TValue>(stateManager,referenceManager);
                ((DictCase2<TKey, TValue>)implementation).SetParent(this);
                CaseType = 2;
            }
            else if (tkeyIsValueTypeOrStringOrTypeNotStruct && typeof(Delegate).IsAssignableFrom(tvalue))
            {
                implementation = new DictCase5<TKey, TValue>(stateManager,surrogateManager);

                CaseType = 5;
            }
            else if (typeof(IStateObject).IsAssignableFrom(tkey) && tvalueIsValueTypeOrString)
            {
                implementation = new DictCase3<TKey, TValue>();
                CaseType = 3;
            }
            else if (typeof(IStateObject).IsAssignableFrom(tkey)
                                    && (typeof(IStateObject).IsAssignableFrom(tvalue) || TypeCacheUtils.IsIListOrIDictionary(tvalue))
                                    )
            {
                implementation = new DictCase4<TKey, TValue>();
                CaseType = 4;
            }
            else if (tkeyIsValueTypeOrStringOrTypeNotStruct && SurrogatesDirectory.IsSurrogateRegistered(tvalue))
            {
                implementation = new DictCase6<TKey, TValue>(stateManager,surrogateManager,referenceManager);
                ((DictCase6<TKey, TValue>)implementation).SetParent(this);
                CaseType = 6;
            }
            else
                throw new NotSupportedException();

        }




        /// <summary>
        /// Indicates if this is a valid type combination
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal bool IsSupportedKeyValuePairDictionary(Type t)
        {
            if (t.IsGenericType)
            {
                var types = t.GetGenericArguments();
                var key = types[0];
                var value = types[1];
                var validKey = (IsValueTypeOrStringOrTypeNotStruct(key) || typeof(IStateObject).IsAssignableFrom(key));
                var validValue = (IsValueTypeOrStringOrType(value) || typeof(IStateObject).IsAssignableFrom(value) || SurrogatesDirectory.IsSurrogateRegistered(value));
                if (!validValue && value.IsGenericType)
                {
                    var genericValueType = value.GetGenericTypeDefinition();
                    if (genericValueType == typeof(IList<>))
                        validValue = TypeCacheUtils.IsSupportedGenericTypeForList(value);
                    else if (genericValueType == typeof(IDictionary<,>))
                    {
                        validValue = IsSupportedKeyValuePairDictionary(value);
                    }
                }
                return validKey && validValue;
            }
            throw new ArgumentException("This method should only be called for generic types");
        }

        public bool IsValueTypeOrStringOrTypeNotStruct(Type t)
		{
			return IsValueTypeOrStringOrType(t);
			//TODO check if it is struct
		}

		public bool IsValueTypeOrStringOrType(Type t)
		{
			return typeof(string) == t || typeof(Type) == t ||
				t.IsValueType;

		}

		public void Add(TKey key, TValue value)
		{
			implementation.Add(key, value);
            MarkDictionaryHeaderAsDirty();
		}

		public bool ContainsKey(TKey key)
		{
			return implementation.ContainsKey(key);

		}

		[StateManagement(StateManagementValues.None)]
		public ICollection<TKey> Keys
		{
			get
			{
				return implementation.Keys;
			}
		}

		public bool Remove(TKey key)
		{
			var res = implementation.Remove(key);
            if (res)
            {
                MarkDictionaryHeaderAsDirty();
            }
            return res;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return implementation.TryGetValue(key, out value);
		}

		[StateManagement(StateManagementValues.None)]
		public ICollection<TValue> Values
		{
			get
			{
				return implementation.Values;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return implementation[key];
			}
			set
			{
				if (key == null)
					throw new ArgumentNullException("IDictionary<K,V>::this[K key] Key argument cannot be null for a dictionary");
				implementation[key] = value;
                MarkDictionaryHeaderAsDirty();
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			implementation.Add(item);
            MarkDictionaryHeaderAsDirty();

		}

		public void Clear()
		{
			implementation.Clear();
            MarkDictionaryHeaderAsDirty();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return implementation.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
            //, MOBILIZE,09/26/2016,TODO,mvega,"Manually changed", "implementing this method to avoid exception" 
            implementation.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get
			{
				return implementation.Count;
			}
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			var res = implementation.Remove(item);
            if (res)
                MarkDictionaryHeaderAsDirty();
            return res;
        }

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return implementation.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return implementation.GetEnumerator();
		}


		public string UniqueID { get; set; }
		public IIocContainer Container { get; set; }

		public void UpdateReference(string oldUniqueID, string newUniqueID)
		{
            if (implementation is IReferenceWatcher)
            {
                ((IReferenceWatcher)implementation).UpdateReference(oldUniqueID, newUniqueID);
                MarkDictionaryHeaderAsDirty();
            }
		}
		public List<string> Dependents
		{
			get;
			set;
		}
	}
	#endregion

}
