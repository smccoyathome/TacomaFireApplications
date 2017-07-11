using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
    /// <summary>
    /// Provides a read-only container for a collection of System.ComponentModel.IComponent
    /// objects.
    /// </summary>
    /// <maps>System.ComponentModel.ComponentCollection</maps>
    [ComVisible(true)]
    public class ComponentCollection : ReadOnlyCollectionBase
    {
        /// <summary>
        /// Initializes a new instance of the System.ComponentModel.ComponentCollection
        /// class using the specified array of components.
        /// </summary>
        /// <param name="components">An array of System.ComponentModel.IComponent objects to initialize the collection with.</param>
        public ComponentCollection(UpgradeHelpers.Interfaces.IComponent[] components) 
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the System.ComponentModel.Component in the collection at the specified 
        /// collection index.
        /// </summary>
        /// <param name="index">The collection index of the System.ComponentModel.Component to get.</param>
        /// <returns>
        /// The System.ComponentModel.IComponent at the specified index.
        /// </returns>
        public virtual UpgradeHelpers.Interfaces.IComponent this[int index] { get { throw new NotSupportedException(); } }

        /// <summary>
        /// Gets any component in the collection matching the specified name.
        /// </summary>
        /// <param name="name">The name of the System.ComponentModel.IComponent to get.</param>
        /// <returns>
        /// A component with a name matching the name specified by the name parameter,
        /// or null if the named component cannot be found in the collection.
        /// </returns>
        public virtual UpgradeHelpers.Interfaces.IComponent this[string name] { get { throw new NotSupportedException(); } }

        /// <summary>
        /// Copies the entire collection to an array, starting writing at the specified
        /// array index.
        /// </summary>
        /// <param name="array">
        /// An System.ComponentModel.IComponent array to copy the objects in the collection
        /// to.
        /// </param>
        /// <param name="index">
        /// The index of the array at which copying to should begin.
        /// </param>
        /// <maps>CopyTo</maps>
        public void CopyTo(UpgradeHelpers.Interfaces.IComponent[] array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
