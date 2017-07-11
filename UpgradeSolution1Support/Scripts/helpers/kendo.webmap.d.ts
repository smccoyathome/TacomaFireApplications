/// <reference path="kendo.all.d.ts" />
declare module Mobilize.WebMap.Kendo {
    namespace Entity {
        class Model extends Core.Model {
            constructor(uniqueId?: string, obj?: any);
            updateModel(item: Contract.Core.IModel): void;
            addReference(property: string, item: Contract.Core.IModel): void;
            addValue(property: string, value: any): void;
            private triggerChange();
            private focus();
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Entity {
        class ModelFactory implements Contract.Core.IModelFactory {
            create(model: any): Mobilize.Contract.Core.IModel;
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Resolvers {
        class KendoChangeNotifier implements Mobilize.Contract.Core.IModelNotifier {
            apply(model: Mobilize.Contract.Core.IModel): void;
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Resolvers {
        class ObservableBehavior implements Mobilize.Contract.Core.IClientBehavior {
            apply(model: Mobilize.Contract.Core.IModel, root: Mobilize.Contract.Core.IEntity): void;
            readonly Order: Mobilize.Contract.Core.Order;
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui {
        class KendoView extends Mobilize.Ui.View {
            name: string;
            templateString: string;
            dispose(): void;
            render(): void;
            bindings(): void;
            invoke(command: Mobilize.Contract.Ui.ICommand): JQueryPromise<{}>;
            private readonly id;
            private addTemplate();
            private bindKendo();
            private focus();
            private AddCloseEvent();
            private renderAsFloating();
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui {
        class KendoViewResolver implements Mobilize.Contract.Ui.IViewResolver {
            resolve(model: Mobilize.Contract.Core.IModel, load: (view: Mobilize.Contract.Ui.IView) => void): void;
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui.Modals {
        class AlertModal extends Mobilize.Ui.Modal {
            private viewModal;
            private isLoaded;
            constructor();
            name(): string;
            show(args: any): void;
            private load();
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui.Modals {
        class ExpiredSession extends Mobilize.Ui.Modal {
            windowKendo: kendo.ui.Window;
            viewModal: kendo.data.ObservableObject;
            constructor();
            retry(): void;
            private load();
            name(): string;
            show(args: any): void;
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui.Modals {
        class LoadingModal extends Mobilize.Ui.Modal {
            private viewModal;
            private timer;
            constructor();
            name(): string;
            show(args: any): void;
            private load();
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui.Modals {
        class MessageBox extends Mobilize.Ui.Modal {
            windowKendo: kendo.ui.Window;
            viewModal: kendo.data.ObservableObject;
            kendoQueue: Array<Object>;
            constructor();
            private reset();
            private load();
            click(): void;
            name(): string;
            show(args: any): any;
            private showModal(args);
        }
    }
}
declare module Mobilize.WebMap.Kendo {
    namespace Ui.Modals {
        class InputBox extends Mobilize.Ui.Modal {
            windowKendo: kendo.ui.Window;
            viewModal: kendo.data.ObservableObject;
            kendoQueue: Array<Object>;
            constructor();
            private reset();
            private load();
            click(): void;
            name(): string;
            show(args: any): any;
            private showModal(parameters);
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class BaseUserControl {
            options: {
                name: string;
                value: any;
                css: string;
                template: string;
                uiinitialized: boolean;
            };
            _old: any;
            _value: any;
            element: any;
            applyTemplate(value: any): any;
            initStyles(): void;
            initClientMethods(value: any): void;
            init(element: any, options: any): void;
            refresh(): void;
            buildUI(): void;
            value(val: any): any;
            _update(value: any): void;
        }
    }
}
declare module WebMap.Client {
    function checkedListBoxProc(element: any): void;
    function customEventBinding(that: any, control: any, event: any, bindingName: any): void;
}
declare module Mobilize.WebMap.Kendo {
    namespace WebComponents {
        class FancyTextBox {
            textBox: any;
            element: any;
            events: string[];
            data: any;
            options: {
                name: string;
                autoBind: boolean;
            };
            templates: {
                textBox: string;
            };
            init(element: any, options: any): void;
            value(value: any): void;
            refresh(value: any): void;
        }
    }
}
declare module WebMap.Utils {
    function IsClassSet(classes: string, cls: string): boolean;
    function RemoveClass(classes: string, cls: string): string;
    function convertDate(value: any): string;
}
declare module Mobilize.WebMap.Kendo {
    class Widget {
        static plugin(widget: any, name: string): void;
    }
}
declare module Mobilize.WebMap.Kendo {
    class App extends Application.App {
        constructor();
        kendoRegister(inject: Contract.Application.IInject): void;
        kendoResolver(modelResolver: Contract.Core.IModelResolver): void;
        viewHandler(viewManager: Contract.Ui.IViewManager): void;
    }
}
declare module Mobilize {
    namespace Ui {
        class BaseDynamicContainer extends BaseUserControl {
            init(element: any, options: any): void;
            options: {
                name: string;
                value: any;
                css: string;
                template: string;
                uiinitialized: boolean;
            };
            applyHtmlDynamicContent(view: any): void;
            buildUI(): void;
            refresh(): void;
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class KendoUtils {
            static getControlHtml(control: any): string;
            static getBindinExpressionFromModel(model: any): string;
            static getRootParent(model: any): any;
            static removeDynamicControls(element: any): void;
            static areAllControlsInHtml(controls: any, element: any): boolean;
            private static getIdToHtmlFromUserControl(control);
            private static getKendoDataRoleFromName(name);
            private static getHashCodeFromUniqueID(uniqueID);
        }
    }
}
declare module WebMap.Client {
}


interface Window {
    app: any;
}

declare var ui: any;
