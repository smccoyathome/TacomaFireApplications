using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgAvailableToWork
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgAvailableToWorkViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgAvailableToWork));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgAvailableToWork_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*********************************************
		//***    dlgAvailableToWork                 ***
		//*********************************************
		//*** This screen is called from any of the ***
		//*** Batt Scheduler Screens.  It lists     ***
		//*** everyone who said they were available ***
		//*** to work...                            ***
		//*********************************************

		//UPGRADE_NOTE: (7001) The following declaration (FormatReport) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void FormatReport()
		//{
			//clsScheduler cSched = new clsScheduler();
			//clsScheduler cCommentInfo = new clsScheduler();
			//clsScheduler cPhoneInfo = new clsScheduler();
			//int iNameRow = 0;
			//
			//
			////UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//sprReport.ClearRange(1, 4, sprReport.MaxCols, sprReport.MaxRows, false);
			//
			//sprReport.Row = 2;
			//sprReport.Col = 1;
			//sprReport.Text = this.Text;
			//
			//if (~cSched.GetEmployeeAvailableToWorkByDate(CurrDate) != 0)
			//{
				//return;
			//}
			//
			//this.Cursor = Cursors.WaitCursor;
			//
			//int iRow = 3;
			//string sEmpID = "";
			//
			//
			//while(!cSched.EmployeeAvailableToWork.EOF)
			//{
				//if (sEmpID == "")
				//{ //First Time
					//sEmpID = modGlobal.Clean(cSched.EmployeeAvailableToWork["employee_id"]);
					//iRow++;
					//sprReport.Row = iRow;
					//iNameRow = iRow;
					//
					//sprReport.Col = 1;
					//sprReport.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["name_full"]);
					//
					//sprReport.Col = 3;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "AM";
					//
					//sprReport.Col = 4;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "PM";
					//
					//sprReport.Col = 5;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "Phone(s)";
					//
					//iRow++;
					//sprReport.Row = iRow;
					//
					//if (DateAndTime.DatePart("h", Convert.ToDateTime(cSched.EmployeeAvailableToWork["shift_start"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 12)
					//{
						//sprReport.Col = 3;
						//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
						//sprReport.Text = "X";
					//}
					//
					//if (DateAndTime.DatePart("h", Convert.ToDateTime(cSched.EmployeeAvailableToWork["shift_start"]), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 12)
					//{
						//sprReport.Col = 4;
						//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
						//sprReport.Text = "X";
					//}
					//
				//}
				//else if (sEmpID == modGlobal.Clean(cSched.EmployeeAvailableToWork["employee_id"]))
				//{ 
					//Get PhoneNumbers and Comments...
					//
				//}
				//else
				//{
					//Next Person
					//iRow++;
					//sprReport.Row = iRow;
					//sprReport.Col = 1;
					////UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.AddCellSpan was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					//sprReport.AddCellSpan(1, iRow, sprReport.MaxCols, iRow);
					//sprReport.BackColor = modGlobal.LT_GRAY;
					//
					//sEmpID = modGlobal.Clean(cSched.EmployeeAvailableToWork["employee_id"]);
					//iRow++;
					//sprReport.Row = iRow;
					//iNameRow = iRow;
					//
					//sprReport.Col = 1;
					//sprReport.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["name_full"]);
					//
					//sprReport.Col = 3;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "AM";
					//
					//sprReport.Col = 4;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "PM";
					//
					//sprReport.Col = 5;
					//sprReport.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//sprReport.Text = "Phone(s)";
					//
					//
					//
				//}
				//cSched.EmployeeAvailableToWork.MoveNext();
			//};
			//this.Cursor = Cursors.Default;
			//
		//}

		private void FillAvailableGrid()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			ViewModel.sprAvailable.Row = 1;
			ViewModel.sprAvailable.Row2 = ViewModel.sprAvailable.MaxRows;
			ViewModel.sprAvailable.Col = 1;
			ViewModel.sprAvailable.Col2 = ViewModel.sprAvailable.MaxCols;
			ViewModel.sprAvailable.BlockMode = true;
			ViewModel.sprAvailable.Text = "";
			ViewModel.sprAvailable.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprAvailable.BlockMode = false;

			if (~cSched.GetEmployeeAvailableToWorkByDate(ViewModel.CurrDate) != 0)
			{
				return;
			}
			ViewModel.CurrRow = 0;

			while(!cSched.EmployeeAvailableToWork.EOF)
			{
				(ViewModel.CurrRow)++;
				ViewModel.sprAvailable.Row = ViewModel.CurrRow;
				ViewModel.sprAvailable.Col = 1;
				ViewModel.sprAvailable.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["name_full"]);
				ViewModel.sprAvailable.Col = 2;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["shift_start"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 3;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["created_on"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 4;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["LastWorked"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 5;
				ViewModel.sprAvailable.Text = Convert.ToDateTime(cSched.EmployeeAvailableToWork["NextWorkSched"]).ToString("MM/dd/yyyy HH:mm");
				ViewModel.sprAvailable.Col = 6;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprAvailable.Text = Convert.ToString(modGlobal.GetVal(cSched.EmployeeAvailableToWork["available_id"]));
				ViewModel.sprAvailable.Col = 7;
				ViewModel.sprAvailable.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["employee_id"]);

				if ( ViewModel.CurrRow == 1)
				{
					ViewModel.CurrEmpID = modGlobal.Clean(cSched.EmployeeAvailableToWork["employee_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.CurrRecord = Convert.ToInt32(modGlobal.GetVal(cSched.EmployeeAvailableToWork["available_id"]));
				}
				cSched.EmployeeAvailableToWork.MoveNext();
			}
			;

			if ( ViewModel.CurrEmpID != "")
			{
				GetEmployeeDetail();
				//        FormatReport
			}
		}

		private void GetEmployeeDetail()
		{
			PTSProject.clsScheduler cSched = Container.Resolve< clsScheduler>();
			ViewModel.txtComment.Text = "";
			if (cSched.GetEmployeeAvailableToWorkByID(ViewModel.CurrRecord) != 0)
			{
				ViewModel.txtComment.Text = modGlobal.Clean(cSched.EmpAvailToWorkComment);
			}
			ViewModel.sprPhoneList.Col = 1;
			ViewModel.sprPhoneList.Col2 = ViewModel.sprPhoneList.MaxCols;
			ViewModel.sprPhoneList.Row = 1;
			ViewModel.sprPhoneList.Row2 = 1;
			ViewModel.sprPhoneList.BlockMode = true;
			ViewModel.sprPhoneList.Text = "";
			ViewModel.sprPhoneList.BlockMode = false;

			int iRow = 0;
			if (cSched.GetEmployeeCallBackPhoneList(ViewModel.CurrEmpID) != 0)
			{

				while(!cSched.EmployeeAvailableToWork.EOF)
				{
					iRow++;
					ViewModel.sprPhoneList.Row = iRow;
					ViewModel.sprPhoneList.Col = 1;
					ViewModel.sprPhoneList.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["phone_type"]);
					ViewModel.sprPhoneList.Col = 2;
					ViewModel.sprPhoneList.Text = modGlobal.Clean(cSched.EmployeeAvailableToWork["phone_number"]);

					cSched.EmployeeAvailableToWork.MoveNext();
				};
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("This feature is coming soon!", "Print List of Staff Available To Work", UpgradeHelpers.Helpers.BoxButtons.OK);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.txtComment.Text = "";
			ViewModel.CurrDate = modGlobal.Shared.gStartTrans;
			ViewModel.CurrRow = 0;

			this.ViewModel.Text = "Employees Available To Work On " + ViewModel.CurrDate;
			FillAvailableGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		private void sprAvailable_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;

			if (Row == 0)
			{
				return;
			}
			ViewModel.sprAvailable.Col = 1;
			if (modGlobal.Clean(ViewModel.sprAvailable.Text) == "")
			{
				return;
			}
			ViewModel.CurrRow = Row;
			ViewModel.sprAvailable.Row = ViewModel.CurrRow;
			ViewModel.sprAvailable.Col = 6;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrRecord = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprAvailable.Text));
			ViewModel.sprAvailable.Col = 7;
			ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.sprAvailable.Text);

			GetEmployeeDetail();


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgAvailableToWork DefInstance
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

		public static dlgAvailableToWork CreateInstance()
		{
			PTSProject.dlgAvailableToWork theInstance = Shared.Container.Resolve< dlgAvailableToWork>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprAvailable.LifeCycleStartup();
			ViewModel.sprPhoneList.LifeCycleStartup();
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprAvailable.LifeCycleShutdown();
			ViewModel.sprPhoneList.LifeCycleShutdown();
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgAvailableToWork
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgAvailableToWorkViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgAvailableToWork m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}