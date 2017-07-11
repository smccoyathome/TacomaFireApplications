using System;
using System.Reflection;

namespace UpgradeHelpers.Helpers
{
    public class DependencyProperty
    {

        public string _name;
        public Type _propertyType;
        public Type _ownerType;
        public PropertyMetadata _typeMetadata;

        public object GetValue(DependencyProperty dp)
        {
            return null;
        }

        public void SetValue(DependencyProperty dp, object value)
        {
        }
        
        public static DependencyProperty Register(string name, Type propertyType, Type ownerType)
        {
            throw new NotImplementedException();
        }

        public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
        {
            DependencyProperty dp = new DependencyProperty();
            dp._name = name;
            dp._propertyType = propertyType;
            dp._ownerType = ownerType;
            dp._typeMetadata = typeMetadata;

            return dp;

        }
        public static DependencyProperty RegisterAttached(string p, Type type1, Type type2, PropertyMetadata propertyMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
