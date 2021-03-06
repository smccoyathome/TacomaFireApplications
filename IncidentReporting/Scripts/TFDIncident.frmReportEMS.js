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
define("TFDIncident.frmReportEMS", ["files/text!views/TFDIncident.frmReportEMS.html", "files/css!views/TFDIncident.frmReportEMS.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmReportEMS, _super);
        function frmReportEMS(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmReportEMS.prototype.bindings = function () {
            this.bind("cmdViewHIPAA_Click", this.cmdViewHIPAA_Click);
            this.bind("cmdPrint_Click", this.cmdPrint_Click);
            this.bind("cmdClose_Click", this.cmdClose_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmReportEMS.prototype, "name", {
            get: function () {
                return "frmReportEMS";
            },
            enumerable: true,
            configurable: true
        });
        frmReportEMS.prototype.loaded = function () {
        };
        frmReportEMS.prototype.frmReportEMS_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmReportEMS", action: "frmReportEMS_Close" });
                e.preventDefault();
            }
        };
        frmReportEMS.prototype.cmdViewHIPAA_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportEMS.prototype.cmdPrint_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportEMS.prototype.cmdClose_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmReportEMS.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        return frmReportEMS;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmReportEMS.js.map