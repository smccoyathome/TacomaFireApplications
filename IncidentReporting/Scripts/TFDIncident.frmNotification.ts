/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmNotification", [ "files/text!views/TFDIncident.frmNotification.html", "files/css!views/TFDIncident.frmNotification.css"],
    (htmlTemplate) => {
    return class frmNotification extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdNext_Click",this.cmdNext_Click);
this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNotification";
            }

            public loaded() {
			
            }

        

        public frmNotification_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNotification",action:"frmNotification_Close"});
                e.preventDefault();
            }
            
        }
        public cmdNext_Click(sender: frmNotification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: frmNotification, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

