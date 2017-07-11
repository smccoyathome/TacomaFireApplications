using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpgradeHelpers.Helpers;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.List;

namespace UpgradeHelpers.WebMap.Server
{
	/// <summary>
	/// A References Table to keep track of the IStateObjects References.
	/// </summary>
    public class ReferencesTable : IDependentModel, IInternalData, IReferenceTable, NoInterception
	{
		internal List<ILazyObject> _references = null;

        /// <summary>
        /// This lock is internal to allow its use by the References table converter
        /// </summary>
		internal object _referencesLock = new object();
		/// <summary>
		/// List of the References to the IStateObject.
		/// </summary>
		public List<ILazyObject> References
		{
			get
			{
				lock (_referencesLock)
				{
					if (_references == null)
						_references = new List<ILazyObject>();
					return _references;
				}
			}
		}

		private bool _attachedToParent = true;
		/// <summary>
		///		Every ReferenceTable borns Attached to the Original Referenced Object parent,
		/// that means that the Referenced parent has not changed in the life cicle. 
		/// </summary>
		public bool AttachedToParent
		{
			get
			{
				return _attachedToParent;
			}
			set
			{
				_attachedToParent = value;
			}
		}

		private IStateObject _referencedObject;
        public IStateObject ReferencedObject
		{
			get 
			{
				if (_referencedObject != null)
					return _referencedObject;

				var parentUID = StateManager.GetParentUniqueID(UniqueID);
				//Let's get the objet but avoid adding it to the cache.
				_referencedObject = StateManager.Current.GetObject(parentUID);
                IsReferencedObjectAnIDisposableDependencyControl = _referencedObject is IDisposableDependencyControl;
                if (_referencedObject == null)
				{
                    lock (_referencesLock)
                    {
                        References.Clear();
                        MarkAsDirty();
                    }
				}
				return _referencedObject;
			}
		}

        public bool IsReferencedObjectAnIDisposableDependencyControl
        {
            get;set;
        }

        private string ReferencedObjectUniqueID
        {
            get
            {
                return StateManager.GetParentUniqueID(UniqueID);
            }
        }


		/// <summary>
		/// Adds a References to the IStateObject References Table.
		/// </summary>
		/// <param name="reference"></param>
		public void AddReference(IStateObject reference)
		{
            lock (_referencesLock)
            {
                References.Add(new CollectionStateObjectReference(reference));
                MarkAsDirty();
            }
        }

		/// <summary>
		/// Removes a References to the IStateObject in the Refernces Table.
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public bool RemoveReference(IStateObject reference)
		{
            bool result = false;
            lock (_referencesLock)
            {
                result = References.Remove(new CollectionStateObjectReference(reference));
                MarkAsDirty();
            }
            return result;
		}

        private static ILazyObject UpdateTargetUniqueID(string targetUniqueID)
        {
            return new CollectionStateObjectReference(targetUniqueID);
        }

		/// <summary>
		/// Updates all the Targets of the References to match the new value.
		/// </summary>
		/// <param name="uniqueID"></param>
		public void UpdateReferencesTable(string oldParent, string newParent, string oldUniqueID, string newUniqueID)
		{
			for (int i = References.Count - 1; i >= 0 && References.Count > 0; i--)
			{ 
				var reference = References[i];
				if (reference.TargetUniqueID.Contains(oldParent))
                   References[i] = new CollectionStateObjectReference(UniqueIDGenerator.ReplaceParent(reference.TargetUniqueID, oldParent, newParent));
                else if (reference.Target == null)
                {
                    lock (_referencesLock)
                    {
                        References.RemoveAt(i);
                        MarkAsDirty();
                    }
                }
				else if (reference.Target is StateObjectPointerReference)
				{
					((StateObjectPointerReference)reference.Target).Target = ReferencedObject;
					StateManager.Current.MarkAsDirty((StateObjectPointerReference)reference.Target, "Target");
				}
				else if (reference.Target is IReferenceWatcher)
					((IReferenceWatcher)reference.Target).UpdateReference(oldUniqueID, newUniqueID);
                else if(reference.Target is Page
                    //When a List's UniqueID has been switched, we have to notify the Page's Parent property,
                    //which hold the List's UniqueID, and updates the List's uniqueID
                    )
                {
                    var parent = StateManager.Current.GetObject(newParent);
                    if (parent is IVirtualListSerializable)
                    {
                        //Update the Parent property, which is the List's uniqueID
                        ((Page)reference.Target).Parent = parent;
                        StateManager.Current.MarkAsDirty(((Page)reference.Target), "Parent");
                    }
                }
			}
				
		}

		/// <summary>
		/// Updates all the Targets of the References to match the new value.
		/// </summary>
		/// <param name="uniqueID"></param>
		public void UpdateReferencesTable( string oldUniqueID, string newUniqueID)
		{
			for (int i = References.Count - 1; i >= 0 && References.Count > 0; i--)
			{
				var reference = References[i];
				if (reference.Target == null)
				{
					lock (_referencesLock)
					{
						References.RemoveAt(i);
                        MarkAsDirty();
                    }
                }
				else if (reference.Target is StateObjectPointerReference)
				{
					((StateObjectPointerReference)reference.Target).Target = ReferencedObject;
					StateManager.Current.MarkAsDirty((StateObjectPointerReference)reference.Target, "Target");
				}
				else if (reference.Target is IReferenceWatcher)
					((IReferenceWatcher)reference.Target).UpdateReference(oldUniqueID, newUniqueID);
			}
		}
        
        /// <summary>
        /// Validates the References to ensure that all the References are valid.
        /// </summary>
        /// <param name="referencedObj"></param>
        public void ValidateReferences(bool validateUnAttached = false, string branchDeleted = null)
        {
            if (References.Count == 0)
                return;
            
            var stateManager = StateManager.Current;
            //Let's get the objet but avoid adding it to the cache.
            for (int i = References.Count - 1; i >= 0 && i < References.Count; i--)
            {
                var proccessedUID = stateManager.BuildFullPathUniqueID(References[i].TargetUniqueID);
                //If the reference belongs to the branch being deleted we must ignore it.
                if (branchDeleted != null && References[i].TargetUniqueID.IndexOf(branchDeleted) != -1
                   || branchDeleted != null && proccessedUID.IndexOf(branchDeleted) != -1
                   || proccessedUID.IndexOf(ReferencedObjectUniqueID) != -1)
                {
                    lock (_referencesLock)
                    {
                        References.RemoveAt(i);
                    }
                    continue;
                }
                var refTarget = References[i].Target as IStateObject;
                var refTargetPointer = refTarget as StateObjectPointerReference;
                //Maybe the Reference doesn't exist anymore which is actually possible
                if (refTarget == null
                 //If the object is not Attached then it is not a valid parent.
                 || (!StateManager.AllBranchesAttached(refTarget.UniqueID) && validateUnAttached
                 ||    //If the top level is the same then Reference could not point to a superior object in the tree or to a sibling.
                       // In fact only object in a superior Levels could keep references to lower levels in a tree.
                       // 0 is the Root.
                       //Maybe the Target of the Reference was changed to null.
                       (refTargetPointer != null && !Object.ReferenceEquals(refTargetPointer.Target, ReferencedObject))))
                 
                {
                    lock (_referencesLock)
                    {
                        References.RemoveAt(i);
                    }
                    continue;
                }
            }
        }
		/// <summary>
		/// Returns a valid candidate for the IStateObject Adoption.
		/// </summary>
		/// <returns></returns>
		public IStateObject GetAdoptionCandidate()
		{
			//Let's get the first avaliable reference.
			return References[0].Target as IStateObject;
		}
		/// <summary>
		/// Returns the number of references to the IStateObject.
		/// </summary>
		public int Count
		{
			get
			{
				return References.Count;
			}
		}

        private void MarkAsDirty()
        {
            StateManager.Current.MarkAsDirty(this, "Count");
        }
        public string UniqueID { get; set; }

	}
}
