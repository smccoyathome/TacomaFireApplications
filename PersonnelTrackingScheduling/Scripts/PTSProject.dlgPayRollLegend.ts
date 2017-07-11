/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgPayRollLegend", [ "files/text!views/PTSProject.dlgPayRollLegend.html", "files/css!views/PTSProject.dlgPayRollLegend.css"],
    (htmlTemplate) => {
    return class dlgPayRollLegend extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgPayRollLegend";
            }

            public loaded() {
			
            }

        

        public dlgPayRollLegend_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgPayRollLegend",action:"dlgPayRollLegend_Close"});
                e.preventDefault();
            }
            
        }
        public cmdCancel_Click(sender: dlgPayRollLegend, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

