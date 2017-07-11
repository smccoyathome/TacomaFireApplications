/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUtility", [ "files/text!views/PTSProject.frmUtility.html", "files/css!views/PTSProject.frmUtility.css"],
    (htmlTemplate) => {
    return class frmUtility extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboAction_SelectionChangeCommitted",this.cboAction_SelectionChangeCommitted);
this.bind("cmdGo_Click",this.cmdGo_Click);
this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUtility";
            }

            public loaded() {
			
            }

        

        public frmUtility_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUtility",action:"frmUtility_Close"});
                e.preventDefault();
            }
            
        }
        public cboAction_SelectionChangeCommitted(sender: frmUtility, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdGo_Click(sender: frmUtility, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmUtility, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

