/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmShiftCal", [ "files/text!views/PTSProject.frmShiftCal.html", "files/css!views/PTSProject.frmShiftCal.css"],
    (htmlTemplate) => {
    return class frmShiftCal extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboYear_SelectionChangeCommitted",this.cboYear_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmShiftCal";
            }

            public loaded() {

            }

        

        public frmShiftCal_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmShiftCal",action:"frmShiftCal_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmShiftCal, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmShiftCal, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboYear_SelectionChangeCommitted(sender: frmShiftCal, action: string, e: any) {
            
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

