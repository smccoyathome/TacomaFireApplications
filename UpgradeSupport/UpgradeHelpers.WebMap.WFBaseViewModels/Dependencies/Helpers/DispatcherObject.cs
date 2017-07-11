using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace UpgradeHelpers.Helpers
{
	// Summary:
	//     Represents an object that is associated with a System.Windows.Threading.Dispatcher.
	public abstract class DispatcherObject
    {
        // Summary:
        //     Initializes a new instance of the System.Windows.Threading.DispatcherObject
        //     class.
        protected DispatcherObject()
        {
            //throw new NotImplementedException();
        }

        // Summary:
        //     Gets the System.Windows.Threading.Dispatcher this System.Windows.Threading.DispatcherObject
        //     is associated with.
        //
        // Returns:
        //     The dispatcher.
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [StateManagement(StateManagementValues.ServerOnly)]
        [DefaultValue(null)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dispatcher Dispatcher {
            get { return null; /*throw new NotImplementedException();*/ } 
        }

        // Summary:
        //     Determines whether the calling thread has access to this System.Windows.Threading.DispatcherObject.
        //
        // Returns:
        //     true if the calling thread has access to this object; otherwise, false.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CheckAccess()
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Enforces that the calling thread has access to this System.Windows.Threading.DispatcherObject.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     the calling thread does not have access to this System.Windows.Threading.DispatcherObject.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void VerifyAccess()
        {
            throw new NotImplementedException();
        }
    }
}
