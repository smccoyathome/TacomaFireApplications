using System;
using UpgradeHelpers.Events;

namespace UpgradeHelpers.Interfaces
{
    /// <summary>
    ///     Defines an object that implements the Event Aggregator pattern.  This object is responsible for keeping track of
    ///     event subscriptors and notify them every time an event is published.
    /// </summary>
	public interface IEventAggregator
	{
		/// <summary>
		///     Registers for a specific event control.
		/// </summary>
		/// <param name="eventId">Id of the event to listen for</param>
		/// <param name="obj">
		///     <code>IStateObject</code> to listen for events
		/// </param>
		/// <param name="handler">
		///     A <c>Delegate</c> to fire when the event occurs
		/// </param>
        void Subscribe(string eventId, IStateObject obj, Delegate handler, bool isDynamic = false);

		/// <summary>
		///     Verifies if a specific event has handlers attached.
		/// </summary>
		/// <param name="eventId">Id of the event to listen for</param>
		/// <param name="obj">
		///     <code>IStateObject</code> to listen for events
		/// </param>
        IStateObject HasSubscribers(string eventId, IStateObject obj);

        /// <summary>
		///     PUblishes a new event by notifying all subscribers interested in events from <c>source</c>.
		/// </summary>
		/// <param name="eventId">Id of the event to publish</param>
		/// <param name="source">Object that thas originated the event</param>
		/// <param name="args">The additional event arguments</param>
		void Publish(string eventId, IStateObject source, params object[] args);
        /// <summary>
        /// PUblishes a new event by notifying all subscribers interested in events from <c>source</c> it will be always triggered no matter the Events state.
        /// </summary>
        /// <param name="eventId">Id of the event to publish</param>
        /// <param name="source">Object that thas originated the event</param>
        /// <param name="args">The additional event arguments</param>
        void PublishHighPriorityEvent(string eventId, IStateObject source, params object[] args);

        /// <summary>
		/// Pblishes a new event by notifying all subscribers interested in events from <c>source</c>
        /// If the event state is suspended it will be enqueued in order to be executed once the events state is resumed.
		/// </summary>
		/// <param name="eventId">Id of the event to publish</param>
		/// <param name="source">Object that thas originated the event</param>
		/// <param name="args">The additional event arguments</param>
		void PublishOrEnqueueEvent(string eventId, IStateObject source, params object[] args);

        /// <summary>
        ///     Unsubscribes from a specific event
        /// </summary>
        /// <param name="eventId">Id of the event to unsubscribe from.</param>
        /// <param name="obj">
        ///     The <c>IStateObject</c> being unsubscribed.
        /// </param>
        /// <param name="handler">handler to unsubscribe.</param>
        void UnSubscribe(string eventId, IStateObject obj, Delegate handler);

        /// <summary>
        ///     Unsubscribes from a specific event
        /// </summary>
        /// <param name="eventId">Id of the event to unsubscribe from.</param>
        /// <param name="obj">
        ///     The <c>IStateObject</c> being unsubscribed.
        /// </param>
        /// <param name="methodName">name of method to unsubscribe.</param>
        void UnSubscribe(string eventId, IStateObject obj, string methodName);

		/// <summary>
		///     Automatically subscribes all <c>ILogicView</c> methods marked with the <c>Handler</c> attribute.
		///     <para>
		///         The autowired feature uses either notation based mechanism or event information provided thru the <c>Handler</c> attribute
		/// to determine the id of the event and the control name to subscribe to.
		///     </para>
		/// </summary>
		/// <param name="logic">The <c>ILogicView</c> object to wire</param>
		/// <seealso cref="ILogic"/>
		/// <seealso cref="Handler"/>
		void AutoWireEvents(ILogic logic);

		/// <summary>
		/// Temporarily suspends event notification.
		/// </summary>
		void Suspend();

		/// <summary>
		/// Restarts event notification.  Events are not notify at least <c>Resume</c> method is called once per every
		/// <c>Suspend</c> method call.
		/// </summary>
		void Resume();

		/// <summary>
		/// Indicates whether the application is suspended due to state management processing phase.
		/// </summary>
		/// <returns></returns>
		bool IsSuspended();

		void Subscribe(string eventId, IStateObject component, ILogic logic, string methodName);

        void Reset();
        T PublishDelegate<T>(string eventId);

        T PublishToDelegate<T>(string eventId, IStateObject source);
        Delegate PublishToDelegate(string eventId, IStateObject source);

        void Subscribe(string eventId, IStateObject obj, Delegate handler, out string eventSubscriptionId, bool isDynamic = false);

        void Dispose();
    }
}