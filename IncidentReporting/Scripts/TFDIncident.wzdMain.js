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
define("TFDIncident.wzdMain", ["files/text!views/TFDIncident.wzdMain.html", "files/css!views/TFDIncident.wzdMain.css"], function (htmlTemplate) {
    return (function (_super) {
        __extends(wzdMain, _super);
        function wzdMain(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        wzdMain.prototype.bindings = function () {
            this.bind("wzdMain_Activated", this.wzdMain_Activated);
            this.bind("chkCasualty_CheckStateChanged", this.chkCasualty_CheckStateChanged);
            this.bind("cmdClearPerson_Click", this.cmdClearPerson_Click);
            this.bind("cboPersonnel_SelectionChangeCommitted", this.cboPersonnel_SelectionChangeCommitted);
            this.bind("cboPosition_SelectionChangeCommitted", this.cboPosition_SelectionChangeCommitted);
            this.bind("chkExposure_CheckStateChanged", this.chkExposure_CheckStateChanged);
            this.bind("cmdAddStaff_Click", this.cmdAddStaff_Click);
            this.bind("txtAmendTime_Leave", this.txtAmendTime_Leave);
            this.bind("txtAmendTime_TextChanged", this.txtAmendTime_TextChanged);
            this.bind("cboAmendReason_SelectedIndexChanged", this.cboAmendReason_SelectedIndexChanged);
            this.bind("lstActionsTaken_SelectedIndexChanged", this.lstActionsTaken_SelectedIndexChanged);
            this.bind("lstReasonDelay_SelectedIndexChanged", this.lstReasonDelay_SelectedIndexChanged);
            this.bind("cboFPEEquipment_SelectionChangeCommitted", this.cboFPEEquipment_SelectionChangeCommitted);
            this.bind("cboFPEStatus_SelectionChangeCommitted", this.cboFPEStatus_SelectionChangeCommitted);
            this.bind("cboFPEProblem_SelectionChangeCommitted", this.cboFPEProblem_SelectionChangeCommitted);
            this.bind("cmdAddPPE_Click", this.cmdAddPPE_Click);
            this.bind("cmdRemovePPE_Click", this.cmdRemovePPE_Click);
            this.bind("cboInjurySeverity_SelectionChangeCommitted", this.cboInjurySeverity_SelectionChangeCommitted);
            this.bind("chkFPEProblem_CheckStateChanged", this.chkFPEProblem_CheckStateChanged);
            this.bind("cboActivity_SelectionChangeCommitted", this.cboActivity_SelectionChangeCommitted);
            this.bind("cboWhereOccured_SelectionChangeCommitted", this.cboWhereOccured_SelectionChangeCommitted);
            this.bind("cboInjuryCausedBy_SelectionChangeCommitted", this.cboInjuryCausedBy_SelectionChangeCommitted);
            this.bind("cboLocationAtInjury_SelectionChangeCommitted", this.cboLocationAtInjury_SelectionChangeCommitted);
            this.bind("chkAddressCorrection_CheckStateChanged", this.chkAddressCorrection_CheckStateChanged);
            this.bind("chkSitFound_CheckStateChanged", this.chkSitFound_CheckStateChanged);
            this.bind("txtNumberCivCasulties_TextChanged", this.txtNumberCivCasulties_TextChanged);
            this.bind("chkCivilianCasualty_CheckStateChanged", this.chkCivilianCasualty_CheckStateChanged);
            this.bind("FDCaresBtn_Click", this.FDCaresBtn_Click);
            this.bind("txtNumberPatients_TextChanged", this.txtNumberPatients_TextChanged);
            this.bind("optServiceReport_CheckedChanged", this.optServiceReport_CheckedChanged);
            this.bind("txtXHouseNumber_TextChanged", this.txtXHouseNumber_TextChanged);
            this.bind("cboXPrefix_SelectionChangeCommitted", this.cboXPrefix_SelectionChangeCommitted);
            this.bind("txtXStreetName_TextChanged", this.txtXStreetName_TextChanged);
            this.bind("cboXStreetType_SelectionChangeCommitted", this.cboXStreetType_SelectionChangeCommitted);
            this.bind("cboXSuffix_SelectionChangeCommitted", this.cboXSuffix_SelectionChangeCommitted);
            this.bind("cboCityCode_SelectionChangeCommitted", this.cboCityCode_SelectionChangeCommitted);
            this.bind("chkEMR_CheckStateChanged", this.chkEMR_CheckStateChanged);
            this.bind("cboEMSPatient_SelectionChangeCommitted", this.cboEMSPatient_SelectionChangeCommitted);
            this.bind("cboSeverity_SelectionChangeCommitted", this.cboSeverity_SelectionChangeCommitted);
            this.bind("cboAllInfo1_SelectionChangeCommitted", this.cboAllInfo1_SelectionChangeCommitted);
            this.bind("cboAllInfo2_SelectionChangeCommitted", this.cboAllInfo2_SelectionChangeCommitted);
            this.bind("cboAllInfo3_SelectionChangeCommitted", this.cboAllInfo3_SelectionChangeCommitted);
            this.bind("txtAllInfo1_TextChanged", this.txtAllInfo1_TextChanged);
            this.bind("cboServiceType_SelectionChangeCommitted", this.cboServiceType_SelectionChangeCommitted);
            this.bind("txtStandbyHours_TextChanged", this.txtStandbyHours_TextChanged);
            this.bind("txtNumberSafePlace_TextChanged", this.txtNumberSafePlace_TextChanged);
            this.bind("chkIC_CheckStateChanged", this.chkIC_CheckStateChanged);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cmdSaveIncomplete_Click", this.cmdSaveIncomplete_Click);
            this.bind("cmdAbandon_Click", this.cmdAbandon_Click);
            this.bind("NavButton_Click", this.NavButton_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(wzdMain.prototype, "name", {
            get: function () {
                return "wzdMain";
            },
            enumerable: true,
            configurable: true
        });
        wzdMain.prototype.loaded = function () {
            this.wzdMain_Activated(this, "wzdMain_Activated", null);
        };
        wzdMain.prototype.wzdMain_Activated = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.wzdMain_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "wzdMain", action: "wzdMain_Close" });
                e.preventDefault();
            }
        };
        wzdMain.prototype.chkCasualty_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.cmdClearPerson_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.cboPersonnel_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.cboPosition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.chkExposure_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.cmdAddStaff_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtAmendTime_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.txtAmendTime_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.cboAmendReason_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.lstActionsTaken_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.lstReasonDelay_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboFPEEquipment_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboFPEStatus_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboFPEProblem_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cmdAddPPE_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cmdRemovePPE_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboInjurySeverity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkFPEProblem_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboActivity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboWhereOccured_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboInjuryCausedBy_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboLocationAtInjury_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkAddressCorrection_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkSitFound_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.txtNumberCivCasulties_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkCivilianCasualty_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.FDCaresBtn_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtNumberPatients_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.optServiceReport_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdMain.prototype.txtXHouseNumber_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboXPrefix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtXStreetName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboXStreetType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboXSuffix_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboCityCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkEMR_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboEMSPatient_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboSeverity_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboAllInfo1_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboAllInfo2_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboAllInfo3_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtAllInfo1_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cboServiceType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtStandbyHours_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.txtNumberSafePlace_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.chkIC_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cmdSaveIncomplete_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.cmdAbandon_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdMain.prototype.NavButton_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        return wzdMain;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.wzdMain.js.map