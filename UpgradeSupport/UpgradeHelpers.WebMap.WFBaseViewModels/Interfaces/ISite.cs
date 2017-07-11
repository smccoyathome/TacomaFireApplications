using System;
using System.Runtime.InteropServices;

namespace UpgradeHelpers.Interfaces
{
	// Summary:
	//     Provides functionality required by sites.
	[ComVisible(true)]
    public interface ISite : IServiceProvider
    {
        // Summary:
        //     Gets the component associated with the System.ComponentModel.ISite when implemented
        //     by a class.
        //
        // Returns:
        //     The System.ComponentModel.IComponent instance associated with the System.ComponentModel.ISite.
        IComponent Component { get; }

        //
        // Summary:
        //     Gets the System.ComponentModel.IContainer associated with the System.ComponentModel.ISite
        //     when implemented by a class.
        //
        // Returns:
        //     The System.ComponentModel.IContainer instance associated with the System.ComponentModel.ISite.
        IContainer Container { get; }

        //
        // Summary:
        //     Determines whether the component is in design mode when implemented by a
        //     class.
        //
        // Returns:
        //     true if the component is in design mode; otherwise, false.
        bool DesignMode { get; }

        //
        // Summary:
        //     Gets or sets the name of the component associated with the System.ComponentModel.ISite
        //     when implemented by a class.
        //
        // Returns:
        //     The name of the component associated with the System.ComponentModel.ISite;
        //     or null, if no name is assigned to the component.
        string Name { get; set; }
    }
}
