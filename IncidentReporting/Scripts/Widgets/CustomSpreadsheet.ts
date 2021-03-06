﻿module Mobilize.Widgets {
    export class Spread extends WidgetBase {
        //Fields
        //ViewModel instance being binded to the Grid.
        public ViewModel: ISpreadViewModel;
        //Instance of the Kendo Grid.
        public kendoSpread: kendo.ui.Spreadsheet;
        //Extends Kendo.Ui.Grid events.
        events = kendo.ui.Grid.fn.events.concat(EVENTS.DBLCLICK);
        //Base type
        public BaseType: any = kendo.ui.Spreadsheet;
        private dataAction: string = "index";
        private changeAction: string = "change";
        private controller: string = "spread"
        //Default options for the MobilizeGrid.
        options = {
            name: "MobilizeSpread",
            headerHeight: 0,
            sheetsbar: false,
            rows: 1,
            cols: 1
        }
        //Synchronizing with server.
        public retrievingData: boolean = false;
        //Synchronizing with server.
        public headersHidden: boolean = false;
        //KendoUI init method.
        init(element: JQuery, options?: Object) {
            //Initializes the kendo.ui.Grid instance, in order to use it easily.
            this.kendoSpread = <kendo.ui.Spreadsheet><any>this;

            //Calls base.
            kendo.ui.Spreadsheet.fn.init.call(this.kendoSpread, element, options);
        }
        //Configures grid with all required information
        initUI(): void {
            // Only if the Grid is not initialized we need to wire the events 
            //and handlers.
            if (!this.isInitialized) {
                //Initializes the events used to keep ViewModel in sync and
                //to add new custom events.
                this.setEvents();
                //
                // **Fields Set listeners.**
                // We are going to add listeners for the ViewModel properties we want to track the changes of.
                //
                this.addFieldListener("RefreshSource", this.ViewModel_SetRefreshSource);
                this.addFieldListener("RefreshLayout", this.ViewModel_SetRefreshLayout);
                this.addFieldListener("Visible", this.ViewModel_SetVisible);
            }
            //Hides the header
            this.hideHeaders();
            //Load data From server
            this.loadSpreadsheetData();
            (this.ViewModel as any).set('RefreshSource', false);
            //Set visibility
            this.ViewModel_SetVisible({ value: this.ViewModel.Visible, field: "Visible" });
            //Calls base.
            super.initUI();
        }

        private hideHeaders() {
            var headers = this.kendoSpread.element.find(".k-spreadsheet-column-header");
            if (headers.length) {
                headers[0].style.display = "none";
                this.headersHidden = true;
            }
        }
        refresh()
        {
            if (!this.headersHidden && this.isInitialized)
                setTimeout((() => this.hideHeaders()).bind(this), 1);
             (<any>this.BaseType).fn.refresh.call(this);
        }
        public loadSpreadsheetData() {
            var data: any = {}
            data.uniqueId = this.ViewModel.UniqueID;
            window.app.inject.resolve("server").
                post(this.controller + "/" + this.dataAction, JSON.stringify(data), (function (response) {
                    this.retrievingData = true;
                    try {
                        var obj: any = JSON.parse(response);
                        var currentOptions = this.kendoSpread.options;
                        //Set columns
                        //Set columns
                        currentOptions.columns = this.ViewModel.Col2;
                        currentOptions.rows = this.ViewModel.MaxRows;
                        this.kendoSpread.fromJSON(obj);
                        var range: kendo.spreadsheet.Range = this.kendoSpread.activeSheet().range((<any>kendo.spreadsheet).SHEETREF);
                        if (this.ViewModel.Lock) {
                            //Enable / disable specified range
                            range.enable(!this.ViewModel.Lock);
                            this.kendoSpread.element.find('.k-spreadsheet-cell').removeClass('k-state-disabled');
                        }
                        if (this.ViewModel.HideCellBorders) {
                            range.borderBottom({ color: "white" });
                            range.borderTop({ color: "white" });
                            range.borderLeft({ color: "white" });
                            range.borderRight({ color: "white" });
                        } else if (this.ViewModel.HideLeftRightBorders)
                        {
                            range.borderLeft({ color: "white" });
                            range.borderRight({ color: "white" });
                        }
                        this.hideHeaders();
                    } finally {
                        this.retrievingData = false;
                    }
                }).bind(this));
        }

        public DataRead_Success() {

        }

        setEvents(): void {
            //Binds the Change event of the grid,
            this.kendoSpread.options.change = this.kendoSpread_Change.bind(this);
            //Binds a handler to a double click in a Row.
            this.kendoSpread.element.delegate(".k-spreadsheet-cell", "dblclick", (function (e) {
                var selectedRow = this.kendoSpread.activeSheet().selection().topLeft().row;
                (this.ViewModel as any).set('Row', selectedRow);
                this.trigger(EVENTS.DBLCLICK);
            }).bind(this));
            //Add an event when the dataSource is read
            this.kendoSpread.bind('render', this.kendoSpread_Render.bind(this));
            //Calls base.
            super.setEvents();
        }
        //Handles the selection Row change
        private kendoSpread_Change(e: kendo.ui.SpreadsheetChangeEvent) {
            if (this.retrievingData)
                return;
            let http = window.app.inject.resolve("server");
            //Get selected row
            var data = {
                uniqueId: this.ViewModel.UniqueID,
                changes: []
            };
            e.range.forEachCell((row, column, value) =>
                data.changes.push({ row: row, column: column, value: value }));
            http.post(this.controller + "/" + this.changeAction, JSON.stringify(data), () => { });
        }

        //Handles the selection Row change
        private kendoSpread_Render(e: kendo.ui.SpreadsheetChangeEvent) {
            console.log('hello!!!');
        }
        //Handles the RefreshSource property changes,
        private ViewModel_SetRefreshSource(e: IChangeEvent) {
            //Only if the property is being changed to true.
            if (e.value) {
                this.loadSpreadsheetData();
                (this.ViewModel as any).set('RefreshSource', false);
            }
        }
        //Handles the RefreshLayout property changes,
        private ViewModel_SetRefreshLayout(e: IChangeEvent) {
            //Only if the property is being changed to true.
            if (e.value) {
                this.initUI();
            }
        }

        private ViewModel_SetVisible(e: IChangeEvent) {
            if (e.value) {
                this.kendoSpread.element[0].style.display = "";
            }
            else {
                this.kendoSpread.element[0].style.display = "none";
            }
        }
    }

    kendo.ui.plugin(kendo.ui.Spreadsheet.extend(new Spread()));
}