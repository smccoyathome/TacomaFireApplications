/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmDailySCKLeaveReport", [ "files/text!views/PTSProject.frmDailySCKLeaveReport.html", "files/css!views/PTSProject.frmDailySCKLeaveReport.css"],
    (htmlTemplate) => {
    return class frmDailySCKLeaveReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("txtNameSearch_TextChanged",this.txtNameSearch_TextChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdEdit_Click",this.cmdEdit_Click);
this.bind("cmdUndo_Click",this.cmdUndo_Click);
this.bind("cmdApproved_Click",this.cmdApproved_Click);
this.bind("dtReportDate_Click",this.dtReportDate_Click);
this.bind("dtReportDate_ValueChanged",this.dtReportDate_ValueChanged);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("chkStaff_CheckStateChanged",this.chkStaff_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmDailySCKLeaveReport";
            }

            public loaded() {

            }

        

        public frmDailySCKLeaveReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmDailySCKLeaveReport",action:"frmDailySCKLeaveReport_Close"});
                e.preventDefault();
            }
            
        }
        public txtNameSearch_TextChanged(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEdit_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdUndo_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApproved_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_ValueChanged(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkStaff_CheckStateChanged(sender: frmDailySCKLeaveReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

