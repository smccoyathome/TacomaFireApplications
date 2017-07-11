using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmImmunizationQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmImmunizationQuery));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmImmunizationQuery_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//Immunization Query Screen
		//   Filtered by Battalion/Shift/Unit
		//   Date Range, Immunization Type,
		//   Assignment Group (HZM, PM, REG, CIV, VOL, etc)
		//   Employee Name (like statement)
		//
		//*************************************************************

		public void RefreshEmployeeList()
		{
			PTSProject.clsEMSInformation cImmune = Container.Resolve< clsEMSInformation>();
			int iType = 0;
			int iFlag = 0;
			string sText = "";

			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.SkipLogic)
			{
				return;
			}

			int CurrRow = 0;
			ViewModel.sprReport.MaxRows = 500;

			string sStartDate = DateTime.Parse(ViewModel.dtStart.Text).ToString("M/d/yyyy");
			string sEndDate = DateTime.Parse(ViewModel.dtEnd.Text).AddDays(1).ToString("M/d/yyyy");
			ViewModel.sHeadingFilter = "Displaying ";

			string sName = modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary));

			if ( ViewModel.chkNotReceived.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				iFlag = 0;
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Immunization NotReceived; ";
			}
			else
			{
				iFlag = 1;
			}

			if ( ViewModel.CurrBatt != "")
			{
				if ( ViewModel.CurrShift != "")
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Batt\\Shift= " + ViewModel.CurrBatt + "\\" + ViewModel.CurrShift + "; ";
				}
			}
			else if ( ViewModel.CurrShift != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Shift= " + ViewModel.CurrShift + "; ";
			}

			if (modGlobal.Clean(ViewModel.CurrUnit) != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Unit = " + modGlobal.Clean(ViewModel.CurrUnit) + "; ";
			}

			if (modGlobal.Clean(ViewModel.CurrGroup) != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Assignment Group = " + modGlobal.Clean(ViewModel.CurrGroup) + "; ";
			}
			ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "from " + sStartDate + " To " + sEndDate + "; ";

			if ( ViewModel.cboType.ListIndex == -1)
			{
				iType = 0;
			}
			else
			{
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboType.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				iType = ViewModel.cboType.ItemData(ViewModel.cboType.ListIndex);
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.cboType.Text + "; ";
			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.ClearRange(1, 1, ViewModel.sprReport.MaxCols, ViewModel.sprReport.MaxRows, false);

			if (cImmune.GetImmunizationQueryResults(ViewModel.CurrBatt, ViewModel.CurrUnit, ViewModel.CurrShift, ViewModel.CurrGroup, sName, iType, sStartDate, sEndDate, iFlag) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There were no rows returned.  Try changing your options.", "Immunization Query", UpgradeHelpers.Helpers.BoxButtons.OK);

				return;
			}


			while(!cImmune.EMSPersonnelImmunizations.EOF)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["name_full"]);
				ViewModel.sprReport.Col = 2;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["shift_code"]);
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["unit_code"]);
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["battalion_code"]);
				ViewModel.sprReport.Col = 5;
				ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["immunize_type"]);

				//cell note
				sText = "";
				if (modGlobal.Clean(cImmune.EMSPersonnelImmunizations["created_date"]) != "")
				{
					sText = "Record created on " +
					        Convert.ToDateTime(cImmune.EMSPersonnelImmunizations["created_date"]).ToString("M/d/yyyy") + " ";
					ViewModel.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprReport.Col = 5;
					ViewModel.sprReport.CellNoteIndicator = true;
					if (modGlobal.Clean(cImmune.EMSPersonnelImmunizations["CreatedBy"]) != "")
					{
						sText = sText + "by " + modGlobal.Clean(cImmune.EMSPersonnelImmunizations["CreatedBy"]);
					}
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprReport.CellNote = modGlobal.Clean(sText);
				}
				ViewModel.sprReport.Col = 6;
				if (modGlobal.Clean(cImmune.EMSPersonnelImmunizations["immunize_date"]) != "")
				{
					ViewModel.sprReport.Text = Convert.ToDateTime(cImmune.EMSPersonnelImmunizations["immunize_date"]).ToString("MM/dd/yyyy");
				}
				else
				{
					ViewModel.sprReport.Text = "";
				}
				ViewModel.sprReport.Col = 7;
				if (modGlobal.Clean(cImmune.EMSPersonnelImmunizations["result_flag"]) != "")
				{
					ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["result_flag"]);
				}
				else
				{
					ViewModel.sprReport.Text = "";
				}
				ViewModel.sprReport.Col = 8;
				if (modGlobal.Clean(cImmune.EMSPersonnelImmunizations["comments"]) != "")
				{
					ViewModel.sprReport.Text = modGlobal.Clean(cImmune.EMSPersonnelImmunizations["Comments"]);
				}
				else
				{
					ViewModel.sprReport.Text = "";
				}

				cImmune.EMSPersonnelImmunizations.MoveNext();
			}
			;
			ViewModel.lbCount.Text = "Total Count: " + ViewModel.sprReport.DataRowCnt.ToString();

		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			PTSProject.clsUnit UnitCL = Container.Resolve< clsUnit>();
			oCmd.Connection = modGlobal.oConn;

			oCmd.CommandType = CommandType.Text;

			//Fill Assignment Type List box
			oCmd.CommandText = "spSelect_AssignmentTypeList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAssignmentCode.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboAssignmentCode.AddItem(modGlobal.Clean(oRec["assignment_type_code"]));
				oRec.MoveNext();
			};
			ViewModel.cboAssignmentCode.SelectedIndex = -1;
			ViewModel.cboAssignmentCode.Text = "";

			//Fill Unit List box
			ViewModel.cboUnit.Clear();
			oCmd.CommandText = "spUnitList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnit.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboUnit.AddItem((string)oRec["unit_code"]);
				oRec.MoveNext();
			};
			ViewModel.cboUnit.ListIndex = -1;
			ViewModel.cboUnit.Text = "";

			//Fill Immunization List box
			oCmd.CommandText = "spSelect_EMSImmunizationTypeList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboType.AddItem(oRec["immunize_type"]);
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboType.NewIndex was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_WARNING: (1068) GetVal(oRec(immunize_id)) of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				//UPGRADE_ISSUE: (2064) LpADOLib.fpComboAdo property cboType.ItemData was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.setItemData(Convert.ToInt32(modGlobal.GetVal(oRec["immunize_id"])), ViewModel.cboType.getNewIndex());
				oRec.MoveNext();
			};
			ViewModel.cboType.ListIndex = -1;
			ViewModel.cboType.Text = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAssignmentCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAssignmentCode.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrGroup = modGlobal.Clean(ViewModel.cboAssignmentCode.Text);
			RefreshEmployeeList();
		}

		private void cboType_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboType.Clicked)
			{
				if ( ViewModel.cboType.ListIndex == -1)
				{
					return;
				}
				RefreshEmployeeList();
			}
			ViewModel.cboType.Clicked = false;
		}

		private void cboUnit_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUnit.Clicked)
			{
				if ( ViewModel.cboUnit.ListIndex == -1)
				{
					return;
				}
				ViewModel.CurrUnit = modGlobal.Clean(ViewModel.cboUnit.Text);
				RefreshEmployeeList();
			}
			ViewModel.cboUnit.Clicked = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void chkNotReceived_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.FirstTime = true;
			ViewModel.sprReport.MaxRows = 50;
			ViewModel.sprReport.Row = 1;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.ClearSelection();
			ViewModel.txtNameSearch.Text = "";
			ViewModel.chkNotReceived.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			ViewModel.cboType.Text = "";
			ViewModel.cboType.ListIndex = -1;
			ViewModel.cboAssignmentCode.Text = "";
			ViewModel.cboAssignmentCode.SelectedIndex = -1;
			ViewModel.cboUnit.Text = "";
			ViewModel.cboUnit.ListIndex = -1;
			ViewModel.optAll.Checked = true;
			ViewModel.opt181.Checked = false;
			ViewModel.opt182.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrGroup = "";
			ViewModel.CurrUnit = "";
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.dtEnd.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
			ViewModel.dtStart.Value = DateTime.Parse(DateTime.Now.AddYears(-5).ToString("MM/dd/yyyy"));
			ViewModel.FirstTime = false;
			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintHeader("/lImmunization Query /n" + ViewModel.sHeadingFilter);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Immunization Query Grid");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{

			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			RefreshEmployeeList();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			ViewModel.dtEnd.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
			ViewModel.dtStart.Value = DateTime.Parse(DateTime.Now.AddYears(-5).ToString("MM/dd/yyyy"));
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrGroup = "";
			ViewModel.CurrUnit = "";
			ViewModel.txtNameSearch.Text = "";
			LoadLists();
			ViewModel.FirstTime = false;

			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "1";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "2";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "3";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "A";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				if ( ViewModel.optAll.Checked)
				{
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
					ViewModel.CurrUnit = "";
					ViewModel.CurrGroup = "";
					ViewModel.cboUnit.ListIndex = -1;
					ViewModel.cboUnit.Text = "";
					ViewModel.cboAssignmentCode.SelectedIndex = -1;
					ViewModel.cboAssignmentCode.Text = "";
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;

					RefreshEmployeeList();
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "B";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "C";

				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "D";

				RefreshEmployeeList();
			}
		}

		private void sprReport_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprReport.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprReport.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			RefreshEmployeeList();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmImmunizationQuery DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null)
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared. m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmImmunizationQuery CreateInstance()
		{
			PTSProject.frmImmunizationQuery theInstance = Shared.Container.Resolve< frmImmunizationQuery>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
			ViewManager.NavigateToView(
				PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmImmunizationQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmImmunizationQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		public static SharedState Shared
		{
			get
			{
				return UpgradeHelpers.Helpers.StaticContainer.GetSharedItem<SharedState>();
			}
		}

		[UpgradeHelpers.Helpers.Singleton]
		public class SharedState
			: UpgradeHelpers.Interfaces.IModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers.
			Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
		{

			public string UniqueID { get; set; }

			public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

			public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

			void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
			{
			}

			public virtual frmImmunizationQuery m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}