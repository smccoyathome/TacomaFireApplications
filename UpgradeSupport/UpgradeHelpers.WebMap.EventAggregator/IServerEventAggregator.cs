// *************************************************************************************
/// <copyright  company="Mobilize" file="IServerEventAggregator.cs">
///     Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
///     All helper classes are provided for customer use only;
///     all other use is prohibited without prior written consent from Mobilize.Net.
///     no warranty express or implied;
///     use at own risk.
/// </copyright>
/// <summary></summary>
/// *************************************************************************************
using System;

namespace UpgradeHelpers.WebMap.EventAggregator
{
	public interface IServerEventAggregator
	{
		void PublishEvent<TEventType>(TEventType eventToPublish);

		void SubsribeEvent(Object subscriber);
	}
}
