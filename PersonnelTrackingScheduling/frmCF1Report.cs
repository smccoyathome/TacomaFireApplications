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

	public partial class frmCF1Report
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmCF1ReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmCF1Report));
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


		private void frmCF1Report_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void DisplayHeadings()
		{
			//Display Report Headings
			ViewModel.sprCF1.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCF1.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCF1.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprCF1.Row = ViewModel.CurrRow;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Text = "Tacoma Fire Department";
			ViewModel.sprCF1.FontSize = 12;
			ViewModel.sprCF1.FontBold = true;
			ViewModel.sprCF1.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			(ViewModel.PageNo)++;
			ViewModel.sprCF1.Col = 4;
			ViewModel.sprCF1.Text = "Page " + ViewModel.PageNo.ToString();
			ViewModel.sprCF1.FontSize = 12;
			ViewModel.sprCF1.FontBold = true;
			ViewModel.sprCF1.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			(ViewModel.CurrRow)++;
			ViewModel.sprCF1.Row = ViewModel.CurrRow;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Text = "CF1 Benefit - Personnel Listing";
			ViewModel.sprCF1.FontSize = 12;
			ViewModel.sprCF1.FontBold = true;
			ViewModel.sprCF1.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			(ViewModel.CurrRow)++;
			ViewModel.sprCF1.Row = ViewModel.CurrRow;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Text = "Employee";
			ViewModel.sprCF1.Col = 2;
			ViewModel.sprCF1.Text = "Employee ID";
			ViewModel.sprCF1.Col = 3;
			ViewModel.sprCF1.Text = "Benefit Prog.";
			ViewModel.sprCF1.Col = 4;
			ViewModel.sprCF1.Text = "TFD Hire Date";
			ViewModel.sprCF1.Col = 5;
			ViewModel.sprCF1.BlockMode = true;
			ViewModel.sprCF1.Row2 = ViewModel.CurrRow;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Col2 = 4;
			ViewModel.sprCF1.FontSize = 12;
			//ViewModel.sprCF1.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprCF1.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprCF1.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageRow = 4;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print CF1 Benefit List

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCF1.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCF1.setPrintAbortMsg("Printing CF1 Benefit List - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCF1.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCF1.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprCF1.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprCF1.setPrintColor(true);
            //    sprCF1.PrintOrientation = 1
            ViewModel.sprCF1.PrintSheet(null);
            //ViewModel.sprCF1.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Format CF1 Benefit Report
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int TotalCount = 0;
			ViewModel.PageNo = 1;
			ViewModel.sprCF1.Row = 1;
			ViewModel.sprCF1.Col = 4;
			ViewModel.sprCF1.Text = "Page " + ViewModel.PageNo.ToString();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_CF1";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;


			while(!oRec.EOF)
			{
				if ( ViewModel.PageRow == 55)
				{
					DisplayHeadings();
				}
				ViewModel.sprCF1.Row = ViewModel.CurrRow;
				ViewModel.sprCF1.Col = 1;
				ViewModel.sprCF1.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprCF1.Col = 2;
				ViewModel.sprCF1.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprCF1.Col = 3;
				ViewModel.sprCF1.Text = modGlobal.Clean(oRec["benefit_program"]);
				ViewModel.sprCF1.Col = 4;
				ViewModel.sprCF1.Text = modGlobal.Clean(oRec["TFD_hire_date"]);
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				TotalCount++;
				oRec.MoveNext();
			};
			ViewModel.CurrRow += 2;
			ViewModel.sprCF1.Row = ViewModel.CurrRow;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Text = "Total CF1 Employees";
			ViewModel.sprCF1.Col = 2;
			ViewModel.sprCF1.Text = TotalCount.ToString();
			ViewModel.sprCF1.BlockMode = true;
			ViewModel.sprCF1.Col = 1;
			ViewModel.sprCF1.Col2 = 2;
			ViewModel.sprCF1.FontSize = 12;
			ViewModel.sprCF1.FontBold = true;
			//ViewModel.sprCF1.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprCF1.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprCF1.BlockMode = false;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmCF1Report DefInstance
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

		public static frmCF1Report CreateInstance()
		{
			PTSProject.frmCF1Report theInstance = Shared.Container.Resolve< frmCF1Report>();
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
			ViewModel.sprCF1.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprCF1.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmCF1Report
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmCF1ReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmCF1Report m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}