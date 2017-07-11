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
define("TFDIncident.frmOtherReports", ["files/text!views/TFDIncident.frmOtherReports.html", "files/css!views/TFDIncident.frmOtherReports.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmOtherReports, _super);
        function frmOtherReports(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmOtherReports.prototype.bindings = function () {
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cmdDone_Click", this.cmdDone_Click);
            this.bind("cboFPEEquipment_SelectionChangeCommitted", this.cboFPEEquipment_SelectionChangeCommitted);
            this.bind("cboFPEStatus_SelectionChangeCommitted", this.cboFPEStatus_SelectionChangeCommitted);
            this.bind("cboFPEProblem_SelectionChangeCommitted", this.cboFPEProblem_SelectionChangeCommitted);
            this.bind("cmdAddPPE_Click", this.cmdAddPPE_Click);
            this.bind("cmdRemovePPE_Click", this.cmdRemovePPE_Click);
            this.bind("cboInjurySeverity_SelectionChangeCommitted", this.cboInjurySeverity_SelectionChangeCommitted);
            this.bind("cmdEDITFPE_Click", this.cmdEDITFPE_Click);
            this.bind("chkFPEProblem_CheckStateChanged", this.chkFPEProblem_CheckStateChanged);
            this.bind("cboActivity_SelectionChangeCommitted", this.cboActivity_SelectionChangeCommitted);
            this.bind("cboWhereOccured_SelectionChangeCommitted", this.cboWhereOccured_SelectionChangeCommitted);
            this.bind("cboInjuryCausedBy_SelectionChangeCommitted", this.cboInjuryCausedBy_SelectionChangeCommitted);
            this.bind("cboLocationAtInjury_SelectionChangeCommitted", this.cboLocationAtInjury_SelectionChangeCommitted);
            this.bind("cboCivNarrList_SelectionChangeCommitted", this.cboCivNarrList_SelectionChangeCommitted);
            this.bind("chkEMR_CheckStateChanged", this.chkEMR_CheckStateChanged);
            this.bind("cboEMSPatient_SelectionChangeCommitted", this.cboEMSPatient_SelectionChangeCommitted);
            this.bind("cboSeverity_SelectionChangeCommitted", this.cboSeverity_SelectionChangeCommitted);
            this.bind("cboInjuryCause_SelectionChangeCommitted", this.cboInjuryCause_SelectionChangeCommitted);
            this.bind("cboCCLocation_SelectionChangeCommitted", this.cboCCLocation_SelectionChangeCommitted);
            this.bind("cmdCivAddNarration_Click", this.cmdCivAddNarration_Click);
            this.bind("cboServiceType_SelectionChangeCommitted", this.cboServiceType_SelectionChangeCommitted);
            this.bind("txtStandbyHours_TextChanged", this.txtStandbyHours_TextChanged);
            this.bind("txtNumberSafePlace_TextChanged", this.txtNumberSafePlace_TextChanged);
            this.bind("cboServiceNarrList_SelectionChangeCommitted", this.cboServiceNarrList_SelectionChangeCommitted);
            this.bind("cmdServAddNarration_Click", this.cmdServAddNarration_Click);
            this.bind("cboNarrList_SelectionChangeCommitted", this.cboNarrList_SelectionChangeCommitted);
            this.bind("cboAllInfo1_SelectionChangeCommitted", this.cboAllInfo1_SelectionChangeCommitted);
            this.bind("cboAllInfo2_SelectionChangeCommitted", this.cboAllInfo2_SelectionChangeCommitted);
            this.bind("cboAllInfo3_SelectionChangeCommitted", this.cboAllInfo3_SelectionChangeCommitted);
            this.bind("txtAllInfo1_TextChanged", this.txtAllInfo1_TextChanged);
            this.bind("cmdAddNarration_Click", this.cmdAddNarration_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmOtherReports.prototype, "name", {
            get: function () {
                return "frmOtherReports";
            },
            enumerable: true,
            configurable: true
        });
        frmOtherReports.prototype.loaded = function () {
        };
        frmOtherReports.prototype.frmOtherReports_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmOtherReports", action: "frmOtherReports_Close" });
                e.preventDefault();
            }
        };
        frmOtherReports.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmOtherReports.prototype.cmdDone_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboFPEEquipment_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboFPEStatus_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboFPEProblem_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdAddPPE_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdRemovePPE_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboInjurySeverity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdEDITFPE_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.chkFPEProblem_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboActivity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboWhereOccured_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboInjuryCausedBy_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboLocationAtInjury_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboCivNarrList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.chkEMR_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboEMSPatient_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboSeverity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboInjuryCause_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboCCLocation_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdCivAddNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboServiceType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.txtStandbyHours_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.txtNumberSafePlace_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboServiceNarrList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdServAddNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboNarrList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboAllInfo1_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboAllInfo2_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cboAllInfo3_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.txtAllInfo1_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmOtherReports.prototype.cmdAddNarration_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmOtherReports;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmOtherReports.js.map