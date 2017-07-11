/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmNewPromo", [ "files/text!views/PTSProject.frmNewPromo.html", "files/css!views/PTSProject.frmNewPromo.css","usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
    return class frmNewPromo extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdAddPromo_Click",this.cmdAddPromo_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmNewPromo";
            }

            public loaded() {
			
            }

        

        public frmNewPromo_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmNewPromo",action:"frmNewPromo_Close"});
                e.preventDefault();
            }
            
        }
        public cmdAddPromo_Click(sender: frmNewPromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: frmNewPromo, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

