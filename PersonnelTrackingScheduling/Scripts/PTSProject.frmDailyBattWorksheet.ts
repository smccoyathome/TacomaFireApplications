/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmDailyBattWorksheet", [ "files/text!views/PTSProject.frmDailyBattWorksheet.html", "files/css!views/PTSProject.frmDailyBattWorksheet.css"],
    (htmlTemplate) => {
    return class frmDailyBattWorksheet extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("dtReportDate_Click",this.dtReportDate_Click);
this.bind("dtReportDate_ValueChanged",this.dtReportDate_ValueChanged);
this.bind("optBatt1_CheckedChanged",this.optBatt1_CheckedChanged);
this.bind("optBatt2_CheckedChanged",this.optBatt2_CheckedChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmDailyBattWorksheet";
            }

            public loaded() {

            }

        

        public frmDailyBattWorksheet_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmDailyBattWorksheet",action:"frmDailyBattWorksheet_Close"});
                e.preventDefault();
            }
            
        }
        public dtReportDate_Click(sender: frmDailyBattWorksheet, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtReportDate_ValueChanged(sender: frmDailyBattWorksheet, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optBatt1_CheckedChanged(sender: frmDailyBattWorksheet, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optBatt2_CheckedChanged(sender: frmDailyBattWorksheet, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmDailyBattWorksheet, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmDailyBattWorksheet, action: string, e: any) {
            
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

