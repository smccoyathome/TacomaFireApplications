/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmHelp", [ "files/text!views/TFDIncident.frmHelp.html", "files/css!views/TFDIncident.frmHelp.css"],
    (htmlTemplate) => {
    return class frmHelp extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("tvHelpList_AfterSelect",this.tvHelpList_AfterSelect);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdCode_Click",this.cmdCode_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmHelp";
            }

            public loaded() {
			
            }

        

        public frmHelp_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmHelp",action:"frmHelp_Close"});
                e.preventDefault();
            }
            
        }
        public tvHelpList_AfterSelect(sender: frmHelp, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmHelp, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCode_Click(sender: frmHelp, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

