/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgExport", [ "files/text!views/PTSProject.dlgExport.html", "files/css!views/PTSProject.dlgExport.css"],
    (htmlTemplate) => {
    return class dlgExport extends Mobilize.WebMap.Kendo.Ui.KendoView {
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
                return "dlgExport";
            }

            public loaded() {
			
            }

        

        public dlgExport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgExport",action:"dlgExport_Close"});
                e.preventDefault();
            }
            
        }
        public OKButton_Click(sender: dlgExport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgExport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

