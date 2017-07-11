/// <reference path="kendo.all.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="require.d.ts" />
/// <reference path="jquery.caret.d.ts" />
declare module WebMap.Client {
    interface TryGetValueResult<T> {
        HasValue: boolean;
        Value: T;
    }
    interface IStorageSerializer {
        Serialize(obj: any): any;
    }
    interface IPromise {
    }
    interface DictionaryStringTo<TV> {
        [uniqueID: string]: TV;
    }
    interface AppActionOptions {
        controller?: string;
        action?: string;
        mainobj: IStateObject;
        parameters?: DictionaryStringTo<any>;
        useblockui?: boolean;
        dialogResult?: string;
    }
    interface Message {
        UniqueID: string;
        text: string;
        buttons?: number;
        icons?: number;
        promptMesage?: string;
        Continuation_UniqueID?: string;
        caption?: string;
    }
    interface IIocContainer {
        Resolve(options?: any): any;
    }
    interface IStateObject {
        UniqueID: string;
    }
    interface IViewModel extends IStateObject {
        Name: string;
    }
    interface ILogicView {
        ViewModel: IViewModel;
        Init(): void;
        Close(): void;
    }
    interface IViewManager {
        /**
          * Closes a view in the client side.  This method handles form closing when the user clicks
          * the close box control and no binding to server side events has been added.
          */
        CloseView(view: IViewModel): any;
        /**
          * Fills up the JSONWebMapRequest object with the delta information provided by the
          * ViewManager
          */
        PrepareDelta(requestInfo: JSONWebMapRequest): any;
        RemoveViews(data: any): void;
        UpdateView(view: IViewModel, viewInfo: any): void;
        NavigateToView(viewModel: IViewModel): JQueryPromise<BaseLogic>;
        ShowMessage(message: string, caption: string, buttons: any, boxIcons: any): IPromise;
        LoadView(logic: ILogicView, domElement: any): JQueryPromise<any>;
        getConstructor(vm: IViewModel): () => ILogicView;
    }
}
declare module WebMap.Client {
    /**
      * Defines a class that contains information about the View changes.  This class
      * is used to interchange data between client and server calls.
      */
    class ViewState {
        LoadedViews: IViewModel[];
    }
    class JSONWebMapRequest {
        JSONWebMapRequest(): void;
        dirty: DictionaryStringTo<any>;
        vm: string;
        closedViews: string[];
        parameters: DictionaryStringTo<any>;
        dialogResult: string;
    }
    class ViewInfo {
        UniqueID: string;
        ZOrder: number;
        Visible: boolean;
    }
    class ViewsState {
        LoadedViews: ViewInfo[];
    }
}
declare module WebMap.Client {
    interface IClientTypeBehaviour {
        cons: (jsonData: any) => any;
        preOrganizeAction: (jsonData: any) => any;
    }
    class ClientTypeBehaviourManager {
        static Current: ClientTypeBehaviourManager;
        private static handlers;
        private postOrganizeActions;
        registerHandler(id: number, handler: IClientTypeBehaviour): void;
        getBehaviour(obj: any): IClientTypeBehaviour;
        registerPostOrganizeAction(action: () => void): void;
        execPostOrganizeActions(): void;
        static Init(): any;
        static staticinit: any;
    }
    class ArraysClientTypeBehaviour implements IClientTypeBehaviour {
        static Init(): any;
        private itemsCollections;
        cons(jsonData: any): any;
        private postActionRegistered;
        preOrganizeAction(jsonData: any): any;
        static staticinit: any;
    }
    class StateObjectPointerClientTypeBehaviour implements IClientTypeBehaviour {
        static Init(): any;
        private pointers;
        cons(jsonData: any): any;
        private postActionRegistered;
        preOrganizeAction(jsonData: any): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    interface ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
    }
    interface ICommand {
        id: string;
        parameters: any;
    }
    class CommandHandlerManager {
        static Current: CommandHandlerManager;
        private static handlers;
        registerHandler(id: string, handler: ICommandHandler): void;
        dispatchAll(commands: ICommand[]): void;
        static InitCommandHandlerManager(): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    class BaseUserControl {
        options: {
            name: string;
            value: any;
            css: string;
            template: string;
            uiinitialized: boolean;
        };
        _old: any;
        _value: any;
        element: any;
        applyTemplate(value: any): any;
        initStyles(): void;
        initClientMethods(value: any): void;
        init(element: any, options: any): void;
        refresh(): void;
        buildUI(): void;
        value(val: any): any;
        _update(value: any): void;
    }
}
declare module WebMap.Client {
    class MessageBoxCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        private static showMessageDialog(cmd);
        private static preparteMessageBoxTemplate(msg);
        private static getMessageBoxIconCssClass(id);
        static showSessionExpiredMessage(): void;
        static showGenericMessage(messageText: string): void;
        static InitMessageBoxHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    /**
      * Prints a message to the console for debugging purposes
      */
    function debug(e: any): void;
    /**
      * Checks that the given id is a new view
      */
    function IsNewView(id: string, VD: any): boolean;
    function showMessage(msg: string): void;
}
declare module WebMap.Utils {
    function IsClassSet(classes: string, cls: string): boolean;
    function RemoveClass(classes: string, cls: string): string;
}
declare module WebMap.Kendo {
    function setupBinding(binding: kendo.data.Binder, previousBinding: kendo.data.Binder, setups: BindingSetup[]): void;
    class BindingSetup {
        setup(binding: kendo.data.Binder): boolean;
    }
}
declare module WebMap.Client {
    class Container implements IIocContainer {
        static Current: Container;
        static Init(): void;
        Resolve(options?: any): any;
    }
}
declare module WebMap.Client {
}
declare module WebMap.Client {
    /**
      * This class represents a WebMap client side application, it is responsible for starting up the application and
      * manage the communication with de server side of a WebMap application
      */
    class App {
        static Current: App;
        ViewManager: IViewManager;
        inActionExecution: boolean;
        clientSynchronizationActive: boolean;
        private updateListeners;
        private eventsQueue;
        /**
         *Static constructor that creates singleton objects
         */
        static Init(): void;
        /**
         *Inits the WebMap application before the first screen is rendered.  This method must be invoked from
         * the main html page just before any other action is performed.
         */
        Init(models: any, viewsState: ViewState): void;
        isSynchronizingClient(): any;
        /**
         * Adds a listener to be called to update the model data
         */
        addModelUpdateListener(l: () => any): void;
        /**
         * Removes the given listener
         */
        removeModelUpdateListener(l: () => any): void;
        /**
         * Calls the registered listeners in order to update the model data
         */
        private callModelUpdateListeners();
        /**
        *  Sends a request to the WebMap server side application.  After call is made, the method updates the
        * WebMap client side app in order to refresh all changes performed by server side logic, to achieve that the
        * updateClientSide and UpdateMessages methods are called.
         */
        sendAction(options: AppActionOptions): JQueryPromise<any>;
        private doServerCall(that, url, actionParamStr, forced);
        /**
         * updates the given model object with the information stored in delta.
         */
        private applyDelta(model, delta);
        /**
         * Builds an url action request based in the values gieven in options.
         */
        private buildActionUrl(options);
        /**
         * Builds a JSON request based in the values given in options
         */
        private buildJSONRequest(options);
        private checkFlag(data, flagName);
        private extractItemsCollectionInfo(data);
        /**
          * When models are received, it might be needed to transverse those collections
          * to collect some information or to modify some aspects of the JSON message
          * to do that Client Type Behaviors can be associated to JSON packages, based on their
          * client type mark. Examples are Collections processing and StateObjectReferences
          */
        preOrganizeModels(models: any[]): void;
        /**
        *  models and modelTypes are supposed to be arrays of the same length
        *  there for each i-th entry in models there is an i-th entry in modelTypes that has
        *  the model associated type id
        *  if modelTypes is
        */
        associateModelTypes(models: any[], modelTypes: number[]): void;
        /**
          *  Creates the IViewModel objects for every model object in "models".  Models is an array of json data sent from the
          *  server side, where every element contains a set of property/value describing the view model object.
          */
        InitModels(models: any[], modelTypes?: number[]): void;
        /**
          *  Initializes the UI object for the first time.  This method must be called when the user first access the
          *  WebMap app and it is responsible for creating the first loaded windows (main window and/or login screen probably!).
          *  This method must be called after InitModels method because it requires view model to be already set.
          *  viewState :  Json object sent from server side containing the information of loaded views.
          */
        private InitUI(viewState);
        /**
         * removes the blocking UI message
         */
        private removeLoadingSplash();
        /** shows a blocking UI message */
        private showLoadingSplash();
        /** Updates the interaction messages sent from the server side in order to show them to the
        end user */
        private dispatchCommands(viewData);
        private extractItemsCollectionInfoFromDeltas(MD);
        /** This function unbinds the change events handlers executes a given lambda and then rebinds the events back to the observable array
        After executing the lambda a change event is triggered */
        private executeUnBinded(array, lambda);
        /**
          *  The purpose of this function is to syncronize the contents of an ObservableArray
          *  that it already on the client with the deltas that were received from the server
          *  after a sendAction call
          */
        private syncControlArraysSize(controlArrays);
        private getDeltaWithId(uniqueID, deltaData);
        private processRemovedIds(data);
        private processSwitchedIds(data, deltaData);
        /**
          *  This method must be called to handle the server side response to an action, it is responsible for updating
          *  client side data out from server side changes.  Responsibilities include:
          *  1. Initialize view models for every new view
          *  2. Update view model objects with server side changed information (delta)
          *  3. Display any shown view
          *  4. Update view changes (position, z-order, visibility)
          *  5. Remove any closed view
          */
        private updateClientSide(data);
    }
}
declare module WebMap.Client {
    /**
      * (Not implementet yet!) Provides an storage area where to serialize IStateObject objects to.
      * The default persistent layer would be the WebMap server side object.
      */
    class StorageManager {
        _storageSerializer: IStorageSerializer;
        /**
          * Tries the gets an object from the storage area.
          * @param uniqueId The id of the object to get.
          */
        TryGetValue(uniqueId: string): JQueryPromise<TryGetValueResult<IStateObject>>;
        /**
          * Persists the StateCache object into the storage area.
          * @param stateCache The StateCache object to persist.
          */
        Persist(stateCache: StateManager): void;
        /**
          * Saves an object to the storage area.
          * @param uniqueId  The id of ghe object to serialize
          * @param serializedValue The value to serialize.
          */
        SaveEntry(uniqueID: string, serializedValue: any): void;
    }
}
declare module WebMap.Client {
    class DeltaTracker {
        attachedObjs: DictionaryStringTo<IStateObject>;
        dirtyTable: DictionaryStringTo<boolean>;
        dirtyPropertiesTable: DictionaryStringTo<DictionaryStringTo<boolean>>;
        isDirty(obj: IStateObject): boolean;
        constructor();
        updateDirtyPropertiesTable(fieldName: any, uid: any): void;
        /**
         * Checks if the object has an UniqueID or it is an AttachedUniquedID
         * AttachedUniqueIds cannot have $$$
         */
        private static IsAttached(obj);
        /**
         * Look for the first parent of the current object that has an AttachedUniqueID and marks it as
         * dirty, so the whole object will be send on the next sendAction call
         */
        private climbToNearestAttachedObjectAndMarkItDirty(item);
        changeTracker(e: any): any;
        _changeDelegate: any;
        /** Register an object for change tracking */
        attachModel(obj: IStateObject, markAsDirty?: boolean): void;
        reset(): void;
        start(): void;
        getDeltas(): void;
        wasModified(variable: IStateObject): boolean;
        getJSONFromFullObject(obj: any): any;
        getCalculatedDeltaFor(variable: any): any;
    }
}
declare module WebMap.Client {
    class ViewManager implements IViewManager {
        private _logic;
        closedViews: string[];
        constructor();
        CloseView(view: IViewModel): void;
        PrepareDelta(requestInfo: JSONWebMapRequest): void;
        UpdateView(view: IViewModel, viewInfo: any): void;
        RemoveViews(data: any): void;
        NavigateToView(viewModel: IViewModel): JQueryPromise<BaseLogic>;
        ShowMessage(message: string, caption: string, buttons: any, boxIcons: any): IPromise;
        private static DESIGNERSUPPORT;
        static removeDesignerSupportSnippet(document: string): string;
        /**
         * Safely compiles an html template for a view
         */
        static CompileView(viewName: string, htmlTemplate: string): any;
        LoadView(logic: ILogicView, domElement?: any): JQueryPromise<any>;
        static AddCssIfMissing(href: any): void;
        private DisposeView(viewModelId);
        getConstructor(vm: IViewModel): () => ILogicView;
        static getViewHtmlURL(viewName: any, extension: string, isLib?: boolean): string;
        private IsRemovedView(id, VD);
    }
}
declare module WebMap.Client {
    class UniqueIDGenerator {
        static UniqueIdSeparator: string;
    }
    class StateManager {
        static Current: StateManager;
        private _storageManager;
        private _cache;
        private _tracker;
        static Init(): void;
        constructor();
        /**
          *We use the term "organize" to refer to actions
          * of using the UniqueIDs to reconnect objects in an object hierarchy.
          * UniqueIDs are allways like Panel1#0002 that means Panel1 property inside
          * a top level object identified by 0002 you can use
          * the shortcut $cache to watch the current models state
          */
        organize(options?: any): void;
        processObject(obj: IStateObject): void;
        addNewObject(obj: IStateObject, markAsDirty?: boolean): any;
        getDirty(): DictionaryStringTo<any>;
        getObjectLocal(uniqueId: string): IStateObject;
        clearDirty(): void;
        getObject(uniqueId: string): JQueryPromise<any>;
        RemoveView(id: string): void;
    }
}
declare module WebMap.Client {
    /**
     * Implements an ILogicView<T> interface.
     * The typescript code for all forms must inherit from this class
     * Descendants must override the Init Method to sed the template to be used
     *
     */
    class BaseLogic implements ILogicView {
        static options: {
            template: (data: any) => string;
        };
        ViewModel: any;
        private timersToCleanup;
        /**
         * Gets the associated view from the ViewManage.LoadView (it could imply a web call) and then
         * calls BuildUI to initalize it
         */
        Init(): void;
        /**
         * Intializes the view elements using the given options
         */
        protected BuildUI(template: any): void;
        Close(): void;
        RegisterTimer(timerInfo: any): void;
        /**
         * This handler is meant to support convention based event handlers
         */
        generic_Click(event: any): JQueryPromise<any>;
        /**
          * Gets the id of the DOM object associated to the view
          */
        private getDOMID();
        CloseWindowLocally(e: any): void;
        private CleanupTimers();
    }
}
interface Window {
    app: any;
}
declare module kendo.data {
    var binders: any;
}
declare module WebMap.Client {
    function checkedListBoxProc(element: any): void;
}
declare module UpgradeHelpers {
    class ControlArray {
        static indexOf(ctrlArray: any, e: any): number;
    }
    class Events {
        static getEventSender(e: any): any;
    }
    class EventKey {
        static getKeyChar(e: any): string;
        static setKeyChar(e: any, key: string): void;
        static getKeyCode(e: any): number;
        static setKeyCode(e: any, key: number): void;
        static handleEvent(e: any, value: boolean): void;
    }
    enum Keys {
        A = 65,
        Add = 43,
        Alt = 18,
        B = 66,
        Back = 8,
        C = 67,
        Capital = 20,
        CapsLock = 20,
        Clear = 46,
        Control = 17,
        ControlKey = 17,
        D = 68,
        D0 = 48,
        D1 = 49,
        D2 = 50,
        D3 = 51,
        D4 = 52,
        D5 = 53,
        D6 = 54,
        D7 = 55,
        D8 = 56,
        D9 = 57,
        Decimal = 44,
        Delete = 46,
        Divide = 47,
        Down = 40,
        E = 69,
        End = 35,
        Enter = 13,
        Escape = 27,
        F = 70,
        F1 = 112,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        G = 71,
        H = 72,
        Home = 36,
        I = 73,
        Insert = 45,
        J = 74,
        K = 75,
        L = 76,
        LControlKey = 17,
        Left = 37,
        LShiftKey = 16,
        M = 77,
        Multiply = 42,
        N = 78,
        NumLock = 144,
        NumPad0 = 48,
        NumPad1 = 49,
        NumPad2 = 50,
        NumPad3 = 51,
        NumPad4 = 52,
        NumPad5 = 53,
        NumPad6 = 54,
        NumPad7 = 55,
        NumPad8 = 56,
        NumPad9 = 57,
        O = 79,
        P = 80,
        PageDown = 34,
        PageUp = 33,
        Q = 81,
        R = 82,
        RControlKey = 17,
        Return = 13,
        Right = 39,
        RShiftKey = 16,
        S = 83,
        Shift = 16,
        ShiftKey = 16,
        Space = 32,
        Subtract = 45,
        T = 84,
        Tab = 9,
        U = 85,
        Up = 38,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
    }
    class Sound {
        static getBeep(): Sound;
        Play(): void;
    }
    class Strings {
        static convertToString(obj: any): string;
        static format(obj: any, format: string): string;
    }
}
