// *************************************************************************************
// <copyright  company="Mobilize" file="IReferenceTable.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System.Collections.Generic;

namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// This is an object that stores all the references of a IStateObject.
	/// This table will manage the reference counting.
	/// </summary>
	public interface IReferenceTable
	{
		IStateObject ReferencedObject { get; }
		List<ILazyObject> References { get; }
		bool AttachedToParent { get; set; }
		void ValidateReferences(bool validateUnAttached = false, string branchDeleted = null);
		IStateObject GetAdoptionCandidate();
		bool RemoveReference(IStateObject reference);
		void AddReference(IStateObject stateObject);
		int Count { get; }
		void UpdateReferencesTable(string oldUniqueID, string newUniqueID);
	}
}
