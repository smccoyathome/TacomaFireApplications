﻿// *************************************************************************************
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
	public interface IUniqueIDGenerator
	{
		string GetPageUniqueID();

		string GetPageItemUniqueID();

        bool IsAllBranchesAttached(string uniqueId);

    }
}
