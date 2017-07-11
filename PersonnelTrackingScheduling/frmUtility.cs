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

	public partial class frmUtility
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUtilityViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmUtility));
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


		private void frmUtility_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void CreateNewSchedule()
		{
			using ( var async1 = this.Async(true) )
			{
				//Create REG, DDF and ROV
				//Schedule records for selected date range
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;
				DbConnection oConUtil = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				string strCon = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ViewModel.cmdExit.Visible = false;

				string sStartDate = DateTime.Parse(ViewModel.calStart.Text).ToString("M/d/yyyy");
				System.DateTime dtStartDate = DateTime.Parse(DateTime.Parse(ViewModel.calStart.Text).ToString("M/d/yyyy"));
				string sEndDate = DateTime.Parse(ViewModel.calEnd.Text).ToString("M/d/yyyy");
				System.DateTime dtEndDate = DateTime.Parse(DateTime.Parse(ViewModel.calEnd.Text).ToString("M/d/yyyy"));

				if (modGlobal.Shared.gTestMode != 0)
				{
					strCon = "Provider=SQLOLEDB; Data Source=TFDSQL1; Initial Catalog=PTSTestBackup; Integrated Security=SSPI";
				}
				else
				{
					strCon = "Provider=SQLOLEDB; Data Source=TFDSQL1; Initial Catalog=PTSData; Integrated Security=SSPI";
				}
				//    strCon = "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=PTSData; Integrated Security=SSPI"
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
				oConUtil.ConnectionString = strCon;
				oConUtil.Open();
				while ((oConUtil.State == ConnectionState.Connecting))
				{
					//Debug.Print "Connecting to SQL Server....."
				}

				oCmd.Connection = oConUtil;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "sp_LastSchedDate";
				ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
				System.DateTime LastDate = Convert.ToDateTime(oRec["last_date"]);

				if (dtStartDate >= dtEndDate)
				{
					ViewManager.ShowMessage("End Date must be greater than Start Date", "Create New Schedule", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					this.Return();
					return ;
				}

				if (LastDate > dtStartDate)
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(()
							=> ViewManager.ShowMessage("Delete Current Schedule Records occuring after selected Start Date?", "Create New Schedule", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.No)
							{
								dtStartDate = LastDate.AddDays(1);
								sStartDate = dtStartDate.ToString("M/d/yyyy");
							}
							else if (Response == UpgradeHelpers.Helpers.DialogResult.Cancel)
							{
								this.Return();
								return ;
							}
							else
							{
								//Delete Overlapping Schedule Records
								oCmd.CommandText = "spClearSchedule '" + sStartDate + "','" + LastDate.AddDays(1).ToString("M/d/yyyy") + "'";
								oCmd.ExecuteNonQuery();
							}
						});
						}
				async1.Append(() =>
					{

						ViewModel.lbStatus.Visible = true;
						ViewModel.pb1.Visible = true;

						//Create REG Schedule Records
						ViewModel.lbStatus.Text = "Creating New REG Schedule Records";
						ViewModel.pb1.Value = 0;
						int RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 164;
						int i = 0;
						oCmd.CommandText = "spCreateSchedREG '" + sStartDate + "','" + sEndDate + "'";
						//    oCmd.CommandText = "spCreateSchedREG_OneTime '" & sStartDate & "','" & sEndDate & "'"
						oRec = ADORecordSetHelper.Open(oCmd, "");


						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "'," + Convert.ToString(oRec["ass_id"]) + ",'REG',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New REG Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creation of New REG Schedule Records Complete";

						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
						for (Response = UpgradeHelpers.Helpers.DialogResult.OK; ((int) Response) <= 10000; Response = (UpgradeHelpers.Helpers.DialogResult) (((int) Response) + 1))
						{
						}

						//Create ROV Schedule Records (position ROV181 & ROV182 & ROV183)
						ViewModel.lbStatus.Text = "Creating New Batt 1 ROV Schedule Records";
						ViewModel.pb1.Value = 0;
						RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 11;
						i = 0;
						oCmd.CommandText = "spCreateSchedROV '" + sStartDate + "','" + sEndDate + "','1'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',559,'REG',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 1 ROV Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating New Batt 2 ROV Schedule Records";
						ViewModel.pb1.Value = 0;
						RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 12;
						i = 0;
						oCmd.CommandText = "spCreateSchedROV '" + sStartDate + "','" + sEndDate + "','2'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',560,'REG',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 2 ROV Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating New Batt 3 ROV Schedule Records";
						ViewModel.pb1.Value = 0;
						RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 12;
						i = 0;
						oCmd.CommandText = "spCreateSchedROV '" + sStartDate + "','" + sEndDate + "','3'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{

							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',1283,'REG',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 3 ROV Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creation of ROV Schedule Records Complete";
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
						for (Response = UpgradeHelpers.Helpers.DialogResult.OK; ((int) Response) <= 10000; Response = (UpgradeHelpers.Helpers.DialogResult) (((int) Response) + 1))
						{
						}

						//Create DDF Schedule Records (position DBT181 & DBT182 & DBT183)
						ViewModel.lbStatus.Text = "Creating New Batt 1 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 6;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF '" + sStartDate + "','" + sEndDate + "','1'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',561,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 1 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating New Batt 2 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF '" + sStartDate + "','" + sEndDate + "','2'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',562,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 2 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating New Batt 3 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF '" + sStartDate + "','" + sEndDate + "','3'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',1284,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New Batt 3 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creation of DDF Schedule Records Complete";
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
						for (Response = UpgradeHelpers.Helpers.DialogResult.OK; ((int) Response) <= 10000; Response = (UpgradeHelpers.Helpers.DialogResult) (((int) Response) + 1))
						{
						}

						//Create DDF Schedule Records (position DBT181 & DBT182 & DBT183) for
						//Special Non-Paramedic Personnel in Paramedic positions
						ViewModel.lbStatus.Text = "Creating Special Batt 1 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						RecFactor = ((int) DateAndTime.DateDiff("d", dtStartDate, dtEndDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) * 6;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF_2 '" + sStartDate + "','" + sEndDate + "','1'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',561,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating Special Batt 1 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating Special Batt 2 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF_2 '" + sStartDate + "','" + sEndDate + "','2'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',562,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating Special Batt 2 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creating Special Batt 3 DDF Schedule Records";
						ViewModel.pb1.Value = 0;
						i = 0;
						oCmd.CommandText = "spCreateSchedDDF_2 '" + sStartDate + "','" + sEndDate + "','3'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						while(!oRec.EOF)
						{
							oCmd.CommandText = "spInsertSchedule '" + Convert.ToString(oRec["shift_start"]) + "','" + Convert.ToString(oRec["employee_id"]) + "',1284,'DDF',0,'" + Convert.ToString(oRec["job_code"]) + "'," + Convert.ToString(oRec["step"]) + ",'" +
							                   DateTime.Now.ToString("M/d/yyyy") + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
							//UPGRADE_ISSUE: (2064) ADODB.Command property oCmd.State was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							while ((oCmd.getState() == ((int) ConnectionState.Executing)))
							{
								//Debug.Print "Executing Insert... " & I
							}
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating Special Batt 3 DDF Schedule Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creation of Special DDF Schedule Records Complete";
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
						for (Response = UpgradeHelpers.Helpers.DialogResult.OK; ((int) Response) <= 10000; Response = (UpgradeHelpers.Helpers.DialogResult) (((int) Response) + 1))
						{
						}

						//Create Payroll Signoff records for new scheduling Period
						//Check for existing SignOff Records for requested date span
						oCmd.CommandText = "sp_LastSignOffDate";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						LastDate = Convert.ToDateTime(oRec["last_date"]);

						if (LastDate > dtStartDate)
						{
							//Delete Overlapping Schedule Records
							oCmd.CommandText = "spClearSignOff '" + sStartDate + "','" + LastDate.AddDays(1).ToString("M/d/yyyy") + "'";
							oCmd.ExecuteNonQuery();
						}
						else
						{
							dtStartDate = LastDate;
							sStartDate = dtStartDate.ToString("M/d/yyyy");
						}

						//Create SignOff Records
						ViewModel.lbStatus.Text = "Creating New PayRoll SignOff Records";
						oCmd.CommandText = "sp_GetSignOffYear '" + sStartDate + "','" + sEndDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						ViewModel.pb1.Value = 0;
						RecFactor = (int) DateAndTime.DateDiff("d", DateTime.Parse(sStartDate), DateTime.Parse(sEndDate), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
						i = 0;


						while(!oRec.EOF)
						{
							oCmd.CommandText = "spCreateSignOff " + Convert.ToString(oRec["calendar_year"]) + ",'" + sStartDate + "','" + sEndDate + "','" + modGlobal.Shared.gUser + "','1'";
							oCmd.ExecuteNonQuery();
							oCmd.CommandText = "spCreateSignOff " + Convert.ToString(oRec["calendar_year"]) + ",'" + sStartDate + "','" + sEndDate + "','" + modGlobal.Shared.gUser + "','2'";
							oCmd.ExecuteNonQuery();
							oCmd.CommandText = "spCreateSignOff " + Convert.ToString(oRec["calendar_year"]) + ",'" + sStartDate + "','" + sEndDate + "','" + modGlobal.Shared.gUser + "','3'";
							oCmd.ExecuteNonQuery();
							oRec.MoveNext();
							i++;
							if ((i / RecFactor) * 100 > 100)
							{
								ViewModel.pb1.Value = 100;
							}
							else
							{
								ViewModel.pb1.Value = (i / RecFactor) * 100;
							}
							ViewModel.lbStatus.Text = "Creating New PayRoll SignOff Records  -  " + ViewModel.pb1.Value.ToString() + "% Complete";
						}
						;
						ViewModel.lbStatus.Text = "Creation of PayRoll SignOff Records Complete";
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: http://www.vbtonet.com/ewis/ewi6021.aspx
						for (Response = UpgradeHelpers.Helpers.DialogResult.OK; ((int) Response) <= 30000; Response = (UpgradeHelpers.Helpers.DialogResult) (((int) Response) + 1))
						{
						}
						ViewModel.lbStatus.Visible = false;
						ViewModel.pb1.Value = 0;
						ViewModel.pb1.Visible = false;

						oRec.Close();
						oRec = null;
						oCmd = null;
						UpgradeHelpers.DB.TransactionManager.DeEnlist(oConUtil);
						oConUtil.Close();
						oConUtil = null;
						ViewModel.cmdExit.Visible = true;

					});
			}
		}

		public void ArchiveRecords()
		{
			ViewModel.cmdExit.Visible = false;
			ViewManager.ShowMessage("The Ability to Archive Records is under construction.", "Under Construction", UpgradeHelpers.Helpers.BoxButtons.OK);
			ViewModel.cmdExit.Visible = true;
		}

		public void CreateCalendar()
		{
			ViewModel.cmdExit.Visible = false;
			ViewManager.ShowMessage("The Ability to Create Calendar Records is under construction.", "Under Construction", UpgradeHelpers.Helpers.BoxButtons.OK);
			ViewModel.cmdExit.Visible = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboAction_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Call Appropriate Sub Routine based
			//Combo box selection
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			ViewModel.cmdExit.Visible = false;

			switch( ViewModel.cboAction.SelectedIndex)
			{
				case -1 :
					return;
				case 0 :
					ViewModel.lbStart.Visible = true;
					ViewModel.lbEnd.Visible = true;
					ViewModel.calStart.Visible = true;
					ViewModel.calEnd.Visible = true;
					ViewModel.cmdGo.Text = "Create New Schedule Records Now";
					ViewModel.cmdGo.Tag = "Sched";
					ViewModel.cmdGo.Visible = true;
					ViewModel.cmdCancel.Visible = true;
					ViewModel.lbLastDateTitle.Visible = true;
					ViewModel.lbLastDate.Visible = true;
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_LastSchedDate";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.lbLastDate.Text = Convert.ToDateTime(oRec["last_date"]).ToString("M/d/yyyy");
					ViewModel.chkRemove.Visible = false;
					ViewModel.frArchive.Visible = false;
					break;
				case 1 :
					ViewModel.lbStart.Visible = true;
					ViewModel.lbEnd.Visible = true;
					ViewModel.calStart.Visible = true;
					ViewModel.calEnd.Visible = true;
					ViewModel.chkRemove.Visible = true;
					ViewModel.frArchive.Visible = true;
					ViewModel.cmdGo.Text = "Archive Records Now";
					ViewModel.cmdGo.Tag = "Arch";
					ViewModel.cmdGo.Visible = true;
					ViewModel.cmdCancel.Visible = true;
					ViewModel.lbLastDateTitle.Visible = false;
					ViewModel.lbLastDate.Visible = false;
					break;
				case 2 :
					ViewModel.lbStart.Visible = true;
					ViewModel.lbEnd.Visible = true;
					ViewModel.calStart.Visible = true;
					ViewModel.calEnd.Visible = true;
					ViewModel.cmdGo.Text = "Create New Calendar Records Now";
					ViewModel.cmdGo.Tag = "Cal";
					ViewModel.cmdGo.Visible = true;
					ViewModel.cmdCancel.Visible = true;
					ViewModel.chkRemove.Visible = false;
					ViewModel.frArchive.Visible = false;
					ViewModel.lbLastDateTitle.Visible = false;
					ViewModel.lbLastDate.Visible = false;
					break;
			}
			ViewModel.cmdExit.Visible = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdExit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Close form
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdGo_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				using ( var async2 = this.Async() )
				{
					switch(Convert.ToString(ViewModel.cmdGo.Tag))
					{
						case "Sched" :
							async2.Append(() =>
								{
									CreateNewSchedule();
								});
							break;
						case "Arch" :
							ArchiveRecords();
							break;
						case "Cal" :
							CreateCalendar();
							break;
					}
				}
			}

				}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.cmdExit.Visible = true;
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmUtility DefInstance
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

		public static frmUtility CreateInstance()
		{
			PTSProject.frmUtility theInstance = Shared.Container.Resolve< frmUtility>();
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
			ViewModel.frArchive.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.frArchive.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmUtility
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmUtilityViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmUtility m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}