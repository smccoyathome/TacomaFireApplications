/// <reference path="WebMap_Interfaces.ts" />


module WebMap.Client {

    export class InputBoxCommandHandler implements ICommandHandler {
        public id: string = "inputbox";
        public dispatch(cmd: any) {
            InputBoxCommandHandler.showInputMessageDialog(cmd);
        }

        private static showInputMessageDialog(cmd: ICommand) :void {
            var inputBox = <InputBox>cmd.parameters;
            var inputBoxTemplate = InputBoxCommandHandler.getTemplate(inputBox);
            // Create the window to be displayed
            var w = $(inputBoxTemplate).kendoWindow(
                {
                    title: inputBox.title ? inputBox.title : "",
                    modal: true,
                    resizable: false
                }
            );
            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();
            // Add handlers to close the window
            (<any>w).find('.msgboxokbuttoncls,.msgboxcancelbuttoncls')
                .click(function () {
                    var dialogResult = "cancel";
                    var inputValue = "";
                    var input = $(w).find('.msgboxinputfieldcls')[0];
                    if ($(this).hasClass('msgboxokbuttoncls')) {
                        dialogResult = "ok";
                        inputValue = $(input).val();
                    } else {
                        dialogResult = "cancel";
                        inputValue = "";
                    }
                    (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", parameters: { "dialogResult": dialogResult, "requestedInput": inputValue } });
                    (<any>w).data('kendoWindow').close();
                });
        }

        private static getTemplate(inputBox: InputBox) {
            var template = "<div class='wmmsgbox __additional_classes__'>" +
                "<span class='msgboxmsgnclass'> " + inputBox.prompt + "</span ><br>" +
                "<div style='text-align:left'><input style='width:100%' type='text' class='k-textbox msgboxinputfieldcls' value='"+inputBox.defaultResponse+"'></div><br>"+
                "<div style='text-align:center'><button class='msgboxokbuttoncls' > OK </button >&nbsp<button class='msgboxcancelbuttoncls'>Cancel</button></div>";
            return template;
        }


        static InitInputBoxHandler() {
            CommandHandlerManager.Current.registerHandler("inputbox", new InputBoxCommandHandler());
            return null;
        }

        static staticinit = InputBoxCommandHandler.InitInputBoxHandler();
    }

}