/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgBattLegend", [ "files/text!views/PTSProject.dlgBattLegend.html", "files/css!views/PTSProject.dlgBattLegend.css"],
    (htmlTemplate) => {
    return class dlgBattLegend extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgBattLegend";
            }

            public loaded() {
			
            }

        

        public dlgBattLegend_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgBattLegend",action:"dlgBattLegend_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: dlgBattLegend, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

