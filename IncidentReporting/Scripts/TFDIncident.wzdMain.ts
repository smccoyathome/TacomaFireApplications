/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.wzdMain", ["files/text!views/TFDIncident.wzdMain.html", "files/css!views/TFDIncident.wzdMain.css"],
    (htmlTemplate) => {
        return class wzdMain extends Mobilize.WebMap.Kendo.Ui.KendoView {
            constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings() {
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
            }


            public get name() {
                return "wzdMain";
            }

            public loaded() {

                this.wzdMain_Activated(this, "wzdMain_Activated", null);
            }


            public wzdMain_Activated(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }

            public wzdMain_Close(e: any) {

                if (e.userTriggered) {
                    window.app.sendAction({ mainobj: this, controller: "wzdMain", action: "wzdMain_Close" });
                    e.preventDefault();
                }

            }
            public chkCasualty_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cmdClearPerson_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboPersonnel_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboPosition_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public chkExposure_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cmdAddStaff_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtAmendTime_Leave(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtAmendTime_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboAmendReason_SelectedIndexChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public lstActionsTaken_SelectedIndexChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstReasonDelay_SelectedIndexChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboFPEEquipment_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboFPEStatus_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboFPEProblem_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAddPPE_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRemovePPE_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInjurySeverity_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkFPEProblem_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboActivity_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboWhereOccured_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInjuryCausedBy_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboLocationAtInjury_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkAddressCorrection_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkSitFound_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtNumberCivCasulties_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkCivilianCasualty_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public FDCaresBtn_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtNumberPatients_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optServiceReport_CheckedChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public txtXHouseNumber_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboXPrefix_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtXStreetName_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboXStreetType_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboXSuffix_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboCityCode_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkEMR_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboEMSPatient_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboSeverity_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboAllInfo1_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboAllInfo2_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboAllInfo3_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtAllInfo1_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboServiceType_SelectionChangeCommitted(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtStandbyHours_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public txtNumberSafePlace_TextChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public chkIC_CheckStateChanged(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSave_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSaveIncomplete_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdAbandon_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public NavButton_Click(sender: wzdMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }

        }

    });

