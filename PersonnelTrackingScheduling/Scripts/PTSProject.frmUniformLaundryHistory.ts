/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUniformLaundryHistory", [ "files/text!views/PTSProject.frmUniformLaundryHistory.html", "files/css!views/PTSProject.frmUniformLaundryHistory.css"],
    (htmlTemplate) => {
    return class frmUniformLaundryHistory extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdFind_Click",this.cmdFind_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("chkFlagged_CheckStateChanged",this.chkFlagged_CheckStateChanged);
this.bind("chkCleaned_CheckStateChanged",this.chkCleaned_CheckStateChanged);
this.bind("chkVendor_CheckStateChanged",this.chkVendor_CheckStateChanged);
this.bind("cmdNewItem_Click",this.cmdNewItem_Click);
this.bind("cmdEdit_Click",this.cmdEdit_Click);
this.bind("chkApproved_CheckStateChanged",this.chkApproved_CheckStateChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUniformLaundryHistory";
            }

            public loaded() {

            }

        

        public frmUniformLaundryHistory_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUniformLaundryHistory",action:"frmUniformLaundryHistory_Close"});
                e.preventDefault();
            }
            
        }
        public cmdFind_Click(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkFlagged_CheckStateChanged(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkCleaned_CheckStateChanged(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkVendor_CheckStateChanged(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdNewItem_Click(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdEdit_Click(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkApproved_CheckStateChanged(sender: frmUniformLaundryHistory, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

