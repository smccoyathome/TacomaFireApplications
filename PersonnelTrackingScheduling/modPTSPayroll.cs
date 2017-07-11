using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public static class modPTSPayroll
	{

		//***********************************************
		//** Global Constants, Variable
		//** Functions and Subroutines for
		//** PTSPayroll Processing
		//** --------------------------------------------
		//** Requires clsFireUpload.cls file to be
		//** add to project
		//************************************************

		//***BAPI control objects***

		//'***Constants for SAP connection object - Test***
		//'***CURRENTLY NOT WORKING... USE QA2 ***
		//Public Const SAPUSER = "firefire"
		//Public Const SAPPASSWORD = "h2oh2o"
		//Public Const SAPDEST = "QAS"
		//Public Const SAPCLIENT = "010"
		//Public Const SAPSYSNUM = "00"
		//Public Const SAPAPPSERVER = "sapqasci01"
		//Public Const SAPLANGUAGE = "EN"

		//***Constants for SAP CATS APPR LITE connection object - Test***
		//Public Const SAPUSER = "firefire"
		//Public Const SAPPASSWORD = "h2oh2o"
		//Public Const SAPDEST = "QA2"
		//Public Const SAPCLIENT = "010"
		//Public Const SAPSYSNUM = "00"
		//Public Const SAPAPPSERVER = "sapprdci01"
		//Public Const SAPLANGUAGE = "EN"

		//'***Constants for SAP connection object - Special Test***
		//Public Const SAPUSER = "firefire"
		//Public Const SAPPASSWORD = "h2oh2o"
		//Public Const SAPDEST = "QA2"
		//Public Const SAPCLIENT = "010"
		//Public Const SAPSYSNUM = "00"
		//Public Const SAPAPPSERVER = "sapqa2ci01"
		//Public Const SAPLANGUAGE = "EN"

		//'***Constants for SAP connection object - Production***
		public const string SAPUSER = "firefire";
		public const string SAPPASSWORD = "h2oh2o";
		public const string SAPDEST = "PRD";
		public const string SAPCLIENT = "010";
		public const string SAPSYSNUM = "00";
		public const string SAPAPPSERVER = "sapprdci01";
		public const string SAPLANGUAGE = "EN";

		//***ADO data connections
		internal static DbConnection oPayroll
		{
			get
			{
				if ( Shared._oPayroll == null)
				{
					Shared.
						_oPayroll = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}
				return Shared. _oPayroll;
			}
			set
			{
				Shared.
					_oPayroll = value;
			}
		}


		//*** Global Payroll Variables

		//***Payroll Upload Counters

		internal static int ConnectToPayrollTransfer()
		{
			//Create a connection to TFDSQL1..PTSPayroll db with specific Application
			//userid and password

			int result = 0;
			try
			{
				result = -1;

				if (modGlobal.Shared.gTestMode != 0)
				{
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
					oPayroll.ConnectionString = "Provider=SQLOLEDB; Data Source=TFDSQL1; Initial Catalog=PTSTestPayroll; uid=SAPPayroll;pwd=SAPPayroll ;Persist Security Info=true";
					oPayroll.Open();
				}
				else
				{
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: http://www.vbtonet.com/ewis/ewi7010.aspx
					oPayroll.ConnectionString = "Provider=SQLOLEDB; Data Source=TFDSQL1; Initial Catalog=PTSPayroll; uid=SAPPayroll;pwd=SAPPayroll ;Persist Security Info=true";
					oPayroll.Open();
				}
				//    oPayroll.Open "Provider=SQLOLEDB; Data Source=TFDSQL2; Initial Catalog=PTSPayroll; uid=SAPPayroll;pwd=SAPPayroll"

				if (oPayroll.State != ConnectionState.Open)
				{
					result = 0;
				}
			}
			catch (System.Exception excep)
			{
				Shared.ViewManager.ShowMessage("ConnectToPayrollTransferError - '" + excep.Message + "'", "Connect To Payroll Transfer", UpgradeHelpers.Helpers.BoxButtons.OK);
				result = 0;
			}
			return result;
		}

		internal static int ConnectToSAP()
		{

			int result = 0;
			result = -1;
			//Set SAP objects
			Shared.
				oBAPICtrl = new Stubs._SAPBAPIControlLib.SAPBAPIControl();
			Shared.
				oLogonCtrl = new Stubs._SAPLogonCtrl.SAPLogonControl();
			Shared.
				oBAPICtrl.Connection = Shared. oLogonCtrl.NewConnection();

			dynamic oBAPIConnection = Shared. oBAPICtrl.Connection;
			//connect to R/3
			//UPGRADE_TODO: (1067) Member User is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.User = SAPUSER;
			//UPGRADE_TODO: (1067) Member Password is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.Password = SAPPASSWORD;
			//UPGRADE_TODO: (1067) Member Destination is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.Destination = SAPDEST;
			//UPGRADE_TODO: (1067) Member Client is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.Client = SAPCLIENT;
			//UPGRADE_TODO: (1067) Member SystemNumber is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.SystemNumber = SAPSYSNUM;
			//UPGRADE_TODO: (1067) Member ApplicationServer is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.ApplicationServer = SAPAPPSERVER;
			//UPGRADE_TODO: (1067) Member Language is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.Language = SAPLANGUAGE;

			//UPGRADE_TODO: (1067) Member Logon is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			oBAPIConnection.Logon(0, true);

//UPGRADE_TODO: (1067) Member IsConnected is not defined in type object(...). More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
if (Convert.ToDouble(oBAPIConnection.IsConnected) != 1)
{
				Shared.ViewManager.ShowMessage("Connect to SAP Error - '" + UpgradeHelpers.Helpers.Information.Err().Description + "'", "Connect to SAP", UpgradeHelpers.Helpers.BoxButtons.OK);
				result = 0;
			}

			return result;
		}

		internal static void UploadToSAP()
		{
			//Process all records in PayrollTransfer Table that have been approved by
			//gUserSAPid (contains SAP employee id (long) of approving individual)
			PTSProject.clsFireUpload cFireUp = Shared.Container.Resolve< clsFireUpload>();
			int ErrorEncountered = 0;
			string CurrStatus = "";
			Shared.

				gTotalSAPRecords = 0;
			Shared.
				gTotalSAPInserts = 0;
			Shared.
				gTotalSAPDeletes = 0;
			Shared.
				gTotalSAPChanges = 0;
			Shared.
				gTotalSAPErrors = 0;

			if (~ConnectToPayrollTransfer() != 0)
			{
				//error msg
				Shared.ViewManager.ShowMessage("Unable to make SQL Connection to PTSPayroll database", System.Diagnostics.FileVersionInfo.
						GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName);
				return;
			}

			if (~cFireUp.GetPayrollTransfer(Shared.gUserSAPid) != 0)
			{
				Shared.ViewManager.ShowMessage("No Payroll Transfer Records returned", System.Diagnostics.FileVersionInfo.GetVersionInfo(
					System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName, UpgradeHelpers.Helpers.BoxButtons.OK);
				oPayroll = null;
				return;
			}


			while(!cFireUp.PayrollTransfer.EOF)
			{
				//***************************************
				//**  Logic to Determine Record should **
				//**  be Inserted, Deleted or Changed  **
				//***************************************
				ErrorEncountered = 0;
				(Shared.

				gTotalSAPRecords)++;

				if (~cFireUp.GetReconciliationLastAction(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
				{
					CurrStatus = "I"; //No Reconciliation Records, Insert
				}
				else
				{
					CurrStatus = cFireUp.PRStatus;
				}

				switch(CurrStatus)
				{
					case "I" :  //** No Reconciliation records exist 
						//Insert new record 
						if (~InsertRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
						{
							//error msg
							ErrorEncountered = -1;
							(Shared.
							gTotalSAPErrors)++;
						}
						else
						{
							(Shared.
							gTotalSAPInserts)++;
						}
						break;
					case "F" :  //** Last Insert Attempt Failed 
						//Insert new record 
						if (~InsertRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
						{
							//error msg
							ErrorEncountered = -1;
							(Shared.
							gTotalSAPErrors)++;
						}
						else
						{
							(Shared.
							gTotalSAPInserts)++;
						}
						break;
					case "S" :  //** Last record was a successful insert 
						//Determine if Delete or Change 
						if (Convert.ToDouble(cFireUp.PayrollTransfer["catshours"]) == 0)
						{
							//Delete record
							if (~DeleteRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
							{
								//error msg
								ErrorEncountered = -1;
								(Shared.
								gTotalSAPErrors)++;
							}
							else
							{
								(Shared.
								gTotalSAPDeletes)++;
							}
						}
						else
						{
							//Change record
							if (~DeleteRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
							{
								//error msg
								ErrorEncountered = -1;
								(Shared.
								gTotalSAPErrors)++;
							}
							if (~ErrorEncountered != 0)
							{
								if (~InsertRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
								{
									//error msg
									ErrorEncountered = -1;
									(Shared.
									gTotalSAPErrors)++;
								}
								else
								{
									(Shared.
									gTotalSAPChanges)++;
								}
							}
						}
						break;
					case "X" :  //** Last record was Failed delete attempt 
						//Determine if Delete or Change 
						if (Convert.ToDouble(cFireUp.PayrollTransfer["catshours"]) == 0)
						{
							//Delete record
							if (~DeleteRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
							{
								//error msg
								ErrorEncountered = -1;
								(Shared.
								gTotalSAPErrors)++;
							}
							else
							{
								(Shared.
								gTotalSAPDeletes)++;
							}
						}
						else
						{
							//Change record
							if (~DeleteRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
							{
								//error msg
								ErrorEncountered = -1;
								(Shared.
								gTotalSAPErrors)++;
							}
							if (~ErrorEncountered != 0)
							{
								if (~InsertRecord(Convert.ToInt32(cFireUp.PayrollTransfer["payroll_sys_id"])) != 0)
								{
									//error msg
									ErrorEncountered = -1;
									(Shared.
									gTotalSAPErrors)++;
								}
								else
								{
									(Shared.
									gTotalSAPChanges)++;
								}
							}
						}
						break;
				}
				cFireUp.PayrollTransfer.MoveNext();
			}
			;

			if (~cFireUp.DeletePayrollTransferForUser(Shared.gUserSAPid) != 0)
			{
				//error msg
				Shared.ViewManager.ShowMessage("Delete PayrollTransfer - '" + UpgradeHelpers.Helpers.Information.Err().Description + "'", "Upload to SAP", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

			oPayroll = null;

		}

		internal static int InsertRecord(int lSysID)
		{
			//** Insert Payroll record in SAP
			int result = 0;
			PTSProject.clsFireUpload cFireUp = Shared.Container.Resolve< clsFireUpload>();

			try
			{

				if (~ConnectToSAP() != 0)
				{
					Shared.ViewManager.ShowMessage("Unable to Connect to SAP", "Insert Record to SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
					return 0;
				}


				//set the data entry profile for uploading multiple CATS records
				Shared.
					profile = "FIRE SCH";

				//create the BOR object and set the key values (for an instance-dependent method)
				//Set oTestObject = oBAPICtrl.GetSAPObject("ZISUACCNT", vkont, gpart)

				//create the BOR object for an instance-independent method
				Shared.
					oBORObject = Shared. oBAPICtrl.GetSAPObject("BUS7024", null, null, null, null, null, null, null, null, null, null);

				//create the structure object(s) of the BOR method
				Shared.
					oSAPStruc = Shared. oBAPICtrl.DimAs(Shared.oBORObject, "Insert", "CatsrecordsIn");
				Shared.
					oSAPReturnStruc = Shared. oBAPICtrl.DimAs(Shared.oBORObject, "Insert", "Return");
				Shared.
					oSAPConfirmStruc = Shared. oBAPICtrl.DimAs(Shared.oBORObject, "Insert", "CatsrecordsOut");

				//fill the SAP struc from the SQL resultset (SAP struct's are 1-based
				//and we will only send one row at a time into the BAPI)
				if (~cFireUp.GetPayrollTransferBySysID(lSysID) != 0)
				{
					//error msg
					Shared.ViewManager.ShowMessage("Unable to GetPayrollTransferBySysID", "Insert Record to SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
					return 0;
				}

				//UPGRADE_TODO: (1067) Member AppendRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oSAPStruc.AppendRow();

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["WORKDATE"] = cFireUp.PayrollRS["workdate"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["ACTTYPE"] = cFireUp.PayrollRS["acttype"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["REC_CCTR"] = cFireUp.PayrollRS["rec_cctr"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["EMPLOYEENUMBER"] = cFireUp.PayrollRS["employeenumber"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["REC_ORDER"] = modGlobal.Clean(cFireUp.PayrollRS["rec_order"]);

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["ACTIVITY"] = cFireUp.PayrollRS["activity"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["WBS_ELEMENT"] = cFireUp.PayrollRS["wbs_element"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["ABS_ATT_TYPE"] = cFireUp.PayrollRS["abs_att_type"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["PAYSCALEGROUP"] = cFireUp.PayrollRS["payscalegroup"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["PAYSCALELEVEL"] = cFireUp.PayrollRS["payscalelevel"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["CATSHOURS"] = cFireUp.PayrollRS["catshours"];

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["UNIT"] = cFireUp.PayrollRS["unit"];


				//call the method (BAPI), import the structure oSAPStruc, get return values
				//and confirmation record
				//UPGRADE_WARNING: (7006) The Named argument Return was not resolved and corresponds to the following expression oSAPReturnStruc More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_WARNING: (7006) The Named argument CatsrecordsOut was not resolved and corresponds to the following expression oSAPConfirmStruc More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_WARNING: (7006) The Named argument CatsrecordsIn was not resolved and corresponds to the following expression oSAPStruc More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_WARNING: (7006) The Named argument profile was not resolved and corresponds to the following expression profile More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_TODO: (1067) Member Insert is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oBORObject.Insert(Shared.profile, Shared. oSAPStruc, Shared. oSAPConfirmStruc, Shared. oSAPReturnStruc);

				//UPGRADE_TODO: (1067) Member RowCount is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				if (Convert.ToDouble(Shared.oSAPConfirmStruc.RowCount) < 1)
				{
					//       if there are return errors, write those to the return structure

					//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					Shared.
						oRtnRow = Shared. oSAPReturnStruc.Rows.Item(1);
					//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					cFireUp.PRReturnmsg = Convert.ToString(Shared.oRtnRow.Value("MESSAGE"));
					cFireUp.PRStatus = "F";
					cFireUp.PRCounter = "";
					//UPGRADE_TODO: (1067) Member RowCount is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					for (int k = 1; k <= Convert.ToDouble(Shared.oSAPReturnStruc.RowCount); k++)
					{
						//UPGRADE_TODO: (1067) Member DeleteRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						Shared.
							oSAPReturnStruc.DeleteRow();
					}
				}
				else
				{
					//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					Shared.
						oConfRow = Shared. oSAPConfirmStruc.Rows.Item(1);
					//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					cFireUp.PRCounter = Convert.ToString(Shared.oConfRow.Value("COUNTER"));
					cFireUp.PRReturnmsg = "Record successfully inserted";
					cFireUp.PRStatus = "S";
					//UPGRADE_TODO: (1067) Member DeleteRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					Shared.
						oSAPConfirmStruc.DeleteRow();
					result = -1;
				}
				cFireUp.PRWorkdate = Convert.ToString(cFireUp.PayrollRS["workdate"]);
				cFireUp.PRActtype = Convert.ToString(cFireUp.PayrollRS["acttype"]);
				cFireUp.PREmployeenumber = Convert.ToInt32(cFireUp.PayrollRS["employeenumber"]);
				cFireUp.PRRec_order = Convert.ToString(cFireUp.PayrollRS["rec_order"]);
				cFireUp.PRActivity = Convert.ToString(cFireUp.PayrollRS["activity"]);
				cFireUp.PRWbs_element = Convert.ToString(cFireUp.PayrollRS["wbs_element"]);
				cFireUp.PRAbs_att_type = Convert.ToString(cFireUp.PayrollRS["abs_att_type"]);
				cFireUp.PRPayscalegroup = Convert.ToString(cFireUp.PayrollRS["payscalegroup"]);
				cFireUp.PRPayscalelevel = Convert.ToString(cFireUp.PayrollRS["payscalelevel"]);
				cFireUp.PRCatshours = Convert.ToDouble(cFireUp.PayrollRS["catshours"]);
				cFireUp.PRUnit = Convert.ToString(cFireUp.PayrollRS["unit"]);
				cFireUp.PRApproved_by = Convert.ToInt32(cFireUp.PayrollRS["approved_by"]);
				cFireUp.PRUploadDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				cFireUp.PRPayroll_sys_id = Convert.ToInt32(cFireUp.PayrollRS["payroll_sys_id"]);

				cFireUp.PPpayroll_status_code = cFireUp.PRStatus;
				cFireUp.PPlast_update_by = modGlobal.Shared.gUser;

				if (~cFireUp.InsertReconciliation() != 0)
				{
					//error msg
					Shared.ViewManager.ShowMessage("Unable to InsertReconciliation", "Insert Record to SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				if (~cFireUp.UpdatePersonnelPayrollStatus(lSysID) != 0)
				{
					//error msg
					Shared.ViewManager.ShowMessage("Unable to UpdatePersonnelPayrollStatus", "Insert Record to SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

				//UPGRADE_TODO: (1067) Member DeleteRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oSAPStruc.DeleteRow();
			}
			catch (System.Exception excep)
			{
				Shared.ViewManager.ShowMessage("InsertRecordError - '" + excep.Message + "'", "Insert Record into SAP", UpgradeHelpers.Helpers.BoxButtons.OK);
				return 0;
			}
			return result;
		}


		internal static int DeleteRecord(int inCtr)
		{
			//Delete payroll record from SAP
			int result = 0;
			PTSProject.clsFireUpload cFireUp = Shared.Container.Resolve< clsFireUpload>();

			try
			{

				result = -1;
				if (~cFireUp.GetReconciliationForDelete(inCtr) != 0)
				{
					//error msg & exit
					Shared.ViewManager.ShowMessage("DeleteRecordError - '" + UpgradeHelpers.Helpers.Information.Err().Description + "'", "Delete SAP Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					return 0;
				}

				if (~ConnectToSAP() != 0)
				{
					//error msg
					Shared.ViewManager.ShowMessage("Unable to Connect to SAP", "Delete Record in SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
					return 0;
				}
				//set the data entry profile
				Shared.
					profile = "FIRE SCH";

				//create the BOR object for an instance-independent method
				Shared.
					oBORObject = Shared. oBAPICtrl.GetSAPObject("BUS7024", null, null, null, null, null, null, null, null, null, null);

				//create the structure object(s) of the BOR method
				Shared.
					oSAPStruc = Shared. oBAPICtrl.DimAs(Shared.oBORObject, "Delete", "Catsrecords");
				Shared.
					oSAPReturnStruc = Shared. oBAPICtrl.DimAs(Shared.oBORObject, "Delete", "Return");

				//fill the SAP struct and call the BAPI
				//UPGRADE_TODO: (1067) Member AppendRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oSAPStruc.AppendRow();

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow = Shared. oSAPStruc.Rows.Item(1);
				//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oRow.Value["COUNTER"] = cFireUp.PRCounter;

				//Alternate method if data type problems occur
				//ctr = cFireUp.PRCounter
				//Set oRow = oSAPStruc.Rows.Item(1)
				//oRow.Value("COUNTER") = ctr


				//call the method (BAPI), import the structure oSAPStruc, get return values
				//and confirmation record
				//UPGRADE_WARNING: (7006) The Named argument Return was not resolved and corresponds to the following expression oSAPReturnStruc More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_WARNING: (7006) The Named argument Catsrecords was not resolved and corresponds to the following expression oSAPStruc More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_WARNING: (7006) The Named argument profile was not resolved and corresponds to the following expression profile More Information: http://www.vbtonet.com/ewis/ewi7006.aspx
				//UPGRADE_TODO: (1067) Member Delete is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				Shared.
					oBORObject.Delete(Shared.profile, Shared. oSAPStruc, Shared. oSAPReturnStruc);

				//UPGRADE_TODO: (1067) Member RowCount is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				if (Convert.ToDouble(Shared.oSAPReturnStruc.RowCount) > 0)
				{
					//    if there are return errors, write those to the return structure
					//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					Shared.
						oRtnRow = Shared. oSAPReturnStruc.Rows.Item(1);
					//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
					if (Convert.ToString(Shared.oRtnRow.Value("TYPE")) == "E")
					{
						//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						cFireUp.PRReturnmsg = Convert.ToString(Shared.oRtnRow.Value("MESSAGE"));
						cFireUp.PRStatus = "X";
						//UPGRADE_TODO: (1067) Member RowCount is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						for (int k = 1; k <= Convert.ToDouble(Shared.oSAPReturnStruc.RowCount); k++)
						{
							//UPGRADE_TODO: (1067) Member DeleteRow is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
							Shared.
								oSAPReturnStruc.DeleteRow();
						}
						Shared.ViewManager.ShowMessage("Deleting from SAP failed.", System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName);
						result = 0;
					}
					else
					{
						//UPGRADE_TODO: (1067) Member Value is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
						cFireUp.PRReturnmsg = Convert.ToString(Shared.oRtnRow.Value("MESSAGE"));
						cFireUp.PRStatus = "D";
					}
				}
				else
				{
					cFireUp.PRReturnmsg = "Record successfully deleted";
					cFireUp.PRStatus = "D";
				}
				cFireUp.PRUploadDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

				cFireUp.PPpayroll_status_code = cFireUp.PRStatus;
				cFireUp.PPlast_update_by = modGlobal.Shared.gUser;

				if (~cFireUp.InsertReconciliation() != 0)
				{
					//error msg
					Shared.ViewManager.ShowMessage("Unable to InsertReconciliation", "Delete Record in SAP Database", UpgradeHelpers.Helpers.BoxButtons.OK);
					result = 0;
				}
				if (~cFireUp.UpdatePersonnelPayrollStatus(inCtr) != 0)
				{
					//error msg
				}
			}
			catch (System.Exception excep)
			{
				Shared.ViewManager.ShowMessage("Delete Record Error '" + excep.Message + "'", "Delete SAP Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return 0;
			}

			return result;
		}

		internal static int CheckPayrollForLeaveDelete(string Empid, string PayrollDate, string TimeCode)
		{
			int result = 0;
			PTSProject.clsFireUpload clPayroll = Shared.Container.Resolve< clsFireUpload>();
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				strSQL = "spSelect_PersonnelPayRollForLeaveDelete '" + Empid + "','";
				strSQL = strSQL + PayrollDate + "','" + TimeCode + "' ";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					if (modGlobal.Clean(oRec["payroll_status_code"]) == "N")
					{
						if (clPayroll.GetTimeCodeByKOT(TimeCode) != 0)
						{
							if (clPayroll.TCfillercode != "")
							{
								if (clPayroll.GetAssociatedPersonnelPayRollRecord(Convert.ToInt32(oRec["payroll_sys_id"]), clPayroll.TCfillercode) != 0)
								{
									if (clPayroll.DeletePersonnelPayroll(Convert.ToInt32(Double.Parse(clPayroll.PPFillerCodeID))) != 0)
									{
										//success
									}
									else
									{
										result = 0;
									}
								}
							}
						}
						if (clPayroll.DeletePersonnelPayroll(Convert.ToInt32(oRec["payroll_sys_id"])) != 0)
						{
							//success
						}
						else
						{
							result = 0;
						}
					}
					else
					{
						Shared.ViewManager.ShowMessage(
							"Please contact Peggy Dundas or your BC!!  Let them know you are deleting/changing a Leave Record where Payroll has been uploaded to SAP!!", "Payroll Record has been Uploaded!!"
							, UpgradeHelpers.Helpers.BoxButtons.OK);
						result = 0;
					}
				}
			}
			catch (System.Exception excep)
			{
				Shared.ViewManager.ShowMessage("Error Checking Payroll For Leave Delete - '" + excep.Message + "'", "Payroll Record has been Uploaded!!", UpgradeHelpers.Helpers.BoxButtons.OK);
				return 0;
			}
			return result;
		}

		internal static int CheckPayrollForDate(string Empid, string PayrollDate)
		{
			int result = 0;
			PTSProject.clsFireUpload clPayroll = Shared.Container.Resolve< clsFireUpload>();
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			try
			{
				result = 0;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				strSQL = "spSelect_PersonnelPayRollForDate '" + Empid + "', '";
				strSQL = strSQL + PayrollDate + "' ";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					result = -1;
				}
			}
			catch (System.Exception excep)
			{
				Shared.ViewManager.ShowMessage("Error Checking Payroll For Date - '" + excep.Message + "'", "Check Payroll!!", UpgradeHelpers.Helpers.BoxButtons.OK);
				return 0;
			}
			return result;
		}

		public static UpgradeHelpers.Interfaces.IViewManager ViewManager
		{
			get
			{
				return Shared.ViewManager;
			}
		}

		public static UpgradeHelpers.Interfaces.IIocContainer Container
		{
			get
			{
				return Shared.Container;
			}
		}

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
				oBAPICtrl = null;
				oLogonCtrl = null;
				oBORObject = null;
				oSAPStruc = null;
				oSAPReturnStruc = null;
				oSAPConfirmStruc = null;
				oRow = null;
				oRtnRow = null;
				oConfRow = null;
				profile = "";
				_oPayroll = null;
				gUserSAPid = 0;
				gPayPeriodReportFlag = false;
				gTotalSAPRecords = 0;
				gTotalSAPInserts = 0;
				gTotalSAPDeletes = 0;
				gTotalSAPChanges = 0;
				gTotalSAPErrors = 0;
				sError = "";
			}

			public virtual Stubs._SAPBAPIControlLib.SAPBAPIControl oBAPICtrl { get; set; }

			public virtual Stubs._SAPLogonCtrl.SAPLogonControl oLogonCtrl { get; set; }

			public virtual dynamic oBORObject { get; set; }

			public virtual dynamic oSAPStruc { get; set; }

			public virtual dynamic oSAPReturnStruc { get; set; }

			public virtual dynamic oSAPConfirmStruc { get; set; }

			public virtual dynamic oRow { get; set; }

			public virtual dynamic oRtnRow { get; set; }

			public virtual dynamic oConfRow { get; set; }

			public virtual string profile { get; set; }

			public virtual DbConnection _oPayroll { get; set; }

			public virtual int gUserSAPid { get; set; }

			public virtual bool gPayPeriodReportFlag { get; set; }

			public virtual int gTotalSAPRecords { get; set; }

			public virtual int gTotalSAPInserts { get; set; }

			public virtual int gTotalSAPDeletes { get; set; }

			public virtual int gTotalSAPChanges { get; set; }

			public virtual int gTotalSAPErrors { get; set; }

			public virtual string sError { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}