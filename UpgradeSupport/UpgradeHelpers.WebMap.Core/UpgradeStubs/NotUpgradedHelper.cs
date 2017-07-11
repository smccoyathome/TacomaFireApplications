using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Extensions
{
    public class NotUpgradedHelper
    {
        public static void NotifyNotUpgradedElement(string msg, Exception excep = null)
        {
			string newMsg = string.Format("{0} {1}{2}\n\n", msg, excep != null ? ",Original Exception (" + excep.Message + "):\n\nOriginal StackTrace: " : string.Empty, excep != null ? excep.StackTrace : string.Empty);
            throw new NotImplementedException(newMsg);
        }


    }
}