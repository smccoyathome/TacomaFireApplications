using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public class clsEMSInformation
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsEMSInformation));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cEMSPersonnelImmunizations = null;
			cEMSPerImmunizeID = 0;
			cEMSEmployeeID = "";
			cEMSImmunizeID = 0;
			cEMSImmunizeDate = "";
			cEMSCreatedDate = "";
			cEMSCreatedBy = "";
			cEMSResultflag = "";
			cEMSComments = "";
		}

		//*******************************************************
		//**    EMS Immunization Tracking                      **
		//**    Properties & Methods                           **
		//*******************************************************


		//*************************************************
		//**             Private Class Variables         **
		//*************************************************
		//EMSPersonnelImmunizations
		public virtual ADORecordSetHelper _cEMSPersonnelImmunizations { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cEMSPersonnelImmunizations
		{
			get
			{
				if (_cEMSPersonnelImmunizations == null)
				{
					_cEMSPersonnelImmunizations = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cEMSPersonnelImmunizations;
			}
			set
			{
				_cEMSPersonnelImmunizations = value;
			}
		}

		public virtual int cEMSPerImmunizeID { get; set; }

		public virtual string cEMSEmployeeID { get; set; }

		public virtual int cEMSImmunizeID { get; set; }

		public virtual string cEMSImmunizeDate { get; set; }

		public virtual string cEMSCreatedDate { get; set; }

		public virtual string cEMSCreatedBy { get; set; }

		public virtual string cEMSResultflag { get; set; }

		public virtual string cEMSComments { get; set; }

		//**********************************************
		//**         Public Class Methods             **
		//**********************************************
		//EMSPersonnelImmunizations
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper EMSPersonnelImmunizations
		{
			get
			{
				return cEMSPersonnelImmunizations;
			}
			set
			{
				cEMSPersonnelImmunizations = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EMSPerImmunizeID
		{
			get
			{
				return cEMSPerImmunizeID;
			}
			set
			{
				cEMSPerImmunizeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSEmployeeID
		{
			get
			{
				return cEMSEmployeeID;
			}
			set
			{
				cEMSEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int EMSImmunizeID
		{
			get
			{
				return cEMSImmunizeID;
			}
			set
			{
				cEMSImmunizeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSImmunizeDate
		{
			get
			{
				return cEMSImmunizeDate;
			}
			set
			{
				cEMSImmunizeDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSCreatedDate
		{
			get
			{
				return cEMSCreatedDate;
			}
			set
			{
				cEMSCreatedDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSCreatedBy
		{
			get
			{
				return cEMSCreatedBy;
			}
			set
			{
				cEMSCreatedBy = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSResultflag
		{
			get
			{
				return cEMSResultflag;
			}
			set
			{
				cEMSResultflag = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EMSComments
		{
			get
			{
				return cEMSComments;
			}
			set
			{
				cEMSComments = value;
			}
		}


		//*********************************************
		//**     Public Class Functions/Subroutines  **
		//*********************************************

		public int GetEMSPersonnelImmunizationsByID(int lRecordID)
		{
			//Retrieve specific record from EMSPersonnelImmunizations table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				oCmd.CommandText = "spSelect_EMSPersonnelImmunizationsByID " + lRecordID.ToString();
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEMSPerImmunizeID = Convert.ToInt32(modGlobal.GetVal(oRec["per_immunize_id"]));
					cEMSEmployeeID = modGlobal.Clean(oRec["employee_id"]);
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					cEMSImmunizeID = Convert.ToInt32(modGlobal.GetVal(oRec["immunize_id"]));
					if (modGlobal.Clean(oRec["immunize_date"]) == "")
					{
						cEMSImmunizeDate = "";
					}
					else
					{
						cEMSImmunizeDate = Convert.ToDateTime(oRec["immunize_date"]).ToString("MM/dd/yyyy");
					}
					cEMSCreatedDate = Convert.ToDateTime(oRec["created_date"]).ToString("MM/dd/yyyy HH:mm:ss");
					cEMSCreatedBy = modGlobal.Clean(oRec["created_by"]);
					if (modGlobal.Clean(oRec["result_flag"]) == "")
					{
						cEMSResultflag = "";
					}
					else
					{
						cEMSResultflag = modGlobal.Clean(oRec["result_flag"]);
					}
					if (modGlobal.Clean(oRec["comments"]) == "")
					{
						cEMSComments = "";
					}
					else
					{
						cEMSComments = modGlobal.Clean(oRec["comments"]);
					}
				}
				else
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetEMSPersonnelImmunizationsByEmp(string sEmpID)
		{
			//Retrieve records from EMSPersonnelImmunizations table
			//for specific employee
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				oCmd.CommandText = "spSelect_EMSPersonnelImmunizationsByEmployee '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEMSPersonnelImmunizations = oRec;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int InsertEMSPersonnelImmunizations()
		{
			//Insert Record into EMSPersonnelImmunizations table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spInsert_EMSPersonnelImmunizations '" + cEMSEmployeeID + "', ";
				SqlString = SqlString + cEMSImmunizeID.ToString() + ", ";
				if (cEMSImmunizeDate == "")
				{
					SqlString = SqlString + "NULL, '";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSImmunizeDate + "', '";
				}
				SqlString = SqlString + cEMSCreatedDate + "', '" + cEMSCreatedBy + "', ";
				if (cEMSResultflag == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSResultflag + "', ";
				}
				if (cEMSComments == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSComments + "' ";
				}

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				//UPGRADE_WARNING: (2065) ADODB.Recordset method oRec.NextRecordset has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
				oRec = oRec.NextRecordSet();
				if (!oRec.EOF)
				{
					cEMSPerImmunizeID = Convert.ToInt32(oRec[0]);
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int DeleteEMSPersonnelImmunizations(int lRecordID)
		{
			//Delete Record from EMSPersonnelImmunizations table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spDelete_EMSPersonnelImmunizations " + lRecordID.ToString() + " ";

				oCmd.CommandText = SqlString;
				oRec = ADORecordSetHelper.Open(oCmd, "");
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

			return result;
		}

		public int GetEMSForSecurity(string sEmpID)
		{
			// Get Employee Information for EMSPersonnelImmunizations
			// Record View/Edit Security
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_EMSUpdateSecurity '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEMSPersonnelImmunizations = oRec;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetImmunizationQueryResults(string sBatt, string sUnit, string sShift, string sGroup, string sName, int iType, string sStartDate, string sEndDate, int iFlag)
		{
			//Retrieve records for Immunization Query Screen
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string sSQLString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				sSQLString = "spReport_ImmunizationQueryFiltered ";
				if (modGlobal.Clean(sBatt) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + modGlobal.Clean(sBatt) + "', ";
				}
				if (modGlobal.Clean(sUnit) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + modGlobal.Clean(sUnit) + "', ";
				}
				if (modGlobal.Clean(sShift) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + modGlobal.Clean(sShift) + "', ";
				}
				if (modGlobal.Clean(sGroup) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + modGlobal.Clean(sGroup) + "', ";
				}
				if (modGlobal.Clean(sName) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					sSQLString = sSQLString + "'" + modGlobal.Clean(sName) + "', ";
				}
				//UPGRADE_WARNING: (1068) GetVal(iType) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if (Convert.ToDouble(modGlobal.GetVal(iType)) == 0)
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					sSQLString = sSQLString + Convert.ToString(modGlobal.GetVal(iType)) + ", ";
				}
				if (modGlobal.Clean(sStartDate) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					System.DateTime TempDate = DateTime.FromOADate(0);
					sSQLString = sSQLString + "'" + ((DateTime.TryParse(sStartDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : sStartDate) + "', ";
				}
				if (modGlobal.Clean(sEndDate) == "")
				{
					sSQLString = sSQLString + "NULL, ";
				}
				else
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					sSQLString = sSQLString + "'" + ((DateTime.TryParse(sEndDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : sEndDate) + "', ";
				}
				if (modGlobal.Clean(iFlag) == "")
				{
					sSQLString = sSQLString + "NULL ";
				}
				else
				{
					//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					sSQLString = sSQLString + Convert.ToString(modGlobal.GetVal(iFlag)) + " ";
				}

				oCmd.CommandText = sSQLString;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				if (!oRec.EOF)
				{
					cEMSPersonnelImmunizations = oRec;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int UpdateEMSPersonnelImmunizations()
		{
			//Insert Record into EMSPersonnelImmunizations table
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{
				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				SqlString = "";

				SqlString = "spUpdate_EMSPersonnelImmunizations " + cEMSPerImmunizeID.ToString() + ", ";
				if (cEMSImmunizeDate == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSImmunizeDate + "', ";
				}
				if (cEMSResultflag == "")
				{
					SqlString = SqlString + "NULL, ";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSResultflag + "', ";
				}
				if (cEMSComments == "")
				{
					SqlString = SqlString + "NULL ";
				}
				else
				{
					SqlString = SqlString + "'" + cEMSComments + "' ";
				}

				oCmd.CommandText = SqlString;
				oCmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public int GetAdminONLYSecurity(string sEmpID)
		{
			// Get Employee Information for EMSPersonnelImmunizations
			// Record View/Edit Security
			int result = 0;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;

			try
			{

				result = -1;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;
				oCmd.CommandText = "spSelect_AdminONLYSecurity '" + sEmpID + "' ";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if (!oRec.EOF)
				{
					cEMSPersonnelImmunizations = oRec;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}