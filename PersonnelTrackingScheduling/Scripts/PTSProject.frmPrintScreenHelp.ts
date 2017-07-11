/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPrintScreenHelp", [ "files/text!views/PTSProject.frmPrintScreenHelp.html", "files/css!views/PTSProject.frmPrintScreenHelp.css"],
    (htmlTemplate) => {
    return class frmPrintScreenHelp extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            
                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPrintScreenHelp";
            }

            public loaded() {
			
            }

        

        public frmPrintScreenHelp_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPrintScreenHelp",action:"frmPrintScreenHelp_Close"});
                e.preventDefault();
            }
            
        }

    }
   
});

