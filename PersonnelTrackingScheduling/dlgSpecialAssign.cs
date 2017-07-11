using Microsoft.VisualBasic;
using System;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgSpecialAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSpecialAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgSpecialAssign));
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


		private void dlgSpecialAssign_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		//***********************************************
		//* Dialog to gather information for Scheduling *
		//* Special Assignments                         *
		//***********************************************
		//No Data Access
		[UpgradeHelpers.Events.Handler]
		internal void cmdCancel_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = "";
			modGlobal.Shared.gEndTrans = "";
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOK_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Check state of check box/calendar controls and
			//Update global start/end variables
			//Unload form

			if ( ViewModel.chkBothShifts.Visible)
			{
				if ( ViewModel.chkBothShifts.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked)
				{
					if (modGlobal.Shared.gStartTrans.Substring(Math.Max(modGlobal.Shared.gStartTrans.Length - 2, 0)) == "AM")
					{
						modGlobal.Shared.gEndTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 2, modGlobal.Shared.gStartTrans.Length)) + "PM";
					}
					modGlobal.Shared.gFullShift = 0;
				}
				else
				{
					if (modGlobal.Shared.gStartTrans.Substring(Math.Max(modGlobal.Shared.gStartTrans.Length - 2, 0)) == "PM")
					{
						modGlobal.Shared.gStartTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 2, modGlobal.Shared.gStartTrans.Length)) + "AM";
					}
					modGlobal.Shared.gFullShift = -1;
				}
			}
			else if ( ViewModel.lbStart.Visible)
			{
				modGlobal.Shared.gStartTrans = ViewModel.calStart.Value.Date.ToString("M/d/yyyy") + modGlobal.Shared.gStartTrans.Substring(Math.Max(modGlobal.Shared.gStartTrans.Length - 7, 0));
				modGlobal.Shared.gEndTrans = ViewModel.calEnd.Value.Date.AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
			}
			ViewManager.DisposeView(this);

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			PTSProject.clsScheduler sScheduler = Container.Resolve< clsScheduler>();

			int iYear = DateTime.Now.Year + 1;
			if (sScheduler.GetScheduleMaxYear() != 0)
			{
				if (!sScheduler.ScheduleRecord.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					iYear = Convert.ToInt32(modGlobal.GetVal(sScheduler.ScheduleRecord["MaxYear"]));
				}
			}

			//Set Min and Max Dates for calendar controls
			if (~modGlobal.Shared.gTradeDefault != 0)
			{
				ViewModel.calStart.MinDate = DateTime.Parse(modGlobal.Shared.gStartTrans);
				ViewModel.calStart.MaxDate = DateTime.Parse("12/31/" + DateTime.Parse(modGlobal.Shared.gStartTrans).Year.ToString());
				ViewModel.calStart.Value = ViewModel.calStart.MinDate;
				ViewModel.calEnd.MinDate = DateTime.Parse(modGlobal.Shared.gStartTrans);
				//TRANSFER END DATE CHANGE
				ViewModel.calEnd.MaxDate = DateTime.Parse("2/1/" + iYear.ToString());
				//Change the default from MaxDate to MinDate
				//        calEnd.Date = calEnd.MaxDate
				ViewModel.calEnd.Value = ViewModel.calEnd.MinDate;
				ViewModel.chkBothShifts.Visible = modGlobal.Shared.gFullShift != 0;
			}
			else
			{
				//For employees working a trade give option only
				//for this day
				ViewModel.lbStart.Visible = false;
				ViewModel.lbEnd.Visible = false;
				ViewModel.calStart.Visible = false;
				ViewModel.calEnd.Visible = false;
				ViewModel.optType[1].Enabled = false;
				ViewModel.optType[2].Enabled = false;
				ViewModel.chkBothShifts.Visible = modGlobal.Shared.gFullShift != 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void optType_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if (((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender).Checked)
			{
				if ( ViewModel.isInitializingComponent)
				{
					return;
				}
				int Index =this.ViewModel.optType.IndexOf((UpgradeHelpers.BasicViewModels.RadioButtonViewModel) eventSender);
				PTSProject.clsScheduler sScheduler = Container.Resolve< clsScheduler>();

				int iYear = DateTime.Now.AddYears(1).Year;
				if (sScheduler.GetScheduleMaxYear() != 0)
				{
					if (!sScheduler.ScheduleRecord.EOF)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						iYear = Convert.ToInt32(modGlobal.GetVal(sScheduler.ScheduleRecord["MaxYear"]));
					}
				}

				switch(Index)
				{
					case 0 :
						ViewModel.lbStart.Visible = false;
						ViewModel.lbEnd.Visible = false;
						ViewModel.calStart.Visible = false;
						ViewModel.calEnd.Visible = false;
						ViewModel.lbWarning.Visible = false;
						if (modGlobal.Shared.gFullShift != 0)
						{
							ViewModel.chkBothShifts.Visible = true;
							modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
						}
						else
						{
							ViewModel.chkBothShifts.Visible = false;
							if (modGlobal.Shared.gStartTrans.Substring(Math.Max(modGlobal.Shared.gStartTrans.Length - 2, 0)) == "PM")
							{
								modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
							}
							else
							{
								modGlobal.Shared.gEndTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 2, modGlobal.Shared.gStartTrans.Length)) + "PM";
							}
						}
						break;
					case 1 :
						ViewModel.lbStart.Visible = true;
						ViewModel.lbEnd.Visible = true;
						ViewModel.calStart.Visible = true;
						ViewModel.calEnd.Visible = true;
						ViewModel.chkBothShifts.Visible = false;
						ViewModel.lbWarning.Visible = false;
						break;
					case 2 :
						//TRANSFER END DATE CHANGE 
						modGlobal
							.Shared.gEndTrans = "2/1/" + iYear.ToString() + " 7:00AM";
						ViewModel.chkBothShifts.Visible = false;
						ViewModel.lbStart.Visible = false;
						ViewModel.lbEnd.Visible = false;
						ViewModel.calStart.Visible = false;
						ViewModel.calEnd.Visible = false;
						ViewModel.lbWarning.Visible = true;
						break;
				}

			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgSpecialAssign DefInstance
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

		public static dlgSpecialAssign CreateInstance()
		{
			PTSProject.dlgSpecialAssign theInstance = Shared.Container.Resolve< dlgSpecialAssign>();
			theInstance.Form_Load();
			return theInstance;
		}

		void ReLoadForm(bool addEvents)
		{
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

	public partial class dlgSpecialAssign
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgSpecialAssignViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgSpecialAssign m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}