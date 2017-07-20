// *************************************************************************************
// <copyright company="Mobilize" file="ColScrollRegionEventArgs.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************


using System;

namespace Custom.ViewModels.Grid.Event
{
	public class ColScrollRegionEventArgs : EventArgs
	{
		public ColScrollRegionEventArgs(ColScrollRegion colScrollRegion)
		{
			ColScrollRegion = colScrollRegion;
		}
		public ColScrollRegion ColScrollRegion { get; set; }
	}

}
