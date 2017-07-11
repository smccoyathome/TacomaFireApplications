/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgAddPPE", [ "files/text!views/PTSProject.dlgAddPPE.html", "files/css!views/PTSProject.dlgAddPPE.css"],
    (htmlTemplate) => {
    return class dlgAddPPE extends Mobilize.WebMap.Kendo.Ui.KendoView {
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
                return "dlgAddPPE";
            }

            public loaded() {

            }

        

        public dlgAddPPE_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgAddPPE",action:"dlgAddPPE_Close"});
                e.preventDefault();
            }
            
        }
        public OKButton_Click(sender: dlgAddPPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgAddPPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }

    }
   
});

