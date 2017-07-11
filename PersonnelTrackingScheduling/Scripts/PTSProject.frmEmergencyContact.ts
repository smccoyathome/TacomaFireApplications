/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmEmergencyContact", [ "files/text!views/PTSProject.frmEmergencyContact.html", "files/css!views/PTSProject.frmEmergencyContact.css"],
    (htmlTemplate) => {
    return class frmEmergencyContact extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("lstContacts_SelectedIndexChanged",this.lstContacts_SelectedIndexChanged);
this.bind("lstPhone_SelectedIndexChanged",this.lstPhone_SelectedIndexChanged);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdDelPhone_Click",this.cmdDelPhone_Click);
this.bind("cmdAddPhone_Click",this.cmdAddPhone_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmEmergencyContact";
            }

            public loaded() {
			
            }

        

        public frmEmergencyContact_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmEmergencyContact",action:"frmEmergencyContact_Close"});
                e.preventDefault();
            }
            
        }
        public cboEmpList_SelectionChangeCommitted(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstContacts_SelectedIndexChanged(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstPhone_SelectedIndexChanged(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelPhone_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddPhone_Click(sender: frmEmergencyContact, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

