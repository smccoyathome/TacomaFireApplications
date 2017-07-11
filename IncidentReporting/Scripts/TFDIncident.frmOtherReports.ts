/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmOtherReports", [ "files/text!views/TFDIncident.frmOtherReports.html", "files/css!views/TFDIncident.frmOtherReports.css"],
    (htmlTemplate) => {
    return class frmOtherReports extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdDone_Click",this.cmdDone_Click);
this.bind("cboFPEEquipment_SelectionChangeCommitted",this.cboFPEEquipment_SelectionChangeCommitted);
this.bind("cboFPEStatus_SelectionChangeCommitted",this.cboFPEStatus_SelectionChangeCommitted);
this.bind("cboFPEProblem_SelectionChangeCommitted",this.cboFPEProblem_SelectionChangeCommitted);
this.bind("cmdAddPPE_Click",this.cmdAddPPE_Click);
this.bind("cmdRemovePPE_Click",this.cmdRemovePPE_Click);
this.bind("cboInjurySeverity_SelectionChangeCommitted",this.cboInjurySeverity_SelectionChangeCommitted);
this.bind("cmdEDITFPE_Click",this.cmdEDITFPE_Click);
this.bind("chkFPEProblem_CheckStateChanged",this.chkFPEProblem_CheckStateChanged);
this.bind("cboActivity_SelectionChangeCommitted",this.cboActivity_SelectionChangeCommitted);
this.bind("cboWhereOccured_SelectionChangeCommitted",this.cboWhereOccured_SelectionChangeCommitted);
this.bind("cboInjuryCausedBy_SelectionChangeCommitted",this.cboInjuryCausedBy_SelectionChangeCommitted);
this.bind("cboLocationAtInjury_SelectionChangeCommitted",this.cboLocationAtInjury_SelectionChangeCommitted);
this.bind("cboCivNarrList_SelectionChangeCommitted",this.cboCivNarrList_SelectionChangeCommitted);
this.bind("chkEMR_CheckStateChanged",this.chkEMR_CheckStateChanged);
this.bind("cboEMSPatient_SelectionChangeCommitted",this.cboEMSPatient_SelectionChangeCommitted);
this.bind("cboSeverity_SelectionChangeCommitted",this.cboSeverity_SelectionChangeCommitted);
this.bind("cboInjuryCause_SelectionChangeCommitted",this.cboInjuryCause_SelectionChangeCommitted);
this.bind("cboCCLocation_SelectionChangeCommitted",this.cboCCLocation_SelectionChangeCommitted);
this.bind("cmdCivAddNarration_Click",this.cmdCivAddNarration_Click);
this.bind("cboServiceType_SelectionChangeCommitted",this.cboServiceType_SelectionChangeCommitted);
this.bind("txtStandbyHours_TextChanged",this.txtStandbyHours_TextChanged);
this.bind("txtNumberSafePlace_TextChanged",this.txtNumberSafePlace_TextChanged);
this.bind("cboServiceNarrList_SelectionChangeCommitted",this.cboServiceNarrList_SelectionChangeCommitted);
this.bind("cmdServAddNarration_Click",this.cmdServAddNarration_Click);
this.bind("cboNarrList_SelectionChangeCommitted",this.cboNarrList_SelectionChangeCommitted);
this.bind("cboAllInfo1_SelectionChangeCommitted",this.cboAllInfo1_SelectionChangeCommitted);
this.bind("cboAllInfo2_SelectionChangeCommitted",this.cboAllInfo2_SelectionChangeCommitted);
this.bind("cboAllInfo3_SelectionChangeCommitted",this.cboAllInfo3_SelectionChangeCommitted);
this.bind("txtAllInfo1_TextChanged",this.txtAllInfo1_TextChanged);
this.bind("cmdAddNarration_Click",this.cmdAddNarration_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmOtherReports";
            }

            public loaded() {
			
            }

        

        public frmOtherReports_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmOtherReports",action:"frmOtherReports_Close"});
                e.preventDefault();
            }
            
        }
        public cmdSave_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdDone_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFPEEquipment_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFPEStatus_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboFPEProblem_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddPPE_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemovePPE_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInjurySeverity_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEDITFPE_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkFPEProblem_CheckStateChanged(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboActivity_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboWhereOccured_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInjuryCausedBy_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboLocationAtInjury_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCivNarrList_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkEMR_CheckStateChanged(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEMSPatient_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSeverity_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboInjuryCause_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCCLocation_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCivAddNarration_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboServiceType_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtStandbyHours_TextChanged(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberSafePlace_TextChanged(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboServiceNarrList_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdServAddNarration_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNarrList_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAllInfo1_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAllInfo2_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAllInfo3_SelectionChangeCommitted(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtAllInfo1_TextChanged(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddNarration_Click(sender: frmOtherReports, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

