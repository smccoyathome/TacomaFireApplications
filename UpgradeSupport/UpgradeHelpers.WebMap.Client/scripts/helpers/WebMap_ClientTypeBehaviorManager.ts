module WebMap.Client {

    /**
     * Holds the catalog of client side behaviours
     * And interacts with the state manager
     */
    export class ClientTypeBehaviourManager {

        public static Current: ClientTypeBehaviourManager;

        private static handlers: { [index: number]: IClientTypeBehaviour; };

        private postOrganizeActions: Array<() => void>;

        private postShowViewsActions: Array<() => void>;

        /**
         * Registers a Client Type Behaviour.
         * By default:
         * 1 --> ArraysClientTypeBehaviour
         * 2 --> StateObjectPointerClientTypeBehaviour
		 */
        public registerHandler(id: number, handler: IClientTypeBehaviour) {
            ClientTypeBehaviourManager.handlers[id] = handler;
        }


        /**
         * Returns the associated Client Type Behaviour
         */
        public getBehaviour(obj: any): IClientTypeBehaviour {
            if (!obj) return undefined;
            //Built in typemappings
            var typeMark = obj["@k"];
		    //Currently there is an issue with Newtonsoft. The JsonProperty setting is ignore and we are getting @k and k as well
            if (typeMark && ((typeMark == "1") || (obj["k"] == "1"))) {
                return ClientTypeBehaviourManager.handlers[1];
            }
            return ClientTypeBehaviourManager.handlers[typeMark];
        }


        public getBehaviourByID(typeMark: any): IClientTypeBehaviour {
            return ClientTypeBehaviourManager.handlers[typeMark];
        }

        /**
         * Registers a function that will be trigger when the standard state organization actions are finished
         */
        public registerPostOrganizeAction(action: () => void) {
            if (!this.postOrganizeActions) {
                this.postOrganizeActions = [];
            }
            this.postOrganizeActions.push(action);
        }

        /**
         * Registers a function that will be trigger when the standard state organization actions are finished
         */
        public registerPostShowViewsAction(action: () => void) {
            if (!this.postShowViewsActions) {
                this.postShowViewsActions = [];
            }
            this.postShowViewsActions.push(action);
        }

        /**
         * Execute any post-organized actions registered by any of the client side behaviours
         */
        public execPostOrganizeActions() {
            if (!this.postOrganizeActions) return;
            for (var i = 0; i < this.postOrganizeActions.length; i++) {
                try {
                    this.postOrganizeActions[i]();
                }
                catch (excepPostOrganizeAction) {
                    console.error("ClientTypeBehaviourManager::execPostOrganizeAction error on postOrganize action " + excepPostOrganizeAction);
                }
            }
            //free all actions
            this.postOrganizeActions = undefined;
        }

        /**
         * Execute any post-organized actions registered by any of the client side behaviours
         */
        public execPostShowViewsActions() {
            if (!this.postShowViewsActions) return;
            for (var i = 0; i < this.postShowViewsActions.length; i++) {
                try {
                    this.postShowViewsActions[i]();
                }
                catch (excepPostOrganizeAction) {
                    console.error("ClientTypeBehaviourManager::execPostOrganizeAction error on postOrganize action " + excepPostOrganizeAction);
                }
            }
            //free all actions
            this.postOrganizeActions = undefined;
        }


        static Init() {
            ClientTypeBehaviourManager.handlers = {};
            ClientTypeBehaviourManager.Current = new ClientTypeBehaviourManager()
            ClientTypeBehaviourManager.Current.postOrganizeActions = [];
            return null;
        }

        ///Typescript does not have static constructors
        ///This variable is used just to achieve the same as an static constructor
        static staticinit = ClientTypeBehaviourManager.Init();
    }

    interface IItemCollectionInfo {
        Parent: string;
        Items: string;
    }


    export class ArraysClientTypeBehaviour implements IClientTypeBehaviour {


        static Init() {
            ClientTypeBehaviourManager.Current.registerHandler(1, new ArraysClientTypeBehaviour());
            return null;
        }
        private itemsCollections: IItemCollectionInfo[] = [];
        public cons(jsonData) { return undefined; }

        private postActionRegistered: boolean = false;

        public preOrganizeAction(jsonData: any) {

            if (!this.postActionRegistered) {
                var that = this;
                ClientTypeBehaviourManager.Current.registerPostOrganizeAction(function () {
                    var $cache = <{ [uniqueid:string]: IStateObject }> (<any>WebMap.Client.StateManager.Current)._cache;
                    for (var i = 0; i < that.itemsCollections.length; i++) {
                        var curr = that.itemsCollections[i];
                        var parent = $cache[curr.Parent];
                        var items = $cache[curr.Items];
                        if (parent && items) {
                            (<any>parent).set("Items", items);
                        }
                    }
                }
                    );
                this.postActionRegistered = true;
            }
            this.itemsCollections.push({ Parent: jsonData.UniqueID, Items: "_items" + UniqueIDGenerator.UniqueIdSeparator + jsonData.UniqueID });
            return jsonData;
        }

        static staticinit = ArraysClientTypeBehaviour.Init();


    }


    export class StateObjectPointerClientTypeBehaviour implements IClientTypeBehaviour {

        static Init() {
            ClientTypeBehaviourManager.Current.registerHandler(2, new StateObjectPointerClientTypeBehaviour());
            return null;
        }
        private pointers: Array<any> = [];
        public cons(jsonData) { return undefined; }


        private postActionRegistered: boolean = false;

        private registerActionPostOrganize() {
            //Just do this the first time
            if (this.postActionRegistered) return;
            this.postActionRegistered = true;
                var that = this;
            ClientTypeBehaviourManager.Current.registerPostOrganizeAction(() => {

                //Get direct access to the cache table
                var $cache = <{ [uniqueid: string]: IStateObject }> (<any>WebMap.Client.StateManager.Current)._cache;
                //Iterate thru the list of collected pointers
                    for (var i = 0; i < that.pointers.length; i++) {
                        var currentPointer = that.pointers[i];
                    //First we need to know where will be the pointer inserted
                    //The first element will be something like ->property#object1#2
                        var property: string = "";
                        if (currentPointer.v) {
                            property = currentPointer.v[0];
                        }
                        else if (currentPointer.u)
                        {
                            property = JSON.parse(currentPointer.u[0]);
                        }
                        else
                            property = currentPointer[0];
                        property = property.replace("->", "");
                    //Now we will use this property unique ID to get to the actual object
                        var accessPath = property.split(UniqueIDGenerator.UniqueIdSeparator).reverse();
                        var field = accessPath.pop();
                        var rootUniqueID:string = property.replace(field + UniqueIDGenerator.UniqueIdSeparator, "");
                        var root= $cache[rootUniqueID]

                    //If we find the object, then we connect the field with the pointed value
                        if (root) {
                            try {
                                //loops might be cause by pointers. So widgets must address the possible issues 
                                //For example it affects Json serialization causing exception like: Maximun call stack 
                                var temp = $cache[currentPointer[1]];
                                if (currentPointer.v) {
                                    var field = WebMap.Utils.getNameFromAlias(root["@k"], field);
                                    root[field] = currentPointer.v[1];
                                }
				else if (currentPointer.d) {/*Nothing so far...*/}
                                else {
                                    var field = WebMap.Utils.getNameFromAlias(root["@k"], field);
                                    root[field] = temp;
				    if (temp) {
					$cache[property] = temp;
					if (!temp[UniqueIDGenerator.ReferencesIdentifier])
	                                     temp[UniqueIDGenerator.ReferencesIdentifier] = [];
					     temp[UniqueIDGenerator.ReferencesIdentifier].push(property);
				     } 
		                }						
                            }
                            catch (pointerExp) {
                                console.error("StateObjectPointerClientTypeBehaviour::preOrganizeAction-anonymousPostOrganize Error trying to restore pointer " + currentPointer.UniqueID + " exception " + pointerExp);
                            }
                        }

                    }
                    that.pointers = [];
                    that.postActionRegistered = false; //Clean the flag in order to register the next time all the pointers

                });
            }

        public preOrganizeAction(jsonData: any) {
            this.registerActionPostOrganize();
            //This json object has an structure like
            //{@k=2,p["->property#object1#2","proper2#panel1#2"]}
            //or
            //{@k=2,v["T186", 19]}

            window.app.log("Processing pointer");
            window.app.log(jsonData);
            if (jsonData.p) {
                this.pointers.push(jsonData.p);
            } else if (jsonData.v) {
                this.pointers.push({ v: jsonData.v });
            }
            //We return undefined so this jsonData object is no longer used
            //At the end of the state processing cycle the postOrganize action will
            //we triggered and pointer will be connected
            return undefined;
        }

        static staticinit = StateObjectPointerClientTypeBehaviour.Init();


    }
    ///Allows the registration of events that were dynamically added during the processing of a sendAction call
    export class DynamicEventClientTypeBehaviour implements IClientTypeBehaviour {

        static Init() {
            ClientTypeBehaviourManager.Current.registerHandler(5, new DynamicEventClientTypeBehaviour());
            return null;
        }
        private events: { [widgetID: string]: Array<DynamicEventData>; } = {};

        private pendingEvents: { [widgetID: string]: Array<DynamicEventData>; } = {};

        public cons(jsonData) { return undefined; }

        public bindEventsForPendingItems(isContextMenuStrip = false, alwaysBind = false) {
            var that = this;
            var keys = Object.keys(that.pendingEvents);
            for (var i = 0; i < keys.length; i++) {
                var uniqueID = keys[i];
                var eventsForWidget = that.pendingEvents[uniqueID];
                var widget: any = WebMap.Utils.getWidgetInDOM(uniqueID, isContextMenuStrip);
                if (!widget) {
                    continue;
                }

                for (var j = 0; j < eventsForWidget.length; j++) {
                    if (alwaysBind)
                        WebMap.Utils.bindWidgetToEvent(widget, eventsForWidget[j].EventId, uniqueID, true);
                    if (isContextMenuStrip)
                    WebMap.Utils.bindMenuItemToEvent(widget, eventsForWidget[j].EventId, uniqueID);
                    else
                        WebMap.Utils.bindWidgetToEvent(widget, eventsForWidget[j].EventId, uniqueID);
                }
                widget = null;
                //delete that.pendingEvents[uniqueID];
            }
        }

        private postActionRegistered = false;

        private registerPostShowViewsAction() {
            //Just do this the first time
            if (this.postActionRegistered) return;
            this.postActionRegistered = true;
            var that = this;
            ClientTypeBehaviourManager.Current.registerPostShowViewsAction(() => {
                var keys = Object.keys(that.events);
                for (var i = 0; i < keys.length; i++) {
                    var uniqueID = keys[i];
                    var eventsForWidget = that.events[uniqueID];
                    var widget: any = WebMap.Utils.getWidgetInDOM(uniqueID);
                    if (!widget) {
                        if (!this.pendingEvents[uniqueID])
                            this.pendingEvents[uniqueID] = [];

                        for (var j = 0; j < eventsForWidget.length; j++) {
                            // check for duplicates before adding the event
                            var duplicate: boolean = false;
                            for (var k = 0; k < this.pendingEvents[uniqueID].length; k++) {
                                if (this.pendingEvents[uniqueID][k].EventId == eventsForWidget[j].EventId) {
                                    duplicate = true;
                                    break;
                                }
                            }
                            if (!duplicate)
                                this.pendingEvents[uniqueID].push(new DynamicEventData(uniqueID, eventsForWidget[j].EventId));
                        }

                        continue;
                    }
      
                    for (var j = 0; j < eventsForWidget.length; j++) {
                        WebMap.Utils.bindWidgetToEvent(widget, eventsForWidget[j].EventId, uniqueID);
                    }
                    delete that.events[uniqueID];
                    widget = null;
                }

                //that.events = {};
                that.postActionRegistered = false; //Clean the flag in order to register the next time all the pointers
            });
        }

        public preOrganizeAction(jsonData: any) {
            this.registerPostShowViewsAction();
            var data = jsonData;
            if (!this.events[jsonData.UniqueID])
                this.events[jsonData.UniqueID] = [];
            this.events[jsonData.UniqueID].push(new DynamicEventData(jsonData.UniqueID, jsonData.EventID));
        }

        static staticinit = DynamicEventClientTypeBehaviour.Init();


    }
} 