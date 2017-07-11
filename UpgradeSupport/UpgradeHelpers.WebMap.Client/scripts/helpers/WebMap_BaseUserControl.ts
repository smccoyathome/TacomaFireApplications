/// <reference path="kendo.all.d.ts" />
function normalizeUniqueID(value:string) {
    var strUniqueId = ""
    strUniqueId = value.replace(/[#\[\]./]/g, "_");
    return strUniqueId;
}

function UserControl_CalcAncestorPath(value) {
    if (!value["$$$parent"]) {//         !value["$$$parent"]) {
        var parent = value.parent();
        var ancestorPath = parent["$$$parent"] || "";
        if (parent) {
            var props = Object.getOwnPropertyNames(parent);
            for (var i = 0; i < props.length; i++) {
                var propName = props[i];
                if (parent[propName] == value) {
                    if (ancestorPath == "") {
                        if (parent instanceof kendo.data.ObservableArray) {
                            UserControl_CalcAncestorPath(parent);
                            ancestorPath = parent["$$$parent"];
                            value["$$$parent"] = ancestorPath + "[" + propName + "]";
                            //window.app.log("Setting parent value to " + value["$$$parent"]);
                        } else {
                            value["$$$parent"] = propName;
                            //window.app.log("Setting parent value to " + value["$$$parent"]);
                        }
                    } else {

                        if (parent instanceof kendo.data.ObservableArray && parent.parent()) {
                            ancestorPath = parent["$$$parent"];
                            value["$$$parent"] = ancestorPath + "[" + propName + "]";
                            //window.app.log("Setting parent value to " + value["$$$parent"]);
                        }
                        else {

                            value["$$$parent"] = ancestorPath + "." + propName;
                            //window.app.log("Setting parent value to " + value["$$$parent"]);
                        }
                    }
                    break;
                }
            }
        }
    }
}


module WebMap.Client {

    // shorten references to variables. this is better for uglification 
    declare var kendo;
    declare var ui;
    declare var $;
    var ui = kendo.ui, Widget = ui.Widget;

    export class BaseUserControl {
        options = {
                /** the name is what it will appear as off the kendo namespace(i.e. kendo.ui.UserControl1). 
                 *The jQuery plugin would be jQuery.fn.kendoUserControl1. 
                 */
                name: "BaseUserControl",
            value: null,
            css: "",
            template: "<div></div>",
            uiinitialized: false
        }
        //_old: any; // MOBILIZE, 2016-05-03, KLUN, this property has never been used from the any widgets.
        _value: any;
        element: any;
        inDestroy: boolean;
		delayedBuild: boolean;
		ignoreDelay: boolean;
        UIInitialized = function (initialized: boolean)
        {
            this.options.uiinitialized = initialized;
        }

 ApplyValueChanges = function (changeEvent) {
            var that = this;
            if (changeEvent.field === "Enabled") {
                var source = changeEvent.sender;
                if (source.Enabled) {
                    $(that.element).css("opacity", "1");
                    $(that.element).find("div").css("pointer-events", "all");
                    $(that.element).find("div").removeProp("disabled");
                }
                else {
                    $(that.element).css("opacity", "0.4");
                    $(that.element).find("div").css("pointer-events", "none");
                    $(that.element).find("div").prop("disabled", "");
                }
            } else if (changeEvent.field === "Visible") {
                var source = changeEvent.sender;
                if (source && that.element) {
                    WebMap.Utils.SetVisible(that.element, source.Visible);
					if (that.delayedBuild) {
						that.delayedBuild = false;
						that.buildUI();
						window.app.Safe.safeExec({
							obj: that._value,
							stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
							category: "base_refresh",
							whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.QueueForLater,
							action: () => {
								that.refresh();

							}
						});
					}
				}
            }
        }

         applyTemplate(value) {
                var that = this;
                var proto = that.constructor.prototype;

            if (!proto._compiledTemplate ||
                proto._compiledTemplate && proto.options.template != proto._currentTemplate) {
                    proto._compiledTemplate = kendo.template(proto.options.template);
                proto._currentTemplate = proto.options.template;
                }
                this.initStyles();
            if (value) {
                value["$$$parent"] = WebMap.Utils.buildParentFromUniqueID(value.UniqueID);
                this.initClientMethods(value);
                return proto._compiledTemplate(value);
            }
            else {
                window.app.log("No value in applyTemplate");
            }

        }

            initStyles() {
                var that = this;
                //ADD CSS RULES DYNAMICALLY 

                var addCssRule = function (styles, id) {
				//There is not CSS required 
				if ("css not loaded" == styles)
					return;
                    if (!document.getElementById(id)) {
                        var style = document.createElement('style');
                        var styleMark = document.createElement("script");
                        var styleIdAtt = document.createAttribute("id");
                        styleIdAtt.value = id;
                        style.type = 'text/css';
                        if ((<any>style).styleSheet) (<any>style).styleSheet.cssText = styles; //IE 
                        else style.innerHTML = styles; //OTHERS 

                        document.getElementsByTagName('head')[0].appendChild(style);
                    }
                };
                addCssRule(that.options.css, '' + that.options.name);
            }

            initClientMethods(value) {
                var that = value;
            }

            init(element, options) {
                // base call to initialize widget 
                options._uiinitialized = false;
                Widget.fn.init.call(this, element, options);
            }

        //override the function destroy,  to add custom implementation or aditional code when applied kendo destroy in widgets
        destroy() {
			
			try {
				var that = this;
				if (!that.inDestroy) {
					that.inDestroy = true;

					//Call the overriden widgetDestroy func of the widgets.
					try {
						that.widgetDestroy();
					} catch (e) {
						window.app.log("widgetDestroy: error on destroying the widget " + that._value.Name);
					}

					Widget.fn.destroy.call(that);

					that.element.removeData();
					that.element.removeAttr();

						// Unbind all the events associated with the object.
						that.element.unbind();
						that._value.unbind();
						(<any>that).unbind();

					try {
						//Destroy the element
						kendo.destroy(that.element);
					} catch (e) {
						window.app.log("kendo.destroy: error on destroying the widget " + that._value.Name);
					}

					//The reason of using this flag is because some other places like DynamicPanel, ExplorerBar 
					//also calls this methods, and in those cases, they shouldn't enter the execute the below code.
					if (WebMap.Client.App.Current.isClosingView) {
						//Remove the DOM element.
						that.element.empty();

						//Delete it from the memory.
						that.element = null;
						that._value = null;
					}
				}
			} catch (e) {
				var name = "";
				if (that._value && that._value.Name)
					name = that._value.Name;
				window.app.log("destroy: error on destroying the widget " + name);
			}
        }
        
        widgetDestroy() { }

            refresh() { }
        KeyBoardEvents(value) {
            var element,events,arrEvents,role,data;

            if(value && value.element && value._events){
                element = value.element;
                events = value._events;
            }

            if (element && events) {
                arrEvents = Object.keys(value._events)

                if (arrEvents.length && arrEvents.length > 0) {
                    role = window.app.getControlRole(value._value);

                    // these events won't be set to the richtextbox. Their implementation should be different inside the widget
                    if (role && (role == "richtextbox" || role.indexOf("textbox") != -1))
                        return;

                    data = element.data(name);

                    if (jQuery.inArray("keypress", arrEvents) != -1) {
                       element.keypress(function (e) {
                            if (e.keyCode && data)
                                data.trigger("keypress", e)
                        });
                    }
                    if (jQuery.inArray("keydown", arrEvents) != -1) {
                        element.keydown(function (e) {
                            if (e.keyCode && data)
                                data.trigger("keydown", e)
                        });
                    }
                    if (jQuery.inArray("keyup", arrEvents) != -1) {
                        element.keyup(function (e) {
                            if (e.keyCode && data)
                                data.trigger("keyup", e)
                        });
                    }
                }    
            }      
        }

            buildUI() {
                try {
                    var that = this;
                if (that._value == null || that._value == undefined) {
                    throw new Error("_value on " + that.options.name + " is null or undefined.");
                }

                 that.UIInitialized(true);
                    //Set Options is defined in Widget
                    (<any>that).setOptions(that.options);
                    var that = this,
                        view = that._value;
                if (view) {
                    view["$$$parent"] = WebMap.Utils.buildParentFromUniqueID(view.UniqueID);
                     $(that.element).attr("data-processed", true);
                    that.element.html(that.applyTemplate(view));
                    WebMap.Utils.bindElementToModel(that.element, view);
                    }

                } catch (exp) {
                var elemID = this.element.attr("id");
                var uniqueID = this._value != undefined ? this._value.UniqueID : "undefined";
                var widgetName = this.options.name;
                console.error("BaseUserControl::buildUI exception: %s. Elem ID=[%s]. UniqueID=[%s]. Widget=[%s]", exp, elemID, uniqueID, widgetName);
                }
            }
            //MVVM framework calls 'value' when the viewmodel 'value' binding changes 
            value(val) {
                var that = this;
                if (val === undefined) {
                    return that._value;
                }
                that._update(val);
            //that._old = that._value;  // MOBILIZE, 2016-05-03, KLUN, this property has never been used from the any widgets.
        }

        normalizeKey(key) {
            return key.replace(/\//g, "").replace(/ /g, "_");
        }

        normalizeKeys(value) {
            try {
                if (value['Columns'] && value['Columns']['ColumnsList']) {
                    var columnsList: Array<any> = value['Columns']['ColumnsList'];
                    for (var i = 0; i < columnsList.length; i++) {
                        var column = columnsList[i];
                        if (column['Key'])
                            column['Key'] = this.normalizeKey(column['Key']);
                    }
                }

                if (value['DataSourceList']) {
                    var DataSourceList: Array<any> = value['DataSourceList'];
                    for (var i = 0; i < DataSourceList.length;i++) {
                        var data = DataSourceList[i];
                        if (data['Keys']) {
                            var keys:Array<any> = data['Keys'];
                            for (var j = 0; j < keys.length; j++)
                            {
                                keys[j] = this.normalizeKey(keys[j]);
                            }
                        }
                    }
                }
            }
            catch (err) {

            }
            }

            _update(value) {
            try {
                this.normalizeKeys(value);
                var that = this;
                that._value = value;
                if (!that.options.uiinitialized) {
					//Every control should be able to modify it's state when it's not visible
					if (that._value) {
						WebMap.Utils.bindEventToModel(that._value, "change",
							function (changeEvent) {
								that.ApplyValueChanges(changeEvent)
							});
						if ((that._value.Visible && !that.delayedBuild) || that.ignoreDelay) {
                    that.buildUI();
                }
						else if (!that.delayedBuild) {
							that.delayedBuild = true;
                            WebMap.Utils.SetVisible(that.element, that._value.Visible);
						}
					}
                    //Keyboard Events (keydown,keypress,keyup)
                    this.KeyBoardEvents(that);
                }
				else {
                    window.app.Safe.safeExec({
                        obj: that._value,
                        stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                        category: "base_refresh",
                        whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.QueueForLater,
                        action: () => {
                that.refresh();
            }
                    });
                }
				WebMap.Client.Responsiveness.ProcessObjectForResponsiveness(that);
            } catch (exp) {
                var elemID = this.element.attr("id");
                var uniqueID = this._value != undefined ? this._value.UniqueID : "undefined";
                var widgetName = this.options.name;
                console.error("BaseUserControl::buildUI exception: %s. Elem ID=[%s]. UniqueID=[%s]. Widget=[%s]", exp, elemID, uniqueID, widgetName);
            }
        }


        public safeRefresh() {
            var that = this;
            window.app.Safe.safeExec(
                {
                    stage: ClientSyncronizationStage.NotUpdatingClientSideYet,
                    obj: that._value,
                    action: ()=>that.refresh(),
                    whenNotAtThatStage: SafeExecutionConditions.QueueForLater,
                    category: "requestAction"
                });
        }
		
    }

    ui.plugin(Widget.extend(new BaseUserControl()));

}