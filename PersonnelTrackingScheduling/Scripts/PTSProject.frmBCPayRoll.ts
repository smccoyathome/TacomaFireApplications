/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmBCPayRoll", [ "files/text!views/PTSProject.frmBCPayRoll.html", "files/css!views/PTSProject.frmBCPayRoll.css"],
    (htmlTemplate) => {
    return class frmBCPayRoll extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboPayPeriod_SelectionChangeCommitted",this.cboPayPeriod_SelectionChangeCommitted);
this.bind("dtReportDate_Click",this.dtReportDate_Click);
this.bind("dtReportDate_ValueChanged",this.dtReportDate_ValueChanged);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboClose_Click",this.cboClose_Click);
this.bind("cmdPrintList_Click",this.cmdPrintList_Click);
this.bind("cmdAllPayroll_Click",this.cmdAllPayroll_Click);
this.bind("cmdOKToPay_Click",this.cmdOKToPay_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdNotes_Click",this.cmdNotes_Click);
this.bind("cboAAType1_SelectionChangeCommitted",this.cboAAType1_SelectionChangeCommitted);
this.bind("cboJobCode1_SelectionChangeCommitted",this.cboJobCode1_SelectionChangeCommitted);
this.bind("cmdApply1_Click",this.cmdApply1_Click);
this.bind("cboAAType2_SelectionChangeCommitted",this.cboAAType2_SelectionChangeCommitted);
this.bind("cboJobCode2_SelectionChangeCommitted",this.cboJobCode2_SelectionChangeCommitted);
this.bind("cmdApply2_Click",this.cmdApply2_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmBCPayRoll";
            }

            public loaded() {

            }

        

        public frmBCPayRoll_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmBCPayRoll",action:"frmBCPayRoll_Close"});
                e.preventDefault();
            }
            
        }
        public cboPayPeriod_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_ValueChanged(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClose_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintList_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAllPayroll_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOKToPay_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdPrint_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNotes_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType1_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode1_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply1_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType2_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode2_SelectionChangeCommitted(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply2_Click(sender: frmBCPayRoll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

