/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmKOTAudit", [ "files/text!views/PTSProject.frmKOTAudit.html", "files/css!views/PTSProject.frmKOTAudit.css"],
    (htmlTemplate) => {
    return class frmKOTAudit extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            
                //this.bindCloseEvent();
            }


            public get name() {
                return "frmKOTAudit";
            }

            public loaded() {

            }

        

        public frmKOTAudit_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmKOTAudit",action:"frmKOTAudit_Close"});
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

