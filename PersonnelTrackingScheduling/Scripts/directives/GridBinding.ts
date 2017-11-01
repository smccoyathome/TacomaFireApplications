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
module WebMap.Client {

    export function checkboxClicked(element) {
        var isChecked = element.checked;
        var cell = $(element).parent()["0"];
        var row = element.closest("tr");
        var grid = element.closest(".k-grid").kendoBindingTarget.target;
        var gridId = grid.gridUID;
        var model = grid.dataItem(row);
        var columnHeader = grid.columns[cell.cellIndex].field;
        model.set(columnHeader, isChecked ? "True":"False");
        let parameters = {
            gridUid: gridId,
            editedCell: JSON.stringify(model)
        }
        var action = new Mobilize.Application
            .ActionModel("UltraGrid",
            "UpdateEditedCells",
            undefined,
            parameters,
            null,
            new Mobilize.Server.RequestConfig(Mobilize.Contract.Server.RequestType.RawRequest));
        window.app.sendAction(action, true);


    };
}

module kendo.data.binders.widget {
    export class Grid extends Binder {
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);

        }
        refresh(attribute?: string): void {
        }
    }

    /// Columns Binder
    export class UltraGridColumns extends Binder {
        isUpdating: boolean;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            this.isUpdating = false;
            var binding = this.bindings["UltraGridColumns"];
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
                    var binding = this.bindings["UltraGridColumns"];
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
			//mobilize-note: jcruz. Adding sortFuntion to allow sort the grid columns based on the VisiblePosition. Related with issue 24645.

            var sortFunction = function (a, b) {
                var firstValue = a.VisiblePosition;
                var secondValue = b.VisiblePosition;
                if (firstValue < secondValue) {
                    return -1;
                }
                else if (firstValue > secondValue) {
                    return 1;
                }
                else {
                    return 0;
                }
            };

            for (var idx = 0; idx < cols.Count; idx++) {
                var colDefinition = cols[idx];
                if (colDefinition == null)
                    continue;
                var columnAlignment = "center";//getKendoAlignment(colDefinition.HorizontalAlignment);
                let columnObject: any;
                let field = "ItemContent[" + idx.toString() + "]"; 
                let image = "Appearances[" + idx.toString() + "].Image"; 
                var columnTemplate = "";
                if (!colDefinition.isCheckbox) {
                    columnTemplate = "#= kendo.toString(" + image + ") !== '' ? '<img  src=' + kendo.toString(" + image + ") + '>' + kendo.toString(" + field + ") : kendo.toString(" + field + ")#";
                }
                else {
                    columnTemplate = '<input type= "checkbox" onclick= "WebMap.Client.checkboxClicked(this)" #= ' + field + ' ==="True" ?\'checked="checked"\' : "" # class="chkbx"/>';
                }
                columnObject = {
                    template: columnTemplate,
                    title: colDefinition.Caption ? colDefinition.Caption : "", //mobilize-note: jcruz. Adding validation for caption undefined
                    hidden: colDefinition.Hidden, //mobilize-note: jcruz. Adding hidden property to the columns. Related with issue 24643.
                    editor: colDefinition.Editable ? allowEdit : ReadOnlyEditor, //mobilize-note: surena. Adding enable property to the columns.
                    maxValue: colDefinition.MaxValue ? colDefinition.MaxValue : 0, //mobilize-note: surena. Adding maxValue property to the columns.
                    field: field,
                    attributes: {
                        style: "text-align: " + columnAlignment + "; background-color: white;"
                    },
                    headerAttributes: {
                        style: "text-align: " + columnAlignment
                    },
                    width: colDefinition.Width,//mobilize-note: scampos. Set width of grid columns. Related with issue 24645.
                    //mobilize-note: jcruz. Changing the use of Header.Visible position by the use of _position because VisiblePosition property is undefined.
                    VisiblePosition: colDefinition._position//Header.VisiblePosition //mobilize-note: jcruz. Adding visiblePosition property to allow sort the grid columns. Related with issue 24645. 
                };
                if (colDefinition.ValueList && colDefinition.ValueList.ValueListItems && colDefinition.ValueList.ValueListItems.Count > 0) {
                    columnObject.editor = setDropDown;
                }

                colsStr.push(columnObject);
            }

        }
        return colsStr.sort(sortFunction); //mobilize-note: jcruz. Sorting the grid columns based on the VisiblePosition. Related with issue 24645.
    }

    //Sets the datasource for the grid
    //Use the getDataSource function to define a new datasource.
    export class UltraGridSource extends Binder {
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
        }
        refresh(): void {
            var that = this;
            var binding = this.bindings["UltraGridSource"];
            var value = binding.get();
            if (value === true) {
                try {
                    var gridId = $(this.element.element).attr('id');
                    var source = this.bindings["UltraGridSource"].source;
					//mobilize-note: lfonseca.Using correct way to get the model in multiple levels.
                    var sourceViewModel = getModelFromBinding(binding);
                    var uniqueId = sourceViewModel.UniqueID; //source[gridId].UniqueID;
                    this.element.gridUID = uniqueId;
                    //Set default pageSize as 25 items per page
                    var pageSize = sourceViewModel.PageSize > 0 ? sourceViewModel.PageSize : 25;
                    //mobilize-note: ldulate. We need to send pageSize variable as a parameter for getDataSource method.
                    this.element.setDataSource(getDataSource(uniqueId, pageSize));


                    this.element.dataSource.unbind('change', () => {
                        that.element.bindMouseEvents();
                    });

                    this.element.dataSource.bind('change', () => {
                        that.element.bindMouseEvents();
                    });


                    //mobilize-note: lvega  this is a temporary change for color the rows.
                    that.element.sourceViewModel = sourceViewModel;
                    that.element.unbind('dataBound');
                    that.element.bind('dataBound', $.proxy(function (e) {   
                        var grid = e.sender;
                        var data = grid.dataSource.view();
                        var scrModel = this.element.sourceViewModel;
                        
                        for (var i = 0; i < data.length; i++) {
                            let indexFind = data[i].index;
                            let currentPage = grid.dataSource.page();

                            if (currentPage >= 2)
                            {
                                indexFind += (pageSize * ( currentPage  - 1));
                            }

                            if (data[i]) {
                                var uid = data[i].uid;
                                var currenRow = grid.table.find("tr[data-uid='" + uid + "']");

                                var style = data[i].RowAppearance;
                                if (style) {

                                    if (style.FontData.Bold == true) {
                                        $(currenRow).css("font-weight", "bold");
                                    }

                                    if (style.FontData.Italic == true) {
                                        $(currenRow).css("font-style", "italic");
                                    }
                                    if (style.Color) {
                                        $(currenRow).css("color", style.Color);
                                    }
                                }

                                for (var j = 0; j < data[i].ItemContent.length; j++) {
                                    var positionDifference = scrModel.Columns.Items[j]._position - j;
                                    var cellStyle = data[i].Appearances[j];//app.Cells.Items[j].Appearance;
                                    var currentCell = $(currenRow).find("td")[j + positionDifference];
                                    if (cellStyle) {

                                        if (cellStyle.FontData.Bold == true) {
                                            $(currentCell).css("font-weight", "bold");
                                        }

                                        if (cellStyle.FontData.Italic == true) {
                                            $(currentCell).css("font-style", "italic");
                                        }
                                        if (cellStyle.Color) {
                                            $(currentCell).css("color", cellStyle.Color);
                                        }
                                        if (cellStyle.BackColor) {
                                            $(currentCell).css("background-color", cellStyle.BackColor.Value);
                                        }
                                    }
                                }
                            }
                        }
                    },that));
                    
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
            //mobilize-note: ldulate. We need to set pageSize property with pageSize method paramenter
            pageSize: pageSize,
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
                            'Appearances': row.Appearances,
                            'Color':row.Color,
                            'RowAppearance': row.RowAppearance
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

    //mobilize-note: surena. Function that closes a cell to avoid edition when is not allowed.
    function ReadOnlyEditor(event) {
        event.closest(".k-grid")["0"].kendoBindingTarget.target.closeCell();
    }

    //mobilize-note: surena. Function that manages the edition in the cells. Shows an input to the user inside the cell.
    function allowEdit(container, options) {
        // create an input element
        var grid = container.closest(".k-grid")["0"].kendoBindingTarget.target;
        var input;
        if (grid.columns[container[0].cellIndex].maxValue == 0)
        {
            input = $("<input />");
        } else
        {
            input = $("<input maxlength='" + grid.columns[container[0].cellIndex].maxValue + "'/>");
        }
        input.attr("name", options.field);
        // append it to the container
        input.appendTo(container);
    }

    /// This custom binding support the ActiveRow property
    //Gets or sets the ActiveRow for the UltraGrid component
    export class UltraGridActiveRow extends Binder {
        isUpdating: boolean;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            this.isUpdating = false;
            this.element.bind('activeRowUpdate', (event) => {
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
                    var page = this.element.pager.page();
                    var pageSize = this.element.pager.pageSize();
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
			//mobilize-todo: lfonseca. Change to run the control Issue 19708 
            this.gridUid = binding.source.UniqueID;
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

    function processPathSection(pathSection: string, bindingModel: any) {
        let arrayExprSections = pathSection.split('[');
        if (arrayExprSections.length > 1) // It's an array expression, ex: userControl11.txtValues[2]
        {
            let arrayName = arrayExprSections[0];
            let index = arrayExprSections[1].slice(0, -1); // remove ending bracket
            return bindingModel[arrayName][index];
        }
        return bindingModel[pathSection];
    }

    /**
     * Gets the model which is binded to the element. To do this it assesses each part of the binding expression path
     * @param binding
     * @param numbersOfLastElemetsPathToRemove
    */
    export function getModelFromBinding(binding: any, numbersOfLastElemetsPathToRemove: number = 0) {
        let pathSections = binding.path.split(".").slice(0, -1 * (numbersOfLastElemetsPathToRemove + 1)); //  by default remove the binded property, and removed the n-element last before of binding property.
        let model = binding.source;
        for (let i = 0; i < pathSections.length; i++) {
            let currentParent = pathSections[i];
            model = processPathSection(currentParent, model);
            if (model == undefined)
                return null;
        }
        return model;
    }

    export class UltraGridOverride extends Binder {
        gridUid: any;
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
            let gridId = $(this.element.element).attr('id');
            var that = this;
            let binding = that.bindings["UltraGridOverride"];			
            this.gridUid = getModelFromBinding(binding).UniqueID; //mobilize-note:lvega calcullate the model correctly
            var displayLayoutValue = binding.get();
            if (displayLayoutValue && displayLayoutValue.Override) {
                displayLayoutValue.Override.bind('change', (event) => {
                    that.refresh();
                });
            }

        }

        refresh() {
            var that = this;
            let binding = this.bindings["UltraGridOverride"];
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
                    this.element.unbind("edit"); //mobilize-note: surena. Unbinds the event to avoid multiple calls.
                    this.element.bind("edit", (event) => {
                        that.element.trigger("beforeEnterEditMode");
                        that.setIsInEditMode(event, that.gridUid);
                    });
                    this.element.unbind("save"); //mobilize-note: surena. Unbinds the event to avoid multiple calls.
                    this.element.bind("save", (event) => {
                        that.element.trigger("beforeExitEditMode");
                        //that.element.trigger("cellChange"); //mobilize-note: surena. This event will be fired inside the UpdateEditedCells method in the server.
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

    export class GridBands extends Binder {
        constructor(element: Element, bindings: { [key: string]: Binding; }, options?: any) {
            super(element, bindings, options);
        }
        refresh() {
            // Hide or show the column header
            var that = this;
            let binding = this.bindings["GridBands"];
            let bands = binding.get();
            if (bands && bands.length > 0) {
                if (bands[0].ColHeadersVisible) {
                    that.element.element.find(".k-grid-header").show();
                } else {
                    that.element.element.find(".k-grid-header").hide();
                }
            }
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