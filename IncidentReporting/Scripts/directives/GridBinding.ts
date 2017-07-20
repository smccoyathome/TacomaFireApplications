/// <reference path="../typings/index.d.ts" />
/*************************************************************************
*
* MOBILIZE CONFIDENTIAL
* _______________________________________________________________________
*
*  Mobilize Company
*  All Rights Reserved.
*
* NOTICE: All helper classes are provided for customer use only;
* all other use is prohibited without prior written consent from Mobilize.Net.
* no warranty express or implied;
* use at own risk.
**************************************************************************/
module kendo.data.binders.widget {
    export class Grid extends Binder {
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);

        }
        refresh(attribute?: string): void {
        }
    }

    /// Columns Binder
    export class CustomGridColumns extends Binder {
        isUpdating: boolean;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            this.isUpdating = false;
            var binding = this.bindings["CustomGridColumns"];
            if (binding) {
                var that = this;
                var value = binding.get();
                if (value) {
                    value.bind('change', function () {
                        // that.refresh();
                    });
                }
            }
        }

        refresh(): void {
            try {
                if (!this.isUpdating) {
                    this.isUpdating = true;
                    var that = this;
                    var binding = this.bindings["CustomGridColumns"];
                    var value = binding.get(); //get the value from the View-Model
                    var columnsObj = ColumnsConverter(value, this);
                    var element = this.element;
                    var options = element.getOptions();
                    options.columns = columnsObj;
                    element.setOptions(options);
                    element.bindJSEvents();
                }
            }
            finally {
                this.isUpdating = false;
            }
        }
    }

    //Generates a columns array from the columns viewmodels
    function ColumnsConverter(cols, thisElement) {
        var colsStr = [];
        if (cols) {
            for (var idx = 0; idx < cols.length; idx++) {
                var colDefinition = cols[idx];
                var columnAlignment = "center";//getKendoAlignment(colDefinition.HorizontalAlignment);
                let columnObject: any;
                columnObject = {
                    title: colDefinition.Caption,
                    field: "ItemContent[" + idx.toString() + "]",
                    attributes: {
                        style: "text-align: " + columnAlignment
                    },
                    headerAttributes: {
                        style: "text-align: " + columnAlignment
                    },
                    width: 20

                };
                if (colDefinition.ValueList.ValueListItems.Count > 0) {
                    columnObject.editor = setDropDown;
                }

                colsStr.push(columnObject);
            }
        }
        return colsStr;
    }

    //Sets the datasource for the grid
    //Use the getDataSource function to define a new datasource.
    export class CustomGridSource extends Binder {
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
        }
        refresh(): void {
            var that = this;
            var binding = this.bindings["CustomGridSource"];
            var value = binding.get();
            if (value === true) {
                try {
                    var gridId = $(this.element.element).attr('id');
                    var source = this.bindings["CustomGridSource"].source;
                    var uniqueId = source[gridId].UniqueID;
                    this.element.gridUID = uniqueId;
                    //Set default pageSize as 25 items per page
                    var pageSize = source[gridId].PageSize > 0 ? source[gridId].PageSize : 25;
                    this.element.setDataSource(getDataSource(uniqueId, this.element));
                    this.element.dataSource.bind('change', () => {
                        that.element.bindMouseEvents();
                    });
                }
                finally {
                    binding.set(false); //Set the NeedRefresh property to false
                }
            }
        }
    }

    //Define a new datasource for the kendo grid
    //Use the GridDatasource Controller to retrieve the grid data.
    function getDataSource(uniqueID, pageSize) {
        return new kendo.data.DataSource({
            pageSize: 25,
            transport: {
                read: {
                    url: "UltraGrid/GetDataSource",
                    dataType: "json",
                    contentType: "application/json"
                },
                parameterMap(options) {
                    options["gridUid"] = uniqueID;
                    return options;
                }
            },
            schema: {
                data(response) {
                    var modelRows = response.data;
                    var viewRows = [];
                    let comboColumns = [];
                    for (let i = 0; i < response.columnList.length; i++) {
                        comboColumns.push(response.columnList[i]);
                    }
                    for (var i = 0; i < modelRows.length; i++) {
                        var row = modelRows[i];
                        // if (row.Cells && row.Cells.length > 0) {
                        var r = {
                            'index': i,
                            'position': row.Index,
                            'rowuid': row.UniqueID,
                            'rowProperties': {
                                TooltipText: row.ToolTipText,
                                Selected: row.Selected,
                                //Activation: row.Activation,
                                //Hidden: row.Hidden
                            },
                            'cellProperties': {},
                            'comboValues': comboColumns,
                            'ItemContent': row.ItemContent,

                        };
                        //}

                        viewRows.push(r);
                    }
                    return viewRows;
                },
                total: "total"

            },
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        });
    }

    function setDropDown(container, options) {
        let comboItems = options.model.comboValues.filter(
            x => x.Position === container.context.cellIndex);
        if (comboItems) {
            $('<input required name="' + options.field + '"/>')
                .appendTo(container)
                .kendoDropDownList({
                    autoBind: false,
                    dataTextField: "DisplayText",
                    dataValueField: "DataValue",
                    dataSource: comboItems[0].ValueList
                });
        }
    }


    /// This custom binding support the ActiveRow property
    //Gets or sets the ActiveRow for the UltraGrid component
    export class UltraGridActiveRow extends Binder {
        isUpdating: boolean;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            this.isUpdating = false;
            this.element.bind('change', (event) => {
                this.update();
            });
            this.element.bind('dataBound', (event) => {
                this.refresh();
            });
        }
        refresh(): void {
            if (this.isUpdating) return;
            var that = this;
            var binding = this.bindings["UltraGridActiveRow"];
            var activeRowVal = binding.get();
            if (activeRowVal) {
                if (activeRowVal.length > 1) {
                    that.element.select(activeRowVal[0]);
                }
            }

        }
        update(): void {
            var that = this;
            var grid = that.element;
            var binding = that.bindings["UltraGridActiveRow"];
            var selectedRow = $(grid.select()[0]).closest('tr');
            var activeRowIndex = $(selectedRow).index();
            var value: any[];
            this.isUpdating = true;
            if (this.element.options.dataSource) { //If datasource is set
                try {
                    var page = this.element.options.dataSource.page;
                    var pageSize = this.element.options.dataSource.pageSize;
                    value = [activeRowIndex, page, pageSize];
                    binding.set(value);
                } finally {
                    this.isUpdating = false;
                }
            }
            else {
                value = [activeRowIndex, -1, -1];
                binding.set(value);
            }
            this.isUpdating = false;

        }
    }

    export class UltraGridSelected extends Binder {
        isUpdating: boolean;
        gridUid: string;
        selected: any;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            var that = this;
            this.isUpdating = false;
            var gridId = $(this.element.element).attr('id');
            let binding = bindings["UltraGridSelected"];
            this.gridUid = binding.source[gridId].UniqueID;
            this.element.bind('dataBound', (event) => {
                this.refreshSelection(event);
            });
            if (!this.element.options.navigatable) {
                this.element.bind('change', (event) => {
                    that.element.trigger('beforeRowDeactivate');
                    this.updateSelection(event);
                });
            }
            if (this.element.options.navigatable && this.element.options.selectable == "multiple cell") {
                var selectedColumns = [];
                var grid = this.element;
                $(this.element.element).children('.k-grid-header').bind('click', (event) => {
                    if (event.ctrlKey) {
                        if (selectedColumns.indexOf(grid._current.context.cellIndex) < 0)
                            selectedColumns.push(grid._current.context.cellIndex);
                    }
                    else {
                        selectedColumns = [];
                        selectedColumns.push(grid._current.context.cellIndex);
                    }
                    this.updateSelectionColumn(selectedColumns);
                });
            }
            ///Listen SelectionChanges
            this.selected = binding.get();
            switch (this.element.options.selectable) {
                case "multiple, row":
                    break;
                case "multiple cell":
                    if (this.selected.SelectedCells) {
                        this.selected.SelectedCells.bind('change', (event) => {
                            that.refreshCellsSelection(event, that.element);
                        });
                    }
                    else {
                        this.selected.bind("change", function (event) {
                            if (event && event.field === "SelectedCells") {
                                that.selected.SelectedCells.bind('change', (event) => {
                                    that.refreshCellsSelection(event, that.element);
                                });
                            }
                            that.selected.unbind("change");
                        });
                    }
                    break;
            }
        }

        refresh() {

        }

        updateSelection(e) {
            var grid = e.sender;
            if (!grid.options.selectable) return;
            if (grid.options.selectable === true ||
                grid.options.selectable === "row" ||
                grid.options.selectable === "multiple, row") {
                var currentSelection = grid.select();
                var selectedRows = [];
                for (let i = 0; i < currentSelection.length; i++) {
                    var rowIndex = $(currentSelection[i]).index();
                    selectedRows.push(UltraGridUtils.calculateRealIndex(grid, rowIndex));
                }
                var parameters = {
                    gridUid: this.gridUid,
                    selectedRows: selectedRows.toString()
                }
                var action = new Mobilize.Application
                    .ActionModel("UltraGrid",
                    "UpdateSelectedRows",
                    undefined,
                    parameters,
                    undefined,
                    new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
                window.app.sendAction(action, true);
            }
            if (grid.options.selectable === "multiple cell") {
                var currentSelection = grid.select();
                var selectedCells = [];
                for (let i = 0; i < currentSelection.length; i++) {
                    var cellIndex = $(currentSelection[i]).index();
                    let cell = {
                        Key: grid.columns[currentSelection[i].cellIndex].title,
                        RowIndex: currentSelection[i].parentElement.rowIndex
                    }
                    selectedCells.push(cell);
                }
                let parameters = {
                    gridUid: this.gridUid,
                    selectedCells: JSON.stringify(selectedCells)
                }
                var action = new Mobilize.Application
                    .ActionModel("UltraGrid",
                    "UpdateSelectedCells",
                    undefined,
                    parameters,
                    undefined,
                    new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
                window.app.sendAction(action, true);
            }
        }

        refreshSelection(e) {
            var rows = e.sender.dataSource.data();
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].rowProperties.Selected == true) {
                    e.sender.select("tr:eq(" + i + ")");
                }
            }
        }

        refreshCellsSelection(event, grid) {
            grid.clearSelection();
            var selectedCells = event.sender;
            for (let i = 0; i < selectedCells.length; i++) {
                let cell = selectedCells[i];
                let rowIndex = cell.RowIndex + 1;
                let columnIndex = $(grid.element).find("th:contains('" + cell.Key + "')").index();
                let gridCell = $(grid.element).find("tr:eq(" + rowIndex + ")").find("td:eq(" + columnIndex + ")");
                grid.select(gridCell);
            }
        }

        updateSelectionColumn(columnIndices) {
            let parameters = {
                gridUid: this.gridUid,
                columnIndices: columnIndices.toString()
            }
            var action = new Mobilize.Application
                .ActionModel("UltraGrid",
                "UpdateSelectedColumns",
                undefined,
                parameters,
                undefined,
                new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
            window.app.sendAction(action, true);
        }
    }

    export class CustomGridOverride extends Binder {
        gridUid: any;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            let gridId = $(this.element.element).attr('id');
            var that = this;
            let binding = bindings["CustomGridOverride"];
            this.gridUid = binding.source[gridId].UniqueID;
            var displayLayoutValue = binding.get();
            if (displayLayoutValue && displayLayoutValue.Override) {
                displayLayoutValue.Override.bind('change', (event) => {
                    that.refresh();
                });
            }

        }

        refresh() {
            var that = this;
            let binding = this.bindings["CustomGridOverride"];
            let displayLayoutValue = binding.get();
            if (!displayLayoutValue) return;
            let overrideValue = displayLayoutValue.Override;
            switch (overrideValue.CellClickAction) {
                case 2:
                case 3:
                    var options = this.element.getOptions();
                    options.editable = true;
                    this.element.setOptions(options);
                    this.element.bindJSEvents();
                    this.element.bind("edit", (event) => {
                        that.element.trigger("beforeEnterEditMode");
                        that.setIsInEditMode(event, that.gridUid);
                    });
                    this.element.bind("save", (event) => {
                        that.element.trigger("beforeExitEditMode");
                        that.element.trigger("cellChange");
                        that.updateEditedCell(event, that);
                    });
                    break;
                case 4:
                    var options = this.element.getOptions();
                    options.selectable = "multiple, row";
                    this.element.setOptions(options);
                    this.element.bindJSEvents();
                    break;
                default:
                    break;
            }

        }
        updateEditedCell(event, context) {
            let gridId = context.gridUid;
            let grid = context.element;
            let modifiedKey = Object.keys(event.values)[0];
            let modifiedValue = event.values[modifiedKey] as string;
            eval("event.model." + modifiedKey + "='" + modifiedValue + "'");
            let parameters = {
                gridUid: gridId,
                editedCell: JSON.stringify(event.model)
            }
            var action = new Mobilize.Application
                .ActionModel("UltraGrid",
                "UpdateEditedCells",
                undefined,
                parameters,
                context.triggerEventsAfterEdition(grid),
                new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
            window.app.sendAction(action, true);
        }

        triggerEventsAfterEdition(grid) {
            grid.trigger("afterCellUpdate");
            grid.trigger("afterRowUpdate");
            grid.trigger("afterExitEditMode");
        }

        setIsInEditMode(event, gridId) {
            var colIndex = event.container.index();
            var rowIndex = UltraGridUtils.calculateRealIndex(event.sender, event.model.index);
            let parameters = {
                gridUid: gridId,
                column: colIndex,
                row: rowIndex
            }
            var action = new Mobilize.Application
                .ActionModel("UltraGrid",
                "UpdateEditMode",
                undefined,
                parameters,
                undefined,
                new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
            window.app.sendAction(action, true);
        }
    }

    ///This class provides methods that are commonly
    /// used for the different Ultragrid's custom bindings
    export class UltraGridUtils {
        static calculateRealIndex(grid, rowIndex) {
            var currentPageSize = grid.pager.pageSize();
            var currentPage = grid.pager.page() - 1;
            return rowIndex + (currentPage * currentPageSize);
        }
    }
}