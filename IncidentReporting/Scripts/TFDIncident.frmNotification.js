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
define("TFDIncident.frmNotification", ["files/text!views/TFDIncident.frmNotification.html", "files/css!views/TFDIncident.frmNotification.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmNotification, _super);
        function frmNotification(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmNotification.prototype.bindings = function () {
            this.bind("cmdNext_Click", this.cmdNext_Click);
            this.bind("cmdExit_Click", this.cmdExit_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmNotification.prototype, "name", {
            get: function () {
                return "frmNotification";
            },
            enumerable: true,
            configurable: true
        });
        frmNotification.prototype.loaded = function () {
        };
        frmNotification.prototype.frmNotification_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmNotification", action: "frmNotification_Close" });
                e.preventDefault();
            }
        };
        frmNotification.prototype.cmdNext_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmNotification.prototype.cmdExit_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmNotification;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmNotification.js.map