/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgSpecialAssign", [ "files/text!views/PTSProject.dlgSpecialAssign.html", "files/css!views/PTSProject.dlgSpecialAssign.css"],
    (htmlTemplate) => {
    return class dlgSpecialAssign extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("optType_CheckedChanged",this.optType_CheckedChanged);
this.bind("cmdOK_Click",this.cmdOK_Click);
this.bind("cmdCancel_Click",this.cmdCancel_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgSpecialAssign";
            }

            public loaded() {
			
            }

        

        public dlgSpecialAssign_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgSpecialAssign",action:"dlgSpecialAssign_Close"});
                e.preventDefault();
            }
            
        }
        public optType_CheckedChanged(sender: dlgSpecialAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index")}));            

        }
        public cmdOK_Click(sender: dlgSpecialAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdCancel_Click(sender: dlgSpecialAssign, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

