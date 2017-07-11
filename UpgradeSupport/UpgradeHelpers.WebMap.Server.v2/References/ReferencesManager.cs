using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.List;

namespace UpgradeHelpers.WebMap.Server
{
	internal class ReferencesManager : IReferenceManager
	{
		internal const string StorageKey = "@@REFMGR";
        internal HashSet<string> RescuedValueUniqueIdHashSet;

		private StateManager _stateManager;
		internal ReferencesManager(StateManager stateManager)
		{
			_stateManager = stateManager;
            RescuedValueUniqueIdHashSet = new HashSet<string>();
        }
		private bool TransferValueToReference(string branchRemoved, ReferencesTable referencesTable, IStateObject elementToAdoptObj = null, bool isDispose = false, IFormBaseViewModel formBaseViewModel = null)
		{
            if (isDispose && referencesTable.IsReferencedObjectAnIDisposableDependencyControl)
                return false;
            //If the elementToAdopt was not sent as a parameter let's calculate it.
            if (elementToAdoptObj == null)
				elementToAdoptObj = referencesTable.ReferencedObject;
			string oldParentUniqueID = elementToAdoptObj.UniqueID;
			//Entire windows won't be preserved.
			if (elementToAdoptObj is IViewModel)
				return false;           
            //Let's get the reference candidate for the adoption.
			var reference = GetReferenceValidForAdoption(referencesTable, false);
			if (reference == null)
				return false;
			var candidate = CalculateCandidateForAdoption(reference);
			//The cadidates parent was already removed...Ciao
			if (candidate == null)
				return false;
            bool doNotRegisterIDSwitch = true;
            if(formBaseViewModel == null)
                formBaseViewModel = ViewManager.Instance.GetTopLevelObject(elementToAdoptObj) as IFormBaseViewModel;
            if (formBaseViewModel != null) doNotRegisterIDSwitch = formBaseViewModel.IsDisposing;

			if (!(elementToAdoptObj is IDisposableDependencyControl) || (!isDispose && !doNotRegisterIDSwitch))
			{
				//The element won't belong to the parent anymore.
				IStateObject elementsToBeAdopted = _stateManager.DettachObject(elementToAdoptObj, !doNotRegisterIDSwitch);
				//We need to promote the object and attach it to the first candidate.
				AdoptionInformation.StaticAdopt(candidate, elementsToBeAdopted);
				////Let's update all the references
				UpdateReferencesTables(oldParentUniqueID, elementToAdoptObj.UniqueID);
				//Only foreign references allowed
				referencesTable.RemoveReference(reference);
				//We move the element to a substitute parent.
				referencesTable.AttachedToParent = false;
				//We had a succesfull adoption :)
				return true;
			}
			return false;
		}

		/// <summary>
		/// Get All the References Tables in a branch.
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		private List<ReferencesTable> GetChildrenReferencesTables(string uniqueID)
		{
			if (StateManager.AllBranchesAttached(uniqueID))
				return GetChildrenReferencesTablesInCache(uniqueID);
			else
				return GetChildrenReferencesTablesInTempStorage(uniqueID);
		}

		/// <summary>
		/// Gets All the ReferencesTables in _cache.
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		private List<ReferencesTable> GetChildrenReferencesTablesInCache(string uniqueID)
		{
			HashSet<string> children = children = _stateManager.GetAllChildrenKeys(uniqueID);
			List<ReferencesTable> result = null;
			foreach (var child in children)
			{
				result = result ?? new List<ReferencesTable>();
				if (UniqueIDGenerator.IsRefencesTable(child) && !_stateManager.IsInElementsToRemove(child))
				{
					var table = _stateManager.GetObject(child) as ReferencesTable;
					result.Add(table);
				}
			}
			return result;
		}

		/// <summary>
		/// Gets All the ReferencesTables in _tempCache.
		/// </summary>
		/// <param name="uniqueID"></param>
		/// <returns></returns>
		private List<ReferencesTable> GetChildrenReferencesTablesInTempStorage(string uniqueID)
		{
			var children = _stateManager._tempcache.GetAllDependentItems(uniqueID);
			List<ReferencesTable> result = null;
			foreach (var child in children)
			{
				result = result ?? new List<ReferencesTable>();
				if (UniqueIDGenerator.IsRefencesTable(child.Key))
				{
					var table = child.Value as ReferencesTable;
					result.Add(table);
				}
			}
			return result;
		}

		/// <summary>
		/// Goes through all the References Tables in a branch and Updates the References.
		/// </summary>
		/// <param name="branchDeleted"></param>
		/// <param name="oldParentUID"></param>
		/// <param name="newParentUID"></param>
		public void UpdateReferencesTables(string oldParentUID, string newParentUID)
		{
			var newParentUIDRefTables = GetChildrenReferencesTables(newParentUID);
            if (newParentUIDRefTables != null)
            {
                foreach (var table in newParentUIDRefTables)
                {
                    var newUID = StateManager.GetParentUniqueID(table.UniqueID);
                    var oldUID = UniqueIDGenerator.ReplaceParent(newUID, newParentUID, oldParentUID);
                    //Let´s update and then validate the References.
					table.UpdateReferencesTable(oldParentUID, newParentUID, oldUID, newUID);
                }
            }
            var olParentUIDRefTables = GetChildrenReferencesTables(oldParentUID);
            if (olParentUIDRefTables != null)
            {

                for (var i = 0; i < olParentUIDRefTables.Count; i++)
                {
                    var table = olParentUIDRefTables[i];
                    //Maybe table is already in ElementsToRemove
                    if (table != null)
                    {
                        var newUID = StateManager.GetParentUniqueID(table.UniqueID);
                        var oldUID = UniqueIDGenerator.ReplaceParent(newUID, newParentUID, oldParentUID);
                        //Let´s update and then validate the References.
                        table.UpdateReferencesTable(oldParentUID, newParentUID, oldUID, newUID);
                    }
                }
            }
        }

		/// <summary>
		/// Gets the References table associated to an IStateObject
		/// </summary>
		/// <param name="valueObject"></param>
		/// <returns></returns>
		private ReferencesTable GetObjectReferencesTable(IStateObject valueObject)
		{
			return GetObjectReferencesTable(valueObject.UniqueID);
		}
		/// <summary>
		/// Gets the References table associated to an IStateObject
		/// </summary>
		/// <param name="valueObject"></param>
		/// <returns></returns>
		private ReferencesTable GetObjectReferencesTable(string uniqueID)
		{
			ReferencesTable result = null;
			var uniqueId = UniqueIDGenerator.GetReferenceTableRelativeUniqueID(uniqueID);
			var obj = _stateManager.GetObject(uniqueId);
			if (obj != null)
				result = obj as ReferencesTable;
			return result;
		}

		/// <summary>
		/// Creates a reference table to an Object.
		/// </summary>
		/// <param name="valueObject"></param>
		/// <returns></returns>
		private ReferencesTable CreateObjectReferencesTable(IStateObject valueObject)
		{
			var new_relativeUid = UniqueIDGenerator.GetReferenceTableRelativeUniqueID(valueObject.UniqueID);
			LazyBehaviours.AddDependent(valueObject, UniqueIDGenerator.REFTABLEPrefix);
			ReferencesTable referencesTable = new ReferencesTable();
			referencesTable.UniqueID = new_relativeUid;
            referencesTable.IsReferencedObjectAnIDisposableDependencyControl = valueObject is IDisposableDependencyControl;

            if (StateManager.AllBranchesAttached(valueObject))
			{
				//at this point we have a new pointer with an attached parent
				//which means that it was born on the temp stateManager
				//we cannot just do a switchunique ids because switching
				//is only on the stateManager level
				//we need to promote it from temp to StateManager
				//to make sure that it will be persisted
				_stateManager.AddNewAttachedObject(referencesTable);
			}
			else
			{
				//at this point we have a new pointer with an UNATTACHED parent
				//which means both the parent and the pointer are on the temp stateManager
				//we need to switchunique ids because 
				//they are at the stateManager level
				//if the parent is promoted so will be the pointer
				_stateManager.AddNewTemporaryObject(referencesTable);
			}
			return referencesTable;
		}

		/// <summary>
		/// Register a reference in an Object References Table
		/// </summary>
		/// <param name="reference">Reference to the Value.</param>
		/// <param name="referencedObject">Value being Referenced</param>
		public void AddReference(IStateObject reference, IStateObject referencedObject)
		{
			var referencesTable = GetObjectReferencesTable(referencedObject);
			if (referencesTable == null)
				referencesTable = CreateObjectReferencesTable(referencedObject);
			referencesTable.AddReference(reference);
		}

		/// <summary>
		/// Removes a Reference to a Value in a References Table.
		/// </summary>
		/// <param name="reference">Reference to the Value.</param>
		/// <param name="referencedObject">Value being Referenced</param>
		public void RemoveReference(IStateObject reference, IStateObject referencedObject, bool removingFromList = false)
		{
			if (referencedObject == null)
				return;
			var referencesTable = GetObjectReferencesTable(referencedObject);
			if (referencesTable != null)
			{
				referencesTable.RemoveReference(reference);
				if (referencesTable.Count == 0 && !referencesTable.AttachedToParent )
					_stateManager.RemoveObject(referencedObject.UniqueID, true, true);
              
            }
		}

		/// <summary>
		/// Rescues a Value if it has Valid References
		/// </summary>
		/// <param name="valueDeleted">It's the UniqueID of the IStateObject being deleted</param>
		/// <param name="branchUniqueID">It's the Root object that started the Deletion process.</param>
		/// <returns>True if the Value had valid references and it was rescued from deletion.</returns>
		internal bool RescueValue(string objToRemoveUniqueID, string branchUniqueID = null, bool allowUnAttachedReferences = true, bool isDispose = false, IFormBaseViewModel formBaseViewModel = null, HashSet<string> _objectsToBeValidatedAfterDisposeHashSet = null)
		{
			if (branchUniqueID == null)
				branchUniqueID = objToRemoveUniqueID;

			var referencesTable = GetObjectReferencesTable(objToRemoveUniqueID);
			if (referencesTable != null)
			{
				referencesTable.ValidateReferences(branchDeleted: branchUniqueID, validateUnAttached: !allowUnAttachedReferences);
                //If the object to be removed is a ListItem AND the referencesTable's count is major than zero,
                //then we have a special block for handling this situation.
                if (UniqueIDGenerator.IsListItem(objToRemoveUniqueID) && referencesTable.Count > 0)
                {
						//If the referenced object is IViewModel, or IDisposableDependencyControl,
						//we should never rescue them.
                    if (isDispose && referencesTable.IsReferencedObjectAnIDisposableDependencyControl)
                        return false;
                    //If there are some valid references, we should rescue it.
                    else if (HasValidReferencesForListItem(referencesTable, objToRemoveUniqueID, _objectsToBeValidatedAfterDisposeHashSet))
                    {
                        RescuedValueUniqueIdHashSet.Add(objToRemoveUniqueID);
                        return true;
                    }
                    //otherwise, we shouldn't resue it
                    else
                    {
                        return false;
                    }
                }
                else if (referencesTable.Count > 0)//No references
                {
                    bool res = TransferValueToReference(branchUniqueID, referencesTable, isDispose: isDispose, formBaseViewModel: formBaseViewModel);
                    if (res) RescuedValueUniqueIdHashSet.Add(objToRemoveUniqueID);
                    return res;
                }
			}
            //Given this kind of uniqueID: x#y#KIXYZ
            // We have to validate if KIXYZ has been rescued previously,
            // if this KIXYZ has been rescued, we should skip this uniqueID
            var accessPathIndex = objToRemoveUniqueID.LastIndexOf(UniqueIDGenerator.UniqueIdSeparator);
            if (accessPathIndex > 0)
            {
                var ancestorUID = objToRemoveUniqueID.Substring(accessPathIndex + 1);
                var canRescue = RescuedValueUniqueIdHashSet.Contains(ancestorUID) && !_stateManager.IsInElementsToRemove(ancestorUID);
                if (UniqueIDGenerator.IsListItem(ancestorUID) && canRescue)
                    return true;
            }
            return false;
		}
        private object _referencesLock = new object();
        private bool HasValidReferencesForListItem(ReferencesTable referencesTable, string uniqueID,  HashSet<string> _objectsToBeValidatedAfterDisposeHashSet)
        {   
            var isValid = false;
            for (int i = referencesTable.References.Count - 1; i >= 0; i--)
            {
                var reference = referencesTable.References[i];
                bool isPage = UniqueIDGenerator.IsPage(reference.TargetUniqueID);
                if (isPage)
                {
                    var page = reference.Target as Page;
                    string pageParentUniqueID = GetPageParentUniqueID(page);
                    //the reference is valid if and only if the list is not in elements to remove, and if the list is allbranchesattached.
                    if (!StateManager.Current.IsInElementsToRemove(pageParentUniqueID) &&
                        StateManager.AllBranchesAttached(pageParentUniqueID))
                        isValid = true;
                }
                else if (!StateManager.Current.IsInElementsToRemove(reference.TargetUniqueID))
                {
                    //if the reference is not a page, this means it is a pointer pointing to the list item
                    // and this pointer is not in elementsToRemove Collection
                    //so this item has valid reference yet.
                    isValid = true;
					_objectsToBeValidatedAfterDisposeHashSet.Add(uniqueID);
				}
            }
            return isValid;
        }
        /// <summary>
        /// The page is pointing a Parent, this parent could be an Object or a string,
        /// so we need to return always the parent as string
        /// </summary>
        public string GetPageParentUniqueID(IVirtualPage page)
        {
            var parentAsIStateObject = page.Parent as IStateObject;
            if (parentAsIStateObject != null)
                return parentAsIStateObject.UniqueID;
            else
                return page.Parent as string;
        }

        /// <summary>
        /// Returns if an Object has References.
        /// </summary>
        /// <param name="referencedObj"></param>
        /// <returns></returns>
        public bool HasReferences(IStateObject referencedObj)
		{
			return HasReferences(referencedObj.UniqueID);
		}

		/// <summary>
		/// Returns if an Object has References.
		/// </summary>
		/// <param name="referencedObj"></param>
		/// <returns></returns>

		public bool HasReferences(string referencedObjUniqueID)
		{
			var referencesTable = GetAndValidateReferencesTable(referencedObjUniqueID);
			if (referencesTable != null && referencesTable.Count > 0)
				return true;
			return false;
		}

		/// <summary>
		/// Retrieves the ReferencesTable and Validate it.
		/// </summary>
		/// <param name="referencedObjUniqueID"></param>
		/// <returns></returns>
		private ReferencesTable GetAndValidateReferencesTable(string referencedObjUniqueID)
		{
			var referencesTable = GetObjectReferencesTable(referencedObjUniqueID);
			if (referencesTable != null)
				referencesTable.ValidateReferences();
			return referencesTable;
		}

		/// <summary>
		/// Returns all the References
		/// </summary>
		/// <param name="referencedObject"></param>
		/// <returns></returns>
		public List<IStateObject> GetReferences(IStateObject referencedObject)
		{
			List<IStateObject> result = null;
			var referencesTable = GetAndValidateReferencesTable(referencedObject.UniqueID);
			if (referencesTable != null)
			{
				foreach (var reference in referencesTable.References)
				{
					result = result ?? new List<IStateObject>();
					result.Add(reference.Target as IStateObject);
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="referencedObject"></param>
		/// <param name="onlyAllBranchesAttached"></param>
		/// <returns></returns>
		public IStateObject GetReferenceValidForAdoption(IStateObject referencedObject, bool onlyAllBranchesAttached = true, bool isHandlingOrphans = false)
		{
			IStateObject result = null;
			var referencesTable = GetAndValidateReferencesTable(referencedObject.UniqueID);
			if (referencesTable != null)
			{
				result = GetReferenceValidForAdoption(referencesTable, onlyAllBranchesAttached, isHandlingOrphans);
			}
			return result;
		}

		/// <summary>
		/// Let's get the reference candidate for the adoption.
		/// </summary>
		/// <param name="referencedObject"></param>
		/// <param name="onlyAllBranchesAttached"></param>
		/// <returns></returns>
		public IStateObject GetReferenceValidForAdoption(ReferencesTable referencesTable, bool onlyAllBranchesAttached = true, bool isHandlingOrphans = false)
		{
			IStateObject result = null;
			if (referencesTable != null)
			{
				IStateObject firstNonVisualParentCandidate = null; ;
				IStateObject firstVisualParentCandidate = null;
				foreach (var candidate in referencesTable.References)
				{
					var parent = CalculateCandidateForAdoption(candidate.Target as IStateObject);
					//If the possible parent is a page, lets retrieve tha page's parent ( the list ), he will be the candidate
                    //who will compete with other parents in the addoption process.
                    if (isHandlingOrphans && parent is Page)
                    {
                        if((parent as Page).Parent is IStateObject) parent = (parent as Page).Parent as IStateObject;
                        else parent = StateManager.Current.GetObject((parent as Page).Parent as string);
                    }
                    if (parent == null)
                        continue;
                    if (!onlyAllBranchesAttached || (onlyAllBranchesAttached && StateManager.AllBranchesAttached(parent)))
					{
                        var isTopModel = UniqueIDGenerator.IsRootModel(parent.UniqueID);
						var isTopShared = UniqueIDGenerator.IsRootSharedState(parent.UniqueID);
						if (isTopModel || isTopShared || parent is IModel || parent is IDependentModel || parent is IPromise)
 						{
							firstNonVisualParentCandidate = parent;
							continue;
						}
						if (parent is IViewModel || parent is IDependentViewModel)
						{
							firstVisualParentCandidate = parent;
							break;
						}
					}
				}
				if (firstVisualParentCandidate != null)
				{
					result = firstVisualParentCandidate;
				}
				else if (firstNonVisualParentCandidate != null)
				{
					result = firstNonVisualParentCandidate;
				}
			}
			return result;
		}

		/// <summary>
		/// Receives a Refernce an Return a valid candidate for adoption, it could be it's parent.
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public IStateObject GetCandidateForAdoption(IStateObject obj , bool onlyAllBranchesAttached = true, bool isHandlingOrphans = false)
		{
			var reference = GetReferenceValidForAdoption(obj, onlyAllBranchesAttached, isHandlingOrphans);
			if(reference == null)
				return null;
			return CalculateCandidateForAdoption(reference);
		}

		private IStateObject CalculateCandidateForAdoption(IStateObject reference = null)
		{
			IStateObject candidate = null;
			candidate = reference;
			if (reference is StateObjectPointerReference)
				candidate = _stateManager.GetParentEx(reference);
			return candidate;
		}

        public void Subscribe(object valueObject, object referenceObject)
        {
            var valueObj = valueObject as IStateObject;
            var referenceObj = referenceObject as IStateObject;
			if (valueObj != null && referenceObj != null)
				AddReference(valueObj, referenceObj);
			}

        public void UnSubscribe(object valueObject, string UniqueID, bool removeDirectly = false, string rootUniqueID = "")
        {
            var referenceToTheValue = valueObject as IStateObject;
            if (referenceToTheValue != null)
            {
                var referencesTable = GetObjectReferencesTable(UniqueID);
                if (referencesTable != null)
                {
                    if (rootUniqueID != "")
                        referencesTable.ValidateReferences(validateUnAttached: true, branchDeleted: rootUniqueID);
                    else
                        referencesTable.ValidateReferences(validateUnAttached: true);
                    if (UniqueIDGenerator.IsListItem(UniqueID) && !HasValidReferencesForListItem(referencesTable, UniqueID, _stateManager._objectsToBeValidatedAfterDisposeHashSet))
                    {
                      
                            _stateManager.DettachListItem(UniqueID, rootUniqueID);
                    }
                    else if (referencesTable.Count == 0 && !referencesTable.AttachedToParent)
                    {
                        _stateManager.DettachObject(UniqueID, false);
                    }
                }
            }
        }

        public IReferenceTable GetReferenceTable(object valueObject)
        {
            var obj = valueObject as IStateObject;
            if (obj != null)
            {
                return this.GetObjectReferencesTable(obj);
            }
            else
                return null;
        }

        public IReferenceTable GetReferenceTable(string valueObjectUniqueId)
        {
            return this.GetObjectReferencesTable(valueObjectUniqueId);
        }

        /// <summary>
        /// Within Dettach object, sometimes the dettached object and its dependants has a reference of a List ( a page )
        /// In this cases, since the object has been dettached, we have to update the page,
        /// marking the page as dirty
        /// </summary>
        internal void UpdateRefTableInDettachObject(IStateObject element, string uniqueID, string oldElementUid = "")
        {
            var referenceTable = this.GetReferenceTable(uniqueID);
            if(referenceTable != null && referenceTable.References.Count>0)
            {
               for(var i = 0; i< referenceTable.References.Count; i++)
                {
                    var reference = referenceTable.References[i];
                    var referenceAsPage = reference.Target as Page;
                    if(referenceAsPage != null)
                    {
                        if(oldElementUid != "")
                        {
                            var objects = referenceAsPage.StoredObjects;
                            foreach(var obj in objects)
                            {
                                var lazyObject = obj as LazyObject;
                                if (String.CompareOrdinal(lazyObject.TargetUniqueID, oldElementUid) == 0)
                                    lazyObject.Target = element;
                            }
                        }
                        this._stateManager.MarkAsDirty(referenceAsPage, "StoredObjects");
                    }
                }
            }
        }
		internal void Dispose()
		{
			this._stateManager = null;
            this.RescuedValueUniqueIdHashSet.Clear();
            this.RescuedValueUniqueIdHashSet = null;
		}
    }
}


