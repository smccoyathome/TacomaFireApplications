/// <reference path="WebMap_Interfaces.ts" />

module WebMap.Client {

    export interface ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
    }

    export interface ICommand {
        id: string;
        parameters: any;
    }
    export class CommandHandlerManager {

        public static Current: CommandHandlerManager;

        private static handlers: { [index: string]: ICommandHandler; };

        public registerHandler(id: string,handler:ICommandHandler) {
            CommandHandlerManager.handlers[id] = handler;
        }

        public dispatchAll(commands:ICommand[]) {
                for (var i = 0; i < commands.length; i++) {
                    var cmd = commands[i];
                    var handler = CommandHandlerManager.handlers[cmd.id];
                    if (handler) handler.dispatch(cmd);
                }
        }

        static InitCommandHandlerManager() {
            CommandHandlerManager.handlers = {};
            CommandHandlerManager.Current = new CommandHandlerManager()
            
            return null;
        }

        static staticinit = CommandHandlerManager.InitCommandHandlerManager();
    }

} 