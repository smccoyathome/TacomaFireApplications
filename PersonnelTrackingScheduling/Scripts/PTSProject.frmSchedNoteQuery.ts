/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.frmSchedNoteQuery", [ "files/text!views/PTSProject.frmSchedNoteQuery.html", "files/css!views/PTSProject.frmSchedNoteQuery.css"],
    (htmlTemplate) => {
    return class frmSchedNoteQuery extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("cmdExit_Click",this.cmdExit_Click);
this.bind("dtStartDate_Click",this.dtStartDate_Click);
this.bind("dtStartDate_ValueChanged",this.dtStartDate_ValueChanged);
this.bind("cmdClear_Click",this.cmdClear_Click);
this.bind("dtEndDate_Click",this.dtEndDate_Click);
this.bind("dtEndDate_ValueChanged",this.dtEndDate_ValueChanged);
this.bind("cmdPrint_Click",this.cmdPrint_Click);
this.bind("txtCommentSearch_TextChanged",this.txtCommentSearch_TextChanged);

                //this.bindCloseEvent();
            }


            public get name() {
                return "frmSchedNoteQuery";
            }

            public loaded() {

            }

        

        public frmSchedNoteQuery_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"frmSchedNoteQuery",action:"frmSchedNoteQuery_Close"});
                e.preventDefault();
            }
            
        }
        public cmdExit_Click(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStartDate_Click(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtStartDate_ValueChanged(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdClear_Click(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEndDate_Click(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public dtEndDate_ValueChanged(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public cmdPrint_Click(sender: frmSchedNoteQuery, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public txtCommentSearch_TextChanged(sender: frmSchedNoteQuery, action: string, e: any) {
            
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

