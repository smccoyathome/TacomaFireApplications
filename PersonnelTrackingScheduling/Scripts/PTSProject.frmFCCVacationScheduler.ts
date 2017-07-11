/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmFCCVacationScheduler", [ "files/text!views/PTSProject.frmFCCVacationScheduler.html", "files/css!views/PTSProject.frmFCCVacationScheduler.css"],
    (htmlTemplate) => {
    return class frmFCCVacationScheduler extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("frmFCCVacationScheduler_Activated",this.frmFCCVacationScheduler_Activated);
this.bind("frmFCCVacationScheduler_Deactivate",this.frmFCCVacationScheduler_Deactivate);
this.bind("calYear_Click",this.calYear_Click);
this.bind("cmdRefresh_Click",this.cmdRefresh_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmFCCVacationScheduler";
            }

            public loaded() {
			
            }

        
        public frmFCCVacationScheduler_Activated(sender: frmFCCVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

        public frmFCCVacationScheduler_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmFCCVacationScheduler",action:"frmFCCVacationScheduler_Close"});
                e.preventDefault();
            }
            
        }
        public frmFCCVacationScheduler_Deactivate(sender: frmFCCVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calYear_Click(sender: frmFCCVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdRefresh_Click(sender: frmFCCVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmFCCVacationScheduler, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

