/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmAdjustAssign", [ "files/text!views/PTSProject.frmAdjustAssign.html", "files/css!views/PTSProject.frmAdjustAssign.css"],
    (htmlTemplate) => {
    return class frmAdjustAssign extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("opbEmp_CheckedChanged",this.opbEmp_CheckedChanged);
this.bind("cmdDone_Click",this.cmdDone_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmAdjustAssign";
            }

            public loaded() {
			
            }

        

        public frmAdjustAssign_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmAdjustAssign",action:"frmAdjustAssign_Close"});
                e.preventDefault();
            }
            
        }
        public opbEmp_CheckedChanged(sender: frmAdjustAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdDone_Click(sender: frmAdjustAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

