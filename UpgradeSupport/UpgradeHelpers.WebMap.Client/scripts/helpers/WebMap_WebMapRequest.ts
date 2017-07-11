module WebMap.Client {


    export interface WebMapRequest {
        /** 
         * Contains a dictionary where each entry is the uniqueID of an IStateObject that was modified
         * and the value is an object with the modified props
         */
        dirty: { [uniqueid: string]: any };

        /**
         * Contains the unique id of the viewmodel or usercontrol that will handle this request.
         * This vm will be injected in the corresponding MVC Controller. 
         * NOTE: the controller should have a parameter called viewFromClient
         */
        vm: string;
        /**
         * List of views that have been closed
         */
        closedViews?: string[];

        /**
         * parameters that are needed on the client side
         */
        parameters?: { [parametername: string]: any };

        /**
         * For message boxes, indicates which button was pressed
         */
        dialogResult?: string;
    }

}