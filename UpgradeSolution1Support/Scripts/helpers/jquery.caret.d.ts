// Type definitions for jQuery.caret.js 1.0.2
// Project: http://plugins.jquery.com/caret/
// Definitions by: Mauricio Rojas <https://github.com/orellabac>
// Definitions: https://github.com/borisyankov/DefinitelyTyped

/// <reference path="jquery.d.ts" />

interface jCaretOptions {
	start : number;
	end : number;
}

interface JQuery {
    /**
    * Get Caret for element
    */
    caret: {
        /**
        * Scroll the matched elements
        *
        * @param target element to get caret info.
        * @param settings Set of settings.
        */
        (settings?: jCaretOptions): jCaretOptions;

    };

}

interface JQueryStatic {
   /**
    * Get Caret for element
    */
    caret: {
        /**
        * Scroll the matched elements
        *
        * @param target element to get caret info.
        * @param settings Set of settings.
        */
        (target: any, settings?: jCaretOptions): jCaretOptions;

    };

}
