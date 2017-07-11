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

	public partial class frmEmployeeNotes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeNotesViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEmployeeNotes));
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


		private void frmEmployeeNotes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		public void ClearFields()
		{
			ViewModel.lbEmpID.Text = "";
			ViewModel.lbNoteID.Text = "";
			ViewModel.txtNewNote.Text = "";
			ViewModel.sprPastComments.MaxRows = 50;
			ViewModel.sprPastComments.Row = 1;
			ViewModel.sprPastComments.Row2 = ViewModel.sprPastComments.MaxRows;
			ViewModel.sprPastComments.Col = 1;
			ViewModel.sprPastComments.Col2 = ViewModel.sprPastComments.MaxCols;
			ViewModel.sprPastComments.BlockMode = true;
			ViewModel.sprPastComments.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprPastComments.Text = "";
			ViewModel.sprPastComments.BlockMode = false;
			ViewModel.cmdAddUpdate.Enabled = true;
			ViewModel.cmdNewNote.Enabled = true;


		}

		public void FindEmployee()
		{

			for ( int i = 0; i <= ViewModel.cboEmpList.Items.Count - 1; i++ )
			{
				//Come Here - for employee id change
				if ( ViewModel.cboEmpList.GetListItem(i).Substring(Math.Max(ViewModel.cboEmpList.GetListItem(i).Length - 5, 0)) == modGlobal.Shared.gAssignID )
				{
					ViewModel.cboEmpList.Text = ViewModel.cboEmpList.GetListItem(i);
					break;
				}
			}

			//Come Here - for employee id change
			if ( modGlobal.Clean(ViewModel.cboEmpList.Text) != "" )
			{
				ViewModel.CurrEmpID = ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0));
				ViewModel.lbEmpID.Text = ViewModel.CurrEmpID;
			}

			this.ViewModel.Text = "Employee Notes For: " + modGlobal.Clean(ViewModel.cboEmpList.Text);

			//Get Past Notes
			GetPastComments();

		}

		public void GetPastComments()
		{
			int CellHeight = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strComment = "";
			ViewModel.txtNewNote.Text = "";
			ViewModel.lbNoteID.Text = "";
			ViewModel.sprPastComments.Row = 1;
			ViewModel.sprPastComments.MaxRows = 1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spSelect_PersonnelNotesByEmployeeID '" + ViewModel.CurrEmpID + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				ViewModel.sprPastComments.Col = 1;
				ViewModel.sprPastComments.BackColor = modGlobal.Shared.LT_GRAY;
				ViewModel.sprPastComments.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeStaticText;
				(ViewModel.sprPastComments.ActiveSheet.Cells[ViewModel.sprPastComments.Row, ViewModel.sprPastComments.Col].CellType as FarPoint.ViewModels.TextCellType).WordWrap = true;
				strComment = "";

				if ( modGlobal.Clean(oRec["author"]) == modGlobal.Clean(oRec["last_update_by"]) )
				{
					if ( Convert.ToDateTime(oRec["date_added"]).ToString("M/d/yyyy") == Convert.ToDateTime(oRec["last_updated"]).ToString("M/d/yyyy") )
					{

						strComment = Convert.ToDateTime(oRec["date_added"]).ToString("M/d/yyyy") +
						             " (by " + modGlobal.Clean(oRec["author"]) + "):  " +
						             modGlobal.Clean(oRec["comment"]);
					}
					else
					{
						strComment = "Last Updated on " + Convert.ToDateTime(oRec["last_updated"]).ToString("M/d/yyyy") +
						             " (by " + modGlobal.Clean(oRec["author"]) + "):  " +
						             modGlobal.Clean(oRec["comment"]);
					}
				}
				else
				{
					strComment = "Last Updated on " + Convert.ToDateTime(oRec["last_updated"]).ToString("M/d/yyyy") +
					             " (by " + modGlobal.Clean(oRec["last_update_by"]) + "):  " +
					             modGlobal.Clean(oRec["comment"]);
				}
				ViewModel.sprPastComments.Text = strComment;
				ViewModel.sprPastComments.Col = 2;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprPastComments.Text = Convert.ToString(modGlobal.GetVal(oRec["note_id"]));

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPastComments.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				CellHeight = Convert.ToInt32(ViewModel.sprPastComments.getMaxTextCellHeight() * 2);
				ViewModel.sprPastComments.SetRowHeight(ViewModel.sprPastComments.Row, CellHeight);

				oRec.MoveNext();
				(ViewModel.sprPastComments.MaxRows)++;
				(ViewModel.sprPastComments.Row)++;
			};
			ViewModel.cmdAddUpdate.Enabled = true;
			ViewModel.cmdNewNote.Enabled = true;


		}

		[UpgradeHelpers.Events.Handler]
		internal void cboEmpList_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboEmpList.SelectedIndex == -1 )
			{
				return ;
			}

			ClearFields();
			ViewModel.CurrEmpID = "";
			ViewModel.CurrEmpID = modGlobal.Clean(ViewModel.cboEmpList.Text.Substring(Math.Max(ViewModel.cboEmpList.Text.Length - 5, 0)));
			ViewModel.lbEmpID.Text = ViewModel.CurrEmpID;
			this.ViewModel.Text = "Employee Notes For: " + modGlobal.Clean(ViewModel.cboEmpList.Text);

			GetPastComments();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAddUpdate_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			if ( modGlobal.Clean(ViewModel.CurrEmpID) == "" )
			{
				return ;
			}

			// If there is no note... then exit sub
			if ( modGlobal.Clean(ViewModel.txtNewNote.Text) == "" )
			{
				GetPastComments();
				ViewModel.txtNewNote.Text = "";
				ViewModel.lbNoteID.Text = "";
				return ;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string sComment = "";
			sComment = modGlobal.Clean(ViewModel.txtNewNote.Text);
			sComment = Strings.Replace(sComment, "'", "''", 1, -1, CompareMethod.Binary);
			string sFlag = "Y";
			string sDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

			string SqlString = "";

			if ( ViewModel.lbNoteID.Text != "" )
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				SqlString = "spUpdate_PersonnelNotes " + Convert.ToString(modGlobal.GetVal(ViewModel.lbNoteID.Text)) + ", ";
				SqlString = SqlString + "'" + sDate + "', '" + modGlobal.Shared.gUser + "', ";
				SqlString = SqlString + "'" + sComment + "' ";
				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			else
			{
				SqlString = "spInsert_PersonnelNotes '" + ViewModel.CurrEmpID + "', ";
				SqlString = SqlString + "'" + sDate + "', '" + modGlobal.Shared.gUser + "', ";
				SqlString = SqlString + "'" + sComment + "', '" + sFlag + "' ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}

			GetPastComments();
			ViewModel.txtNewNote.Text = "";
			ViewModel.lbNoteID.Text = "";


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNewNote_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.cboEmpList.SelectedIndex == -1 )
			{
				return ;
			}
			ViewModel.lbNoteID.Text = "";
			ViewModel.txtNewNote.Text = "";
			ViewModel.cmdNewNote.Enabled = false;
			ViewModel.cmdAddUpdate.Enabled = true;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string strName = "";
			ViewModel.CurrEmpID = "";
			ViewModel.cboEmpList.Items.Clear();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			strSQL = "spFullNameList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				strName = Convert.ToString(oRec["name_full"]).Trim() + "  :" + Convert.ToString(oRec["employee_id"]);
				ViewModel.cboEmpList.AddItem(strName);
				oRec.MoveNext();
			};

			ClearFields();
			if ( modGlobal.Shared.gAssignID != "" )
			{
				FindEmployee();
			}

		}

		private void sprPastComments_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;

			if ( Row == 0 )
			{
				return ;
			}

			if ( Row > ViewModel.sprPastComments.DataRowCnt )
			{
				return ;
			}

			int CurrRow = Row;
			ViewModel.sprPastComments.Col = 2;
			ViewModel.sprPastComments.Row = CurrRow;
			ViewModel.lbNoteID.Text = ViewModel.sprPastComments.Text;

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			string strSQL = "";

			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			strSQL = "spSelect_PersonnelNotesByID " + Convert.ToString(modGlobal.GetVal(ViewModel.lbNoteID.Text)) + " ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{
				ViewModel.txtNewNote.Text = modGlobal.Clean(oRec["comment"]);
			}



		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmEmployeeNotes DefInstance
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

		public static frmEmployeeNotes CreateInstance()
		{
			PTSProject.frmEmployeeNotes theInstance = Shared.Container.Resolve<frmEmployeeNotes>();
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
			ViewModel.sprPastComments.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPastComments.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmEmployeeNotes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEmployeeNotesViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmEmployeeNotes m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}