using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Events
{
    /// <summary>
    ///     Event args class for TypeValidationEvent event handlers.  This class is provided for compilation purposes only,
    ///     because mouse events are not server propagated to server side, instead they are
    ///     converted to client side events (such as JavaScript)
    /// </summary>
    public class TypeValidationEventArgs : EventArgs
    {

        public TypeValidationEventArgs(Type validatingType, bool isValidInput, object returnValue, string message)
        {
            this.IsValidInput = isValidInput;
            this.Message = message;
            this.ReturnValue = returnValue;
            this.ValidatingType = validatingType;
        }

        public bool Cancel { get; set; }
        public bool IsValidInput { get; set; }
        public string Message { get; set; }
        public object ReturnValue { get; set; }
        public Type ValidatingType { get; set; }
    }
}