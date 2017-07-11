/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgSignOff", [ "files/text!views/PTSProject.dlgSignOff.html", "files/css!views/PTSProject.dlgSignOff.css"],
    (htmlTemplate) => {
    return class dlgSignOff extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgSignOff";
            }

            public loaded() {

            }

        

        public dlgSignOff_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgSignOff",action:"dlgSignOff_Close"});
                e.preventDefault();
            }
            
        }
        public cboNameList_SelectionChangeCommitted(sender: dlgSignOff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: dlgSignOff, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: dlgSignOff, action: string, e: any) {
            
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

