using System;
using System.Collections.Generic;
using System.Diagnostics;
using UpgradeHelpers.Interfaces;
using System.IO;
using UpgradeHelpers.WebMap.Server.Common;
using System.Threading;
using System.Reflection;

namespace UpgradeHelpers.WebMap.Server
{
	internal class SurrogateManager : ISurrogateManager
	{
		StateManager _stateManager;

        public bool AllDependenciesAreProcessed = false;
        internal SurrogateManager(StateManager stateManager)
		{
			_stateManager = stateManager;
			this.GetSurrogateFor = this.GetSurrogateForBeforePersist;
			this._surrogateDependencyManager = new SurrogateDependencyManager(stateManager);
		}
		private Dictionary<object, StateObjectSurrogate> _surrogates = new Dictionary<object, StateObjectSurrogate>(ComparerByReference.CommonInstance);
		private Dictionary<string, StateObjectSurrogate> _surrogatesIdsToSurrogates = new Dictionary<string, StateObjectSurrogate>(StringComparer.Ordinal);
		internal SurrogateDependencyManager _surrogateDependencyManager;
		private ReaderWriterLockSlim surrogateDirectoryLock = new ReaderWriterLockSlim();
		private IList<StateObjectSurrogate> _surrogatesToBePersisted = null;
		HashSet<StateObjectSurrogate> lastMinuteSurrogates;


		internal void AddSurrogateReference(StateObjectSurrogate surrogate, string uniqueId)
		{
			lock (surrogate)
			{
				surrogate.AddReference(new LazyStateObjectReference(_stateManager, uniqueId));
			}
		}

		internal void AddSurrogateReference(StateObjectSurrogate surrogate, IStateObject reference)
		{
			lock (surrogate)
			{
				surrogate.AddReference(new LazyStateObjectReference(_stateManager, reference));
			}
		}

        public void AddSurrogateReference(IStateObjectSurrogate surrogate, IStateObject reference)
        {
            lock (surrogate)
            {
                ((StateObjectSurrogate)surrogate).AddReference(new LazyStateObjectReference(_stateManager, reference));
            }
        }

		/// <summary>
		/// Registers which pointers are using this surrogate.
		/// This is important because a surrogate with no references should be deleted
		/// </summary>
		/// <param name="surrogate"></param>
		/// <param name="pointer"></param>
		/// <param name="isNewPointer"></param>
		internal void AddSurrogateReference(StateObjectSurrogate surrogate, StateObjectPointer pointer, bool isNewPointer = true)
		{
			//Check if reference already exits
			lock (surrogate)
			{
				surrogate.AddReference(new LazyStateObjectReference(_stateManager, pointer));
			}
			//RegisterSurrogatedObject(surrogate, pointer.UniqueID);
			pointer.Target = surrogate;
			if (isNewPointer)
				_stateManager.AddNewObject(pointer);
			else if (StateManager.AllBranchesAttached(pointer))
				_stateManager.StorageManager.SaveObject(pointer);
			_stateManager.UndoRemove(pointer.UniqueID);
		}

		/// <summary>
		/// 
		/// </summary>
		internal void UpdateReference(IStateObject obj)
		{
			var pointer = obj as StateObjectPointer;
			if (pointer != null)
			{
				var surrogate = pointer.Target as StateObjectSurrogate;
				if (surrogate != null)
				{
					AddSurrogateReference(surrogate, pointer);
				}
			}
		}

		public void RemoveSurrogateReference(StateObjectSurrogate surrogate, IStateObject oldReference)
		{
			if (oldReference != null && surrogate!=null)
			{
				RemoveSurrogateReference(surrogate, oldReference.UniqueID);
			}
		}

        public void RemoveSurrogateReference(IStateObjectSurrogate surrogate, IStateObject reference)
        {
            RemoveSurrogateReference((StateObjectSurrogate)surrogate, reference);
        }
        public void RemoveSurrogateReference(StateObjectSurrogate surrogate, string uniqueIdOfLastReferent)
		{
			lock (surrogate)
			{
				surrogate.RemoveReference(uniqueIdOfLastReferent);
				if (surrogate.objectRefs.Count == 0)
					_stateManager.RemoveObject(surrogate.UniqueID, true);
			}
		}


        public void RemoveDependency(object surrogateValue, string uniqueIdOfLastReferent)
        {
            var surrogate = GetSurrogateFor(surrogateValue, generateIfNotFound: false);
            if (surrogate!=null)
                lock (surrogate)
                {
                    surrogate.RemoveReference(uniqueIdOfLastReferent);
                    if (surrogate.objectRefs.Count == 0)
                        _stateManager.RemoveObject(surrogate.UniqueID, true);
                }
        }
		/// <summary>
		/// Calculates the surrogates to be persisted or removes the ones that do not have valid references
		/// </summary>
		public void CalculateSurrogatesToBePersisted()
		{
			var currentSurrogates = new StateObjectSurrogate[_surrogates.Values.Count];
			_surrogates.Values.CopyTo(currentSurrogates, 0);
			bool removedSurrogate;
			//Step 1. Make sure that the surrogates have valid references, otherwise are removed.
			do
			{
				removedSurrogate = false;
				for (int i = currentSurrogates.Length - 1; i >= 0; i--)
				{
					var surrogate = currentSurrogates[i];
					if (surrogate == null)
						continue;
					lock (surrogate)
					{
						if (!surrogate.ShouldBeSerialized())
						{
							currentSurrogates[i] = null;
							removedSurrogate = true;
							//The surrogate won't persist and will be removed from the storage if present.
							_stateManager.RemoveObject(surrogate.UniqueID, false, true);
						}
					}
				}
			} while (removedSurrogate);
			//Step 2. Was there are removed surrogate? then make sure the remaining where not dependent of them.
			//No removed surrogates then this is the final list.
			_surrogatesToBePersisted = currentSurrogates;
		}

		internal void Persist()
		{
			this.GetSurrogateFor = this.GetSurrogateForAfterPersist;
			if (_surrogatesToBePersisted != null)
			{
				foreach (var surrogate in _surrogatesToBePersisted)
				{
					if (surrogate != null)
					{
						lock (surrogate)
						{
							_stateManager.StorageManager.SendToSurrogatesToBePersisted(surrogate);
						}
					}
				}
			}
			_stateManager.StorageManager.PersistSurrogates();
			_stateManager.AdoptionInformation.HandleSurrogateHolders();
			//Step 5. Save any new surrogates
			// Some surrogates might create new surrogates
			while (lastMinuteSurrogates != null)
			{
				HashSet<StateObjectSurrogate> lastMinuteSurrogatesCopy = new HashSet<StateObjectSurrogate>(lastMinuteSurrogates);
				lastMinuteSurrogates = null;
				foreach (var surrogate in lastMinuteSurrogatesCopy)
				{
					lock (surrogate)
					{
						if (surrogate.ShouldBeSerialized())
						{
							_stateManager.StorageManager.SendToSurrogatesToBePersisted(surrogate);
							//We remove the surrogate to avoid a double serialization. Two is enough. Because It might have been already serialized
							_surrogates.Remove(surrogate);
						}
						else
							throw new InvalidOperationException("A last minute surrogate must be an object worth serializing");
					}
				}
				_stateManager.StorageManager.PersistSurrogates();
				_stateManager.AdoptionInformation.HandleSurrogateHolders();
			}
		}

		internal void RemoveEntry(object reference, string uniqueId)
		{
			lock (this)
			{
				_surrogates.Remove(reference);
				_surrogatesIdsToSurrogates.Remove(uniqueId);
				_stateManager.RemoveObject(uniqueId, true);
			}

		}

		internal StateObjectSurrogate GetObject(string uniqueId, bool isOkForSurrogateToBeMissing = false)
		{
			StateObjectSurrogate surrogate;
			lock (this)
			{
				if (!_surrogatesIdsToSurrogates.TryGetValue(uniqueId, out surrogate))
				{
					surrogate = (StateObjectSurrogate)_stateManager.GetObjectRaw(uniqueId,isOkForSurrogateToBeMissing);
                    if (surrogate == null && isOkForSurrogateToBeMissing) return null;
					surrogate.Parent = _stateManager as IStateManager;
					if (_surrogates.ContainsKey(surrogate.Value))
					{
						TraceUtil.TraceInformation("Inconsistency in surrogates tables");
					}
					else
						_surrogates.Add(surrogate.Value, surrogate);
					_surrogatesIdsToSurrogates.Add(uniqueId, surrogate);
				}
			}
			return surrogate;
		}
		internal delegate StateObjectSurrogate GetSurrogateForDelegate(object newValueObject, bool generateIfNotFound, string parentSurrogate = null);

		internal GetSurrogateForDelegate GetSurrogateFor;

		private StateObjectSurrogate GetSurrogateForAfterPersist(object newValueObject, bool generateIfNotFound, string parentSurrogate = null)
		{
			StateObjectSurrogate surrogate;
			lock (this)
			{
				if (_surrogates.TryGetValue(newValueObject, out surrogate))
				{
					//The surrogate could exist but it was not worthy of serialization
                    //In old times, surrogates were in charge of serialization and reference management
                    //Now these dependencies are handle in the SurrogateDependencyManager.
                    //So we now asumme we should not validate if the surrogate is worthy or not.
                    return surrogate;
				}
				if (generateIfNotFound)
				{
#if DEBUG
                    if (AllDependenciesAreProcessed)
                    {
                        Debug.WriteLine("Invalid surrogate reference. This might be caused by a calculated property that is being call to get an object JSON. Please analyze the callstack and make the proper code changes.\r\nCall Stack: \r\n: {0}", new StackTrace(true).ToString());
                    }
#endif


                    //was it that it is present but was not worthy?
                    if (surrogate != null)
					{
						if (lastMinuteSurrogates == null || !lastMinuteSurrogates.Contains(surrogate))
						{
							//We need to update the UniqueID
							if (parentSurrogate != null)
							{
								surrogate.UniqueID = "!" + _stateManager.UniqueIDGenerator.GetUniqueID() + UniqueIDGenerator.UniqueIdSeparator + parentSurrogate;

                                if (surrogate.UniqueID.StartsWith("!r"))
                                {
                                    Trace.WriteLine("Surrogate = " + surrogate.UniqueID);
                                    Trace.WriteLine(new StackTrace(true).ToString());
                                }



								_surrogates[surrogate.Value] = surrogate;
								_surrogatesIdsToSurrogates[surrogate.UniqueID] = surrogate;
							}
						}
					}
					else
					{
						var parentSurrogateUniqueID = (parentSurrogate == null ? "" : UniqueIDGenerator.UniqueIdSeparator + parentSurrogate);
						_surrogates.Add(newValueObject,
							surrogate =
								new StateObjectSurrogate
								{
									UniqueID = "!" + _stateManager.UniqueIDGenerator.GetUniqueID() + parentSurrogateUniqueID,
									Value = newValueObject
								});

     
						_surrogatesIdsToSurrogates.Add(surrogate.UniqueID, surrogate);

					}
					//Add to last minute surrogate
					lastMinuteSurrogates = lastMinuteSurrogates ?? new HashSet<StateObjectSurrogate>(ComparerByReference.CommonInstance);
					if (parentSurrogate != null)
						_stateManager.surrogateManager.AddSurrogateReference(surrogate, parentSurrogate);
					lastMinuteSurrogates.Add(surrogate);
				}
			}
			return surrogate;
		}



		/// <summary>
		/// Retrieves or creates a surrogate object for a value
		/// </summary>
		/// <param name="newValueObject"></param>
		/// <param name="generateIfNotFound"></param>
		/// <returns></returns>
		private StateObjectSurrogate GetSurrogateForBeforePersist(object newValueObject, bool generateIfNotFound, string parentSurrogate = null)
		{
#if DEBUG
			Debug.Assert(newValueObject != null, "Surrogates cannot be registered for null values");
#endif

			StateObjectSurrogate surrogate;
			lock (this)
			{
				if (_surrogates.TryGetValue(newValueObject, out surrogate))
				{
					return surrogate;
				}
				if (generateIfNotFound)
				{
#if DEBUG
                    if (AllDependenciesAreProcessed)
                    {
                        Debug.WriteLine("Invalid surrogate reference. This might be caused by a calculated property that is being call to get an object JSON. Please analyze the callstack and make the proper code changes.\r\nCall Stack: \r\n: {0}", new StackTrace(true).ToString());
                    }
#endif
                    surrogateDirectoryLock.EnterUpgradeableReadLock();
					try
					{
						surrogateDirectoryLock.EnterWriteLock();
						try
						{
							var parentSurrogateUniqueID = (parentSurrogate == null ? "" : UniqueIDGenerator.UniqueIdSeparator + parentSurrogate);
							_surrogates.Add(newValueObject,
								surrogate =
									new StateObjectSurrogate
									{
										UniqueID = "!" + _stateManager.UniqueIDGenerator.GetUniqueID() + parentSurrogateUniqueID,
										Value = newValueObject
									});

							//REMOVE _stateManager.AddNewObject(surrogate); //TODO Add in stateManager not mark as dirty because all surrogates are dirty
							//We need to add the uniqueID to the surrogatesIdsToSurrogates
							//because this table is used to match surrogates instances to their
							//corresponding uniqueid because obviously surrogates do not have the uniqueId property
							_surrogatesIdsToSurrogates.Add(surrogate.UniqueID, surrogate);
						}
						finally
						{
							surrogateDirectoryLock.ExitWriteLock();
						}
					}
					finally
					{
						surrogateDirectoryLock.ExitUpgradeableReadLock();
					}
					//Trace.TraceInformation("A new surrogate ID {0} for object of type {1} has been created", surrogate.UniqueID, newValueObject.GetType());
				}
			}
			return surrogate;
		}

		/// <summary>
		/// Processes all types in search for the ones that implement ISurrogateRegistration
		/// </summary>
		/// <param name="typesToRegister"></param>
		internal static void RegisterSurrogates(IEnumerable<Type> typesToRegister)
		{
			foreach (var typeToRegister in typesToRegister)
			{
				if (!typeToRegister.IsAbstract && !typeToRegister.IsInterface && typeToRegister.IsClass &&
					typeof(ISurrogateRegistration).IsAssignableFrom(typeToRegister))
				{
					try
					{
						ISurrogateRegistration surrogatesRegistration = (ISurrogateRegistration)Activator.CreateInstance(typeToRegister);
						surrogatesRegistration.Register();
					}
					catch (Exception e)
					{
						TraceUtil.TraceError("SurrogateManager::RegisterSurrogates Error registering surrogates " + typeToRegister.FullName + " message " + e.Message);
					}
				}
			}
		}

		/// <summary>
		/// Replaces the surrogate pointer references from one pointer to another.  This method is called 
		/// every time a pointer is promoted because its parent object has been attached to a view model object.
		/// </summary>
		/// <param name="pointerOldUniqueId">Unique id of the object that was not attached.</param>
		/// <param name="pointerNewUniqueId">Uniqued Id of the object pointer once attached.</param>
		public void UpdateDependantSurrogatePointerReferences(string pointerOldUniqueId, string pointerNewUniqueId, IStateObject value)
		{
			// lets check if it is a pointer if it is registered as surrogate object pointer.
			if (value != null && UniqueIDGenerator.IsPointer(pointerOldUniqueId))
			{
				StateObjectPointer ptr = (StateObjectPointer)value;
				var surrogate = ptr.Target as StateObjectSurrogate;
				if (surrogate != null)
				{
					lock (surrogate)
					{
						foreach (var objectRef in surrogate.objectRefs)
						{
							if (objectRef.UniqueID == pointerOldUniqueId)
							{
								objectRef.UniqueID = pointerNewUniqueId;
							}
						}
					}
				}
			}
		}


		/// <summary>
		/// Adds a reference between two surrogates.
		/// </summary>
		/// <param name="referenceValue">The value of referenced object</param>
		/// <param name="currentValue">The value of referencing object</param>
		/// <param name="referenceUniqueID">Sets the Id of the resulting reference surrogate</param>
		/// <returns>The Id of the current value surrogate</returns>
		public string HandleReference(object referenceValue, object currentValue, out string referenceUniqueID)
		{
			string currentUniqueID = null;

			//Lets find the surrogate for the current object.
			var currentSurrogate = GetSurrogateFor(currentValue, generateIfNotFound: false);
			currentUniqueID = currentSurrogate.UniqueID;

			var referenceSurrogate = GetSurrogateFor(referenceValue, generateIfNotFound: false);

			if (referenceSurrogate == null)
			{
				//Creates and saves the surrogate if doesn't exist. Creates ID referencing its parent
				referenceSurrogate = GetSurrogateFor(referenceValue, generateIfNotFound: true);
			}

			//Updates surrogate references and adds it to the saving list
			AddSurrogateReference(referenceSurrogate, currentUniqueID);

			referenceUniqueID = referenceSurrogate.UniqueID;
			return currentUniqueID;
		}

		/// <summary>
		/// Wires a handler to its respective event
		/// </summary>
		/// <typeparam name="T">The type of the event handler</typeparam>
		/// <param name="eventName">The name of the event to be wired</param>
		/// <param name="value">The instance of the object to be wired</param>
		/// <param name="surrogate">The surrogate that contains the event handler</param>
		public void WireEvent<T>(string eventId, string eventName, object value)
		{
			var events = (EventAggregator)ViewManager.Instance.Events;

			//1. Get the event information
			var eventInfo = value.GetType().GetEvent(eventName);
			if (eventInfo != null)
			{
				//2. Get the handler delegate from storage
				var eventDelegate = events.PublishDelegate<T>(eventId);
				if (eventDelegate != null)
				{
					//3. Wire the event handler to the instance
					var addMethod = eventInfo.GetAddMethod();
					addMethod.Invoke(value, new object[] { eventDelegate });
				}
			}
		}

		internal Dictionary<object, StateObjectSurrogate> GetSurrogates()
		{
			return _surrogates;
		}


		#region Implementation of SurrogateManager
		public bool SupportsBinding(object surrogateValue)
		{
			return SurrogatesDirectory.SupportsBinding(surrogateValue);
		}
		public void RegisterSurrogate(string signature, Type supportedType, Action<object, Action<bool>> applyBindingAction = null, Func<object, string, object> PropertyGetter = null, Action<object, string, object> PropertySetter = null)
		{
			SurrogatesDirectory.RegisterSurrogate(signature, supportedType, applyBindingAction, PropertyGetter, PropertySetter);
		}

		public bool IsSurrogateRegistered(Type supportedType)
		{
			return SurrogatesDirectory.IsSurrogateRegistered(supportedType);
		}

		public IStateObjectSurrogate GetStateObjectSurrogate(object newValueObject, bool generateIfNotFound, string parentSurrogate = null)
		{
			return this.GetSurrogateFor(newValueObject, generateIfNotFound, parentSurrogate) as IStateObjectSurrogate;
		}

		public string ValidSignature(string signature)
		{
			return SurrogatesDirectory.ValidSignature(signature);
		}

		public object ObjectToRaw(string surrogateUniqueID, object obj)
		{
			var surrogateContext = GetSurrogateContext(surrogateUniqueID,obj);
			return SurrogatesDirectory.ObjectToRaw(obj, surrogateContext);
		}

		public object RawToObject(string surrogateUniqueID,object raw)
		{
			var context = this.GetSurrogateContext(surrogateUniqueID);
			return SurrogatesDirectory.RawToObject(raw, context);
		}

		public object RestoreSurrogate(string uniqueId)
		{
			return SurrogatesDirectory.RestoreSurrogate(uniqueId);
		}

        public string GetUniqueIdForSurrogate(object obj, string parentUniqueId = null, bool generateIfNotFound = true)
		{
			return SurrogatesDirectory.GetUniqueIDForSurrogateDelegate(obj, parentUniqueId,generateIfNotFound);
		}

		public Func<object, string, object> GetPropertyGetter(object obj)
		{
			return SurrogatesDirectory.GetPropertyGetter(obj);
		}

		public Action<object, string, object> GetPropertySetter(object obj)
		{
			return SurrogatesDirectory.GetPropertySetter(obj);
		}

		public void ApplyBindingHandlers(object surrogateValue, Action<bool> bindingAction)
		{
			SurrogatesDirectory.ApplyBindingHandlers(surrogateValue, bindingAction);
		}

		#endregion

		internal IStateObject GetSurrogateFirstReference(StateObjectSurrogate obj)
		{
			lock (obj)
			{
				return _stateManager.GetObject(obj.objectRefs[0].UniqueID);
			}
		}

		internal ISurrogateContext GetSurrogateContext(string uniqueID, object value = null)
		{
			return new UpgradeHelpers.WebMap.Server.Surrogates.SurrogateContext()
			{
                SurrogateUniqueID = uniqueID,
				Value = value,
				DependencyManager = this._surrogateDependencyManager,
				_stateManager = _stateManager,
				_viewManager = ViewManager.Instance,
				_surrogateManager = this
			};
		}


        public string GetUniqueIdForSurrogate(object obj, string parentUniqueId = null)
        {
            return GetUniqueIdForSurrogate(obj, parentUniqueId, true);
        }

		internal void Dispose()
		{
			this._stateManager = null;
			this._surrogates = null;
			this._surrogatesIdsToSurrogates = null;
			this.lastMinuteSurrogates = null;
			if (_surrogatesToBePersisted != null)
			{
				Array.Clear((Array)this._surrogatesToBePersisted, 0, this._surrogatesToBePersisted.Count);
			this._surrogatesToBePersisted = null;
			}
			this._surrogateDependencyManager.Dispose();
		}
	}
}