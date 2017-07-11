module WebMap.Client {

export interface IDynamicEventData {
    UniqueID: string;
    EventId: string;
}

export class DynamicEventData {
    UniqueID: string;
    EventId: string;
    constructor(public uniqueID: string, public eventId: string )
    {
        this.UniqueID = uniqueID;
        this.EventId = eventId;
    }
}

}