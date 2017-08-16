/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.wzdEms", ["files/text!views/TFDIncident.wzdEms.html", "files/css!views/TFDIncident.wzdEms.css", "usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
        return class wzdEms extends Mobilize.WebMap.Kendo.Ui.KendoView {
            constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings() {
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
                this.bind("dpBirthdate_Click", this.dpBirthdate_Click);
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
            }


            public get name() {
                return "wzdEms";
            }

            public loaded() {

            }



            public wzdEms_Close(e: any) {

                if (e.userTriggered) {
                    window.app.sendAction({ mainobj: this, controller: "wzdEms", action: "wzdEms_Close" });
                    e.preventDefault();
                }

            }
            public cboRoute_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboRoute_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboRate_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboRate_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtAmount_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboSite_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboSite_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboGauge_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboGauge_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public chkNoVitals_CheckStateChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtTime_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtTime_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboVitalsPosition_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboVitalsPosition_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtRespiration_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtPulse_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboECG_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtSystolic_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtDiastolic_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public chkPalp_CheckStateChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtGlucose_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtPulseOxy_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtPerOxy_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboEyes_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboEyes_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboVerbal_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboVerbal_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboMotor_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboMotor_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboMechCode_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboMechCode_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInjuryType_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInjuryType_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBodyPart_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBodyPart_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkMajTrauma_CheckStateChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPrimaryIllness_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPrimaryIllness_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optPupils_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public optLevelOfConsciouness_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public optRespiratoryEffort_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public optSeverity_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboTreatmentAuth_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTreatmentAuth_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtExtricationTime_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboMedications_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboMedications_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtDosage_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAddMedications_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRemoveMedication_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public FDCaresBtn_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncidentLocation_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncidentLocation_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtIncidentZipcode_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncidentSetting_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncidentSetting_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboResearchCode_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboResearchCode_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBaseStationContact_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBaseStationContact_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportBy_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportBy_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportTo_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportTo_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportFrom_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboTransportFrom_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtMileage_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboHospitalChosenBy_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboHospitalChosenBy_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboCPRPerformedBy_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboCPRPerformedBy_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optArrestToCPR_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cmdClear1_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optArrestToALS_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cmdClear2_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAddCPR_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optArrestToShock_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cmdClear3_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRemoveCPR_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtFirstName_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtLastName_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboState_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtZipCode_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public mskBirthdate_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public dpBirthdate_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtPatientAge_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPatientAgeUnits_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPatientAgeUnits_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optGender_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboRace_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboRace_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtTraumaID_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboProtectiveDevice_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboProtectiveDevice_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPatientLocation_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboPatientLocation_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstTrauma1_SelectedIndexChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstTrauma3_SelectedIndexChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstTrauma2_SelectedIndexChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboALSProcedures_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboALSProcedures_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtAttempts_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboALSPersonnel_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboALSPersonnel_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAddALS_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRemoveALSProcedures_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkCPRPerformed_CheckStateChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBLSProcedures_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboBLSProcedures_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtOtherBLSProcedures_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstBLSPersonnel_SelectedIndexChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAddBLS_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRemoveBLSProcedures_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optActionTaken_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtBFirstName_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtBLastName_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtBBirthdate_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtAge_TextChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboAgeUnits_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboAgeUnits_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optEMSGender_CheckedChanged(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboEMSRace_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboEMSRace_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboServiceProvided_SelectionChangeCommitted(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboServiceProvided_Leave(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSave_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSaveIncomplete_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAbandon_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public NavButton_Click(sender: wzdEms, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
           
        }

    });

