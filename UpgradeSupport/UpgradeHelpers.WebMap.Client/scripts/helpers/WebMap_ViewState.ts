module WebMap.Client {

    /** 
      * Defines a class that contains information about the View changes.  This class
      * is used to interchange data between client and server calls.
      */
    export interface ViewState {

        /**
         * Holds information indicating the current state of the views that should be present on display
         */
        LoadedViews?: IViewModel[];  // List of loaded views
        ModalViews: string[]; //List of modal uids

        /**
         * Indicates the UniqueIDs of the IViewModels for views that have been recently loaded
         * NOTE: LoadedViews and NewViews do not appear together at the same time. If LoadedViews is present that means 
         * that this state is listing all the currently loaded views.
         */
        NewViews?: string[];

        /**
         * If present, it holds the name of the field that should adquire focus
         */
        CurrentFocusedControl: string;

		/**
         * 
         * Removed views on server.
         */
        RemovedViews: string[];
    }
}
