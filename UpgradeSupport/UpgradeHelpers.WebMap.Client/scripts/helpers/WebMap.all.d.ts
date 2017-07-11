/// <reference path="jquery.d.ts" />
/// <reference path="kendo.all.d.ts" />
/// <reference path="require.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.caret.d.ts" />
declare namespace JQueryUI {
    interface AccordionOptions extends AccordionEvents {
        active?: any;
        animate?: any;
        collapsible?: boolean;
        disabled?: boolean;
        event?: string;
        header?: string;
        heightStyle?: string;
        icons?: any;
    }
    interface AccordionUIParams {
        newHeader: JQuery;
        oldHeader: JQuery;
        newPanel: JQuery;
        oldPanel: JQuery;
    }
    interface AccordionEvent {
        (event: Event, ui: AccordionUIParams): void;
    }
    interface AccordionEvents {
        activate?: AccordionEvent;
        beforeActivate?: AccordionEvent;
        create?: AccordionEvent;
    }
    interface Accordion extends Widget, AccordionOptions {
    }
    interface AutocompleteOptions extends AutocompleteEvents {
        appendTo?: any;
        autoFocus?: boolean;
        delay?: number;
        disabled?: boolean;
        minLength?: number;
        position?: any;
        source?: any;
    }
    interface AutocompleteUIParams {
        /**
         * The item selected from the menu, if any. Otherwise the property is null
         */
        item?: any;
    }
    interface AutocompleteEvent {
        (event: Event, ui: AutocompleteUIParams): void;
    }
    interface AutocompleteEvents {
        change?: AutocompleteEvent;
        close?: AutocompleteEvent;
        create?: AutocompleteEvent;
        focus?: AutocompleteEvent;
        open?: AutocompleteEvent;
        response?: AutocompleteEvent;
        search?: AutocompleteEvent;
        select?: AutocompleteEvent;
    }
    interface Autocomplete extends Widget, AutocompleteOptions {
        escapeRegex: (value: string) => string;
        filter: (array: any, term: string) => any;
    }
    interface ButtonOptions {
        disabled?: boolean;
        icons?: any;
        label?: string;
        text?: string | boolean;
        click?: (event?: Event) => void;
    }
    interface Button extends Widget, ButtonOptions {
    }
    interface DatepickerOptions {
        /**
         * An input element that is to be updated with the selected date from the datepicker. Use the altFormat option to change the format of the date within this field. Leave as blank for no alternate field.
         */
        altField?: any;
        /**
         * The dateFormat to be used for the altField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the formatDate function
         */
        altFormat?: string;
        /**
         * The text to display after each date field, e.g., to show the required format.
         */
        appendText?: string;
        /**
         * Set to true to automatically resize the input field to accommodate dates in the current dateFormat.
         */
        autoSize?: boolean;
        /**
         * A function that takes an input field and current datepicker instance and returns an options object to update the datepicker with. It is called just before the datepicker is displayed.
         */
        beforeShow?: (input: Element, inst: any) => JQueryUI.DatepickerOptions;
        /**
         * A function that takes a date as a parameter and must return an array with:
         * [0]: true/false indicating whether or not this date is selectable
         * [1]: a CSS class name to add to the date's cell or "" for the default presentation
         * [2]: an optional popup tooltip for this date
         * The function is called for each day in the datepicker before it is displayed.
         */
        beforeShowDay?: (date: Date) => any[];
        /**
         * A URL of an image to use to display the datepicker when the showOn option is set to "button" or "both". If set, the buttonText option becomes the alt value and is not directly displayed.
         */
        buttonImage?: string;
        /**
         * Whether the button image should be rendered by itself instead of inside a button element. This option is only relevant if the buttonImage option has also been set.
         */
        buttonImageOnly?: boolean;
        /**
         * The text to display on the trigger button. Use in conjunction with the showOn option set to "button" or "both".
         */
        buttonText?: string;
        /**
         * A function to calculate the week of the year for a given date. The default implementation uses the ISO 8601 definition: weeks start on a Monday; the first week of the year contains the first Thursday of the year.
         */
        calculateWeek?: (date: Date) => string;
        /**
         * Whether the month should be rendered as a dropdown instead of text.
         */
        changeMonth?: boolean;
        /**
         * Whether the year should be rendered as a dropdown instead of text. Use the yearRange option to control which years are made available for selection.
         */
        changeYear?: boolean;
        /**
         * The text to display for the close link. Use the showButtonPanel option to display this button.
         */
        closeText?: string;
        /**
         * When true, entry in the input field is constrained to those characters allowed by the current dateFormat option.
         */
        constrainInput?: boolean;
        /**
         * The text to display for the current day link. Use the showButtonPanel option to display this button.
         */
        currentText?: string;
        /**
         * The format for parsed and displayed dates. For a full list of the possible formats see the formatDate function.
         */
        dateFormat?: string;
        /**
         * The list of long day names, starting from Sunday, for use as requested via the dateFormat option.
         */
        dayNames?: string[];
        /**
         * The list of minimised day names, starting from Sunday, for use as column headers within the datepicker.
         */
        dayNamesMin?: string[];
        /**
         * The list of abbreviated day names, starting from Sunday, for use as requested via the dateFormat option.
         */
        dayNamesShort?: string[];
        /**
         * Set the date to highlight on first opening if the field is blank. Specify either an actual date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null for today.
         * Multiple types supported:
         * Date: A date object containing the default date.
         * Number: A number of days from today. For example 2 represents two days from today and -1 represents yesterday.
         * String: A string in the format defined by the dateFormat option, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.
         */
        defaultDate?: any;
        /**
         * Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds ("slow", "normal", "fast").
         */
        duration?: string;
        /**
         * Set the first day of the week: Sunday is 0, Monday is 1, etc.
         */
        firstDay?: number;
        /**
         * When true, the current day link moves to the currently selected date instead of today.
         */
        gotoCurrent?: boolean;
        /**
         * Normally the previous and next links are disabled when not applicable (see the minDate and maxDate options). You can hide them altogether by setting this attribute to true.
         */
        hideIfNoPrevNext?: boolean;
        /**
         * Whether the current language is drawn from right to left.
         */
        isRTL?: boolean;
        /**
         * The maximum selectable date. When set to null, there is no maximum.
         * Multiple types supported:
         * Date: A date object containing the maximum date.
         * Number: A number of days from today. For example 2 represents two days from today and -1 represents yesterday.
         * String: A string in the format defined by the dateFormat option, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.
         */
        maxDate?: any;
        /**
         * The minimum selectable date. When set to null, there is no minimum.
         * Multiple types supported:
         * Date: A date object containing the minimum date.
         * Number: A number of days from today. For example 2 represents two days from today and -1 represents yesterday.
         * String: A string in the format defined by the dateFormat option, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.
         */
        minDate?: any;
        /**
         * The list of full month names, for use as requested via the dateFormat option.
         */
        monthNames?: string[];
        /**
         * The list of abbreviated month names, as used in the month header on each datepicker and as requested via the dateFormat option.
         */
        monthNamesShort?: string[];
        /**
         * Whether the prevText and nextText options should be parsed as dates by the formatDate function, allowing them to display the target month names for example.
         */
        navigationAsDateFormat?: boolean;
        /**
         * The text to display for the next month link. With the standard ThemeRoller styling, this value is replaced by an icon.
         */
        nextText?: string;
        /**
         * The number of months to show at once.
         * Multiple types supported:
         * Number: The number of months to display in a single row.
         * Array: An array defining the number of rows and columns to display.
         */
        numberOfMonths?: any;
        /**
         * Called when the datepicker moves to a new month and/or year. The function receives the selected year, month (1-12), and the datepicker instance as parameters. this refers to the associated input field.
         */
        onChangeMonthYear?: (year: number, month: number, inst: any) => void;
        /**
         * Called when the datepicker is closed, whether or not a date is selected. The function receives the selected date as text ("" if none) and the datepicker instance as parameters. this refers to the associated input field.
         */
        onClose?: (dateText: string, inst: any) => void;
        /**
         * Called when the datepicker is selected. The function receives the selected date as text and the datepicker instance as parameters. this refers to the associated input field.
         */
        onSelect?: (dateText: string, inst: any) => void;
        /**
         * The text to display for the previous month link. With the standard ThemeRoller styling, this value is replaced by an icon.
         */
        prevText?: string;
        /**
         * Whether days in other months shown before or after the current month are selectable. This only applies if the showOtherMonths option is set to true.
         */
        selectOtherMonths?: boolean;
        /**
         * The cutoff year for determining the century for a date (used in conjunction with dateFormat 'y'). Any dates entered with a year value less than or equal to the cutoff year are considered to be in the current century, while those greater than it are deemed to be in the previous century.
         * Multiple types supported:
         * Number: A value between 0 and 99 indicating the cutoff year.
         * String: A relative number of years from the current year, e.g., "+3" or "-5".
         */
        shortYearCutoff?: any;
        /**
         * The name of the animation used to show and hide the datepicker. Use "show" (the default), "slideDown", "fadeIn", any of the jQuery UI effects. Set to an empty string to disable animation.
         */
        showAnim?: string;
        /**
         * Whether to display a button pane underneath the calendar. The button pane contains two buttons, a Today button that links to the current day, and a Done button that closes the datepicker. The buttons' text can be customized using the currentText and closeText options respectively.
         */
        showButtonPanel?: boolean;
        /**
         * When displaying multiple months via the numberOfMonths option, the showCurrentAtPos option defines which position to display the current month in.
         */
        showCurrentAtPos?: number;
        /**
         * Whether to show the month after the year in the header.
         */
        showMonthAfterYear?: boolean;
        /**
         * When the datepicker should appear. The datepicker can appear when the field receives focus ("focus"), when a button is clicked ("button"), or when either event occurs ("both").
         */
        showOn?: string;
        /**
         * If using one of the jQuery UI effects for the showAnim option, you can provide additional settings for that animation via this option.
         */
        showOptions?: any;
        /**
         * Whether to display dates in other months (non-selectable) at the start or end of the current month. To make these days selectable use the selectOtherMonths option.
         */
        showOtherMonths?: boolean;
        /**
         * When true, a column is added to show the week of the year. The calculateWeek option determines how the week of the year is calculated. You may also want to change the firstDay option.
         */
        showWeek?: boolean;
        /**
         * Set how many months to move when clicking the previous/next links.
         */
        stepMonths?: number;
        /**
         * The text to display for the week of the year column heading. Use the showWeek option to display this column.
         */
        weekHeader?: string;
        /**
         * The range of years displayed in the year drop-down: either relative to today's year ("-nn:+nn"), relative to the currently selected year ("c-nn:c+nn"), absolute ("nnnn:nnnn"), or combinations of these formats ("nnnn:-nn"). Note that this option only affects what appears in the drop-down, to restrict which dates may be selected use the minDate and/or maxDate options.
         */
        yearRange?: string;
        /**
         * Additional text to display after the year in the month headers.
         */
        yearSuffix?: string;
    }
    interface DatepickerFormatDateOptions {
        dayNamesShort?: string[];
        dayNames?: string[];
        monthNamesShort?: string[];
        monthNames?: string[];
    }
    interface Datepicker extends Widget, DatepickerOptions {
        regional: {
            [languageCod3: string]: any;
        };
        setDefaults(defaults: DatepickerOptions): void;
        formatDate(format: string, date: Date, settings?: DatepickerFormatDateOptions): string;
        parseDate(format: string, date: string, settings?: DatepickerFormatDateOptions): Date;
        iso8601Week(date: Date): number;
        noWeekends(date: Date): any[];
    }
    interface DialogOptions extends DialogEvents {
        autoOpen?: boolean;
        buttons?: {
            [buttonText: string]: (event?: Event) => void;
        } | DialogButtonOptions[];
        closeOnEscape?: boolean;
        closeText?: string;
        appendTo?: string;
        dialogClass?: string;
        disabled?: boolean;
        draggable?: boolean;
        height?: number | string;
        hide?: boolean | number | string | DialogShowHideOptions;
        maxHeight?: number;
        maxWidth?: number;
        minHeight?: number;
        minWidth?: number;
        modal?: boolean;
        position?: any;
        resizable?: boolean;
        show?: boolean | number | string | DialogShowHideOptions;
        stack?: boolean;
        title?: string;
        width?: any;
        zIndex?: number;
        open?: DialogEvent;
        close?: DialogEvent;
    }
    interface DialogButtonOptions {
        icons?: any;
        showText?: string | boolean;
        text?: string;
        click?: (eventObject: JQueryEventObject) => any;
        [attr: string]: any;
    }
    interface DialogShowHideOptions {
        effect: string;
        delay?: number;
        duration?: number;
        easing?: string;
    }
    interface DialogUIParams {
    }
    interface DialogEvent {
        (event: Event, ui: DialogUIParams): void;
    }
    interface DialogEvents {
        beforeClose?: DialogEvent;
        close?: DialogEvent;
        create?: DialogEvent;
        drag?: DialogEvent;
        dragStart?: DialogEvent;
        dragStop?: DialogEvent;
        focus?: DialogEvent;
        open?: DialogEvent;
        resize?: DialogEvent;
        resizeStart?: DialogEvent;
        resizeStop?: DialogEvent;
    }
    interface Dialog extends Widget, DialogOptions {
    }
    interface DraggableEventUIParams {
        helper: JQuery;
        position: {
            top: number;
            left: number;
        };
        offset: {
            top: number;
            left: number;
        };
    }
    interface DraggableEvent {
        (event: Event, ui: DraggableEventUIParams): void;
    }
    interface DraggableOptions extends DraggableEvents {
        disabled?: boolean;
        addClasses?: boolean;
        appendTo?: any;
        axis?: string;
        cancel?: string;
        connectToSortable?: Element | Element[] | JQuery | string;
        containment?: any;
        cursor?: string;
        cursorAt?: any;
        delay?: number;
        distance?: number;
        grid?: number[];
        handle?: any;
        helper?: any;
        iframeFix?: any;
        opacity?: number;
        refreshPositions?: boolean;
        revert?: any;
        revertDuration?: number;
        scope?: string;
        scroll?: boolean;
        scrollSensitivity?: number;
        scrollSpeed?: number;
        snap?: any;
        snapMode?: string;
        snapTolerance?: number;
        stack?: string;
        zIndex?: number;
    }
    interface DraggableEvents {
        create?: DraggableEvent;
        start?: DraggableEvent;
        drag?: DraggableEvent;
        stop?: DraggableEvent;
    }
    interface Draggable extends Widget, DraggableOptions, DraggableEvent {
    }
    interface DroppableEventUIParam {
        draggable: JQuery;
        helper: JQuery;
        position: {
            top: number;
            left: number;
        };
        offset: {
            top: number;
            left: number;
        };
    }
    interface DroppableEvent {
        (event: Event, ui: DroppableEventUIParam): void;
    }
    interface DroppableOptions extends DroppableEvents {
        accept?: any;
        activeClass?: string;
        addClasses?: boolean;
        disabled?: boolean;
        greedy?: boolean;
        hoverClass?: string;
        scope?: string;
        tolerance?: string;
    }
    interface DroppableEvents {
        create?: DroppableEvent;
        activate?: DroppableEvent;
        deactivate?: DroppableEvent;
        over?: DroppableEvent;
        out?: DroppableEvent;
        drop?: DroppableEvent;
    }
    interface Droppable extends Widget, DroppableOptions {
    }
    interface MenuOptions extends MenuEvents {
        disabled?: boolean;
        icons?: any;
        menus?: string;
        position?: any;
        role?: string;
    }
    interface MenuUIParams {
        item?: JQuery;
    }
    interface MenuEvent {
        (event: Event, ui: MenuUIParams): void;
    }
    interface MenuEvents {
        blur?: MenuEvent;
        create?: MenuEvent;
        focus?: MenuEvent;
        select?: MenuEvent;
    }
    interface Menu extends Widget, MenuOptions {
    }
    interface ProgressbarOptions extends ProgressbarEvents {
        disabled?: boolean;
        value?: number | boolean;
        max?: number;
    }
    interface ProgressbarUIParams {
    }
    interface ProgressbarEvent {
        (event: Event, ui: ProgressbarUIParams): void;
    }
    interface ProgressbarEvents {
        change?: ProgressbarEvent;
        complete?: ProgressbarEvent;
        create?: ProgressbarEvent;
    }
    interface Progressbar extends Widget, ProgressbarOptions {
    }
    interface ResizableOptions extends ResizableEvents {
        alsoResize?: any;
        animate?: boolean;
        animateDuration?: any;
        animateEasing?: string;
        aspectRatio?: any;
        autoHide?: boolean;
        cancel?: string;
        containment?: any;
        delay?: number;
        disabled?: boolean;
        distance?: number;
        ghost?: boolean;
        grid?: any;
        handles?: any;
        helper?: string;
        maxHeight?: number;
        maxWidth?: number;
        minHeight?: number;
        minWidth?: number;
    }
    interface ResizableUIParams {
        element: JQuery;
        helper: JQuery;
        originalElement: JQuery;
        originalPosition: any;
        originalSize: any;
        position: any;
        size: any;
    }
    interface ResizableEvent {
        (event: Event, ui: ResizableUIParams): void;
    }
    interface ResizableEvents {
        resize?: ResizableEvent;
        start?: ResizableEvent;
        stop?: ResizableEvent;
        create?: ResizableEvents;
    }
    interface Resizable extends Widget, ResizableOptions {
    }
    interface SelectableOptions extends SelectableEvents {
        autoRefresh?: boolean;
        cancel?: string;
        delay?: number;
        disabled?: boolean;
        distance?: number;
        filter?: string;
        tolerance?: string;
    }
    interface SelectableEvents {
        selected?(event: Event, ui: {
            selected?: Element;
        }): void;
        selecting?(event: Event, ui: {
            selecting?: Element;
        }): void;
        start?(event: Event, ui: any): void;
        stop?(event: Event, ui: any): void;
        unselected?(event: Event, ui: {
            unselected: Element;
        }): void;
        unselecting?(event: Event, ui: {
            unselecting: Element;
        }): void;
    }
    interface Selectable extends Widget, SelectableOptions {
    }
    interface SelectMenuOptions extends SelectMenuEvents {
        appendTo?: string;
        disabled?: boolean;
        icons?: any;
        position?: JQueryPositionOptions;
        width?: number;
    }
    interface SelectMenuUIParams {
        item?: JQuery;
    }
    interface SelectMenuEvent {
        (event: Event, ui: SelectMenuUIParams): void;
    }
    interface SelectMenuEvents {
        change?: SelectMenuEvent;
        close?: SelectMenuEvent;
        create?: SelectMenuEvent;
        focus?: SelectMenuEvent;
        open?: SelectMenuEvent;
        select?: SelectMenuEvent;
    }
    interface SelectMenu extends Widget, SelectMenuOptions {
    }
    interface SliderOptions extends SliderEvents {
        animate?: any;
        disabled?: boolean;
        max?: number;
        min?: number;
        orientation?: string;
        range?: any;
        step?: number;
        value?: number;
        values?: number[];
        highlight?: boolean;
    }
    interface SliderUIParams {
        handle?: JQuery;
        value?: number;
        values?: number[];
    }
    interface SliderEvent {
        (event: Event, ui: SliderUIParams): void;
    }
    interface SliderEvents {
        change?: SliderEvent;
        create?: SliderEvent;
        slide?: SliderEvent;
        start?: SliderEvent;
        stop?: SliderEvent;
    }
    interface Slider extends Widget, SliderOptions {
    }
    interface SortableOptions extends SortableEvents {
        appendTo?: any;
        axis?: string;
        cancel?: any;
        connectWith?: any;
        containment?: any;
        cursor?: string;
        cursorAt?: any;
        delay?: number;
        disabled?: boolean;
        distance?: number;
        dropOnEmpty?: boolean;
        forceHelperSize?: boolean;
        forcePlaceholderSize?: boolean;
        grid?: number[];
        helper?: string | ((event: Event, element: Sortable) => Element);
        handle?: any;
        items?: any;
        opacity?: number;
        placeholder?: string;
        revert?: any;
        scroll?: boolean;
        scrollSensitivity?: number;
        scrollSpeed?: number;
        tolerance?: string;
        zIndex?: number;
    }
    interface SortableUIParams {
        helper: JQuery;
        item: JQuery;
        offset: any;
        position: any;
        originalPosition: any;
        sender: JQuery;
        placeholder: JQuery;
    }
    interface SortableEvent {
        (event: JQueryEventObject, ui: SortableUIParams): void;
    }
    interface SortableEvents {
        activate?: SortableEvent;
        beforeStop?: SortableEvent;
        change?: SortableEvent;
        deactivate?: SortableEvent;
        out?: SortableEvent;
        over?: SortableEvent;
        receive?: SortableEvent;
        remove?: SortableEvent;
        sort?: SortableEvent;
        start?: SortableEvent;
        stop?: SortableEvent;
        update?: SortableEvent;
    }
    interface Sortable extends Widget, SortableOptions, SortableEvents {
    }
    interface SpinnerOptions extends SpinnerEvents {
        culture?: string;
        disabled?: boolean;
        icons?: any;
        incremental?: any;
        max?: any;
        min?: any;
        numberFormat?: string;
        page?: number;
        step?: any;
    }
    interface SpinnerUIParam {
        value: number;
    }
    interface SpinnerEvent<T> {
        (event: Event, ui: T): void;
    }
    interface SpinnerEvents {
        change?: SpinnerEvent<{}>;
        create?: SpinnerEvent<{}>;
        spin?: SpinnerEvent<SpinnerUIParam>;
        start?: SpinnerEvent<{}>;
        stop?: SpinnerEvent<{}>;
    }
    interface Spinner extends Widget, SpinnerOptions {
    }
    interface TabsOptions extends TabsEvents {
        active?: any;
        collapsible?: boolean;
        disabled?: any;
        event?: string;
        heightStyle?: string;
        hide?: any;
        show?: any;
    }
    interface TabsActivationUIParams {
        newTab: JQuery;
        oldTab: JQuery;
        newPanel: JQuery;
        oldPanel: JQuery;
    }
    interface TabsBeforeLoadUIParams {
        tab: JQuery;
        panel: JQuery;
        jqXHR: JQueryXHR;
        ajaxSettings: any;
    }
    interface TabsCreateOrLoadUIParams {
        tab: JQuery;
        panel: JQuery;
    }
    interface TabsEvent<UI> {
        (event: Event, ui: UI): void;
    }
    interface TabsEvents {
        activate?: TabsEvent<TabsActivationUIParams>;
        beforeActivate?: TabsEvent<TabsActivationUIParams>;
        beforeLoad?: TabsEvent<TabsBeforeLoadUIParams>;
        load?: TabsEvent<TabsCreateOrLoadUIParams>;
        create?: TabsEvent<TabsCreateOrLoadUIParams>;
    }
    interface Tabs extends Widget, TabsOptions {
    }
    interface TooltipOptions extends TooltipEvents {
        content?: any;
        disabled?: boolean;
        hide?: any;
        items?: string;
        position?: any;
        show?: any;
        tooltipClass?: string;
        track?: boolean;
    }
    interface TooltipUIParams {
    }
    interface TooltipEvent {
        (event: Event, ui: TooltipUIParams): void;
    }
    interface TooltipEvents {
        close?: TooltipEvent;
        open?: TooltipEvent;
    }
    interface Tooltip extends Widget, TooltipOptions {
    }
    interface EffectOptions {
        effect: string;
        easing?: string;
        duration?: number;
        complete: Function;
    }
    interface BlindEffect {
        direction?: string;
    }
    interface BounceEffect {
        distance?: number;
        times?: number;
    }
    interface ClipEffect {
        direction?: number;
    }
    interface DropEffect {
        direction?: number;
    }
    interface ExplodeEffect {
        pieces?: number;
    }
    interface FadeEffect {
    }
    interface FoldEffect {
        size?: any;
        horizFirst?: boolean;
    }
    interface HighlightEffect {
        color?: string;
    }
    interface PuffEffect {
        percent?: number;
    }
    interface PulsateEffect {
        times?: number;
    }
    interface ScaleEffect {
        direction?: string;
        origin?: string[];
        percent?: number;
        scale?: string;
    }
    interface ShakeEffect {
        direction?: string;
        distance?: number;
        times?: number;
    }
    interface SizeEffect {
        to?: any;
        origin?: string[];
        scale?: string;
    }
    interface SlideEffect {
        direction?: string;
        distance?: number;
    }
    interface TransferEffect {
        className?: string;
        to?: string;
    }
    interface JQueryPositionOptions {
        my?: string;
        at?: string;
        of?: any;
        collision?: string;
        using?: Function;
        within?: any;
    }
    interface MouseOptions {
        cancel?: string;
        delay?: number;
        distance?: number;
    }
    interface KeyCode {
        BACKSPACE: number;
        COMMA: number;
        DELETE: number;
        DOWN: number;
        END: number;
        ENTER: number;
        ESCAPE: number;
        HOME: number;
        LEFT: number;
        NUMPAD_ADD: number;
        NUMPAD_DECIMAL: number;
        NUMPAD_DIVIDE: number;
        NUMPAD_ENTER: number;
        NUMPAD_MULTIPLY: number;
        NUMPAD_SUBTRACT: number;
        PAGE_DOWN: number;
        PAGE_UP: number;
        PERIOD: number;
        RIGHT: number;
        SPACE: number;
        TAB: number;
        UP: number;
    }
    interface UI {
        mouse(method: string): JQuery;
        mouse(options: MouseOptions): JQuery;
        mouse(optionLiteral: string, optionName: string, optionValue: any): JQuery;
        mouse(optionLiteral: string, optionValue: any): any;
        accordion: Accordion;
        autocomplete: Autocomplete;
        button: Button;
        buttonset: Button;
        datepicker: Datepicker;
        dialog: Dialog;
        keyCode: KeyCode;
        menu: Menu;
        progressbar: Progressbar;
        slider: Slider;
        spinner: Spinner;
        tabs: Tabs;
        tooltip: Tooltip;
        version: string;
    }
    interface WidgetOptions {
        disabled?: boolean;
        hide?: any;
        show?: any;
    }
    interface Widget {
        (methodName: string): JQuery;
        (options: WidgetOptions): JQuery;
        (options: AccordionOptions): JQuery;
        (optionLiteral: string, optionName: string): any;
        (optionLiteral: string, options: WidgetOptions): any;
        (optionLiteral: string, optionName: string, optionValue: any): JQuery;
        (name: string, prototype: any): JQuery;
        (name: string, base: Function, prototype: any): JQuery;
    }
}
interface JQuery {
    accordion(): JQuery;
    accordion(methodName: 'destroy'): void;
    accordion(methodName: 'disable'): void;
    accordion(methodName: 'enable'): void;
    accordion(methodName: 'refresh'): void;
    accordion(methodName: 'widget'): JQuery;
    accordion(methodName: string): JQuery;
    accordion(options: JQueryUI.AccordionOptions): JQuery;
    accordion(optionLiteral: string, optionName: string): any;
    accordion(optionLiteral: string, options: JQueryUI.AccordionOptions): any;
    accordion(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    autocomplete(): JQuery;
    autocomplete(methodName: 'close'): void;
    autocomplete(methodName: 'destroy'): void;
    autocomplete(methodName: 'disable'): void;
    autocomplete(methodName: 'enable'): void;
    autocomplete(methodName: 'search', value?: string): void;
    autocomplete(methodName: 'widget'): JQuery;
    autocomplete(methodName: string): JQuery;
    autocomplete(options: JQueryUI.AutocompleteOptions): JQuery;
    autocomplete(optionLiteral: string, optionName: string): any;
    autocomplete(optionLiteral: string, options: JQueryUI.AutocompleteOptions): any;
    autocomplete(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    button(): JQuery;
    button(methodName: 'destroy'): void;
    button(methodName: 'disable'): void;
    button(methodName: 'enable'): void;
    button(methodName: 'refresh'): void;
    button(methodName: 'widget'): JQuery;
    button(methodName: string): JQuery;
    button(options: JQueryUI.ButtonOptions): JQuery;
    button(optionLiteral: string, optionName: string): any;
    button(optionLiteral: string, options: JQueryUI.ButtonOptions): any;
    button(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    buttonset(): JQuery;
    buttonset(methodName: 'destroy'): void;
    buttonset(methodName: 'disable'): void;
    buttonset(methodName: 'enable'): void;
    buttonset(methodName: 'refresh'): void;
    buttonset(methodName: 'widget'): JQuery;
    buttonset(methodName: string): JQuery;
    buttonset(options: JQueryUI.ButtonOptions): JQuery;
    buttonset(optionLiteral: string, optionName: string): any;
    buttonset(optionLiteral: string, options: JQueryUI.ButtonOptions): any;
    buttonset(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    /**
     * Initialize a datepicker
     */
    datepicker(): JQuery;
    /**
     * Removes the datepicker functionality completely. This will return the element back to its pre-init state.
     *
     * @param methodName 'destroy'
     */
    datepicker(methodName: 'destroy'): JQuery;
    /**
     * Opens the datepicker in a dialog box.
     *
     * @param methodName 'dialog'
     * @param date The initial date.
     * @param onSelect A callback function when a date is selected. The function receives the date text and date picker instance as parameters.
     * @param settings The new settings for the date picker.
     * @param pos The position of the top/left of the dialog as [x, y] or a MouseEvent that contains the coordinates. If not specified the dialog is centered on the screen.
     */
    datepicker(methodName: 'dialog', date: Date, onSelect?: () => void, settings?: JQueryUI.DatepickerOptions, pos?: number[]): JQuery;
    /**
     * Opens the datepicker in a dialog box.
     *
     * @param methodName 'dialog'
     * @param date The initial date.
     * @param onSelect A callback function when a date is selected. The function receives the date text and date picker instance as parameters.
     * @param settings The new settings for the date picker.
     * @param pos The position of the top/left of the dialog as [x, y] or a MouseEvent that contains the coordinates. If not specified the dialog is centered on the screen.
     */
    datepicker(methodName: 'dialog', date: Date, onSelect?: () => void, settings?: JQueryUI.DatepickerOptions, pos?: MouseEvent): JQuery;
    /**
     * Opens the datepicker in a dialog box.
     *
     * @param methodName 'dialog'
     * @param date The initial date.
     * @param onSelect A callback function when a date is selected. The function receives the date text and date picker instance as parameters.
     * @param settings The new settings for the date picker.
     * @param pos The position of the top/left of the dialog as [x, y] or a MouseEvent that contains the coordinates. If not specified the dialog is centered on the screen.
     */
    datepicker(methodName: 'dialog', date: string, onSelect?: () => void, settings?: JQueryUI.DatepickerOptions, pos?: number[]): JQuery;
    /**
     * Opens the datepicker in a dialog box.
     *
     * @param methodName 'dialog'
     * @param date The initial date.
     * @param onSelect A callback function when a date is selected. The function receives the date text and date picker instance as parameters.
     * @param settings The new settings for the date picker.
     * @param pos The position of the top/left of the dialog as [x, y] or a MouseEvent that contains the coordinates. If not specified the dialog is centered on the screen.
     */
    datepicker(methodName: 'dialog', date: string, onSelect?: () => void, settings?: JQueryUI.DatepickerOptions, pos?: MouseEvent): JQuery;
    /**
     * Returns the current date for the datepicker or null if no date has been selected.
     *
     * @param methodName 'getDate'
     */
    datepicker(methodName: 'getDate'): Date;
    /**
     * Close a previously opened date picker.
     *
     * @param methodName 'hide'
     */
    datepicker(methodName: 'hide'): JQuery;
    /**
     * Determine whether a date picker has been disabled.
     *
     * @param methodName 'isDisabled'
     */
    datepicker(methodName: 'isDisabled'): boolean;
    /**
     * Redraw the date picker, after having made some external modifications.
     *
     * @param methodName 'refresh'
     */
    datepicker(methodName: 'refresh'): JQuery;
    /**
     * Sets the date for the datepicker. The new date may be a Date object or a string in the current date format (e.g., "01/26/2009"), a number of days from today (e.g., +7) or a string of values and periods ("y" for years, "m" for months, "w" for weeks, "d" for days, e.g., "+1m +7d"), or null to clear the selected date.
     *
     * @param methodName 'setDate'
     * @param date The new date.
     */
    datepicker(methodName: 'setDate', date: Date): JQuery;
    /**
     * Sets the date for the datepicker. The new date may be a Date object or a string in the current date format (e.g., "01/26/2009"), a number of days from today (e.g., +7) or a string of values and periods ("y" for years, "m" for months, "w" for weeks, "d" for days, e.g., "+1m +7d"), or null to clear the selected date.
     *
     * @param methodName 'setDate'
     * @param date The new date.
     */
    datepicker(methodName: 'setDate', date: string): JQuery;
    /**
     * Open the date picker. If the datepicker is attached to an input, the input must be visible for the datepicker to be shown.
     *
     * @param methodName 'show'
     */
    datepicker(methodName: 'show'): JQuery;
    /**
     * Returns a jQuery object containing the datepicker.
     *
     * @param methodName 'widget'
     */
    datepicker(methodName: 'widget'): JQuery;
    /**
     * Get the altField option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altField'
     */
    datepicker(methodName: 'option', optionName: 'altField'): any;
    /**
     * Set the altField option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altField'
     * @param altFieldValue An input element that is to be updated with the selected date from the datepicker. Use the altFormat option to change the format of the date within this field. Leave as blank for no alternate field.
     */
    datepicker(methodName: 'option', optionName: 'altField', altFieldValue: string): JQuery;
    /**
     * Set the altField option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altField'
     * @param altFieldValue An input element that is to be updated with the selected date from the datepicker. Use the altFormat option to change the format of the date within this field. Leave as blank for no alternate field.
     */
    datepicker(methodName: 'option', optionName: 'altField', altFieldValue: JQuery): JQuery;
    /**
     * Set the altField option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altField'
     * @param altFieldValue An input element that is to be updated with the selected date from the datepicker. Use the altFormat option to change the format of the date within this field. Leave as blank for no alternate field.
     */
    datepicker(methodName: 'option', optionName: 'altField', altFieldValue: Element): JQuery;
    /**
     * Get the altFormat option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altFormat'
     */
    datepicker(methodName: 'option', optionName: 'altFormat'): string;
    /**
     * Set the altFormat option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'altFormat'
     * @param altFormatValue The dateFormat to be used for the altField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the formatDate function
     */
    datepicker(methodName: 'option', optionName: 'altFormat', altFormatValue: string): JQuery;
    /**
     * Get the appendText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'appendText'
     */
    datepicker(methodName: 'option', optionName: 'appendText'): string;
    /**
     * Set the appendText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'appendText'
     * @param appendTextValue The text to display after each date field, e.g., to show the required format.
     */
    datepicker(methodName: 'option', optionName: 'appendText', appendTextValue: string): JQuery;
    /**
     * Get the autoSize option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'autoSize'
     */
    datepicker(methodName: 'option', optionName: 'autoSize'): boolean;
    /**
     * Set the autoSize option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'autoSize'
     * @param autoSizeValue Set to true to automatically resize the input field to accommodate dates in the current dateFormat.
     */
    datepicker(methodName: 'option', optionName: 'autoSize', autoSizeValue: boolean): JQuery;
    /**
     * Get the beforeShow option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'beforeShow'
     */
    datepicker(methodName: 'option', optionName: 'beforeShow'): (input: Element, inst: any) => JQueryUI.DatepickerOptions;
    /**
     * Set the beforeShow option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'beforeShow'
     * @param beforeShowValue A function that takes an input field and current datepicker instance and returns an options object to update the datepicker with. It is called just before the datepicker is displayed.
     */
    datepicker(methodName: 'option', optionName: 'beforeShow', beforeShowValue: (input: Element, inst: any) => JQueryUI.DatepickerOptions): JQuery;
    /**
     * Get the beforeShow option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'beforeShowDay'
     */
    datepicker(methodName: 'option', optionName: 'beforeShowDay'): (date: Date) => any[];
    /**
     * Set the beforeShow option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'beforeShowDay'
     * @param beforeShowDayValue A function that takes a date as a parameter and must return an array with:
     * [0]: true/false indicating whether or not this date is selectable
     * [1]: a CSS class name to add to the date's cell or "" for the default presentation
     * [2]: an optional popup tooltip for this date
     * The function is called for each day in the datepicker before it is displayed.
     */
    datepicker(methodName: 'option', optionName: 'beforeShowDay', beforeShowDayValue: (date: Date) => any[]): JQuery;
    /**
     * Get the buttonImage option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonImage'
     */
    datepicker(methodName: 'option', optionName: 'buttonImage'): string;
    /**
     * Set the buttonImage option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonImage'
     * @param buttonImageValue A URL of an image to use to display the datepicker when the showOn option is set to "button" or "both". If set, the buttonText option becomes the alt value and is not directly displayed.
     */
    datepicker(methodName: 'option', optionName: 'buttonImage', buttonImageValue: string): JQuery;
    /**
     * Get the buttonImageOnly option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonImageOnly'
     */
    datepicker(methodName: 'option', optionName: 'buttonImageOnly'): boolean;
    /**
     * Set the buttonImageOnly option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonImageOnly'
     * @param buttonImageOnlyValue Whether the button image should be rendered by itself instead of inside a button element. This option is only relevant if the buttonImage option has also been set.
     */
    datepicker(methodName: 'option', optionName: 'buttonImageOnly', buttonImageOnlyValue: boolean): JQuery;
    /**
     * Get the buttonText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonText'
     */
    datepicker(methodName: 'option', optionName: 'buttonText'): string;
    /**
     * Set the buttonText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'buttonText'
     * @param buttonTextValue The text to display on the trigger button. Use in conjunction with the showOn option set to "button" or "both".
     */
    datepicker(methodName: 'option', optionName: 'buttonText', buttonTextValue: string): JQuery;
    /**
     * Get the calculateWeek option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'calculateWeek'
     */
    datepicker(methodName: 'option', optionName: 'calculateWeek'): (date: Date) => string;
    /**
     * Set the calculateWeek option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'calculateWeek'
     * @param calculateWeekValue A function to calculate the week of the year for a given date. The default implementation uses the ISO 8601 definition: weeks start on a Monday; the first week of the year contains the first Thursday of the year.
     */
    datepicker(methodName: 'option', optionName: 'calculateWeek', calculateWeekValue: (date: Date) => string): JQuery;
    /**
     * Get the changeMonth option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'changeMonth'
     */
    datepicker(methodName: 'option', optionName: 'changeMonth'): boolean;
    /**
     * Set the changeMonth option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'changeMonth'
     * @param changeMonthValue Whether the month should be rendered as a dropdown instead of text.
     */
    datepicker(methodName: 'option', optionName: 'changeMonth', changeMonthValue: boolean): JQuery;
    /**
     * Get the changeYear option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'changeYear'
     */
    datepicker(methodName: 'option', optionName: 'changeYear'): boolean;
    /**
     * Set the changeYear option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'changeYear'
     * @param changeYearValue Whether the year should be rendered as a dropdown instead of text. Use the yearRange option to control which years are made available for selection.
     */
    datepicker(methodName: 'option', optionName: 'changeYear', changeYearValue: boolean): JQuery;
    /**
     * Get the closeText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'closeText'
     */
    datepicker(methodName: 'option', optionName: 'closeText'): string;
    /**
     * Set the closeText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'closeText'
     * @param closeTextValue The text to display for the close link. Use the showButtonPanel option to display this button.
     */
    datepicker(methodName: 'option', optionName: 'closeText', closeTextValue: string): JQuery;
    /**
     * Get the constrainInput option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'constrainInput'
     */
    datepicker(methodName: 'option', optionName: 'constrainInput'): boolean;
    /**
     * Set the constrainInput option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'constrainInput'
     * @param constrainInputValue When true, entry in the input field is constrained to those characters allowed by the current dateFormat option.
     */
    datepicker(methodName: 'option', optionName: 'constrainInput', constrainInputValue: boolean): JQuery;
    /**
     * Get the currentText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'currentText'
     */
    datepicker(methodName: 'option', optionName: 'currentText'): string;
    /**
     * Set the currentText option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'currentText'
     * @param currentTextValue The text to display for the current day link. Use the showButtonPanel option to display this button.
     */
    datepicker(methodName: 'option', optionName: 'currentText', currentTextValue: string): JQuery;
    /**
     * Get the dateFormat option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dateFormat'
     */
    datepicker(methodName: 'option', optionName: 'dateFormat'): string;
    /**
     * Set the dateFormat option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dateFormat'
     * @param dateFormatValue The format for parsed and displayed dates. For a full list of the possible formats see the formatDate function.
     */
    datepicker(methodName: 'option', optionName: 'dateFormat', dateFormatValue: string): JQuery;
    /**
     * Get the dayNames option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNames'
     */
    datepicker(methodName: 'option', optionName: 'dayNames'): string[];
    /**
     * Set the dayNames option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNames'
     * @param dayNamesValue The list of long day names, starting from Sunday, for use as requested via the dateFormat option.
     */
    datepicker(methodName: 'option', optionName: 'dayNames', dayNamesValue: string[]): JQuery;
    /**
     * Get the dayNamesMin option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNamesMin'
     */
    datepicker(methodName: 'option', optionName: 'dayNamesMin'): string[];
    /**
     * Set the dayNamesMin option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNamesMin'
     * @param dayNamesMinValue The list of minimised day names, starting from Sunday, for use as column headers within the datepicker.
     */
    datepicker(methodName: 'option', optionName: 'dayNamesMin', dayNamesMinValue: string[]): JQuery;
    /**
     * Get the dayNamesShort option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNamesShort'
     */
    datepicker(methodName: 'option', optionName: 'dayNamesShort'): string[];
    /**
     * Set the dayNamesShort option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'dayNamesShort'
     * @param dayNamesShortValue The list of abbreviated day names, starting from Sunday, for use as requested via the dateFormat option.
     */
    datepicker(methodName: 'option', optionName: 'dayNamesShort', dayNamesShortValue: string[]): JQuery;
    /**
     * Get the defaultDate option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'defaultDate'
     */
    datepicker(methodName: 'option', optionName: 'defaultDate'): any;
    /**
     * Set the defaultDate option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'defaultDate'
     * @param defaultDateValue A date object containing the default date.
     */
    datepicker(methodName: 'option', optionName: 'defaultDate', defaultDateValue: Date): JQuery;
    /**
     * Set the defaultDate option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'defaultDate'
     * @param defaultDateValue A number of days from today. For example 2 represents two days from today and -1 represents yesterday.
     */
    datepicker(methodName: 'option', optionName: 'defaultDate', defaultDateValue: number): JQuery;
    /**
     * Set the defaultDate option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'defaultDate'
     * @param defaultDateValue A string in the format defined by the dateFormat option, or a relative date. Relative dates must contain value and period pairs; valid periods are "y" for years, "m" for months, "w" for weeks, and "d" for days. For example, "+1m +7d" represents one month and seven days from today.
     */
    datepicker(methodName: 'option', optionName: 'defaultDate', defaultDateValue: string): JQuery;
    /**
     * Get the duration option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'duration'
     */
    datepicker(methodName: 'option', optionName: 'duration'): string;
    /**
     * Set the duration option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'duration'
     * @param durationValue Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds ("slow", "normal", "fast").
     */
    datepicker(methodName: 'option', optionName: 'duration', durationValue: string): JQuery;
    /**
     * Get the firstDay option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'firstDay'
     */
    datepicker(methodName: 'option', optionName: 'firstDay'): number;
    /**
     * Set the firstDay option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'firstDay'
     * @param firstDayValue Set the first day of the week: Sunday is 0, Monday is 1, etc.
     */
    datepicker(methodName: 'option', optionName: 'firstDay', firstDayValue: number): JQuery;
    /**
     * Get the gotoCurrent option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'gotoCurrent'
     */
    datepicker(methodName: 'option', optionName: 'gotoCurrent'): boolean;
    /**
     * Set the gotoCurrent option, after initialization
     *
     * @param methodName 'option'
     * @param optionName 'gotoCurrent'
     * @param gotoCurrentValue When true, the current day link moves to the currently selected date instead of today.
     */
    datepicker(methodName: 'option', optionName: 'gotoCurrent', gotoCurrentValue: boolean): JQuery;
    /**
     * Gets the value currently associated with the specified optionName.
     *
     * @param methodName 'option'
     * @param optionName The name of the option to get.
     */
    datepicker(methodName: 'option', optionName: string): any;
    datepicker(methodName: 'option', optionName: string, ...otherParams: any[]): any;
    datepicker(methodName: string, ...otherParams: any[]): any;
    /**
     * Initialize a datepicker with the given options
     */
    datepicker(options: JQueryUI.DatepickerOptions): JQuery;
    dialog(): JQuery;
    dialog(methodName: 'close'): JQuery;
    dialog(methodName: 'destroy'): JQuery;
    dialog(methodName: 'isOpen'): boolean;
    dialog(methodName: 'moveToTop'): JQuery;
    dialog(methodName: 'open'): JQuery;
    dialog(methodName: 'widget'): JQuery;
    dialog(methodName: string): JQuery;
    dialog(options: JQueryUI.DialogOptions): JQuery;
    dialog(optionLiteral: string, optionName: string): any;
    dialog(optionLiteral: string, options: JQueryUI.DialogOptions): any;
    dialog(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    draggable(): JQuery;
    draggable(methodName: 'destroy'): void;
    draggable(methodName: 'disable'): void;
    draggable(methodName: 'enable'): void;
    draggable(methodName: 'widget'): JQuery;
    draggable(methodName: string): JQuery;
    draggable(options: JQueryUI.DraggableOptions): JQuery;
    draggable(optionLiteral: string, optionName: string): any;
    draggable(optionLiteral: string, options: JQueryUI.DraggableOptions): any;
    draggable(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    droppable(): JQuery;
    droppable(methodName: 'destroy'): void;
    droppable(methodName: 'disable'): void;
    droppable(methodName: 'enable'): void;
    droppable(methodName: 'widget'): JQuery;
    droppable(methodName: string): JQuery;
    droppable(options: JQueryUI.DroppableOptions): JQuery;
    droppable(optionLiteral: string, optionName: string): any;
    droppable(optionLiteral: string, options: JQueryUI.DraggableOptions): any;
    droppable(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    menu: {
        (): JQuery;
        (methodName: 'blur'): void;
        (methodName: 'collapse', event?: JQueryEventObject): void;
        (methodName: 'collapseAll', event?: JQueryEventObject, all?: boolean): void;
        (methodName: 'destroy'): void;
        (methodName: 'disable'): void;
        (methodName: 'enable'): void;
        (methodName: string, event: JQueryEventObject, item: JQuery): void;
        (methodName: 'focus', event: JQueryEventObject, item: JQuery): void;
        (methodName: 'isFirstItem'): boolean;
        (methodName: 'isLastItem'): boolean;
        (methodName: 'next', event?: JQueryEventObject): void;
        (methodName: 'nextPage', event?: JQueryEventObject): void;
        (methodName: 'previous', event?: JQueryEventObject): void;
        (methodName: 'previousPage', event?: JQueryEventObject): void;
        (methodName: 'refresh'): void;
        (methodName: 'select', event?: JQueryEventObject): void;
        (methodName: 'widget'): JQuery;
        (methodName: string): JQuery;
        (options: JQueryUI.MenuOptions): JQuery;
        (optionLiteral: string, optionName: string): any;
        (optionLiteral: string, options: JQueryUI.MenuOptions): any;
        (optionLiteral: string, optionName: string, optionValue: any): JQuery;
        active: boolean;
    };
    progressbar(): JQuery;
    progressbar(methodName: 'destroy'): void;
    progressbar(methodName: 'disable'): void;
    progressbar(methodName: 'enable'): void;
    progressbar(methodName: 'refresh'): void;
    progressbar(methodName: 'value'): any;
    progressbar(methodName: 'value', value: number): void;
    progressbar(methodName: 'value', value: boolean): void;
    progressbar(methodName: 'widget'): JQuery;
    progressbar(methodName: string): JQuery;
    progressbar(options: JQueryUI.ProgressbarOptions): JQuery;
    progressbar(optionLiteral: string, optionName: string): any;
    progressbar(optionLiteral: string, options: JQueryUI.ProgressbarOptions): any;
    progressbar(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    resizable(): JQuery;
    resizable(methodName: 'destroy'): void;
    resizable(methodName: 'disable'): void;
    resizable(methodName: 'enable'): void;
    resizable(methodName: 'widget'): JQuery;
    resizable(methodName: string): JQuery;
    resizable(options: JQueryUI.ResizableOptions): JQuery;
    resizable(optionLiteral: string, optionName: string): any;
    resizable(optionLiteral: string, options: JQueryUI.ResizableOptions): any;
    resizable(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    selectable(): JQuery;
    selectable(methodName: 'destroy'): void;
    selectable(methodName: 'disable'): void;
    selectable(methodName: 'enable'): void;
    selectable(methodName: 'widget'): JQuery;
    selectable(methodName: string): JQuery;
    selectable(options: JQueryUI.SelectableOptions): JQuery;
    selectable(optionLiteral: string, optionName: string): any;
    selectable(optionLiteral: string, options: JQueryUI.SelectableOptions): any;
    selectable(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    selectmenu(): JQuery;
    selectmenu(methodName: 'close'): JQuery;
    selectmenu(methodName: 'destroy'): JQuery;
    selectmenu(methodName: 'disable'): JQuery;
    selectmenu(methodName: 'enable'): JQuery;
    selectmenu(methodName: 'instance'): any;
    selectmenu(methodName: 'menuWidget'): JQuery;
    selectmenu(methodName: 'open'): JQuery;
    selectmenu(methodName: 'refresh'): JQuery;
    selectmenu(methodName: 'widget'): JQuery;
    selectmenu(methodName: string): JQuery;
    selectmenu(options: JQueryUI.SelectMenuOptions): JQuery;
    selectmenu(optionLiteral: string, optionName: string): any;
    selectmenu(optionLiteral: string, options: JQueryUI.SelectMenuOptions): any;
    selectmenu(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    slider(): JQuery;
    slider(methodName: 'destroy'): void;
    slider(methodName: 'disable'): void;
    slider(methodName: 'enable'): void;
    slider(methodName: 'refresh'): void;
    slider(methodName: 'value'): number;
    slider(methodName: 'value', value: number): void;
    slider(methodName: 'values'): Array<number>;
    slider(methodName: 'values', index: number): number;
    slider(methodName: string, index: number, value: number): void;
    slider(methodName: 'values', index: number, value: number): void;
    slider(methodName: string, values: Array<number>): void;
    slider(methodName: 'values', values: Array<number>): void;
    slider(methodName: 'widget'): JQuery;
    slider(methodName: string): JQuery;
    slider(options: JQueryUI.SliderOptions): JQuery;
    slider(optionLiteral: string, optionName: string): any;
    slider(optionLiteral: string, options: JQueryUI.SliderOptions): any;
    slider(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    sortable(): JQuery;
    sortable(methodName: 'destroy'): void;
    sortable(methodName: 'disable'): void;
    sortable(methodName: 'enable'): void;
    sortable(methodName: 'widget'): JQuery;
    sortable(methodName: 'toArray'): string[];
    sortable(methodName: string): JQuery;
    sortable(options: JQueryUI.SortableOptions): JQuery;
    sortable(optionLiteral: string, optionName: string): any;
    sortable(methodName: 'serialize', options?: {
        key?: string;
        attribute?: string;
        expression?: RegExp;
    }): string;
    sortable(optionLiteral: string, options: JQueryUI.SortableOptions): any;
    sortable(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    spinner(): JQuery;
    spinner(methodName: 'destroy'): void;
    spinner(methodName: 'disable'): void;
    spinner(methodName: 'enable'): void;
    spinner(methodName: 'pageDown', pages?: number): void;
    spinner(methodName: 'pageUp', pages?: number): void;
    spinner(methodName: 'stepDown', steps?: number): void;
    spinner(methodName: 'stepUp', steps?: number): void;
    spinner(methodName: 'value'): number;
    spinner(methodName: 'value', value: number): void;
    spinner(methodName: 'widget'): JQuery;
    spinner(methodName: string): JQuery;
    spinner(options: JQueryUI.SpinnerOptions): JQuery;
    spinner(optionLiteral: string, optionName: string): any;
    spinner(optionLiteral: string, options: JQueryUI.SpinnerOptions): any;
    spinner(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    tabs(): JQuery;
    tabs(methodName: 'destroy'): void;
    tabs(methodName: 'disable'): void;
    tabs(methodName: 'enable'): void;
    tabs(methodName: 'load', index: number): void;
    tabs(methodName: 'refresh'): void;
    tabs(methodName: 'widget'): JQuery;
    tabs(methodName: string): JQuery;
    tabs(options: JQueryUI.TabsOptions): JQuery;
    tabs(optionLiteral: string, optionName: string): any;
    tabs(optionLiteral: string, options: JQueryUI.TabsOptions): any;
    tabs(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    tooltip(): JQuery;
    tooltip(methodName: 'destroy'): void;
    tooltip(methodName: 'disable'): void;
    tooltip(methodName: 'enable'): void;
    tooltip(methodName: 'open'): void;
    tooltip(methodName: 'close'): void;
    tooltip(methodName: 'widget'): JQuery;
    tooltip(methodName: string): JQuery;
    tooltip(options: JQueryUI.TooltipOptions): JQuery;
    tooltip(optionLiteral: string, optionName: string): any;
    tooltip(optionLiteral: string, options: JQueryUI.TooltipOptions): any;
    tooltip(optionLiteral: string, optionName: string, optionValue: any): JQuery;
    addClass(classNames: string, speed?: number, callback?: Function): JQuery;
    addClass(classNames: string, speed?: string, callback?: Function): JQuery;
    addClass(classNames: string, speed?: number, easing?: string, callback?: Function): JQuery;
    addClass(classNames: string, speed?: string, easing?: string, callback?: Function): JQuery;
    removeClass(classNames: string, speed?: number, callback?: Function): JQuery;
    removeClass(classNames: string, speed?: string, callback?: Function): JQuery;
    removeClass(classNames: string, speed?: number, easing?: string, callback?: Function): JQuery;
    removeClass(classNames: string, speed?: string, easing?: string, callback?: Function): JQuery;
    switchClass(removeClassName: string, addClassName: string, duration?: number, easing?: string, complete?: Function): JQuery;
    switchClass(removeClassName: string, addClassName: string, duration?: string, easing?: string, complete?: Function): JQuery;
    toggleClass(className: string, duration?: number, easing?: string, complete?: Function): JQuery;
    toggleClass(className: string, duration?: string, easing?: string, complete?: Function): JQuery;
    toggleClass(className: string, aswitch?: boolean, duration?: number, easing?: string, complete?: Function): JQuery;
    toggleClass(className: string, aswitch?: boolean, duration?: string, easing?: string, complete?: Function): JQuery;
    effect(options: any): JQuery;
    effect(effect: string, options?: any, duration?: number, complete?: Function): JQuery;
    effect(effect: string, options?: any, duration?: string, complete?: Function): JQuery;
    hide(options: any): JQuery;
    hide(effect: string, options?: any, duration?: number, complete?: Function): JQuery;
    hide(effect: string, options?: any, duration?: string, complete?: Function): JQuery;
    show(options: any): JQuery;
    show(effect: string, options?: any, duration?: number, complete?: Function): JQuery;
    show(effect: string, options?: any, duration?: string, complete?: Function): JQuery;
    toggle(options: any): JQuery;
    toggle(effect: string, options?: any, duration?: number, complete?: Function): JQuery;
    toggle(effect: string, options?: any, duration?: string, complete?: Function): JQuery;
    position(options: JQueryUI.JQueryPositionOptions): JQuery;
    enableSelection(): JQuery;
    disableSelection(): JQuery;
    focus(delay: number, callback?: Function): JQuery;
    uniqueId(): JQuery;
    removeUniqueId(): JQuery;
    scrollParent(): JQuery;
    zIndex(): number;
    zIndex(zIndex: number): JQuery;
    widget: JQueryUI.Widget;
    jQuery: JQueryStatic;
}
interface JQueryStatic {
    ui: JQueryUI.UI;
    datepicker: JQueryUI.Datepicker;
    widget: JQueryUI.Widget;
    Widget: JQueryUI.Widget;
}
interface JQueryEasingFunctions {
    easeInQuad: JQueryEasingFunctions;
    easeOutQuad: JQueryEasingFunctions;
    easeInOutQuad: JQueryEasingFunctions;
    easeInCubic: JQueryEasingFunctions;
    easeOutCubic: JQueryEasingFunctions;
    easeInOutCubic: JQueryEasingFunctions;
    easeInQuart: JQueryEasingFunctions;
    easeOutQuart: JQueryEasingFunctions;
    easeInOutQuart: JQueryEasingFunctions;
    easeInQuint: JQueryEasingFunctions;
    easeOutQuint: JQueryEasingFunctions;
    easeInOutQuint: JQueryEasingFunctions;
    easeInExpo: JQueryEasingFunctions;
    easeOutExpo: JQueryEasingFunctions;
    easeInOutExpo: JQueryEasingFunctions;
    easeInSine: JQueryEasingFunctions;
    easeOutSine: JQueryEasingFunctions;
    easeInOutSine: JQueryEasingFunctions;
    easeInCirc: JQueryEasingFunctions;
    easeOutCirc: JQueryEasingFunctions;
    easeInOutCirc: JQueryEasingFunctions;
    easeInElastic: JQueryEasingFunctions;
    easeOutElastic: JQueryEasingFunctions;
    easeInOutElastic: JQueryEasingFunctions;
    easeInBack: JQueryEasingFunctions;
    easeOutBack: JQueryEasingFunctions;
    easeInOutBack: JQueryEasingFunctions;
    easeInBounce: JQueryEasingFunctions;
    easeOutBounce: JQueryEasingFunctions;
    easeInOutBounce: JQueryEasingFunctions;
}
declare module WebMap.Client {
    class MobilizeObservableObject extends kendo.data.ObservableObject {
        init(value: any): void;
        merge(value: any): void;
        setModelValue(field: string, object: kendo.Observable): void;
    }
    function eventHandler(context: any, type: any, field: any, prefix: any): (e: any) => void;
    function cloneEvent(e: any): {};
}
declare module WebMap.Client.Enums {
    enum DockStyle {
        None = 0,
        Top = 1,
        Bottom = 2,
        Left = 3,
        Right = 4,
        Fill = 5,
    }
}
declare module WebMap.Client {
    interface TryGetValueResult<T> {
        HasValue: boolean;
        Value: T;
    }
    interface IStorageSerializer {
        Serialize(obj: any): any;
    }
    interface IPromise {
    }
    interface AppActionOptions {
        controller?: string;
        action?: string;
        mainobj?: (IStateObject | any);
        parameters?: {
            [paremeterName: string]: any;
        };
        useblockui?: boolean;
        dialogResult?: string;
        uniqueID?: string;
    }
    interface Message {
        UniqueID: string;
        text: string;
        buttons?: number;
        icons?: number;
        promptMesage?: string;
        Continuation_UniqueID?: string;
        caption?: string;
    }
    interface InputBox {
        UniqueID: string;
        prompt: string;
        title: string;
        defaultResponse: string;
    }
    interface IIocContainer {
        Resolve(options?: any): any;
    }
    interface IStateObject {
        UniqueID: string;
    }
    interface IViewModel extends IStateObject {
        Name: string;
    }
    interface ILogicView {
        ViewModel: IViewModel;
        Init(isModal: boolean): void;
        Close(): void;
    }
    interface IViewManager {
        /**
          * Closes a view in the client side.  This method handles form closing when the user clicks
          * the close box control and no binding to server side events has been added.
          */
        CloseView(view: IViewModel): any;
        /**
          * Fills up the WebMapRequest object with the delta information provided by the
          * ViewManager
          */
        PrepareDelta(requestInfo: WebMapRequest): any;
        RemoveViews(data: any): void;
        UpdateView(view: IViewModel, viewInfo: any): void;
        NavigateToView(viewModel: IViewModel, isModal: boolean): JQueryPromise<BaseLogic>;
        ShowMessage(message: string, caption: string, buttons: any, boxIcons: any): IPromise;
        getConstructor(vm: IViewModel): () => ILogicView;
        GetView(UniqueID: string): BaseLogic;
    }
}
declare module WebMap.Client {
    enum typeDialogCmd {
        cmdOpen = 1,
        cmdSave = 2,
    }
    class FileDialogCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        static saveDialog(nid: string, args: string[]): void;
        static openDialog(nid: string, args: string[]): void;
        private static generateDialog(cmd);
        static InitMessageBoxHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    /**
     * Client Type Behaviours are provide to provide
     * json processing on the client side.
     * For example:
     * A Json object can have a compressed format for bandwidth saving.
     * So for sending an object like formatting data it could be sent as {p:"0x00101010101" }
     * and the preOrganizeActin can turn that json into something easier to handle on the client side like:
     * { BackColor: red, Font: "Courier", ForeColor: blue}
     *
     * It other scenenarios a custom processing is needed, so the object must be taken out of the normal
     * state syncronization processing.
     * In those cases the original Json object can be stored in a temporal collection and return undefined, so it is not processing by the standard state processing cycle
     * Also an action can be registered to be triggered at the end of the standard state processing
     */
    interface IClientTypeBehaviour {
        cons: (jsonData: any) => any;
        preOrganizeAction: (jsonData: any) => any;
    }
}
declare module WebMap.Client {
    /**
     * Holds the catalog of client side behaviours
     * And interacts with the state manager
     */
    class ClientTypeBehaviourManager {
        static Current: ClientTypeBehaviourManager;
        private static handlers;
        private postOrganizeActions;
        private postShowViewsActions;
        /**
         * Registers a Client Type Behaviour.
         * By default:
         * 1 --> ArraysClientTypeBehaviour
         * 2 --> StateObjectPointerClientTypeBehaviour
         */
        registerHandler(id: number, handler: IClientTypeBehaviour): void;
        /**
         * Returns the associated Client Type Behaviour
         */
        getBehaviour(obj: any): IClientTypeBehaviour;
        getBehaviourByID(typeMark: any): IClientTypeBehaviour;
        /**
         * Registers a function that will be trigger when the standard state organization actions are finished
         */
        registerPostOrganizeAction(action: () => void): void;
        /**
         * Registers a function that will be trigger when the standard state organization actions are finished
         */
        registerPostShowViewsAction(action: () => void): void;
        /**
         * Execute any post-organized actions registered by any of the client side behaviours
         */
        execPostOrganizeActions(): void;
        /**
         * Execute any post-organized actions registered by any of the client side behaviours
         */
        execPostShowViewsActions(): void;
        static Init(): any;
        static staticinit: any;
    }
    class ArraysClientTypeBehaviour implements IClientTypeBehaviour {
        static Init(): any;
        private itemsCollections;
        cons(jsonData: any): any;
        private postActionRegistered;
        preOrganizeAction(jsonData: any): any;
        static staticinit: any;
    }
    class StateObjectPointerClientTypeBehaviour implements IClientTypeBehaviour {
        static Init(): any;
        private pointers;
        cons(jsonData: any): any;
        private postActionRegistered;
        private registerActionPostOrganize();
        preOrganizeAction(jsonData: any): any;
        static staticinit: any;
    }
    class DynamicEventClientTypeBehaviour implements IClientTypeBehaviour {
        static Init(): any;
        private events;
        private pendingEvents;
        cons(jsonData: any): any;
        bindEventsForPendingItems(isContextMenuStrip?: boolean, alwaysBind?: boolean): void;
        private postActionRegistered;
        private registerPostShowViewsAction();
        preOrganizeAction(jsonData: any): void;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    interface ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
    }
    interface ICommand {
        id: string;
        parameters: any;
    }
    class CommandHandlerManager {
        static Current: CommandHandlerManager;
        private static handlers;
        registerHandler(id: string, handler: ICommandHandler): void;
        dispatchAll(commands: ICommand[]): void;
        static InitCommandHandlerManager(): any;
        static staticinit: any;
    }
}
declare function normalizeUniqueID(value: string): string;
declare function UserControl_CalcAncestorPath(value: any): void;
declare module WebMap.Client {
    class BaseUserControl {
        options: {
            name: string;
            value: any;
            css: string;
            template: string;
            uiinitialized: boolean;
        };
        _value: any;
        element: any;
        inDestroy: boolean;
        delayedBuild: boolean;
        ignoreDelay: boolean;
        UIInitialized: (initialized: boolean) => void;
        ApplyValueChanges: (changeEvent: any) => void;
        applyTemplate(value: any): any;
        initStyles(): void;
        initClientMethods(value: any): void;
        init(element: any, options: any): void;
        destroy(): void;
        widgetDestroy(): void;
        refresh(): void;
        KeyBoardEvents(value: any): void;
        buildUI(): void;
        value(val: any): any;
        normalizeKey(key: any): any;
        normalizeKeys(value: any): void;
        _update(value: any): void;
        safeRefresh(): void;
    }
}
declare module WebMap.Client {
    interface IDynamicEventData {
        UniqueID: string;
        EventId: string;
    }
    class DynamicEventData {
        uniqueID: string;
        eventId: string;
        UniqueID: string;
        EventId: string;
        constructor(uniqueID: string, eventId: string);
    }
}
declare module WebMap.Client {
    class InputBoxCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        private static showInputMessageDialog(cmd);
        private static getTemplate(inputBox);
        static InitInputBoxHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    class InvokeActionCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        private static SpellCheckV11(cmd);
        private static SetDocumentForNote(cmd);
        private static ChangeContextNavigator(cmd);
        private static PatientChange(cmd);
        private static EncounterChange(cmd);
        private static MacrosChange(cmd);
        private static showHtmlDialog(cmd, screen);
        static InitInvokeActionHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Utils {
    class KendoWidgetMappings {
        private static _typeMappings;
        static getMappedEvent(widget: kendo.ui.Widget, eventID: string): string;
        static getMappedEventForMenuItem(widget: JQuery, eventID: string): string;
    }
}
declare module WebMap.Client {
    class Responsiveness {
        static ProcessObjectForResponsiveness(object: any): void;
        private static SetDockStyle(object);
        private static SetDisplayToParent(element);
    }
}
declare module WebMap.Client {
    class MessageBoxCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        private static showMessageDialog(cmd);
        private static preparteMessageBoxTemplate(msg);
        private static getMessageBoxIconCssClass(id);
        static showSessionExpiredMessage(): void;
        static showGenericMessage(messageText: string): void;
        static InitMessageBoxHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Client {
    class PluginCommandHandler implements ICommandHandler {
        id: string;
        dispatch(cmd: any): void;
        private static sendCommandToDesktopAgent(cmd);
        static InitPluginCommandHandler(): any;
        static staticinit: any;
    }
}
declare module WebMap.Utils {
    interface IControl {
        UniqueID: string;
        Controls: kendo.data.ObservableArray;
    }
    function getHashCodeFromUniqueID(uniqueID: string): string;
    function getWidgetInDOM(uniqueID: string, isMenuItem?: boolean): any;
    function bindWidgetToEvent(widget: kendo.ui.Widget, eventID: string, uniqueID: string, alwaysBind?: boolean): boolean;
    function bindMenuItemToEvent(widget: JQuery, eventID: string, uniqueID: string): boolean;
    function getSendActionFunction(mainObj: any, controllerName: string, action: string, parameters: {}): Function;
    function getNameFromAlias(typeOfObj: any, alias: string): string;
    function getTypeFromAlias(typeOfObj: any, alias: string): string;
    function prepareUniqueID(uniqueID: any, buildFullPath?: boolean): any;
    function buildParentFromUniqueID(UniqueID: string): any;
    function GetControls(controls: kendo.data.ObservableArray, callback: Function): void;
    /**
    * Set the display to the element.
    * @param $element
    * @param visible
    * @returns {}
    */
    function SetVisible($element: JQuery, visible: boolean): void;
    function refreshChildrenWidgets(element: JQuery): void;
    function isEventInWidgetEvents(widget: kendo.ui.Widget, event: string): boolean;
    function bindEventToModel(model: kendo.Observable, eventID: string, func: any): void;
    function isEventBoundToModel(model: kendo.Observable, eventID: any, func: any): boolean;
    function bindElementToModel(element: JQuery, model: WebMap.Client.IStateObject, executeInmediatly?: boolean): void;
    function selectiveUnbind(model: kendo.Observable): void;
    function isParentExecuted(UniqueID: string): boolean;
    function getWidgetFromSelector(selector: string): kendo.ui.Widget;
    class DynamicContainer {
        static applyTemplate(view: IControl, Controls: any, useTag?: boolean): string;
        static applyRowColumnProperties(tableinfo: any): string;
        static loadHTML(control: any, element: any, panelName: any, index: any, tableinfo?: any): string;
        static getIdToHtmlFromUserControl(control: any): {
            uid: any;
            identifier: any;
            alias: any;
        };
        static applyTemplateForGroup(view: IControl): string;
    }
}
declare module WebMap.Client {
    class Container implements IIocContainer {
        static Current: Container;
        static Init(): void;
        private GetEmptyObject(typeOfObj);
        cloneObject(obj: Object): Object;
        Resolve(options?: any): any;
        GetKendoObservableFor(model: IStateObject): kendo.data.ObservableObject;
    }
}
declare module WebMap.Client {
}
declare module WebMap.Client {
    enum SafeExecutionConditions {
        Ignore = 1,
        QueueForLater = 2,
    }
    interface IActionSafeExecution {
        obj: IStateObject;
        action: () => void;
        stage: ClientSyncronizationStage;
        whenNotAtThatStage: SafeExecutionConditions;
        category: string;
        abortWhenPreviousActionIsInExecution?: boolean;
    }
    enum ClientSyncronizationStage {
        NotUpdatingClientSideYet = 2,
        CurrentlyUpdatingClientSide = 4,
        UpdateClientSideAlmostComplete = 8,
        SendActionTriggered = 16,
    }
    class SafeActionExecutionManager {
        private app;
        constructor(app: App);
        pendingBindings: {
            [id: string]: any;
        };
        pendingBindingInExecution: string;
        executedBindings: {
            [id: string]: any;
        };
        kendoBinds: {
            [id: string]: any;
        };
        pendingSendActionCallBacks: any[];
        updateClientSideState: ClientSyncronizationStage;
        safeExec(args: IActionSafeExecution): void;
        Async(action: () => any): JQueryPromise<any>;
        getSendActionPromise(): JQueryPromise<any>;
        /**
        * registers ONE pending action associated to an IStateObject
        */
        registerPendingBinding(obj: IStateObject, func: () => void, category?: any): void;
        executePendingBindings(): void;
    }
    /**
      * This class represents a WebMap client side application, it is responsible for starting up the application and
      * manage the communication with de server side of a WebMap application
      */
    class App {
        static Current: App;
        ViewManager: IViewManager;
        inActionExecution: boolean;
        sendActionPromise: JQueryPromise<any>;
        private updateListeners;
        private eventsQueue;
        isClosingView: boolean;
        Safe: SafeActionExecutionManager;
        pendingUnBindedEx: {
            array: IStateObject;
            events: Array<any>;
        }[];
        pendingUnBindedExDictonary: {};
        private executeUnBindedEx(array, lambda);
        constructor();
        actionInExecution: string;
        servier: number;
        info(text: any): void;
        log(text: any): void;
        /**
         *Static constructor that creates singleton objects
         */
        private static Init();
        static Start(customClientTypeRegistrations: (app: WebMap.Client.App) => void): void;
        getControlRole(control: IStateObject): string;
        getControlType(typeTag: number): string;
        getControlTypeID(typeName: string): number;
        /**
         *Inits the WebMap application before the first screen is rendered.  This method must be invoked from
         * the main html page just before any other action is performed.
         */
        Init(models: any, viewsState: ViewState, modelTypes?: number[]): void;
        /**
         * Adds a listener to be called to update the model data
         */
        addModelUpdateListener(l: () => any): void;
        /**
         * Removes the given listener
         */
        removeModelUpdateListener(l: () => any): void;
        /**
         * Calls the registered listeners in order to update the model data
         */
        private callModelUpdateListeners();
        /**
        *  Sends a request to the WebMap server side application.  After call is made, the method updates the
        * WebMap client side app in order to refresh all changes performed by server side logic, to achieve that the
        * updateClientSide and UpdateMessages methods are called.
         */
        sendAction(options: AppActionOptions, forced?: boolean): JQueryPromise<any>;
        private doBlockUI(time);
        private undoBlockUI();
        private doServerCall(that, url, actionParamStr, forced, promise);
        /**
         * updates the given model object with the information stored in delta.
         */
        private applyDelta(model, delta);
        /**
         * Builds an url action request based in the values gieven in options.
         */
        private buildActionUrl(options);
        /**
         * Builds a JSON request based in the values given in options
         */
        private buildJSONRequest(options);
        private checkFlag(data, flagName);
        /**
          * When models are received, it might be needed to transverse those collections
          * to collect some information or to modify some aspects of the JSON message
          * to do that Client Type Behaviors can be associated to JSON packages, based on their
          * client type mark. Examples are Collections processing and StateObjectReferences
          */
        preOrganizeModels(models: any[], modelTypes: any[]): void;
        /**
         *  Execs any actions registered during the preOrganizeModel phase
         */
        postOrganizeModels(): void;
        bindPendingEventsForWidgetItems(isContextMenu?: boolean, alwaysBind?: boolean): void;
        private executePendingSendActions();
        /**
        *  models and modelTypes are supposed to be arrays of the same length
        *  there for each i-th entry in models there is an i-th entry in modelTypes that has
        *  the model associated type id
        *  if modelTypes is
        */
        associateModelTypes(models: any[], modelTypes: number[]): void;
        /**
          *  Creates the IViewModel objects for every model object in "models".  Models is an array of json data sent from the
          *  server side, where every element contains a set of property/value describing the view model object.
          */
        InitModels(models: any[], modelTypes?: number[]): void;
        /**
          *  Initializes the UI object for the first time.  This method must be called when the user first access the
          *  WebMap app and it is responsible for creating the first loaded windows (main window and/or login screen probably!).
          *  This method must be called after InitModels method because it requires view model to be already set.
          *  viewState :  Json object sent from server side containing the information of loaded views.
          */
        private InitUI(viewState);
        /**
         * removes the blocking UI message
         */
        private removeLoadingSplash();
        /** shows a blocking UI message */
        private showLoadingSplash();
        /** Updates the interaction messages sent from the server side in order to show them to the
        end user */
        private dispatchCommands(viewData);
        private FinishWakeUpArrayElements();
        private WakeUpArrayElements(controlArrays);
        private InsertIStateObjectIntoTheArray(array, value, uid);
        private getDeltaWithId(uniqueID, deltaData);
        private processRemovedIds(data);
        private processSwitchedIds(data, deltaData);
        /**
          *  This method must be called to handle the server side response to an action, it is responsible for updating
          *  client side data out from server side changes.  Responsibilities include:
          *  1. Initialize view models for every new view
          *  2. Update view model objects with server side changed information (delta)
          *  3. Display any shown view
          *  4. Update view changes (position, z-order, visibility)
          *  5. Remove any closed view
          */
        private updateClientSide(data, actionDeffered, n1);
    }
}
declare module WebMap.Client {
    class DeltaTracker {
        attachedObjs: {
            [uniqueid: string]: IStateObject;
        };
        dirtyTable: {
            [uniqueid: string]: boolean;
        };
        dirtyPropertiesTable: {
            [uniqueid: string]: {
                [propertyname: string]: boolean;
            };
        };
        isDirty(obj: IStateObject): boolean;
        markAsModified(obj: IStateObject, propertyName: string): void;
        constructor();
        updateDirtyPropertiesTable(fieldName: any, uid: any): void;
        /**
         * Checks if the object has an UniqueID or it is an AttachedUniquedID
         * AttachedUniqueIds cannot have $
         */
        private static IsAttached(obj);
        /**
         * Look for the first parent of the current object that has an AttachedUniqueID and marks it as
         * dirty, so the whole object will be send on the next sendAction call
         */
        private climbToNearestAttachedObjectAndMarkItDirty(item);
        changeTracker(e: any): any;
        _changeDelegate: any;
        /** Register an object for change tracking */
        attachModel(obj: IStateObject, markAsDirty?: boolean): void;
        reset(): void;
        start(): void;
        getDeltas(): void;
        wasModified(variable: IStateObject): boolean;
        getJSONFromFullObject(obj: any): any;
        getCalculatedDeltaFor(variable: any): {
            [dirtypropertyname: string]: any;
        };
    }
}
declare module WebMap.Client {
    class ViewManager implements IViewManager {
        private _logic;
        closedViews: string[];
        constructor();
        GetView(UniqueID: string): BaseLogic;
        CloseView(view: IViewModel): void;
        PrepareDelta(requestInfo: WebMapRequest): void;
        UpdateView(view: IViewModel, viewInfo: any): void;
        RemoveViews(data: any): void;
        NavigateToView(viewModel: IViewModel, isModal: boolean): JQueryPromise<BaseLogic>;
        ShowMessage(message: string, caption: string, buttons: any, boxIcons: any): IPromise;
        private static DESIGNERSUPPORT;
        static removeDesignerSupportSnippet(document: string): string;
        /**
         * Safely compiles an html template for a view
         */
        static CompileView(viewName: string, htmlTemplate: string): any;
        private DisposeView(viewModelId);
        getConstructor(vm: IViewModel): () => ILogicView;
        private IsRemovedView(id, VD);
    }
}
declare module WebMap.Client {
    class UniqueIDGenerator {
        static UniqueIdSeparator: string;
        static ReferencesIdentifier: string;
        static getParent(uniqueID: string): any;
        static getLastToken(uniqueID: string): string;
        static getFirstToken(uniqueID: string): string;
    }
    class StateManager {
        static Current: StateManager;
        private _cache;
        private _tracker;
        static Init(): void;
        constructor();
        /**
          *We use the term "organize" to refer to actions
          * of using the UniqueIDs to reconnect objects in an object hierarchy.
          * UniqueIDs are allways like Panel1#0002 that means Panel1 property inside
          * a top level object identified by 0002 you can use
          * the shortcut $cache to watch the current models state
          */
        organize(options?: any): void;
        attachModel(obj: IStateObject): void;
        private resolveHierarchy(options);
        resolveMissingParent(parentKey: any, name: any, value: any): void;
        addNewObject(obj: IStateObject, markAsDirty?: boolean): any;
        getDirty(): {
            [uniqueid: string]: {
                [dirtyproperty: string]: any;
            };
        };
        getObjectLocal(uniqueId: string): IStateObject;
        clearDirty(): void;
        markAsModified(obj: IStateObject, fieldName: string): void;
        getObject(uniqueId: string): IStateObject;
        removeReferences(objUniqueID: string): void;
        ClearViewReferences(id: string): void;
    }
}
declare module WebMap.Client {
    /**
      * Defines a class that contains information about the View changes.  This class
      * is used to interchange data between client and server calls.
      */
    interface ViewState {
        /**
         * Holds information indicating the current state of the views that should be present on display
         */
        LoadedViews?: IViewModel[];
        ModalViews: string[];
        /**
         * Indicates the UniqueIDs of the IViewModels for views that have been recently loaded
         * NOTE: LoadedViews and NewViews do not appear together at the same time. If LoadedViews is present that means
         * that this state is listing all the currently loaded views.
         */
        NewViews?: string[];
        /**
         * If present, it holds the name of the field that should adquire focus
         */
        CurrentFocusedControl: string;
        /**
         *
         * Removed views on server.
         */
        RemovedViews: string[];
    }
}
declare module WebMap.Client {
    /**
     * Implements an ILogicView<T> interface.
     * The typescript code for all forms must inherit from this class
     * Descendants must override the Init Method to sed the template to be used
     *
     */
    class BaseLogic implements ILogicView {
        static options: {
            template: (data: any) => string;
        };
        ViewModel: any;
        private timersToCleanup;
        /**
         * Gets the associated view from the ViewManage.LoadView (it could imply a web call) and then
         * calls BuildUI to initalize it
         */
        Init(isModal: boolean): void;
        /**
         * Intializes the view elements using the given options
         * param template - The value of the template
        * param keyboardEvents - It's optional. Is used to validate whether the keyboard events should be added or not. True by default.
         */
        protected BuildUI(template: any, isModal: boolean, keyboardEvents?: boolean): void;
        Close(): void;
        RegisterTimer(timerInfo: any): void;
        /**
         * This handler is meant to support convention based event handlers
         */
        generic_Click(event: any): JQueryPromise<any>;
        /**
          * Gets the id of the DOM object associated to the view
          */
        getDOMID(): string;
        /**
         * Set keyboard events
         **/
        KeyBoardEvents(): void;
        CloseWindowLocally(e: any): void;
        private CleanupTimers();
        ApplyEnabledPointerEvents: (status: any) => void;
        private ApplyValueChanges;
    }
}
interface Window {
    app: WebMap.Client.App;
}
declare module kendo.data {
    var binders: any;
}
declare module WebMap.Client {
    function checkedListBoxProc(element: any): void;
}
declare module UpgradeHelpers {
    class ControlArray {
        static indexOf(ctrlArray: any, e: any): number;
    }
    class Events {
        static getEventSender(e: any): any;
    }
    class EventKey {
        static getKeyChar(e: any): string;
        static setKeyChar(e: any, key: string): void;
        static getKeyCode(e: any): number;
        static setKeyCode(e: any, key: number): void;
        static handleEvent(e: any, value: boolean): void;
    }
    enum Keys {
        A = 65,
        Add = 43,
        Alt = 18,
        B = 66,
        Back = 8,
        C = 67,
        Capital = 20,
        CapsLock = 20,
        Clear = 46,
        Control = 17,
        ControlKey = 17,
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
        Escape = 27,
        F = 70,
        F1 = 112,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        G = 71,
        H = 72,
        Home = 36,
        I = 73,
        Insert = 45,
        J = 74,
        K = 75,
        L = 76,
        LControlKey = 17,
        Left = 37,
        LShiftKey = 16,
        M = 77,
        Multiply = 42,
        N = 78,
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
        P = 80,
        PageDown = 34,
        PageUp = 33,
        Q = 81,
        R = 82,
        RControlKey = 17,
        Return = 13,
        Right = 39,
        RShiftKey = 16,
        S = 83,
        Shift = 16,
        ShiftKey = 16,
        Space = 32,
        Subtract = 45,
        T = 84,
        Tab = 9,
        U = 85,
        Up = 38,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
    }
    class Sound {
        static getBeep(): Sound;
        Play(): void;
    }
    class Strings {
        static convertToString(obj: any): string;
        static format(obj: any, format: string): string;
    }
}
declare module WebMap.Client {
    interface WebMapRequest {
        /**
         * Contains a dictionary where each entry is the uniqueID of an IStateObject that was modified
         * and the value is an object with the modified props
         */
        dirty: {
            [uniqueid: string]: any;
        };
        /**
         * Contains the unique id of the viewmodel or usercontrol that will handle this request.
         * This vm will be injected in the corresponding MVC Controller.
         * NOTE: the controller should have a parameter called viewFromClient
         */
        vm: string;
        /**
         * List of views that have been closed
         */
        closedViews?: string[];
        /**
         * parameters that are needed on the client side
         */
        parameters?: {
            [parametername: string]: any;
        };
        /**
         * For message boxes, indicates which button was pressed
         */
        dialogResult?: string;
    }
}
declare module WebMap.Client {
    interface WebMapResponse {
        /**
         * If present indicates that a session timeout ocurred when the request was processed
         */
        SessionTimeOut?: boolean;
        /**
         * MDT aka Model Delta Types
         * Contains an array of integers that are used to 'type mark' the view models
         * MDT and MD must have the same size, and there is a corresponding MDT[i] for each MD[i]
         */
        MDT: number[];
        /**
         * MD aka Model Delta
         * Contains an array of the modified models after performing a request on the server
         */
        MD: IStateObject[];
        /**
         * RM aka removed views
         * list of models that have been removed on the server side, and that should also be removed on the client
         */
        RM: string[];
        /**
         * SW aka switched ids
         * Each element in this array is a pair like [ originalUniqueID, newUniqueID] that indicates a 'switch' on the UniqueID of an object already
         * on the StateManager
         */
        SW: Array<Array<string>>;
        /**
         * VD aka Views Delta
         * Reflects the current views state changes
         */
        VD: ViewState;
        NV: string;
    }
}
