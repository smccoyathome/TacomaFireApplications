using System;
using UpgradeHelpers.Interfaces;

namespace UpgradeHelpers.Events
{



    /// <summary>
    ///     Masks a method as an event handler.  When a business logic object is created by calling any of its
    ///     <see
    ///         cref="IIocContainer.Resolve(System.Type,System.Func{string},object[])" />
    ///     methods all marked methods are registered for business side events.  Handlers are subscribed to an event aggregator object that
    ///     in a decoupled way notifies all subscribed handlers.
    ///     <para>
    ///         By default the marked methods are registered for events by following a naming convention, so method must be called like controlName_eventId
    ///         in order to listen for a specific control event.
    ///     </para>
    ///     <seealso cref="IIocContainer.Resolve(System.Type,System.Func{string},object[])" />
    ///     <seealso cref="IIocContainer.Resolve{T}" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class Handler : Attribute
    {
        //public string Control { get; set; }
        //public string Event { get; set; }
        private readonly string _control;
        private readonly string _event;

        /// <summary>
        ///     Constructs an empty attribute that registers the method for events by following naming conventions.
				///     Naming conventions are ComponentName_EventName
				///<remarks>
				///     NOTE: Form events are not supported
				///</remarks>
        /// </summary>
        public Handler()
        {
        }

        /// <summary>
        ///     Constructs an attribute that listens for events of given control and event id.
        /// </summary>
				/// <remarks>
				///  NOTE: Form events are not supported
				/// </remarks>
        /// <param name="control">Name of the control to listen events for.</param>
        /// <param name="eventId">Id of the event to listen events for.</param>
        public Handler(string control, string eventId)
        {
            _control = control;
            _event = eventId;
        }


				/// <summary>
				/// This attribute is used on classes to register events. It is assume that events belong to the current class
				/// </summary>
				/// <param name="eventId"></param>
				public Handler(string eventId)
				{
					_control = null;
					_event = eventId;
				}

        /// <summary>
        ///     Indicates whether this attribute is a by convention one or not.
        /// </summary>
        public bool IsDefault
        {
            get { return String.IsNullOrEmpty(_control) && String.IsNullOrEmpty(_event); }
        }

        /// <summary>
        ///     Gets the name of the control to listen events for.
        /// </summary>
        /// <returns>Name of the control</returns>
        public string GetControl()
        {
            return _control;
        }

        /// <summary>
        ///     Gets the event id to listens for.
        /// </summary>
        /// <returns>Id of the event</returns>
        public string GetEvent()
        {
            return _event;
        }

    }
}