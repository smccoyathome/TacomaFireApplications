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
var WebMap;
(function (WebMap) {
    var Client;
    (function (Client) {
        var ui = kendo.ui, Widget = ui.Widget, binders = kendo.data["binders"];
        var customDragDrop = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                var _this = this;
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
                var widget = $(element).data("kendoDropTarget");
                if (widget) {
                    widget.bind("drop", function (e) { return _this.dropEvent(that, e); });
                }
                else {
                    $(element).kendoDropTarget({
                        drop: function (e) { return _this.dropEvent(that, e); }
                    });
                }
            },
            refresh: function (e) {
            },
            dropEvent: function (that, e) {
                var binding = that.bindings["DragDrop"];
                var originalPath = binding.path;
                var tempath = originalPath.substr(0, originalPath.lastIndexOf("."));
                if (tempath == "") {
                    tempath = originalPath;
                }
                binding.path = tempath + ".AllowDrop";
                if (binding.get()) {
                    binding.path = originalPath;
                    var methodName = binding.path.substring((binding.path.indexOf(".") + 1));
                    var method = binding.source.view[methodName];
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
        binders.widget.DragDrop = customDragDrop;
        binders.DragDrop = customDragDrop;
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
//# sourceMappingURL=DragDrop.js.map