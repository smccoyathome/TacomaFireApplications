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
        binders.imagePath = kendo.data.Binder.extend({
            init: function (element, bindings, options) {
                kendo.data.Binder.fn.init.call(this, element, bindings, options);
            },
            refresh: function () {
                var binding = this.bindings["imagePath"];
                var imagePath = binding.get();
                if (imagePath && imagePath !== "~/Resources/Images/") {
                    var imageSource = imagePath;
                    if (this.element.children.length > 0)
                        this.element.children[0].src = imageSource;
                    else {
                        var img = document.createElement('img');
                        img.src = imageSource;
                        this.element.appendChild(img);
                    }
                }
            }
        });
    })(Client = WebMap.Client || (WebMap.Client = {}));
})(WebMap || (WebMap = {}));
//# sourceMappingURL=Label.js.map