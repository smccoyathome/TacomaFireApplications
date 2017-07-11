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
        /*********************************************************
        *                   Custom Bindings
        *********************************************************/
        binders.spEnabled = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var enabled = this.bindings["spEnabled"].get();
                if (enabled) {
                    $(this.element).children().removeAttr("pointer-events");
                }
                else {
                    $(this.element).children().attr("pointer-events", "none");
                }
            },
        });
        binders.spVisible = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
                var that = this;
            },
            refresh: function () {
                var visible = this.bindings["spVisible"].get();
                if (visible) {
                    this.element.style.display = "inherit";
                    this.element.children[0].style.visibility = "inherit";
                    $($(this.element)[0]).children().children()[0].style.visibility = "inherit";
                }
                else {
                    this.element.style.display = "none";
                    this.element.children[0].style.visibility = "hidden";
                    $($(this.element)[0]).children().children()[0].style.visibility = "hidden";
                }
            }
        });
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
//# sourceMappingURL=Shapes.js.map