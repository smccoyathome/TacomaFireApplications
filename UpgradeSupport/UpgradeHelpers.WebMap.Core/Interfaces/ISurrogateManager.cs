// *************************************************************************************
// <copyright  company="Mobilize" file="ISurrogateManager.cs">
//     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//     All helper classes are provided for customer use only;
//     all other use is prohibited without prior written consent from Mobilize.Net.
//     no warranty express or implied;
//     use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
using System;
using System.IO;

namespace UpgradeHelpers.Interfaces
{
	/// <summary>
	/// This is the Manager who is in charge of everything related with the Surrogates.
	/// </summary>
	public interface ISurrogateManager
	{
		/// <summary>
		/// Returns true if the type is registered as a Surrogate member
		/// </summary>
		/// <param name="supportedType"></param>
		/// <returns></returns>
		bool IsSurrogateRegistered(Type supportedType);

		/// <summary>
		/// Gets the StateObjectSurrogate of the real surrogate
		/// </summary>
		/// <param name="newValueObject">The object that is meets to the requirements of being a surrogate</param>
		/// <param name="generateIfNotFound">Generate a new StateObjectSurrogate if it didn't found in the sotrage</param>
		/// <param name="parentSurrogate"></param>
		/// <returns></returns>
		IStateObjectSurrogate GetStateObjectSurrogate(object newValueObject, bool generateIfNotFound, string parentSurrogate = null);

		/// <summary>
		/// Validates that the string that will be used as a signature follows the expected format. Adjust length if necessary
		/// </summary>
		string ValidSignature(string signature);

		/// <summary>
		/// Convert any object to RAW. This is used for serializing purposes
		/// </summary>
		/// <param name="obj">The object to be serialized</param>
		/// <returns></returns>
		object ObjectToRaw(string surrogateUniqueID,object obj);

		/// <summary>
		/// Convert any RAW to object. This is used for deserializing purposes
		/// </summary>
		/// <param name="obj">The object to be deserializing</param>
		object RawToObject(string surrogateUniqueID, object raw);

		/// <summary>
		/// Gets the surrogate object based on the uniqueid
		/// </summary>
		/// <param name="uniqueId">the unique id</param>
		/// <returns></returns>
		object RestoreSurrogate(string uniqueId);

		/// <summary>
		/// Get the unique id of the surrogate
		/// </summary>
		string GetUniqueIdForSurrogate(object obj, string parentUniqueId = null);

        /// <summary>
        /// Un registers a reference between an surrogate and its dependency
        /// </summary>
        /// <param name="surrogate"></param>
        /// <param name="uniqueIdOfLastReferent"></param>
        void RemoveDependency(object surrogate, string uniqueIdOfLastReferent);


        /// <summary>
        /// The implementation of the Getter
        /// </summary>
        Func<object, string, object> GetPropertyGetter(object obj);

		/// <summary>
		/// The implementation of the Setter
		/// </summary>
		Action<object, string, object> GetPropertySetter(object obj);

		void ApplyBindingHandlers(object surrogateValue, Action<bool> bindingAction);

		bool SupportsBinding(object surrogateValue);
        void AddSurrogateReference(IStateObjectSurrogate surrogate, IStateObject reference);
        void RemoveSurrogateReference(IStateObjectSurrogate surrogate, IStateObject reference);
		/// <summary>
		/// Calculates the surrogates to be persisted or removes the one that do not have valid references
		/// </summary>
		void CalculateSurrogatesToBePersisted();
	}
}
