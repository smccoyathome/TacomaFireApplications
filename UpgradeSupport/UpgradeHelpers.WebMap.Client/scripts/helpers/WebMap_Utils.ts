module WebMap.Utils {

    export interface IControl {
        UniqueID: string;
        Controls: kendo.data.ObservableArray;
    }

    export function getHashCodeFromUniqueID(uniqueID: string): string {
        var hash = 0, len = uniqueID.length, chr;
        if (len === 0) return hash.toString(16);
        for (var i = 0; i < len; ++i) {
            chr = uniqueID.charCodeAt(i);
            hash = ((hash << 5) - hash) + chr;
            hash = hash & hash; // Convert to 32bit integer
        }
        //Why z?...Because IDs must start with a character.
        var hashStr = "z" + hash.toString(16);
        //Why x?...To avoid issues with invalid characters.
        return hashStr.replace("-", "x");
    }

    export function getWidgetInDOM(uniqueID: string, isMenuItem = false) {
        //Variable declarations.
        var widget = null, parentUniqueID = null, parentValue = null, elementID = null, selector = null, element = null;
        //UniqueID computations
        var preparedUniqueID = prepareUniqueID(uniqueID);
        var topLevelUniqueID = buildTopLevelObjectFromUniqueID(uniqueID);
        //Gets ViewModel
        var elementValue = window['$cache'][uniqueID];
        //Serious error here...The ViewModel trying to find the widget associated.
        if (!elementValue)
            return null;
        //If there is a hash in the UniqueID
        var hashIndex = preparedUniqueID ? preparedUniqueID.indexOf("#") : -1;
        //First try...Let's try to get it as an static element.
        if (hashIndex != -1) {
            parentUniqueID = uniqueID.substring(hashIndex + 1);
            parentValue = window['$cache'][parentUniqueID];
            if (parentValue) {
                elementID = getNameFromAlias(parentValue['@k'], buildCurrentObjectFromUniqueID(uniqueID));
                selector = '#' + topLevelUniqueID + ' #' + elementID;
                widget = getWidgetFromSelector(selector);
                if (widget) {
                    return widget;
                }
            }
        }
        //The element binded is the kendoWindow.
        else {
            selector = '#' + topLevelUniqueID;
            widget = getWidgetFromSelector(selector);
            if (widget) {
                return widget;
            }
        }
        //Second try...It's a dynamic element so that we need to use the UID.
        elementID = window['$cache'][uniqueID]['uid'];
        selector = '#' + elementID;
        widget = getWidgetFromSelector(selector);
        if (widget) {
            return widget;
        }
        //Third case. This is an special case and should not exist in the future.
        if (isMenuItem) {
            selector = '#' + elementValue.uid;
            element = $(selector).parent().parent().parent();
            if (element.length > 0) {
                return element;
            } else {
                return null;
            }
        }
        return undefined;
    }

    export function bindWidgetToEvent(widget: kendo.ui.Widget, eventID: string, uniqueID: string, alwaysBind = false): boolean {
        var mappedEvent = KendoWidgetMappings.getMappedEvent(widget, eventID);
        if (mappedEvent && this.isEventInWidgetEvents(widget, mappedEvent) || mappedEvent && alwaysBind) {
            var controlVM = window["$cache"][uniqueID];
            var bindedFunction = getSendActionFunction(controlVM, "EventDispatcher", "ProcessMessage", { 'eventID': eventID });
            widget.bind(mappedEvent, bindedFunction);
            return true;
        }
        return false;
    }

    export function bindMenuItemToEvent(widget: JQuery, eventID: string, uniqueID: string): boolean {
        var mappedEvent = KendoWidgetMappings.getMappedEventForMenuItem(widget, eventID);
        if (mappedEvent) {
            var controlVM = window["$cache"][uniqueID];
            var bindedFunction = getSendActionFunction(controlVM, "EventDispatcher", "ProcessMessage", { 'eventID': eventID });
            widget.on(<any>mappedEvent, bindedFunction);
            return true;
        }
        return false;
    }

    export function getSendActionFunction(mainObj: any, controllerName: string, action: string, parameters: {}): Function {
        var argArray: any[] = [];
        //the argument 0 is always the mainOBJ
        argArray.push(mainObj);
        argArray.push(controllerName);
        argArray.push(action);
        argArray.push(parameters);

        var bindedFunction = function (e: any) {
            return window.app.sendAction({ mainobj: arguments[0][0], controller: arguments[0][1], action: arguments[0][2], parameters: arguments[0][3] });
        }.bind(mainObj, argArray);
        return bindedFunction;
    }

    export function getNameFromAlias(typeOfObj, alias: string): string {
        var result = alias;
        var aliasCollection = window["defaultsInfo"][typeOfObj];
        if (aliasCollection && aliasCollection[alias]) {
            result = aliasCollection[alias][0];
        }
        return result;
    }

    export function getTypeFromAlias(typeOfObj, alias: string): string {
        var result = "0";
        var aliasCollection = window["defaultsInfo"][typeOfObj];
        if (aliasCollection && aliasCollection[alias]) {
            result = aliasCollection[alias][2];
        }
        return result;
    }
    
    function buildTopLevelObjectFromUniqueID(uniqueID: string): string {
        var preparedID = prepareUniqueID(uniqueID);
        if (preparedID) {
            uniqueID = preparedID;
        }
        return uniqueID.split("#").reverse()[0];
    }

    function buildCurrentObjectFromUniqueID(uniqueID: string): string {
        return uniqueID.split("#")[0];
    }

    //Summary: This method builds the full binding expression from the given uniqueID,
    //          we need this because sometimes the uniqueID comes as top level "KI" list item uniqueID.
    //Returns: The desired uniqueID with the parents resolved
    export function prepareUniqueID(uniqueID, buildFullPath?: boolean) {
        var result = "";
        var substring = "";
        //We are going to check if the uniqueID has any List element.
        var from = uniqueID.indexOf("KI");
        if (from == -1 && buildFullPath) {
            //Only those unique id that goes to HTML DOM should be transformed from shorten uniqueid to real uniqueid
            return TransformShortUniqueIDToRealUniqueID(uniqueID);
        }
        else if (from == -1 && !buildFullPath)
            return uniqueID;

        var until = uniqueID.indexOf("#", from);
        if (until == -1) until = uniqueID.length;
        substring = (from == 0) ? uniqueID : uniqueID.substring(from, until);
        var obj = window["$cache"][substring];
        var parentObject = GetListItemParent(obj);
        if (parentObject instanceof kendo.data.ObservableArray
            || (parentObject != null && parentObject.length != null && parentObject.length > 0)) {
            if (buildFullPath) {
                result = (<any>parentObject).UniqueID;
                if (result.indexOf(uniqueID) != -1)
                    return result;
                return TransformShortUniqueIDToRealUniqueID(uniqueID) + "#" + prepareUniqueID(result, buildFullPath);

            } else {
                result = buildPartialResult(parentObject, uniqueID, substring);
                if (result != "") {
                    if (result.indexOf(uniqueID) != -1)
                        return result;
                    return prepareUniqueID(uniqueID.replace(substring, result), false);
                }
            }
        }
    }

    //Summary: Transforms the shorten uniqueid to the real uniqueid
    function TransformShortUniqueIDToRealUniqueID(uniqueid: string) {
        var parts = uniqueid.split("#").reverse();
        var partsReal = [];
        var currentContext = parts[0];
        partsReal.push(parts[0]);
        for (var i = 0; i < parts.length - 1; i++) {
            var currentParent = window["$cache"][currentContext];
            partsReal.push(getNameFromAlias(currentParent["@k"], parts[i + 1]));
            currentContext = parts[i + 1] + "#" + currentContext;
        }
        return partsReal.reverse().join("#");
    }

    function buildPartialResult(parentObject, uniqueID, substring): string {
        var result = "";
        for (var i = 0; i < parentObject.length; i++) {
            var item = parentObject[i];
            if (item != null && item.UniqueID == substring) {
                result = i + "#" + (<any>parentObject).UniqueID;
                break;
            }
        }
        return result;
    }

    //Summary: This is the method that retrieves the parent.
    function GetListItemParent(obj: any) {
        var parentObject = undefined;
        if (obj) {
            parentObject = obj.parent();
            if (parentObject == null) {
                //If this is null, maybe I am a list. 
                //This is a case of a list that is inside another list.
                parentObject = obj["__parent"];
            }
        }
        return parentObject;
    }

    //Summary: This method builds the full binding expression for the DOM Element from the given uniqueID,
    //          we need this because sometimes the uniqueID comes as top level "KI" list item uniqueID.
    //Returns: The desired uniqueID with the parents resolved
    export function buildParentFromUniqueID(UniqueID: string) {
        var uniqueID = prepareUniqueID(UniqueID, true);
        var parts = uniqueID.split("#");
        parts.pop();
        return parts.reverse().join(".");
    }

    export function GetControls(controls: kendo.data.ObservableArray, callback: Function) {
        var length = controls ? (<any>controls).Count : 0;
        for (var i = 0; i < length; i++) {
            if (controls[i]) {
                if (typeof controls[i] === "function") {
                    controls[i] = controls[i]();
                }
                if (controls[i].UniqueID != "") // This validation should be remove when server side doesn't insert null objects.
                {
                    if (typeof callback === "function") {
                        callback(controls[i])
                    }
                }
            }
        }
    }

    /**
    * Set the display to the element.
    * @param $element 
    * @param visible 
    * @returns {} 
    */
    export function SetVisible($element: JQuery, visible: boolean): void {
        if ($element && $element.length && visible != null && visible != undefined) {
            if (visible) {
                $element[0].style.display = "";
            } else {
                $element[0].style.display = "none";
            }
        }
    }

    export function refreshChildrenWidgets(element: JQuery) {
        var children = element.children();
        var widgetInstanceFunc: any = kendo.widgetInstance;
        for (var i = 0; i < children.length; i++) {
            var instance = widgetInstanceFunc($(children[i]));
            if (instance && instance.refresh)
                instance.refresh();
        }
    }

    export function isEventInWidgetEvents(widget: kendo.ui.Widget, event: string) {
        var events: string[] = (<any>widget).events;
        return events.filter(function (currentEvent) { return event == currentEvent; }).length == 1;
    }

    export function bindEventToModel(model: kendo.Observable, eventID: string, func: any) {
        func.WebMapFunction = true;
        if (!isEventBoundToModel(model, eventID, func)) {
            model.bind(eventID, func);
        }
    }

    export function isEventBoundToModel(model: kendo.Observable, eventID: any, func: any) {
        var events = (<any>model)._events[eventID];
        if (events) {
            return -1 !== $.inArray(func, events);
        } else {
            return false;
        }
    }

    export function bindElementToModel(element: JQuery, model: WebMap.Client.IStateObject, executeInmediatly?: boolean) {
        try {
            //prepareUniqueID...Yes, we need the UniqueID of something that is not a KIxxx element.
            var UniqueID = WebMap.Utils.prepareUniqueID(model.UniqueID, false);
            var topModel = window["$cache"][UniqueID.split("#").pop()];
            //Let's remove only kendo change handlers.
            var widgetInstance = (<any>kendo).widgetInstance(element);
            if (widgetInstance) {
                selectiveUnbind((<any>model));
            }
            //In case we decide to bind the element rigth away...
            if (executeInmediatly) {
                //Not recomended, kendo leaks change handlers in the topModel.
                kendo.bind(element, topModel);
            }
            else {
                //Maybe, there is a full binding in execution, but more expansions of DOM are triggered.
                //Which means that the TopLevel object is binding but an inner Widget needs a bind. In that case
                //we will notice that the bindingInExecution is the same that we were going to register.
                var bindingToRegister = "kendoBind@" + topModel.UniqueID
                if (window.app.Safe.pendingBindingInExecution
                    == bindingToRegister
                    || window.app.Safe.kendoBinds[topModel.UniqueID]) {
                    //Lets reset the current Hierarky history, to allow more binds.
                    delete window.app.Safe.executedBindings["kendoBind@" + topModel.UniqueID];
                    //Lets use the Full uniqueID in case the model is a List item(List items are top level objects)
                    //registerPendingBinding only uses the ID thats why this is valid.
                    var emptyModel: any = {};
                    //UniqueID complete? Well, in fact the UniqueID for a KIxxx is complete, but in order to represent the hierarky 
                    //correctly, it's better if we generate the ID in a way that shows the level of the Widget in the DOM.
                    emptyModel.UniqueID = WebMap.Utils.prepareUniqueID(model.UniqueID, true);
                    //Let's register the pending binding.
                    window.app.Safe.safeExec({
                        obj: emptyModel,
                        category: "kendoBind",
                        stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                        whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.QueueForLater,
                        action: () => {
                            //If there was a binding executed for the parent. Then all the children binds are
                            //useless and time counsuming.
                            if (!isParentExecuted("kendoBind@" + emptyModel.UniqueID)) {
                                //  This in fact will acumulate change handler in the root object, but the idea is to avoid
                                //this kind of Bind as much as possible.
                                kendo.bind(element, topModel);
                            }
                        }
                    });
                }
                else {
                    //In case the topModel is not being binded...Then let's register an entry for it.
                    window.app.Safe.safeExec({
                        obj: topModel,
                        category: "kendoBind",
                        stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                        whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.QueueForLater,
                        action: () => {
                            //Using the UniqueID we can retrieve the topLevel object or kendoWindow.
                            var form = $("#" + topModel.UniqueID);
                            var kendowindow = form.data('kendoWindow');
                            var ismaximized = kendowindow ? kendowindow.options.isMaximized : false;
                            var isminimized = kendowindow ? kendowindow.options.isMinimized : false;

                            //Let's remove the leaked bindings
                            selectiveUnbind(topModel);
                            //Lets bind the entire window again.
                            kendo.bind(form, topModel);

                            //restore to the previous state if this is maximized
                            if (ismaximized) kendowindow.maximize();
                            if (isminimized) kendowindow.minimize();
                            window.app.Safe.kendoBinds[topModel.UniqueID] = true;
}
                    });
                }
            }
        } catch (ex) {
            console.log("Error binding Model");
        }
    }

    export function selectiveUnbind(model: kendo.Observable) {
        //var changeEvents: any[] = (<any>model)._events['change'];
        //if (changeEvents) {
        //    for (var i = changeEvents.length - 1; i >= 0; i--) {
        //        var event = changeEvents[i];
        //        if (!event.WebMapFunction) {
        //            model.unbind("change", event);
        //        }
        //    }
        //}

    }

    export function isParentExecuted(UniqueID: string) {
        var parent = WebMap.Client.UniqueIDGenerator.getParent(UniqueID);
        while (parent != null) {
            if (window.app.Safe.executedBindings["kendoBind@" + parent])
                return true;
            parent = WebMap.Client.UniqueIDGenerator.getParent(parent);
        }
        return false;
    }

    export function getWidgetFromSelector(selector: string): kendo.ui.Widget {
        var element = $(selector);
        if (element.length > 0) {
            return kendo.widgetInstance(element, undefined);
        }
    }

    export class DynamicContainer {
        //Handle pointer cases, when the property is a function
        //If the control is not undefined then load it. 
        //We mark it inside controlsInPanel to avoid loading if if not necessary during the refresh call
        static applyTemplate(view: IControl, Controls: any, useTag?: boolean) {
            var controls = [];
            var lastcontrolsIDs = [];
            WebMap.Utils.GetControls(Controls, function (control) {
                if (useTag) {
                    var ctrl = (typeof control.Tag === "function") ? control.Tag() : control.Tag;
                    controls.push(ctrl);
                } else {
                    controls.push(control);
                }
            })
            if (view && controls.length > 0) {
                var result = "";
                var control = null;
                var controlInfo = null;
                for (var i = 0; i < controls.length; i++) {
                    control = controls[i];
                    //Validate control
                    if (control.UniqueID && control.UniqueID != "") {
                        control["$$$parent"] = WebMap.Utils.buildParentFromUniqueID(control.UniqueID);
                        controlInfo = WebMap.Utils.DynamicContainer.getIdToHtmlFromUserControl(control);
                        lastcontrolsIDs.push({ identifier: controlInfo.identifier, uid: controlInfo.uid });
                        if (useTag)
                            result += WebMap.Utils.DynamicContainer.loadHTML(control, "", control["$$$parent"], i, Controls[i]);
                        else
                            result += WebMap.Utils.DynamicContainer.loadHTML(control, "", control["$$$parent"], i);
                    }
                }
                view["$$$lastcontrols"] = controls.length;
                view["$$$lastcontrolsIds"] = lastcontrolsIDs;
            }
            return result;
        }

        static applyRowColumnProperties(tableinfo) {
            var tableInfoString = "";
            if (tableinfo.Row != null && tableinfo.Column != null && tableinfo.Row != -1 && tableinfo.Column != -1) {
                tableInfoString = "row='" + tableinfo.Row + "' column='" + tableinfo.Column + "'";
                if (tableinfo.RowSpan != null && tableinfo.RowSpan != -1)
                    tableInfoString += " rowspan='" + tableinfo.RowSpan + "'";
                if (tableinfo.ColumnSpan != null && tableinfo.ColumnSpan != -1)
                    tableInfoString += " colspan='" + tableinfo.ColumnSpan + "'";
            }
            return tableInfoString;
        }

        static loadHTML(control, element, panelName, index, tableinfo?) {
            panelName = "notdetermined";
            if (control && control.parent() && control.parent().UniqueID) {
                panelName = WebMap.Utils.buildParentFromUniqueID(control.parent().UniqueID);
            }
            var panelParentName = panelName;
            var itemBindingExpression = WebMap.Utils.buildParentFromUniqueID(control.UniqueID);
            var ids = WebMap.Utils.DynamicContainer.getIdToHtmlFromUserControl(control);

            var tinfo = "";
            if (tableinfo != null)
                tinfo = DynamicContainer.applyRowColumnProperties(tableinfo);

            var dockStyle = "";
            var controlTemplate = "";

            switch (ids.uid) {
                case "textbox":
                case "upgradehelpers_basicviewmodels_groupboxviewmodel":
                    controlTemplate = "<div id='" + ids.identifier + "' data-role='" + "groupbox" + "' data-bind='value: " + itemBindingExpression + "' class='" + ids.alias + dockStyle + "'  " + tinfo + "></div>";
                    break;
                default:
                    controlTemplate = "<div id='" + ids.identifier + "' data-role='" + ids.uid + "' data-bind='value: " + itemBindingExpression + "' class='" + ids.alias + dockStyle + "'  " + tinfo + "></div>";
                    break;
            }
            return controlTemplate;
        };

        static getIdToHtmlFromUserControl(control) {
            var useTag = (control.Tag && (typeof (control.Tag) == "string")) ? true : false; /// Backward compatibility validation

            var uid = useTag ? control.Tag : window.app.getControlRole(control); /// Backward compatibility validation
            var identifier = control.uid;
            var alias = control.Name ? control.Name : uid;
            return { uid, identifier, alias };
        }

        static applyTemplateForGroup(view: IControl) {

            var controls = [];
            if (view.Controls) {
                for (var i = 0; i < view.Controls.length; i++) {
                    if (view.Controls[i] && view.Controls[i].UniqueID != "") // This validation should be remove when server side doesn't insert null objects.
                        controls.push(view.Controls[i]);
                }
            }

            if (view) {
                var result = "";
                var controlRoles = {};
                var lastcontrolsIds = [];
                for (var i = 0; i < controls.length; i++) {
                    var control = controls[i];
                    //Handle pointer cases, when the property is a function
                    if (typeof control === "function") {
                        control = control();
                    }
                    //If the control is not undefined then load it. 
                    //We mark it inside controlsInPanel to avoid loading if if not necessary during the refresh call
                    if (control) {
                        control["$$$parent"] = WebMap.Utils.buildParentFromUniqueID(control.UniqueID);
                        var topModel = window["$cache"][view.UniqueID.split("#").pop()];

                        var html = WebMap.Utils.DynamicContainer.loadHTML(control, "", control["$$$parent"], i);
                        result += html;

                        lastcontrolsIds.push(control.UniqueID);
                        var controlrole = WebMap.Utils.DynamicContainer.getIdToHtmlFromUserControl(control);
                        if (controlrole) {
                            controlRoles[control.UniqueID] = controlrole.uid;
                        }

                    }
                }
                view["$$$lastcontrolsIds"] = lastcontrolsIds;
                view["$$$lastcontrols"] = controls.length;
                view["$$$lastroles"] = controlRoles;
            }
            return result;
        }
    }
}
 