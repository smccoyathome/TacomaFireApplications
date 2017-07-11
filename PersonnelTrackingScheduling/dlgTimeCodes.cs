using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgTimeCodes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTimeCodesViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgTimeCodes));
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


		private void dlgTimeCodes_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void FillGrids()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.sprTimeCode.BlockMode = true;
			ViewModel.sprTimeCode.Row = 1;
			ViewModel.sprTimeCode.Row2 = ViewModel.sprTimeCode.MaxRows;
			ViewModel.sprTimeCode.Col = 1;
			ViewModel.sprTimeCode.Col2 = 5;
			ViewModel.sprTimeCode.Text = "";
			ViewModel.sprTimeCode.BlockMode = false;
			ViewModel.sprOrderCode.BlockMode = true;
			ViewModel.sprOrderCode.Row = 1;
			ViewModel.sprOrderCode.Row2 = ViewModel.sprOrderCode.MaxRows;
			ViewModel.sprOrderCode.Col = 1;
			ViewModel.sprOrderCode.Col2 = 3;
			ViewModel.sprOrderCode.Text = "";
			ViewModel.sprOrderCode.BlockMode = false;
			ViewModel.sprJobCode.BlockMode = true;
			ViewModel.sprJobCode.Row = 1;
			ViewModel.sprJobCode.Row2 = ViewModel.sprJobCode.MaxRows;
			ViewModel.sprJobCode.Col = 1;
			ViewModel.sprJobCode.Col2 = 3;
			ViewModel.sprJobCode.Text = "";
			ViewModel.sprJobCode.BlockMode = false;
			ViewModel.sprLeaveAllowed.BlockMode = true;
			ViewModel.sprLeaveAllowed.Row = 1;
			ViewModel.sprLeaveAllowed.Row2 = ViewModel.sprLeaveAllowed.MaxRows;
			ViewModel.sprLeaveAllowed.Col = 1;
			ViewModel.sprLeaveAllowed.Col2 = ViewModel.sprLeaveAllowed.MaxCols;
			ViewModel.sprLeaveAllowed.Text = "";
			ViewModel.sprLeaveAllowed.BlockMode = false;


			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "sp_GetTimeCodeList ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int i = 1;

			while(!oRec.EOF)
			{
				ViewModel.sprTimeCode.Row = i;
				ViewModel.sprTimeCode.Col = 1;
				ViewModel.sprTimeCode.Text = modGlobal.Clean(oRec["time_code_id"]);
				ViewModel.sprTimeCode.Col = 2;
				//UPGRADE_WARNING: (1068) GetVal(oRec(a_a_type)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["a_a_type"])) > 0)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprTimeCode.Text = Convert.ToString(modGlobal.GetVal(oRec["a_a_type"]));
				}
				else
				{
					ViewModel.sprTimeCode.Text = "";
				}
				ViewModel.sprTimeCode.Col = 3;
				//UPGRADE_WARNING: (1068) GetVal(oRec(a_a_type_2)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(oRec["a_a_type_2"])) > 0)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					ViewModel.sprTimeCode.Text = Convert.ToString(modGlobal.GetVal(oRec["a_a_type_2"]));
				}
				else
				{
					ViewModel.sprTimeCode.Text = "";
				}
				ViewModel.sprTimeCode.Col = 4;
				ViewModel.sprTimeCode.Text = modGlobal.Clean(oRec["description"]);
				ViewModel.sprTimeCode.Col = 5;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprTimeCode.Text = Convert.ToString(modGlobal.GetVal(oRec["timecode_sys_id"]));


				i++;
				oRec.MoveNext();

			};
			ViewModel.sprTimeCode.MaxRows = i;

			oCmd.CommandText = "spSelect_SAPOrderCodes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			i = 1;

			while(!oRec.EOF)
			{
				ViewModel.sprOrderCode.Row = i;
				ViewModel.sprOrderCode.Col = 1;
				ViewModel.sprOrderCode.Text = modGlobal.Clean(oRec["order_code"]);
				ViewModel.sprOrderCode.Col = 2;
				ViewModel.sprOrderCode.Text = modGlobal.Clean(oRec["order_description"]);
				ViewModel.sprOrderCode.Col = 3;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprOrderCode.Text = Convert.ToString(modGlobal.GetVal(oRec["order_id"]));

				i++;
				oRec.MoveNext();

			};
			ViewModel.sprOrderCode.MaxRows = i;

			oCmd.CommandText = "spJobCodeList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			i = 1;

			while(!oRec.EOF)
			{
				ViewModel.sprJobCode.Row = i;
				ViewModel.sprJobCode.Col = 1;
				ViewModel.sprJobCode.Text = modGlobal.Clean(oRec["job_code_id"]);
				ViewModel.sprJobCode.Col = 2;
				ViewModel.sprJobCode.Text = modGlobal.Clean(oRec["job_title"]);

				i++;
				oRec.MoveNext();

			};
			ViewModel.sprJobCode.MaxRows = i;

			oCmd.CommandText = "spSelect_AuthorizedLeave ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			i = 1;

			while(!oRec.EOF)
			{
				ViewModel.sprLeaveAllowed.Row = i;
				ViewModel.sprLeaveAllowed.Col = 1;
				ViewModel.sprLeaveAllowed.Text = modGlobal.Clean(oRec["label"]);
				ViewModel.sprLeaveAllowed.Col = 2;
				ViewModel.sprLeaveAllowed.Text = modGlobal.Clean(oRec["leave_allowed"]);

				i++;
				oRec.MoveNext();

			};


		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.sprOrderCode.Visible = false;
			ViewModel.sprJobCode.Visible = false;
			ViewModel.sprTimeCode.Visible = true;
			ViewModel.sprLeaveAllowed.Visible = false;

			FillGrids();
		}

		[UpgradeHelpers.Events.Handler]
		internal void optJobCode_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optJobCode.Checked)
				{
					ViewModel.sprTimeCode.Visible = false;
					ViewModel.sprJobCode.Visible = true;
					ViewModel.sprOrderCode.Visible = false;
					ViewModel.sprLeaveAllowed.Visible = false;
				}
				else
				{
					ViewModel.sprJobCode.Visible = false;
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optLeaveAllowed_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optLeaveAllowed.Checked)
				{
					ViewModel.sprLeaveAllowed.Visible = true;
					ViewModel.sprTimeCode.Visible = false;
					ViewModel.sprJobCode.Visible = false;
					ViewModel.sprOrderCode.Visible = false;
				}
				else
				{
					ViewModel.sprLeaveAllowed.Visible = false;
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optOrderCode_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optOrderCode.Checked)
				{
					ViewModel.sprTimeCode.Visible = false;
					ViewModel.sprJobCode.Visible = false;
					ViewModel.sprOrderCode.Visible = true;
					ViewModel.sprLeaveAllowed.Visible = false;
				}
				else
				{
					ViewModel.sprOrderCode.Visible = false;
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optTimeCode_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.optTimeCode.Checked)
				{
					ViewModel.sprTimeCode.Visible = true;
					ViewModel.sprOrderCode.Visible = false;
					ViewModel.sprJobCode.Visible = false;
					ViewModel.sprLeaveAllowed.Visible = false;
				}
				else
				{
					ViewModel.sprTimeCode.Visible = false;
				}

			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgTimeCodes DefInstance
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

		public static dlgTimeCodes CreateInstance()
		{
			PTSProject.dlgTimeCodes theInstance = Shared.Container.Resolve< dlgTimeCodes>();
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
			ViewModel.sprLeaveAllowed.LifeCycleStartup();
			ViewModel.sprOrderCode.LifeCycleStartup();
			ViewModel.sprTimeCode.LifeCycleStartup();
			ViewModel.sprJobCode.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprLeaveAllowed.LifeCycleShutdown();
			ViewModel.sprOrderCode.LifeCycleShutdown();
			ViewModel.sprTimeCode.LifeCycleShutdown();
			ViewModel.sprJobCode.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgTimeCodes
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgTimeCodesViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgTimeCodes m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}