using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UpgradeHelpers.Interfaces
{
    // Summary:
    //     Provides functionality required by all components.
    [ComVisible(true)]
    [RootDesignerSerializer("System.ComponentModel.Design.Serialization.RootCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true)]
    [System.ComponentModel.TypeConverter(typeof(ComponentConverter))]
    public interface IComponent : IDisposable
    {
		// Summary:
		//     Gets or sets the System.ComponentModel.ISite associated with the System.ComponentModel.IComponent.
		//
		// Returns:
		//     The System.ComponentModel.ISite object associated with the component; or
		//     null, if the component does not have a site.
		UpgradeHelpers.Interfaces.ISite Site { get; set; }

        // Summary:
        //     Represents the method that handles the System.ComponentModel.IComponent.Disposed
        //     event of a component.
        event EventHandler Disposed;
    }
}
