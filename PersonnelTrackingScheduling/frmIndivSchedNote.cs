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

	public partial class frmIndivSchedNote
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivSchedNoteViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmIndivSchedNote));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmIndivSchedNote_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Save Note or Create new Note record and Exit

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;
			//string strSQL = "";
			string strNote = "";
			//string str1 = "", str2 = "";
			//int i = 0;

			if ( ViewModel.txtEdit.Text == "")
			{
				return;
			}

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				strNote = Strings.Replace(ViewModel.txtEdit.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim();

				oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + modGlobal.Shared.gReportUser + "','" + modGlobal.Shared.gStartTrans + "','" + strNote + "','" + modGlobal.Shared.gUser + "' ";
				oCmd.CommandType = CommandType.Text;
				oCmd.ExecuteNonQuery();
				ViewManager.DisposeView(this);
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Exit with out creating or saving note
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SQLScript = "";
			string strComment = "";
			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				SQLScript = "Select * from PersonnelScheduleNotes Where employee_id = '";
				SQLScript = SQLScript + modGlobal.Shared.gReportUser + "' and datediff(day,'";
				System.DateTime TempDate = DateTime.FromOADate(0);
				SQLScript = SQLScript + ((DateTime.TryParse(modGlobal.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gStartTrans);
				SQLScript = SQLScript + "',shift_start) >= 0 and datediff(day,'";
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				SQLScript = SQLScript + ((DateTime.TryParse(modGlobal.Shared.gEndTrans, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : modGlobal.Shared.gEndTrans);
				SQLScript = SQLScript + "',shift_start) <= 0";

				oCmd.CommandText = SQLScript;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					strComment = "";

					while(!oRec.EOF)
					{
						strComment = modGlobal.Clean(strComment) + modGlobal.Clean(oRec["note"]).Trim() + ";  ";
						oRec.MoveNext();
					};
				}

				if (modGlobal.Clean(strComment) != "")
				{
					ViewModel.txtNote.Text = modGlobal.Clean(strComment);
				}
				else
				{
					ViewModel.txtNote.Text = "No Schedule Notes exist";
				}

				if (modGlobal.Shared.gSecurity == "RO")
				{
					ViewModel.cmdOK.Enabled = false;
					ViewModel.txtNote.Enabled = false;
				}
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmIndivSchedNote DefInstance
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

		public static frmIndivSchedNote CreateInstance()
		{
			PTSProject.frmIndivSchedNote theInstance = Shared.Container.Resolve< frmIndivSchedNote>();
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

	public partial class frmIndivSchedNote
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmIndivSchedNoteViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmIndivSchedNote m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}