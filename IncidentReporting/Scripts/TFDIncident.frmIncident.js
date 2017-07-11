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
define("TFDIncident.frmIncident", ["files/text!views/TFDIncident.frmIncident.html", "files/css!views/TFDIncident.frmIncident.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmIncident, _super);
        function frmIncident(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmIncident.prototype.bindings = function () {
            this.bind("cmdViewReport_Click", this.cmdViewReport_Click);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("chkSitFound_CheckStateChanged", this.chkSitFound_CheckStateChanged);
            this.bind("cboUnit_SelectionChangeCommitted", this.cboUnit_SelectionChangeCommitted);
            this.bind("chkExposures_CheckStateChanged", this.chkExposures_CheckStateChanged);
            this.bind("txtNumberExposures_Leave", this.txtNumberExposures_Leave);
            this.bind("txtNumberExposures_TextChanged", this.txtNumberExposures_TextChanged);
            this.bind("chkCivilianCasualty_CheckStateChanged", this.chkCivilianCasualty_CheckStateChanged);
            this.bind("txtNumberCivCasulties_TextChanged", this.txtNumberCivCasulties_TextChanged);
            this.bind("FDCaresBtn_Click", this.FDCaresBtn_Click);
            this.bind("txtNumberPatients_Leave", this.txtNumberPatients_Leave);
            this.bind("txtNumberPatients_TextChanged", this.txtNumberPatients_TextChanged);
            this.bind("optServiceReport_CheckedChanged", this.optServiceReport_CheckedChanged);
            this.bind("cboEMSUnit_SelectionChangeCommitted", this.cboEMSUnit_SelectionChangeCommitted);
            this.bind("txtXHouseNumber_TextChanged", this.txtXHouseNumber_TextChanged);
            this.bind("cboXPrefix_SelectionChangeCommitted", this.cboXPrefix_SelectionChangeCommitted);
            this.bind("txtXStreetName_TextChanged", this.txtXStreetName_TextChanged);
            this.bind("cboXStreetType_SelectionChangeCommitted", this.cboXStreetType_SelectionChangeCommitted);
            this.bind("cboXSuffix_SelectionChangeCommitted", this.cboXSuffix_SelectionChangeCommitted);
            this.bind("cboCityCode_SelectionChangeCommitted", this.cboCityCode_SelectionChangeCommitted);
            this.bind("cboPersonnel_Leave", this.cboPersonnel_Leave);
            this.bind("cboPosition_Leave", this.cboPosition_Leave);
            this.bind("cmdAddStaff_Click", this.cmdAddStaff_Click);
            this.bind("txtAmendTime_Leave", this.txtAmendTime_Leave);
            this.bind("txtAmendTime_TextChanged", this.txtAmendTime_TextChanged);
            this.bind("cboAmendReason_Leave", this.cboAmendReason_Leave);
            this.bind("cboAmendReason_SelectedIndexChanged", this.cboAmendReason_SelectedIndexChanged);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmIncident.prototype, "name", {
            get: function () {
                return "frmIncident";
            },
            enumerable: true,
            configurable: true
        });
        frmIncident.prototype.loaded = function () {
        };
        frmIncident.prototype.frmIncident_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmIncident", action: "frmIncident_Close" });
                e.preventDefault();
            }
        };
        frmIncident.prototype.cmdViewReport_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.chkSitFound_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cboUnit_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.chkExposures_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtNumberExposures_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtNumberExposures_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.chkCivilianCasualty_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtNumberCivCasulties_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.FDCaresBtn_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtNumberPatients_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtNumberPatients_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.optServiceReport_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cboEMSUnit_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.txtXHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cboXPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtXStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cboXStreetType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cboXSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cboCityCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.cboPersonnel_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cboPosition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cmdAddStaff_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmIncident.prototype.txtAmendTime_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.txtAmendTime_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cboAmendReason_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmIncident.prototype.cboAmendReason_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        return frmIncident;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmIncident.js.map