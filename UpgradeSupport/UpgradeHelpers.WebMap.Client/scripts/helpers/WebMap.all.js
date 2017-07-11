var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
// Type definitions for jQueryUI 1.11
// Project: http://jqueryui.com/
// Definitions by: Boris Yankov <https://github.com/borisyankov/>, John Reilly <https://github.com/johnnyreilly>
// Definitions: https://github.com/DefinitelyTyped/DefinitelyTyped
/// <reference path="./jquery.d.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var MobilizeObservableObject = (function (_super) {
            __extends(MobilizeObservableObject, _super);
            function MobilizeObservableObject() {
                _super.apply(this, arguments);
            }
            MobilizeObservableObject.prototype.init = function (value) {
                var that = this, member, field, parent = function () {
                    return that;
                };
                kendo.Observable.fn.init.call(this);
                this['_handlers'] = {};
                for (field in value) {
                    that[field] = value[field];
                }
                that.uid = kendo.guid();
            };
            ;
            MobilizeObservableObject.prototype.merge = function (value) {
                var field, that = this;
                for (field in value) {
                    that[field] = value[field];
                }
            };
            MobilizeObservableObject.prototype.setModelValue = function (field, object) {
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
                    object['parent'] = function () { return that; };
                }
            };
            ;
            return MobilizeObservableObject;
        }(kendo.data.ObservableObject));
        Client.MobilizeObservableObject = MobilizeObservableObject;
        function eventHandler(context, type, field, prefix) {
            return function (e) {
                var event = {}, key;
                for (key in e) {
                    event[key] = e[key];
                }
                if (prefix) {
                    event.field = field + '.' + e.field;
                }
                else {
                    event.field = field;
                }
                if (type == 'change' && context._notifyChange) {
                    context._notifyChange(event);
                }
                context.trigger(type, event);
            };
        }
        Client.eventHandler = eventHandler;
        function cloneEvent(e) {
            var result = {};
            Object.keys(e).forEach(function (key) {
                if (key[0] != '_') {
                    result[key] = e[key];
                }
            });
            return result;
        }
        Client.cloneEvent = cloneEvent;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var Enums;
        (function (Enums) {
            (function (DockStyle) {
                DockStyle[DockStyle["None"] = 0] = "None";
                DockStyle[DockStyle["Top"] = 1] = "Top";
                DockStyle[DockStyle["Bottom"] = 2] = "Bottom";
                DockStyle[DockStyle["Left"] = 3] = "Left";
                DockStyle[DockStyle["Right"] = 4] = "Right";
                DockStyle[DockStyle["Fill"] = 5] = "Fill";
            })(Enums.DockStyle || (Enums.DockStyle = {}));
            var DockStyle = Enums.DockStyle;
        })(Enums = Client.Enums || (Client.Enums = {}));
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        (function (typeDialogCmd) {
            typeDialogCmd[typeDialogCmd["cmdOpen"] = 1] = "cmdOpen";
            typeDialogCmd[typeDialogCmd["cmdSave"] = 2] = "cmdSave";
        })(Client.typeDialogCmd || (Client.typeDialogCmd = {}));
        var typeDialogCmd = Client.typeDialogCmd;
        var FileDialogCommandHandler = (function () {
            function FileDialogCommandHandler() {
                this.id = "filedialog";
            }
            FileDialogCommandHandler.prototype.dispatch = function (cmd) {
                FileDialogCommandHandler.generateDialog(cmd);
            };
            FileDialogCommandHandler.saveDialog = function (nid, args) {
                var templateFileDialog = "", namedlg = "dialog" + nid;
                templateFileDialog += "<div id=" + namedlg + " style= 'width: 250px'>";
                templateFileDialog += "<br>Enter file name:<br><br>";
                templateFileDialog += "&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id='filename" + namedlg + "' TYPE='text' NAME= 'FileName' >";
                templateFileDialog += "<br><br><div class='dialog_buttons' >";
                templateFileDialog += "<input type='button' class='confirm_save k-button' value= 'Save' style= 'width: 70px' /> &nbsp;";
                templateFileDialog += "<input type='button' class='confirm_cancel k-button' value= 'Cancel' style= 'width: 70px' />";
                templateFileDialog += "</div>";
                templateFileDialog += "</div>";
                var w = $(templateFileDialog).kendoWindow({
                    title: "Export File",
                    modal: true,
                    resizable: false
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                var textFileName = $("#filename" + namedlg);
                var bSave = $('#' + namedlg + ' .confirm_save').kendoButton({
                    enable: false,
                    click: function (e) {
                        kendowWindow.close();
                        var dialogResult = "ok";
                        var dataURI_ = "data:text/plain;base64," + kendo.util.encodeBase64(args[0]);
                        var fileNameXML = textFileName.val();
                        var checkName = fileNameXML.toLowerCase();
                        if (checkName.indexOf(".xml") == -1) {
                            fileNameXML += ".xml";
                        }
                        kendo.saveAs({
                            dataURI: dataURI_,
                            fileName: fileNameXML
                        });
                        //(<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { } } });
                    }
                });
                $('#' + namedlg + ' .confirm_cancel').kendoButton({
                    click: function (e) {
                        kendowWindow.close();
                        var dialogResult = "cancel";
                        //(<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { } } });
                    }
                });
                textFileName.keyup(function () {
                    bSave.data("kendoButton").enable($(this).val() != "");
                });
            };
            FileDialogCommandHandler.openDialog = function (nid, args) {
                var templateFileDialog = "";
                templateFileDialog += "<div id=dialog" + nid + ">";
                templateFileDialog += "<p>File to import:</p>";
                templateFileDialog += "<input name='file'  id='" + nid + "' type='file'/>";
                templateFileDialog += "</div>";
                var w = $(templateFileDialog).kendoWindow({
                    title: "Select File to Import",
                    modal: true,
                    resizable: false
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                $("#" + nid + "").kendoUpload({
                    multiple: false,
                    showFileList: false,
                    async: {
                        saveUrl: window.document.URL + "FileDialog/UploadFile",
                        autoUpload: true
                    },
                    select: function (e) {
                        //$.each(e.files, function (index, value) {
                        //});
                    },
                    success: function onSuccess(e) {
                        var js = JSON.parse(e.response);
                        var dialogResult = "ok";
                        window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: { filenames: js.fileName } } });
                    },
                    complete: function e(e) {
                        w.data('kendoWindow').close();
                        w.data('kendoWindow').destroy();
                    }
                });
            };
            FileDialogCommandHandler.generateDialog = function (cmd) {
                var nid = "files" + Math.floor((Math.random() * 10000) + 1);
                switch (cmd.parameters.cmd) {
                    case typeDialogCmd.cmdOpen:
                        FileDialogCommandHandler.openDialog(nid, cmd.parameters.args);
                        break;
                    case typeDialogCmd.cmdSave:
                        FileDialogCommandHandler.saveDialog(nid, cmd.parameters.args);
                        break;
                }
            };
            FileDialogCommandHandler.InitMessageBoxHandler = function () {
                if (Client.CommandHandlerManager && Client.CommandHandlerManager.Current) {
                    Client.CommandHandlerManager.Current.registerHandler("filedialog", new FileDialogCommandHandler());
                    return null;
                }
            };
            FileDialogCommandHandler.staticinit = FileDialogCommandHandler.InitMessageBoxHandler();
            return FileDialogCommandHandler;
        }());
        Client.FileDialogCommandHandler = FileDialogCommandHandler;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        /**
         * Holds the catalog of client side behaviours
         * And interacts with the state manager
         */
        var ClientTypeBehaviourManager = (function () {
            function ClientTypeBehaviourManager() {
            }
            /**
             * Registers a Client Type Behaviour.
             * By default:
             * 1 --> ArraysClientTypeBehaviour
             * 2 --> StateObjectPointerClientTypeBehaviour
             */
            ClientTypeBehaviourManager.prototype.registerHandler = function (id, handler) {
                ClientTypeBehaviourManager.handlers[id] = handler;
            };
            /**
             * Returns the associated Client Type Behaviour
             */
            ClientTypeBehaviourManager.prototype.getBehaviour = function (obj) {
                if (!obj)
                    return undefined;
                //Built in typemappings
                var typeMark = obj["@k"];
                //Currently there is an issue with Newtonsoft. The JsonProperty setting is ignore and we are getting @k and k as well
                if (typeMark && ((typeMark == "1") || (obj["k"] == "1"))) {
                    return ClientTypeBehaviourManager.handlers[1];
                }
                return ClientTypeBehaviourManager.handlers[typeMark];
            };
            ClientTypeBehaviourManager.prototype.getBehaviourByID = function (typeMark) {
                return ClientTypeBehaviourManager.handlers[typeMark];
            };
            /**
             * Registers a function that will be trigger when the standard state organization actions are finished
             */
            ClientTypeBehaviourManager.prototype.registerPostOrganizeAction = function (action) {
                if (!this.postOrganizeActions) {
                    this.postOrganizeActions = [];
                }
                this.postOrganizeActions.push(action);
            };
            /**
             * Registers a function that will be trigger when the standard state organization actions are finished
             */
            ClientTypeBehaviourManager.prototype.registerPostShowViewsAction = function (action) {
                if (!this.postShowViewsActions) {
                    this.postShowViewsActions = [];
                }
                this.postShowViewsActions.push(action);
            };
            /**
             * Execute any post-organized actions registered by any of the client side behaviours
             */
            ClientTypeBehaviourManager.prototype.execPostOrganizeActions = function () {
                if (!this.postOrganizeActions)
                    return;
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
            };
            /**
             * Execute any post-organized actions registered by any of the client side behaviours
             */
            ClientTypeBehaviourManager.prototype.execPostShowViewsActions = function () {
                if (!this.postShowViewsActions)
                    return;
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
            };
            ClientTypeBehaviourManager.Init = function () {
                ClientTypeBehaviourManager.handlers = {};
                ClientTypeBehaviourManager.Current = new ClientTypeBehaviourManager();
                ClientTypeBehaviourManager.Current.postOrganizeActions = [];
                return null;
            };
            ///Typescript does not have static constructors
            ///This variable is used just to achieve the same as an static constructor
            ClientTypeBehaviourManager.staticinit = ClientTypeBehaviourManager.Init();
            return ClientTypeBehaviourManager;
        }());
        Client.ClientTypeBehaviourManager = ClientTypeBehaviourManager;
        var ArraysClientTypeBehaviour = (function () {
            function ArraysClientTypeBehaviour() {
                this.itemsCollections = [];
                this.postActionRegistered = false;
            }
            ArraysClientTypeBehaviour.Init = function () {
                ClientTypeBehaviourManager.Current.registerHandler(1, new ArraysClientTypeBehaviour());
                return null;
            };
            ArraysClientTypeBehaviour.prototype.cons = function (jsonData) { return undefined; };
            ArraysClientTypeBehaviour.prototype.preOrganizeAction = function (jsonData) {
                if (!this.postActionRegistered) {
                    var that = this;
                    ClientTypeBehaviourManager.Current.registerPostOrganizeAction(function () {
                        var $cache = WebMap.Client.StateManager.Current._cache;
                        for (var i = 0; i < that.itemsCollections.length; i++) {
                            var curr = that.itemsCollections[i];
                            var parent = $cache[curr.Parent];
                            var items = $cache[curr.Items];
                            if (parent && items) {
                                parent.set("Items", items);
                            }
                        }
                    });
                    this.postActionRegistered = true;
                }
                this.itemsCollections.push({ Parent: jsonData.UniqueID, Items: "_items" + Client.UniqueIDGenerator.UniqueIdSeparator + jsonData.UniqueID });
                return jsonData;
            };
            ArraysClientTypeBehaviour.staticinit = ArraysClientTypeBehaviour.Init();
            return ArraysClientTypeBehaviour;
        }());
        Client.ArraysClientTypeBehaviour = ArraysClientTypeBehaviour;
        var StateObjectPointerClientTypeBehaviour = (function () {
            function StateObjectPointerClientTypeBehaviour() {
                this.pointers = [];
                this.postActionRegistered = false;
            }
            StateObjectPointerClientTypeBehaviour.Init = function () {
                ClientTypeBehaviourManager.Current.registerHandler(2, new StateObjectPointerClientTypeBehaviour());
                return null;
            };
            StateObjectPointerClientTypeBehaviour.prototype.cons = function (jsonData) { return undefined; };
            StateObjectPointerClientTypeBehaviour.prototype.registerActionPostOrganize = function () {
                //Just do this the first time
                if (this.postActionRegistered)
                    return;
                this.postActionRegistered = true;
                var that = this;
                ClientTypeBehaviourManager.Current.registerPostOrganizeAction(function () {
                    //Get direct access to the cache table
                    var $cache = WebMap.Client.StateManager.Current._cache;
                    //Iterate thru the list of collected pointers
                    for (var i = 0; i < that.pointers.length; i++) {
                        var currentPointer = that.pointers[i];
                        //First we need to know where will be the pointer inserted
                        //The first element will be something like ->property#object1#2
                        var property = "";
                        if (currentPointer.v) {
                            property = currentPointer.v[0];
                        }
                        else if (currentPointer.u) {
                            property = JSON.parse(currentPointer.u[0]);
                        }
                        else
                            property = currentPointer[0];
                        property = property.replace("->", "");
                        //Now we will use this property unique ID to get to the actual object
                        var accessPath = property.split(Client.UniqueIDGenerator.UniqueIdSeparator).reverse();
                        var field = accessPath.pop();
                        var rootUniqueID = property.replace(field + Client.UniqueIDGenerator.UniqueIdSeparator, "");
                        var root = $cache[rootUniqueID];
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
                                else if (currentPointer.d) { }
                                else {
                                    var field = WebMap.Utils.getNameFromAlias(root["@k"], field);
                                    root[field] = temp;
                                    if (temp) {
                                        $cache[property] = temp;
                                        if (!temp[Client.UniqueIDGenerator.ReferencesIdentifier])
                                            temp[Client.UniqueIDGenerator.ReferencesIdentifier] = [];
                                        temp[Client.UniqueIDGenerator.ReferencesIdentifier].push(property);
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
            };
            StateObjectPointerClientTypeBehaviour.prototype.preOrganizeAction = function (jsonData) {
                this.registerActionPostOrganize();
                //This json object has an structure like
                //{@k=2,p["->property#object1#2","proper2#panel1#2"]}
                //or
                //{@k=2,v["T186", 19]}
                window.app.log("Processing pointer");
                window.app.log(jsonData);
                if (jsonData.p) {
                    this.pointers.push(jsonData.p);
                }
                else if (jsonData.v) {
                    this.pointers.push({ v: jsonData.v });
                }
                //We return undefined so this jsonData object is no longer used
                //At the end of the state processing cycle the postOrganize action will
                //we triggered and pointer will be connected
                return undefined;
            };
            StateObjectPointerClientTypeBehaviour.staticinit = StateObjectPointerClientTypeBehaviour.Init();
            return StateObjectPointerClientTypeBehaviour;
        }());
        Client.StateObjectPointerClientTypeBehaviour = StateObjectPointerClientTypeBehaviour;
        ///Allows the registration of events that were dynamically added during the processing of a sendAction call
        var DynamicEventClientTypeBehaviour = (function () {
            function DynamicEventClientTypeBehaviour() {
                this.events = {};
                this.pendingEvents = {};
                this.postActionRegistered = false;
            }
            DynamicEventClientTypeBehaviour.Init = function () {
                ClientTypeBehaviourManager.Current.registerHandler(5, new DynamicEventClientTypeBehaviour());
                return null;
            };
            DynamicEventClientTypeBehaviour.prototype.cons = function (jsonData) { return undefined; };
            DynamicEventClientTypeBehaviour.prototype.bindEventsForPendingItems = function (isContextMenuStrip, alwaysBind) {
                if (isContextMenuStrip === void 0) { isContextMenuStrip = false; }
                if (alwaysBind === void 0) { alwaysBind = false; }
                var that = this;
                var keys = Object.keys(that.pendingEvents);
                for (var i = 0; i < keys.length; i++) {
                    var uniqueID = keys[i];
                    var eventsForWidget = that.pendingEvents[uniqueID];
                    var widget = WebMap.Utils.getWidgetInDOM(uniqueID, isContextMenuStrip);
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
                }
            };
            DynamicEventClientTypeBehaviour.prototype.registerPostShowViewsAction = function () {
                var _this = this;
                //Just do this the first time
                if (this.postActionRegistered)
                    return;
                this.postActionRegistered = true;
                var that = this;
                ClientTypeBehaviourManager.Current.registerPostShowViewsAction(function () {
                    var keys = Object.keys(that.events);
                    for (var i = 0; i < keys.length; i++) {
                        var uniqueID = keys[i];
                        var eventsForWidget = that.events[uniqueID];
                        var widget = WebMap.Utils.getWidgetInDOM(uniqueID);
                        if (!widget) {
                            if (!_this.pendingEvents[uniqueID])
                                _this.pendingEvents[uniqueID] = [];
                            for (var j = 0; j < eventsForWidget.length; j++) {
                                // check for duplicates before adding the event
                                var duplicate = false;
                                for (var k = 0; k < _this.pendingEvents[uniqueID].length; k++) {
                                    if (_this.pendingEvents[uniqueID][k].EventId == eventsForWidget[j].EventId) {
                                        duplicate = true;
                                        break;
                                    }
                                }
                                if (!duplicate)
                                    _this.pendingEvents[uniqueID].push(new Client.DynamicEventData(uniqueID, eventsForWidget[j].EventId));
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
            };
            DynamicEventClientTypeBehaviour.prototype.preOrganizeAction = function (jsonData) {
                this.registerPostShowViewsAction();
                var data = jsonData;
                if (!this.events[jsonData.UniqueID])
                    this.events[jsonData.UniqueID] = [];
                this.events[jsonData.UniqueID].push(new Client.DynamicEventData(jsonData.UniqueID, jsonData.EventID));
            };
            DynamicEventClientTypeBehaviour.staticinit = DynamicEventClientTypeBehaviour.Init();
            return DynamicEventClientTypeBehaviour;
        }());
        Client.DynamicEventClientTypeBehaviour = DynamicEventClientTypeBehaviour;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var CommandHandlerManager = (function () {
            function CommandHandlerManager() {
            }
            CommandHandlerManager.prototype.registerHandler = function (id, handler) {
                CommandHandlerManager.handlers[id] = handler;
            };
            CommandHandlerManager.prototype.dispatchAll = function (commands) {
                for (var i = 0; i < commands.length; i++) {
                    var cmd = commands[i];
                    var handler = CommandHandlerManager.handlers[cmd.id];
                    if (handler)
                        handler.dispatch(cmd);
                }
            };
            CommandHandlerManager.InitCommandHandlerManager = function () {
                CommandHandlerManager.handlers = {};
                CommandHandlerManager.Current = new CommandHandlerManager();
                return null;
            };
            CommandHandlerManager.staticinit = CommandHandlerManager.InitCommandHandlerManager();
            return CommandHandlerManager;
        }());
        Client.CommandHandlerManager = CommandHandlerManager;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="kendo.all.d.ts" />
function normalizeUniqueID(value) {
    var strUniqueId = "";
    strUniqueId = value.replace(/[#\[\]./]/g, "_");
    return strUniqueId;
}
function UserControl_CalcAncestorPath(value) {
    if (!value["$$$parent"]) {
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
                        }
                        else {
                            value["$$$parent"] = propName;
                        }
                    }
                    else {
                        if (parent instanceof kendo.data.ObservableArray && parent.parent()) {
                            ancestorPath = parent["$$$parent"];
                            value["$$$parent"] = ancestorPath + "[" + propName + "]";
                        }
                        else {
                            value["$$$parent"] = ancestorPath + "." + propName;
                        }
                    }
                    break;
                }
            }
        }
    }
}
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var ui = kendo.ui, Widget = ui.Widget;
        var BaseUserControl = (function () {
            function BaseUserControl() {
                this.options = {
                    /** the name is what it will appear as off the kendo namespace(i.e. kendo.ui.UserControl1).
                     *The jQuery plugin would be jQuery.fn.kendoUserControl1.
                     */
                    name: "BaseUserControl",
                    value: null,
                    css: "",
                    template: "<div></div>",
                    uiinitialized: false
                };
                this.UIInitialized = function (initialized) {
                    this.options.uiinitialized = initialized;
                };
                this.ApplyValueChanges = function (changeEvent) {
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
                    }
                    else if (changeEvent.field === "Visible") {
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
                                    action: function () {
                                        that.refresh();
                                    }
                                });
                            }
                        }
                    }
                };
            }
            BaseUserControl.prototype.applyTemplate = function (value) {
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
            };
            BaseUserControl.prototype.initStyles = function () {
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
                        if (style.styleSheet)
                            style.styleSheet.cssText = styles; //IE 
                        else
                            style.innerHTML = styles; //OTHERS 
                        document.getElementsByTagName('head')[0].appendChild(style);
                    }
                };
                addCssRule(that.options.css, '' + that.options.name);
            };
            BaseUserControl.prototype.initClientMethods = function (value) {
                var that = value;
            };
            BaseUserControl.prototype.init = function (element, options) {
                // base call to initialize widget 
                options._uiinitialized = false;
                Widget.fn.init.call(this, element, options);
            };
            //override the function destroy,  to add custom implementation or aditional code when applied kendo destroy in widgets
            BaseUserControl.prototype.destroy = function () {
                try {
                    var that = this;
                    if (!that.inDestroy) {
                        that.inDestroy = true;
                        //Call the overriden widgetDestroy func of the widgets.
                        try {
                            that.widgetDestroy();
                        }
                        catch (e) {
                            window.app.log("widgetDestroy: error on destroying the widget " + that._value.Name);
                        }
                        Widget.fn.destroy.call(that);
                        that.element.removeData();
                        that.element.removeAttr();
                        // Unbind all the events associated with the object.
                        that.element.unbind();
                        that._value.unbind();
                        that.unbind();
                        try {
                            //Destroy the element
                            kendo.destroy(that.element);
                        }
                        catch (e) {
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
                }
                catch (e) {
                    var name = "";
                    if (that._value && that._value.Name)
                        name = that._value.Name;
                    window.app.log("destroy: error on destroying the widget " + name);
                }
            };
            BaseUserControl.prototype.widgetDestroy = function () { };
            BaseUserControl.prototype.refresh = function () { };
            BaseUserControl.prototype.KeyBoardEvents = function (value) {
                var element, events, arrEvents, role, data;
                if (value && value.element && value._events) {
                    element = value.element;
                    events = value._events;
                }
                if (element && events) {
                    arrEvents = Object.keys(value._events);
                    if (arrEvents.length && arrEvents.length > 0) {
                        role = window.app.getControlRole(value._value);
                        // these events won't be set to the richtextbox. Their implementation should be different inside the widget
                        if (role && (role == "richtextbox" || role.indexOf("textbox") != -1))
                            return;
                        data = element.data(name);
                        if (jQuery.inArray("keypress", arrEvents) != -1) {
                            element.keypress(function (e) {
                                if (e.keyCode && data)
                                    data.trigger("keypress", e);
                            });
                        }
                        if (jQuery.inArray("keydown", arrEvents) != -1) {
                            element.keydown(function (e) {
                                if (e.keyCode && data)
                                    data.trigger("keydown", e);
                            });
                        }
                        if (jQuery.inArray("keyup", arrEvents) != -1) {
                            element.keyup(function (e) {
                                if (e.keyCode && data)
                                    data.trigger("keyup", e);
                            });
                        }
                    }
                }
            };
            BaseUserControl.prototype.buildUI = function () {
                try {
                    var that = this;
                    if (that._value == null || that._value == undefined) {
                        throw new Error("_value on " + that.options.name + " is null or undefined.");
                    }
                    that.UIInitialized(true);
                    //Set Options is defined in Widget
                    that.setOptions(that.options);
                    var that = this, view = that._value;
                    if (view) {
                        view["$$$parent"] = WebMap.Utils.buildParentFromUniqueID(view.UniqueID);
                        $(that.element).attr("data-processed", true);
                        that.element.html(that.applyTemplate(view));
                        WebMap.Utils.bindElementToModel(that.element, view);
                    }
                }
                catch (exp) {
                    var elemID = this.element.attr("id");
                    var uniqueID = this._value != undefined ? this._value.UniqueID : "undefined";
                    var widgetName = this.options.name;
                    console.error("BaseUserControl::buildUI exception: %s. Elem ID=[%s]. UniqueID=[%s]. Widget=[%s]", exp, elemID, uniqueID, widgetName);
                }
            };
            //MVVM framework calls 'value' when the viewmodel 'value' binding changes 
            BaseUserControl.prototype.value = function (val) {
                var that = this;
                if (val === undefined) {
                    return that._value;
                }
                that._update(val);
                //that._old = that._value;  // MOBILIZE, 2016-05-03, KLUN, this property has never been used from the any widgets.
            };
            BaseUserControl.prototype.normalizeKey = function (key) {
                return key.replace(/\//g, "").replace(/ /g, "_");
            };
            BaseUserControl.prototype.normalizeKeys = function (value) {
                try {
                    if (value['Columns'] && value['Columns']['ColumnsList']) {
                        var columnsList = value['Columns']['ColumnsList'];
                        for (var i = 0; i < columnsList.length; i++) {
                            var column = columnsList[i];
                            if (column['Key'])
                                column['Key'] = this.normalizeKey(column['Key']);
                        }
                    }
                    if (value['DataSourceList']) {
                        var DataSourceList = value['DataSourceList'];
                        for (var i = 0; i < DataSourceList.length; i++) {
                            var data = DataSourceList[i];
                            if (data['Keys']) {
                                var keys = data['Keys'];
                                for (var j = 0; j < keys.length; j++) {
                                    keys[j] = this.normalizeKey(keys[j]);
                                }
                            }
                        }
                    }
                }
                catch (err) {
                }
            };
            BaseUserControl.prototype._update = function (value) {
                try {
                    this.normalizeKeys(value);
                    var that = this;
                    that._value = value;
                    if (!that.options.uiinitialized) {
                        //Every control should be able to modify it's state when it's not visible
                        if (that._value) {
                            WebMap.Utils.bindEventToModel(that._value, "change", function (changeEvent) {
                                that.ApplyValueChanges(changeEvent);
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
                            action: function () {
                                that.refresh();
                            }
                        });
                    }
                    WebMap.Client.Responsiveness.ProcessObjectForResponsiveness(that);
                }
                catch (exp) {
                    var elemID = this.element.attr("id");
                    var uniqueID = this._value != undefined ? this._value.UniqueID : "undefined";
                    var widgetName = this.options.name;
                    console.error("BaseUserControl::buildUI exception: %s. Elem ID=[%s]. UniqueID=[%s]. Widget=[%s]", exp, elemID, uniqueID, widgetName);
                }
            };
            BaseUserControl.prototype.safeRefresh = function () {
                var that = this;
                window.app.Safe.safeExec({
                    stage: Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                    obj: that._value,
                    action: function () { return that.refresh(); },
                    whenNotAtThatStage: Client.SafeExecutionConditions.QueueForLater,
                    category: "requestAction"
                });
            };
            return BaseUserControl;
        }());
        Client.BaseUserControl = BaseUserControl;
        ui.plugin(Widget.extend(new BaseUserControl()));
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var DynamicEventData = (function () {
            function DynamicEventData(uniqueID, eventId) {
                this.uniqueID = uniqueID;
                this.eventId = eventId;
                this.UniqueID = uniqueID;
                this.EventId = eventId;
            }
            return DynamicEventData;
        }());
        Client.DynamicEventData = DynamicEventData;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var InputBoxCommandHandler = (function () {
            function InputBoxCommandHandler() {
                this.id = "inputbox";
            }
            InputBoxCommandHandler.prototype.dispatch = function (cmd) {
                InputBoxCommandHandler.showInputMessageDialog(cmd);
            };
            InputBoxCommandHandler.showInputMessageDialog = function (cmd) {
                var inputBox = cmd.parameters;
                var inputBoxTemplate = InputBoxCommandHandler.getTemplate(inputBox);
                // Create the window to be displayed
                var w = $(inputBoxTemplate).kendoWindow({
                    title: inputBox.title ? inputBox.title : "",
                    modal: true,
                    resizable: false
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                // Add handlers to close the window
                w.find('.msgboxokbuttoncls,.msgboxcancelbuttoncls')
                    .click(function () {
                    var dialogResult = "cancel";
                    var inputValue = "";
                    var input = $(w).find('.msgboxinputfieldcls')[0];
                    if ($(this).hasClass('msgboxokbuttoncls')) {
                        dialogResult = "ok";
                        inputValue = $(input).val();
                    }
                    else {
                        dialogResult = "cancel";
                        inputValue = "";
                    }
                    window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", parameters: { "dialogResult": dialogResult, "requestedInput": inputValue } });
                    w.data('kendoWindow').close();
                });
            };
            InputBoxCommandHandler.getTemplate = function (inputBox) {
                var template = "<div class='wmmsgbox __additional_classes__'>" +
                    "<span class='msgboxmsgnclass'> " + inputBox.prompt + "</span ><br>" +
                    "<div style='text-align:left'><input style='width:100%' type='text' class='k-textbox msgboxinputfieldcls' value='" + inputBox.defaultResponse + "'></div><br>" +
                    "<div style='text-align:center'><button class='msgboxokbuttoncls' > OK </button >&nbsp<button class='msgboxcancelbuttoncls'>Cancel</button></div>";
                return template;
            };
            InputBoxCommandHandler.InitInputBoxHandler = function () {
                Client.CommandHandlerManager.Current.registerHandler("inputbox", new InputBoxCommandHandler());
                return null;
            };
            InputBoxCommandHandler.staticinit = InputBoxCommandHandler.InitInputBoxHandler();
            return InputBoxCommandHandler;
        }());
        Client.InputBoxCommandHandler = InputBoxCommandHandler;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
/// <reference path="../helpers/require.d.ts"/>
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var InvokeActionCommandHandler = (function () {
            function InvokeActionCommandHandler() {
                this.id = "invokeaction";
            }
            InvokeActionCommandHandler.prototype.dispatch = function (cmd) {
                var requestedModule;
                requestedModule = cmd.parameters.args[0];
                switch (requestedModule) {
                    case "PatientChange":
                        InvokeActionCommandHandler.PatientChange(cmd);
                        break;
                    case "EncounterChange":
                        InvokeActionCommandHandler.EncounterChange(cmd);
                        break;
                    case "PrintDialog":
                        InvokeActionCommandHandler.showHtmlDialog(cmd, "PrintDialog");
                        break;
                    case "PrintChart":
                        InvokeActionCommandHandler.showHtmlDialog(cmd, "PrintChart");
                        break;
                    case "TaskDialog":
                        InvokeActionCommandHandler.showHtmlDialog(cmd, "TaskDialog");
                        break;
                    case "CreateNewDocument":
                        InvokeActionCommandHandler.showHtmlDialog(cmd, "CreateNewDocument");
                        break;
                    case "SetDocumentContext":
                        InvokeActionCommandHandler.SetDocumentForNote(cmd);
                        break;
                    case "SpellChecker":
                        InvokeActionCommandHandler.SpellCheckV11(cmd);
                        break;
                    case "UpdateMacros":
                        InvokeActionCommandHandler.MacrosChange(cmd);
                        break;
                    case "ChangeContextNavigator":
                        InvokeActionCommandHandler.ChangeContextNavigator(cmd);
                        break;
                    default:
                        console.log("Invoke action handler pending");
                        break;
                }
            };
            InvokeActionCommandHandler.SpellCheckV11 = function (cmd) {
                $.getScript("scripts/frontpage/WebWorks/notev11.spellcheck.js");
            };
            InvokeActionCommandHandler.SetDocumentForNote = function (cmd) {
                glo_isDocEdit = true;
                glo_docId = cmd.parameters.args[1];
                glo_sSubClass = cmd.parameters.args[2];
                glo_bFromResume = false;
            };
            InvokeActionCommandHandler.ChangeContextNavigator = function (cmd) {
                $.getScript("scripts/frontpage/ContextNavigatorChangeManagers.js");
                window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
            };
            InvokeActionCommandHandler.PatientChange = function (cmd) {
                glo_patientId = cmd.parameters.args[1];
                $.getScript("scripts/frontpage/PatientContextChangeManager.js");
                window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
            };
            InvokeActionCommandHandler.EncounterChange = function (cmd) {
                glo_encounterId = cmd.parameters.args[1];
                $.getScript("scripts/frontpage/EncounterContextChangeManager.js");
                window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
            };
            InvokeActionCommandHandler.MacrosChange = function (cmd) {
                args = cmd.parameters.args.join(",");
                $.getScript("scripts/frontpage/MacrosChangeManager.js");
                window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: "ok", parameters: { requestedInput: "" } });
            };
            InvokeActionCommandHandler.showHtmlDialog = function (cmd, screen) {
                args = cmd.parameters.args.join(",");
                appName = cmd.parameters.appName;
                glo_ptid = cmd.parameters.args[1];
                glo_id = [cmd.parameters.args[2], ""];
                glo_sWhere = cmd.parameters.args[3];
                glo_sOrder = cmd.parameters.args[4];
                glo_sGroup1 = cmd.parameters.args[5];
                glo_sGroup2 = cmd.parameters.args[6];
                glo_sPurpose = cmd.parameters.args[8];
                var dialogResult = "ok";
                switch (screen) {
                    case "PrintDialog":
                        //Mobilize.MLO: Script injection for subsecuent management of script loading.     
                        $.getScript("scripts/frontpage/InvokeActionManager.js");
                        break;
                    case "TaskDialog":
                        {
                            glo_WORKTYPE = cmd.parameters.args[2];
                            glo_WORKOBJECTID = cmd.parameters.args[3];
                            glo_patientId = cmd.parameters.args[5];
                            $.getScript("scripts/frontpage/InvokeActionTaskList.js");
                            window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: "" } });
                        }
                        break;
                    case "CreateNewDocument":
                        {
                            glo_selectedDocType = cmd.parameters.args[1];
                            glo_encDTTM = cmd.parameters.args[2];
                            glo_endID = cmd.parameters.args[3];
                            glo_patID = cmd.parameters.args[4];
                            glo_saveObject = cmd.parameters.args[5];
                            glo_sFormID = cmd.parameters.args[6];
                            glo_sOwnerFullName = cmd.parameters.args[7];
                            glo_dOwnerID = cmd.parameters.args[8];
                            window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult, parameters: { requestedInput: "" } });
                        }
                        break;
                    default:
                        $.getScript("scripts/frontpage/InvokeActionManager.js");
                        break;
                }
            };
            InvokeActionCommandHandler.InitInvokeActionHandler = function () {
                Client.CommandHandlerManager.Current.registerHandler("invokeaction", new InvokeActionCommandHandler());
                return null;
            };
            InvokeActionCommandHandler.staticinit = InvokeActionCommandHandler.InitInvokeActionHandler();
            return InvokeActionCommandHandler;
        }());
        Client.InvokeActionCommandHandler = InvokeActionCommandHandler;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Utils;
    (function (Utils) {
        var KendoWidgetMappings = (function () {
            function KendoWidgetMappings() {
            }
            KendoWidgetMappings.getMappedEvent = function (widget, eventID) {
                var eventMapped = null;
                // widget
                var widgetName = widget.options['name'];
                //the keys are stored lower case.
                widgetName = widgetName.toLowerCase();
                var widgetMappings = this._typeMappings[widgetName];
                if (widgetMappings) {
                    eventMapped = widgetMappings[eventID];
                }
                return eventMapped;
            };
            KendoWidgetMappings.getMappedEventForMenuItem = function (widget, eventID) {
                var eventMapped = null;
                // widget
                var widgetName = widget.attr("role");
                if (widgetName) {
                    //the keys are stored lower case.
                    widgetName = widgetName.toLowerCase();
                    var widgetMappings = this._typeMappings[widgetName];
                    if (widgetMappings) {
                        eventMapped = widgetMappings[eventID];
                    }
                }
                return eventMapped;
            };
            KendoWidgetMappings._typeMappings = {
                'button': { 'CLICK': 'click' },
                'picturebox': { 'CLICK': 'click' },
                'ultrabutton': { 'CLICK': 'click' },
                'twtextbox': { 'TEXTCHANGED': 'change' },
                'menuitem': { 'CLICK': 'click' }
            };
            return KendoWidgetMappings;
        }());
        Utils.KendoWidgetMappings = KendoWidgetMappings;
    })(Utils = WebMap.Utils || (WebMap.Utils = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var Responsiveness = (function () {
            function Responsiveness() {
            }
            Responsiveness.ProcessObjectForResponsiveness = function (object) {
                /* Step 1: Process its Dock Style*/
                //this.SetDockStyle(object);
            };
            Responsiveness.SetDockStyle = function (object) {
                try {
                    var model = object._value;
                    var element = object.element;
                    if (model.Visible) {
                        switch (model.Dock) {
                            case Client.Enums.DockStyle.Top:
                                this.SetDisplayToParent(element);
                                element.css("width", "100%");
                                break;
                            case Client.Enums.DockStyle.Bottom:
                                this.SetDisplayToParent(element);
                                element.css("width", "100%");
                                break;
                            case Client.Enums.DockStyle.Left:
                                this.SetDisplayToParent(element);
                                element.css("height", "100%").css("position", "relative").css("left", "");
                                break;
                            case Client.Enums.DockStyle.Right:
                                this.SetDisplayToParent(element);
                                element.css("height", "100%").css("position", "relative").css("left", "");
                                break;
                            case Client.Enums.DockStyle.Fill:
                                this.SetDisplayToParent(element);
                                element.css("flex-grow", "1").css("width", "100%").css("height", "100%").css("position", "relative").css("left", "");
                                break;
                        }
                    }
                }
                catch (e) {
                }
            };
            Responsiveness.SetDisplayToParent = function (element) {
                var parent = element.parent();
                var displayType = parent.css("display");
                if (displayType == "flex")
                    return;
                if (displayType != "none") {
                    parent.css("display", "flex");
                }
            };
            return Responsiveness;
        }());
        Client.Responsiveness = Responsiveness;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var MessageBoxCommandHandler = (function () {
            function MessageBoxCommandHandler() {
                this.id = "msg";
            }
            MessageBoxCommandHandler.prototype.dispatch = function (cmd) {
                MessageBoxCommandHandler.showMessageDialog(cmd);
            };
            MessageBoxCommandHandler.showMessageDialog = function (cmd) {
                var msg = cmd.parameters;
                var msgBoxTemplate = MessageBoxCommandHandler.preparteMessageBoxTemplate(msg);
                // Create the window to be displayed
                var w = $(msgBoxTemplate).kendoWindow({
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                // Add handlers to close the window
                w.find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls,.msgboxretrybuttoncls')
                    .click(function () {
                    var dialogResult = "cancel";
                    if ($(this).hasClass('msgboxokbuttoncls')) {
                        dialogResult = "ok";
                    }
                    else if ($(this).hasClass('msgboxyesbuttoncls')) {
                        dialogResult = "yes";
                    }
                    else if ($(this).hasClass('msgboxnobuttoncls')) {
                        dialogResult = "no";
                    }
                    else if ($(this).hasClass('msgboxretrybuttoncls')) {
                        dialogResult = "retry";
                    }
                    else {
                        dialogResult = "cancel";
                    }
                    window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult });
                    w.data('kendoWindow').close();
                    w.data('kendoWindow').destroy();
                });
            };
            MessageBoxCommandHandler.preparteMessageBoxTemplate = function (msg) {
                var msgBoxTemplate = "<div class='wmmsgbox __additional_classes__'>" +
                    "<span class='msgboxiconscls' ></span><span class='msgboxmsgnclass'> " + msg.text + "</span > " +
                    "<div style='text-align:center'>";
                var iconClass = MessageBoxCommandHandler.getMessageBoxIconCssClass(msg.icons);
                if ((!msg.buttons) || msg.buttons == 1) {
                    msgBoxTemplate = msgBoxTemplate + "<button class='msgboxokbuttoncls' > OK </button > ";
                }
                if (msg.buttons == 3 || msg.buttons == 4) {
                    msgBoxTemplate = msgBoxTemplate + "<button class='msgboxyesbuttoncls' > Yes </button > ";
                    msgBoxTemplate = msgBoxTemplate + "<button class='msgboxnobuttoncls'>No</button>";
                }
                if (msg.buttons == 5) {
                    msgBoxTemplate = msgBoxTemplate + "<button class='msgboxretrybuttoncls'>Retry</button>";
                }
                if (msg.buttons == 1 || msg.buttons == 3 || msg.buttons == 5) {
                    msgBoxTemplate = msgBoxTemplate + "<button class='msgboxcancelbuttoncls'>Cancel</button>";
                }
                msgBoxTemplate = msgBoxTemplate + "</div>";
                msgBoxTemplate = msgBoxTemplate.replace('__additional_classes__', iconClass);
                return msgBoxTemplate;
            };
            MessageBoxCommandHandler.getMessageBoxIconCssClass = function (id) {
                var iconClass = "";
                switch (id) {
                    case 1:
                        iconClass = "msgboxquestion";
                        break;
                    case 2:
                        iconClass = "msgboxwarning";
                        break;
                    case 3:
                        iconClass = "msgboxerror";
                        break;
                }
                return iconClass;
            };
            MessageBoxCommandHandler.showSessionExpiredMessage = function () {
                var msg = { UniqueID: "generic", text: "The application session has timeout! You must reload the application.", buttons: 0, caption: "Session Expired" };
                var msgBoxTemplate = this.preparteMessageBoxTemplate(msg);
                // Create the window to be displayed
                var w = $(msgBoxTemplate).kendoWindow({
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false,
                    width: 300
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                // Add handlers to close the window
                w.find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls')
                    .click(function () {
                    location.reload(true);
                });
                // Add handlers to close the window
                w.find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls').html("Reload");
            };
            MessageBoxCommandHandler.showGenericMessage = function (messageText) {
                var msg = { UniqueID: "generic", text: messageText, buttons: 1, caption: "Exception Occurred" };
                var msgBoxTemplate = MessageBoxCommandHandler.preparteMessageBoxTemplate(msg);
                // Create the window to be displayed
                var w = $(msgBoxTemplate).kendoWindow({
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false
                });
                var kendowWindow = w.data("kendoWindow");
                kendowWindow.center().open();
                // Add handlers to close the window
                w.find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls')
                    .click(function () {
                    var dialogResult = "cancel";
                    if ($(this).hasClass('msgboxokbuttoncls')) {
                        dialogResult = "ok";
                    }
                    else if ($(this).hasClass('msgboxyesbuttoncls')) {
                        dialogResult = "yes";
                    }
                    else if ($(this).hasClass('msgboxnobuttoncls')) {
                        dialogResult = "no";
                    }
                    else {
                        dialogResult = "cancel";
                    }
                    window.app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult });
                    w.data('kendoWindow').close();
                });
            };
            MessageBoxCommandHandler.InitMessageBoxHandler = function () {
                Client.CommandHandlerManager.Current.registerHandler("msg", new MessageBoxCommandHandler());
                return null;
            };
            MessageBoxCommandHandler.staticinit = MessageBoxCommandHandler.InitMessageBoxHandler();
            return MessageBoxCommandHandler;
        }());
        Client.MessageBoxCommandHandler = MessageBoxCommandHandler;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var PluginCommandHandler = (function () {
            function PluginCommandHandler() {
                this.id = "plugin";
            }
            PluginCommandHandler.prototype.dispatch = function (cmd) {
                PluginCommandHandler.sendCommandToDesktopAgent(cmd);
            };
            PluginCommandHandler.sendCommandToDesktopAgent = function (cmd) {
                $.ajax({
                    url: "http://localhost:60064/api/dopluginaction",
                    data: JSON.stringify(cmd.parameters),
                    "type": "POST",
                    contentType: "application/json",
                    success: function (data) {
                        console.log("-- Trying SelfHost Communication --");
                        console.log("Response: ");
                        console.log(data);
                    }
                });
            };
            PluginCommandHandler.InitPluginCommandHandler = function () {
                Client.CommandHandlerManager.Current.registerHandler("plugin", new PluginCommandHandler());
                return null;
            };
            PluginCommandHandler.staticinit = PluginCommandHandler.InitPluginCommandHandler();
            return PluginCommandHandler;
        }());
        Client.PluginCommandHandler = PluginCommandHandler;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var WebMap;
(function (WebMap) {
    var Utils;
    (function (Utils) {
        function getHashCodeFromUniqueID(uniqueID) {
            var hash = 0, len = uniqueID.length, chr;
            if (len === 0)
                return hash.toString(16);
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
        Utils.getHashCodeFromUniqueID = getHashCodeFromUniqueID;
        function getWidgetInDOM(uniqueID, isMenuItem) {
            if (isMenuItem === void 0) { isMenuItem = false; }
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
                }
                else {
                    return null;
                }
            }
            return undefined;
        }
        Utils.getWidgetInDOM = getWidgetInDOM;
        function bindWidgetToEvent(widget, eventID, uniqueID, alwaysBind) {
            if (alwaysBind === void 0) { alwaysBind = false; }
            var mappedEvent = Utils.KendoWidgetMappings.getMappedEvent(widget, eventID);
            if (mappedEvent && this.isEventInWidgetEvents(widget, mappedEvent) || mappedEvent && alwaysBind) {
                var controlVM = window["$cache"][uniqueID];
                var bindedFunction = getSendActionFunction(controlVM, "EventDispatcher", "ProcessMessage", { 'eventID': eventID });
                widget.bind(mappedEvent, bindedFunction);
                return true;
            }
            return false;
        }
        Utils.bindWidgetToEvent = bindWidgetToEvent;
        function bindMenuItemToEvent(widget, eventID, uniqueID) {
            var mappedEvent = Utils.KendoWidgetMappings.getMappedEventForMenuItem(widget, eventID);
            if (mappedEvent) {
                var controlVM = window["$cache"][uniqueID];
                var bindedFunction = getSendActionFunction(controlVM, "EventDispatcher", "ProcessMessage", { 'eventID': eventID });
                widget.on(mappedEvent, bindedFunction);
                return true;
            }
            return false;
        }
        Utils.bindMenuItemToEvent = bindMenuItemToEvent;
        function getSendActionFunction(mainObj, controllerName, action, parameters) {
            var argArray = [];
            //the argument 0 is always the mainOBJ
            argArray.push(mainObj);
            argArray.push(controllerName);
            argArray.push(action);
            argArray.push(parameters);
            var bindedFunction = function (e) {
                return window.app.sendAction({ mainobj: arguments[0][0], controller: arguments[0][1], action: arguments[0][2], parameters: arguments[0][3] });
            }.bind(mainObj, argArray);
            return bindedFunction;
        }
        Utils.getSendActionFunction = getSendActionFunction;
        function getNameFromAlias(typeOfObj, alias) {
            var result = alias;
            var aliasCollection = window["defaultsInfo"][typeOfObj];
            if (aliasCollection && aliasCollection[alias]) {
                result = aliasCollection[alias][0];
            }
            return result;
        }
        Utils.getNameFromAlias = getNameFromAlias;
        function getTypeFromAlias(typeOfObj, alias) {
            var result = "0";
            var aliasCollection = window["defaultsInfo"][typeOfObj];
            if (aliasCollection && aliasCollection[alias]) {
                result = aliasCollection[alias][2];
            }
            return result;
        }
        Utils.getTypeFromAlias = getTypeFromAlias;
        function buildTopLevelObjectFromUniqueID(uniqueID) {
            var preparedID = prepareUniqueID(uniqueID);
            if (preparedID) {
                uniqueID = preparedID;
            }
            return uniqueID.split("#").reverse()[0];
        }
        function buildCurrentObjectFromUniqueID(uniqueID) {
            return uniqueID.split("#")[0];
        }
        //Summary: This method builds the full binding expression from the given uniqueID,
        //          we need this because sometimes the uniqueID comes as top level "KI" list item uniqueID.
        //Returns: The desired uniqueID with the parents resolved
        function prepareUniqueID(uniqueID, buildFullPath) {
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
            if (until == -1)
                until = uniqueID.length;
            substring = (from == 0) ? uniqueID : uniqueID.substring(from, until);
            var obj = window["$cache"][substring];
            var parentObject = GetListItemParent(obj);
            if (parentObject instanceof kendo.data.ObservableArray
                || (parentObject != null && parentObject.length != null && parentObject.length > 0)) {
                if (buildFullPath) {
                    result = parentObject.UniqueID;
                    if (result.indexOf(uniqueID) != -1)
                        return result;
                    return TransformShortUniqueIDToRealUniqueID(uniqueID) + "#" + prepareUniqueID(result, buildFullPath);
                }
                else {
                    result = buildPartialResult(parentObject, uniqueID, substring);
                    if (result != "") {
                        if (result.indexOf(uniqueID) != -1)
                            return result;
                        return prepareUniqueID(uniqueID.replace(substring, result), false);
                    }
                }
            }
        }
        Utils.prepareUniqueID = prepareUniqueID;
        //Summary: Transforms the shorten uniqueid to the real uniqueid
        function TransformShortUniqueIDToRealUniqueID(uniqueid) {
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
        function buildPartialResult(parentObject, uniqueID, substring) {
            var result = "";
            for (var i = 0; i < parentObject.length; i++) {
                var item = parentObject[i];
                if (item != null && item.UniqueID == substring) {
                    result = i + "#" + parentObject.UniqueID;
                    break;
                }
            }
            return result;
        }
        //Summary: This is the method that retrieves the parent.
        function GetListItemParent(obj) {
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
        function buildParentFromUniqueID(UniqueID) {
            var uniqueID = prepareUniqueID(UniqueID, true);
            var parts = uniqueID.split("#");
            parts.pop();
            return parts.reverse().join(".");
        }
        Utils.buildParentFromUniqueID = buildParentFromUniqueID;
        function GetControls(controls, callback) {
            var length = controls ? controls.Count : 0;
            for (var i = 0; i < length; i++) {
                if (controls[i]) {
                    if (typeof controls[i] === "function") {
                        controls[i] = controls[i]();
                    }
                    if (controls[i].UniqueID != "") {
                        if (typeof callback === "function") {
                            callback(controls[i]);
                        }
                    }
                }
            }
        }
        Utils.GetControls = GetControls;
        /**
        * Set the display to the element.
        * @param $element
        * @param visible
        * @returns {}
        */
        function SetVisible($element, visible) {
            if ($element && $element.length && visible != null && visible != undefined) {
                if (visible) {
                    $element[0].style.display = "";
                }
                else {
                    $element[0].style.display = "none";
                }
            }
        }
        Utils.SetVisible = SetVisible;
        function refreshChildrenWidgets(element) {
            var children = element.children();
            var widgetInstanceFunc = kendo.widgetInstance;
            for (var i = 0; i < children.length; i++) {
                var instance = widgetInstanceFunc($(children[i]));
                if (instance && instance.refresh)
                    instance.refresh();
            }
        }
        Utils.refreshChildrenWidgets = refreshChildrenWidgets;
        function isEventInWidgetEvents(widget, event) {
            var events = widget.events;
            return events.filter(function (currentEvent) { return event == currentEvent; }).length == 1;
        }
        Utils.isEventInWidgetEvents = isEventInWidgetEvents;
        function bindEventToModel(model, eventID, func) {
            func.WebMapFunction = true;
            if (!isEventBoundToModel(model, eventID, func)) {
                model.bind(eventID, func);
            }
        }
        Utils.bindEventToModel = bindEventToModel;
        function isEventBoundToModel(model, eventID, func) {
            var events = model._events[eventID];
            if (events) {
                return -1 !== $.inArray(func, events);
            }
            else {
                return false;
            }
        }
        Utils.isEventBoundToModel = isEventBoundToModel;
        function bindElementToModel(element, model, executeInmediatly) {
            try {
                //prepareUniqueID...Yes, we need the UniqueID of something that is not a KIxxx element.
                var UniqueID = WebMap.Utils.prepareUniqueID(model.UniqueID, false);
                var topModel = window["$cache"][UniqueID.split("#").pop()];
                //Let's remove only kendo change handlers.
                var widgetInstance = kendo.widgetInstance(element);
                if (widgetInstance) {
                    selectiveUnbind(model);
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
                    var bindingToRegister = "kendoBind@" + topModel.UniqueID;
                    if (window.app.Safe.pendingBindingInExecution
                        == bindingToRegister
                        || window.app.Safe.kendoBinds[topModel.UniqueID]) {
                        //Lets reset the current Hierarky history, to allow more binds.
                        delete window.app.Safe.executedBindings["kendoBind@" + topModel.UniqueID];
                        //Lets use the Full uniqueID in case the model is a List item(List items are top level objects)
                        //registerPendingBinding only uses the ID thats why this is valid.
                        var emptyModel = {};
                        //UniqueID complete? Well, in fact the UniqueID for a KIxxx is complete, but in order to represent the hierarky 
                        //correctly, it's better if we generate the ID in a way that shows the level of the Widget in the DOM.
                        emptyModel.UniqueID = WebMap.Utils.prepareUniqueID(model.UniqueID, true);
                        //Let's register the pending binding.
                        window.app.Safe.safeExec({
                            obj: emptyModel,
                            category: "kendoBind",
                            stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                            whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.QueueForLater,
                            action: function () {
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
                            action: function () {
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
                                if (ismaximized)
                                    kendowindow.maximize();
                                if (isminimized)
                                    kendowindow.minimize();
                                window.app.Safe.kendoBinds[topModel.UniqueID] = true;
                            }
                        });
                    }
                }
            }
            catch (ex) {
                console.log("Error binding Model");
            }
        }
        Utils.bindElementToModel = bindElementToModel;
        function selectiveUnbind(model) {
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
        Utils.selectiveUnbind = selectiveUnbind;
        function isParentExecuted(UniqueID) {
            var parent = WebMap.Client.UniqueIDGenerator.getParent(UniqueID);
            while (parent != null) {
                if (window.app.Safe.executedBindings["kendoBind@" + parent])
                    return true;
                parent = WebMap.Client.UniqueIDGenerator.getParent(parent);
            }
            return false;
        }
        Utils.isParentExecuted = isParentExecuted;
        function getWidgetFromSelector(selector) {
            var element = $(selector);
            if (element.length > 0) {
                return kendo.widgetInstance(element, undefined);
            }
        }
        Utils.getWidgetFromSelector = getWidgetFromSelector;
        var DynamicContainer = (function () {
            function DynamicContainer() {
            }
            //Handle pointer cases, when the property is a function
            //If the control is not undefined then load it. 
            //We mark it inside controlsInPanel to avoid loading if if not necessary during the refresh call
            DynamicContainer.applyTemplate = function (view, Controls, useTag) {
                var controls = [];
                var lastcontrolsIDs = [];
                WebMap.Utils.GetControls(Controls, function (control) {
                    if (useTag) {
                        var ctrl = (typeof control.Tag === "function") ? control.Tag() : control.Tag;
                        controls.push(ctrl);
                    }
                    else {
                        controls.push(control);
                    }
                });
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
            };
            DynamicContainer.applyRowColumnProperties = function (tableinfo) {
                var tableInfoString = "";
                if (tableinfo.Row != null && tableinfo.Column != null && tableinfo.Row != -1 && tableinfo.Column != -1) {
                    tableInfoString = "row='" + tableinfo.Row + "' column='" + tableinfo.Column + "'";
                    if (tableinfo.RowSpan != null && tableinfo.RowSpan != -1)
                        tableInfoString += " rowspan='" + tableinfo.RowSpan + "'";
                    if (tableinfo.ColumnSpan != null && tableinfo.ColumnSpan != -1)
                        tableInfoString += " colspan='" + tableinfo.ColumnSpan + "'";
                }
                return tableInfoString;
            };
            DynamicContainer.loadHTML = function (control, element, panelName, index, tableinfo) {
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
            ;
            DynamicContainer.getIdToHtmlFromUserControl = function (control) {
                var useTag = (control.Tag && (typeof (control.Tag) == "string")) ? true : false; /// Backward compatibility validation
                var uid = useTag ? control.Tag : window.app.getControlRole(control); /// Backward compatibility validation
                var identifier = control.uid;
                var alias = control.Name ? control.Name : uid;
                return { uid: uid, identifier: identifier, alias: alias };
            };
            DynamicContainer.applyTemplateForGroup = function (view) {
                var controls = [];
                if (view.Controls) {
                    for (var i = 0; i < view.Controls.length; i++) {
                        if (view.Controls[i] && view.Controls[i].UniqueID != "")
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
            };
            return DynamicContainer;
        }());
        Utils.DynamicContainer = DynamicContainer;
    })(Utils = WebMap.Utils || (WebMap.Utils = {}));
})(WebMap || (WebMap = {}));
// Module
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        // IIocContainer implementation that does use of kendo objects to keep track of the
        // state of the elements it creates.
        var Container = (function () {
            function Container() {
            }
            // Initializes the singleton instance
            Container.Init = function () {
                if (!Container.Current) {
                    Container.Current = new Container();
                }
            };
            // Returns a empty object of a certain type,
            //this allow us to avoid sending the Default Values.
            Container.prototype.GetEmptyObject = function (typeOfObj) {
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
            };
            Container.prototype.cloneObject = function (obj) {
                if (obj === null) {
                    return obj;
                }
                var temp = obj.constructor(); // give temp the original obj's constructor
                for (var key in obj) {
                    temp[key] = obj[key];
                }
                return temp;
            };
            // Creates a new object according to the given options.  Standard calls are:
            // 1. Resolve({ vm: true, data: <JSON object>, dirty: false }).  Creates a new view model object with the 
            // given JSON data and marks it as not diry.
            // 2. Resolve({ "cons": constructor lambda) }).  Creates a new object usign the given lambda to create it.
            Container.prototype.Resolve = function (options) {
                if (options) {
                    if (options.vm) {
                        var observable;
                        if (options.data['@arr']) {
                            observable = new kendo.data.ObservableArray(options.data);
                            observable.Count = options.data.Count;
                            observable.UniqueID = options.data.UniqueID;
                            observable.uids = options.data.uids;
                            observable.ltype = options.data.ltype;
                        }
                        else {
                            observable = this.GetKendoObservableFor(options.data);
                        }
                        // the new view model objects defaults to not dirty, however its initial value can be changed by 
                        // using the dirty flag.
                        var dirty = false;
                        if (options.dirty != undefined)
                            dirty = options.dirty;
                        // adds the new object to cache
                        Client.StateManager.Current.addNewObject(observable, dirty);
                        return observable;
                    }
                    // Creates the object from the given constructor
                    if (options.cons) {
                        return new options.cons();
                    }
                }
                return null;
            };
            ///Retrieves a kendoObservable Object given a IStateObject model.
            Container.prototype.GetKendoObservableFor = function (model) {
                var object = model;
                //Gets an empty object for a type.(With the default values set.)
                var emptyObj = this.GetEmptyObject(object["@k"]);
                var observable;
                if (emptyObj) {
                    //Empty objects are stored for type, so that we need a ligth clone of it.
                    var result = this.cloneObject(emptyObj);
                    //Object properties from the model, are excluded.
                    // and stored to set them later.
                    observable = new WebMap.Client.MobilizeObservableObject(result);
                    observable.merge(model);
                }
                else {
                    observable = new WebMap.Client.MobilizeObservableObject(object);
                }
                return observable;
            };
            return Container;
        }());
        Client.Container = Container;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="kendo.all.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        // DataBinding: stores a list of Bindings and provides common operations
        var DataBinding = (function () {
            function DataBinding() {
                this.bindings = new Array();
            }
            DataBinding.prototype.addBinding = function (propertyName, dataSource, memberName) {
                var newBinding = new Binding();
                newBinding.propertyName = propertyName;
                newBinding.dataSource = dataSource;
                newBinding.memberName = memberName;
                this.bindings.push(newBinding);
            };
            return DataBinding;
        }());
        var Binding = (function () {
            function Binding() {
            }
            return Binding;
        }());
        // DataSource: stores a "RecordSet" with the common operations
        var DataSource = (function () {
            function DataSource() {
                this.data = new Array();
                this.index = 0;
                this.page = 1;
            }
            DataSource.prototype.loadData = function (rsJSON) {
                //This function is not working as expected
                // the rsJSON is not being used, the array is for output
                // It was corrected to properly compile in TS 1.8
                var dataRows = new Array();
                for (var i = 0; i < dataRows.length; i++) {
                    var row = dataRows[i];
                    var dataRow = new DataRow();
                    var dataCells = new Array();
                    var currentrow = row;
                    for (var cell in currentrow) {
                        var dataCell = new DataCell();
                        // TODO: review
                        dataCell.propertyName = cell;
                        dataCell.value = row[cell];
                        dataCells.push(dataCell);
                    }
                    dataRow.cells = dataCells;
                    dataRows.push(dataRow);
                }
                this.data = dataRows;
            };
            DataSource.prototype.refresh = function () {
                //TODO
            };
            DataSource.prototype.update = function () {
                //TODO
            };
            return DataSource;
        }());
        var DataRow = (function () {
            function DataRow() {
            }
            return DataRow;
        }());
        var DataCell = (function () {
            function DataCell() {
            }
            return DataCell;
        }());
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="WebMap_Interfaces.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        (function (SafeExecutionConditions) {
            SafeExecutionConditions[SafeExecutionConditions["Ignore"] = 1] = "Ignore";
            SafeExecutionConditions[SafeExecutionConditions["QueueForLater"] = 2] = "QueueForLater";
        })(Client.SafeExecutionConditions || (Client.SafeExecutionConditions = {}));
        var SafeExecutionConditions = Client.SafeExecutionConditions;
        (function (ClientSyncronizationStage) {
            ClientSyncronizationStage[ClientSyncronizationStage["NotUpdatingClientSideYet"] = 2] = "NotUpdatingClientSideYet";
            ClientSyncronizationStage[ClientSyncronizationStage["CurrentlyUpdatingClientSide"] = 4] = "CurrentlyUpdatingClientSide";
            ClientSyncronizationStage[ClientSyncronizationStage["UpdateClientSideAlmostComplete"] = 8] = "UpdateClientSideAlmostComplete";
            ClientSyncronizationStage[ClientSyncronizationStage["SendActionTriggered"] = 16] = "SendActionTriggered";
        })(Client.ClientSyncronizationStage || (Client.ClientSyncronizationStage = {}));
        var ClientSyncronizationStage = Client.ClientSyncronizationStage;
        var SafeActionExecutionManager = (function () {
            function SafeActionExecutionManager(app) {
                this.pendingBindings = {};
                this.executedBindings = {};
                this.kendoBinds = {};
                this.pendingSendActionCallBacks = [];
                // updateClientSideState is a flag that shows when the Application is processing the UpdateClientSide method.
                // 0 means 'Not updating client side yet'
                // 1 means 'Currently updating client side'
                // 2 means 'Update Client side completed'
                // Example code: 
                // if (window.app.updateClientSideState < 2) {
                //		window.app.registerPendingBinding(that._value, doSomeThing)
                // else doSomeThing()
                this.updateClientSideState = ClientSyncronizationStage.NotUpdatingClientSideYet;
                this.app = app;
            }
            SafeActionExecutionManager.prototype.safeExec = function (args) {
                //Are we in the requested stage?
                if ((this.updateClientSideState & args.stage) != 0) {
                    args.action();
                }
                else {
                    if (args.whenNotAtThatStage === SafeExecutionConditions.QueueForLater)
                        this.registerPendingBinding(args.obj, args.action, args.category);
                }
            };
            SafeActionExecutionManager.prototype.Async = function (action) {
                action();
                return this.getSendActionPromise();
            };
            SafeActionExecutionManager.prototype.getSendActionPromise = function () {
                return window.app.sendActionPromise;
            };
            //public execWhenIsSynchronizingClient(obj: IStateObject, action: () => void, queueForLater = true) {
            //    var actionIfNotInStage = queueForLater ? SafeExecutionConditions.QueueForLater : SafeExecutionConditions.Ignore;
            //    this.safeExec(
            //        {
            //            stage: ClientSyncronizationStage.CurrentlyUpdatingClientSide | ClientSyncronizationStage.UpdateClientSideAlmostComplete,
            //            obj: obj,
            //            action: action,
            //            whenNotAtThatStage: actionIfNotInStage,
            //            category: "requestAction"
            //        });
            //}
            /**
            * registers ONE pending action associated to an IStateObject
            */
            SafeActionExecutionManager.prototype.registerPendingBinding = function (obj, func, category) {
                if (category === void 0) { category = undefined; }
                //kesanchez:The binding registered should not be the same as the one in execution, 
                //otherwise we could have infinite loops.
                if (obj && obj.UniqueID) {
                    var pendingID = obj.UniqueID;
                    if (category) {
                        pendingID = category + "@" + pendingID;
                    }
                    if (this.pendingBindingInExecution != pendingID) {
                        this.pendingBindings[pendingID] = func;
                    }
                }
            };
            SafeActionExecutionManager.prototype.executePendingBindings = function () {
                this.executedBindings = {};
                var topBindings = this.pendingBindings;
                var bindKeys = Object.getOwnPropertyNames(topBindings);
                bindKeys = bindKeys.sort(function (a, b) {
                    //ASC  -> a.length - b.length
                    //DESC -> b.length - a.length
                    return a.length - b.length;
                });
                while (bindKeys.length != 0) {
                    try {
                        window.app.log("Executing pending binding for " + bindKeys[0]);
                        //Extract first key value pair
                        var key = bindKeys[0];
                        var func = topBindings[key];
                        //remove key
                        delete topBindings[key];
                        if (func) {
                            try {
                                //Block key from re-insertion
                                this.pendingBindingInExecution = key;
                                this.executedBindings[key] = true;
                                //execute action
                                func();
                            }
                            finally {
                                //UnBlock key
                                this.pendingBindingInExecution = null;
                            }
                        }
                        //Get keys agains because the object might have changed during action execution
                        bindKeys = Object.getOwnPropertyNames(topBindings);
                    }
                    catch (appPendingBinds) {
                        console.error("App::postOrganizeModels error on pending binding" + appPendingBinds);
                    }
                }
                this.pendingBindings = {};
                this.kendoBinds = {};
            };
            return SafeActionExecutionManager;
        }());
        Client.SafeActionExecutionManager = SafeActionExecutionManager;
        /**
          * This class represents a WebMap client side application, it is responsible for starting up the application and
          * manage the communication with de server side of a WebMap application
          */
        var App = (function () {
            function App() {
                this.pendingUnBindedEx = [];
                this.pendingUnBindedExDictonary = {};
                this.Safe = new SafeActionExecutionManager(this);
            }
            App.prototype.executeUnBindedEx = function (array, lambda) {
                var oldChangeEventHandlers = array._events.change || [];
                var length = this.pendingUnBindedEx.push({
                    array: array, events: oldChangeEventHandlers
                });
                this.pendingUnBindedExDictonary[array.UniqueID] = length - 1;
                //Now we unbind the event handler
                array._events.change = [];
                lambda(array);
            };
            App.prototype.info = function (text) {
                //console.info(text);
            };
            App.prototype.log = function (text) {
                //console.log(text);
            };
            /**
             *Static constructor that creates singleton objects
             */
            App.Init = function () {
                if (!App.Current) {
                    App.Current = new App();
                    App.Current.ViewManager = new Client.ViewManager();
                }
                window.app = WebMap.Client.App.Current;
                //At the app Start we need to have a resolved promise so code does not get queued
                var deferred = $.Deferred();
                deferred.resolve();
                window.app.sendActionPromise = deferred.promise();
            };
            App.Start = function (customClientTypeRegistrations) {
                if (!window["app"]) {
                    WebMap.Client.App.Init();
                }
                var settings = { url: "TypeInfo/GetAll", type: "POST" };
                WebMap.Client.App.Current.doBlockUI(0);
                try {
                    $.ajax(settings).done(function (data) {
                        window["typesInfo"] = data.TypesInfo;
                        window["defaultsInfo"] = data.DefaultsAndAlias;
                        window["emptyObjs"] = {};
                        WebMap.Client.App.Current.undoBlockUI();
                        //Get current app state from server
                        customClientTypeRegistrations && customClientTypeRegistrations(window["app"]);
                        try {
                            $.ajax({
                                url: "Home/AppState",
                                success: function (data) {
                                    var state = data;
                                    //Setup state
                                    window["app"].Init(state.MD, state.VD, state.MDT);
                                    WebMap.Client.App.Current.undoBlockUI();
                                }
                            });
                        }
                        catch (startException1) {
                            console.error("Start Exception -- " + startException1);
                            WebMap.Client.App.Current.undoBlockUI();
                        }
                    });
                }
                catch (startException) {
                    console.error("Start Exception -- " + startException);
                    WebMap.Client.App.Current.undoBlockUI();
                }
            };
            App.prototype.getControlRole = function (control) {
                var controlType;
                if (control && control["@k"])
                    controlType = window["typesInfo"][control["@k"]];
                if (!controlType)
                    return "rolenotfound";
                switch (controlType.toLowerCase()) {
                    case "upgradehelpers_basicviewmodels_webbrowserviewmodel":
                        controlType = "browser";
                        break;
                    case "upgradehelpers_basicviewmodels_radiobuttonviewmodel":
                        controlType = "radio";
                        break;
                    case "upgradehelpers_basicviewmodels_panelviewmodel":
                        controlType = "panel";
                        break;
                    case "allscripts_touchworks_note_controls_twtextmacrotextbox":
                        controlType = "textbox";
                        break;
                    case "upgradehelpers_basicviewmodels_ultrapanelviewmodel":
                        controlType = "ultrapanel";
                        break;
                    case "upgradehelpers_basicviewmodels_pictureboxviewmodel":
                    case "upgradehelpers_basicviewmodels_ultrapictureboxviewmodel":
                        controlType = "picturebox";
                        break;
                    case "upgradehelpers_basicviewmodels_labelviewmodel":
                        controlType = "label";
                        break;
                    default:
                        controlType = controlType.toLowerCase();
                        break;
                }
                return controlType;
            };
            App.prototype.getControlType = function (typeTag) {
                var controlType = window["typesInfo"][typeTag];
                return (controlType || "typenotfound");
            };
            App.prototype.getControlTypeID = function (typeName) {
                var types = window["typesInfo"];
                var keys = Object.getOwnPropertyNames(types);
                for (var i = 0; i < keys.length; i++) {
                    var key = keys[i];
                    if (types[key] == typeName) {
                        return parseInt(key);
                    }
                }
                return -1;
            };
            /**
             *Inits the WebMap application before the first screen is rendered.  This method must be invoked from
             * the main html page just before any other action is performed.
             */
            App.prototype.Init = function (models, viewsState, modelTypes) {
                var _this = this;
                Client.Container.Init();
                Client.StateManager.Init();
                //Calc any dependency files
                var requirements = [];
                for (var i = 0; i < modelTypes.length; i++) {
                    if (modelTypes[i] % 10 == 0) {
                        var dependency = "usercontrols/" + window.app.getControlType(modelTypes[i]);
                        if (dependency.indexOf("UpgradeHelpers") == -1 && dependency.indexOf("typenotfound") == -1 && !requirejs.defined(dependency)) {
                            requirements.push(dependency);
                        }
                    }
                }
                require(requirements, function () {
                    _this.InitModels(models, modelTypes);
                    _this.InitUI(viewsState);
                    _this.eventsQueue = new Array();
                    Client.StateManager.Current.clearDirty();
                }, function (err) {
                    console.error("Error loading requirement: " + err.requireModules + " the application might not work. Loading dummy module");
                    var currentModule = err.requireModules[0];
                    if (currentModule) {
                        require.undef(currentModule);
                        define(currentModule, [], function () { });
                        require([currentModule], function () { window.app.info("Loading dummy module for " + currentModule); });
                    }
                });
            };
            /**
             * Adds a listener to be called to update the model data
             */
            App.prototype.addModelUpdateListener = function (l) {
                if (l) {
                    if (!this.updateListeners)
                        this.updateListeners = [l];
                    else
                        this.updateListeners.push(l);
                }
            };
            /**
             * Removes the given listener
             */
            App.prototype.removeModelUpdateListener = function (l) {
                var ul = this.updateListeners;
                if (ul) {
                    var idx = ul.indexOf(l);
                    if (idx >= 0)
                        ul.splice(idx, 1);
                }
            };
            /**
             * Calls the registered listeners in order to update the model data
             */
            App.prototype.callModelUpdateListeners = function () {
                var ul = this.updateListeners;
                if (ul) {
                    for (var i = 0, len = ul.length; i < len; i++)
                        ul[i]();
                }
            };
            /**
            *  Sends a request to the WebMap server side application.  After call is made, the method updates the
            * WebMap client side app in order to refresh all changes performed by server side logic, to achieve that the
            * updateClientSide and UpdateMessages methods are called.
             */
            App.prototype.sendAction = function (options, forced) {
                if (forced === void 0) { forced = false; }
                var inExecution = this.inActionExecution;
                var that = this;
                var url = this.buildActionUrl(options);
                var actionParamStr = this.buildJSONRequest(options);
                if (inExecution) {
                    // Here we are queuing processing
                    var emptyPromess = $.Deferred();
                    var data = [url, actionParamStr, emptyPromess];
                    this.eventsQueue.push(data);
                    //Set sendAction promise to the last element to the queue
                    this.sendActionPromise = emptyPromess.promise();
                }
                else {
                    this.inActionExecution = true;
                    this.Safe.updateClientSideState = ClientSyncronizationStage.SendActionTriggered;
                    this.callModelUpdateListeners();
                    var promise = this.doServerCall(this, url, actionParamStr, forced, null);
                    this.sendActionPromise = promise;
                    return promise;
                }
            };
            App.prototype.doBlockUI = function (time) {
                $.blockUI();
            };
            App.prototype.undoBlockUI = function () {
                $.unblockUI();
            };
            App.prototype.doServerCall = function (that, url, actionParamStr, forced, promise) {
                var _this = this;
                that.inActionExecution = true;
                that.actionInExecution = url;
                var deffered;
                var n1 = window.performance.now();
                if (promise != null)
                    deffered = promise;
                else
                    deffered = $.Deferred();
                $.ajax({
                    url: url,
                    type: "POST",
                    headers: {
                        WM: true
                    },
                    dataType: "json",
                    data: actionParamStr,
                    beforeSend: function () {
                        if (!forced)
                            window.timeoutForActions = that.doBlockUI(1500);
                    },
                    complete: function (jqXHR, textStatus) {
                        var n2 = window.performance.now();
                        var d = n2 - n1;
                        that.servier = d;
                        if (window.timeoutForActions) {
                            clearTimeout(window.timeoutForActions);
                        }
                        _this.undoBlockUI();
                    },
                    success: function (data, textStatus, jqXHR) {
                        //Error reported!
                        if (data.ErrorOcurred) {
                            Client.MessageBoxCommandHandler.showGenericMessage(data.ExMessage + "<pre>" + data.ExStackTrace + "<pre\>");
                            _this.inActionExecution = false;
                            that.undoBlockUI();
                            return false;
                        }
                        //Timeout ocurred
                        if (data.SessionTimeOut) {
                            if (window.timeoutForActions) {
                                clearTimeout(window.timeoutForActions);
                            }
                            _this.inActionExecution = false;
                            _this.undoBlockUI();
                            Client.MessageBoxCommandHandler.showSessionExpiredMessage();
                            return;
                        }
                        if (that.checkFlag(data, "SessionTimeOut")) {
                        }
                        else if (that.checkFlag(data, "DoLogoff")) {
                        }
                        else if (that.checkFlag(data, "CloseApp")) {
                            window.close();
                        }
                        else {
                            _this.Safe.updateClientSideState = ClientSyncronizationStage.CurrentlyUpdatingClientSide;
                            var requirements = [];
                            for (var i = 0; i < data.MDT.length; i++) {
                                if (data.MDT[i] % 10 == 0) {
                                    var dependency = "usercontrols/" + window.app.getControlType(data.MDT[i]);
                                    if (dependency.indexOf("UpgradeHelpers") == -1 && dependency.indexOf("typenotfound") == -1 && !requirejs.defined(dependency)) {
                                        requirements.push(dependency);
                                    }
                                }
                            }
                            window.app.log("Loading dependencies [" + requirements + "]");
                            require(requirements, function () {
                                try {
                                    that.updateClientSide(data, deffered, n1);
                                    deffered.done(function () {
                                        if (data) {
                                            that.dispatchCommands(data.VD);
                                        }
                                    });
                                }
                                catch (updateClientSideEx) {
                                    console.error("App::doServerCall during sucess callback for updating client side. Error " + updateClientSideEx);
                                    that.Safe.updateClientSideState = ClientSyncronizationStage.NotUpdatingClientSideYet;
                                    Client.StateManager.Current.clearDirty();
                                }
                            }, function (err) {
                                console.error("Error loading requirement: " + err.requireModules + " the application might not work. Loading dummy module");
                                var currentModule = err.requireModules[0];
                                require.undef(currentModule);
                                define(currentModule, [], function () { });
                                require([currentModule], function () { window.app.info("Loading dummy module for " + currentModule); });
                            });
                        }
                        return false;
                    },
                    error: function (a, b, c) {
                        that.inActionExecution = false;
                        that.undoBlockUI();
                        return false;
                    },
                    contentType: 'application/json; charset=utf-8'
                });
                return deffered.promise();
            };
            /**
             * updates the given model object with the information stored in delta.
             */
            App.prototype.applyDelta = function (model, delta) {
                //We must verify that model is an ObservableObject
                if (model.set) {
                    for (var prop in delta) {
                        if (prop == "@k")
                            continue;
                        /*if ((prop in model) && (<any>model).set) {*/
                        try {
                            model.set(prop, delta[prop]);
                        }
                        catch (applyDeltaExceptionInner) {
                            console.error("App::applyDelta Error trying to set property for object UniqueId: " + model.UniqueID + " Property " + prop + " Message " + applyDeltaExceptionInner);
                        }
                    }
                }
            };
            /**
             * Builds an url action request based in the values gieven in options.
             */
            App.prototype.buildActionUrl = function (options) {
                var path1 = location.pathname;
                var path2 = options.controller || "Home";
                if (options.mainobj !== undefined && options.mainobj["area"]) {
                    path2 = options.mainobj["area"] + "/" + path2;
                }
                if (path1.length > 1 && path1.substring(path1.length - 1) != '/') {
                    path1 = path1 + "/";
                }
                if (path2.length > 1 && path2[0] === '/') {
                    path2 = path2.substring(1);
                }
                options.action = options.action;
                var url = path1 + path2 + "/" + options.action + "/";
                return url;
            };
            /**
             * Builds a JSON request based in the values given in options
             */
            App.prototype.buildJSONRequest = function (options) {
                var request = {
                    dirty: Client.StateManager.Current.getDirty(),
                    vm: options && options.mainobj && options.mainobj.UniqueID
                };
                if (options.dialogResult) {
                    request.dialogResult = options.dialogResult;
                }
                App.Current.ViewManager.PrepareDelta(request);
                //Parameters are merged with the request object
                //We need to process parameters. If a parameter is an state object we will just send the UniqueID something like { UniqueID : uniqueIDvalue }
                if (options.parameters) {
                    var parametersNames = Object.getOwnPropertyNames(options.parameters);
                    for (var p = 0; p < parametersNames.length; p++) {
                        var parameterName = parametersNames[p];
                        var parameterValue = options.parameters[parameterName];
                        if (parameterValue && parameterValue.UniqueID) {
                            options.parameters[parameterName] = { UniqueID: parameterValue.UniqueID };
                        }
                    }
                }
                $.extend(request, options.parameters);
                var cache = [];
                var res = JSON.stringify(request, function (key, value) {
                    if (typeof value === 'object' && value !== null) {
                        if (cache.indexOf(value) !== -1) {
                            // Circular reference found, discard key
                            return;
                        }
                        // Store value in our collection
                        cache.push(value);
                    }
                    return value;
                });
                cache = null; // Enable garbage collection
                return res;
            };
            App.prototype.checkFlag = function (data, flagName) {
                return false;
            };
            /**
              * When models are received, it might be needed to transverse those collections
              * to collect some information or to modify some aspects of the JSON message
              * to do that Client Type Behaviors can be associated to JSON packages, based on their
              * client type mark. Examples are Collections processing and StateObjectReferences
              */
            App.prototype.preOrganizeModels = function (models, modelTypes) {
                for (var i = 0; i < models.length; i++) {
                    var model = models[i];
                    var typeBehaviourHandler = Client.ClientTypeBehaviourManager.Current.getBehaviour(model);
                    if (typeBehaviourHandler) {
                        models[i] = typeBehaviourHandler.preOrganizeAction(model);
                    }
                }
            };
            /**
             *  Execs any actions registered during the preOrganizeModel phase
             */
            App.prototype.postOrganizeModels = function () {
                //Pointers and others pending actions
                Client.ClientTypeBehaviourManager.Current.execPostOrganizeActions();
            };
            App.prototype.bindPendingEventsForWidgetItems = function (isContextMenu, alwaysBind) {
                if (isContextMenu === void 0) { isContextMenu = false; }
                if (alwaysBind === void 0) { alwaysBind = false; }
                var dynamicEventsBehaviourManager = Client.ClientTypeBehaviourManager.Current.getBehaviourByID(5);
                dynamicEventsBehaviourManager.bindEventsForPendingItems(isContextMenu, alwaysBind);
            };
            App.prototype.executePendingSendActions = function () {
                if (window.timeoutForActions) {
                    clearTimeout(window.timeoutForActions);
                }
                if (this.eventsQueue.length > 0) {
                    //(<any>window).timeoutForActions = this.doBlockUI(1500);
                    var opts = this.eventsQueue.shift();
                    this.doServerCall(this, opts[0], opts[1], true, opts[2]);
                }
                else {
                    this.inActionExecution = false;
                }
            };
            /**
            *  models and modelTypes are supposed to be arrays of the same length
            *  there for each i-th entry in models there is an i-th entry in modelTypes that has
            *  the model associated type id
            *  if modelTypes is
            */
            App.prototype.associateModelTypes = function (models, modelTypes) {
                if (modelTypes && modelTypes.length) {
                    for (var i = 0; i < modelTypes.length; i++) {
                        var model = models[i];
                        var modelType = modelTypes[i];
                        if (model && modelType && !model["@k"] /* we should not set model type if the model already has one*/) {
                            model["@k"] = modelType;
                        }
                    }
                }
            };
            /**
              *  Creates the IViewModel objects for every model object in "models".  Models is an array of json data sent from the
              *  server side, where every element contains a set of property/value describing the view model object.
              */
            App.prototype.InitModels = function (models, modelTypes) {
                if (modelTypes === void 0) { modelTypes = undefined; }
                this.Safe.updateClientSideState = ClientSyncronizationStage.CurrentlyUpdatingClientSide;
                try {
                    this.associateModelTypes(models, modelTypes);
                    //Execute Preorganize actions
                    this.preOrganizeModels(models, modelTypes);
                    var controlArrays = [];
                    for (var i = 0; i < models.length; i++) {
                        var current = models[i];
                        if (!current)
                            continue; //Skip undefineds
                        var vm = Client.Container.Current.Resolve({ vm: true, data: current, dirty: false });
                        if (vm instanceof kendo.data.ObservableArray)
                            controlArrays.push({ controlArray: vm, delta: vm });
                        if (vm.Name && vm.Name.indexOf("UserControl") == 0) {
                            var logic = vm["logic"] = Client.Container.Current.Resolve({ "cons": App.Current.ViewManager.getConstructor(vm) });
                            logic.ViewModel = vm;
                        }
                    }
                    this.WakeUpArrayElements(controlArrays);
                    var options = {};
                    options.cache = models;
                    //Child models must be connected to entry in the cache
                    Client.StateManager.Current.organize(options);
                    this.FinishWakeUpArrayElements();
                    this.postOrganizeModels();
                }
                catch (initModelEx) {
                    console.error("InitModel error " + initModelEx);
                }
                finally {
                    this.Safe.updateClientSideState = ClientSyncronizationStage.NotUpdatingClientSideYet;
                }
            };
            /**
              *  Initializes the UI object for the first time.  This method must be called when the user first access the
              *  WebMap app and it is responsible for creating the first loaded windows (main window and/or login screen probably!).
              *  This method must be called after InitModels method because it requires view model to be already set.
              *  viewState :  Json object sent from server side containing the information of loaded views.
              */
            App.prototype.InitUI = function (viewState) {
                var _this = this;
                var that = this;
                this.showLoadingSplash();
                var def = $.Deferred();
                var modalViews = viewState.ModalViews;
                //All view navigation are promises. If there are several views
                //we must collect all promises and wait for all of them to finish
                var viewNavigationPromises = [];
                //Are there any views?
                if (viewState.LoadedViews) {
                    for (var i = 0; i < viewState.LoadedViews.length; i++) {
                        var current = viewState.LoadedViews[i];
                        // gets the matching view model object from the state cache and then navigates to the view.
                        var viewModel = Client.StateManager.Current.getObject(current.UniqueID);
                        if (!viewModel) {
                            console.error("FATAL ERROR: View model is null");
                        }
                        else {
                            window.app.log("Init promess from InitUI for" + viewModel.Name);
                            var isModal = modalViews.indexOf(viewModel.UniqueID) > -1;
                            viewNavigationPromises.push(that.ViewManager.NavigateToView(viewModel, isModal));
                        }
                    }
                }
                $.when.apply(this, viewNavigationPromises).then(function () { that.removeLoadingSplash(); }).then(function () {
                    _this.dispatchCommands(viewState);
                });
                return def.promise();
            };
            /**
             * removes the blocking UI message
             */
            App.prototype.removeLoadingSplash = function () {
                this.undoBlockUI();
            };
            /** shows a blocking UI message */
            App.prototype.showLoadingSplash = function () {
                $.blockUI({ message: "Loading app views" });
            };
            /** Updates the interaction messages sent from the server side in order to show them to the
            end user */
            App.prototype.dispatchCommands = function (viewData) {
                if (viewData && viewData.Commands) {
                    Client.CommandHandlerManager.Current.dispatchAll(viewData.Commands);
                }
                return null;
            };
            App.prototype.FinishWakeUpArrayElements = function () {
                for (var i = 0; i < this.pendingUnBindedEx.length; i++) {
                    var item = this.pendingUnBindedEx[i];
                    var array = item.array;
                    var events = item.events;
                    array._events.change = array._events.change.concat(events);
                    try {
                        array.trigger("change");
                    }
                    catch (ex) {
                    }
                }
            };
            App.prototype.WakeUpArrayElements = function (controlArrays) {
                this.pendingUnBindedEx = [];
                for (var i = 0; i < controlArrays.length; i++) {
                    var curr = controlArrays[i];
                    var oldChangeEventHandlers = curr.controlArray._events.change || [];
                    this.pendingUnBindedEx.push({
                        array: curr.controlArray, events: oldChangeEventHandlers
                    });
                    curr.controlArray._events.change = [];
                    //We are removing the old elements, because every time that the list changes its elements, 
                    //the server will send the whole list again
                    if (curr.controlArray.uids) {
                        for (var k = 0; k < curr.controlArray.uids.length; k++) {
                            if (curr.controlArray.ltype == 1 /* Value Types*/) {
                                curr.controlArray.length = 0; // clearing the array.
                            }
                            else {
                                if (curr.controlArray.uids[k] && !curr.controlArray[curr.controlArray.uids[k]])
                                    break;
                                curr.controlArray[curr.controlArray.uids[k]] = null;
                                delete curr.controlArray[curr.controlArray.uids[k]];
                                curr.controlArray.pop();
                            }
                        }
                        curr.controlArray.uids = curr.delta.uids;
                    }
                    var uidarray = curr.delta.uids;
                    var listtype = curr.delta.ltype;
                    for (var innerIndex = 0; innerIndex < uidarray.length; innerIndex++) {
                        if (listtype == 1 /* Value Type */)
                            curr.controlArray.push(uidarray[innerIndex]);
                        else if (listtype == 4 /* Object Type*/) {
                            var uid = uidarray[innerIndex].toString();
                            var value = Client.StateManager.Current.getObjectLocal(uid);
                            if (value) {
                                // If the value is an IStateObject
                                this.InsertIStateObjectIntoTheArray(curr.controlArray, value, uid);
                            }
                            else
                                curr.controlArray.push(uidarray[innerIndex]);
                        }
                        else {
                            if (uidarray[innerIndex]) {
                                var uid = uidarray[innerIndex].toString();
                                var value = Client.StateManager.Current.getObjectLocal(uid);
                                if (value) {
                                    this.InsertIStateObjectIntoTheArray(curr.controlArray, value, uid);
                                }
                                else
                                    curr.controlArray.push({ UniqueID: "" });
                            }
                            else
                                curr.controlArray.push({ UniqueID: "" });
                        }
                    }
                    curr.controlArray.Count = curr.delta.Count;
                }
            };
            App.prototype.InsertIStateObjectIntoTheArray = function (array, value, uid) {
                if (value instanceof kendo.data.ObservableArray) {
                    //If the value is an array, this means that we are having list of lists.
                    //When we evaluates value.parent(), kendo will return undefined,
                    //so we need to set a parent for this value,
                    //because in the BuildParentFromUniqueID depends on the parent
                    //of each item of the list in order to build the binding expression.
                    value["__parent"] = array;
                }
                array.push(value);
                array[uid] = value;
                if (value) {
                    if (!value[Client.UniqueIDGenerator.ReferencesIdentifier])
                        value[Client.UniqueIDGenerator.ReferencesIdentifier] = [];
                    value[Client.UniqueIDGenerator.ReferencesIdentifier].push(array.UniqueID);
                }
            };
            App.prototype.getDeltaWithId = function (uniqueID, deltaData) {
                var result = undefined;
                if (deltaData !== undefined) {
                    for (var i = 0; i < deltaData.length; i++) {
                        if (deltaData[i].UniqueID === uniqueID) {
                            result = kendo.observable(deltaData[i].Delta);
                            break;
                        }
                    }
                }
                if (!result) {
                    window.app.log('Not found:' + uniqueID);
                    result = {
                        UniqueID: uniqueID
                    };
                }
                return result;
            };
            App.prototype.processRemovedIds = function (data) {
                if (data.length) {
                    for (var i = 0; i < data.length; i++) {
                        var id = data[i];
                        if (id in Client.StateManager.Current._cache) {
                            Client.StateManager.Current.removeReferences(id);
                            delete Client.StateManager.Current._cache[id];
                        }
                    }
                }
            };
            App.prototype.processSwitchedIds = function (data, deltaData) {
                var collectionsToCheck = {};
                // the assumed format for 'data' is [ [id1_1,id1_2], [id2_1,id2_2] ... ]
                for (var i = 0; i < data.length; i++) {
                    var pair = data[i];
                    if (pair.length === 2) {
                        var id1 = pair[0];
                        var id2 = pair[1];
                        var id1Parts = id1.split(Client.UniqueIDGenerator.UniqueIdSeparator);
                        var index1 = id1Parts.shift();
                        var id2Parts = id2.split(Client.UniqueIDGenerator.UniqueIdSeparator);
                        var index2 = id2Parts.shift();
                        //if (id1Parts.shift() == "_items" && id2Parts.shift() == "_items") {
                        var list1Id = id1Parts.join(Client.UniqueIDGenerator.UniqueIdSeparator);
                        var list2Id = id2Parts.join(Client.UniqueIDGenerator.UniqueIdSeparator);
                        // locate the collections
                        var collection1 = Client.StateManager.Current.getObjectLocal(list1Id);
                        var collection2 = Client.StateManager.Current.getObjectLocal(list2Id);
                        //Only switches on Observable arrays are supported
                        if (collection1 instanceof kendo.data.ObservableArray &&
                            collection2 instanceof kendo.data.ObservableArray) {
                            // remmember this collectionto fill its gaps later
                            collectionsToCheck[list1Id] = collection1;
                            // switch the element inside the collection
                            var tmp = collection1[index1];
                            collection1[index2] = tmp;
                            // the origin slot is marked with 'undefined'
                            collection1[index1] = undefined;
                            if (tmp) {
                                tmp.UniqueID = id2;
                            }
                            // Remove the origin slot from the cache
                            delete Client.StateManager.Current._cache[id1];
                            Client.StateManager.Current._cache[id2] = tmp;
                        }
                        else if (id1.indexOf("->") < 0) {
                            var tmp = Client.StateManager.Current._cache[id1];
                            if (tmp) {
                                tmp.UniqueID = id2;
                                // Remove the origin slot from the cache
                                delete Client.StateManager.Current._cache[id1];
                                Client.StateManager.Current._cache[id2] = tmp;
                                //Lets check the list of references.
                                // If the referenced object is an observable array
                                // we have to update its key to the new key.                            
                                var references = tmp[Client.UniqueIDGenerator.ReferencesIdentifier];
                                if (references) {
                                    for (var i = 0; i < references.length; i++) {
                                        var referencedObject = Client.StateManager.Current.getObjectLocal(references[i]);
                                        if (referencedObject &&
                                            (referencedObject instanceof kendo.data.ObservableArray ||
                                                (referencedObject.length != null && referencedObject.length > 0))) {
                                            if (referencedObject[id1]) {
                                                delete referencedObject[id1];
                                                var endIndex = id2.indexOf(referencedObject.UniqueID);
                                                if (endIndex > 0) {
                                                    var newId = id2.substring(0, endIndex - 1);
                                                    referencedObject[newId] = tmp;
                                                }
                                                else if (endIndex != -1) {
                                                    referencedObject[id2] = tmp;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else {
                        }
                    }
                }
                //Fill any gaps on the collections 
                for (var listId in collectionsToCheck) {
                    var collection = collectionsToCheck[listId];
                    for (var j = 0; j < collection.length; j++) {
                        if (collection[j] === undefined) {
                            //We build uniqueId to array element
                            var id = j.toString() + Client.UniqueIDGenerator.UniqueIdSeparator + listId;
                            var deltaObj = this.getDeltaWithId(id, deltaData);
                            if (deltaObj) {
                                collection[j] = deltaObj;
                                Client.StateManager.Current._cache[id1] = deltaObj;
                            }
                        }
                    }
                }
            };
            /**
              *  This method must be called to handle the server side response to an action, it is responsible for updating
              *  client side data out from server side changes.  Responsibilities include:
              *  1. Initialize view models for every new view
              *  2. Update view model objects with server side changed information (delta)
              *  3. Display any shown view
              *  4. Update view changes (position, z-order, visibility)
              *  5. Remove any closed view
              */
            App.prototype.updateClientSide = function (data, actionDeffered, n1) {
                var that = this;
                var isThereAnyNewModels = false;
                //MOBILIZE,08/12/2016,TODO,CEBR-MRF-JQR, this change is required because of the change in promises in updateClientSide method
                var areThereAnyNewViews = false;
                if (data) {
                    var deffered = $.Deferred();
                    var lastPromise = deffered.promise();
                    if (data.VD) {
                        this.ViewManager.RemoveViews(data.VD);
                    }
                    if (data.SW) {
                        this.processSwitchedIds(data.SW, data.MD);
                    }
                    if (data.MD) {
                        var modelsToBeOrganized = [];
                        //We will collect all uniqueIDs that were sent, to restrict the 
                        //organizeAction ONLY to those objects
                        var lastUniqueIDs = [];
                        var controlArrays = [];
                        //Execute Preorganize actions
                        this.associateModelTypes(data.MD, data.MDT);
                        this.preOrganizeModels(data.MD, data.MDT);
                        //We will iterate thru all new items
                        //if an ObservableArray is found we will collect it in the controlArrays list.
                        //for doing an syncControlArrays call at the end.
                        //This call must be done after all models are processed, because the synccontrolArrays has
                        //the side effect of affect the ObservableArraySize. During this resize it is expected that 
                        //array entries are already on the cache
                        //Array containing information if the Views are New or not.
                        var newViews = data.NV;
                        for (var i = 0; i < data.MD.length; i++) {
                            var modelUpdateEntry = data.MD[i];
                            if (!modelUpdateEntry)
                                continue;
                            var lastUniqueIDs = [];
                            var delta = modelUpdateEntry;
                            //Checks if the View is new or not.
                            var isNewView = newViews[i] == '1' ? true : false;
                            if (isNewView)
                                modelsToBeOrganized.push(modelUpdateEntry);
                            var entry = Client.StateManager.Current.getObjectLocal(modelUpdateEntry.UniqueID);
                            if (entry && ((delta["@k"] == entry["@k"] && delta.UniqueID == entry.UniqueID) || !isNewView)) {
                                if (entry instanceof kendo.data.ObservableArray)
                                    controlArrays.push({ controlArray: entry, delta: delta });
                                else
                                    that.applyDelta(entry, delta);
                            }
                            else {
                                if (!isNewView)
                                    console.log(delta.UniqueID + " say it's not new but is not here. Inconsistent.");
                                if (entry)
                                    Client.StateManager.Current.ClearViewReferences(entry.UniqueID);
                                //This is a new model.
                                isThereAnyNewModels = true;
                                //We will "Resolve it from the Container"
                                var vm = entry = Client.Container.Current.Resolve({ vm: true, data: delta, dirty: false });
                                //If there is typing available set it
                                if (vm instanceof kendo.data.ObservableArray)
                                    controlArrays.push({ controlArray: vm, delta: delta });
                                if (vm.Name && vm.Name.indexOf("UserControl") == 0) {
                                    var logic = vm["logic"] = WebMap.Client.Container.Current.Resolve({ "cons": App.Current.ViewManager.getConstructor(vm) });
                                    logic.ViewModel = vm;
                                }
                            }
                        }
                        try {
                            //Lets make sure that ObservableArrays have a size that is Ok with the delta that
                            //we received
                            this.WakeUpArrayElements(controlArrays);
                            if (data.VD && data.VD.NewViews) {
                                var modalViews = data.VD.ModalViews;
                                var newModels = [];
                                for (var i = 0; i < data.VD.NewViews.length; i++) {
                                    var uid = data.VD.NewViews[i];
                                    var obj = Client.StateManager.Current.getObjectLocal(uid);
                                    if (obj) {
                                        newModels.push(obj);
                                    }
                                    areThereAnyNewViews = true;
                                    function displayView(uid, obj) {
                                        if (modalViews && modalViews.indexOf(uid) !== -1) {
                                            return that.ViewManager.NavigateToView(obj, true);
                                        }
                                        else {
                                            return that.ViewManager.NavigateToView(obj, false);
                                        }
                                    }
                                    lastPromise = lastPromise.then(displayView.bind(null, uid, obj));
                                }
                            }
                            //Sets focus to the current control
                            if (data.VD && data.VD.CurrentFocusedControl) {
                                var uniqueIDs = data.VD.CurrentFocusedControl;
                                var uniqueID = uniqueIDs[0];
                                var uidParent = Client.UniqueIDGenerator.getParent(uniqueID);
                                var parent = window["$cache"][uidParent];
                                if (parent && parent["@k"]) {
                                    var parentType = parent["@k"];
                                    var uidChild = Client.UniqueIDGenerator.getLastToken(uniqueID);
                                    var idOfElement = WebMap.Utils.getNameFromAlias(parentType, uidChild);
                                    var topElement = Client.UniqueIDGenerator.getFirstToken(uniqueID);
                                    var queryStr = "#" + topElement;
                                    for (var i = 1; i <= data.VD.CurrentFocusedControl.length - 1; i++) {
                                        var uidParentParent = Client.UniqueIDGenerator.getParent(data.VD.CurrentFocusedControl[i]);
                                        var parentParent = window["$cache"][uidParentParent];
                                        var parentParentType = parentParent["@k"];
                                        var uidParentChild = Client.UniqueIDGenerator.getLastToken(data.VD.CurrentFocusedControl[i]);
                                        var idOfParentElement = WebMap.Utils.getNameFromAlias(parentParentType, uidParentChild);
                                        queryStr += " #" + idOfParentElement;
                                    }
                                    queryStr += " #" + idOfElement;
                                    $(queryStr).focus();
                                }
                            }
                            if (isThereAnyNewModels) {
                                //If there is any new models then we would like to restrict organize 
                                //to only those objects
                                var options = { lastUniqueIDs: lastUniqueIDs, cache: modelsToBeOrganized };
                                //Child models must be connected to entry in the cache
                                Client.StateManager.Current.organize(options);
                            }
                            this.FinishWakeUpArrayElements();
                        }
                        catch (ExpCatch) {
                            console.error(ExpCatch, ExpCatch.stack);
                        }
                    }
                    this.postOrganizeModels();
                    this.Safe.updateClientSideState = ClientSyncronizationStage.UpdateClientSideAlmostComplete;
                    if (!areThereAnyNewViews) {
                        this.Safe.executePendingBindings();
                    }
                    lastPromise.done(function () {
                        that.Safe.executePendingBindings();
                        that.Safe.updateClientSideState = ClientSyncronizationStage.NotUpdatingClientSideYet;
                        Client.ClientTypeBehaviourManager.Current.execPostShowViewsActions();
                        Client.StateManager.Current.clearDirty();
                        actionDeffered.resolve();
                        that.executePendingSendActions();
                        //Finish request metrics
                        var n2 = window.performance.now();
                        var total = n2 - n1;
                        var action = that.actionInExecution;
                        var client = total - that.servier;
                        console.info(that.actionInExecution + ", " + that.servier + ", " + client + ", " + total);
                    });
                    deffered.resolve();
                    if (data.RM) {
                        this.processRemovedIds(data.RM);
                    }
                }
            };
            return App;
        }());
        Client.App = App;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
// Module
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var DeltaTracker = (function () {
            function DeltaTracker() {
                this.dirtyTable = {};
                this.attachedObjs = {};
                this.dirtyPropertiesTable = {};
            }
            DeltaTracker.prototype.isDirty = function (obj) {
                return (this.dirtyTable[obj.UniqueID] ||
                    this.dirtyPropertiesTable[obj.UniqueID]);
            };
            //Registers a JSON property as if it has been modified
            //so it will be send as part of the model deltas to the client  
            DeltaTracker.prototype.markAsModified = function (obj, propertyName) {
                this.updateDirtyPropertiesTable(propertyName, obj.UniqueID);
            };
            //Update the Dirty properties table 
            DeltaTracker.prototype.updateDirtyPropertiesTable = function (fieldName, uid) {
                var propertiesChangesMap = this.dirtyPropertiesTable[uid];
                if (!propertiesChangesMap) {
                    this.dirtyPropertiesTable[uid] = {};
                    propertiesChangesMap = this.dirtyPropertiesTable[uid];
                }
                propertiesChangesMap[fieldName] = true;
            };
            /**
             * Checks if the object has an UniqueID or it is an AttachedUniquedID
             * AttachedUniqueIds cannot have $
             */
            DeltaTracker.IsAttached = function (obj) {
                if (obj && obj.UniqueID)
                    return obj.UniqueID.indexOf("$") == -1;
                return false;
            };
            /**
             * Look for the first parent of the current object that has an AttachedUniqueID and marks it as
             * dirty, so the whole object will be send on the next sendAction call
             */
            DeltaTracker.prototype.climbToNearestAttachedObjectAndMarkItDirty = function (item) {
                var root = item.parent();
                while (root && !DeltaTracker.IsAttached(root)) {
                    root = root.parent();
                }
                if (root && root.UniqueID) {
                    this.dirtyTable[root.UniqueID] = true;
                }
            };
            DeltaTracker.prototype.changeTracker = function (e) {
                var fieldName = e.field;
                if (fieldName && e.sender.UniqueID) {
                    var uid = e.sender.UniqueID; // e.sender.get(actualSenderNameParts.join('.')).UniqueID;
                    this.updateDirtyPropertiesTable(fieldName, uid);
                }
            };
            /** Register an object for change tracking */
            DeltaTracker.prototype.attachModel = function (obj, markAsDirty) {
                var _this = this;
                var events = obj["_events"];
                var that = this;
                if (!this._changeDelegate) {
                    this._changeDelegate = function (e) {
                        if (!((e.action && e.action == "itemchange") || (e.field && e.field.indexOf('.') > -1))) {
                            that.changeTracker(e);
                        }
                        //is it an action on a Watchable feature?
                        //It the reported item does not have UniqueID it means that we need to find the closest parent with an attached uniqueID
                        //and mark it as dirty
                        if (e.action && e.action == "itemchange" && e.items && e.items.length > 0 && !DeltaTracker.IsAttached(e.items[0])) {
                            for (var i = 0; i < e.items.length; i++) {
                                _this.climbToNearestAttachedObjectAndMarkItDirty(e.items[i]);
                            }
                        }
                    };
                }
                //We will look to determine if the change delegate has already been attached
                if (events && events.change) {
                    var found = false;
                    for (var i = 0; i < events.change.length; i++) {
                        if (events.change[i] == this._changeDelegate) {
                            found = true;
                            break;
                        }
                    }
                    //if it hasnt been attached then insert it
                    if (!found) {
                        WebMap.Utils.bindEventToModel(obj, "change", this._changeDelegate);
                    }
                }
                else {
                    //No events yet. Then just attach the change delegate
                    WebMap.Utils.bindEventToModel(obj, "change", this._changeDelegate);
                }
                if (markAsDirty) {
                    this.dirtyTable[obj.UniqueID] = true;
                }
            };
            DeltaTracker.prototype.reset = function () {
            };
            DeltaTracker.prototype.start = function () {
                this.dirtyTable = {};
                this.dirtyPropertiesTable = {};
            };
            DeltaTracker.prototype.getDeltas = function () {
            };
            DeltaTracker.prototype.wasModified = function (variable) {
                return true;
            };
            DeltaTracker.prototype.getJSONFromFullObject = function (obj) {
                //Creating an empty object and extending it, is used
                //as a strategy to avoid maximum call stack error during toJSON calls
                var clone = jQuery.extend(true, {}, obj);
                for (var prop in clone) {
                    var elementUniqueID;
                    if (clone[prop] && (elementUniqueID = clone[prop]) && elementUniqueID.UniqueID) {
                        //this is another viewmode so just decouple
                        delete clone[prop];
                    }
                }
                return clone.toJSON();
            };
            DeltaTracker.prototype.getCalculatedDeltaFor = function (variable) {
                var isDirty = this.dirtyTable[variable.UniqueID];
                if (isDirty)
                    return this.getJSONFromFullObject(variable);
                var hasDirtyProperties = this.dirtyPropertiesTable[variable.UniqueID];
                if (hasDirtyProperties) {
                    //var behaviour = SerializationBehaviourManager.getBehaviour(delta);
                    //if (behaviour)
                    //   delta = behaviour.exportDelta(variable, delta);
                    var delta = {};
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
                            var elementUniqueID;
                            if (value && typeof (value) == 'object' && (elementUniqueID = value) && elementUniqueID.UniqueID) {
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
            };
            return DeltaTracker;
        }());
        Client.DeltaTracker = DeltaTracker;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="require.d.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var ViewManager = (function () {
            function ViewManager() {
                this._logic = {};
                this.closedViews = [];
            }
            ViewManager.prototype.GetView = function (UniqueID) {
                return this._logic[UniqueID];
            };
            ViewManager.prototype.CloseView = function (view) {
                window.app.sendAction({ mainobj: this, controller: "WebMapViewManager", action: "QueryClose", parameters: { viewId: view.UniqueID } });
            };
            ViewManager.prototype.PrepareDelta = function (requestInfo) {
                requestInfo.closedViews = this.closedViews;
            };
            ViewManager.prototype.UpdateView = function (view, viewInfo) {
                var viewId = view.UniqueID;
                // if the view has been removed lets ignored the update process
                var isRemoved = this.IsRemovedView(viewId, viewInfo);
                if (!isRemoved) {
                }
            };
            ViewManager.prototype.RemoveViews = function (data) {
                if (data.RemovedViews) {
                    for (var i = 0; i < data.RemovedViews.length; i++) {
                        var viewModelId = data.RemovedViews[i];
                        this.DisposeView(viewModelId);
                    }
                }
            };
            ViewManager.prototype.NavigateToView = function (viewModel, isModal) {
                var def = $.Deferred();
                var viewManager = this;
                window.app.log("Navigating to " + viewModel.Name);
                require([viewModel.Name], function (baseLogicClass) {
                    try {
                        if (!baseLogicClass) {
                            console.error("ViewManager::NavigateToView. The baseLogicClass is undefined. Verify that the class constructor is being returned on your Form.ts file");
                            throw "Missing Form Client Code";
                        }
                        window.app.log("Form Loaded");
                        var logic = viewManager._logic[viewModel.UniqueID];
                        if (!logic) {
                            logic = Client.Container.Current.Resolve({ "cons": baseLogicClass });
                            viewManager._logic[viewModel.UniqueID] = logic;
                        }
                        logic.ViewModel = viewModel;
                        viewModel.ViewModel = viewModel;
                        viewModel.logic = logic;
                        viewManager._logic[viewModel.UniqueID] = logic;
                        logic.Init(isModal);
                    }
                    finally {
                        def.resolve(logic);
                    }
                });
                return def;
            };
            ViewManager.prototype.ShowMessage = function (message, caption, buttons, boxIcons) {
                return null;
            };
            ViewManager.removeDesignerSupportSnippet = function (document) {
                var index = -1;
                if ((index = document.indexOf(ViewManager.DESIGNERSUPPORT)) != -1) {
                    document = document.substring(index + ViewManager.DESIGNERSUPPORT.length);
                }
                return document;
            };
            /**
             * Safely compiles an html template for a view
             */
            ViewManager.CompileView = function (viewName, htmlTemplate) {
                var compiledTemplate;
                try {
                    htmlTemplate = ViewManager.removeDesignerSupportSnippet(htmlTemplate);
                    compiledTemplate = kendo.template(htmlTemplate);
                }
                catch (CompileException) {
                    window.app.log("ViewManager::CompileView error compiling template [" + CompileException + "] for view [" + viewName + "]");
                    compiledTemplate = kendo.template("<div> Error </div>");
                }
                return compiledTemplate;
            };
            // Disposes the given view by removing the ILogicView object and calling its Close method.
            ViewManager.prototype.DisposeView = function (viewModelId) {
                var baseLogic = this._logic[viewModelId];
                if (baseLogic) {
                    delete this._logic[viewModelId];
                    baseLogic.Close();
                }
            };
            // Gets a lambda responsible for creating a new ILogicView<IViewModel> object for the given
            // view model
            ViewManager.prototype.getConstructor = function (vm) {
                var root = window;
                var current = null;
                if (vm.Name) {
                    var name = vm.Name;
                    if (name.indexOf('#') > 0) {
                        name = name.substring(name.indexOf('#') + 1);
                    }
                    var parts = name.split(".");
                    for (var i = 0; i < parts.length; i++) {
                        var currentPart = parts[i];
                        if (root === undefined) {
                            throw "Error while looking for constructor of " + vm.Name + " possible cause is that the JS code for that class has not been loaded, if plugins used check if the script is processed";
                        }
                        current = root[currentPart];
                        root = current;
                    }
                }
                return current;
            };
            // Checks that the given id is a removed view
            ViewManager.prototype.IsRemovedView = function (id, VD) {
                if (VD && VD.RemovedViews) {
                    for (var i = 0; i < VD.RemovedViews.length; i++) {
                        if (VD.RemovedViews[i] == id)
                            return true;
                    }
                }
                return false;
            };
            ViewManager.DESIGNERSUPPORT = '<designersupport/>';
            return ViewManager;
        }());
        Client.ViewManager = ViewManager;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
// Module
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var UniqueIDGenerator = (function () {
            function UniqueIDGenerator() {
            }
            UniqueIDGenerator.getParent = function (uniqueID) {
                var parent = null;
                var indexOfSeparator = uniqueID.indexOf(this.UniqueIdSeparator);
                if (indexOfSeparator != -1) {
                    parent = uniqueID.substring(uniqueID.indexOf(this.UniqueIdSeparator) + 1);
                }
                return parent;
            };
            UniqueIDGenerator.getLastToken = function (uniqueID) {
                return uniqueID.split(this.UniqueIdSeparator)[0];
            };
            UniqueIDGenerator.getFirstToken = function (uniqueID) {
                var parts = uniqueID.split(this.UniqueIdSeparator);
                return parts[parts.length - 1];
            };
            UniqueIDGenerator.UniqueIdSeparator = "#";
            UniqueIDGenerator.ReferencesIdentifier = "@@r";
            return UniqueIDGenerator;
        }());
        Client.UniqueIDGenerator = UniqueIDGenerator;
        function isNumeric(str) {
            return !isNaN(parseFloat(str));
        }
        var StateManager = (function () {
            function StateManager() {
                this._cache = {};
                this._tracker = new Client.DeltaTracker();
            }
            StateManager.Init = function () {
                if (!StateManager.Current) {
                    StateManager.Current = new StateManager();
                    window.$cache = StateManager.Current._cache;
                    window.$tracker = StateManager.Current._tracker;
                }
            };
            /**
              *We use the term "organize" to refer to actions
              * of using the UniqueIDs to reconnect objects in an object hierarchy.
              * UniqueIDs are allways like Panel1#0002 that means Panel1 property inside
              * a top level object identified by 0002 you can use
              * the shortcut $cache to watch the current models state
              */
            StateManager.prototype.organize = function (options) {
                this.resolveHierarchy(options);
            };
            StateManager.prototype.attachModel = function (obj) {
                this._tracker.attachModel(obj);
            };
            StateManager.prototype.resolveHierarchy = function (options) {
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
                        if (parent && parent.set) {
                            try {
                                var alreadySet = false;
                                //for performance metrics var n1 = window.performance.now();
                                if (cacheValue instanceof kendo.data.ObservableArray) {
                                    for (var j = 0; j < cacheValue.length; j++) {
                                        var item = cacheValue[j];
                                        if (item != null && entryUniqueID.indexOf(item.UniqueID) > 0) {
                                            parent[realName] = cacheValue;
                                            alreadySet = true;
                                            break;
                                        }
                                    }
                                    if (!alreadySet) {
                                        parent.set(realName, cacheValue);
                                    }
                                    //check if "after set" -> added new events(change) in ObservableArray
                                    if (cacheValue._events && cacheValue._events.change && cacheValue._events.change.length > 0) {
                                        var j = 0;
                                        var i = window.app.pendingUnBindedExDictonary[cacheValue.UniqueID];
                                        //if undefined then search one by one in list
                                        while (i == undefined && j < window.app.pendingUnBindedEx.length) {
                                            if (window.app.pendingUnBindedEx[j].array.UniqueID == cacheValue.UniqueID) {
                                                i = j;
                                            }
                                            j++;
                                        }
                                        if (i >= 0 && window.app.pendingUnBindedEx[i].array.UniqueID == cacheValue.UniqueID) {
                                            //backup new events and add in pendingUnBindedEx
                                            window.app.pendingUnBindedEx[i].events = window.app.pendingUnBindedEx[i].events.concat(cacheValue._events.change);
                                            //Now we unbind the event handler
                                            cacheValue._events.change = [];
                                        }
                                    }
                                }
                                else
                                    parent.setModelValue(realName, cacheValue);
                                // Take into account the change between _items (hierarchy string) and Items (property of JS object)
                                if (realName === "_items") {
                                    if (alreadySet)
                                        parent["Items"] = cacheValue;
                                    else
                                        parent.set("Items", cacheValue);
                                }
                            }
                            catch (ExpCatch) {
                                console.log(ExpCatch, ExpCatch.stack);
                            }
                        }
                    }
                }
            };
            StateManager.prototype.resolveMissingParent = function (parentKey, name, value) {
                window.app.log("Filling gap for " + parentKey);
                var parentDummyObject;
                //Can this token be for a control array?
                if (isNumeric(name)) {
                    parentDummyObject = this._cache[parentKey] = new kendo.data.ObservableArray([]);
                    parentDummyObject["UniqueID"] = parentKey;
                }
                else {
                    parentDummyObject = this._cache[parentKey] = new WebMap.Client.MobilizeObservableObject({ UniqueID: parentKey });
                }
                parentDummyObject["isGap"] = true;
                var typeOfParent = null;
                // Make sure the rest of the hierarchy is populated
                if (parentKey.indexOf(UniqueIDGenerator.UniqueIdSeparator) > -1) {
                    var parentName = parentKey.split(UniqueIDGenerator.UniqueIdSeparator)[0];
                    var grandpaKey = parentKey.substring(parentKey.indexOf(UniqueIDGenerator.UniqueIdSeparator) + 1); // Removing the '#' character from the parentKey also
                    // Create the grandpa object if it's not present in the cache
                    if (this._cache[grandpaKey] == null) {
                        this.resolveMissingParent(grandpaKey, parentName, parentDummyObject);
                        var grandpa = this._cache[grandpaKey];
                        var realName = WebMap.Utils.getNameFromAlias(grandpa["@k"], parentName);
                        typeOfParent = WebMap.Utils.getTypeFromAlias(grandpa["@k"], parentName);
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
                else {
                    parentDummyObject[name] = value;
                }
            };
            //public dettachObject(obj: IStateObject) {
            //	this._tracker.dettachModel(obj);
            //}
            StateManager.prototype.addNewObject = function (obj, markAsDirty) {
                if (!obj || !obj.UniqueID) {
                    window.app.info("StateCache::addNewObject trying to insert a model in the StateCache that is undefined or has not an UniqueID property");
                    return undefined;
                }
                this._cache[obj.UniqueID] = obj;
                if (markAsDirty === undefined)
                    markAsDirty = true;
                this._tracker.attachModel(obj, markAsDirty);
                return obj;
            };
            StateManager.prototype.getDirty = function () {
                var res = {};
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
            };
            StateManager.prototype.getObjectLocal = function (uniqueId) {
                return this._cache[uniqueId];
            };
            StateManager.prototype.clearDirty = function () {
                this._tracker.start();
            };
            StateManager.prototype.markAsModified = function (obj, fieldName) {
                this._tracker.markAsModified(obj, fieldName);
            };
            StateManager.prototype.getObject = function (uniqueId) {
                return this._cache[uniqueId];
            };
            //Removes the References to the object to avoid leaks.
            StateManager.prototype.removeReferences = function (objUniqueID) {
                var obj = this._cache[objUniqueID];
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
                }
                catch (e) {
                    console.log("ERROR REMOVING REFERENCES OF " + objUniqueID);
                }
                finally {
                    this._cache[objUniqueID] = null;
                }
            };
            // Removes all elements belonging to a specific view
            StateManager.prototype.ClearViewReferences = function (id) {
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
                                var KIItem = this._cache[uniqueID.substring(indexOfKi)];
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
                            }
                            catch (e) {
                            }
                        }
                    }
                }, 500);
            };
            return StateManager;
        }());
        Client.StateManager = StateManager;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="require.d.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        /**
         * Implements an ILogicView<T> interface.
         * The typescript code for all forms must inherit from this class
         * Descendants must override the Init Method to sed the template to be used
         *
         */
        var BaseLogic = (function () {
            function BaseLogic() {
                this.timersToCleanup = [];
                this.ApplyEnabledPointerEvents = function (status) {
                    $("#" + this.ViewModel.UniqueID).css("pointer-events", status);
                    if ($("#" + this.ViewModel.UniqueID).children && $("#" + this.ViewModel.UniqueID).children.length > 0) {
                        //disabled children events, some tags in html don't have enabled-disabled in children levels
                        $("#" + this.ViewModel.UniqueID).find('*').css("pointer-events", status);
                    }
                };
                this.ApplyValueChanges = function (changeEvent) {
                    var that = this;
                    try {
                        if (changeEvent.field === "Enabled") {
                            if (this.ViewModel.Enabled) {
                                $("#" + this.ViewModel.UniqueID).css("opacity", "1");
                                $("#" + this.ViewModel.UniqueID).removeProp("disabled");
                                this.ApplyEnabledPointerEvents('all');
                            }
                            else {
                                $("#" + this.ViewModel.UniqueID).css("opacity", "0.4");
                                $("#" + this.ViewModel.UniqueID).prop("disabled", "");
                                this.ApplyEnabledPointerEvents('none');
                            }
                        }
                        else if (changeEvent.field === "Visible") {
                            if (this.ViewModel.Visible) {
                                $("#" + this.ViewModel.UniqueID).css("visibility", "visible");
                            }
                            else {
                                $("#" + this.ViewModel.UniqueID).css("visibility", "hidden");
                            }
                        }
                    }
                    catch (e) {
                        window.app.log(e.message);
                    }
                };
            }
            /**
             * Gets the associated view from the ViewManage.LoadView (it could imply a web call) and then
             * calls BuildUI to initalize it
             */
            BaseLogic.prototype.Init = function (isModal) {
                // let's get the associated view from the ViewManager (it could imply a web call) and then
                // let's initalize it!
                this.BuildUI(BaseLogic.options.template, isModal);
            };
            /**
             * Intializes the view elements using the given options
             * param template - The value of the template
            * param keyboardEvents - It's optional. Is used to validate whether the keyboard events should be added or not. True by default.
             */
            BaseLogic.prototype.BuildUI = function (template, isModal, keyboardEvents) {
                var _this = this;
                template = template || kendo.template("<div>No template</div>");
                var appliedTemplate = template(this.ViewModel);
                var selector = this.ViewModel['Target'] || "#mainContent";
                //Appends the template to the page's DOM
                if (this.ViewModel['IsMdiParent']) {
                    $(selector).replaceWith(appliedTemplate);
                }
                else {
                    $(selector).append(appliedTemplate);
                }
                var domID = this.getDOMID();
                var element = $(domID);
                // If the window is not an MDI Parent then it will be rendered as a floating
                // window using the Kendo UI Window
                if (!this.ViewModel['IsMdiParent']) {
                    var dynamicHTML = WebMap.Utils.DynamicContainer.applyTemplate(this.ViewModel, this.ViewModel.Controls);
                    if (dynamicHTML != "") {
                        element.find("form").append(dynamicHTML);
                    }
                    var width = element.attr("data-width");
                    var height = element.attr("data-height");
                    var topValue = "0px";
                    var titleValue = element.attr("data-title");
                    if (element.attr("name") == "NoteAuthoring" || element.attr("name") == "AddClinicalItem" || element.attr("name") == "qChartDialog") {
                        topValue = "100px";
                    }
                    if (this.ViewModel.Text && this.ViewModel.Text != "" && this.ViewModel.Text != titleValue) {
                        titleValue = this.ViewModel.Text;
                        element.attr("data-title", titleValue);
                    }
                    var width = $(domID).attr("data-width");
                    var height = $(domID).attr("data-height");
                    var removeControlBox = $(domID).attr("data-removeControlBox");
                    var actions;
                    if (width && height) {
                        element.kendoWindow({
                            modal: isModal, width: width, height: height, resizable: false, actions: ["Minimize", "Maximize", "Close"], position: { top: topValue }, title: titleValue, animation: {
                                close: false,
                                open: false
                            } });
                    }
                    else {
                        element.kendoWindow({
                            actions: ["Minimize", "Maximize", "Close"], title: titleValue, modal: isModal, animation: {
                                close: false,
                                open: false
                            } });
                    }
                    //Adds a close event if not added at migration time
                    var kendoInfo = element.data("kendoWindow");
                    if (!kendoInfo) {
                        throw "Possible initialization error. A kendoWindow was expected but it was not found";
                    }
                    var that = this;
                    if (kendoInfo && !kendoInfo._events || !kendoInfo._events.close) {
                        kendoInfo.bind("close", function (e) {
                            if (e.userTriggered) {
                                Client.App.Current.ViewManager.CloseView(that.ViewModel);
                                e.preventDefault();
                            }
                        });
                    }
                    // fix an extra scrollbar in Chrome
                    element.css("overflow", "hidden");
                }
                // binds the html element identified by gotten domID with the view model
                kendo.bind(element, this.ViewModel);
                //Set focus 
                $(domID + " *[tabindex=\"0\"]").first().focus();
                WebMap.Utils.bindEventToModel(this.ViewModel, "change", function (changeEvent) { return _this.ApplyValueChanges(changeEvent); });
                //Keyboard Events (keydown,keypress,keyup)
                if (typeof (keyboardEvents) === "undefined" || keyboardEvents)
                    this.KeyBoardEvents();
            };
            BaseLogic.prototype.Close = function () {
                var domID = this.getDOMID();
                WebMap.Client.App.Current.isClosingView = true;
                if (!this.ViewModel['IsMdiParent']) {
                    window.destroyCount = 0;
                    var windowElement = $(domID);
                    windowElement.data("kendoWindow").close();
                    WebMap.Utils.selectiveUnbind(this.ViewModel);
                    kendo.unbind(windowElement);
                    setTimeout(function () {
                        kendo.destroy(windowElement);
                        $(domID).parent().empty();
                        $(domID).parent().remove();
                    }, 250);
                }
                else {
                    window.close();
                }
                WebMap.Client.App.Current.isClosingView = false;
                this.CleanupTimers();
                Client.StateManager.Current.ClearViewReferences(this.ViewModel.UniqueID);
            };
            BaseLogic.prototype.RegisterTimer = function (timerInfo) {
                this.timersToCleanup.push(timerInfo);
            };
            /**
             * This handler is meant to support convention based event handlers
             */
            BaseLogic.prototype.generic_Click = function (event) {
                if (event && event.data && event.target) {
                    var options = {
                        controller: event.data.Name.split(".").join("/"),
                        action: event.target.id + "_Click",
                        mainobj: event.data
                    };
                    Client.App.Current.sendAction(options);
                }
                else {
                    var def = $.Deferred();
                    def.resolve();
                    return def.promise();
                }
            };
            /**
              * Gets the id of the DOM object associated to the view
              */
            BaseLogic.prototype.getDOMID = function () {
                return "#" + this.ViewModel.UniqueID;
            };
            /**
             * Set keyboard events
             **/
            BaseLogic.prototype.KeyBoardEvents = function () {
                var id = $('#' + this.ViewModel.UniqueID);
                var kendoWindow = id.data("kendoWindow");
                if (id && kendoWindow) {
                    id.keypress(function (e) {
                        kendoWindow.trigger("keypress", e);
                    }).keydown(function (e) {
                        kendoWindow.trigger("keydown", e);
                    }).keyup(function (e) {
                        kendoWindow.trigger("keyup", e);
                    });
                }
            };
            BaseLogic.prototype.CloseWindowLocally = function (e) {
                if (e.userTriggered) {
                    var id = this.getDOMID();
                    Client.App.Current.ViewManager.CloseView(this.ViewModel);
                }
            };
            BaseLogic.prototype.CleanupTimers = function () {
                for (var i = 0; i < this.timersToCleanup.length; i++) {
                    var timerInfo = this.timersToCleanup[i];
                    if (timerInfo && timerInfo.clearTimer) {
                        timerInfo.clearTimer();
                    }
                }
            };
            BaseLogic.options = {
                template: kendo.template("template not loaded")
            };
            return BaseLogic;
        }());
        Client.BaseLogic = BaseLogic;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
/// <reference path="kendo.all.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="jquery.caret.d.ts" />
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        /// Custom bindings
        //Form Visible Custom binding 
        kendo.data.binders.widget.formVisible = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var that = this;
                var binding = that.bindings["formVisible"];
                var visibleValue = binding.get();
                if (typeof visibleValue != 'undefined') {
                    $(that.element.element).data("kendoWindow").setOptions({ "visible": visibleValue }); //update the widget
                    if (!visibleValue && $(".k-overlay"))
                        $(".k-overlay").remove();
                }
            }
        });
        //Form Text Custom binding 
        kendo.data.binders.widget.formTextBinding = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var that = this;
                var binding = that.bindings["formTextBinding"];
                if (binding)
                    $(that.element.element).data("kendoWindow").title(binding.get()); //update the widget
            }
        });
        kendo.data.binders.checkState = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                that.element.addEventListener('click', function () {
                    that.change();
                });
            },
            refresh: function () {
                var binding = this.bindings["checkState"];
                var vmelement = binding.source[binding.path.substr(0, binding.path.indexOf('.'))];
                if (vmelement !== undefined) {
                    var currentState = vmelement.get('CheckState');
                    if (currentState != 2) {
                        (this.element).checked = currentState == 1;
                    }
                    else {
                        (this.element).indeterminate = true;
                    }
                }
            },
            change: function () {
                var value = this.element.checked;
                var binding = this.bindings["checkState"];
                var vmelement = binding.source[binding.path.substr(0, binding.path.indexOf('.'))];
                vmelement.set('Checked', value);
                vmelement.set('CheckState', value ? 1 : 0);
                this.bindings['checkState'].set(value ? 1 : 0);
            }
        });
        (kendo.data.binders).customChecked = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                (kendo.data.Binder.fn).init.call(this, element, bindings, options);
                var that = this;
                (that.element).addEventListener('change', function () {
                    that.change();
                });
            },
            refresh: function () {
                var binding = this.bindings["customChecked"];
                (this.element).checked = binding.get();
            },
            change: function () {
                var value = this.element.checked;
                var binding = this.bindings["customChecked"];
                if (binding.source.get(binding.path) !== undefined) {
                    binding.set(true);
                }
                var source = binding.source;
                var relatedRadios = document.querySelectorAll('div[id="' + source.UniqueID + '"] input[name="' + this.element.name + '"]');
                for (var i in relatedRadios) {
                    var e = relatedRadios[i];
                    if (e != this.element &&
                        e.kendoBindingTarget &&
                        e.kendoBindingTarget.source) {
                        if (e.kendoBindingTarget.source[e.id]) {
                            e.kendoBindingTarget.source[e.id].set('Checked', false);
                        }
                        else {
                            // Check for control array updates
                            var controlArrayRefRegex = /^_(.+)_([0-9]+)/;
                            if (controlArrayRefRegex.test(e.id)) {
                                e.kendoBindingTarget.source.set(e.id.replace(controlArrayRefRegex, "$1[$2]") + ".Checked", false);
                            }
                        }
                    }
                }
            }
        });
        kendo.data.binders.menuEnabled = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var binding = this.bindings["menuEnabled"];
                var parentMenu = $(this.element).parents('ul[data-role="menu"]').data('kendoMenu');
                if (parentMenu)
                    parentMenu.enable(this.element, binding.get());
                else {
                    var parentContextMenu = $(this.element).parents('ul[data-role="contextMenu"]').data('kendoContextMenu');
                    if (parentContextMenu)
                        parentContextMenu.enable(this.element, binding.get());
                }
            }
        });
        kendo.data.binders.widget.dateTimePickerValue = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                this.element.bind("change", function () {
                    that.change();
                });
            },
            refresh: function () {
                var binding = this.bindings["dateTimePickerValue"];
                var value = binding.get();
                if (typeof (value) === 'string') {
                    value = kendo.parseDate(value);
                }
                this.element.value(value);
            },
            change: function () {
                var value = this.element.value();
                var binding = this.bindings["dateTimePickerValue"];
                binding.set(convertDate(value));
            }
        });
        function convertDate(value) {
            var year = value.getFullYear();
            var month = (value.getMonth() + 1 < 10) ? "0" + (value.getMonth() + 1) : (value.getMonth() + 1);
            var date = (value.getDate() < 10) ? "0" + value.getDate() : value.getDate();
            var hours = (value.getHours() < 10) ? "0" + value.getHours() : value.getHours();
            var minutes = (value.getMinutes() < 10) ? "0" + value.getMinutes() : value.getMinutes();
            var seconds = (value.getSeconds() < 10) ? "0" + value.getSeconds() : value.getSeconds();
            return year + "-" + month + "-" + date + "T" + hours + ":" + minutes + ":" + seconds;
        }
        kendo.data.binders.buttonText = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var binding = this.bindings["buttonText"];
                var spans = $(this.element).find("span");
                if (!spans || !spans.length)
                    $(this.element).html(binding.get());
                else {
                    $(spans[0]).html(binding.get());
                }
            }
        });
        kendo.data.binders.widget.DateTimeMinDate = kendo.data.Binder.extend({
            refresh: function (widget) {
                var binding = this.bindings["DateTimeMinDate"];
                var value = binding.get();
                if (value != null) {
                    var dataRole = this.element.element.attr('data-role');
                    if (dataRole === "datetimepicker")
                        this.element.element.data("kendoDateTimePicker").min(kendo.parseDate(value));
                    else if (dataRole === "datepicker")
                        this.element.element.data("kendoDatePicker").min(kendo.parseDate(value));
                }
            }
        });
        kendo.data.binders.timerTick = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
            }
        });
        kendo.data.binders.timerInterval = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
            }
        });
        kendo.data.binders.timerEnabled = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.isTimerActive = false;
                this.currentTimeoutId = -1;
            },
            refresh: function () {
                var binding = this.bindings["timerEnabled"];
                if (this.bindings.events) {
                    var callbackBinding = this.bindings.events["timerTick"];
                    var intervalBinding = this.bindings["timerInterval"];
                    var source = binding.source;
                    var logic = source.logic;
                    var that = this;
                    var interval = -1;
                    if (intervalBinding !== undefined) {
                        interval = intervalBinding.get();
                    }
                    else {
                        interval = parseInt($(this.element).attr('data-timerinterval'));
                        if (isNaN(interval)) {
                            interval = -1;
                        }
                    }
                    if (logic && logic.RegisterTimer) {
                        logic.RegisterTimer(that);
                    }
                    that.isTimerActive = binding.get() !== false;
                    if (binding.get() !== false) {
                        var theCallBack = callbackBinding.source.get(callbackBinding.path);
                        function returnHere() {
                            theCallBack.call(binding.source).then(function () {
                                if (that.bindings["timerEnabled"].get() !== false) {
                                    that.currentTimeoutId = setTimeout(returnHere, interval);
                                }
                            });
                        }
                        that.currentTimeoutId = setTimeout(returnHere, interval);
                    }
                    else {
                        that.clearTimer();
                    }
                }
            },
            clearTimer: function () {
                if (this.isTimerActive) {
                    this.isTimerActive = false;
                }
                if (this.currentTimeoutId != -1) {
                    clearTimeout(this.currentTimeoutId);
                    this.currentTimeoutId = -1;
                }
            }
        });
        kendo.data.binders.widget.comboSelectedIndex = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                that.indexCorrection = 0;
                this.element.bind("select", function (item) {
                    that.change(item);
                });
                if (this.element.ns === ".kendoDropDownList") {
                    this.indexCorrection = 1;
                }
                this.ignoreRefresh = false;
            },
            refresh: function () {
                var that = this;
                if (!this.ignoreRefresh) {
                    var binding = this.bindings["comboSelectedIndex"];
                    var value = binding.get();
                    if (typeof (value) === 'string') {
                        value = parseInt(value);
                    }
                    // Update the selected element, but be careful
                    // the data in the Combo may not be available yet
                    if (this.element.dataSource.data().length > 0) {
                        this.element.select(value + this.indexCorrection);
                    }
                    else {
                        // If the datasource is not available yet then delay the selection
                        setTimeout(function () {
                            that.element.select(value + that.indexCorrection);
                        }, 1);
                    }
                }
            },
            change: function (item) {
                var value = item.item.index();
                var binding = this.bindings["comboSelectedIndex"];
                try {
                    this.ignoreRefresh = true;
                    binding.set(value);
                }
                finally {
                    this.ignoreRefresh = false;
                }
            }
        });
        //////////////////////////////
        ///
        /// ListView support
        ///
        function createListViewGridAsChild(element, source, columnsObject, thisElement) {
            var newElement = document.createElement("div");
            var role = document.createAttribute("data-role");
            role.value = "grid";
            var db = $(element).attr('data-itemssource');
            var dbatt = document.createAttribute("data-bind");
            dbatt.value = db;
            newElement.setAttribute('data-role', 'grid');
            newElement.setAttribute('data-resizable', 'true');
            var dblclickhandler = $(element).attr('data-doubleclickhandler');
            if (dblclickhandler) {
                db = db + ",listViewDoubleClick: " + dblclickhandler;
            }
            var changeHandler = $(element).attr('data-changehandler');
            if (changeHandler) {
                source.logic["internalChangeHandler"] =
                    function (e) {
                        var that = this;
                        window.app.Safe.safeExec({
                            obj: source,
                            stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                            whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                            category: "requestAction",
                            action: function () { return that.logic[changeHandler].bind(that)(e); }
                        });
                    };
                db = db + ",events: {change: logic.internalChangeHandler}";
            }
            var initialHeight = $(element).attr('data-initialheight');
            if (initialHeight !== undefined) {
                newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
            }
            var selectIndices = $(element).attr('data-selectedIndices');
            var checkedIndices = $(element).attr('data-checkedIndices');
            newElement.setAttribute('data-bind', db + "," + selectIndices + "," + checkedIndices);
            element.appendChild(newElement);
            var selectionMode = $(element).data('selectionmode') == "multiple" ? "multiple, row" : "row";
            var allowReorder = $(element).data('allowreorder') === true ? true : false;
            $(newElement).kendoGrid({
                resizable: true,
                scrollable: true,
                reorderable: allowReorder,
                selectable: selectionMode,
                columns: transformColumnsToObj(columnsObject, thisElement),
                dataBound: function (e) {
                    var items = e.sender.dataItems();
                    if (items && items.length) {
                        var itemElements = e.sender.element.find("[class='k-grid-content']").find('tr');
                        var i = 0;
                        for (i = 0; i < items.length; i++) {
                            if (items[i].Checked) {
                                var checkbox = $(itemElements[i]).find('input');
                                if (checkbox) {
                                    $(checkbox).attr("checked", "checked");
                                }
                            }
                            if (items[i].Selected) {
                                $(itemElements[i]).addClass("k-state-selected");
                                $(itemElements[i]).attr('selected', 'true');
                            }
                        }
                    }
                },
                change: function (e) {
                    var items = e.sender.dataItems();
                    if (items && items.length) {
                        var itemElements = e.sender.element.find("[class='k-grid-content']").find('tr');
                        var i = 0;
                        for (i = 0; i < items.length; i++) {
                            var isSelected = $(itemElements[i]).hasClass('k-state-selected');
                            if (isSelected)
                                items[i].Selected = true;
                            else
                                items[i].Selected = false;
                        }
                    }
                }
            });
            // setTimeout is required because the template may not be completely applied
            if (initialHeight === undefined) {
                setTimeout(function () {
                    $(element).find('.k-widget').height("100%");
                    $(newElement).find('.k-grid-content').height("87%");
                    $(newElement).find('.k - grid - header').height("13%");
                }, 100);
            }
            kendo.bind($(element).children('div'), source);
        }
        function removeExistingListViewInnerElement(element) {
            $(element).children('div').each(function (index, subeelement) {
                var existingGrid = $(subeelement).data('kendoGrid');
                if (existingGrid) {
                    existingGrid.destroy();
                    $(subeelement).remove();
                }
                var existingLv = $(subeelement).data('kendoListView');
                if (existingLv) {
                    existingLv.destroy();
                    $(subeelement).remove();
                }
            });
        }
        function noImageTemplate(checkboxes) {
            var listTemplate = "";
            if (checkboxes)
                listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><input type='checkbox' value='#= ItemContent[0] #'/><p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
            else
                listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
            return listTemplate;
        }
        function createTemplateForList(element, modevalue, checkboxes) {
            var listTemplate = "<div style='float: left'><div>#= ItemContent[0] #<br></div></div>";
            if (modevalue == 0) {
                var imageListPrefix = $(element).data('imagelistprefix');
            }
            if (modevalue == 2) {
                var imageListPrefix = $(element).data('smallimagelistprefix');
            }
            if (modevalue == 0 || modevalue == 2) {
                if (imageListPrefix) {
                    imageListPrefix = imageListPrefix;
                    if (checkboxes) {
                        listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><input type='checkbox' value='#= ItemContent[0] #'/>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}#<p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
                    }
                    else {
                        listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}#<p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
                    }
                }
                else
                    listTemplate = noImageTemplate(checkboxes);
            }
            else {
                var imageListPrefix = $(element).data('smallimagelistprefix');
                if (imageListPrefix) {
                    imageListPrefix = imageListPrefix;
                    if (checkboxes) {
                        listTemplate = "<div style='float: left'><div><input type='checkbox' value='#= ItemContent[0] #'/>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}##= ItemContent[0] #<br></div></div>";
                    }
                    else {
                        listTemplate = "<div style='float: left'><div>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}##= ItemContent[0] #<br></div></div>";
                    }
                }
                else if (checkboxes) {
                    listTemplate = "<div style='float: left'><div><input type='checkbox' value='#= ItemContent[0] #'/>#= ItemContent[0] #<br></div></div>";
                }
                else {
                    listTemplate = "<div style='float: left'><div>#= ItemContent[0] #<br></div></div>";
                }
            }
            return listTemplate;
        }
        function refreshListViewTemplates(thisElement) {
            var modebinding = thisElement.bindings["listViewMode"];
            var modevalue = modebinding.get();
            var binding = thisElement.bindings["listViewColumns"];
            var value = binding.get();
            var element = thisElement.element.element[0];
            var checkBoxes = thisElement.bindings["CheckBoxesMode"].get(); //Indicates if the template should have a checkbox element next to each Item
            removeExistingListViewInnerElement(element);
            if (modevalue === 1) {
                createListViewGridAsChild(element, binding.source, value, thisElement);
            }
            else {
                var newElement = document.createElement("div");
                var role = document.createAttribute("data-role");
                role.value = "listview";
                var db = $(element).attr('data-itemssource');
                var selectIndices = $(element).attr('data-selectedIndices');
                var checkedIndices = $(element).attr('data-checkedIndices');
                var selectedIndexChanged = $(element).attr('data-SelectedIndexChanged');
                newElement.setAttribute('data-role', 'listview');
                newElement.setAttribute('data-resizable', 'true');
                var events = "";
                if (selectedIndexChanged !== undefined) {
                    events = "events : {" + selectedIndexChanged + "}";
                }
                ;
                newElement.setAttribute('data-bind', db + "," + selectIndices + "," + checkedIndices + "," + events);
                element.appendChild(newElement);
                var initialHeight = $(element).attr('data-initialheight');
                if (initialHeight !== undefined) {
                    newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
                }
                newElement.setAttribute('style', 'overflow:scroll' + (newElement.getAttribute('style') ? ';' + newElement.getAttribute('style') : ''));
                var selectionMode = $(element).data('selectionmode') == "single" ? "single" : "multiple";
                var listTemplate = createTemplateForList(element, modevalue, checkBoxes);
                $(newElement).kendoListView({
                    navigatable: true,
                    selectable: selectionMode,
                    template: kendo.template($(listTemplate).html()),
                    dataBound: function (e) {
                        var items = e.sender.dataItems();
                        if (items && items.length) {
                            var itemElements = e.sender.element.find("div");
                            var i = 0;
                            for (i = 0; i < items.length; i++) {
                                if (items[i].Checked) {
                                    var checkbox = $(itemElements[i]).find('input');
                                    if (checkbox) {
                                        $(checkbox).attr("checked", "checked");
                                    }
                                }
                                if (items[i].Selected) {
                                    $(itemElements[i]).addClass("k-state-selected");
                                    $(itemElements[i]).attr('selected', 'true');
                                }
                            }
                        }
                    },
                    change: function (e) {
                        var items = e.sender.dataItems();
                        if (items && items.length) {
                            var itemElements = e.sender.element.find("div");
                            var i = 0;
                            for (i = 0; i < items.length; i++) {
                                var isSelected = $(itemElements[i]).hasClass('k-state-selected');
                                window.app.log(isSelected);
                                if (isSelected)
                                    items[i].Selected = true;
                                else
                                    items[i].Selected = false;
                            }
                        }
                    }
                });
                kendo.bind($(element).children('div'), binding.source);
            }
        }
        kendo.data.binders.widget.listViewSelectedIndices = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                element.bind('change', function () {
                    _this.update();
                });
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    var selectedIndexBinding = this.bindings["listViewSelectedIndices"];
                    var newIndex = selectedIndexBinding.get();
                    var listview = this.element.element;
                    if (listview)
                        listview = listview[0];
                    else
                        listview = this.element[0];
                    var isGrid = $(listview).find('table');
                    var items = null;
                    if (isGrid.length == 0) {
                        items = $(listview).find('div');
                    }
                    else
                        items = $(listview).find("[class='k-grid-content']").find('tr');
                    this.selectionRestore(items, newIndex);
                }
            },
            update: function () {
                var listview = this.element.element;
                if (listview)
                    listview = listview[0];
                else
                    listview = this.element[0];
                var isGrid = $(listview).find('table');
                var items = null;
                if (isGrid.length == 0)
                    items = $(listview).find('div');
                else
                    items = $(listview).find("[class='k-grid-content']").find('tr');
                var newIndices = [];
                items.each(function (i, item) {
                    var isSelected = $(item).hasClass('k-state-selected');
                    if (typeof isSelected !== typeof undefined && isSelected !== false) {
                        newIndices.push(i);
                    }
                });
                var selectedIndexBinding = this.bindings["listViewSelectedIndices"];
                selectedIndexBinding.set(newIndices);
                this.innerUpdating = false;
            },
            destroy: function () {
                kendo.data.Binder.fn.destroy.call(this);
                this.element.unbind('dblclick');
            },
            selectionRestore: function (children, indices) {
                if (indices) {
                    children.each(function (i, element) {
                        var colIndex = indices.indexOf(i);
                        if (colIndex != -1) {
                            $(element).addClass('k-state-selected');
                            $(element).attr('selected', 'true');
                        }
                        else if (colIndex == -1) {
                            $(element).removeClass('k-state-selected');
                            $(element).removeAttr('selected');
                        }
                    });
                }
            }
        });
        kendo.data.binders.widget.listViewCheckedIndices = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                element.element.bind('click', function () {
                    _this.update();
                });
                element.element.bind('dataBound', function () {
                    _this.databound();
                });
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    var checkedIndexBinding = this.bindings["listViewCheckedIndices"];
                    var newIndex = checkedIndexBinding.get();
                    var listview = this.element.element;
                    if (listview)
                        listview = listview[0];
                    else
                        listview = this.element[0];
                    var isGrid = $(listview).find('table');
                    var items = null;
                    if (isGrid.length == 0) {
                        items = $(listview).find('div');
                    }
                    else
                        items = $(listview).find("[class='k-grid-content']").find('tr');
                    this.selectionRestore(items, newIndex);
                }
            },
            update: function () {
                var listview = this.element.element;
                if (listview)
                    listview = listview[0];
                else
                    listview = this.element[0];
                var isGrid = $(listview).find('table');
                var items = null;
                if (isGrid.length == 0)
                    items = $(listview).find('div');
                else
                    items = $(listview).find("[class='k-grid-content']").find('tr');
                var newIndices = [];
                items.each(function (i, item) {
                    var checkbox = $(item).find('input');
                    var checked = false;
                    if (checkbox.get(0) !== undefined) {
                        checked = checkbox.prop('checked');
                        if (checked)
                            newIndices.push(i);
                    }
                });
                var checkedIndexBinding = this.bindings["listViewCheckedIndices"];
                checkedIndexBinding.set(newIndices);
                this.innerUpdating = false;
            },
            destroy: function () {
                kendo.data.Binder.fn.destroy.call(this);
                this.element.unbind('dblclick');
            },
            selectionRestore: function (children, indices) {
                if (indices) {
                    children.each(function (i, element) {
                        var colIndex = indices.indexOf(i);
                        if (colIndex != -1) {
                            var checkbox = $(element).find('input');
                            if (checkbox) {
                                $(checkbox).prop("checked", "checked");
                            }
                        }
                        else if (colIndex == -1) {
                            var checkbox = $(element).find('input');
                            if (checkbox)
                                checkbox.removeAttr('checked');
                        }
                    });
                }
            }
        });
        kendo.data.binders.widget.listViewMode = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                refreshListViewTemplates(this);
            }
        });
        kendo.data.binders.widget.CheckBoxesMode = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                refreshListViewTemplates(this);
            }
        });
        function transformColumnsToObj(cols, thisElement) {
            var colsStr = [];
            if (thisElement.bindings["CheckBoxesMode"]) {
                var checkBoxes = thisElement.bindings["CheckBoxesMode"].get();
                if (checkBoxes) {
                    colsStr.push({
                        field: "select",
                        title: "&nbsp;",
                        template: '<input type=\'checkbox\' />',
                        sortable: false,
                        width: 25
                    });
                }
            }
            //Some optimizations do not send collections when empty
            //so we must check before using them
            if (cols && cols.Items) {
                for (var idx = 0; idx < cols.Items.length; idx++) {
                    var colDefinition = cols.Items[idx];
                    var columnAlignment = getKendoAlignment(colDefinition.HorizontalAlignment);
                    colsStr.push({
                        title: colDefinition.Text,
                        field: "ItemContent[" + idx.toString() + "]",
                        attributes: {
                            style: "text-align: " + columnAlignment
                        },
                        headerAttributes: {
                            style: "text-align: " + columnAlignment
                        },
                        width: colDefinition.Width,
                        editor: colDefinition.ReadOnly ? ReadOnlyEditor : ''
                    });
                }
            }
            var deleteRows = thisElement.bindings["DataGridDeleteRows"];
            if (deleteRows) {
                var value = deleteRows.get();
                if (value) {
                    colsStr.push({
                        command: [{
                                name: 'deleteRecord',
                                text: 'Delete Record',
                                click: deleteRecords,
                                imageClass: "ui-icon ui-icon-close"
                            }],
                        width: "100px"
                    });
                }
            }
            return colsStr;
        }
        function ReadOnlyEditor(event) {
            var gridDiv = $(event).closest("div[id$='_innerGrid']");
            $(gridDiv).data('kendoGrid').closeCell();
        }
        function getKendoAlignment(alignment) {
            switch (alignment) {
                case 0: return "center";
                case 2: return "right";
                default: return "left";
            }
        }
        kendo.data.binders.widget.listViewColumns = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var binding = this.bindings["listViewColumns"];
                if (binding) {
                    var that = this;
                    var value = binding.get();
                    if (value) {
                        value.bind('change', function () {
                            that.refresh();
                        });
                    }
                }
            },
            refresh: function () {
                var modebinding = this.bindings["listViewMode"];
                var modevalue = modebinding.get();
                if (modevalue !== 1) {
                    return;
                }
                var binding = this.bindings["listViewColumns"];
                var value = binding.get();
                var element = this.element.element[0];
                removeExistingListViewInnerElement(element);
                createListViewGridAsChild(element, binding.source, value, this);
            }
        });
        kendo.data.binders.widget.listViewDoubleClick = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var handlerBinding = this.bindings["listViewDoubleClick"];
                var theCallBack = handlerBinding.source.get(handlerBinding.path);
                if (this.theHandler === undefined) {
                    this.theHandler = function () {
                        theCallBack.call(handlerBinding.source);
                    };
                    $(this.element.table).last().dblclick(this.theHandler);
                }
            },
            destroy: function () {
                kendo.data.Binder.fn.destroy.call(this);
                $(this.element.table).last().unbind('dblclick');
            }
        });
        (function ($) {
            var ui = kendo.ui, Widget = ui.Widget;
            var WMListView = Widget.extend({
                init: function (element, options) {
                    Widget.fn.init.call(this, element, options);
                },
                options: {
                    name: "WMListView",
                    mode: 1
                }
            });
            ui.plugin(WMListView);
            kendo.init($(document.body));
        })(jQuery);
        kendo.data.binders.enabled = kendo.data.Binder.extend({
            previousBinder: kendo.data.binders.enabled,
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget, bindings, options);
                this.refresh = this.setupTabStripPage(widget) ||
                    this.setupMenuItem(widget) ||
                    (this.previousBinder ? this.previousBinder.prototype.refresh : undefined); // use default kendo enabled binder
            },
            setupTabStripPage: function (widget) {
                // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
                var tabControl, tmp;
                if (widget instanceof HTMLLIElement && (tmp = widget.parentElement) instanceof HTMLUListElement &&
                    (tabControl = tmp.parentElement) instanceof HTMLDivElement && tabControl.getAttribute("data-role") === "tabstrip") {
                    var tabWidget = $(tabControl).data("kendoTabStrip");
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        var index = enabledBinding.path.indexOf(".Items[");
                        if (index >= 0) {
                            var sinPath = enabledBinding.path.substring(0, index);
                            sinPath = sinPath.concat(".Enabled");
                        }
                        var widgetEnabledValue = enabledBinding.source.get(sinPath);
                        if (widgetEnabledValue) {
                            tabWidget.enable(this.element, enabledBinding.get());
                        }
                    };
                }
                return null;
            },
            setupMenuItem: function (widget) {
                var parentMenuElement = $(this.element).parents('ul[data-role="menu"]');
                if (parentMenuElement && parentMenuElement.length > 0) {
                    var binding = this.bindings["enabled"];
                    var parentMenu = parentMenuElement.data('kendoMenu');
                    return function () {
                        parentMenu.enable(this.element, binding.get());
                    };
                }
                return null;
            }
        });
        /// Enabled custom binding for widgets 
        kendo.data.binders.widget.enabled = kendo.data.Binder.extend({
            previousBinder: kendo.data.binders.widget.enabled,
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget, bindings, options);
                this.refresh = this.setupControls(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined); // use default kendo widget enabled binder
            },
            setupControls: function (widget) {
                var dataRole = $(widget.element).attr('data-role');
                if (dataRole === "treeview") {
                    var treeWidget = widget;
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        treeWidget.enable(".k-item", enabledBinding.get());
                    };
                }
                else if (dataRole === "dropdownlist"
                    || dataRole === "datetimepicker"
                    || dataRole === "timepicker"
                    || dataRole === "maskedtextbox"
                    || dataRole === "datepicker"
                    || dataRole === "combobox"
                    || dataRole === "textbox") {
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        widget.enable(enabledBinding.get());
                    };
                }
                else if (dataRole === "wmlistview") {
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        var coverDiv = $(widget.element).find('.cover');
                        var enabledValue = enabledBinding.get();
                        if (!enabledValue) {
                            $("<div class='cover'>").css({
                                width: "100%",
                                height: "100%",
                                top: "0px",
                                left: "0px",
                                position: "absolute",
                                background: 'rgba(0,0,0,0.2)',
                                "z-index": $("div[data-role='grid']").css('z-index') + 1
                            }).appendTo($(widget.element));
                        }
                        else {
                            $(widget.element).find('.cover').remove();
                        }
                    };
                }
                else if (dataRole === "tabstrip") {
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        var ulElem = $(widget.element).children('ul').first();
                        ulElem.children('li').each(function (index, li) {
                            if (enabledBinding.get()) {
                                var sinPath = enabledBinding.path.replace('.Enabled', '');
                                var itemEnabledValue = enabledBinding.source.get(sinPath + '.Items[' + index + '].Enabled');
                                widget.enable(li, itemEnabledValue);
                            }
                            else {
                                widget.enable(li, enabledBinding.get());
                            }
                        });
                    };
                }
                else if (dataRole === "wmflexgrid") {
                    var enabledBinding = this.bindings.enabled;
                    return function () {
                        var gridElem = $(widget.element);
                        $(gridElem).prop("disabled", enabledBinding.get());
                    };
                }
                return null;
            }
        });
        kendo.data.binders.visible = kendo.data.Binder.extend({
            previousBinder: kendo.data.binders.visible,
            isClassSet: function (classes, cls) {
                var idx = classes.indexOf(cls);
                var len = cls.length;
                return (idx == 0 && (classes.length == len || classes[len] == ' ')) || (idx > 0 && classes[idx - 1] == ' ' && ((idx += len) == classes.length || classes[idx] == ' '));
            },
            removeClass: function (classes, cls) {
                var len = cls.length;
                var idx = classes.indexOf(cls);
                if (idx >= 0) {
                    var idx2 = idx + len;
                    var before = "", after = "";
                    if (idx > 0) {
                        if (classes[idx - 1] == ' ')
                            idx--;
                        else
                            return classes;
                        before = classes.substring(0, idx);
                    }
                    if (idx2 < classes.length) {
                        if (classes[idx2] == ' ')
                            idx2++;
                        else
                            return classes;
                        after = classes.substring(idx2);
                    }
                    return (before + ' ' + after).trim();
                }
                return classes;
            },
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget, bindings, options);
                //WebMap.Kendo.setupBinding(this, kendo.data.binders.visible, [TabPageVisibleBindingSetup.prototype]);
                this.refresh = this.setupTabStripPage(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined); // use default kendo enabled binder
            },
            setupTabStripPage: function (widget) {
                // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
                var tabControl, tmp;
                if (widget instanceof HTMLLIElement && (tmp = widget.parentElement) instanceof HTMLUListElement &&
                    (tabControl = tmp.parentElement) instanceof HTMLDivElement && tabControl.getAttribute("data-role") === "tabstrip") {
                    var tabWidget = $(tabControl).data("kendoTabStrip");
                    var visibleBinding = this.bindings.visible;
                    return function () {
                        var cls = widget.getAttributeNode("class");
                        if (visibleBinding.get()) {
                            if (!this.isClassSet(cls.value, "k-item"))
                                cls.value = "k-item " + cls.value;
                            widget.removeAttribute("hidden");
                        }
                        else {
                            var newValue = this.removeClass(cls.value, "k-item");
                            if (newValue != cls.value) {
                                if (tabWidget.select()[0] === widget)
                                    tabWidget.deactivateTab(widget);
                                cls.value = newValue;
                                widget.setAttribute("hidden", "hidden");
                            }
                        }
                    };
                }
                return null;
            }
        });
        //class TabPageVisibleBindingSetup extends WebMap.Kendo.BindingSetup {
        //    public setup(binding: kendo.data.Binder): boolean {
        //        // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
        //        var widget = binding.element;
        //        var tabControl;
        //        if (widget instanceof HTMLLIElement && widget.parentElement instanceof HTMLUListElement &&
        //            (tabControl = widget.parentElement.parentElement) instanceof HTMLDivElement &&
        //            tabControl.getAttribute("data-role") === "tabstrip") {
        //            var tabWidget = $(tabControl).data("kendoTabStrip");
        //            var visibleBinding = binding.bindings["visible"];
        //            binding.refresh = function () {
        //                var cls = widget.getAttributeNode("class");
        //                if (visibleBinding.get()) {
        //                    if (!WebMap.Utils.IsClassSet(cls.value, "k-item"))
        //                        cls.value = "k-item " + cls.value;
        //                    widget.removeAttribute("hidden");
        //                }
        //                else {
        //                    var newValue = WebMap.Utils.RemoveClass(cls.value, "k-item");
        //                    if (newValue != cls.value) {
        //                        if (tabWidget.select()[0] === widget)
        //                            tabWidget.deactivateTab(widget);
        //                        cls.value = newValue;
        //                        widget.setAttribute("hidden", "hidden");
        //                    }
        //                }
        //            };
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        kendo.data.binders.widget.visible = kendo.data.Binder.extend({
            previousBinder: kendo.data.binders.visible,
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget, bindings, options);
                this.refresh = this.setupCustomControl(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined); // use default kendo enabled binder
            },
            setupCustomControl: function (widget) {
                var dataRole = $(widget.element).attr('data-role');
                var visibleBinding = this.bindings.visible;
                if (dataRole === "wmlistview"
                    || dataRole === "listbox"
                    || dataRole === "grid"
                    || dataRole === "wmflexgrid"
                    || dataRole === "dropdownlist"
                    || dataRole === "combobox"
                    || dataRole === "maskedtextbox"
                    || dataRole === "menu"
                    || dataRole === "treeview"
                    || dataRole === "tabstrip"
                    || dataRole === "datetimepicker"
                    || dataRole === "timepicker"
                    || dataRole === "truedbgrid") {
                    return function () {
                        if (visibleBinding.get()) {
                            $(widget.element).css({ visibility: "inherit" });
                        }
                        else {
                            $(widget.element).css({ visibility: "hidden" });
                        }
                    };
                }
                else if (dataRole === "datepicker" || dataRole === "dropdownlist") {
                    return function () {
                        if (visibleBinding.get()) {
                            $(widget.element).closest(".k-widget").css({ visibility: "inherit" });
                        }
                        else {
                            $(widget.element).closest(".k-widget").css({ visibility: "hidden" });
                        }
                    };
                }
                else if (dataRole === "menu") {
                    return function () {
                        var isVisible = visibleBinding.get();
                        if (typeof isVisible === 'boolean' && isVisible === false) {
                            $(widget.element).css({ display: "none" });
                        }
                        else {
                            $(widget.element).css({ display: "block" });
                        }
                    };
                }
                else if (dataRole === "numerictextbox") {
                    return function () {
                        var isVisible = visibleBinding.get();
                        if (typeof isVisible === 'boolean' && isVisible === false) {
                            $(widget.element).closest('.k-numerictextbox').parent().css({ visibility: "hidden" });
                        }
                        else {
                            $(widget.element).closest('.k-numerictextbox').parent().css({ visibility: "inherit" });
                        }
                    };
                }
                else if (dataRole === "window") {
                    return function () {
                        var isVisible = visibleBinding.get();
                        if (typeof isVisible === 'boolean' && isVisible === false) {
                            $(widget.element).parent().css({ visibility: "hidden" });
                        }
                        else {
                            $(widget.element).parent().css({ visibility: "inherit" });
                        }
                    };
                }
                return null;
            }
        });
        kendo.data.binders.widget.Visible = kendo.data.Binder.extend({
            refresh: function () {
                var value = this.bindings["Visible"].get();
                if (value == false) {
                    this.element.element.css("display", "none");
                }
                else {
                    this.element.element.css("display", "inherit");
                }
            }
        });
        kendo.data.binders.Visible = kendo.data.Binder.extend({
            refresh: function () {
                var value = this.bindings["Visible"].get();
                if (value == false) {
                    this.element.css("display", "none");
                }
                else {
                    this.element.css("display", "inherit");
                }
            }
        });
        kendo.data.binders.widget.selectedIndex = kendo.data.Binder.extend({
            previousBinder: kendo.data.binders.widget.selectedIndex,
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget, bindings, options);
                if (!this.setupTabStripPage(widget) && this.previousBinder) {
                    this.refresh = this.previousBinder.prototype.refresh;
                    this.destroy = this.previousBinder.proptotype.destroy;
                }
            },
            setupTabStripPage: function (widget) {
                // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
                var htmlElement = widget.element[0];
                if (htmlElement instanceof HTMLDivElement && htmlElement.getAttribute("data-role") === "tabstrip") {
                    var selectedIndexBinding = this.bindings.selectedIndex;
                    var busy = false;
                    var updateModel = function () {
                        if (!busy)
                            try {
                                busy = true;
                                selectedIndexBinding.set(widget.select().index());
                            }
                            finally {
                                busy = false;
                            }
                    };
                    WebMap.Client.App.Current.addModelUpdateListener(updateModel);
                    this.refresh = function () {
                        if (!busy)
                            try {
                                busy = true;
                                var selectedValue = selectedIndexBinding.get();
                                if (selectedValue == -1) {
                                    widget.select(0);
                                }
                                else {
                                    widget.select(selectedValue);
                                }
                            }
                            finally {
                                busy = false;
                            }
                    };
                    this.destroy = function () {
                        WebMap.Client.App.Current.removeModelUpdateListener(updateModel);
                    };
                    return true;
                }
                return false;
            }
        });
        kendo.data.binders.widget.flexGridRefresh = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var binding = this.bindings["flexGridRefresh"];
                var value = binding.get();
                if (value === true) {
                    try {
                        var grid = $(this.element.element.children('div')).data('kendoGrid');
                        grid.dataSource.read();
                    }
                    finally {
                        binding.set(false);
                    }
                }
            }
        });
        kendo.data.binders.widget.flexGridPosition = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                var that = this;
                that.registerChange();
                this.element.bind('reconfigured', function () {
                    that.registerChange();
                });
            },
            registerChange: function () {
                var that = this;
                var grid = $(this.element.element).find('div').data('kendoGrid');
                if (grid) {
                    grid.bind('change', function () {
                        that.update(grid, that.bindings["flexGridPosition"]);
                        setTimeout(function () {
                            that.element.trigger("click");
                        }, 1);
                    });
                }
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    var binding = this.bindings["flexGridPosition"];
                    var grid = $(this.element.element).find('div').data('kendoGrid');
                    var htmlRow = grid.tbody.children().eq(binding.get()[0] - this.rowAdjustment());
                    if (htmlRow && htmlRow.length > 0) {
                        if ((grid.options && grid.options.selectable === "row")) {
                            grid.clearSelection();
                            grid.select(htmlCell);
                        }
                        else {
                            var htmlCell = htmlRow.children('td').eq(binding.get()[1]);
                            if (htmlCell && !htmlCell.hasClass('k-state-selected')) {
                                grid.clearSelection();
                                grid.select(htmlCell);
                            }
                        }
                    }
                }
            },
            update: function (grid, binding) {
                var dataItem = grid.dataItem(grid.select()) ||
                    grid.dataItem($(grid.select()).parent());
                if (dataItem && dataItem.UniqueID) {
                    var rowIndex = parseInt(dataItem.UniqueID.substring(0, dataItem.UniqueID.indexOf('#')));
                    rowIndex = rowIndex + this.rowAdjustment();
                    try {
                        this.innerUpdating = true;
                        var columnIndex = (grid.options && grid.options.selectable === "row") ?
                            0 : $(grid.select()).index();
                        binding.set([rowIndex, columnIndex]);
                    }
                    finally {
                        this.innerUpdating = false;
                    }
                }
            },
            rowAdjustment: function () {
                var result = 0;
                if (this.bindings['flexGridDefinition'] && this.bindings['flexGridDefinition'].get) {
                    var binding = this.bindings['flexGridDefinition'];
                    var columnsValue = binding.get();
                    if (columnsValue &&
                        columnsValue.parent() &&
                        "FixedRowsCount" in columnsValue.parent()) {
                        result = columnsValue.parent().FixedRowsCount;
                    }
                }
                return result;
            }
        });
        kendo.data.binders.widget.flexGridEndSelection = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                var that = this;
                var grid = $(element.element).find('div').data('kendoGrid');
                if (grid) {
                    grid.bind('change', function () {
                        that.update(grid, that.bindings["flexGridEndSelection"]);
                    });
                }
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    var binding = this.bindings["flexGridEndSelection"];
                    var positionBinding = this.bindings["flexGridPosition"];
                    if (positionBinding) {
                        if (positionBinding.get()[0] == binding.get()[0]
                            && positionBinding.get()[1] == binding.get()[1]) {
                            return;
                        }
                        var position = positionBinding.get();
                        position[0] = position[0] - this.rowAdjustment();
                        var destination = binding.get();
                        destination[0] = destination[0] - this.rowAdjustment();
                        var grid = $(this.element.element).find('div').data('kendoGrid');
                        var htmlRow = grid.tbody.children().eq(binding.get()[0]);
                        grid.clearSelection();
                        for (var y = position[1]; y <= destination[1]; y++) {
                            for (var x = position[0]; x <= destination[0]; x++) {
                                this.selectCell(x, y, grid);
                            }
                        }
                    }
                }
            },
            selectCell: function (row, column, grid) {
                var htmlRow = grid.tbody.children().eq(row);
                if (htmlRow) {
                    if ((grid.options && grid.options.selectable === "row")) {
                        grid.select(htmlCell);
                    }
                    else {
                        var htmlCell = htmlRow.children('td').eq(column);
                        if (htmlCell && !htmlCell.hasClass('k-state-selected')) {
                            grid.select(htmlCell);
                        }
                    }
                }
            },
            rowAdjustment: function () {
                var result = 0;
                if (this.bindings['flexGridDefinition'] && this.bindings['flexGridDefinition'].get) {
                    var binding = this.bindings['flexGridDefinition'];
                    var columnsValue = binding.get();
                    if (columnsValue &&
                        columnsValue.parent() &&
                        "FixedRowsCount" in columnsValue.parent()) {
                        result = columnsValue.parent().FixedRowsCount;
                    }
                }
                return result;
            },
            update: function (grid, binding) {
                var dataItem = grid.dataItem(grid.select().last()) ||
                    grid.dataItem($(grid.select().last()).parent());
                if (dataItem && dataItem.UniqueID) {
                    var rowIndex = parseInt(dataItem.UniqueID.substring(0, dataItem.UniqueID.indexOf('#'))) + 1;
                    try {
                        this.innerUpdating = true;
                        var columnIndex = (grid.options && grid.options.selectable === "multiple row") ?
                            ($(grid.select().last()).children('td').length - 1) : $(grid.select().last()).index();
                        binding.set([rowIndex, columnIndex]);
                    }
                    finally {
                        this.innerUpdating = false;
                    }
                }
            }
        });
        kendo.data.binders.widget.flexCellCoordinates = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                var that = this;
                var grid = $(element.element).find('div').data('kendoGrid');
                if (grid) {
                    grid.bind('change', function () {
                        that.update(grid, that.bindings["flexCellCoordinates"]);
                    });
                }
            },
            refresh: function () { },
            update: function (grid, binding) {
                var selected = grid.select();
                if (selected) {
                    var height = Math.floor($(selected).height());
                    var width = Math.floor($(selected).width());
                    var pos = $(selected).position();
                    binding.set([pos.left, pos.top, width, height]);
                }
            }
        });
        kendo.data.binders.widget.flexGridDefinition = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var binding = this.bindings["flexGridDefinition"];
                if (binding) {
                    var that = this;
                    var value = binding.get();
                    if (value) {
                        value.bind('change', function () {
                            if (!that.isRefreshPending) {
                                that.isRefreshPending = true;
                                setTimeout(function () {
                                    try {
                                        that.refresh();
                                        that.element.trigger('reconfigured');
                                    }
                                    finally {
                                        that.isRefreshPending = false;
                                    }
                                }, 1);
                            }
                        });
                    }
                }
            },
            refresh: function () {
                var binding = this.bindings["flexGridDefinition"];
                var value = binding.get();
                var element = this.element.element[0];
                this.removeExistingInnerElement(element);
                this.createGridAsChild(element, binding.source, value);
            },
            transformColumnsToObj: function (cols) {
                var colsStr = [];
                for (var idx = 0; idx < cols.Items.length; idx++) {
                    var colDefinition = cols.Items[idx];
                    colsStr.push({
                        title: colDefinition.Text,
                        field: "RowContent[" + idx.toString() + "]",
                        width: colDefinition.Width
                    });
                }
                return colsStr;
            },
            removeExistingInnerElement: function (element) {
                $(element).children('div').each(function (index, subeelement) {
                    var existingGrid = $(subeelement).data('kendoGrid');
                    if (existingGrid) {
                        existingGrid.destroy();
                        $(subeelement).remove();
                    }
                });
                ///
            },
            createGridAsChild: function (element, source, columnsObject) {
                var that = this;
                var newElement = document.createElement("div");
                var role = document.createAttribute("data-role");
                role.value = "grid";
                var db = "source: " + $(element).attr('data-itemssource');
                var dbatt = document.createAttribute("data-bind");
                dbatt.value = db;
                newElement.setAttribute('data-role', 'grid');
                newElement.setAttribute('data-resizable', 'true');
                var pageSize = parseInt($(element).attr('data-pagesize')) || 15;
                var itemsSource = source.get($(element).attr('data-itemssource'));
                var itemsSourceUniqueId = itemsSource.UniqueID;
                var extraBindings = $(element).attr('data-gridbindings');
                if (extraBindings) {
                    newElement.setAttribute('data-bind', extraBindings);
                }
                element.appendChild(newElement);
                var selectionMode = $(element).attr('data-selectionmode') || "multiple cell";
                $(newElement).kendoGrid({
                    resizable: true,
                    scrollable: {
                        virtual: true
                    },
                    selectable: selectionMode,
                    //pageable: true,
                    dataSource: {
                        serverPaging: true,
                        pageSize: pageSize,
                        schema: {
                            data: "data",
                            total: "total"
                        },
                        transport: {
                            read: function (options) {
                                var t = new Date();
                                $.ajax({
                                    url: 'ResumeOperation/CollectiongPendingResults',
                                    type: "POST",
                                    headers: {
                                        WM: true
                                    },
                                    dataType: "json",
                                    data: { coluid: itemsSourceUniqueId, skip: options.data.skip, take: options.data.take },
                                    success: function (data, textStatus, jqXHR) {
                                        options.success(data);
                                    }
                                });
                            }
                        }
                    },
                    columns: this.transformColumnsToObj(columnsObject)
                });
                // setTimeout is required because the template may not be completely applied
                setTimeout(function () {
                    $(element).find('.k-widget').height("100%");
                    $(element).find('table').last().dblclick(function () {
                        that.element.trigger('dblclick');
                    });
                }, 100);
                kendo.bind($(element).children('div'), source);
            }
        });
        //treeView MouseUp event
        kendo.data.binders.widget.mouseUpEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                customEventBinding(that, element.element, "mouseup", "mouseUpEvent");
            },
            refresh: function () { }
        });
        kendo.data.binders.widget.treeDataSource = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                // Create a new empty data source to start with
                element.setDataSource(kendo.observableHierarchy([]));
                // Event handler used to synchronize checkboxes
                element.dataSource.bind('change', function (e) {
                    that.syncCheckedNodes(that, e);
                });
                var treeview = $(that.element.element).data("kendoTreeView");
                // Event handler to handle children
                element.bind('change', function (e) {
                    var selected = element.dataItem(element.select());
                    if (selected && selected.wmid) {
                        var dataSourceBinding = that.bindings["treeDataSource"];
                        var model = dataSourceBinding.get();
                        model.set('SelectedItemId', selected.wmid);
                    }
                });
                element.element.bind('click', function (e) {
                    var editable = $(this).attr('data-labeledit');
                    if (editable && (editable == "true")) {
                        var modelObj = e.target;
                        $(modelObj).bind('click', function () {
                            $(modelObj).prop('contentEditable', true);
                        });
                        $(modelObj).bind('blur', function () {
                            $(modelObj).removeAttr('contentEditable');
                            var binding = that.bindings["treeDataSource"];
                            var tree = binding.get();
                            var ds = that.element.dataSource.data();
                            for (var i = 0; i < tree.Items.length; i++) {
                                var modelObj = tree.Items[i];
                                var htmlElement = ds[i];
                                that.updateValues(that, modelObj, htmlElement);
                            }
                        });
                    }
                });
                that.initialHeight = $(element.element).attr('data-initialheight');
                that.imageListPrefix = $(element.element).attr('data-imagelistprefix');
                that.imageIndex = $(element.element).attr('data-imageIndex');
            },
            // Updating text when the labels are edited.
            updateValues: function (that, e, treeNode) {
                if (treeNode) {
                    var node = $(that.element.element).find("[data-uid='" + treeNode.uid + "']").children()[0];
                    if (node) {
                        var innerSpan = $(node).find("[class*='k-in']");
                        e.set('Text', innerSpan.text());
                    }
                    if (e.Items)
                        for (var i = 0; i < e.Items.length; i++) {
                            this.updateValues(that, e.Items[i], treeNode.items[i]);
                        }
                }
            },
            // Updating text when the labels are edited.
            updateVisibilities: function (that, e, treeNode, parentExpanded) {
                if (treeNode) {
                    e.set('IsVisible', parentExpanded);
                }
                if (e.Items)
                    for (var i = 0; i < e.Items.length; i++) {
                        this.updateVisibilities(that, e.Items[i], treeNode.items[i], treeNode.expanded);
                    }
            },
            // Synchronization of checkbox nodes
            syncCheckedNodes: function (that, e) {
                var binding = that.bindings["treeDataSource"];
                if (binding && binding.get()
                    && (e.field === 'checked'
                        || e.field === 'selected'
                        || e.field === 'expanded'
                        || e.field === 'isVisible')
                    && e.items
                    && e.items.length > 0) {
                    var tree = binding.get();
                    var field = e.field;
                    for (var i = 0; i < tree.Items.length; i++) {
                        that.syncingCheckedNodes(that, tree.Items[i], e.items, field);
                    }
                }
            },
            syncingCheckedNodes: function (that, modelTreeNode, treeNodes, field) {
                for (var i = 0; i < treeNodes.length; i++) {
                    var uiTreeNode = treeNodes[i];
                    if (uiTreeNode.wmid === modelTreeNode.UniqueID) {
                        var ht = $(uiTreeNode).html();
                        switch (field) {
                            case "checked": {
                                modelTreeNode.set('Checked', uiTreeNode.checked);
                                break;
                            }
                            case "selected": {
                                modelTreeNode.set('IsSelected', uiTreeNode.selected);
                                break;
                            }
                            case "expanded": {
                                modelTreeNode.set('IsExpanded', uiTreeNode.expanded);
                                that.updateVisibilities(that, modelTreeNode, uiTreeNode, modelTreeNode.parent().parent().IsExpanded);
                                break;
                            }
                        }
                    }
                }
                if (modelTreeNode && modelTreeNode.Items)
                    for (var i = 0; i < modelTreeNode.Items.length; i++) {
                        this.syncingCheckedNodes(that, modelTreeNode.Items[i], treeNodes, field);
                    }
            },
            createMirrorNodeFromModelNode: function (modelObj) {
                var that = this;
                var imageurl = undefined;
                if (that.imageListPrefix !== undefined)
                    if (modelObj.ImageIndex != null && modelObj.ImageIndex > -1)
                        imageurl = that.imageListPrefix + '.ImageStream' + modelObj.ImageIndex + ".png";
                    else if (that.imageIndex != null && that.imageIndex > -1)
                        imageurl = that.imageListPrefix + '.ImageStream' + that.imageIndex + ".png"; //Default image
                return kendo.observableHierarchy([{
                        text: modelObj.Text,
                        wmid: modelObj.UniqueID,
                        imageUrl: imageurl,
                        checked: modelObj.Checked,
                        expanded: modelObj.IsExpanded,
                        items: []
                    }])[0];
            },
            createMirrorStructure: function (parentItemsCollection, modelObj) {
                var that = this;
                var newObj = that.createMirrorNodeFromModelNode(modelObj);
                if (parentItemsCollection.isRoot) {
                    parentItemsCollection.pop();
                }
                parentItemsCollection.push(newObj);
                var element = $(that.element.element).find("[data-uid='" + newObj.uid + "']");
                var itemHeight = $(element).height();
                var dataSourceBinding = that.bindings["treeDataSource"];
                var model = dataSourceBinding.get();
                var vc = model.get('VisibleCount');
                if (!(vc && vc > 0) && (itemHeight > 0)) {
                    var visibleCount = Math.floor(that.initialHeight / itemHeight);
                    model.set('VisibleCount', visibleCount);
                }
                var newObj2 = parentItemsCollection[parentItemsCollection.length - 1];
                function syncItems(e) {
                    if ((e.action === 'add' || e.action === undefined)
                        && newObj2.items.length < modelObj.Items.length) {
                        for (var k = newObj2.items.length; k < modelObj.Items.length; k++) {
                            var innerObj = modelObj.Items[k];
                            var newInnerObj = that.createMirrorNodeFromModelNode(innerObj);
                            that.createMirrorStructure(newObj2.items, innerObj);
                        }
                    }
                    else if (e.action == 'remove' && ('index' in e)) {
                        newObj2.items.remove(newObj2[e.index]);
                    }
                    else {
                        horizontalSyncItems();
                    }
                }
                function horizontalSyncItems() {
                    for (var i = 0; i < newObj.items.length && i < modelObj.Items.length; i++) {
                        if (newObj.items[i] && modelObj.Items[i]
                            && newObj.items[i].wmid
                            && modelObj.Items[i].UniqueID
                            && newObj.items[i].wmid !== modelObj.Items[i].UniqueID) {
                            newObj.items[i].set("wmid", modelObj.Items[i].UniqueID);
                            newObj.items[i].set("text", modelObj.Items[i].Text);
                            newObj.items[i].set("checked", modelObj.Items[i].Checked);
                            newObj.items[i].set("items", modelObj.Items[i].Items);
                        }
                    }
                }
                var changeFunc = function (e) {
                    var oldChangeEventHandlers = modelObj._events.change || [];
                    try {
                        modelObj._events.change = [];
                        switch (e.field) {
                            case "Text":
                                {
                                    newObj2.set('text', modelObj.get(e.field));
                                    break;
                                }
                            case "_items":
                                {
                                    if (!(e.action && (e.action === 'itemchange'))) {
                                        syncItems(e);
                                    }
                                    break;
                                }
                            case "Items":
                                {
                                    if (!(e.action && (e.action === 'itemchange'))) {
                                        syncItems(e);
                                    }
                                    break;
                                }
                            case "IsExpanded":
                                {
                                    newObj2.set('expanded', modelObj.get(e.field));
                                    that.updateVisibilities(that, modelObj, newObj2, modelObj.parent().parent().IsExpanded);
                                    break;
                                }
                            case "Checked":
                                {
                                    newObj2.set('checked', modelObj.get(e.field));
                                    break;
                                }
                            case "ImageIndex":
                                {
                                    var imageurl = that.imageListPrefix + '.ImageStream' + modelObj.ImageIndex + ".png";
                                    newObj2.set('imageUrl', imageurl);
                                    break;
                                }
                            default:
                                {
                                    newObj2.set(e.field, modelObj.get(e.field));
                                    break;
                                }
                        }
                    }
                    finally {
                        //We restore the old Event Handlers
                        modelObj._events.change = oldChangeEventHandlers;
                    }
                };
                modelObj.unbind('change');
                modelObj.bind('change', changeFunc);
                newObj2.changeFunc = changeFunc;
                // Add existing items if available
                if ('Items' in modelObj) {
                    var itemsChangeFunc = function (e) {
                        if (e.action === "add") {
                            var idx = e.index === undefined ? 0 : e.index;
                            var innerObj = modelObj.Items[idx];
                            var newInnerObj = that.createMirrorNodeFromModelNode(innerObj);
                            that.createMirrorStructure(newObj2.items, modelObj.Items[idx]);
                        }
                    };
                    newObj2.itemsChangeFunc = itemsChangeFunc;
                    for (var k = 0; k < modelObj.Items.length; k++) {
                        this.createMirrorStructure(newObj2.items, modelObj.Items[k]);
                    }
                }
            },
            refresh: function () {
                var that = this;
                var treeDataSourceBinding = this.bindings["treeDataSource"];
                var labelEdit = $(this.element.element).data("LabelEdit");
                that.labelEdit = labelEdit;
                if (treeDataSourceBinding.get()) {
                    var bvalue = treeDataSourceBinding.get().Items;
                    var ds = this.element.dataSource;
                    var data = ds.data();
                    var callRefresh = function (f) {
                        // Skip for child object property change
                        if (data.lastfiredField && f.action === "itemchange" || f.action === "add") {
                            return;
                        }
                        else if (f.action === "remove" && ('index' in f)) {
                            data.remove(data[f.index]);
                        }
                        else {
                            that.refresh();
                        }
                    };
                    // Unregister a previous version of the 'refresh' callback if exist
                    // (this is needed to avoid multiple calls)
                    if (data.callRefresh) {
                        bvalue.unbind('change', callRefresh);
                    }
                    bvalue.bind('change', callRefresh);
                    // Keep a reference of the function in order to unregister it
                    data.callRefresh = callRefresh;
                    var oldCount = data.length;
                    data.isRoot = true;
                    for (var i = 0; i < bvalue.length; i++) {
                        var modelObj = bvalue[i];
                        that.createMirrorStructure(data, modelObj);
                    }
                }
            }
        });
        (function ($) {
            var ui = kendo.ui, Widget = ui.Widget;
            var wmflexgrid = Widget.extend({
                init: function (element, options) {
                    Widget.fn.init.call(this, element, options);
                },
                options: {
                    name: "wmflexgrid",
                    itemssource: ""
                },
                events: [
                    "reconfigured", "dblclick", "click"
                ]
            });
            ui.plugin(wmflexgrid);
            kendo.init($(document.body));
        })(jQuery);
        kendo.data.binders.widget.listBoxSelectedIndices = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                element.bind('change', function () {
                    _this.update();
                });
                element.bind('dataBound', function () {
                    _this.databound();
                });
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    this.selectionRestore(this.element.items(), this.bindings["listBoxSelectedIndices"].get());
                }
            },
            update: function () {
                try {
                    this.innerUpdating = true;
                    var selectedIndices = $.map(this.element.select(), function (item) { return $(item).index(); });
                    var listBoxSelectedIndicesBinding = this.bindings["listBoxSelectedIndices"];
                    $(this.element.element).trigger("clickEvent");
                    if (this.options.checkOnClick) {
                        var listBox = $(this.element.element).data('kendoCheckedListBox');
                        var data = listBox.dataSource.data();
                        for (var i = 0; i < selectedIndices.length; i++) {
                            var _checkedStatus = data[selectedIndices[i]].get("Checked");
                            if (!_checkedStatus) {
                                var control = $(this.element.element).find("[data-uid='" + data[selectedIndices[i]].uid + "']");
                                var checkbox = $(control).find('input');
                                $(checkbox).trigger("click");
                            }
                            else {
                                var control = $(this.element.element).find("[data-uid='" + data[selectedIndices[i]].uid + "']");
                                var checkbox = $(control).find('input');
                                $(checkbox).trigger("click");
                            }
                        }
                    }
                    listBoxSelectedIndicesBinding.set(selectedIndices);
                }
                finally {
                    this.innerUpdating = false;
                }
            },
            databound: function () {
                if (!this.innerUpdating) {
                    this.selectionRestore(this.element.items(), this.bindings["listBoxSelectedIndices"].get());
                }
            },
            selectionRestore: function (children, indices) {
                if (indices && indices.indexOf) {
                    children.each(function (i, element) {
                        var isSelected = $(element).hasClass('k-state-selected');
                        var colIndex = indices.indexOf(i);
                        if (colIndex != -1 && !isSelected) {
                            $(element).addClass('k-state-selected');
                        }
                        else if (colIndex == -1 && isSelected) {
                            $(element).removeClass('k-state-selected');
                        }
                    });
                }
            }
        });
        kendo.data.binders.widget.listBoxCheckedIndices = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                var that = this;
                element.bind('dataBound', function () {
                    _this.databound();
                });
                element.dataSource.bind('change', function (e) {
                    that.databound();
                });
            },
            databound: function () {
                if (!this.innerUpdating) {
                    this.selectionRestore(this.element.items(), this.element.dataSource.data());
                }
            },
            refresh: function () {
            },
            update: function () {
            },
            selectionRestore: function (children, data) {
                children.each(function (i, element) {
                    var checked = data[i].Checked;
                    if (checked) {
                        var checkbox = $(element).find('input');
                        if (checkbox) {
                            $(checkbox).prop("checked", "checked");
                        }
                    }
                    else if (checked) {
                        var checkbox = $(element).find('input');
                        if (checkbox)
                            checkbox.removeAttr('checked');
                    }
                });
            }
        });
        function checkedListBoxProc(element) {
            var listBox = $(element).parents('div[data-role="checkedlistbox"]').data('kendoCheckedListBox');
            var index = $(element).parent().index();
            if (listBox && index >= 0) {
                var data = listBox.dataSource.data();
                if (data && data[index]) {
                    data[index].set("Checked", element.checked);
                }
                $(listBox.element).trigger("itemCheck");
            }
        }
        Client.checkedListBoxProc = checkedListBoxProc;
        //CheckedListBox checkOnClick
        kendo.data.binders.widget.checkOnClick = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
                var that = this;
                var value = that.bindings["checkOnClick"].get();
                this.widget.setOptions({ checkOnClick: value });
            }
        });
        //ItemCheckEvent
        kendo.data.binders.widget.ItemCheckEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                customEventBinding(that, element.element, "itemCheck", "ItemCheckEvent");
            },
            refresh: function () { }
        });
        //ClickEvent
        kendo.data.binders.widget.ClickEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                customEventBinding(that, element.element, "clickEvent", "ClickEvent");
            },
            refresh: function () { }
        });
        var lastTextBoxOnFocus = null;
        kendo.data.binders.textBoxEnter = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                $(element).bind("focusin", function (event) {
                    if (document.activeElement !== lastTextBoxOnFocus) {
                        lastTextBoxOnFocus = element;
                        var binding = that.bindings["textBoxEnter"];
                        var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                        var method = binding.source.logic[methodName];
                        method.apply(binding.source, [event]);
                    }
                    else {
                        lastTextBoxOnFocus = null;
                    }
                });
            },
            refresh: function () { }
        });
        kendo.data.binders.selectedRange = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                this.requiresUpdate = true;
                $(element).bind('focus', function (e) {
                    this.requiresUpdate = false;
                    var binding = that.bindings["selectedRange"];
                    var bindingValue = binding.get();
                    var selectionStart = bindingValue[0];
                    var selectionEnd = bindingValue[1];
                    that.element.setSelectionRange(selectionStart, selectionEnd);
                });
                $(element).bind('select', function (e) {
                    if (this.requiresUpdate)
                        that.update();
                    else
                        this.requiresUpdate = true;
                });
            },
            update: function () {
                this.requiresUpdate = false;
                var selectedRangeBinding = this.bindings["selectedRange"];
                var caret = $(this.element).caret();
                console.log("Update: " + caret.start + " " + caret.end);
                selectedRangeBinding.set([caret.start, caret.end]);
            },
            refresh: function () { }
        });
        //NumericTextBox  Value
        kendo.data.binders.widget.NumericUpDownValue = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                var _this = this;
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                widget.bind('change', function () {
                    _this.update();
                });
            },
            update: function () {
                var that = this;
                var val = $(that.element).data("kendoNumericTextBox").value();
                that.bindings["NumericUpDownValue"].set(val);
            },
            refresh: function () {
                var that = this, value = that.bindings["NumericUpDownValue"].get(); //get the value from the View-Model
                $(that.element).data("kendoNumericTextBox").value(value); //update the widget
            }
        });
        //NumericTextBox Max Value
        kendo.data.binders.widget.NumericUpDownMax = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this, maxValue = that.bindings["NumericUpDownMax"].get(); //get the value from the View-Model
                $(that.element).data("kendoNumericTextBox").max(maxValue); //update the widget
                var currentValue = that.bindings["NumericUpDownValue"].get(); // get the current widget value
                (maxValue < currentValue) ? $(that.element).data("kendoNumericTextBox").value(maxValue) : $(that.element).data("kendoNumericTextBox").value(currentValue);
            }
        });
        //NumericTextBox Min Value
        kendo.data.binders.widget.NumericUpDownMin = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this, minValue = that.bindings["NumericUpDownMin"].get(); //get the value from the View-Model
                $(that.element).data("kendoNumericTextBox").min(minValue); //update the widget
                var currentValue = that.bindings["NumericUpDownValue"].get(); // get the current widget value
                (minValue > currentValue) ? $(that.element).data("kendoNumericTextBox").value(minValue) : $(that.element).data("kendoNumericTextBox").value(currentValue);
            }
        });
        //NumericTextBox Increment Value
        kendo.data.binders.widget.NumericUpDownIncrementVal = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this, value = that.bindings["NumericUpDownIncrementVal"].get(); //get the value from the View-Model
                $(that.element).data("kendoNumericTextBox").step(value); //update the widget
            }
        });
        kendo.data.binders.widget.refreshOnChange = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.timeout = 0;
            },
            refresh: function () {
                var that = this;
                /// The following code allows use to trigger just one refresh call for a batch of 
                // updates on the same list.
                if (that.timeout === 0) {
                    that.timeout = setTimeout(function () {
                        try {
                            that.element.refresh();
                        }
                        finally {
                            that.timeout = 0;
                        }
                    }, 1);
                }
            }
        });
        ////Masked Textbox Support
        //MaskedTextBox Mask 
        kendo.data.binders.widget.maskedTextBoxMask = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
                var that = this;
                var oldmask = this.widget.options.mask;
                var value = that.bindings["maskedTextBoxMask"].get();
                this.widget.setOptions({ mask: value });
                if (oldmask != "")
                    $(this.element).trigger("maskChanged");
            }
        });
        //MaskedTextBox promptChar
        kendo.data.binders.widget.maskedTextBoxPrompt = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
                var that = this;
                var value = that.bindings["maskedTextBoxPrompt"].get();
                this.widget.setOptions({ promptChar: value });
            }
        });
        //MaskedTextBox TextMaskFormat
        kendo.data.binders.widget.maskedTextBoxFormat = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            applyRefresh: function () {
                var that = this;
                var maskedValue = $(that.widget.element[0]).data("kendoMaskedTextBox").value();
                var valueBind = this.bindings["maskedTexBoxValue"];
                valueBind.set(maskedValue);
            },
            refresh: function () {
                ///This binding might be called during the sucess handler of a sendAction call.
                //Remember that communication with the backend is always thru the App.sendAction function
                //the sucess handler will sync the viewmodel deltas with the client.
                //In this case if this binding is call at this time
                //we just postpone the execution because this binding will update
                //a view model and we need its dirty mark to stay in order for these changes
                //to travel back to the server
                var that = this;
                var safe = window.app.Safe;
                safe.safeExec({
                    obj: that._value,
                    stage: WebMap.Client.ClientSyncronizationStage.CurrentlyUpdatingClientSide | WebMap.Client.ClientSyncronizationStage.UpdateClientSideAlmostComplete,
                    whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                    category: "requestAction",
                    action: function () { return setTimeout(function () { that.applyRefresh(); }, 300); }
                });
                safe.safeExec({
                    obj: that._value,
                    stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                    whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                    category: "requestAction",
                    action: function () { return that.applyRefresh(); }
                });
            }
        });
        //MaskedTextBox value
        kendo.data.binders.widget.maskedTexBoxValue = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
                widget.bind('change', function () {
                    that.update();
                });
            },
            refresh: function () {
                var that = this;
                var value = that.bindings["maskedTexBoxValue"].get();
                that.widget.value(value);
            },
            update: function () {
                var that = this;
                var maskedTB = $(that.widget.element[0]).data("kendoMaskedTextBox");
                var value = maskedTB.value();
                that.bindings["maskedTexBoxValue"].set(value);
            }
        });
        //MaskChangedEvent
        kendo.data.binders.widget.MaskChanged = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                customEventBinding(that, element.element, "maskChanged", "MaskChanged");
            },
            refresh: function () { }
        });
        //TypeValidationEvent
        kendo.data.binders.widget.TypeValidationCompleted = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                customEventBinding(that, element.element, "change", "TypeValidationCompleted");
            },
            refresh: function () { }
        });
        //MaskInputRejected 
        kendo.data.binders.widget.MaskInputRejected = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                $(element.element).bind("keypress", function (event) {
                    var binding = that.bindings["MaskInputRejected"];
                    var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                    var method = binding.source.logic[methodName];
                    var newChar = String.fromCharCode(event.charCode);
                    var position = ($(this).caret().start);
                    var currentMask = that.options.mask;
                    while (isLiteral(currentMask.charAt(position))) {
                        position++;
                    }
                    var match = maskToRegex(newChar, currentMask.charAt(position));
                    if (!match) {
                        method.apply(binding.source);
                    }
                });
            },
            refresh: function () { }
        });
        function maskToRegex(newChar, maskChar) {
            switch (maskChar) {
                case "0": {
                    return newChar.match(/\d/);
                }
                case "9": {
                    return newChar.match(/\d|\s/);
                }
                case "#": {
                    return newChar.match(/\d|\s|\+|\-/);
                }
                case "&": {
                    return newChar.match(/\S/);
                }
                case "?": {
                    return newChar.match(/[a-zA-Z]|\s/);
                }
                case "A": {
                    return newChar.match(/[a-zA-Z0-9]/);
                }
                case "C": {
                    return newChar.match(/./);
                }
                case "L": {
                    return newChar.match(/[a-zA-Z]/);
                }
                case "a": {
                    return newChar.match(/[a-zA-Z0-9]|\s/);
                }
                default: {
                    return newChar.match(new RegExp("/\\" + maskChar + "/"));
                }
            }
        }
        function isLiteral(char) {
            return char.match(/[^09#&?ACLa]/);
        }
        function customEventBinding(that, control, event, bindingName) {
            $(control).bind(event, function (event) {
                var binding = that.bindings[bindingName];
                var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                var method = binding.source.logic[methodName];
                method.apply(binding.source, [event]);
            });
        }
        var lastFiredEvent = "";
        function widgetCustomEventBinding(that, widget, event, bindingName) {
            widget.bind(event, function (event) {
                if (lastFiredEvent !== bindingName) {
                    lastFiredEvent = bindingName;
                    var binding = that.bindings[bindingName];
                    var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                    var method = binding.source.logic[methodName];
                    method.apply(binding.source);
                }
                else {
                    lastFiredEvent = "";
                }
            });
        }
        ///*******************DataGridViewSupport**********************
        function createNewDataGrid(element, source, columnsObject, thisElement) {
            var dataGridContainerID = $(element).attr('id');
            var newElement = document.createElement("div");
            newElement.setAttribute('data-role', 'grid');
            var uniqueID = source[dataGridContainerID].UniqueID;
            newElement.setAttribute('data-resizable', 'true');
            var newElementID = uniqueID + "_innerGrid";
            newElement.setAttribute('id', newElementID);
            var initialHeight = $(element).attr('data-initialheight');
            var addRows = $(element).attr('data-addRows');
            var db = ''; //Empty source used in case an initialized dataSource was passed.
            var dataSource;
            var useDataSource = $(element).data('datasource');
            if (!useDataSource) {
                db = $(element).attr('data-itemssource');
            }
            else {
                dataSource = getDataSource(uniqueID);
            }
            if (initialHeight !== undefined) {
                newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
            }
            var selectionMode = $(element).data('selectionmode');
            var kendoSelectionMode = "";
            switch ("" + selectionMode) {
                case "CellSelect":
                    kendoSelectionMode = "multiple, cell";
                    break;
                case "FullRowSelect":
                    kendoSelectionMode = "multiple, row";
                    break;
                case "RowHeaderSelect":
                    kendoSelectionMode = "multiple, cell";
                    break;
                default:
                    kendoSelectionMode = "multiple, cell";
                    break;
            }
            var allowReorder = Boolean($(element).data('allowreorder')) === true ? true : false;
            var edit = thisElement.bindings["DataGridEditable"].get();
            var addNewRows = thisElement.bindings["DataGridAddRows"];
            var cellClickEvent = $(element).attr('data-cellClickEvent');
            if (cellClickEvent) {
                db += ",events: { change: " + cellClickEvent + " }";
            }
            newElement.setAttribute('data-bind', db + "," + addRows);
            element.appendChild(newElement);
            $(newElement).kendoGrid({
                resizable: true,
                scrollable: true,
                columns: columnsObject,
                reorderable: allowReorder,
                selectable: kendoSelectionMode,
                editable: !edit,
                pageable: true,
                sortable: true,
                dataSource: dataSource
            });
            $(newElement).data('kendoGrid').dataSource.bind('change', function (e) {
                setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 10); //Removes the dirty flag
                //window.app.sendAction({ controller: "ResumeOperation", action: "DataGridViewSyncVals", parameters: { "uniqueID": uniqueID }});
                window.app.log('changed');
            });
            if (addNewRows && addNewRows.get()) {
                AddRowToolbar(newElement, addNewRows);
            }
            kendo.bind($(element).children('div'), source);
        }
        function getDataSource(uniqueID) {
            return {
                pageSize: 10,
                transport: {
                    read: {
                        url: "GridDatasource/GetDataSource?gridUid=" + encodeURIComponent(uniqueID),
                        dataType: "json",
                        contentType: "application/json"
                    }
                },
                schema: {
                    data: "data",
                    total: "total"
                },
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            };
        }
        //DataGridColumns Value
        kendo.data.binders.widget.DataGridColumns = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var binding = this.bindings["DataGridColumns"];
                if (binding) {
                    var that = this;
                    var value = binding.get();
                    if (value) {
                        value.bind('change', function () {
                            that.refresh();
                        });
                    }
                }
            },
            refresh: function () {
                var that = this;
                var binding = this.bindings["DataGridColumns"];
                var value = binding.get(); //get the value from the View-Model
                var columnsObj = transformColumnsToObj(value, this);
                var element = this.element;
                removeExistingListViewInnerElement(element);
                createNewDataGrid(element, binding.source, columnsObj, this);
            }
        });
        //DataGrid ReadOnly
        kendo.data.binders.widget.DataGridEditable = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
                var that = this;
                var value = that.bindings["DataGridEditable"].get();
                var gridDiv = $(this.element).children('div');
                $(gridDiv).data('kendoGrid').options.editable = !value;
            }
        });
        //DataGridViewDataSource
        kendo.data.binders.widget.DataSourceVersion = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function (e) {
                var that = this;
                var value = that.bindings["DataSourceVersion"].get();
                if (value > 0)
                    $(this.element).data("datasource", true);
            },
            update: function () {
            }
        });
        //DataGridAddRows
        kendo.data.binders.widget.DataGridAddRows = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
            }
        });
        //DataGridDeleteRows
        kendo.data.binders.widget.DataGridDeleteRows = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function (e) {
            },
            update: function () {
            }
        });
        function deleteRecords(event) {
            var row = $(event.currentTarget).closest("tr");
            var gridDiv = row.closest('div').parent();
            var dataGridID = gridDiv.attr('id').substring(0, gridDiv.attr('id').indexOf('_'));
            var dialogResult = dataGridID + '@' + row.index();
            window.app.sendAction({ controller: "ResumeOperation", action: "DataGridViewDeleteRow", parameters: { "uniqueID": dataGridID, "rowIndex": row.index() } });
        }
        function AddRowToolbar(gridDiv, binding) {
            $(gridDiv).data('kendoGrid').options.toolbar = ['create'];
            setTimeout(function () {
                var addButton = $(gridDiv).find('.k-header .k-grid-add');
                addButton.removeClass('k-grid-add'); //Remove Original addRow Code
                addButton.removeAttr('href');
                addButton.on('click', function () {
                    var dataGridName = binding.path.substring(0, binding.path.indexOf('.'));
                    var vmobj = binding.source[dataGridName];
                    window.app.sendAction({ mainobj: vmobj, controller: "ResumeOperation", action: "DataGridViewAddNewRow", uniqueID: vmobj.UniqueID });
                });
            }, 100);
        }
        (function ($) {
            var ui = kendo.ui, Widget = ui.Widget;
            var WMGrid = Widget.extend({
                init: function (element, options) {
                    Widget.fn.init.call(this, element, options);
                },
                options: {
                    name: "WMGrid",
                    mode: 1
                }
            });
            ui.plugin(WMGrid);
            kendo.init($(document.body));
        })(jQuery);
        /*********************** Component One TrueDBGrid ************************/
        function createNewTrueDBGrid(element, source, columnsObject, thisElement) {
            var dataGridContainerID = $(element).attr('id');
            var newElement = document.createElement("div");
            newElement.setAttribute('data-role', 'grid');
            var uniqueID = source[dataGridContainerID].UniqueID;
            newElement.setAttribute('data-resizable', 'true');
            var newElementID = uniqueID + "_innerGrid";
            newElement.setAttribute('id', newElementID);
            var initialHeight = $(element).attr('data-initialheight');
            var addRows = $(element).attr('data-addRows');
            var db = ''; //Empty datasource used in case an initialized dataSource was passed.
            var selectIndices = $(element).attr('data-selectedindices');
            if (selectIndices)
                db += "," + selectIndices;
            var dataSource;
            dataSource = getDataSource(uniqueID);
            var dblclickhandler = $(element).attr('data-doubleClickEvent');
            if (dblclickhandler) {
                db = db + ",listViewDoubleClick: " + dblclickhandler;
            }
            var headClickEvent = $(element).attr('data-headclickevent');
            if (headClickEvent) {
                db = db + ",trueDBGridHeadClick: " + headClickEvent;
                var colIndexBinding = $(element).attr('data-columnIndex');
                db += ",trueDBColumnIndex: " + colIndexBinding;
            }
            if (initialHeight !== undefined) {
                newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
            }
            var splits = thisElement.bindings["gridSplits"].get();
            var selectionMode = splits[0].MarqueeStyle;
            var kendoSelectionMode;
            switch (selectionMode) {
                case 0:
                    kendoSelectionMode = "multiple, row";
                    break;
                case 1:
                    kendoSelectionMode = "multiple, cell";
                    break;
                case 2:
                    kendoSelectionMode = false;
                    break;
                default:
                    kendoSelectionMode = "multiple, row";
                    break;
            }
            var allowReorder = Boolean($(element).data('allowreorder')) === true ? true : false;
            var edit = thisElement.bindings["trueDBGridAllowUpdate"].get();
            var cellClickEvent = $(element).attr('data-cellClickEvent');
            var clickEvent = $(element).attr('data-click');
            var events = "";
            var beforeColEdit = $(element).attr('data-beforeColEdit');
            if (beforeColEdit) {
                db += ",trueDBBeforeColEdit: " + beforeColEdit;
            }
            if (clickEvent) {
                db += ",trueDBClickEvent: " + clickEvent;
            }
            if (cellClickEvent) {
                events += ",trueDBClickEvent: " + cellClickEvent;
            }
            var rowColChangeEvent = $(element).attr('data-rowColChange');
            if (rowColChangeEvent) {
                db += ",trueDBRowColChangeEvent: " + rowColChangeEvent;
            }
            var selChangeEvent = $(element).attr('data-selChangeEvent');
            if (selChangeEvent) {
                db += ",trueDBSelChangeEvent: " + selChangeEvent;
            }
            if (events !== "") {
                db += ",events: { " + events + " }";
            }
            if (addRows)
                db += "," + addRows;
            newElement.setAttribute('data-bind', db);
            element.appendChild(newElement);
            var kendoPageable = true;
            var isPageable = $(element).attr('data-pageable');
            if (isPageable && isPageable === "false") {
                kendoPageable = false;
            }
            $(newElement).kendoGrid({
                resizable: true,
                scrollable: true,
                navigatable: true,
                pageable: kendoPageable,
                sortable: true,
                columns: columnsObject,
                reorderable: allowReorder,
                selectable: kendoSelectionMode,
                editable: edit,
                dataSource: dataSource,
                save: function (e) {
                    var columnKey = Object.keys(e.values)[0];
                    var value = e.values[columnKey];
                    window.app.sendAction({
                        controller: "GridDatasource",
                        action: "UpdateDataSourceRecord",
                        parameters: {
                            "uniqueID": uniqueID,
                            "rowIndex": e.model["RecordSetIndex"],
                            "columnIndex": e.container.index(),
                            "value": value
                        }
                    });
                    setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 1000);
                }
            });
            $(newElement).data('kendoGrid').dataSource.bind('change', function (e) {
                setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 10); //Removes the dirty flags
            });
            $(newElement).on("change", "input.chkbx", function (e) {
                var grid = $(newElement).data("kendoGrid"), dataItem = grid.dataItem($(e.target).closest("tr"));
                var colIndex = $(e.target).closest("td").index();
                dataItem.set("ItemContent[" + colIndex + "]", this.checked ? "True" : "False");
            });
            kendo.bind($(element).children('div'), source);
        }
        function ColumnsConverter(cols, thisElement) {
            var colsStr = [];
            var totalwidth = 0;
            var bindingSplits = thisElement.bindings["gridSplits"];
            var splits;
            if (bindingSplits) {
                splits = bindingSplits.get();
            }
            for (var idx = 0; idx < cols.length; idx++) {
                var colDefinition = cols[idx];
                if (jQuery.isFunction(cols[idx])) {
                    colDefinition = cols[idx]();
                }
                if (splits) {
                    var designerwidth = splits[0].DisplayColumns._items[idx].Width;
                    var extendRightColumn = splits[0].ExtendRightColumn;
                    if (extendRightColumn && idx === cols.length - 1) {
                        var gridWidth = $(thisElement.element).width();
                        designerwidth = gridWidth - totalwidth;
                    }
                    var visible = splits[0].DisplayColumns._items[idx].Visible;
                    var locked = splits[0].DisplayColumns._items[idx].Locked;
                    var width = designerwidth ? designerwidth : 65;
                    totalwidth += width;
                    var columnAlignment = getKendoAlignment(colDefinition.HorizontalAlignment);
                    var checkboxColumn = colDefinition.ValueItems.Presentation === 0;
                    if (checkboxColumn) {
                        var itemContent = "ItemContent[" + idx.toString() + "]";
                        colsStr.push({
                            field: itemContent,
                            title: colDefinition.Caption ? colDefinition.Caption : " ",
                            template: '<input type="checkbox" #=' + itemContent + ' == "True" ? checked="checked" : "" # class="chkbx"></input>',
                            sortable: false,
                            width: 25
                        });
                    }
                    else {
                        colsStr.push({
                            title: colDefinition.Caption ? colDefinition.Caption : " ",
                            field: "ItemContent[" + idx.toString() + "]",
                            format: colDefinition.NumberFormat,
                            attributes: {
                                style: "text-align: " + columnAlignment
                            },
                            headerAttributes: {
                                style: "text-align: " + columnAlignment
                            },
                            width: width,
                            hidden: !visible,
                            editor: locked ? ReadOnlyEditor : ''
                        });
                    }
                }
            }
            var deleteRows = thisElement.bindings["DataGridDeleteRows"];
            if (deleteRows) {
                var value = deleteRows.get();
                if (value) {
                    colsStr.push({
                        command: [{
                                name: 'deleteRecord',
                                text: 'Delete Record',
                                click: trueDBDeleteRecord,
                                imageClass: "ui-icon ui-icon-close"
                            }],
                        width: "100px"
                    });
                }
            }
            return colsStr;
        }
        function trueDBDeleteRecord(event) {
            var row = $(event.currentTarget).closest("tr");
            var gridDiv = row.closest('div').parent();
            var rowData = $(gridDiv).data('kendoGrid').dataItem(row);
            var dataGridID = gridDiv.attr('id').substring(0, gridDiv.attr('id').indexOf('_'));
            window.app.sendAction({ controller: "GridDatasource", action: "DeleteRecord", parameters: { "uniqueID": dataGridID, "rowIndex": rowData["RecordSetIndex"] } });
        }
        //Splits value
        kendo.data.binders.widget.gridSplits = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function (e) {
            },
            update: function () {
            }
        });
        //trueDBGridHeadClick
        kendo.data.binders.widget.trueDBGridHeadClick = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                $(element.element).find("th[role='columnheader']").bind("click", function (event) {
                    var binding = that.bindings["trueDBGridHeadClick"];
                    var colIndex = that.bindings["trueDBColumnIndex"];
                    var index = $(event.target).closest("th").index();
                    colIndex.set(index);
                    var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                    var method = binding.source.logic[methodName];
                    method.apply(binding.source);
                });
            },
            refresh: function () { }
        });
        //ColumnIndex
        kendo.data.binders.widget.trueDBColumnIndex = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () { }
        });
        //RowColChangeEvent
        kendo.data.binders.widget.trueDBRowColChangeEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                widgetCustomEventBinding(that, element, "change", "trueDBRowColChangeEvent");
            },
            refresh: function () { }
        });
        //BeforeColEdit
        kendo.data.binders.widget.trueDBBeforeColEdit = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                widgetCustomEventBinding(that, element, "edit", "trueDBBeforeColEdit");
            },
            refresh: function () { }
        });
        //SelChangeEvent
        kendo.data.binders.widget.trueDBSelChangeEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                widgetCustomEventBinding(that, element, "change", "trueDBSelChangeEvent");
            },
            refresh: function () { }
        });
        //ClickEvent
        kendo.data.binders.widget.trueDBClickEvent = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                widgetCustomEventBinding(that, element, "change", "trueDBClickEvent");
            },
            refresh: function () { }
        });
        //DataGridColumns Columns
        kendo.data.binders.widget.trueDBGridColumns = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var binding = this.bindings["trueDBGridColumns"];
                if (binding) {
                    var that = this;
                    var value = binding.get();
                    if (value) {
                        value.bind('change', function () {
                            that.refresh();
                        });
                    }
                }
            },
            refresh: function () {
                var that = this;
                var binding = this.bindings["trueDBGridColumns"];
                var value = binding.get(); //get the value from the View-Model
                var columnsObj = ColumnsConverter(value, this);
                var element = this.element;
                removeExistingListViewInnerElement(element);
                createNewTrueDBGrid(element, binding.source, columnsObj, this);
            }
        });
        //DataSourceVersion
        kendo.data.binders.widget.TrueDBDataSourceVersion = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            },
            refresh: function () {
                var that = this;
                var binding = that.bindings["TrueDBDataSourceVersion"];
                if (binding.get()) {
                    var value = that.bindings["trueDBGridColumns"].get();
                    var columnsObj = ColumnsConverter(value, this);
                    var element = this.element;
                    that.bindings["TrueDBDataSourceVersion"].set(false);
                    removeExistingListViewInnerElement(element);
                    createNewTrueDBGrid(element, binding.source, columnsObj, this);
                }
            }
        });
        //TrueDBGrid AllowUpdateBinding
        kendo.data.binders.widget.trueDBGridAllowUpdate = kendo.data.Binder.extend({
            init: function (widget, bindings, options) {
                //call the base constructor
                kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
                var that = this;
                this.widget = widget;
            },
            refresh: function () {
                var that = this;
                var value = that.bindings["trueDBGridAllowUpdate"].get();
                var gridDiv = $(this.element).children('div');
                $(gridDiv).data('kendoGrid').options.editable = value;
            }
        });
        var lastTrueDBGridSelectedCell;
        //TrueDBgrid SelectedIndices
        kendo.data.binders.widget.trueDBGridSelectedRows = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                this.innerUpdating = false;
                element.bind('change', function (e) {
                    var currentSelection = e.sender.select().attr('data-uid');
                    if (currentSelection !== lastTrueDBGridSelectedCell)
                        _this.update();
                    lastTrueDBGridSelectedCell = currentSelection;
                });
            },
            refresh: function () {
                if (!this.innerUpdating) {
                    var selectedIndexBinding = this.bindings["trueDBGridSelectedRows"];
                    var newIndex = selectedIndexBinding.get();
                    var grid = this.element.element;
                    if (grid)
                        grid = grid[0];
                    else
                        grid = this.element[0];
                    var items = null;
                    var kendoData = $(grid).data('kendoGrid');
                    if (kendoData) {
                        var isPageableGrid = kendoData.options.pageable;
                        var pageAdjustment = isPageableGrid ? ((kendoData.dataSource.page() - 1) * kendoData.pager.pageSize()) : 0;
                        var selectionMode = kendoData ? kendoData.options.selectable : "row";
                        if (selectionMode !== "multiple, cell") {
                            items = $(grid).find("[class='k-grid-content']").find('tr');
                            newIndex = newIndex.map(function (i) { return i - pageAdjustment; });
                            this.rowSelectionRestore(items, newIndex);
                        }
                        else {
                            items = $(grid).find("[class='k-grid-content']").find('tr');
                            this.cellSelectionRestore(items, newIndex);
                        }
                    }
                }
            },
            update: function () {
                var grid = this.element.element;
                var innerID = $(this.element.element).attr("id");
                var uniqueID = innerID.substring(0, innerID.indexOf("_innerGrid"));
                var gridData = $(grid).data('kendoGrid');
                var selectionMode = gridData.options.selectable;
                if (grid)
                    grid = grid[0];
                else
                    grid = this.element[0];
                var items = null;
                items = $(grid).find("[class='k-grid-content']").find('tr');
                var isPageableGrid = gridData.options.pageable;
                var pageAdjustment = isPageableGrid ? ((gridData.dataSource.page() - 1) * gridData.pager.pageSize()) : 0;
                var newIndices = [];
                if (selectionMode !== "multiple, cell") {
                    items.each(function (i, item) {
                        var isSelected = $(item).hasClass('k-state-selected');
                        if (typeof isSelected !== typeof undefined && isSelected !== false) {
                            newIndices.push(i + pageAdjustment);
                        }
                    });
                }
                else {
                    items.each(function (i, item) {
                        var cell = $(item).children('.k-state-selected');
                        if (cell && cell.length > 0) {
                            newIndices.push(i, $(cell).index());
                            return false;
                        }
                    });
                }
                this.bindings["trueDBGridSelectedRows"].set(newIndices);
                this.innerUpdating = false;
                if (newIndices.length > 0)
                    window.app.sendAction({ controller: "GridDatasource", action: "UpdateRecordSet", parameters: { "uniqueID": uniqueID, "selectedRow": newIndices[0] } });
            },
            destroy: function () {
                kendo.data.Binder.fn.destroy.call(this);
                this.element.unbind('dblclick');
            },
            rowSelectionRestore: function (children, indices) {
                if (indices) {
                    children.each(function (i, element) {
                        var colIndex = indices.indexOf(i);
                        if (colIndex != -1) {
                            $(element).addClass('k-state-selected');
                            $(element).attr('selected', 'true');
                        }
                        else if (colIndex == -1) {
                            $(element).removeClass('k-state-selected');
                            $(element).removeAttr('selected');
                        }
                    });
                }
            },
            cellSelectionRestore: function (children, indices) {
                if (indices) {
                    children.each(function (i, element) {
                        if (indices.length > 0 && indices[0] === i) {
                            var cell = $(element).children("td")[indices[1]];
                            if (cell) {
                                $(cell).addClass('k-state-selected');
                                $(cell).attr('selected', 'true');
                            }
                            return false;
                        }
                        else if (indices.length > 0 && indices[0] === i) {
                            $(element).children().removeClass('k-state-selected');
                            $(element).children().removeAttr('selected');
                        }
                    });
                }
            }
        });
        //// Widget definition
        (function ($) {
            var ui = kendo.ui, Widget = ui.Widget;
            var WMGrid = Widget.extend({
                init: function (element, options) {
                    Widget.fn.init.call(this, element, options);
                },
                options: {
                    name: "truedbgrid",
                    mode: 1
                }
            });
            ui.plugin(WMGrid);
            kendo.init($(document.body));
        })(jQuery);
        /////////////////
        /// Context Menu
        /////////////
        kendo.data.binders.widget.contextMenu = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var that = this;
                var parentForm = $(this.element).parents('form');
                var contextMenuId = that.bindings["contextMenu"].path.split(".")[1];
                var parentMenu = $('#' + contextMenuId).data("kendoContextMenu");
                parentMenu.setOptions({ filter: '.' + contextMenuId + 'Enabled' });
            }
        });
        kendo.data.binders.widget.contextMenuShow = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var that = this;
                var getShowValue = that.bindings["contextMenuShow"].get();
                if (getShowValue && getShowValue[0]) {
                    var contextMenu = $(that.element.element).data("kendoContextMenu");
                    contextMenu.open(getShowValue[2], getShowValue[3]);
                    $(contextMenu.element).parent().css('z-index', 2147483647); //fix ContextMenu appears behind windows.
                }
            }
        });
        //////////
        /// Widget Style
        ///////////
        function getValue(obj, path) {
            for (var i = 0, path = path.split('.'), len = path.length; i < len; i++) {
                if (!obj || obj[path[i]] === undefined)
                    return undefined;
                obj = obj[path[i]];
            }
            ;
            return obj;
        }
        //Style Custom binding 
        kendo.data.binders.widget.style = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var _this = this;
                var self = this;
                var binding = self.bindings["style"];
                Object.keys(binding).forEach(function (key) {
                    var source = binding[key].source;
                    var cssValPath = binding[key].path;
                    if (source && cssValPath) {
                        var value = getValue(source, cssValPath);
                        if (value) {
                            $(_this.element.element).css(key, value);
                        }
                    }
                }, self);
            }
        });
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
var UpgradeHelpers;
(function (UpgradeHelpers) {
    var ControlArray = (function () {
        function ControlArray() {
        }
        ControlArray.indexOf = function (ctrlArray, e) {
            return ctrlArray.indexOf(Events.getEventSender(e));
        };
        return ControlArray;
    }());
    UpgradeHelpers.ControlArray = ControlArray;
    var Events = (function () {
        function Events() {
        }
        Events.getEventSender = function (e) {
            var isEvent = (e.target != undefined);
            var id = isEvent ? e.target.id : e.id;
            var viewModel = isEvent ? e.data : e.ViewModel;
            var controlArrayRefRegex = /^_(.+)_([0-9]+)/;
            var eventSender = undefined;
            if (controlArrayRefRegex.test(id)) {
                eventSender = viewModel.get(id.replace(controlArrayRefRegex, "$1[$2]"));
            }
            else
                eventSender = viewModel.get(id);
            return eventSender;
        };
        return Events;
    }());
    UpgradeHelpers.Events = Events;
    var EventKey = (function () {
        function EventKey() {
        }
        EventKey.getKeyChar = function (e) {
            return String.fromCharCode(this.getKeyCode(e));
        };
        EventKey.setKeyChar = function (e, key) {
            this.setKeyCode(e, key.charCodeAt(0));
        };
        EventKey.getKeyCode = function (e) {
            return (e.keyCode ? e.keyCode : e.which);
        };
        EventKey.setKeyCode = function (e, key) {
            if (key != 0 && key != this.getKeyCode(e)) {
                var eventSender = Events.getEventSender(e);
                eventSender.set("Text", eventSender.Text + String.fromCharCode(key));
                this.handleEvent(e, true);
            }
        };
        EventKey.handleEvent = function (e, value) {
            if (value) {
                e.preventDefault();
            }
        };
        return EventKey;
    }());
    UpgradeHelpers.EventKey = EventKey;
    (function (Keys) {
        Keys[Keys["A"] = 65] = "A";
        Keys[Keys["Add"] = 43] = "Add";
        Keys[Keys["Alt"] = 18] = "Alt";
        /*        Apps,
                Attn,*/
        Keys[Keys["B"] = 66] = "B";
        Keys[Keys["Back"] = 8] = "Back";
        /*        BrowserBack,
                BrowserFavorites,
                BrowserForward,
                BrowserHome,
                BrowserRefresh,
                BrowserSearch,
                BrowserStop,*/
        Keys[Keys["C"] = 67] = "C";
        /*        Cancel,*/
        Keys[Keys["Capital"] = 20] = "Capital";
        Keys[Keys["CapsLock"] = 20] = "CapsLock";
        Keys[Keys["Clear"] = 46] = "Clear";
        Keys[Keys["Control"] = 17] = "Control";
        Keys[Keys["ControlKey"] = 17] = "ControlKey";
        /*        Crsel,*/
        Keys[Keys["D"] = 68] = "D";
        Keys[Keys["D0"] = 48] = "D0";
        Keys[Keys["D1"] = 49] = "D1";
        Keys[Keys["D2"] = 50] = "D2";
        Keys[Keys["D3"] = 51] = "D3";
        Keys[Keys["D4"] = 52] = "D4";
        Keys[Keys["D5"] = 53] = "D5";
        Keys[Keys["D6"] = 54] = "D6";
        Keys[Keys["D7"] = 55] = "D7";
        Keys[Keys["D8"] = 56] = "D8";
        Keys[Keys["D9"] = 57] = "D9";
        Keys[Keys["Decimal"] = 44] = "Decimal";
        Keys[Keys["Delete"] = 46] = "Delete";
        Keys[Keys["Divide"] = 47] = "Divide";
        Keys[Keys["Down"] = 40] = "Down";
        Keys[Keys["E"] = 69] = "E";
        Keys[Keys["End"] = 35] = "End";
        Keys[Keys["Enter"] = 13] = "Enter";
        /*        EraseEof,*/
        Keys[Keys["Escape"] = 27] = "Escape";
        /*        Execute,
                Exsel,*/
        Keys[Keys["F"] = 70] = "F";
        Keys[Keys["F1"] = 112] = "F1";
        Keys[Keys["F10"] = 121] = "F10";
        Keys[Keys["F11"] = 122] = "F11";
        Keys[Keys["F12"] = 123] = "F12";
        /*        F13,
                F14,
                F15,
                F16,
                F17,
                F18,
                F19,*/
        Keys[Keys["F2"] = 113] = "F2";
        /*        F20,
                F21,
                F22,
                F23,
                F24,*/
        Keys[Keys["F3"] = 114] = "F3";
        Keys[Keys["F4"] = 115] = "F4";
        Keys[Keys["F5"] = 116] = "F5";
        Keys[Keys["F6"] = 117] = "F6";
        Keys[Keys["F7"] = 118] = "F7";
        Keys[Keys["F8"] = 119] = "F8";
        Keys[Keys["F9"] = 120] = "F9";
        /*        FinalMode,*/
        Keys[Keys["G"] = 71] = "G";
        Keys[Keys["H"] = 72] = "H";
        /*        HanguelMode,
                HangulMode,
                HanjaMode,
                Help,*/
        Keys[Keys["Home"] = 36] = "Home";
        Keys[Keys["I"] = 73] = "I";
        /*        IMEAccept,
                IMEAceept,
                IMEConvert,
                IMEModeChange,
                IMENonconvert,*/
        Keys[Keys["Insert"] = 45] = "Insert";
        Keys[Keys["J"] = 74] = "J";
        /*        JunjaMode,*/
        Keys[Keys["K"] = 75] = "K";
        /*        KanaMode,
                KanjiMode,
                KeyCode,*/
        Keys[Keys["L"] = 76] = "L";
        /*        LaunchApplication1,
                LaunchApplication2,
                LaunchMail,
                LButton,*/
        Keys[Keys["LControlKey"] = 17] = "LControlKey";
        Keys[Keys["Left"] = 37] = "Left";
        /*        LineFeed,
                LMenu,*/
        Keys[Keys["LShiftKey"] = 16] = "LShiftKey";
        /*        LWin,*/
        Keys[Keys["M"] = 77] = "M";
        /*        MButton,
                MediaNextTrack,
                MediaPlayPause,
                MediaPreviousTrack,
                MediaStop,
                Menu,
                Modifiers,*/
        Keys[Keys["Multiply"] = 42] = "Multiply";
        Keys[Keys["N"] = 78] = "N";
        /*        Next,
                NoName,
                None,*/
        Keys[Keys["NumLock"] = 144] = "NumLock";
        Keys[Keys["NumPad0"] = 48] = "NumPad0";
        Keys[Keys["NumPad1"] = 49] = "NumPad1";
        Keys[Keys["NumPad2"] = 50] = "NumPad2";
        Keys[Keys["NumPad3"] = 51] = "NumPad3";
        Keys[Keys["NumPad4"] = 52] = "NumPad4";
        Keys[Keys["NumPad5"] = 53] = "NumPad5";
        Keys[Keys["NumPad6"] = 54] = "NumPad6";
        Keys[Keys["NumPad7"] = 55] = "NumPad7";
        Keys[Keys["NumPad8"] = 56] = "NumPad8";
        Keys[Keys["NumPad9"] = 57] = "NumPad9";
        Keys[Keys["O"] = 79] = "O";
        /*        Oem1,
                Oem102,
                Oem2,
                Oem3,
                Oem4,
                Oem5,
                Oem6,
                Oem7,
                Oem8,
                OemBackslash,
                OemClear,
                OemCloseBrackets,
                Oemcomma,
                OemMinus,
                OemOpenBrackets,
                OemPeriod,
                OemPipe,
                Oemplus,
                OemQuestion,
                OemQuotes,
                OemSemicolon,
                Oemtilde,*/
        Keys[Keys["P"] = 80] = "P";
        /*        Pa1,
                Packet,*/
        Keys[Keys["PageDown"] = 34] = "PageDown";
        Keys[Keys["PageUp"] = 33] = "PageUp";
        /*        Pause,
                Play,
                Print,
                PrintScreen,
                Prior,
                ProcessKey,*/
        Keys[Keys["Q"] = 81] = "Q";
        Keys[Keys["R"] = 82] = "R";
        /*        RButton,*/
        Keys[Keys["RControlKey"] = 17] = "RControlKey";
        Keys[Keys["Return"] = 13] = "Return";
        Keys[Keys["Right"] = 39] = "Right";
        /*        RMenu,*/
        Keys[Keys["RShiftKey"] = 16] = "RShiftKey";
        /*        RWin,*/
        Keys[Keys["S"] = 83] = "S";
        /*        Scroll,
                Select,
                SelectMedia,
                Separator,*/
        Keys[Keys["Shift"] = 16] = "Shift";
        Keys[Keys["ShiftKey"] = 16] = "ShiftKey";
        /*        Sleep,
                Snapshot,*/
        Keys[Keys["Space"] = 32] = "Space";
        Keys[Keys["Subtract"] = 45] = "Subtract";
        Keys[Keys["T"] = 84] = "T";
        Keys[Keys["Tab"] = 9] = "Tab";
        Keys[Keys["U"] = 85] = "U";
        Keys[Keys["Up"] = 38] = "Up";
        Keys[Keys["V"] = 86] = "V";
        /*        VolumeDown,
                VolumeMute,
                VolumeUp,*/
        Keys[Keys["W"] = 87] = "W";
        Keys[Keys["X"] = 88] = "X";
        /*        XButton1,
                XButton2,*/
        Keys[Keys["Y"] = 89] = "Y";
        Keys[Keys["Z"] = 90] = "Z";
    })(UpgradeHelpers.Keys || (UpgradeHelpers.Keys = {}));
    var Keys = UpgradeHelpers.Keys;
    var Sound = (function () {
        function Sound() {
        }
        Sound.getBeep = function () {
            return new Sound();
        };
        Sound.prototype.Play = function () {
            // TODO: to be implemented
            //throw "Sound.Play needs to be implemented";
        };
        return Sound;
    }());
    UpgradeHelpers.Sound = Sound;
    var Strings = (function () {
        function Strings() {
        }
        Strings.convertToString = function (obj) {
            return obj == null ? null : obj.toString();
        };
        Strings.format = function (obj, format) {
            // TODO: to be implemented
            //throw "String.format needs to be implemented";
            return obj.toString();
        };
        return Strings;
    }());
    UpgradeHelpers.Strings = Strings;
})(UpgradeHelpers || (UpgradeHelpers = {}));
//# sourceMappingURL=WebMap.all.js.map