/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmCF1Report", [ "files/text!views/PTSProject.frmCF1Report.html", "files/css!views/PTSProject.frmCF1Report.css"],
    (htmlTemplate) => {
    return class frmCF1Report extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmCF1Report";
            }

            public loaded() {

            }

        

        public frmCF1Report_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmCF1Report",action:"frmCF1Report_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmCF1Report, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmCF1Report, action: string, e: any) {
            
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

