/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndSched", [ "files/text!views/PTSProject.frmIndSched.html", "files/css!views/PTSProject.frmIndSched.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmIndSched extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmIndSched_Activated",this.frmIndSched_Activated);
this.bind("frmIndSched_Deactivate",this.frmIndSched_Deactivate);
this.bind("calSched_Click",this.calSched_Click);
this.bind("calSched_DoubleClick",this.calSched_DoubleClick);
this.bind("cmdAvailable_Click",this.cmdAvailable_Click);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdNotes_Click",this.cmdNotes_Click);
this.bind("cmdAdjustHOLMax_Click",this.cmdAdjustHOLMax_Click);
this.bind("chkRecert_CheckStateChanged",this.chkRecert_CheckStateChanged);
this.bind("cmdCallBack_Click",this.cmdCallBack_Click);
this.bind("chkSCKflag_CheckStateChanged",this.chkSCKflag_CheckStateChanged);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdSenority_Click",this.cmdSenority_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdSchedReport_Click",this.cmdSchedReport_Click);
this.bind("cmdTimeCard_Click",this.cmdTimeCard_Click);
this.bind("cmdRequestVAC_Click",this.cmdRequestVAC_Click);
this.bind("cmdReqTransfer_Click",this.cmdReqTransfer_Click);
this.bind("cmdContacts_Click",this.cmdContacts_Click);
this.bind("cmdAddress_Click",this.cmdAddress_Click);
this.bind("cmdPhone_Click",this.cmdPhone_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndSched";
            }

            public loaded() {
			
            }

        
        public frmIndSched_Activated(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmIndSched_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndSched",action:"frmIndSched_Close"});
                e.preventDefault();
            }
            
        }
        public frmIndSched_Deactivate(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calSched_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calSched_DoubleClick(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAvailable_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNotes_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdjustHOLMax_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkRecert_CheckStateChanged(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCallBack_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkSCKflag_CheckStateChanged(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSenority_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSchedReport_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdTimeCard_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRequestVAC_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReqTransfer_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdContacts_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddress_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPhone_Click(sender: frmIndSched, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

