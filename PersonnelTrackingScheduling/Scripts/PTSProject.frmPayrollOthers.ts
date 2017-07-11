/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPayrollOthers", [ "files/text!views/PTSProject.frmPayrollOthers.html", "files/css!views/PTSProject.frmPayrollOthers.css"],
    (htmlTemplate) => {
    return class frmPayrollOthers extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboPayPeriod_SelectionChangeCommitted",this.cboPayPeriod_SelectionChangeCommitted);
this.bind("cboClose_Click",this.cboClose_Click);
this.bind("cmdPrintList_Click",this.cmdPrintList_Click);
this.bind("cmdOKToPay_Click",this.cmdOKToPay_Click);
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
                return "frmPayrollOthers";
            }

            public loaded() {

            }

        

        public frmPayrollOthers_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPayrollOthers",action:"frmPayrollOthers_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClear_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPayPeriod_SelectionChangeCommitted(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboClose_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintList_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdOKToPay_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSave_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType1_SelectionChangeCommitted(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode1_SelectionChangeCommitted(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply1_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboAAType2_SelectionChangeCommitted(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode2_SelectionChangeCommitted(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdApply2_Click(sender: frmPayrollOthers, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

