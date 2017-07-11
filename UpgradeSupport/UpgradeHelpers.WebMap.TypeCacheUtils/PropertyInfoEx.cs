using System;
using System.Reflection;
using UpgradeHelpers.Helpers;
using Fasterflect;
using System.Reflection.Emit;

namespace UpgradeHelpers.WebMap.Server
{

    /// <summary>
    /// Catches general information about the Property taht can be used during interception for delta tracking and serialization
    /// </summary>
    public partial class PropertyInfoEx
    {
        public bool hasReferenceAttribute;
        public bool isStateObject;
        public bool isNonStateObjectFixedType;
        public bool isObjectPropertyType;
        public bool hasSurrogate;
		public bool OnlyHasGetter;
        public bool isAssignableFromIDependantStateObject;
        public bool isAnIList;
        public bool isAnIDictionary;
		public bool mustIgnoreMemberForClient;
		public StateManagementValues stateManagementAttribute;
		public short propertyPositionIndex;
		public string alias;
		public PropertyInfo prop;
        public ProcessGetterMethodDelegate ProcessGetter;
        public ProcessSetterMethodDelegate ProcessSetter;
		private SetterDelegate _originalSetter;
		public void OriginalSetter(object instance, object value)
		{
			if (_originalSetter == null)
				SetterLazyGeneration(instance, value);
			else
				_originalSetter(instance, value);
		}

		public delegate void SetterDelegate(object parent, object value);
        private void SetterLazyGeneration(object parentObject, object value)
        {
            lock (this)
            {
                var prop = this.prop;
                var setMethod = prop.GetSetMethod();
                if (setMethod != null)
                {
                    MethodInfo method = setMethod.GetBaseDefinition();
                    DynamicMethod dm = new DynamicMethod("Base" + method.Name, null, new Type[] { typeof(object), typeof(object) }, parentObject.GetType());
                    ILGenerator gen = dm.GetILGenerator();
                    gen.Emit(OpCodes.Nop);
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Call, method);
                    gen.Emit(OpCodes.Nop);
                    gen.Emit(OpCodes.Ret);
					_originalSetter = (SetterDelegate)dm.CreateDelegate(typeof(SetterDelegate));
                    //System.Runtime.CompilerServices.RuntimeHelpers.PrepareDelegate(OriginalSetter);
					_originalSetter(parentObject, value);
                }
                else
                    throw new NotSupportedException();
        }
        }

        public bool IsExcludedPropertyForSerialization(bool forServerSide, bool skipUniqueID,bool skipObjectProperties)
        {
            if (skipObjectProperties && isObjectPropertyType)
                return true;

            if (isStateObject || hasSurrogate || isAnIList || isAnIDictionary || hasReferenceAttribute)
            {
                return true; //It must be excluded
            }
            if (forServerSide && (stateManagementAttribute == StateManagementValues.None || stateManagementAttribute == StateManagementValues.ClientOnly))
            {
                return true;//It must be excluded
            }
            if (!forServerSide && (stateManagementAttribute == StateManagementValues.None || stateManagementAttribute == StateManagementValues.ServerOnly))
            {
                return true;//It must be excluded
            }
            return prop.Name.Equals("ViewManager", StringComparison.Ordinal) || prop.Name.Equals("Container", StringComparison.Ordinal) ||
                   (skipUniqueID && prop.Name.Equals("UniqueID", StringComparison.Ordinal));
        }

    }



 
}
