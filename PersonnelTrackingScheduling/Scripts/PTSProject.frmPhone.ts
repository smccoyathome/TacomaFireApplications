/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPhone", [ "files/text!views/PTSProject.frmPhone.html", "files/css!views/PTSProject.frmPhone.css"],
    (htmlTemplate) => {
    return class frmPhone extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cboResource_SelectionChangeCommitted",this.cboResource_SelectionChangeCommitted);
this.bind("lstPhone_SelectedIndexChanged",this.lstPhone_SelectedIndexChanged);
this.bind("chkCallBack_CheckStateChanged",this.chkCallBack_CheckStateChanged);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPhone";
            }

            public loaded() {
			
            }

        

        public frmPhone_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPhone",action:"frmPhone_Close"});
                e.preventDefault();
            }
            
        }
        public cboEmpList_SelectionChangeCommitted(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboResource_SelectionChangeCommitted(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstPhone_SelectedIndexChanged(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkCallBack_CheckStateChanged(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPhone, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

