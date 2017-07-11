module Mobilize.Widgets {

    export interface IObservableColection {
        Count: number;
    }

    export interface IViewModel
    {
        bind(eventName: string, handler: Function);
        set(name: string, value: any);
        UniqueID: string;
    }

    export interface IChangeEvent {
        field: string;
        value: any;
    }
    export interface IGridViewModel extends IViewModel {
        Columns: IObservableColection;
        Splits: IObservableColection;
        Rows: IObservableColection;
        SelectedIndices: number[];
        RefreshSource: boolean;
        HoldFields: boolean;
        PageSize: number;
        AllowDelete: boolean;
    }

    export interface ISpreadViewModel extends IViewModel
    {
        Name: string;
        RefreshSource: boolean;
        Col2: number;
        Visible: boolean;
        Lock: boolean;
    }

    export interface IComboboxViewModel extends IViewModel
    {
        Visible: boolean,
        SelectedIndex: number,
        CustomText: string
        BackColor: any;
    }

    export interface IWidget
    {
        ViewModel: IViewModel;
        isInitialized: boolean
        addFieldListener(name: string, handler: { (e: IChangeEvent): void; });
    }
}