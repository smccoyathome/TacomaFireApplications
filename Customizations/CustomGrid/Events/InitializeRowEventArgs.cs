// *************************************************************************************
// <copyright company="Mobilize" file="InitializeRowEventArgs.cs" >
//      Copyright (c) 2016 Mobilize, Inc. All Rights Reserved.
//      All helper classes are provided for customer use only;
//      all other use is prohibited without prior written consent from Mobilize.Net.
//      no warranty express or implied;
//      use at own risk.
// </copyright>
// <summary></summary>
// *************************************************************************************
namespace Custom.ViewModels.Grid.Event
{
    using System;

    /// <summary>
    /// Class InitializeRowEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class InitializeRowEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializeRowEventArgs"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <exception cref="System.ArgumentNullException">the row is null</exception>
        public InitializeRowEventArgs(UltraGridRow row,bool reInitialize = false) 
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            this.Row = row;
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>The row.</value>
        public UltraGridRow Row { get; }
    }
}