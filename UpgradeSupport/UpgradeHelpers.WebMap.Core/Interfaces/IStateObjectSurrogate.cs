// *************************************************************************************
// <copyright  company="Mobilize" file="IStateObjectSurrogate.cs">
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
	/// This Interface is encapsulating the existence of the real surrogate object.
	/// </summary>
	public interface IStateObjectSurrogate : IStateObject, IDependentsContainer
	{
		/// <summary>
		/// Stores the real object
		/// </summary>
		object Value { get; set; }

		/// <summary>
		/// Verifies if the references are valid (not set to be deleted and have a value)
		/// </summary>
		bool ShouldBeSerialized();

		/// <summary>
		/// The IStateManager is the parent of any IStateObjectSurrogates
		/// </summary>
		IStateManager Parent { get; set; }
	}
}
