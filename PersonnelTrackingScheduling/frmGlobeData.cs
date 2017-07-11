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

	public partial class frmGlobeData
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmGlobeDataViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmGlobeData));
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


		private void frmGlobeData_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		public void LoadLists()
		{
			DbCommand ocmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			ViewModel.txtNameSearch.Text = "";

			ocmd.Connection = modGlobal.oConn;
			ocmd.CommandType = CommandType.Text;

			//fill dropdown list for Uniform Types (Coat, Pants, Boots, etc.)
			string strSQL = "spSelect_UniformTypeList ";

			ocmd.CommandText = strSQL;
			ADORecordSetHelper orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboType.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboType.AddItem(modGlobal.Clean(orec["description"]));
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				ViewModel.cboType.SetItemData(ViewModel.cboType.GetNewIndex(), Convert.ToInt32(modGlobal.GetVal(orec["uniform_type"])));

				orec.MoveNext();
			};

			//fill dropdown list for Stations
			strSQL = "spSelect_UniformInventoryStationList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboStation.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboStation.AddItem(modGlobal.Clean(orec["station"]));
				orec.MoveNext();
			};

			//fill dropdown list for Chest/Waist Sizes
			strSQL = "spSelect_UniformGlobeChstWaistSizeList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboChstWaist.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboChstWaist.AddItem(modGlobal.Clean(orec["chst_waist_size"]));
				orec.MoveNext();
			};

			//fill dropdown list for Chest/Waist Sizes
			strSQL = "spSelect_UniformGlobeChstWaistSizeList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboChstWaist.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboChstWaist.AddItem(modGlobal.Clean(orec["chst_waist_size"]));
				orec.MoveNext();
			};

			//fill dropdown list for Globe Colors
			strSQL = "spSelect_UniformGlobeColorList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboColor.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboColor.AddItem(modGlobal.Clean(orec["color"]));
				orec.MoveNext();
			};

			//fill dropdown list for Globe Lengths
			strSQL = "spSelect_UniformGlobeLengthList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboLength.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboLength.AddItem(modGlobal.Clean(orec["length"]));
				orec.MoveNext();
			};

			//fill dropdown list for Globe Sleeve Lengths
			strSQL = "spSelect_UniformGlobeSleeveLengthList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboSleeve.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboSleeve.AddItem(modGlobal.Clean(orec["sleeve_length"]));
				orec.MoveNext();
			};

			//fill dropdown list for Globe Manufactured Dates
			strSQL = "spSelect_UniformGlobeManufDateList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboManufDate.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboManufDate.AddItem(Convert.ToDateTime(orec["manufactured_date"]).ToString("M/d/yyyy"));
				orec.MoveNext();
			};

			//fill dropdown list for Globe Order #s
			strSQL = "spSelect_UniformGlobeOrderNumberList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboOrder.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboOrder.AddItem(modGlobal.Clean(orec["order_number"]));
				orec.MoveNext();
			};

			//
			//fill dropdown list for Globe Style #s
			strSQL = "spSelect_UniformStyleNumberList ";

			ocmd.CommandText = strSQL;
			orec = ADORecordSetHelper.Open(ocmd, "");
			ViewModel.cboStyle.Items.Clear();

			while(!orec.EOF)
			{
				ViewModel.cboStyle.AddItem(modGlobal.Clean(orec["style_number"]));
				orec.MoveNext();
			};


		}

		public void FillGrid()
		{
			PTSProject.clsUniform UniformCL = Container.Resolve< clsUniform>();

			int iType = 0;
			int iStation = 0;
			string sName = "";
			string sOrder = "";
			string sStyle = "";
			string sColor = "";
			string sLength = "";
			string sSleeve = "";
			string sDate = "";
			string sChstWaist = "";
			ViewModel.sHeadingFilter = "List Filtered by: ";

			int CurrRow = 0;
			ViewModel.sprList.MaxRows = 5000;

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprList.ClearRange was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.ClearRange(1, 1, ViewModel.sprList.MaxCols, ViewModel.sprList.MaxRows, false);

			if ( ViewModel.cboType.SelectedIndex != -1)
			{
				iType = ViewModel.cboType.GetItemData(ViewModel.cboType.SelectedIndex);
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + modGlobal.Clean(ViewModel.cboType.Text) + "; ";
			}

			if (modGlobal.Clean(ViewModel.cboStation.Text) != "")
			{
				//UPGRADE_WARNING: (1068) GetVal() of type Variant is being forced to int. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
				iStation = Convert.ToInt32(modGlobal.GetVal(ViewModel.cboStation.Text));
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Station = " + modGlobal.Clean(ViewModel.cboStation.Text) + "; ";
			}

			sName = modGlobal.Clean(Strings.Replace(ViewModel.txtNameSearch.Text, "'", "''", 1, -1, CompareMethod.Binary));
			if (sName != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Name like  " + sName + "; ";
			}
			sChstWaist = modGlobal.Clean(ViewModel.cboChstWaist.Text);
			if (sChstWaist != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Chst/Waist = " + sChstWaist + "; ";
			}
			sLength = modGlobal.Clean(ViewModel.cboLength.Text);
			if (sLength != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Length = " + sLength + "; ";
			}
			sSleeve = modGlobal.Clean(ViewModel.cboSleeve.Text);
			if (sSleeve != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Sleeve Length = " + sSleeve + "; ";
			}
			sDate = modGlobal.Clean(ViewModel.cboManufDate.Text);
			if (sDate != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Manuf Date = " + sDate + "; ";
			}
			sColor = modGlobal.Clean(ViewModel.cboColor.Text);
			if (sColor != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Color = " + sColor + "; ";
			}
			sOrder = modGlobal.Clean(ViewModel.cboOrder.Text);
			if (sOrder != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Order # = " + sOrder + "; ";
			}
			sStyle = modGlobal.Clean(ViewModel.cboStyle.Text);
			if (sStyle != "")
			{
				ViewModel.sHeadingFilter = ViewModel.sHeadingFilter + "Style # = " + sStyle + "; ";
			}

			if (~UniformCL.GetUniformGlobeList(iType, iStation, sName, sOrder, sStyle, sColor, sLength, sSleeve, sDate, sChstWaist) != 0)
			{
				ViewManager.ShowMessage("There is no Globe Uniforms returned.  Clear Filters and try again.", "Get Globe Uniform Data", UpgradeHelpers.Helpers.BoxButtons.OK);
				return;
			}


			while(!UniformCL.Uniform.EOF)
			{
				CurrRow++;
				ViewModel.sprList.Row = CurrRow;
				ViewModel.sprList.Col = 1;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["co"]);
				ViewModel.sprList.Col = 2;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["description"]);
				ViewModel.sprList.Col = 3;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["serial_number"]);
				ViewModel.sprList.Col = 4;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["order_number"]);
				ViewModel.sprList.Col = 5;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["color"]);
				ViewModel.sprList.Col = 6;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["chst_waist_size"]);
				ViewModel.sprList.Col = 7;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["length"]);
				ViewModel.sprList.Col = 8;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["sleeve_length"]);
				ViewModel.sprList.Col = 9;
				ViewModel.sprList.Text = Convert.ToDateTime(UniformCL.Uniform["manufactured_date"]).ToString("M/d/yyyy");
				ViewModel.sprList.Col = 10;
				ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["style_number"]);

				if (modGlobal.Clean(UniformCL.Uniform["style_description"]) != "")
				{
					ViewModel.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprList.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprList.CellNote = modGlobal.Clean(UniformCL.Uniform["style_description"]);
				}
				ViewModel.sprList.Col = 11;
				if (modGlobal.Clean(UniformCL.Uniform["name_full"]) == "")
				{
					if (modGlobal.Clean(UniformCL.Uniform["station"]) == "")
					{
						ViewModel.sprList.Text = "???";
					}
					else
					{
						ViewModel.sprList.Text = "Station " + modGlobal.Clean(UniformCL.Uniform["station"]);
					}
				}
				else
				{
					ViewModel.sprList.Text = modGlobal.Clean(UniformCL.Uniform["name_full"]);
				}
				ViewModel.sprList.Col = 12;
				if (modGlobal.Clean(UniformCL.Uniform["retired_date"]) == "")
				{
					if (modGlobal.Clean(UniformCL.Uniform["issued_date"]) == "")
					{
						ViewModel.sprList.Text = "";
					}
					else
					{
						ViewModel.sprList.Text = Convert.ToDateTime(UniformCL.Uniform["issued_date"]).ToString("M/d/yyyy");
						ViewModel.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
						ViewModel.sprList.CellNoteIndicator = true;
						//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
						ViewModel.sprList.CellNote = "Issued";
					}
				}
				else
				{
					ViewModel.sprList.Text = Convert.ToDateTime(UniformCL.Uniform["retired_date"]).ToString("M/d/yyyy");
					ViewModel.sprList.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
					ViewModel.sprList.CellNoteIndicator = true;
					//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.CellNote was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
					ViewModel.sprList.CellNote = "Retired";
				}

				UniformCL.Uniform.MoveNext();
			}
			;
			ViewModel.lbCount.Text = "Total Count: " + ViewModel.sprList.DataRowCnt.ToString();
			ViewModel.sprList.MaxRows = ViewModel.sprList.DataRowCnt;



		}

		[UpgradeHelpers.Events.Handler]
		internal void cboChstWaist_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboChstWaist.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboColor_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboColor.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLength_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboLength.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboManufDate_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboManufDate.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboOrder_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboOrder.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboSleeve_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboSleeve.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboStation_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboStation.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboStyle_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.cboStyle.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboType_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			if ( ViewModel.cboType.SelectedIndex == -1)
			{
				return;
			}
			FillGrid();
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClear_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( ViewModel.FirstTime)
			{
				return;
			}
			ViewModel.cboType.Text = "";
			ViewModel.cboType.SelectedIndex = -1;
			ViewModel.cboStation.Text = "";
			ViewModel.cboStation.SelectedIndex = -1;
			ViewModel.txtNameSearch.Text = "";
			ViewModel.cboChstWaist.Text = "";
			ViewModel.cboChstWaist.SelectedIndex = -1;
			ViewModel.cboLength.Text = "";
			ViewModel.cboLength.SelectedIndex = -1;
			ViewModel.cboSleeve.Text = "";
			ViewModel.cboSleeve.SelectedIndex = -1;
			ViewModel.cboManufDate.Text = "";
			ViewModel.cboManufDate.SelectedIndex = -1;
			ViewModel.cboColor.Text = "";
			ViewModel.cboColor.SelectedIndex = -1;
			ViewModel.cboOrder.Text = "";
			ViewModel.cboOrder.SelectedIndex = -1;
			ViewModel.cboStyle.Text = "";
			ViewModel.cboStyle.SelectedIndex = -1;

			FillGrid();

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPrint_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Print Globe Uniform Data Grid
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintHeader was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintHeader("/lPPE Globe Data Query /n" + ViewModel.sHeadingFilter);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintFooter was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintFooter("/nPrinted on " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "/rPage /p of /pc");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintAbortMsg("Printing PPE Globe Data Grid/List");
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColor(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintBorder(false);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintColHeaders was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintColHeaders(true);
			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprList.PrintSmartPrint was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			ViewModel.sprList.setPrintSmartPrint(true);

			//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprList.PrintSheet was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
			//object tempRefParam = null;
			//WEBMAP_UPGRADE_ISSUE: (1101) FarPoint.Win.Spread.FpSpread.PrintSheet was not upgraded
			ViewModel.sprList.PrintSheet(null);
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			ViewModel.FirstTime = true;
			LoadLists();
			FillGrid();
			ViewModel.FirstTime = false;
		}

		private void sprList_TextTipFetch(object eventSender, EventArgs eventArgs)
		{
			if ( ViewModel.sprList.IsFetchCellNote())
			{
				//UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread method sprList.SetTextTipAppearance was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
				ViewModel.sprList.SetTextTipAppearance("Arial", 9, true, false, 0xFFFF, 0x0);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void txtNameSearch_TextChanged(Object eventSender, System.EventArgs eventArgs)
		{
			if ( ViewModel.FirstTime)
			{
				return;
			}
			FillGrid();
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static frmGlobeData DefInstance
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

		public static frmGlobeData CreateInstance()
		{
			PTSProject.frmGlobeData theInstance = Shared.Container.Resolve< frmGlobeData>();
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
			ViewModel.sprList.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
			ViewModel.sprList.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmGlobeData
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmGlobeDataViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmGlobeData m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}