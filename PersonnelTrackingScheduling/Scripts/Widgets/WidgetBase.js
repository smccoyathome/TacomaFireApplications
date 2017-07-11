//ViewModel CustomBinding
kendo.data.binders.widget.widgetvalue = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        var binding = this.bindings.widgetvalue;
        var widget = this.element;
        widget.setViewModel(binding.get());
    },
    refresh: function () {
    }
});
var Mobilize;
(function (Mobilize) {
    var Widgets;
    (function (Widgets) {
        //Constants
        Widgets.EVENTS = {
            CHANGE: "change",
            SET: "set",
            DBLCLICK: "dblclick",
            DATABOUND: "dataBound"
        };
        var WidgetBase = (function () {
            function WidgetBase() {
                this.fieldsSetListeners = {};
                // In order to update the UI, with changes comming from the server we are going to Queue them, in order to call
                //the refresh handlers associated to a property, just once.
                this.timeoutHandlers = {};
                //Is the Grid Initialized?
                this.isInitialized = false;
                //Base type
                this.BaseType = kendo.ui.Widget;
            }
            //
            // Adds a Listener in case a field changes.
            //
            WidgetBase.prototype.addFieldListener = function (fieldName, handler) {
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                    this.fieldsSetListeners[this.ViewModel.UniqueID] = {};
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName])
                    this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName] = [];
                this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName].push(handler);
            };
            WidgetBase.prototype.restoreEvents = function (events) {
                $.extend(true, this._events, events);
            };
            //Get the current events.
            WidgetBase.prototype.getCurrentEvents = function () {
                var oldEvents = this._events;
                delete oldEvents["change"];
                return oldEvents;
            };
            //
            // Adds a Listener in case a field changes.
            //
            WidgetBase.prototype.removeFieldListener = function (fieldName, handler) {
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                    return;
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName])
                    return;
                var listeners = this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName];
                for (var i = 0; i < listeners.length; i++) {
                    if (listeners[i] == handler)
                        listeners.splice(i, 1);
                }
            };
            //
            //Removes the hanlders associated to a widget
            //
            WidgetBase.prototype.clearHandlersOfModel = function () {
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                    return;
                else
                    delete this.fieldsSetListeners[this.ViewModel.UniqueID];
                if (!this.timeoutHandlers[this.ViewModel.UniqueID])
                    return;
                else
                    delete this.timeoutHandlers[this.ViewModel.UniqueID];
            };
            //Intercepts the 
            WidgetBase.prototype.setViewModel = function (val) {
                //If the UI is not initialized. We initializr the grid.
                if (!this.isInitialized && val && !this.ViewModel) {
                    try {
                        //Sets the ViewModel binded to the Grid to this instance.
                        this.ViewModel = val;
                        this.initUI();
                        this.isInitialized = true;
                    }
                    catch (e) {
                        console.error("Error initializing the Widget: " + e);
                    }
                }
            };
            WidgetBase.prototype.destroy = function () {
                this.oldEvents = this.getCurrentEvents();
                this.BaseType.fn.destroy.call(this);
                if (this.isInitialized) {
                    this.clearHandlersOfModel();
                }
            };
            WidgetBase.prototype.initUI = function () {
                // Only if the Grid is not initialized we need to wire the events 
                //and handlers.
                if (!this.isInitialized) {
                    //Initializes the Widget Refresh handlers.
                    this.setRefreshHandlers();
                }
                if (this.oldEvents) {
                    this.restoreEvents(this.oldEvents);
                    delete this.oldEvents;
                }
            };
            WidgetBase.prototype.setEvents = function () {
            };
            //Sets all the handlers related to the widget refresh.
            WidgetBase.prototype.setRefreshHandlers = function () {
                this.ViewModel.bind(Widgets.EVENTS.SET, this.ViewModel_SetRefresh.bind(this));
            };
            //Handler that handles the Field listeners.
            WidgetBase.prototype.ViewModel_SetRefresh = function (e) {
                //Let's get the modified field.
                var propertyChanged = e.field;
                if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                    return;
                //Does it have any listener registered?
                var hasListener = this.fieldsSetListeners[this.ViewModel.UniqueID].hasOwnProperty(propertyChanged);
                if (hasListener) {
                    this.QueueFieldListeners(e.field, e);
                }
            };
            //
            // In case a property is modified then we should execute the
            //handlers related to it, but only once. The why we queue them
            //for later.
            WidgetBase.prototype.QueueFieldListeners = function (fieldName, event) {
                var _this = this;
                //Is that model being listened?
                if (!this.timeoutHandlers[this.ViewModel.UniqueID])
                    this.timeoutHandlers[this.ViewModel.UniqueID] = {};
                //Do we have a handler already queued for this property?
                var queued = this.timeoutHandlers[this.ViewModel.UniqueID][fieldName];
                if (!queued) {
                    // Let's register a timeout Id so that, we can track
                    //the handlers associated to the Field and also cancel 
                    //them if required.
                    this.timeoutHandlers[this.ViewModel.UniqueID][fieldName] = setTimeout((function () {
                        //Retrieves the handlers associated with a property change
                        var fieldListeners = _this.fieldsSetListeners[_this.ViewModel.UniqueID][fieldName];
                        for (var i = 0; i < fieldListeners.length; i++) {
                            //For each Handler in the list, we 
                            //execute it with the the right context.
                            var listener = fieldListeners[i];
                            try {
                                listener.call(_this, event);
                            }
                            catch (ex) {
                                console.error("Error executing change handler for the field name: " + fieldName + " Error:" + ex);
                            }
                        }
                        //Removes the timeout handler for the property.
                        delete _this.timeoutHandlers[_this.ViewModel.UniqueID][fieldName];
                    }).bind(this), 0);
                }
            };
            return WidgetBase;
        }());
        Widgets.WidgetBase = WidgetBase;
    })(Widgets = Mobilize.Widgets || (Mobilize.Widgets = {}));
})(Mobilize || (Mobilize = {}));
//# sourceMappingURL=WidgetBase.js.map