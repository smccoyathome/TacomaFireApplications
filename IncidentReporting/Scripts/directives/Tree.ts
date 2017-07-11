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

    /// This custom binding searches through the nodes of the SWF.Tree and selects the one that matches with the SelectedItemId property that comes from the server
    binders.widget.selectedNode = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            let binding = this.bindings["selectedNode"];
            let selectedNodeID = binding.get();
            if (selectedNodeID != null) {
                let tree = this.element.element.data("kendoTreeView");
                let treeHTMLNodes = tree.items();
                treeHTMLNodes.each(function (index, node) {
                    let nodeModel = tree.dataItem(node);
                    if (nodeModel.wmid == selectedNodeID) {
                        tree.select(node);
                        return false;
                    }
                });
            }
        }
    });
}