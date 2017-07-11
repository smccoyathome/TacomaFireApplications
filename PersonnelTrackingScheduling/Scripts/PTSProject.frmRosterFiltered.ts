/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmRosterFiltered", [ "files/text!views/PTSProject.frmRosterFiltered.html", "files/css!views/PTSProject.frmRosterFiltered.css"],
    (htmlTemplate) => {
    return class frmRosterFiltered extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboEmployee_SelectionChangeCommitted",this.cboEmployee_SelectionChangeCommitted);
this.bind("cboRank_SelectionChangeCommitted",this.cboRank_SelectionChangeCommitted);
this.bind("cboBatt_SelectionChangeCommitted",this.cboBatt_SelectionChangeCommitted);
this.bind("cboShift_SelectionChangeCommitted",this.cboShift_SelectionChangeCommitted);
this.bind("cboCity_SelectionChangeCommitted",this.cboCity_SelectionChangeCommitted);
this.bind("cboZipCode_SelectionChangeCommitted",this.cboZipCode_SelectionChangeCommitted);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClear_Click",this.cmdClear_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmRosterFiltered";
            }

            public loaded() {

            }

        

        public frmRosterFiltered_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmRosterFiltered",action:"frmRosterFiltered_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmployee_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboRank_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboBatt_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboShift_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboCity_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboZipCode_SelectionChangeCommitted(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmRosterFiltered, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmRosterFiltered, action: string, e: any) {
            
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

