/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmSecurity", [ "files/text!views/PTSProject.frmSecurity.html", "files/css!views/PTSProject.frmSecurity.css"],
    (htmlTemplate) => {
    return class frmSecurity extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cmdNext_Click",this.cmdNext_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmSecurity";
            }

            public loaded() {
			
            }

        

        public frmSecurity_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmSecurity",action:"frmSecurity_Close"});
                e.preventDefault();
            }
            
        }
        public cboEmpList_SelectionChangeCommitted(sender: frmSecurity, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNext_Click(sender: frmSecurity, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmSecurity, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmSecurity, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

