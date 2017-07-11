/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />
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
define("TFDIncident.Form1", ["files/text!views/TFDIncident.Form1.html", "files/css!views/TFDIncident.Form1.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(Form1, _super);
        function Form1(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        Form1.prototype.bindings = function () {
            //this.bindCloseEvent();
        };
        Object.defineProperty(Form1.prototype, "name", {
            get: function () {
                return "Form1";
            },
            enumerable: true,
            configurable: true
        });
        Form1.prototype.loaded = function () {
        };
        Form1.prototype.Form1_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "Form1", action: "Form1_Close" });
                e.preventDefault();
            }
        };
        return Form1;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.Form1.js.map