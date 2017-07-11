using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Helpers
{
    /// <summary>
    /// Compilation stubs for WPF methods related to UI automation.
    /// They provide no functionality yet.
    /// </summary>
    /// <maps>System.Windows.Media.CompositionTarget</maps>
    public abstract class CompositionTarget : DispatcherObject, IDisposable
    {
        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps><get/></maps>
        public virtual Visual RootVisual
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        //
        // Summary:
        //     Gets a matrix that can be used to transform coordinates from the rendering
        //     destination device to this target.
        public abstract Matrix TransformFromDevice { get; }

        //
        // Summary:
        //     Gets a matrix that can be used to transform coordinates from this target
        //     to the rendering destination device.
        public abstract Matrix TransformToDevice { get; }


        // Summary:
        //     Occurs just before the objects in the composition tree are rendered.
        public static event EventHandler Rendering;

        /// <summary>
        /// Compilation Stub. No implementation
        /// </summary>
        /// <maps>Dispose</maps>
        public virtual void Dispose()
        {
            /*Dispose method has no implementation*/
            System.Diagnostics.Debugger.Break();
        }
    }
}
