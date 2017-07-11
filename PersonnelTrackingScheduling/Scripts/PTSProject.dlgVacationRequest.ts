/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgVacationRequest", [ "files/text!views/PTSProject.dlgVacationRequest.html", "files/css!views/PTSProject.dlgVacationRequest.css"],
    (htmlTemplate) => {
    return class dlgVacationRequest extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optRequest_CheckedChanged",this.optRequest_CheckedChanged);
this.bind("optDelete_CheckedChanged",this.optDelete_CheckedChanged);
this.bind("optUpdate_CheckedChanged",this.optUpdate_CheckedChanged);
this.bind("optAvailable_CheckedChanged",this.optAvailable_CheckedChanged);
this.bind("cboReqNameList_SelectionChangeCommitted",this.cboReqNameList_SelectionChangeCommitted);
this.bind("chkPMOnly_CheckStateChanged",this.chkPMOnly_CheckStateChanged);
this.bind("chkHZMOnly_CheckStateChanged",this.chkHZMOnly_CheckStateChanged);
this.bind("cmdClearRequest_Click",this.cmdClearRequest_Click);
this.bind("calAvail_DateChanged",this.calAvail_DateChanged);
this.bind("cmdAvailDone_Click",this.cmdAvailDone_Click);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("lstCurrSched_SelectedIndexChanged",this.lstCurrSched_SelectedIndexChanged);
this.bind("cmdReqDone_Click",this.cmdReqDone_Click);
this.bind("cboUpdateNameList_SelectionChangeCommitted",this.cboUpdateNameList_SelectionChangeCommitted);
this.bind("cboUpdateNameList_TextChanged",this.cboUpdateNameList_TextChanged);
this.bind("cboKOT_SelectionChangeCommitted",this.cboKOT_SelectionChangeCommitted);
this.bind("cboKOT_TextChanged",this.cboKOT_TextChanged);
this.bind("cmdUpdateDone_Click",this.cmdUpdateDone_Click);
this.bind("cmdClearAvail_Click",this.cmdClearAvail_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgVacationRequest";
            }

            public loaded() {

            }

        

        public dlgVacationRequest_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgVacationRequest",action:"dlgVacationRequest_Close"});
                e.preventDefault();
            }
            
        }
        public optRequest_CheckedChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optDelete_CheckedChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optUpdate_CheckedChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optAvailable_CheckedChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboReqNameList_SelectionChangeCommitted(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkPMOnly_CheckStateChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkHZMOnly_CheckStateChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClearRequest_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public calAvail_DateChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAvailDone_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstCurrSched_SelectedIndexChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReqDone_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUpdateNameList_SelectionChangeCommitted(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUpdateNameList_TextChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboKOT_SelectionChangeCommitted(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboKOT_TextChanged(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdUpdateDone_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClearAvail_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgVacationRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

