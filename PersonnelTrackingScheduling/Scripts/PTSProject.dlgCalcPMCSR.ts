/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgCalcPMCSR", [ "files/text!views/PTSProject.dlgCalcPMCSR.html", "files/css!views/PTSProject.dlgCalcPMCSR.css"],
    (htmlTemplate) => {
    return class dlgCalcPMCSR extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);
this.bind("cmdCalculate_Click",this.cmdCalculate_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgCalcPMCSR";
            }

            public loaded() {
			
            }

        

        public dlgCalcPMCSR_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgCalcPMCSR",action:"dlgCalcPMCSR_Close"});
                e.preventDefault();
            }
            
        }
        public CancelButton_Renamed_Click(sender: dlgCalcPMCSR, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCalculate_Click(sender: dlgCalcPMCSR, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

