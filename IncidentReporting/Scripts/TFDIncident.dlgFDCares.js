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
define("TFDIncident.dlgFDCares", ["files/text!views/TFDIncident.dlgFDCares.html", "files/css!views/TFDIncident.dlgFDCares.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(dlgFDCares, _super);
        function dlgFDCares(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        dlgFDCares.prototype.bindings = function () {
            this.bind("OKButton_Click", this.OKButton_Click);
            this.bind("CancelButton_Renamed_Click", this.CancelButton_Renamed_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(dlgFDCares.prototype, "name", {
            get: function () {
                return "dlgFDCares";
            },
            enumerable: true,
            configurable: true
        });
        dlgFDCares.prototype.loaded = function () {
        };
        dlgFDCares.prototype.dlgFDCares_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "dlgFDCares", action: "dlgFDCares_Close" });
                e.preventDefault();
            }
        };
        dlgFDCares.prototype.OKButton_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgFDCares.prototype.CancelButton_Renamed_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return dlgFDCares;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.dlgFDCares.js.map