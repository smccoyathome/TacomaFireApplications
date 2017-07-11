/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.MDIIncident", [ "files/text!views/TFDIncident.MDIIncident.html", "files/css!views/TFDIncident.MDIIncident.css"],
    (htmlTemplate) => {
    return class MDIIncident extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("mnuExit_Click",this.mnuExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "MDIIncident";
            }

            public loaded() {
			
            }

        

        public MDIIncident_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"MDIIncident",action:"MDIIncident_Close"});
                e.preventDefault();
            }
            
        }
        public mnuExit_Click(sender: MDIIncident, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

