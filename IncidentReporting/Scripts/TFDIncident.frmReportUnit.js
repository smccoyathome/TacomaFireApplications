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
define("TFDIncident.frmReportUnit", ["files/text!views/TFDIncident.frmReportUnit.html", "files/css!views/TFDIncident.frmReportUnit.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmReportUnit, _super);
        function frmReportUnit(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmReportUnit.prototype.bindings = function () {
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmReportUnit.prototype, "name", {
            get: function () {
                return "frmReportUnit";
            },
            enumerable: true,
            configurable: true
        });
        frmReportUnit.prototype.loaded = function () {
        };
        frmReportUnit.prototype.frmReportUnit_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmReportUnit", action: "frmReportUnit_Close" });
                e.preventDefault();
            }
        };
        frmReportUnit.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        return frmReportUnit;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmReportUnit.js.map