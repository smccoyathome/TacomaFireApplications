/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmUpdatePromo", [ "files/text!views/PTSProject.frmUpdatePromo.html", "files/css!views/PTSProject.frmUpdatePromo.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmUpdatePromo extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboPromotion_SelectionChangeCommitted",this.cboPromotion_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdUpdate_Click",this.cmdUpdate_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdRemove_Click",this.cmdRemove_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmUpdatePromo";
            }

            public loaded() {

            }

        

        public frmUpdatePromo_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmUpdatePromo",action:"frmUpdatePromo_Close"});
                e.preventDefault();
            }
            
        }
        public cboPromotion_SelectionChangeCommitted(sender: frmUpdatePromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdPrint_Click(sender: frmUpdatePromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdate_Click(sender: frmUpdatePromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmUpdatePromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemove_Click(sender: frmUpdatePromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

