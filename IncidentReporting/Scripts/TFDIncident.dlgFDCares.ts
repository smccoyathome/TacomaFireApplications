/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.dlgFDCares", [ "files/text!views/TFDIncident.dlgFDCares.html", "files/css!views/TFDIncident.dlgFDCares.css"],
    (htmlTemplate) => {
    return class dlgFDCares extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("OKButton_Click",this.OKButton_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgFDCares";
            }

            public loaded() {
			
            }

        

        public dlgFDCares_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgFDCares",action:"dlgFDCares_Close"});
                e.preventDefault();
            }
            
        }
        public OKButton_Click(sender: dlgFDCares, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgFDCares, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

