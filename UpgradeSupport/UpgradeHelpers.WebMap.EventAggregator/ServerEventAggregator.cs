using System;
using System.Collections.Generic;
using System.Linq;

namespace UpgradeHelpers.WebMap.EventAggregator
{
	public class ServerEventAggregator : IServerEventAggregator
	{

		private static class ServerEventsCache<T>
		{
			internal static readonly Type DefaultType = GetDefaultType();
			private static Type GetDefaultType()
			{
				return typeof(ISubscriber<T>);
			}
		}

		private readonly Dictionary<Type, List<WeakReference>> eventSubsribers = new Dictionary<Type, List<WeakReference>>();

		private readonly object lockSubscriberDictionary = new object();

		#region IEventAggregator Members              

		/// <summary>
		/// Publish an event
		/// </summary>
		/// <typeparam name="TEventType"></typeparam>
		/// <param name="eventToPublish"></param>
		public void PublishEvent<TEventType>(TEventType eventToPublish)
		{
			var subsriberType = ServerEventsCache<TEventType>.DefaultType;
			List<WeakReference> subsribersToBeRemoved = new List<WeakReference>();
			List<WeakReference> subscribers = null;
			lock (lockSubscriberDictionary)
			{
				subscribers = GetSubscriberList(subsriberType);
				foreach (var weakSubsriber in subscribers)
				{
					if (weakSubsriber.IsAlive)
					{
						var subscriber = (ISubscriber<TEventType>)weakSubsriber.Target;

						InvokeSubscriberEvent<TEventType>(eventToPublish, subscriber);
					}
					else
					{
						subsribersToBeRemoved.Add(weakSubsriber);

					}//End-if-else (weakSubsriber.IsAlive)

				}//End-for-each (var weakSubriber in subscribers)
			}

			if (subsribersToBeRemoved.Count > 0)
			{
				lock (lockSubscriberDictionary)
				{
					foreach (var remove in subsribersToBeRemoved)
					{
						subscribers.Remove(remove);

					}//End-for-each (var remove in subsribersToBeRemoved)

				}//End-lock (lockSubscriberDictionary)

			}//End-if (subsribersToBeRemoved.Any())
		}

		/// <summary>
		/// Subribe to an event.
		/// </summary>
		/// <param name="subscriber"></param>
		public void SubsribeEvent(object subscriber)
		{
			lock (lockSubscriberDictionary)
			{
				var subsriberTypes = subscriber.GetType().GetInterfaces()
										.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

				WeakReference weakReference = new WeakReference(subscriber);

				foreach (var subsriberType in subsriberTypes)
				{
					List<WeakReference> subscribers = GetSubscriberList(subsriberType);

					subscribers.Add(weakReference);

				}//End-for-each (var subsriberType in subsriberTypes)

			}//End-lock (lockSubscriberDictionary)
		}



		#endregion

		private void InvokeSubscriberEvent<TEventType>(TEventType eventToPublish, ISubscriber<TEventType> subscriber)
		{
			subscriber.OnEventHandler(eventToPublish);
		}

		private List<WeakReference> GetSubscriberList(Type subsriberType)
		{
			List<WeakReference> subsribersList = null;

			lock (lockSubscriberDictionary)
			{
				bool found = this.eventSubsribers.TryGetValue(subsriberType, out subsribersList);

				if (!found)
				{
					//First time create the list.

					subsribersList = new List<WeakReference>();

					this.eventSubsribers.Add(subsriberType, subsribersList);

				}//End-if (!found)

			}//End-lock (lockSubscriberDictionary)

			return subsribersList;
		}
	}
}
