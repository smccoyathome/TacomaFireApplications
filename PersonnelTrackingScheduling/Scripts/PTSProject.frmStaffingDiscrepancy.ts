/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmStaffingDiscrepancy", [ "files/text!views/PTSProject.frmStaffingDiscrepancy.html", "files/css!views/PTSProject.frmStaffingDiscrepancy.css"],
    (htmlTemplate) => {
    return class frmStaffingDiscrepancy extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("chkDateFilter_CheckStateChanged",this.chkDateFilter_CheckStateChanged);
this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("dtStartDate_Click",this.dtStartDate_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("dtEndDate_Click",this.dtEndDate_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmStaffingDiscrepancy";
            }

            public loaded() {

            }

        

        public frmStaffingDiscrepancy_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmStaffingDiscrepancy",action:"frmStaffingDiscrepancy_Close"});
                e.preventDefault();
            }
            
        }
        public chkDateFilter_CheckStateChanged(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStartDate_Click(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEndDate_Click(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmStaffingDiscrepancy, action: string, e: any) {
            
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

