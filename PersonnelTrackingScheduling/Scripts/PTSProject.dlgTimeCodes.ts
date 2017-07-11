/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgTimeCodes", [ "files/text!views/PTSProject.dlgTimeCodes.html", "files/css!views/PTSProject.dlgTimeCodes.css"],
    (htmlTemplate) => {
    return class dlgTimeCodes extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optTimeCode_CheckedChanged",this.optTimeCode_CheckedChanged);
this.bind("optJobCode_CheckedChanged",this.optJobCode_CheckedChanged);
this.bind("optOrderCode_CheckedChanged",this.optOrderCode_CheckedChanged);
this.bind("optLeaveAllowed_CheckedChanged",this.optLeaveAllowed_CheckedChanged);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgTimeCodes";
            }

            public loaded() {

            }

        

        public dlgTimeCodes_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgTimeCodes",action:"dlgTimeCodes_Close"});
                e.preventDefault();
            }
            
        }
        public optTimeCode_CheckedChanged(sender: dlgTimeCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optJobCode_CheckedChanged(sender: dlgTimeCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optOrderCode_CheckedChanged(sender: dlgTimeCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optLeaveAllowed_CheckedChanged(sender: dlgTimeCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgTimeCodes, action: string, e: any) {
            
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

