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

	public partial class frmNote
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNoteViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNote));
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


		private void frmNote_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//******************************************************
		//Battalion Scheduler Note form
		//Called from frmBattSched
		//******************************************************
		//ADODB
		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Exit with out creating or saving note
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Save Note or Create new Note record and Exit

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			//string strSQL = "";
			string strNote = "";
			//string str1 = "", str2 = "";
			//int i = 0;

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				//    If Len(Trim$(txtNote.Text)) > 254 Then
				//        MsgBox "Note field contains too many characters. Please edit comments", vbInformation, "Battalion Scheduler"
				//        txtNote.Text = Left$(Trim$(txtNote.Text), 254)
				//        Exit Sub
				//    End If
				//
				//     strNote = Left$(Trim$(txtNote.Text), 254)
				strNote = Strings.Replace(ViewModel.txtNote.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim();
				//    Do Until InStr(1, strNote, "'") = 0
				//        I = InStr(1, strNote, "'")
				//        str1 = Left$(strNote, I - 1)
				//        str2 = Right$(strNote, Len(strNote) - I)
				//        strNote = str1 & "-" & str2
				//    Loop
				ViewModel.txtNote.Text = strNote;



				if ( ViewModel.NoteID == 0)
				{
					//New note for this shift
					if (strNote != "")
					{
						//Add new Note record
						oCmd.CommandText = "select next_note = MAX(note_id) + 1 From Schedule_Notes";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						//Test for existing notes
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if (!Convert.IsDBNull(oRec["next_note"]))
						{
							ViewModel.NoteID = Convert.ToInt32(oRec["next_note"]);
						}
						else
						{
							ViewModel.NoteID = 1;
						}
						oCmd.CommandType = CommandType.StoredProcedure;
						oCmd.CommandText = "spInsertNote";
						oCmd.ExecuteNonQuery(new object[] { ViewModel.NoteID, modGlobal.Shared.gNoteDate + " 12:00AM", "1", strNote });
					}
				}
				else
				{
					//Update current note
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "spUpdateNote " + ViewModel.NoteID.ToString() + ",'" + strNote + "'";
					oCmd.ExecuteNonQuery();
				}
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

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Create display title
			//Retrieve existing note

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			try
			{

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				ViewModel.lbTitle.Text = "Notes for " + modGlobal.Shared.gNoteDate;

				//get existing note
				strSQL = "select note_id, battalion_code, shift_start, note From Schedule_Notes";
				strSQL = strSQL + " Where battalion_code = '1' And shift_start = '" + modGlobal.Shared.gNoteDate + " 12:00AM" + "'";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					ViewModel.NoteID = Convert.ToInt32(oRec["note_id"]);
					ViewModel.txtNote.Text = Convert.ToString(oRec["note"]);
				}
				else
				{
					ViewModel.NoteID = 0;
					ViewModel.txtNote.Text = "";
				}

				if (modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "CPT")
				{
					ViewModel.lbLocked.Visible = true;
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

		public static frmNote DefInstance
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

		public static frmNote CreateInstance()
		{
			PTSProject.frmNote theInstance = Shared.Container.Resolve< frmNote>();
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
			ViewModel.Shape1.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.Shape1.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmNote
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNoteViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNote m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}