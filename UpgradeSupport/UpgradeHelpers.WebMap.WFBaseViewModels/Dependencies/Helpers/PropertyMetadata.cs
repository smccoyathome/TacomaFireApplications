using System;

namespace UpgradeHelpers.Helpers
{
    public class PropertyMetadata
    {
        private Func<DependencyObject, object, object> maskCoerceValueCallBack;        
        private object p;

        public PropertyMetadata() { }



        public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback, object coerceValueCallback) 
        {
            throw new NotImplementedException();
        }
        public PropertyChangedCallback PropertyChangedCallback { get; set; }
    }
}
