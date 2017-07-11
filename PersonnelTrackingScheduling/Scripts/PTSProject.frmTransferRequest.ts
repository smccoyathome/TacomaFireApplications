/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmTransferRequest", [ "files/text!views/PTSProject.frmTransferRequest.html", "files/css!views/PTSProject.frmTransferRequest.css"],
    (htmlTemplate) => {
    return class frmTransferRequest extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optNewPosition_CheckedChanged",this.optNewPosition_CheckedChanged);
this.bind("optRequest_CheckedChanged",this.optRequest_CheckedChanged);
this.bind("cboReqNameList_SelectionChangeCommitted",this.cboReqNameList_SelectionChangeCommitted);
this.bind("cmdClearRequest_Click",this.cmdClearRequest_Click);
this.bind("cboReqPositionList_SelectionChangeCommitted",this.cboReqPositionList_SelectionChangeCommitted);
this.bind("cboUnitList_SelectionChangeCommitted",this.cboUnitList_SelectionChangeCommitted);
this.bind("cboPositionList_SelectionChangeCommitted",this.cboPositionList_SelectionChangeCommitted);
this.bind("cboShiftList_SelectionChangeCommitted",this.cboShiftList_SelectionChangeCommitted);
this.bind("dteOpenDate_Click",this.dteOpenDate_Click);
this.bind("cmdAddPosition_Click",this.cmdAddPosition_Click);
this.bind("cboNameList_SelectionChangeCommitted",this.cboNameList_SelectionChangeCommitted);
this.bind("lstAvailPositions_SelectedIndexChanged",this.lstAvailPositions_SelectedIndexChanged);
this.bind("cboPriority_SelectionChangeCommitted",this.cboPriority_SelectionChangeCommitted);
this.bind("cmdReqDone_Click",this.cmdReqDone_Click);
this.bind("cmdAssign_Click",this.cmdAssign_Click);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("chkActiveOnly_CheckStateChanged",this.chkActiveOnly_CheckStateChanged);
this.bind("cmdInactivate_Click",this.cmdInactivate_Click);
this.bind("cmdDisplay_Click",this.cmdDisplay_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmTransferRequest";
            }

            public loaded() {

            }

        

        public frmTransferRequest_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmTransferRequest",action:"frmTransferRequest_Close"});
                e.preventDefault();
            }
            
        }
        public optNewPosition_CheckedChanged(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public optRequest_CheckedChanged(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboReqNameList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClearRequest_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboReqPositionList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboUnitList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPositionList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboShiftList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dteOpenDate_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAddPosition_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboNameList_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public lstAvailPositions_SelectedIndexChanged(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboPriority_SelectionChangeCommitted(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdReqDone_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdAssign_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
        public chkActiveOnly_CheckStateChanged(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdInactivate_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdDisplay_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: frmTransferRequest, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

