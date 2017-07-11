/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUniformRepairHistory", [ "files/text!views/PTSProject.frmUniformRepairHistory.html", "files/css!views/PTSProject.frmUniformRepairHistory.css"],
    (htmlTemplate) => {
    return class frmUniformRepairHistory extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdFind_Click",this.cmdFind_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("chkDateIn_CheckStateChanged",this.chkDateIn_CheckStateChanged);
this.bind("chkDateOut_CheckStateChanged",this.chkDateOut_CheckStateChanged);
this.bind("cmdNewItem_Click",this.cmdNewItem_Click);
this.bind("cmdEdit_Click",this.cmdEdit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUniformRepairHistory";
            }

            public loaded() {

            }

        

        public frmUniformRepairHistory_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUniformRepairHistory",action:"frmUniformRepairHistory_Close"});
                e.preventDefault();
            }
            
        }
        public cmdFind_Click(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkDateIn_CheckStateChanged(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkDateOut_CheckStateChanged(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewItem_Click(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEdit_Click(sender: frmUniformRepairHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

