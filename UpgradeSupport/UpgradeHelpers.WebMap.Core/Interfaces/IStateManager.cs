// *************************************************************************************
// <copyright  company="Mobilize" file="IStateManager.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace UpgradeHelpers.Interfaces
{
	public interface IStateManager
	{

        /// <summary>
        /// If stateObj is an item inside a list it will return the first page for the list item.
        /// For other items it will return the "parent" in the structure hierarchy
        /// </summary>
        /// <param name="stateObj"></param>
        /// <returns></returns>
        string GetParentKeyEx(string uniqueID);

        /// <summary>
        /// Mark an IStateObject as a dirty model in order to be sent to client.
        /// </summary>
        void MarkAsDirty(IStateObject model, string property);
		/// <summary>
		/// Promote moves object to an upper level stateManager
		/// Search is done by reference. After finding instance on temp stateManager it will remove its old key
		/// And object will be put on the upper level stateManager (StateManager) using the current UniqueID
		/// 
		/// Prior to calling this method, the uniqueID is update, that is why the search is performed by refeernce not id
		/// </summary>
		void PromoteObject(IStateObject obj, string newUniqueID, bool inAdoption = false);


        /// <summary>
        /// Register parent object as candidate foster parent for obj
        /// </summary>
        void RegisterPossibleOrphan(IStateObject parent, IStateObject obj);



		/// <summary>
		/// This method is to verify that we are not trying to promote an object
		/// whose parent has not been promoted yet
		/// </summary>
		bool IsStateObjectAllAttached(IStateObject obj);

		/// <summary>
		/// Determines if the specified obj is attached. It does not need that
		/// the object is attached to an element on the StateManager.Current._stateManager
		/// it could also be any object on the temp stateManager
		/// </summary>
		bool IsStateObjectAttached(IStateObject obj);

		/// <summary>
		/// Retrieves the desired object from storage.
		/// </summary>
		/// <param name="uniqueId">The unique id of the desired object</param>
		/// <returns>Returns the IStateObject of the desired object, otherwise returns null.</returns>
		IStateObject GetObject(string uniqueId, bool includeDeleted = false, bool isOkForSurrogateToBeMissing = false, bool getObjectFromTemp = false, bool isNew = false);

        /// <summary>
		/// Retrieves the desired object from storage.
		/// </summary>
		/// <param name="uniqueId">The unique id of the desired object</param>
		/// <returns>Returns the IStateObject of the desired object, otherwise returns null.</returns>
		IStateObject GetObject(string uniqueId);

        /// <summary>
        /// Gets the RAW object from the storage
        /// </summary>
        /// <param name="uniqueid">The Unique ID of the RAW object</param>
        object GetObjectRaw(string uniqueid);

		/// <summary>
		/// Add the object to the cache and attaches into the Delta Tracker 
		/// It is assumed that this method is ONLY called for new objects
		/// </summary>
		/// <param name="obj">The object that will be stored</param>
		IStateObject AddNewObject(IStateObject obj);

        /// <summary>
        /// Does not directly remove element but registers it for deletion
        /// </summary>
        bool RemoveObject(string uniqueId, bool mustDetach, bool deep = true, string rootUniqueID = null, bool isDispose = false, object vm = null);

        bool AllDependenciesAreProcessed { get; }

		void SubscribeReference(IStateObject reference, IStateObject referencedObject);

		/// <summary>
		/// Cancel a possible removal from Session.
		/// </summary>
		void UndoRemove(string uniqueId);
		
		/// <summary>
		/// Verifies if the object is in the list of elements set to be removed from the session
		/// </summary>
		bool IsInElementsToRemove(string objectRefID);

        /// <summary>
        /// Cancel a possible item removal from Session, including its children.
        /// </summary>
        void PromoteListItem(string uniqueId, IStateObject obj, bool deep = true, System.Collections.Generic.HashSet<string> alreadyPromotedHashSet = null);

        IStateObject DettachObject(IStateObject obj, bool registerSwitchID = true);


		bool IsNewObject(IStateObject obj);

		void AddNewJustPromotedObject(IStateObject obj);

	   void RemoveObjectReference(string uniqueID, out bool isJustPromoted, bool addToElementsToRemove = true, bool removeEntryFromCache = true);
	}
}
