using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgChangeMaxHoliday
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgChangeMaxHolidayViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgChangeMaxHoliday));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgChangeMaxHoliday_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}


		public void GetEmployeeInfo()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_EmployeeHolidayMax '" + modGlobal.Shared.gReportUser + "', '" + modGlobal.Shared.gReportYear.ToString() + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if (!oRec.EOF)
			{
				ViewModel.lblEmployeeName.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.txtTotal.Text = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["holiday_max"], "##.0");
			}


		}

		public void ChangeMAXHolidayTotals()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string SqlString = "Delete PersonnelHOLMAXOverride Where employee_id  = '";
			SqlString = SqlString + modGlobal.Shared.gReportUser + "' and year_applied = '";
			SqlString = SqlString + modGlobal.Shared.gReportYear.ToString() + "' ";
			oCmd.CommandText = SqlString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//spInsert_PersonnelHOLMAXOverride
			//UPGRADE_WARNING: (1068) GetVal(txtTotal.Text) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			if (Convert.ToDouble(modGlobal.GetVal(ViewModel.txtTotal.Text)) > 0)
			{
				SqlString = "spInsert_PersonnelHOLMAXOverride '";
				SqlString = SqlString + modGlobal.Shared.gReportUser + "', '";
				SqlString = SqlString + modGlobal.Shared.gReportYear.ToString() + "', ";
				SqlString = SqlString + UpgradeHelpers.Helpers.StringsHelper.Format(ViewModel.txtTotal.Text, "##.#") + " ";
				oCmd.CommandText = SqlString;
			}
			else
			{
				SqlString = "spInsert_PersonnelHOLMAXOverride '";
				SqlString = SqlString + modGlobal.Shared.gReportUser + "', '";
				SqlString = SqlString + modGlobal.Shared.gReportYear.ToString() + "', ";
				SqlString = SqlString + "0" + " ";
				oCmd.CommandText = SqlString;
			}
			oRec = ADORecordSetHelper.Open(oCmd, "");



		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.txtTotal.Text = "";
			GetEmployeeInfo();

		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ChangeMAXHolidayTotals();
			ViewManager.DisposeView(this);
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgChangeMaxHoliday DefInstance
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

		public static dlgChangeMaxHoliday CreateInstance()
		{
			PTSProject.dlgChangeMaxHoliday theInstance = Shared.Container.Resolve< dlgChangeMaxHoliday>();
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

	public partial class dlgChangeMaxHoliday
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgChangeMaxHolidayViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgChangeMaxHoliday m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}