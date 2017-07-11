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
        /// This custom binding searches through the nodes of the SWF.Tree and selects the one that matches with the SelectedItemId property that comes from the server
        binders.widget.selectedNode = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var binding = this.bindings["selectedNode"];
                var selectedNodeID = binding.get();
                if (selectedNodeID != null) {
                    var tree_1 = this.element.element.data("kendoTreeView");
                    var treeHTMLNodes = tree_1.items();
                    treeHTMLNodes.each(function (index, node) {
                        var nodeModel = tree_1.dataItem(node);
                        if (nodeModel.wmid == selectedNodeID) {
                            tree_1.select(node);
                            return false;
                        }
                    });
                }
            }
        });
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
//# sourceMappingURL=Tree.js.map