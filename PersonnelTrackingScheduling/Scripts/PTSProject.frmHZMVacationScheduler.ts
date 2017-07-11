/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmHZMVacationScheduler", [ "files/text!views/PTSProject.frmHZMVacationScheduler.html", "files/css!views/PTSProject.frmHZMVacationScheduler.css"],
    (htmlTemplate) => {
    return class frmHZMVacationScheduler extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmHZMVacationScheduler_Activated",this.frmHZMVacationScheduler_Activated);
this.bind("frmHZMVacationScheduler_Deactivate",this.frmHZMVacationScheduler_Deactivate);
this.bind("calYear_Click",this.calYear_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmHZMVacationScheduler";
            }

            public loaded() {
			
            }

        
        public frmHZMVacationScheduler_Activated(sender: frmHZMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmHZMVacationScheduler_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmHZMVacationScheduler",action:"frmHZMVacationScheduler_Close"});
                e.preventDefault();
            }
            
        }
        public frmHZMVacationScheduler_Deactivate(sender: frmHZMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calYear_Click(sender: frmHZMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmHZMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmHZMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

