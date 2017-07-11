/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.Form1", [ "files/text!views/TFDIncident.Form1.html", "files/css!views/TFDIncident.Form1.css"],
    (htmlTemplate) => {
    return class Form1 extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            
                //this.bindCloseEvent();
            }


            public get name() {
                return "Form1";
            }

            public loaded() {
			
            }

        

        public Form1_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"Form1",action:"Form1_Close"});
                e.preventDefault();
            }
            
        }

    }
   
});

