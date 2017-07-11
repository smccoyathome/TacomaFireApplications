/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmSrReport", [ "files/text!views/PTSProject.frmSrReport.html", "files/css!views/PTSProject.frmSrReport.css"],
    (htmlTemplate) => {
    return class frmSrReport extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cboSenior_SelectionChangeCommitted",this.cboSenior_SelectionChangeCommitted);
this.bind("calSrDate_Click",this.calSrDate_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmSrReport";
            }

            public loaded() {

            }

        

        public frmSrReport_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmSrReport",action:"frmSrReport_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: frmSrReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmSrReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboSenior_SelectionChangeCommitted(sender: frmSrReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calSrDate_Click(sender: frmSrReport, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }

    }
   
});

