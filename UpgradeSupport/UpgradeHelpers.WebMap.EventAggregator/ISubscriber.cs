// *************************************************************************************
/// <copyright  company="Mobilize" file="ISubscriber.cs">
///     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
///     All helper classes are provided for customer use only;
///     all other use is prohibited without prior written consent from Mobilize.Net.
///     no warranty express or implied;
///     use at own risk.
/// </copyright>
/// <summary></summary>
/// *************************************************************************************
namespace UpgradeHelpers.WebMap.EventAggregator
{
	public interface ISubscriber<in TEventType>
	{
		void OnEventHandler(TEventType e);
	}
}
