/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgIndSchedLegend", [ "files/text!views/PTSProject.dlgIndSchedLegend.html", "files/css!views/PTSProject.dlgIndSchedLegend.css"],
    (htmlTemplate) => {
    return class dlgIndSchedLegend extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgIndSchedLegend";
            }

            public loaded() {
			
            }

        

        public dlgIndSchedLegend_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgIndSchedLegend",action:"dlgIndSchedLegend_Close"});
                e.preventDefault();
            }
            
        }
        public CancelButton_Renamed_Click(sender: dlgIndSchedLegend, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

