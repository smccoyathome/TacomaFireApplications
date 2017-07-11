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

	public partial class frmPayrollOthers
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollOthersViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPayrollOthers));
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


		private void frmPayrollOthers_Activated(System.Object eventSender, System.EventArgs eventArgs)
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

		public void PrepareReportDate()
		{

			ViewModel.sprWeek1.Row = 0;
			ViewModel.sprWeek1.Row2 = 0;
			ViewModel.sprWeek1.Col = 1;
			ViewModel.sprWeek1.Col2 = ViewModel.sprWeek1.MaxCols;
			ViewModel.sprWeek1.BlockMode = true;
			ViewModel.sprWeek1.FontBold = false;
			ViewModel.sprWeek1.BlockMode = false;
			ViewModel.sprWeek2.Row = 0;
			ViewModel.sprWeek2.Row2 = 0;
			ViewModel.sprWeek2.Col = 1;
			ViewModel.sprWeek2.Col2 = ViewModel.sprWeek2.MaxCols;
			ViewModel.sprWeek2.BlockMode = true;
			ViewModel.sprWeek2.FontBold = false;
			ViewModel.sprWeek2.BlockMode = false;

			int ColNumber = 0;
			int WhichWeek = 0;
			for ( int i = 0; i <= 13; i++ )
			{
				if ( ViewModel.ReportDate == Convert.ToString(ViewModel.DateArray[i, 0]) )
				{
					if ( Convert.ToDouble(ViewModel.DateArray[i, 2]) == 0 )
					{
						WhichWeek = 1;
						ColNumber = Convert.ToInt32(ViewModel.DateArray[i, 1]);
					}
					else
					{
						WhichWeek = 2;
						ColNumber = Convert.ToInt32(ViewModel.DateArray[i, 1]);
					}
					break;
				}
			}

			if ( ColNumber == 0 )
			{
				WhichWeek = 0;
			}

			if ( WhichWeek == 1 )
			{
				ViewModel.sprWeek1.Row = 0;
				ViewModel.sprWeek1.Row2 = 0;
				ViewModel.sprWeek1.Col = ColNumber;
				ViewModel.sprWeek1.Col2 = ColNumber;
				ViewModel.sprWeek1.BlockMode = true;
				ViewModel.sprWeek1.FontBold = true;
				ViewModel.sprWeek1.BlockMode = false;
			}
			else if ( WhichWeek == 2 )
			{
				ViewModel.sprWeek2.Row = 0;
				ViewModel.sprWeek2.Row2 = 0;
				ViewModel.sprWeek2.Col = ColNumber;
				ViewModel.sprWeek2.Col2 = ColNumber;
				ViewModel.sprWeek2.BlockMode = true;
				ViewModel.sprWeek2.FontBold = true;
				ViewModel.sprWeek2.BlockMode = false;
			}

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

			oCmd.CommandText = "spOtherJobCodeList";
			oRec = ADORecordSetHelper.Open(oCmd, "");

			//Load Job Code lists

			while ( !oRec.EOF )
			{
				ViewModel.cboJobCode1.AddItem(Convert.ToString(oRec["job_code_id"]));
				ViewModel.cboJobCode2.AddItem(Convert.ToString(oRec["job_code_id"]));
				oRec.MoveNext();
			};

			//Schedule Time Codes
			oCmd.CommandText = "spSelect_OtherTimeCodes ";
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
		//    Dim cWorkOrder As New clsFireUpload
		//    Dim i As Integer
		//    Dim x As Integer
		//    Dim PayrollDate As String
		//    Dim SAPActivityType As String 'letter + job_code
		//    Dim sActivity As String, sCostCenter As String
		//    Dim sWBSElement As String, sOrder As String
		//    Dim sAAType As String, sJobCode As String
		//    Dim sStep As String
		//    Dim sOTHours As Double
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    'Murray Morgan WO Logic will go in this procedure
		//
		//    PayrollCL.PPcalendar_year = gPayrollYear
		//    PayrollCL.PPpay_period = gPayPeriod
		//    PayrollCL.PPper_sys_id = CurrPersID
		//
		//    sOTHours = 0

		//    For i = 1 To sprWeek1.DataRowCnt
		//        sprWeek1.Row = i
		//        sprWeek1.Col = 5
		//        If sprWeek1.Text = "Schedule" Then
		//            'skip any logic... move to the next row
		//        Else
		//            sprWeek1.Col = 6
		//            If Clean(sprWeek1.Text) <> "" Then
		//
		//                sprWeek1.Col = 1 'Activity Type
		//                PayrollCL.PPsap_acttype = UCase(Clean(sprWeek1.Text))
		//
		//                sprWeek1.Col = 2 'CostCenter
		//                PayrollCL.PPsap_rec_center = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 3 'WBS Element
		//                PayrollCL.PPwbs_element = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 4 'Order
		//                PayrollCL.PPsap_rec_order = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 5 'Operation/Activity
		//                PayrollCL.PPsap_activity = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 6 'AA Type
		//                PayrollCL.PPa_a_type = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 7 'Job Code
		//                PayrollCL.PPexception_job_code = Clean(sprWeek1.Text)
		//
		//                sprWeek1.Col = 8 'Step
		//                PayrollCL.PPexception_step = Clean(sprWeek1.Text)
		//
		//                For x = 0 To 6
		//                    PayrollDate = DateArray(x, 0)
		//                    sOTHours = 0
		//                    If DateDiff("d", PayrollDate, SpecialEndDate) >= 0 Then
		//'                    If PayrollDate <= Format(Now(), "m/d/yyyy") Then
		//                        sprWeek1.Col = x + 9
		//                        If Clean(sprWeek1.Text) <> "" Then
		//                            If sprWeek1.ForeColor = BLUE Then
		//                                PayrollCL.PPpayroll_date = PayrollDate
		//                                PayrollCL.PPcreate_date = Now()
		//                                PayrollCL.PPcreate_by = gUser
		//                                If sOTHours = 0 Then
		//                                    PayrollCL.PPhours = Round(CDbl(sprWeek1.Text), 2)
		//                                    If PayrollCL.InsertPersonnelPayroll Then
		//                                        sprWeek1.ForeColor = BLACK
		//                                        sprWeek1.Col = x + 16
		//                                        sprWeek1.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                    End If
		//                                Else
		//                                    If sOTHours >= Round(CDbl(sprWeek1.Text), 2) Then
		//                                        PayrollCL.PPhours = Round(CDbl(sprWeek1.Text), 2)
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//                                            sprWeek1.ForeColor = BLACK
		//                                            sprWeek1.Col = x + 16
		//                                            sprWeek1.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                    Else 'sOTHours is less than hours... 2 records needed
		//                                        PayrollCL.PPhours = sOTHours
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//'                                            sprWeek1.ForeColor = BLACK
		//'                                            sprWeek1.Col = X + 16
		//'                                            sprWeek1.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                        PayrollCL.PPhours = Round(CDbl(sprWeek1.Text), 2) - sOTHours
		//                                        PayrollCL.PPsap_acttype = ""
		//                                        PayrollCL.PPsap_rec_center = ""
		//                                        PayrollCL.PPsap_rec_order = ""
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//'                                            sprWeek1.ForeColor = BLACK
		//'                                            sprWeek1.Col = X + 16
		//'                                            sprWeek1.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                    End If
		//                                End If
		//                            End If
		//                        End If
		//                    End If
		//                Next x
		//            End If
		//        End If
		//    Next i
		//
		//    For i = 1 To sprWeek2.DataRowCnt
		//        sprWeek2.Row = i
		//        sprWeek2.Col = 5
		//        If sprWeek2.Text = "Schedule" Then
		//            'skip any logic... move to the next row
		//        Else
		//            sprWeek2.Col = 6
		//            If Clean(sprWeek2.Text) <> "" Then
		//                sprWeek2.Col = 1 'Activity Type
		//                PayrollCL.PPsap_acttype = UCase(Clean(sprWeek2.Text))
		//
		//                sprWeek2.Col = 2 'CostCenter
		//                PayrollCL.PPsap_rec_center = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 3 'WBS Element
		//                PayrollCL.PPwbs_element = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 4 'Order
		//                PayrollCL.PPsap_rec_order = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 5 'Operation/Activity
		//                PayrollCL.PPsap_activity = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 6 'AA Type
		//                PayrollCL.PPa_a_type = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 7 'Job Code
		//                PayrollCL.PPexception_job_code = Clean(sprWeek2.Text)
		//
		//                sprWeek2.Col = 8 'Step
		//                PayrollCL.PPexception_step = Clean(sprWeek2.Text)
		//
		//                For x = 7 To 13
		//                    PayrollDate = DateArray(x, 0)
		//                    sOTHours = 0

		//                    If DateDiff("d", PayrollDate, SpecialEndDate) >= 0 Then
		//    '                    If PayrollDate <= Format(Now(), "m/d/yyyy") Then
		//                        sprWeek2.Col = x + 2
		//                        If Clean(sprWeek2.Text) <> "" Then
		//                            If sprWeek2.ForeColor = BLUE Then
		//                                PayrollCL.PPpayroll_date = PayrollDate
		//                                PayrollCL.PPcreate_date = Now()
		//                                PayrollCL.PPcreate_by = gUser
		//                                If sOTHours = 0 Then
		//                                    PayrollCL.PPhours = Round(CDbl(sprWeek2.Text), 2)
		//                                    If PayrollCL.InsertPersonnelPayroll Then
		//                                        sprWeek2.ForeColor = BLACK
		//                                        sprWeek2.Col = x + 9
		//                                        sprWeek2.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                    End If
		//                                Else
		//                                    If sOTHours >= Round(CDbl(sprWeek2.Text), 2) Then
		//                                        PayrollCL.PPhours = Round(CDbl(sprWeek2.Text), 2)
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//                                            sprWeek2.ForeColor = BLACK
		//                                            sprWeek2.Col = x + 9
		//                                            sprWeek2.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                    Else 'sOTHours is less than hours... 2 records needed
		//                                        PayrollCL.PPhours = sOTHours
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//'                                            sprWeek2.ForeColor = BLACK
		//'                                            sprWeek2.Col = X + 9
		//'                                            sprWeek2.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                        PayrollCL.PPhours = Round(CDbl(sprWeek2.Text), 2) - sOTHours
		//                                        PayrollCL.PPsap_acttype = ""
		//                                        PayrollCL.PPsap_rec_center = ""
		//                                        PayrollCL.PPsap_rec_order = ""
		//                                        If PayrollCL.InsertPersonnelPayroll Then
		//'                                            sprWeek2.ForeColor = BLACK
		//'                                            sprWeek2.Col = X + 9
		//'                                            sprWeek2.Text = CLng(PayrollCL.PPpayroll_sys_id)
		//                                        End If
		//                                    End If
		//                                End If
		//                            End If
		//                        End If
		//                    End If
		//                Next x
		//            End If
		//        End If
		//    Next i
		//    Screen.MousePointer = vbDefault
		//    PayRollExist = True
		//
		}

		public object GetEmployeePayRoll()
		{
			//    Dim oCmd As New ADODB.Command
			//    Dim oRec As ADODB.Recordset
			//    Dim SqlString As String
			//    Dim i As Integer
			//    Dim CurrPayrollID As Long
			//    Dim CurrJob As String
			//    Dim WorkDate As String
			//    Dim SaveDate As String
			//    Dim CurrStep As String
			//    Dim CurrActivity As String
			//    Dim CurrOper As String
			//    Dim RecCenter As String
			//    Dim RecOrder As String
			//    Dim WorkCenter As String
			//    Dim TotalHours As Single
			//    Dim NeedToAddRow1 As Boolean
			//    Dim NeedToAddRow2 As Boolean
			//    Dim WhichWeek As Integer
			//
			//    GetEmployeePayRoll = False
			//
			//    sprWeek1.Row = 1
			//    sprWeek1.Col = 5
			//    If sprWeek1.Text = "Schedule" Then
			//        NeedToAddRow1 = True
			//    Else
			//        NeedToAddRow1 = False
			//    End If
			//    sprWeek2.Row = 1
			//    sprWeek2.Col = 5
			//    If sprWeek2.Text = "Schedule" Then
			//        NeedToAddRow2 = True
			//    Else
			//        NeedToAddRow2 = False
			//    End If
			//
			//    TotalHours = 0
			//
			//    oCmd.ActiveConnection = oConn
			//    oCmd.CommandType = adCmdText
			//
			//    SqlString = "spSelect_IndividualPersonnelPayRollList " & gPayPeriod
			//    SqlString = SqlString & "," & gPayrollYear & "," & CurrPersID & " "
			//    oCmd.CommandText = SqlString
			//    Set oRec = oCmd.Execute
			//
			//    If oRec.EOF Then
			//        Exit Function
			//    Else
			//        GetEmployeePayRoll = True
			//        CurrPayrollID = GetVal(oRec("payroll_sys_id"]) 'Payroll System ID
			//        CurrActivity = Clean(oRec("sap_acttype"]) 'Activity Type
			//        RecCenter = Clean(oRec("sap_rec_center"]) 'Cost Center
			//        WorkCenter = Clean(oRec("wbs_element"]) 'WBS Element
			//        RecOrder = Clean(oRec("sap_rec_order"]) 'Order
			//        CurrOper = Clean(oRec("sap_activity"]) 'Operation
			//        CurrSAPCode = Clean(oRec("a_a_type"]) 'A/A Type
			//        CurrJob = Clean(oRec("exception_job_code"]) 'PS Group
			//        CurrStep = Clean(oRec("exception_step"]) 'Level
			//        SaveDate = Format$(oRec("payroll_date"), "m/d/yyyy")
			//        WhichWeek = 0
			//    End If
			//
			//    Do Until oRec.EOF
			//        WorkDate = Format$(oRec("payroll_date"), "m/d/yyyy") 'Payroll Date
			//        For i = 0 To 13
			//            If WorkDate = DateArray(i, 0) Then
			//                If DateArray(i, 2) = 0 Then
			//                    WhichWeek = 1
			//                Else
			//                    WhichWeek = 2
			//                End If
			//                Exit For
			//            End If
			//        Next i
			//
			//        If CurrActivity = Clean(oRec("sap_acttype"]) And _
			//'            RecCenter = Clean(oRec("sap_rec_center"]) And _
			//'            WorkCenter = Clean(oRec("wbs_element"]) And _
			//'            RecOrder = Clean(oRec("sap_rec_order"]) And _
			//'            CurrOper = Clean(oRec("sap_activity"]) And _
			//'            CurrSAPCode = Clean(oRec("a_a_type"]) And _
			//'            CurrJob = Clean(oRec("exception_job_code"]) And _
			//'            CurrStep = Clean(oRec("exception_step"]) Then
			//                If CurrPayrollID = Clean(oRec("payroll_sys_id"]) Then
			//                    'continue
			//                ElseIf SaveDate = WorkDate Then
			//                    NeedToAddRow1 = True
			//                    NeedToAddRow2 = True
			//                    CurrPayrollID = Clean(oRec("payroll_sys_id"])
			//                Else
			//                    SaveDate = WorkDate
			//                End If
			//        Else
			//            CurrPayrollID = Clean(oRec("payroll_sys_id"])
			//            CurrActivity = Clean(oRec("sap_acttype"]) 'Activity
			//            RecCenter = Clean(oRec("sap_rec_center"]) 'Cost Center
			//            WorkCenter = Clean(oRec("wbs_element"]) 'WBS Element
			//            RecOrder = Clean(oRec("sap_rec_order"]) 'Order
			//            CurrOper = Clean(oRec("sap_activity"]) 'Operation
			//            CurrSAPCode = Clean(oRec("a_a_type"]) 'A/A Type
			//            CurrJob = Clean(oRec("exception_job_code"]) 'PS Group
			//            CurrStep = Clean(oRec("exception_step"]) 'Level
			//            SaveDate = WorkDate
			//                NeedToAddRow1 = True
			//                NeedToAddRow2 = True
			//        End If
			//
			//        If WhichWeek = 1 Then
			//            If NeedToAddRow1 Then
			//                CurrRow1 = CurrRow1 + 1
			//                NeedToAddRow1 = False
			//            End If
			//            sprWeek1.Row = CurrRow1
			//            sprWeek1.Col = 6
			//            'test to see if timecard info is there
			//            If Clean(sprWeek1.Text) = "" Then
			//                sprWeek1.Col = 1
			//                sprWeek1.Text = CurrActivity
			//
			//                sprWeek1.Col = 2
			//                sprWeek1.Text = RecCenter
			//
			//                sprWeek1.Col = 3
			//                sprWeek1.Text = WorkCenter
			//
			//                sprWeek1.Col = 4
			//                sprWeek1.Text = RecOrder
			//
			//                sprWeek1.Col = 5
			//                sprWeek1.Text = CurrOper
			//
			//                sprWeek1.Col = 6
			//                sprWeek1.Text = CurrSAPCode
			//
			//                sprWeek1.Col = 7
			//                sprWeek1.Text = CurrJob
			//
			//                sprWeek1.Col = 8
			//                sprWeek1.Text = CurrStep
			//            End If
			//            sprWeek1.Col = DateArray(i, 1)
			//
			//            If Clean(oRec("payroll_status_code"]) = "S" Then
			//                sprWeek1.ForeColor = GREEN
			//            ElseIf Clean(oRec("payroll_status_code"]) = "D" Then
			//                sprWeek1.ForeColor = GREEN
			//            ElseIf Clean(oRec("payroll_status_code"]) = "N" Then
			//                sprWeek1.ForeColor = BLACK
			//            ElseIf Clean(oRec("payroll_status_code"]) = "" Then
			//                sprWeek1.ForeColor = BLACK
			//            Else 'Payroll Record Failed
			//                sprWeek1.ForeColor = RED
			//            End If
			//
			//            sprWeek1.Text = Round(CDbl(oRec("hours"]), 2)
			//
			//            TotalHours = Round(TotalHours + CDbl(oRec("hours"]), 2)
			//
			//            sprWeek1.Col = sprWeek1.Col + 7
			//            sprWeek1.Text = CLng(oRec("payroll_sys_id"])
			//        Else
			//            If NeedToAddRow2 Then
			//                CurrRow2 = CurrRow2 + 1
			//                NeedToAddRow2 = False
			//            End If
			//            sprWeek2.Row = CurrRow2
			//            sprWeek2.Col = 6
			//            'test to see if timecard info is there
			//            If Clean(sprWeek2.Text) = "" Then
			//                sprWeek2.Col = 1
			//                sprWeek2.Text = CurrActivity
			//
			//                sprWeek2.Col = 2
			//                sprWeek2.Text = RecCenter
			//
			//                sprWeek2.Col = 3
			//                sprWeek2.Text = WorkCenter
			//
			//                sprWeek2.Col = 4
			//                sprWeek2.Text = RecOrder
			//
			//                sprWeek2.Col = 5
			//                sprWeek2.Text = CurrOper
			//
			//                sprWeek2.Col = 6
			//                sprWeek2.Text = CurrSAPCode
			//
			//                sprWeek2.Col = 7
			//                sprWeek2.Text = CurrJob
			//
			//                sprWeek2.Col = 8
			//                sprWeek2.Text = CurrStep
			//            End If
			//            sprWeek2.Col = DateArray(i, 1)
			//
			//            If Clean(oRec("payroll_status_code"]) = "S" Then
			//                sprWeek2.ForeColor = GREEN
			//            ElseIf Clean(oRec("payroll_status_code"]) = "D" Then
			//                sprWeek2.ForeColor = GREEN
			//            ElseIf Clean(oRec("payroll_status_code"]) = "N" Then
			//                sprWeek2.ForeColor = BLACK
			//            ElseIf Clean(oRec("payroll_status_code"]) = "" Then
			//                sprWeek2.ForeColor = BLACK
			//            Else 'Payroll Record Failed
			//                sprWeek2.ForeColor = RED
			//            End If
			//
			//            sprWeek2.Text = Round(CDbl(oRec("hours"]), 2)
			//
			//            TotalHours = Round(TotalHours + CDbl(oRec("hours"]), 2)
			//
			//            sprWeek2.Col = sprWeek2.Col + 7
			//            sprWeek2.Text = CLng(oRec("payroll_sys_id"])
			//        End If
			//        oRec.MoveNext
			//    Loop
			//    cmdSave.Visible = False
			//    lbPayrollHrs.Caption = "Total Payrolled Hours:"
			//    lbTotalHrs.Caption = Round(TotalHours, 2)
			//
			return null;
		}

		public void FillTimeCard()
		{
		//    'Fill in Employee Pay Roll Detail
		//    'Fill in Time Card detail
		//
		//    Dim oCmd As New ADODB.Command
		//    Dim ocmd2 As New ADODB.Command
		//    Dim oRec As ADODB.Recordset
		//    Dim orec2 As ADODB.Recordset
		//    Dim FillerRow1 As Integer
		//    Dim FillerRow2 As Integer
		//    Dim i As Integer, x As Integer
		//    Dim JobCode As String
		//    Dim WorkDate As String
		//    Dim CurrOper As String
		//    Dim CurrJob As String
		//    Dim CurrTitle As String
		//    Dim CurrStep As String
		//    Dim TotalHours As Single
		//    Dim WeekHours As Single
		//    Dim TotalShifts As Single
		//    Dim PossibleSkip As Boolean
		//    Dim NoExceptions As Boolean
		//    Dim NoSchedule As Boolean
		//    Dim AddedAline As Boolean
		//    Dim TemporaryJobCode As String
		//    Dim TemporaryStep As String
		//
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    PayRollExist = False
		//    NoExceptions = False
		//    NoSchedule = False
		//
		//    TemporaryJobCode = ""
		//    TemporaryStep = ""
		//
		//    'Clear Grid
		//    ClearTimeCard
		//    lbPayrollHrs.Caption = ""
		//    lbTotalHrs.Caption = 0
		//    PossibleSkip = False
		//    CurrSAPCode = ""

		//    CurrLeaveTotal = 0
		//    TotalShifts = 0
		//    CurrentUnit = ""
		//
		//    oCmd.ActiveConnection = oConn
		//    oCmd.CommandType = adCmdText
		//    oCmd.CommandText = "sp_GetPersonnelDetail '" & CurrEmpID & "'"
		//    Set oRec = oCmd.Execute
		//
		//    If oRec.EOF Then
		//        MsgBox "Unable to Recall Employee Payroll Detail", vbCritical, "Individual Time Cards"
		//        Exit Sub
		//    End If
		//
		//    JobCode = oRec("job_code_id")
		//    CurrPersID = oRec("per_sys_id")
		//    CurrentUnit = Clean(oRec("assignment_type_code"])
		//    TemporaryJobCode = Clean(oRec("UpgradeJobCode"])
		//    If TemporaryJobCode <> "" Then
		//        TemporaryStep = Clean(oRec("UpgradeStep"])
		//    Else
		//        TemporaryStep = ""
		//    End If
		//
		//    'Get all Scheduled Shifts... this will not show up on printed TimeCard
		//    oCmd.CommandText = "sp_GetIndPPShifts '" & CurrEmpID & "','" & CurrStartDate & "','" & CurrEndDate & "'"
		//    Set oRec = oCmd.Execute
		//    CurrRow1 = 1
		//    CurrRow2 = 1
		//
		//    If oRec.EOF Then
		//        NoSchedule = True
		//    Else
		//
		//        Do Until oRec.EOF
		//            WorkDate = Format$(oRec("schedule_date"), "m/d/yyyy")
		//            For i = 0 To 13
		//                If DateArray(i, 0) = WorkDate Then
		//                    If DateArray(i, 2) = 0 Then
		//                        sprWeek1.Col = DateArray(i, 1)
		//                        sprWeek1.Row = CurrRow1
		//                        sprWeek1.FontBold = True
		//                        sprWeek1.ForeColor = RED
		//                        sprWeek1.Text = oRec("shift_code")
		//                        sprWeek1.Col = 5
		//                        If sprWeek1.Text = "" Then
		//                            sprWeek1.FontBold = True
		//                            sprWeek1.ForeColor = RED
		//                            sprWeek1.Text = "Schedule"
		//                        End If
		//                        Exit For
		//                    Else
		//                        sprWeek2.Col = DateArray(i, 1)
		//                        sprWeek2.Row = CurrRow2
		//                        sprWeek2.FontBold = True
		//                        sprWeek2.ForeColor = RED
		//                        sprWeek2.Text = oRec("shift_code")
		//                        sprWeek2.Col = 5
		//                        If sprWeek2.Text = "" Then
		//                            sprWeek2.FontBold = True
		//                            sprWeek2.ForeColor = RED
		//                            sprWeek2.Text = "Schedule"
		//                        End If
		//                        Exit For
		//                    End If
		//                End If
		//            Next i
		//
		//            oRec.MoveNext
		//        Loop
		//    End If
		//    '*********************************************************************
		//    '*********************************************************************
		//    '  NEW LOGIC NEEDS TO GO HERE!!
		//    '   Determine if PersonnelPayRoll Rows exist for this payperiod
		//    '       True - Then rows will have been loaded in GetEmployeePayroll
		//    '              Apply Changes will involve Update/Delete & Insert
		//    '       False - Do the logic that you have been doing
		//    '              Apply Changes will only involve Insert
		//    '*********************************************************************
		//    '*********************************************************************
		//
		//    If GetEmployeePayRoll Then
		//        PayRollExist = True
		//        sprEmployeeList.Col = 1
		//        sprEmployeeList.Row = SelectedRow
		//        If SelectedRow > 0 Then
		//            If Not sprEmployeeList.Value = 1 Then
		//                sprEmployeeList.Value = 1
		//                sprEmployeeList.BlockMode = True
		//                sprEmployeeList.Row = SelectedRow
		//                sprEmployeeList.Row2 = SelectedRow
		//                sprEmployeeList.Col = 2
		//                sprEmployeeList.Col2 = sprEmployeeList.MaxCols
		//                sprEmployeeList.ForeColor = BLUE
		//                sprEmployeeList.FontBold = False
		//                sprEmployeeList.BlockMode = False
		//            End If
		//        End If
		//    End If
		//
		//    If NoSchedule Then
		//        If Not PayRollExist Then
		//            'No Schedule information is available... default to bank time card
		//            sprWeek1.Row = 1
		//
		//            sprWeek1.Col = 5
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 6
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 9
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 10
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 11
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 12
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek1.Col = 13
		//            sprWeek1.FontBold = False
		//            sprWeek1.ForeColor = BLACK
		//            sprWeek1.Text = ""
		//
		//            sprWeek2.Row = 1
		//
		//            sprWeek2.Col = 5
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 6
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 9
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 10
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 11
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 12
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            sprWeek2.Col = 13
		//            sprWeek2.FontBold = False
		//            sprWeek2.ForeColor = BLACK
		//            sprWeek2.Text = ""
		//
		//            lbPayrollHrs.Caption = "Total Payroll Hours:"
		//            lbTotalHrs.Caption = "0"
		//        End If
		//    End If
		//
		//    'Add logic to split out Debit Day Upgrades
		//    'Enter Exception Lines
		//    oCmd.CommandText = "sp_GetIndPPException '" & CurrEmpID & "','" & CurrStartDate & "','" & CurrEndDate & "'"
		//    Set oRec = oCmd.Execute
		//    TotalHours = 0
		//    Dim NeedToAddRow1 As Boolean
		//    Dim NeedToAddRow2 As Boolean
		//
		//    If Not oRec.EOF Then
		//        CurrOper = ""
		//        CurrSAPCode = Clean(oRec("a_a_type"])
		//        CurrJob = Clean(oRec("curr_job"])
		//        CurrTitle = Trim$(Clean(oRec("job_title"]))
		//        CurrStep = Clean(oRec("step"])
		//        If CurrStep = "0" Then
		//            CurrStep = ""
		//        End If
		//        WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//        NeedToAddRow1 = True
		//        NeedToAddRow2 = True
		//        Do Until oRec.EOF
		//            If CurrSAPCode = Clean(oRec("a_a_type"]) Then
		//                If Clean(CurrJob) = Clean(oRec("curr_job"]) Then
		//                    If WorkDate = Format$(oRec("shift_start"), "m/d/yyyy") Then
		//                        TotalHours = TotalHours + 12
		//                        oRec.MoveNext
		//                    Else
		//                        For i = 0 To 13
		//                            If DateArray(i, 0) = WorkDate Then
		//                                If DateArray(i, 2) = 0 Then
		//                                    If NeedToAddRow1 Then
		//                                        CurrRow1 = CurrRow1 + 1
		//                                        NeedToAddRow1 = False
		//                                    End If
		//                                    If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                        sprWeek1.Row = CurrRow1
		//                                        sprWeek1.FontBold = False
		//                                        sprWeek1.ForeColor = BLACK
		//                                        sprWeek1.Col = 5
		//                                        sprWeek1.Text = CurrOper
		//                                        sprWeek1.Col = 6
		//                                        sprWeek1.Text = CurrSAPCode
		//                                        sprWeek1.Col = DateArray(i, 1)
		//                                        sprWeek1.ForeColor = BLUE
		//                                        sprWeek1.Text = Round(TotalHours, 2)
		//'                                        If CurrJob <> JobCode Then
		//                                            sprWeek1.Col = 7
		//                                            sprWeek1.Text = CurrJob
		//                                            sprWeek1.Col = 8
		//                                            sprWeek1.Text = CurrStep
		//'                                        End If
		//                                    Else
		//                                        sprWeek1.Row = CurrRow1
		//                                        sprWeek1.FontBold = False
		//                                        sprWeek1.ForeColor = BLACK
		//                                        sprWeek1.Col = 5
		//                                        sprWeek1.Text = CurrOper
		//                                        sprWeek1.Col = 6
		//                                        sprWeek1.Text = CurrSAPCode
		//                                        sprWeek1.Col = DateArray(i, 1)
		//                                        sprWeek1.ForeColor = BLUE
		//                                        sprWeek1.Text = Round(TotalHours, 2)
		//                                        sprWeek1.Col = 7
		//                                        sprWeek1.Text = ""
		//                                        sprWeek1.Col = 8
		//                                        sprWeek1.Text = ""
		//
		//                                        If Clean(CurrJob) <> "" Then
		//'                                            If CurrJob <> JobCode Then
		//                                                FillerRow1 = CurrRow1 + 1
		//                                                sprWeek1.Row = FillerRow1
		//                                                sprWeek1.FontBold = False
		//                                                sprWeek1.ForeColor = BLACK
		//                                                sprWeek1.Col = 5
		//                                                sprWeek1.Text = CurrOper
		//                                                sprWeek1.Col = 6
		//                                                sprWeek1.Text = "9005"
		//                                                sprWeek1.Col = DateArray(i, 1)
		//                                                sprWeek1.ForeColor = BLUE
		//                                                sprWeek1.Text = Round(TotalHours, 2)
		//                                                sprWeek1.Col = 7
		//                                                sprWeek1.Text = CurrJob
		//                                                sprWeek1.Col = 8
		//                                                sprWeek1.Text = CurrStep
		//'                                            End If
		//                                        End If
		//                                        NeedToAddRow1 = True
		//                                    End If
		//                                    Exit For
		//                                Else
		//                                    If NeedToAddRow2 Then
		//                                        CurrRow2 = CurrRow2 + 1
		//                                        NeedToAddRow2 = False
		//                                    End If
		//                                    If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                        sprWeek2.Row = CurrRow2
		//                                        sprWeek2.Col = 5
		//                                        sprWeek2.Text = CurrOper
		//                                        sprWeek2.Col = 6
		//                                        sprWeek2.Text = CurrSAPCode
		//                                        sprWeek2.FontBold = False
		//                                        sprWeek2.ForeColor = BLACK
		//                                        sprWeek2.Col = DateArray(i, 1)
		//                                        sprWeek2.ForeColor = BLUE
		//                                        sprWeek2.Text = Round(TotalHours, 2)
		//'                                        If CurrJob <> JobCode Then
		//                                            sprWeek2.Col = 7
		//                                            sprWeek2.Text = CurrJob
		//                                            sprWeek2.Col = 8
		//                                            sprWeek2.Text = CurrStep
		//'                                        End If
		//
		//                                    Else
		//                                        sprWeek2.Row = CurrRow2
		//                                        sprWeek2.Col = 5
		//                                        sprWeek2.Text = CurrOper
		//                                        sprWeek2.Col = 6
		//                                        sprWeek2.Text = CurrSAPCode
		//                                        sprWeek2.FontBold = False
		//                                        sprWeek2.ForeColor = BLACK
		//                                        sprWeek2.Col = DateArray(i, 1)
		//                                        sprWeek2.ForeColor = BLUE
		//                                        sprWeek2.Text = Round(TotalHours, 2)
		//                                        sprWeek2.Col = 7
		//                                        sprWeek2.Text = ""
		//                                        sprWeek2.Col = 8
		//                                        sprWeek2.Text = ""
		//
		//                                        If Clean(CurrJob) <> "" Then
		//'                                            If CurrJob <> JobCode Then
		//                                                FillerRow2 = CurrRow2 + 1
		//                                                sprWeek2.Row = FillerRow2
		//                                                sprWeek2.Col = 5
		//                                                sprWeek2.Text = CurrOper
		//                                                sprWeek2.Col = 6
		//                                                sprWeek2.Text = "9005"
		//                                                sprWeek2.FontBold = False
		//                                                sprWeek2.ForeColor = BLACK
		//                                                sprWeek2.Col = DateArray(i, 1)
		//                                                sprWeek2.ForeColor = BLUE
		//                                                sprWeek2.Text = Round(TotalHours, 2)
		//                                                sprWeek2.Col = 7
		//                                                sprWeek2.Text = CurrJob
		//                                                sprWeek2.Col = 8
		//                                                sprWeek2.Text = CurrStep
		//'                                            End If
		//                                        End If
		//                                    End If
		//                                    Exit For
		//                                End If
		//                            End If
		//                        Next i
		//                        TotalHours = 0
		//                        WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//                    End If
		//                Else ' KOT is the same... but not JobCode
		//                    If TotalHours < 12 Then
		//                        TotalHours = TotalHours + 12
		//                    End If
		//                    For i = 0 To 13
		//                        If DateArray(i, 0) = WorkDate Then
		//                            If DateArray(i, 2) = 0 Then
		//                                If NeedToAddRow1 Then
		//                                    CurrRow1 = CurrRow1 + 1
		//                                    NeedToAddRow1 = False
		//                                End If
		//                                If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                    sprWeek1.Col = DateArray(i, 1)
		//                                    sprWeek1.Row = CurrRow1
		//                                    sprWeek1.ForeColor = BLUE
		//                                    sprWeek1.Text = Round(TotalHours, 2)
		//                                    sprWeek1.Col = 5
		//                                    sprWeek1.Text = CurrOper
		//                                    sprWeek1.Col = 6
		//                                    sprWeek1.Text = CurrSAPCode
		//'                                    If CurrJob <> JobCode Then
		//                                        sprWeek1.Col = 7
		//                                        sprWeek1.Text = CurrJob
		//                                        sprWeek1.Col = 8
		//                                        sprWeek1.Text = CurrStep
		//'                                    End If
		//                                Else
		//                                    sprWeek1.Col = DateArray(i, 1)
		//                                    sprWeek1.Row = CurrRow1
		//                                    sprWeek1.ForeColor = BLUE
		//                                    sprWeek1.Text = Round(TotalHours, 2)
		//                                    sprWeek1.Col = 5
		//                                    sprWeek1.Text = CurrOper
		//                                    sprWeek1.Col = 6
		//                                    sprWeek1.Text = CurrSAPCode
		//                                    sprWeek1.Col = 7
		//                                    sprWeek1.Text = ""
		//                                    sprWeek1.Col = 8
		//                                    sprWeek1.Text = ""
		//
		//                                    If Clean(CurrJob) <> "" Then
		//'                                        If CurrJob <> JobCode Then
		//                                            FillerRow1 = CurrRow1 + 1
		//                                            sprWeek1.Col = DateArray(i, 1)
		//                                            sprWeek1.Row = FillerRow1
		//                                            sprWeek1.ForeColor = BLUE
		//                                            sprWeek1.Text = Round(TotalHours, 2)
		//                                            sprWeek1.Col = 5
		//                                            sprWeek1.Text = CurrOper
		//                                            sprWeek1.Col = 6
		//                                            sprWeek1.Text = CurrSAPCode
		//                                            sprWeek1.Col = 7
		//                                            sprWeek1.Text = CurrJob
		//                                            sprWeek1.Col = 8
		//                                            sprWeek1.Text = CurrStep
		//                                            CurrRow1 = FillerRow1
		//'                                        End If
		//                                    End If
		//                                End If
		//                                NeedToAddRow1 = True
		//                                Exit For
		//                            Else
		//                                If NeedToAddRow2 Then
		//                                    CurrRow2 = CurrRow2 + 1
		//                                    NeedToAddRow2 = False
		//                                End If
		//                                If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                    sprWeek2.Row = CurrRow2
		//                                    sprWeek2.Col = 5
		//                                    sprWeek2.Text = CurrOper
		//                                    sprWeek2.Col = 6
		//                                    sprWeek2.Text = CurrSAPCode
		//                                    sprWeek2.Col = DateArray(i, 1)
		//                                    sprWeek2.ForeColor = BLUE
		//                                    sprWeek2.Text = Round(TotalHours, 2)
		//'                                    If CurrJob <> JobCode Then
		//                                        sprWeek2.Col = 7
		//                                        sprWeek2.Text = CurrJob
		//                                        sprWeek2.Col = 8
		//                                        sprWeek2.Text = CurrStep
		//'                                    End If
		//                                Else
		//                                    sprWeek2.Row = CurrRow2
		//                                    sprWeek2.Col = 5
		//                                    sprWeek2.Text = CurrOper
		//                                    sprWeek2.Col = 6
		//                                    sprWeek2.Text = CurrSAPCode
		//                                    sprWeek2.Col = DateArray(i, 1)
		//                                    sprWeek2.ForeColor = BLUE
		//                                    sprWeek2.Text = Round(TotalHours, 2)
		//                                    sprWeek2.Col = 7
		//                                    sprWeek2.Text = ""
		//                                    sprWeek2.Col = 8
		//                                    sprWeek2.Text = ""
		//
		//                                    If Clean(CurrJob) <> "" Then
		//'                                        If CurrJob <> JobCode Then
		//                                            FillerRow2 = CurrRow2 + 1
		//                                            sprWeek2.Row = FillerRow2
		//                                            sprWeek2.Col = 5
		//                                            sprWeek2.Text = CurrOper
		//                                            sprWeek2.Col = 6
		//                                            sprWeek2.Text = "9005"
		//                                            sprWeek2.FontBold = False
		//                                            sprWeek2.ForeColor = BLACK
		//                                            sprWeek2.Col = DateArray(i, 1)
		//                                            sprWeek2.ForeColor = BLUE
		//                                            sprWeek2.Text = Round(TotalHours, 2)
		//                                            sprWeek2.Col = 7
		//                                            sprWeek2.Text = CurrJob
		//                                            sprWeek2.Col = 8
		//                                            sprWeek2.Text = CurrStep
		//                                            CurrRow2 = FillerRow2
		//'                                        End If
		//                                    End If
		//                                End If
		//                                NeedToAddRow2 = True
		//                                Exit For
		//                            End If
		//                        End If
		//                    Next i
		//                    TotalHours = 0
		//                    CurrJob = oRec("curr_job")
		//                    CurrTitle = Trim$(Clean(oRec("job_title"]))
		//                    CurrStep = Clean(oRec("step"])
		//                    If CurrStep = "0" Then
		//                        CurrStep = ""
		//                    End If
		//                    '*****
		//                    NeedToAddRow1 = True
		//                    NeedToAddRow2 = True
		//                    '*****
		//                    WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//                End If
		//            Else
		//                For i = 0 To 13
		//                    If DateArray(i, 0) = WorkDate Then
		//                        If DateArray(i, 2) = 0 Then
		//                            If NeedToAddRow1 Then
		//                                CurrRow1 = CurrRow1 + 1
		//                            End If
		//                            If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                sprWeek1.Col = DateArray(i, 1)
		//                                sprWeek1.Row = CurrRow1
		//                                sprWeek1.ForeColor = BLUE
		//                                sprWeek1.Text = Round(TotalHours, 2)
		//                                sprWeek1.Col = 5
		//                                sprWeek1.Text = CurrOper
		//                                sprWeek1.Col = 6
		//                                sprWeek1.Text = CurrSAPCode
		//'                                If CurrJob <> JobCode Then
		//                                    sprWeek1.Col = 7
		//                                    sprWeek1.Text = CurrJob
		//                                    sprWeek1.Col = 8
		//                                    sprWeek1.Text = CurrStep
		//'                                End If
		//                            Else
		//                                sprWeek1.Col = DateArray(i, 1)
		//                                sprWeek1.Row = CurrRow1
		//                                sprWeek1.ForeColor = BLUE
		//                                sprWeek1.Text = Round(TotalHours, 2)
		//                                sprWeek1.Col = 5
		//                                sprWeek1.Text = CurrOper
		//                                sprWeek1.Col = 6
		//                                sprWeek1.Text = CurrSAPCode
		//                                sprWeek1.Col = 7
		//                                sprWeek1.Text = ""
		//                                sprWeek1.Col = 8
		//                                sprWeek1.Text = ""
		//
		//                                If Clean(CurrJob) <> "" Then
		//'                                    If CurrJob <> JobCode Then
		//                                        sprWeek1.Col = DateArray(i, 1)
		//                                        FillerRow1 = CurrRow1 + 1
		//                                        sprWeek1.Row = FillerRow1
		//                                        sprWeek1.ForeColor = BLUE
		//                                        sprWeek1.Text = Round(TotalHours, 2)
		//                                        sprWeek1.Col = 5
		//                                        sprWeek1.Text = CurrOper
		//                                        sprWeek1.Col = 6
		//                                        sprWeek1.Text = "9005"
		//                                        sprWeek1.Col = 7
		//                                        sprWeek1.Text = CurrJob
		//                                        sprWeek1.Col = 8
		//                                        sprWeek1.Text = CurrStep
		//                                        CurrRow1 = FillerRow1
		//'                                    End If
		//                                End If
		//                            End If
		//                            NeedToAddRow1 = True
		//                            Exit For
		//                        Else
		//                            If NeedToAddRow2 Then
		//                                CurrRow2 = CurrRow2 + 1
		//                            End If
		//                            If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                                sprWeek2.Col = DateArray(i, 1)
		//                                sprWeek2.Row = CurrRow2
		//                                sprWeek2.ForeColor = BLUE
		//                                sprWeek2.Text = Round(TotalHours, 2)
		//                                sprWeek2.Col = 5
		//                                sprWeek2.Text = CurrOper
		//                                sprWeek2.Col = 6
		//                                sprWeek2.Text = CurrSAPCode
		//'                                If CurrJob <> JobCode Then
		//                                    sprWeek2.Col = 7
		//                                    sprWeek2.Text = CurrJob
		//                                    sprWeek2.Col = 8
		//                                    sprWeek2.Text = CurrStep
		//'                                End If
		//                            Else
		//                                sprWeek2.Col = DateArray(i, 1)
		//                                sprWeek2.Row = CurrRow2
		//                                sprWeek2.ForeColor = BLUE
		//                                sprWeek2.Text = Round(TotalHours, 2)
		//                                sprWeek2.Col = 5
		//                                sprWeek2.Text = CurrOper
		//                                sprWeek2.Col = 6
		//                                sprWeek2.Text = CurrSAPCode
		//                                sprWeek2.Col = 7
		//                                sprWeek2.Text = ""
		//                                sprWeek2.Col = 8
		//                                sprWeek2.Text = ""
		//
		//                                If Clean(CurrJob) <> "" Then
		//'                                    If CurrJob <> JobCode Then
		//                                        sprWeek2.Col = DateArray(i, 1)
		//                                        FillerRow2 = CurrRow2 + 1
		//                                        sprWeek2.Row = FillerRow2
		//                                        sprWeek2.ForeColor = BLUE
		//                                        sprWeek2.Text = Round(TotalHours, 2)
		//                                        sprWeek2.Col = 5
		//                                        sprWeek2.Text = CurrOper
		//                                        sprWeek2.Col = 6
		//                                        sprWeek2.Text = "9005"
		//                                        sprWeek2.Col = 7
		//                                        sprWeek2.Text = CurrJob
		//                                        sprWeek2.Col = 8
		//                                        sprWeek2.Text = CurrStep
		//                                        CurrRow2 = FillerRow2
		//'                                    End If
		//                                End If
		//                            End If
		//                            NeedToAddRow2 = True
		//                            Exit For
		//                        End If
		//                    End If
		//                Next i
		//                TotalHours = 0
		//                CurrOper = ""
		//                CurrSAPCode = oRec("a_a_type")
		//                CurrJob = oRec("curr_job")
		//                CurrTitle = Trim$(Clean(oRec("job_title"]))
		//                CurrStep = Clean(oRec("step"])
		//                If CurrStep = "0" Then
		//                    CurrStep = ""
		//                End If
		//                WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//
		//            End If
		//        Loop
		//
		//        'Last Record...
		//        For i = 0 To 13
		//            If DateArray(i, 0) = WorkDate Then
		//                If DateArray(i, 2) = 0 Then
		//                    If NeedToAddRow1 Then
		//                        CurrRow1 = CurrRow1 + 1
		//                        NeedToAddRow1 = False
		//                    End If
		//                    If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                        sprWeek1.Col = DateArray(i, 1)
		//                        sprWeek1.Row = CurrRow1
		//                        sprWeek1.FontBold = False
		//                        sprWeek1.ForeColor = BLUE
		//                        sprWeek1.Text = Round(TotalHours, 2)
		//                        sprWeek1.Col = 5
		//                        If sprWeek1.Text = "" Then
		//                            sprWeek1.Text = CurrOper
		//                            sprWeek1.Col = 6
		//                            sprWeek1.Text = CurrSAPCode
		//                        End If
		//'                        If CurrJob <> JobCode Then
		//                            sprWeek1.Col = 7
		//                            sprWeek1.Text = CurrJob
		//                            sprWeek1.Col = 8
		//                            sprWeek1.Text = CurrStep
		//'                        End If
		//                    Else
		//                        sprWeek1.Col = DateArray(i, 1)
		//                        sprWeek1.Row = CurrRow1
		//                        If Clean(sprWeek1.Text) = "" Then
		//                            sprWeek1.FontBold = False
		//                            sprWeek1.ForeColor = BLUE
		//                            sprWeek1.Text = Round(TotalHours, 2)
		//                            sprWeek1.Col = 5
		//                            sprWeek1.Text = CurrOper
		//                            sprWeek1.Col = 6
		//                            If sprWeek1.Text = "" Then
		//                                sprWeek1.Text = CurrSAPCode
		//                            End If
		//                        End If
		//
		//                        If Clean(CurrJob) <> "" Then
		//'                            If CurrJob <> JobCode Then
		//                                sprWeek1.Col = DateArray(i, 1)
		//                                FillerRow1 = CurrRow1 + 1
		//                                sprWeek1.Row = FillerRow1
		//                                sprWeek1.FontBold = False
		//                                sprWeek1.ForeColor = BLUE
		//                                sprWeek1.Text = Round(TotalHours, 2)
		//                                sprWeek1.Col = 5
		//                                sprWeek1.Text = CurrOper
		//                                sprWeek1.Col = 6
		//                                sprWeek1.Text = "9005"
		//                                sprWeek1.Col = 7
		//                                sprWeek1.Text = CurrJob
		//                                sprWeek1.Col = 8
		//                                sprWeek1.Text = CurrStep
		//                                CurrRow1 = FillerRow1
		//'                            End If
		//                        End If
		//                    End If
		//                    Exit For
		//                Else
		//                    If NeedToAddRow2 Then
		//                        CurrRow2 = CurrRow2 + 1
		//                        NeedToAddRow2 = False
		//                    End If
		//                    If CurrSAPCode <> "9900" And CurrSAPCode <> "9901" Then
		//                        sprWeek2.Col = DateArray(i, 1)
		//                        sprWeek2.Row = CurrRow2
		//                        sprWeek2.FontBold = False
		//                        sprWeek2.ForeColor = BLUE
		//                        sprWeek2.Text = Round(TotalHours, 2)
		//                        sprWeek2.Col = 5
		//                        If sprWeek2.Text = "" Then
		//                            sprWeek2.Text = CurrOper
		//                            sprWeek2.Col = 6
		//                            sprWeek2.Text = CurrSAPCode
		//                        End If
		//'                        If CurrJob <> JobCode Then
		//                            sprWeek2.Col = 7
		//                            sprWeek2.Text = CurrJob
		//                            sprWeek2.Col = 8
		//                            sprWeek2.Text = CurrStep
		//'                        End If
		//                    Else
		//                        sprWeek2.Col = DateArray(i, 1)
		//                        sprWeek2.Row = CurrRow2
		//                        If Clean(sprWeek2.Text) = "" Then
		//                            sprWeek2.FontBold = False
		//                            sprWeek2.ForeColor = BLUE
		//                            sprWeek2.Text = Round(TotalHours, 2)
		//                            sprWeek2.Col = 5
		//                            If sprWeek2.Text = "" Then
		//                                sprWeek2.Text = CurrOper
		//                                sprWeek2.Col = 6
		//                                sprWeek2.Text = CurrSAPCode
		//                            End If
		//                            sprWeek2.Col = 7
		//                            sprWeek2.Text = ""
		//                            sprWeek2.Col = 8
		//                            sprWeek2.Text = ""
		//                        End If
		//                        If Clean(CurrJob) <> "" Then
		//'                            If CurrJob <> JobCode Then
		//                                sprWeek2.Col = DateArray(i, 1)
		//                                FillerRow2 = CurrRow2 + 1
		//                                sprWeek2.Row = FillerRow2
		//                                sprWeek2.FontBold = False
		//                                sprWeek2.ForeColor = BLUE
		//                                sprWeek2.Text = Round(TotalHours, 2)
		//                                sprWeek2.Col = 5
		//                                sprWeek2.Text = CurrOper
		//                                sprWeek2.Col = 6
		//                                sprWeek2.Text = "9005"
		//                                sprWeek2.Col = 7
		//                                sprWeek2.Text = CurrJob
		//                                sprWeek2.Col = 8
		//                                sprWeek2.Text = CurrStep
		//                                CurrRow2 = FillerRow2
		//'                            End If
		//                        End If
		//                    End If
		//                    Exit For
		//                End If
		//            End If
		//        Next i
		//        If gPayPeriod = CurrPayPeriod Then
		//            cmdSave.Visible = True
		//            cmdSave.Enabled = True
		//        End If
		//    End If
		//
		//    ocmd2.ActiveConnection = oConn
		//    ocmd2.CommandType = adCmdText
		//
		//    CurrLeaveTotal = 0
		//    'Enter Leave Lines
		//    oCmd.CommandText = "sp_GetIndPPLeave '" & CurrEmpID & "','" & CurrStartDate & "','" & CurrEndDate & "'"
		//    Set oRec = oCmd.Execute
		//    TotalHours = 0
		//
		//    If Not oRec.EOF Then
		//        CurrOper = ""
		//        CurrSAPCode = oRec("a_a_type")
		//        SchedTime = Clean(oRec("sched_time_code"])

		//        '**********
		//        '**********
		//        WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//        NeedToAddRow1 = True
		//        NeedToAddRow2 = True
		//        Do Until oRec.EOF
		//            If CurrSAPCode = Clean(oRec("a_a_type"]) Then
		//                If WorkDate = Format$(oRec("shift_start"), "m/d/yyyy") Then
		//                    TotalHours = TotalHours + 12
		//
		//                    oRec.MoveNext
		//                    If Not oRec.EOF Then
		//                        SchedTime = Clean(oRec("sched_time_code"])
		//                    End If
		//                Else
		//                    For i = 0 To 13
		//                        If DateArray(i, 0) = WorkDate Then
		//                            If DateArray(i, 2) = 0 Then
		//                                '**********
		//
		//                                '**********
		//                                If NeedToAddRow1 Then
		//                                    CurrRow1 = CurrRow1 + 1
		//                                    NeedToAddRow1 = False
		//                                End If
		//                                sprWeek1.Row = CurrRow1
		//                                If TemporaryJobCode <> "" Then
		//                                    sprWeek1.Col = 7
		//                                    sprWeek1.Text = TemporaryJobCode
		//                                    sprWeek1.Col = 8
		//                                    sprWeek1.Text = TemporaryStep
		//                                End If
		//                                sprWeek1.Col = 5
		//                                sprWeek1.Text = CurrOper
		//                                sprWeek1.Col = 6
		//                                sprWeek1.Text = CurrSAPCode
		//                                sprWeek1.Col = DateArray(i, 1)
		//
		//                                sprWeek1.ForeColor = BLUE
		//                                sprWeek1.Text = Round(TotalHours, 2)

		//                                lbPayrollHrs.Caption = "Total Exception Hours:"
		//                                lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                                Exit For
		//
		//                            Else
		//                                '**********
		//                                '**********
		//                                If NeedToAddRow2 Then
		//                                    CurrRow2 = CurrRow2 + 1
		//                                    NeedToAddRow2 = False
		//                                End If
		//
		//                                sprWeek2.Row = CurrRow2
		//                                If TemporaryJobCode <> "" Then
		//                                    sprWeek2.Col = 7
		//                                    sprWeek2.Text = TemporaryJobCode
		//                                    sprWeek2.Col = 8
		//                                    sprWeek2.Text = TemporaryStep
		//                                End If
		//                                sprWeek2.Col = 5
		//                                sprWeek2.Text = CurrOper
		//                                sprWeek2.Col = 6
		//                                sprWeek2.Text = CurrSAPCode
		//                                sprWeek2.Col = DateArray(i, 1)
		//
		//                                sprWeek2.ForeColor = BLUE
		//                                sprWeek2.Text = Round(TotalHours, 2)
		//
		//                                lbPayrollHrs.Caption = "Total Exception Hours:"
		//                                lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                                Exit For
		//                            End If
		//                        End If
		//                    Next i
		//                    TotalHours = 0
		//                    WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//                    SchedTime = Clean(oRec("sched_time_code"])
		//                End If
		//            Else
		//                For i = 0 To 13
		//                    If DateArray(i, 0) = WorkDate Then
		//                        If DateArray(i, 2) = 0 Then
		//                            If NeedToAddRow1 Then
		//                                CurrRow1 = CurrRow1 + 1
		//                            End If
		//                            sprWeek1.Row = CurrRow1
		//                            If TemporaryJobCode <> "" Then
		//                                sprWeek1.Col = 7
		//                                sprWeek1.Text = TemporaryJobCode
		//                                sprWeek1.Col = 8
		//                                sprWeek1.Text = TemporaryStep
		//                            End If
		//                            sprWeek1.Col = 5
		//                            sprWeek1.Text = CurrOper
		//                            sprWeek1.Col = 6
		//                            sprWeek1.Text = CurrSAPCode
		//                            sprWeek1.Col = DateArray(i, 1)
		//
		//                            sprWeek1.ForeColor = BLUE
		//                            sprWeek1.Text = Round(TotalHours, 2)

		//                            lbPayrollHrs.Caption = "Total Exception Hours:"
		//                            lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                            NeedToAddRow1 = True
		//                            Exit For
		//                        Else
		//                            If NeedToAddRow2 Then
		//                                CurrRow2 = CurrRow2 + 1
		//                            End If
		//                            sprWeek2.Row = CurrRow2
		//                            If TemporaryJobCode <> "" Then
		//                                sprWeek2.Col = 7
		//                                sprWeek2.Text = TemporaryJobCode
		//                                sprWeek2.Col = 8
		//                                sprWeek2.Text = TemporaryStep
		//                            End If
		//                            sprWeek2.Col = 5
		//                            sprWeek2.Text = CurrOper
		//                            sprWeek2.Col = 6
		//                            sprWeek2.Text = CurrSAPCode
		//                            sprWeek2.Col = DateArray(i, 1)
		//
		//                            sprWeek2.ForeColor = BLUE
		//                            sprWeek2.Text = Round(TotalHours, 2)
		//
		//                            lbPayrollHrs.Caption = "Total Exception Hours:"
		//                            lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                            NeedToAddRow2 = True
		//                            Exit For
		//                        End If
		//                    End If
		//                Next i
		//                TotalHours = 0
		//                CurrOper = ""
		//                CurrSAPCode = oRec("a_a_type")
		//                SchedTime = Clean(oRec("sched_time_code"])
		//                WorkDate = Format$(oRec("shift_start"), "m/d/yyyy")
		//                '****                    '  *
		//                '****
		//            End If
		//        Loop
		//
		//        'start here
		//        For i = 0 To 13
		//            If DateArray(i, 0) = WorkDate Then
		//                If DateArray(i, 2) = 0 Then
		//                    '**********
		//                    '**********
		//                    If NeedToAddRow1 Then
		//                        CurrRow1 = CurrRow1 + 1
		//                        NeedToAddRow1 = False
		//                    End If
		//                    sprWeek1.Row = CurrRow1
		//                    sprWeek1.Col = 5
		//                    If sprWeek1.Text = "" Then
		//                        sprWeek1.Text = CurrOper
		//                        sprWeek1.Col = 6
		//                        sprWeek1.Text = CurrSAPCode
		//                        If TemporaryJobCode <> "" Then
		//                            sprWeek1.Col = 7
		//                            sprWeek1.Text = TemporaryJobCode
		//                            sprWeek1.Col = 8
		//                            sprWeek1.Text = TemporaryStep
		//                        End If
		//                    End If
		//                    sprWeek1.Col = DateArray(i, 1)
		//
		//                    sprWeek1.ForeColor = BLUE
		//                    sprWeek1.Text = Round(TotalHours, 2)
		//                    '**********
		//                    lbPayrollHrs.Caption = "Total Exception Hours:"
		//                    lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                    Exit For
		//
		//                Else
		//                    '**********
		//                    '**********
		//                    If NeedToAddRow2 Then
		//                        CurrRow2 = CurrRow2 + 1
		//                        NeedToAddRow2 = False
		//                    End If
		//                    sprWeek2.Row = CurrRow2
		//                    sprWeek2.Col = 5
		//                    If sprWeek2.Text = "" Then
		//                        sprWeek2.Text = CurrOper
		//                        sprWeek2.Col = 6
		//                        sprWeek2.Text = CurrSAPCode
		//                        If TemporaryJobCode <> "" Then
		//                            sprWeek2.Col = 7
		//                            sprWeek2.Text = TemporaryJobCode
		//                            sprWeek2.Col = 8
		//                            sprWeek2.Text = TemporaryStep
		//                        End If
		//                    End If
		//                    sprWeek2.Col = DateArray(i, 1)
		//
		//                    sprWeek2.ForeColor = BLUE
		//                    sprWeek2.Text = Round(TotalHours, 2)
		//                    '*********
		//
		//                    lbPayrollHrs.Caption = "Total Exception Hours:"
		//                    lbTotalHrs.Caption = Round(lbTotalHrs.Caption + TotalHours, 2)
		//                    Exit For
		//
		//                End If
		//            End If
		//        Next i
		//        If gPayPeriod = CurrPayPeriod Then
		//            cmdSave.Visible = True
		//            cmdSave.Enabled = True
		//        End If
		//    End If
		//
		//    Screen.MousePointer = vbDefault
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
			sStringText = "spSelect_OtherEmployeeGridList ";

			sStringText = sStringText + modGlobal.Shared.gPayrollYear.ToString() + "," + modGlobal.Shared.gPayPeriod.ToString() + " ";

			oCmd.CommandText = sStringText;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			int GridRow = 0;

			while ( !oRec.EOF )
			{
				GridRow++;
				ViewModel.sprEmployeeList.MaxRows = GridRow;
				ViewModel.sprEmployeeList.Row = GridRow;

				//does employee have a schedule?
				ocmd2.CommandText = "sp_GetIndPPShifts '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
				orec2 = ADORecordSetHelper.Open(ocmd2, "");
				if ( orec2.EOF )
				{
					NoSchedule = true;
				}
				else
				{
					NoSchedule = false;
					//does employee have exceptions?
					ocmd2.CommandText = "sp_GetIndPPException '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
					orec2 = ADORecordSetHelper.Open(ocmd2, "");
					NoExceptions = orec2.EOF;

					//does employee have leave?
					oCmd3.CommandText = "sp_GetIndPPLeave '" + modGlobal.Clean(oRec["employee_id"]) + "','" + ViewModel.CurrStartDate + "','" + ViewModel.CurrEndDate + "'";
					oRec3 = ADORecordSetHelper.Open(oCmd3, "");
					NoLeave = oRec3.EOF;
				}
				ViewModel.sprEmployeeList.Col = 1;
				ViewModel.sprEmployeeList.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeCheckBox;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				if ( modGlobal.Clean(oRec["TodayOKflag"]) == "N" )
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
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["unit_code"]);
				ViewModel.sprEmployeeList.Col = 6;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["position_code"]);
				ViewModel.sprEmployeeList.Col = 7;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["job_code_id"]);
				ViewModel.sprEmployeeList.Col = 8;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = Convert.ToDateTime(oRec["TFD_hire_date"]).ToString("M/d/yyyy");
				ViewModel.sprEmployeeList.Col = 9;
				ViewModel.sprEmployeeList.Lock = true;
				ViewModel.sprEmployeeList.TypeHAlign = FarPoint.ViewModels.CellHorizontalAlignment.Center;
				ViewModel.sprEmployeeList.Text = modGlobal.Clean(oRec["union_code"]);
				ViewModel.sprEmployeeList.Col = 10;
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.sprEmployeeList.Text = Convert.ToString(modGlobal.GetVal(oRec["per_sys_id"]));

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

		public void ClearFields()
		{

			ViewModel.lbTotalHrs.Text = "0";
			ViewModel.CurrGroupCode = "";
			ViewModel.CurrBenefit = "";

		}

		//
		[UpgradeHelpers.Events.Handler]
		internal void cboAAType1_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper orec2 = null;

			if ( ViewModel.cboAAType1.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			ViewModel.SchedTime = "";
			ViewModel.CurrSAPCode = "";
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
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAAType2_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper orec2 = null;

			if ( ViewModel.cboAAType2.SelectedIndex < 0 )
			{
				return ;
			} //no selection

			ViewModel.SchedTime = "";
			ViewModel.CurrSAPCode = "";
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
			//        SchedTime = Clean(oRec("time_code_id"])
			//        CurrSAPCode = Clean(oRec("a_a_type"])
			}

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
				PrepareReportDate();
			}
			else
			{
				ViewModel.CurrStartDate = "";
				ViewModel.CurrEndDate = "";
				ViewManager.ShowMessage("Unable to recall Pay Period Data", "Individual Time Card Reporting", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
				return ;
			}

			if ( ViewModel.CurrEmpID != "" )
			{
				FillTimeCard();
				FormatTimeCard();
			}

			PrepareReportDate();
			RefreshEmployeeList();


			if ( modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
			{
				ViewModel.cmdOKToPay.Enabled = false;
				ViewModel.cmdSave.Enabled = false;
				ViewModel.cmdPrint.Enabled = false;
			}
			else
			{
				ViewModel.cmdOKToPay.Enabled = true;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdApply1_Click(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsFireUpload PayrollCL = Container.Resolve<clsFireUpload>();
			//string SAPActivityType = ""; //letter + job_code

			string CurrTimeCode = "";
			PTSProject.clsFireUpload cWorkOrder = Container.Resolve<clsFireUpload>();

			bool NeedRefresh = false;
			bool RecordChange = false;

			if ( ViewModel.SelectedRow1 == 0 )
			{
				return ;
			}

			if ( !ViewModel.PayRollExist )
			{
				AddEmployeePayRoll();
			}

			if ( ~EditApply(1) != 0 )
			{
				return ;
			}

			ViewModel.sprWeek1.Row = ViewModel.SelectedRow1;

			PayrollCL.PPcalendar_year = modGlobal.Shared.gPayrollYear;
			PayrollCL.PPpay_period = modGlobal.Shared.gPayPeriod;
			PayrollCL.PPper_sys_id = ViewModel.CurrPersID;

			double sOTHours = 0;

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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate2 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtMo1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									System.DateTime TempDate3 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtMo1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									System.DateTime TempDate4 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo1.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									System.DateTime TempDate5 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtMo1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtMo1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate7 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate7)) ? TempDate7.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtMo1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate9 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate9)) ? TempDate9.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate10 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate10)) ? TempDate10.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate11 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate11)) ? TempDate11.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate12 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate12)) ? TempDate12.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
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
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
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
							else if ( sOTHours >= Double.Parse(ViewModel.txtTu1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate15 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate15)) ? TempDate15.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu1.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									//error
									System
										.DateTime TempDate16 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate16)) ? TempDate16.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate17 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate17)) ? TempDate17.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtTu1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtTu1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate18 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate18)) ? TempDate18.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtTu1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate19 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate19)) ? TempDate19.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate20 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate20)) ? TempDate20.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate21 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate21)) ? TempDate21.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate22 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate22)) ? TempDate22.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate23 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate23)) ? TempDate23.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate24 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate24)) ? TempDate24.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtWe1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate25 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate25)) ? TempDate25.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtWe1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate26 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate26)) ? TempDate26.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe1.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									//error
									System
										.DateTime TempDate27 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate27)) ? TempDate27.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate28 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate28)) ? TempDate28.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtWe1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtWe1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate29 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate29)) ? TempDate29.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtWe1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate30 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate30)) ? TempDate30.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records inserted
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate31 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate31)) ? TempDate31.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate32 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate32)) ? TempDate32.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
							}
							else
							{
								//error
								System
									.DateTime TempDate33 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate33)) ? TempDate33.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate34 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate34)) ? TempDate34.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate35 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate35)) ? TempDate35.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtTh1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate36 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate36)) ? TempDate36.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtTh1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate37 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate37)) ? TempDate37.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate38 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate38)) ? TempDate38.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate39 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate39)) ? TempDate39.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate40 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate40)) ? TempDate40.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtTh1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtTh1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate41 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate41)) ? TempDate41.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtTh1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate42 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate42)) ? TempDate42.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate43 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate43)) ? TempDate43.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
			}

			//Friday
			ViewModel.sprWeek1.Col = 20;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag))) )
			{
				ViewModel.txtFr1.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek1.Text)).ToString();
			}
			ViewModel.sprWeek1.Col = 13;
			PayrollDate = Convert.ToString(ViewModel.DateArray[4, 0]);
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate46 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate46)) ? TempDate46.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate47 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate47)) ? TempDate47.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtFr1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate48 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate48)) ? TempDate48.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtFr1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate49 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate49)) ? TempDate49.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 records needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr1.Tag)))) != 0 )
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
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate51 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Insert this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate51)) ? TempDate51.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate52 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate52)) ? TempDate52.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtFr1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtFr1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
								else if ( sOTHours >= Double.Parse(ViewModel.txtFr1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate54 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate54)) ? TempDate54.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... need 2 rows
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate55 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate55)) ? TempDate55.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate56 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate56)) ? TempDate56.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate57 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate57)) ? TempDate57.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate58 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate58)) ? TempDate58.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate59 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate59)) ? TempDate59.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtSa1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate60 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate60)) ? TempDate60.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtSa1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate61 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate61)) ? TempDate61.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate62 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate62)) ? TempDate62.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate63 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Insert this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate63)) ? TempDate63.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate64 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate64)) ? TempDate64.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtSa1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtSa1.Text) > 0 )
							{ //insert logic...

								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate65 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate65)) ? TempDate65.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtSa1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate66 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate66)) ? TempDate66.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate67 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate67)) ? TempDate67.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate68 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate68)) ? TempDate68.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate69 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate69)) ? TempDate69.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate70 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate70)) ? TempDate70.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate71 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate71)) ? TempDate71.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtSu1.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate72 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate72)) ? TempDate72.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtSu1.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate73 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate73)) ? TempDate73.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 rows needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu1.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate74 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate74)) ? TempDate74.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate75 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate75)) ? TempDate75.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate76 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate76)) ? TempDate76.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtSu1.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtSu1.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate77 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate77)) ? TempDate77.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtSu1.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate78 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate78)) ? TempDate78.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 rows needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate79 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate79)) ? TempDate79.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu1.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate80 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate80)) ? TempDate80.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate81 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate81)) ? TempDate81.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			PTSProject.clsFireUpload cWorkOrder = Container.Resolve<clsFireUpload>();

			bool NeedRefresh = false;
			bool RecordChange = false;

			if ( ViewModel.SelectedRow2 == 0 )
			{
				return ;
			}

			if ( !ViewModel.PayRollExist )
			{
				AddEmployeePayRoll();
			}

			if ( ~EditApply(2) != 0 )
			{
				return ;
			}

			ViewModel.sprWeek2.Row = ViewModel.SelectedRow2;

			PayrollCL.PPcalendar_year = modGlobal.Shared.gPayrollYear;
			PayrollCL.PPpay_period = modGlobal.Shared.gPayPeriod;
			PayrollCL.PPper_sys_id = ViewModel.CurrPersID;

			double sOTHours = 0;

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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate2 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtMo2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									System.DateTime TempDate3 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtMo2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									System.DateTime TempDate4 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtMo2.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									System.DateTime TempDate5 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtMo2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtMo2.Text) > 0 )
							{ //insert logic...

								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate7 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate7)) ? TempDate7.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtMo2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate9 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate9)) ? TempDate9.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtMo2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate10 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate10)) ? TempDate10.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate11 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate11)) ? TempDate11.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate12 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate12)) ? TempDate12.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
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
							sOTHours = 0;
							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
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
							else if ( sOTHours >= Double.Parse(ViewModel.txtTu2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate15 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate15)) ? TempDate15.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTu2.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									//error
									System
										.DateTime TempDate16 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate16)) ? TempDate16.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate17 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate17)) ? TempDate17.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtTu2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtTu2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate18 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate18)) ? TempDate18.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtTu2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate19 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate19)) ? TempDate19.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate20 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate20)) ? TempDate20.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTu2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successfull
									}
									else
									{
										//error
										System
											.DateTime TempDate21 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate21)) ? TempDate21.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate22 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate22)) ? TempDate22.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate23 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate23)) ? TempDate23.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate24 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate24)) ? TempDate24.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtWe2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate25 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate25)) ? TempDate25.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtWe2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate26 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate26)) ? TempDate26.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtWe2.Tag)))) != 0 )
								{
									PayrollCL.PPhours = Math.Round((double)(Double.Parse(ViewModel.txtWe2.Text) - sOTHours), 2);
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
								}
								else
								{
									//error
									System
										.DateTime TempDate27 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate27)) ? TempDate27.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate28 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate28)) ? TempDate28.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtWe2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtWe2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate29 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate29)) ? TempDate29.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtWe2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate30 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate30)) ? TempDate30.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records inserted
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate31 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate31)) ? TempDate31.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtWe2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate32 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate32)) ? TempDate32.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate33 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate33)) ? TempDate33.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate34 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate34)) ? TempDate34.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate35 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate35)) ? TempDate35.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtTh2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate36 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate36)) ? TempDate36.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtTh2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate37 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate37)) ? TempDate37.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 rows need to be inserted
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate38 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate38)) ? TempDate38.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtTh2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate39 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate39)) ? TempDate39.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate40 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate40)) ? TempDate40.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtTh2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtTh2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate41 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate41)) ? TempDate41.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtTh2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate42 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate42)) ? TempDate42.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate43 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate43)) ? TempDate43.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtTh2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
			}

			//Friday
			ViewModel.sprWeek2.Col = 20;
			if ( Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)) != Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag))) )
			{
				ViewModel.txtFr2.Tag = Convert.ToInt32(Double.Parse(ViewModel.sprWeek2.Text)).ToString();
			}
			ViewModel.sprWeek2.Col = 13;
			PayrollDate = Convert.ToString(ViewModel.DateArray[11, 0]);
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate46 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate46)) ? TempDate46.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate47 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate47)) ? TempDate47.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtFr2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate48 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate48)) ? TempDate48.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtFr2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate49 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate49)) ? TempDate49.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 records needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtFr2.Tag)))) != 0 )
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
								PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate51 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Insert this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate51)) ? TempDate51.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate52 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate52)) ? TempDate52.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtFr2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtFr2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
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
								else if ( sOTHours >= Double.Parse(ViewModel.txtFr2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate54 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate54)) ? TempDate54.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... need 2 rows
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate55 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate55)) ? TempDate55.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtFr2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate56 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate56)) ? TempDate56.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate57 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate57)) ? TempDate57.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate58 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate58)) ? TempDate58.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate59 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate59)) ? TempDate59.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtSa2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate60 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate60)) ? TempDate60.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtSa2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate61 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate61)) ? TempDate61.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours is less than hours... 2 rows needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSa2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate62 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate62)) ? TempDate62.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate63 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Insert this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate63)) ? TempDate63.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate64 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate64)) ? TempDate64.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtSa2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtSa2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate65 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate65)) ? TempDate65.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtSa2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate66 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate66)) ? TempDate66.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 records needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate67 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate67)) ? TempDate67.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSa2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate68 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate68)) ? TempDate68.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate69 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate69)) ? TempDate69.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			if ( ((int)DateAndTime.DateDiff("d", DateTime.Parse(PayrollDate), ViewModel.SpecialEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) >= 0 )
			{
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
								}
								else
								{
									//error
									System
										.DateTime TempDate70 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record for Deletion Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate70)) ? TempDate70.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								if ( PayrollCL.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
								{
									//Successful
									NeedRefresh = true;
								}
								else
								{
									//error
									System
										.DateTime TempDate71 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Delete this Record Failed.", "Delete Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate71)) ? TempDate71.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else if ( Double.Parse(ViewModel.txtSu2.Text) > 0 )
						{ //update logic
							//NOT ADDED ANY NEEDFILLER LOGIC AT THIS TIME
							sOTHours = 0;

							PayrollCL.PPlast_update_date = DateTime.Now.ToString("MM/dd/yyyy");
							PayrollCL.PPlast_update_by = modGlobal.Shared.gUser;
							PayrollCL.PPpayroll_status_code = ProcessFlag;
							//sOTHour Logic goes here
							if ( sOTHours == 0 )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate72 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate72)) ? TempDate72.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else if ( sOTHours >= Double.Parse(ViewModel.txtSu2.Text) )
							{
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate73 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate73)) ? TempDate73.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
							else
							{
								//sOTHours less than hours... 2 rows needed
								PayrollCL.PPhours = sOTHours;
								if ( PayrollCL.UpdatePersonnelPayroll(Convert.ToInt32(Double.Parse(Convert.ToString(ViewModel.txtSu2.Tag)))) != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate74 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate74)) ? TempDate74.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
								PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text) - sOTHours;
								PayrollCL.PPsap_acttype = "";
								PayrollCL.PPsap_rec_center = "";
								PayrollCL.PPsap_rec_order = "";
								if ( PayrollCL.InsertPersonnelPayroll() != 0 )
								{
								//Successful
								}
								else
								{
									//error
									System
										.DateTime TempDate75 = DateTime.FromOADate(0);
									ViewManager.ShowMessage("Attempt to Update this Record Failed.", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
										out TempDate75)) ? TempDate75.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
								}
							}
						}
						else
						{
							//error
							System
								.DateTime TempDate76 = DateTime.FromOADate(0);
							ViewManager.ShowMessage("Not sure what you're trying to do...", "Update Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
								out TempDate76)) ? TempDate76.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
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
						sOTHours = 0;

						ProcessFlag = "N";
						PayrollCL.PPcreate_date = DateTime.Now.ToString("MM/dd/yyyy");
						PayrollCL.PPcreate_by = modGlobal.Shared.gUser;
						PayrollCL.PPpayroll_status_code = ProcessFlag;
						if ( modGlobal.Clean(ViewModel.txtSu2.Text) != "" )
						{
							if ( Double.Parse(ViewModel.txtSu2.Text) > 0 )
							{ //insert logic...
								//sOTHour Logic goes here
								if ( sOTHours == 0 )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate77 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate77)) ? TempDate77.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else if ( sOTHours >= Double.Parse(ViewModel.txtSu2.Text) )
								{
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text);
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate78 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate78)) ? TempDate78.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}
								else
								{
									//sOTHours less than hours... 2 rows needed
									PayrollCL.PPhours = sOTHours;
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate79 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate79)) ? TempDate79.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
									PayrollCL.PPhours = Double.Parse(ViewModel.txtSu2.Text) - sOTHours;
									PayrollCL.PPsap_acttype = "";
									PayrollCL.PPsap_rec_center = "";
									PayrollCL.PPsap_rec_order = "";
									if ( PayrollCL.InsertPersonnelPayroll() != 0 )
									{
									//successful
									}
									else
									{
										//error
										System
											.DateTime TempDate80 = DateTime.FromOADate(0);
										ViewManager.ShowMessage("Insert Failed!!", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate, out
											TempDate80)) ? TempDate80.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
									}
								}

							}
							else
							{
								//error
								System
									.DateTime TempDate81 = DateTime.FromOADate(0);
								ViewManager.ShowMessage("Not sure what you're trying to do...", "Insert Personnel Payroll for " + ((DateTime.TryParse(PayrollDate,
									out TempDate81)) ? TempDate81.ToString("MM/dd/yyyy") : PayrollDate), UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
							}
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
			PTSProject.clsFireUpload clPayroll = Container.Resolve<clsFireUpload>();
		//
		//    If gSecurity <> "ADM" Then
		//        If clPayroll.CheckPayRollStatus(gPayrollYear, gPayPeriod) Then
		//            If clPayroll.PayrollReconciliation("PayrollStatus") = "Locked" Then
		//                MsgBox "This Payperiod has now been Locked.  Please let Peggy Dundis know you have payroll that needs to be uploaded." _
		//'                    , vbOKOnly, "PTS Payroll Upload"
		//                Exit Sub
		//            End If
		//        End If
		//    End If
		//
		//    Screen.MousePointer = vbHourglass
		//'    MsgBox "This option is under construction", vbOKOnly, "OK To Pay"
		//    If clPayroll.AddPayRollTransferForDate(gUserSAPid, gPayrollYear, gPayPeriod, Format(Now(), "mm/dd/yyyy")); Then
		//        UploadToSAP
		//    End If
		//    Screen.MousePointer = vbDefault
		//    gPayPeriodReportFlag = False
		//    dlgPayrollUpload.Show vbModal
		//
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{


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
		internal void cmdSave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("This option is under construction", "Save Time Card", UpgradeHelpers.Helpers.BoxButtons.OK);
		//    AddEmployeePayRoll
		//    FillTimeCard
		//    FormatTimeCard
		//'   RefreshEmployeeList
		//
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
			ViewModel.CurrPayPeriod = modGlobal.Shared.gPayPeriod;
			ViewModel.CurrEmpID = "";
			ViewModel.CurrPersID = 0;
			ViewModel.CurrStartDate = "";
			ViewModel.CurrEndDate = "";

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

			RefreshEmployeeList();
			LoadLists();
			ViewModel.FirstTime = false;
			ViewModel.cmdSave.Enabled = false;
			ViewModel.cmdPrint.Enabled = false;

		}
		//
		//Private Sub Label3_Click(Index As Integer)
		//
		//End Sub
		//

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
			ViewModel.RecordIsMurrayMorganWO = false;
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
			ViewModel.cmdPrint.Enabled = !(modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod);

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
			else if ( modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
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
			if ( modGlobal.Clean(ViewModel.cboOrder1.Text) == "90007883" || modGlobal.Clean(ViewModel.cboOrder1.Text) == "80011537" )
			{
				ViewManager.ShowMessage("Please do not CHANGE the hours... DELETE record, then ADD. Thank you.", "Murray Morgan WorkOrder", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.RecordIsMurrayMorganWO = true;
			}
			else
			{
				ViewModel.RecordIsMurrayMorganWO = false;
			}
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
			else if ( modGlobal.Shared.gPayPeriod != ViewModel.CurrPayPeriod )
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
			if ( modGlobal.Clean(ViewModel.cboOrder2.Text) == "90007883" || modGlobal.Clean(ViewModel.cboOrder2.Text) == "80011537" )
			{
				ViewManager.ShowMessage("Please do not CHANGE the hours... DELETE record, then ADD. Thank you.", "Murray Morgan WorkOrder", UpgradeHelpers.Helpers.BoxButtons.OK);
				ViewModel.RecordIsMurrayMorganWO = true;
			}
			else
			{
				ViewModel.RecordIsMurrayMorganWO = false;
			}
			ViewModel.frmWeek2.Visible = true;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPayrollOthers DefInstance
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

		public static frmPayrollOthers CreateInstance()
		{
			PTSProject.frmPayrollOthers theInstance = Shared.Container.Resolve<frmPayrollOthers>();
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
			ViewModel.sprEmployeeList.LifeCycleStartup();
			ViewModel.sprTimeSheet.LifeCycleStartup();
			ViewModel.sprWeek2.LifeCycleStartup();
			ViewModel.sprWeek1.LifeCycleStartup();
			ViewModel.frmWeek1.LifeCycleStartup();
			ViewModel.frmWeek2.LifeCycleStartup();
			ViewModel.frmFilterList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprEmployeeList.LifeCycleShutdown();
			ViewModel.sprTimeSheet.LifeCycleShutdown();
			ViewModel.sprWeek2.LifeCycleShutdown();
			ViewModel.sprWeek1.LifeCycleShutdown();
			ViewModel.frmWeek1.LifeCycleShutdown();
			ViewModel.frmWeek2.LifeCycleShutdown();
			ViewModel.frmFilterList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPayrollOthers
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPayrollOthersViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPayrollOthers m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}