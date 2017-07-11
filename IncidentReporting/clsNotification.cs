using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace TFDIncident
{

	public class clsNotification
		: UpgradeHelpers.Interfaces.IDependentModel, UpgradeHelpers.Interfaces.ICreatesObjects, UpgradeHelpers
		.Interfaces.IInteractsWithView, UpgradeHelpers.Interfaces.IInitializableCommon, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(clsNotification));
		}

		void UpgradeHelpers.Interfaces.IInitializableCommon.Common()
		{
			_cNotificationReceiver = null;
			cEmployeeID = "";
			cNotificationReceiverType = 0;
			_cNotificationMessage = null;
			cNotificationMessageID = 0;
			cMessageEmployeeID = "";
			cMessageText = "";
			cFlagReceived = 0;
			cDateMessageCreated = "";
			cDateMessageReceived = "";
			_cNotificationReceiverTypeCode = null;
		}


		//********************************************************
		//**    Notification Class                              **
		//**                                                    **
		//********************************************************
		//**    Methods                                         **
		//**----------------------------------------------------**


		//********************************************************
		//**             Private Class Variables                **
		//********************************************************
		//NotificationReceiver
		public virtual ADORecordSetHelper _cNotificationReceiver { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cNotificationReceiver
		{
			get
			{
				if (_cNotificationReceiver == null)
				{
					_cNotificationReceiver = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cNotificationReceiver;
			}
			set
			{
				_cNotificationReceiver = value;
			}
		}

		public virtual string cEmployeeID { get; set; }

		public virtual int cNotificationReceiverType { get; set; }

		//NotificationMessage
		public virtual ADORecordSetHelper _cNotificationMessage { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cNotificationMessage
		{
			get
			{
				if (_cNotificationMessage == null)
				{
					_cNotificationMessage = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cNotificationMessage;
			}
			set
			{
				_cNotificationMessage = value;
			}
		}

		public virtual int cNotificationMessageID { get; set; }

		public virtual string cMessageEmployeeID { get; set; }

		public virtual string cMessageText { get; set; }

		public virtual byte cFlagReceived { get; set; }

		public virtual string cDateMessageCreated { get; set; }

		public virtual string cDateMessageReceived { get; set; }

		//NotificationReceiverTypeCode Recordset
		public virtual ADORecordSetHelper _cNotificationReceiverTypeCode { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		private ADORecordSetHelper cNotificationReceiverTypeCode
		{
			get
			{
				if (_cNotificationReceiverTypeCode == null)
				{
					_cNotificationReceiverTypeCode = new UpgradeHelpers.DB.ADO.ADORecordSetHelper("");
				}
				return _cNotificationReceiverTypeCode;
			}
			set
			{
				_cNotificationReceiverTypeCode = value;
			}
		}


		//*********************************************
		//**         Class Public Properties         **
		//*********************************************
		//NotificationReceiver
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper NotificationReceiver
		{
			get
			{
				return cNotificationReceiver;
			}
			set
			{
				cNotificationReceiver = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string EmployeeID
		{
			get
			{
				return cEmployeeID;
			}
			set
			{
				cEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NotificationReceiverType
		{
			get
			{
				return cNotificationReceiverType;
			}
			set
			{
				cNotificationReceiverType = value;
			}
		}


		//NotificationMessage
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper NotificationMessage
		{
			get
			{
				return cNotificationMessage;
			}
			set
			{
				cNotificationMessage = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public int NotificationMessageID
		{
			get
			{
				return cNotificationMessageID;
			}
			set
			{
				cNotificationMessageID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string MessageEmployeeID
		{
			get
			{
				return cMessageEmployeeID;
			}
			set
			{
				cMessageEmployeeID = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string MessageText
		{
			get
			{
				return cMessageText;
			}
			set
			{
				cMessageText = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public byte FlagReceived
		{
			get
			{
				return cFlagReceived;
			}
			set
			{
				cFlagReceived = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateMessageCreated
		{
			get
			{
				return cDateMessageCreated;
			}
			set
			{
				cDateMessageCreated = value;
			}
		}

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]


		public string DateMessageReceived
		{
			get
			{
				return cDateMessageReceived;
			}
			set
			{
				cDateMessageReceived = value;
			}
		}


		//NotificationReceiverTypeCode Recordset
		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.None)]
		public ADORecordSetHelper NotificationReceiverTypeCode
		{
			get
			{
				return cNotificationReceiverTypeCode;
			}
			set
			{
				cNotificationReceiverTypeCode = value;
			}
		}



		//**********************************************
		//**         Public Class Methods             **
		//**********************************************


		public int GetNotificationMessagesNew(string sEmpID)
		{
			//Get All New Notification Messages for selected receiver
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationMessagesNew '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationMessage = orec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public int GetNotificationMessagesByReceiver(string sEmpID)
		{
			//Get All  Notification Messages for selected receiver
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationMessagesByReceiver '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationMessage = orec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public int GetNotificationReceiver(string sEmpID)
		{
			//Get All  Notification Messages for selected receiver
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationReceiver '" + sEmpID + "'";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationReceiver = orec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public int GetNotificationReceiverByType(int iReceiverType)
		{
			//Get All  Notification Receivers for selected Receiver Type
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationReceiverByType " + iReceiverType.ToString();
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationReceiver = orec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}

		public int GetNotificationReceivers()
		{
			//Get All  Notification Receivers
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationReceivers";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationReceiver = orec;
					return -1;
				}
				else
				{
					return 0;
				}
			}
			catch
			{

				return 0;
			}
		}


		public void GetNotificationReceiverTypeCodes()
		{
			//Get All  Notification Receiver Type Codes
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper orec = null;

			try
			{


				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spSelect_NotificationReceiverTypeCode";
				orec = ADORecordSetHelper.Open(ocmd, "");
				if (!orec.EOF)
				{
					cNotificationReceiverTypeCode = orec;
				}
			}
			catch
			{

				return;
			}
		}


		public int AddNotificationMessage()
		{
			//Add New NotificationMessage
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			string SqlString = "";


			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				SqlString = "spInsert_NotificationMessage '" + cMessageEmployeeID + "','";
				SqlString = SqlString + Strings.Replace(cMessageText, "'", "''", 1, -1, CompareMethod.Binary) + "'," + cFlagReceived.ToString() + ",'";
				SqlString = SqlString + cDateMessageCreated + "'";
				ocmd.CommandText = SqlString;
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}

			return result;
		}

		public int AddNotificationReceiver(string sEmpID, int iReceiverType)
		{
			//Add New Notification Receiver
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spInsert_NotificationReceiver '" + sEmpID + "'," + iReceiverType.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}

			return result;
		}

		public int UpdateNotificationMessage(int lMessageID, byte bFlagReceived, string sDateReceived)
		{
			//Update NotificationMessage Received Status and Date
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spUpdate_NotificationMessage " + lMessageID.ToString() + "," + bFlagReceived.ToString() + ",'" + sDateReceived + "'";
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}

			return result;
		}


		public int DeleteNotificationReceiver(string sEmpID, int iReceiverType)
		{
			//Delete Notification Receiver
			//Also Deletes all notification messages for this receiver
			int result = 0;
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			try
			{

				result = -1;
				ocmd.Connection = IncidentMain.oIncident;
				ocmd.CommandType = CommandType.Text;
				ocmd.CommandText = "spDelete_NotificationReceiver '" + sEmpID + "'," + iReceiverType.ToString();
				ocmd.ExecuteNonQuery();
			}
			catch
			{

				return 0;
			}

			return result;
		}

		public string UniqueID { get; set; }

		public UpgradeHelpers.Interfaces.IViewManager ViewManager { get; set; }

		public UpgradeHelpers.Interfaces.IIocContainer Container { get; set; }

	}
}