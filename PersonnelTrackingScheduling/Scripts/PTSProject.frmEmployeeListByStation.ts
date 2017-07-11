/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmEmployeeListByStation", [ "files/text!views/PTSProject.frmEmployeeListByStation.html", "files/css!views/PTSProject.frmEmployeeListByStation.css"],
    (htmlTemplate) => {
    return class frmEmployeeListByStation extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("chkSelectAll_CheckStateChanged",this.chkSelectAll_CheckStateChanged);
this.bind("cboLocation_SelectionChangeCommitted",this.cboLocation_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmEmployeeListByStation";
            }

            public loaded() {

            }

        

        public frmEmployeeListByStation_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmEmployeeListByStation",action:"frmEmployeeListByStation_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmEmployeeListByStation, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public chkSelectAll_CheckStateChanged(sender: frmEmployeeListByStation, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboLocation_SelectionChangeCommitted(sender: frmEmployeeListByStation, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmEmployeeListByStation, action: string, e: any) {
            
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

