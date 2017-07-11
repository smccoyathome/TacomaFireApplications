using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsEPCR
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsEPCR));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cePCRTransfer = null;
			cMessageID = 0;
			cMessageSeqNumber = 0;
			cOrganizationID = "";
			cPWD = "";
			cUsername = "";
			cRunNumber = "";
			cIncidentDate = "";
			cIncLocation = "";
			cIncCity = "";
			cIncLatitude = "";
			cIncLongitude = "";
			cIncZipCode = "";
			cIncTelephone = "";
			cDispatchComplaint = "";
			cDispatchComplaintCode = "";
			cUnitDispatch = "";
			cUnitEnroute = "";
			cUnitOnscene = "";
			cUnitTransfer = "";
			cUnitTransComplete = "";
			cUnitAvailable = "";
			cAgencyName = "";
			cAgencyNumber = "";
			cUnitID = "";
		}



		//********************************************************
		//**    ePCR Class                                      **
		//********************************************************

		//********************************************************
		//**             Private Class Variables                **
		//********************************************************

		//Private Class Variables
		//ePCRTransfer
		public virtual ADORecordSetHelper _cePCRTransfer { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cePCRTransfer
		{
			get
			{
				if (_cePCRTransfer == null)
				{
					_cePCRTransfer = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cePCRTransfer;
			}
			set
			{
				_cePCRTransfer = value;
			}
		}

		public virtual int cMessageID { get; set; }

		public virtual int cMessageSeqNumber { get; set; }

		public virtual string cOrganizationID { get; set; }

		public virtual string cPWD { get; set; }

		public virtual string cUsername { get; set; }

		public virtual string cRunNumber { get; set; }

		public virtual string cIncidentDate { get; set; }

		public virtual string cIncLocation { get; set; }

		public virtual string cIncCity { get; set; }

		public virtual string cIncLatitude { get; set; }

		public virtual string cIncLongitude { get; set; }

		public virtual string cIncZipCode { get; set; }

		public virtual string cIncTelephone { get; set; }

		public virtual string cDispatchComplaint { get; set; }

		public virtual string cDispatchComplaintCode { get; set; }

		public virtual string cUnitDispatch { get; set; }

		public virtual string cUnitEnroute { get; set; }

		public virtual string cUnitOnscene { get; set; }

		public virtual string cUnitTransfer { get; set; }

		public virtual string cUnitTransComplete { get; set; }

		public virtual string cUnitAvailable { get; set; }

		public virtual string cAgencyName { get; set; }

		public virtual string cAgencyNumber { get; set; }

		public virtual string cUnitID { get; set; }



		//***************************************************
		//**         Class Public Properties               **
		//***************************************************
		//ePCRTransfer
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper ePCRTransfer
		{
			get
			{
				return cePCRTransfer;
			}
			set
			{
				cePCRTransfer = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MessageID
		{
			get
			{
				return cMessageID;
			}
			set
			{
				cMessageID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int MessageSeqNumber
		{
			get
			{
				return cMessageSeqNumber;
			}
			set
			{
				cMessageSeqNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string OrganizationID
		{
			get
			{
				return cOrganizationID;
			}
			set
			{
				cOrganizationID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string PWD
		{
			get
			{
				return cPWD;
			}
			set
			{
				cPWD = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string Username
		{
			get
			{
				return cUsername;
			}
			set
			{
				cUsername = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string RunNumber
		{
			get
			{
				return cRunNumber;
			}
			set
			{
				cRunNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncidentDate
		{
			get
			{
				return cIncidentDate;
			}
			set
			{
				cIncidentDate = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncLocation
		{
			get
			{
				return cIncLocation;
			}
			set
			{
				cIncLocation = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncCity
		{
			get
			{
				return cIncCity;
			}
			set
			{
				cIncCity = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncLatitude
		{
			get
			{
				return cIncLatitude;
			}
			set
			{
				cIncLatitude = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncLongitude
		{
			get
			{
				return cIncLongitude;
			}
			set
			{
				cIncLongitude = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncZipCode
		{
			get
			{
				return cIncZipCode;
			}
			set
			{
				cIncZipCode = cIncZipCode;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string IncTelephone
		{
			get
			{
				return cIncTelephone;
			}
			set
			{
				cIncTelephone = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DispatchComplaint
		{
			get
			{
				return cDispatchComplaint;
			}
			set
			{
				cDispatchComplaint = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DispatchComplaintCode
		{
			get
			{
				return cDispatchComplaintCode;
			}
			set
			{
				cDispatchComplaintCode = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitDispatch
		{
			get
			{
				return cUnitDispatch;
			}
			set
			{
				cUnitDispatch = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitEnroute
		{
			get
			{
				return cUnitEnroute;
			}
			set
			{
				cUnitEnroute = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitOnscene
		{
			get
			{
				return cUnitOnscene;
			}
			set
			{
				cUnitOnscene = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitTransfer
		{
			get
			{
				return cUnitEnroute;
			}
			set
			{
				cUnitTransfer = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitTransComplete
		{
			get
			{
				return cUnitTransComplete;
			}
			set
			{
				cUnitTransComplete = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitAvailable
		{
			get
			{
				return cUnitAvailable;
			}
			set
			{
				cUnitAvailable = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string AgencyName
		{
			get
			{
				return cAgencyName;
			}
			set
			{
				cAgencyName = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string AgencyNumber
		{
			get
			{
				return cAgencyNumber;
			}
			set
			{
				cAgencyNumber = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string UnitID
		{
			get
			{
				return cUnitID;
			}
			set
			{
				cUnitID = value;
			}
		}


		//**********************************************
		//**         Public Class Methods             **
		//**********************************************

		public int GetNewTransferRecord(int lUnitID)
		{


			//Retrieve Data items for Requested New ePCR Transfer Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NewePCRRecord " + lUnitID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");


				if (!orec.EOF)
				{
					ClearePCR();
					//Set ePCRTransfer  Class Variables
					cMessageID = Convert.ToInt32(orec["message_id"]);
					cMessageSeqNumber = 1;
					cOrganizationID = "001";
					cPWD = "tfd";
					cUsername = "tfd";
					cRunNumber = IncidentMain.Clean(orec.GetField("run_number"));
					cIncidentDate = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("incident_date")), "YYYY-MM-DDThh:mm:ss");
					cIncLocation = IncidentMain.Clean(orec.GetField("inc_location"));
					cIncCity = IncidentMain.Clean(orec.GetField("inc_city"));
					cIncLatitude = IncidentMain.Clean(orec.GetField("inc_latitude"));
					cIncLongitude = IncidentMain.Clean(orec.GetField("inc_longitude"));
					cIncZipCode = IncidentMain.Clean(orec.GetField("inc_zipcode"));
					cIncTelephone = IncidentMain.Clean(orec.GetField("inc_telephone"));
					cDispatchComplaint = IncidentMain.Clean(orec.GetField("dispatch_complaint"));
					cDispatchComplaintCode = IncidentMain.Clean(orec.GetField("dispatch_complaint_code"));
					cUnitDispatch = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_dispatch")), "YYYY-MM-DDThh:mm:ss");
					if (IncidentMain.CleanDate(orec.GetField("unit_enroute")) == "")
					{
						cUnitEnroute = "";
					}
					else
					{
						cUnitEnroute = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_enroute")), "YYYY-MM-DDThh:mm:ss");
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_onscene")) == "")
					{
						cUnitOnscene = "";
					}
					else
					{
						cUnitOnscene = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_onscene")), "YYYY-MM-DDThh:mm:ss");
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_transfer")) == "")
					{
						cUnitTransfer = "";
					}
					else
					{
						cUnitTransfer = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_transfer")), "YYYY-MM-DDThh:mm:ss");
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_trans_complete")) == "")
					{
						cUnitTransComplete = "";
					}
					else
					{
						cUnitTransComplete = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_trans_complete")), "YYYY-MM-DDThh:mm:ss");
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_available")) == "")
					{
						cUnitAvailable = "";
					}
					else
					{
						cUnitAvailable = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_available")), "YYYY-MM-DDThh:mm:ss");
					}
					cAgencyName = IncidentMain.Clean(orec.GetField("agency_name"));
					cAgencyNumber = IncidentMain.Clean(orec.GetField("agency_number"));
					cUnitID = IncidentMain.Clean(orec.GetField("unit"));
					return -1;
				}
				else
				{
					return 0;
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


		public int GetePCRTransferRecord(int lUnitID)
		{


			//Retrieve existining ePCR Transfer Record
			//Set Class  Variables to Retrieved Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ePCRTransfer " + lUnitID.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");


				if (!orec.EOF)
				{
					ClearePCR();
					//Set ePCRTransfer  Class Variables
					cMessageID = Convert.ToInt32(orec["message_id"]);
					cMessageSeqNumber = Convert.ToInt32(orec["message_seq_number"]);
					cOrganizationID = Convert.ToString(orec["organization_id"]);
					cPWD = IncidentMain.Clean(orec.GetField("pwd"));
					cUsername = IncidentMain.Clean(orec.GetField("username"));
					cRunNumber = IncidentMain.Clean(orec.GetField("run_number"));
					cIncidentDate = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("incident_date")), "YYYY-MM-DDThh:mm:ss");
					cIncLocation = IncidentMain.Clean(orec.GetField("inc_location"));
					cIncCity = IncidentMain.Clean(orec.GetField("inc_city"));
					cIncLatitude = IncidentMain.Clean(orec.GetField("inc_latitude"));
					cIncLongitude = IncidentMain.Clean(orec.GetField("inc_longitude"));
					cIncZipCode = IncidentMain.Clean(orec.GetField("inc_zipcode"));
					cIncTelephone = IncidentMain.Clean(orec.GetField("inc_telephone"));
					cDispatchComplaint = IncidentMain.Clean(orec.GetField("dispatch_complaint"));
					cDispatchComplaintCode = IncidentMain.Clean(orec.GetField("dispatch_complaint_code"));
					if (IncidentMain.CleanDate(orec.GetField("unit_dispatch")) != "")
					{
						cUnitDispatch = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_dispatch")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitDispatch = "";
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_enroute")) != "")
					{
						cUnitEnroute = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_enroute")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitEnroute = "";
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_onscene")) != "")
					{
						cUnitOnscene = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_onscene")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitOnscene = "";
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_transfer")) != "")
					{
						cUnitTransfer = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_transfer")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitTransfer = "";
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_trans_complete")) != "")
					{
						cUnitTransComplete = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_trans_complete")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitTransComplete = "";
					}
					if (IncidentMain.CleanDate(orec.GetField("unit_available")) != "")
					{
						cUnitAvailable = UpgradeHelpers.Helpers.StringsHelper.Format(IncidentMain.CleanDate(orec.GetField("unit_available")), "YYYY-MM-DDThh:mm:ss");
					}
					else
					{
						cUnitAvailable = "";
					}
					cAgencyName = IncidentMain.Clean(orec.GetField("agency_name"));
					cAgencyNumber = IncidentMain.Clean(orec.GetField("agency_number"));
					cUnitID = IncidentMain.Clean(orec.GetField("unit_id"));
					return -1;
				}
				else
				{
					return 0;
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

		public void ClearePCR()
		{
			//Clear all ePCRTransfer record fields
			cMessageID = 0;
			cMessageSeqNumber = 0;
			cOrganizationID = "";
			cPWD = "";
			cUsername = "";
			cRunNumber = "";
			cIncidentDate = "";
			cIncLocation = "";
			cIncCity = "";
			cIncLatitude = "";
			cIncLongitude = "";
			cIncZipCode = "";
			cIncTelephone = "";
			cDispatchComplaint = "";
			cDispatchComplaintCode = "";
			cUnitDispatch = "";
			cUnitEnroute = "";
			cUnitOnscene = "";
			cUnitTransfer = "";
			cUnitTransComplete = "";
			cUnitAvailable = "";
			cAgencyName = "";
			cAgencyNumber = "";
			cUnitID = "";

		}

		public int AddePCRTransfer()
		{

			//Add AddePCRTransfer Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_ePCRTransfer " + cMessageID.ToString() + "," + cMessageSeqNumber.ToString() + ",";
				SqlString = SqlString + "'" + cOrganizationID + "','" + cPWD + "','" + cUsername + "','" + cRunNumber + "','";
				SqlString = SqlString + cIncidentDate + "','" + cIncLocation + "','" + cIncCity + "','";
				SqlString = SqlString + cIncLatitude + "','" + cIncLongitude + "','" + cIncZipCode + "','" + cIncTelephone + "','" + cDispatchComplaint + "','";
				SqlString = SqlString + cDispatchComplaintCode + "','" + cUnitDispatch + "','";
				SqlString = SqlString + cUnitEnroute + "','" + cUnitOnscene + "','" + cUnitTransfer + "','" + cUnitTransComplete + "','";
				SqlString = SqlString + cUnitAvailable + "','" + cAgencyName + "','" + cAgencyNumber + "','" + cUnitID + "'";

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}


		public int UpdateePCRTransfer()
		{

			//Add UpdateePCRTransfer Record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spUpdate_ePCRTransfer " + cMessageID.ToString() + "," + cMessageSeqNumber.ToString() + ",";
				SqlString = SqlString + "'" + cOrganizationID + "','" + cPWD + "','" + cUsername + "','" + cRunNumber + "','";
				SqlString = SqlString + cIncidentDate + "','" + cIncLocation + "','" + cIncCity + "','";
				SqlString = SqlString + cIncLatitude + "','" + cIncLongitude + "','" + cIncZipCode + "','" + cIncTelephone + "','" + cDispatchComplaint + "','";
				SqlString = SqlString + cDispatchComplaintCode + "','" + cUnitDispatch + "','";
				SqlString = SqlString + cUnitEnroute + "','" + cUnitOnscene + "','" + cUnitTransfer + "','" + cUnitTransComplete + "','";
				SqlString = SqlString + cUnitAvailable + "','" + cAgencyName + "','" + cAgencyNumber + "','" + cUnitID + "'";

				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}


		public int ProcessePCRTransfer(int lMessageID)
		{
			//Create ePCRTransfer xml transfer file

			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			TFDIncident.clsIncident cIncident = Container.Resolve< clsIncident>();
			string FilePath = "", Fileline = "";
			object FSO = null;
			      System.IO.StreamWriter TextStm = null;


			string Header1 = "<?xml version = " + "\"" + "1.0" + "\"" + " encoding = " + "\"" + "UTF-8" + "\"" + " ?> ";
Header1 = Header1 + "<AmbulanceDispatch xmlns:b=" + "\"" + "http://schemas.microsoft.com/BizTalk/2003" + "\"";
Header1 = Header1 + " xmlns:xsi=" + "\"" + "http://www.w3.org/2001/XMLSchema-instance" + "\"";
Header1 = Header1 + " xmlns=" + "\"" + "http://Medusa.Siren.Schemas.AmbulanceDispatch" + "\"";
Header1 = Header1 + " xsi:schemaLocation=" + "\"" + "http://Medusa.Siren.Schemas.AmbulanceDispatch C:\\CAD\\AmbulanceDispatch.xsd" + "\"" + "> ";

try
{
	if (GetePCRTransferRecord(lMessageID) != 0)
	{
		result = -1;
		Fileline = Header1;
		Fileline = Fileline + "<Incident> ";
		//Hardcode Destination Zipcode for EMS Billing extract
		Fileline = Fileline + new System.String(' ', 3) + "<DestinationPostalCode>" + "98408" + "</DestinationPostalCode> ";
		if (cDispatchComplaint != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<DispatchComplaint>" + cDispatchComplaint + "</DispatchComplaint> ";
		}
		if (cDispatchComplaintCode != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<DispatchComplaintCode>" + cDispatchComplaintCode + "</DispatchComplaintCode> ";
		}
		Fileline = Fileline + new System.String(' ', 3) + "<IncidentDateTime>" + cIncidentDate + "</IncidentDateTime> ";
		Fileline = Fileline + new System.String(' ', 3) + "<LocationAddress1>" + cIncLocation + "</LocationAddress1> ";
		if (cIncCity != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationCity>" + cIncCity + "</LocationCity> ";
		}
		Fileline = Fileline + new System.String(' ', 3) + "<LocationCountry>" + "U.S.A." + "</LocationCountry> ";
		if (cIncCity == "Federal Way")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationCounty>" + "King" + "</LocationCounty> ";
		}
		else
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationCounty>" + "Pierce" + "</LocationCounty> ";
		}
		if (cIncLatitude != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationLatitude>" + cIncLatitude + "</LocationLatitude> ";
		}
		if (cIncLongitude != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationLongitude>" + cIncLongitude + "</LocationLongitude> ";
		}
		//Hardcode Location Zipcode for EMS Billing extract
		if (cIncZipCode != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationPostalCode>" + cIncZipCode + "</LocationPostalCode> ";
		}
		else
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationPostalCode>" + "98408" + "</LocationPostalCode> ";
		}
		Fileline = Fileline + new System.String(' ', 3) + "<LocationProv>" + "Washington" + "</LocationProv> ";
		if (cIncTelephone != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<LocationTelephone1>" + cIncTelephone + "</LocationTelephone1> ";
		}
		Fileline = Fileline + new System.String(' ', 3) + "<RunNumber>" + cRunNumber + "</RunNumber> ";
		Fileline = Fileline + "</Incident> ";

		Fileline = Fileline + "<Message> ";
		Fileline = Fileline + new System.String(' ', 3) + "<MessageID>" + cMessageID.ToString() + "</MessageID> ";
		Fileline = Fileline + new System.String(' ', 3) + "<MessageSequenceNumber>" + cMessageSeqNumber.ToString() + "</MessageSequenceNumber> ";
		Fileline = Fileline + new System.String(' ', 3) + "<OrganizationID>001</OrganizationID> ";
		Fileline = Fileline + new System.String(' ', 3) + "<Pwd>" + cPWD + "</Pwd> ";
		Fileline = Fileline + new System.String(' ', 3) + "<Username>" + cUsername + "</Username> ";
		Fileline = Fileline + "</Message> ";

		Fileline = Fileline + "<Misc/> ";
		Fileline = Fileline + "<Outcomes/> ";
		Fileline = Fileline + "<Patient/> ";

		Fileline = Fileline + "<TimesDetails> ";
		Fileline = Fileline + new System.String(' ', 3) + "<DispatchTime>" + cUnitDispatch + "</DispatchTime> ";
		if (cUnitTransComplete != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<ArriveDestinationTime>" + cUnitTransComplete + "</ArriveDestinationTime> ";
		}
		if (cUnitOnscene != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<ArriveSceneTime>" + cUnitOnscene + "</ArriveSceneTime> ";
		}
		if (cUnitAvailable != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<AvailableTime>" + cUnitAvailable + "</AvailableTime> ";
		}
		if (cUnitTransfer != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<DepartSceneTime>" + cUnitTransfer + "</DepartSceneTime> ";
		}
		if (cUnitEnroute != "")
		{
			Fileline = Fileline + new System.String(' ', 3) + "<EnrouteTime>" + cUnitEnroute + "</EnrouteTime> ";
		}
		Fileline = Fileline + "</TimesDetails> ";
		Fileline = Fileline + "<Vehicle> ";
		Fileline = Fileline + new System.String(' ', 3) + "<AgencyName>" + cAgencyName + "</AgencyName> ";
		Fileline = Fileline + new System.String(' ', 3) + "<AgencyNumber>" + cAgencyNumber + "</AgencyNumber> ";
		Fileline = Fileline + new System.String(' ', 3) + "<UnitID>" + cUnitID + "</UnitID> ";
		Fileline = Fileline + "</Vehicle> ";
		Fileline = Fileline + "</AmbulanceDispatch>";

			        // ***************************************
			        //**  Call Siren Web Service and send xml file
			        //****************************************

			        //**********************************************
			        //**  Write out archive xml file
			        //**********************************************

			        FilePath = IncidentMain.SIRENFILEPATH;
			        FilePath = FilePath + cMessageID.ToString() + "-" + cMessageSeqNumber.ToString() + ".xml";
			        FSO = null;
			        TextStm = null;
			        FSO = new System.Object();
			        TextStm = System.IO.File.CreateText(FilePath);
			        TextStm.Write(Fileline);
			        TextStm.Flush();
			        TextStm.Close();
			        //UPGRADE_TODO: (1067) Member CreateTextFile is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			        //TextStm = FSO.CreateTextFile(FilePath);
			        //UPGRADE_TODO: (1067) Member Write is not defined in type Variant. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			        //TextStm.Write(Fileline);









			    }
			    else
	{
		return 0;
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




		public int ProcessePCRRecord(int lMessageID)
		{
			//Process incoming ePCR record request
			//Determine if new record or update
			//Increment sequence number if needed
			//send to Process Transfer function to create xml file

			int result = 0;
			int SeqNumber = 0;

			try
			{

				result = -1;

				if (GetePCRTransferRecord(lMessageID) != 0)
				{
					//update existing record
					SeqNumber = cMessageSeqNumber;
					if (GetNewTransferRecord(lMessageID) != 0)
					{
						cMessageSeqNumber = SeqNumber + 1;
						if (~UpdateePCRTransfer() != 0)
						{
							return 0;
						}
					}
					else
					{
						return 0;
					}
				}
				else
				{
					//create new record
					if (GetNewTransferRecord(lMessageID) != 0)
					{
						if (~AddePCRTransfer() != 0)
						{
							return 0;
						}
					}
					else
					{
						return 0;
					}
				}

				//Create xml file, tranfer to Siren
				if (~ProcessePCRTransfer(lMessageID) != 0)
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


		public int GetePCRUnit(string sUnitID)
		{
			//Determine if Unit should generate an ePCR record
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{

				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_ePCRUnit '" + sUnitID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					//Set return values
					return -1;
				}
				else
				{
					return 0;
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