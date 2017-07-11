/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmVacationScheduler", [ "files/text!views/PTSProject.frmVacationScheduler.html", "files/css!views/PTSProject.frmVacationScheduler.css"],
    (htmlTemplate) => {
    return class frmVacationScheduler extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmVacationScheduler_Activated",this.frmVacationScheduler_Activated);
this.bind("frmVacationScheduler_Deactivate",this.frmVacationScheduler_Deactivate);
this.bind("calYear_Click",this.calYear_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmVacationScheduler";
            }

            public loaded() {
			
            }

        
        public frmVacationScheduler_Activated(sender: frmVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmVacationScheduler_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmVacationScheduler",action:"frmVacationScheduler_Close"});
                e.preventDefault();
            }
            
        }
        public frmVacationScheduler_Deactivate(sender: frmVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calYear_Click(sender: frmVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

