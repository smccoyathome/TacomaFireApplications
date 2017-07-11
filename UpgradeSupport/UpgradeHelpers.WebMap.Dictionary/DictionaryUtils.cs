using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.WebMap.Server
{

    public class DictionaryUtils
    {
        public delegate IPromise CreateEventInstanceDelegate(IStateManager stateManager, Delegate del);

        public delegate object FromContinuationInfoDelegate(Type type, IPromise cont);

        public delegate object GetObjectContainingMethodDelegate(IPromise promise);


        public static Func<IStateManager> Current;

        public static CreateEventInstanceDelegate CreatePromise;

        public static FromContinuationInfoDelegate RetrieveDelegateFromPromise;

        public static GetObjectContainingMethodDelegate GetObjectContainingMethod;
    }

}