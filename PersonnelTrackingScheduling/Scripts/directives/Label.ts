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

    binders.imagePath = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            let binding = this.bindings["imagePath"];
            let imagePath = binding.get();
            if (imagePath && imagePath !== "~/Resources/Images/") {
                let imageSource = imagePath;
                if (this.element.children.length > 0)
                    this.element.children[0].src = imageSource;
                else {
                    let img = document.createElement('img');
                    img.src = imageSource;
                    this.element.appendChild(img);
                }
            }
        }
    });
}