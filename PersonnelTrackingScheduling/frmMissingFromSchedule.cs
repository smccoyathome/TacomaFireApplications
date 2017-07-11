using System;
using System.Data;
using System.Data.Common;
using System.Text;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmMissingFromSchedule
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMissingFromScheduleViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmMissingFromSchedule));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmMissingFromSchedule_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//***********************************************************
		//*  This Screen Displays Employees scheduled to Work but are
		//*  not scheduled... possibility that schedule was deleted
		//*  accidently
		//***********************************************************

		public void ScheduleEmployee()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.JobCode = modGlobal.GetJobCode(ViewModel.Empid);
			ViewModel.Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(ViewModel.Empid)));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.StoredProcedure;
			oCmd.CommandText = "spInsertSchedule";
			oCmd.ExecuteNonQuery(new object[]{ ViewModel.AMShiftStart, ViewModel.Empid, ViewModel.AssignID, ViewModel
            .TimeCode, ViewModel.PayUp, ViewModel.JobCode, ViewModel.Step, DateTime.Now, modGlobal.Shared.gUser});

			oCmd.ExecuteNonQuery(new object[]{ ViewModel.PMShiftStart, ViewModel.Empid, ViewModel.AssignID, ViewModel
            .TimeCode, ViewModel.PayUp, ViewModel.JobCode, ViewModel.Step, DateTime.Now, modGlobal.Shared.gUser});

			ViewModel.Empid = "";
			ViewModel.JobCode = "";
			ViewModel.Step = 1;
			ViewModel.PayUp = 0;

			LoadMIAList();
		}

		public void LoadMIAList()
		{
			//Load sprMissing

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;
			string strComment = "";

			//Clear list
			ViewModel.sprMissing.BlockMode = true;
			ViewModel.sprMissing.Row = 1;
			ViewModel.sprMissing.Row2 = ViewModel.sprMissing.MaxRows;
			ViewModel.sprMissing.Col = 1;
			ViewModel.sprMissing.Col2 = ViewModel.sprMissing.MaxCols;
			ViewModel.sprMissing.Text = "";
			ViewModel.sprMissing.BlockMode = false;
			ViewModel.sprMissing.MaxRows = 1;
			int CurrRow = 1;

			StringBuilder SQLScript = new System.Text.StringBuilder();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_MissingFromSchedule '" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "' ";

			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprMissing.Row = CurrRow;
				strComment = "";
				ViewModel.sprMissing.Col = 1;
				ViewModel.sprMissing.Text = Convert.ToString(oRec["name_full"]).Trim();

				//fetch any schedule notes...
				ocmd2.Connection = modGlobal.oConn;
				ocmd2.CommandType = CommandType.Text;

				SQLScript = new System.Text.StringBuilder("Select * from PersonnelScheduleNotes Where employee_id = '");
				SQLScript.Append(Convert.ToString(oRec["employee_id"]).Trim() + "' and datediff(day,'");
				System.DateTime TempDate = DateTime.FromOADate(0);
				SQLScript.Append((DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gStartTrans);
				SQLScript.Append("',shift_start) >= 0 and datediff(day,'");
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				SQLScript.Append((DateTime.TryParse(modGlobal.Shared.gEndTrans, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : modGlobal.Shared.gEndTrans);
				SQLScript.Append("',shift_start) <= 0");

				ocmd2.CommandText = SQLScript.ToString();
				orec2 = ADORecordSetHelper.Open(ocmd2, "");

				if (!orec2.EOF)
				{
					strComment = "";

					while(!orec2.EOF)
					{
						strComment = modGlobal.Clean(strComment) + modGlobal.Clean(orec2["note"]).Trim() + ";  ";
						orec2.MoveNext();
					};
				}

				//comment
				if (modGlobal.Clean(strComment) != "")
				{
					ViewModel.sprMissing.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprMissing.Col = 1;
					ViewModel.sprMissing.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprMissing.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprMissing.CellNote = strComment;
				}
				ViewModel.sprMissing.Col = 2;
				ViewModel.sprMissing.Text = Convert.ToString(oRec["employee_id"]).Trim();
				if (CurrRow == 1)
				{
					ViewModel.Empid = Convert.ToString(oRec["employee_id"]).Trim();
				}
				ViewModel.sprMissing.Col = 3;
				ViewModel.sprMissing.Text = modGlobal.Clean(oRec["KOT"]);
				if (CurrRow == 1)
				{
					ViewModel.TimeCode = modGlobal.Clean(oRec["KOT"]);
					if (modGlobal.Shared.gBatt == "2")
					{
						if ( ViewModel.TimeCode == "REG")
						{
							ViewModel.AssignID = modGlobal.ASGN182ROV;
						}
						else
						{
							ViewModel.AssignID = modGlobal.ASGN182DBT;
						}
					}
					else if (modGlobal.Shared.gBatt == "1")
					{
						if ( ViewModel.TimeCode == "REG")
						{
							ViewModel.AssignID = modGlobal.ASGN181ROV;
						}
						else
						{
							ViewModel.AssignID = modGlobal.ASGN181DBT;
						}
					}
					else
					{
						//gBatt = "3"
						if ( ViewModel.TimeCode == "REG")
						{
							ViewModel.AssignID = modGlobal.ASGN183ROV;
						}
						else
						{
							ViewModel.AssignID = modGlobal.ASGN183DBT;
						}
					}
				}

				CurrRow++;
				ViewModel.sprMissing.MaxRows = CurrRow;
				oRec.MoveNext();
			};
			ViewModel.cmdAdd.Enabled = ViewModel.sprMissing.DataRowCnt > 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAdd_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ScheduleEmployee();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.AMShiftStart = ((DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("M/d/yyyy") : modGlobal.Shared.gStartTrans) + " 7:00AM";
			System.DateTime TempDate2 = DateTime.FromOADate(0);
			ViewModel.PMShiftStart = ((DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : modGlobal.Shared.gStartTrans) + " 7:00PM";
			ViewModel.Empid = "";
			ViewModel.JobCode = "";
			ViewModel.Step = 1;
			ViewModel.PayUp = 0;

			//default Assignment ID
			if (modGlobal.Shared.gBatt == "2")
			{
				ViewModel.AssignID = modGlobal.ASGN182ROV;
			}
			else if (modGlobal.Shared.gBatt == "1")
			{
				ViewModel.AssignID = modGlobal.ASGN181ROV;
			}
			else
			{
				//gBatt = "3"
				ViewModel.AssignID = modGlobal.ASGN183ROV;
			}

			//default TimeCode
			ViewModel.TimeCode = "REG";

			LoadMIAList();

		}

		private void sprMissing_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;

			if (Row == 0)
			{
				return;
			}
			ViewModel.SelectedRow = Row;
			ViewModel.sprMissing.Row = ViewModel.SelectedRow;
			ViewModel.sprMissing.Col = 2;
			ViewModel.Empid = modGlobal.Clean(ViewModel.sprMissing.Text);
			ViewModel.sprMissing.Col = 3;
			ViewModel.TimeCode = modGlobal.Clean(ViewModel.sprMissing.Text);

			if (modGlobal.Shared.gBatt == "2")
			{
				if ( ViewModel.TimeCode == "REG")
				{
					ViewModel.AssignID = modGlobal.ASGN182ROV;
				}
				else
				{
					ViewModel.AssignID = modGlobal.ASGN182DBT;
				}
			}
			else if (modGlobal.Shared.gBatt == "1")
			{
				if ( ViewModel.TimeCode == "REG")
				{
					ViewModel.AssignID = modGlobal.ASGN181ROV;
				}
				else
				{
					ViewModel.AssignID = modGlobal.ASGN181DBT;
				}
			}
			else
			{
				//gBatt = "3"
				if ( ViewModel.TimeCode == "REG")
				{
					ViewModel.AssignID = modGlobal.ASGN183ROV;
				}
				else
				{
					ViewModel.AssignID = modGlobal.ASGN183DBT;
				}
			}

		}

		private void sprMissing_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprMissing.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprMissing.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprMissing.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmMissingFromSchedule DefInstance
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

		public static frmMissingFromSchedule CreateInstance()
		{
			PTSProject.frmMissingFromSchedule theInstance = Shared.Container.Resolve< frmMissingFromSchedule>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprMissing.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprMissing.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmMissingFromSchedule
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmMissingFromScheduleViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmMissingFromSchedule m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}