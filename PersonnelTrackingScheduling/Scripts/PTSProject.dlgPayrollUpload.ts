/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgPayrollUpload", [ "files/text!views/PTSProject.dlgPayrollUpload.html", "files/css!views/PTSProject.dlgPayrollUpload.css"],
    (htmlTemplate) => {
    return class dlgPayrollUpload extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgPayrollUpload";
            }

            public loaded() {

            }

        

        public dlgPayrollUpload_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgPayrollUpload",action:"dlgPayrollUpload_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdPrint_Click(sender: dlgPayrollUpload, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: dlgPayrollUpload, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

