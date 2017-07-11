/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmChangeCallBackNum", [ "files/text!views/PTSProject.frmChangeCallBackNum.html", "files/css!views/PTSProject.frmChangeCallBackNum.css"],
    (htmlTemplate) => {
    return class frmChangeCallBackNum extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboShift_SelectionChangeCommitted",this.cboShift_SelectionChangeCommitted);
this.bind("cboDebitGroup_SelectionChangeCommitted",this.cboDebitGroup_SelectionChangeCommitted);
this.bind("OKButton_Click",this.OKButton_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmChangeCallBackNum";
            }

            public loaded() {
			
            }

        

        public frmChangeCallBackNum_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmChangeCallBackNum",action:"frmChangeCallBackNum_Close"});
                e.preventDefault();
            }
            
        }
        public cboShift_SelectionChangeCommitted(sender: frmChangeCallBackNum, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboDebitGroup_SelectionChangeCommitted(sender: frmChangeCallBackNum, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public OKButton_Click(sender: frmChangeCallBackNum, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: frmChangeCallBackNum, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

