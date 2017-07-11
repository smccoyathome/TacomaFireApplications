/// <reference path="kendo.all.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="jquery.caret.d.ts" />

interface Window {
    app: WebMap.Client.App;
}

declare module kendo.data {
    var binders: any;

}
module WebMap.Client {


    /// Custom bindings
    
    //Form Visible Custom binding 
    kendo.data.binders.widget.formVisible = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var that = this;
            var binding = that.bindings["formVisible"];
            var visibleValue = binding.get();
            if (typeof visibleValue != 'undefined') {
                $(that.element.element).data("kendoWindow").setOptions({ "visible": visibleValue }); //update the widget
                if (!visibleValue && $(".k-overlay"))
                    $(".k-overlay").remove();
            }
        }
    });
    
    //Form Text Custom binding 
    kendo.data.binders.widget.formTextBinding = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var that = this;
            var binding = that.bindings["formTextBinding"];
            if (binding)
                $(that.element.element).data("kendoWindow").title(binding.get()); //update the widget
        }
    });

    kendo.data.binders.checkState = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);

            var that = this;
            (<HTMLInputElement>that.element).addEventListener('click', () => {
                that.change();
            });
        },
        refresh: function () {
            var binding = this.bindings["checkState"];
            var vmelement = binding.source[binding.path.substr(0, binding.path.indexOf('.'))];
            if (vmelement !== undefined) {
                var currentState = vmelement.get('CheckState');
                if (currentState != 2) {
                    (this.element).checked = currentState == 1;
                } else {
                    (this.element).indeterminate = true;
                }
            }
        },
        change: function () {
            var value = this.element.checked;
            var binding = this.bindings["checkState"];
            var vmelement = binding.source[binding.path.substr(0, binding.path.indexOf('.'))];
            vmelement.set('Checked', value);
            vmelement.set('CheckState', value ? 1 : 0);
            this.bindings['checkState'].set(value ? 1 : 0);
        }

    });

    (kendo.data.binders).customChecked = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (kendo.data.Binder.fn).init.call(this, element, bindings, options);

            var that = this;
            (that.element).addEventListener('change', function () {
                that.change();
            });
        },
        refresh: function () {
            var binding = this.bindings["customChecked"];
            (this.element).checked = binding.get();
        },
        change: function () {
            var value = this.element.checked;
            var binding = this.bindings["customChecked"];
            if (binding.source.get(binding.path) !== undefined) {
                binding.set(true);
            }


            var source = binding.source;
            var relatedRadios = document.querySelectorAll('div[id="' + source.UniqueID + '"] input[name="' + this.element.name + '"]');
            for (var i in relatedRadios) {
                var e = <any>relatedRadios[i];
                if (e != this.element &&
                    e.kendoBindingTarget &&
                    e.kendoBindingTarget.source) {
                    if (e.kendoBindingTarget.source[e.id]) {
                        e.kendoBindingTarget.source[e.id].set('Checked', false);
                    } else {
                        // Check for control array updates
                        var controlArrayRefRegex = /^_(.+)_([0-9]+)/;
                        if (controlArrayRefRegex.test(e.id)) {
                            e.kendoBindingTarget.source.set(e.id.replace(controlArrayRefRegex, "$1[$2]") + ".Checked", false);
                        }
                    }
                }
            }
        }
    });

    kendo.data.binders.menuEnabled = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var binding = this.bindings["menuEnabled"];
            var parentMenu = $(this.element).parents('ul[data-role="menu"]').data('kendoMenu');
            if (parentMenu)
                parentMenu.enable(this.element, binding.get());
            else { //For ContextMenu control
                var parentContextMenu = $(this.element).parents('ul[data-role="contextMenu"]').data('kendoContextMenu');
                if (parentContextMenu)
                    parentContextMenu.enable(this.element, binding.get());
            }
        }
    });

    kendo.data.binders.widget.dateTimePickerValue = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);

            var that = this;
            this.element.bind("change",
                function () {
                    that.change();
                });
        },
        refresh: function () {
            var binding = this.bindings["dateTimePickerValue"];
            var value = binding.get();
            if (typeof (value) === 'string') {
                value = kendo.parseDate(value);
            }
            this.element.value(value);
        },
        change: function () {
            var value = this.element.value();
            var binding = this.bindings["dateTimePickerValue"];
            binding.set(convertDate(value));
        }

    });

    function convertDate(value) {
        var year = value.getFullYear();
        var month = (value.getMonth() + 1 < 10) ? "0" + (value.getMonth() + 1) : (value.getMonth() + 1);
        var date = (value.getDate() < 10) ? "0" + value.getDate() : value.getDate();
        var hours = (value.getHours() < 10) ? "0" + value.getHours() : value.getHours();
        var minutes = (value.getMinutes() < 10) ? "0" + value.getMinutes() : value.getMinutes();
        var seconds = (value.getSeconds() < 10) ? "0" + value.getSeconds() : value.getSeconds();
        return year + "-" + month + "-" + date + "T" + hours + ":" + minutes + ":" + seconds;
    }

    kendo.data.binders.buttonText = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var binding = this.bindings["buttonText"];
            var spans = $(this.element).find("span");
            if (!spans || !spans.length)
                $(this.element).html(binding.get());
            else {
                $(spans[0]).html(binding.get());
            }
        }
    });

    kendo.data.binders.widget.DateTimeMinDate = kendo.data.Binder.extend({
        refresh: function (widget) {
            var binding = this.bindings["DateTimeMinDate"];
            var value = binding.get();
            if (value != null) {
                var dataRole = this.element.element.attr('data-role');
                if (dataRole === "datetimepicker")
                    this.element.element.data("kendoDateTimePicker").min(kendo.parseDate(value));
                else if (dataRole === "datepicker")
                    this.element.element.data("kendoDatePicker").min(kendo.parseDate(value));
            }
        }
    });

    kendo.data.binders.timerTick = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
        },
    });

    kendo.data.binders.timerInterval = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
        },
    });

    kendo.data.binders.timerEnabled = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.isTimerActive = false;
            this.currentTimeoutId = -1;
        },
        refresh: function () {
            var binding = this.bindings["timerEnabled"];
            if (this.bindings.events) {
                var callbackBinding = this.bindings.events["timerTick"];
                var intervalBinding = this.bindings["timerInterval"];
                var source = binding.source;
                var logic = source.logic;
                var that = this;
                var interval = -1;
                if (intervalBinding !== undefined) {
                    interval = intervalBinding.get();
                } else {
                    interval = parseInt($(this.element).attr('data-timerinterval'));
                    if (isNaN(interval)) {
                        interval = -1;
                    }
                }
                if (logic && logic.RegisterTimer) {
                    logic.RegisterTimer(that);
                }
                that.isTimerActive = binding.get() !== false;

                if (binding.get() !== false) {
                    var theCallBack = callbackBinding.source.get(callbackBinding.path);
                    function returnHere() {
                        theCallBack.call(binding.source).then(function () {
                          if (that.bindings["timerEnabled"].get() !== false) {
                                that.currentTimeoutId = setTimeout(returnHere, interval);
                            }
                        });
                    }

                    that.currentTimeoutId = setTimeout(returnHere, interval);
                } else {

                    that.clearTimer();
                }
            }
        },
        clearTimer: function () {
            if (this.isTimerActive) {
                this.isTimerActive = false;
            }
            if (this.currentTimeoutId != -1) {
                clearTimeout(this.currentTimeoutId);
                this.currentTimeoutId = -1;
            }
        }
    });

    kendo.data.binders.widget.comboSelectedIndex = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);

            var that = this;
            that.indexCorrection = 0;
            this.element.bind("select",
                function (item) {
                    that.change(item);
                });
            if (this.element.ns === ".kendoDropDownList") {
                this.indexCorrection = 1;
            }
            this.ignoreRefresh = false;
        },
        refresh: function () {
            var that = this;
            if (!this.ignoreRefresh) {
                var binding = this.bindings["comboSelectedIndex"];
                var value = binding.get();
                if (typeof (value) === 'string') {
                    value = parseInt(value);
                }
                // Update the selected element, but be careful
                // the data in the Combo may not be available yet
                if (this.element.dataSource.data().length > 0) {
                    this.element.select(value + this.indexCorrection);
                } else {
                    // If the datasource is not available yet then delay the selection
                    setTimeout(function () {
                        that.element.select(value + that.indexCorrection);
                    },
                        1);
                }
            }
        },
        change: function (item) {
            var value = item.item.index();
            var binding = this.bindings["comboSelectedIndex"];
            try {
                this.ignoreRefresh = true;
                binding.set(value);
            } finally {
                this.ignoreRefresh = false;
            }
        }
    });

    //////////////////////////////
    ///
    /// ListView support
    ///



    function createListViewGridAsChild(element: any, source: any, columnsObject: any, thisElement: any) {
        var newElement = document.createElement("div");
        var role = document.createAttribute("data-role");
        role.value = "grid";
        var db = $(element).attr('data-itemssource');
        var dbatt = document.createAttribute("data-bind");
        dbatt.value = db;
        newElement.setAttribute('data-role', 'grid');
        newElement.setAttribute('data-resizable', 'true');
        var dblclickhandler = $(element).attr('data-doubleclickhandler');
        if (dblclickhandler) {
            db = db + ",listViewDoubleClick: " + dblclickhandler;
        }
        var changeHandler = $(element).attr('data-changehandler');
        if (changeHandler) {
            source.logic["internalChangeHandler"] =
            function (e) {
                var that = this;
                window.app.Safe.safeExec({
                    obj: source,
                    stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                    whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                    category: "requestAction",
                    action: () => that.logic[changeHandler].bind(that)(e)
                });
            }
            db = db + ",events: {change: logic.internalChangeHandler}";
        }


        var initialHeight = $(element).attr('data-initialheight');
        if (initialHeight !== undefined) {
            newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
        }
        var selectIndices = $(element).attr('data-selectedIndices');
        var checkedIndices = $(element).attr('data-checkedIndices');
        newElement.setAttribute('data-bind', db + "," + selectIndices + "," + checkedIndices);

        element.appendChild(newElement);

        var selectionMode = <any>$(element).data('selectionmode') == "multiple" ? "multiple, row" : "row";
        var allowReorder = <any>$(element).data('allowreorder') === true ? true : false;
        $(newElement).kendoGrid({
            resizable: true,
            scrollable: true,
            reorderable: allowReorder,
            selectable: selectionMode,
            columns: transformColumnsToObj(columnsObject, thisElement),
            dataBound: function (e: any) {
                var items = e.sender.dataItems();
                if (items && items.length) {
                    var itemElements = e.sender.element.find("[class='k-grid-content']").find('tr');
                    var i = 0;
                    for (i = 0; i < items.length; i++) {
                        if (items[i].Checked) {
                            var checkbox = $(itemElements[i]).find('input');
                            if (checkbox) {
                                $(checkbox).attr("checked", "checked");
                            }
                        }
                        if (items[i].Selected) {
                            $(itemElements[i]).addClass("k-state-selected");
                            $(itemElements[i]).attr('selected', 'true');
                        }
                    }
                }
            },
            change: function (e: any) {
                var items = e.sender.dataItems();
                if (items && items.length) {
                    var itemElements = e.sender.element.find("[class='k-grid-content']").find('tr');
                    var i = 0;
                    for (i = 0; i < items.length; i++) {
                        var isSelected = $(itemElements[i]).hasClass('k-state-selected');
                        if (isSelected)
                            items[i].Selected = true;
                        else
                            items[i].Selected = false;
                    }
                }
            }
        });
        // setTimeout is required because the template may not be completely applied
        if (initialHeight === undefined) {
            setTimeout(function () {
                $(element).find('.k-widget').height("100%");
                $(newElement).find('.k-grid-content').height("87%");
                $(newElement).find('.k - grid - header').height("13%");
            }, 100);
        }
        kendo.bind($(element).children('div'), source);
    }

    function removeExistingListViewInnerElement(element: any) {
        $(element).children('div').each(function (index, subeelement) {
            var existingGrid = $(subeelement).data('kendoGrid');
            if (existingGrid) {
                existingGrid.destroy();
                $(subeelement).remove();
            }
            var existingLv = $(subeelement).data('kendoListView');
            if (existingLv) {
                existingLv.destroy();
                $(subeelement).remove();
            }
        });

    }

    function noImageTemplate(checkboxes) {
        var listTemplate = "";
        if (checkboxes)
            listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><input type='checkbox' value='#= ItemContent[0] #'/><p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";

        else


            listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
        return listTemplate;
    }

    function createTemplateForList(element: any, modevalue: number, checkboxes: boolean) {
        var listTemplate = "<div style='float: left'><div>#= ItemContent[0] #<br></div></div>";
        if (modevalue == 0) {
            var imageListPrefix = $(element).data('imagelistprefix');
        }
        if (modevalue == 2) {
            var imageListPrefix = $(element).data('smallimagelistprefix');
        }

        if (modevalue == 0 || modevalue == 2) {
            if (imageListPrefix) {
                imageListPrefix = imageListPrefix;
                if (checkboxes) {
                    listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'><input type='checkbox' value='#= ItemContent[0] #'/>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}#<p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
                }
                else {
                    listTemplate = "<div style='float: left;'><div style='float:left; margin: 10px 10px 0 10px;'>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}#<p style='word-wrap:break-word; width: 5em; margin-top:0;'>#= ItemContent[0] #</p><br></div></div>";
                }
            }
            else
                listTemplate = noImageTemplate(checkboxes);
        } else {
            var imageListPrefix = $(element).data('smallimagelistprefix');
            if (imageListPrefix) {
                imageListPrefix = imageListPrefix;
                if (checkboxes) {
                    listTemplate = "<div style='float: left'><div><input type='checkbox' value='#= ItemContent[0] #'/>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}##= ItemContent[0] #<br></div></div>";
                }
                else {
                    listTemplate = "<div style='float: left'><div>#if(ImageIndex != -1){#<img src='" + imageListPrefix + ".ImageStream#= ImageIndex #.png'>#}##= ItemContent[0] #<br></div></div>";
                }
            }
            else
                if (checkboxes) {
                    listTemplate = "<div style='float: left'><div><input type='checkbox' value='#= ItemContent[0] #'/>#= ItemContent[0] #<br></div></div>";
                }
                else {
                    listTemplate = "<div style='float: left'><div>#= ItemContent[0] #<br></div></div>";

                }
        }
        return listTemplate;
    }

    function refreshListViewTemplates(thisElement) {
        var modebinding = thisElement.bindings["listViewMode"];
        var modevalue = modebinding.get();
        var binding = thisElement.bindings["listViewColumns"];
        var value = binding.get();
        var element = thisElement.element.element[0];
        var checkBoxes = thisElement.bindings["CheckBoxesMode"].get();//Indicates if the template should have a checkbox element next to each Item
        removeExistingListViewInnerElement(element);

        if (modevalue === 1) {
            createListViewGridAsChild(element, binding.source, value, thisElement);
        } else {
            var newElement = document.createElement("div");
            var role = document.createAttribute("data-role");
            role.value = "listview";
            var db = $(element).attr('data-itemssource');
            var selectIndices = $(element).attr('data-selectedIndices');
            var checkedIndices = $(element).attr('data-checkedIndices');
            var selectedIndexChanged = $(element).attr('data-SelectedIndexChanged');
            newElement.setAttribute('data-role', 'listview');
            newElement.setAttribute('data-resizable', 'true');
            var events = "";
            if (selectedIndexChanged !== undefined) {
                events = "events : {" + selectedIndexChanged + "}";
            };
            newElement.setAttribute('data-bind', db + "," + selectIndices + "," + checkedIndices + "," + events);
            element.appendChild(newElement);
            var initialHeight = $(element).attr('data-initialheight');
            if (initialHeight !== undefined) {
                newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
            }
            newElement.setAttribute('style', 'overflow:scroll' + (newElement.getAttribute('style') ? ';' + newElement.getAttribute('style') : ''));

            var selectionMode = $(element).data('selectionmode') as any == "single" ? "single" : "multiple";
            var listTemplate = createTemplateForList(element, modevalue, checkBoxes);

            $(newElement).kendoListView({
                navigatable: true,
                selectable: selectionMode,
                template: kendo.template($(listTemplate).html()),
                dataBound: function (e: any) {

                    var items = e.sender.dataItems();
                    if (items && items.length) {
                        var itemElements = e.sender.element.find("div");
                        var i = 0;
                        for (i = 0; i < items.length; i++) {
                            if (items[i].Checked) {
                                var checkbox = $(itemElements[i]).find('input');
                                if (checkbox) {
                                    $(checkbox).attr("checked", "checked");
                                }
                            }
                            if (items[i].Selected) {
                                $(itemElements[i]).addClass("k-state-selected");
                                $(itemElements[i]).attr('selected', 'true');
                            }
                        }
                    }
                },
                change: function (e: any) {
                    var items = e.sender.dataItems();
                    if (items && items.length) {
                        var itemElements = e.sender.element.find("div");
                        var i = 0;
                        for (i = 0; i < items.length; i++) {
                            var isSelected = $(itemElements[i]).hasClass('k-state-selected');
                            window.app.log(isSelected);
                            if (isSelected)
                                items[i].Selected = true;
                            else
                                items[i].Selected = false;
                        }
                    }
                }
            });
            kendo.bind($(element).children('div'), binding.source);
        }
    }



    kendo.data.binders.widget.listViewSelectedIndices = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            element.bind('change', () => {
                this.update();
            });

        },
        refresh: function () {
            if (!this.innerUpdating) {
                var selectedIndexBinding = this.bindings["listViewSelectedIndices"];
                var newIndex = selectedIndexBinding.get();
                var listview = this.element.element;
                if (listview)
                    listview = listview[0];
                else
                    listview = this.element[0];
                var isGrid = $(listview).find('table');
                var items = null;
                if (isGrid.length == 0) {
                    items = $(listview).find('div');
                }
                else
                    items = $(listview).find("[class='k-grid-content']").find('tr');
                this.selectionRestore(items, newIndex);
            }
        },
        update: function () {
            var listview = this.element.element;
            if (listview)
                listview = listview[0];
            else
                listview = this.element[0];
            var isGrid = $(listview).find('table');
            var items = null;
            if (isGrid.length == 0)
                items = $(listview).find('div');
            else
                items = $(listview).find("[class='k-grid-content']").find('tr');
            var newIndices: number[] = [];
            items.each((i, item) => {
                var isSelected = $(item).hasClass('k-state-selected');
                if (typeof isSelected !== typeof undefined && isSelected !== false) {
                    newIndices.push(i);
                }
            });
            var selectedIndexBinding = this.bindings["listViewSelectedIndices"];
            selectedIndexBinding.set(newIndices);
            this.innerUpdating = false;

        },
        destroy: function () {
            (<any>kendo.data.Binder.fn).destroy.call(this);
            this.element.unbind('dblclick');

        },
        selectionRestore: (children, indices) => {
            if (indices) {
                children.each((i, element) => {
                    var colIndex = indices.indexOf(i);
                    if (colIndex != -1) {
                        $(element).addClass('k-state-selected');
                        $(element).attr('selected', 'true');

                    } else if (colIndex == -1) {
                        $(element).removeClass('k-state-selected');
                        $(element).removeAttr('selected');

                    }
                });
            }
        }
    });

    kendo.data.binders.widget.listViewCheckedIndices = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            element.element.bind('click', () => {
                this.update();
            });
            element.element.bind('dataBound', () => {
                this.databound();
            });
        },
        refresh: function () {
            if (!this.innerUpdating) {
                var checkedIndexBinding = this.bindings["listViewCheckedIndices"];
                var newIndex = checkedIndexBinding.get();
                var listview = this.element.element;
                if (listview)
                    listview = listview[0];
                else
                    listview = this.element[0];
                var isGrid = $(listview).find('table');
                var items = null;
                if (isGrid.length == 0) {
                    items = $(listview).find('div');
                }
                else
                    items = $(listview).find("[class='k-grid-content']").find('tr');
                this.selectionRestore(items, newIndex);
            }


        },
        update: function () {
            var listview = this.element.element;
            if (listview)
                listview = listview[0];
            else
                listview = this.element[0];
            var isGrid = $(listview).find('table');
            var items = null;
            if (isGrid.length == 0)
                items = $(listview).find('div');
            else
                items = $(listview).find("[class='k-grid-content']").find('tr');
            var newIndices: number[] = [];
            items.each((i, item) => {
                var checkbox = $(item).find('input');
                var checked = false;
                if (checkbox.get(0) !== undefined) { //checkbox activated
                    checked = checkbox.prop('checked');
                    if (checked)
                        newIndices.push(i);
                }
            });
            var checkedIndexBinding = this.bindings["listViewCheckedIndices"];
            checkedIndexBinding.set(newIndices);
            this.innerUpdating = false;

        },
        destroy: function () {
            (<any>kendo.data.Binder.fn).destroy.call(this);
            this.element.unbind('dblclick');

        },
        selectionRestore: (children, indices) => {
            if (indices) {
                children.each((i, element) => {
                    var colIndex = indices.indexOf(i);
                    if (colIndex != -1) {
                        var checkbox = $(element).find('input');
                        if (checkbox) {
                            $(checkbox).prop("checked", "checked");
                        }
                    } else if (colIndex == -1) {
                        var checkbox = $(element).find('input');
                        if (checkbox)
                            checkbox.removeAttr('checked');
                    }
                });
            }
        }
    });

    kendo.data.binders.widget.listViewMode = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },

        refresh: function () {
            refreshListViewTemplates(this);
        },

    });


    kendo.data.binders.widget.CheckBoxesMode = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },

        refresh: function () {
            refreshListViewTemplates(this);
        },

    });

    function transformColumnsToObj(cols, thisElement) {
        var colsStr = [];
        if (thisElement.bindings["CheckBoxesMode"]) {
            var checkBoxes = thisElement.bindings["CheckBoxesMode"].get();
            if (checkBoxes) {
                colsStr.push(
                    {
                        field: "select",
                        title: "&nbsp;",
                        template: '<input type=\'checkbox\' />',
                        sortable: false,
                        width: 25
                    });
            }
        }
        //Some optimizations do not send collections when empty
        //so we must check before using them
        if (cols && cols.Items) {
        for (var idx = 0; idx < cols.Items.length; idx++) {
            var colDefinition = cols.Items[idx];
            var columnAlignment = getKendoAlignment(colDefinition.HorizontalAlignment);
            colsStr.push({
                title: colDefinition.Text,
                field: "ItemContent[" + idx.toString() + "]",
                attributes: {
                    style: "text-align: " + columnAlignment
                },
                headerAttributes: {
                    style: "text-align: " + columnAlignment
                },
                width: colDefinition.Width,
                editor: colDefinition.ReadOnly ? ReadOnlyEditor : ''
            });
        }
        }
        var deleteRows = thisElement.bindings["DataGridDeleteRows"];
        if (deleteRows) {
            var value = deleteRows.get();
            if (value) {
                colsStr.push({
                    command: [{
                        name: 'deleteRecord',
                        text: 'Delete Record',
                        click: deleteRecords,
                        imageClass: "ui-icon ui-icon-close",
                    }],
                    width: "100px"
                });
            }
        }

        return colsStr;
    }
    function ReadOnlyEditor(event) {
        var gridDiv = $(event).closest("div[id$='_innerGrid']");
        $(gridDiv).data('kendoGrid').closeCell();
    }

    function getKendoAlignment(alignment) {
        switch (alignment) {
            case 0: return "center";
            case 2: return "right";
            default: return "left";
        }
    }

    kendo.data.binders.widget.listViewColumns = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var binding = this.bindings["listViewColumns"];
            if (binding) {
                var that = this;
                var value = binding.get();
                if (value) {
                    value.bind('change', function () {
                        that.refresh();
                    });
                }
            }
        },
        refresh: function () {
            var modebinding = this.bindings["listViewMode"];
            var modevalue = modebinding.get();
            if (modevalue !== 1) {
                return;
            }
            var binding = this.bindings["listViewColumns"];
            var value = binding.get();
            var element = this.element.element[0];
            removeExistingListViewInnerElement(element);
            createListViewGridAsChild(element, binding.source, value, this);
        },

    });



    kendo.data.binders.widget.listViewDoubleClick = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);

        },
        refresh: function () {
            var handlerBinding = this.bindings["listViewDoubleClick"];
            var theCallBack = handlerBinding.source.get(handlerBinding.path);
            if (this.theHandler === undefined) {
                this.theHandler = function () {
                    theCallBack.call(handlerBinding.source);
                };
                $(this.element.table).last().dblclick(this.theHandler);
            }
        },
        destroy: function () {
            (<any>kendo.data.Binder.fn).destroy.call(this);
            $(this.element.table).last().unbind('dblclick');
        }

    });


    (function ($) {
        var ui = kendo.ui,
            Widget = ui.Widget
        var WMListView = Widget.extend({
            init: function (element, options) {
                Widget.fn.init.call(this, element, options);
            },
            options: {
                name: "WMListView",
                mode: 1
            }
        });

        ui.plugin(WMListView);
        kendo.init($(document.body));

    })(jQuery);

    kendo.data.binders.enabled = kendo.data.Binder.extend({
        previousBinder: kendo.data.binders.enabled,
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget, bindings, options);
            this.refresh = this.setupTabStripPage(widget) ||
            this.setupMenuItem(widget) ||
            (this.previousBinder ? this.previousBinder.prototype.refresh : undefined);  // use default kendo enabled binder
        },
        setupTabStripPage: function (widget) {
            // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
            var tabControl, tmp;
            if (widget instanceof HTMLLIElement && (tmp = widget.parentElement) instanceof HTMLUListElement &&
                (tabControl = tmp.parentElement) instanceof HTMLDivElement && tabControl.getAttribute("data-role") === "tabstrip") {
                var tabWidget = $(tabControl).data("kendoTabStrip");
                var enabledBinding = this.bindings.enabled;
                return function () {
                    var index = enabledBinding.path.indexOf(".Items[")
                    if (index >= 0) {
                        var sinPath = enabledBinding.path.substring(0, index);
                        sinPath = sinPath.concat(".Enabled");
                    }
                    var widgetEnabledValue = enabledBinding.source.get(sinPath);
                    if (widgetEnabledValue) {
                        tabWidget.enable(this.element, enabledBinding.get());
                    }
                };
            }
            return null;
        },
        setupMenuItem: function (widget) {
            var parentMenuElement = $(this.element).parents('ul[data-role="menu"]');
            if (parentMenuElement && parentMenuElement.length > 0) {
                var binding = this.bindings["enabled"];
                var parentMenu = parentMenuElement.data('kendoMenu');
                return function () {
                    parentMenu.enable(this.element, binding.get());
                };
            }
            return null;
        }
    });

    /// Enabled custom binding for widgets 
    kendo.data.binders.widget.enabled = kendo.data.Binder.extend({
        previousBinder: kendo.data.binders.widget.enabled,
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget, bindings, options);
            this.refresh = this.setupControls(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined);  // use default kendo widget enabled binder
        },
        setupControls: function (widget) {
            var dataRole = $(widget.element).attr('data-role');
            if (dataRole === "treeview") {
                var treeWidget = widget;
                var enabledBinding = this.bindings.enabled;
                return function () {
                    treeWidget.enable(".k-item", enabledBinding.get());
                };
            } else if (dataRole === "dropdownlist"
                || dataRole === "datetimepicker"
                || dataRole === "timepicker"
                || dataRole === "maskedtextbox"
                || dataRole === "datepicker"
                || dataRole === "combobox"
                || dataRole === "textbox") {
                var enabledBinding = this.bindings.enabled;
                return function () {
                    widget.enable(enabledBinding.get());
                };
            } else if (dataRole === "wmlistview") {
                var enabledBinding = this.bindings.enabled;
                return function () {
                    var coverDiv = $(widget.element).find('.cover');
                    var enabledValue = enabledBinding.get();
                    if (!enabledValue) {
                        $("<div class='cover'>").css({
                            width: "100%",
                            height: "100%",
                            top: "0px",
                            left: "0px",
                            position: "absolute",
                            background: 'rgba(0,0,0,0.2)',
                            "z-index": $("div[data-role='grid']").css('z-index') + 1,
                        }).appendTo($(widget.element));
                    } else {
                        $(widget.element).find('.cover').remove();
                    }
                };
            } else if (dataRole === "tabstrip") {
                var enabledBinding = this.bindings.enabled;
                return function () {
                    var ulElem = $(widget.element).children('ul').first();
                    ulElem.children('li').each(function (index, li) {
                        if (enabledBinding.get()) {
                            var sinPath = enabledBinding.path.replace('.Enabled', '');
                            var itemEnabledValue = enabledBinding.source.get(sinPath + '.Items[' + index + '].Enabled');
                            widget.enable(li, itemEnabledValue);
                        }
                        else {
                            widget.enable(li, enabledBinding.get());
                        }
                    });
                }
            }
            else if (dataRole === "wmflexgrid") {
                var enabledBinding = this.bindings.enabled;
                return function () {
                    var gridElem = $(widget.element);
                    $(gridElem).prop("disabled", enabledBinding.get());
                }
            }
            return null;
        }
    });



    kendo.data.binders.visible = kendo.data.Binder.extend({
        previousBinder: kendo.data.binders.visible,
        isClassSet: (classes: string, cls: string): boolean => {
            var idx = classes.indexOf(cls);
            var len = cls.length;
            return (idx == 0 && (classes.length == len || classes[len] == ' ')) || (idx > 0 && classes[idx - 1] == ' ' && ((idx += len) == classes.length || classes[idx] == ' '));
        },

        removeClass: (classes: string, cls: string): string => {
            var len = cls.length;
            var idx = classes.indexOf(cls);
            if(idx >= 0) {
                var idx2 = idx + len;
                var before = "", after = "";
                if (idx > 0) {
                    if (classes[idx - 1] == ' ')
                        idx--;
                    else
                        return classes;
                    before = classes.substring(0, idx);
                }
                if (idx2 < classes.length) {
                    if (classes[idx2] == ' ')
                        idx2++;
                    else
                        return classes;
                    after = classes.substring(idx2);
                }
                return (before + ' ' + after).trim();
            }
        return classes;
        },
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget, bindings, options);
            //WebMap.Kendo.setupBinding(this, kendo.data.binders.visible, [TabPageVisibleBindingSetup.prototype]);
            this.refresh = this.setupTabStripPage(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined);  // use default kendo enabled binder
        },
        setupTabStripPage: function (widget) {
            // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
            var tabControl, tmp;
            if (widget instanceof HTMLLIElement && (tmp = widget.parentElement) instanceof HTMLUListElement &&
                (tabControl = tmp.parentElement) instanceof HTMLDivElement && tabControl.getAttribute("data-role") === "tabstrip") {
                var tabWidget = $(tabControl).data("kendoTabStrip");
                var visibleBinding = this.bindings.visible;
                return function () {
                    var cls = widget.getAttributeNode("class");
                    if (visibleBinding.get()) {
                        if (!this.isClassSet(cls.value, "k-item"))
                            cls.value = "k-item " + cls.value;
                        widget.removeAttribute("hidden");
                    }
                    else {
                        var newValue = this.removeClass(cls.value, "k-item");
                        if (newValue != cls.value) {
                            if (tabWidget.select()[0] === widget)
                                tabWidget.deactivateTab(widget);
                            cls.value = newValue;
                            widget.setAttribute("hidden", "hidden");
                        }
                    }
                };
            }
            return null;
        }
    });

    //class TabPageVisibleBindingSetup extends WebMap.Kendo.BindingSetup {
    //    public setup(binding: kendo.data.Binder): boolean {
    //        // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
    //        var widget = binding.element;
    //        var tabControl;
    //        if (widget instanceof HTMLLIElement && widget.parentElement instanceof HTMLUListElement &&
    //            (tabControl = widget.parentElement.parentElement) instanceof HTMLDivElement &&
    //            tabControl.getAttribute("data-role") === "tabstrip") {
    //            var tabWidget = $(tabControl).data("kendoTabStrip");
    //            var visibleBinding = binding.bindings["visible"];
    //            binding.refresh = function () {
    //                var cls = widget.getAttributeNode("class");
    //                if (visibleBinding.get()) {
    //                    if (!WebMap.Utils.IsClassSet(cls.value, "k-item"))
    //                        cls.value = "k-item " + cls.value;
    //                    widget.removeAttribute("hidden");
    //                }
    //                else {
    //                    var newValue = WebMap.Utils.RemoveClass(cls.value, "k-item");
    //                    if (newValue != cls.value) {
    //                        if (tabWidget.select()[0] === widget)
    //                            tabWidget.deactivateTab(widget);
    //                        cls.value = newValue;
    //                        widget.setAttribute("hidden", "hidden");
    //                    }
    //                }
    //            };
    //            return true;
    //        }
    //        return false;
    //    }
    //}


    kendo.data.binders.widget.visible = kendo.data.Binder.extend({
        previousBinder: kendo.data.binders.visible,
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget, bindings, options);
            this.refresh = this.setupCustomControl(widget) || (this.previousBinder ? this.previousBinder.prototype.refresh : undefined);  // use default kendo enabled binder
        },
        setupCustomControl: function (widget) {
            var dataRole = $(widget.element).attr('data-role');
            var visibleBinding = this.bindings.visible;
            if (dataRole === "wmlistview"
                || dataRole === "listbox"
                || dataRole === "grid"
                || dataRole === "wmflexgrid"
                || dataRole === "dropdownlist"
                || dataRole === "combobox"
                || dataRole === "maskedtextbox"
                || dataRole === "menu"
                || dataRole === "treeview"
                || dataRole === "tabstrip"
                || dataRole === "datetimepicker"
                || dataRole === "timepicker"
                || dataRole === "truedbgrid") {
                return function () {
                    if (visibleBinding.get()) {
                        $(widget.element).css({ visibility: "inherit" });
                    } else {
                        $(widget.element).css({ visibility: "hidden" });
                    }
                };
            }
            else if (dataRole === "datepicker" || dataRole === "dropdownlist") {
                return function () {
                    if (visibleBinding.get()) {
                        $(widget.element).closest(".k-widget").css({ visibility: "inherit" });
                    } else {
                        $(widget.element).closest(".k-widget").css({ visibility: "hidden" });
                    }
                }
            }
            else if (dataRole === "menu") {
                return function () {
                    var isVisible = visibleBinding.get();
                    if (typeof isVisible === 'boolean' && isVisible === false) {
                        $(widget.element).css({ display: "none" });
                    } else {
                        $(widget.element).css({ display: "block" });
                    }
                }
            }
            else if (dataRole === "numerictextbox") {
                return function () {
                    var isVisible = visibleBinding.get();
                    if (typeof isVisible === 'boolean' && isVisible === false) {
                        $(widget.element).closest('.k-numerictextbox').parent().css({ visibility: "hidden" });
                    } else {
                        $(widget.element).closest('.k-numerictextbox').parent().css({ visibility: "inherit" });
                    }
                }
            }
            else if (dataRole === "window") {
                return function () {
                    var isVisible = visibleBinding.get();
                    if (typeof isVisible === 'boolean' && isVisible === false) {
                        $(widget.element).parent().css({ visibility: "hidden" });
                    } else {
                        $(widget.element).parent().css({ visibility: "inherit" });
                    }
                }
            }
            return null;
        }
    });

	kendo.data.binders.widget.Visible = kendo.data.Binder.extend({
		refresh: function () {
			var value = this.bindings["Visible"].get();

			if (value == false) {
				this.element.element.css("display", "none");
			} else {
				this.element.element.css("display", "inherit");
			}
		}
	});
	kendo.data.binders.Visible = kendo.data.Binder.extend({
		refresh: function () {
			var value = this.bindings["Visible"].get();

			if (value == false) {
				this.element.css("display", "none");
			} else {
				this.element.css("display", "inherit");
			}
		}
	});

    kendo.data.binders.widget.selectedIndex = kendo.data.Binder.extend({
        previousBinder: kendo.data.binders.widget.selectedIndex,
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget, bindings, options);
            if (!this.setupTabStripPage(widget) && this.previousBinder) {
                this.refresh = this.previousBinder.prototype.refresh;
                this.destroy = this.previousBinder.proptotype.destroy;
            }
        },
        setupTabStripPage: function (widget) {
            // check if the HTML element receiving bindings is a tabpage from a tabcontrol widget
            var htmlElement = widget.element[0];
            if (htmlElement instanceof HTMLDivElement && htmlElement.getAttribute("data-role") === "tabstrip") {
                var selectedIndexBinding = this.bindings.selectedIndex;
                var busy = false;
                var updateModel = function () {
                    if (!busy)
                        try {
                            busy = true;
                            selectedIndexBinding.set(widget.select().index());
                        }
                        finally {
                            busy = false;
                        }
                };
                WebMap.Client.App.Current.addModelUpdateListener(updateModel);
                this.refresh = function () {
                    if (!busy)
                        try {
                            busy = true;
                            var selectedValue = selectedIndexBinding.get();
                            if (selectedValue == -1) {
                                widget.select(0);
                            }
                            else {
                                widget.select(selectedValue);
                            }
                        }
                        finally {
                            busy = false;
                        }
                };
                this.destroy = function () {
                    WebMap.Client.App.Current.removeModelUpdateListener(updateModel);
                };
                return true;
            }
            return false;
        }
    });

    kendo.data.binders.widget.flexGridRefresh = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {

            var binding = this.bindings["flexGridRefresh"];
            var value = binding.get();
            if (value === true) {
                try {
                    var grid = $(this.element.element.children('div')).data('kendoGrid');
                    grid.dataSource.read();
                } finally {
                    binding.set(false);
                }
            }
        }
    });


    kendo.data.binders.widget.flexGridPosition = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            var that = this;

            that.registerChange();

            this.element.bind('reconfigured', function () {
                that.registerChange();
            });
        },
        registerChange: function () {
            var that = this;
            var grid = $(this.element.element).find('div').data('kendoGrid');
            if (grid) {
                grid.bind('change', function () {
                    that.update(grid, that.bindings["flexGridPosition"]);
                    setTimeout(function () {
                        that.element.trigger("click");
                    }, 1);

                });
            }
        },
        refresh: function () {
            if (!this.innerUpdating) {
                var binding = this.bindings["flexGridPosition"];
                var grid = $(this.element.element).find('div').data('kendoGrid');
                var htmlRow = grid.tbody.children().eq(binding.get()[0] - this.rowAdjustment());
                if (htmlRow && htmlRow.length > 0) {
                    if ((grid.options && grid.options.selectable === "row")) {
                        grid.clearSelection();
                        grid.select(htmlCell);
                    } else {
                        var htmlCell = htmlRow.children('td').eq(binding.get()[1]);
                        if (htmlCell && !htmlCell.hasClass('k-state-selected')) {
                            grid.clearSelection();
                            grid.select(htmlCell);
                        }
                    }
                }
            }
        },
        update: function (grid, binding) {
            var dataItem = grid.dataItem(grid.select()) ||
                grid.dataItem($(grid.select()).parent());
            if (dataItem && dataItem.UniqueID) {
                var rowIndex = parseInt(dataItem.UniqueID.substring(0, dataItem.UniqueID.indexOf('#')));
                rowIndex = rowIndex + this.rowAdjustment();
                try {
                    this.innerUpdating = true;
                    var columnIndex =
                        (grid.options && grid.options.selectable === "row") ?
                            0 : $(grid.select()).index();
                    binding.set([rowIndex, columnIndex]);
                } finally {
                    this.innerUpdating = false;
                }
            }
        },
        rowAdjustment: function () {
            var result = 0;
            if (this.bindings['flexGridDefinition'] && this.bindings['flexGridDefinition'].get) {
                var binding = this.bindings['flexGridDefinition'];
                var columnsValue = binding.get();
                if (columnsValue &&
                    columnsValue.parent() &&
                    "FixedRowsCount" in columnsValue.parent()) {
                    result = columnsValue.parent().FixedRowsCount;
                }
            }
            return result;
        }
    });

    kendo.data.binders.widget.flexGridEndSelection = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            var that = this;
            var grid = $(element.element).find('div').data('kendoGrid');
            if (grid) {
                grid.bind('change', function () {
                    that.update(grid, that.bindings["flexGridEndSelection"]);
                });
            }
        },
        refresh: function () {
            if (!this.innerUpdating) {
                var binding = this.bindings["flexGridEndSelection"];
                var positionBinding = this.bindings["flexGridPosition"];
                if (positionBinding) {
                    if (positionBinding.get()[0] == binding.get()[0]
                        && positionBinding.get()[1] == binding.get()[1]) {
                        return;
                    }
                    var position = positionBinding.get();
                    position[0] = position[0] - this.rowAdjustment();
                    var destination = binding.get();
                    destination[0] = destination[0] - this.rowAdjustment();
                    var grid = $(this.element.element).find('div').data('kendoGrid');
                    var htmlRow = grid.tbody.children().eq(binding.get()[0]);
                    grid.clearSelection();
                    for (var y = position[1]; y <= destination[1]; y++) {
                        for (var x = position[0]; x <= destination[0]; x++) {
                            this.selectCell(x, y, grid);
                        }
                    }
                }
            }
        },
        selectCell: function (row: number, column: number, grid: any) {
            var htmlRow = grid.tbody.children().eq(row);
            if (htmlRow) {
                if ((grid.options && grid.options.selectable === "row")) {
                    grid.select(htmlCell);
                } else {
                    var htmlCell = htmlRow.children('td').eq(column);
                    if (htmlCell && !htmlCell.hasClass('k-state-selected')) {
                        grid.select(htmlCell);
                    }
                }
            }
        },
        rowAdjustment: function () {
            var result = 0;
            if (this.bindings['flexGridDefinition'] && this.bindings['flexGridDefinition'].get) {
                var binding = this.bindings['flexGridDefinition'];
                var columnsValue = binding.get();
                if (columnsValue &&
                    columnsValue.parent() &&
                    "FixedRowsCount" in columnsValue.parent()) {
                    result = columnsValue.parent().FixedRowsCount;
                }
            }
            return result;
        },
        update: function (grid, binding) {
            var dataItem = grid.dataItem(grid.select().last()) ||
                grid.dataItem($(grid.select().last()).parent());
            if (dataItem && dataItem.UniqueID) {
                var rowIndex = parseInt(dataItem.UniqueID.substring(0, dataItem.UniqueID.indexOf('#'))) + 1;
                try {
                    this.innerUpdating = true;
                    var columnIndex =
                        (grid.options && grid.options.selectable === "multiple row") ?
                            ($(grid.select().last()).children('td').length - 1) : $(grid.select().last()).index();
                    binding.set([rowIndex, columnIndex]);
                } finally {
                    this.innerUpdating = false;
                }
            }
        }
    });

    kendo.data.binders.widget.flexCellCoordinates = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            var that = this;
            var grid = $(element.element).find('div').data('kendoGrid');
            if (grid) {
                grid.bind('change', function () {
                    that.update(grid, that.bindings["flexCellCoordinates"]);
                });
            }
        },
        refresh: function () { },
        update: function (grid, binding) {
            var selected = grid.select();
            if (selected) {
                var height = Math.floor($(selected).height());
                var width = Math.floor($(selected).width());
                var pos = $(selected).position();
                binding.set([pos.left, pos.top, width, height]);
            }
        }
    });

    kendo.data.binders.widget.flexGridDefinition = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var binding = this.bindings["flexGridDefinition"];
            if (binding) {
                var that = this;
                var value = binding.get();
                if (value) {
                    value.bind('change', function () {
                        if (!that.isRefreshPending) {
                            that.isRefreshPending = true;
                            setTimeout(function () {
                                try {
                                    that.refresh();
                                    that.element.trigger('reconfigured');
                                } finally {
                                    that.isRefreshPending = false;
                                }
                            }, 1);
                        }
                    });
                }
            }
        },
        refresh: function () {

            var binding = this.bindings["flexGridDefinition"];
            var value = binding.get();
            var element = this.element.element[0];
            this.removeExistingInnerElement(element);
            this.createGridAsChild(element, binding.source, value);

        },
        transformColumnsToObj: function (cols) {
            var colsStr = [];

            for (var idx = 0; idx < cols.Items.length; idx++) {
                var colDefinition = cols.Items[idx];
                colsStr.push({
                    title: colDefinition.Text,
                    field: "RowContent[" + idx.toString() + "]",
                    width: colDefinition.Width
                });
            }
            return colsStr;
        },

        removeExistingInnerElement: function (element: any) {
            $(element).children('div').each(function (index, subeelement) {
                var existingGrid = $(subeelement).data('kendoGrid');
                if (existingGrid) {
                    existingGrid.destroy();
                    $(subeelement).remove();
                }
            });
            ///
        },
        createGridAsChild: function (element: any, source: any, columnsObject: any) {
            var that = this;
            var newElement = document.createElement("div");
            var role = document.createAttribute("data-role");
            role.value = "grid";
            var db = "source: " + $(element).attr('data-itemssource');
            var dbatt = document.createAttribute("data-bind");
            dbatt.value = db;
            newElement.setAttribute('data-role', 'grid');
            newElement.setAttribute('data-resizable', 'true');
            var pageSize = parseInt($(element).attr('data-pagesize')) || 15;

            var itemsSource = source.get($(element).attr('data-itemssource'));
            var itemsSourceUniqueId = itemsSource.UniqueID;

            var extraBindings = $(element).attr('data-gridbindings');
            if (extraBindings) {
                newElement.setAttribute('data-bind', extraBindings);
            }

            element.appendChild(newElement);
            var selectionMode = $(element).attr('data-selectionmode') || "multiple cell";

            $(newElement).kendoGrid({
                resizable: true,
                scrollable: {
                    virtual: true
                },
                selectable: selectionMode,
                //pageable: true,
                dataSource: {
                    serverPaging: true,
                    pageSize: pageSize,
                    schema: {
                        data: "data",
                        total: "total"
                    },
                    transport: {
                        read: function (options) {
                            var t = new Date();

                            $.ajax({
                                url: 'ResumeOperation/CollectiongPendingResults',
                                type: "POST",
                                headers:
                                {
                                    WM: true
                                },
                                dataType: "json",
                                data: { coluid: itemsSourceUniqueId, skip: options.data.skip, take: options.data.take },
                                success: (data: any, textStatus: string, jqXHR: JQueryXHR) => {
                                    options.success(data);
                                }
                            });
                        }
                    }
                },
                columns: this.transformColumnsToObj(columnsObject)
            });
            // setTimeout is required because the template may not be completely applied
            setTimeout(function () {
                $(element).find('.k-widget').height("100%");
                $(element).find('table').last().dblclick(function () {
                    that.element.trigger('dblclick');
                });
            }, 100);
            kendo.bind($(element).children('div'), source);
        }
    });

    //treeView MouseUp event
    kendo.data.binders.widget.mouseUpEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            customEventBinding(that, element.element, "mouseup", "mouseUpEvent");
        },
        refresh: function () { }
    });
    kendo.data.binders.widget.treeDataSource = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            // Create a new empty data source to start with
            element.setDataSource((<any>kendo).observableHierarchy([]));
            // Event handler used to synchronize checkboxes
            element.dataSource.bind('change', function (e) {
                that.syncCheckedNodes(that, e);
            });
            var treeview = $(that.element.element).data("kendoTreeView");
            // Event handler to handle children
            element.bind('change', function (e) {
                var selected = element.dataItem(element.select());
                if (selected && selected.wmid) {
                    var dataSourceBinding = that.bindings["treeDataSource"];
                    var model = dataSourceBinding.get();
                    model.set('SelectedItemId', selected.wmid);
                }
            });
            element.element.bind('click', function (e) {
                var editable = $(this).attr('data-labeledit');
                if (editable && (editable == "true")) {
                    var modelObj = e.target;
                    $(modelObj).bind('click', function () {
                        $(modelObj).prop('contentEditable', true);
                    });
                    $(modelObj).bind('blur', function () {
                        $(modelObj).removeAttr('contentEditable');
                        var binding = that.bindings["treeDataSource"];
                        var tree = binding.get();
                        var ds = that.element.dataSource.data();
                        for (var i = 0; i < tree.Items.length; i++) {
                            var modelObj = tree.Items[i];
                            var htmlElement = ds[i];
                            that.updateValues(that, modelObj, htmlElement);
                        }
                    });
                }
            });
            that.initialHeight = $(element.element).attr('data-initialheight');
            that.imageListPrefix = $(element.element).attr('data-imagelistprefix');
            that.imageIndex = $(element.element).attr('data-imageIndex');


        },
        // Updating text when the labels are edited.
        updateValues: function (that, e, treeNode) {
            if (treeNode) {
                var node = $(that.element.element).find("[data-uid='" + treeNode.uid + "']").children()[0];
                if (node) {
                    var innerSpan = $(node).find("[class*='k-in']");
                    e.set('Text', innerSpan.text());
                }
                if (e.Items)
                    for (var i = 0; i < e.Items.length; i++) {
                        this.updateValues(that, e.Items[i], treeNode.items[i]);
                    }
            }
        },
        // Updating text when the labels are edited.
        updateVisibilities: function (that, e, treeNode, parentExpanded) {
            if (treeNode) {
                e.set('IsVisible', parentExpanded);
            }
            if (e.Items)
                for (var i = 0; i < e.Items.length; i++) {
                    this.updateVisibilities(that, e.Items[i], treeNode.items[i], treeNode.expanded);
                }
        },
        // Synchronization of checkbox nodes
        syncCheckedNodes: function (that, e) {
            var binding = that.bindings["treeDataSource"];
            if (binding && binding.get()
                && (e.field === 'checked'
                    || e.field === 'selected'
                    || e.field === 'expanded'
                    || e.field === 'isVisible')
                && e.items
                && e.items.length > 0) {
                var tree = binding.get();
                var field = e.field;
                for (var i = 0; i < tree.Items.length; i++) {
                    that.syncingCheckedNodes(that, tree.Items[i], e.items, field);
                }
            }
        },

        syncingCheckedNodes: function (that, modelTreeNode, treeNodes, field) {
            for (var i = 0; i < treeNodes.length; i++) {
                var uiTreeNode = treeNodes[i];
                if (uiTreeNode.wmid === modelTreeNode.UniqueID) {
                    var ht = $(uiTreeNode).html();
                    switch (field) {
                        case "checked": { modelTreeNode.set('Checked', uiTreeNode.checked); break; }
                        case "selected": { modelTreeNode.set('IsSelected', uiTreeNode.selected); break; }
                        case "expanded": { modelTreeNode.set('IsExpanded', uiTreeNode.expanded); that.updateVisibilities(that, modelTreeNode, uiTreeNode, modelTreeNode.parent().parent().IsExpanded); break; }
                    }

                }
            }
            if (modelTreeNode && modelTreeNode.Items)
                for (var i = 0; i < modelTreeNode.Items.length; i++) {
                    this.syncingCheckedNodes(that, modelTreeNode.Items[i], treeNodes, field);
                }
        },

        createMirrorNodeFromModelNode: function (modelObj) {
            var that = this;
            var imageurl = undefined;
            if (that.imageListPrefix !== undefined)
                if (modelObj.ImageIndex != null && modelObj.ImageIndex > -1)
                    imageurl = that.imageListPrefix + '.ImageStream' + modelObj.ImageIndex + ".png";
                else if (that.imageIndex != null && that.imageIndex > -1)
                    imageurl = that.imageListPrefix + '.ImageStream' + that.imageIndex + ".png"; //Default image
            return (<any>kendo).observableHierarchy([{
                text: modelObj.Text,
                wmid: modelObj.UniqueID,
                imageUrl: imageurl,
                checked: modelObj.Checked,
                expanded: modelObj.IsExpanded,
                items: []
            }])[0];
        },

        createMirrorStructure: function (parentItemsCollection, modelObj) {
            var that = this;
            var newObj = that.createMirrorNodeFromModelNode(modelObj);
            if (parentItemsCollection.isRoot) {
                parentItemsCollection.pop();
            }
            parentItemsCollection.push(newObj);
            var element = $(that.element.element).find("[data-uid='" + newObj.uid + "']");
            var itemHeight = $(element).height();
            var dataSourceBinding = that.bindings["treeDataSource"];
            var model = dataSourceBinding.get();
            var vc = model.get('VisibleCount');
            if (!(vc && vc > 0) && (itemHeight > 0)) {
                var visibleCount = Math.floor(that.initialHeight / itemHeight);
                model.set('VisibleCount', visibleCount);
            }
            var newObj2 = parentItemsCollection[parentItemsCollection.length - 1];
            function syncItems(e) {
                if ((e.action === 'add' || e.action === undefined)
                    && newObj2.items.length < modelObj.Items.length) {
                    for (var k = newObj2.items.length; k < modelObj.Items.length; k++) {
                        var innerObj = modelObj.Items[k];
                        var newInnerObj = that.createMirrorNodeFromModelNode(innerObj);
                        that.createMirrorStructure(newObj2.items, innerObj);
                    }
                } else if (e.action == 'remove' && ('index' in e)) {
                    newObj2.items.remove(newObj2[e.index]);
                } else {
                    horizontalSyncItems();
                }
            }

            function horizontalSyncItems() {
                for (var i = 0;
                    i < newObj.items.length && i < modelObj.Items.length;
                    i++) {
                    if (newObj.items[i] && modelObj.Items[i]
                        && newObj.items[i].wmid
                        && modelObj.Items[i].UniqueID
                        && newObj.items[i].wmid !== modelObj.Items[i].UniqueID) {
                        newObj.items[i].set("wmid", modelObj.Items[i].UniqueID);
                        newObj.items[i].set("text", modelObj.Items[i].Text);
                        newObj.items[i].set("checked", modelObj.Items[i].Checked);
                        newObj.items[i].set("items", modelObj.Items[i].Items);
                    }
                }
            }

            var changeFunc = function (e) {
                var oldChangeEventHandlers = modelObj._events.change || [];
                try {
                    modelObj._events.change = [];
                    switch (e.field) {
                        case "Text":
                            {
                                newObj2.set('text', modelObj.get(e.field));
                                break;
                            }
                        case "_items":
                            {
                                if (!(e.action && (e.action === 'itemchange'))) {
                                    syncItems(e);
                                }
                                break;
                            }
                        case "Items":
                            {
                                if (!(e.action && (e.action === 'itemchange'))) {
                                    syncItems(e);
                                }
                                break;
                            }
                        case "IsExpanded":
                            {
                                newObj2.set('expanded', modelObj.get(e.field));
                                that.updateVisibilities(that, modelObj, newObj2, modelObj.parent().parent().IsExpanded);
                                break;
                            }
                        case "Checked":
                            {
                                newObj2.set('checked', modelObj.get(e.field));
                                break;
                            }
                        case "ImageIndex":
                            {
                                var imageurl = that.imageListPrefix + '.ImageStream' + modelObj.ImageIndex + ".png";
                                newObj2.set('imageUrl', imageurl);
                                break;
                            }
                        default:
                            {
                                newObj2.set(e.field, modelObj.get(e.field));
                                break;
                            }
                    }
                }
                finally {
                    //We restore the old Event Handlers
                    modelObj._events.change = oldChangeEventHandlers;
                }
            };
            modelObj.unbind('change');
            modelObj.bind('change', changeFunc);
            newObj2.changeFunc = changeFunc;

            // Add existing items if available
            if ('Items' in modelObj) {
                var itemsChangeFunc = function (e) {
                    if (e.action === "add") {
                        var idx = e.index === undefined ? 0 : e.index;
                        var innerObj = modelObj.Items[idx];
                        var newInnerObj = that.createMirrorNodeFromModelNode(innerObj);
                        that.createMirrorStructure(newObj2.items, modelObj.Items[idx])
                    }
                };
                newObj2.itemsChangeFunc = itemsChangeFunc;
                for (var k = 0; k < modelObj.Items.length; k++) {
                    this.createMirrorStructure(newObj2.items, modelObj.Items[k]);
                }
            }
        },

        refresh: function () {
            var that = this;
            var treeDataSourceBinding = this.bindings["treeDataSource"];
            var labelEdit = $(this.element.element).data("LabelEdit");
            that.labelEdit = labelEdit;
            if (treeDataSourceBinding.get()) { //Check if the binding is not undefined
                var bvalue = treeDataSourceBinding.get().Items;
                var ds = this.element.dataSource;
                var data = ds.data();
                var callRefresh = function (f) {
                    // Skip for child object property change
                    if (data.lastfiredField && f.action === "itemchange" || f.action === "add") {
                        return;
                    } else if (f.action === "remove" && ('index' in f)) {
                        data.remove(data[f.index]);
                    } else {
                        that.refresh();
                    }
                };
                // Unregister a previous version of the 'refresh' callback if exist
                // (this is needed to avoid multiple calls)
                if (data.callRefresh) {
                    bvalue.unbind('change', callRefresh);
                }
                bvalue.bind('change', callRefresh);
                // Keep a reference of the function in order to unregister it
                data.callRefresh = callRefresh;
                var oldCount = data.length;
                data.isRoot = true;
                for (var i = 0; i < bvalue.length; i++) {
                    var modelObj = bvalue[i];
                    that.createMirrorStructure(data, modelObj);
                }

            }
        }
    });

    (function ($) {
        var ui = kendo.ui,
            Widget = ui.Widget
        var wmflexgrid = Widget.extend({
            init: function (element, options) {
                Widget.fn.init.call(this, element, options);
            },
            options: {
                name: "wmflexgrid",
                itemssource: ""
            },
            events: [
                "reconfigured", "dblclick", "click"
            ]
        });

        ui.plugin(wmflexgrid);
        kendo.init($(document.body));

    })(jQuery);


    kendo.data.binders.widget.listBoxSelectedIndices = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            element.bind('change', () => {
                this.update();
            });
            element.bind('dataBound', () => {
                this.databound();
            });
        },
        refresh: function () {
            if (!this.innerUpdating) {
                this.selectionRestore(this.element.items(), this.bindings["listBoxSelectedIndices"].get());
            }
        },
        update: function () {
            try {
                this.innerUpdating = true;
                var selectedIndices = $.map(this.element.select(), item => $(item).index());
                var listBoxSelectedIndicesBinding = this.bindings["listBoxSelectedIndices"];
                $(this.element.element).trigger("clickEvent");
                if (this.options.checkOnClick) {
                    var listBox: kendo.ui.ListView = <any>$(this.element.element).data('kendoCheckedListBox');
                    var data = listBox.dataSource.data();
                    for (var i = 0; i < selectedIndices.length; i++) {
                        var _checkedStatus = data[selectedIndices[i]].get("Checked");
                        if (!_checkedStatus) {
                            var control = $(this.element.element).find("[data-uid='" + data[selectedIndices[i]].uid + "']")
                            var checkbox = $(control).find('input');
                            $(checkbox).trigger("click");
                        }
                        else {
                            var control = $(this.element.element).find("[data-uid='" + data[selectedIndices[i]].uid + "']")
                            var checkbox = $(control).find('input');
                            $(checkbox).trigger("click");

                        }
                    }
                }
                listBoxSelectedIndicesBinding.set(selectedIndices);
            } finally {
                this.innerUpdating = false;
            }
        },
        databound: function () {
            if (!this.innerUpdating) {
                this.selectionRestore(this.element.items(), this.bindings["listBoxSelectedIndices"].get());
            }
        },
        selectionRestore: (children, indices) => {
            if (indices && indices.indexOf) {
                children.each((i, element) => {
                    var isSelected = $(element).hasClass('k-state-selected');
                    var colIndex = indices.indexOf(i);
                    if (colIndex != -1 && !isSelected) {
                        $(element).addClass('k-state-selected');
                    } else if (colIndex == -1 && isSelected) {
                        $(element).removeClass('k-state-selected');
                    }
                });
            }
        }
    });


    kendo.data.binders.widget.listBoxCheckedIndices = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            var that = this;
            element.bind('dataBound', () => {
                this.databound();
            });
            element.dataSource.bind('change', function (e) {
                that.databound();
            });
        },
        databound: function () {
            if (!this.innerUpdating) {
                this.selectionRestore(this.element.items(), this.element.dataSource.data());
            }
        },
        refresh: function () {
        },
        update: function () {
        },
        selectionRestore: (children, data) => {
            children.each((i, element) => {
                var checked = data[i].Checked;
                if (checked) {
                    var checkbox = $(element).find('input');
                    if (checkbox) {
                        $(checkbox).prop("checked", "checked");
                    }
                } else if (checked) {
                    var checkbox = $(element).find('input');
                    if (checkbox)
                        checkbox.removeAttr('checked');
                }
            });
        }
    });


    export function checkedListBoxProc(element: any) {
        var listBox: kendo.ui.ListView = <any>$(element).parents('div[data-role="checkedlistbox"]').data('kendoCheckedListBox');
        var index = $(element).parent().index();
        if (listBox && index >= 0) {
            var data = listBox.dataSource.data();
            if (data && data[index]) {
                data[index].set("Checked", element.checked);
            }
            $(listBox.element).trigger("itemCheck");
        }
    }

    //CheckedListBox checkOnClick
    kendo.data.binders.widget.checkOnClick = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function () {
            var that = this;
            var value = that.bindings["checkOnClick"].get();
            this.widget.setOptions({ checkOnClick: value });
        }
    });

    //ItemCheckEvent
    kendo.data.binders.widget.ItemCheckEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            customEventBinding(that, element.element, "itemCheck", "ItemCheckEvent");
        },
        refresh: function () { }
    });


    //ClickEvent
    kendo.data.binders.widget.ClickEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            customEventBinding(that, element.element, "clickEvent", "ClickEvent");
        },
        refresh: function () { }
    });

    var lastTextBoxOnFocus = null;
    kendo.data.binders.textBoxEnter = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            $(element).bind("focusin", function (event) {
                if (document.activeElement !== lastTextBoxOnFocus) {
                    lastTextBoxOnFocus = element;
                    var binding = that.bindings["textBoxEnter"];
                    var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                    var method = binding.source.logic[methodName];
                    method.apply(binding.source, [event]);
                }
                else {
                    lastTextBoxOnFocus = null;
                }

            });
        },
        refresh: function () { }
    });

    kendo.data.binders.selectedRange = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            this.requiresUpdate = true;
            $(element).bind('focus', function (e) {
                this.requiresUpdate = false;
                var binding = that.bindings["selectedRange"];
                var bindingValue = binding.get();
                var selectionStart = bindingValue[0];
                var selectionEnd = bindingValue[1];
                that.element.setSelectionRange(selectionStart, selectionEnd);
            });
            $(element).bind('select', function (e) {
                if (this.requiresUpdate)
                    that.update();
                else
                    this.requiresUpdate = true;
            });
        },
        update: function () {
            this.requiresUpdate = false;
            var selectedRangeBinding = this.bindings["selectedRange"];
            var caret = $(this.element).caret();
            console.log("Update: " + caret.start + " " + caret.end);
            selectedRangeBinding.set([caret.start, caret.end]);
        },
        refresh: function () { },
    });


    //NumericTextBox  Value
    kendo.data.binders.widget.NumericUpDownValue = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            widget.bind('change', () => {
                this.update();
            });
        },
        update: function () {
            var that = this;
            var val = $(that.element).data("kendoNumericTextBox").value();
            that.bindings["NumericUpDownValue"].set(val);
        },
        refresh: function () {
            var that = this,
                value = that.bindings["NumericUpDownValue"].get(); //get the value from the View-Model
            $(that.element).data("kendoNumericTextBox").value(value); //update the widget
        }
    });

    //NumericTextBox Max Value
    kendo.data.binders.widget.NumericUpDownMax = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
        },
        refresh: function () {
            var that = this,
                maxValue = that.bindings["NumericUpDownMax"].get(); //get the value from the View-Model
            $(that.element).data("kendoNumericTextBox").max(maxValue); //update the widget
            var currentValue = that.bindings["NumericUpDownValue"].get(); // get the current widget value
            (maxValue < currentValue) ? $(that.element).data("kendoNumericTextBox").value(maxValue) : $(that.element).data("kendoNumericTextBox").value(currentValue);
        }
    });

    //NumericTextBox Min Value
    kendo.data.binders.widget.NumericUpDownMin = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
        },
        refresh: function () {
            var that = this,
                minValue = that.bindings["NumericUpDownMin"].get(); //get the value from the View-Model
            $(that.element).data("kendoNumericTextBox").min(minValue); //update the widget
            var currentValue = that.bindings["NumericUpDownValue"].get(); // get the current widget value
            (minValue > currentValue) ? $(that.element).data("kendoNumericTextBox").value(minValue) : $(that.element).data("kendoNumericTextBox").value(currentValue);
        }
    });

    //NumericTextBox Increment Value
    kendo.data.binders.widget.NumericUpDownIncrementVal = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
        },
        refresh: function () {
            var that = this,
                value = that.bindings["NumericUpDownIncrementVal"].get(); //get the value from the View-Model
            $(that.element).data("kendoNumericTextBox").step(value); //update the widget
        }
    });



    kendo.data.binders.widget.refreshOnChange = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.timeout = 0;
        },
        refresh: function () {
            var that = this;
            /// The following code allows use to trigger just one refresh call for a batch of 
            // updates on the same list.
            if (that.timeout === 0) {
                that.timeout = setTimeout(function () {
                    try {
                        that.element.refresh();
                    } finally {
                        that.timeout = 0;
                    }
                }, 1);
            }
        }
    });

    ////Masked Textbox Support
    //MaskedTextBox Mask 
    kendo.data.binders.widget.maskedTextBoxMask = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function () {
            var that = this;
            var oldmask = this.widget.options.mask;
            var value = that.bindings["maskedTextBoxMask"].get();
            this.widget.setOptions({ mask: value });
            if (oldmask != "")
                $(this.element).trigger("maskChanged");
        }
    });
 
    //MaskedTextBox promptChar
    kendo.data.binders.widget.maskedTextBoxPrompt = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function () {
            var that = this;
            var value = that.bindings["maskedTextBoxPrompt"].get();
            this.widget.setOptions({ promptChar: value });
        }
    });

    //MaskedTextBox TextMaskFormat
    kendo.data.binders.widget.maskedTextBoxFormat = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        applyRefresh: function () {
            var that = this;
            var maskedValue = $(that.widget.element[0]).data("kendoMaskedTextBox").value();
            var valueBind = this.bindings["maskedTexBoxValue"];
            valueBind.set(maskedValue);
        },


        refresh: function () {
            ///This binding might be called during the sucess handler of a sendAction call.
            //Remember that communication with the backend is always thru the App.sendAction function
            //the sucess handler will sync the viewmodel deltas with the client.
            //In this case if this binding is call at this time
            //we just postpone the execution because this binding will update
            //a view model and we need its dirty mark to stay in order for these changes
            //to travel back to the server
                var that = this;

            var safe = window.app.Safe;

            safe.safeExec(
            {
                    obj: that._value,
                    stage: WebMap.Client.ClientSyncronizationStage.CurrentlyUpdatingClientSide | WebMap.Client.ClientSyncronizationStage.UpdateClientSideAlmostComplete,
                    whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                    category: "requestAction",
                    action: () => setTimeout(function () { that.applyRefresh() }, 300) 
            });
            safe.safeExec(
            {
                    obj: that._value,
                    stage: WebMap.Client.ClientSyncronizationStage.NotUpdatingClientSideYet,
                    whenNotAtThatStage: WebMap.Client.SafeExecutionConditions.Ignore,
                    category: "requestAction",
                    action: ()=> that.applyRefresh()
            });
        }
    });

    //MaskedTextBox value
    kendo.data.binders.widget.maskedTexBoxValue = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
            widget.bind('change', function () {
                that.update();
            });
        },
        refresh: function () {
            var that = this;
            var value = that.bindings["maskedTexBoxValue"].get();
            that.widget.value(value);
        },
        update: function () {
            var that = this;
            var maskedTB = $(that.widget.element[0]).data("kendoMaskedTextBox");
            var value = maskedTB.value();
            that.bindings["maskedTexBoxValue"].set(value);
        }
    });

    //MaskChangedEvent
    kendo.data.binders.widget.MaskChanged = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            customEventBinding(that, element.element, "maskChanged", "MaskChanged");
        },
        refresh: function () { }
    });


    //TypeValidationEvent
    kendo.data.binders.widget.TypeValidationCompleted = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            customEventBinding(that, element.element, "change", "TypeValidationCompleted");
        },
        refresh: function () { }
    });

    //MaskInputRejected 
    kendo.data.binders.widget.MaskInputRejected = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            $(element.element).bind("keypress", function (event) {
                var binding = that.bindings["MaskInputRejected"];
                var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                var method = binding.source.logic[methodName];
                var newChar = String.fromCharCode(event.charCode);
                var position = ($(this).caret().start);
                var currentMask = that.options.mask;
                while (isLiteral(currentMask.charAt(position))) {
                    position++;
                }
                var match = maskToRegex(newChar, currentMask.charAt(position));
                if (!match) {
                    method.apply(binding.source);
                }
            });
        },
        refresh: function () { }
    });

    function maskToRegex(newChar, maskChar) {
        switch (maskChar) {
            case "0": { return newChar.match(/\d/); }
            case "9": { return newChar.match(/\d|\s/); }
            case "#": { return newChar.match(/\d|\s|\+|\-/); }
            case "&": { return newChar.match(/\S/); }
            case "?": { return newChar.match(/[a-zA-Z]|\s/); }
            case "A": { return newChar.match(/[a-zA-Z0-9]/); }
            case "C": { return newChar.match(/./); }
            case "L": { return newChar.match(/[a-zA-Z]/); }
            case "a": { return newChar.match(/[a-zA-Z0-9]|\s/); }
            default: {
                return newChar.match(new RegExp("/\\" + maskChar + "/"));
            }

        }
    }
    function isLiteral(char) {
        return char.match(/[^09#&?ACLa]/);
    }

    function customEventBinding(that, control, event, bindingName) {
        $(control).bind(event, function (event) {
            var binding = that.bindings[bindingName];
            var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
            var method = binding.source.logic[methodName];
            method.apply(binding.source, [event]);
        });
    }

    var lastFiredEvent = "";
    function widgetCustomEventBinding(that, widget, event, bindingName) {
        widget.bind(event, function (event) {
            if (lastFiredEvent !== bindingName) {
                lastFiredEvent = bindingName;
                var binding = that.bindings[bindingName];
                var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                var method = binding.source.logic[methodName];
                method.apply(binding.source);
            }
            else {
                lastFiredEvent = "";
            }
        });
    }

    ///*******************DataGridViewSupport**********************

    function createNewDataGrid(element: any, source: any, columnsObject: any, thisElement: any) {
        var dataGridContainerID = $(element).attr('id');
        var newElement = document.createElement("div");
        newElement.setAttribute('data-role', 'grid');
        var uniqueID = source[dataGridContainerID].UniqueID;
        newElement.setAttribute('data-resizable', 'true');
        var newElementID = uniqueID + "_innerGrid";
        newElement.setAttribute('id', newElementID);
        var initialHeight = $(element).attr('data-initialheight');
        var addRows = $(element).attr('data-addRows');
        var db = ''; //Empty source used in case an initialized dataSource was passed.
        var dataSource: any;
        var useDataSource = $(element).data('datasource');
        if (!useDataSource) {
            db = $(element).attr('data-itemssource');
        }
        else {
            dataSource = getDataSource(uniqueID);
        }
        if (initialHeight !== undefined) {
            newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
        }
        var selectionMode = $(element).data('selectionmode');
        var kendoSelectionMode = "";
        switch ("" + selectionMode) {
            case "CellSelect":
                kendoSelectionMode = "multiple, cell";
                break;
            case "FullRowSelect":
                kendoSelectionMode = "multiple, row";
                break;
            case "RowHeaderSelect":
                kendoSelectionMode = "multiple, cell";
                break;
            default:
                kendoSelectionMode = "multiple, cell";
                break;
        }
        var allowReorder = Boolean($(element).data('allowreorder')) === true ? true : false;
        var edit = thisElement.bindings["DataGridEditable"].get();
        var addNewRows = thisElement.bindings["DataGridAddRows"];
        var cellClickEvent = $(element).attr('data-cellClickEvent');
        if (cellClickEvent) {
            db += ",events: { change: " + cellClickEvent + " }";
        }
        newElement.setAttribute('data-bind', db + "," + addRows);
        element.appendChild(newElement);
        $(newElement).kendoGrid({
            resizable: true,
            scrollable: true,
            columns: columnsObject,
            reorderable: allowReorder,
            selectable: kendoSelectionMode,
            editable: !edit,
            pageable: true,
            sortable: true,
            dataSource: dataSource
        });

        $(newElement).data('kendoGrid').dataSource.bind('change', function (e) {
            setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 10); //Removes the dirty flag
            //window.app.sendAction({ controller: "ResumeOperation", action: "DataGridViewSyncVals", parameters: { "uniqueID": uniqueID }});
            window.app.log('changed');
        });
        if (addNewRows && addNewRows.get()) {
            AddRowToolbar(newElement, addNewRows);
        }
        kendo.bind($(element).children('div'), source);
    }


    function getDataSource(uniqueID) {
        return {
            pageSize: 10,
            transport: {
                read: {
                    url: "GridDatasource/GetDataSource?gridUid=" + encodeURIComponent(uniqueID),
                    dataType: "json",
                    contentType: "application/json"
                }
            },
            schema: {
                data: "data",
                total: "total"
            },
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        };
    }

    //DataGridColumns Value
    kendo.data.binders.widget.DataGridColumns = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var binding = this.bindings["DataGridColumns"];
            if (binding) {
                var that = this;
                var value = binding.get();
                if (value) {
                    value.bind('change', function () {
                        that.refresh();
                    });
                }
            }
        },
        refresh: function () {
            var that = this;
            var binding = this.bindings["DataGridColumns"];
            var value = binding.get(); //get the value from the View-Model
            var columnsObj = transformColumnsToObj(value, this);
            var element = this.element;
            removeExistingListViewInnerElement(element);
            createNewDataGrid(element, binding.source, columnsObj, this);
        }
    });


    //DataGrid ReadOnly
    kendo.data.binders.widget.DataGridEditable = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function () {
            var that = this;
            var value = that.bindings["DataGridEditable"].get();
            var gridDiv = $(this.element).children('div');
            $(gridDiv).data('kendoGrid').options.editable = !value;
        }
    });

    //DataGridViewDataSource
    kendo.data.binders.widget.DataSourceVersion = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function (e) {
            var that = this;
            var value = that.bindings["DataSourceVersion"].get();
            if (value > 0)
                $(this.element).data("datasource", true);

        },
        update: function () {
        }
    });

    //DataGridAddRows
    kendo.data.binders.widget.DataGridAddRows = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;

        },
        refresh: function () {

        }
    });


    //DataGridDeleteRows
    kendo.data.binders.widget.DataGridDeleteRows = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function (e) {
        },
        update: function () {
        }
    });

    function deleteRecords(event) {
        var row = $(event.currentTarget).closest("tr");
        var gridDiv = row.closest('div').parent();
        var dataGridID = gridDiv.attr('id').substring(0, gridDiv.attr('id').indexOf('_'));
        var dialogResult = dataGridID + '@' + row.index();
        window.app.sendAction({ controller: "ResumeOperation", action: "DataGridViewDeleteRow", parameters: { "uniqueID": dataGridID, "rowIndex": row.index() } });
    }

    function AddRowToolbar(gridDiv, binding) {
        $(gridDiv).data('kendoGrid').options.toolbar = ['create'];

        setTimeout(function () {
            var addButton = $(gridDiv).find('.k-header .k-grid-add');
            addButton.removeClass('k-grid-add');//Remove Original addRow Code
            addButton.removeAttr('href');
            addButton.on('click', function () {
                var dataGridName = binding.path.substring(0, binding.path.indexOf('.'));
                var vmobj = binding.source[dataGridName] as IStateObject;
                window.app.sendAction({ mainobj: vmobj, controller: "ResumeOperation", action: "DataGridViewAddNewRow", uniqueID: vmobj.UniqueID });

            });
        }, 100);
    }


    (function ($) {
        var ui = kendo.ui,
            Widget = ui.Widget
        var WMGrid = Widget.extend({
            init: function (element, options) {
                Widget.fn.init.call(this, element, options);
            },
            options: {
                name: "WMGrid",
                mode: 1
            }
        });

        ui.plugin(WMGrid);
        kendo.init($(document.body));

    })(jQuery);

    /*********************** Component One TrueDBGrid ************************/
    function createNewTrueDBGrid(element: any, source: any, columnsObject: any, thisElement: any) {
        var dataGridContainerID = $(element).attr('id');
        var newElement = document.createElement("div");
        newElement.setAttribute('data-role', 'grid');
        var uniqueID = source[dataGridContainerID].UniqueID;
        newElement.setAttribute('data-resizable', 'true');
        var newElementID = uniqueID + "_innerGrid";
        newElement.setAttribute('id', newElementID);
        var initialHeight = $(element).attr('data-initialheight');
        var addRows = $(element).attr('data-addRows');
        var db = ''; //Empty datasource used in case an initialized dataSource was passed.
        var selectIndices = $(element).attr('data-selectedindices');
        if (selectIndices)
            db += "," + selectIndices;
        var dataSource: any;
        dataSource = getDataSource(uniqueID);
        var dblclickhandler = $(element).attr('data-doubleClickEvent');
        if (dblclickhandler) {
            db = db + ",listViewDoubleClick: " + dblclickhandler;
        }
        var headClickEvent = $(element).attr('data-headclickevent');
        if (headClickEvent) {
            db = db + ",trueDBGridHeadClick: " + headClickEvent;
            var colIndexBinding = $(element).attr('data-columnIndex');
            db += ",trueDBColumnIndex: " + colIndexBinding;
        }
        if (initialHeight !== undefined) {
            newElement.setAttribute('style', 'height: ' + initialHeight + 'px');
        }
        var splits = thisElement.bindings["gridSplits"].get();
        var selectionMode = splits[0].MarqueeStyle;
        var kendoSelectionMode: string | boolean;
        switch (selectionMode) {
            case 0:
                kendoSelectionMode = "multiple, row";
                break;
            case 1:
                kendoSelectionMode = "multiple, cell";
                break;
            case 2:
                kendoSelectionMode = false;
                break;
            default:
                kendoSelectionMode = "multiple, row";
                break;
        }
        var allowReorder = Boolean($(element).data('allowreorder')) === true ? true : false;
        var edit = thisElement.bindings["trueDBGridAllowUpdate"].get();
        var cellClickEvent = $(element).attr('data-cellClickEvent');
        var clickEvent = $(element).attr('data-click');
        var events = "";
        var beforeColEdit = $(element).attr('data-beforeColEdit');
        if (beforeColEdit) {
            db += ",trueDBBeforeColEdit: " + beforeColEdit;
        }
        if (clickEvent) {
            db += ",trueDBClickEvent: " + clickEvent;
        }
        if (cellClickEvent) {
            events += ",trueDBClickEvent: " + cellClickEvent;
        }
        var rowColChangeEvent = $(element).attr('data-rowColChange');
        if (rowColChangeEvent) {
            db += ",trueDBRowColChangeEvent: " + rowColChangeEvent;
        }
        var selChangeEvent = $(element).attr('data-selChangeEvent');
        if (selChangeEvent) {
            db += ",trueDBSelChangeEvent: " + selChangeEvent;
        }
        if (events !== "") {
            db += ",events: { " + events + " }";
        }
       
        if (addRows)
            db += "," + addRows;

        newElement.setAttribute('data-bind', db);
        element.appendChild(newElement);
        var kendoPageable = true;
        var isPageable = $(element).attr('data-pageable');
        if (isPageable && isPageable === "false") {
            kendoPageable = false;
        }
        $(newElement).kendoGrid({
            resizable: true,
            scrollable: true,
            navigatable: true,
            pageable: kendoPageable,
            sortable: true,
            columns: columnsObject,
            reorderable: allowReorder,
            selectable: kendoSelectionMode,
            editable: edit,
            dataSource: dataSource,
            save: function (e) {
                var columnKey = Object.keys(e.values)[0];
                var value = e.values[columnKey];
                window.app.sendAction({
                    controller: "GridDatasource",
                    action: "UpdateDataSourceRecord",
                    parameters: {
                        "uniqueID": uniqueID,
                        "rowIndex": e.model["RecordSetIndex"],
                        "columnIndex": e.container.index(),
                        "value": value
                    }
                });
                setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 1000);
            }
        });
        $(newElement).data('kendoGrid').dataSource.bind('change', function (e) {
            setTimeout(function () { $(newElement).find(".k-dirty").removeClass("k-dirty"); }, 10); //Removes the dirty flags
        });
        $(newElement).on("change", "input.chkbx", function (e) {
            var grid = $(newElement).data("kendoGrid"),
                dataItem = grid.dataItem($(e.target).closest("tr"));
            var colIndex = $(e.target).closest("td").index();
            dataItem.set("ItemContent[" + colIndex + "]", this.checked ? "True" : "False");
        });
        kendo.bind($(element).children('div'), source);
    }

    function ColumnsConverter(cols, thisElement) {
        var colsStr = [];
        var totalwidth = 0;
        var bindingSplits = thisElement.bindings["gridSplits"];
        var splits;
        if (bindingSplits) {
            splits = bindingSplits.get();
        }
        for (var idx = 0; idx < cols.length; idx++) {
            var colDefinition = cols[idx];
            if (jQuery.isFunction(cols[idx])) {
                colDefinition = cols[idx]();
            }
            if (splits) {
                var designerwidth = splits[0].DisplayColumns._items[idx].Width;
                var extendRightColumn = splits[0].ExtendRightColumn;
                if (extendRightColumn && idx === cols.length - 1) {
                    var gridWidth = $(thisElement.element).width();
                    designerwidth = gridWidth - totalwidth;
                }
                var visible = splits[0].DisplayColumns._items[idx].Visible;
                var locked = splits[0].DisplayColumns._items[idx].Locked;
                var width = designerwidth ? designerwidth : 65;
                totalwidth += width;
                var columnAlignment = getKendoAlignment(colDefinition.HorizontalAlignment);
                var checkboxColumn = colDefinition.ValueItems.Presentation === 0;
                if (checkboxColumn) {
                    var itemContent = "ItemContent[" + idx.toString() + "]";
                    colsStr.push(
                        {
                            field: itemContent,
                            title: colDefinition.Caption ? colDefinition.Caption : " ",
                            template: '<input type="checkbox" #=' + itemContent + ' == "True" ? checked="checked" : "" # class="chkbx"></input>',
                            sortable: false,
                            width: 25
                        });
                }
                else {
                    colsStr.push({
                        title: colDefinition.Caption ? colDefinition.Caption : " ",
                        field: "ItemContent[" + idx.toString() + "]",
                        format: colDefinition.NumberFormat,
                        attributes: {
                            style: "text-align: " + columnAlignment
                        },
                        headerAttributes: {
                            style: "text-align: " + columnAlignment
                        },
                        width: width,
                        hidden: !visible,
                        editor: locked ? ReadOnlyEditor : '',
                    });
                }
            }
        }
        var deleteRows = thisElement.bindings["DataGridDeleteRows"];
        if (deleteRows) {
            var value = deleteRows.get();
            if (value) {
                colsStr.push({
                    command: [{
                        name: 'deleteRecord',
                        text: 'Delete Record',
                        click: trueDBDeleteRecord,
                        imageClass: "ui-icon ui-icon-close",
                    }],
                    width: "100px"
                });
            }
        }

        return colsStr;
    }


    function trueDBDeleteRecord(event) {
        var row = $(event.currentTarget).closest("tr");
        var gridDiv = row.closest('div').parent();
        var rowData = $(gridDiv).data('kendoGrid').dataItem(row);
        var dataGridID = gridDiv.attr('id').substring(0, gridDiv.attr('id').indexOf('_'));
        window.app.sendAction({ controller: "GridDatasource", action: "DeleteRecord", parameters: { "uniqueID": dataGridID, "rowIndex": rowData["RecordSetIndex"] } });
    }

    //Splits value
    kendo.data.binders.widget.gridSplits = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function (e) {
        },
        update: function () {
        }
    });


    //trueDBGridHeadClick
    kendo.data.binders.widget.trueDBGridHeadClick = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            $(element.element).find("th[role='columnheader']").bind("click", function (event) {
                var binding = that.bindings["trueDBGridHeadClick"];
                var colIndex = that.bindings["trueDBColumnIndex"];
                var index = $(event.target).closest("th").index();
                colIndex.set(index);
                var methodName = binding.path.substring((binding.path.indexOf('.') + 1));
                var method = binding.source.logic[methodName];
                method.apply(binding.source);
            });
        },
        refresh: function () { }
    });

    //ColumnIndex
    kendo.data.binders.widget.trueDBColumnIndex = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () { }
    });

    //RowColChangeEvent
    kendo.data.binders.widget.trueDBRowColChangeEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            widgetCustomEventBinding(that, element, "change", "trueDBRowColChangeEvent");
        },
        refresh: function () { }
    });


    //BeforeColEdit
    kendo.data.binders.widget.trueDBBeforeColEdit = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            widgetCustomEventBinding(that, element, "edit", "trueDBBeforeColEdit");
        },
        refresh: function () { }
    });

    //SelChangeEvent
    kendo.data.binders.widget.trueDBSelChangeEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            widgetCustomEventBinding(that, element, "change", "trueDBSelChangeEvent");
        },
        refresh: function () { }
    });

    //ClickEvent
    kendo.data.binders.widget.trueDBClickEvent = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            var that = this;
            widgetCustomEventBinding(that, element, "change", "trueDBClickEvent");
        },
        refresh: function () { }
    });

    //DataGridColumns Columns
    kendo.data.binders.widget.trueDBGridColumns = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var binding = this.bindings["trueDBGridColumns"];
            if (binding) {
                var that = this;
                var value = binding.get();
                if (value) {
                    value.bind('change', function () {
                        that.refresh();
                    });
                }
            }
        },
        refresh: function () {
            var that = this;
            var binding = this.bindings["trueDBGridColumns"];
            var value = binding.get(); //get the value from the View-Model
            var columnsObj = ColumnsConverter(value, this);
            var element = this.element;
            removeExistingListViewInnerElement(element);
            createNewTrueDBGrid(element, binding.source, columnsObj, this);
        }
    });


    //DataSourceVersion
    kendo.data.binders.widget.TrueDBDataSourceVersion = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
        },
        refresh: function () {
            var that = this;
            var binding = that.bindings["TrueDBDataSourceVersion"];
            if (binding.get()) {
                var value = that.bindings["trueDBGridColumns"].get();
                var columnsObj = ColumnsConverter(value, this);
                var element = this.element;
                that.bindings["TrueDBDataSourceVersion"].set(false);
                removeExistingListViewInnerElement(element);
                createNewTrueDBGrid(element, binding.source, columnsObj, this);
            }
        }
    });

    //TrueDBGrid AllowUpdateBinding
    kendo.data.binders.widget.trueDBGridAllowUpdate = kendo.data.Binder.extend({
        init: function (widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);
            var that = this;
            this.widget = widget;
        },
        refresh: function () {
            var that = this;
            var value = that.bindings["trueDBGridAllowUpdate"].get();
            var gridDiv = $(this.element).children('div');
            $(gridDiv).data('kendoGrid').options.editable = value;
        }
    });

    var lastTrueDBGridSelectedCell;
    //TrueDBgrid SelectedIndices
    kendo.data.binders.widget.trueDBGridSelectedRows = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
            this.innerUpdating = false;
            element.bind('change', (e) => {
                var currentSelection = e.sender.select().attr('data-uid');
                if (currentSelection !== lastTrueDBGridSelectedCell)
                    this.update();
                lastTrueDBGridSelectedCell = currentSelection;
            });

        },
        refresh: function () {
            if (!this.innerUpdating) {
                var selectedIndexBinding = this.bindings["trueDBGridSelectedRows"];
                var newIndex = selectedIndexBinding.get();
                var grid = this.element.element;
                if (grid)
                    grid = grid[0];
                else
                    grid = this.element[0];
                var items = null;
                var kendoData = $(grid).data('kendoGrid');
                if (kendoData) {
                    var isPageableGrid = kendoData.options.pageable;
                    var pageAdjustment = isPageableGrid ? ((kendoData.dataSource.page() - 1) * kendoData.pager.pageSize()) : 0;
                    var selectionMode = kendoData ? kendoData.options.selectable : "row";
                    if (selectionMode !== "multiple, cell") {
                        items = $(grid).find("[class='k-grid-content']").find('tr');
                        newIndex = newIndex.map((i) => { return i - pageAdjustment });
                        this.rowSelectionRestore(items, newIndex);
                    } else {
                        items = $(grid).find("[class='k-grid-content']").find('tr');
                        this.cellSelectionRestore(items, newIndex);
                    }
                }
            }
        },
        update: function () {
            var grid = this.element.element;
            var innerID = $(this.element.element).attr("id");
            var uniqueID = innerID.substring(0, innerID.indexOf("_innerGrid"));
            var gridData = $(grid).data('kendoGrid');
            var selectionMode = gridData.options.selectable;
            if (grid)
                grid = grid[0];
            else
                grid = this.element[0];
            var items = null;
            items = $(grid).find("[class='k-grid-content']").find('tr');
            var isPageableGrid = gridData.options.pageable;
            var pageAdjustment = isPageableGrid ? ((gridData.dataSource.page() - 1) * gridData.pager.pageSize()) : 0;
            var newIndices: number[] = [];
            if (selectionMode !== "multiple, cell") {
                items.each((i, item) => {
                    var isSelected = $(item).hasClass('k-state-selected');
                    if (typeof isSelected !== typeof undefined && isSelected !== false) {
                        newIndices.push(i + pageAdjustment);
                    }
                });
            } else {
                items.each((i, item) => {
                    var cell = $(item).children('.k-state-selected');
                    if (cell && cell.length > 0) {
                        newIndices.push(i, $(cell).index());
                        return false;
                    }
                });
            }
            this.bindings["trueDBGridSelectedRows"].set(newIndices);
            this.innerUpdating = false;
            if (newIndices.length > 0)
                window.app.sendAction({ controller: "GridDatasource", action: "UpdateRecordSet", parameters: { "uniqueID": uniqueID, "selectedRow": newIndices[0] } });

        },
        destroy: function () {
            (<any>kendo.data.Binder.fn).destroy.call(this);
            this.element.unbind('dblclick');

        },
        rowSelectionRestore: (children, indices) => {
            if (indices) {
                children.each((i, element) => {
                    var colIndex = indices.indexOf(i);
                    if (colIndex != -1) {
                        $(element).addClass('k-state-selected');
                        $(element).attr('selected', 'true');

                    } else if (colIndex == -1) {
                        $(element).removeClass('k-state-selected');
                        $(element).removeAttr('selected');

                    }
                });
            }
        },
        cellSelectionRestore: (children, indices) => {
            if (indices) {
                children.each((i, element) => {
                    if (indices.length > 0 && indices[0] === i) {
                        var cell = $(element).children("td")[indices[1]];
                        if (cell) {
                            $(cell).addClass('k-state-selected');
                            $(cell).attr('selected', 'true');
                        }
                        return false;
                    }
                    else if (indices.length > 0 && indices[0] === i) {
                        $(element).children().removeClass('k-state-selected');
                        $(element).children().removeAttr('selected');

                    }
                });
            }
        }
    });

    //// Widget definition
    (function ($) {
        var ui = kendo.ui,
            Widget = ui.Widget
        var WMGrid = Widget.extend({
            init: function (element, options) {
                Widget.fn.init.call(this, element, options);
            },
            options: {
                name: "truedbgrid",
                mode: 1
            }
        });

        ui.plugin(WMGrid);
        kendo.init($(document.body));

    })(jQuery);


    /////////////////
    /// Context Menu
    /////////////
    kendo.data.binders.widget.contextMenu = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var that = this;
            var parentForm = $(this.element).parents('form');
            var contextMenuId = that.bindings["contextMenu"].path.split(".")[1];
            var parentMenu = $('#' + contextMenuId).data("kendoContextMenu");
            parentMenu.setOptions({ filter: '.' + contextMenuId + 'Enabled' });
        }
    });

    kendo.data.binders.widget.contextMenuShow = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var that = this;
            var getShowValue = that.bindings["contextMenuShow"].get();
            if (getShowValue && getShowValue[0]) {
                var contextMenu = $(that.element.element).data("kendoContextMenu");
                contextMenu.open(getShowValue[2], getShowValue[3]);
                $(contextMenu.element).parent().css('z-index', 2147483647);//fix ContextMenu appears behind windows.
            }
        }
    });
    //////////
    /// Widget Style
    ///////////
    function getValue(obj, path) {
        for (var i = 0, path = path.split('.'), len = path.length; i < len; i++) {
            if (!obj || obj[path[i]] === undefined) return undefined;
            obj = obj[path[i]];
        };
        return obj;
    }
    //Style Custom binding 
    kendo.data.binders.widget.style = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            (<any>kendo.data.Binder.fn).init.call(this, element, bindings, options);
        },
        refresh: function () {
            var self = this;
            var binding = self.bindings["style"];
            Object.keys(binding).forEach((key) => {
                var source = binding[key].source;
                var cssValPath = binding[key].path;
                if (source && cssValPath) {
                    var value = getValue(source, cssValPath);
                    if (value) {
                        $(this.element.element).css(key, value);
                    }
                }
            }, self);
        }
    });

}