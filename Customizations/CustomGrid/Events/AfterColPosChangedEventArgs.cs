// *************************************************************************************
// <copyright company="Mobilize" file="AfterColPosChangedEventArgs.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.ViewModels.Grid.Event
{
	// Summary:
	//     Used to specify what type of position change has occurred
	public enum PosChanged
	{
		// Summary:
		//     Position Moved. The object's position changed because it was moved
		Moved = 0,
		//
		// Summary:
		//     Position Swapped. The object's position changed because it was swapped
		Swapped = 1,
		//
		// Summary:
		//     Position Sized. The object's position changed because it was resized
		Sized = 2,
		//
		// Summary:
		//     Hidden state of the column changed. This is fired when the end user changes
		//     the hidden state of a column, for example via the ColumnChooser functionality.
		HiddenStateChanged = 3,
	}
	public class AfterColPosChangedEventArgs : EventArgs
	{

		// Summary:
		//     Constructor
		//
		// Parameters:
		//   posChanged:
		//     postion changed value
		//
		//   columnHeaders:
		//     columns
		public AfterColPosChangedEventArgs(PosChanged posChanged, ColumnHeader[] columnHeaders)
		{
			ColumnHeaders = columnHeaders;
			PosChanged = posChanged;
		}

		// Summary:
		//     columns (read-only)
		public ColumnHeader[] ColumnHeaders { get; set; }
		//
		// Summary:
		//     postion changed value (read-only)
		public PosChanged PosChanged { get; set; }
	}
}
