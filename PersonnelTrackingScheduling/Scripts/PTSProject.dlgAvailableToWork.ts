/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgAvailableToWork", [ "files/text!views/PTSProject.dlgAvailableToWork.html", "files/css!views/PTSProject.dlgAvailableToWork.css"],
    (htmlTemplate) => {
    return class dlgAvailableToWork extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("OKButton_Click",this.OKButton_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgAvailableToWork";
            }

            public loaded() {

            }

        

        public dlgAvailableToWork_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgAvailableToWork",action:"dlgAvailableToWork_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdPrint_Click(sender: dlgAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public OKButton_Click(sender: dlgAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

