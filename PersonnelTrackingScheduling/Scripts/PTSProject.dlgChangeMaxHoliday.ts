/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("PTSProject.dlgChangeMaxHoliday", [ "files/text!views/PTSProject.dlgChangeMaxHoliday.html", "files/css!views/PTSProject.dlgChangeMaxHoliday.css"],
    (htmlTemplate) => {
    return class dlgChangeMaxHoliday extends Mobilize.WebMap.Kendo.Ui.KendoView {
        constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings(){
            this.bind("OKButton_Click",this.OKButton_Click);
this.bind("CancelButton_Renamed_Click",this.CancelButton_Renamed_Click);

                //this.bindCloseEvent();
            }


            public get name() {
                return "dlgChangeMaxHoliday";
            }

            public loaded() {
			
            }

        

        public dlgChangeMaxHoliday_Close(e:any) {
            
            if (e.userTriggered) {
                window.app.sendAction({mainobj:this,controller:"dlgChangeMaxHoliday",action:"dlgChangeMaxHoliday_Close"});
                e.preventDefault();
            }
            
        }
        public OKButton_Click(sender: dlgChangeMaxHoliday, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }
        public CancelButton_Renamed_Click(sender: dlgChangeMaxHoliday, action: string, e: any) {
            
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

        }

    }
   
});

