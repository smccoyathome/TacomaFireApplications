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
    var ui = kendo.ui, Widget = ui.Widget, binders = kendo.data["binders"] as any;

    var customDragOver = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            var widget = $(element).data("kendoDropTarget");
            if (widget) {
                widget.bind("dragenter", e => this.dragerEvent(that, e));
            } else {
                $(element).kendoDropTarget({
                    dragenter: e => this.dragerEvent(that, e)
                });
            }
        },
        refresh: function () {
        },
        dragerEvent: function (that, e) {
            const binding = that.bindings["DragOver"];
            let originalPath = binding.path;
            let tempath = originalPath.substr(0, originalPath.lastIndexOf("."));
            if (tempath == "") {
                tempath = originalPath;
            }
            binding.path = tempath + ".AllowDrop";
            if (binding.get()) {
                binding.path = originalPath;
                const methodName = binding.path.substring((binding.path.indexOf(".") + 1));
                const method = binding.source.view[methodName];
                var idControl = e.draggable.element[0].id;
                var uniqueIdControl = binding.source[idControl].UniqueID;
                e.ControlUID = uniqueIdControl;
                method(binding.source.view, methodName, e);
            }
            else {
                binding.path = originalPath;
            }
        }
    });
    binders.widget.DragOver = customDragOver;
    binders.DragOver = customDragOver;
}
