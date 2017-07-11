/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPPEInspHistory", [ "files/text!views/PTSProject.frmPPEInspHistory.html", "files/css!views/PTSProject.frmPPEInspHistory.css"],
    (htmlTemplate) => {
    return class frmPPEInspHistory extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("chkDisplayOption_CheckStateChanged",this.chkDisplayOption_CheckStateChanged);
this.bind("optAll_CheckedChanged",this.optAll_CheckedChanged);
this.bind("opt182_CheckedChanged",this.opt182_CheckedChanged);
this.bind("opt181_CheckedChanged",this.opt181_CheckedChanged);
this.bind("opt183_CheckedChanged",this.opt183_CheckedChanged);
this.bind("optA_CheckedChanged",this.optA_CheckedChanged);
this.bind("optC_CheckedChanged",this.optC_CheckedChanged);
this.bind("optB_CheckedChanged",this.optB_CheckedChanged);
this.bind("optD_CheckedChanged",this.optD_CheckedChanged);
this.bind("cboType_SelectionChangeCommitted",this.cboType_SelectionChangeCommitted);
this.bind("cboBrand_SelectionChangeCommitted",this.cboBrand_SelectionChangeCommitted);
this.bind("opt6Month_CheckedChanged",this.opt6Month_CheckedChanged);
this.bind("opt12Month_CheckedChanged",this.opt12Month_CheckedChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("chkInactive_CheckStateChanged",this.chkInactive_CheckStateChanged);
this.bind("cmdSearchNum_Click",this.cmdSearchNum_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdPrintList_Click",this.cmdPrintList_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPPEInspHistory";
            }

            public loaded() {

            }

        

        public frmPPEInspHistory_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPPEInspHistory",action:"frmPPEInspHistory_Close"});
                e.preventDefault();
            }
            
        }
        public chkDisplayOption_CheckStateChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAll_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt182_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt181_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt183_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optA_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optC_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optB_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optD_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboType_SelectionChangeCommitted(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBrand_SelectionChangeCommitted(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt6Month_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public opt12Month_CheckedChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkInactive_CheckStateChanged(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSearchNum_Click(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPPEInspHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintList_Click(sender: frmPPEInspHistory, action: string, e: any) {
            
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

