using System;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmIndAvailableToWork
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndAvailableToWorkViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndAvailableToWork));
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


		private void frmIndAvailableToWork_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//**********************************************
		//***    frmIndAvailableToWork               ***
		//**********************************************
		//*** This screen is available to CSRs       ***
		//*** from the Individulal Scheduler to      ***
		//*** manage specific date/shifts available  ***
		//*** to work.  The results are display for  ***
		//*** BCs /ISOs for callbacks...             ***
		//**********************************************

		private void FillAvailableGrid()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			ViewModel.sprAvailable.Row = 1;
			ViewModel.sprAvailable.Row2 = ViewModel.sprAvailable.MaxRows;
			ViewModel.sprAvailable.Col = 1;
			ViewModel.sprAvailable.Col2 = ViewModel.sprAvailable.MaxCols;
			ViewModel.sprAvailable.BlockMode = true;
			ViewModel.sprAvailable.Text = "";
			ViewModel.sprAvailable.BlockMode = false;

			if (~cSched.GetEmployeeAvailableToWorkByEmp(ViewModel.CurrEmployee) != 0)
			{
				return;
			}
			ViewModel.CurrRow = 0;

			while(!cSched.EmployeeAvailableToWork.EOF)
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprAvailable.Row = ViewModel.CurrRow;

				this.ViewModel.Text = "Dates Available To Work For " + modGlobal.Clean(cSched.EmployeeAvailableToWork["name_full"]);
				ViewModel.sprAvailable.Col = 1;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["shift_start"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 2;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["created_on"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 3;
				ViewModel.sprAvailable.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["comment"]);
				ViewModel.sprAvailable.Col = 4;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprAvailable.Text = Convert.ToString(modGlobal.GetVal(cSched.EmployeeAvailableToWork["available_id"]));

				cSched.EmployeeAvailableToWork.MoveNext();
			}
			;

					}

		//UPGRADE_WARNING: (2074) SSMonth event calAvail.Click was upgraded to calAvail.DateChanged which has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2074.aspx
		[UpgradeHelpers.Events.Handler]
		internal void calAvail_DateChanged(Object eventSender, Stubs._System.Windows.Forms.DateRangeEventArgs eventArgs)
		{
			string SelDate = eventArgs.End.ToString();
			//string OldSelDate = "";
			int Selected = 1;
			//int RtnCancel = 0;
			if (~Selected != 0)
			{
				return;
			}

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.SelectedDate = (DateTime.TryParse(SelDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : SelDate;

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();

			cSched.EmpAvailToWorkEmpID = ViewModel.CurrEmployee;
			cSched.EmpAvailToWorkCreatedBy = modGlobal.Shared.gUser;
			cSched.EmpAvailToWorkCreatedOn = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			cSched.EmpAvailToWorkComment = modGlobal.Clean(ViewModel.txtComment.Text);

			//Private cEmpAvailToWorkShiftDate As String

			if ( ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				cSched.EmpAvailToWorkShiftDate = ViewModel.SelectedDate + " 7:00:00";
				if (cSched.AddEmployeeAvailableToWork())
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to add AM record.", "Add Available To Work Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			if ( ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				cSched.EmpAvailToWorkShiftDate = ViewModel.SelectedDate + " 19:00:00";
				if (cSched.AddEmployeeAvailableToWork())
				{
					//continue
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to add PM record.", "Add Available To Work Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
			}

			FillAvailableGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdDelete_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();

			if ( ViewModel.CurrRecordID == 0)
			{
				return;
			}

			cSched.EmpAvailToWorkID = ViewModel.CurrRecordID;
			if (cSched.DeleteEmployeeAvailableToWork() != 0)
			{
				ViewManager.ShowMessage("Record was successfully deleted.", "Delete Available To Work Record", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong!", "Delete Available To Work Record", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

			FillAvailableGrid();


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.calAvail.SelectionRange.Start = DateTime.Now.AddDays(2);
			ViewModel.calAvail.SelectionRange.End = DateTime.Now.AddDays(2);
			ViewModel.SelectedDate = DateTime.Now.AddDays(2).ToString("MM/dd/yyyy");
			ViewModel.txtComment.Text = "";
			ViewModel.CurrRecordID = 0;
			ViewModel.CurrEmployee = modGlobal.Shared.gReportUser;
			FillAvailableGrid();

		}

		private void sprAvailable_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			ViewModel.cmdDelete.Enabled = false;
			ViewModel.CurrRecordID = 0;

			if (Row == 0)
			{
				return;
			}
			ViewModel.CurrRow = Row;
			ViewModel.sprAvailable.Row = ViewModel.CurrRow;
			ViewModel.sprAvailable.Col = 4;
			if (modGlobal.Clean(ViewModel.sprAvailable.Text) == "")
			{
				ViewModel.CurrRow = 0;
				return;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.CurrRecordID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprAvailable.Text));
			}
			ViewModel.cmdDelete.Enabled = true;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmIndAvailableToWork DefInstance
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

		public static frmIndAvailableToWork CreateInstance()
		{
			PTSProject.frmIndAvailableToWork theInstance = Shared.Container.Resolve< frmIndAvailableToWork>();
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
			ViewModel.sprAvailable.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprAvailable.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmIndAvailableToWork
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndAvailableToWorkViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndAvailableToWork m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}