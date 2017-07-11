using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgScheduleDetail
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgScheduleDetailViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgScheduleDetail));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgScheduleDetail_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FillGrid()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			string sComment = "";
			string SavedComment = "";
			ViewModel.txtComment.Text = "";
			ViewModel.sprDetail.BlockMode = true;
			ViewModel.sprDetail.Row = 1;
			ViewModel.sprDetail.Row2 = ViewModel.sprDetail.MaxRows;
			ViewModel.sprDetail.Col = 1;
			ViewModel.sprDetail.Col2 = ViewModel.sprDetail.MaxCols;
			ViewModel.sprDetail.Text = "";
			ViewModel.sprDetail.BlockMode = false;
			int i = 1;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.lbTitle.Text = modGlobal.Shared.gEmployeeName + " Schedule Detail For " + ((DateTime.TryParse(modGlobal
					.Shared.gStartTrans, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : modGlobal.Shared.gStartTrans);

			oCmd.CommandText = "sp_GetIndLeaveSchedDetail '" + modGlobal.Shared.gEmployeeId + "','" + modGlobal.Shared.gStartTrans + "','" + modGlobal.Shared.gEndTrans + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");


			while(!oRec.EOF)
			{
				ViewModel.sprDetail.Row = i;
				ViewModel.sprDetail.Col = 1;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["UpdatedByName"]);

				if (sComment == "" && modGlobal.Clean(oRec["Comment"]) != "")
				{ //first comment
					sComment = modGlobal.Clean(oRec["Comment"]) + " authored by " + modGlobal.Clean(oRec["AuthoredBy"]);
					SavedComment = sComment;
					ViewModel.txtComment.Text = ViewModel.txtComment.Text + sComment + "\r" + "\n";
				}
				else if (modGlobal.Clean(oRec["Comment"]) == "")
				{
					//continue
				}
				else
				{
					sComment = modGlobal.Clean(oRec["Comment"]) + " authored by " + modGlobal.Clean(oRec["AuthoredBy"]);
					if (modGlobal.Clean(sComment) == modGlobal.Clean(SavedComment))
					{
						//continue
					}
					else
					{
						ViewModel.txtComment.Text = ViewModel.txtComment.Text + sComment + "\r" + "\n";
						SavedComment = sComment;
					}
				}
				//        If Clean(oRec("Comment"]) <> "" Then
				//            sprDetail.TextTip = TextTipFloating
				//            sprDetail.Col = 1
				//            sprDetail.Row = i
				//            sprDetail.CellNoteIndicator = CellNoteIndicatorShowAndFireEvent
				//            sprDetail.CellNote = Clean(oRec("Comment"]) & " authored by " & Clean(oRec("AuthoredBy"])
				//        End If
				ViewModel.sprDetail.Col = 2;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["LeaveUpdateDate"]);
				ViewModel.sprDetail.Col = 3;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["AMPM"]);
				ViewModel.sprDetail.Col = 4;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["TimeType"]);
				ViewModel.sprDetail.Col = 5;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["job_code"]);
				ViewModel.sprDetail.Col = 6;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["step"]);
				ViewModel.sprDetail.Col = 7;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprDetail.Col = 8;
				ViewModel.sprDetail.Text = modGlobal.Clean(oRec["position_code"]);

				i++;
				oRec.MoveNext();
			};
			ViewModel.sprDetail.MaxRows = i;
			ViewModel.txtComment.Visible = modGlobal.Clean(ViewModel.txtComment.Text) != "";

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//Private Sub sprDetail_TextTipFetch(ByVal Col As Long, ByVal Row As Long, MultiLine As Integer, TipWidth As Long, TipText As String, ShowTip As Boolean)
		//    If sprDetail.IsFetchCellNote Then
		//        sprDetail.SetTextTipAppearance "Arial", 9, True, False, &HFFFF&, &H0&
		//    End If
		//End Sub
		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgScheduleDetail DefInstance
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

		public static dlgScheduleDetail CreateInstance()
		{
			PTSProject.dlgScheduleDetail theInstance = Shared.Container.Resolve< dlgScheduleDetail>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprDetail.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprDetail.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgScheduleDetail
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgScheduleDetailViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgScheduleDetail m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}