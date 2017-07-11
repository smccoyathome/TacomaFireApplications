// *************************************************************************************
// <copyright  company="Mobilize" file="IReferenceManager.cs">
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
	/// <summary>
	/// The IReferenceManager is in charge of everything related on keeping the reference up to date using Strong References, and reference counting.
	/// </summary>
	public interface IReferenceManager
	{
		/// <summary>
		/// Register a new reference to the value object within its references Table
		/// </summary>
		/// <param name="valueObject">The value that expects a new referent</param>
		/// <param name="referenceObject">The referent object that will be registered in the value object's reference table</param>
		void Subscribe(object valueObject, object referenceObject);

		/// <summary>
		/// Unregister a reference
		/// </summary>
		/// <param name="valueObject">The value that contains the referent object in its reference table</param>
		/// <param name="referenceObject">The referent object that will be removed from the value object's reference table</param>
		void UnSubscribe(object valueObject, string UniqueID, bool removeDirectly = false, string rootUniqueID = "");

		/// <summary>
		/// Retrieves the reference table of the given Value Object
		/// </summary>
		/// <param name="valueObject">The value object</param>
		/// <returns></returns>
		IReferenceTable GetReferenceTable(object valueObject);

		/// <summary>
		/// Retrieves the reference table of the given Value Object's unique id
		/// </summary>
		/// <param name="valueObjectUniqueId">The unique id of the object</param>
		/// <returns></returns>
		IReferenceTable GetReferenceTable(string valueObjectUniqueId);

		void UpdateReferencesTables(string oldParentUID, string newParentUID);

	}
}
