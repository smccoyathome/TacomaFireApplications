module WebMap.Client {

	export class MobilizeObservableObject extends kendo.data.ObservableObject {
		init(value) {
			var that = this, member, field, parent = function () {
				return that;
			};
			(<any>kendo.Observable.fn).init.call(this);
			this['_handlers'] = {};
			for (field in value) {
				that[field] = value[field];
			}
			that.uid = kendo.guid();
		};
		merge(value) {
			var field, that = this;
			for (field in value) {
				that[field] = value[field];
			}
		}
        setModelValue(field: string, object: kendo.Observable) {
            var CHANGE = "change";
			var that = this;
			var current = that[field];
			if (current !== object) {
				if (current instanceof kendo.Observable && this['_handlers'][field]) {
					if (this['_handlers'][field].get) {
						current.unbind('get', this['_handlers'][field].get);
					}
					current.unbind('change', this['_handlers'][field].change);
				}
				that[field] = object;
				var getFunc = eventHandler(that, 'get', field, true);
				object.bind('get', getFunc);
				var change = eventHandler(that, 'change', field, true);
				object.bind(CHANGE, change);
				if (this['_handlers']) {
					this['_handlers'][field] = {
						get: getFunc,
						change: change
					};
				}
				object['parent'] = function () { return that };
			}
		};
	}

	export function eventHandler(context, type, field, prefix) {
		return function (e) {
			var event = {}, key;
			for (key in e) {
				event[key] = e[key];
			}
			if (prefix) {
				(<any>event).field = field + '.' + e.field;
			} else {
				(<any>event).field = field;
			}
			if (type == 'change' && context._notifyChange) {
				context._notifyChange(event);
			}
			context.trigger(type, event);
		};
	}

	export function cloneEvent(e) {
		var result = {};
		Object.keys(e).forEach(function (key) {
			if (key[0] != '_') {
				result[key] = e[key];
			}
		});
		return result;
	}
}