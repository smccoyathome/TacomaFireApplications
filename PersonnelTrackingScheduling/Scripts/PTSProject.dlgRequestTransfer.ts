/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgRequestTransfer", [ "files/text!views/PTSProject.dlgRequestTransfer.html", "files/css!views/PTSProject.dlgRequestTransfer.css"],
    (htmlTemplate) => {
    return class dlgRequestTransfer extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);
this.bind("optRequest_CheckedChanged",this.optRequest_CheckedChanged);
this.bind("optDelete_CheckedChanged",this.optDelete_CheckedChanged);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("cboPriority_SelectionChangeCommitted",this.cboPriority_SelectionChangeCommitted);
this.bind("cmdReqDone_Click",this.cmdReqDone_Click);
this.bind("cboDelNameList_SelectionChangeCommitted",this.cboDelNameList_SelectionChangeCommitted);
this.bind("cmdDelete_Click",this.cmdDelete_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgRequestTransfer";
            }

            public loaded() {

            }

        

        public dlgRequestTransfer_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgRequestTransfer",action:"dlgRequestTransfer_Close"});
                e.preventDefault();
            }
            
        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public CancelButton_Renamed_Click(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optRequest_CheckedChanged(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optDelete_CheckedChanged(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPriority_SelectionChangeCommitted(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReqDone_Click(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDelNameList_SelectionChangeCommitted(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDelete_Click(sender: dlgRequestTransfer, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

