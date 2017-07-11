var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Mobilize;
(function (Mobilize) {
    var Widgets;
    (function (Widgets) {
        var Spread = (function (_super) {
            __extends(Spread, _super);
            function Spread() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                //Extends Kendo.Ui.Grid events.
                _this.events = kendo.ui.Grid.fn.events.concat(Widgets.EVENTS.DBLCLICK);
                //Base type
                _this.BaseType = kendo.ui.Spreadsheet;
                _this.dataAction = "index";
                _this.changeAction = "change";
                _this.controller = "spread";
                //Default options for the MobilizeGrid.
                _this.options = {
                    name: "MobilizeSpread",
                    headerHeight: 0,
                    sheetsbar: false,
                    rows: 1,
                    cols: 1
                };
                //Synchronizing with server.
                _this.retrievingData = false;
                //Synchronizing with server.
                _this.headersHidden = false;
                return _this;
            }
            //KendoUI init method.
            Spread.prototype.init = function (element, options) {
                //Initializes the kendo.ui.Grid instance, in order to use it easily.
                this.kendoSpread = this;
                //Calls base.
                kendo.ui.Spreadsheet.fn.init.call(this.kendoSpread, element, options);
            };
            //Configures grid with all required information
            Spread.prototype.initUI = function () {
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
                this.ViewModel.set('RefreshSource', false);
                //Set visibility
                this.ViewModel_SetVisible({ value: this.ViewModel.Visible, field: "Visible" });
                //Calls base.
                _super.prototype.initUI.call(this);
            };
            Spread.prototype.hideHeaders = function () {
                var headers = this.kendoSpread.element.find(".k-spreadsheet-column-header");
                if (headers.length) {
                    headers[0].style.display = "none";
                    this.headersHidden = true;
                }
            };
            Spread.prototype.refresh = function () {
                var _this = this;
                if (!this.headersHidden && this.isInitialized)
                    setTimeout((function () { return _this.hideHeaders(); }).bind(this), 1);
                this.BaseType.fn.refresh.call(this);
            };
            Spread.prototype.loadSpreadsheetData = function () {
                var data = {};
                data.uniqueId = this.ViewModel.UniqueID;
                window.app.inject.resolve("server").
                    post(this.controller + "/" + this.dataAction, JSON.stringify(data), (function (response) {
                    this.retrievingData = true;
                    try {
                        var obj = JSON.parse(response);
                        var currentOptions = this.kendoSpread.options;
                        //Set columns
                        //Set columns
                        currentOptions.columns = this.ViewModel.Col2;
                        currentOptions.rows = this.ViewModel.MaxRows;
                        this.kendoSpread.fromJSON(obj);
                        var range = this.kendoSpread.activeSheet().range(kendo.spreadsheet.SHEETREF);
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
                        }
                        else if (this.ViewModel.HideLeftRightBorders) {
                            range.borderLeft({ color: "white" });
                            range.borderRight({ color: "white" });
                        }
                        this.hideHeaders();
                    }
                    finally {
                        this.retrievingData = false;
                    }
                }).bind(this));
            };
            Spread.prototype.DataRead_Success = function () {
            };
            Spread.prototype.setEvents = function () {
                //Binds the Change event of the grid,
                this.kendoSpread.options.change = this.kendoSpread_Change.bind(this);
                //Binds a handler to a double click in a Row.
                this.kendoSpread.element.delegate(".k-spreadsheet-cell", "dblclick", (function (e) {
                    var selectedRow = this.kendoSpread.activeSheet().selection().topLeft().row;
                    this.ViewModel.set('Row', selectedRow);
                    this.trigger(Widgets.EVENTS.DBLCLICK);
                }).bind(this));
                //Add an event when the dataSource is read
                this.kendoSpread.bind('render', this.kendoSpread_Render.bind(this));
                //Calls base.
                _super.prototype.setEvents.call(this);
            };
            //Handles the selection Row change
            Spread.prototype.kendoSpread_Change = function (e) {
                if (this.retrievingData)
                    return;
                var http = window.app.inject.resolve("server");
                //Get selected row
                var data = {
                    uniqueId: this.ViewModel.UniqueID,
                    changes: []
                };
                e.range.forEachCell(function (row, column, value) {
                    return data.changes.push({ row: row, column: column, value: value });
                });
                http.post(this.controller + "/" + this.changeAction, JSON.stringify(data), function () { });
            };
            //Handles the selection Row change
            Spread.prototype.kendoSpread_Render = function (e) {
                console.log('hello!!!');
            };
            //Handles the RefreshSource property changes,
            Spread.prototype.ViewModel_SetRefreshSource = function (e) {
                //Only if the property is being changed to true.
                if (e.value) {
                    this.loadSpreadsheetData();
                    this.ViewModel.set('RefreshSource', false);
                }
            };
            //Handles the RefreshLayout property changes,
            Spread.prototype.ViewModel_SetRefreshLayout = function (e) {
                //Only if the property is being changed to true.
                if (e.value) {
                    this.initUI();
                }
            };
            Spread.prototype.ViewModel_SetVisible = function (e) {
                if (e.value) {
                    this.kendoSpread.element[0].style.display = "";
                }
                else {
                    this.kendoSpread.element[0].style.display = "none";
                }
            };
            return Spread;
        }(Widgets.WidgetBase));
        Widgets.Spread = Spread;
        kendo.ui.plugin(kendo.ui.Spreadsheet.extend(new Spread()));
    })(Widgets = Mobilize.Widgets || (Mobilize.Widgets = {}));
})(Mobilize || (Mobilize = {}));
//# sourceMappingURL=CustomSpreadsheet.js.map