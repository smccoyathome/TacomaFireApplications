using System;
using System.Web;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Helpers
{
    /// <summary>
    /// Thread Safe Dictionary for ShareStateItems
    /// </summary>
    public class SharedItemsDictionary
    {
        private System.Collections.Generic.Dictionary<string, object> _sharedItems = new System.Collections.Generic.Dictionary<string, object>(StringComparer.Ordinal);
        private object _locker = new object();
        public T Get<T>()
        {
            var key = typeof(T).FullName;
            var type = typeof(T);
            object item;
            bool isFirstTimeForSinglenton = false;
            lock (_locker)
            {
                if (_sharedItems.TryGetValue(key, out item))
                    return (T)item;
                //Check into storage
                item = (T)StaticContainer.Instance.Resolve(typeof(T), null, IIocContainerFlags.Lean | IIocContainerFlags.ExtraLean | IIocContainerFlags.SinglentonNonReturnIfExisting);
                if (item == null)
                {
                    //That means that the singleton exists
                    //let's get it
                    item = (T)StaticContainer.Instance.Resolve(typeof(T), null, IIocContainerFlags.SinglentonReturnIfExisting);

                    if (item == null) throw new InvalidOperationException("Problem with singlenton");
                }
                else
                    isFirstTimeForSinglenton = true;
                _sharedItems.Add(key, item);
            }
            if (isFirstTimeForSinglenton)
            {
                if (item is IInitializableCommon)
                    InitializationHelpers.CallInitializeCommon(item, type);
                if (item is IInitializable)
                    InitializationHelpers.CallInitMethod((IInitializable)item, null);
            }
            return (T)item;
        }
        public void Clear()
        {
            if (_sharedItems != null)
            {
                _sharedItems.Clear();
                _sharedItems = null;
            }
        }

        internal void Dispose()
        {
            _sharedItems = null;
        }
    }

    public static class StaticContainer
	{
		public static Func<IIocContainer> InitContainer { get; set; }

		[ThreadStatic]
		internal static IIocContainer instance;


		//Shared items must be cleared at the start and end of requests
		[ThreadStatic]
        public static SharedItemsDictionary SharedItems;

        public static IIocContainer Instance
		{
			get { return instance ?? (instance = InitContainer()); }
		}


		/// <summary>
		/// Returns a cached instance that will be available only during this request
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetSharedItem<T>()
		{
            SharedItems = SharedItems ?? new SharedItemsDictionary();
            return SharedItems.Get<T>();
        }



	}
}
