/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgEmployeePayCalc", [ "files/text!views/PTSProject.dlgEmployeePayCalc.html", "files/css!views/PTSProject.dlgEmployeePayCalc.css"],
    (htmlTemplate) => {
    return class dlgEmployeePayCalc extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("cboEmpList_SelectionChangeCommitted",this.cboEmpList_SelectionChangeCommitted);
this.bind("cboJobCode_SelectionChangeCommitted",this.cboJobCode_SelectionChangeCommitted);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgEmployeePayCalc";
            }

            public loaded() {
			
            }

        

        public dlgEmployeePayCalc_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgEmployeePayCalc",action:"dlgEmployeePayCalc_Close"});
                e.preventDefault();
            }
            
        }
        public cmdClose_Click(sender: dlgEmployeePayCalc, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboEmpList_SelectionChangeCommitted(sender: dlgEmployeePayCalc, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cboJobCode_SelectionChangeCommitted(sender: dlgEmployeePayCalc, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

