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

	public partial class frmPromoReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPromoReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPromoReport));
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


		private void frmPromoReport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void ClearGrid()
		{
			//Clear Report Grid
			ViewModel.sprPromo.Row = 2;
			ViewModel.sprPromo.Col = 2;
			ViewModel.sprPromo.Text = "";
			ViewModel.sprPromo.BlockMode = true;
			ViewModel.sprPromo.Row = 4;
			ViewModel.sprPromo.Row2 = ViewModel.MaxRow;
			ViewModel.sprPromo.Col = 1;
			ViewModel.sprPromo.Col2 = 5;
			//ViewModel.sprPromo.Action = (FarPoint.ViewModels.FPActionConstants) 12;
			//ViewModel.sprPromo.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprPromo.FontSize = 10;
			ViewModel.sprPromo.FontBold = false;
			ViewModel.sprPromo.BlockMode = false;
			ViewModel.MaxRow = 4;

		}

		public void DisplayHeadings()
		{
			//PageBreak and Display Headings
			ViewModel.sprPromo.Row = ViewModel.CurrRow;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromo.RowPageBreak was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromo.setRowPageBreak(true);
			(ViewModel.CurrRow)++;
			ViewModel.sprPromo.Row = ViewModel.CurrRow;
			ViewModel.sprPromo.Col = 1;
			ViewModel.sprPromo.Text = "Tacoma Fire Department";
			ViewModel.sprPromo.FontBold = true;
			ViewModel.sprPromo.FontSize = 12;
			(ViewModel.CurrRow)++;
			ViewModel.sprPromo.Row = ViewModel.CurrRow;
			ViewModel.sprPromo.Text = "Promotional Listing";
			ViewModel.sprPromo.FontBold = true;
			ViewModel.sprPromo.FontSize = 12;
			ViewModel.sprPromo.Col = 2;
			ViewModel.sprPromo.Text = ViewModel.cboPromo.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboPromo.Text) - 7, ViewModel.cboPromo.Text.Length));
			ViewModel.sprPromo.FontBold = true;
			ViewModel.sprPromo.FontSize = 12;
			(ViewModel.CurrRow)++;
			ViewModel.sprPromo.Row = ViewModel.CurrRow;
			ViewModel.sprPromo.Col = 1;
			ViewModel.sprPromo.Text = "Name";
			ViewModel.sprPromo.Col = 2;
			ViewModel.sprPromo.Text = "Current Job Title";
			ViewModel.sprPromo.Col = 3;
			ViewModel.sprPromo.Text = "Promotion Date";
			ViewModel.sprPromo.Col = 4;
			ViewModel.sprPromo.Text = "Exc. Days";
			ViewModel.sprPromo.Col = 5;
			ViewModel.sprPromo.Text = "TFD Hire Date";
			ViewModel.sprPromo.BlockMode = true;
			ViewModel.sprPromo.Col = 1;
			ViewModel.sprPromo.Col2 = 5;
			ViewModel.sprPromo.Row2 = ViewModel.CurrRow;
			//ViewModel.sprPromo.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			//ViewModel.sprPromo.Action = (FarPoint.ViewModels.FPActionConstants) 16;
			ViewModel.sprPromo.FontSize = 12;
			ViewModel.sprPromo.BlockMode = false;
			(ViewModel.CurrRow)++;
			ViewModel.PageRow = 4;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPromo_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Load Report with selected Promotion List
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.MaxRow > 4)
			{
				ClearGrid();
			}

			string PromoID = ViewModel.cboPromo.Text.Substring(Math.Max(ViewModel.cboPromo.Text.Length - 4, 0));
			string PromoTitle = ViewModel.cboPromo.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboPromo.Text) - 7, ViewModel.cboPromo.Text.Length));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spReport_PromoList '" + PromoID + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow = 4;
			ViewModel.PageRow = 4;
			ViewModel.sprPromo.Col = 2;
			ViewModel.sprPromo.Row = 2;
			ViewModel.sprPromo.Text = PromoTitle;


			while(!oRec.EOF)
			{
				if ( ViewModel.PageRow > 56)
				{
					DisplayHeadings();
				}
				ViewModel.sprPromo.Row = ViewModel.CurrRow;
				ViewModel.sprPromo.Col = 1;
				ViewModel.sprPromo.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprPromo.Col = 2;
				ViewModel.sprPromo.Text = modGlobal.Clean(oRec["job_title"]);
				ViewModel.sprPromo.Col = 3;
				ViewModel.sprPromo.Text = modGlobal.Clean(oRec["promotion_date"]);
				ViewModel.sprPromo.Col = 4;
				ViewModel.sprPromo.Text = modGlobal.Clean(oRec["x_days"]);
				ViewModel.sprPromo.Col = 5;
				ViewModel.sprPromo.Text = modGlobal.Clean(oRec["TFD_hire_date"]);
				(ViewModel.CurrRow)++;
				(ViewModel.PageRow)++;
				oRec.MoveNext();
			};
			ViewModel.MaxRow = ViewModel.CurrRow;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Promotion List

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromo.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromo.setPrintAbortMsg("Printing Promotion Listing - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromo.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromo.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPromo.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprPromo.setPrintColor(true);
            //    sprPromo.PrintOrientation = 1
            ViewModel.sprPromo.PrintSheet(null);
			//ViewModel.sprPromo.Action = (FarPoint.ViewModels.FPActionConstants) 32;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Load Promotion List Box
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPromoTypes";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboPromo.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboPromo.AddItem(Convert.ToString(oRec["description"]).Trim() + "  :" + Convert.ToString(oRec["promotion_code_id"]));
				oRec.MoveNext();
			};
			ViewModel.MaxRow = 4;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPromoReport DefInstance
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

		public static frmPromoReport CreateInstance()
		{
			PTSProject.frmPromoReport theInstance = Shared.Container.Resolve< frmPromoReport>();
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
			ViewModel.sprPromo.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPromo.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPromoReport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPromoReportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPromoReport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}