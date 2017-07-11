/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmWatchDutyAssignment", [ "files/text!views/PTSProject.frmWatchDutyAssignment.html", "files/css!views/PTSProject.frmWatchDutyAssignment.css"],
    (htmlTemplate) => {
    return class frmWatchDutyAssignment extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("dtReportDate_Click",this.dtReportDate_Click);
this.bind("dtReportDate_ValueChanged",this.dtReportDate_ValueChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboLocation_SelectionChangeCommitted",this.cboLocation_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("chkOnlyAssigned_CheckStateChanged",this.chkOnlyAssigned_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmWatchDutyAssignment";
            }

            public loaded() {

            }

        

        public frmWatchDutyAssignment_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmWatchDutyAssignment",action:"frmWatchDutyAssignment_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_Click(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_ValueChanged(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboLocation_SelectionChangeCommitted(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkOnlyAssigned_CheckStateChanged(sender: frmWatchDutyAssignment, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }

    }
   
});

