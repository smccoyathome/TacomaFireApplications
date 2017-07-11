/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUniformCheckList", [ "files/text!views/PTSProject.frmUniformCheckList.html", "files/css!views/PTSProject.frmUniformCheckList.css"],
    (htmlTemplate) => {
    return class frmUniformCheckList extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("cmdPrintChecklist_Click",this.cmdPrintChecklist_Click);
this.bind("chkOldFormat_CheckStateChanged",this.chkOldFormat_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUniformCheckList";
            }

            public loaded() {

            }

        

        public frmUniformCheckList_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUniformCheckList",action:"frmUniformCheckList_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmUniformCheckList, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintChecklist_Click(sender: frmUniformCheckList, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkOldFormat_CheckStateChanged(sender: frmUniformCheckList, action: string, e: any) {
            
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

