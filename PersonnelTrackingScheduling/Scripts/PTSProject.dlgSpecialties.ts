/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgSpecialties", [ "files/text!views/PTSProject.dlgSpecialties.html", "files/css!views/PTSProject.dlgSpecialties.css"],
    (htmlTemplate) => {
    return class dlgSpecialties extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("OptParamedic_CheckedChanged",this.OptParamedic_CheckedChanged);
this.bind("optFCCDispatcher_CheckedChanged",this.optFCCDispatcher_CheckedChanged);
this.bind("OptTempUpgrade_CheckedChanged",this.OptTempUpgrade_CheckedChanged);
this.bind("OptOmitBCList_CheckedChanged",this.OptOmitBCList_CheckedChanged);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdRemove_Click",this.cmdRemove_Click);
this.bind("cmdSaveUpdate_Click",this.cmdSaveUpdate_Click);
this.bind("cboJobCode_SelectionChangeCommitted",this.cboJobCode_SelectionChangeCommitted);
this.bind("cmdSaveReason_Click",this.cmdSaveReason_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgSpecialties";
            }

            public loaded() {

            }

        

        public dlgSpecialties_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgSpecialties",action:"dlgSpecialties_Close"});
                e.preventDefault();
            }
            
        }
        public OptParamedic_CheckedChanged(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optFCCDispatcher_CheckedChanged(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public OptTempUpgrade_CheckedChanged(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public OptOmitBCList_CheckedChanged(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdAdd_Click(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRemove_Click(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSaveUpdate_Click(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode_SelectionChangeCommitted(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdSaveReason_Click(sender: dlgSpecialties, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

