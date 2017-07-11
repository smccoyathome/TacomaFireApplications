/// <reference path="WebMap_Interfaces.ts" />


module WebMap.Client {

    export class PluginCommandHandler implements ICommandHandler {
        public id: string = "plugin";
        public dispatch(cmd: any) {
            PluginCommandHandler.sendCommandToDesktopAgent(cmd);
        }

        private static sendCommandToDesktopAgent(cmd: any) {
            $.ajax({
                url: "http://localhost:60064/api/dopluginaction",
                data: JSON.stringify(cmd.parameters),
                "type": "POST",
                contentType: "application/json",
                success: (data: any) => {
                    console.log("-- Trying SelfHost Communication --");
                    console.log("Response: ");
                    console.log(data);
                }
            });
        }

        static InitPluginCommandHandler() {
            CommandHandlerManager.Current.registerHandler("plugin", new PluginCommandHandler());
            return null;
        }

        static staticinit = PluginCommandHandler.InitPluginCommandHandler();
    }
}