/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmMissingFromSchedule", [ "files/text!views/PTSProject.frmMissingFromSchedule.html", "files/css!views/PTSProject.frmMissingFromSchedule.css"],
    (htmlTemplate) => {
    return class frmMissingFromSchedule extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmMissingFromSchedule";
            }

            public loaded() {

            }

        

        public frmMissingFromSchedule_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmMissingFromSchedule",action:"frmMissingFromSchedule_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdAdd_Click(sender: frmMissingFromSchedule, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: frmMissingFromSchedule, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

