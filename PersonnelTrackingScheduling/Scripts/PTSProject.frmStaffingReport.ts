/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmStaffingReport", [ "files/text!views/PTSProject.frmStaffingReport.html", "files/css!views/PTSProject.frmStaffingReport.css"],
    (htmlTemplate) => {
    return class frmStaffingReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboMonth_SelectionChangeCommitted",this.cboMonth_SelectionChangeCommitted);
this.bind("cmdRunReport_Click",this.cmdRunReport_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("optWorking_CheckedChanged",this.optWorking_CheckedChanged);
this.bind("optCallback_CheckedChanged",this.optCallback_CheckedChanged);
this.bind("optCSRs_CheckedChanged",this.optCSRs_CheckedChanged);
this.bind("cmdPrintDetail_Click",this.cmdPrintDetail_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmStaffingReport";
            }

            public loaded() {

            }

        

        public frmStaffingReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmStaffingReport",action:"frmStaffingReport_Close"});
                e.preventDefault();
            }
            
        }
        public cboYear_SelectionChangeCommitted(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboMonth_SelectionChangeCommitted(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRunReport_Click(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public optWorking_CheckedChanged(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optCallback_CheckedChanged(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optCSRs_CheckedChanged(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintDetail_Click(sender: frmStaffingReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

