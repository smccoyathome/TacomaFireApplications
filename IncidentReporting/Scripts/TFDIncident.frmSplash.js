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
define("TFDIncident.frmSplash", ["files/text!views/TFDIncident.frmSplash.html", "files/css!views/TFDIncident.frmSplash.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmSplash, _super);
        function frmSplash(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            $.proxy(_this.onact, _this)();
            return _this;
        }
        frmSplash.prototype.bindings = function () {
            this.bind("frmSplash_KeyPress", this.frmSplash_KeyPress);
            this.bind("Frame1_Click", this.Frame1_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmSplash.prototype, "name", {
            get: function () {
                return "frmSplash";
            },
            enumerable: true,
            configurable: true
        });
        frmSplash.prototype.loaded = function () {
        };
        frmSplash.prototype.onact = function () {
            var that = this;
            return setTimeout(function () {
                that.close();
            }, 1000);
        };
        frmSplash.prototype.frmSplash_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmSplash", action: "frmSplash_Close" });
                e.preventDefault();
            }
        };
        frmSplash.prototype.frmSplash_KeyPress = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "keyCode": e.keyCode }));
        };
        frmSplash.prototype.Frame1_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmSplash;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmSplash.js.map