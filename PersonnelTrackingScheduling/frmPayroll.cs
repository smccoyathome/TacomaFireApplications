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

	public partial class frmPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPayroll));
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


		private void frmPayroll_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		public int EditApply(int iApply)
		{

			int result = 0;
			result = 0;

			switch ( iApply )
			{
				case 1: //Week One 

					if ( modGlobal.Clean(ViewModel.txtActivity1.Text) != "" )
					{
						if ( modGlobal.Clean(ViewModel.txtActivity1.Text) == "" && modGlobal.Clean(ViewModel.txtCostCenter1.Text
										) == "" && modGlobal.Clean(ViewModel.txtWBSElement1.Text) == "" && modGlobal.Clean(ViewModel.cboOrder1.Text) == "" && modGlobal.Clean(ViewModel.txtOper1.Text) == "" )
						{
							ViewManager.ShowMessage("Activity should be blank.", "Error on Activity", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtActivity1);
							return result;
						}
					}

					if ( modGlobal.Clean(ViewModel.txtActivity1.Text) == "" )
					{
						if ( modGlobal.Clean(ViewModel.txtActivity1.Text) != "" || modGlobal.Clean(ViewModel.txtCostCenter1.Text
									) != "" || modGlobal.Clean(ViewModel.txtWBSElement1.Text) != "" || modGlobal.Clean(ViewModel.cboOrder1.Text) != "" )
						{
							ViewManager.ShowMessage("You need to enter an Activity (ex:  T40010).", "Error on Activity", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtActivity1);
							return result;
						}
					}

					if ( modGlobal.Clean(ViewModel.cboAAType1.Text) == "" )
					{
						ViewManager.ShowMessage("Please Select an A/A Type.", "Missing A/A Type (KOT)", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewManager.SetCurrent(ViewModel.cboAAType1);
						return result;
					}

					if ( modGlobal.Clean(ViewModel.cboJobCode1.Text) != "" )
					{
						if ( modGlobal.Clean(ViewModel.cboStep1.Text) == "" )
						{
							ViewManager.ShowMessage("Please enter the Step.", "Job Code - Missing Step", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.cboStep1);
							return result;
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.cboStep1.Text) != "" )
						{
							ViewModel.cboStep1.Text = "";
						}
					}

					if (modGlobal.Clean(ViewModel.txtMo1.Text) == "" && modGlobal.Clean(ViewModel.txtTu1.Text) == "" && modGlobal.
										Clean(ViewModel.txtWe1.Text) == "" && modGlobal.Clean(ViewModel.txtTh1.Text) == "" && modGlobal.Clean(
								ViewModel.txtFr1.Text) == "" && modGlobal.Clean(ViewModel.txtSa1.Text) == "" && modGlobal.Clean(ViewModel.txtSu1.Text) == "")
					{
						ViewManager.ShowMessage("Please enter the Hours.", "No Hours Entered", UpgradeHelpers.Helpers.BoxButtons.OK);
						return result;
					}

					break;
				case 2: //Week Two 

					if ( modGlobal.Clean(ViewModel.txtActivity2.Text) != "" )
					{
						if ( modGlobal.Clean(ViewModel.txtActivity2.Text) == "" && modGlobal.Clean(ViewModel.txtCostCenter2.Text
										) == "" && modGlobal.Clean(ViewModel.txtWBSElement2.Text) == "" && modGlobal.Clean(ViewModel.cboOrder2.Text) == "" && modGlobal.Clean(ViewModel.txtOper2.Text) == "" )
						{
							ViewManager.ShowMessage("Activity should be blank.", "Error on Activity", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtActivity2);
							return result;
						}
					}

					if ( modGlobal.Clean(ViewModel.txtActivity2.Text) == "" )
					{
						if ( modGlobal.Clean(ViewModel.txtActivity2.Text) != "" || modGlobal.Clean(ViewModel.txtCostCenter2.Text
									) != "" || modGlobal.Clean(ViewModel.txtWBSElement2.Text) != "" || modGlobal.Clean(ViewModel.cboOrder2.Text) != "" )
						{
							ViewManager.ShowMessage("You need to enter an Activity (ex:  T40010).", "Error on Activity", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.txtActivity2);
							return result;
						}
					}

					if ( modGlobal.Clean(ViewModel.cboAAType2.Text) == "" )
					{
						ViewManager.ShowMessage("Please Select an A/A Type.", "Missing A/A Type (KOT)", UpgradeHelpers.Helpers.BoxButtons.OK);
						ViewManager.SetCurrent(ViewModel.cboAAType2);
						return result;
					}

					if ( modGlobal.Clean(ViewModel.cboJobCode2.Text) != "" )
					{
						if ( modGlobal.Clean(ViewModel.cboStep2.Text) == "" )
						{
							ViewManager.ShowMessage("Please enter the Step.", "Job Code - Missing Step", UpgradeHelpers.Helpers.BoxButtons.OK);
							ViewManager.SetCurrent(ViewModel.cboStep2);
							return result;
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.cboStep2.Text) != "" )
						{
							ViewModel.cboStep2.Text = "";
						}
					}

					if (modGlobal.Clean(ViewModel.txtMo2.Text) == "" && modGlobal.Clean(ViewModel.txtTu2.Text) == "" && modGlobal.
										Clean(ViewModel.txtWe2.Text) == "" && modGlobal.Clean(ViewModel.txtTh2.Text) == "" && modGlobal.Clean(
								ViewModel.txtFr2.Text) == "" && modGlobal.Clean(ViewModel.txtSa2.Text) == "" && modGlobal.Clean(ViewModel.txtSu2.Text) == "")
					{
						ViewManager.ShowMessage("Please enter the Hours.", "No Hours Entered", UpgradeHelpers.Helpers.BoxButtons.OK);
						return result;
					}

					break;
			}

			return -1;


		}


		public void PrintAllTimeCards()
		{

			//    MsgBox "This option is under construction", vbOKOnly, "Print Individual Time Card(s)"
			ViewModel.cmdPrint.Enabled = false;

			int tempForVar = ViewModel.sprEmployeeList.MaxRows;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				//    For i = 204 To sprEmployeeList.MaxRows
				ViewModel.sprEmployeeList.Row = i;
				ViewModel.sprEmployeeList.Col = 2;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.CurrEmpID = Convert.ToString(modGlobal.GetVal(ViewModel.sprEmployeeList.Text));

				if ( modGlobal.Clean(ViewModel.CurrEmpID) == "" )
				{
					break;
				}

				if ( modGlobal.Clean(ViewModel.cboPayPeriod.Text) == "" )
				{
					ViewManager.ShowMessage("Please select a Pay Period", "Personnel Tracking System", UpgradeHelpers.Helpers.BoxButtons.OK);
					ViewManager.SetCurrent(ViewModel.cboPayPeriod);
					break;
				}
				ViewModel.SelectedRow = i;
				FillTimeCard();
				FormatTimeCard();

				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprTimeSheet.setPrintAbortMsg("Printing Individual Time Card #" + i.ToString() + " - Click Cancel to quit");
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprTimeSheet.setPrintBorder(false);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprTimeSheet.setPrintColor(true);
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprTimeSheet.setPrintMarginLeft(360);
                //        sprTimeSheet.PrintOrientation = 2
                ViewModel.sprTimeSheet.PrintSheet(null);
                //ViewModel.sprTimeSheet.Action = (FarPoint.ViewModels.FPActionConstants)32;

			}

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

		}


		public void FormatTimeCard()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//clear TimeSheet
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprTimeSheet.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTimeSheet.ClearSelection();

			oCmd.CommandText = "spSelect_SAPConversionByEmployee " + ViewModel.CurrPersID.ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//SAP Employee ID
			ViewModel.sprTimeSheet.Row = 2;
			ViewModel.sprTimeSheet.Col = 1;
			if ( !oRec.EOF )
			{
				if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 8 )
				{
					ViewModel.sprTimeSheet.Text = Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 8 )
				{
					ViewModel.sprTimeSheet.Text = Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 7 )
				{
					ViewModel.sprTimeSheet.Text = "0" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 6 )
				{
					ViewModel.sprTimeSheet.Text = "00" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 5 )
				{
					ViewModel.sprTimeSheet.Text = "000" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 4 )
				{
					ViewModel.sprTimeSheet.Text = "0000" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 3 )
				{
					ViewModel.sprTimeSheet.Text = "00000" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 2 )
				{
					ViewModel.sprTimeSheet.Text = "000000" + Convert.ToString(oRec["sap_id"]);
				}
				else if ( Strings.Len(Convert.ToString(oRec["sap_id"])) == 1 )
				{
					ViewModel.sprTimeSheet.Text = "0000000" + Convert.ToString(oRec["sap_id"]);
				}
				else
				{
					ViewModel.sprTimeSheet.Text = "00000000";
				}
			}
			else
			{
				ViewModel.sprTimeSheet.Text = "00000000";
			}

			oCmd.CommandText = "sp_GetPersonnelDetail '" + ViewModel.CurrEmpID + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Unable to Recall Employee Payroll Detail", "Individual Time Cards", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}

			//Employee Name
			ViewModel.sprTimeSheet.Col = 2;
			ViewModel.sprTimeSheet.Text = Convert.ToString(oRec["name_full"]).Trim();

			//Cost Center
			ViewModel.sprTimeSheet.Col = 4;
			ViewModel.sprTimeSheet.Text = Convert.ToString(oRec["org"]);

			//Job Code
			ViewModel.sprTimeSheet.Col = 5;
			ViewModel.sprTimeSheet.Text = Convert.ToString(oRec["job_code_id"]);

			//Step
			ViewModel.sprTimeSheet.Col = 6;
			ViewModel.sprTimeSheet.Text = modGlobal.Clean(oRec["step"]);

			//Pay Rate
			ViewModel.sprTimeSheet.Col = 7;
			ViewModel.sprTimeSheet.Text = Math.Round((double)Convert.ToDouble(oRec["pay_rate"]), 2).ToString();

			//Pay Period Begin Date
			ViewModel.sprTimeSheet.Col = 9;
			System.DateTime TempDate = DateTime.FromOADate(0);
			ViewModel.sprTimeSheet.Text = (DateTime.TryParse(ViewModel.CurrStartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ViewModel.CurrStartDate;

			//Pay Period Begin Date
			ViewModel.sprTimeSheet.Col = 12;
			ViewModel.sprTimeSheet.Text = DateTime.Parse(ViewModel.CurrEndDate).AddDays(-1).ToString("MM/d/yyyy");

			//Transfering Time Card Information from screen to report
			//Week 1...
			int x = 5; //time card
			int i = 1; //screen
			int c = 1;
			for ( i = 1; i <= 11; i++ )
			{
				ViewModel.sprTimeSheet.Row = x;
				ViewModel.sprWeek1.Row = i;
				for ( c = 1; c <= 15; c++ )
				{
					ViewModel.sprTimeSheet.Col = c;
					ViewModel.sprWeek1.Col = c;
					ViewModel.sprTimeSheet.Text = ViewModel.sprWeek1.Text;
				}
				x++;
			}

			//Week 2...
			x = 18; //time card
			i = 1; //screen
			c = 1;
			for ( i = 1; i <= 11; i++ )
			{
				ViewModel.sprTimeSheet.Row = x;
				ViewModel.sprWeek2.Row = i;
				for ( c = 1; c <= 15; c++ )
				{
					ViewModel.sprTimeSheet.Col = c;
					ViewModel.sprWeek2.Col = c;
					ViewModel.sprTimeSheet.Text = ViewModel.sprWeek2.Text;
				}
				x++;
			}


		}

		public bool FillStepList(int i, string Job)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboStep1.Items.Clear();
			ViewModel.cboStep1.SelectedIndex = -1;
			ViewModel.cboStep1.Text = "";
			ViewModel.cboStep2.Items.Clear();
			ViewModel.cboStep2.SelectedIndex = -1;
			ViewModel.cboStep2.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "sp_GetStepListByJobCode '" + modGlobal.Clean(Job) + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code lists

			while ( !oRec.EOF )
			{
				if ( i == 1 )
				{
					ViewModel.cboStep1.AddItem(Convert.ToString(oRec["step"]));
				}
				else
				{
					ViewModel.cboStep2.AddItem(Convert.ToString(oRec["step"]));
				}
				oRec.MoveNext();
			};

			return false;
		}

		public void LoadLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.cboOrder1.Items.Clear();
			ViewModel.cboOrder1.SelectedIndex = -1;
			ViewModel.cboOrder1.Text = "";
			ViewModel.cboOrder2.Items.Clear();
			ViewModel.cboOrder2.SelectedIndex = -1;
			ViewModel.cboOrder2.Text = "";
			ViewModel.cboAAType1.Items.Clear();
			ViewModel.cboAAType1.SelectedIndex = -1;
			ViewModel.cboAAType1.Text = "";
			ViewModel.cboAAType2.Items.Clear();
			ViewModel.cboAAType2.SelectedIndex = -1;
			ViewModel.cboAAType2.Text = "";
			ViewModel.cboJobCode1.Items.Clear();
			ViewModel.cboJobCode1.SelectedIndex = -1;
			ViewModel.cboJobCode1.Text = "";
			ViewModel.cboJobCode2.Items.Clear();
			ViewModel.cboJobCode2.SelectedIndex = -1;
			ViewModel.cboJobCode2.Text = "";
			ViewModel.cboStep1.Items.Clear();
			ViewModel.cboStep1.SelectedIndex = -1;
			ViewModel.cboStep1.Text = "";
			ViewModel.cboStep2.Items.Clear();
			ViewModel.cboStep2.SelectedIndex = -1;
			ViewModel.cboStep2.Text = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_SAPOrderCodes ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load SAP Order Codes

			while ( !oRec.EOF )
			{
				ViewModel.cboOrder1.AddItem(Convert.ToString(oRec["order_code"]));
				ViewModel.cboOrder2.AddItem(Convert.ToString(oRec["order_code"]));
				oRec.MoveNext();
			};

			oCmd.CommandText = "spJobCodeList";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code lists

			while ( !oRec.EOF )
			{
				ViewModel.cboJobCode1.AddItem(Convert.ToString(oRec["job_code_id"]));
				ViewModel.cboJobCode2.AddItem(Convert.ToString(oRec["job_code_id"]));
				oRec.MoveNext();
			};

			//Schedule Time Codes
			oCmd.CommandText = "spSelect_AllTimeCodes ";
			oRec = ADORecordSetHelper.Open(oCmd, "");


			while ( !oRec.EOF )
			{
				ViewModel.cboAAType1.AddItem(modGlobal.Clean(oRec["AAType"]) + "-" + modGlobal.Clean(oRec["TimeCode"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboAAType1.SetItemData(ViewModel.cboAAType1.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
				ViewModel.cboAAType2.AddItem(modGlobal.Clean(oRec["AAType"]) + "-" + modGlobal.Clean(oRec["TimeCode"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboAAType2.SetItemData(ViewModel.cboAAType2.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(oRec["timecode_sys_id"])));
				oRec.MoveNext();
			};

			}

		public void AddEmployeePayRoll()
		{
			PTSProject.clsFireUpload PayrollCL = Container.Resolve<clsFireUpload>();
			string PayrollDate = "";

			//Murray Morgan WO Logic will go in this procedure

			PayrollCL.PPcalendar_year = modGlobal.Shared.gPayrollYear;
			PayrollCL.PPpay_period = modGlobal.Shared.gPayPeriod;
			PayrollCL.PPper_sys_id = ViewModel.CurrPersID;

			int tempForVar = ViewModel.sprWeek1.DataRowCnt;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				ViewModel.sprWeek1.Row = i;
				ViewModel.sprWeek1.Col = 5;
				if ( ViewModel.sprWeek1.Text == "Schedule" )
				{
				//skip any logic... move to the next row
				}
				else
				{
					ViewModel.sprWeek1.Col = 6;
					if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != "" )
					{
						ViewModel.sprWeek1.Col = 1; //Activity Type

						PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.sprWeek1.Text).ToUpper();
						ViewModel.sprWeek1.Col = 2; //CostCenter

						PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 3; //WBS Element

						PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 4; //Order

						PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 5; //Operation/Activity

						PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 6; //AA Type

						PayrollCL.PPa_a_type = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 7; //Job Code

						PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.sprWeek1.Text);
						ViewModel.sprWeek1.Col = 8; //Step

						PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.sprWeek1.Text);

						for ( int x = 0; x <= 6; x++ )
						{
							PayrollDate = Convert.ToString(ViewModel.DateArray[x, 0]);
							ViewModel.sprWeek1.Col = x + 9;
							if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != "" )
							{
								if ( ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
								{
									PayrollCL.PPpayroll_date = PayrollDate;
									PayrollCL.PPhours = Math.Round((double)Double.Parse(ViewModel.sprWeek1.Text), 2);
									PayrollCL.PPcreate_date = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now);
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
										ViewModel.sprWeek1.Col = x + 16;
										ViewModel.sprWeek1.Text = PayrollCL.PPpayroll_sys_id.ToString();
									}
								}
							}
						}
					}
				}
			}

			int tempForVar2 = ViewModel.sprWeek2.DataRowCnt;
			for ( int i = 1; i <= tempForVar2; i++ )
			{
				ViewModel.sprWeek2.Row = i;
				ViewModel.sprWeek2.Col = 5;
				if ( ViewModel.sprWeek2.Text == "Schedule" )
				{
				//skip any logic... move to the next row
				}
				else
				{
					ViewModel.sprWeek2.Col = 6;
					if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != "" )
					{
						ViewModel.sprWeek2.Col = 1; //Activity Type

						PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.sprWeek2.Text).ToUpper();
						ViewModel.sprWeek2.Col = 2; //CostCenter

						PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 3; //WBS Element

						PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 4; //Order

						PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 5; //Operation/Activity

						PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 6; //AA Type

						PayrollCL.PPa_a_type = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 7; //Job Code

						PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.sprWeek2.Text);
						ViewModel.sprWeek2.Col = 8; //Step

						PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.sprWeek2.Text);

						for ( int x = 7; x <= 13; x++ )
						{
							PayrollDate = Convert.ToString(ViewModel.DateArray[x, 0]);
							ViewModel.sprWeek2.Col = x + 2;
							if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != "" )
							{
								if ( ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
								{
									PayrollCL.PPpayroll_date = PayrollDate;
									PayrollCL.PPhours = Math.Round((double)Double.Parse(ViewModel.sprWeek2.Text), 2);
									PayrollCL.PPcreate_date = UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now);
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
										ViewModel.sprWeek2.Col = x + 9;
										ViewModel.sprWeek2.Text = PayrollCL.PPpayroll_sys_id.ToString();
									}
								}
							}
						}
					}
				}
			}

			ViewModel.PayRollExist = true;

		}

		public bool GetEmployeePayRoll()
		{
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int i = 0;
			int CurrPayrollID = 0;
			string CurrJob = "";
			string WorkDate = "";
			string SaveDate = "";
			string CurrStep = "";
			string CurrActivity = "";
			string CurrOper = "";
			string RecCenter = "";
			string RecOrder = "";
			string WorkCenter = "";
			bool NeedToAddRow1 = false;
			bool NeedToAddRow2 = false;
			int WhichWeek = 0;
			ViewModel.sprWeek1.Row = 1;
			ViewModel.sprWeek1.Col = 5;
			NeedToAddRow1 = ViewModel.sprWeek1.Text == "Schedule";
			ViewModel.sprWeek2.Row = 1;
			ViewModel.sprWeek2.Col = 5;
			NeedToAddRow2 = ViewModel.sprWeek2.Text == "Schedule";

			float TotalHours = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string SqlString = "spSelect_IndividualPersonnelPayRollList " + modGlobal.Shared.gPayPeriod.ToString();
			SqlString = SqlString + "," + modGlobal.Shared.gPayrollYear.ToString() + "," + ViewModel.CurrPersID.ToString() + " ";
			oCmd.CommandText = SqlString;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				return result;
			}
			else
			{
				result = true;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				CurrPayrollID = Convert.ToInt32(modGlobal.GetVal(oRec["payroll_sys_id"])); //Payroll System ID
				CurrActivity = modGlobal.Clean(oRec["sap_acttype"]); //Activity Type
				RecCenter = modGlobal.Clean(oRec["sap_rec_center"]); //Cost Center
				WorkCenter = modGlobal.Clean(oRec["wbs_element"]); //WBS Element
				RecOrder = modGlobal.Clean(oRec["sap_rec_order"]); //Order
				CurrOper = modGlobal.Clean(oRec["sap_activity"]); //Operation

				ViewModel.CurrSAPCode = modGlobal.Clean(oRec["a_a_type"]); //A/A Type
				CurrJob = modGlobal.Clean(oRec["exception_job_code"]); //PS Group
				CurrStep = modGlobal.Clean(oRec["exception_step"]); //Level
				SaveDate = Convert.ToDateTime(oRec["payroll_date"]).ToString("M/d/yyyy");
				WhichWeek = 0;
			}


			while ( !oRec.EOF )
			{
				WorkDate = Convert.ToDateTime(oRec["payroll_date"]).ToString("M/d/yyyy"); //Payroll Date
				for ( i = 0; i <= 13; i++ )
				{
					if ( WorkDate == Convert.ToString(ViewModel.DateArray[i, 0]) )
					{
						if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
						{
							WhichWeek = 1;
						}
						else
						{
							WhichWeek = 2;
						}
						break;
					}
				}

				if (CurrActivity == modGlobal.Clean(oRec["sap_acttype"]) && RecCenter == modGlobal.Clean(oRec["sap_rec_center"]) && WorkCenter == modGlobal.Clean(oRec
								["wbs_element"]) && RecOrder == modGlobal.Clean(oRec["sap_rec_order"]) && CurrOper == modGlobal.Clean(oRec["sap_activity"]) && ViewModel.CurrSAPCode == modGlobal.Clean(oRec["a_a_type"]) && CurrJob == modGlobal.Clean(oRec["exception_job_code"]) && CurrStep == modGlobal.Clean(oRec["exception_step"]))
				{
					if ( CurrPayrollID == UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["payroll_sys_id"])) )
					{
					//continue
					}
					else if ( SaveDate == WorkDate )
					{
						NeedToAddRow1 = true;
						NeedToAddRow2 = true;
						CurrPayrollID = Convert.ToInt32(Double.Parse(modGlobal.Clean(oRec["payroll_sys_id"])));
					}
					else
					{
						SaveDate = WorkDate;
					}
				}
				else
				{
					CurrPayrollID = Convert.ToInt32(Double.Parse(modGlobal.Clean(oRec["payroll_sys_id"])));
					CurrActivity = modGlobal.Clean(oRec["sap_acttype"]); //Activity
					RecCenter = modGlobal.Clean(oRec["sap_rec_center"]); //Cost Center
					WorkCenter = modGlobal.Clean(oRec["wbs_element"]); //WBS Element
					RecOrder = modGlobal.Clean(oRec["sap_rec_order"]); //Order
					CurrOper = modGlobal.Clean(oRec["sap_activity"]); //Operation

					ViewModel.CurrSAPCode = modGlobal.Clean(oRec["a_a_type"]); //A/A Type
					CurrJob = modGlobal.Clean(oRec["exception_job_code"]); //PS Group
					CurrStep = modGlobal.Clean(oRec["exception_step"]); //Level
					SaveDate = WorkDate;
					NeedToAddRow1 = true;
					NeedToAddRow2 = true;
				}

				if ( WhichWeek == 1 )
				{
					if ( NeedToAddRow1 )
					{
						(ViewModel.CurrRow1)++;
						NeedToAddRow1 = false;
					}
					ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
					ViewModel.sprWeek1.Col = 6;
					//test to see if timecard info is there
					if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
					{
						ViewModel.sprWeek1.Col = 1;
						ViewModel.sprWeek1.Text = CurrActivity;
						ViewModel.sprWeek1.Col = 2;
						ViewModel.sprWeek1.Text = RecCenter;
						ViewModel.sprWeek1.Col = 3;
						ViewModel.sprWeek1.Text = WorkCenter;
						ViewModel.sprWeek1.Col = 4;
						ViewModel.sprWeek1.Text = RecOrder;
						ViewModel.sprWeek1.Col = 5;
						ViewModel.sprWeek1.Text = CurrOper;
						ViewModel.sprWeek1.Col = 6;
						ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
						ViewModel.sprWeek1.Col = 7;
						ViewModel.sprWeek1.Text = CurrJob;
						ViewModel.sprWeek1.Col = 8;
						ViewModel.sprWeek1.Text = CurrStep;
					}
					ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

					if ( modGlobal.Clean(oRec["payroll_status_code"]) == "S" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "D" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "N" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "" )
					{
					}
					else
					{
						//Payroll Record Failed
						;
					}
					ViewModel.sprWeek1.Text = Math.Round((double)Convert.ToDouble(oRec["hours"]), 2).ToString();

					TotalHours = (float)Math.Round((double)(TotalHours + Convert.ToDouble(oRec["hours"])), 2);
					ViewModel.sprWeek1.Col += 7;
					ViewModel.sprWeek1.Text = Convert.ToInt32(oRec["payroll_sys_id"]).ToString();
				}
				else
				{
					if ( NeedToAddRow2 )
					{
						(ViewModel.CurrRow2)++;
						NeedToAddRow2 = false;
					}
					ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
					ViewModel.sprWeek2.Col = 6;
					//test to see if timecard info is there
					if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
					{
						ViewModel.sprWeek2.Col = 1;
						ViewModel.sprWeek2.Text = CurrActivity;
						ViewModel.sprWeek2.Col = 2;
						ViewModel.sprWeek2.Text = RecCenter;
						ViewModel.sprWeek2.Col = 3;
						ViewModel.sprWeek2.Text = WorkCenter;
						ViewModel.sprWeek2.Col = 4;
						ViewModel.sprWeek2.Text = RecOrder;
						ViewModel.sprWeek2.Col = 5;
						ViewModel.sprWeek2.Text = CurrOper;
						ViewModel.sprWeek2.Col = 6;
						ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
						ViewModel.sprWeek2.Col = 7;
						ViewModel.sprWeek2.Text = CurrJob;
						ViewModel.sprWeek2.Col = 8;
						ViewModel.sprWeek2.Text = CurrStep;
					}
					ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

					if ( modGlobal.Clean(oRec["payroll_status_code"]) == "S" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "D" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "N" )
					{
					}
					else if ( modGlobal.Clean(oRec["payroll_status_code"]) == "" )
					{
					}
					else
					{
						//Payroll Record Failed
						;
					}
					ViewModel.sprWeek2.Text = Math.Round((double)Convert.ToDouble(oRec["hours"]), 2).ToString();

					TotalHours = (float)Math.Round((double)(TotalHours + Convert.ToDouble(oRec["hours"])), 2);
					ViewModel.sprWeek2.Col += 7;
					ViewModel.sprWeek2.Text = Convert.ToInt32(oRec["payroll_sys_id"]).ToString();
				}
				oRec.MoveNext();
			};
			ViewModel.cmdSave.Visible = false;
			ViewModel.lbPayrollHrs.Text = "Total Payrolled Hours:";
			ViewModel.lbTotalHrs.Text = Math.Round((double)TotalHours, 2).ToString();

			return result;
		}

		public void FillTimeCard()
		{
			//Fill in Employee Pay Roll Detail
			//Fill in Time Card detail

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;
			int FillerRow1 = 0;
			int FillerRow2 = 0;
			string WorkDate = "";
			string CurrOper = "";
			string CurrJob = "";
			string CurrTitle = "";
			string CurrStep = "";

			ViewModel.PayRollExist = false;
			bool NoSchedule = false;

			//Clear Grid
			ClearTimeCard();
			ViewModel.lbPayrollHrs.Text = "";
			ViewModel.lbTotalHrs.Text = "0";
			ViewModel.NeedFillerCode = false;
			ViewModel.NeedAdjustment = false;
			bool PossibleSkip = false;
			ViewModel.CurrSAPCode = "";
			ViewModel.OverAmount = 0;
			ViewModel.UnderAmount = 0;
			ViewModel.SetLimit = false;
			ViewModel.CurrLeaveTotal = 0;
			float TotalShifts = 0;
			ViewModel.CurrentUnit = "";

			string TemporaryJobCode = "";
			string TemporaryStep = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPersonnelDetail '" + ViewModel.CurrEmpID + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Unable to Recall Employee Payroll Detail", "Individual Time Cards", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}

			string JobCode = Convert.ToString(oRec["job_code_id"]);
			ViewModel.CurrPersID = Convert.ToInt32(oRec["per_sys_id"]);
			ViewModel.CurrentUnit = modGlobal.Clean(oRec["assignment_type_code"]);
			TemporaryJobCode = modGlobal.Clean(oRec["UpgradeJobCode"]);
			if ( TemporaryJobCode != "" )
			{
				TemporaryStep = modGlobal.Clean(oRec["UpgradeStep"]);
			}
			else
			{
				TemporaryStep = "";
			}

			//Get all Scheduled Shifts... this will not show up on printed TimeCard
			oCmd.CommandText = "sp_GetIndPPShifts '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.CurrRow1 = 1;
			ViewModel.CurrRow2 = 1;

			if ( oRec.EOF )
			{
				NoSchedule = true;
			}
			else
			{


				while ( !oRec.EOF )
				{
					WorkDate = Convert.ToDateTime(oRec["schedule_date"]).ToString("M/d/yyyy");
					for ( int i = 0; i <= 13; i++ )
					{
						if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
						{
							if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
							{
								ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
								ViewModel.sprWeek1.FontBold = true;
								ViewModel.sprWeek1.Text = Convert.ToString(oRec["shift_code"]);
								ViewModel.sprWeek1.Col = 5;
								if ( ViewModel.sprWeek1.Text == "" )
								{
									ViewModel.sprWeek1.FontBold = true;
									ViewModel.sprWeek1.Text = "Schedule";
								}
								break;
							}
							else
							{
								ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
								ViewModel.sprWeek2.FontBold = true;
								ViewModel.sprWeek2.Text = Convert.ToString(oRec["shift_code"]);
								ViewModel.sprWeek2.Col = 5;
								if ( ViewModel.sprWeek2.Text == "" )
								{
									ViewModel.sprWeek2.FontBold = true;
									ViewModel.sprWeek2.Text = "Schedule";
								}
								break;
							}
						}
					}

					oRec.MoveNext();
				};
				}
			//*********************************************************************
			//*********************************************************************
			//  NEW LOGIC NEEDS TO GO HERE!!
			//   Determine if PersonnelPayRoll Rows exist for this payperiod
			//       True - Then rows will have been loaded in GetEmployeePayroll
			//              Apply Changes will involve Update/Delete & Insert
			//       False - Do the logic that you have been doing
			//              Apply Changes will only involve Insert
			//*********************************************************************
			//*********************************************************************

			if ( GetEmployeePayRoll() )
			{
				ViewModel.PayRollExist = true;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Row = ViewModel.SelectedRow;
				if ( ViewModel.SelectedRow > 0 )
				{
					if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprEmployeeList.Value)) != 1 )
					{
						ViewModel.sprEmployeeList.Value = 1;
						ViewModel.sprEmployeeList.BlockMode = true;
						ViewModel.sprEmployeeList.Row = ViewModel.SelectedRow;
						ViewModel.sprEmployeeList.Row2 = ViewModel.SelectedRow;
						ViewModel.sprEmployeeList.Col = 2;
						ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
						ViewModel.sprEmployeeList.FontBold = false;
						ViewModel.sprEmployeeList.BlockMode = false;
					}
				}
			}

			if ( NoSchedule )
			{
				if ( !ViewModel.PayRollExist )
				{
					//No Schedule information is available... default to bank time card
					ViewModel.sprWeek1.Row = 1;
					ViewModel.sprWeek1.Col = 5;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 6;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 9;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 10;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 11;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 12;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek1.Col = 13;
					ViewModel.sprWeek1.FontBold = false;
					ViewModel.sprWeek1.Text = "";
					ViewModel.sprWeek2.Row = 1;
					ViewModel.sprWeek2.Col = 5;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 6;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 9;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 10;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 11;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 12;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.sprWeek2.Col = 13;
					ViewModel.sprWeek2.FontBold = false;
					ViewModel.sprWeek2.Text = "";
					ViewModel.lbPayrollHrs.Text = "Total Payroll Hours:";
					ViewModel.lbTotalHrs.Text = "0";
				}
			}

			//Add logic to split out Debit Day Upgrades
			//Enter Exception Lines
			oCmd.CommandText = "sp_GetIndPPException '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			float TotalHours = 0;
			bool NeedToAddRow1 = false;
			bool NeedToAddRow2 = false;

			if ( !oRec.EOF )
			{
				CurrOper = "";
				ViewModel.CurrSAPCode = modGlobal.Clean(oRec["a_a_type"]);
				CurrJob = modGlobal.Clean(oRec["curr_job"]);
				CurrTitle = modGlobal.Clean(oRec["job_title"]).Trim();
				CurrStep = modGlobal.Clean(oRec["step"]);
				if ( CurrStep == "0" )
				{
					CurrStep = "";
				}
				WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				NeedToAddRow1 = true;
				NeedToAddRow2 = true;

				while ( !oRec.EOF )
				{
					if ( ViewModel.CurrSAPCode == modGlobal.Clean(oRec["a_a_type"]) )
					{
						if ( modGlobal.Clean(CurrJob) == modGlobal.Clean(oRec["curr_job"]) )
						{
							if ( WorkDate == Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy") )
							{
								TotalHours += 12;
								oRec.MoveNext();
							}
							else
							{
								for ( int i = 0; i <= 13; i++ )
								{
									if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
									{
										if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
										{
											if ( NeedToAddRow1 )
											{
												(ViewModel.CurrRow1)++;
												NeedToAddRow1 = false;
											}
											if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.FontBold = false;
												ViewModel.sprWeek1.Col = 5;
												ViewModel.sprWeek1.Text = CurrOper;
												ViewModel.sprWeek1.Col = 6;
												ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
												ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
												//                                        If CurrJob <> JobCode Then
												ViewModel.sprWeek1.Col = 7;
												ViewModel.sprWeek1.Text = CurrJob;
												ViewModel.sprWeek1.Col = 8;
												ViewModel.sprWeek1.Text = CurrStep;
											//                                        End If
											}
											else
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.FontBold = false;
												ViewModel.sprWeek1.Col = 5;
												ViewModel.sprWeek1.Text = CurrOper;
												ViewModel.sprWeek1.Col = 6;
												ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
												ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
												ViewModel.sprWeek1.Col = 7;
												ViewModel.sprWeek1.Text = "";
												ViewModel.sprWeek1.Col = 8;
												ViewModel.sprWeek1.Text = "";

												if ( modGlobal.Clean(CurrJob) != "" )
												{
													//                                            If CurrJob <> JobCode Then
													FillerRow1 = ViewModel.CurrRow1 + 1;
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.FontBold = false;
													ViewModel.sprWeek1.Col = 5;
													ViewModel.sprWeek1.Text = CurrOper;
													ViewModel.sprWeek1.Col = 6;
													ViewModel.sprWeek1.Text = "9005";
													ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
													ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
													ViewModel.sprWeek1.Col = 7;
													ViewModel.sprWeek1.Text = CurrJob;
													ViewModel.sprWeek1.Col = 8;
													ViewModel.sprWeek1.Text = CurrStep;
												//                                            End If
												}

												NeedToAddRow1 = true;
											}
											break;
										}
										else
										{
											if ( NeedToAddRow2 )
											{
												(ViewModel.CurrRow2)++;
												NeedToAddRow2 = false;
											}
											if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col = 5;
												ViewModel.sprWeek2.Text = CurrOper;
												ViewModel.sprWeek2.Col = 6;
												ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
												ViewModel.sprWeek2.FontBold = false;
												ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
												//                                        If CurrJob <> JobCode Then
												ViewModel.sprWeek2.Col = 7;
												ViewModel.sprWeek2.Text = CurrJob;
												ViewModel.sprWeek2.Col = 8;
												ViewModel.sprWeek2.Text = CurrStep;
											//                                        End If

											}
											else
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col = 5;
												ViewModel.sprWeek2.Text = CurrOper;
												ViewModel.sprWeek2.Col = 6;
												ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
												ViewModel.sprWeek2.FontBold = false;
												ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
												ViewModel.sprWeek2.Col = 7;
												ViewModel.sprWeek2.Text = "";
												ViewModel.sprWeek2.Col = 8;
												ViewModel.sprWeek2.Text = "";

												if ( modGlobal.Clean(CurrJob) != "" )
												{
													//                                            If CurrJob <> JobCode Then
													FillerRow2 = ViewModel.CurrRow2 + 1;
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Col = 5;
													ViewModel.sprWeek2.Text = CurrOper;
													ViewModel.sprWeek2.Col = 6;
													ViewModel.sprWeek2.Text = "9005";
													ViewModel.sprWeek2.FontBold = false;
													ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
													ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
													ViewModel.sprWeek2.Col = 7;
													ViewModel.sprWeek2.Text = CurrJob;
													ViewModel.sprWeek2.Col = 8;
													ViewModel.sprWeek2.Text = CurrStep;
												//                                            End If
												}
											}
											break;
										}
									}
								}
								TotalHours = 0;
								WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
							}
						}
						else
						{
							// KOT is the same... but not JobCode
							if ( TotalHours < 12 )
							{
								TotalHours += 12;
							}
							for ( int i = 0; i <= 13; i++ )
							{
								if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
								{
									if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
									{
										if ( NeedToAddRow1 )
										{
											(ViewModel.CurrRow1)++;
											NeedToAddRow1 = false;
										}
										if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
										{
											ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
											ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
											ViewModel.sprWeek1.Col = 5;
											ViewModel.sprWeek1.Text = CurrOper;
											ViewModel.sprWeek1.Col = 6;
											ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
											//                                    If CurrJob <> JobCode Then
											ViewModel.sprWeek1.Col = 7;
											ViewModel.sprWeek1.Text = CurrJob;
											ViewModel.sprWeek1.Col = 8;
											ViewModel.sprWeek1.Text = CurrStep;
										//                                    End If
										}
										else
										{
											ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
											ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
											ViewModel.sprWeek1.Col = 5;
											ViewModel.sprWeek1.Text = CurrOper;
											ViewModel.sprWeek1.Col = 6;
											ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
											ViewModel.sprWeek1.Col = 7;
											ViewModel.sprWeek1.Text = "";
											ViewModel.sprWeek1.Col = 8;
											ViewModel.sprWeek1.Text = "";

											if ( modGlobal.Clean(CurrJob) != "" )
											{
												//                                        If CurrJob <> JobCode Then
												FillerRow1 = ViewModel.CurrRow1 + 1;
												ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek1.Row = FillerRow1;
												ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
												ViewModel.sprWeek1.Col = 5;
												ViewModel.sprWeek1.Text = CurrOper;
												ViewModel.sprWeek1.Col = 6;
												ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
												ViewModel.sprWeek1.Col = 7;
												ViewModel.sprWeek1.Text = CurrJob;
												ViewModel.sprWeek1.Col = 8;
												ViewModel.sprWeek1.Text = CurrStep;
												ViewModel.CurrRow1 = FillerRow1;
											//                                        End If
											}
										}
										NeedToAddRow1 = true;
										break;
									}
									else
									{
										if ( NeedToAddRow2 )
										{
											(ViewModel.CurrRow2)++;
											NeedToAddRow2 = false;
										}
										if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
										{
											ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
											ViewModel.sprWeek2.Col = 5;
											ViewModel.sprWeek2.Text = CurrOper;
											ViewModel.sprWeek2.Col = 6;
											ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
											ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
											//                                    If CurrJob <> JobCode Then
											ViewModel.sprWeek2.Col = 7;
											ViewModel.sprWeek2.Text = CurrJob;
											ViewModel.sprWeek2.Col = 8;
											ViewModel.sprWeek2.Text = CurrStep;
										//                                    End If
										}
										else
										{
											ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
											ViewModel.sprWeek2.Col = 5;
											ViewModel.sprWeek2.Text = CurrOper;
											ViewModel.sprWeek2.Col = 6;
											ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
											ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
											ViewModel.sprWeek2.Col = 7;
											ViewModel.sprWeek2.Text = "";
											ViewModel.sprWeek2.Col = 8;
											ViewModel.sprWeek2.Text = "";

											if ( modGlobal.Clean(CurrJob) != "" )
											{
												//                                        If CurrJob <> JobCode Then
												FillerRow2 = ViewModel.CurrRow2 + 1;
												ViewModel.sprWeek2.Row = FillerRow2;
												ViewModel.sprWeek2.Col = 5;
												ViewModel.sprWeek2.Text = CurrOper;
												ViewModel.sprWeek2.Col = 6;
												ViewModel.sprWeek2.Text = "9005";
												ViewModel.sprWeek2.FontBold = false;
												ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
												ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
												ViewModel.sprWeek2.Col = 7;
												ViewModel.sprWeek2.Text = CurrJob;
												ViewModel.sprWeek2.Col = 8;
												ViewModel.sprWeek2.Text = CurrStep;
												ViewModel.CurrRow2 = FillerRow2;
											//                                        End If
											}
										}
										NeedToAddRow2 = true;
										break;
									}
								}
							}
							TotalHours = 0;
							CurrJob = Convert.ToString(oRec["curr_job"]);
							CurrTitle = modGlobal.Clean(oRec["job_title"]).Trim();
							CurrStep = modGlobal.Clean(oRec["step"]);
							if ( CurrStep == "0" )
							{
								CurrStep = "";
							}
							//*****
							NeedToAddRow1 = true;
							NeedToAddRow2 = true;
							//*****
							WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
						}
					}
					else
					{
						for ( int i = 0; i <= 13; i++ )
						{
							if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
							{
								if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
								{
									if ( NeedToAddRow1 )
									{
										(ViewModel.CurrRow1)++;
									}
									if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
									{
										ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
										ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
										ViewModel.sprWeek1.Col = 5;
										ViewModel.sprWeek1.Text = CurrOper;
										ViewModel.sprWeek1.Col = 6;
										ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
										//                                If CurrJob <> JobCode Then
										ViewModel.sprWeek1.Col = 7;
										ViewModel.sprWeek1.Text = CurrJob;
										ViewModel.sprWeek1.Col = 8;
										ViewModel.sprWeek1.Text = CurrStep;
									//                                End If
									}
									else
									{
										ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
										ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
										ViewModel.sprWeek1.Col = 5;
										ViewModel.sprWeek1.Text = CurrOper;
										ViewModel.sprWeek1.Col = 6;
										ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
										ViewModel.sprWeek1.Col = 7;
										ViewModel.sprWeek1.Text = "";
										ViewModel.sprWeek1.Col = 8;
										ViewModel.sprWeek1.Text = "";

										if ( modGlobal.Clean(CurrJob) != "" )
										{
											//                                    If CurrJob <> JobCode Then
											ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											FillerRow1 = ViewModel.CurrRow1 + 1;
											ViewModel.sprWeek1.Row = FillerRow1;
											ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
											ViewModel.sprWeek1.Col = 5;
											ViewModel.sprWeek1.Text = CurrOper;
											ViewModel.sprWeek1.Col = 6;
											ViewModel.sprWeek1.Text = "9005";
											ViewModel.sprWeek1.Col = 7;
											ViewModel.sprWeek1.Text = CurrJob;
											ViewModel.sprWeek1.Col = 8;
											ViewModel.sprWeek1.Text = CurrStep;
											ViewModel.CurrRow1 = FillerRow1;
										//                                    End If
										}
									}
									NeedToAddRow1 = true;
									break;
								}
								else
								{
									if ( NeedToAddRow2 )
									{
										(ViewModel.CurrRow2)++;
									}
									if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
									{
										ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
										ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
										ViewModel.sprWeek2.Col = 5;
										ViewModel.sprWeek2.Text = CurrOper;
										ViewModel.sprWeek2.Col = 6;
										ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
										//                                If CurrJob <> JobCode Then
										ViewModel.sprWeek2.Col = 7;
										ViewModel.sprWeek2.Text = CurrJob;
										ViewModel.sprWeek2.Col = 8;
										ViewModel.sprWeek2.Text = CurrStep;
									//                                End If
									}
									else
									{
										ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
										ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
										ViewModel.sprWeek2.Col = 5;
										ViewModel.sprWeek2.Text = CurrOper;
										ViewModel.sprWeek2.Col = 6;
										ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
										ViewModel.sprWeek2.Col = 7;
										ViewModel.sprWeek2.Text = "";
										ViewModel.sprWeek2.Col = 8;
										ViewModel.sprWeek2.Text = "";

										if ( modGlobal.Clean(CurrJob) != "" )
										{
											//                                    If CurrJob <> JobCode Then
											ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											FillerRow2 = ViewModel.CurrRow2 + 1;
											ViewModel.sprWeek2.Row = FillerRow2;
											ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
											ViewModel.sprWeek2.Col = 5;
											ViewModel.sprWeek2.Text = CurrOper;
											ViewModel.sprWeek2.Col = 6;
											ViewModel.sprWeek2.Text = "9005";
											ViewModel.sprWeek2.Col = 7;
											ViewModel.sprWeek2.Text = CurrJob;
											ViewModel.sprWeek2.Col = 8;
											ViewModel.sprWeek2.Text = CurrStep;
											ViewModel.CurrRow2 = FillerRow2;
										//                                    End If
										}
									}
									NeedToAddRow2 = true;
									break;
								}
							}
						}
						TotalHours = 0;
						CurrOper = "";
						ViewModel.CurrSAPCode = Convert.ToString(oRec["a_a_type"]);
						CurrJob = Convert.ToString(oRec["curr_job"]);
						CurrTitle = modGlobal.Clean(oRec["job_title"]).Trim();
						CurrStep = modGlobal.Clean(oRec["step"]);
						if ( CurrStep == "0" )
						{
							CurrStep = "";
						}
						WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");

					}
				};

				for ( int i = 0; i <= 13; i++ )
				{
					if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
					{
						if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
						{
							if ( NeedToAddRow1 )
							{
								(ViewModel.CurrRow1)++;
								NeedToAddRow1 = false;
							}
							if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
							{
								ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
								ViewModel.sprWeek1.FontBold = false;
								ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
								ViewModel.sprWeek1.Col = 5;
								if ( ViewModel.sprWeek1.Text == "" )
								{
									ViewModel.sprWeek1.Text = CurrOper;
									ViewModel.sprWeek1.Col = 6;
									ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
								}
								//                        If CurrJob <> JobCode Then
								ViewModel.sprWeek1.Col = 7;
								ViewModel.sprWeek1.Text = CurrJob;
								ViewModel.sprWeek1.Col = 8;
								ViewModel.sprWeek1.Text = CurrStep;
							//                        End If
							}
							else
							{
								ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
								if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
								{
									ViewModel.sprWeek1.FontBold = false;
									ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
									ViewModel.sprWeek1.Col = 5;
									ViewModel.sprWeek1.Text = CurrOper;
									ViewModel.sprWeek1.Col = 6;
									if ( ViewModel.sprWeek1.Text == "" )
									{
										ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
									}
								}
								if ( modGlobal.Clean(CurrJob) != "" )
								{
									//                            If CurrJob <> JobCode Then
									ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
									FillerRow1 = ViewModel.CurrRow1 + 1;
									ViewModel.sprWeek1.Row = FillerRow1;
									ViewModel.sprWeek1.FontBold = false;
									ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
									ViewModel.sprWeek1.Col = 5;
									ViewModel.sprWeek1.Text = CurrOper;
									ViewModel.sprWeek1.Col = 6;
									ViewModel.sprWeek1.Text = "9005";
									ViewModel.sprWeek1.Col = 7;
									ViewModel.sprWeek1.Text = CurrJob;
									ViewModel.sprWeek1.Col = 8;
									ViewModel.sprWeek1.Text = CurrStep;
									ViewModel.CurrRow1 = FillerRow1;
								//                            End If
								}
							}
							break;
						}
						else
						{
							if ( NeedToAddRow2 )
							{
								(ViewModel.CurrRow2)++;
								NeedToAddRow2 = false;
							}
							if ( ViewModel.CurrSAPCode != "9900" && ViewModel.CurrSAPCode != "9901" )
							{
								ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
								ViewModel.sprWeek2.FontBold = false;
								ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
								ViewModel.sprWeek2.Col = 5;
								if ( ViewModel.sprWeek2.Text == "" )
								{
									ViewModel.sprWeek2.Text = CurrOper;
									ViewModel.sprWeek2.Col = 6;
									ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
								}
								//                        If CurrJob <> JobCode Then
								ViewModel.sprWeek2.Col = 7;
								ViewModel.sprWeek2.Text = CurrJob;
								ViewModel.sprWeek2.Col = 8;
								ViewModel.sprWeek2.Text = CurrStep;
							//                        End If
							}
							else
							{
								ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
								if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
								{
									ViewModel.sprWeek2.FontBold = false;
									ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
									ViewModel.sprWeek2.Col = 5;
									if ( ViewModel.sprWeek2.Text == "" )
									{
										ViewModel.sprWeek2.Text = CurrOper;
										ViewModel.sprWeek2.Col = 6;
										ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
									}
									ViewModel.sprWeek2.Col = 7;
									ViewModel.sprWeek2.Text = "";
									ViewModel.sprWeek2.Col = 8;
									ViewModel.sprWeek2.Text = "";
								}
								if ( modGlobal.Clean(CurrJob) != "" )
								{
									//                            If CurrJob <> JobCode Then
									ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
									FillerRow2 = ViewModel.CurrRow2 + 1;
									ViewModel.sprWeek2.Row = FillerRow2;
									ViewModel.sprWeek2.FontBold = false;
									ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
									ViewModel.sprWeek2.Col = 5;
									ViewModel.sprWeek2.Text = CurrOper;
									ViewModel.sprWeek2.Col = 6;
									ViewModel.sprWeek2.Text = "9005";
									ViewModel.sprWeek2.Col = 7;
									ViewModel.sprWeek2.Text = CurrJob;
									ViewModel.sprWeek2.Col = 8;
									ViewModel.sprWeek2.Text = CurrStep;
									ViewModel.CurrRow2 = FillerRow2;
								//                            End If
								}
							}
							break;
						}
					}
				}
				if ( modGlobal.Shared.gPayPeriod == ViewModel.CurrPayPeriod )
				{
					ViewModel.cmdSave.Visible = true;
					ViewModel.cmdSave.Enabled = true;
				}
			}

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;
			ViewModel.CurrLeaveTotal = 0;
			//Enter Leave Lines
			oCmd.CommandText = "sp_GetIndPPLeave '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			TotalHours = 0;

			if ( !oRec.EOF )
			{
				CurrOper = "";
				ViewModel.CurrSAPCode = Convert.ToString(oRec["a_a_type"]);
				ViewModel.SchedTime = modGlobal.Clean(oRec["sched_time_code"]);
				if ( modGlobal.Clean(oRec["filler_code"]) != "" )
				{
					//Make Change Here  FCC = TFC
					if ( ViewModel.CurrentUnit != "FCC" )
					{
						ViewModel.NeedFillerCode = true;
						ViewModel.CurrFillerCode = modGlobal.Clean(oRec["filler_code"]);
					}
					else
					{
						ViewModel.NeedFillerCode = false;
						ViewModel.CurrFillerCode = "";
					}
				}
				else
				{
					ViewModel.NeedFillerCode = false;
					ViewModel.CurrFillerCode = "";
				}
				//**********
				bool tempBool = false;
				string auxVar = modGlobal.Clean(oRec["pension_limit"]);
				if ( (Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)) )
				{
					ocmd2.CommandText = "spSelect_EmployeePensionLimitPPTotal '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "','" + ViewModel.CurrSAPCode + "' ";
					orec2 = ADORecordSetHelper.Open(ocmd2, "");
					if ( !orec2.EOF )
					{
						ViewModel.CurrLeaveTotal = Convert.ToSingle(orec2["LeaveTotal"]);
						TotalShifts = ViewModel.CurrLeaveTotal / 12;
						ViewModel.SetLimit = true;
						if ( ViewModel.CurrLeaveTotal > modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.OverAmount = ViewModel.CurrLeaveTotal - modGlobal.Shared.gMaxhoursOp;
							ViewModel.UnderAmount = 0;
						}
						else if ( ViewModel.CurrLeaveTotal < modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.UnderAmount = modGlobal.Shared.gMaxhoursOp - ViewModel.CurrLeaveTotal;
							ViewModel.OverAmount = 0;
						}
					}
					else
					{
						ViewModel.SetLimit = false;
						ViewModel.OverAmount = 0;
						ViewModel.UnderAmount = 0;
					}
				}
				else
				{
					ViewModel.SetLimit = false;
					ViewModel.CurrLeaveTotal = 0;
					TotalShifts = 0;
					ViewModel.OverAmount = 0;
					ViewModel.UnderAmount = 0;
				}
				//**********
				WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
				NeedToAddRow1 = true;
				NeedToAddRow2 = true;

				while ( !oRec.EOF )
				{
					if ( ViewModel.CurrSAPCode == modGlobal.Clean(oRec["a_a_type"]) )
					{
						if ( WorkDate == Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy") )
						{
							TotalHours += 12;
							if ( ViewModel.SetLimit )
							{
								ViewModel.CurrLeaveTotal -= 12;
								TotalShifts--;
								PossibleSkip = ViewModel.SchedTime == "DDF" || ViewModel.SchedTime == "UDD";
							}
							oRec.MoveNext();
							if ( !oRec.EOF )
							{
								ViewModel.SchedTime = modGlobal.Clean(oRec["sched_time_code"]);
							}
						}
						else
						{
							for ( int i = 0; i <= 13; i++ )
							{
								if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
								{
									if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
									{
										//**********
										if ( ViewModel.SetLimit )
										{
											if ( PossibleSkip )
											{
												if ( ViewModel.OverAmount > 0 )
												{
													if ( ViewModel.OverAmount >= TotalHours )
													{
														ViewModel.OverAmount -= TotalHours;
														break; //not going to write this row
													}
													else
													{
													//                                                    TotalHours = TotalHours - OverAmount
													//                                                    OverAmount = 0
													//                                                    SetLimit = False
													}
												}
											}
											else
											{
												if ( TotalShifts > 0 )
												{ //not the last time through
												//continue
												}
												else
												{
													if ( ViewModel.OverAmount >= TotalHours )
													{
													//                                                    NeedAdjustment = True
													}
													else if ( ViewModel.UnderAmount > 0 )
													{
														ViewModel.NeedAdjustment = true;
													}
													else
													{
													//                                                    TotalHours = TotalHours - OverAmount
													//                                                    OverAmount = 0
													//                                                    SetLimit = False
													}
												}
											}
										}
										//**********
										if ( NeedToAddRow1 )
										{
											(ViewModel.CurrRow1)++;
											NeedToAddRow1 = false;
										}
										ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
										if ( TemporaryJobCode != "" )
										{
											ViewModel.sprWeek1.Col = 7;
											ViewModel.sprWeek1.Text = TemporaryJobCode;
											ViewModel.sprWeek1.Col = 8;
											ViewModel.sprWeek1.Text = TemporaryStep;
										}
										ViewModel.sprWeek1.Col = 5;
										ViewModel.sprWeek1.Text = CurrOper;
										ViewModel.sprWeek1.Col = 6;
										ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
										ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

										if ( ViewModel.NeedFillerCode )
										{
											ViewModel.sprWeek1.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
											FillerRow1 = ViewModel.CurrRow1 + 1;
											ViewModel.sprWeek1.Row = FillerRow1;
											if ( TemporaryJobCode != "" )
											{
												ViewModel.sprWeek1.Col = 7;
												ViewModel.sprWeek1.Text = TemporaryJobCode;
												ViewModel.sprWeek1.Col = 8;
												ViewModel.sprWeek1.Text = TemporaryStep;
											}
											ViewModel.sprWeek1.Col = 5;
											ViewModel.sprWeek1.Text = "";
											ViewModel.sprWeek1.Col = 6;
											ViewModel.sprWeek1.Text = ViewModel.CurrFillerCode;
											ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek1.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
										}
										else
										{
											ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
										}
										ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
										ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
										break;

									}
									else
									{
										//**********
										if ( ViewModel.SetLimit )
										{
											if ( PossibleSkip )
											{
												if ( ViewModel.OverAmount > 0 )
												{
													if ( ViewModel.OverAmount >= TotalHours )
													{
														ViewModel.OverAmount -= TotalHours;
														break; //not going to write this row
													}
													else
													{
													//                                                    TotalHours = TotalHours - OverAmount
													//                                                    OverAmount = 0
													//                                                    SetLimit = False
													}
												}
											}
											else
											{
												if ( TotalShifts > 0 )
												{ //not the last time through
												//continue
												}
												else
												{
													if ( ViewModel.OverAmount >= TotalHours )
													{
													//                                                    NeedAdjustment = True
													}
													else if ( ViewModel.UnderAmount > 0 )
													{
														ViewModel.NeedAdjustment = true;
													}
													else
													{
													//                                                    TotalHours = TotalHours - OverAmount
													//                                                    OverAmount = 0
													//                                                    SetLimit = False
													}
												}
											}
										}
										//**********
										if ( NeedToAddRow2 )
										{
											(ViewModel.CurrRow2)++;
											NeedToAddRow2 = false;
										}
										ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
										if ( TemporaryJobCode != "" )
										{
											ViewModel.sprWeek2.Col = 7;
											ViewModel.sprWeek2.Text = TemporaryJobCode;
											ViewModel.sprWeek2.Col = 8;
											ViewModel.sprWeek2.Text = TemporaryStep;
										}
										ViewModel.sprWeek2.Col = 5;
										ViewModel.sprWeek2.Text = CurrOper;
										ViewModel.sprWeek2.Col = 6;
										ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
										ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

										if ( ViewModel.NeedFillerCode )
										{
											ViewModel.sprWeek2.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
											FillerRow2 = ViewModel.CurrRow2 + 1;
											ViewModel.sprWeek2.Row = FillerRow2;
											if ( TemporaryJobCode != "" )
											{
												ViewModel.sprWeek2.Col = 7;
												ViewModel.sprWeek2.Text = TemporaryJobCode;
												ViewModel.sprWeek2.Col = 8;
												ViewModel.sprWeek2.Text = TemporaryStep;
											}
											ViewModel.sprWeek2.Col = 5;
											ViewModel.sprWeek2.Text = "";
											ViewModel.sprWeek2.Col = 6;
											ViewModel.sprWeek2.Text = ViewModel.CurrFillerCode;
											ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
											ViewModel.sprWeek2.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
										}
										else
										{
											ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
										}
										ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
										ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
										break;
									}
								}
							}
							TotalHours = 0;
							WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
							ViewModel.SchedTime = modGlobal.Clean(oRec["sched_time_code"]);
						}
					}
					else
					{
						for ( int i = 0; i <= 13; i++ )
						{
							if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
							{
								if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
								{
									if ( NeedToAddRow1 )
									{
										(ViewModel.CurrRow1)++;
									}
									ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
									if ( TemporaryJobCode != "" )
									{
										ViewModel.sprWeek1.Col = 7;
										ViewModel.sprWeek1.Text = TemporaryJobCode;
										ViewModel.sprWeek1.Col = 8;
										ViewModel.sprWeek1.Text = TemporaryStep;
									}
									ViewModel.sprWeek1.Col = 5;
									ViewModel.sprWeek1.Text = CurrOper;
									ViewModel.sprWeek1.Col = 6;
									ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
									ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

									if ( ViewModel.NeedFillerCode )
									{
										ViewModel.sprWeek1.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
										FillerRow1 = ViewModel.CurrRow1 + 1;
										ViewModel.sprWeek1.Row = FillerRow1;
										if ( TemporaryJobCode != "" )
										{
											ViewModel.sprWeek1.Col = 7;
											ViewModel.sprWeek1.Text = TemporaryJobCode;
											ViewModel.sprWeek1.Col = 8;
											ViewModel.sprWeek1.Text = TemporaryStep;
										}
										ViewModel.sprWeek1.Col = 5;
										ViewModel.sprWeek1.Text = "";
										ViewModel.sprWeek1.Col = 6;
										ViewModel.sprWeek1.Text = ViewModel.CurrFillerCode;
										ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek1.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
										//                                If NeedToAddRow1 Then
										ViewModel.CurrRow1 = FillerRow1;
									//                                End If
									}
									else
									{
										ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
									}
									ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
									ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
									NeedToAddRow1 = true;
									break;
								}
								else
								{
									if ( NeedToAddRow2 )
									{
										(ViewModel.CurrRow2)++;
									}
									ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
									if ( TemporaryJobCode != "" )
									{
										ViewModel.sprWeek2.Col = 7;
										ViewModel.sprWeek2.Text = TemporaryJobCode;
										ViewModel.sprWeek2.Col = 8;
										ViewModel.sprWeek2.Text = TemporaryStep;
									}
									ViewModel.sprWeek2.Col = 5;
									ViewModel.sprWeek2.Text = CurrOper;
									ViewModel.sprWeek2.Col = 6;
									ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
									ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

									if ( ViewModel.NeedFillerCode )
									{
										ViewModel.sprWeek2.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
										FillerRow2 = ViewModel.CurrRow2 + 1;
										ViewModel.sprWeek2.Row = FillerRow2;
										if ( TemporaryJobCode != "" )
										{
											ViewModel.sprWeek2.Col = 7;
											ViewModel.sprWeek2.Text = TemporaryJobCode;
											ViewModel.sprWeek2.Col = 8;
											ViewModel.sprWeek2.Text = TemporaryStep;
										}
										ViewModel.sprWeek2.Col = 5;
										ViewModel.sprWeek2.Text = "";
										ViewModel.sprWeek2.Col = 6;
										ViewModel.sprWeek2.Text = ViewModel.CurrFillerCode;
										ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
										ViewModel.sprWeek2.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
										ViewModel.CurrRow2 = FillerRow2;
									}
									else
									{
										ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
									}
									ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
									ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
									NeedToAddRow2 = true;
									break;
								}
							}
						}
						TotalHours = 0;
						CurrOper = "";
						ViewModel.CurrSAPCode = Convert.ToString(oRec["a_a_type"]);
						ViewModel.SchedTime = modGlobal.Clean(oRec["sched_time_code"]);
						WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
						//****                    '  *
						if ( modGlobal.Clean(oRec["filler_code"]) != "" )
						{
							//Make Change Here  FCC = TFC
							if ( ViewModel.CurrentUnit != "FCC" )
							{
								ViewModel.NeedFillerCode = true;
								ViewModel.CurrFillerCode = modGlobal.Clean(oRec["filler_code"]);
							}
							else
							{
								ViewModel.NeedFillerCode = false;
								ViewModel.CurrFillerCode = "";
							}
						}
						else
						{
							ViewModel.NeedFillerCode = false;
							ViewModel.CurrFillerCode = "";
						}
					//****
					}
				};

				//start here... last time through...
				for ( int i = 0; i <= 13; i++ )
				{
					if ( Convert.ToString(ViewModel.DateArray[i, 0]) == WorkDate )
					{
						if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
						{
							//**********
							if ( ViewModel.SetLimit )
							{
								if ( PossibleSkip )
								{
									if ( ViewModel.OverAmount > 0 )
									{
										if ( ViewModel.OverAmount >= TotalHours )
										{
											ViewModel.OverAmount -= TotalHours;
											break; //this should never happen
										}
										else
										{
											TotalHours -= ViewModel.OverAmount;
											ViewModel.OverAmount = 0;
											ViewModel.SetLimit = false;
										}
									}
									else if ( ViewModel.UnderAmount > 0 )
									{
										ViewModel.NeedAdjustment = true;
									}
								}
								else
								{
									if ( TotalShifts > 0 )
									{ //not the last time through
									//continue
									}
									else
									{
										if ( ViewModel.OverAmount >= TotalHours )
										{
										//                                        NeedAdjustment = True
										}
										else if ( ViewModel.UnderAmount > 0 )
										{
											ViewModel.NeedAdjustment = true;
										}
										else
										{
											TotalHours -= ViewModel.OverAmount;
											ViewModel.OverAmount = 0;
											ViewModel.SetLimit = false;
										}
									}
								}
							}
							//**********
							if ( NeedToAddRow1 )
							{
								(ViewModel.CurrRow1)++;
								NeedToAddRow1 = false;
							}
							ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
							ViewModel.sprWeek1.Col = 5;
							if ( ViewModel.sprWeek1.Text == "" )
							{
								ViewModel.sprWeek1.Text = CurrOper;
								ViewModel.sprWeek1.Col = 6;
								ViewModel.sprWeek1.Text = ViewModel.CurrSAPCode;
								if ( TemporaryJobCode != "" )
								{
									ViewModel.sprWeek1.Col = 7;
									ViewModel.sprWeek1.Text = TemporaryJobCode;
									ViewModel.sprWeek1.Col = 8;
									ViewModel.sprWeek1.Text = TemporaryStep;
								}
							}
							ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

							if ( ViewModel.NeedFillerCode )
							{
								ViewModel.sprWeek1.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
								FillerRow1 = ViewModel.CurrRow1 + 1;
								ViewModel.sprWeek1.Row = FillerRow1;
								if ( TemporaryJobCode != "" )
								{
									ViewModel.sprWeek1.Col = 7;
									ViewModel.sprWeek1.Text = TemporaryJobCode;
									ViewModel.sprWeek1.Col = 8;
									ViewModel.sprWeek1.Text = TemporaryStep;
								}
								ViewModel.sprWeek1.Col = 5;
								ViewModel.sprWeek1.Text = "";
								ViewModel.sprWeek1.Col = 6;
								ViewModel.sprWeek1.Text = ViewModel.CurrFillerCode;
								ViewModel.sprWeek1.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek1.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
								//**********
								if ( ViewModel.NeedAdjustment )
								{ //time to deal with the UnderAmount
									switch ( Convert.ToInt32(ViewModel.DateArray[i, 1]) )
									{ //sprWeek1.Col
										case 9:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
										case 10:
											for ( int x = 0; x <= 5; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 1; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek1.Row = FillerRow1;
														ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 11:
											for ( int x = 0; x <= 4; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 2; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek1.Row = FillerRow1;
														ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 12:
											for ( int x = 0; x <= 3; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 3; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek1.Row = FillerRow1;
														ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 13:
											for ( int x = 0; x <= 2; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 4; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek1.Row = FillerRow1;
														ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 14:
											for ( int x = 0; x <= 1; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 5; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek1.Row = FillerRow1;
														ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 15:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col -= x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek1.Row = FillerRow1;
													ViewModel.sprWeek1.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
									}
									TotalHours += ViewModel.UnderAmount;
								}
							//**********
							}
							else
							{
								ViewModel.sprWeek1.Text = Math.Round((double)TotalHours, 2).ToString();
								//**********
								if ( ViewModel.NeedAdjustment )
								{ //time to deal with the UnderAmount
									switch ( Convert.ToInt32(ViewModel.DateArray[i, 1]) )
									{ //sprWeek1.Col
										case 9:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
										case 10:
											for ( int x = 0; x <= 5; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 1; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 11:
											for ( int x = 0; x <= 4; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 2; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 12:
											for ( int x = 0; x <= 3; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 3; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 13:
											for ( int x = 0; x <= 2; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 4; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 14:
											for ( int x = 0; x <= 1; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 5; x++ )
												{
													ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
													ViewModel.sprWeek1.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
													{
														ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 15:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek1.Row = ViewModel.CurrRow1;
												ViewModel.sprWeek1.Col -= x;
												if ( modGlobal.Clean(ViewModel.sprWeek1.Text) == "" )
												{
													ViewModel.sprWeek1.Text = Math.Round((double)ViewModel.UnderAmount, 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
									}
									TotalHours += ViewModel.UnderAmount;
								}
							//**********
							}

							ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
							ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
							break;

						}
						else
						{
							//**********
							if ( ViewModel.SetLimit )
							{
								if ( PossibleSkip )
								{
									if ( ViewModel.OverAmount > 0 )
									{
										if ( ViewModel.OverAmount >= TotalHours )
										{
											ViewModel.OverAmount -= TotalHours;
											break; //not going to write this row
										}
										else
										{
											TotalHours -= ViewModel.OverAmount;
											ViewModel.OverAmount = 0;
											ViewModel.SetLimit = false;
										}
									}
								}
								else
								{
									if ( TotalShifts > 0 )
									{ //not the last time through
									//continue
									}
									else
									{
										if ( ViewModel.OverAmount >= TotalHours )
										{
										//                                        NeedAdjustment = True
										}
										else if ( ViewModel.UnderAmount > 0 )
										{
											ViewModel.NeedAdjustment = true;
										}
										else
										{
											TotalHours -= ViewModel.OverAmount;
											ViewModel.OverAmount = 0;
											ViewModel.SetLimit = false;
										}
									}
								}
							}
							//**********
							if ( NeedToAddRow2 )
							{
								(ViewModel.CurrRow2)++;
								NeedToAddRow2 = false;
							}
							ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
							ViewModel.sprWeek2.Col = 5;
							if ( ViewModel.sprWeek2.Text == "" )
							{
								ViewModel.sprWeek2.Text = CurrOper;
								ViewModel.sprWeek2.Col = 6;
								ViewModel.sprWeek2.Text = ViewModel.CurrSAPCode;
								if ( TemporaryJobCode != "" )
								{
									ViewModel.sprWeek2.Col = 7;
									ViewModel.sprWeek2.Text = TemporaryJobCode;
									ViewModel.sprWeek2.Col = 8;
									ViewModel.sprWeek2.Text = TemporaryStep;
								}
							}
							ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);

							if ( ViewModel.NeedFillerCode )
							{
								ViewModel.sprWeek2.Text = Math.Round((double)((TotalHours / 3) * 2), 2).ToString();
								FillerRow2 = ViewModel.CurrRow2 + 1;
								ViewModel.sprWeek2.Row = FillerRow2;
								if ( TemporaryJobCode != "" )
								{
									ViewModel.sprWeek2.Col = 7;
									ViewModel.sprWeek2.Text = TemporaryJobCode;
									ViewModel.sprWeek2.Col = 8;
									ViewModel.sprWeek2.Text = TemporaryStep;
								}
								ViewModel.sprWeek2.Col = 5;
								ViewModel.sprWeek2.Text = "";
								ViewModel.sprWeek2.Col = 6;
								ViewModel.sprWeek2.Text = ViewModel.CurrFillerCode;
								ViewModel.sprWeek2.Col = Convert.ToInt32(ViewModel.DateArray[i, 1]);
								ViewModel.sprWeek2.Text = Math.Round((double)(TotalHours / 3d), 2).ToString();
								//*********
								if ( ViewModel.NeedAdjustment )
								{ //time to deal with the UnderAmount
									switch ( Convert.ToInt32(ViewModel.DateArray[i, 1]) )
									{ //sprWeek2.Col
										case 9:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
										case 10:
											for ( int x = 0; x <= 5; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 1; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek2.Row = FillerRow2;
														ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 11:
											for ( int x = 0; x <= 4; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 2; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek2.Row = FillerRow2;
														ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 12:
											for ( int x = 0; x <= 3; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 3; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek2.Row = FillerRow2;
														ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 13:
											for ( int x = 0; x <= 2; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 4; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek2.Row = FillerRow2;
														ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 14:
											for ( int x = 0; x <= 1; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 5; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
														ViewModel.sprWeek2.Row = FillerRow2;
														ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 15:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col -= x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = Math.Round((double)((ViewModel.UnderAmount / 3) * 2), 2).ToString();
													ViewModel.sprWeek2.Row = FillerRow2;
													ViewModel.sprWeek2.Text = Math.Round((double)(ViewModel.UnderAmount / 3d), 2).ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
									}
									TotalHours += ViewModel.UnderAmount;
								}
							//*********
							}
							else
							{
								ViewModel.sprWeek2.Text = Math.Round((double)TotalHours, 2).ToString();
								//*********
								if ( ViewModel.NeedAdjustment )
								{ //time to deal with the UnderAmount
									switch ( Convert.ToInt32(ViewModel.DateArray[i, 1]) )
									{ //sprweek2.Col
										case 9:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
										case 10:
											for ( int x = 0; x <= 5; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 1; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 11:
											for ( int x = 0; x <= 4; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 2; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 12:
											for ( int x = 0; x <= 3; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 3; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 13:
											for ( int x = 0; x <= 2; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 4; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 14:
											for ( int x = 0; x <= 1; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col += x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											if ( ViewModel.NeedAdjustment )
											{ //still haven't found a space
												for ( int x = 0; x <= 5; x++ )
												{
													ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
													ViewModel.sprWeek2.Col -= x;
													if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
													{
														ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
														ViewModel.NeedAdjustment = false;
														break;
													}
												}
											}
											break;
										case 15:
											for ( int x = 0; x <= 6; x++ )
											{
												ViewModel.sprWeek2.Row = ViewModel.CurrRow2;
												ViewModel.sprWeek2.Col -= x;
												if ( modGlobal.Clean(ViewModel.sprWeek2.Text) == "" )
												{
													ViewModel.sprWeek2.Text = ViewModel.UnderAmount.ToString();
													ViewModel.NeedAdjustment = false;
													break;
												}
											}
											break;
									}
									TotalHours += ViewModel.UnderAmount;
								}
							//*********
							}

							ViewModel.lbPayrollHrs.Text = "Total Exception Hours:";
							ViewModel.lbTotalHrs.Text = Math.Round((double)(Double.Parse(ViewModel.lbTotalHrs.Text) + TotalHours), 2).ToString();
							break;

						}
					}
				}
				if ( !ViewModel.LimitedAccess )
				{
					if ( ViewModel.frmBattOpt.Enabled )
					{
						ViewModel.cmdSave.Visible = true;
						ViewModel.cmdSave.Enabled = true;
					}
					else if ( modGlobal.Shared.gPayPeriod == ViewModel.CurrPayPeriod )
					{
						ViewModel.cmdSave.Visible = true;
						ViewModel.cmdSave.Enabled = true;
					}
				}
			}

		}

		public void RefreshEmployeeList()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;
			DbCommand oCmd3 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec3 = null;

			ViewModel.sprEmployeeList.Row = 1;
			ViewModel.sprEmployeeList.Row2 = ViewModel.sprEmployeeList.MaxRows;
			ViewModel.sprEmployeeList.Col = 1;
			ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
			ViewModel.sprEmployeeList.BlockMode = true;
			ViewModel.sprEmployeeList.Text = "";
			ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
			ViewModel.sprEmployeeList.BlockMode = false;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.ClearSelection();

			bool NoExceptions = false;
			bool NoLeave = false;
			bool NoSchedule = false;

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;

			oCmd3.Connection = modGlobal.oConn;
			oCmd3.CommandType = CommandType.Text;

			//Fill Employee Grid
			string sStringText = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			if ( ViewModel.chkNotUploaded.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				sStringText = "spSelect_EmployeeNotUploadedList ";
			}
			else
			{
				sStringText = "spSelect_EmployeeGridList ";
			}

			if ( modGlobal.Clean(ViewModel.CurrBatt) == "" )
			{
				if ( modGlobal.Clean(ViewModel.CurrUnit) == "" )
				{
					if ( modGlobal.Clean(ViewModel.CurrShift) == "" )
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, Null, Null, Null, Null";
							}
							else
							{
								sStringText = sStringText + "Null, Null, Null, Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, Null, Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "Null, Null, Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, Null";
							}
							else
							{
								sStringText = sStringText + "Null, Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "Null, Null, '" + modGlobal.Clean(ViewModel.CurrShift) + ", '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
				}
				else
				{
					if ( modGlobal.Clean(ViewModel.CurrShift) == "" )
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, Null, Null";
							}
							else
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, Null";
							}
							else
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "Null, '" + modGlobal.Clean(ViewModel.CurrUnit) + "', '" + modGlobal.Clean(ViewModel.
												CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}

				}
			}
			else
			{
				if ( modGlobal.Clean(ViewModel.CurrUnit) == "" )
				{
					if ( modGlobal.Clean(ViewModel.CurrShift) == "" )
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, Null, Null, Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, Null, Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, '" + modGlobal.Clean(ViewModel.CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', Null, '" + modGlobal.Clean(ViewModel.
												CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
				}
				else
				{
					if ( modGlobal.Clean(ViewModel.CurrShift) == "" )
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, Null, Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.CurrUnit) + "', Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.
												CurrUnit) + "', Null, '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
					else
					{
						if ( modGlobal.Clean(ViewModel.CurrGroupCode) == "" )
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.
												CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', Null, '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
						else
						{
							if ( modGlobal.Clean(ViewModel.CurrBenefit) == "" )
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.
												CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', Null";
							}
							else
							{
								sStringText = sStringText + "'" + modGlobal.Clean(ViewModel.CurrBatt) + "', '" + modGlobal.Clean(ViewModel.
														CurrUnit) + "', '" + modGlobal.Clean(ViewModel.CurrShift) + "', '" + modGlobal.Clean(ViewModel.CurrGroupCode) + "', '" + modGlobal.Clean(ViewModel.CurrBenefit) + "' ";
							}
						}
					}
				}
			}

			sStringText = sStringText + ", " + modGlobal.Shared.gPayrollYear.ToString() + "," + modGlobal.Shared.gPayPeriod.ToString() + ",";
			if ( modGlobal.Clean(ViewModel.txtNameSearch.Text) != "" )
			{
				sStringText = sStringText + "'" + modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary)) + "' ";
			}
			else
			{
				sStringText = sStringText + " Null ";
			}
			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;

			while ( !oRec.EOF )
			{
				GridRow++;
				ViewModel.sprEmployeeList.MaxRows = GridRow;
				ViewModel.sprEmployeeList.Row = GridRow;
				//        'does employee have a schedule?
				//        ocmd2.CommandText = "sp_GetQuickIndPPShifts '" & Clean(oRec("employee_id"]) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
				//        Set orec2 = ocmd2.Execute
				//        If orec2.EOF Then
				//            NoSchedule = True
				//        Else
				//            NoSchedule = False
				//            'does employee have exceptions?
				//            ocmd2.CommandText = "sp_GetQuickIndPPException '" & Clean(oRec("employee_id"]) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
				//            Set orec2 = ocmd2.Execute
				//            If orec2.EOF Then
				//                NoExceptions = True
				//            Else
				//                NoExceptions = False
				//            End If
				//            'does employee have leave?
				//            oCmd3.CommandText = "sp_GetQuickIndPPLeave '" & Clean(oRec("employee_id"]) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
				//            Set oRec3 = oCmd3.Execute
				//            If oRec3.EOF Then
				//                NoLeave = True
				//            Else
				//                NoLeave = False
				//            End If
				//        End If
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if ( modGlobal.Clean(oRec["OKflag"]) == "N" )
				{
					ViewModel.sprEmployeeList.Value = 0;
				}
				else
				{
					ViewModel.sprEmployeeList.Value = 1;
					NoSchedule = false;
					NoLeave = false;
					NoExceptions = false;
				}
				ViewModel.sprEmployeeList.Col = 2;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["employee_id"]);
				ViewModel.sprEmployeeList.Col = 3;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.sprEmployeeList.Col = 4;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["org"]);
				ViewModel.sprEmployeeList.Col = 5;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["battalion_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["shift_code"]);
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["job_code_id"]);
				ViewModel.sprEmployeeList.Col = 9;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = Convert.ToDateTime(oRec["TFD_hire_date"]).ToString("M/d/yyyy");
				ViewModel.sprEmployeeList.Col = 10;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));

				//does employee have a schedule?
				ocmd2.CommandText = "sp_GetQuickIndPPShifts '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
				orec2 = ADORecordSetHelper.Open(ocmd2, "");
				if ( orec2.EOF )
				{
					NoSchedule = true;
				}
				else
				{
					NoSchedule = false;
					//does employee have exceptions?
					ocmd2.CommandText = "sp_GetQuickIndPPException '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
					orec2 = ADORecordSetHelper.Open(ocmd2, "");
					NoExceptions = orec2.EOF;
					//does employee have leave?
					oCmd3.CommandText = "sp_GetQuickIndPPLeave '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
					oRec3 = ADORecordSetHelper.Open(oCmd3, "");
					NoLeave = oRec3.EOF;
				}

				if ( NoSchedule )
				{
					ViewModel.sprEmployeeList.BlockMode = true;
					ViewModel.sprEmployeeList.Row = GridRow;
					ViewModel.sprEmployeeList.Row2 = GridRow;
					ViewModel.sprEmployeeList.Col = 2;
					ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
					ViewModel.sprEmployeeList.FontBold = false;
					ViewModel.sprEmployeeList.BlockMode = false;
				}
				else if ( NoLeave && NoExceptions )
				{
					ViewModel.sprEmployeeList.BlockMode = true;
					ViewModel.sprEmployeeList.Row = GridRow;
					ViewModel.sprEmployeeList.Row2 = GridRow;
					ViewModel.sprEmployeeList.Col = 2;
					ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
					ViewModel.sprEmployeeList.FontBold = false;
					ViewModel.sprEmployeeList.BlockMode = false;
				}
				else
				{
					ViewModel.sprEmployeeList.BlockMode = true;
					ViewModel.sprEmployeeList.Row = GridRow;
					ViewModel.sprEmployeeList.Row2 = GridRow;
					ViewModel.sprEmployeeList.Col = 2;
					ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
					ViewModel.sprEmployeeList.FontBold = false;
					ViewModel.sprEmployeeList.BlockMode = false;
				}

				oRec.MoveNext();
			};

			//    For i = 1 To GridRow
			//        sprEmployeeList.Row = i
			//        sprEmployeeList.Col = 2
			//        If Clean(sprEmployeeList.Text) <> "" Then
			//            EmpID = sprEmployeeList.Text
			//            'does employee have a schedule?
			//            ocmd2.CommandText = "sp_GetQuickIndPPShifts '" & Clean(EmpID) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
			//            Set orec2 = ocmd2.Execute
			//            If orec2.EOF Then
			//                NoSchedule = True
			//            Else
			//                NoSchedule = False
			//                'does employee have exceptions?
			//                ocmd2.CommandText = "sp_GetQuickIndPPException '" & Clean(EmpID) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
			//                Set orec2 = ocmd2.Execute
			//                If orec2.EOF Then
			//                    NoExceptions = True
			//                Else
			//                    NoExceptions = False
			//                End If
			//                'does employee have leave?
			//                oCmd3.CommandText = "sp_GetQuickIndPPLeave '" & Clean(EmpID) & "','" & CurrStartDate & "','" & CurrEndDate & "'"
			//                Set oRec3 = oCmd3.Execute
			//                If oRec3.EOF Then
			//                    NoLeave = True
			//                Else
			//                    NoLeave = False
			//                End If
			//            End If
			//
			//            If NoSchedule Then
			//                sprEmployeeList.BlockMode = True
			//                sprEmployeeList.Row = GridRow
			//                sprEmployeeList.Row2 = GridRow
			//                sprEmployeeList.Col = 2
			//                sprEmployeeList.Col2 = sprEmployeeList.MaxCols
			//                sprEmployeeList.ForeColor = BLACK
			//                sprEmployeeList.FontBold = False
			//                sprEmployeeList.BlockMode = False
			//            ElseIf NoLeave And NoExceptions Then
			//                sprEmployeeList.BlockMode = True
			//                sprEmployeeList.Row = GridRow
			//                sprEmployeeList.Row2 = GridRow
			//                sprEmployeeList.Col = 2
			//                sprEmployeeList.Col2 = sprEmployeeList.MaxCols
			//                sprEmployeeList.ForeColor = RED
			//                sprEmployeeList.FontBold = False
			//                sprEmployeeList.BlockMode = False
			//            Else
			//                sprEmployeeList.BlockMode = True
			//                sprEmployeeList.Row = GridRow
			//                sprEmployeeList.Row2 = GridRow
			//                sprEmployeeList.Col = 2
			//                sprEmployeeList.Col2 = sprEmployeeList.MaxCols
			//                sprEmployeeList.ForeColor = BLUE
			//                sprEmployeeList.FontBold = False
			//                sprEmployeeList.BlockMode = False
			//            End If
			//        End If
			//    Next i

			if ( GridRow > 0 )
			{
				ViewModel.sprEmployeeList.MaxRows = GridRow;
			}
			else
			{
				ViewModel.sprEmployeeList.MaxRows = 1;
			}
			ViewModel.lbCount.Text = "List Count: " + GridRow.ToString();
			ViewModel.sprEmployeeList.Protect = true;
			//    FirstTime = False
			ViewModel.CurrPersID = 0;
			ViewModel.SelectedRow = 0;
			ClearTimeCard();

		}

		public void ClearTimeCard()
		{

			ViewModel.sprWeek1.Row = 1;
			ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
			ViewModel.sprWeek1.Col = 1;
			ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
			ViewModel.sprWeek1.BlockMode = true;
			ViewModel.sprWeek1.Text = "";
			ViewModel.sprWeek1.BlockMode = false;
			ViewModel.sprWeek2.Row = 1;
			ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
			ViewModel.sprWeek2.Col = 1;
			ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
			ViewModel.sprWeek2.BlockMode = true;
			ViewModel.sprWeek2.Text = "";
			ViewModel.sprWeek2.BlockMode = false;
			ViewModel.txtActivity1.Text = "";
			ViewModel.txtActivity2.Text = "";
			ViewModel.txtCostCenter1.Text = "";
			ViewModel.txtCostCenter2.Text = "";
			ViewModel.txtOper1.Text = "";
			ViewModel.txtOper2.Text = "";
			ViewModel.txtWBSElement1.Text = "";
			ViewModel.txtWBSElement2.Text = "";
			ViewModel.cboOrder1.Text = "";
			ViewModel.cboOrder1.SelectedIndex = -1;
			ViewModel.cboOrder2.Text = "";
			ViewModel.cboOrder2.SelectedIndex = -1;
			ViewModel.cboAAType1.Text = "";
			ViewModel.cboAAType1.SelectedIndex = -1;
			ViewModel.cboAAType2.Text = "";
			ViewModel.cboAAType2.SelectedIndex = -1;
			ViewModel.cboJobCode1.Text = "";
			ViewModel.cboJobCode1.SelectedIndex = -1;
			ViewModel.cboJobCode2.Text = "";
			ViewModel.cboJobCode2.SelectedIndex = -1;
			ViewModel.cboStep1.Text = "";
			ViewModel.cboStep1.SelectedIndex = -1;
			ViewModel.cboStep2.Text = "";
			ViewModel.cboStep2.SelectedIndex = -1;
			ViewModel.txtMo1.Text = "";
			ViewModel.txtMo2.Text = "";
			ViewModel.txtTu1.Text = "";
			ViewModel.txtTu2.Text = "";
			ViewModel.txtWe1.Text = "";
			ViewModel.txtWe2.Text = "";
			ViewModel.txtTh1.Text = "";
			ViewModel.txtTh2.Text = "";
			ViewModel.txtFr1.Text = "";
			ViewModel.txtFr2.Text = "";
			ViewModel.txtSa1.Text = "";
			ViewModel.txtSa2.Text = "";
			ViewModel.txtSu1.Text = "";
			ViewModel.txtSu2.Text = "";
			ViewModel.txtMo1.Tag = "";
			ViewModel.txtMo2.Tag = "";
			ViewModel.txtTu1.Tag = "";
			ViewModel.txtTu2.Tag = "";
			ViewModel.txtWe1.Tag = "";
			ViewModel.txtWe2.Tag = "";
			ViewModel.txtTh1.Tag = "";
			ViewModel.txtTh2.Tag = "";
			ViewModel.txtFr1.Tag = "";
			ViewModel.txtFr2.Tag = "";
			ViewModel.txtSa1.Tag = "";
			ViewModel.txtSa2.Tag = "";
			ViewModel.txtSu1.Tag = "";
			ViewModel.txtSu2.Tag = "";
			ViewModel.sprWeek1.Row = 1;
			ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
			ViewModel.sprWeek1.Col = 1;
			ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
			ViewModel.sprWeek1.BlockMode = true;
			ViewModel.sprWeek1.Text = "";
			ViewModel.sprWeek1.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek1.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek1.ClearSelection();

			//fill ID fields with zeros
			ViewModel.sprWeek1.Row = 1;
			ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
			ViewModel.sprWeek1.Col = 16;
			ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
			ViewModel.sprWeek1.BlockMode = true;
			ViewModel.sprWeek1.Text = "0";
			ViewModel.sprWeek1.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek1.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek1.ClearSelection();
			ViewModel.sprWeek2.Row = 1;
			ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
			ViewModel.sprWeek2.Col = 1;
			ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
			ViewModel.sprWeek2.BlockMode = true;
			ViewModel.sprWeek2.Text = "";
			ViewModel.sprWeek2.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek2.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek2.ClearSelection();

			//fill ID fields with zeros
			ViewModel.sprWeek2.Row = 1;
			ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
			ViewModel.sprWeek2.Col = 16;
			ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
			ViewModel.sprWeek2.BlockMode = true;
			ViewModel.sprWeek2.Text = "0";
			ViewModel.sprWeek2.BlockMode = false;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek2.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek2.ClearSelection();
			ViewModel.frmWeek1.Visible = false;
			ViewModel.frmWeek2.Visible = false;

		}

		public void LoadDateArray()
		{
			object WorkDate = ViewModel.CurrStartDate;
			for ( int i = 0; i <= 13; i++ )
			{
				//UPGRADE_WARNING: (1068) WorkDate of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.DateArray[i, 0] = WorkDate;
				if ( i < 7 )
				{
					ViewModel.DateArray[i, 1] = i + 9;
					ViewModel.DateArray[i, 2] = 0;
				}
				else
				{
					ViewModel.DateArray[i, 1] = i + 2;
					ViewModel.DateArray[i, 2] = 1;
				}
				//UPGRADE_WARNING: (1068) WorkDate of type Variant is being forced to DateTime. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				WorkDate = Convert.ToDateTime(WorkDate).AddDays(1).ToString("M/d/yyyy");
			}

		}

		public void FillLists()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			//Fill Assignment Type List box
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spSelect_AssignmentTypeList";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboAssignmentCode.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboAssignmentCode.AddItem(modGlobal.Clean(oRec["assignment_type_code"]));
				oRec.MoveNext();
			};

			//Fill Unit List box
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "spUnitList";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.cboUnit.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboUnit.AddItem(Convert.ToString(oRec["unit_code"]));
				oRec.MoveNext();
			};

			//Fill Benefit Combo Box list
			ViewModel.cboBenefit.AddItem(""); // Add each item to list.

			ViewModel.cboBenefit.AddItem("COT");
			ViewModel.cboBenefit.AddItem("CF1");
			ViewModel.cboBenefit.AddItem("CF2");
			ViewModel.cboBenefit.Text = ViewModel.cboBenefit.GetListItem(0); // Display first item
		}

		public void ClearFields()
		{

			ViewModel.cboAssignmentCode.SelectedIndex = -1;
			ViewModel.cboBenefit.SelectedIndex = -1;
			ViewModel.cboUnit.SelectedIndex = -1;
			ViewModel.optA.Checked = false;
			ViewModel.optB.Checked = false;
			ViewModel.optC.Checked = false;
			ViewModel.optD.Checked = false;

			//    chkNotUploaded.Value = 0
			ViewModel.lbTotalHrs.Text = "0";
			ViewModel.txtNameSearch.Text = "";
			ViewModel.CurrShift = "";
			ViewModel.CurrUnit = "";
			ViewModel.CurrGroupCode = "";
			ViewModel.CurrBenefit = "";

			if ( ViewModel.frmBattOpt.Enabled )
			{
				ViewModel.opt181.Checked = false;
				ViewModel.opt182.Checked = false;
				ViewModel.optAll.Checked = true;
				ViewModel.CurrBatt = "";
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAssignmentCode_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboAssignmentCode.SelectedIndex == -1 )
			{
				return ;
			}
			ViewModel.CurrGroupCode = modGlobal.Clean(ViewModel.cboAssignmentCode.Text);
			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboBenefit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboBenefit.SelectedIndex == -1 )
			{
				return ;
			}
			ViewModel.CurrBenefit = modGlobal.Clean(ViewModel.cboBenefit.Text);
			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( modGlobal.Clean(ViewModel.cboJobCode1.Text) == "" )
			{
				return ;
			}
			else
			{
				if ( FillStepList(1, modGlobal.Clean(ViewModel.cboJobCode1.Text)) )
				{
					return ;
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboJobCode2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( modGlobal.Clean(ViewModel.cboJobCode2.Text) == "" )
			{
				return ;
			}
			else
			{
				if ( FillStepList(2, modGlobal.Clean(ViewModel.cboJobCode2.Text)) )
				{
					return ;
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboPayPeriod_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Recall start and end dates for Pay Period
			//Check to determine if a Employee is selected
			//If so Fill Time Card

			if ( ViewModel.cboPayPeriod.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetPPDates " + ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex).ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( !oRec.EOF )
			{
				modGlobal.Shared.gPayPeriod = ViewModel.cboPayPeriod.GetItemData(ViewModel.cboPayPeriod.SelectedIndex);
				ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
				ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
				LoadDateArray();
			}
			else
			{
				ViewModel.CurrStartDate = "";
				ViewModel.CurrEndDate = "";
				ViewManager.ShowMessage("Unable to recall Pay Period Data", "Individual Time Card Reporting", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}

			if ( !ViewModel.frmBattOpt.Enabled )
			{
				if ( modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
				{
					ViewModel.cmdOKToPay.Enabled = false;
					ViewModel.cmdSave.Enabled = false;
					ViewModel.cmdPrint.Enabled = false;
				}
				else
				{
					ViewModel.cmdOKToPay.Enabled = !ViewModel.LimitedAccess;
				}
			}

			if ( ViewModel.CurrEmpID != "" )
			{
				FillTimeCard();
				FormatTimeCard();
			}


			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboUnit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboUnit.SelectedIndex == -1 )
			{
				return ;
			}
			ViewModel.CurrUnit = modGlobal.Clean(ViewModel.cboUnit.Text);
			RefreshEmployeeList();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboYear_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(ViewModel.cboYear.Text) == modGlobal.Shared.gPayrollYear )
			{
				return ;
			}

			modGlobal.Shared.gPayrollYear = Convert.ToInt32(Double.Parse(ViewModel.cboYear.Text));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while ( !oRec.EOF )
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				oRec.MoveNext();
			};

			modGlobal.Shared.gPayPeriod = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void chkAll_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			//int i = 0;

			if ( ViewModel.chkAll.CheckState == UpgradeHelpers.Helpers.CheckState.Unchecked )
			{
				return ;
			}

		//    For i = 1 To sprEmployeeList.MaxRows
		//        sprEmployeeList.Col = 1
		//        sprEmployeeList.Row = i
		//        If sprEmployeeList.Value = chkAll.Value Then
		//
		//        End If
		//    Next i


		}

		[UpgradeHelpers.Events.Handler]
		internal void chkNotUploaded_CheckStateChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime )
			{
				return ;
			}
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdApply1_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsFireUpload PayrollCL = Container.Resolve<clsFireUpload>();
			//string SAPActivityType = ""; //letter + job_code

			string CurrTimeCode = "";

			bool NeedRefresh = false;
			bool RecordChange = false;

			if ( ViewModel.SelectedRow1 == 0 )
			{
				return ;
			}
			if ( modGlobal.Shared.gPayPeriod == 0 )
			{
				ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( !ViewModel.frmBattOpt.Enabled )
			{
				if ( ~EditApply(1) != 0 )
				{
					return ;
				}
			}

			if ( !ViewModel.PayRollExist )
			{
				AddEmployeePayRoll();

			}
			ViewModel.sprWeek1.Row = ViewModel.SelectedRow1;

			PayrollCL.PPcalendar_year = modGlobal.Shared.gPayrollYear;
			PayrollCL.PPpay_period = modGlobal.Shared.gPayPeriod;
			PayrollCL.PPper_sys_id = ViewModel.CurrPersID;

			//Activity
			ViewModel.sprWeek1.Col = 1;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtActivity1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.txtActivity1.Text);
			}

			//Cost Center
			ViewModel.sprWeek1.Col = 2;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtCostCenter1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
			}

			//WBS Element
			ViewModel.sprWeek1.Col = 3;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtWBSElement1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
			}

			//Order
			ViewModel.sprWeek1.Col = 4;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.cboOrder1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.cboOrder1.Text);
			}

			//Operation
			ViewModel.sprWeek1.Col = 5;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtOper1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.txtOper1.Text);
			}

			//A/A Type
			ViewModel.sprWeek1.Col = 6;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != ViewModel.cboAAType1.Text.Substring(0, Math.Min(4, ViewModel.cboAAType1.Text.Length)) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = ViewModel.cboAAType1.Text.Substring(0, Math.Min(4, ViewModel.cboAAType1.Text.Length));
			}

			if ( ViewModel.CurrSAPCode == "" )
			{
				CurrTimeCode = ViewModel.cboAAType1.Text.Substring(0, Math.Min(4, ViewModel.cboAAType1.Text.Length));
			}
			else
			{
				CurrTimeCode = ViewModel.CurrSAPCode;
			}
			if ( modGlobal.Clean(CurrTimeCode) == "" )
			{
				ViewManager.ShowMessage("You must select an A/A Type(KOT)", "Payroll Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( ViewModel.NeedFillerCode )
			{
			//continue... no need to check
			}
			else if ( PayrollCL.GetTimeCodeByKOT(ViewModel.cboAAType1.Text.Substring(Math.Max(ViewModel.cboAAType1.Text.Length - 3, 0)).TrimEnd()) != 0 )
			{
				if ( PayrollCL.TCfillercode != "" )
				{
					ViewModel.NeedFillerCode = true;
					ViewModel.CurrFillerCode = PayrollCL.TCfillercode;
				}
			}

			//PS Group / Job Code
			ViewModel.sprWeek1.Col = 7;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.cboJobCode1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.cboJobCode1.Text);
			}

			//Level / Step
			ViewModel.sprWeek1.Col = 8;
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.cboStep1.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek1.Text = modGlobal.Clean(ViewModel.cboStep1.Text);
			}
			string ProcessFlag = "";

			//Monday
			ViewModel.sprWeek1.Col = 16;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag))) )
			{
				ViewModel.txtMo1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 9;
			string PayrollDate = Convert.ToString(ViewModel.DateArray[0, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtMo1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtMo1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate2 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate3 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate4 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtMo1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate5 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate6 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate6)) ? TempDate6.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtMo1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtMo1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtMo1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtMo1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate7 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate7)) ? TempDate7.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate8 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate8)) ? TempDate8.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate9 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate9)) ? TempDate9.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}

			//Tuesday
			ViewModel.sprWeek1.Col = 17;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag))) )
			{
				ViewModel.txtTu1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 10;
			PayrollDate = Convert.ToString(ViewModel.DateArray[1, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtTu1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtTu1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate10 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate10)) ? TempDate10.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate11 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate11)) ? TempDate11.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate12 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate12)) ? TempDate12.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate13 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate13)) ? TempDate13.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtTu1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate14 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate14)) ? TempDate14.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate15 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate15)) ? TempDate15.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtTu1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtTu1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtTu1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtTu1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate16 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate16)) ? TempDate16.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate17 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate17)) ? TempDate17.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate18 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate18)) ? TempDate18.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Wednesday
			ViewModel.sprWeek1.Col = 18;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag))) )
			{
				ViewModel.txtWe1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}

			PayrollDate = Convert.ToString(ViewModel.DateArray[2, 0]);
			ViewModel.sprWeek1.Col = 11;
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtWe1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtWe1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate19 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate19)) ? TempDate19.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate20 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate20)) ? TempDate20.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate21 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate21)) ? TempDate21.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate22 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate22)) ? TempDate22.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtWe1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate23 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate23)) ? TempDate23.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate24 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate24)) ? TempDate24.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtWe1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtWe1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtWe1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtWe1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate25 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate25)) ? TempDate25.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate26 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate26)) ? TempDate26.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate27 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate27)) ? TempDate27.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Thursday
			ViewModel.sprWeek1.Col = 19;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag))) )
			{
				ViewModel.txtTh1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 12;
			PayrollDate = Convert.ToString(ViewModel.DateArray[3, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtTh1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtTh1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate28 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate28)) ? TempDate28.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate29 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate29)) ? TempDate29.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate30 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate30)) ? TempDate30.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate31 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate31)) ? TempDate31.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtTh1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate32 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate32)) ? TempDate32.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate33 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate33)) ? TempDate33.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtTh1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtTh1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtTh1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtTh1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate34 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate34)) ? TempDate34.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate35 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate35)) ? TempDate35.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate36 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate36)) ? TempDate36.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Friday
			ViewModel.sprWeek1.Col = 20;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag))) )
			{
				ViewModel.txtFr1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 13;
			PayrollDate = Convert.ToString(ViewModel.DateArray[4, 0]);
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtFr1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtFr1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate37 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate37)) ? TempDate37.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate38 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate38)) ? TempDate38.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate39 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate39)) ? TempDate39.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate40 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate40)) ? TempDate40.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtFr1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate41 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate41)) ? TempDate41.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate42 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate42)) ? TempDate42.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtFr1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtFr1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtFr1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtFr1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate43 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate43)) ? TempDate43.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate44 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate44)) ? TempDate44.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate45 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate45)) ? TempDate45.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}

			//Saturday
			ViewModel.sprWeek1.Col = 21;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag))) )
			{
				ViewModel.txtSa1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 14;
			PayrollDate = Convert.ToString(ViewModel.DateArray[5, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtSa1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtSa1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate46 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate46)) ? TempDate46.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate47 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate47)) ? TempDate47.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate48 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate48)) ? TempDate48.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate49 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate49)) ? TempDate49.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtSa1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate50 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate50)) ? TempDate50.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate51 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate51)) ? TempDate51.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtSa1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtSa1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtSa1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtSa1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate52 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate52)) ? TempDate52.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate53 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate53)) ? TempDate53.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate54 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate54)) ? TempDate54.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}

			//Sunday
			ViewModel.sprWeek1.Col = 22;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag))) )
			{
				ViewModel.txtSu1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 15;
			PayrollDate = Convert.ToString(ViewModel.DateArray[6, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek1.Text) != modGlobal.Clean(ViewModel.txtSu1.Text) || RecordChange || ViewModel.sprWeek1.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtSu1.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate55 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate55)) ? TempDate55.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate56 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate56)) ? TempDate56.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate57 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate57)) ? TempDate57.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate58 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate58)) ? TempDate58.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtSu1.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate59 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate59)) ? TempDate59.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate60 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate60)) ? TempDate60.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity1.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter1.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement1.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder1.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper1.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode1.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep1.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtSu1.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtSu1.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtSu1.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtSu1.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate61 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate61)) ? TempDate61.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate62 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate62)) ? TempDate62.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate63 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate63)) ? TempDate63.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			FillTimeCard();
			FormatTimeCard();
			if ( NeedRefresh )
			{
			//        RefreshEmployeeList
			}

			if ( ViewModel.SelectedRow1 != 0 )
			{
				ViewModel.sprWeek1.Row = 1;
				ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
				ViewModel.sprWeek1.Col = 1;
				ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek1.BlockMode = false;
			}
			if ( ViewModel.SelectedRow2 != 0 )
			{
				ViewModel.sprWeek2.Row = 1;
				ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
				ViewModel.sprWeek2.Col = 1;
				ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek2.BlockMode = false;
			}
			ViewModel.SelectedRow1 = 0;
			ViewModel.SelectedRow2 = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdApply2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsFireUpload PayrollCL = Container.Resolve<clsFireUpload>();
			//string SAPActivityType = ""; //letter + job_code

			string CurrTimeCode = "";

			bool NeedRefresh = false;
			bool RecordChange = false;

			if ( ViewModel.SelectedRow2 == 0 )
			{
				return ;
			}
			if ( modGlobal.Shared.gPayPeriod == 0 )
			{
				ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( !ViewModel.frmBattOpt.Enabled )
			{
				if ( ~EditApply(2) != 0 )
				{
					return ;
				}
			}

			if ( !ViewModel.PayRollExist )
			{
				AddEmployeePayRoll();
			}
			ViewModel.sprWeek2.Row = ViewModel.SelectedRow2;

			PayrollCL.PPcalendar_year = modGlobal.Shared.gPayrollYear;
			PayrollCL.PPpay_period = modGlobal.Shared.gPayPeriod;
			PayrollCL.PPper_sys_id = ViewModel.CurrPersID;

			//Activity
			ViewModel.sprWeek2.Col = 1;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtActivity2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.txtActivity2.Text);
			}

			//Cost Center
			ViewModel.sprWeek2.Col = 2;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtCostCenter2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
			}

			//WBS Element
			ViewModel.sprWeek2.Col = 3;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtWBSElement2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
			}

			//Order
			ViewModel.sprWeek2.Col = 4;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.cboOrder2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.cboOrder2.Text);
			}

			//Operation
			ViewModel.sprWeek2.Col = 5;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtOper2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.txtOper2.Text);
			}

			//A/A Type
			ViewModel.sprWeek2.Col = 6;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != ViewModel.cboAAType2.Text.Substring(0, Math.Min(4, ViewModel.cboAAType2.Text.Length)) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = ViewModel.cboAAType2.Text.Substring(0, Math.Min(4, ViewModel.cboAAType2.Text.Length));
			}

			if ( ViewModel.CurrSAPCode == "" )
			{
				CurrTimeCode = ViewModel.cboAAType2.Text.Substring(0, Math.Min(4, ViewModel.cboAAType2.Text.Length));
			}
			else
			{
				CurrTimeCode = ViewModel.CurrSAPCode;
			}

			if ( modGlobal.Clean(CurrTimeCode) == "" )
			{
				ViewManager.ShowMessage("You must select an A/A Type(KOT)", "Payroll Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( ViewModel.NeedFillerCode )
			{
			//continue... no need to check
			}
			else if ( PayrollCL.GetTimeCodeByKOT(ViewModel.cboAAType2.Text.Substring(Math.Max(ViewModel.cboAAType2.Text.Length - 3, 0)).TrimEnd()) != 0 )
			{
				if ( PayrollCL.TCfillercode != "" )
				{
					ViewModel.NeedFillerCode = true;
					ViewModel.CurrFillerCode = PayrollCL.TCfillercode;
				}
			}

			//PS Group / Job Code
			ViewModel.sprWeek2.Col = 7;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.cboJobCode2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.cboJobCode2.Text);
			}

			//Level / Step
			ViewModel.sprWeek2.Col = 8;
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.cboStep2.Text) )
			{
				RecordChange = true;
				ViewModel.sprWeek2.Text = modGlobal.Clean(ViewModel.cboStep2.Text);
			}
			string ProcessFlag = "";


			//Monday
			ViewModel.sprWeek2.Col = 16;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag))) )
			{
				ViewModel.txtMo2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 9;
			string PayrollDate = Convert.ToString(ViewModel.DateArray[7, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtMo2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtMo2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate2 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate3 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate4 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtMo2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate5 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate6 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate6)) ? TempDate6.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtMo2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtMo2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtMo2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtMo2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate7 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate7)) ? TempDate7.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate8 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate8)) ? TempDate8.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate9 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate9)) ? TempDate9.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Tuesday
			ViewModel.sprWeek2.Col = 17;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag))) )
			{
				ViewModel.txtTu2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 10;
			PayrollDate = Convert.ToString(ViewModel.DateArray[8, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtTu2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtTu2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate10 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate10)) ? TempDate10.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate11 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate11)) ? TempDate11.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate12 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate12)) ? TempDate12.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate13 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate13)) ? TempDate13.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtTu2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate14 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate14)) ? TempDate14.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate15 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate15)) ? TempDate15.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtTu2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtTu2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtTu2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtTu2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate16 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate16)) ? TempDate16.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate17 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate17)) ? TempDate17.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate18 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate18)) ? TempDate18.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Wednesday
			ViewModel.sprWeek2.Col = 18;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag))) )
			{
				ViewModel.txtWe2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}

			PayrollDate = Convert.ToString(ViewModel.DateArray[9, 0]);
			ViewModel.sprWeek2.Col = 11;
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtWe2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtWe2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate19 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate19)) ? TempDate19.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate20 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate20)) ? TempDate20.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate21 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate21)) ? TempDate21.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate22 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate22)) ? TempDate22.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtWe2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate23 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate23)) ? TempDate23.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate24 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate24)) ? TempDate24.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtWe2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtWe2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtWe2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtWe2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate25 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate25)) ? TempDate25.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate26 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate26)) ? TempDate26.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate27 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate27)) ? TempDate27.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Thursday
			ViewModel.sprWeek2.Col = 19;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag))) )
			{
				ViewModel.txtTh2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 12;
			PayrollDate = Convert.ToString(ViewModel.DateArray[10, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtTh2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtTh2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate28 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate28)) ? TempDate28.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate29 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate29)) ? TempDate29.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate30 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate30)) ? TempDate30.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate31 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate31)) ? TempDate31.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtTh2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate32 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate32)) ? TempDate32.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate33 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate33)) ? TempDate33.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtTh2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtTh2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtTh2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtTh2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate34 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate34)) ? TempDate34.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate35 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate35)) ? TempDate35.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate36 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate36)) ? TempDate36.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Friday
			ViewModel.sprWeek2.Col = 20;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag))) )
			{
				ViewModel.txtFr2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 13;
			PayrollDate = Convert.ToString(ViewModel.DateArray[11, 0]);
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtFr2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtFr2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate37 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate37)) ? TempDate37.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate38 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate38)) ? TempDate38.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate39 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate39)) ? TempDate39.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate40 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate40)) ? TempDate40.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtFr2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate41 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate41)) ? TempDate41.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate42 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate42)) ? TempDate42.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtFr2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtFr2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtFr2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtFr2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate43 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate43)) ? TempDate43.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate44 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate44)) ? TempDate44.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate45 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate45)) ? TempDate45.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Saturday
			ViewModel.sprWeek2.Col = 21;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag))) )
			{
				ViewModel.txtSa2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 14;
			PayrollDate = Convert.ToString(ViewModel.DateArray[12, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtSa2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtSa2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate46 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate46)) ? TempDate46.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate47 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate47)) ? TempDate47.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate48 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate48)) ? TempDate48.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate49 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate49)) ? TempDate49.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtSa2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate50 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate50)) ? TempDate50.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate51 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate51)) ? TempDate51.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtSa2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtSa2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtSa2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtSa2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate52 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate52)) ? TempDate52.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate53 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate53)) ? TempDate53.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate54 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate54)) ? TempDate54.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			//Sunday
			ViewModel.sprWeek2.Col = 22;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag))) )
			{
				ViewModel.txtSu2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 15;
			PayrollDate = Convert.ToString(ViewModel.DateArray[13, 0]);
			//if there has been any kind of change...
			if ( modGlobal.Clean(ViewModel.sprWeek2.Text) != modGlobal.Clean(ViewModel.txtSu2.Text) || RecordChange || ViewModel.sprWeek2.ForeColor.Equals(modGlobal.Shared.BLUE) )
			{
				PayrollCL.PPpayroll_date = PayrollDate;
				if ( PayrollCL.GetPersonnelPayrollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
				{
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( Double.Parse(ViewModel.txtSu2.Text) == 0 )
					{ //delete logic...
						//If it was uploaded to SAP
						if ( PayrollCL.PPpayroll_status_code == "S" )
						{
							PayrollCL.PPhours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
							{
								//Successful
								if ( ViewModel.NeedFillerCode )
								{
									if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag))), ViewModel.CurrFillerCode) != 0 )
									{
										PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
										PayrollCL.PPhours = 0;
										PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
										PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
										PayrollCL.PPpayroll_status_code = ProcessFlag;
										if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
										{
										//successful
										}
										else
										{
											//error
											System
												.DateTime TempDate55 = DateTime.FromOADate(0);
											ViewManager.ShowMessage("Attempt to Update Associated Record for Deletion.", "Update Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
												out TempDate55)) ? TempDate55.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
										}
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate56 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate56)) ? TempDate56.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							if ( ViewModel.NeedFillerCode )
							{
								if ( PayrollCL.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag))), ViewModel.CurrFillerCode) != 0 )
								{
									//MAY NEED TO ADD LOGIC IF THIS HAD BEEN UPLOADED TO SAP WITHOUT ORIGINAL RECORD ??
									if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(PayrollCL.PPFillerCodeID))) != 0 )
									{
										//successful
										NeedRefresh = true;
									}
									else
									{
										//error
										System
											.DateTime TempDate57 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Attempt to Delete Associated Record Failed.", "Delete Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate57)) ? TempDate57.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
							{
								//Successful
								NeedRefresh = true;
							}
							else
							{
								//error
								System
									.DateTime TempDate58 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate58)) ? TempDate58.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
					}
					else if ( Double.Parse(ViewModel.txtSu2.Text) > 0 )
					{ //update logic
						//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
						PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
						PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
						{
						//Successful
						}
						else
						{
							//error
							System
								.DateTime TempDate59 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate59)) ? TempDate59.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
					else
					{
						//error
						System
							.DateTime TempDate60 = DateTime.FromOADate(0);
						ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
							out TempDate60)) ? TempDate60.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					}
				}
				else
				{
					//insert logic
					PayrollCL.PPsap_acttype = modGlobal.Clean(ViewModel.txtActivity2.Text).ToUpper();
					PayrollCL.PPsap_rec_center = modGlobal.Clean(ViewModel.txtCostCenter2.Text);
					PayrollCL.PPwbs_element = modGlobal.Clean(ViewModel.txtWBSElement2.Text);
					PayrollCL.PPsap_rec_order = modGlobal.Clean(ViewModel.cboOrder2.Text);
					PayrollCL.PPsap_activity = modGlobal.Clean(ViewModel.txtOper2.Text);
					PayrollCL.PPa_a_type = CurrTimeCode;
					PayrollCL.PPexception_job_code = modGlobal.Clean(ViewModel.cboJobCode2.Text);
					PayrollCL.PPexception_step = modGlobal.Clean(ViewModel.cboStep2.Text);
					ProcessFlag = "N";
					if ( modGlobal.Clean(ViewModel.txtSu2.Text) != "" )
					{
						if ( Double.Parse(ViewModel.txtSu2.Text) > 0 )
						{ //insert logic...
							if ( ViewModel.NeedFillerCode )
							{
								PayrollCL.PPhours = Math.Round((double)((Double.Parse(ViewModel.txtSu2.Text) / 3) * 2), 2);
							}
							else
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
							}
							PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							if ( PayrollCL.InsertPersonnelPayroll() != 0 )
							{
								//successful
								if ( ViewModel.NeedFillerCode )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtSu2.Text) / 3), 2);
									PayrollCL.PPa_a_type = ViewModel.CurrFillerCode;
									PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
									PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
									PayrollCL.PPpayroll_status_code = ProcessFlag;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//SUCCESSFUL
									}
									else
									{
										//error
										System
											.DateTime TempDate61 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed for Associated Record!!", "Insert Personnel Associated Payroll for " + ((DateTime.TryParse(PayrollDate,
											out TempDate61)) ? TempDate61.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate62 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
									TempDate62)) ? TempDate62.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate63 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate63)) ? TempDate63.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
						}
					}
				}
			}


			FillTimeCard();
			FormatTimeCard();
			if ( NeedRefresh )
			{
			//        RefreshEmployeeList
			}

			if ( ViewModel.SelectedRow1 != 0 )
			{
				ViewModel.sprWeek1.Row = 1;
				ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
				ViewModel.sprWeek1.Col = 1;
				ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek1.BlockMode = false;
			}
			if ( ViewModel.SelectedRow2 != 0 )
			{
				ViewModel.sprWeek2.Row = 1;
				ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
				ViewModel.sprWeek2.Col = 1;
				ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek2.BlockMode = false;
			}
			ViewModel.SelectedRow1 = 0;
			ViewModel.SelectedRow2 = 0;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ClearFields();
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdOKToPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				PTSProject.clsFireUpload clPayroll = Container.Resolve<clsFireUpload>();

				if ( modGlobal.Shared.gPayPeriod == 0 )
				{
					ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				//    MsgBox "This option is under construction", vbOKOnly, "OK To Pay"
				if ( clPayroll.AddPayRollTransferForPayperiod(modPTSPayroll.Shared.gUserSAPid, modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0 )
				{
					modPTSPayroll.UploadToSAP();
				}

				modPTSPayroll.Shared.gPayPeriodReportFlag = false;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgPayrollUpload.DefInstance, true);
					});
			}


		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( modGlobal.Shared.gPayPeriod == 0 )
			{
				ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( ViewModel.chkAll.CheckState == UpgradeHelpers.Helpers.CheckState.Checked )
			{
				PrintAllTimeCards();
				return ;
			}

			//    MsgBox "This option is under construction", vbOKOnly, "Print Individual Time Card(s)"
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTimeSheet.setPrintAbortMsg("Printing Individual Time Card - Click Cancel to quit");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTimeSheet.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTimeSheet.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprTimeSheet.PrintMarginLeft was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprTimeSheet.setPrintMarginLeft(360);
            //    sprTimeSheet.PrintOrientation = 2
            ViewModel.sprTimeSheet.PrintSheet(null);
            //ViewModel.sprTimeSheet.Action = (FarPoint.ViewModels.FPActionConstants)32;
        }

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrintList_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This option is under construction", vbOKOnly, "Print Employee Grid List"
			//Print Employee Grid List
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintSmartPrint(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprEmployeeList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprEmployeeList.setPrintAbortMsg("Printing Employee Grid List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprEmployeeList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprEmployeeList.PrintSheet(null);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				if ( modGlobal.Shared.gPayPeriod == 0 )
				{
					ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				modPTSPayroll.Shared.gPayPeriodReportFlag = true;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgPayrollUpload.DefInstance, true);
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This option is under construction", vbOKOnly, "Save Time Card"
			if ( modGlobal.Shared.gPayPeriod == 0 )
			{
				ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			AddEmployeePayRoll();
			FillTimeCard();
			FormatTimeCard();
		//    RefreshEmployeeList

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdUploadALL_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//        MsgBox "This option is under construction", vbOKOnly, "Upload All for Pay Period"
				if ( modGlobal.Shared.gPayPeriod == 0 )
				{
					ViewManager.ShowMessage("Please select a Pay Period first.", "No Pay Period Selected", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				PTSProject.clsFireUpload clPayroll = Container.Resolve<clsFireUpload>();

				if ( clPayroll.UpdatePersonnelPayrollForUpload(modGlobal.Shared.gPayPeriod, modGlobal.Shared.gPayrollYear, modGlobal.Shared.gUser) != 0 )
				{


				}

				//    MsgBox "This option is under construction", vbOKOnly, "OK To Pay"
				if ( clPayroll.AddPayRollTransferForPayperiod(modPTSPayroll.Shared.gUserSAPid, modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0 )
				{
					modPTSPayroll.UploadToSAP();
				}

				modPTSPayroll.Shared.gPayPeriodReportFlag = false;
				async1.Append(() =>
					{
						ViewManager.NavigateToView(
							dlgPayrollUpload.DefInstance, true);
					});
			}

		}



		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//string strName = "";
			bool DoThis = false;
			ViewModel.FirstTime = true;
			ClearFields();
			ViewModel.LimitedAccess = false;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			modGlobal.Shared.gPayrollYear = modGlobal.Shared.gCurrentYear;

			oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + DateTime.Now.ToString("M/d/yyyy") + "' ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
			}

			if ( modGlobal.Shared.gPayrollYear > 2005 )
			{
				modGlobal.Shared.gMaxhoursOp = 92.2f;
			}
			else
			{
				modGlobal.Shared.gMaxhoursOp = 93.2f;
			}
			modGlobal.Shared.gMaxhoursFCC = 80;

			DoThis = !(modGlobal.Shared.gPayPeriod > 0);


			oCmd.CommandText = "sp_GetYearList ";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Initialize Year Combobox
			ViewModel.cboYear.Items.Clear();

			while ( !oRec.EOF )
			{
				ViewModel.cboYear.AddItem(Convert.ToString(oRec["cal_year"]).Trim());
				oRec.MoveNext();
			};
			ViewModel.cboYear.Text = modGlobal.Shared.gPayrollYear.ToString();
			ViewModel.cboPayPeriod.Items.Clear();
			oCmd.CommandText = "sp_GetPayRollPeriods " + modGlobal.Shared.gPayrollYear.ToString();
			oRec = ADORecordSetHelper.Open(oCmd, "");

			while ( !oRec.EOF )
			{
				ViewModel.cboPayPeriod.AddItem(Convert.ToString(oRec["start_date"]) + " - " + Convert.ToString(oRec["end_date"]));
				ViewModel.cboPayPeriod.SetItemData(ViewModel.cboPayPeriod.GetNewIndex(), Convert.ToInt32(oRec["pay_period"]));
				if ( (((int)DateAndTime.DateDiff("d", Convert.ToDateTime(oRec["start_date"]), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0) && DoThis )
				{
					modGlobal.Shared.gPayPeriod = Convert.ToInt32(oRec["pay_period"]);
				}
				oRec.MoveNext();
			};
			ViewModel.CurrEmpID = "";
			ViewModel.CurrPersID = 0;
			ViewModel.CurrStartDate = "";
			ViewModel.CurrEndDate = "";
			ViewModel.CurrShift = "";

			if ( modGlobal.Clean(modGlobal.Shared.gPayRollBatt) != "" )
			{
				if ( modGlobal.Shared.gPayRollBatt == "1" )
				{
					ViewModel.CurrBatt = "1";
					ViewModel.opt181.Checked = true;
					ViewModel.optAll.Checked = false;
					ViewModel.opt182.Checked = false;
					ViewModel.opt183.Checked = false;
				}
				else if ( modGlobal.Shared.gPayRollBatt == "3" )
				{
					ViewModel.CurrBatt = "3";
					ViewModel.opt183.Checked = true;
					ViewModel.optAll.Checked = false;
					ViewModel.opt182.Checked = false;
					ViewModel.opt181.Checked = false;
				}
				else
				{
					ViewModel.CurrBatt = "2";
					ViewModel.opt182.Checked = true;
					ViewModel.optAll.Checked = false;
					ViewModel.opt181.Checked = false;
					ViewModel.opt183.Checked = false;
				}
				ViewModel.CurrPayPeriod = modGlobal.Shared.gPayPeriod;
				ViewModel.frmBattOpt.Enabled = false;
			}
			else
			{
				//        CurrPayPeriod = 0
				ViewModel.CurrBatt = "";
			}

			if ( modGlobal.Shared.gPayPeriod > 0 )
			{
				for ( int i = 0; i <= ViewModel.cboPayPeriod.Items.Count - 1; i++ )
				{
					if ( ViewModel.cboPayPeriod.GetItemData(i) == modGlobal.Shared.gPayPeriod )
					{
						oCmd.CommandText = "sp_GetPPDates " + modGlobal.Shared.gPayPeriod.ToString() + "," + modGlobal.Shared.gPayrollYear.ToString();
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
							ViewModel.CurrStartDate = Convert.ToDateTime(oRec["start_date"]).ToString("M/d/yyyy");
							ViewModel.CurrEndDate = Convert.ToDateTime(oRec["end_date"]).AddDays(1).ToString("M/d/yyyy");
							LoadDateArray();
							ViewModel.cboPayPeriod.SelectedIndex = i;
							break;
						}
					}
				}
			}
			FillLists();
			LoadLists();
			ViewModel.FirstTime = false;
			ViewModel.cmdSave.Enabled = false;
			ViewModel.cmdPrint.Enabled = false;
			ViewModel.cmdUploadALL.Enabled = false;

			if ( modGlobal.Shared.gSecurity == "PER" )
			{
			//        If gUserLogon <> "PDUNDAS" And gUserLogon <> "LDAY" And gUserLogon <> "YCHISA" _
			//'        And gUserLogon <> "MWALTER" And gUserLogon <> "PBUCHANA" _
			//'        And gUserLogon <> "JSTILL" Then
			//            LimitedAccess = True
			//        Else
			//            cmdUploadALL.Enabled = True
			//        End If
			}
			else if ( modGlobal.Shared.gSecurity == "ADM" )
			{
				ViewModel.cmdUploadALL.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void opt181_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "1";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt182_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "2";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void opt183_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrBatt = "3";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optA_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "A";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optAll_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				if ( ViewModel.FirstTime )
				{
					return ;
				}
				if ( ViewModel.optAll.Checked )
				{
					ViewModel.CurrBatt = "";
					ViewModel.CurrShift = "";
					ViewModel.optA.Checked = false;
					ViewModel.optB.Checked = false;
					ViewModel.optC.Checked = false;
					ViewModel.optD.Checked = false;
					RefreshEmployeeList();
				}
			//    RefreshEmployeeList

			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optB_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "B";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optC_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "C";
				RefreshEmployeeList();
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void optD_CheckedChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ((UpgradeHelpers.BasicViewModels.RadioButtonViewModel)eventSender).Checked )
			{
				if ( ViewModel.isInitializingComponent )
				{
					return ;
				}
				ViewModel.CurrShift = "D";
				RefreshEmployeeList();
			}
		}

		private void sprEmployeeList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//Select clicked row
			//Exit if Headers clicked for sort
			if ( Row == 0 )
			{
				return ;
			}


			//change
			// clear the previous selection
			if ( ViewModel.SelectedRow != 0 )
			{
				ViewModel.sprEmployeeList.Row = ViewModel.SelectedRow;
				ViewModel.sprEmployeeList.Row2 = ViewModel.SelectedRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
				ViewModel.sprEmployeeList.BlockMode = true;
				ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprEmployeeList.BlockMode = false;
			}

			// clear timecard selections and close editing frames
			if ( ViewModel.SelectedRow1 != 0 )
			{
				ViewModel.sprWeek1.Row = 1;
				ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
				ViewModel.sprWeek1.Col = 1;
				ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek1.BlockMode = false;
				ViewModel.frmWeek1.Visible = false;
			}
			if ( ViewModel.SelectedRow2 != 0 )
			{
				ViewModel.sprWeek2.Row = 1;
				ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
				ViewModel.sprWeek2.Col = 1;
				ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek2.BlockMode = false;
				ViewModel.frmWeek2.Visible = false;
			}
			ViewModel.SelectedRow = 0;
			int CurrRow = Row;
			int CurrCol = Col;
			ViewModel.sprEmployeeList.Row = CurrRow;
			ViewModel.sprEmployeeList.Col = 2;
			//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			ViewModel.CurrEmpID = Convert.ToString(modGlobal.GetVal(ViewModel.sprEmployeeList.Text));

			if ( modGlobal.Clean(ViewModel.cboPayPeriod.Text) == "" )
			{
				ViewManager.ShowMessage("Please select a Pay Period", "Personnel Tracking System", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewManager.SetCurrent(ViewModel.cboPayPeriod);
				return ;
			}
			ViewModel.SelectedRow = CurrRow;
			FillTimeCard();
			FormatTimeCard();

			if ( ViewModel.frmBattOpt.Enabled )
			{
				ViewModel.cmdPrint.Enabled = true;
			}
			else
			{
				ViewModel.cmdPrint.Enabled = !(modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod);
			}

			//change
			if ( ViewModel.SelectedRow != 0 )
			{
				//    set the backcolor for new selection
				ViewModel.sprEmployeeList.Row = ViewModel.SelectedRow;
				ViewModel.sprEmployeeList.Row2 = ViewModel.SelectedRow;
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.Col2 = ViewModel.sprEmployeeList.MaxCols;
				ViewModel.sprEmployeeList.BlockMode = true;
				ViewModel.sprEmployeeList.BackColor = modGlobal.Shared.YELLOW;
				ViewModel.sprEmployeeList.BlockMode = false;
			//        sprEmployeeList.SetSelection 1, SelectedRow, sprEmployeeList.MaxCols, SelectedRow
			}

		}


		private void sprWeek1_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if ( Row == 0 )
			{
				ViewModel.frmWeek1.Visible = false;
				return ;
			}


			if ( ViewModel.SelectedRow1 != 0 )
			{
				ViewModel.sprWeek1.Row = 1;
				ViewModel.sprWeek1.Row2 = ViewModel.sprWeek1.MaxRows;
				ViewModel.sprWeek1.Col = 1;
				ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek1.BlockMode = false;
			}
			ViewModel.SelectedRow1 = 0;
			int CurrRow = Row;
			int CurrCol = Col;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek1.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek1.ClearSelection();
			ViewModel.sprWeek1.Row = CurrRow;
			ViewModel.sprWeek1.Col = 5;
			if ( ViewModel.sprWeek1.Text == "Schedule" )
			{
				ViewModel.frmWeek1.Visible = false;
				return ;
			}
			else if ( !ViewModel.frmBattOpt.Enabled && modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
			{
				ViewModel.frmWeek1.Visible = false;
				return ;
			}
			else
			{
				for ( int i = 1; i <= 15; i++ )
				{
					ViewModel.sprWeek1.Col = i;
					switch ( i )
					{
						case 1:
							ViewModel.txtActivity1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 2:
							ViewModel.txtCostCenter1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 3:
							ViewModel.txtWBSElement1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 4:
							ViewModel.cboOrder1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 5:
							ViewModel.txtOper1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 6:
							for ( int x = 0; x <= ViewModel.cboAAType1.Items.Count - 1; x++ )
							{
								if ( ViewModel.cboAAType1.GetListItem(x).StartsWith(modGlobal.Clean(ViewModel.sprWeek1.Text)) )
								{
									ViewModel.cboAAType1.SelectedIndex = x;
									if ( ViewModel.cboAAType1.Text.Substring(Math.Max(ViewModel.cboAAType1.Text.Length - 3, 0)) == ViewModel.txtOper1.Text )
									{
										ViewModel.txtOper1.Text = "";
									}
									break;
								}
							}
							break;
						case 7:
							ViewModel.cboJobCode1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							if ( ViewModel.cboJobCode1.Text != "" )
							{
								if ( FillStepList(1, modGlobal.Clean(ViewModel.cboJobCode1.Text)) )
								{
									return ;
								}
							}
							break;
						case 8:
							ViewModel.cboStep1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							if ( ViewModel.cboJobCode1.Text != "" && ViewModel.cboStep1.Text == "" )
							{
								ViewModel.cboStep1.Text = "1";
							}
							//                    cboStep1.AddItem Clean(sprWeek1.Text) 
							//                    cboStep1.ListIndex = 0 
							break;
						case 9:
							ViewModel.txtMo1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 16;
							ViewModel.txtMo1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 10:
							ViewModel.txtTu1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 17;
							ViewModel.txtTu1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 11:
							ViewModel.txtWe1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 18;
							ViewModel.txtWe1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 12:
							ViewModel.txtTh1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 19;
							ViewModel.txtTh1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 13:
							ViewModel.txtFr1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 20;
							ViewModel.txtFr1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						case 14:
							ViewModel.txtSa1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 21;
							ViewModel.txtSa1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
						default: //15 

							ViewModel.txtSu1.Text = modGlobal.Clean(ViewModel.sprWeek1.Text);
							ViewModel.sprWeek1.Col = 22;
							ViewModel.txtSu1.Tag = modGlobal.Clean(ViewModel.sprWeek1.Text);
							break;
					}
				}

			}
			ViewModel.SelectedRow1 = CurrRow;
			//change
			// set background color for new selection
			if ( ViewModel.SelectedRow1 != 0 )
			{
				ViewModel.sprWeek1.Row = ViewModel.SelectedRow1;
				ViewModel.sprWeek1.Row2 = ViewModel.SelectedRow1;
				ViewModel.sprWeek1.Col = 1;
				ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprWeek1.BlockMode = false;
			}
			//    sprWeek1.SetSelection 1, CurrRow, sprWeek1.MaxCols, CurrRow
			ViewModel.frmWeek1.Visible = true;
		}

		private void sprWeek2_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if ( Row == 0 )
			{
				ViewModel.frmWeek2.Visible = false;
				return ;
			}


			if ( ViewModel.SelectedRow2 != 0 )
			{
				ViewModel.sprWeek2.Row = 1;
				ViewModel.sprWeek2.Row2 = ViewModel.sprWeek2.MaxRows;
				ViewModel.sprWeek2.Col = 1;
				ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.BackColor = modGlobal.Shared.WHITE;
				ViewModel.sprWeek2.BlockMode = false;
			}
			ViewModel.SelectedRow2 = 0;
			int CurrRow = Row;
			int CurrCol = Col;
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprWeek2.ClearSelection was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprWeek2.ClearSelection();
			ViewModel.sprWeek2.Row = CurrRow;
			ViewModel.sprWeek2.Col = 5;
			if ( ViewModel.sprWeek2.Text == "Schedule" )
			{
				ViewModel.frmWeek2.Visible = false;
				return ;
			}
			else if ( !ViewModel.frmBattOpt.Enabled && modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
			{
				ViewModel.frmWeek2.Visible = false;
				return ;
			}
			else
			{
				for ( int i = 1; i <= 15; i++ )
				{
					ViewModel.sprWeek2.Col = i;
					switch ( i )
					{
						case 1:
							ViewModel.txtActivity2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 2:
							ViewModel.txtCostCenter2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 3:
							ViewModel.txtWBSElement2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 4:
							ViewModel.cboOrder2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 5:
							ViewModel.txtOper2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 6:
							for ( int x = 0; x <= ViewModel.cboAAType2.Items.Count - 1; x++ )
							{
								if ( ViewModel.cboAAType2.GetListItem(x).StartsWith(modGlobal.Clean(ViewModel.sprWeek2.Text)) )
								{
									ViewModel.cboAAType2.SelectedIndex = x;
									if ( ViewModel.cboAAType2.Text.Substring(Math.Max(ViewModel.cboAAType2.Text.Length - 3, 0)) == ViewModel.txtOper2.Text )
									{
										ViewModel.txtOper2.Text = "";
									}
									break;
								}
							}
							break;
						case 7:
							ViewModel.cboJobCode2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							if ( ViewModel.cboJobCode2.Text != "" )
							{
								if ( FillStepList(2, modGlobal.Clean(ViewModel.cboJobCode2.Text)) )
								{
									return ;
								}
							}
							break;
						case 8:
							ViewModel.cboStep2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							if ( ViewModel.cboJobCode2.Text != "" && ViewModel.cboStep2.Text == "" )
							{
								ViewModel.cboStep2.Text = "1";
							}
							//                    cboStep2.AddItem Clean(sprWeek2.Text) 
							//                    cboStep2.ListIndex = 0 
							break;
						case 9:
							ViewModel.txtMo2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 16;
							ViewModel.txtMo2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 10:
							ViewModel.txtTu2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 17;
							ViewModel.txtTu2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 11:
							ViewModel.txtWe2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 18;
							ViewModel.txtWe2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 12:
							ViewModel.txtTh2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 19;
							ViewModel.txtTh2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 13:
							ViewModel.txtFr2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 20;
							ViewModel.txtFr2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						case 14:
							ViewModel.txtSa2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 21;
							ViewModel.txtSa2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
						default: //15 

							ViewModel.txtSu2.Text = modGlobal.Clean(ViewModel.sprWeek2.Text);
							ViewModel.sprWeek2.Col = 22;
							ViewModel.txtSu2.Tag = modGlobal.Clean(ViewModel.sprWeek2.Text);
							break;
					}
				}

			}
			ViewModel.SelectedRow2 = CurrRow;
			//change
			// set background color for new selection
			if ( ViewModel.SelectedRow2 != 0 )
			{
				ViewModel.sprWeek2.Row = ViewModel.SelectedRow2;
				ViewModel.sprWeek2.Row2 = ViewModel.SelectedRow2;
				ViewModel.sprWeek2.Col = 1;
				ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.BackColor = UpgradeHelpers.Helpers.ColorTranslator.FromOle(modGlobal.LT_BLUE);
				ViewModel.sprWeek2.BlockMode = false;
			}
			//    sprWeek2.SetSelection 1, CurrRow, sprWeek2.MaxCols, CurrRow
			ViewModel.frmWeek2.Visible = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime )
			{
				return ;
			}
			RefreshEmployeeList();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAAType1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;

			if ( ViewModel.cboAAType1.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			ViewModel.NeedAdjustment = false;
			ViewModel.NeedFillerCode = false;
			ViewModel.SetLimit = false;
			ViewModel.OverAmount = 0;
			ViewModel.UnderAmount = 0;
			ViewModel.SchedTime = "";
			ViewModel.CurrSAPCode = "";
			ViewModel.CurrFillerCode = "";
			ViewModel.CurrLeaveTotal = 0;
			ViewModel.SchedTime = ViewModel.cboAAType1.Text.Substring(Math.Max(ViewModel.cboAAType1.Text.Length - 3, 0));
			ViewModel.CurrSAPCode = ViewModel.cboAAType1.Text.Substring(0, Math.Min(4, ViewModel.cboAAType1.Text.Length));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_TimeCode " + ViewModel.cboAAType1.GetItemData(ViewModel.cboAAType1.SelectedIndex).ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				//        SchedTime = Clean(orec("time_code_id"])
				//        CurrSAPCode = Clean(orec("a_a_type"])
				if ( modGlobal.Clean(oRec["filler_code"]) != "" )
				{
					//Make Change Here  FCC = TFC
					if ( ViewModel.CurrUnit != "FCC" )
					{
						ViewModel.NeedFillerCode = true;
						ViewModel.CurrFillerCode = modGlobal.Clean(oRec["filler_code"]);
					}
					else
					{
						ViewModel.NeedFillerCode = false;
						ViewModel.CurrFillerCode = "";
					}
				}
				else
				{
					ViewModel.NeedFillerCode = false;
					ViewModel.CurrFillerCode = "";
				}
				if ( modGlobal.Clean(oRec["pension_limit"]) != "" )
				{
					ocmd2.CommandText = "spSelect_EmployeePensionLimitPPTotal '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "','" + ViewModel.CurrSAPCode + "' ";
					orec2 = ADORecordSetHelper.Open(ocmd2, "");
					if ( !orec2.EOF )
					{
						ViewModel.CurrLeaveTotal = Convert.ToSingle(orec2["LeaveTotal"]);
						ViewModel.SetLimit = true;
						if ( ViewModel.CurrLeaveTotal > modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.OverAmount = ViewModel.CurrLeaveTotal - modGlobal.Shared.gMaxhoursOp;
							ViewModel.UnderAmount = 0;
						}
						else if ( ViewModel.CurrLeaveTotal < modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.UnderAmount = modGlobal.Shared.gMaxhoursOp - ViewModel.CurrLeaveTotal;
							ViewModel.OverAmount = 0;
						}
						else
						{
							ViewModel.SetLimit = false;
							ViewModel.OverAmount = 0;
							ViewModel.UnderAmount = 0;
						}
					}
					else
					{
						ViewModel.SetLimit = false;
						ViewModel.OverAmount = 0;
						ViewModel.UnderAmount = 0;
					}
				}
				else
				{
					ViewModel.SetLimit = false;
					ViewModel.OverAmount = 0;
					ViewModel.UnderAmount = 0;
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAAType2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec2 = null;

			if ( ViewModel.cboAAType2.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			ViewModel.NeedAdjustment = false;
			ViewModel.NeedFillerCode = false;
			ViewModel.SetLimit = false;
			ViewModel.OverAmount = 0;
			ViewModel.UnderAmount = 0;
			ViewModel.SchedTime = "";
			ViewModel.CurrSAPCode = "";
			ViewModel.CurrFillerCode = "";
			ViewModel.CurrLeaveTotal = 0;
			ViewModel.SchedTime = ViewModel.cboAAType2.Text.Substring(Math.Max(ViewModel.cboAAType2.Text.Length - 3, 0));
			ViewModel.CurrSAPCode = ViewModel.cboAAType2.Text.Substring(0, Math.Min(4, ViewModel.cboAAType2.Text.Length));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			ocmd2.Connection = modGlobal.oConn;
			ocmd2.CommandType = CommandType.Text;

			oCmd.CommandText = "spSelect_TimeCode " + ViewModel.cboAAType2.GetItemData(ViewModel.cboAAType2.SelectedIndex).ToString() + " ";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				//        SchedTime = Clean(orec("time_code_id"])
				//        CurrSAPCode = Clean(orec("a_a_type"])
				if ( modGlobal.Clean(oRec["filler_code"]) != "" )
				{
					//Make Change Here  FCC = TFC
					if ( ViewModel.CurrUnit != "FCC" )
					{
						ViewModel.NeedFillerCode = true;
						ViewModel.CurrFillerCode = modGlobal.Clean(oRec["filler_code"]);
					}
					else
					{
						ViewModel.NeedFillerCode = false;
						ViewModel.CurrFillerCode = "";
					}
				}
				else
				{
					ViewModel.NeedFillerCode = false;
					ViewModel.CurrFillerCode = "";
				}
				if ( modGlobal.Clean(oRec["pension_limit"]) != "" )
				{
					ocmd2.CommandText = "spSelect_EmployeePensionLimitPPTotal '" + ViewModel.CurrEmpID + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "','" + ViewModel.CurrSAPCode + "' ";
					orec2 = ADORecordSetHelper.Open(ocmd2, "");
					if ( !orec2.EOF )
					{
						ViewModel.CurrLeaveTotal = Convert.ToSingle(orec2["LeaveTotal"]);
						ViewModel.SetLimit = true;
						if ( ViewModel.CurrLeaveTotal > modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.OverAmount = ViewModel.CurrLeaveTotal - modGlobal.Shared.gMaxhoursOp;
							ViewModel.UnderAmount = 0;
						}
						else if ( ViewModel.CurrLeaveTotal < modGlobal.Shared.gMaxhoursOp )
						{
							ViewModel.UnderAmount = modGlobal.Shared.gMaxhoursOp - ViewModel.CurrLeaveTotal;
							ViewModel.OverAmount = 0;
						}
						else
						{
							ViewModel.SetLimit = false;
							ViewModel.OverAmount = 0;
							ViewModel.UnderAmount = 0;
						}
					}
					else
					{
						ViewModel.SetLimit = false;
						ViewModel.OverAmount = 0;
						ViewModel.UnderAmount = 0;
					}
				}
				else
				{
					ViewModel.SetLimit = false;
					ViewModel.OverAmount = 0;
					ViewModel.UnderAmount = 0;
				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPayroll DefInstance
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

		public static frmPayroll CreateInstance()
		{
			PTSProject.frmPayroll theInstance = Shared.Container.Resolve<frmPayroll>();
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
			ViewModel.frmFilterList.LifeCycleStartup();
			ViewModel.frmBattOpt.LifeCycleStartup();
			ViewModel.sprTimeSheet.LifeCycleStartup();
			ViewModel.sprWeek2.LifeCycleStartup();
			ViewModel.sprWeek1.LifeCycleStartup();
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.frmWeek1.LifeCycleStartup();
			ViewModel.frmWeek2.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frmFilterList.LifeCycleShutdown();
			ViewModel.frmBattOpt.LifeCycleShutdown();
			ViewModel.sprTimeSheet.LifeCycleShutdown();
			ViewModel.sprWeek2.LifeCycleShutdown();
			ViewModel.sprWeek1.LifeCycleShutdown();
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.frmWeek1.LifeCycleShutdown();
			ViewModel.frmWeek2.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPayroll
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPayroll m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}