/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgTrainingCodes", [ "files/text!views/PTSProject.dlgTrainingCodes.html", "files/css!views/PTSProject.dlgTrainingCodes.css"],
    (htmlTemplate) => {
    return class dlgTrainingCodes extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cboSpecificCodes_SelectionChangeCommitted",this.cboSpecificCodes_SelectionChangeCommitted);
this.bind("cmdExpand_Click",this.cmdExpand_Click);
this.bind("cmdExit_Click",this.cmdExit_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgTrainingCodes";
            }

            public loaded() {
			
            }

        

        public dlgTrainingCodes_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgTrainingCodes",action:"dlgTrainingCodes_Close"});
                e.preventDefault();
            }
            
        }
        public cboSpecificCodes_SelectionChangeCommitted(sender: dlgTrainingCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExpand_Click(sender: dlgTrainingCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExit_Click(sender: dlgTrainingCodes, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

