// *************************************************************************************
// <copyright  company="Mobilize" file="ILazyStateObject.cs">
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
	public interface ILazyObject
	{
		/// <summary>
		/// The unique id of the pointed target unique id
		/// </summary>
		string TargetUniqueID { get; }

		/// <summary>
		/// The pointed target object. The concrete implementation should use the IStateObject to get objects from storage or cache.
		/// </summary>
		object Target { get; }
	}
}
