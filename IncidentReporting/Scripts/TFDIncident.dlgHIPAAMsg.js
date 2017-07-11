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
define("TFDIncident.dlgHIPAAMsg", ["files/text!views/TFDIncident.dlgHIPAAMsg.html", "files/css!views/TFDIncident.dlgHIPAAMsg.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(dlgHIPAAMsg, _super);
        function dlgHIPAAMsg(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        dlgHIPAAMsg.prototype.bindings = function () {
            this.bind("txtReleaseName_TextChanged", this.txtReleaseName_TextChanged);
            this.bind("txtReleaseAdd1_TextChanged", this.txtReleaseAdd1_TextChanged);
            this.bind("txtReleaseAdd2_TextChanged", this.txtReleaseAdd2_TextChanged);
            this.bind("txtReleaseReason_TextChanged", this.txtReleaseReason_TextChanged);
            this.bind("cmdCancel_Click", this.cmdCancel_Click);
            this.bind("cmdPrint_Click", this.cmdPrint_Click);
            this.bind("cmdOut_Click", this.cmdOut_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(dlgHIPAAMsg.prototype, "name", {
            get: function () {
                return "dlgHIPAAMsg";
            },
            enumerable: true,
            configurable: true
        });
        dlgHIPAAMsg.prototype.loaded = function () {
        };
        dlgHIPAAMsg.prototype.dlgHIPAAMsg_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "dlgHIPAAMsg", action: "dlgHIPAAMsg_Close" });
                e.preventDefault();
            }
        };
        dlgHIPAAMsg.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        dlgHIPAAMsg.prototype.txtReleaseName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.txtReleaseAdd1_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.txtReleaseAdd2_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.txtReleaseReason_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.cmdCancel_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.cmdPrint_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        dlgHIPAAMsg.prototype.cmdOut_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return dlgHIPAAMsg;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.dlgHIPAAMsg.js.map