using System;
using System.Runtime.InteropServices;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Interfaces
{
	// Summary:
	//     Provides functionality for containers. Containers are objects that logically
	//     contain zero or more components.
	[ComVisible(true)]
    public interface IContainer : IDisposable
    {
        // Summary:
        //     Gets all the components in the System.ComponentModel.IContainer.
        //
        // Returns:
        //     A collection of System.ComponentModel.IComponent objects that represents
        //     all the components in the System.ComponentModel.IContainer.
        ComponentCollection Components { get; }

        // Summary:
        //     Adds the specified System.ComponentModel.IComponent to the System.ComponentModel.IContainer
        //     at the end of the list.
        //
        // Parameters:
        //   component:
        //     The System.ComponentModel.IComponent to add.
        void Add(IComponent component);

        //
        // Summary:
        //     Adds the specified System.ComponentModel.IComponent to the System.ComponentModel.IContainer
        //     at the end of the list, and assigns a name to the component.
        //
        // Parameters:
        //   component:
        //     The System.ComponentModel.IComponent to add.
        //
        //   name:
        //     The unique, case-insensitive name to assign to the component.-or- null that
        //     leaves the component unnamed.
        void Add(IComponent component, string name);

        //
        // Summary:
        //     Removes a component from the System.ComponentModel.IContainer.
        //
        // Parameters:
        //   component:
        //     The System.ComponentModel.IComponent to remove.
        void Remove(IComponent component);
    }
}
