/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmNote3", [ "files/text!views/PTSProject.frmNote3.html", "files/css!views/PTSProject.frmNote3.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmNote3 extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNote3";
            }

            public loaded() {
			
            }

        

        public frmNote3_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNote3",action:"frmNote3_Close"});
                e.preventDefault();
            }
            
        }
        public cmdOK_Click(sender: frmNote3, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: frmNote3, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

