module WebMap.Client {

    export interface TryGetValueResult<T> {
        HasValue: boolean;
        Value: T;
    }

    export interface IStorageSerializer {
        Serialize(obj: any);
    }

    export interface IPromise {
    }


    export interface AppActionOptions {
        controller?: string;
        action?: string;
        mainobj?: (IStateObject | any);
        parameters?: { [paremeterName: string]: any };
        useblockui?: boolean;
        dialogResult?: string;
        uniqueID?: string;
    }

    export interface Message {
        UniqueID: string;
        text: string;
        buttons?: number;
        icons?: number;
        promptMesage?: string;
        Continuation_UniqueID?: string;
        caption?: string;

    }

    export interface InputBox {
        UniqueID: string;
        prompt: string;
        title: string;
        defaultResponse: string;
    }

    // Defines an Inversion of control container used to resolve object instances.

    export interface IIocContainer {
        Resolve(options?: any): any;
    }


    interface Window {
        WebMapClientModels: {[uniqueId:string]:IStateObject};
        timeoutForActions: any;
    }

    // Defines an object that defines state and is uniquely identified by an ID
    export interface IStateObject {
        UniqueID: string;
    }

    // Defines a view object (Views and ViewModels are both defined as IViewModel).
    export interface IViewModel extends IStateObject {
        Name: string;
    }

    // Defines and object that contains "logic"to attend IViewModel actions.
    export interface ILogicView {
        // The IViewModel object to handle
        ViewModel: IViewModel;
        // Intializes this object with the given actions.
        Init(isModal: boolean): void;
        // Closes the view elements.
        Close(): void;
    }

    // Defines an object responsible for dealing with the views cycle (show, hide, close them).
    export interface IViewManager {
        //void SetAsAlwaysOnTop(IViewModel view);
        //void BringToFront(IViewModel view);

        /**
          * Closes a view in the client side.  This method handles form closing when the user clicks
          * the close box control and no binding to server side events has been added.
          */
        CloseView(view: IViewModel);

        /**
          * Fills up the WebMapRequest object with the delta information provided by the
          * ViewManager
          */
        PrepareDelta(requestInfo: WebMapRequest);

        // Removes the views indicated byt the "RemovedViews" of the data object
        RemoveViews(data): void;

        // Updates the given view with the information sent from the server side.
        UpdateView(view: IViewModel, viewInfo: any): void;

        // Navigates to the view matching the given IViewModel.  Navigating implies to display a 
        // window containing the view information and intantiating its matching ILogicView object
        NavigateToView(viewModel: IViewModel, isModal: boolean): JQueryPromise<BaseLogic>;

        // Not used
        ShowMessage(message: string, caption: string, buttons, boxIcons): IPromise;


        getConstructor(vm: IViewModel): () => ILogicView;

        GetView(UniqueID: string): BaseLogic;
    }
}