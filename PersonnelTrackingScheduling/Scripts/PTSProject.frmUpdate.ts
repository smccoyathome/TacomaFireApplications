/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUpdate", [ "files/text!views/PTSProject.frmUpdate.html", "files/css!views/PTSProject.frmUpdate.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmUpdate extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdSwitch_Click",this.cmdSwitch_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cboJobCode_SelectionChangeCommitted",this.cboJobCode_SelectionChangeCommitted);
this.bind("cmdNote_Click",this.cmdNote_Click);
this.bind("cmdEmergency_Click",this.cmdEmergency_Click);
this.bind("txtMName_Leave",this.txtMName_Leave);
this.bind("cmdPhone_Click",this.cmdPhone_Click);
this.bind("txtSex_TextChanged",this.txtSex_TextChanged);
this.bind("cmdAddress_Click",this.cmdAddress_Click);
this.bind("cmdVerify_Click",this.cmdVerify_Click);
this.bind("cmdChangeCC_Click",this.cmdChangeCC_Click);
this.bind("cmdUndo_Click",this.cmdUndo_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdAssign_Click",this.cmdAssign_Click);
this.bind("cmdNewPromo_Click",this.cmdNewPromo_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUpdate";
            }

            public loaded() {
			
            }

        

        public frmUpdate_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUpdate",action:"frmUpdate_Close"});
                e.preventDefault();
            }
            
        }
        public cmdSwitch_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode_SelectionChangeCommitted(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNote_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEmergency_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtMName_Leave(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPhone_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtSex_TextChanged(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddress_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdVerify_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdChangeCC_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUndo_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAssign_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewPromo_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmUpdate, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

