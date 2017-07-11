/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPayrollBCStaff", [ "files/text!views/PTSProject.frmPayrollBCStaff.html", "files/css!views/PTSProject.frmPayrollBCStaff.css"],
    (htmlTemplate) => {
    return class frmPayrollBCStaff extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboPayPeriod_SelectionChangeCommitted",this.cboPayPeriod_SelectionChangeCommitted);
this.bind("cboClose_Click",this.cboClose_Click);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("cmdPrintList_Click",this.cmdPrintList_Click);
this.bind("chkAll_CheckStateChanged",this.chkAll_CheckStateChanged);
this.bind("cmdOKToPay_Click",this.cmdOKToPay_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cmdApprove_Click",this.cmdApprove_Click);
this.bind("cboAAType1_SelectionChangeCommitted",this.cboAAType1_SelectionChangeCommitted);
this.bind("cboJobCode1_SelectionChangeCommitted",this.cboJobCode1_SelectionChangeCommitted);
this.bind("cmdApply1_Click",this.cmdApply1_Click);
this.bind("cboAAType2_SelectionChangeCommitted",this.cboAAType2_SelectionChangeCommitted);
this.bind("cboJobCode2_SelectionChangeCommitted",this.cboJobCode2_SelectionChangeCommitted);
this.bind("cmdApply2_Click",this.cmdApply2_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPayrollBCStaff";
            }

            public loaded() {

            }

        

        public frmPayrollBCStaff_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPayrollBCStaff",action:"frmPayrollBCStaff_Close"});
                e.preventDefault();
            }
            
        }
        public cboPayPeriod_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClose_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintList_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkAll_CheckStateChanged(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdOKToPay_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApprove_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType1_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode1_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply1_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType2_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode2_SelectionChangeCommitted(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply2_Click(sender: frmPayrollBCStaff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

