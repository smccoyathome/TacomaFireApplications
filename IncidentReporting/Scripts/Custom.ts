/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />
module Mobilize.WebMap.Kendo {

    (<any>Mobilize).WebMap.Kendo.DragAndDropRegister.prototype.dragHandler =
        function (command: any) {
            const controlSelector = "#" + command.form + " #" + command.ControlName;
            var ele: any = $(controlSelector);
            if (ele.data("kendoDraggable") === (null || undefined)) {
                ele.kendoDraggable({
                    hint: function () {
                        return $(controlSelector).clone();
                    }
                });
            }
            var widget = ele.data("kendoDraggable");
            var event = (window as any).app.mouseDragEvent;
            if (event !== undefined && event !== null) {
                widget["userEvents"]._start(event);
            }
            else {
                console.log("The mouseDragEvent variable is not set. The dragging event cannot start.");
            }
        }
}


(<any>kendo).data.binders.widget.comboSelectedIndex = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);

        var that = this;
        that.indexCorrection = 0;
        this.element.bind("select",
            function (item) {
                that.change(this, item);
            });
        if (this.element.ns === ".kendoDropDownList") {
            this.indexCorrection = 1;
        }
        this.ignoreRefresh = false;
    },
    refresh: function () {
        var that = this;
        if (!this.ignoreRefresh) {
            var binding = this.bindings["comboSelectedIndex"];
            var value = binding.get();
            if (typeof (value) === 'string') {
                value = parseInt(value);
            }
            // Update the selected element, but be careful
            // the data in the Combo may not be available yet
            if (this.element.dataSource.data().length > 0) {
                this.element.select(value + this.indexCorrection);
            } else {
                // If the datasource is not available yet then delay the selection
                setTimeout(function () {
                    that.element.select(value + that.indexCorrection);
                },
                    1);
            }
        }
    },
    change: function (that, item) {
        var selectedItem = that.listView._view.filter(function (currentItem) {
            return currentItem.item.UniqueID == item.dataItem.UniqueID;
        })[0];

        var value = selectedItem ? selectedItem.index : -1;
        var binding = this.bindings["comboSelectedIndex"];
        try {
            this.ignoreRefresh = true;
            binding.set(value);
        } finally {
            this.ignoreRefresh = false;
        }
    }
});