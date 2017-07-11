// Module
module WebMap.Client {

    export class DeltaTracker {

        attachedObjs: {[uniqueid:string]:IStateObject};
        dirtyTable: {[uniqueid:string]:boolean };
        dirtyPropertiesTable: { [uniqueid: string]: {[propertyname:string]: boolean } };

        public isDirty(obj: IStateObject): boolean {
            return <boolean>(this.dirtyTable[obj.UniqueID] ||
                this.dirtyPropertiesTable[obj.UniqueID]);
        }

        //Registers a JSON property as if it has been modified
        //so it will be send as part of the model deltas to the client  
        public markAsModified(obj: IStateObject, propertyName: string) {
            this.updateDirtyPropertiesTable(propertyName, obj.UniqueID);
        }


        constructor() {
            this.dirtyTable = {};
            this.attachedObjs = {};
            this.dirtyPropertiesTable = {};
        }
        //Update the Dirty properties table 
        updateDirtyPropertiesTable(fieldName, uid): void {
            var propertiesChangesMap = this.dirtyPropertiesTable[uid];
            if (!propertiesChangesMap) {
                this.dirtyPropertiesTable[uid] = {};
                propertiesChangesMap = this.dirtyPropertiesTable[uid]
            }
            propertiesChangesMap[fieldName] = true;

        }

         /**
          * Checks if the object has an UniqueID or it is an AttachedUniquedID
          * AttachedUniqueIds cannot have $
          */
        private static IsAttached(obj) {

            if (obj && obj.UniqueID)
                return (<string>obj.UniqueID).indexOf("$") == -1;
            return false;
        }

        /**
         * Look for the first parent of the current object that has an AttachedUniqueID and marks it as
         * dirty, so the whole object will be send on the next sendAction call
         */

        private climbToNearestAttachedObjectAndMarkItDirty(item: kendo.data.ObservableObject): void {
            var root: kendo.data.ObservableObject = item.parent();
            while (root && !DeltaTracker.IsAttached(root)) {
                root = root.parent();
            }
            if (root && (<any>root).UniqueID) {
                this.dirtyTable[(<any>root).UniqueID] = true;
            }

        }


        changeTracker(e): any {
            var fieldName: string = e.field;
            if (fieldName && e.sender.UniqueID) {
                var uid = e.sender.UniqueID;// e.sender.get(actualSenderNameParts.join('.')).UniqueID;
                this.updateDirtyPropertiesTable(fieldName, uid);
            }
        }
        
        _changeDelegate: any;

        /** Register an object for change tracking */
        public attachModel(obj: IStateObject, markAsDirty?: boolean): void {
            var events = obj["_events"];
            var that = this;
            if (!this._changeDelegate) {
                this._changeDelegate = (e) => {
                    if (!((e.action && e.action == "itemchange") || (e.field && e.field.indexOf('.') > -1))) { //Filter the itemchange action
                        that.changeTracker(e);
                    }
                    //is it an action on a Watchable feature?
                    //It the reported item does not have UniqueID it means that we need to find the closest parent with an attached uniqueID
                    //and mark it as dirty
                    if (e.action && e.action == "itemchange" && e.items && e.items.length > 0 && !DeltaTracker.IsAttached(e.items[0])) {
                        for (var i = 0; i < e.items.length; i++) {
                            this.climbToNearestAttachedObjectAndMarkItDirty(e.items[i]);
                        }
                    }
                };
            }
            //We will look to determine if the change delegate has already been attached
            if (events && events.change) {
                var found: boolean = false;
                for (var i = 0; i < events.change.length; i++) {
                    if (events.change[i] == this._changeDelegate) {
                        found = true;
						break;
                }
                }
                //if it hasnt been attached then insert it
                if (!found) {
                    WebMap.Utils.bindEventToModel(<kendo.Observable><any>obj, "change", this._changeDelegate);
                }
            }
            else {
                //No events yet. Then just attach the change delegate
                WebMap.Utils.bindEventToModel(<kendo.Observable><any>obj, "change", this._changeDelegate);
            }
            if (markAsDirty) {
                this.dirtyTable[obj.UniqueID] = true;
            }

        }


        public reset(): void {

        }

        public start(): void {
            this.dirtyTable = {};
            this.dirtyPropertiesTable = {};
        }

        public getDeltas(): void {

        }

        wasModified(variable: IStateObject): boolean {
            return true;
        }

        getJSONFromFullObject(obj): any {
           //Creating an empty object and extending it, is used
           //as a strategy to avoid maximum call stack error during toJSON calls
            var clone = jQuery.extend(true, {}, obj);
            for (var prop in clone) {
                var elementUniqueID: IStateObject;
                if (clone[prop] && (elementUniqueID = clone[prop]) && elementUniqueID.UniqueID) {
                    //this is another viewmode so just decouple
                    delete clone[prop];
                }
            }
            return clone.toJSON();
        }

        getCalculatedDeltaFor(variable): { [dirtypropertyname: string]: any }  {
            var isDirty = this.dirtyTable[variable.UniqueID];
            if (isDirty)
                return this.getJSONFromFullObject(variable);
            var hasDirtyProperties = this.dirtyPropertiesTable[variable.UniqueID];
            if (hasDirtyProperties) {

                //var behaviour = SerializationBehaviourManager.getBehaviour(delta);
                //if (behaviour)
                //   delta = behaviour.exportDelta(variable, delta);

                var delta: {[dirtypropertyname:string]:any} = {};
                for (var prop in hasDirtyProperties) {
                    
                    //The purpose of this section of code 
                    //is to support the serialization of array objects
                    //this generate a serializated field like [null,null,Value,null]
                    //and not something like "ItemContent[2]": Value
                    if (prop.match(/\w+\[\d+\]/)) {
                        var valor = variable.get(prop);
                        var deltaName = prop.substr(0, prop.indexOf('['));
                        if (!delta[deltaName]) {
                            delta[deltaName] = new Array(variable.ItemContent.length);
                        }
                        var indexVal = prop.match(/\[(.*?)\]/);
                        var index = parseInt(indexVal[1]);
                        delta[deltaName][index] = valor;
                    }
                    else {
                        var value = variable.get(prop);
                        //Some checking must be performed to avoid issues during serialization
                        var elementUniqueID: IStateObject;
                        if (value && typeof(value) == 'object' && (elementUniqueID = value) && elementUniqueID.UniqueID){
                            if (!(value instanceof kendo.data.ObservableArray)) {
                                value = this.getJSONFromFullObject(value);
                                delta[prop] = value;
                            }
                        }
                        else
                            delta[prop] = value;
                        
                    }
                }
                return delta;
            }
            return undefined;
        }
    }

}
