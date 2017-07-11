/// <reference path="helpers/webmap.d.ts"/>
/// <reference path="helpers/kendo.webmap.d.ts"/>
/// <reference path="helpers/require.d.ts"/>
/// <reference path="helpers/jquery.d.ts" />

define("TFDIncident.frmMain", ["files/text!views/TFDIncident.frmMain.html", "files/css!views/TFDIncident.frmMain.css", "usercontrols/UpgradeHelpers_Gui_ShapeHelper"],
    (htmlTemplate) => {
        return class frmMain extends Mobilize.WebMap.Kendo.Ui.KendoView {
            constructor(model: Mobilize.Contract.Core.IModel) {
                super(model);
                this.templateString = htmlTemplate;
                this.onPostLoad = this.loaded;
            }

            public bindings() {
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
            }


            public get name() {
                return "frmMain";
            }

            public loaded() {

            }



            public frmMain_Close(e: any) {

                if (e.userTriggered) {
                    window.app.sendAction({ mainobj: this, controller: "frmMain", action: "frmMain_Close" });
                    e.preventDefault();
                }

            }

            public sprUnitList_DoubleClick(sender: frmMain, action: string, e: any) {
                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
            }

            public sprIncident_DoubleClick(sender: frmMain, action: string, e: any) {
                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));
            }
           
            public MainTabs_Selecting(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSysButt3_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public loadSpread(name: string) {
                var uniqueId = this.model.UniqueID;
                require(["spread"], (spread) => {
                    spread(name, uniqueId);
                });
            }
            public calUnit_DateChanged(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public optBattalion_CheckedChanged(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, { "index": $(e.srcElement || e.target || e.sender.element).attr("index") || $(e.target.parentElement).attr("index") }));

            }
            public cboUnit_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboUnit_Leave(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboType_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboType_Leave(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdClearUnit_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboStatus_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboStatus_Leave(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdExitApp_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRefreshUnit_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            //public cmdRefreshIncident_Click(sender: frmMain, action: string, e: any) {

            //    return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));            

            //}
            public calIncident_DateChanged(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncUnit_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncType_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboIncType_Leave(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdClearIncident_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdExit2_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdRefreshIncList_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboFieldReport_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboSelection1_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboSelection2_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdViewReport_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInquiryList_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboInquiryList_Leave(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboReportList_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstFields_SelectedIndexChanged(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public lstFilters_SelectedIndexChanged(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdView_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdClearSelections_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cboSystemAction_SelectionChangeCommitted(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public tvHelpList_AfterSelect(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSysButt1_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }
            public cmdSysButt2_Click(sender: frmMain, action: string, e: any) {

                return sender.invoke(new Mobilize.Ui.Command.Send(sender, action, null));

            }

        }

    });

