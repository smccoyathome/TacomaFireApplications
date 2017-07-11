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

	public partial class frmPPEInspQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInspQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPPEInspQuery));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
			ReLoadForm(false);
		}


		private void frmPPEInspQuery_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		public void FillGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int iRetired = 0;
			int iIssued = 0;
			int iType = 0;
			int iBrand = 0;
			int iMisc = 0;
			ViewModel.sprList.Row = 1;
			ViewModel.sprList.Row2 = ViewModel.sprList.MaxRows;
			ViewModel.sprList.Col = 1;
			ViewModel.sprList.Col2 = ViewModel.sprList.MaxCols;
			ViewModel.sprList.BlockMode = true;
			ViewModel.sprList.Text = "";
			ViewModel.sprList.BlockMode = false;
			ViewModel.sprList.MaxRows = 5000;
			ViewModel.lbTotalCount.Text = "List Count:   0";
			ViewModel.sHeadingFilter = "Displaying Uniforms: ";

			if ( ViewModel.CurrBatt != "" )
			{
				if ( ViewModel.CurrShift != "" )
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Batt\\Shift= " + ViewModel.CurrBatt + "\\" + ViewModel.CurrShift + "; ";
				}
			}
			else if ( ViewModel.CurrShift != "" )
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "for Shift= " + ViewModel.CurrShift + "; ";
			}

			for ( int i = 0; i <= 2; i++ )
			{
				if ( ViewModel.OptRetired[i].Checked )
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.OptRetired[i].Text + "; ";
				}
				if ( ViewModel.OptIssued[i].Checked )
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.OptIssued[i].Text + "; ";
				}
				if ( ViewModel.OptMonth[i].Checked )
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.OptMonth[i].Text + "; ";
				}
			}

			for ( int i = 0; i <= 3; i++ )
			{
				if ( ViewModel.OptMisc[i].Checked )
				{
					ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + ViewModel.OptMisc[i].Text + "; ";
				}
			}

			if ( ViewModel.OptRetired[0].Checked )
			{
				iRetired = 0;
			}
			else if ( ViewModel.OptRetired[1].Checked )
			{
				iRetired = 1;
			}
			else
			{
				iRetired = 2;
			}

			if ( ViewModel.OptIssued[0].Checked )
			{
				iIssued = 0;
			}
			else if ( ViewModel.OptIssued[1].Checked )
			{
				iIssued = 1;
			}
			else
			{
				iIssued = 2;
			}

			if ( ViewModel.cboType.SelectedIndex == -1 )
			{
				iType = 0;
			}
			else
			{
				iType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
			}

			if ( ViewModel.cboBrand.SelectedIndex == -1 )
			{
				iBrand = 0;
			}
			else
			{
				iBrand = ViewModel.cboBrand.GetItemData(ViewModel.cboBrand.SelectedIndex);
			}

			if ( ViewModel.OptMisc[1].Checked )
			{
				iMisc = 1;
			}
			else if ( ViewModel.OptMisc[2].Checked )
			{
				iMisc = 2;
			}
			else if ( ViewModel.OptMisc[3].Checked )
			{
				iMisc = 3;
			}
			else
			{
				iMisc = 0;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spSelect_PPEUniformQueryList ";
			if ( iRetired == 2 )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iRetired.ToString() + ", ";
			}
			if ( iIssued == 2 )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iIssued.ToString() + ", ";
			}
			if ( iType == 0 )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iType.ToString() + ", ";
			}
			if ( iBrand == 0 )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iBrand.ToString() + ", ";
			}
			if ( iMisc == 0 )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + iMisc.ToString() + ", ";
			}
			if ( ViewModel.CurrBatt == "" )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrBatt + "', ";
			}
			if ( ViewModel.CurrShift == "" )
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrShift + "', ";
			}
			if ( ViewModel.iMonth == 0 )
			{
				strSQL = strSQL + "NULL ";
			}
			else
			{
				strSQL = strSQL + ViewModel.iMonth.ToString() + " ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewModel.sprList.MaxRows = 1;
				ViewManager.ShowMessage("No PPE Information was found.", "PPE Query Information", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			ViewModel.sprList.Row = 0;
			int TotalCount = 0;

			while ( !oRec.EOF )
			{
				(ViewModel.sprList.Row)++;
				ViewModel.sprList.Col = 1; //Station

				ViewModel.sprList.Text = modGlobal.Clean(oRec["station"]);
				ViewModel.sprList.Col = 2; //Uniform Item

				ViewModel.sprList.Text = modGlobal.Clean(oRec["UniformType"]);
				ViewModel.sprList.Col = 3; //Tracking #

				ViewModel.sprList.Text = modGlobal.Clean(oRec["tracking_number"]);
				ViewModel.sprList.Col = 4; //Size/Color

				if ( modGlobal.Clean(oRec["SizeCode"]) == "" )
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["Color"]);
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(oRec["SizeCode"]);
				}
				ViewModel.sprList.Col = 5; //Brand

				ViewModel.sprList.Text = modGlobal.Clean(oRec["manufacturer_name"]);
				ViewModel.sprList.Col = 6; //Retired Date

				if ( modGlobal.Clean(oRec["retired_date"]) == "" )
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["retired_date"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 7; //Issued Date

				if ( modGlobal.Clean(oRec["IssuedDate"]) == "" )
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["IssuedDate"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 8; //Issued To

				ViewModel.sprList.Text = modGlobal.Clean(oRec["IssuedTo"]);
				ViewModel.sprList.Col = 9; //Last Inspected Date

				if ( modGlobal.Clean(oRec["LastInspected"]) == "" )
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["LastInspected"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 10; //Out for Repair Date

				if ( modGlobal.Clean(oRec["RepairFlagged"]) == "" )
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["RepairFlagged"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 11; //Flagged for Cleaning Date

				if ( modGlobal.Clean(oRec["LaunderFlagged"]) == "" )
				{
					ViewModel.sprList.Text = "";
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(oRec["LaunderFlagged"]).ToString("M/d/yyyy");
				}
				ViewModel.sprList.Col = 12; //Uniform ID

				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));


				TotalCount++;
				oRec.MoveNext();
			};
			ViewModel.sprList.MaxRows = TotalCount;
			ViewModel.lbTotalCount.Text = "List Count:  " + TotalCount.ToString();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBrand_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBrand.SelectedIndex == -1 )
			{
				return ;
			}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.cboType.SelectedIndex == -1 )
			{
				return ;
			}

			int iItemType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.cboBrand.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill Manufacturer for Selected Uniform Type
			string strSQL = "spSelect_UniformManufacturerByItemType " + iItemType.ToString() + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{


				while ( !oRec.EOF )
				{
					ViewModel.cboBrand.AddItem(modGlobal.Clean(oRec["manufacturer_name"]));
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.cboBrand.SetItemData(ViewModel.cboBrand.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"])));
					oRec.MoveNext();
				};

				}

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboBrand.Text = "";
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.OptIssued[2].Checked = true;
			ViewModel.OptRetired[0].Checked = true;
			ViewModel.OptMisc[0].Checked = true;
			ViewModel.OptMonth[0].Checked = true;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.iMonth = 0;
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction.", vbOKOnly, "PPE Inspection Query Grid/List "
			//Print PPE Inspection Query Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintHeader("/lPPE Inspection Query /n" + ViewModel.sHeadingFilter);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintAbortMsg("Printing PPE Inspection Query Grid/List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprList.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string sShift = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboType.Items.Clear();
			ViewModel.cboType.Text = "";

			while ( !oRec.EOF )
			{
				ViewModel.cboType.AddItem(modGlobal.Clean(oRec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["uniform_type"])));
				oRec.MoveNext();
			};
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboBrand.Items.Clear();
			ViewModel.cboBrand.Text = "";
			ViewModel.cboBrand.SelectedIndex = -1;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.iMonth = 0;

			string ShiftDate = DateTime.Now.ToString("M/d/yyyy") + " 7:00AM";
			oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				sShift = modGlobal.Clean(oRec["shift_code"]);
			}

			//    If gUserBatt = "1" Then
			//        CurrBatt = "1"
			//        opt181.Value = True
			//    ElseIf gUserBatt = "2" Then
			//        CurrBatt = "2"
			//        opt182.Value = True
			//    ElseIf gUserBatt = "3" Then
			//        CurrBatt = "3"
			//        opt183.Value = True
			//    End If

			if ( ViewModel.CurrBatt != "" )
			{
				if ( sShift != "" )
				{
					if ( sShift == "A" )
					{
						ViewModel.optA.Checked = true;
					}
					else if ( sShift == "B" )
					{
						ViewModel.optB.Checked = true;
					}
					else if ( sShift == "C" )
					{
						ViewModel.optC.Checked = true;
					}
					else if ( sShift == "D" )
					{
						ViewModel.optD.Checked = true;
					}
				}
			}


			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "1";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "2";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "3";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "A";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				FillGrid();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "B";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "C";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "D";
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptIssued_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}

				FillGrid();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptMisc_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptMonth_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				int Index = this.ViewModel.OptMonth.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender);
				if ( Index == 1 )
				{
					ViewModel.iMonth = 6;
				}
				else if ( Index == 2 )
				{
					ViewModel.iMonth = 12;
				}
				else
				{
					ViewModel.iMonth = 0;
				}
				FillGrid();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void OptRetired_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}

				FillGrid();

			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPPEInspQuery DefInstance
		{
			get
			{
				if ( Shared.m_vb6FormDefInstance == null )
				{
					Shared.
						m_InitializingDefInstance = true;
					Shared.
						m_vb6FormDefInstance = CreateInstance();
					Shared.
						m_InitializingDefInstance = false;
				}
				return Shared.m_vb6FormDefInstance;
			}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmPPEInspQuery CreateInstance()
		{
			PTSProject.frmPPEInspQuery theInstance = Shared.Container.Resolve<frmPPEInspQuery>();
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
			ViewModel.Frame3[0].LifeCycleStartup();
			ViewModel.Frame3[1].LifeCycleStartup();
			ViewModel.Frame3[2].LifeCycleStartup();
			ViewModel.sprList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Frame3[0].LifeCycleShutdown();
			ViewModel.Frame3[1].LifeCycleShutdown();
			ViewModel.Frame3[2].LifeCycleShutdown();
			ViewModel.sprList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPPEInspQuery
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPEInspQueryViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPPEInspQuery m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}