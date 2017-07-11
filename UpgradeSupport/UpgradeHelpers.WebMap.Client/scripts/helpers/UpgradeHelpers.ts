module UpgradeHelpers {

    export class ControlArray {

        public static indexOf(ctrlArray, e): number {
            return ctrlArray.indexOf(Events.getEventSender(e));
        }

    }

    export class Events {

        public static getEventSender(e:any): any {
            var isEvent = (e.target != undefined);
            var id = isEvent ? e.target.id : e.id;
            var viewModel = isEvent ? e.data : e.ViewModel;
            var controlArrayRefRegex = /^_(.+)_([0-9]+)/;
            var eventSender = undefined;
            if (controlArrayRefRegex.test(id)) {
                eventSender = viewModel.get(id.replace(controlArrayRefRegex, "$1[$2]"));
            }
            else
                eventSender = viewModel.get(id);
            return eventSender;
        }

    }

    export class EventKey {

        public static getKeyChar(e: any): string {
            return String.fromCharCode(this.getKeyCode(e));
        }

        public static setKeyChar(e: any, key: string): void {
            this.setKeyCode(e, key.charCodeAt(0));
        }

        public static getKeyCode(e: any): number {
            return (e.keyCode ? e.keyCode : e.which);
        }

        public static setKeyCode(e: any, key: number): void {
            if (key != 0 && key != this.getKeyCode(e)) {
                var eventSender = Events.getEventSender(e);
                eventSender.set("Text", eventSender.Text + String.fromCharCode(key));
                this.handleEvent(e, true);
            }
        }

        public static handleEvent(e: any, value: boolean): void {
            if (value) {
                e.preventDefault();
            }
        }

    }

    export enum Keys {
        A = 65,
        Add = 43,
        Alt = 18,
        /*        Apps,
                Attn,*/
        B = 66,
        Back = 8,
        /*        BrowserBack,
                BrowserFavorites,
                BrowserForward,
                BrowserHome,
                BrowserRefresh,
                BrowserSearch,
                BrowserStop,*/
        C = 67,
        /*        Cancel,*/
        Capital = 20,
        CapsLock = 20,
        Clear = 46,
        Control = 17,
        ControlKey = 17,
        /*        Crsel,*/
        D = 68,
        D0 = 48,
        D1 = 49,
        D2 = 50,
        D3 = 51,
        D4 = 52,
        D5 = 53,
        D6 = 54,
        D7 = 55,
        D8 = 56,
        D9 = 57,
        Decimal = 44,
        Delete = 46,
        Divide = 47,
        Down = 40,
        E = 69,
        End = 35,
        Enter = 13,
        /*        EraseEof,*/
        Escape = 27,
        /*        Execute,
                Exsel,*/
        F = 70,
        F1 = 112,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        /*        F13,
                F14,
                F15,
                F16,
                F17,
                F18,
                F19,*/
        F2 = 113,
        /*        F20,
                F21,
                F22,
                F23,
                F24,*/
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        /*        FinalMode,*/
        G = 71,
        H = 72,
        /*        HanguelMode,
                HangulMode,
                HanjaMode,
                Help,*/
        Home = 36,
        I = 73,
        /*        IMEAccept,
                IMEAceept,
                IMEConvert,
                IMEModeChange,
                IMENonconvert,*/
        Insert = 45,
        J = 74,
        /*        JunjaMode,*/
        K = 75,
        /*        KanaMode,
                KanjiMode,
                KeyCode,*/
        L = 76,
        /*        LaunchApplication1,
                LaunchApplication2,
                LaunchMail,
                LButton,*/
        LControlKey = 17,
        Left = 37,
        /*        LineFeed,
                LMenu,*/
        LShiftKey = 16,
        /*        LWin,*/
        M = 77,
        /*        MButton,
                MediaNextTrack,
                MediaPlayPause,
                MediaPreviousTrack,
                MediaStop,
                Menu,
                Modifiers,*/
        Multiply = 42,
        N = 78,
        /*        Next,
                NoName,
                None,*/
        NumLock = 144,
        NumPad0 = 48,
        NumPad1 = 49,
        NumPad2 = 50,
        NumPad3 = 51,
        NumPad4 = 52,
        NumPad5 = 53,
        NumPad6 = 54,
        NumPad7 = 55,
        NumPad8 = 56,
        NumPad9 = 57,
        O = 79,
        /*        Oem1,
                Oem102,
                Oem2,
                Oem3,
                Oem4,
                Oem5,
                Oem6,
                Oem7,
                Oem8,
                OemBackslash,
                OemClear,
                OemCloseBrackets,
                Oemcomma,
                OemMinus,
                OemOpenBrackets,
                OemPeriod,
                OemPipe,
                Oemplus,
                OemQuestion,
                OemQuotes,
                OemSemicolon,
                Oemtilde,*/
        P = 80,
        /*        Pa1,
                Packet,*/
        PageDown = 34,
        PageUp = 33,
        /*        Pause,
                Play,
                Print,
                PrintScreen,
                Prior,
                ProcessKey,*/
        Q = 81,
        R = 82,
        /*        RButton,*/
        RControlKey = 17,
        Return = 13,
        Right = 39,
        /*        RMenu,*/
        RShiftKey = 16,
        /*        RWin,*/
        S = 83,
        /*        Scroll,
                Select,
                SelectMedia,
                Separator,*/
        Shift = 16,
        ShiftKey = 16,
        /*        Sleep,
                Snapshot,*/
        Space = 32,
        Subtract = 45,
        T = 84,
        Tab = 9,
        U = 85,
        Up = 38,
        V = 86,
        /*        VolumeDown,
                VolumeMute,
                VolumeUp,*/
        W = 87,
        X = 88,
        /*        XButton1,
                XButton2,*/
        Y = 89,
        Z = 90,
        /*        Zoom*/
    }

    export class Sound {

        public static getBeep(): Sound {
            return new Sound();
        }

        public Play(): void {
            // TODO: to be implemented
            //throw "Sound.Play needs to be implemented";
        }
    }

    export class Strings {

        public static convertToString(obj: any): string {
            return obj == null ? null : obj.toString();
        }

        public static format(obj: any, format: string): string {
            // TODO: to be implemented
            //throw "String.format needs to be implemented";
            return obj.toString();
        }

    }

}        
