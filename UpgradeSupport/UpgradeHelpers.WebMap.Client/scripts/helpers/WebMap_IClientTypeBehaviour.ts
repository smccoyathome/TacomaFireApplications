module WebMap.Client {

    /**
     * Client Type Behaviours are provide to provide
     * json processing on the client side.
     * For example:
     * A Json object can have a compressed format for bandwidth saving. 
     * So for sending an object like formatting data it could be sent as {p:"0x00101010101" }
     * and the preOrganizeActin can turn that json into something easier to handle on the client side like:
     * { BackColor: red, Font: "Courier", ForeColor: blue}
     *
     * It other scenenarios a custom processing is needed, so the object must be taken out of the normal 
     * state syncronization processing.
     * In those cases the original Json object can be stored in a temporal collection and return undefined, so it is not processing by the standard state processing cycle
     * Also an action can be registered to be triggered at the end of the standard state processing
     */
    export interface IClientTypeBehaviour {
        //constructor function
        cons: (jsonData: any) => any;


        preOrganizeAction: (jsonData: any) => any;
        //Post OrganizeActions are register in constructor or preOrganize directly into the maanager
    }
}