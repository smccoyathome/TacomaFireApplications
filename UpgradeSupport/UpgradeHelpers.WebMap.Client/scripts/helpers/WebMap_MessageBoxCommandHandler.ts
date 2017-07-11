
module WebMap.Client {


    export class MessageBoxCommandHandler implements ICommandHandler {
        public id: string = "msg";
        public dispatch(cmd: any) {
            MessageBoxCommandHandler.showMessageDialog(cmd);

        }


        private static showMessageDialog(cmd:ICommand): void {
            var msg: Message = <Message>cmd.parameters;
            var msgBoxTemplate = MessageBoxCommandHandler.preparteMessageBoxTemplate(msg);

            // Create the window to be displayed
            var w = $(msgBoxTemplate).kendoWindow(
                {
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false
                }
                );
            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();

            // Add handlers to close the window
            (<any>w).find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls,.msgboxretrybuttoncls')
                .click(function () {
                var dialogResult = "cancel";
                if ($(this).hasClass('msgboxokbuttoncls')) {
                    dialogResult = "ok";
                } else if ($(this).hasClass('msgboxyesbuttoncls')) {
                    dialogResult = "yes";
                } else if ($(this).hasClass('msgboxnobuttoncls')) {
                    dialogResult = "no";
                } else if ($(this).hasClass('msgboxretrybuttoncls')) {
                    dialogResult = "retry";
                } else {
                    dialogResult = "cancel";
                }
                (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult });
                (<any>w).data('kendoWindow').close();
	        (<any>w).data('kendoWindow').destroy();
            });
        }

        private static preparteMessageBoxTemplate(msg: Message): string {
            var msgBoxTemplate = "<div class='wmmsgbox __additional_classes__'>" +
                "<span class='msgboxiconscls' ></span><span class='msgboxmsgnclass'> " + msg.text + "</span > " +
                "<div style='text-align:center'>";
            var iconClass = MessageBoxCommandHandler.getMessageBoxIconCssClass(msg.icons);

            if ((!msg.buttons)|| msg.buttons == 1) { // Default value (OK) or OKCancel 
                msgBoxTemplate = msgBoxTemplate + "<button class='msgboxokbuttoncls' > OK </button > ";
            }
            if (msg.buttons == 3 || msg.buttons == 4) {
                msgBoxTemplate = msgBoxTemplate + "<button class='msgboxyesbuttoncls' > Yes </button > ";
                msgBoxTemplate = msgBoxTemplate + "<button class='msgboxnobuttoncls'>No</button>";
            }
            if (msg.buttons == 5) {
                msgBoxTemplate = msgBoxTemplate + "<button class='msgboxretrybuttoncls'>Retry</button>";
            }
            if (msg.buttons == 1 || msg.buttons == 3 || msg.buttons == 5) {
                msgBoxTemplate = msgBoxTemplate + "<button class='msgboxcancelbuttoncls'>Cancel</button>";
            }
            msgBoxTemplate = msgBoxTemplate + "</div>";
            msgBoxTemplate = msgBoxTemplate.replace('__additional_classes__', iconClass);

            return msgBoxTemplate;
        }

        private static getMessageBoxIconCssClass(id: number): string {
            var iconClass = "";
            switch (id) {
                case 1:
                    iconClass = "msgboxquestion";
                    break;
                case 2:
                    iconClass = "msgboxwarning";
                    break;
                case 3:
                    iconClass = "msgboxerror";
                    break;
            }
            return iconClass;
        }

        public static showSessionExpiredMessage(): void {
            var msg = <Message> { UniqueID: "generic", text: "The application session has timeout! You must reload the application.", buttons: 0, caption: "Session Expired" };
            var msgBoxTemplate = this.preparteMessageBoxTemplate(msg);

            // Create the window to be displayed
            var w = $(msgBoxTemplate).kendoWindow(
                {
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false,
                    width: 300
                });
            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();

            // Add handlers to close the window
            (<any>w).find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls')
                .click(function () {
                location.reload(true);
            });

            // Add handlers to close the window
            (<any>w).find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls').html("Reload");

        }


        public static showGenericMessage(messageText: string): void {

            var msg = <Message> { UniqueID: "generic", text: messageText, buttons: 1, caption: "Exception Occurred" };
            var msgBoxTemplate = MessageBoxCommandHandler.preparteMessageBoxTemplate(msg);

            // Create the window to be displayed
            var w = $(msgBoxTemplate).kendoWindow(
                {
                    title: msg.caption ? msg.caption : "",
                    modal: true,
                    resizable: false
                }
                );
            var kendowWindow: kendo.ui.Window = w.data("kendoWindow");
            kendowWindow.center().open();

            // Add handlers to close the window
            (<any>w).find('.msgboxokbuttoncls,.msgboxcancelbuttoncls,.msgboxyesbuttoncls,.msgboxnobuttoncls')
                .click(function () {
                var dialogResult = "cancel";
                if ($(this).hasClass('msgboxokbuttoncls')) {
                    dialogResult = "ok";
                } else if ($(this).hasClass('msgboxyesbuttoncls')) {
                    dialogResult = "yes";
                } else if ($(this).hasClass('msgboxnobuttoncls')) {
                    dialogResult = "no";
                } else {
                    dialogResult = "cancel";
                }
                (<any>window).app.sendAction({ controller: "WebMapViewManager", action: "ResumePendingOperation", dialogResult: dialogResult });
                (<any>w).data('kendoWindow').close();
            });
        }

        static InitMessageBoxHandler() {
            CommandHandlerManager.Current.registerHandler("msg", new MessageBoxCommandHandler());
            return null;
        }

        static staticinit = MessageBoxCommandHandler.InitMessageBoxHandler();


    }

}
