// *************************************************************************************
// <copyright company="Mobilize" file="RowScrollRegionEventArgs.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************

using System;
using System.ComponentModel;

namespace Custom.ViewModels.Grid.Event
{
	public class RowScrollRegionEventArgs: CancelEventArgs
	{
		// Summary:
		//     Constructor
		//
		// Parameters:
		//   rowScrollRegion:
		public RowScrollRegionEventArgs(RowScrollRegion rowScrollRegion)
		{
			RowScrollRegion = rowScrollRegion;
		}

		// Summary:
		//     The row scroll region (read-only)
		public RowScrollRegion RowScrollRegion { get; set; }
	}
}
