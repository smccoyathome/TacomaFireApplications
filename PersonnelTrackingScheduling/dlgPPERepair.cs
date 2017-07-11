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

	public partial class dlgPPERepair
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgPPERepairViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgPPERepair));
			if ( Shared.m_vb6FormDefInstance == null )
			{
				if ( Shared.m_InitializingDefInstance )
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgPPERepair_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			}
		}

		//Dim UniformType As Integer

		public void DetermineSecurity()
		{
			PTSProject.clsUniform cUniform = Container.Resolve<clsUniform>();
			ViewModel.NoLimitUpdate = false;

			if ( modGlobal.Shared.gSecurity == "ADM" )
			{
				ViewModel.NoLimitUpdate = true;
				return ;
			}

			if ( cUniform.GetPPEInfoForSecurity(modGlobal.Shared.gUser) != 0 )
			{
				ViewModel.NoLimitUpdate = true;
			}

		}

		public void AddRepairRecord()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve<clsUniform>();
			PTSProject.clsUniform clUniform = Container.Resolve<clsUniform>();


			UniformCL.UniformRepairUniformID = ViewModel.iUniformID;
			UniformCL.UniformRepairerID = ViewModel.iRepairerID;

			//If Uniform Repair/Launder record exists... then don't create another one...
			if ( ViewModel.CreateLaunderRecord )
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if ( clUniform.GetUniformRepairLaunderInfoByID(Convert.ToInt32(modGlobal.GetVal(ViewModel.iRepairID))) != 0 )
				{
					ViewModel.CreateLaunderRecord = false;
				}
			}

			if ( ViewModel.sDateIn == "" )
			{
				UniformCL.UniformRepairDateIn = "";
			}
			else
			{
				System.DateTime TempDate = DateTime.FromOADate(0);
				UniformCL.UniformRepairDateIn = (DateTime.TryParse(ViewModel.sDateIn, out TempDate)) ? TempDate.ToString("M/d/yyyy") : ViewModel.sDateIn;
			}

			if ( ViewModel.sDateOut == "" )
			{
				UniformCL.UniformRepairDateOut = "";
			}
			else
			{
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				UniformCL.UniformRepairDateOut = (DateTime.TryParse(ViewModel.sDateOut, out TempDate2)) ? TempDate2.ToString("M/d/yyyy") : ViewModel.sDateOut;
			}
			UniformCL.UniformRepairComment = modGlobal.Clean(ViewModel.sComment);

			if ( ViewModel.iRepairID == 0 )
			{
				if ( UniformCL.InsertUniformRepair() != 0 )
				{
				//continue
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert Repair Record.  Call Debra Lewandowsky x5068.", "Inserting UniformRepair Record"
						, UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			else
			{
				UniformCL.UniformRepairID = ViewModel.iRepairID;
				if ( UniformCL.UpdateUniformRepair() != 0 )
				{
				//continue
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Update Repair Record.  Call Debra Lewandowsky x5068.", "Update UniformRepair Record",
						UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}

			if ( ViewModel.CreateLaunderRecord )
			{
				UniformCL.UniformLaunderUniformID = ViewModel.iUniformID;
				//default dates to now
				UniformCL.UniformLaunderDateFlagged = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
				UniformCL.UniformLaunderDateApproved = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");
				UniformCL.UniformLaunderDateCleaned = DateTime.Now.ToString("M/d/yyyy HH:mm:ss");

				//default flagged by to current user
				UniformCL.UniformLaunderFlaggedBy = modGlobal.Shared.gUser;
				UniformCL.UniformLaunderApprovedBy = modGlobal.Shared.gUser;
				UniformCL.UniformLaunderCleanedBy = "";
				UniformCL.UniformLaunderVendorCleaned = "Y";

				UniformCL.UniformLaunderComment = "Item was IN for cleaning ON: " + UniformCL.UniformRepairDateIn + "; ";
				UniformCL.UniformLaunderComment = UniformCL.UniformLaunderComment + " OUT ON: " + UniformCL.UniformRepairDateOut + "; ";

				UniformCL.UniformLaunderCleaningComments = "Item was cleaned by Vendor while in for repairs.";

				if ( UniformCL.InsertUniformLaunderInfo() != 0 )
				{
					if ( UniformCL.InsertUniformRepairLaunderInfo() != 0 )
					{
					//success
					}
					else
					{
						ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert UniformRepairLaunderInfo.  Call Debra Lewandowsky x5068."
							, "Insert UniformRepairLaunderInfo Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				else
				{
					ViewManager.ShowMessage("Oooops!  Something went wrong when trying to Insert UniformLaunderInfo.  Call Debra Lewandowsky x5068.", "Insert UniformLaunderInfo Record"
						, UpgradeHelpers.Helpers.BoxButtons.OK);
				}
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

			//    Select Case UniformDescription
			//        Case "Coat"
			//            UniformType = 1
			//        Case "Pants"
			//            UniformType = 2
			//        Case "Helmet"
			//            UniformType = 3
			//        Case "Boots"
			//            UniformType = 4
			//        Case Else
			//            Exit Sub
			//    End Select

			string strSQL = "sp_GetUniformID '" + modGlobal.Shared.gAssignID + "', '" + ViewModel.UniformDescription + "', '";
			strSQL = strSQL + ViewModel.UniformTrackingNumber + "' ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			if ( oRec.EOF )
			{
				ViewManager.ShowMessage("Error trying to retrieve UniformID.  Contact Debra Lewandowsky x5068", "Find UniformID for Repair Record", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.iUniformID = Convert.ToInt32(modGlobal.GetVal(oRec["uniform_id"]));
			}

		}

		public void GetPPERepairInformation()
		{
				//Retrieve and Display Employee PPE Repair Record

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
						ViewModel.sprPPEList.Row = i;
						for ( int x = 1; x <= 8; x++ )
						{
							ViewModel.sprPPEList.Col = x;
							if ( x == 6 )
							{
								ViewModel.sprPPEList.Value = 0;
							}
							else
							{
								ViewModel.sprPPEList.Text = "";
							}
						}
					}

					//    sprPPEList.MaxRows = 1
					CurrRow = 0;
					ViewModel.OKButton.Enabled = false;

					//Get Employee PPE Repair History
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_GetEmployeePPERepairInfo '" + modGlobal.Shared.gAssignID + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Test to determine that a record was retrieved
					if ( oRec.EOF )
					{
						return ;
					}

					//Fill PPE Repair Info from fields

					while ( !oRec.EOF )
					{
						CurrRow++;
						//        sprPPEList.MaxRows = CurrRow
						ViewModel.sprPPEList.Row = CurrRow;
						ViewModel.sprPPEList.Col = 1; //TurnOut
						sText = modGlobal.Clean(oRec["uniform_description"]) + ": " + modGlobal.Clean(oRec["tracking_number"]);
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprPPEList.TypeComboBoxClear was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprPPEList.TypeComboBoxClear(1, CurrRow);
						ViewModel.sprPPEList.TypeComboBoxIndex = 0;
						ViewModel.sprPPEList.TypeComboBoxString = sText;
						ViewModel.sprPPEList.Text = sText;
						ViewModel.sprPPEList.Col = 2; //Repairer Name
						sText = modGlobal.Clean(oRec["repairer_name"]);
						//        sprPPEList.TypeComboBoxClear 2, CurrRow
						ViewModel.sprPPEList.TypeComboBoxIndex = 0;
						ViewModel.sprPPEList.TypeComboBoxString = sText;
						ViewModel.sprPPEList.Text = sText;
						ViewModel.sprPPEList.Col = 3; //Date In
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( !Convert.IsDBNull(oRec["date_in"]) )
						{
							ViewModel.sprPPEList.Value = Convert.ToDateTime(oRec["date_in"]).ToString("MMddyyyy");
						}
						else
						{
							ViewModel.sprPPEList.Text = "";
						}
						ViewModel.sprPPEList.Col = 4; //Date Out
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
						if ( !Convert.IsDBNull(oRec["date_out"]) )
						{
							ViewModel.sprPPEList.Value = Convert.ToDateTime(oRec["date_out"]).ToString("MMddyyyy");
						}
						else
						{
							ViewModel.sprPPEList.Text = "";
						}
						ViewModel.sprPPEList.Col = 5;
						ViewModel.sprPPEList.Text = modGlobal.Clean(oRec["comment"]);
						ViewModel.sprPPEList.Col = 6;
						if ( modGlobal.Clean(oRec["launder_id"]) == "" )
						{
							ViewModel.sprPPEList.Value = 0;
							ViewModel.sprPPEList.EditMode = true;
							ViewModel.sprPPEList.Lock = false;
						}
						else
						{
							ViewModel.sprPPEList.Value = 1;
							ViewModel.sprPPEList.EditMode = false;
							ViewModel.sprPPEList.Lock = true;
						}
						ViewModel.sprPPEList.Col = 7;
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						ViewModel.sprPPEList.Text = Convert.ToString(modGlobal.GetVal(oRec["repair_id"]));
						ViewModel.sprPPEList.Col = 8;
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

								GetPPERepairInformation();
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
			string strSQL = "spSelect_UniformRepairerList ";
			oCmd.CommandText = strSQL;
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			//fill Repairer for all Uniform Repairers
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int x = 1; x <= tempForVar; x++ )
			{
				ViewModel.sprPPEList.Row = x;
				ViewModel.sprPPEList.Col = 2;
				i = 0;

				while ( !oRec.EOF )
				{
					ViewModel.sprPPEList.TypeComboBoxIndex = i;
					ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["repairer_name"]);
					i++;
					oRec.MoveNext();
				}
				;
				oRec.MoveFirst();
			}

			//fill Repairer for all Uniform Types
			strSQL = "sp_GetEmployeeCurrentItemList '" + modGlobal.Shared.gAssignID + "' ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			int tempForVar2 = ViewModel.sprPPEList.MaxRows;
			for ( int x = 1; x <= tempForVar2; x++ )
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
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			//process one row at a time in the sprPPEList
			int tempForVar = ViewModel.sprPPEList.MaxRows;
			for ( int i = 1; i <= tempForVar; i++ )
			{
				ViewModel.CreateLaunderRecord = false;
				ViewModel.sprPPEList.Row = i;
				ViewModel.sprPPEList.Col = 2;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					strSQL = "spSelect_UniformRepairerByName '" + modGlobal.Clean(ViewModel.sprPPEList.Text) + "' ";
					oCmd.CommandText = strSQL;
					oRec = ADORecordSetHelper.Open(oCmd, "");

					if ( oRec.EOF )
					{
						ViewModel.iRepairerID = 0;
					}
					else
					{
						ViewModel.iRepairerID = Convert.ToInt32(oRec["repairer_id"]);
					}
				}
				else
				{
					ViewModel.iRepairerID = 0;
				}
				ViewModel.sprPPEList.Col = 3;
				ViewModel.sDateIn = modGlobal.Clean(ViewModel.sprPPEList.Text);
				ViewModel.sprPPEList.Col = 4;
				ViewModel.sDateOut = modGlobal.Clean(ViewModel.sprPPEList.Text);
				ViewModel.sprPPEList.Col = 5;
				ViewModel.sComment = modGlobal.Clean(ViewModel.sprPPEList.Text);
				ViewModel.sprPPEList.Col = 6;
				if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(Convert.ToString(ViewModel.sprPPEList.Value)) == 1 )
				{
					DetermineSecurity();
					if ( ViewModel.NoLimitUpdate )
					{
						ViewModel.CreateLaunderRecord = true;
					}
					else
					{
						ViewManager.ShowMessage("You do not have the authority to create a Vendor Cleaning record.", "Insert UniformLaunderInfo Record", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				ViewModel.sprPPEList.Col = 7;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( Convert.IsDBNull(ViewModel.sprPPEList.Text) || modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
				{
					ViewModel.sprPPEList.Text = "0";
				}
				ViewModel.iRepairID = Convert.ToInt32(Double.Parse(ViewModel.sprPPEList.Text));
				ViewModel.sprPPEList.Col = 8;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: http://www.vbtonet.com/ewis/ewi1049.aspx
				if ( Convert.IsDBNull(ViewModel.sprPPEList.Text) || modGlobal.Clean(ViewModel.sprPPEList.Text) == "" )
				{
					ViewModel.sprPPEList.Text = "0";
				}
				ViewModel.iUniformID = Convert.ToInt32(Double.Parse(ViewModel.sprPPEList.Text));

				//UPGRADE_WARNING: (1068) GetVal(iUniformID) of type Variant is being forced to double. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				if ( Convert.ToDouble(modGlobal.GetVal(ViewModel.iUniformID)) != 0 )
				{
					AddRepairRecord();
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
					ViewModel.sprPPEList.Col = 8;
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
							ViewModel.sprPPEList.Col = 8;
							ViewModel.sprPPEList.Text = ViewModel.iUniformID.ToString();
						}
					}
					ViewModel.OKButton.Enabled = true;
				}
			}

			if ( Col == 3 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{
					if ( !Information.IsDate(ViewModel.sprPPEList.Text) )
					{
						ViewManager.ShowMessage("Date In is not a valid date.  Must be in m/d/yyyy format.", "Invalid Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
			}

			if ( Col == 4 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{
					if ( !Information.IsDate(ViewModel.sprPPEList.Text) )
					{
						ViewManager.ShowMessage("Date Out is not a valid date.  Must be in m/d/yyyy format.", "Invalid Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
			}

			if ( Col == 5 )
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

			if ( Col == 1 )
			{
				ViewModel.sprPPEList.Row = Row;
				ViewModel.sprPPEList.Col = Col;
				if ( modGlobal.Clean(ViewModel.sprPPEList.Text) != "" )
				{
					ViewModel.sprPPEList.Col = 8;
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
							ViewModel.sprPPEList.Col = 8;
							ViewModel.sprPPEList.Text = ViewModel.iUniformID.ToString();
						}
					}
					ViewModel.OKButton.Enabled = true;
				}
			}


		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgPPERepair DefInstance
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

		public static dlgPPERepair CreateInstance()
		{
				PTSProject.dlgPPERepair theInstance = Shared.Container.Resolve<dlgPPERepair>();
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

	public partial class dlgPPERepair
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgPPERepairViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgPPERepair m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}