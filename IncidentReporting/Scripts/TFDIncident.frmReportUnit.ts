/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmReportUnit", [ "files/text!views/TFDIncident.frmReportUnit.html", "files/css!views/TFDIncident.frmReportUnit.css"],
    (htmlTemplate) => {
    return class frmReportUnit extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            
                //this.bindCloseEvent();
            }


            public get name() {
                return "frmReportUnit";
            }

            public loaded() {

            }

        

        public frmReportUnit_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmReportUnit",action:"frmReportUnit_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }

    }
   
});

