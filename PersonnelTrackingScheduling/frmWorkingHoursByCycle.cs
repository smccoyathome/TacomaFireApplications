using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmWorkingHoursByCycle
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmWorkingHoursByCycleViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmWorkingHoursByCycle));
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


		private void frmWorkingHoursByCycle_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**************************************
		//  Employee Working Hours By Cycle  ***
		//**************************************

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_AssignmentGroupList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboGroup.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboGroup.AddItem(modGlobal.Clean(oRec["group_code"]));
				oRec.MoveNext();
			};

			strSQL = "spSelect_CycleYearList ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboYear.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboYear.AddItem(modGlobal.Clean(oRec["cycle_year"]));
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = DateTime.Now.Year.ToString();
			ViewModel.CurrYear = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.cboYear.Text)));

			strSQL = "spSelect_CalendarCycleShiftStartByYear " + ViewModel.CurrYear.ToString();
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboCycleDate.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboCycleDate.AddItem(Convert.ToDateTime(oRec["start_date"]).ToString("MM/dd/yyyy") + " - " + Convert.ToDateTime(oRec["end_date"]).AddDays(-1).ToString("MM/dd/yyyy"));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboCycleDate.SetItemData(ViewModel.cboCycleDate.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["cycle_id"])));
				oRec.MoveNext();
			};

		}

		public void FillGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.CurrCycle == 0)
			{
				return;
			}

			ViewModel.sprEmployeeGrid.Row = 1;
			ViewModel.sprEmployeeGrid.Row2 = ViewModel.sprEmployeeGrid.MaxRows;
			ViewModel.sprEmployeeGrid.Col = 1;
			ViewModel.sprEmployeeGrid.Col2 = ViewModel.sprEmployeeGrid.MaxCols;
			ViewModel.sprEmployeeGrid.BlockMode = true;
			ViewModel.sprEmployeeGrid.Text = "";
			ViewModel.sprEmployeeGrid.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeGrid.BlockMode = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_FLSAEmployeeHoursFiltered " + ViewModel.CurrYear.ToString() + ", ";
			if ( ViewModel.CurrCycle == 0)
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + ViewModel.CurrCycle.ToString() + ", ";
			}
			if ( ViewModel.CurrBatt == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrBatt + "', ";
			}
			if ( ViewModel.CurrShift == "")
			{
				strSQL = strSQL + "NULL, ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrShift + "', ";
			}
			if ( ViewModel.CurrGroup == "")
			{
				strSQL = strSQL + "NULL ";
			}
			else
			{
				strSQL = strSQL + "'" + ViewModel.CurrGroup + "' ";
			}

			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int iRow = 0;

			while(!oRec.EOF)
			{
				iRow++;
				ViewModel.sprEmployeeGrid.Row = iRow;
				ViewModel.sprEmployeeGrid.Col = 1;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeGrid.Col = 2;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeGrid.Col = 3;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeGrid.Col = 4;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprEmployeeGrid.Col = 5;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprEmployeeGrid.Col = 6;
				ViewModel.sprEmployeeGrid.Text = modGlobal.Clean(oRec["group_code"]);
				ViewModel.sprEmployeeGrid.Col = 7;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeGrid.Text = Convert.ToString(modGlobal.GetVal(oRec["hours"]));
				ViewModel.sprEmployeeGrid.Col = 8;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeGrid.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));

				if (modGlobal.Clean(oRec["HourStatus"]) == "OverMax")
				{
					ViewModel.sprEmployeeGrid.Row = iRow;
					ViewModel.sprEmployeeGrid.Row2 = iRow;
					ViewModel.sprEmployeeGrid.Col = 1;
					ViewModel.sprEmployeeGrid.Col2 = ViewModel.sprEmployeeGrid.MaxCols;
					ViewModel.sprEmployeeGrid.BlockMode = true;
					ViewModel.sprEmployeeGrid.BlockMode = false;
				}
				else
				{
					ViewModel.sprEmployeeGrid.Row = iRow;
					ViewModel.sprEmployeeGrid.Row2 = iRow;
					ViewModel.sprEmployeeGrid.Col = 1;
					ViewModel.sprEmployeeGrid.Col2 = ViewModel.sprEmployeeGrid.MaxCols;
					ViewModel.sprEmployeeGrid.BlockMode = true;
					ViewModel.sprEmployeeGrid.BlockMode = false;
				}

				oRec.MoveNext();
			};
			ViewModel.lbRowCount.Text = "Total Row = " + iRow.ToString();
	
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboCycleDate_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboCycleDate.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrCycle = ViewModel.cboCycleDate.GetItemData(ViewModel.cboCycleDate.SelectedIndex);
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboGroup_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboGroup.SelectedIndex == -1)
			{
				return;
			}
			ViewModel.CurrGroup = modGlobal.Clean(ViewModel.cboGroup.Text);
			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			// int i = 0;
			ViewModel.CurrYear = Convert.ToInt32(Double.Parse(modGlobal.Clean(ViewModel.cboYear.Text)));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "spSelect_CalendarCycleShiftStartByYear " + ViewModel.CurrYear.ToString();
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboCycleDate.Items.Clear();

			while(!oRec.EOF)
			{
				ViewModel.cboCycleDate.AddItem(Convert.ToDateTime(oRec["start_date"]).ToString("MM/dd/yyyy") + " - " + Convert.ToDateTime(oRec["end_date"]).AddDays(-1).ToString("MM/dd/yyyy"));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboCycleDate.SetItemData(ViewModel.cboCycleDate.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["cycle_id"])));
				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.CurrBatt = "";
			ViewModel.optAll.Checked = true;
			ViewModel.CurrShift = "";
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			//    cboCycleDate.ListIndex = -1
			//    CurrCycle = 0
			ViewModel.cboGroup.SelectedIndex = -1;
			ViewModel.CurrGroup = "";
			ViewModel.lbRowCount.Text = "";
			FillGrid();

			//    sprEmployeeGrid.Row = 1
			//    sprEmployeeGrid.Row2 = sprEmployeeGrid.MaxRows
			//    sprEmployeeGrid.Col = 1
			//    sprEmployeeGrid.Col2 = sprEmployeeGrid.MaxCols
			//    sprEmployeeGrid.BlockMode = True
			//    sprEmployeeGrid.Text = ""
			//    sprEmployeeGrid.BackColor = WHITE
			//    sprEmployeeGrid.ForeColor = BLACK
			//    sprEmployeeGrid.BlockMode = False

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrCycle = 0;
			ViewModel.CurrGroup = "";
			ViewModel.lbRowCount.Text = "";

			LoadLists();
			FillGrid();

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
				ViewModel.CurrBatt = "1";
				FillGrid();
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
				ViewModel.CurrBatt = "2";
				FillGrid();
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
				ViewModel.CurrBatt = "3";
				FillGrid();
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
				ViewModel.CurrShift = "A";
				FillGrid();
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
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				ViewModel.CurrShift = "B";
				FillGrid();
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
				ViewModel.CurrShift = "C";
				FillGrid();
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
				ViewModel.CurrShift = "D";
				FillGrid();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmWorkingHoursByCycle DefInstance
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

		public static frmWorkingHoursByCycle CreateInstance()
		{
			PTSProject.frmWorkingHoursByCycle theInstance = Shared.Container.Resolve< frmWorkingHoursByCycle>();
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
			ViewModel.sprEmployeeGrid.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeGrid.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmWorkingHoursByCycle
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmWorkingHoursByCycleViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmWorkingHoursByCycle m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}