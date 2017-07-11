using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmMakeShiftAvailable
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMakeShiftAvailableViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmMakeShiftAvailable));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmMakeShiftAvailable_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//********************************************
		//*** frmMakeShiftAvailable Screen         ***
		//********************************************
		//*** This screen is displayed when a VAC  ***
		//*** or HOL is deleted and the shift is   ***
		//*** available to be given out by BC/ISO  ***
		//********************************************

		public void AddAvailableShift()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			if (!Information.IsDate(ViewModel.SelectedDate))
			{
				return;
			}
			if ( ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked && ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
			{
				return;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			if ( ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.lbExistAM.Text == "NA")
			{
				ViewModel.SelectedSchedDate = ViewModel.SelectedDate.Trim() + " 7:00 AM";
				SqlString = "spInsertVacationAvailable '" + ViewModel.SelectedSchedDate + "','";
				SqlString = SqlString + ViewModel.dtpGiveOut.Text + "', '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',";
				SqlString = SqlString + " NULL, NULL, '" + modGlobal.Clean(Strings.Replace(ViewModel.txtAvailComment.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				SqlString = "";
			}

			if ( ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked && ViewModel.lbExistPM.Text == "NA")
			{
				ViewModel.SelectedSchedDate = ViewModel.SelectedDate.Trim() + " 7:00 PM";
				SqlString = "spInsertVacationAvailable '" + ViewModel.SelectedSchedDate + "','";
				SqlString = SqlString + ViewModel.dtpGiveOut.Text + "', '" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',";
				SqlString = SqlString + " NULL, NULL, '" + modGlobal.Clean(Strings.Replace(ViewModel.txtAvailComment.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				SqlString = "";
			}

		}

		public void GetDailyTotals()
		{
			//This subroutine runs when a day is selected on Month Calendar
			//The AM & PM total scheduled personnel for selected date are
			//displayed in label controls below calendar

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Initialize Leave Total Labels
			ViewModel.lbREGam.Text = "";
			ViewModel.lbREGpm.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + ViewModel.SelectedDate + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				modGlobal
					.Shared.gMAXLEAVE = Convert.ToInt32(modGlobal.GetVal(oRec["max_leave_allowed"]));
			}
			else
			{
				modGlobal.Shared.gMAXLEAVE = 10;
			}

			//Select AM Leave Totals for selected date
			string NewDate = ViewModel.SelectedDate + " 7:00AM";
			ViewModel.lbSelectAM.Text = NewDate;
			oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbREGam.Text = "0";
				ViewModel.lbExistAM.Text = "NA";
			}


			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV")
				{

				}
				else
				{
					ViewModel.lbREGam.Text = Convert.ToString(oRec["total_leave"]);
					ViewModel.lbExistAM.Text = modGlobal.Clean(oRec["Available"]);
				}
				oRec.MoveNext();
			};

			//Select PM Leave Totals for selected date
			NewDate = ViewModel.SelectedDate + " 7:00PM";
			ViewModel.lbSelectPM.Text = NewDate;
			oCmd.CommandText = "sp_GetAllLeaveCounts '" + NewDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				ViewModel.lbREGpm.Text = "0";
				ViewModel.lbExistPM.Text = "NA";
			}




			while(!oRec.EOF)
			{
				if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "PM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "HZM")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "MRN")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "FCC")
				{

				}
				else if (modGlobal.Clean(oRec["assignment_type_code"]).Trim() == "RESV")
				{

				}
				else
				{
					ViewModel.lbREGpm.Text = Convert.ToString(oRec["total_leave"]);
					ViewModel.lbExistPM.Text = modGlobal.Clean(oRec["Available"]);
				}
				oRec.MoveNext();
			};


			//UPGRADE_WARNING: (1068) GetVal(lbREGam.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbREGam.Text)) >= modGlobal.Shared.gMAXLEAVE)
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			//UPGRADE_WARNING: (1068) GetVal(lbREGpm.Caption) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.lbREGpm.Text)) >= modGlobal.Shared.gMAXLEAVE)
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Unchecked;
			}
			else
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}

			if ( ViewModel.chkAM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked || ViewModel.chkPM.CheckState == UpgradeHelpers.Helpers.CheckState.Checked)
			{
				ViewModel.cmdAvailDone.Enabled = true;
				ViewModel.txtAvailComment.Text = "";
				ViewModel.lbAvailComment.Visible = true;
				ViewModel.txtAvailComment.Visible = true;
			}
			else
			{
				ViewModel.cmdAvailDone.Enabled = false;
				ViewModel.lbAvailComment.Visible = false;
				ViewModel.txtAvailComment.Visible = false;
			}
			ViewModel.lbSelectAM.Visible = true;
			ViewModel.lbSelectPM.Visible = true;
			ViewModel.lbREGam.Visible = true;
			ViewModel.lbREGpm.Visible = true;


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
			ViewModel.dtpGiveOut.Text = DateTime.Parse(ViewModel.SelectedDate).AddDays(-14).ToString("MM/dd/yyyy");
			GetDailyTotals();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAvailDone_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.cmdAvailDone.Enabled = false;

			AddAvailableShift();
			ViewModel.txtAvailComment.Text = "";
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.calAvail.SelectionRange.Start = DateTime.Parse(modGlobal.Shared.gDetailDate);
			ViewModel.calAvail.SelectionRange.End = DateTime.Parse(modGlobal.Shared.gDetailDate);
			ViewModel.txtAvailComment.Text = "";
			if (modGlobal.Shared.gAMShift)
			{
				ViewModel.chkAM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}
			if (modGlobal.Shared.gPMShift)
			{
				ViewModel.chkPM.CheckState = UpgradeHelpers.Helpers.CheckState.Checked;
			}

			if (modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID")
			{
				ViewModel.cmdAvailDone.Enabled = true;
			}
			else
			{
				ViewModel.cmdAvailDone.Enabled = false;
				ViewManager.ShowMessage("You do not have the security to make this Shift Available.", "Make Shift Available", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmMakeShiftAvailable DefInstance
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

		public static frmMakeShiftAvailable CreateInstance()
		{
			PTSProject.frmMakeShiftAvailable theInstance = Shared.Container.Resolve< frmMakeShiftAvailable>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmMakeShiftAvailable
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMakeShiftAvailableViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmMakeShiftAvailable m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}