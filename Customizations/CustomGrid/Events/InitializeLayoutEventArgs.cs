// *************************************************************************************
// <copyright company="Mobilize" file="InitializeLayoutEventArgs.cs" >
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
    /// Class InitializeLayoutEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class InitializeLayoutEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializeLayoutEventArgs"/> class.
        /// </summary>
        /// <param name="layout">The layout.</param>
        /// <exception cref="System.ArgumentNullException">the layout is null</exception>
        public InitializeLayoutEventArgs(UltraGridLayout layout)
        {
            if (layout == null)
            {
                throw new ArgumentNullException(nameof(layout));
            }

            this.Layout = layout;
        }

        /// <summary>
        /// Gets the layout.
        /// </summary>
        /// <value>The layout.</value>
        public UltraGridLayout Layout { get; }
    }
}