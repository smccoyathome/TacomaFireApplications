/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgRetirePPE", [ "files/text!views/PTSProject.dlgRetirePPE.html", "files/css!views/PTSProject.dlgRetirePPE.css"],
    (htmlTemplate) => {
    return class dlgRetirePPE extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdEditItem_Click",this.cmdEditItem_Click);
this.bind("cboItemType_SelectionChangeCommitted",this.cboItemType_SelectionChangeCommitted);
this.bind("cboItemType_TextChanged",this.cboItemType_TextChanged);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgRetirePPE";
            }

            public loaded() {
			
            }

        

        public dlgRetirePPE_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgRetirePPE",action:"dlgRetirePPE_Close"});
                e.preventDefault();
            }
            
        }
        public cmdEditItem_Click(sender: dlgRetirePPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemType_SelectionChangeCommitted(sender: dlgRetirePPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboItemType_TextChanged(sender: dlgRetirePPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: dlgRetirePPE, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

