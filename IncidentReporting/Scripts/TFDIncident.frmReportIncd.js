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
define("TFDIncident.frmReportIncd", ["files/text!views/TFDIncident.frmReportIncd.html", "files/css!views/TFDIncident.frmReportIncd.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmReportIncd, _super);
        function frmReportIncd(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmReportIncd.prototype.bindings = function () {
            this.bind("cmdPrint_Click", this.cmdPrint_Click);
            this.bind("cmdClose_Click", this.cmdClose_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmReportIncd.prototype, "name", {
            get: function () {
                return "frmReportIncd";
            },
            enumerable: true,
            configurable: true
        });
        frmReportIncd.prototype.loaded = function () {
        };
        frmReportIncd.prototype.frmReportIncd_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmReportIncd", action: "frmReportIncd_Close" });
                e.preventDefault();
            }
        };
        frmReportIncd.prototype.cmdPrint_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportIncd.prototype.cmdClose_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportIncd.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        return frmReportIncd;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmReportIncd.js.map