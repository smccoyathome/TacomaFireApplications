/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmGrantVACRequest", [ "files/text!views/PTSProject.frmGrantVACRequest.html", "files/css!views/PTSProject.frmGrantVACRequest.css"],
    (htmlTemplate) => {
    return class frmGrantVACRequest extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            
                //this.bindCloseEvent();
            }


            public get name() {
                return "frmGrantVACRequest";
            }

            public loaded() {

            }

        

        public frmGrantVACRequest_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmGrantVACRequest",action:"frmGrantVACRequest_Close"});
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

