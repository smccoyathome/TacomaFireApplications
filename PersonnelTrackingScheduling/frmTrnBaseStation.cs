using System;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmTrnBaseStation
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrnBaseStationViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmTrnBaseStation));
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


		private void frmTrnBaseStation_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}
		//*************************************************************
		//         Training Annual Paramedic Base Station Report
		//           Filtered by Year, Battalion/Shift/Groups
		//*************************************************************

		public void FormatReport()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 6;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			int iGroup = ViewModel.CurrGroup;

			if (TrainCL.GetPMAnnualBaseStationReport(ViewModel.CurrYear, ViewModel.CurrBatt, ViewModel.CurrShift, iGroup) != 0)
			{
				//continue
			}
			else
			{
				ViewManager.ShowMessage("There are no Paramedic/Training Records to report for Year!", "Training Annual OTEPReport", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}

			string sEmployeeName = "";
			int iCodeRow = 5;
			int iCurrRow = 6;


			while(!TrainCL.TrainingRecord.EOF)
			{
				ViewModel.sprReport.Row = iCurrRow;

				if (sEmployeeName == "")
				{ //first time

					ViewModel.sprReport.Col = 1;
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["state_number"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + "-" + modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = 4;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(group_number)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (modGlobal.Clean(TrainCL.TrainingRecord["group_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"])) > 0)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"]));
					}
					else
					{
						ViewModel.sprReport.Text = "";
					}

					if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Row = iCurrRow;
								ViewModel.sprReport.Col = i;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurrences"]));
								ViewModel.sprReport.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_hrs"]));
								break;
							}
						}
					}


				}
				else if (sEmployeeName == modGlobal.Clean(TrainCL.TrainingRecord["name_full"]))
				{

					if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar2 = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar2; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Row = iCurrRow;
								ViewModel.sprReport.Col = i;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurrences"]));
								ViewModel.sprReport.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_hrs"]));
								break;
							}
						}
					}
				}
				else
				{
					iCurrRow++;
					ViewModel.sprReport.Row = iCurrRow;
					ViewModel.sprReport.Col = 1;
					sEmployeeName = modGlobal.Clean(TrainCL.TrainingRecord["name_full"]);
					ViewModel.sprReport.Text = sEmployeeName;
					ViewModel.sprReport.Col = 2;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["state_number"]);
					ViewModel.sprReport.Col = 3;
					ViewModel.sprReport.Text = modGlobal.Clean(TrainCL.TrainingRecord["unit_code"]) + "-" + modGlobal.Clean(TrainCL.TrainingRecord["shift_code"]);
					ViewModel.sprReport.Col = 4;
					//UPGRADE_WARNING: (1068) GetVal(TrainCL.TrainingRecord(group_number)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (modGlobal.Clean(TrainCL.TrainingRecord["group_number"]) == "")
					{
						ViewModel.sprReport.Text = "";
					}
					else if (Convert.ToDouble(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"])) > 0)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["group_number"]));
					}
					else
					{
						ViewModel.sprReport.Text = "";
					}

					if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) != "")
					{
						ViewModel.sprReport.Row = iCodeRow;
						int tempForVar3 = ViewModel.sprReport.MaxCols;
						for (int i = 5; i <= tempForVar3; i++)
						{
							ViewModel.sprReport.Col = i;
							if (modGlobal.Clean(TrainCL.TrainingRecord["trn_month"]) == modGlobal.Clean(ViewModel.sprReport.Text))
							{
								ViewModel.sprReport.Row = iCurrRow;
								ViewModel.sprReport.Col = i;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_occurrences"]));
								ViewModel.sprReport.Col = i + 1;
								//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
								ViewModel.sprReport.Text = Convert.ToString(modGlobal.GetVal(TrainCL.TrainingRecord["total_hrs"]));
								break;
							}
						}
					}

				}
				TrainCL.TrainingRecord.MoveNext();
			}
			;

					}

		public void FormatHeadings()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.sprReport.Row = 6;
			ViewModel.sprReport.Row2 = ViewModel.sprReport.MaxRows;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Col2 = ViewModel.sprReport.MaxCols;
			ViewModel.sprReport.BlockMode = true;
			ViewModel.sprReport.Text = "";
			ViewModel.sprReport.BlockMode = false;

			string sHeading = "Annual Paramedic Base Station Report For ";

			sHeading = sHeading + ViewModel.CurrYear.ToString();
			ViewModel.sprReport.Row = 2;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;

			sHeading = "Base Station Reporting For Paramedics Only ";
			if ( ViewModel.CurrBatt == "")
			{
				sHeading = sHeading + "\\ All Battalions ";
			}
			else
			{
				sHeading = sHeading + "\\ Battalion " + ViewModel.CurrBatt + " ";
			}
			if ( ViewModel.CurrShift == "")
			{
				sHeading = sHeading + "\\ All Shifts ";
			}
			else
			{
				sHeading = sHeading + "\\ Shift " + ViewModel.CurrShift + " ";
			}
			if ( ViewModel.CurrGroup != 0)
			{
				sHeading = sHeading + "\\ Group " + ViewModel.CurrGroup.ToString();
			}
			ViewModel.sprReport.Row = 3;
			ViewModel.sprReport.Col = 1;
			ViewModel.sprReport.Text = sHeading;

		}

		public void LoadLists()
		{
			PTSProject.clsTraining TrainCL = Container.Resolve< clsTraining>();
			ViewModel.cboYear.Items.Clear();
			if (TrainCL.GetTrainingStandardYearList() != 0)
			{

				while(!TrainCL.TrainingRecord.EOF)
				{
					ViewModel.cboYear.AddItem(modGlobal.Clean(TrainCL.TrainingRecord["trn_year"]));
					TrainCL.TrainingRecord.MoveNext();
				};
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrYear = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboYear.Text));

			FormatHeadings();
			FormatReport();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Set Defaults
			if (DateTime.Now.Month == 1)
			{
				ViewModel.CurrYear = DateTime.Now.Year - 1;
			}
			else
			{
				ViewModel.CurrYear = DateTime.Now.Year;
			}
			ViewModel.cboYear.Text = ViewModel.CurrYear.ToString();
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.optGrp1.Checked = false;
			ViewModel.optGrp2.Checked = false;
			ViewModel.optGrp3.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrGroup = 0;

			FormatHeadings();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "TTraining Paramedic Base Station Reports"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/r Page /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintAbortMsg("Printing Training Paramedic Base Station Report");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprReport.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprReport.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprReport.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprReport.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			LoadLists();

			//Set Defaults
			if (DateTime.Now.Month == 1)
			{
				ViewModel.CurrYear = DateTime.Now.Year - 1;
			}
			else
			{
				ViewModel.CurrYear = DateTime.Now.Year;
			}
			ViewModel.cboYear.Text = ViewModel.CurrYear.ToString();
			ViewModel.optAll.Checked = true;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;
			ViewModel.optGrp1.Checked = false;
			ViewModel.optGrp2.Checked = false;
			ViewModel.optGrp3.Checked = false;
			ViewModel.CurrBatt = "";
			ViewModel.CurrGroup = 0;
			ViewModel.FirstTime = false;
			FormatHeadings();
			FormatReport();

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "1";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "2";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "3";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "A";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrBatt = "";
				ViewModel.CurrShift = "";
				ViewModel.CurrGroup = 0;
				ViewModel.optA.Checked = false;
				ViewModel.optB.Checked = false;
				ViewModel.optC.Checked = false;
				ViewModel.optD.Checked = false;
				ViewModel.optGrp1.Checked = false;
				ViewModel.optGrp2.Checked = false;
				ViewModel.optGrp3.Checked = false;

				FormatHeadings();
				FormatReport();

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "B";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "C";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrShift = "D";

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp1_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrGroup = 1;

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp2_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrGroup = 2;

				FormatHeadings();
				FormatReport();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optGrp3_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				if ( ViewModel.FirstTime)
				{
					return;
				}
				ViewModel.CurrGroup = 3;

				FormatHeadings();
				FormatReport();
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmTrnBaseStation DefInstance
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

		public static frmTrnBaseStation CreateInstance()
		{
			PTSProject.frmTrnBaseStation theInstance = Shared.Container.Resolve< frmTrnBaseStation>();
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
			ViewModel.sprReport.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprReport.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmTrnBaseStation
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmTrnBaseStationViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmTrnBaseStation m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}