module Mobilize.Widgets {

    export class Combobox extends WidgetBase {
        //ViewModel instance being binded to the Grid.
        public ViewModel: IComboboxViewModel;
        //Base type
        public BaseType: any = kendo.ui.ComboBox;
        //Default options for the MobilizeGrid.
        options = {
            name: "MobilizeCombobox"
        }
        public kendoCombo: kendo.ui.ComboBox;
        //KendoUI init method.
        init(element: JQuery, options?: Object) {
            //Initializes the kendo.ui.Grid instance, in order to use it easily.
            this.kendoCombo = <kendo.ui.ComboBox><any>this;
            //Calls base.
            kendo.ui.ComboBox.fn.init.call(this.kendoCombo, element, options);
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
                this.addFieldListener("SelectedIndex", this.ViewModel_SetSelectedIndex);
                this.addFieldListener("CustomText", this.ViewModel_SetCustomText);
                this.addFieldListener("BackColor", this.ViewModel_SetBackColor);
            }
            //Set visibility
            this.ViewModel_SetSelectedIndex({ value: this.ViewModel.SelectedIndex, field: "SelectedIndex" });
            //Sets Backgroundcolor
            this.setBackGroundColor(this.ViewModel.BackColor.Value);
            //Calls base.
            super.initUI();
        }

        public setBackGroundColor(value: string)
        {
            //Sets the background
            var input: JQuery = (<any>this).input;
            input[0].style.backgroundColor = value;
        }

        public setEvents()
        {
            //Binds the Change event of the grid,
            this.kendoCombo.bind('dataBound', this.kendoCombo_DataBound.bind(this));
            this.kendoCombo.bind('select', this.kendoCombo_Select.bind(this));
        }

        //Handles the BackColor property changes,
        private ViewModel_SetBackColor(e: IChangeEvent) {
            //Only if the property is being changed to true.
            this.setBackGroundColor(e.value.Value);
        } 

        //Handles the SelectedIndex property changes,
        private ViewModel_SetSelectedIndex(e: IChangeEvent) {
            //Only if the property is being changed to true.
            this.kendoCombo.select(e.value);
        }

        //Handles the CustomText property changes,
        private ViewModel_SetCustomText(e: IChangeEvent) {
            //Only if the property is being changed to true.
            this.kendoCombo.text(e.value)
        }
        private kendoCombo_Select(e: kendo.ui.ComboBoxSelectEvent) {
            //Set visibility
            var index = this.kendoCombo.dataSource.indexOf(e.dataItem);
            var text = e.dataItem.Text;
            (this.ViewModel as any).set('SelectedIndex', index);
            (this.ViewModel as any).set('CustomText', text);
        }
        private kendoCombo_DataBound(e: any)
        {
            //Set visibility
            this.ViewModel_SetSelectedIndex({ value: this.ViewModel.SelectedIndex, field: "SelectedIndex" });
        }

    }
    kendo.ui.plugin(kendo.ui.ComboBox.extend(new Combobox()));
}