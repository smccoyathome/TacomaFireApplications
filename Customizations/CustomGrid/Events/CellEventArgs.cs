// *************************************************************************************
// <copyright company="Mobilize" file="CellEventArgs.cs" >
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
	/// <summary>
	/// Class CellEventArgs.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class CellEventArgs : EventArgs
	{
		public CellEventArgs(UltraGridCell cell)
		{
			Cell = cell;
		}

		public UltraGridCell Cell { get; set; }
	}
}
