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

	public partial class frmPMVacationScheduler
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPMVacationSchedulerViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPMVacationScheduler));
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



		public void SetMaxLeave(System.DateTime DateCheck)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_MaxLeaveAllowed '" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateCheck) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (!oRec.EOF)
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.MaxAllowed = Convert.ToInt32(modGlobal.GetVal(oRec["paramedic_max"]));
			}
			else
			{
				ViewModel.MaxAllowed = 1;
			}

		}


		public void SetCalendarShifts()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			System.DateTime SaveDate = DateTime.FromOADate(0);
			System.DateTime WorkingDate = DateTime.FromOADate(0);

			ViewModel.CalendarLoading = true;
			frmPMVacationScheduler.DefInstance.ViewModel.Visible = false;
			bool DateRequested = false;
			ViewModel.MaxAllowed = 1;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.Constants_SelectionType property Constants_SelectionType.ssSelectionTypeMultiSelect was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.SelectionType was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.calYear.setSelectionType(UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionType.getssSelectionTypeMultiSelect());

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_AnnualCalendarStep1 '" + modGlobal.Shared.gCurrentYear.ToString() + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if (oRec.EOF)
			{
				return;
			}
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().SelectedDays.RemoveAll();


			while(!oRec.EOF)
			{
				SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy"));
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calYear.getX().SelectedDays.Add(SaveDate);
				//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				ViewModel.calYear.getX().SelectedDays(SaveDate).Caption = oRec["shift_code"];

				oRec.MoveNext();
			};

			SaveDate = DateTime.Parse("1/1/1900");
			string AMColor = "";
			string PMColor = "";

			oCmd.CommandText = "spSelect_AnnualCalendarStepPM '" + modGlobal.Shared.gCurrentYear.ToString() + "' ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().SelectedDays.RemoveAll();
			if (oRec.EOF)
			{
				frmPMVacationScheduler.DefInstance.ViewModel.Visible = true;
				return;
			}


			while(!oRec.EOF)
			{
				WorkingDate = DateTime.Parse(Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy"));
				SetMaxLeave(WorkingDate);
				if (modGlobal.Clean(oRec["AMPM"]) == "AM")
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(LeaveTotal)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["LeaveTotal"])) >= ViewModel.MaxAllowed)
					{
						AMColor = "blue";
					}
					else if (Convert.ToString(oRec["Available"]) != "No")
					{
						AMColor = "yellow";
					}
					else
					{
						AMColor = "white";
						if (Convert.ToString(oRec["Requested"]) != "No")
						{
							DateRequested = true;
						}
					}
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal(oRec(LeaveTotal)) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if (Convert.ToDouble(modGlobal.GetVal(oRec["LeaveTotal"])) >= ViewModel.MaxAllowed)
					{
						PMColor = "blue";
					}
					else if (Convert.ToString(oRec["Available"]) != "No")
					{
						PMColor = "yellow";
					}
					else
					{
						PMColor = "white";
						if (Convert.ToString(oRec["Requested"]) != "No")
						{
							DateRequested = true;
						}
					}
				}
				if (WorkingDate == SaveDate)
				{ //PM Record just read
					if (AMColor == "white" && PMColor == "white")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "OpenRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("OpenRequest");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "Default";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("Default");
						}
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "yellow" && PMColor == "yellow")
					{
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						ViewModel.calYear.getX().Day(SaveDate).StyleSet = "Available";
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.calYear.setDayCaptionStyleSet("Available");
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "blue" && PMColor == "blue")
					{
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						ViewModel.calYear.getX().Day(SaveDate).StyleSet = "Closed";
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.calYear.setDayCaptionStyleSet("Closed");
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "blue" && PMColor == "white")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "amClosedRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("amClosedRequest");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "amClosed";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("amClosed");
						}
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "white" && PMColor == "blue")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmClosedRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmClosedRequest");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmClosed";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmClosed");
						}
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "yellow" && PMColor == "white")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "amAvailRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("amAvailRequest");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "amAvail";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("amAvail");
						}
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "white" && PMColor == "yellow")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmAvailRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmAvailRequest");
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmAvail";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmAvail");
						}
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "yellow" && PMColor == "blue")
					{
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						ViewModel.calYear.getX().Day(SaveDate).StyleSet = "AvailClose";
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.calYear.setDayCaptionStyleSet("AvailClose");
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
					else if (AMColor == "blue" && PMColor == "yellow")
					{
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						ViewModel.calYear.getX().Day(SaveDate).StyleSet = "CloseAvail";
						//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.calYear.setDayCaptionStyleSet("CloseAvail");
						AMColor = "";
						PMColor = "";
						DateRequested = false;
					}
				}
				else
				{
					if (SaveDate == DateTime.Parse("1/1/1900"))
					{ //first time in
						//continue
					}
					else if (AMColor == "white" && PMColor == "")
					{
						//continue
					}
					else if (AMColor == "" && PMColor == "white")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "OpenRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("OpenRequest");
							DateRequested = false;
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "Default";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("Default");
						}
					}
					else if (AMColor == "" && PMColor == "yellow")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmAvailRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmAvailRequest");
							PMColor = "";
							DateRequested = false;
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmAvail";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmAvail");
							PMColor = "";
						}
					}
					else if (AMColor == "" && PMColor == "blue")
					{
						if (DateRequested)
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmClosedRequest";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmClosedRequest");
							PMColor = "";
							DateRequested = false;
						}
						else
						{
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							//UPGRADE_TODO: (1067) Member Day is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							ViewModel.calYear.getX().Day(SaveDate).StyleSet = "pmClosed";
							//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.DayCaptionStyleSet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.calYear.setDayCaptionStyleSet("pmClosed");
							PMColor = "";
						}
					}
					else if (AMColor == "yellow" && PMColor == "")
					{
						//                calYear.X.Day(SaveDate).StyleSet = "amAvail"
						//                calYear.DayCaptionStyleSet = "amAvail"
					}
					else if (AMColor == "blue" && PMColor == "")
					{
						//                calYear.X.Day(SaveDate).StyleSet = "amClosed"
						//                calYear.DayCaptionStyleSet = "amClosed"
					}
				}

				SaveDate = DateTime.Parse(Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy"));
				oRec.MoveNext();
			};

			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().SelectedDays.RemoveAll();
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.Constants_SelectionType property Constants_SelectionType.ssSelectionTypeSingleSelect was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.SelectionType was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.calYear.setSelectionType(UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionType.getssSelectionTypeSingleSelect());
			ViewModel.CalendarLoading = false;
			frmPMVacationScheduler.DefInstance.ViewModel.Visible = true;

		}

		public void CreateStyleSets()
		{
			//totally white
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Default").BackColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.WHITE);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Default").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);

			//totally white w/request
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("OpenRequest").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("OpenRequest").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("OpenRequest").Picture = modGlobal.IMAGEPATH + "reqfull.bmp";

			//totally Yellow
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Available").BackColor = modGlobal.CHOLIDAY;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Available").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);

			//totally Blue
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Closed").BackColor = modGlobal.CREGULAR;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("Closed").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);

			//blue/white
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosed").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosed").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosed").Picture = modGlobal.IMAGEPATH + "amreg.bmp";

			//blue/white w/request
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosedRequest").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosedRequest").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amClosedRequest").Picture = modGlobal.IMAGEPATH + "reqpm.bmp";

			//white/blue
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosed").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosed").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosed").Picture = modGlobal.IMAGEPATH + "pmreg.bmp";

			//white/blue w/request
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosedRequest").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosedRequest").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmClosedRequest").Picture = modGlobal.IMAGEPATH + "reqam.bmp";

			//yellow/blue
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("AvailClose").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("AvailClose").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("AvailClose").Picture = modGlobal.IMAGEPATH + "amhol.bmp";

			//blue/yellow
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("CloseAvail").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("CloseAvail").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("CloseAvail").Picture = modGlobal.IMAGEPATH + "pmHol.bmp";

			//yellow/white
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvail").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvail").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvail").Picture = modGlobal.IMAGEPATH + "amholhalf.bmp";

			//yellow/white w/request
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvailRequest").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvailRequest").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("amAvailRequest").Picture = modGlobal.IMAGEPATH + "reqpmyellow.bmp";

			//white/yellow
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvail").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvail").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvail").Picture = modGlobal.IMAGEPATH + "pmholhalf.bmp";

			//yellow/white w/request
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvailRequest").BackColor = modGlobal.CDEFAULT;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvailRequest").ForeColor = UpgradeHelpers.Helpers.ColorTranslator.ToOle(modGlobal.Shared.RED);
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member StyleSets is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().StyleSets("pmAvailRequest").Picture = modGlobal.IMAGEPATH + "reqamyellow.bmp";

		}

		[UpgradeHelpers.Events.Handler]
		internal void calYear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//    MsgBox "The Screen to Display & Add Vacation Requests is being worked on.", vbOKOnly, "Coming Soon!!"
				if (!Information.IsDate(modGlobal.Shared.gDetailDate))
				{
					this.Return();
					return ;
				}

				modGlobal.Shared.gParamedicSchedule = true;
				modGlobal.Shared.gHazmatSchedule = false;
				modGlobal.Shared.gFCCSchedule = false;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgVacationRequest.DefInstance, true);
					});
				async1.Append(() =>
					{
						modGlobal.Shared.gDetailDate = "";
					});
			}

					}

		//UPGRADE_WARNING: (2050) SSCalendarWidgets_A.SSYear Event calYear.InitYear was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		private void calYear_InitYear(int YearNum, int RtnCancel)
		{
			//Calendar moved to new year
			//Reload Schedule and Annual Leave Totals
			if ( ViewModel.FirstTime)
			{
				return;
			}
			modGlobal.Shared.gCurrentYear = YearNum;
			modGlobal.RefreshActiveForm();
			SetCalendarShifts();

		}

		//UPGRADE_WARNING: (2050) SSCalendarWidgets_A.SSYear Event calYear.SelChange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2050.aspx

		private void calYear_SelChange(string SelDate, string OldSelDate, int Selected, int RtnCancel)
		{
			//This event occurs if a day on the calYear control is selected.
			//If the day is being deselected the subroutine is exited.
			//Selected Date in removed from the Selected Days collection
			//so any Stylesets for this day display correctly

			if (~Selected != 0)
			{
				return;
			}
			if ( ViewModel.CalendarLoading)
			{
				return;
			}

			modGlobal.Shared.gDetailDate = SelDate;
			//UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSYear property calYear.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//UPGRADE_TODO: (1067) Member SelectedDays is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			ViewModel.calYear.getX().SelectedDays.RemoveAll();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.RefreshActiveForm();
			SetCalendarShifts();
		}

		internal void frmPMVacationScheduler_Activated(Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
				modGlobal.RefreshActiveForm();
			}
		}

		//UPGRADE_WARNING: (2065) Form event frmPMVacationScheduler.Deactivate has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
		[UpgradeHelpers.Events.Handler]
		internal void frmPMVacationScheduler_Deactivate(Object eventSender, System.EventArgs eventArgs)
		{
			//    RefreshActiveForm
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			CreateStyleSets();
			ViewModel.FirstTime = false;
			modGlobal.Shared.gParamedicSchedule = true;
			modGlobal.Shared.gHazmatSchedule = false;
			modGlobal.Shared.gFCCSchedule = false;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPMVacationScheduler DefInstance
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

		public static frmPMVacationScheduler CreateInstance()
		{
			PTSProject.frmPMVacationScheduler theInstance = Shared.Container.Resolve< frmPMVacationScheduler>();
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
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPMVacationScheduler
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPMVacationSchedulerViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPMVacationScheduler m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}