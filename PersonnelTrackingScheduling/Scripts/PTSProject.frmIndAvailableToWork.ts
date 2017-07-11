/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmIndAvailableToWork", [ "files/text!views/PTSProject.frmIndAvailableToWork.html", "files/css!views/PTSProject.frmIndAvailableToWork.css"],
    (htmlTemplate) => {
    return class frmIndAvailableToWork extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("calAvail_DateChanged",this.calAvail_DateChanged);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);
this.bind("cmdAdd_Click",this.cmdAdd_Click);
this.bind("cmdDelete_Click",this.cmdDelete_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmIndAvailableToWork";
            }

            public loaded() {

            }

        

        public frmIndAvailableToWork_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmIndAvailableToWork",action:"frmIndAvailableToWork_Close"});
                e.preventDefault();
            }
            
        }
        public calAvail_DateChanged(sender: frmIndAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: frmIndAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAdd_Click(sender: frmIndAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public cmdDelete_Click(sender: frmIndAvailableToWork, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

