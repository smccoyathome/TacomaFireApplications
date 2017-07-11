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
define("TFDIncident.frmReportOther", ["files/text!views/TFDIncident.frmReportOther.html", "files/css!views/TFDIncident.frmReportOther.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmReportOther, _super);
        function frmReportOther(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmReportOther.prototype.bindings = function () {
            this.bind("cmdPrint_Click", this.cmdPrint_Click);
            this.bind("cmdClose_Click", this.cmdClose_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmReportOther.prototype, "name", {
            get: function () {
                return "frmReportOther";
            },
            enumerable: true,
            configurable: true
        });
        frmReportOther.prototype.loaded = function () {
        };
        frmReportOther.prototype.frmReportOther_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmReportOther", action: "frmReportOther_Close" });
                e.preventDefault();
            }
        };
        frmReportOther.prototype.cmdPrint_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportOther.prototype.cmdClose_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportOther.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        return frmReportOther;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmReportOther.js.map