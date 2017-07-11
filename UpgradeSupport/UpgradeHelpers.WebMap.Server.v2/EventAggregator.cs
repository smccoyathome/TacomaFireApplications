using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Fasterflect;
using UpgradeHelpers.Events;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.WebMap.Server.Common;

namespace UpgradeHelpers.WebMap.Server
{
	internal class EventAggregator : IEventAggregator
	{

		private StateManager _stateManager;
        private ViewManager _viewManager;
		public EventAggregator(StateManager stateManager, ViewManager _viewManager)
		{
			this._stateManager = stateManager;
            this._viewManager = _viewManager;

		}

		public void Subscribe(string eventId, IStateObject component, ILogic logic, string methodName)
		{
			var type = logic.GetType();
			var method = type.Method(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | Flags.ExcludeBackingMembers);
			RegisterMethodForEvent(logic, method, component.ToString(), eventId, component);

		}

		public void Subscribe(string eventId, IStateObject obj, Delegate handler, bool isDynamic = false)
		{
			var eventSubscriptionId = String.Empty;
			Subscribe(eventId, obj, handler, out eventSubscriptionId, isDynamic);
		}

        /// <summary>
        /// Will register a subscriber. Event will be recognized by "eventId" and will be attached to 
        /// obj
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="obj"></param>
        /// <param name="handler"></param>
		public void Subscribe(string eventId, IStateObject obj, Delegate handler, out string eventSubscriptionId, bool isDynamic = false)
        {
			var result = String.Empty;
			if (handler != null)
			{
				//get/created subscribed promises info 
				eventId = eventId.ToUpper();
				var handlerSubscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(obj, eventId);
				LazyBehaviours.AddDependent(obj, UniqueIDGenerator.EVENTPrefix + eventId);
				var promisesInfo = PromisesInfo.CreateInstance(handlerSubscriptionId);

				////subscribe handler
				var eventMethodName = handler.Method.Name.ToUpper() + eventId;
				eventSubscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(obj, eventMethodName);
				LazyBehaviours.AddDependent(obj, UniqueIDGenerator.EVENTPrefix + eventMethodName);
				promisesInfo.Add(eventMethodName);
				if (isDynamic)
					EventPromiseInfoForClient.CreateEventInstance(_stateManager,handler, obj, eventSubscriptionId, actionID: eventId);
				else
					EventPromiseInfo.CreateEventInstance(_stateManager,handler, obj, eventSubscriptionId);
#if DEBUG
				Debug.Assert(_stateManager.GetObject(eventSubscriptionId) != null, "Event Subscription Failed", "Event for {0} on Object {1} failed", eventId, obj.UniqueID);
#endif
				result = eventSubscriptionId;
			}
			eventSubscriptionId = result;
		}


        public Delegate PublishToDelegate(string eventId, IStateObject source) 
        {
            eventId = eventId.ToUpper();
            var promisesInfo = HasSubscribers(eventId, source) as PromisesInfo;
            if (promisesInfo != null)
            {
                foreach (string eventsnameid in promisesInfo.GetListMethodsMame())
                {
                    var subscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(source, eventsnameid);
                    var eventHandlerInfo = _stateManager.GetObject(subscriptionId) as EventPromiseInfo;
                    if (eventHandlerInfo != null)
                    {
                        var result = this.PublishInternal(eventHandlerInfo, eventId, source, true, null);
                        return result;
                    }
                    else
                    {
                        TraceUtil.TraceError(string.Format("EventAggregator::PublishToMainSyncronizationContext. No Events found for EventId [{0}] on object [{1}]", subscriptionId, source == null ? "null" : source.UniqueID));
                    }
                }
            }
            else
            {
                TraceUtil.TraceError(string.Format("HandlersEventAggregator::PublishToMainSyncronizationContext. No Events found for EventId [{0}] on object [{1}]", eventId, source == null ? "null" : source.UniqueID));
            }
            return null;
        }

        public T PublishToDelegate<T>(string eventId, IStateObject source)
        {
            var result = PublishToDelegate(eventId, source);
            if (result != null)
            {
                return (T)(object)Delegate.CreateDelegate(typeof(T), result.Target, result.Method);
            }
            return default(T);
            
        }


        public void PublishHighPriorityEvent(string eventId, IStateObject source, params object[] args)
		{
			PublishInternal(eventId, source, args);
		}

        public void Publish(string eventId, IStateObject source, params object[] args)
        {
			if (suspendedState > 0) 
					return;
			PublishInternal(eventId, source, args);
		}

		private void PublishInternal(string eventId, IStateObject source, object[] args)
		{

            eventId = eventId.ToUpper();
            var promisesInfo = HasSubscribers(eventId, source) as PromisesInfo;
            if (promisesInfo != null)
            {
                foreach (string eventsnameid in promisesInfo.GetListMethodsMame())
                {
                    var subscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(source, eventsnameid);
                    var eventHandlerInfo = _stateManager.GetObject(subscriptionId) as EventPromiseInfo;
                    if (eventHandlerInfo != null)
					{
                        this.PublishInternal(eventHandlerInfo, eventId, source, false, args);
					}
                    else
					{
						TraceUtil.TraceError(string.Format("EventAggregator::PublishInternal. No Events found for EventId [{0}] on object [{1}]", subscriptionId, source == null ? "null" : source.UniqueID));
                    }
                }
            }
            else
            {
				TraceUtil.TraceError(string.Format("HandlersEventAggregator::PublishInternal. No Events found for EventId [{0}] on object [{1}]", eventId, source == null ? "null" : source.UniqueID));
            }
		}

		public T PublishDelegate<T>(string eventId)
		{
			Delegate result = null;

			var eventHandlerInfo = _stateManager.GetObject(eventId) as EventPromiseInfo;

			if (eventHandlerInfo != null)
			{
				var delegateType = TypeCacheUtils.GetType(eventHandlerInfo.DelegateType);
				result = PromiseUtils.FromContinuationInfo(delegateType, eventHandlerInfo) as Delegate;
			}
			return result == null ? default(T) : (T)(object)Delegate.CreateDelegate(typeof(T), result.Target, result.Method);

		}

        private Delegate PublishInternal(EventPromiseInfo eventHandlerInfo, string eventId, IStateObject source,bool doNotCall, params object[] args)
        {
            var delegateType = TypeCacheUtils.GetType(eventHandlerInfo.DelegateType);
            Delegate eventDelegate = PromiseUtils.FromContinuationInfo(delegateType, eventHandlerInfo, source) as Delegate;
            if (eventDelegate == null)
            {
				TraceUtil.TraceError("EventAggregator::PublishInternal Error publishing event. Continuation could not be restored");
                return null;
            }
            if (doNotCall)
                return eventDelegate;
            TraceUtil.TraceInformation("Publishing event " + eventId);
            if (eventDelegate != null)
            {
                try
                {
                   eventDelegate.Method.Invoke(eventDelegate.Target, args);
                }
                catch (TargetInvocationException tiex)
                {
                    var baseException = tiex.GetBaseException();
                    PreserveStackTrace(baseException);
                    throw baseException;
                }
            }
            return eventDelegate;
        }

        private static void PreserveStackTrace(Exception e)
        {
            try
            {
                var ctx =
                    new System.Runtime.Serialization.StreamingContext(
                        System.Runtime.Serialization.StreamingContextStates.CrossAppDomain);
                var mgr = new System.Runtime.Serialization.ObjectManager(null, ctx);
                var si = new System.Runtime.Serialization.SerializationInfo(e.GetType(),
                    new System.Runtime.Serialization.FormatterConverter());

                e.GetObjectData(si, ctx);
                mgr.RegisterObject(e, 1, si); // prepare for SetObjectData
                mgr.DoFixups(); // ObjectManager calls SetObjectData

                // voila, e is unmodified save for _remoteStackTraceString
            }
            catch
            {
                //If it doesnt work then, just do as always. There is nothing else we can do
            }
        }

        public void UnSubscribe(string eventId, IStateObject source,Delegate handler)
		{
            this.UnSubscribe(eventId, source, handler.Method.Name);
		}

		public void UnSubscribe(string eventId, IStateObject source,string methodName)
        {
            eventId = eventId.ToUpper();
            var promisesInfo = HasSubscribers(eventId, source) as PromisesInfo;
            if (promisesInfo != null)
            {
                methodName = methodName.ToUpper();
                promisesInfo.Remove(methodName);
                var eventSubscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(source, methodName + eventId);
				_stateManager.RemoveObject(eventSubscriptionId, true);

                if (promisesInfo.IsEmpty())
                {
                    eventSubscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(source,eventId);
                    _stateManager.RemoveObject(eventSubscriptionId, true);
				}
            }
        }


		private const string NONCOMPONENT_EVENT = "@@@###@@@NONCOMPONENTEVENT";


        public void AutoWireEvents(ILogic logic)
        {
            var logicType = logic.GetType();
            var methodsForAutoWire = TypeCacheUtils.NeedsAutoWire(logicType);
            foreach (var methodEx in methodsForAutoWire)
			{
                var method = methodEx.method;
                var attr = methodEx.HandlerAttribute;
				ILogicWithViewModel<IViewModel> logicWithViewModel = logic as ILogicWithViewModel<IViewModel>;
				string componentName;
				string eventId;
				//We have an attribute with no arguments like [Handler] void MethodName(...) { ... }
				if (attr.IsDefault)
				{
                    if (methodEx.MethodAndEventParts != null)
					{
                        var methodNameParts = methodEx.MethodAndEventParts;
						Debug.Assert(methodNameParts.Count() == 2);
						componentName = methodNameParts[0];
						eventId = methodNameParts[1];
					}
					else
					{
						componentName = null;
						eventId = method.Name;
					}
				}
				else
				{
					componentName = attr.GetControl();
					eventId = attr.GetEvent();
				}
                TraceUtil.WriteLine(string.Format("AutoWire Event for {0} {1}", componentName, eventId));
				//Is this event on a Form?
				if (logicWithViewModel != null)
				{
					if (logicWithViewModel.ViewModel == null)
					{
						Debug.Assert(false, "A Form does not have its corresponding ViewModel");
					}
					else
					{
						if (componentName != null)
						{
							var componentProp = logicWithViewModel.ViewModel.GetType().Property(componentName);
							if (componentProp != null)
							{
								var component = componentProp.GetValue(logicWithViewModel.ViewModel, null) as IStateObject;
								var controlArray = component is IList;
								if (component != null && !controlArray)
									RegisterMethodForEvent(logicWithViewModel, method, componentName, eventId, component);
								else if (component == null && componentProp.PropertyType.IsArray)
								{
									var array = logicWithViewModel.ViewModel.GetPropertyValue(componentName) as IList;
									if (array != null)
									{
										foreach (IStateObject element in array)
										{
											RegisterMethodForEvent(logicWithViewModel, method, componentName, eventId, element);
										}
									}
								}
							}
						}
					}
				}
				else if (logic is IStateObject)
				{
					IStateObject stateObject = (IStateObject)logic;
					//If this is not a form then it must something like an IModel or an IDependentViewModel
					if (componentName != null)
					{
                        var componentProp = logicType.Property(componentName);
						if (componentProp != null)
						{
							var component = componentProp.GetValue(logic, null) as IStateObject;
							if (component != null)
							{
								RegisterMethodForEvent(logic, method, componentName, eventId, component);
							}
							else
							{
                                TraceUtil.TraceError("EventAggregator::AutoWriteEvents failed for method [" + method.Name + "] property not found for [" + componentName + "]");
								continue;
							}
						}
					}
					else
						RegisterMethodForEvent(logic, method, NONCOMPONENT_EVENT, eventId, stateObject);
				}
				else
				{
					throw new NotSupportedException("Events can only be register on object instances implementing ILogicView<T> or (ILogic and IDependentViewModel) or IModel");
				}

            }
        }

        private void RegisterMethodForEvent(ILogic logic, MethodInfo method, string componentName, string eventId, IStateObject component) 
		{
			var parameters = method.GetParameters();
			Debug.Assert(component != null, 
					"Invalid AutoWire for event handler " + method.Name + " component " + componentName + " was not found in viewmodel. Logic Type [ " + logic.GetType() + "]");
			if (component != null)
					Subscribe(eventId, component, PromiseUtils.CreateDelegateFromMethodInfo(logic, method));
		}
	
		[ThreadStatic]
		static int suspendedState; //Every Thread must handle the SuspendedState of the Events.
        

        [ThreadStatic]
        static Queue<Action> pendingEvents;
        private static Queue<Action> PendingEvents
        {
            get
            {
                if (pendingEvents == null)//suspendedState is Lazy, it's initialized when used.
                    pendingEvents = new Queue<Action>();
                return pendingEvents;
            }
        }
        public void Suspend()
		{
            suspendedState++;
		}

		public void Resume()
		{
			if (suspendedState > 0)
				suspendedState--;
            if (suspendedState == 0)
            {
                if (pendingEvents != null && pendingEvents.Count > 0)
                {
                    while (pendingEvents.Count > 0)
                    {
                        var action = pendingEvents.Dequeue();
                        action.Invoke();
                    }
                }
            }
//#if EVENTS_DEBUG
//            if (suspendedState.Count==0)
//                 Debug.WriteLine("Events Resumed");
//#endif
		}

		public bool IsSuspended()
		{
			return suspendedState > 0;
		}


        public IStateObject HasSubscribers(string eventId, IStateObject source)
		{
			eventId = eventId.ToUpper();
			if (source == null)
			{
                TraceUtil.TraceError("EventAggregator::PublishHighPriorityEvent Error publishing event [" + eventId + "] source argument should not be null");
				return null;
			}
			var subscriptionId = UniqueIDGenerator.GetEventRelativeUniqueID(source, eventId);
            var promisesInfo = _stateManager.GetObject(subscriptionId) as PromisesInfo;
            return promisesInfo;
		}



		public void Reset()
		{
            suspendedState = 0;
		}

        public void PublishOrEnqueueEvent(string eventId, IStateObject source, params object[] args)
        {
            if (suspendedState > 0)
            {
                PendingEvents.Enqueue(() =>PublishInternal(eventId, source, args));
            }
            else
            {
                PublishInternal(eventId, source, args);
            }
                
        }


		public void Dispose()
		{
            if (pendingEvents != null)
                pendingEvents.Clear();
			_stateManager = null;
			_viewManager = null;
		}
	}
}
