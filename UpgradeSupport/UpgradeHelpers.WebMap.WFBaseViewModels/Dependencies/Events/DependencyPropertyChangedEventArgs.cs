using System;
using UpgradeHelpers.Helpers;


namespace UpgradeHelpers.Events
{
    public struct DependencyPropertyChangedEventArgs
    {
        public DependencyProperty Property
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DependencyPropertyChangedEventArgs(DependencyProperty property, object oldValue, object newValue) {
            throw new NotImplementedException();
        }

        public object NewValue { get; set; }
        
    }
}
