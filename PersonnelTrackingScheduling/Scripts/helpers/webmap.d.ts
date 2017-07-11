
declare module Mobilize {
    namespace Contract.System {
        enum ErrorCode {
            ServerError = 500,
            SessionExpire = 440,
            Authentication = 401,
            BadRequest = 400,
            AccessDenied = 403,
        }
        interface IException {
            message: string;
        }
        interface INetworkException extends IException {
            code: ErrorCode;
        }
    }
}
declare module Mobilize {
    namespace Contract.Server {
        interface IServer {
            get(url: string, params: Array<any>, callback: (response: any) => void): any;
            post(url: string, data: any, callback: (response: any) => void, config?: IRequestConfig): any;
        }
        interface IUrlResolver {
            resolveUrl(action: Contract.Application.IActionModel): any;
        }
        interface IResponse {
            views: any;
            models: any;
            viewDeltas: any;
            modelDeltas: any;
            modelDeltaTypes: any;
            switchIds: any;
            removeIds: any;
        }
        interface IRawResponse {
            V: any;
            M: any;
            MT: any;
            VD: any;
            MD: any;
            MDT: any;
            SW: any;
            RM: any;
        }
        interface IRequest {
            dirty: Array<any>;
            vm: string;
            parameters: Array<any>;
        }
        interface IRequestConfig {
            requestType: RequestType;
            contentType: string;
            includeDirty: boolean;
        }
        interface IRequestBuilder {
            create(action: Mobilize.Application.ActionModel): any;
        }
        enum RequestType {
            RawRequest = 0,
            ModelRequest = 1,
        }
    }
}
declare module Mobilize {
    namespace Contract.Application {
        class Constants {
            static EventAggregator: string;
            static ViewManager: string;
            static ViewResolver: string;
            static ModelResolver: string;
            static Server: string;
            static Library: string;
            static Buffer: string;
            static Action: string;
            static Invoker: string;
            static NotifyBuffer: string;
            static UrlResolver: string;
            static ModelFactory: string;
            static ModalFactory: string;
            static RequestBuilder: string;
            static DeltaHandler: string;
            static TypeService: string;
            static WorkQueue: string;
            static CommandWorker: string;
            static CommandFactory: string;
        }
        class ContentType {
            static application_json: string;
            static multipart_formdata: string;
        }
        class Events {
            static Change: string;
            static ActionComplete: string;
            static ActionError: string;
            static ActionSending: string;
            static ApplyDeltas: string;
            static Error: string;
            static AddToWorkQueue: string;
            static ExecWorkQueue: string;
            static PreActionCommandGeneratorRegistration: string;
            static PreActionCommandGeneratorDeregistration: string;
        }
        enum Resolve {
            Singleton = 0,
            Request = 1,
        }
        interface IDomHandler {
            append: any;
            attr: any;
            clone: any;
            prepend: any;
            prop: any;
            remove: any;
            has: any;
            find: any;
            val: any;
            data: any;
            fadeIn: any;
            fadeOut: any;
        }
        interface IDom {
            find: (selector: string) => IDomHandler;
            extend: (object1: Object, object2: Object) => any;
        }
        interface IQuery {
            ajax: any;
            get: any;
        }
        interface ILibrary {
            query: IQuery;
            dom: IDom;
        }
        interface IActionModel {
            controller: string;
            action: string;
            item: Contract.Core.IModel;
            parameters: any;
            callback: (response: Contract.Server.IResponse) => void;
            requestConfig: Contract.Server.IRequestConfig;
        }
        interface IApp {
            onError: (error) => void;
            onInitialized: () => void;
            onRegister: (inject: IInject) => void;
            onResolver: (modelResolver: Contract.Core.IModelResolver) => void;
            onViewHandler: (viewManager: Mobilize.Contract.Ui.IViewManager) => void;
            init(controller?: string, action?: string, callback?: () => void): void;
            sendAction(action: IActionModel): any;
            loadInitialState(controller: string, action: string, callback: () => void): any;
            publishEvent(event: string, data?: any): any;
            executeSafely(data: Contract.Application.IWorkData): any;
            getTypeInfo(modelType: string): string;
        }
        interface IEventAggregator {
            publish(event: string, data?: any): any;
            subscribe(event: string, lambda: (data: any) => void): any;
        }
        interface IInject {
            register(name: string, type: any, resolve: Resolve): any;
            resolve(name: string): any;
        }
        interface IAction {
            send(action: IActionModel, includeDirty?: boolean): any;
        }
        interface IDictionary {
            length: number;
            add(key: string, value: any): void;
            remove(key: string): void;
            containsKey(key: string): boolean;
            keys(): string[];
            values(): any[];
            value(key: string): any;
            replace(key: any, value: any): any;
        }
        interface IDeltaHandler {
            registerWorker(worker: IDeltaWorker): any;
            executeWorkers(resoponse: Server.IResponse): any;
        }
        interface IDeltaWorker {
            Order: Core.Order;
            process(response: Server.IResponse): any;
        }
        interface IWorkQueue {
            addToWorkQueue(data: IWorkData): any;
            executeWorkQueue(): any;
        }
        interface IWorkData {
            key: string;
            fn: () => void;
        }
        interface ICommandWorker {
            Order: Core.Order;
            process(response: Server.IResponse): any;
        }
        interface IRequestCommand {
            command: string;
            data: any;
        }
    }
}
declare module Mobilize {
    namespace Contract.Core {
        enum Order {
            PRE = 1,
            ORD = 2,
            POST = 3,
        }
        interface IChangeBuffer {
            init(entity: IEntity): any;
            getChanges(): any;
        }
        interface IModelNotifier {
            apply(model: IModel): any;
        }
        interface IModelFactory {
            create(model: any): IModel;
        }
        interface IClientBehavior {
            Order: Order;
            apply(model: IModel, root: IEntity): any;
        }
        interface IEntity {
            getModel(key: string): IModel;
            getParentByKey(key: string): IModel;
            getParentByModel(model: IModel): IModel;
            replace(model: IModel): void;
            exists(model: IModel): boolean;
            deleteCascade(key: string): any;
            search(name: string): IModel;
        }
        interface IBuffer extends IEntity {
            add(model: IModel): any;
            apply(fn: (model: IModel) => any): any;
            addRange(models: Array<IModel>): any;
            switchIds(oldUniqueId: string, newUniqueId: string): any;
            toArray(): Array<IModel>;
        }
        interface IModelResolver {
            isCoreSynchronizing: () => boolean;
            init(buffer: IBuffer): any;
            process(): void;
            registerNotifier(notify: IModelNotifier): any;
            registerBehavior(behavior: IClientBehavior): any;
            attachModels(modelDeltas: Array<IModel>): any;
            removeModels(models: Array<Contract.Core.IModel>): any;
            switchIds(ids: Array<Array<string>>): any;
        }
        interface IModel {
            UniqueID: string;
            IsTempModel: boolean;
            IsModalView: boolean;
            childrenToNotify: Array<IModel>;
            isPointer: boolean;
            isArray: boolean;
            getPos(key?: string): number;
            uniqueName(): string;
            parentName(): string;
            isRoot(): boolean;
            isCoreSynchronizing(): any;
            updateModel(item: IModel): any;
            applyOnProperties(item: IModel, fn: (property: any) => void): any;
            fireChange(): any;
            addReference(property: string, item: IModel): any;
            addValue(property: string, value: any): any;
            removeModel(item: IModel): any;
            applyMethod(method: string): any;
            addPointerId(key: string, pointerId: string): any;
            onPropertyChange: (property: string, oldValue: any, newValue: any) => void;
        }
        interface IDirty {
            toReduce(): any;
        }
        interface ITypeService {
            init(data: any): void;
            setAliases(aliases: any): void;
            getAlias(model: string, alias: string): string;
            setTypes(typesInfo: any): any;
            getTypeInfo(typeId: string): any;
        }
    }
}
declare module Mobilize {
    namespace Contract.Ui {
        interface IReceiver {
            execute(command: ICommand): any;
            hasCommand(command: ICommand): boolean;
            registerCommand(name: string, fn: (command: ICommand) => void): any;
        }
        interface IViewManager extends IReceiver {
            createView(model: Contract.Core.IModel, items?: Array<string>, views?: Array<Contract.Ui.IView>): void;
            deleteView(viewId: string): void;
            getView(model: Core.IModel): IView;
            removeViews(data: any): void;
            init(views: any, models: Core.IEntity): any;
            loadDeltas(viewDeltas: any): any;
            loadFirstViews(views: any): any;
            registerModal(modal: IModal): any;
        }
        interface IInvoker {
            invoke(command: ICommand): any;
            register(receiver: IReceiver): any;
        }
        interface IUiElement {
            onLoad: (sender: any, events: any) => void;
            onPostLoad: (sender: any, events: any) => void;
            load(): any;
            render(): any;
            dispose(): any;
        }
        interface ITemplate {
            getTemplate(): string;
            setTemplate(template: string): any;
        }
        interface IView extends IUiElement {
            name: string;
            model: Contract.Core.IModel;
            invoke(command: ICommand): void;
            bind(action: string, delegate: (sender: IView, action: string, event: any) => void): any;
            close(): any;
            requestClose(): any;
            registerTimer(timerInfo: any): any;
        }
        interface ICommand {
            name: string;
        }
        interface IViewResolver {
            resolve(model: Contract.Core.IModel, load: (view: IView) => void): any;
        }
        interface IMessage {
            UniqueID: string;
            text: string;
            buttons?: number;
            icons?: number;
            promptMessage?: string;
            Continuation_UniqueID?: string;
            caption?: string;
        }
        interface IModal {
            name(): string;
            show(params: any): any;
        }
        interface IModalFactory {
            create(type: string): IModal;
            register(modal: IModal): any;
        }
        interface ICommandFactory {
            create(type: any): ICommand;
            register(name: string, constructor: any): any;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class Dictionary implements Contract.Application.IDictionary {
            _keys: Array<string>;
            _values: Array<any>;
            constructor();
            add(key: string, value: any): void;
            remove(key: string): void;
            keys(): string[];
            values(): any[];
            value(key: string): any;
            containsKey(key: string): boolean;
            toLookup(): Contract.Application.IDictionary;
            readonly length: number;
            replace(key: string, value: any): void;
        }
    }
}
declare module Mobilize {
    namespace System {
        class Exception implements Contract.System.IException {
            private _message;
            constructor(message: string);
            readonly message: string;
        }
    }
}
declare module Mobilize {
    namespace System {
        class NetworkException implements Contract.System.INetworkException {
            private _message;
            private _code;
            constructor(message: string, code: Contract.System.ErrorCode);
            readonly message: string;
            readonly code: Contract.System.ErrorCode;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class ActionModel implements Contract.Application.IActionModel {
            private _controller;
            private _action;
            private _item;
            private _parameters;
            private _callback;
            private _includeDirty;
            private _requestConfig;
            constructor(controller?: string, action?: string, item?: Contract.Core.IModel, parameters?: any, callback?: (response: any) => void, requestConfig?: Contract.Server.IRequestConfig);
            controller: string;
            action: string;
            item: Contract.Core.IModel;
            parameters: any;
            callback: (response: Contract.Server.IResponse) => void;
            includeDirty: boolean;
            requestConfig: Contract.Server.IRequestConfig;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class Model implements Contract.Core.IModel {
            static separator: string;
            childrenToNotify: Array<Model>;
            onPropertyChange: (property: string, oldValue: any, newValue: any) => void;
            protected onModelChange: () => void;
            private _uniqueID;
            private _pointers;
            private _internalProperties;
            private _isTempModel;
            private _isModalView;
            notifiercount(): number;
            UniqueID: string;
            IsTempModel: boolean;
            IsModalView: boolean;
            readonly isPointer: boolean;
            __notify(property: any, value: any): void;
            __subscribe(model: Model): void;
            constructor(uniqueId?: string, obj?: any);
            addReference(property: string, item: Contract.Core.IModel): void;
            addValue(property: string, value: any): void;
            uniqueName(): string;
            parentName(): string;
            isRoot(): boolean;
            parentNameKey(key: string): string;
            isCoreSynchronizing(): boolean;
            updateModel(item: Contract.Core.IModel): void;
            applyOnProperties(item: Contract.Core.IModel, fn: (property: any) => void): void;
            removeModel(item: Contract.Core.IModel): void;
            fireChange(): void;
            applyMethod(method: string): void;
            addPointerId(key: string, pointerId: string): void;
            getPos(key?: string): number;
            private addProperties(obj);
            readonly isArray: any;
            private addOnArray(array, item);
            private addArrayMethods(array);
            private addSpliceMethod(array);
            private addPushMethod(array);
            private addSortMethod(array);
            private removeOnArray(item);
            private getPositionOnArray(item);
            private addPointerProperties(model);
            private getPointerId(key);
            private getPointerName(key);
        }
    }
}
declare module Mobilize {
    namespace Core {
        import IModel = Mobilize.Contract.Core.IModel;
        class ModelCollection implements Contract.Core.IBuffer {
            models: Contract.Application.IDictionary;
            constructor();
            add(model: IModel): void;
            apply(fn: (model: IModel) => any): void;
            getModel(key: string): IModel;
            getParentByKey(key: string): IModel;
            getParentByModel(model: IModel): IModel;
            addRange(array: Array<Contract.Core.IModel>): void;
            readonly length: number;
            deleteCascade(key: string): void;
            replace(model: IModel): void;
            switchIds(oldUniqueId: string, newUniqueId: string): void;
            exists(model: Contract.Core.IModel): boolean;
            search(name: string): IModel;
            toArray(): Array<IModel>;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class DirtyModel implements Contract.Core.IDirty {
            private _name;
            private _properties;
            constructor(name: string, properties: Array<DirtyProperty>);
            name: string;
            properties: Array<DirtyProperty>;
            toReduce(): any;
            private minProperties();
        }
    }
}
declare module Mobilize {
    namespace Application {
        class Alert {
            _caption: string;
            _message: string;
            _info: string;
            _type: string;
            _tooltip: string;
            constructor(caption: string, message: string, info?: string, type?: string, tooltip?: string);
            readonly caption: string;
            readonly message: string;
            readonly info: string;
            readonly tooltip: string;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class DirtyProperty {
            private _name;
            private _value;
            constructor(name: string, value: string);
            name: string;
            value: string;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class InjectMember {
            private _constructor;
            private resolve;
            private instance;
            constructor(_constructor: any, resolve: Contract.Application.Resolve);
            getObject(inject: Contract.Application.IInject): any;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class EventAggregator implements Contract.Application.IEventAggregator {
            private events;
            constructor();
            publish(event: string, data?: any): void;
            subscribe(event: string, lambda: (data: any) => void): void;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class Inject implements Contract.Application.IInject {
            private static _instance;
            private dictionary;
            constructor(dictionary?: Contract.Application.IDictionary);
            register(name: string, _constructor: any, resolve: Contract.Application.Resolve): void;
            resolve(name: string): any;
            static readonly Instance: Contract.Application.IInject;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class PendingEvent {
            private _action;
            private _request;
            constructor(action: Contract.Application.IActionModel, request: Contract.Server.IRequest);
            readonly action: Contract.Application.IActionModel;
            readonly request: Contract.Server.IRequest;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class ChangeNotifier implements Mobilize.Contract.Core.IModelNotifier {
            private event;
            private inject;
            constructor(inject?: Contract.Application.IInject);
            apply(model: Mobilize.Contract.Core.IModel): void;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class DirtyCache implements Contract.Core.IChangeBuffer {
            private items;
            private event;
            private entity;
            constructor(inject?: Contract.Application.IInject);
            change(model: Contract.Core.IModel, property: string): void;
            init(entity: Mobilize.Contract.Core.IEntity): void;
            getChanges(): any;
            private setListener();
        }
    }
}
declare module Mobilize {
    namespace Core {
        import ClientBehavior = Mobilize.Contract.Core.IClientBehavior;
        import Entity = Mobilize.Contract.Core.IEntity;
        import IModel = Mobilize.Contract.Core.IModel;
        import Order = Contract.Core.Order;
        class AliasBehavior implements ClientBehavior {
            private inject;
            aliasService: Contract.Core.ITypeService;
            constructor(inject?: Contract.Application.IInject);
            apply(model: IModel, root: Entity): void;
            readonly Order: Order;
        }
    }
}
declare module Mobilize {
    namespace Core {
        import ClientBehavior = Mobilize.Contract.Core.IClientBehavior;
        import Entity = Mobilize.Contract.Core.IEntity;
        import IModel = Mobilize.Contract.Core.IModel;
        import Order = Contract.Core.Order;
        class HierarchyBehavior implements ClientBehavior {
            apply(model: IModel, root: Entity): void;
            readonly Order: Order;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class PointerBehavior implements Mobilize.Contract.Core.IClientBehavior {
            apply(model: Contract.Core.IModel, root: Mobilize.Contract.Core.IEntity): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Core {
        import ClientBehavior = Mobilize.Contract.Core.IClientBehavior;
        import IModel = Mobilize.Contract.Core.IModel;
        import Entity = Mobilize.Contract.Core.IEntity;
        import Order = Contract.Core.Order;
        class PropagateChangeIdBehavior implements ClientBehavior {
            apply(model: IModel, root: Entity): void;
            readonly Order: Order;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class ModelFactory implements Contract.Core.IModelFactory {
            create(model: any): Contract.Core.IModel;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class TypeService implements Contract.Core.ITypeService {
            private aliases;
            private typesInfo;
            private inject;
            private modelResolver;
            private behaviorEnabled;
            constructor(inject?: Contract.Application.IInject);
            getAlias(model: string, alias: string): any;
            setAliases(aliases: any): void;
            init(data: any): void;
            setTypes(typesInfo: any): void;
            getTypeInfo(typeId: string): any;
            private enableAliasBehavior(aliasesInfo);
        }
    }
}
declare module Mobilize {
    namespace Server {
        class RequestBuilder implements Contract.Server.IRequestBuilder {
            private inject;
            private library;
            constructor(inject?: Contract.Application.IInject);
            create(action: Mobilize.Application.ActionModel): any;
        }
    }
}
declare module Mobilize {
    namespace Server {
        class RequestConfig implements Contract.Server.IRequestConfig {
            requestType: Contract.Server.RequestType;
            includeDirty: boolean;
            contentType: string;
            constructor(_requestType?: Contract.Server.RequestType, _includeDirty?: boolean, _contentType?: string);
        }
    }
}
declare module Mobilize {
    namespace Core {
        class ModelResolver implements Contract.Core.IModelResolver {
            private inject;
            private behaviors;
            private notifiers;
            private _isSynchronizing;
            private buffer;
            private modelFactory;
            constructor(inject?: Contract.Application.IInject);
            init(buffer: Mobilize.Contract.Core.IBuffer): void;
            registerNotifier(notifier: Contract.Core.IModelNotifier): void;
            registerBehavior(behavior: Contract.Core.IClientBehavior): void;
            process(): void;
            attachModels(modelDeltas: Array<Contract.Core.IModel>): void;
            removeModels(models: Array<Contract.Core.IModel>): void;
            switchIds(ids: Array<Array<string>>): void;
            isCoreSynchronizing(): boolean;
            private detachModel(model);
            private addBehavior(behavior);
            private propagateDeltas(modelDeltas);
            private sortArraysModels(arrays);
            private attachIsSynchronizingClient(model);
            private updateModel(item);
            private getBehaviors();
            private applyBehaviors(behaviors, models);
            private tryApplyBehaviors(behavior, model);
            private createMissingHierarchy(models);
            private createMissingParent(model, buffer);
        }
    }
}
declare module Mobilize {
    namespace Server {
        class HttpServer implements Contract.Server.IServer {
            private library;
            private event;
            private inject;
            constructor(inject?: Contract.Application.IInject);
            get(url: string, params: any[], callback: (response: any) => void): void;
            post(url: string, data: any, callback: (response: any) => void, config?: Contract.Server.IRequestConfig): void;
            private ExecuteResponse(response, callback);
            private validateResponse(response);
            private sendRequest(url, data, config?);
            private processFormData(url, data);
            private processApplicationJSON(url, data);
            private processDefault(url, data, contentType);
        }
    }
}
declare module Mobilize {
    namespace Server {
        class Request implements Contract.Server.IRequest {
            dirty: Array<any>;
            vm: string;
            parameters: Array<any>;
            commands: Array<any>;
            constructor();
        }
    }
}
declare module Mobilize {
    namespace Server {
        class Response implements Contract.Server.IResponse {
            V: any;
            M: any;
            MT: any;
            VD: any;
            MD: any;
            MDT: any;
            SW: any;
            RM: any;
            constructor(rawResponse: Mobilize.Contract.Server.IRawResponse);
            readonly views: any;
            readonly models: any;
            readonly viewDeltas: any;
            readonly modelDeltas: any;
            readonly modelDeltaTypes: any;
            readonly switchIds: any;
            readonly removeIds: any;
            private addProperties(rawResponse);
            private checkModelTypes(rawResponse);
            private associateModelTypes(models, modelTypes);
            private mergeType(model, modelType);
        }
    }
}
declare module Mobilize {
    namespace Server {
        class UrlResolver implements Contract.Server.IUrlResolver {
            resolveUrl(action: Contract.Application.IActionModel): string;
            private getController(action);
            private getAction(action);
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class Invoker implements Contract.Ui.IInvoker {
            private receivers;
            constructor();
            invoke(command: Contract.Ui.ICommand): void;
            register(receiver: Contract.Ui.IReceiver): void;
        }
    }
}
declare module Mobilize {
    namespace Ui {
        abstract class Modal implements Contract.Ui.IModal {
            onLoad: () => void;
            protected library: Contract.Application.ILibrary;
            private invoker;
            constructor(inject?: Contract.Application.IInject);
            abstract name(): string;
            invoke(command: Contract.Ui.ICommand): void;
            executeLoad(): void;
            abstract show(params: any): any;
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class ModalFactory implements Contract.Ui.IModalFactory {
            private factories;
            constructor();
            create(type: string): Mobilize.Contract.Ui.IModal;
            register(modal: Mobilize.Contract.Ui.IModal): void;
        }
    }
}
declare module Mobilize {
    namespace Ui {
        abstract class View implements Mobilize.Contract.Ui.IView {
            name: string;
            model: Mobilize.Contract.Core.IModel;
            onLoad: (sender, events) => void;
            onPostLoad: (sender, events) => void;
            private invoker;
            private timersToCleanup;
            constructor(model: Mobilize.Contract.Core.IModel, inject?: Mobilize.Application.Inject);
            close(): void;
            requestClose(): void;
            load(): void;
            bind(action: string, delegate: (sender: Contract.Ui.IView, action: string, event: any) => void): void;
            abstract bindings(): any;
            abstract render(): any;
            abstract dispose(): any;
            invoke(command: Mobilize.Contract.Ui.ICommand): void;
            registerTimer(timerInfo: any): void;
            private cleanupTimers();
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class ViewManager implements Contract.Ui.IViewManager {
            private inject;
            private views;
            private commands;
            private action;
            private viewResolver;
            private modalFactory;
            private onRegisterCommand;
            private models;
            constructor(inject?: Contract.Application.IInject);
            createView(model: Contract.Core.IModel, items?: Array<string>, views?: Array<Contract.Ui.IView>): void;
            viewCreated(view: Contract.Ui.IView): void;
            deleteView(viewId: string): void;
            getView(model: Contract.Core.IModel): Contract.Ui.IView;
            removeViews(data: any): void;
            execute(command: Contract.Ui.ICommand): void;
            hasCommand(command: Contract.Ui.ICommand): boolean;
            registerCommand(name: string, fn: (command: Contract.Ui.ICommand) => void): void;
            registerModal(modal: Mobilize.Contract.Ui.IModal): void;
            init(views: any, models: Contract.Core.IEntity): void;
            loadFirstViews(views: any): void;
            loadDeltas(viewDeltas: any): void;
            private setFocus(control);
            private loadNewViews(newViews, modalViews);
            private isModalView(viewId, modalViews);
            private initializeCommand();
            private inputBoxHandler(command);
            private messageBoxHandler(command);
            private openViewHandler(command);
            private closeViewHandler(command);
            private closeHandler(command);
            private clientCloseHandler(command);
            private sendHandler(command);
            private modalHandler(command);
            private modalActionHandler(command);
            private inputBoxActionHandler(command);
            private keyPressHandler(command);
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ClientClose implements Mobilize.Contract.Ui.ICommand {
            private _controller;
            private _action;
            private _args;
            constructor(sender: Mobilize.Contract.Ui.IView, controller?: string, action?: string);
            readonly controller: string;
            readonly args: any;
            readonly action: string;
            readonly name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class Close implements Mobilize.Contract.Ui.ICommand {
            private _sender;
            private _action;
            constructor(sender: Mobilize.Contract.Ui.IView, action: string);
            readonly sender: Mobilize.Contract.Ui.IView;
            readonly action: any;
            readonly name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class Commands {
            static readonly CloseCommand: string;
            static readonly ClientCloseCommand: string;
            static readonly KeyPressCommand: string;
            static readonly InputBoxActionCommand: string;
            static readonly ModalCommand: string;
            static readonly ModalActionCommand: string;
            static readonly SendCommand: string;
            static readonly LoadingCommand: string;
            static readonly MessageBox: string;
            static readonly OpenView: string;
            static readonly CloseView: string;
            static readonly InputBox: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class KeyPress implements Contract.Ui.ICommand {
            private _sender;
            private _key;
            private _action;
            constructor(sender: Contract.Ui.IView, action: string, key: string);
            readonly name: string;
            readonly sender: Contract.Ui.IView;
            readonly key: string;
            readonly action: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ModalAction implements Contract.Ui.ICommand {
            private _dialogResult;
            private _requestedInput;
            constructor(dialogResult?: string, requestedInput?: string);
            setArgs(dialogResult: string, requestedInput: string): void;
            readonly name: string;
            readonly dialogResult: string;
            readonly requestedInput: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        abstract class ModalCommand implements Contract.Ui.ICommand {
            abstract modalName(): string;
            abstract parameters(): any;
            readonly name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ModalCommandAlert extends Command.ModalCommand {
            private _settings;
            constructor(settings: any);
            modalName(): string;
            parameters(): any;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ModalCommandLoading extends ModalCommand {
            private _settings;
            constructor(settings: any);
            modalName(): string;
            parameters(): any;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class InputBoxAction implements Contract.Ui.ICommand {
            private _dialogResult;
            private _requestedInput;
            constructor(dialogResult: string, requestedInput: string);
            readonly name: string;
            readonly dialogResult: string;
            readonly requestedInput: string;
        }
    }
}
declare module Mobilize {
    namespace System.Aop {
        function Component(templateUrl: string, styleCss: string): (target: Function) => any;
    }
}
declare module Mobilize {
    namespace System.Aop {
        function ExceptionHandler(onException?: string): (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => TypedPropertyDescriptor<any>;
    }
}
declare module Mobilize {
    namespace Application {
        class ActionService implements Contract.Application.IAction {
            private pendingEvents;
            private http;
            private inject;
            private changeBuffer;
            private urlResolver;
            private event;
            private state;
            private requestBuilder;
            private commandGenerators;
            constructor(inject?: Contract.Application.IInject);
            send(action: ActionModel): void;
            addCommandGenerator(commandGenerator: () => Contract.Application.IRequestCommand): void;
            removeCommandGenerator(commandGenerator: () => Contract.Application.IRequestCommand): void;
            private processActionResponse(action, response);
            private processPending();
            private onException();
            private sendActions();
            private handleResponse(action, response);
            private buildCommandGenerators();
        }
    }
}
declare module Mobilize {
    namespace Application {
        class App implements Contract.Application.IApp {
            protected inject: Contract.Application.IInject;
            protected viewManager: Contract.Ui.IViewManager;
            protected modelResolver: Contract.Core.IModelResolver;
            protected event: Contract.Application.IEventAggregator;
            protected action: Contract.Application.IAction;
            protected invoker: Contract.Ui.IInvoker;
            protected notifyBuffer: Contract.Core.IChangeBuffer;
            protected modelFactory: Contract.Core.IModelFactory;
            protected models: Contract.Core.IBuffer;
            protected deltaHandler: Contract.Application.IDeltaHandler;
            protected typeService: Contract.Core.ITypeService;
            protected commandFactory: Contract.Ui.ICommandFactory;
            protected httpService: Contract.Server.IServer;
            protected workQueue: Contract.Application.IWorkQueue;
            onRegister: (inject: Mobilize.Contract.Application.IInject) => void;
            onResolver: (modelResolver: Mobilize.Contract.Core.IModelResolver) => void;
            onInvoker: (invoker: Mobilize.Contract.Ui.IInvoker) => void;
            onViewHandler: (viewManager: Mobilize.Contract.Ui.IViewManager) => void;
            onCommandRegister: (factory: Mobilize.Contract.Ui.ICommandFactory) => void;
            onInitialized: () => void;
            onError: (error) => void;
            constructor(inject?: Contract.Application.IInject);
            protected handleResponse(response: Contract.Server.IResponse): void;
            protected getDependenciesForTypes(modelTypes: any): Array<string>;
            protected getDependencyFullName(modelType: string): string;
            init(controller?: string, action?: string, callback?: () => void): void;
            sendAction(action: Contract.Application.IActionModel): void;
            loadInitialState(controller: string, action: string, callback?: () => void): void;
            isSyncronizing(): boolean;
            executeSafely(data: Contract.Application.IWorkData): void;
            getTypeInfo(modelType: string): string;
            publishEvent(event: string, data?: any): void;
            private afterInit(callback?);
            private register();
            private initResolve();
            private modelResolverInit();
            private deltaHandlerInit();
            private executeOnCommandRegister();
            private executeOnInvoker();
            private executeOnRegister();
            private executeOnResolver();
            private executeOnViewResolver();
            private handleError(exception);
            private handleNetworkError(exception);
            private subscribe();
            private initModules();
            private loadModelTypes(callback);
        }
    }
}
declare module Mobilize {
    namespace Application {
        class DeltaHandler implements Contract.Application.IDeltaHandler {
            private inject;
            private preWorkers;
            private workers;
            private postWorkers;
            private event;
            constructor(inject?: Contract.Application.IInject);
            registerWorker(worker: Contract.Application.IDeltaWorker): void;
            executeWorkers(response: Contract.Server.IResponse): void;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class Library implements Contract.Application.ILibrary {
            private _query;
            private _dom;
            private domWrapper;
            constructor(query?: Contract.Application.IQuery, dom?: Contract.Application.IDom);
            readonly query: Contract.Application.IQuery;
            readonly dom: Contract.Application.IDom;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class WorkQueue implements Contract.Application.IWorkQueue {
            private inject;
            private event;
            private queue;
            private executingKey;
            constructor(inject?: Contract.Application.IInject);
            addToWorkQueue(data: Contract.Application.IWorkData): void;
            executeWorkQueue(): void;
            private init();
        }
    }
}
declare module Mobilize {
    namespace Application.DeltaWorker {
        class CommandsWorker implements Contract.Application.ICommandWorker {
            private inject;
            private invoker;
            private commandFactory;
            constructor(inject?: Contract.Application.IInject);
            process(response: Contract.Server.IResponse): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Application.DeltaWorker {
        class ModelDeltaWorker implements Contract.Application.IDeltaWorker {
            private inject;
            private modelResolver;
            private modelFactory;
            constructor(inject?: Contract.Application.IInject);
            process(response: Contract.Server.IResponse): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Application.DeltaWorker {
        class RemovedIdWorker implements Contract.Application.IDeltaWorker {
            private inject;
            private modelResolver;
            private modelFactory;
            constructor(inject?: Contract.Application.IInject);
            process(response: Contract.Server.IResponse): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Application.DeltaWorker {
        class SwitchIdWorker implements Contract.Application.IDeltaWorker {
            private inject;
            private modelResolver;
            constructor(inject?: Contract.Application.IInject);
            process(response: Contract.Server.IResponse): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Application.DeltaWorker {
        class ViewDeltaWorker implements Contract.Application.IDeltaWorker {
            private inject;
            private viewManager;
            constructor(inject?: Contract.Application.IInject);
            process(response: Contract.Server.IResponse): void;
            readonly Order: Contract.Core.Order;
        }
    }
}
declare module Mobilize {
    namespace Core {
        import ClientBehavior = Mobilize.Contract.Core.IClientBehavior;
        import Entity = Mobilize.Contract.Core.IEntity;
        import IModel = Mobilize.Contract.Core.IModel;
        import Order = Contract.Core.Order;
        class ModalVisibilityManagementBehavior implements ClientBehavior {
            private inject;
            aliasService: Contract.Core.ITypeService;
            eventAggregator: Contract.Application.IEventAggregator;
            constructor(inject?: Contract.Application.IInject);
            apply(model: IModel, root: Entity): void;
            readonly Order: Order;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class CloseView implements Mobilize.Contract.Ui.ICommand {
            private _arguments;
            private _uniqueID;
            constructor(data: any);
            readonly sender: any;
            readonly UniqueID: any;
            readonly name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui {
        class CommandFactory implements Contract.Ui.ICommandFactory {
            private factories;
            constructor();
            create(args: any): Mobilize.Contract.Ui.ICommand;
            register(name: string, constructor: any): void;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class InputBox implements Contract.Ui.ICommand {
            private _input;
            private _caption;
            private _text;
            private _icons;
            constructor(data: any);
            readonly name: string;
            readonly input: string;
            readonly caption: string;
            readonly text: string;
            readonly icons: number;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class MessageBox implements Mobilize.Contract.Ui.ICommand {
            private _sender;
            private _action;
            private _input;
            private _inputRequest;
            private _caption;
            private _text;
            private _buttons;
            private _icons;
            constructor(data: any);
            readonly sender: Mobilize.Contract.Ui.IView;
            readonly action: any;
            readonly name: string;
            readonly input: string;
            readonly inputRequest: string;
            readonly caption: string;
            readonly text: string;
            readonly buttons: number;
            readonly icons: number;
            readonly status: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ModalCommandSessionExpired extends ModalCommand {
            private _settings;
            constructor(settings: any);
            modalName(): string;
            parameters(): any;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class OpenView implements Mobilize.Contract.Ui.ICommand {
            private _arguents;
            private _uniqueID;
            constructor(data: any);
            readonly sender: any;
            readonly UniqueID: any;
            readonly name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class Send implements Mobilize.Contract.Ui.ICommand {
            _sender: Mobilize.Contract.Ui.IView;
            _action: string;
            _args: any;
            _callback: (response?: Contract.Server.IResponse) => void;
            constructor(sender: Mobilize.Contract.Ui.IView, action: string, args?: any, callback?: (resonse?: Contract.Server.IResponse) => void);
            readonly sender: Mobilize.Contract.Ui.IView;
            readonly action: any;
            readonly name: string;
            readonly args: any;
            readonly callback: (response?: Contract.Server.IResponse) => void;
        }
    }
}
