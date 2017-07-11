using System;

namespace UpgradeHelpers.WebMap.Server
{

    public class InterceptionDelegates
    {
        public ProcessGetterMethodDelegate ProcessGetterNoAction;
        public ProcessGetterMethodDelegate ProcessGetterNonTopLevelIStateObject;
        public ProcessGetterMethodDelegate ProcessGetterStrongReference;
        public ProcessGetterMethodDelegate ProcessGetterSurrogate;
        public ProcessGetterMethodDelegate ProcessGetterTopLevelIStateObject;
        public ProcessGetterMethodDelegate ProcessGetterWeakReference;
        public ProcessSetterMethodDelegate ProcessSetterMostCases;
        public ProcessSetterMethodDelegate ProcessSetterObjectReference;
        public ProcessSetterMethodDelegate ProcessSetterSimpleTypes;
        public ProcessSetterMethodDelegate ProcessSetterStrongReference;
        public ProcessSetterMethodDelegate ProcessSetterSurrogate;
        public ProcessSetterMethodDelegate ProcessSetterWeakReference;
        public ProcessSetterMethodDelegate ProcessSetterVisibleState;
        public Func<Type, bool> isASupportedValueTypeForIListDelegate;
    }

}
