// Module
module WebMap.Client {

    // IIocContainer implementation that does use of kendo objects to keep track of the
    // state of the elements it creates.
    export class Container implements IIocContainer {
        static Current: Container;

        // Initializes the singleton instance
        public static Init() {
            if (!Container.Current) {
                Container.Current = new Container();
            }
        }
		// Returns a empty object of a certain type,
		//this allow us to avoid sending the Default Values.
		private GetEmptyObject(typeOfObj): Object {
			var typeConfig = window["defaultsInfo"][typeOfObj];
			var emptyObj = window["emptyObjs"][typeOfObj];
			if (emptyObj) {
				return emptyObj;
			}
			emptyObj = {};
			if (typeConfig) {
				var keys = Object.keys(typeConfig);
				for (var i = 0; i < keys.length; i++) {
					var info = typeConfig[keys[i]];
					//In case of simple types or String(20 is string).
					if ((info[2] == 0 && info[1] != null) || info[2] == 20)
						emptyObj[info[0]] = info[1];
				}
				window["emptyObjs"][typeOfObj] = emptyObj;
				return emptyObj;
			}
			return null;
		}

		cloneObject(obj: Object): Object {
			if (obj === null) {
				return obj;
			}
			var temp = obj.constructor(); // give temp the original obj's constructor
			for (var key in obj) {
				temp[key] = obj[key];
			}
			return temp;
		}

        // Creates a new object according to the given options.  Standard calls are:
        // 1. Resolve({ vm: true, data: <JSON object>, dirty: false }).  Creates a new view model object with the 
        // given JSON data and marks it as not diry.
        // 2. Resolve({ "cons": constructor lambda) }).  Creates a new object usign the given lambda to create it.
        Resolve(options?: any): any {
            if (options) {
                if (options.vm) {  // creating a view model object?

                    var observable: kendo.Observable;
                    if (options.data['@arr']) {  // is it an array? then let's create an Observable array
                        observable = new kendo.data.ObservableArray(options.data);
                        (<any>observable).Count = options.data.Count;
                        (<any>observable).UniqueID = options.data.UniqueID;
                        (<any>observable).uids = options.data.uids;
                        (<any>observable).ltype = options.data.ltype;
                    }
                    else {
						observable = this.GetKendoObservableFor(options.data);
                    }

                    // the new view model objects defaults to not dirty, however its initial value can be changed by 
                    // using the dirty flag.
                    var dirty: boolean = false;
                    if (options.dirty != undefined)
                        dirty = options.dirty;
                    // adds the new object to cache
                    StateManager.Current.addNewObject(<IStateObject><any>observable, dirty);
                    return observable;
                }
                // Creates the object from the given constructor
                if (options.cons) {
                    return new options.cons();
                }
            }
            return null;
        }

		///Retrieves a kendoObservable Object given a IStateObject model.
		GetKendoObservableFor(model: IStateObject) : kendo.data.ObservableObject
		{
			var object: any = model;
			//Gets an empty object for a type.(With the default values set.)
			var emptyObj = this.GetEmptyObject(object["@k"]);
			var observable: WebMap.Client.MobilizeObservableObject;
			if (emptyObj) {
				//Empty objects are stored for type, so that we need a ligth clone of it.
				var result = this.cloneObject(emptyObj);
				//Object properties from the model, are excluded.
				// and stored to set them later.
				observable = new WebMap.Client.MobilizeObservableObject(result);
				observable.merge(model);

			}
			else
			{
				observable = new WebMap.Client.MobilizeObservableObject(object);
			}

			return observable;

		}

    }

}
