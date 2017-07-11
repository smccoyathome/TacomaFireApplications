using System;
using System.Diagnostics;
using Microsoft.Practices.Unity.InterceptionExtension;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using System.Collections.Generic;

namespace UpgradeHelpers.WebMap.Server
{
	internal static class LazyBehaviours
	{
		internal static bool ProcessGetterNoAction(PropertyInfoEx propEx, object parentObject, ref Object lastValue)
		{
			return false;
		}

		internal static bool ProcessGetterTopLevelIStateObject(PropertyInfoEx propEx, object parentObject, ref Object lastValue)
		{
			if (lastValue == null)
			{
				var prop = propEx.prop;
				var parentInstance = parentObject as IStateObject;
				if (typeof(IStateObject).IsAssignableFrom(prop.DeclaringType))
				{
					Type returnType = prop.PropertyType;
					var stateManager = StateManager.Current;
					var attributes = returnType.GetCustomAttributes(typeof(Singleton), false);
					if (attributes.Length > 0)
					{
						var cachedValue = stateManager.GetObject(UniqueIDGenerator.GetSinglentonUniqueId(returnType));
						lastValue = cachedValue;
						return true;
					}
					else
					{
						var propName = GetPropertyName(propEx);
						var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
						var pointer = (StateObjectPointer)stateManager.GetObject(relativeUid);
						if (pointer != null)
						{
							var cachedValue = TryToRecoverWithPointer(stateManager, propEx, parentInstance, false, pointer: pointer);
							lastValue = cachedValue;
							return true;
						}
					}
				}
			}
			return false;
		}

		internal static bool ProcessGetterWeakReference(PropertyInfoEx propEx, object parentObject, ref Object lastResult)
		{
			var parentInstance = parentObject as IStateObject;
			var prop = propEx.prop;
			Type returnType = prop.PropertyType;
			string propName = GetPropertyName(propEx);
			//Try to recover
			//1. First recover pointer
			//2. Then get surrogate
			string relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
			var stateManager = StateManager.Current;
			var pointer = (StateObjectPointer)stateManager.GetObject(relativeUid);
			if (pointer != null)
			{
				if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
				{
					stateManager.isServerSideOnly.Add(pointer);
				}
				//Extend to support other types
				var cachedValue = TryToRecoverWithPointer(stateManager, propEx, parentInstance, false, false, pointer: pointer);
				lastResult = cachedValue;
				return true;
			}
			else
			{
				//There was no pointer, then return null
				lastResult = null;
				return true;
			}
		}

		internal static bool ProcessGetterStrongReference(PropertyInfoEx propEx, object parentObject, ref Object lastResult)
		{
			var prop = propEx.prop;
			var parentInstance = parentObject as IStateObject;
			string propName = GetPropertyName(propEx);
			//Try to recover
			//1. First recover pointer
			//2. Then get surrogate
			string relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
			var stateManager = StateManager.Current;
			var pointer = (StateObjectPointer)stateManager.GetObject(relativeUid);
			if (pointer != null)
			{
				if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
				{
					stateManager.isServerSideOnly.Add(pointer);
				}
				//Extend to support other types
				var cachedValue = TryToRecoverWithPointer(stateManager, propEx, parentInstance, false, false, pointer: pointer);
				lastResult = cachedValue;
				return true;
			}
			else
			{
				//There was no pointer, then return null
				lastResult = null;
				return true;
			}
		}

		internal static bool ProcessGetterSurrogate(PropertyInfoEx propEx, object parentObject, ref Object lastResult)
		{
			if (lastResult == null)
			{
				var prop = propEx.prop;
				var parentInstance = parentObject as IStateObject;
				Type returnType = prop.PropertyType;
				string propName = GetPropertyName(propEx);
				//Try to recover
				//1. First recover pointer
				//2. Then get surrogate
				string relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
				var stateManager = StateManager.Current;
				var pointer = (StateObjectPointer)stateManager.GetObject(relativeUid);
				if (pointer != null)
				{
					var cachedValue = TryToRecoverWithPointer(stateManager, propEx, parentInstance, true, pointer: pointer);
					lastResult = cachedValue;
					return true;
				}
			}
			return false;
		}

		internal static bool ProcessGetterNonTopLevelIStateObject(PropertyInfoEx propEx, object parentObject, ref Object lastResult)
		{

			//Here we need to introduce an exception.
			//We can have a property that has a PropertyType that is NOT an IStateObject
			//for example an IList
			//We have taken the decision that all IList<SomeObjectThatImplementsIStateObject>
			//will have an implementation class that is an IStateObject
			//so we need to add that check
			object cachedValue = lastResult; //propEx.OriginalGetter(parentObject);
			bool result = false;
			//If the cached value is null or it's a reference, we need to try to get it again.
			if (cachedValue == null)
			{
				var parentInstance = parentObject as IStateObject;
				var stateManager = StateManager.Current;
				string relaviteUID = null;
				cachedValue = GetCurrentValue(stateManager, propEx, parentInstance, out relaviteUID);
				if (cachedValue is StateObjectPointerReference)
				{
					cachedValue = TryToRecoverWithPointer(stateManager, propEx, parentInstance, false, false, pointer: (StateObjectPointerReference)cachedValue);
				}
				else
				{
					//If the value Tagged as server side only?
					//We must track because it could also be assigned into lists, dictionaries or references
					if (cachedValue != null)
					{
						if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
							stateManager.isServerSideOnly.Add((IStateObject)cachedValue);
						var events = ViewManager.Instance.Events;
						try
						{
							events.Suspend();
							propEx.OriginalSetter(parentObject, cachedValue);
						}
						finally
						{
							events.Resume();
						}
					}
				}
				lastResult = cachedValue;
				result = true;

			}
			return result;
		}

		/// <summary>
		/// Tries to recover an StateObject instance thru an StateObjectPointer
		/// </summary>
		/// <param name="input"></param>
		/// <param name="propEx"></param>
		/// <param name="parentInstance"></param>
		/// <param name="forSurrogate"></param>
		/// <param name="updateProperty"></param>
		/// <returns></returns>
		internal static object TryToRecoverWithPointer(StateManager stateManager, PropertyInfoEx propEx, IStateObject parentInstance, bool forSurrogate, bool updateProperty = true, StateObjectPointer pointer = null)
		{
			object cachedValue = null;
			StateObjectSurrogate surrogate = null;
			if (pointer != null)
			{
				if (forSurrogate)
				{
					surrogate = (StateObjectSurrogate)pointer.Target;
					cachedValue = surrogate.Value;
				}
				else
				{
					var superValuePointer = pointer as StateObjectPointerReferenceSuperValueBase;
					if (superValuePointer != null)
					{
						if (superValuePointer is StateObjectPointerReferenceSuperValue)
							cachedValue = superValuePointer.SuperTarget;

						else if (superValuePointer is StateObjectPointerReferenceSuperSurrogate)
							cachedValue = (superValuePointer.SuperTarget as StateObjectSurrogate).Value;

						else if (superValuePointer is StateObjectPointerReferenceSerializable)
							cachedValue = superValuePointer.SuperTarget;

						if (cachedValue == null) //Reference is pointing to nothing so lets get rid of it
							stateManager.RemoveObject(pointer.UniqueID, true);
					}
					else
					{
						cachedValue = pointer.Target;
						if (cachedValue == null) //Reference is pointing to nothing so lets get rid of it
						{
							stateManager.RemoveObject(pointer.UniqueID, true);
						}
						///Added to support cases in that the referenced object is a Surrogate
						else if (cachedValue is StateObjectSurrogate)
						{
							surrogate = (StateObjectSurrogate)pointer.Target;
							cachedValue = surrogate.Value;
							forSurrogate = true;
						}
					}
				}
				if (updateProperty)
					propEx.OriginalSetter(parentInstance, cachedValue);
				if (forSurrogate)
					stateManager.AttachBindingBehaviourForSurrogate(surrogate, cachedValue);
			}
			return cachedValue;
		}

		internal static void ProcessSetterSimpleTypes(PropertyInfoEx propEx, object parentObject, object newObjectValue, bool isNew = false)
		{
			if (isNew)
				return;
			string propName = propEx.prop.Name;
			var parentInstance = (IStateObject)parentObject;
			var tracker = StateManager.Current.Tracker;
			// Delta Tracking of modified property
			if (!tracker.IsDirtyModel(parentInstance))
			{
				tracker.MarkAsModified(parentInstance, propEx.propertyPositionIndex);
			}
			var stateManager = StateManager.Current;
			if (!stateManager.flagInBind)
			{
				var bindinguid = UniqueIDGenerator.GetRelativeUniqueID(parentInstance, propName + StateManager.BindingKey);
				var bindingPointer = StateManager.Current.GetObject(bindinguid) as StateObjectPointer;
				if (bindingPointer != null)
				{
					var bindingSurrogate = bindingPointer.Target as StateObjectSurrogate;
					if (bindingSurrogate != null)
					{
						var binding = bindingSurrogate.Value as DataBinding;
						if (binding != null)
						{
							var dataSource = binding.DataSourceReference;
							if (dataSource is StateObjectSurrogate)
							{
								var surrogate = (StateObjectSurrogate)dataSource;
								var surrogateValue = surrogate.Value;
								var setter = SurrogatesDirectory.GetPropertySetter(surrogate.Value);
								setter(surrogateValue, binding.DataSourceProperty, newObjectValue);
							}
							else
								throw new NotImplementedException();
						}
					}
				}
			}
		}

		private static IStateObject GetCurrentValue(StateManager stateManager, PropertyInfoEx propEx, IStateObject parentInstance, out string valueRelativeUid, bool isNew = false)
		{
			var propName = GetPropertyName(propEx);
			valueRelativeUid = UniqueIDGenerator.GetRelativeUniqueID(parentInstance, propName);
			//First Try: Let's get the object from the Storage.
			var currentValue = stateManager.GetObject(valueRelativeUid);
			if (currentValue == null)
			{
				var pointerRelativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
				//Second try: get the Reference if present.
				currentValue = stateManager.GetObject(pointerRelativeUid, isNew: isNew);
			}
			return currentValue;
		}

		private static string GetPropertyName(PropertyInfoEx prop)
		{
			if (prop.alias != null)
				return prop.alias;
			else
				return prop.prop.Name;
		}
		internal static void ProcessSetterMostCases(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			var parentInstance = parentObject as IStateObject;
			var stateManager = StateManager.Current;

			//Let's promote this newObject.
			string valueRelativeUid = null;
			bool isReferencePresent = false;
			var oldValue = GetCurrentValue(stateManager, propEx, parentInstance, out valueRelativeUid, isNew);
			//First case: Both values are null. This is the fastest scenario.
			if (oldValue == null && newValueObject == null)
				return;
			var newValue = newValueObject as IStateObject;
			//Second case: The values are the sa,e value.
			if (Object.ReferenceEquals(oldValue, newValueObject) || (oldValue != null && newValue != null && oldValue.UniqueID == newValue.UniqueID))
			{ /*Nothing to do.*/
				return;
			}
			//Third: If the oldValue is not null then we need to remove the Reference or the IStateObject.
			if (oldValue != null)
			{
				if (oldValue is StateObjectPointerReference)
				{
					stateManager.ReferencesManager.RemoveReference(oldValue, ((StateObjectPointerReference)oldValue).Target);
					if (newValue == null)//If the value is null, lets remove it as well
						stateManager.RemoveObject(oldValue.UniqueID, true);
					else
						isReferencePresent = true;
				}
				else
					stateManager.RemoveObject(oldValue.UniqueID, true);
			}
			//Forth: If the newValue is null at this point, we are done.
			if (newValue == null)
				return;
			//If the newValue is not null, lets process it.
			else
			{
				//Verify that the old_Uid is not null
				if (newValue.UniqueID == null)
				{
					ReportInvalidStateObject(propEx, newValue);
					return;
				}
				//It's attached..Then let's generate a reference.
				if (StateManager.IsAttached(newValue)
					//A child element should NEVER adopt its parent. Cyclic references.
					|| StateManager.IsChild(newValue.UniqueID, parentInstance.UniqueID)
					//The ID is resolution, so let's not adoot it.
					|| stateManager.IsIDInResolution(newValue.UniqueID))
					////Lets create or update a reference if exists.
					AddOrUpdateReference(propEx, parentInstance, newValue, isReferencePresent ? (StateObjectPointerReference)oldValue : null, isNew: isNew);
				else
				{
					//Only dependantStateObjects will be marked as dependants
					if (propEx.isAssignableFromIDependantStateObject || (newValue is IDependentStateObject))
					{
						stateManager.SwitchOrPromoteObject(newValue, valueRelativeUid);
						//If the property is masked as ServerOnly, let's notify that to the StateManager.
						if (isReferencePresent)
							stateManager.RemoveObject(oldValue.UniqueID, true);
						if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
							stateManager.isServerSideOnly.Add(newValue);
						if (oldValue == null)
						{
							AddDependent(parentInstance, GetPropertyName(propEx));
						}
					}
					else
						//...Otherwise let's create a Reference.
						AddOrUpdateReference(propEx, parentInstance, newValue, isReferencePresent ? (StateObjectPointerReference)oldValue : null, isNew: isNew);
				}
			}
		}

		public static  void AddDependent(IStateObject parentInstance, string dependent)
		{
			var interceptableObject = parentInstance as IDependentsContainer;
			List<string>  dependents = null;
			if (interceptableObject != null)
			{
				StateManager.Current.Tracker.MarkEntityForPersist(parentInstance);
				if ((dependents = interceptableObject.Dependents) == null)
				{
					dependents = new List<string>();
					interceptableObject.Dependents = dependents;
				}
				if (!dependents.Contains(dependent))
				{
					dependents.Add(dependent);
				}
			}
		}
		private static void ReportInvalidStateObject(PropertyInfoEx propEx, IStateObject newValue)
		{
			var stackTrace = new System.Diagnostics.StackTrace(3, true);
			throw new InvalidOperationException(
					"LazyBehaviour::ProcessSetter old_Uid was null. This might happen if the ViewModel is instantiated with new instead of using Container.Resolve<T>.\r\n" +
					"Additional Info: \r\n" +
					"ViewModel Type: " + newValue.GetType().FullName + "\r\n" +
					"Property Type: " + propEx.prop.PropertyType.FullName + "\r\n" +
					"Error Location: " + stackTrace.ToString());
		}

		private static void ReportOwnerException(PropertyInfoEx propEx, IStateObject newValue, string old_Uid)
		{
			var stackTrace = new System.Diagnostics.StackTrace(4, true);

			var ownerInfo = " Not owner info available";
			var ownerObject = StateManager.Current.GetParentEx(newValue);
			if (ownerObject != null)
			{

				var format =
					" The owner of the object is an instance of class {0}, it is {1}. Look for property {2}. It could have been set during a Build call that is still of process or during an Initialize.Init which is the WebMap equivalent of a constructor. If it is used as parent reference reimplement the property as a non virtual, [StateManagement(None)] calculated property using ViewManager.GetParent(), you can also use [Reference] attribute or disable interception by removing virtual from the property";
				if (StateManager.AllBranchesAttached(ownerObject))
				{
					ownerInfo = string.Format(format,
						TypeCacheUtils.GetOriginalTypeName(ownerObject.GetType()), " ATTACHED ",
						StateManager.GetLastPartOfUniqueID(newValue));
				}
				else
				{
					ownerInfo = string.Format(format, "NOT ATTACHED",
						TypeCacheUtils.GetOriginalTypeName(ownerObject.GetType()),
						StateManager.GetLastPartOfUniqueID(newValue));

				}
			}
			throw new InvalidOperationException(
					"LazyBehaviour::ProcessSetter object has already an Owner." + ownerInfo + "\r\n" +
					"UniqueID: " + old_Uid + "\r\n" +
					"Additional Info: \r\n" +
					"ViewModel Type: " + newValue.GetType().FullName + "\r\n" +
					"Property Type: " + propEx.prop.PropertyType.FullName + "\r\n" +
					"Error Location: " + stackTrace.ToString());
		}

		internal static void ProcessSetterSurrogate(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			//TODO might do direct cast without as. That will be slightly faster
			var parentInstance = parentObject as IStateObject;
			var stateManager = StateManager.Current;
			var uuidgen = stateManager.UniqueIDGenerator;
			string propName = GetPropertyName(propEx);

			var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
			var pointer = (StateObjectPointer)stateManager.GetObject(relativeUid, isNew: isNew);


			if (newValueObject == null)
			{
				//Here we need to remove the surrogate reference if available
				if (propEx.hasReferenceAttribute)
				{
					//However we do no have yet implemented support for Surrogates along with references
					throw new NotSupportedException();
					//TODO
				}
				//If there was a value there was a pointer
				//Surrogates are always accessed thu a pointer
				if (pointer != null)
				{
					//Retrieve surrogate
					var surrogate = (StateObjectSurrogate)pointer.Target;
					//Decrease surrogate references //If references drops to 0. Then remove surrogate
					stateManager.surrogateManager.RemoveSurrogateReference(surrogate, pointer);
					//Eliminate pointer
					stateManager.RemoveObject(pointer.UniqueID, true);
				}
			}
			else
			{
				bool somethingToDo = true;
				//Was there a previous value? If there was one then there was a pointer.
				//If not we need one now.
				if (pointer == null)
				{
					pointer = new StateObjectPointer();
					AddDependent(parentInstance, UniqueIDGenerator.REFERENCEPrefix + GetPropertyName(propEx));
					StateObjectPointer.AssignUniqueIdToPointer(parentInstance, relativeUid, pointer);
				}
				else
				{
					//I need to validate that the surrogate is the same and if not decrease reference
					//First lets see if this is same object
					var oldsurrogate = (StateObjectSurrogate)pointer.Target;
					if (oldsurrogate != null)
					{
						if (Object.ReferenceEquals(oldsurrogate.Value, newValueObject))
						{
							//Nothing to do
							somethingToDo = false;
						}
						else
						{
							//Retrieve surrogate
							StateObjectSurrogate surrogate = stateManager.surrogateManager.GetSurrogateFor(newValueObject, generateIfNotFound: true);
							if (surrogate == null) throw new Exception("Object must be instantiated/registered with resolve");
							//Add reference if needed
							stateManager.surrogateManager.AddSurrogateReference(surrogate, pointer, false);
							stateManager.RebindSurrogateReference(oldsurrogate, surrogate, pointer);
							somethingToDo = false;
						}
					}
					else
					{
						throw new InvalidOperationException("Pointer is broken. It should point to an existing surrogate");
					}
				}

				if (somethingToDo)
				{
					//Retrieve surrogate
					StateObjectSurrogate surrogate = stateManager.surrogateManager.GetSurrogateFor(newValueObject, generateIfNotFound: true);
					if (surrogate == null) throw new Exception("Object must be instantiated/registered with resolve");
					//Add reference if needed
					stateManager.surrogateManager.AddSurrogateReference(surrogate, pointer, false);
				}
			}

		}

		internal static void ProcessSetterObjectReference(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			var parentInstance = parentObject as IStateObject;
			AddOrUpdateReference(propEx, parentInstance, newValueObject, isNew: isNew);
		}

		/// <summary>
		/// Gets a Reference for an specified value and property.
		/// </summary>
		/// <param name="propEx">The property associated to the value being set.</param>
		/// <param name="parentInstance">The parent instance of the property</param>
		/// <param name="newValueObject">The new value for the property.</param>
		/// <returns></returns>
		private static StateObjectPointerReference GetReference(PropertyInfoEx propEx, IStateObject parentInstance, object newValueObject)
		{
			StateObjectPointerReference reference = null;
			string name = GetPropertyName(propEx);
			var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, name);
			AddDependent(parentInstance, UniqueIDGenerator.REFERENCEPrefix + name);
			//Let's try to cast the element to IStateObject
			var newValue = newValueObject as IStateObject;
			//It's an IList, IDisctionary or an IStateObject or the Value is an IStateObject
			if (propEx.isStateObject || propEx.isAnIList || propEx.isAnIDictionary || newValue != null)
				reference = new StateObjectPointerReference();
			//It's a value type or type.
			else if (propEx.isNonStateObjectFixedType)
				reference = new StateObjectPointerReferenceSuperValue();
			//It's declared as an Object.
			else if (propEx.isObjectPropertyType)
			{
				var newValueType = newValueObject.GetType();
				//If the Value is an IStateObject
				if (newValueType.IsValueType || newValueType == typeof(string) || newValueType == typeof(Type))
				{
					if (TypeCacheUtils.IsAnUserStructType(propEx.prop.PropertyType))
					{
						reference = new StateObjectPointerReferenceSuperStruct();
					}
					else
					{
						reference = new StateObjectPointerReferenceSuperValue();
					}
				}
				//It's a registered surrogated.
				else if (SurrogatesDirectory.IsSurrogateRegistered(newValueType))
					reference = new StateObjectPointerReferenceSuperSurrogate();
				else
					reference = new StateObjectPointerReferenceSerializable();
			}
			else //Not supported type
			{
				var stackTrace = new StackTrace(3, true);
				throw new InvalidOperationException(
					"LazyBehaviour::ProcessSetter Property with reference attribute receive a value of unsupported type.\r\n" +
					"Additional Info: \r\n" +
					"Value Type: " + propEx.prop.PropertyType.FullName + "\r\n" +
					"Property Type: " + GetPropertyName(propEx) + "\r\n" +
					"Error Location: " + stackTrace);
			}
			//If it has the StateManagement attribute set as ServerOnly, then let's respect that.
			if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
				StateManager.Current.isServerSideOnly.Add(reference);
			//Let's set the UniqueID to the new reference.
			StateObjectPointer.AssignUniqueIdToPointer(parentInstance, relativeUid, reference);
			//Let's return the pointer of the desired type.
			return reference;
		}

		internal static void UpdateReferenceValue(StateManager stateManager, StateObjectPointerReference reference, IStateObject parentInstance, object newValueObj, bool shouldAddReference = true)
		{
			var tracker = stateManager.Tracker;
			var newValue = newValueObj as IStateObject;
			//Let's update the referece Target.
			if (reference is StateObjectPointerReferenceSuperValueBase)
			{
				//The value is not an IStateObject let's use the original value.
				((StateObjectPointerReferenceSuperValueBase)reference).SuperTarget = newValueObj;
				//If the model is not Dirty let's mark it as modified.
				tracker.MarkAsModified(reference, "SuperTarget");
				// Not being implemented in case property is IStateObject, review sets before
			}
			else
			{
				//Once we have a pointer make the newValue its new target
				reference.Target = newValue;
				// Here we will try to manage posible orphans assigned to Pointers
				if (!StateManager.AllBranchesAttached(newValue))
					stateManager.AdoptionInformation.RegisterPossibleOrphan(parentInstance, newValue, godparent: reference);
				if (shouldAddReference)
					//Let's addd a reference to the References Table.
					stateManager.ReferencesManager.AddReference(reference, newValue);
				//If the model is not Dirty let's mark it as modified.
				tracker.MarkAsModified(reference, "Target");
			}
		}
		private static void AddOrUpdateReference(PropertyInfoEx propEx, IStateObject parentInstance, object newValueObj, StateObjectPointerReference currentValue = null, bool isNew = false)
		{
			var stateManager = StateManager.Current;
			string propName = GetPropertyName(propEx);
			var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);

			var reference = currentValue;
			if (reference == null)
				reference = stateManager.GetObject(relativeUid, isNew: isNew) as StateObjectPointerReference;
			//We need to remove the pointer;
			if (reference != null)
			{
				//	We need to remove the Reference to the value if present and if it's not a 
				//StateObjectPointerReferenceSuperValueBase
				if (!(reference is StateObjectPointerReferenceSuperValueBase))
					stateManager.ReferencesManager.RemoveReference(reference, reference.Target);
				// Let's check if the existing reference is compatible with the newValue to 
				//remove it or if the value being set is null as well.
				if (newValueObj == null || !reference.IsCompatibleWith(newValueObj))
				{
					//If the Reference is not compatible then we need to remove it to get a new one.
					stateManager.RemoveObject(relativeUid, true);
					reference = null;
				}
			}
			//Only if the newValue is not null we need a reference, otherwise lets avoid the overhead.
			if (newValueObj != null && reference == null)
				//Gets the reference for the property.
				reference = GetReference(propEx, parentInstance, newValueObj);
			//No reference, no value...We don't need to do anything else.
			else if (newValueObj == null && reference == null)
				return;

			//Once we got the Reference let's update it.
			UpdateReferenceValue(stateManager, reference, parentInstance, newValueObj);
		}

		internal static void ProcessSetterStrongReference(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			var parentInstance = parentObject as IStateObject;
			AddOrUpdateReference(propEx, parentInstance, newValueObject, isNew: isNew);
		}

		internal static void ProcessSetterWeakReference(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			//TODO might do direct cast without as. That will be slightly faster
			var parentInstance = parentObject as IStateObject;
			var stateManager = StateManager.Current;
			string propName = GetPropertyName(propEx);


			//Implementation of StateObject Reference
			//In this case the setter is never really used.
			//it is always intercepted
			var relativeUid = UniqueIDGenerator.GetPointerRelativeUniqueID(parentInstance, propName);
			var pointer = (StateObjectPointerReference)stateManager.GetObject(relativeUid, isNew: isNew);

			if (newValueObject == null)
			{
				if (pointer != null)
				{
					//We need to remove the pointer;
					stateManager.RemoveObject(relativeUid, true);
				}
				//if newValue == null and pointer == null there is nothing to do
			}
			else //New value is not null then
			{
				//did we have a value?
				if (pointer == null)
				{
					AddDependent(parentInstance, UniqueIDGenerator.REFERENCEPrefix + GetPropertyName(propEx));
					//If not create one
					if (propEx.isStateObject || propEx.isAnIList || propEx.isAnIDictionary)
					{
						pointer = new StateObjectPointerReference();
						if (propEx.stateManagementAttribute == StateManagementValues.ServerOnly)
							stateManager.isServerSideOnly.Add(pointer);
					}
					else if (propEx.isNonStateObjectFixedType)
					{
						pointer = new StateObjectPointerReferenceSuperValue();
					}
					else
					{
						var stackTrace = new StackTrace(3, true);
						throw new InvalidOperationException(
							"LazyBehaviour::ProcessSetter Property with reference attribute receive a value of unsupported type.\r\n" +
							"Additional Info: \r\n" +
							"Value Type: " + newValueObject.GetType().FullName + "\r\n" +
							"Property Type: " + propName + "\r\n" +
							"Error Location: " + stackTrace);
					}
					//Surrogates are handled above

					StateObjectPointer.AssignUniqueIdToPointer(parentInstance, relativeUid, pointer);
				}
				var pointerReferenceSuperValue = pointer as StateObjectPointerReferenceSuperValue;
				var tracker = stateManager.Tracker;
				if (pointerReferenceSuperValue != null)
				{
					pointerReferenceSuperValue.SuperTarget = newValueObject;
					tracker.MarkAsModified(pointerReferenceSuperValue, "Target");

				}
				else
				{
					var newValue = newValueObject as IStateObject;
					//Once we have a pointer make the newValue its new target
					pointer.Target = newValue;
					tracker.MarkAsModified(pointer, "Target");


					// Here we will try to manage posible orphans assigned to Pointers
					if (!StateManager.AllBranchesAttached(newValue))
					{
						stateManager.AdoptionInformation.RegisterPossibleOrphan(parentInstance, newValue, godparent: pointer);
					}
				}
			}
		}
		/// <summary>
		/// This setter will be invoked when the property VisibleState of the CotrolBase or FormBase is modified
		/// </summary>
		internal static void ProcessSetterVisibleState(PropertyInfoEx propEx, object parentObject, object newValueObject, bool isNew = false)
		{
			if (isNew)
				return;
			ProcessSetterSimpleTypes(propEx, parentObject, newValueObject);
			var tracker = StateManager.Current.Tracker;
			var parentInstance = parentObject as IStateObject;
			tracker.MarkAsModified(parentInstance, "Visible");
		}

	}
    internal class LazyBehaviour : IInterceptionBehavior
    {

        [ThreadStatic]
        internal static bool DisableInterception = false;

        /// This method id called every time a method is called from ViewModel
        public VirtualMethodInvocation Invoke(VirtualMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //Interception is only for properties and Properties are always special names
            VirtualMethodInvocation result = null;
            if (!DisableInterception)
            {
                var parentInstance = input.Target;
				PropertyInfoEx prop = input.PropertyInfo;
                if (input.MethodType == 1)
                {
                    prop.ProcessSetter(prop, parentInstance, input.myReturnValue);
                }
                result = getNext()(input, getNext);
				if (input.MethodType == 2)
                {
                    Object lastResult = result.ReturnValue;
                    if (prop.ProcessGetter(prop, parentInstance, ref lastResult))
                    {
                        result.ReturnValue = lastResult;
                    }
                }
            }
            else
            {
                result = getNext()(input, getNext);
            }
            return result;
        }


       
        
    }

	internal class LazyBehaviourNewInstance : IInterceptionBehavior
	{

		[ThreadStatic]
		internal static bool DisableInterception = false;

		/// This method id called every time a method is called from ViewModel
		public VirtualMethodInvocation Invoke(VirtualMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
		{
			//Interception is only for properties and Properties are always special names
			VirtualMethodInvocation result = null;
			if (!DisableInterception)
			{
				var parentInstance = input.Target;
				if (input.MethodType == 1)
				{
					PropertyInfoEx prop = input.PropertyInfo;
					prop.ProcessSetter(prop, parentInstance, input.myReturnValue, true);
				}
				result = getNext()(input, getNext);
			}
			else
			{
				result = getNext()(input, getNext);
			}
			return result;
		}




	}

	internal class LazyBehaviourNoSetters : IInterceptionBehavior
	{

		[ThreadStatic]
		internal static bool DisableInterception = false;

		/// This method id called every time a method is called from ViewModel
		public VirtualMethodInvocation Invoke(VirtualMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
		{
			//Interception is only for properties and Properties are always special names
			VirtualMethodInvocation result = null;
			if (!DisableInterception)
			{
				var parentInstance = input.Target;
				result = getNext()(input, getNext);
				if (input.MethodType == 2)
				{
					PropertyInfoEx prop = input.PropertyInfo;
					Object lastResult = result.ReturnValue;
					if (prop.ProcessGetter(prop, parentInstance, ref lastResult))
					{
						result.ReturnValue = lastResult;
					}
				}
			}
			else
			{
				result = getNext()(input, getNext);
			}
			return result;
		}




	}

}