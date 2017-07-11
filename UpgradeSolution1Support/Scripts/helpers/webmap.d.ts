
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
        }
        class Events {
            static Change: string;
            static ActionComplete: string;
            static ActionError: string;
            static ActionSending: string;
            static ApplyDeltas: string;
            static Error: string;
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
        }
        interface IBuffer extends IEntity {
            add(model: IModel): any;
            apply(fn: (model: IModel) => any): any;
            addRange(models: Array<IModel>): any;
            switchIds(oldUniqueId: string, newUniqueId: string): any;
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
            uniqueName(): string;
            parentName(): string;
            isRoot(): boolean;
            isCoreSynchronizing(): any;
            updateModel(item: IModel): any;
            fireChange(): any;
            addReference(property: string, item: IModel): any;
            removeModel(item: IModel): any;
        }
        interface IDirty {
            toReduce(): any;
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
            createView(model: Core.IModel): void;
            deleteView(viewId: string): void;
            getView(model: Core.IModel): IView;
            removeViews(data: any): void;
            init(views: any, models: Core.IEntity): any;
            loadDeltas(viewDeltas: any): any;
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
            length: number;
            replace(key: string, value: any): void;
        }
    }
}
declare module Mobilize {
    namespace System {
        class Exception implements Contract.System.IException {
            private _message;
            constructor(message: string);
            message: string;
        }
    }
}
declare module Mobilize {
    namespace System {
        class NetworkException implements Contract.System.INetworkException {
            private _message;
            private _code;
            constructor(message: string, code: Contract.System.ErrorCode);
            message: string;
            code: Contract.System.ErrorCode;
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
            private static separator;
            protected onModelChange: () => void;
            private _uniqueID;
            private observables;
            notifiercount(): number;
            UniqueID: string;
            __notify(property: any, value: any): void;
            __subscribe(model: Model): void;
            constructor(uniqueId?: string, obj?: any);
            addReference(property: string, item: Contract.Core.IModel): void;
            uniqueName(): string;
            parentName(): string;
            isRoot(): boolean;
            parentNameKey(key: string): string;
            isCoreSynchronizing(): boolean;
            updateModel(item: Contract.Core.IModel): void;
            removeModel(item: Contract.Core.IModel): void;
            fireChange(): void;
            private addProperties(obj);
            protected isArray: any;
            pos: number;
            private addOnArray(array, item);
            private addArrayMethods(array);
            private addSpliceMethod(array);
            private addPushMethod(array);
            private addSortMethod(array);
            private removeOnArray(item);
            private getPositionOnArray(item);
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
            length: number;
            deleteCascade(key: string): void;
            replace(model: IModel): void;
            switchIds(oldUniqueId: string, newUniqueId: string): void;
            exists(model: Contract.Core.IModel): boolean;
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
            caption: string;
            message: string;
            info: string;
            tooltip: string;
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
            static Instance: Contract.Application.IInject;
        }
    }
}
declare module Mobilize {
    namespace Application {
        class PendingEvent {
            private _action;
            private _request;
            constructor(action: Contract.Application.IActionModel, request: Contract.Server.IRequest);
            action: Contract.Application.IActionModel;
            request: Contract.Server.IRequest;
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
        class HierarchyBehavior implements ClientBehavior {
            apply(model: IModel, root: Entity): void;
            Order: Order;
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
        class ModelResolver implements Contract.Core.IModelResolver {
            private behaviors;
            private notifiers;
            private _isSynchronizing;
            private buffer;
            constructor();
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
            private applyBehaviors(behaviors, model);
            private tryApplyBehaviors(behavior, model);
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
        }
    }
}
declare module Mobilize {
    namespace Server {
        class Request implements Contract.Server.IRequest {
            dirty: Array<any>;
            vm: string;
            parameters: Array<any>;
        }
    }
}
declare module Mobilize {
    namespace Server {
        class Response implements Contract.Server.IResponse {
            V: any;
            M: any;
            VD: any;
            MD: any;
            SW: any;
            RM: any;
            constructor(rawResponse: Mobilize.Contract.Server.IRawResponse);
            views: any;
            models: any;
            viewDeltas: any;
            modelDeltas: any;
            switchIds: any;
            removeIds: any;
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
            constructor(model: Mobilize.Contract.Core.IModel, inject?: Mobilize.Application.Inject);
            close(): void;
            requestClose(): void;
            load(): void;
            bind(action: string, delegate: (sender: Contract.Ui.IView, action: string, event: any) => void): void;
            abstract bindings(): any;
            abstract render(): any;
            abstract dispose(): any;
            invoke(command: Mobilize.Contract.Ui.ICommand): void;
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
            createView(model: Contract.Core.IModel): void;
            viewCreated(view: Contract.Ui.IView): void;
            deleteView(viewId: string): void;
            getView(model: Contract.Core.IModel): Contract.Ui.IView;
            removeViews(data: any): void;
            execute(command: Contract.Ui.ICommand): void;
            hasCommand(command: Contract.Ui.ICommand): boolean;
            registerCommand(name: string, fn: (command: Contract.Ui.ICommand) => void): void;
            registerModal(modal: Mobilize.Contract.Ui.IModal): void;
            init(views: any, models: Contract.Core.IEntity): void;
            loadDeltas(viewDeltas: any): void;
            private loadModals(commands);
            private loadNewViews(newViews);
            private initializeCommand();
            private closeHandler(command);
            private clientCloseHandler(command);
            private sendHandler(command);
            private modalHandler(command);
            private modalActionHandler(command);
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
            controller: string;
            args: any;
            action: string;
            name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class Close implements Mobilize.Contract.Ui.ICommand {
            private _sender;
            private _action;
            constructor(sender: Mobilize.Contract.Ui.IView, action: string);
            sender: Mobilize.Contract.Ui.IView;
            action: any;
            name: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class Commands {
            static CloseCommand: string;
            static ClientCloseCommand: string;
            static KeyPressCommand: string;
            static ModalCommand: string;
            static ModalActionCommand: string;
            static SendCommand: string;
            static LoadingCommand: string;
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
            name: string;
            sender: Contract.Ui.IView;
            key: string;
            action: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        class ModalAction implements Contract.Ui.ICommand {
            private _dialogResult;
            private _requestedInput;
            constructor(dialogResult: string, requestedInput: string);
            name: string;
            dialogResult: string;
            requestedInput: string;
        }
    }
}
declare module Mobilize {
    namespace Ui.Command {
        abstract class ModalCommand implements Contract.Ui.ICommand {
            abstract modalName(): string;
            abstract parameters(): any;
            name: string;
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
            constructor(inject?: Contract.Application.IInject);
            send(action: ActionModel): void;
            private processActionResponse(action, response);
            private processPending();
            private onException();
            private sendActions();
            private handleResponse(action, response);
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
            onRegister: (inject: Mobilize.Contract.Application.IInject) => void;
            onResolver: (modelResolver: Mobilize.Contract.Core.IModelResolver) => void;
            onInvoker: (invoker: Mobilize.Contract.Ui.IInvoker) => void;
            onViewHandler: (viewManager: Mobilize.Contract.Ui.IViewManager) => void;
            onInitialized: () => void;
            onError: (error) => void;
            constructor(inject?: Contract.Application.IInject);
            init(controller?: string, action?: string, callback?: () => void): void;
            sendAction(action: Contract.Application.IActionModel): void;
            applyDeltas(response: Contract.Server.IResponse): void;
            loadInitialState(controller: string, action: string, callback?: () => void): void;
            isSyncronizing(): boolean;
            private loadResponse(response);
            private initResponse(response, callback?);
            private register();
            private initResolve();
            private modelResolverInit();
            private executeOnInvoker();
            private executeOnRegister();
            private executeOnResolver();
            private executeOnViewResolver();
            private applyModelDeltas(response);
            private applyViewDeltas(response);
            private applySwitchIds(response);
            private applyRemoveDeltas(response);
            private handleError(exception);
            private handleNetworkError(exception);
            private subscribe();
        }
    }
}
declare module Mobilize {
    namespace Application {
        class Library implements Contract.Application.ILibrary {
            private _query;
            private _dom;
            constructor(query?: Contract.Application.IQuery, dom?: Contract.Application.IDom);
            private domWrapper;
            query: Contract.Application.IQuery;
            dom: Contract.Application.IDom;
        }
    }
}
declare module Mobilize {
    namespace Core {
        class PointerBehavior implements Mobilize.Contract.Core.IClientBehavior {
            apply(model: Contract.Core.IModel, root: Mobilize.Contract.Core.IEntity): void;
            Order: Contract.Core.Order;
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
            Order: Order;
        }
    }
}
declare module Mobilize {
    namespace Server {
        class RequestBuilder implements Contract.Server.IRequestBuilder {
            private library;
            constructor();
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
        class Send implements Mobilize.Contract.Ui.ICommand {
            _sender: Mobilize.Contract.Ui.IView;
            _action: string;
            _args: any;
            _callback: (response?: Contract.Server.IResponse) => void;
            constructor(sender: Mobilize.Contract.Ui.IView, action: string, args?: any, callback?: (resonse?: Contract.Server.IResponse) => void);
            sender: Mobilize.Contract.Ui.IView;
            action: any;
            name: string;
            args: any;
            callback: (response?: Contract.Server.IResponse) => void;
        }
    }
}
