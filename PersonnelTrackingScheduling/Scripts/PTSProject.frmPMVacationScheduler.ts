/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmPMVacationScheduler", [ "files/text!views/PTSProject.frmPMVacationScheduler.html", "files/css!views/PTSProject.frmPMVacationScheduler.css"],
    (htmlTemplate) => {
    return class frmPMVacationScheduler extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmPMVacationScheduler_Activated",this.frmPMVacationScheduler_Activated);
this.bind("frmPMVacationScheduler_Deactivate",this.frmPMVacationScheduler_Deactivate);
this.bind("calYear_Click",this.calYear_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmPMVacationScheduler";
            }

            public loaded() {
			
            }

        
        public frmPMVacationScheduler_Activated(sender: frmPMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmPMVacationScheduler_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmPMVacationScheduler",action:"frmPMVacationScheduler_Close"});
                e.preventDefault();
            }
            
        }
        public frmPMVacationScheduler_Deactivate(sender: frmPMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calYear_Click(sender: frmPMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmPMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmPMVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

