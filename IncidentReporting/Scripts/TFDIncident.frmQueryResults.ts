/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmQueryResults", [ "files/text!views/TFDIncident.frmQueryResults.html", "files/css!views/TFDIncident.frmQueryResults.css"],
    (htmlTemplate) => {
    return class frmQueryResults extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmQueryResults";
            }

            public loaded() {

            }

        

        public frmQueryResults_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmQueryResults",action:"frmQueryResults_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmQueryResults, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmQueryResults, action: string, e: any) {
            
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

