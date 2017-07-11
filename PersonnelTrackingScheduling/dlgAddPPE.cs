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

	public partial class dlgAddPPE
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgAddPPEViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgAddPPE));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgAddPPE_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void AddPPEUniform()
		{
			PTSProject.clsUniform cUniform = Container.Resolve< clsUniform>();
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			string strSQL = "";

			try
			{

				if ( ViewModel.CurrRow == 0)
				{
					return;
				}
				ViewModel.sprPPEList.Row = ViewModel.CurrRow;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				cUniform.UniformType = ViewModel.CurrRow;
				cUniform.UniformRetiredDate = "";
				ViewModel.sprPPEList.Col = 4;
				cUniform.UniformTrackingNumber = modGlobal.Clean(ViewModel.sprPPEList.Text);

				cUniform.UniformColorType = 0;
				cUniform.UniformSizeType = 0;
				ViewModel.sprPPEList.Col = 3; //Size or Color
				if (modGlobal.Clean(ViewModel.sprPPEList.Text) != "")
				{
					if ( ViewModel.CurrRow != 3)
					{ //Size... Only Helmets have color
						strSQL = "Select size_type From UniformSizeCode Where description = '" + modGlobal.Clean(ViewModel.sprPPEList.Text) + "'";
						oCmd.CommandText = strSQL;
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							cUniform.UniformSizeType = Convert.ToInt32(modGlobal.GetVal(oRec["size_type"]));
						}
					}
					else
					{
						//Color
						strSQL = "Select color_type From UniformColorCode Where description = '" + modGlobal.Clean(ViewModel.sprPPEList.Text) + "'";
						oCmd.CommandText = strSQL;
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if (!oRec.EOF)
						{
							//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
							cUniform.UniformColorType = Convert.ToInt32(modGlobal.GetVal(oRec["color_type"]));
						}
					}
				}

				cUniform.UniformManufacturerID = 0;
				ViewModel.sprPPEList.Col = 2; //Manufacturer
				if (modGlobal.Clean(ViewModel.sprPPEList.Text) != "")
				{
					strSQL = "Select manufacturer_id From UniformManufacturer Where manufacturer_name = '" + modGlobal.Clean(ViewModel.sprPPEList.Text) + "'";
					oCmd.CommandText = strSQL;
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if (!oRec.EOF)
					{
						//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
						cUniform.UniformManufacturerID = Convert.ToInt32(modGlobal.GetVal(oRec["manufacturer_id"]));
					}
				}
				ViewModel.sprPPEList.Col = 5;
				if (modGlobal.Clean(ViewModel.sprPPEList.Text) == "")
				{
					cUniform.UniformManufacturedDate = "";
				}
				else if (((int) DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(ViewModel.sprPPEList.Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
				{
					ViewManager.ShowMessage("Manufactured Date can not be in the future.", "Manufactured Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					return;
				}
				else
				{
					cUniform.UniformManufacturedDate = DateTime.Parse(ViewModel.sprPPEList.Text).ToString("MM/dd/yyyy");
				}

				if (cUniform.InsertUniform() != 0)
				{
					cUniform.PersUniformID = cUniform.UniformID;
					cUniform.PersUniformEmpID = ViewModel.EmployeeID;
					ViewModel.sprPPEList.Col = 1;
					if (modGlobal.Clean(ViewModel.sprPPEList.Text) != "")
					{
						if (((int) DateAndTime.DateDiff("d", DateTime.Now, DateTime.Parse(DateTime.Parse(ViewModel.sprPPEList.Text).ToString("M/d/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
						{
							ViewManager.ShowMessage("Issued Date can not be in the future.", "Issued Date Error", UpgradeHelpers.Helpers.BoxButtons.OK);
							return;
						}
						else
						{
							cUniform.PersUniformIssuedDate = DateTime.Parse(ViewModel.sprPPEList.Text).ToString("M/d/yyyy");
						}
					}
					else
					{
						cUniform.PersUniformIssuedDate = DateTime.Now.ToString("M/d/yyyy");
					}
					if (cUniform.InsertPersonnelUniform() != 0)
					{
						//continue
					}
					else
					{
						ViewModel.sprPPEList.Col = 0;
						ViewManager.ShowMessage("Ooops! The " + modGlobal.Clean(ViewModel.
							sprPPEList.Text) + " PersonnelUniform Record was not added. " + "Please call Debra Lewandowsky x5068. Thanks.", "Insert PersonnelUniform Error", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}
				else
				{
					ViewModel.sprPPEList.Col = 0;
					ViewManager.ShowMessage("Ooops! The " + modGlobal.Clean(ViewModel.
						sprPPEList.Text) + " Uniform Record was not added. " + "Please call Debra Lewandowsky x5068. Thanks.", "Insert Uniform Error", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
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
				if (oRec.EOF)
				{
					ViewManager.ShowMessage("There was a problem retrieving this Employees record", "Update Employee Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
					return;
				}

				//Fill Personnel record form fields
				ViewModel.lblName.Text = modGlobal.Clean(oRec["name_full"]);
				ViewModel.lblEmpNum.Text = modGlobal.Shared.gAssignID;
				ViewModel.EmployeeID = modGlobal.Shared.gAssignID;
				sAssignment = "Batt: " + modGlobal.Clean(oRec["battalion_code"]);
				//    If Clean(orec("battalion_code"]) <> "" Then
				//        If Clean(orec("battalion_code"]) = "1 " Then
				//            sAssignment = "Batt: 1 "
				//        Else
				//            If Clean(orec("battalion_code"]) = "2 " Then
				//                sAssignment = "Batt: 2 "
				//            End If
				//        End If
				//    End If
				if (modGlobal.Clean(oRec["shift_code"]) != "*")
				{
					sAssignment = sAssignment + "  Shift: " + modGlobal.Clean(oRec["shift_code"]).TrimEnd() + " ";
				}
				if (modGlobal.Clean(oRec["unit_code"]) != "")
				{
					sAssignment = sAssignment + "  Unit/Position: " + modGlobal.Clean(oRec["unit_code"]).TrimEnd() + " / " + modGlobal.Clean(oRec["position_code"]).TrimEnd() + " ";
				}
				ViewModel.lblAssignment.Text = modGlobal.Clean(sAssignment);
			}
			catch
			{

				if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
				{
					return;
				}
			}

		}

		public void FillGridLists()
		{
			//Retrieve & fill Grid lists for Manuactures & Sizes & Color (Helmet only)
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ADORecordSetHelper oRec = null;
			int i = 0;
			string strSQL = "";

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			//    strSQL = "Select * From UniformManufacturer order by manufacturer_name "
			//    ocmd.CommandText = strSQL
			//    Set orec = ocmd.Execute

			//fill Manufacturer for all Uniform Types
			for (int x = 1; x <= 8; x++)
			{
				ViewModel.sprPPEList.Row = x;
				ViewModel.sprPPEList.Col = 2;
				i = 0;
				//fill Manufacturer for Selected Uniform Type
				strSQL = "spSelect_UniformManufacturerByItemType " + x.ToString() + " ";
				oCmd.CommandText = strSQL;
				oRec = ADORecordSetHelper.Open(oCmd, "");

				while(!oRec.EOF)
				{
					ViewModel.sprPPEList.TypeComboBoxIndex = i;
					ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["manufacturer_name"]);
					i++;
					oRec.MoveNext();
				}
				;
							}

							//fill Size for all Uniform Types = Coat
							strSQL = "Select * From UniformSizeCode where uniform_type = 1 order by description ";
							oCmd.CommandText = strSQL;
							oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 1;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

			//fill Size for all Uniform Types = Pants
			strSQL = "Select * From UniformSizeCode where uniform_type = 2 order by description ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 2;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

			//fill Size for all Uniform Types = Boots
			strSQL = "Select * From UniformSizeCode where uniform_type = 4 order by description ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 4;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};
			//fill Color for all Uniform Types = Helmet
			strSQL = "Select * From UniformColorCode order by description ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 3;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

			//fill Size for all Uniform Types = FLash Hood
			strSQL = "Select * From UniformSizeCode where uniform_type = 6 order by size_type ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 6;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

			//fill Size for all Uniform Types = Gloves
			strSQL = "Select * From UniformSizeCode where uniform_type = 7 order by size_type ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 7;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

			//fill Size for all Uniform Types = Field Jackets
			strSQL = "Select * From UniformSizeCode where uniform_type = 8 order by size_type ";
			oCmd.CommandText = strSQL;
			oRec = ADORecordSetHelper.Open(oCmd, "");
			ViewModel.sprPPEList.Row = 8;
			ViewModel.sprPPEList.Col = 3;
			i = 0;

			while(!oRec.EOF)
			{
				ViewModel.sprPPEList.TypeComboBoxIndex = i;
				ViewModel.sprPPEList.TypeComboBoxString = modGlobal.Clean(oRec["description"]);
				i++;
				oRec.MoveNext();
			};

		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.CurrRow = 0;
			FillGridLists();
			FillEmployeeInfo();
		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			bool ADDItem = false;

			//Add logic to Insert rows to the Uniform & PersonnelUniform tables
			for (int i = 1; i <= 8; i++)
			{
				ViewModel.sprPPEList.Row = i;
				ADDItem = false;
				for (int x = 1; x <= 5; x++)
				{
					ViewModel.sprPPEList.Col = x;
					if (modGlobal.Clean(ViewModel.sprPPEList.Text) != "")
					{
						ADDItem = true;
					}
				}
				if (ADDItem)
				{
					ViewModel.CurrRow = i;
					AddPPEUniform();
				}
			}
			ViewManager.DisposeView(this);
		}


		private void sprPPEList_Advance(object eventSender, Stubs._FarPoint.Win.Spread.AdvanceEventArgs eventArgs)
		{
			bool AdvanceNext = eventArgs.AdvanceNext;

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgAddPPE DefInstance
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

		public static dlgAddPPE CreateInstance()
		{
			PTSProject.dlgAddPPE theInstance = Shared.Container.Resolve< dlgAddPPE>();
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

	public partial class dlgAddPPE
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgAddPPEViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgAddPPE m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}