/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
define("TFDIncident.frmMain", ["files/text!views/TFDIncident.frmMain.html", "files/css!views/TFDIncident.frmMain.css", "usercontrols/UpgradeHelpers_Gui_ShapeHelper"], function (htmlTemplate) {
    return (function (_super) {
        __extends(frmMain, _super);
        function frmMain(model) {
            var _this = _super.call(this, model) || this;
            _this.templateString = htmlTemplate;
            _this.onPostLoad = _this.loaded;
            return _this;
        }
        frmMain.prototype.bindings = function () {
            this.bind("MainTabs_Selecting", this.MainTabs_Selecting);
            this.bind("cmdSysButt3_Click", this.cmdSysButt3_Click);
            this.bind("calUnit_DateChanged", this.calUnit_DateChanged);
            this.bind("optBattalion_CheckedChanged", this.optBattalion_CheckedChanged);
            this.bind("cboUnit_SelectionChangeCommitted", this.cboUnit_SelectionChangeCommitted);
            this.bind("cboUnit_Leave", this.cboUnit_Leave);
            this.bind("cboType_SelectionChangeCommitted", this.cboType_SelectionChangeCommitted);
            this.bind("cboType_Leave", this.cboType_Leave);
            this.bind("cmdClearUnit_Click", this.cmdClearUnit_Click);
            this.bind("cboStatus_SelectionChangeCommitted", this.cboStatus_SelectionChangeCommitted);
            this.bind("cboStatus_Leave", this.cboStatus_Leave);
            this.bind("cmdExitApp_Click", this.cmdExitApp_Click);
            this.bind("cmdRefreshUnit_Click", this.cmdRefreshUnit_Click);
            //this.bind("cmdRefreshIncident_Click",this.cmdRefreshIncident_Click);
            this.bind("calIncident_DateChanged", this.calIncident_DateChanged);
            this.bind("cboIncUnit_SelectionChangeCommitted", this.cboIncUnit_SelectionChangeCommitted);
            this.bind("cboIncType_SelectionChangeCommitted", this.cboIncType_SelectionChangeCommitted);
            this.bind("cboIncType_Leave", this.cboIncType_Leave);
            this.bind("cmdClearIncident_Click", this.cmdClearIncident_Click);
            this.bind("cmdExit2_Click", this.cmdExit2_Click);
            this.bind("cmdRefreshIncList_Click", this.cmdRefreshIncList_Click);
            this.bind("cboFieldReport_SelectionChangeCommitted", this.cboFieldReport_SelectionChangeCommitted);
            this.bind("cboSelection1_SelectionChangeCommitted", this.cboSelection1_SelectionChangeCommitted);
            this.bind("cboSelection2_SelectionChangeCommitted", this.cboSelection2_SelectionChangeCommitted);
            this.bind("cmdViewReport_Click", this.cmdViewReport_Click);
            this.bind("cboInquiryList_SelectionChangeCommitted", this.cboInquiryList_SelectionChangeCommitted);
            this.bind("cboInquiryList_Leave", this.cboInquiryList_Leave);
            this.bind("cboReportList_SelectionChangeCommitted", this.cboReportList_SelectionChangeCommitted);
            this.bind("lstFields_SelectedIndexChanged", this.lstFields_SelectedIndexChanged);
            this.bind("lstFilters_SelectedIndexChanged", this.lstFilters_SelectedIndexChanged);
            this.bind("cmdView_Click", this.cmdView_Click);
            this.bind("cmdClearSelections_Click", this.cmdClearSelections_Click);
            this.bind("cboSystemAction_SelectionChangeCommitted", this.cboSystemAction_SelectionChangeCommitted);
            this.bind("tvHelpList_AfterSelect", this.tvHelpList_AfterSelect);
            this.bind("cmdSysButt1_Click", this.cmdSysButt1_Click);
            this.bind("cmdSysButt2_Click", this.cmdSysButt2_Click);
            this.bind("sprUnitList_DoubleClick", this.sprUnitList_DoubleClick);
            this.bind("sprIncident_DoubleClick", this.sprIncident_DoubleClick);
            //this.bindCloseEvent();
        };
        Object.defineProperty(frmMain.prototype, "name", {
            get: function () {
                return "frmMain";
            },
            enumerable: true,
            configurable: true
        });
        frmMain.prototype.loaded = function () {
        };
        frmMain.prototype.frmMain_Close = function (e) {
            if (e.userTriggered) {
                window.app.sendAction({ mainobj: this, controller: "frmMain", action: "frmMain_Close" });
                e.preventDefault();
            }
        };
        frmMain.prototype.sprUnitList_DoubleClick = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.sprIncident_DoubleClick = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.MainTabs_Selecting = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdSysButt3_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.loadSpread = function (name) {
            var uniqueId = this.model.UniqueID;
            require(["spread"], function (spread) {
                spread(name, uniqueId);
            });
        };
        frmMain.prototype.calUnit_DateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.optBattalion_CheckedChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));
        };
        frmMain.prototype.cboUnit_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboUnit_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdClearUnit_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboStatus_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboStatus_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdExitApp_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdRefreshUnit_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        //public cmdRefreshIncident_Click(sender: frmMain, action: string, e: any) {
        //    return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            
        //}
        frmMain.prototype.calIncident_DateChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboIncUnit_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboIncType_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboIncType_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdClearIncident_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdExit2_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdRefreshIncList_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboFieldReport_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboSelection1_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboSelection2_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdViewReport_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboInquiryList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboInquiryList_Leave = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboReportList_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.lstFields_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.lstFilters_SelectedIndexChanged = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdView_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdClearSelections_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cboSystemAction_SelectionChangeCommitted = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.tvHelpList_AfterSelect = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdSysButt1_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        frmMain.prototype.cmdSysButt2_Click = function (sender, action, e) {
            return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
        };
        return frmMain;
    }(Mobilize.WebMap.Kendo.Ui.KendoView));
});
//# sourceMappingURL=TFDIncident.frmMain.js.map