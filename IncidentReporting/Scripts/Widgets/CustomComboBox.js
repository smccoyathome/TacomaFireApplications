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
        var Combobox = (function (_super) {
            __extends(Combobox, _super);
            function Combobox() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                //Base type
                _this.BaseType = kendo.ui.ComboBox;
                //Default options for the MobilizeGrid.
                _this.options = {
                    name: "MobilizeCombobox"
                };
                return _this;
            }
            //KendoUI init method.
            Combobox.prototype.init = function (element, options) {
                //Initializes the kendo.ui.Grid instance, in order to use it easily.
                this.kendoCombo = this;
                //Calls base.
                kendo.ui.ComboBox.fn.init.call(this.kendoCombo, element, options);
            };
            //Configures grid with all required information
            Combobox.prototype.initUI = function () {
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
                    this.addFieldListener("SelectedIndex", this.ViewModel_SetSelectedIndex);
                    this.addFieldListener("CustomText", this.ViewModel_SetCustomText);
                    this.addFieldListener("BackColor", this.ViewModel_SetBackColor);
                }
                //Set visibility
                this.ViewModel_SetSelectedIndex({ value: this.ViewModel.SelectedIndex, field: "SelectedIndex" });
                //Sets Backgroundcolor
                this.setBackGroundColor(this.ViewModel.BackColor.Value);
                //Calls base.
                _super.prototype.initUI.call(this);
            };
            Combobox.prototype.setBackGroundColor = function (value) {
                //Sets the background
                var input = this.input;
                input[0].style.backgroundColor = value;
            };
            Combobox.prototype.setEvents = function () {
                //Binds the Change event of the grid,
                this.kendoCombo.bind('dataBound', this.kendoCombo_DataBound.bind(this));
                this.kendoCombo.bind('select', this.kendoCombo_Select.bind(this));
            };
            //Handles the BackColor property changes,
            Combobox.prototype.ViewModel_SetBackColor = function (e) {
                //Only if the property is being changed to true.
                this.setBackGroundColor(e.value.Value);
            };
            //Handles the SelectedIndex property changes,
            Combobox.prototype.ViewModel_SetSelectedIndex = function (e) {
                //Only if the property is being changed to true.
                this.kendoCombo.select(e.value);
            };
            //Handles the CustomText property changes,
            Combobox.prototype.ViewModel_SetCustomText = function (e) {
                //Only if the property is being changed to true.
                this.kendoCombo.text(e.value);
            };
            Combobox.prototype.kendoCombo_Select = function (e) {
                //Set visibility
                var index = this.kendoCombo.dataSource.indexOf(e.dataItem);
                var text = e.dataItem.Text;
                this.ViewModel.set('SelectedIndex', index);
                this.ViewModel.set('CustomText', text);
            };
            Combobox.prototype.kendoCombo_DataBound = function (e) {
                //Set visibility
                this.ViewModel_SetSelectedIndex({ value: this.ViewModel.SelectedIndex, field: "SelectedIndex" });
            };
            return Combobox;
        }(Widgets.WidgetBase));
        Widgets.Combobox = Combobox;
        kendo.ui.plugin(kendo.ui.ComboBox.extend(new Combobox()));
    })(Widgets = Mobilize.Widgets || (Mobilize.Widgets = {}));
})(Mobilize || (Mobilize = {}));
//# sourceMappingURL=CustomComboBox.js.map