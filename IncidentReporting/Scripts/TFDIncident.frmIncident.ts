/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmIncident", [ "files/text!views/TFDIncident.frmIncident.html", "files/css!views/TFDIncident.frmIncident.css"],
    (htmlTemplate) => {
    return class frmIncident extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdViewReport_Click",this.cmdViewReport_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("chkSitFound_CheckStateChanged",this.chkSitFound_CheckStateChanged);
this.bind("cboUnit_SelectionChangeCommitted",this.cboUnit_SelectionChangeCommitted);
this.bind("chkExposures_CheckStateChanged",this.chkExposures_CheckStateChanged);
this.bind("txtNumberExposures_Leave",this.txtNumberExposures_Leave);
this.bind("txtNumberExposures_TextChanged",this.txtNumberExposures_TextChanged);
this.bind("chkCivilianCasualty_CheckStateChanged",this.chkCivilianCasualty_CheckStateChanged);
this.bind("txtNumberCivCasulties_TextChanged",this.txtNumberCivCasulties_TextChanged);
this.bind("FDCaresBtn_Click",this.FDCaresBtn_Click);
this.bind("txtNumberPatients_Leave",this.txtNumberPatients_Leave);
this.bind("txtNumberPatients_TextChanged",this.txtNumberPatients_TextChanged);
this.bind("optServiceReport_CheckedChanged",this.optServiceReport_CheckedChanged);
this.bind("cboEMSUnit_SelectionChangeCommitted",this.cboEMSUnit_SelectionChangeCommitted);
this.bind("txtXHouseNumber_TextChanged",this.txtXHouseNumber_TextChanged);
this.bind("cboXPrefix_SelectionChangeCommitted",this.cboXPrefix_SelectionChangeCommitted);
this.bind("txtXStreetName_TextChanged",this.txtXStreetName_TextChanged);
this.bind("cboXStreetType_SelectionChangeCommitted",this.cboXStreetType_SelectionChangeCommitted);
this.bind("cboXSuffix_SelectionChangeCommitted",this.cboXSuffix_SelectionChangeCommitted);
this.bind("cboCityCode_SelectionChangeCommitted",this.cboCityCode_SelectionChangeCommitted);
this.bind("cboPersonnel_Leave",this.cboPersonnel_Leave);
this.bind("cboPosition_Leave",this.cboPosition_Leave);
this.bind("cmdAddStaff_Click",this.cmdAddStaff_Click);
this.bind("txtAmendTime_Leave",this.txtAmendTime_Leave);
this.bind("txtAmendTime_TextChanged",this.txtAmendTime_TextChanged);
this.bind("cboAmendReason_Leave",this.cboAmendReason_Leave);
this.bind("cboAmendReason_SelectedIndexChanged",this.cboAmendReason_SelectedIndexChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIncident";
            }

            public loaded() {
			
            }

        

        public frmIncident_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIncident",action:"frmIncident_Close"});
                e.preventDefault();
            }
            
        }
        public cmdViewReport_Click(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkSitFound_CheckStateChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboUnit_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public chkExposures_CheckStateChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberExposures_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberExposures_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkCivilianCasualty_CheckStateChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberCivCasulties_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public FDCaresBtn_Click(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberPatients_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNumberPatients_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optServiceReport_CheckedChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboEMSUnit_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public txtXHouseNumber_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXPrefix_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtXStreetName_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXStreetType_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboXSuffix_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCityCode_SelectionChangeCommitted(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPersonnel_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboPosition_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdAddStaff_Click(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtAmendTime_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public txtAmendTime_TextChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboAmendReason_Leave(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cboAmendReason_SelectedIndexChanged(sender: frmIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }

    }
   
});

