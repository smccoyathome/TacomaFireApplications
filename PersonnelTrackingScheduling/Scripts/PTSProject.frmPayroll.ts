/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPayroll", [ "files/text!views/PTSProject.frmPayroll.html", "files/css!views/PTSProject.frmPayroll.css"],
    (htmlTemplate) => {
    return class frmPayroll extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("cboBenefit_SelectionChangeCommitted",this.cboBenefit_SelectionChangeCommitted);
this.bind("cboUnit_SelectionChangeCommitted",this.cboUnit_SelectionChangeCommitted);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboClose_Click",this.cboClose_Click);
this.bind("cboPayPeriod_SelectionChangeCommitted",this.cboPayPeriod_SelectionChangeCommitted);
this.bind("cboAssignmentCode_SelectionChangeCommitted",this.cboAssignmentCode_SelectionChangeCommitted);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cmdReport_Click",this.cmdReport_Click);
this.bind("chkNotUploaded_CheckStateChanged",this.chkNotUploaded_CheckStateChanged);
this.bind("txtNameSearch_TextChanged",this.txtNameSearch_TextChanged);
this.bind("cmdPrintList_Click",this.cmdPrintList_Click);
this.bind("cmdUploadALL_Click",this.cmdUploadALL_Click);
this.bind("cmdOKToPay_Click",this.cmdOKToPay_Click);
this.bind("chkAll_CheckStateChanged",this.chkAll_CheckStateChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdSave_Click",this.cmdSave_Click);
this.bind("cboAAType1_SelectionChangeCommitted",this.cboAAType1_SelectionChangeCommitted);
this.bind("cboJobCode1_SelectionChangeCommitted",this.cboJobCode1_SelectionChangeCommitted);
this.bind("cmdApply1_Click",this.cmdApply1_Click);
this.bind("cboAAType2_SelectionChangeCommitted",this.cboAAType2_SelectionChangeCommitted);
this.bind("cboJobCode2_SelectionChangeCommitted",this.cboJobCode2_SelectionChangeCommitted);
this.bind("cmdApply2_Click",this.cmdApply2_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPayroll";
            }

            public loaded() {

            }

        

        public frmPayroll_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPayroll",action:"frmPayroll_Close"});
                e.preventDefault();
            }
            
        }
        public optAll_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBenefit_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnit_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClose_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPayPeriod_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAssignmentCode_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReport_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkNotUploaded_CheckStateChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtNameSearch_TextChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintList_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUploadALL_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdOKToPay_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkAll_CheckStateChanged(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType1_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode1_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply1_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType2_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode2_SelectionChangeCommitted(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply2_Click(sender: frmPayroll, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

