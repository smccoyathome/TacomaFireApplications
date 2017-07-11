/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmTimeCard2", [ "files/text!views/PTSProject.frmTimeCard2.html", "files/css!views/PTSProject.frmTimeCard2.css"],
    (htmlTemplate) => {
    return class frmTimeCard2 extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("cmdPrintAll_Click",this.cmdPrintAll_Click);
this.bind("cmdExcept_Click",this.cmdExcept_Click);
this.bind("cmdLeave_Click",this.cmdLeave_Click);
this.bind("cmdClose_Click",this.cmdClose_Click);
this.bind("calDate_Click",this.calDate_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmTimeCard2";
            }

            public loaded() {

            }

        

        public frmTimeCard2_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmTimeCard2",action:"frmTimeCard2_Close"});
                e.preventDefault();
            }
            
        }
        public cmdPrint_Click(sender: frmTimeCard2, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrintAll_Click(sender: frmTimeCard2, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdExcept_Click(sender: frmTimeCard2, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdLeave_Click(sender: frmTimeCard2, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClose_Click(sender: frmTimeCard2, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public calDate_Click(sender: frmTimeCard2, action: string, e: any) {
            
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

