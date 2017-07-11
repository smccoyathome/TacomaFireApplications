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
define("TFDIncident.MDIIncident", ["files/text!views/TFDIncident.MDIIncident.html", "files/css!views/TFDIncident.MDIIncident.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(MDIIncident, _super);
        function MDIIncident(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        MDIIncident.prototype.bindings = function () {
            this.bind("mnuExit_Click", this.mnuExit_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(MDIIncident.prototype, "name", {
            get: function () {
                return "MDIIncident";
            },
            enumerable: true,
            configurable: true
        });
        MDIIncident.prototype.loaded = function () {
        };
        MDIIncident.prototype.MDIIncident_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "MDIIncident", action: "MDIIncident_Close" });
                e.preventDefault();
            }
        };
        MDIIncident.prototype.mnuExit_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return MDIIncident;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.MDIIncident.js.map