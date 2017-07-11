//ViewModel CustomBinding
(<any>kendo).data.binders.widget.widgetvalue = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        var binding: any = this.bindings.widgetvalue;
        var widget: Mobilize.Widgets.WidgetBase = this.element;
        widget.setViewModel(binding.get())
    },
    refresh: function () {
    }
});

module Mobilize.Widgets {
    //Constants
    export const EVENTS = {
        CHANGE: "change",
        SET: "set",
        DBLCLICK: "dblclick",
        DATABOUND: "dataBound"
    }
    export class WidgetBase implements IWidget {
        private fieldsSetListeners: { [uniqueid: string]: { [id: string]: { (e: any): void; }[] } } = {};
        // In order to update the UI, with changes comming from the server we are going to Queue them, in order to call
        //the refresh handlers associated to a property, just once.
        private timeoutHandlers: { [uniqueid: string]: { [id: string]: number; } } = {};
        //Is the Grid Initialized?
        public isInitialized: boolean = false;
        //ViewModel instance being binded to the Widget.
        public ViewModel: IViewModel;
        //Base type
        public BaseType: any = kendo.ui.Widget;
        //
        // Adds a Listener in case a field changes.
        //
        addFieldListener(fieldName: string, handler: { (e: IChangeEvent): void; }) {
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                this.fieldsSetListeners[this.ViewModel.UniqueID] = {};
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName])
                this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName] = [];
            this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName].push(handler);
        }

        restoreEvents(events) {
            $.extend(true, (<any>this)._events, events);
        }
        //Get the current events.
        getCurrentEvents() {
            var oldEvents = (<any>this)._events;
            delete oldEvents["change"];
            return oldEvents;
        }
        //
        // Adds a Listener in case a field changes.
        //
        removeFieldListener(fieldName: string, handler: { (e: IChangeEvent): void; }) {
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                return;
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName])
                return;
            var listeners = this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName];
            for (var i = 0; i < listeners.length; i++) {
                if (listeners[i] == handler)
                    listeners.splice(i, 1);
            }
        }
        //
        //Removes the hanlders associated to a widget
        //
        clearHandlersOfModel() {
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                return;
            else
                delete this.fieldsSetListeners[this.ViewModel.UniqueID];
            if (!this.timeoutHandlers[this.ViewModel.UniqueID])
                return;
            else
                delete this.timeoutHandlers[this.ViewModel.UniqueID];
        }
        //Intercepts the 
        setViewModel(val: IViewModel) {
            //If the UI is not initialized. We initializr the grid.
            if (!this.isInitialized && val && !this.ViewModel) {
                try {
                    //Sets the ViewModel binded to the Grid to this instance.
                    this.ViewModel = val;
                    this.initUI();
                    this.isInitialized = true;
                } catch (e) {
                    console.error("Error initializing the Widget: " + e);
                }
            }
        }
        destroy() {
            (<any>this).oldEvents = this.getCurrentEvents();
            (<any>this.BaseType).fn.destroy.call(this);
            if (this.isInitialized) {
                this.clearHandlersOfModel();
            }
        }
        initUI() {
            // Only if the Grid is not initialized we need to wire the events 
            //and handlers.
            if (!this.isInitialized) {
                //Initializes the Widget Refresh handlers.
                this.setRefreshHandlers();
            }
            if ((<any>this).oldEvents) {
                this.restoreEvents((<any>this).oldEvents);
                delete (<any>this).oldEvents;
            }
        }
        setEvents() {
        }
        //Sets all the handlers related to the widget refresh.
        private setRefreshHandlers(): void {
            this.ViewModel.bind(EVENTS.SET, this.ViewModel_SetRefresh.bind(this));
        }
        //Handler that handles the Field listeners.
        private ViewModel_SetRefresh(e: IChangeEvent) {
            //Let's get the modified field.
            var propertyChanged = e.field;
            if (!this.fieldsSetListeners[this.ViewModel.UniqueID])
                return;
            //Does it have any listener registered?
            var hasListener = this.fieldsSetListeners[this.ViewModel.UniqueID].hasOwnProperty(propertyChanged);
            if (hasListener) {
                this.QueueFieldListeners(e.field, e);
            }
        }
        //
        // In case a property is modified then we should execute the
        //handlers related to it, but only once. The why we queue them
        //for later.
        private QueueFieldListeners(fieldName: string, event: IChangeEvent) {
            //Is that model being listened?
            if (!this.timeoutHandlers[this.ViewModel.UniqueID])
                this.timeoutHandlers[this.ViewModel.UniqueID] = {};
            //Do we have a handler already queued for this property?
            var queued = this.timeoutHandlers[this.ViewModel.UniqueID][fieldName];
            if (!queued) {
                // Let's register a timeout Id so that, we can track
                //the handlers associated to the Field and also cancel 
                //them if required.
                this.timeoutHandlers[this.ViewModel.UniqueID][fieldName] = setTimeout((() => {
                    //Retrieves the handlers associated with a property change
                    var fieldListeners = this.fieldsSetListeners[this.ViewModel.UniqueID][fieldName];
                    for (var i = 0; i < fieldListeners.length; i++) {
                        //For each Handler in the list, we 
                        //execute it with the the right context.
                        var listener = fieldListeners[i];
                        try {
                            listener.call(this, event);
                        } catch (ex) {
                            console.error("Error executing change handler for the field name: " + fieldName + " Error:" + ex);
                        }
                    }
                    //Removes the timeout handler for the property.
                    delete this.timeoutHandlers[this.ViewModel.UniqueID][fieldName]
                }).bind(this), 0);
            }
        }

    }
    
}