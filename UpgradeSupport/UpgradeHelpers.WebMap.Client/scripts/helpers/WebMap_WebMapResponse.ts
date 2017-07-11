module WebMap.Client {
    export interface WebMapResponse {
        /**
         * If present indicates that a session timeout ocurred when the request was processed
         */
        SessionTimeOut?: boolean;
        /**
         * MDT aka Model Delta Types
         * Contains an array of integers that are used to 'type mark' the view models
         * MDT and MD must have the same size, and there is a corresponding MDT[i] for each MD[i]
         */
        MDT: number[];
        /**
         * MD aka Model Delta
         * Contains an array of the modified models after performing a request on the server
         */
        MD: IStateObject[];
        /**
         * RM aka removed views
         * list of models that have been removed on the server side, and that should also be removed on the client
         */
        RM: string[];
        /**
         * SW aka switched ids
         * Each element in this array is a pair like [ originalUniqueID, newUniqueID] that indicates a 'switch' on the UniqueID of an object already
         * on the StateManager
         */
        SW: Array<Array<string>>;

        /**
         * VD aka Views Delta
         * Reflects the current views state changes
         */
        VD: ViewState;
		/*
		* NV contains string with 1 and 0 indicating if a View is new.
		*
		*/
		NV: string


    }
}