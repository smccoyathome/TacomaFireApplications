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

	public partial class frmPPELaunder
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPELaunderViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmPPELaunder));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void frmPPELaunder_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		//Dim UniformType As Integer

		public void AddLaunderRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();

			UniformCL.UniformLaunderUniformID = ViewModel.iUniformID;
			UniformCL.UniformLaunderDateFlagged = ViewModel.sDateFlagged;
			UniformCL.UniformLaunderFlaggedBy = modGlobal.Shared.gUser;
			UniformCL.UniformLaunderDateApproved = ViewModel.sDateApproved;
			if ( modGlobal.Clean(ViewModel.sDateApproved) == "" )
			{
				UniformCL.UniformLaunderApprovedBy = "";
			}
			else
			{
				UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
			}
			UniformCL.UniformLaunderComment = modGlobal.Clean(ViewModel.sComment);

			//these fields will be blank
			UniformCL.UniformLaunderDateCleaned = "";
			UniformCL.UniformLaunderCleanedBy = "";
			UniformCL.UniformLaunderCleaningComments = "";

			if ( UniformCL.InsertUniformLaunderInfo() != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong inserting UniformLaunderInfo record." + "  Call Debra Lewandowsky x5068.",
					"Error Inserting UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		public void UpdateLaunderRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( ViewModel.iLaunderID == 0 )
			{
				return ;
			}

			if ( UniformCL.GetUniformLaunderInfoByID(ViewModel.iLaunderID) != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong Getting UniformLaunderInfo record." + "  Call Debra Lewandowsky x5068.",
					"Error Getting UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

			if ( modGlobal.Clean(ViewModel.sDateApproved) == "" )
			{
				ViewModel.sDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
			}

			UniformCL.UniformLaunderDateApproved = ViewModel.sDateApproved;
			UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
			UniformCL.UniformLaunderComment = modGlobal.Clean(ViewModel.sComment);

			if ( UniformCL.UpdateUniformLaunderInfo() != 0 )
			{
			//continue
			}
			else
			{
				ViewManager.ShowMessage("Oooops!  Something went wrong Updating UniformLaunderInfo record." + "  Call Debra Lewandowsky x5068.",
					"Error Updating UniformLaunderInfo", UpgradeHelpers.Helpers.BoxButtons.OK);
			}

		}

		public void FindUniformID()
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.iUniformID = 0;

			//    Dim UniformType As Integer

			if ( Strings.Len(ViewModel.UniformDescription) <= (ViewModel.UniformDescription.IndexOf(':') + 1) )
			{
				ViewModel.UniformTrackingNumber = "";
			}
			else
			{
				ViewModel.UniformTrackingNumber = ViewModel.UniformDescription.Substring(Math.Max(ViewModel.UniformDescription.
												Length - (Strings.Len(ViewModel.UniformDescription) - ((ViewModel.UniformDescription.IndexOf(':') + 1) + 1)), 0));
			}
			ViewModel.UniformDescription = ViewModel.UniformDescription.Substring(0, Math.Min(ViewModel.UniformDescription.IndexOf(':'), ViewModel.UniformDescription.Length));

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			string strSQL = "sp_GetUniformID '" + modGlobal.Shared.gAssignID + "', '" + ViewModel.UniformDescription + "', '";
			strSQL = strSQL + ViewModel.UniformTrackingNumber + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Error trying to retrieve UniformID.  Contact Debra Lewandowsky x5068", "Find UniformID for Launder Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.iUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
			}

		}

		public void GetUniformLaunderInformation()
		{
				//Retrieve and Display Employee PPE UniformLaunderInfo

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string sText = "";
				int CurrRow = 0;

				try
				{

					//Clear Grid
					int tempForVar = ViewModel.sprPPEList.MaxRows;
					for ( int i = 1; i <= tempForVar; i++ )
					{
						int tempForVar2 = ViewModel.sprPPEList.MaxCols;
						for ( int x = 1; x <= tempForVar2; x++ )
						{
							if ( x == 2 || x == 3 || x == 5 )
							{
								ViewModel.sprPPEList.Value = 0;
								//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
								ViewModel.sprPPEList.setTypeCheckText("");
							}
							else
							{
								ViewModel.sprPPEList.Text = "";
							}
						}
					}
					ViewModel.sprPPEList.Col = 1;
					ViewModel.sprPPEList.Col2 = ViewModel.sprPPEList.MaxCols;
					ViewModel.sprPPEList.Row = 1;
					ViewModel.sprPPEList.Row2 = ViewModel.sprPPEList.MaxRows;
					ViewModel.sprPPEList.BlockMode = true;
					ViewModel.sprPPEList.Lock = false;
					ViewModel.sprPPEList.BlockMode = false;

					CurrRow = 0;
					ViewModel.OKButton.Enabled = false;

					//Get Employee PPE Launder History
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_GetEmployeeUniformLaunderInfo '" + modGlobal.Shared.gAssignID + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Test to determine that a record was retrieved
					if ( oRec.EOF )
					{
						return ;
					}

					//Fill PPE Launder Info from fields

					while ( !oRec.EOF )
					{
						CurrRow++;
						ViewModel.sprPPEList.Row = CurrRow;
						ViewModel.sprPPEList.Col = 1; //TurnOut
						sText = modGlobal.Clean(oRec["uniform_description"]) + ": " + modGlobal.Clean(oRec["tracking_number"]);
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPPEList.TypeComboBoxClear was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprPPEList.TypeComboBoxClear(1, CurrRow);
						ViewModel.sprPPEList.TypeComboBoxIndex = 0;
						ViewModel.sprPPEList.TypeComboBoxString = sText;
						ViewModel.sprPPEList.Text = sText;
						ViewModel.sprPPEList.EditMode = false;
						ViewModel.sprPPEList.Lock = true;
						ViewModel.sprPPEList.Col = 2; //Date Flagged
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( !Convert.IsDBNull(oRec["date_flagged"]) )
						{
							ViewModel.sprPPEList.Value = 1;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.setTypeCheckText(Convert.ToDateTime(oRec["date_flagged"]).ToString("M/d/yyyy"));
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
						}
						else
						{
							ViewModel.sprPPEList.Value = 0;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.setTypeCheckText("");
							ViewModel.sprPPEList.EditMode = true;
							ViewModel.sprPPEList.Lock = false;
						}

						//flagged name will be in cell note for col 2
						if ( modGlobal.Clean(oRec["flagged_name"]) != "" )
						{
							ViewModel.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Fixed;
							ViewModel.sprPPEList.Col = 2;
							ViewModel.sprPPEList.CellNoteIndicator = true;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.CellNote = "Flagged by " + modGlobal.Clean(oRec["flagged_name"]);
						}
						ViewModel.sprPPEList.Col = 3; //Date Approved
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( !Convert.IsDBNull(oRec["date_approved"]) )
						{
							ViewModel.sprPPEList.Value = 1;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.setTypeCheckText(Convert.ToDateTime(oRec["date_approved"]).ToString("M/d/yyyy"));
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
							ViewModel.sprPPEList.Col = 4;
							ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["comment"]);
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
						}
						else
						{
							ViewModel.sprPPEList.Value = 0;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.setTypeCheckText("");
							ViewModel.sprPPEList.EditMode = true;
							ViewModel.sprPPEList.Lock = false;
							ViewModel.sprPPEList.Col = 4;
							ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["comment"]);
							ViewModel.sprPPEList.EditMode = true;
							ViewModel.sprPPEList.Lock = false;
						}

						//approved name will be in cell note for col 3
						if ( modGlobal.Clean(oRec["approved_name"]) != "" )
						{
							ViewModel.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Fixed;
							ViewModel.sprPPEList.Col = 3;
							ViewModel.sprPPEList.CellNoteIndicator = true;
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.CellNote = "Approved by " + modGlobal.Clean(oRec["approved_name"]);
						}
						ViewModel.sprPPEList.Col = 5;
						if ( modGlobal.Clean(oRec["date_cleaned"]) == "" )
						{
							ViewModel.sprPPEList.Value = 0;
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
						}
						else
						{
							ViewModel.sprPPEList.Value = 1;
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
							ViewModel.sprPPEList.TextTip = FarPoint.ViewModels.TextTipPolicy.Fixed;
							ViewModel.sprPPEList.CellNoteIndicator = true;
							sText = "Cleaned On " + Convert.ToDateTime(oRec["date_cleaned"]).ToString("M/d/yyyy");
							if ( modGlobal.Clean(oRec["vendor_cleaned"]) == "N" )
							{
								sText = sText + " by " + modGlobal.Clean(oRec["cleaned_name"]);
							}
							else
							{
								sText = sText + " by Vendor";
							}
							sText = sText + " - " + modGlobal.Clean(oRec["laundry_comment"]);
							//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
							ViewModel.sprPPEList.CellNote = sText;
						}
						ViewModel.sprPPEList.Col = 6;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["launder_id"]));
						ViewModel.sprPPEList.Col = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["uniform_id"]));

						oRec.MoveNext();

				};
					ViewModel.OKButton.Enabled = true;
				}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public void FillEmployeeInfo()
		{
				//Retrieve and Display Employee Record
				//for Selected Employee
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string sAssignment = "";

				try
				{
						ViewModel.lblName.Text = "";
						ViewModel.lblEmpNum.Text = "";
						ViewModel.lblAssignment.Text = "";

						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetEmployeeWDLInfo '" + modGlobal.Shared.gAssignID + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");

						//Test to determine that a record was retrieved
						if ( oRec.EOF )
						{
							ViewManager.ShowMessage("There was a problem retrieving this Employees record", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							return ;
						}

						//Fill Personnel record form fields
						ViewModel.lblName.Text = modGlobal.Clean(oRec["name_full"]);
						ViewModel.lblEmpNum.Text = modGlobal.Shared.gAssignID;
						sAssignment = "Batt: " + modGlobal.Clean(oRec["battalion_code"]);

						if ( modGlobal.Clean(oRec["shift_code"]) != "*" )
						{
							sAssignment = sAssignment + "  Shift: " + modGlobal.Clean(oRec["shift_code"]).TrimEnd() + " ";
						}
						if ( modGlobal.Clean(oRec["unit_code"]) != "" )
						{
							sAssignment = sAssignment + "  Unit/Position: " + modGlobal.Clean(oRec["unit_code"]).TrimEnd() + " / " + modGlobal.Clean(oRec["position_code"]).TrimEnd() + " ";
						}
						ViewModel.lblAssignment.Text = modGlobal.Clean(sAssignment);

								GetUniformLaunderInformation();
					}
				catch
				{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public void FillGridLists()
		{
			//Retrieve & fill Grid lists
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int i = 0;

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//fill list for all Uniform Types assigned to current employee
			string strSQL = "sp_GetEmployeeCurrentItemList '" + modGlobal.Shared.gAssignID + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int x = 1; x <= tempForVar; x++ )
			{
				ViewModel.sprPPEList.Row = x;
				ViewModel.sprPPEList.Col = 1;
				i = 0;

				while ( !oRec.EOF )
				{
					ViewModel.sprPPEList.TypeComboBoxIndex = i;
					ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["UniformType"]) + ": " + modGlobal.Clean(oRec["tracking_number"]);
					i++;
					oRec.MoveNext();
				}
				;
				oRec.MoveFirst();
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
				FillGridLists();
						FillEmployeeInfo();
			}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			//ADORecordSetHelper oRec = null;
			//string strSQL = "";

			//process one row at a time in the sprPPEList
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				ViewModel.sprPPEList.Row = i;
				ViewModel.sprPPEList.Col = 1;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{ //item selected...

					ViewModel.sprPPEList.Col = 7;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
					if ( Convert.IsDBNull(ViewModel.sprPPEList.Text) || modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
					{
						ViewModel.sprPPEList.Text = "0";
					}
					ViewModel.iUniformID = Convert.ToInt32(Double.Parse(ViewModel.sprPPEList.Text));

					//UPGRADE_WARNING: (1068) GetVal(iUniformID) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
					if ( Convert.ToDouble(modGlobal.GetVal(ViewModel.iUniformID)) != 0 )
					{ //item identified...

						ViewModel.sprPPEList.Col = 6;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( Convert.IsDBNull(ViewModel.sprPPEList.Text) || modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
						{
							ViewModel.sprPPEList.Text = "0";
						}
						ViewModel.iLaunderID = Convert.ToInt32(Double.Parse(ViewModel.sprPPEList.Text));

						//UPGRADE_WARNING: (1068) GetVal(iLaunderID) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						if ( Convert.ToDouble(modGlobal.GetVal(ViewModel.iLaunderID)) != 0 )
						{ //Update

							ViewModel.sprPPEList.Col = 4;
							if ( ViewModel.sprPPEList.Lock )
							{
							//nothing...
							}
							else
							{
								ViewModel.sComment = modGlobal.Clean(ViewModel.sprPPEList.Text);
								ViewModel.sprPPEList.Col = 3;
								if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
								{
									//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
									if ( ViewModel.sprPPEList.getTypeCheckText() == DateTime.Now.ToString("M/d/yyyy") )
									{
										ViewModel.sDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
										UpdateLaunderRecord();
									}
								}
							}
						}
						else
						{
							//Add new record
							ViewModel.sDateFlagged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
							ViewModel.sprPPEList.Col = 3;
							ViewModel.sDateApproved = "";
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
							{
								ViewModel.sDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
							}
							ViewModel.sprPPEList.Col = 4;
							ViewModel.sComment = modGlobal.Clean(ViewModel.sprPPEList.Text);

							AddLaunderRecord();
						}
					}
				}
			}
			ViewManager.DisposeView(this);

		}

		private void sprPPEList_Change(object eventSender, Stubs._FarPoint.Win.Spread.ChangeEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			int CellHeight = 0;

			if ( Col == 1 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{
					ViewModel.sprPPEList.Col = 7;
					if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.iUniformID = Convert.ToInt32(modGlobal.GetVal(ViewModel.sprPPEList.Text));
					}
					else
					{
						ViewModel.sprPPEList.Col = 1;
						ViewModel.iUniformID = 0;
						ViewModel.UniformDescription = modGlobal.Clean(ViewModel.sprPPEList.Text);
						FindUniformID();
						if ( ViewModel.iUniformID == 0 )
						{
							return ;
						}
						else
						{
							ViewModel.sprPPEList.Col = 7;
							ViewModel.sprPPEList.Text = ViewModel.iUniformID.ToString();
						}
					}
					ViewModel.OKButton.Enabled = true;
				}
			}

			if ( Col == 2 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPPEList.setTypeCheckText(DateTime.Now.ToString("M/d/yyyy"));
				}
				else
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPPEList.setTypeCheckText("");
				}
			}

			if ( Col == 3 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPPEList.setTypeCheckText(DateTime.Now.ToString("M/d/yyyy"));
				}
				else
				{
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprPPEList.setTypeCheckText("");
				}
			}

			if ( Col == 4 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				ViewModel.sprPPEList.CellType = FarPoint.ViewModels.Cells.FpCellType.CellTypeEdit;
				ViewModel.sprPPEList.TypeEditMultiLine = true;
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.MaxTextCellHeight was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				CellHeight = Convert.ToInt32(ViewModel.sprPPEList.getMaxTextCellHeight());
				ViewModel.sprPPEList.SetRowHeight(Row, CellHeight);
			}

		}

		private void sprPPEList_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			//int lColClicked = 0;
			//int lRowClicked = 0;

			if ( Row == 0 )
			{
				return ;
			} //header clicked
			if ( Col == 2 || Col == 3 )
			{
			//continue
			}
			else
			{
				return ;
			}
			ViewModel.sprPPEList.Row = Row;
			ViewModel.sprPPEList.Col = Col;

			if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprPPEList.setTypeCheckText(DateTime.Now.ToString("M/d/yyyy"));
			}
			else
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprPPEList.TypeCheckText was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprPPEList.setTypeCheckText("");
			}

		}

		private void sprPPEList_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPPEList.IsFetchCellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			if ( ViewModel.sprPPEList.IsFetchCellNote() )
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPPEList.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprPPEList.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmPPELaunder DefInstance
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
				return Shared. m_vb6FormDefInstance;
				}
			set
			{
				Shared.
					m_vb6FormDefInstance = value;
			}
		}

		public static frmPPELaunder CreateInstance()
		{
				PTSProject.frmPPELaunder theInstance = Shared.Container.Resolve<frmPPELaunder>();
						theInstance.Form_Load();
			return theInstance;
			}

		protected override void ExecuteControlsStartup()
		{
			ViewModel.sprPPEList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprPPEList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmPPELaunder
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmPPELaunderViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmPPELaunder m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}