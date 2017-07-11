// Module
module WebMap.Client {

    export class UniqueIDGenerator {
        public static UniqueIdSeparator:string = "#";
		public static ReferencesIdentifier: string = "@@r";
		public static getParent(uniqueID: string) {
			var parent = null;
			var indexOfSeparator = uniqueID.indexOf(this.UniqueIdSeparator);
			if (indexOfSeparator != -1) {
				parent = uniqueID.substring(uniqueID.indexOf(this.UniqueIdSeparator) + 1)
			}
			return parent;
		}

		public static getLastToken(uniqueID: string) {
			return uniqueID.split(this.UniqueIdSeparator)[0]
        }

        public static getFirstToken(uniqueID: string) {
            var parts = uniqueID.split(this.UniqueIdSeparator);
            return parts[parts.length - 1];
        }
    }

	function isNumeric(str: string) {
		return !isNaN(parseFloat(str));
	}

    export class StateManager {


        static Current: StateManager;
        private _cache: { [uniqueID: string]: IStateObject };
        private _tracker: DeltaTracker;
        

        static Init() {
            if (!StateManager.Current) {
                StateManager.Current = new StateManager();
                (<any>window).$cache = StateManager.Current._cache;
                (<any>window).$tracker = StateManager.Current._tracker;
            }
        }

        constructor() {
            this._cache = {};
            this._tracker = new DeltaTracker();
        }



          /**
            *We use the term "organize" to refer to actions 
            * of using the UniqueIDs to reconnect objects in an object hierarchy.
            * UniqueIDs are allways like Panel1#0002 that means Panel1 property inside
            * a top level object identified by 0002 you can use
            * the shortcut $cache to watch the current models state
            */
        organize(options?: any): void {
			this.resolveHierarchy(options);
        }

		

        public attachModel(obj: IStateObject) {
            this._tracker.attachModel(obj);
        }

		private resolveHierarchy(options: any) {
			var aliasCollection = null;
			var cache = this._cache;
            var entries = options.cache;
            for (var k = 0; k < entries.length; k++) {
				//Lets get the new entry from the Models collection coming from the server
                var newEntry = entries[k];
				//Integrity checks.
                if (!newEntry)
						continue;
				if (!newEntry.UniqueID)
					continue;
				//Lets store the entry UniqueID.
                var entryUniqueID = newEntry.UniqueID;
				//If it is a dependent object...
                var separatorIndex = entryUniqueID.indexOf(UniqueIDGenerator.UniqueIdSeparator);
				//Top level objects should not be organized.
				if (separatorIndex === -1)
					continue;
				//Let's retrieve the value from the cache.
				var cacheValue = cache[entryUniqueID];
				if (cacheValue) {
                    // part of the unique Id that identifies the element
					var propertyName = entryUniqueID.substring(0, separatorIndex);
					// rest of the unique Id that identifies the parent
                    var parentKey = entryUniqueID.substring(separatorIndex + 1); // Removing the '#' character from the parentKey also
					//Let's retrieve the parent value from the storage.
					var parent = cache[parentKey];
					//Lets store the possible property name.
					var realName = propertyName;
					//If the parent is null...Then we need to calculate the gaps, to fill the empty space.
					if (parent == null) {
                        this.resolveMissingParent(parentKey, realName, cacheValue);
                        continue;
                    }
					// We clear the aliasCollection.
					aliasCollection = null;
					//If the parent has a type....
					var parentType = parent["@k"];
                    if (parentType) {
						//Every type has a diccionary of metadata.
                        aliasCollection = window["defaultsInfo"][parentType];
						//If the property is an alias, the let's retrieve the readable name used in binding expresions
						if (aliasCollection && aliasCollection[realName]) {
							//Transforms a alias to a name like: L to button1.
							realName = aliasCollection[realName][0];
						}
					}
                    if (parent && (<any>parent).set) {
							try {
                            var alreadySet = false;

                                //for performance metrics var n1 = window.performance.now();
                                if (cacheValue instanceof kendo.data.ObservableArray) {
                                    for (var j = 0; j < (cacheValue as any).length; j++) {
                                        var item = cacheValue[j];
                                        if (item != null && entryUniqueID.indexOf(item.UniqueID) > 0) {
                                            (<any>parent)[realName] = cacheValue;
                                            alreadySet = true;
                                            break;
							}
							}
                                    if (!alreadySet) {
                                        (<any>parent).set(realName, cacheValue);
						}
									//check if "after set" -> added new events(change) in ObservableArray
                                    if ((<any>cacheValue)._events && (<any>cacheValue)._events.change && (<any>cacheValue)._events.change.length > 0) {
                                        var j = 0;
                                        var i = window.app.pendingUnBindedExDictonary[cacheValue.UniqueID];
                                        //if undefined then search one by one in list
                                        while (i == undefined && j < window.app.pendingUnBindedEx.length) { //do not use !i because !0 == true
                                            if (window.app.pendingUnBindedEx[j].array.UniqueID == cacheValue.UniqueID) {
                                                i = j;
					}
                                            j++;
						}
                                        if (i >= 0 && window.app.pendingUnBindedEx[i].array.UniqueID == cacheValue.UniqueID) {
                                            //backup new events and add in pendingUnBindedEx
                                            window.app.pendingUnBindedEx[i].events = window.app.pendingUnBindedEx[i].events.concat((<any>cacheValue)._events.change);
                                            //Now we unbind the event handler
                                            (<any>cacheValue)._events.change = [];
						}
                                    }
                                } else
									(<any>parent).setModelValue(realName, cacheValue);

								// Take into account the change between _items (hierarchy string) and Items (property of JS object)
                            if (realName === "_items") {
                                if (alreadySet)
                                    (<any>parent)["Items"] = cacheValue;
                                else
                                    (<any>parent).set("Items", cacheValue);
								}
							}
                        catch (ExpCatch) {
                            console.log(ExpCatch, ExpCatch.stack);
						}
					}
				}
			}
	    }


        public resolveMissingParent(parentKey, name, value) {

            window.app.log("Filling gap for " + parentKey);
			var parentDummyObject;
			//Can this token be for a control array?
			if (isNumeric(name)) {
				parentDummyObject = this._cache[parentKey] = <IStateObject><any>new kendo.data.ObservableArray([]);
				parentDummyObject["UniqueID"] = parentKey;
			}
			else {

                parentDummyObject = this._cache[parentKey] = <IStateObject><any> new WebMap.Client.MobilizeObservableObject({ UniqueID: parentKey });
            }
            parentDummyObject["isGap"] = true;
			var typeOfParent:string = null;
            // Make sure the rest of the hierarchy is populated
            if (parentKey.indexOf(UniqueIDGenerator.UniqueIdSeparator) > -1) {
                var parentName = parentKey.split(UniqueIDGenerator.UniqueIdSeparator)[0];
                var grandpaKey = parentKey.substring(parentKey.indexOf(UniqueIDGenerator.UniqueIdSeparator) + 1); // Removing the '#' character from the parentKey also
                // Create the grandpa object if it's not present in the cache
                if (this._cache[grandpaKey] == null) { //If null or undefined
                    this.resolveMissingParent(grandpaKey, parentName, parentDummyObject);
					var grandpa = this._cache[grandpaKey];
					var realName = WebMap.Utils.getNameFromAlias(grandpa["@k"], parentName)
                    typeOfParent = WebMap.Utils.getTypeFromAlias(grandpa["@k"], parentName)
                }
                else {
                    var grandpa = this._cache[grandpaKey];
                    var realName = WebMap.Utils.getNameFromAlias(grandpa["@k"], parentName);
                    typeOfParent = WebMap.Utils.getTypeFromAlias(grandpa["@k"], parentName);
                    grandpa[realName] = parentDummyObject;
                }
            }
			if (typeOfParent != null) {
				parentDummyObject["@k"] = typeOfParent;
                var realName = WebMap.Utils.getNameFromAlias(typeOfParent, name);
				parentDummyObject[realName] = value;
			}
			else
			{
				parentDummyObject[name] = value;
			}
			
        }
        
		//public dettachObject(obj: IStateObject) {
		//	this._tracker.dettachModel(obj);
		//}
        public addNewObject(obj: IStateObject, markAsDirty?: boolean): any {
            if (!obj || !obj.UniqueID) {
                window.app.info("StateCache::addNewObject trying to insert a model in the StateCache that is undefined or has not an UniqueID property");
                return undefined;
            }
            this._cache[obj.UniqueID] = <IStateObject>obj;
            if (markAsDirty === undefined)
                markAsDirty = true;
            this._tracker.attachModel(obj, markAsDirty);
            return obj;
        }

        public getDirty(): { [uniqueid: string]: {[dirtyproperty:string]:any} } {
            var res: { [uniqueid: string]: { [dirtyproperty: string]: any } } = {};

            var dirtyEntries = Object.keys(this._tracker.dirtyPropertiesTable);
            var children = dirtyEntries.concat(Object.keys(this._tracker.dirtyTable));
            for (var i = 0; i < children.length; i++) {
                var entryKey = children[i];
                var obj = this._cache[entryKey];

                var delta = obj && this._tracker.getCalculatedDeltaFor(obj);
                if (delta) {
                    res[obj.UniqueID] = delta;
                }
            }
            if (Object.keys(res).length == 0)
                return undefined;
            this._tracker.start();
            return res;
        }

        public getObjectLocal(uniqueId: string): IStateObject {
            return this._cache[uniqueId];
        }


        public clearDirty() {
            this._tracker.start();
        }

        public markAsModified(obj: IStateObject, fieldName: string) {
            this._tracker.markAsModified(obj, fieldName);
        }

        public getObject(uniqueId: string): IStateObject {
               return this._cache[uniqueId];
        }
		//Removes the References to the object to avoid leaks.
		public removeReferences(objUniqueID: string) {
			var obj: any = this._cache[objUniqueID];
			try {
				//The element should be defined and should not be a Reference
				if (obj && obj.UniqueID && obj.UniqueID == objUniqueID) {
					var references = obj[UniqueIDGenerator.ReferencesIdentifier];
					if (references) {
						//For each reference pointing to the object
						for (var j = 0; j < references.length; j++) {
							var refKey = references[j];
							var parentKey = UniqueIDGenerator.getParent(refKey);
                            var propertyNameToken = UniqueIDGenerator.getLastToken(refKey);
                           
							//Let's get the parent first.//
							var parent = this._cache[parentKey];

                          
                            //Conditions to remove the refKey are:
                            // 1. The refKey is an Array with no elements
                            // 2. The refKey is not an Array
							// We can't delete ObservableArrays rigth away. They could be used by someone else. Parents are the only ones can do this.
                            var canRemove = !(this._cache[refKey] instanceof kendo.data.ObservableArray);

                            if (canRemove) {
                                if (parent) {
                                    var propertyName = WebMap.Utils.getNameFromAlias(parent["@k"], propertyNameToken);
								//Nullify the property on the parent.
								parent[propertyName] = null;
                                }

							//Let's now assing that entry in the cache to null.
							this._cache[refKey] = null;
							delete this._cache[refKey];
						}
					}
					}
					var uniqueID = obj.UniqueID;
					//Let's try to get the parent if present.
					var uidParent = UniqueIDGenerator.getParent(uniqueID);
					if (uidParent != null) {
                        var propertyNameToken = UniqueIDGenerator.getLastToken(uniqueID);
						var parent = this._cache[uidParent];
                        
						//Let's assign the property on the parent to null as well, if the parent is not a reference
                        if (parent && uidParent == parent.UniqueID) {
                            var propertyName = WebMap.Utils.getNameFromAlias(parent["@k"], propertyNameToken);
							parent[propertyName] = null;
					}
					}
					obj.unbind('change');
				}
			} catch (e) {
				console.log("ERROR REMOVING REFERENCES OF " + objUniqueID);
			} finally {
				this._cache[objUniqueID] = null;
			}
		}
        // Removes all elements belonging to a specific view
        public ClearViewReferences(id: string) {
			var that = this;
			setTimeout(function () {
				var cache = that._cache;
				var cacheEntries = Object.keys(cache);
				var key = "#" + id;
				for (var i = cacheEntries.length - 1; i >= 0 && cacheEntries.length; i--) {
					var uniqueID = cacheEntries[i];
					var indexOfKi = -1;
					if ((indexOfKi = uniqueID.indexOf("KI")) != -1) {
						try {
							var KIItem: any = this._cache[uniqueID.substring(indexOfKi)];
							if (!KIItem) {
								delete cache[uniqueID];
							}
							var KIParent = KIItem.parent();
							if (!KIParent) {
								delete cache[uniqueID];
							}
							var visitedKIItems = {};
							while ((indexOfKi = KIParent.UniqueID.indexOf("KI")) != -1) {
								KIItem = this._cache[KIParent.UniqueID.substring(indexOfKi)];
								if (!KIItem) {
									delete cache[uniqueID];
								}
								KIParent = KIItem.parent();
								if (!KIParent) {
									delete cache[uniqueID];
								}
								else {
									if (visitedKIItems[KIParent.UniqueID]) {
										delete cache[uniqueID];
									}
									visitedKIItems[KIParent.UniqueID] = true;
								}
							}
						} catch (e) {

						}
                }
            }
			}, 500);
        }

    }

}
