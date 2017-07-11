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
define("TFDIncident.wzdEms", ["files/text!views/TFDIncident.wzdEms.html", "files/css!views/TFDIncident.wzdEms.css", "usercontrols/UpgradeHelpers_Gui_ShapeHelper"], function (htmlTemplate) {
    return (function (_super) {
        __extends(wzdEms, _super);
        function wzdEms(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        wzdEms.prototype.bindings = function () {
            this.bind("cboRoute_SelectionChangeCommitted", this.cboRoute_SelectionChangeCommitted);
            this.bind("cboRoute_Leave", this.cboRoute_Leave);
            this.bind("cboRate_SelectionChangeCommitted", this.cboRate_SelectionChangeCommitted);
            this.bind("cboRate_Leave", this.cboRate_Leave);
            this.bind("txtAmount_TextChanged", this.txtAmount_TextChanged);
            this.bind("cboSite_SelectionChangeCommitted", this.cboSite_SelectionChangeCommitted);
            this.bind("cboSite_Leave", this.cboSite_Leave);
            this.bind("cboGauge_SelectionChangeCommitted", this.cboGauge_SelectionChangeCommitted);
            this.bind("cboGauge_Leave", this.cboGauge_Leave);
            this.bind("chkNoVitals_CheckStateChanged", this.chkNoVitals_CheckStateChanged);
            this.bind("txtTime_TextChanged", this.txtTime_TextChanged);
            this.bind("txtTime_Leave", this.txtTime_Leave);
            this.bind("cboVitalsPosition_SelectionChangeCommitted", this.cboVitalsPosition_SelectionChangeCommitted);
            this.bind("cboVitalsPosition_Leave", this.cboVitalsPosition_Leave);
            this.bind("txtRespiration_TextChanged", this.txtRespiration_TextChanged);
            this.bind("txtPulse_TextChanged", this.txtPulse_TextChanged);
            this.bind("cboECG_Leave", this.cboECG_Leave);
            this.bind("txtSystolic_TextChanged", this.txtSystolic_TextChanged);
            this.bind("txtDiastolic_TextChanged", this.txtDiastolic_TextChanged);
            this.bind("chkPalp_CheckStateChanged", this.chkPalp_CheckStateChanged);
            this.bind("txtGlucose_TextChanged", this.txtGlucose_TextChanged);
            this.bind("txtPulseOxy_TextChanged", this.txtPulseOxy_TextChanged);
            this.bind("txtPerOxy_TextChanged", this.txtPerOxy_TextChanged);
            this.bind("cboEyes_SelectionChangeCommitted", this.cboEyes_SelectionChangeCommitted);
            this.bind("cboEyes_Leave", this.cboEyes_Leave);
            this.bind("cboVerbal_SelectionChangeCommitted", this.cboVerbal_SelectionChangeCommitted);
            this.bind("cboVerbal_Leave", this.cboVerbal_Leave);
            this.bind("cboMotor_SelectionChangeCommitted", this.cboMotor_SelectionChangeCommitted);
            this.bind("cboMotor_Leave", this.cboMotor_Leave);
            this.bind("cboMechCode_SelectionChangeCommitted", this.cboMechCode_SelectionChangeCommitted);
            this.bind("cboMechCode_Leave", this.cboMechCode_Leave);
            this.bind("cboInjuryType_SelectionChangeCommitted", this.cboInjuryType_SelectionChangeCommitted);
            this.bind("cboInjuryType_Leave", this.cboInjuryType_Leave);
            this.bind("cboBodyPart_SelectionChangeCommitted", this.cboBodyPart_SelectionChangeCommitted);
            this.bind("cboBodyPart_Leave", this.cboBodyPart_Leave);
            this.bind("chkMajTrauma_CheckStateChanged", this.chkMajTrauma_CheckStateChanged);
            this.bind("cboPrimaryIllness_SelectionChangeCommitted", this.cboPrimaryIllness_SelectionChangeCommitted);
            this.bind("cboPrimaryIllness_Leave", this.cboPrimaryIllness_Leave);
            this.bind("optPupils_CheckedChanged", this.optPupils_CheckedChanged);
            this.bind("optLevelOfConsciouness_CheckedChanged", this.optLevelOfConsciouness_CheckedChanged);
            this.bind("optRespiratoryEffort_CheckedChanged", this.optRespiratoryEffort_CheckedChanged);
            this.bind("optSeverity_CheckedChanged", this.optSeverity_CheckedChanged);
            this.bind("cboTreatmentAuth_SelectionChangeCommitted", this.cboTreatmentAuth_SelectionChangeCommitted);
            this.bind("cboTreatmentAuth_Leave", this.cboTreatmentAuth_Leave);
            this.bind("txtExtricationTime_TextChanged", this.txtExtricationTime_TextChanged);
            this.bind("cboMedications_SelectionChangeCommitted", this.cboMedications_SelectionChangeCommitted);
            this.bind("cboMedications_Leave", this.cboMedications_Leave);
            this.bind("txtDosage_TextChanged", this.txtDosage_TextChanged);
            this.bind("cmdAddMedications_Click", this.cmdAddMedications_Click);
            this.bind("cmdRemoveMedication_Click", this.cmdRemoveMedication_Click);
            this.bind("FDCaresBtn_Click", this.FDCaresBtn_Click);
            this.bind("cboIncidentLocation_SelectionChangeCommitted", this.cboIncidentLocation_SelectionChangeCommitted);
            this.bind("cboIncidentLocation_Leave", this.cboIncidentLocation_Leave);
            this.bind("txtIncidentZipcode_TextChanged", this.txtIncidentZipcode_TextChanged);
            this.bind("cboIncidentSetting_SelectionChangeCommitted", this.cboIncidentSetting_SelectionChangeCommitted);
            this.bind("cboIncidentSetting_Leave", this.cboIncidentSetting_Leave);
            this.bind("cboResearchCode_SelectionChangeCommitted", this.cboResearchCode_SelectionChangeCommitted);
            this.bind("cboResearchCode_Leave", this.cboResearchCode_Leave);
            this.bind("cboBaseStationContact_SelectionChangeCommitted", this.cboBaseStationContact_SelectionChangeCommitted);
            this.bind("cboBaseStationContact_Leave", this.cboBaseStationContact_Leave);
            this.bind("cboTransportBy_SelectionChangeCommitted", this.cboTransportBy_SelectionChangeCommitted);
            this.bind("cboTransportBy_Leave", this.cboTransportBy_Leave);
            this.bind("cboTransportTo_SelectionChangeCommitted", this.cboTransportTo_SelectionChangeCommitted);
            this.bind("cboTransportTo_Leave", this.cboTransportTo_Leave);
            this.bind("cboTransportFrom_SelectionChangeCommitted", this.cboTransportFrom_SelectionChangeCommitted);
            this.bind("cboTransportFrom_Leave", this.cboTransportFrom_Leave);
            this.bind("txtMileage_TextChanged", this.txtMileage_TextChanged);
            this.bind("cboHospitalChosenBy_SelectionChangeCommitted", this.cboHospitalChosenBy_SelectionChangeCommitted);
            this.bind("cboHospitalChosenBy_Leave", this.cboHospitalChosenBy_Leave);
            this.bind("cboCPRPerformedBy_SelectionChangeCommitted", this.cboCPRPerformedBy_SelectionChangeCommitted);
            this.bind("cboCPRPerformedBy_Leave", this.cboCPRPerformedBy_Leave);
            this.bind("optArrestToCPR_CheckedChanged", this.optArrestToCPR_CheckedChanged);
            this.bind("cmdClear1_Click", this.cmdClear1_Click);
            this.bind("optArrestToALS_CheckedChanged", this.optArrestToALS_CheckedChanged);
            this.bind("cmdClear2_Click", this.cmdClear2_Click);
            this.bind("cmdAddCPR_Click", this.cmdAddCPR_Click);
            this.bind("optArrestToShock_CheckedChanged", this.optArrestToShock_CheckedChanged);
            this.bind("cmdClear3_Click", this.cmdClear3_Click);
            this.bind("cmdRemoveCPR_Click", this.cmdRemoveCPR_Click);
            this.bind("txtFirstName_TextChanged", this.txtFirstName_TextChanged);
            this.bind("txtLastName_TextChanged", this.txtLastName_TextChanged);
            this.bind("cboState_Leave", this.cboState_Leave);
            this.bind("txtZipCode_TextChanged", this.txtZipCode_TextChanged);
            this.bind("mskBirthdate_Leave", this.mskBirthdate_Leave);
            this.bind("txtPatientAge_TextChanged", this.txtPatientAge_TextChanged);
            this.bind("cboPatientAgeUnits_SelectionChangeCommitted", this.cboPatientAgeUnits_SelectionChangeCommitted);
            this.bind("cboPatientAgeUnits_Leave", this.cboPatientAgeUnits_Leave);
            this.bind("optGender_CheckedChanged", this.optGender_CheckedChanged);
            this.bind("cboRace_SelectionChangeCommitted", this.cboRace_SelectionChangeCommitted);
            this.bind("cboRace_Leave", this.cboRace_Leave);
            this.bind("txtTraumaID_TextChanged", this.txtTraumaID_TextChanged);
            this.bind("cboProtectiveDevice_SelectionChangeCommitted", this.cboProtectiveDevice_SelectionChangeCommitted);
            this.bind("cboProtectiveDevice_Leave", this.cboProtectiveDevice_Leave);
            this.bind("cboPatientLocation_SelectionChangeCommitted", this.cboPatientLocation_SelectionChangeCommitted);
            this.bind("cboPatientLocation_Leave", this.cboPatientLocation_Leave);
            this.bind("lstTrauma1_SelectedIndexChanged", this.lstTrauma1_SelectedIndexChanged);
            this.bind("lstTrauma3_SelectedIndexChanged", this.lstTrauma3_SelectedIndexChanged);
            this.bind("lstTrauma2_SelectedIndexChanged", this.lstTrauma2_SelectedIndexChanged);
            this.bind("cboALSProcedures_SelectionChangeCommitted", this.cboALSProcedures_SelectionChangeCommitted);
            this.bind("cboALSProcedures_Leave", this.cboALSProcedures_Leave);
            this.bind("txtAttempts_TextChanged", this.txtAttempts_TextChanged);
            this.bind("cboALSPersonnel_SelectionChangeCommitted", this.cboALSPersonnel_SelectionChangeCommitted);
            this.bind("cboALSPersonnel_Leave", this.cboALSPersonnel_Leave);
            this.bind("cmdAddALS_Click", this.cmdAddALS_Click);
            this.bind("cmdRemoveALSProcedures_Click", this.cmdRemoveALSProcedures_Click);
            this.bind("chkCPRPerformed_CheckStateChanged", this.chkCPRPerformed_CheckStateChanged);
            this.bind("cboBLSProcedures_SelectionChangeCommitted", this.cboBLSProcedures_SelectionChangeCommitted);
            this.bind("cboBLSProcedures_Leave", this.cboBLSProcedures_Leave);
            this.bind("txtOtherBLSProcedures_TextChanged", this.txtOtherBLSProcedures_TextChanged);
            this.bind("lstBLSPersonnel_SelectedIndexChanged", this.lstBLSPersonnel_SelectedIndexChanged);
            this.bind("cmdAddBLS_Click", this.cmdAddBLS_Click);
            this.bind("cmdRemoveBLSProcedures_Click", this.cmdRemoveBLSProcedures_Click);
            this.bind("optActionTaken_CheckedChanged", this.optActionTaken_CheckedChanged);
            this.bind("txtBFirstName_TextChanged", this.txtBFirstName_TextChanged);
            this.bind("txtBLastName_TextChanged", this.txtBLastName_TextChanged);
            this.bind("txtBBirthdate_Leave", this.txtBBirthdate_Leave);
            this.bind("txtAge_TextChanged", this.txtAge_TextChanged);
            this.bind("cboAgeUnits_SelectionChangeCommitted", this.cboAgeUnits_SelectionChangeCommitted);
            this.bind("cboAgeUnits_Leave", this.cboAgeUnits_Leave);
            this.bind("optEMSGender_CheckedChanged", this.optEMSGender_CheckedChanged);
            this.bind("cboEMSRace_SelectionChangeCommitted", this.cboEMSRace_SelectionChangeCommitted);
            this.bind("cboEMSRace_Leave", this.cboEMSRace_Leave);
            this.bind("cboServiceProvided_SelectionChangeCommitted", this.cboServiceProvided_SelectionChangeCommitted);
            this.bind("cboServiceProvided_Leave", this.cboServiceProvided_Leave);
            this.bind("cmdSave_Click", this.cmdSave_Click);
            this.bind("cmdSaveIncomplete_Click", this.cmdSaveIncomplete_Click);
            this.bind("cmdAbandon_Click", this.cmdAbandon_Click);
            this.bind("NavButton_Click", this.NavButton_Click);
            //this.bindCloseEvent();
        };
        Object.defineProperty(wzdEms.prototype, "name", {
            get: function () {
                return "wzdEms";
            },
            enumerable: true,
            configurable: true
        });
        wzdEms.prototype.loaded = function () {
        };
        wzdEms.prototype.wzdEms_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "wzdEms", action: "wzdEms_Close" });
                e.preventDefault();
            }
        };
        wzdEms.prototype.cboRoute_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboRoute_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboRate_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboRate_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtAmount_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboSite_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboSite_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboGauge_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboGauge_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.chkNoVitals_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtTime_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtTime_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboVitalsPosition_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboVitalsPosition_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtRespiration_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtPulse_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboECG_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtSystolic_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtDiastolic_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.chkPalp_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtGlucose_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtPulseOxy_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtPerOxy_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboEyes_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboEyes_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboVerbal_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboVerbal_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboMotor_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboMotor_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboMechCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboMechCode_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboInjuryType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboInjuryType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBodyPart_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBodyPart_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.chkMajTrauma_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPrimaryIllness_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPrimaryIllness_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optPupils_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.optLevelOfConsciouness_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.optRespiratoryEffort_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.optSeverity_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboTreatmentAuth_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTreatmentAuth_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtExtricationTime_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboMedications_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboMedications_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtDosage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdAddMedications_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdRemoveMedication_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.FDCaresBtn_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboIncidentLocation_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboIncidentLocation_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtIncidentZipcode_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboIncidentSetting_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboIncidentSetting_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboResearchCode_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboResearchCode_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBaseStationContact_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBaseStationContact_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportBy_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportBy_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportTo_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportTo_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportFrom_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboTransportFrom_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtMileage_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboHospitalChosenBy_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboHospitalChosenBy_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboCPRPerformedBy_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboCPRPerformedBy_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optArrestToCPR_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cmdClear1_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optArrestToALS_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cmdClear2_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdAddCPR_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optArrestToShock_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cmdClear3_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdRemoveCPR_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtFirstName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtLastName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboState_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtZipCode_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.mskBirthdate_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtPatientAge_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPatientAgeUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPatientAgeUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optGender_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboRace_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboRace_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtTraumaID_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboProtectiveDevice_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboProtectiveDevice_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPatientLocation_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboPatientLocation_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.lstTrauma1_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.lstTrauma3_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.lstTrauma2_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboALSProcedures_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboALSProcedures_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtAttempts_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboALSPersonnel_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboALSPersonnel_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdAddALS_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdRemoveALSProcedures_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.chkCPRPerformed_CheckStateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBLSProcedures_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboBLSProcedures_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtOtherBLSProcedures_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.lstBLSPersonnel_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdAddBLS_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdRemoveBLSProcedures_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optActionTaken_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.txtBFirstName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtBLastName_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtBBirthdate_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.txtAge_TextChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboAgeUnits_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboAgeUnits_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.optEMSGender_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        wzdEms.prototype.cboEMSRace_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboEMSRace_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboServiceProvided_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cboServiceProvided_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdSave_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdSaveIncomplete_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.cmdAbandon_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        wzdEms.prototype.NavButton_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        return wzdEms;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.wzdEms.js.map