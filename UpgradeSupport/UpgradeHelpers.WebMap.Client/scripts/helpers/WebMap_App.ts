/// <reference path="WebMap_Interfaces.ts" />

module WebMap.Client {
    export enum SafeExecutionConditions {
        Ignore = 1,
        QueueForLater = 2
    }

    export interface IActionSafeExecution {
        obj: IStateObject,
        action: () => void,
        stage: ClientSyncronizationStage,
        whenNotAtThatStage: SafeExecutionConditions,
        category: string,
        abortWhenPreviousActionIsInExecution?: boolean
    }

    export enum ClientSyncronizationStage {
        NotUpdatingClientSideYet = 2,
        CurrentlyUpdatingClientSide = 4,
        UpdateClientSideAlmostComplete = 8,
		SendActionTriggered = 16
    }

    export class SafeActionExecutionManager {
        private app: App;
        constructor(app: App) {
            this.app = app;
        }
        public pendingBindings: { [id: string]: any; } = {};
        public pendingBindingInExecution: string;
        public executedBindings: { [id: string]: any; } = {};
        public kendoBinds: { [id: string]: any; } = {};
        public pendingSendActionCallBacks: any[] = [];

        // updateClientSideState is a flag that shows when the Application is processing the UpdateClientSide method.
        // 0 means 'Not updating client side yet'
        // 1 means 'Currently updating client side'
        // 2 means 'Update Client side completed'
        // Example code: 
        // if (window.app.updateClientSideState < 2) {
        //		window.app.registerPendingBinding(that._value, doSomeThing)
        // else doSomeThing()
        public updateClientSideState: ClientSyncronizationStage = ClientSyncronizationStage.NotUpdatingClientSideYet;

        public safeExec(args: IActionSafeExecution): void {
            //Are we in the requested stage?
            if ((this.updateClientSideState & args.stage) != 0) {
                args.action();
            }
            else {
                if (args.whenNotAtThatStage === SafeExecutionConditions.QueueForLater)
                    this.registerPendingBinding(args.obj, args.action, args.category);
                //else ignore
            }
        }

        public Async(action: () => any): JQueryPromise<any> {
            action();
            return this.getSendActionPromise();
        }

        public getSendActionPromise(): JQueryPromise<any> {
            return window.app.sendActionPromise;
        }

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
        public registerPendingBinding(obj: IStateObject, func: () => void, category = undefined): void {
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
        }

        public executePendingBindings() {
            this.executedBindings = {};
            var topBindings: { [id: string]: any; } = this.pendingBindings;
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
                    var key = bindKeys[0]
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
                        } finally {
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
        }
    }
    /**
      * This class represents a WebMap client side application, it is responsible for starting up the application and
      * manage the communication with de server side of a WebMap application
      */
    export class App {

        public static Current: App;
        public ViewManager: IViewManager;
        public inActionExecution: boolean;
        public sendActionPromise: JQueryPromise<any>;

        private updateListeners: any[];
        private eventsQueue: any[];

        public isClosingView: boolean;
        public Safe: SafeActionExecutionManager;
        pendingUnBindedEx: {array:IStateObject, events: Array<any>}[]  = [];
        pendingUnBindedExDictonary = {};

        private executeUnBindedEx(array: any, lambda: (array: any) => void) {
            var oldChangeEventHandlers = array._events.change || [];
            var length = this.pendingUnBindedEx.push({
                array: array, events: oldChangeEventHandlers
            });
            this.pendingUnBindedExDictonary[array.UniqueID] = length - 1;
            //Now we unbind the event handler
            array._events.change = [];
            lambda(array);

        }
        constructor() {
            this.Safe = new SafeActionExecutionManager(this);

        }
		public actionInExecution: string;
		public servier: number;




        public info(text: any) {
            //console.info(text);
        }

        public log(text: any) {
            //console.log(text);
        }

        /**
         *Static constructor that creates singleton objects
         */
        private static Init() {
            if (!App.Current) {
                App.Current = new App();
                App.Current.ViewManager = new ViewManager();
            }
            window.app = WebMap.Client.App.Current;
            //At the app Start we need to have a resolved promise so code does not get queued
            var deferred = $.Deferred();
            deferred.resolve();
            window.app.sendActionPromise = deferred.promise();
        }

        public static Start(customClientTypeRegistrations: (app: WebMap.Client.App) => void): void {
            if (!window["app"]) {
                WebMap.Client.App.Init();
            }
            var settings: JQueryAjaxSettings = { url: "TypeInfo/GetAll", type: "POST" };
            WebMap.Client.App.Current.doBlockUI(0);
            try {
            $.ajax(settings).done(function (data: any) {
                window["typesInfo"] = data.TypesInfo;
                window["defaultsInfo"] = data.DefaultsAndAlias;
                    window["emptyObjs"] = {};
                    WebMap.Client.App.Current.undoBlockUI();
                //Get current app state from server
                customClientTypeRegistrations && customClientTypeRegistrations(window["app"]);
                    try {
                $.ajax({
                    url: "Home/AppState",
                    success: (data: WebMapResponse) => {
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
        }

        public getControlRole(control: IStateObject): string {
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
        }

        public getControlType(typeTag: number): string {
            var controlType = window["typesInfo"][typeTag];
            return (controlType || "typenotfound");
        }

        public getControlTypeID(typeName: string): number {
            var types = window["typesInfo"];
            var keys = Object.getOwnPropertyNames(types);
            for (var i = 0; i < keys.length; i++) {
                var key = keys[i];
                if (types[key] == typeName) {
                    return parseInt(key);
                }
            }
            return -1;
        }

        /**
         *Inits the WebMap application before the first screen is rendered.  This method must be invoked from
         * the main html page just before any other action is performed.
         */
        public Init(models, viewsState: ViewState,modelTypes?: number[]) {
            Container.Init();
            StateManager.Init();
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
            require(requirements, () => {
            this.InitModels(models,modelTypes);
            this.InitUI(viewsState);
            this.eventsQueue = new Array<string[]>();
            StateManager.Current.clearDirty();
            },
                (err) => {
                    console.error("Error loading requirement: " + err.requireModules + " the application might not work. Loading dummy module");
                    var currentModule = err.requireModules[0];
                    if (currentModule) {
                        require.undef(currentModule);
                        define(currentModule, [], () => { });
                        require([currentModule], () => { window.app.info("Loading dummy module for " + currentModule); });
                    }
                });


        }


        /**
         * Adds a listener to be called to update the model data
         */
        public addModelUpdateListener(l: () => any) {
            if (l) {
                if (!this.updateListeners)
                    this.updateListeners = [l];
                else
                    this.updateListeners.push(l);
            }
        }

        /**
         * Removes the given listener
         */
        public removeModelUpdateListener(l: () => any) {
            var ul = this.updateListeners;
            if (ul) {
                var idx = ul.indexOf(l);
                if (idx >= 0)
                    ul.splice(idx, 1);
            }
        }

        /**
         * Calls the registered listeners in order to update the model data
         */
        private callModelUpdateListeners() {
            var ul = this.updateListeners;
            if (ul) {
                for (var i = 0, len = ul.length; i < len; i++)
                    ul[i]();
            }
        }

        /**
        *  Sends a request to the WebMap server side application.  After call is made, the method updates the 
        * WebMap client side app in order to refresh all changes performed by server side logic, to achieve that the 
        * updateClientSide and UpdateMessages methods are called.
         */
        public sendAction(options: AppActionOptions, forced = false): JQueryPromise<any> {
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

        }

        private doBlockUI(time) {
            $.blockUI();
        }

		private undoBlockUI() {
            $.unblockUI();
        }

        private doServerCall(that: App, url: string, actionParamStr: string, forced: boolean, promise: JQueryDeferred<any>): JQueryPromise<any> {
            that.inActionExecution = true;
			that.actionInExecution = url;
            var deffered: JQueryDeferred<any>;
			var n1 = window.performance.now();
            if (promise != null)
                deffered = promise;
            else
                deffered = $.Deferred();

            $.ajax({
                url: url,
                type: "POST",
                headers:
                {
                    WM: true
                },

                dataType: "json",
                data: actionParamStr,
                beforeSend: () => {
                    if (!forced)
                        (<any>window).timeoutForActions = that.doBlockUI(1500);
                },

                complete: (jqXHR: JQueryXHR, textStatus: string) => {
					var n2 = window.performance.now();
                    var d = n2 - n1;
                    that.servier = d;
                    if ((<any>window).timeoutForActions) {
                        clearTimeout((<any>window).timeoutForActions);
                    }
					this.undoBlockUI();
                },

                success: (data: any, textStatus: string, jqXHR: JQueryXHR) => {
                    //Error reported!
                    if (data.ErrorOcurred) {
                        MessageBoxCommandHandler.showGenericMessage(data.ExMessage + "<pre>" + data.ExStackTrace + "<pre\>");
                        this.inActionExecution = false;
                        that.undoBlockUI();
                        return false;
                    }

                    //Timeout ocurred
                    if (data.SessionTimeOut) {
                        if ((<any>window).timeoutForActions) {
                            clearTimeout((<any>window).timeoutForActions);
                        }
                        this.inActionExecution = false;
                        this.undoBlockUI();
                        Client.MessageBoxCommandHandler.showSessionExpiredMessage();
                        return;
                    }

                    if (that.checkFlag(data, "SessionTimeOut")) {
                        //showConfirmDialog("Session Timeout", "Your session has ended. You need to logon again");
                    }
                    else if (that.checkFlag(data, "DoLogoff")) {
                        //goHome();
                    }
                    else if (that.checkFlag(data, "CloseApp")) {
                        window.close();
                    }
                    else {
                        this.Safe.updateClientSideState = ClientSyncronizationStage.CurrentlyUpdatingClientSide;
                        var requirements = [];
                        for (var i = 0; i < data.MDT.length; i++) {
                            if (data.MDT[i] % 10 == 0) { //This is done only for usercontrols
                                var dependency = "usercontrols/" + window.app.getControlType(data.MDT[i]);
                                if (dependency.indexOf("UpgradeHelpers") == -1 && dependency.indexOf("typenotfound") == -1 && !requirejs.defined(dependency)) {
                                    requirements.push(dependency);
                        }
                        }
                        }
                        window.app.log("Loading dependencies [" + requirements + "]");
                        require(requirements, () => {
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
                        StateManager.Current.clearDirty();
                    }
                },
                            (err) => {
                                console.error("Error loading requirement: " + err.requireModules + " the application might not work. Loading dummy module");
                                var currentModule = err.requireModules[0];
                                require.undef(currentModule);
                                define(currentModule, [], () => { });
                                require([currentModule], () => { window.app.info("Loading dummy module for " + currentModule); });
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
        }

        /**
         * updates the given model object with the information stored in delta.
         */
        private applyDelta(model: IStateObject, delta: any) {
            //We must verify that model is an ObservableObject
            if ((<any>model).set) {
                for (var prop in delta) {
                    if (prop == "@k") continue;
                    /*if ((prop in model) && (<any>model).set) {*/
                    try {

                        (<kendo.data.ObservableObject><any>model).set(prop, delta[prop]);
                    } catch (applyDeltaExceptionInner) {
                        console.error("App::applyDelta Error trying to set property for object UniqueId: " + model.UniqueID + " Property " + prop + " Message " + applyDeltaExceptionInner);
                    }
                    //}
                }
            }
        }

        /**
         * Builds an url action request based in the values gieven in options.
         */
        private buildActionUrl(options: AppActionOptions): string {
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
        }

        /**
         * Builds a JSON request based in the values given in options
         */
        private buildJSONRequest(options: AppActionOptions): string {
            var request: WebMapRequest =
                {
                    dirty: StateManager.Current.getDirty(),
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
        }

        private checkFlag(data: any, flagName: string): boolean {
            return false;
        }

        /**
          * When models are received, it might be needed to transverse those collections
          * to collect some information or to modify some aspects of the JSON message
          * to do that Client Type Behaviors can be associated to JSON packages, based on their
          * client type mark. Examples are Collections processing and StateObjectReferences
          */
        public preOrganizeModels(models: any[], modelTypes: any[]) {
            for (var i = 0; i < models.length; i++) {
                var model = models[i];
                var typeBehaviourHandler = ClientTypeBehaviourManager.Current.getBehaviour(model);
                if (typeBehaviourHandler) {
                    models[i] = typeBehaviourHandler.preOrganizeAction(model);
                }
            }
        }

        /**
         *  Execs any actions registered during the preOrganizeModel phase
         */
        public postOrganizeModels() {
            //Pointers and others pending actions
            ClientTypeBehaviourManager.Current.execPostOrganizeActions();
        }


        public bindPendingEventsForWidgetItems(isContextMenu = false, alwaysBind = false) {
            var dynamicEventsBehaviourManager: DynamicEventClientTypeBehaviour = <DynamicEventClientTypeBehaviour>ClientTypeBehaviourManager.Current.getBehaviourByID(5);

            dynamicEventsBehaviourManager.bindEventsForPendingItems(isContextMenu, alwaysBind);
        }
        
		private executePendingSendActions()
		{
			if ((<any>window).timeoutForActions) {
				clearTimeout((<any>window).timeoutForActions);
			}
			if (this.eventsQueue.length > 0) {
                //(<any>window).timeoutForActions = this.doBlockUI(1500);
				var opts = this.eventsQueue.shift();
				this.doServerCall(this, opts[0], opts[1], true, opts[2]);
			} else {
				this.inActionExecution = false;
			}

		}


        /**
        *  models and modelTypes are supposed to be arrays of the same length
        *  there for each i-th entry in models there is an i-th entry in modelTypes that has
        *  the model associated type id
        *  if modelTypes is 
        */
        public associateModelTypes(models: any[], modelTypes: number[]) {
            if (modelTypes && modelTypes.length) {
                for (var i = 0; i < modelTypes.length; i++) {
                    var model = models[i];
                    var modelType = modelTypes[i];
                    if (model && modelType && !model["@k"] /* we should not set model type if the model already has one*/) {
                        model["@k"] = modelType;
                    }
                }
            }
        }

        /**
          *  Creates the IViewModel objects for every model object in "models".  Models is an array of json data sent from the 
          *  server side, where every element contains a set of property/value describing the view model object.
          */
        public InitModels(models: any[], modelTypes: number[] = undefined) {
            this.Safe.updateClientSideState = ClientSyncronizationStage.CurrentlyUpdatingClientSide;
            try {
            this.associateModelTypes(models, modelTypes);
            //Execute Preorganize actions
                this.preOrganizeModels(models, modelTypes);
            var controlArrays: any[] = [];
            for (var i = 0; i < models.length; i++) {
                var current = models[i];
                if (!current) continue; //Skip undefineds
                var vm: IViewModel = <IViewModel>Container.Current.Resolve({ vm: true, data: current, dirty: false });
                if (vm instanceof kendo.data.ObservableArray)
                    controlArrays.push({ controlArray: vm, delta: vm });
                if (vm.Name && vm.Name.indexOf("UserControl") == 0) {

                    var logic = vm["logic"] = Client.Container.Current.Resolve({ "cons": App.Current.ViewManager.getConstructor(vm) });
                    logic.ViewModel = vm;
                    //this.usercontrols = this.usercontrols || [];
                    //this.usercontrols.push(logic);
                }
            }
                this.WakeUpArrayElements(controlArrays);
                var options: any = {};
                options.cache = models;
            //Child models must be connected to entry in the cache
            StateManager.Current.organize(options);
                this.FinishWakeUpArrayElements();
            this.postOrganizeModels();
            }
            catch (initModelEx) {
                console.error("InitModel error " + initModelEx);
            }
            finally {
                this.Safe.updateClientSideState = ClientSyncronizationStage.NotUpdatingClientSideYet;
            }

        }

        /**
          *  Initializes the UI object for the first time.  This method must be called when the user first access the 
          *  WebMap app and it is responsible for creating the first loaded windows (main window and/or login screen probably!).
          *  This method must be called after InitModels method because it requires view model to be already set.
          *  viewState :  Json object sent from server side containing the information of loaded views.
          */
        private InitUI(viewState: ViewState) {

            var that = this;
            this.showLoadingSplash();
            var def = $.Deferred();
            var modalViews = viewState.ModalViews;

            //All view navigation are promises. If there are several views
            //we must collect all promises and wait for all of them to finish
            var viewNavigationPromises: Array<JQueryPromise<BaseLogic>> = [];

            //Are there any views?
            if (viewState.LoadedViews) {
                for (var i = 0; i < viewState.LoadedViews.length; i++) {
                    var current: IViewModel = viewState.LoadedViews[i];
                    // gets the matching view model object from the state cache and then navigates to the view.
                    var viewModel: IViewModel = <IViewModel>StateManager.Current.getObject(current.UniqueID);
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
            $.when.apply(this, viewNavigationPromises).then(function () { that.removeLoadingSplash() }).then(() => {
                this.dispatchCommands(viewState);
            });
            return def.promise();
        }

        /**
         * removes the blocking UI message
         */
        private removeLoadingSplash(): void {
            this.undoBlockUI();
        }

        /** shows a blocking UI message */
        private showLoadingSplash(): void {
            $.blockUI({ message: "Loading app views" });
        }

        /** Updates the interaction messages sent from the server side in order to show them to the 
        end user */
        private dispatchCommands(viewData: any): JQueryPromiseCallback<any> {
            if (viewData && viewData.Commands) {
                CommandHandlerManager.Current.dispatchAll(viewData.Commands);
            }
            return null;
        }





        private FinishWakeUpArrayElements() {
            for (var i = 0; i < this.pendingUnBindedEx.length; i++) {
                var item = this.pendingUnBindedEx[i];
                var array:any = item.array;
                var events = item.events;
                array._events.change = array._events.change.concat(events);
            try {
                    (<kendo.Observable>array).trigger("change");
            }
            catch (ex) {
            }
        }
        }

        private WakeUpArrayElements(controlArrays: any[]) {
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
					curr.controlArray.uids= curr.delta.uids;
                }

                var uidarray = curr.delta.uids;
                var listtype = curr.delta.ltype;
                for (var innerIndex = 0; innerIndex < uidarray.length; innerIndex++) {
                    if (listtype == 1 /* Value Type */)
                        curr.controlArray.push(uidarray[innerIndex]);
                    else if (listtype == 4 /* Object Type*/) {
                        var uid = uidarray[innerIndex].toString();
                        var value = StateManager.Current.getObjectLocal(uid);
                        if (value) {
                            // If the value is an IStateObject
                            this.InsertIStateObjectIntoTheArray(curr.controlArray, value, uid);
                                }
                        else /* If the value is a Value Type */
                            curr.controlArray.push(uidarray[innerIndex]);
                                }
                    else {
                        if (uidarray[innerIndex]) {
                            var uid = uidarray[innerIndex].toString();
                            var value = StateManager.Current.getObjectLocal(uid);
                            if (value) {
                                this.InsertIStateObjectIntoTheArray(curr.controlArray, value, uid);
                            } else curr.controlArray.push({ UniqueID: "" });
                        } else
                            curr.controlArray.push({ UniqueID: "" });
                    }
                }
                curr.controlArray.Count = curr.delta.Count;
            }
        }

        private InsertIStateObjectIntoTheArray(array, value, uid): void {
            if (value instanceof kendo.data.ObservableArray) {
                //If the value is an array, this means that we are having list of lists.
                //When we evaluates value.parent(), kendo will return undefined,
                //so we need to set a parent for this value,
                //because in the BuildParentFromUniqueID depends on the parent
                //of each item of the list in order to build the binding expression.
                value["__parent"] = array;
            }
            array.push(value);
            (<any>array)[uid] = value;
            if (value) {
                if (!value[UniqueIDGenerator.ReferencesIdentifier])
                    value[UniqueIDGenerator.ReferencesIdentifier] = [];
                value[UniqueIDGenerator.ReferencesIdentifier].push(array.UniqueID);
            }
        }


        private getDeltaWithId(uniqueID: string, deltaData: any): any {
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
        }


        private processRemovedIds(data: any): void {
            if (data.length) {
                for (var i = 0; i < data.length; i++) {
                    var id = data[i];
                    if (id in (<any>StateManager.Current)._cache) {
						StateManager.Current.removeReferences(id);
                        delete (<any>StateManager.Current)._cache[id];
                    }
                }
            }
        }

        private processSwitchedIds(data: any, deltaData: any): void {
            var collectionsToCheck = {};
            // the assumed format for 'data' is [ [id1_1,id1_2], [id2_1,id2_2] ... ]
            for (var i = 0; i < data.length; i++) {
                var pair = data[i];
                if (pair.length === 2) {
                    var id1 = pair[0];
                    var id2 = pair[1];
                    var id1Parts = id1.split(UniqueIDGenerator.UniqueIdSeparator);
                    var index1 = id1Parts.shift();
                    var id2Parts = id2.split(UniqueIDGenerator.UniqueIdSeparator);
                    var index2 = id2Parts.shift();
                    //if (id1Parts.shift() == "_items" && id2Parts.shift() == "_items") {
                    var list1Id = id1Parts.join(UniqueIDGenerator.UniqueIdSeparator);
                    var list2Id = id2Parts.join(UniqueIDGenerator.UniqueIdSeparator);
                    // locate the collections
                    var collection1 = <kendo.data.ObservableArray><any>StateManager.Current.getObjectLocal(list1Id);
                    var collection2 = <kendo.data.ObservableArray><any>StateManager.Current.getObjectLocal(list2Id);
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
                        delete (<any>StateManager.Current)._cache[id1];
                        (<any>StateManager.Current)._cache[id2] = tmp;
                    }
                    //We might have observable arrays or something else
                    //We need to check if this case applies to pointers
                    //because pointers must be handled differently
                    else if (id1.indexOf("->") < 0) {
                        var tmp = (<any>StateManager.Current)._cache[id1];
                        if (tmp) {
                            tmp.UniqueID = id2;
                        // Remove the origin slot from the cache
                        delete (<any>StateManager.Current)._cache[id1];
                        (<any>StateManager.Current)._cache[id2] = tmp;

                            //Lets check the list of references.
                            // If the referenced object is an observable array
                            // we have to update its key to the new key.                            
                            var references = tmp[UniqueIDGenerator.ReferencesIdentifier];
                            if (references) {
                                for (var i = 0; i < references.length; i++) {
                                    var referencedObject = (<any>StateManager.Current).getObjectLocal(references[i]);
                                    if (referencedObject &&
                                        (referencedObject instanceof kendo.data.ObservableArray ||
                                            (referencedObject.length != null && referencedObject.length > 0))) {
                                        if (referencedObject[id1]) {
                                            delete referencedObject[id1];
                                            var endIndex = id2.indexOf(referencedObject.UniqueID);
                                            if (endIndex > 0) {
                                                var newId = id2.substring(0, endIndex - 1);
                                                referencedObject[newId] = tmp;
                                            } else if(endIndex != -1) {
                                                referencedObject[id2] = tmp;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else {
                        //This is a pointer. 
                        //pointers are not switched
                    }
                }
            }
            //Fill any gaps on the collections 
            for (var listId in collectionsToCheck) {
                var collection = collectionsToCheck[listId];
                for (var j = 0; j < collection.length; j++) {
                    if (collection[j] === undefined) {
                        //We build uniqueId to array element
                        var id = j.toString() + UniqueIDGenerator.UniqueIdSeparator + listId;
                        var deltaObj = this.getDeltaWithId(id, deltaData);
                        if (deltaObj) {
                            collection[j] = deltaObj;
                            (<any>StateManager.Current)._cache[id1] = deltaObj;
                        }
                    }
                }
            }
        }
        /**
          *  This method must be called to handle the server side response to an action, it is responsible for updating
          *  client side data out from server side changes.  Responsibilities include:
          *  1. Initialize view models for every new view 
          *  2. Update view model objects with server side changed information (delta)
          *  3. Display any shown view
          *  4. Update view changes (position, z-order, visibility)
          *  5. Remove any closed view
          */
        private updateClientSide(data: WebMapResponse, actionDeffered: JQueryDeferred<any>, n1: any): void {
            var that = this;
            var isThereAnyNewModels = false;
            //MOBILIZE,08/12/2016,TODO,CEBR-MRF-JQR, this change is required because of the change in promises in updateClientSide method
            var areThereAnyNewViews = false;
            if (data) {
                var deffered = $.Deferred();
                var lastPromise: JQueryPromise<BaseLogic> = deffered.promise();
                if (data.VD) {
                    this.ViewManager.RemoveViews(data.VD);
                }
                if (data.SW) {
                    this.processSwitchedIds(data.SW, data.MD);
                }
                if (data.MD) {
                    var modelsToBeOrganized: any[] = [];
                    //We will collect all uniqueIDs that were sent, to restrict the 
                    //organizeAction ONLY to those objects
                    var lastUniqueIDs: string[] = [];
                    var controlArrays: any[] = [];
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
                        if (!modelUpdateEntry) continue;
                        var lastUniqueIDs: string[] = [];

                        var delta = modelUpdateEntry;
			//Checks if the View is new or not.
                        var isNewView = newViews[i] == '1' ? true : false;
                        if(isNewView) modelsToBeOrganized.push(modelUpdateEntry);
                        var entry = StateManager.Current.getObjectLocal(modelUpdateEntry.UniqueID);
                        if (entry && ((delta["@k"] == entry["@k"] && delta.UniqueID == entry.UniqueID) || !isNewView)) {
                            if (entry instanceof kendo.data.ObservableArray)
                                controlArrays.push({ controlArray: entry, delta: delta });
                            else
                                that.applyDelta(entry, delta);
                        } else
						{
							if (!isNewView)
								console.log(delta.UniqueID + " say it's not new but is not here. Inconsistent.");
							if (entry)
								StateManager.Current.ClearViewReferences(entry.UniqueID);
                            //This is a new model.
                            isThereAnyNewModels = true;
                            //We will "Resolve it from the Container"
                            var vm: IViewModel = entry = <IViewModel>Container.Current.Resolve({ vm: true, data: delta, dirty: false });
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
                        var newModels: IViewModel[] = [];
                        for (var i = 0; i < data.VD.NewViews.length; i++) {
                            var uid = data.VD.NewViews[i];
                            var obj = <IViewModel>StateManager.Current.getObjectLocal(uid);
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
                            var uidParent = UniqueIDGenerator.getParent(uniqueID);
                            var parent = window["$cache"][uidParent];
                            if (parent && parent["@k"]) {
                                var parentType = parent["@k"];
                                var uidChild = UniqueIDGenerator.getLastToken(uniqueID);
                                var idOfElement = WebMap.Utils.getNameFromAlias(parentType, uidChild);
                                var topElement = UniqueIDGenerator.getFirstToken(uniqueID);
                                var queryStr = "#" + topElement;
                                for (var i = 1; i <= data.VD.CurrentFocusedControl.length - 1; i++) {
                                    var uidParentParent = UniqueIDGenerator.getParent(data.VD.CurrentFocusedControl[i]);
                                    var parentParent = window["$cache"][uidParentParent];
                                    var parentParentType = parentParent["@k"];
                                    var uidParentChild = UniqueIDGenerator.getLastToken(data.VD.CurrentFocusedControl[i]);
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
                        StateManager.Current.organize(options);
                        }
                        this.FinishWakeUpArrayElements();
                    }
                    catch (ExpCatch)
                    {
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
						ClientTypeBehaviourManager.Current.execPostShowViewsActions();
						StateManager.Current.clearDirty();
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
        }


    }

}
