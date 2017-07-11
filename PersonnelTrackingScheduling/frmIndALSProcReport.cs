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

	public partial class frmIndALSProcReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndALSProcReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndALSProcReport));
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


		private void frmIndALSProcReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************************************
		//   TFD Training Individual Paramedic ALS Procedures
		//         By Employee, Begin Date thru End Date
		//********************************************************

		public void FillGrid()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			string sSSN = "";

			ClearGrid();

			if (TrainCL.GetEmployeePMRecertInfoByID(ViewModel.CurrEmp) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Not able to find Employee Information!", "Employee Paramedic Recert Info", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sReportInfo = "";
			string sCertExpDate = "";
			if (!TrainCL.Employee.EOF)
			{
				sReportInfo = "Name: " + modGlobal.Clean(TrainCL.Employee["name_full"]) + "       ";
				sReportInfo = sReportInfo + "SS#: ";
				if (modGlobal.Clean(TrainCL.Employee["social_security_nbr"]) == "")
				{
					sReportInfo = sReportInfo + "           ";
				}
				else
				{
					sSSN = modGlobal.Clean(TrainCL.Employee["social_security_nbr"]);
					sReportInfo = sReportInfo + "*******" + sSSN.Substring(Math.Max(sSSN.Length - 4, 0));
				}
				sReportInfo = sReportInfo + "       Expiration Date: ";
				if (modGlobal.Clean(TrainCL.Employee["recert_date"]) == "")
				{
					sReportInfo = sReportInfo + "          ";
				}
				else
				{
					sCertExpDate = Convert.ToDateTime(TrainCL.Employee["recert_date"]).ToString("M/d/yyyy");
					sReportInfo = sReportInfo + sCertExpDate;
				}
				ViewModel.sprReport.Row = 3;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = sReportInfo;

				//        If sCertExpDate = "" Then
				//            dtStart.Text = Format$("01/01/" & Year(Now()) - 2, "mm/dd/yyyy")
				//            dtEnd.Text = Format$(Now(), "mm/dd/yyyy")
				//        Else
				//            dtStart.Text = Format$(TrainCL.Employee("StartDate"), "mm/dd/yyyy")
				//            dtEnd.Text = DateAdd("d", -1, DateAdd("yyyy", 3, dtStart.Text))
				//        End If

				sReportInfo = "";
				sReportInfo = "Period Begins: " + ViewModel.dtStart.Text + "          ";
				sReportInfo = sReportInfo + "Period Ends: " + ViewModel.dtEnd.Text;
				ViewModel.sprReport.Row = 4;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Text = sReportInfo;
			}

			//Get ALS Procedures from IRS...
			if (TrainCL.GetEmployeeALSProceduresForPMRecert(ViewModel.CurrEmp, ViewModel.dtStart.Text, ViewModel.dtEnd.Text) != 0)
			{
				//continue
			}
			else
			{
				return;
			}

			int ProcedureCount = 0;
			string sSubHeading = "";
			int CurrRow = 7;

			while(!TrainCL.TrainingRecord.EOF)
			{
				if (sSubHeading == "")
				{ //First Time

					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "ALS Procedures (IRS)";
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "DateTime";
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = "Incident #";
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = modGlobal.Shared.PARCHMENT;
					ViewModel.sprReport.BlockMode = false;

					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;

				}
				else if (modGlobal.Clean(TrainCL.TrainingRecord["description"]) == sSubHeading)
				{
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;

				}
				else
				{
					//Add logic for subtotaling...
					CurrRow++;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;
					ViewModel.sprReport.Text = "Total For " + modGlobal.Clean(sSubHeading) + ": ";
					ViewModel.sprReport.BlockMode = true;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Row2 = CurrRow;
					ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
					ViewModel.sprReport.FontBold = true;
					ViewModel.sprReport.BlockMode = false;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
					ViewModel.sprReport.Text = ProcedureCount.ToString();
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.Text = "";

					//continue
					ProcedureCount = 0;
					CurrRow += 2;
					ViewModel.sprReport.Row = CurrRow;
					ViewModel.sprReport.Col = 1;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					sSubHeading = modGlobal.Clean(TrainCL.TrainingRecord["description"]);
					ViewModel.sprReport.Text = sSubHeading;
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["date_incident_created"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						ViewModel.sprReport.Text = Convert.ToDateTime(TrainCL.TrainingRecord["date_incident_created"]).ToString("M/d/yyyy H:mm:ss");
					}
					ViewModel.sprReport.Col = 4;
					ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
					if (modGlobal.Clean(TrainCL.TrainingRecord["incident_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["incident_number"]));
					}

					ProcedureCount++;
				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;
			// Now do Total Hours for LAST row...
			if (ProcedureCount > 0)
			{
				CurrRow++;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Right;
				ViewModel.sprReport.Text = "Total For " + modGlobal.Clean(sSubHeading) + ": ";
				ViewModel.sprReport.BlockMode = true;
				ViewModel.sprReport.Col = 1;
				ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
				ViewModel.sprReport.Row = CurrRow;
				ViewModel.sprReport.Row2 = CurrRow;
				ViewModel.sprReport.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprReport.FontBold = true;
				ViewModel.sprReport.BlockMode = false;
				ViewModel.sprReport.Col = 3;
				ViewModel.sprReport.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprReport.Text = ProcedureCount.ToString();
				ViewModel.sprReport.Col = 4;
				ViewModel.sprReport.Text = "";
			}

		}

		public void ClearGrid()
		{
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Row2 = 5;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Row = 7;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprReport.FontBold = false;
			ViewModel.sprReport.BlockMode = false;

		}

		public void LoadList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboEmployee.Text = "";
			ViewModel.cboEmployee.Items.Clear();

			//Load Employee Name combobox
			oCmd.Connection = modGlobal.oConn;

			if (modGlobal.Shared.gSecurity == "RO")
			{
				ViewModel.cboEmployee.AddItem(modGlobal.Shared.gUserName + "  :" + modGlobal.Shared.gUser);
				return;
			}

			oCmd.CommandText = "spOpNameList ";

			oCmd.CommandType = CommandType.Text;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			while (!oRec.EOF)
			{
				ViewModel.cboEmployee.AddItem(Convert.ToString(oRec["name_full"]).Trim() + " - " + Convert.ToString(oRec["employee_id"]));
				oRec.MoveNext();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmployee_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Select new employee
			//Refill Grid
			ViewModel.CurrEmp = ViewModel.cboEmployee.Text.Substring(Math.Max(ViewModel.cboEmployee.Text.Length - 5, 0));
			ViewModel.lbEmpName.Text = ViewModel.cboEmployee.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboEmployee.Text) - 8, ViewModel.cboEmployee.Text.Length));

			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Paramedic Recertification Classes"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Individual Training PM Recert Summary Report");
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
		internal void dtEnd_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtEnd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_ValueChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void dtStart_Click(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}

			FillGrid();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.dtStart.Text = (DateTime.TryParse("01/01/" + (DateTime.Now.Year - 2).ToString(), out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : "01/01/" + (DateTime.Now.Year - 2).ToString();
			ViewModel.dtEnd.Text = DateTime.Now.ToString("MM/dd/yyyy");
			LoadList();
			ViewModel.FirstTime = false;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmIndALSProcReport DefInstance
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

		public static frmIndALSProcReport CreateInstance()
		{
			PTSProject.frmIndALSProcReport theInstance = Shared.Container.Resolve< frmIndALSProcReport>();
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

	public partial class frmIndALSProcReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndALSProcReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndALSProcReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}