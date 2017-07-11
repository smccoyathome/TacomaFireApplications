using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using UpgradeHelpers.DB.ADO;
using UpgradeStubs;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class frmEMSDailySched
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEMSDailySchedViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmEMSDailySched));
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

		[UpgradeHelpers.Events.Handler]
		internal void lbPospm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPosam_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void picTrash_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_39_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_39.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_39_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_39.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_38_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_38.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_38_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_38.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_37_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_37.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_37_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_37.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_36_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_36.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_36_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_36.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_35_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_35.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_34_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_34.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_33_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_33.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_32_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_32.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_35_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_35.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_34_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_34.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_33_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_33.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_32_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_32.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_19_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_19.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_18_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_18.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_17_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_17.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_16_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_16.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_15_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_15.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_14_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_14.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_13_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_13.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_12_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_12.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_19_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_19.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_18_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_18.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_17_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_17.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_16_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_16.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_15_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_15.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_14_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_14.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_13_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_13.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_12_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_12.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_31_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_31.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_30_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_30.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_29_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_29.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_28_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_28.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_31_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_31.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_30_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_30.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_29_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_29.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_28_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_28.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_27_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_27.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_26_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_26.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_25_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_25.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_24_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_24.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_27_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_27.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_26_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_26.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_25_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_25.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_24_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_24.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_11_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_11.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_10_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_10.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_9_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_9.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_8_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_8.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_7_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_7.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_11_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_11.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_10_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_10.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_9_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_9.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_8_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_8.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_7_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_7.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_23_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_23.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_22_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_22.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_21_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_21.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_23_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_23.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_22_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_22.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_21_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_21.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_20_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_20.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_20_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_20.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void pnSelected_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel.pnSelected.BeginDrag();
		}
		//**********************************************
		//Daily Schedule form used for Scheduling EMS
		//**********************************************


		public bool SecurityOK()
		{
			//Check Security
			//Return Ok if current User Authorized to make changes
			switch ( modGlobal.Shared.gSecurity )
			{
				case "ADM":
				case "BAT":
				case "AID":
				case "PM":
					return true;
				default:
					return false;
			}

		}

		public void FillLists()
		{
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string ShiftStart = "";
				string StartDate = "";
				string ShiftEnd = "";
				string EndDate = "";
				string sName = "";
				string CurrName = "";
				int CurrRow = 0;

				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

					ShiftStart = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
					StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");
					ShiftEnd = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
					EndDate = DateTime.Parse(StartDate).AddDays(1).ToString("M/d/yyyy");

					//Fill Leave Grid
					sName = "";
					ViewModel.sprLeave.BlockMode = true;
					ViewModel.sprLeave.Row = 1;
					ViewModel.sprLeave.Row2 = 25;
					ViewModel.sprLeave.Col = 1;
					ViewModel.sprLeave.Col2 = 4;
					//ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants)12;
					ViewModel.sprLeave.FontUnderline = false;
					ViewModel.sprLeave.BlockMode = false;
					CurrRow = 1;

					oCmd.CommandText = "spReport_GetEMSDailySchLv '" + StartDate + "','" + EndDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					while ( !oRec.EOF )
					{
						sName = Convert.ToString(oRec["name_last"]).Trim() + ", " + Convert.ToString(oRec["name_first"]).Trim();
						if ( CurrName == sName )
						{
							ViewModel.sprLeave.Row = CurrRow - 1;
							if ( Convert.ToString(oRec["AMPM"]) == "AM" )
							{
								ViewModel.sprLeave.Col = 2;
							}
							else
							{
								ViewModel.sprLeave.Col = 3;
							}
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1 )
							{
								ViewModel.sprLeave.FontUnderline = true;
							}
							ViewModel.sprLeave.Col = 4;
							ViewModel.sprLeave.Text = Convert.ToString(oRec["employee_id"]).Trim();
						}
						else
						{
							ViewModel.sprLeave.Row = CurrRow;
							ViewModel.sprLeave.Col = 1;
							ViewModel.sprLeave.Text = sName;
							if ( Convert.ToString(oRec["AMPM"]) == "AM" )
							{
								ViewModel.sprLeave.Col = 2;
							}
							else
							{
								ViewModel.sprLeave.Col = 3;
							}
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
							if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.Clean(oRec["vacation_bank_flag"])) == 1 )
							{
								ViewModel.sprLeave.FontUnderline = true;
							}
							ViewModel.sprLeave.Col = 4;
							ViewModel.sprLeave.Text = Convert.ToString(oRec["employee_id"]).Trim();
							CurrName = sName;
							CurrRow++;
						}
						oRec.MoveNext();
        };
					oCmd.CommandText = "spReport_GetEMSDailySckLv '" + StartDate + "','" + EndDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					sName = "";
					CurrName = "";

					while ( !oRec.EOF )
					{
						sName = Convert.ToString(oRec["name_last"]).Trim() + ", " + Convert.ToString(oRec["name_first"]).Trim();
						if ( CurrName == sName )
						{
							ViewModel.sprLeave.Row = CurrRow - 1;
							if ( Convert.ToString(oRec["AMPM"]) == "AM" )
							{
								ViewModel.sprLeave.Col = 2;
							}
							else
							{
								ViewModel.sprLeave.Col = 3;
							}
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
							ViewModel.sprLeave.Col = 4;
							ViewModel.sprLeave.Text = Convert.ToString(oRec["employee_id"]).Trim();
						}
						else
						{
							ViewModel.sprLeave.Row = CurrRow;
							ViewModel.sprLeave.Col = 1;
							ViewModel.sprLeave.Text = sName;
							if ( Convert.ToString(oRec["AMPM"]) == "AM" )
							{
								ViewModel.sprLeave.Col = 2;
							}
							else
							{
								ViewModel.sprLeave.Col = 3;
							}
							ViewModel.sprLeave.Text = modGlobal.Clean(oRec["time_code_id"]);
							ViewModel.sprLeave.Col = 4;
							ViewModel.sprLeave.Text = Convert.ToString(oRec["employee_id"]).Trim();
							CurrName = sName;
							CurrRow++;
						}
						oRec.MoveNext();
        };
					}
				catch
				{

        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public ScheduleEmployeeStruct ScheduleEmployee(string Unit, string ShiftDate, string Empid, string Position)
		{
			using ( var async1 = this.Async<ScheduleEmployeeStruct>(true) )
			{
				//Gather information for Schedule Record
				//(date, employee_id, assignment, time code, pay upgrade info)
				//Insert new Schedule record
				//Requery schedule data for form
				int UpdateFlag = 0;
				string TimeCode = "";
				int AssignID = 0;
				int PayUp = 0;
				string JobCode = "";
				decimal PayRate = 0;
				string PayString = "";
				int Step = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdInsert = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				try
				{
					{
						modGlobal.Shared.gOTimeDefault = 0;
						UpdateFlag = 0;
						//Determine if Employee is already scheduled for this date
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
							//Employee is already on schedule determine
							//if generic Rover or Debit or Special Assignment
							//if so set UpdateFlag to indicate an update rather than an add action
							//otherwise send error message and exit
                            if (Convert.ToDouble(oRec["assignment_id"]) >= 559 && Convert.ToDouble(oRec["assignment_id"]) < 563 || (Convert.ToDouble(oRec["assignment_id"]) == 1167) || (Convert.ToDouble(oRec["assignment_id"]) == 1283) || (Convert.ToDouble(oRec["assignment_id"]) == 1284))
							{
								UpdateFlag = -1;
								if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
								{
									modGlobal.Shared.gLeaveType = "TRD";
								}
								else if ( modGlobal.Clean(oRec["time_code_id"]) == "OTP" || modGlobal.Clean(oRec["time_code_id"]) == "EDO" )
								{
									modGlobal.Shared.gOTimeDefault = -1;
								}
							}
							else if ( Convert.ToDouble(oRec["assignment_id"]) >= 575 && Convert.ToDouble(oRec["assignment_id"]) <= 578 )
							{
								UpdateFlag = -1;
								if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
								{
									modGlobal.Shared.gLeaveType = "TRD";
								}
								else if ( modGlobal.Clean(oRec["time_code_id"]) == "OTP" || modGlobal.Clean(oRec["time_code_id"]) == "EDO" )
								{
									modGlobal.Shared.gOTimeDefault = -1;
								}
							}
							else
							{
								ViewManager.ShowMessage("This Employee is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
                                return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
							}
						}

						//Find Assignment ID
						oCmd.CommandText = "sp_GetAssign '" + Unit + "','" + Position + "','" + ViewModel.lbShift.Text + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						AssignID = Convert.ToInt32(oRec["assignment_id"]);
						modGlobal.Shared.gAssignID = Convert.ToString(oRec["job_code"]);
						//Check to see if position is still empty...
						oCmd.CommandText = "spSelect_CheckScheduleDateAssignment '" + ShiftDate + "', " + AssignID.ToString() + " ";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
                            ViewManager.ShowMessage("Refresh your screen... it looks like this position is filled!", "Schedule Employee Double-Check", UpgradeHelpers.Helpers
                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
                            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
						}

						//Display Time Code selection Dialog
						if ( modGlobal.Shared.gLeaveType != "TRD" )
						{
							modGlobal.Shared.gLType = "S";
							modGlobal.Shared.gPayType = "";
							modGlobal.Shared.gLeaveType = "";
							modGlobal.Shared.gVacBank = 0;
							modGlobal.Shared.gSCKFlag = 0;
							modGlobal.Shared.gEmployeeId = Empid;
                            async1.Append(() =>
								{
                                    ViewManager.NavigateToView(
                                        dlgTime.DefInstance, true);
								});
						}
						async1.Append<ScheduleEmployeeStruct>(() =>
							{
								using ( var async2 = this.Async() )
								{

									if ( modGlobal.Shared.gLeaveType == "" )
									{
                                        return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
									}

									TimeCode = modGlobal.Shared.gLeaveType;
									if ( modGlobal.Shared.gPayType == "" )
									{
										//Get current JobCode
										JobCode = modGlobal.GetJobCode(Empid);
										Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
										PayUp = 0;
									}
									else
									{
										JobCode = modGlobal.GetJobCode(Empid);
										Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
										//Determine Step for PayUp
										oCmd.CommandText = "sp_FindPayRate '" + JobCode + "'," + Step.ToString();
										oRec = ADORecordSetHelper.Open(oCmd, "");
										if ( !oRec.EOF )
										{
											PayRate = Convert.ToDecimal(oRec["pay_rate"]);
											PayRate = (decimal)Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
											for ( int i = 1; i <= 11; i++ )
											{
												oCmd.CommandText = "sp_FindPayRate '" + modGlobal.Shared.gPayType + "'," + i.ToString();
												oRec = ADORecordSetHelper.Open(oCmd, "");
												if ( oRec.EOF )
												{
													ViewManager.ShowMessage("The Selected Job does not constitute a Pay Upgrade. Pay Upgrade canceled.", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons.OK);
													modGlobal.Shared.gPayType = "";
													PayUp = 0;
													break;
												}
												else
												{
													if ( ((double)PayRate) <= Convert.ToDouble(oRec["pay_rate"]) )
													{
														Step = i;
														JobCode = modGlobal.Shared.gPayType.Trim();
														PayUp = -1;
														break;
													}
												}
											}
										}
										else
										{
											async2.Append<System.String>(() => ViewManager.InputBox("Unable to Calculate New Step. Please Enter Step for this Pay Upgrade.", "Pay Upgrade Step", "1"));
                                            async2.Append<System.String, System.String>(tempNormalized0 => tempNormalized0);
                                            async2.Append<System.String>(tempNormalized1 =>
												{
                                                    PayString = tempNormalized1;
												});
											async2.Append(() =>
												{
													double dbNumericTemp = 0;
													if ( PayString == "" )
													{
														PayUp = 0;
														modGlobal.Shared.gPayType = "";
													}
													else if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
													{
														ViewManager.ShowMessage("Invalid Step, Pay Upgrade Canceled", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons.OK);
														PayUp = 0;
														modGlobal.Shared.gPayType = "";
													}
													else
													{
														Step = Convert.ToInt32(Conversion.Val(PayString));
														JobCode = modGlobal.Shared.gPayType.Trim();
														PayUp = -1;
													}
												});
										}
									}
                                    async2.Append(() =>
                                        {

									if ( UpdateFlag != 0 )
									{
                                                var returningMetodValue191 = //Delete old Schedule record
                                             DeleteSchedule(Empid, ShiftDate);
												Empid = returningMetodValue191.Empid;
												ShiftDate = returningMetodValue191.ShiftDate;
												UpdateFlag = 0;
									}

												oCmdInsert.Connection = modGlobal.oConn;
												oCmdInsert.CommandType = CommandType.StoredProcedure;
												oCmdInsert.CommandText = "spInsertSchedule";
												oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

												//Insert Personnel Schedule Note if needed
												if ( modGlobal.Clean(modGlobal.Shared.gLeaveNotes) != "" )
												{
													oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + Empid + "','" + ShiftDate + "','" + modGlobal.Clean(modGlobal.Shared.gLeaveNotes) + "','" + modGlobal.Shared.gUser + "' ";
													oCmd.CommandType = CommandType.Text;
													oCmd.ExecuteNonQuery();
													modGlobal.Shared.gLeaveNotes = "";
												}

												if ( modGlobal.Shared.gFullShift != 0 )
												{
													if ( ShiftDate.Substring(Math.Max(ShiftDate.Length - 2, 0)) == "AM" )
													{
														ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
													}
													else
													{
														ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
													}

													//Test to make sure employee not already scheduled
													oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
													oRec = ADORecordSetHelper.Open(oCmd, "");
													if ( !oRec.EOF )
													{
                                                    if (Convert.ToDouble(oRec["assignment_id"]) >= 559 && Convert.ToDouble(oRec["assignment_id"]) < 563 || (Convert.ToDouble(oRec["assignment_id"]) == 1167) || (Convert.ToDouble(oRec["assignment_id"]) == 1283) || (Convert.ToDouble(oRec["assignment_id"]) == 1284))
														{
															UpdateFlag = -1;
														}
														else if ( Convert.ToDouble(oRec["assignment_id"]) >= 575 && Convert.ToDouble(oRec["assignment_id"]) <= 578 )
														{
															UpdateFlag = -1;
														}
														else
														{
															UpdateFlag = 0;
															modGlobal.Shared.gFullShift = 0;
														}

														if ( UpdateFlag != 0 )
														{
                                                        var returningMetodValue213 = DeleteSchedule(Empid, ShiftDate);
														Empid = returningMetodValue213.Empid;
														ShiftDate = returningMetodValue213.ShiftDate;				
														oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
														}
													}
													else
													{
														oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
													}
												}
										});
								}
								return this.Continue<ScheduleEmployeeStruct>();
							});

                        return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = true, ShiftDate = ShiftDate, Empid = Empid, });
					}
				}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmEMSDailySched.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
			}
		}

		public int CheckFullShift(UpgradeHelpers.Helpers.ControlViewModel Source, string ShiftDate, string AMPM)
		{
			//Check to determine if both am & pm shifts are
			//Scheduled for the same assignment to determine if
			//Full shift scheduling automatically done
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
			int AssignID = 0;
			string OtherShiftDate = "";

			string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetWorkingAssignID '" + Empid + "','" + ShiftDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				AssignID = Convert.ToInt32(oRec["assignment_id"]);
			}
			else
			{
				if ( AMPM == "AM" )
				{
					OtherShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
				}
				else
				{
					OtherShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
				}
				oCmd.CommandText = "sp_GetWorkingAssignID '" + Empid + "','" + OtherShiftDate + "'";
				oRec = ADORecordSetHelper.Open(oCmd, "");
				if ( !oRec.EOF )
				{
					//Attempting to reschedule wrong shift
					if ( AMPM == "AM" )
					{
						modGlobal.Shared.gTradeEmp = "PM";
					}
					else
					{
						modGlobal.Shared.gTradeEmp = "AM";
					}
					return 0;
				}
			}
			if ( AMPM == "AM" )
			{
				OtherShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
			}
			else
			{
				OtherShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
			}
			oCmd.CommandText = "sp_GetWorkingAssignID '" + Empid + "','" + OtherShiftDate + "'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				if ( Convert.ToDouble(oRec["assignment_id"]) == AssignID )
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}

		}

		public MoveEmployeeStruct MoveEmployee(string Unit, string ShiftDate, string Empid, string Position)
		{
			using ( var async1 = this.Async<MoveEmployeeStruct>(true) )
			{
				//MoveEmployee function returns:
				//True if position move successful
				//False if move request canceled
				//--------------------------
				//Gather information for Schedule Record
				//(date, employee_id, assignment info)
				//Update Schedule record
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				int PayUp = 0;
				string JobCode = "";
				int Step = 0;
				decimal PayRate = 0;
				decimal NewPayRate = 0;
				decimal LastRate = 0;
				string PayString = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbCommand oCmdUpdate = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				try
				{
					{
						//Request Full Shift Move Info if needed
						if ( modGlobal.Shared.gFullShift != 0 )
						{
                            async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.
                                ShowMessage("Move both AM and PM Schedule Slots?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async1.Append<MoveEmployeeStruct>(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										modGlobal.Shared.gFullShift = -1;
									}
									else if ( Response == UpgradeHelpers.Helpers.DialogResult.No )
									{
										modGlobal.Shared.gFullShift = 0;
									}
									else
									{
                                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
									}
									return this.Continue<MoveEmployeeStruct>();
								});
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
						}
						async1.Append<MoveEmployeeStruct>(() =>
							{
								using ( var async2 = this.Async<MoveEmployeeStruct>() )
								{

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;
									oCmd.CommandText = "sp_GetAssign '" + Unit + "','" + Position + "','" + ViewModel.lbShift.Text + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									modGlobal.Shared.gAssignID = Convert.ToString(oRec["assignment_id"]);
									modGlobal.Shared.gPayType = Convert.ToString(oRec["job_code"]);
									oCmdUpdate.Connection = modGlobal.oConn;
									oCmdUpdate.CommandType = CommandType.StoredProcedure;
									oCmdUpdate.CommandText = "spUpdateScheduleAssign";
									oCmdUpdate.ExecuteNonQuery(new object[] { Empid, ShiftDate, Conversion.Val(modGlobal.Shared.gAssignID), DateTime.Now, modGlobal.Shared.gUser });


									if ( modGlobal.Shared.gFullShift != 0 )
									{
										if ( ShiftDate.Substring(Math.Max(ShiftDate.Length - 2, 0)) == "AM" )
										{
											ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
										}
										else
										{
											ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
										}
										oCmdUpdate.ExecuteNonQuery(new object[] { Empid, ShiftDate, Conversion.Val(modGlobal.Shared.gAssignID), DateTime.Now, modGlobal.Shared.gUser });
									}

									//NEW CODE Added 2/15/2002:
									JobCode = modGlobal.GetJobCode(Empid);
									PayUp = 0;
									// Compare Employee JobCode with Assignment JobCode to determine if
									// a PayUp is valid...
									if ( modGlobal.Shared.gPayType != "40010" )
									{
										if ( JobCode != modGlobal.Shared.gPayType )
										{
											Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
											oCmd.CommandText = "sp_FindPayRate '" + JobCode + "'," + Step.ToString();
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( !oRec.EOF )
											{
												PayRate = Convert.ToDecimal(oRec["pay_rate"]);
												NewPayRate = (decimal)Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
												for ( int i = 1; i <= 11; i++ )
												{
													oCmd.CommandText = "sp_FindPayRate '" + modGlobal.Shared.gPayType + "'," + i.ToString();
													oRec = ADORecordSetHelper.Open(oCmd, "");
													if ( oRec.EOF )
													{
														if ( LastRate > PayRate )
														{
															PayUp = -1;
															Step = i - 1;
															break;
														}
														else
														{
															PayUp = 0;
                                                            return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct(
                                                                ) { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
														}
													}
													else
													{
														if ( ((double)NewPayRate) <= Convert.ToDouble(oRec["pay_rate"]) )
														{
															PayUp = -1;
															Step = i;
															break;
														}
														else
														{
															LastRate = Convert.ToDecimal(oRec["pay_rate"]);
														}
													}
												}
											}
											else
											{
												PayUp = 0;
											}
										}
									}

									// If a PayUp is valid...  send dialog window for verification
									if ( PayUp == (-1) )
									{
										//Display Leave request Dialog
                        modGlobal
                                            .Shared.gLeaveType = "";
										modGlobal.Shared.gVacBank = 0;
										modGlobal.Shared.gSCKFlag = 0;
										modGlobal.Shared.gEmployeeId = Empid;
										modGlobal.Shared.gLType = "P";
                                        async2.Append(() =>
											{
                                                ViewManager.NavigateToView(
                                                    dlgTime.DefInstance, true);
											});
										async2.Append<MoveEmployeeStruct>(() =>
											{
												using ( var async3 = this.Async() )
												{
													if ( modGlobal.Shared.gPayType == "" )
													{
                                                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
													}

													//Determine Step for PayUp
													JobCode = modGlobal.GetJobCode(Empid);
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
													oCmd.CommandText = "sp_FindPayRate '" + JobCode + "'," + Step.ToString();
													oRec = ADORecordSetHelper.Open(oCmd, "");
													if ( !oRec.EOF )
													{
														PayRate = Convert.ToDecimal(oRec["pay_rate"]);
														NewPayRate = (decimal)Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
														for ( int i = 1; i <= 11; i++ )
														{
															oCmd.CommandText = "sp_FindPayRate '" + modGlobal.Shared.gPayType + "'," + i.ToString();
															oRec = ADORecordSetHelper.Open(oCmd, "");
															if ( oRec.EOF )
															{
																if ( LastRate > PayRate )
																{
																	Step = i - 1;
																	break;
																}
																else
																{
                                                                    ViewManager.ShowMessage("The Selected Job does not constitute a Pay Upgrade. Please try a different Job Code.", "Pay Upgrade Error",
                                                                        UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
																}
															}
															else
															{
																if ( ((double)NewPayRate) <= Convert.ToDouble(oRec["pay_rate"]) )
																{
																	Step = i;
																	break;
																}
																else
																{
																	LastRate = Convert.ToDecimal(oRec["pay_rate"]);
																}
															}
														}
													}
													else
													{
														async3.Append<System.String>(() => ViewManager.InputBox("Unable to Calculate New Step. Please Enter Step for this Pay Upgrade.", "Pay Upgrade Step", "1"));
                                                        async3.Append<System.String, System.String>(tempNormalized2 => tempNormalized2);
                                                        async3.Append<System.String>(tempNormalized3 =>
															{
                                                                PayString = tempNormalized3;
															});
														async3.Append<MoveEmployeeStruct>(() =>
															{
																if ( PayString == "" )
																{
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
																}

																double dbNumericTemp = 0;
																if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
																{
                                                                    ViewManager.ShowMessage("Invalid Step, Please try Pay Upgrade again", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons
                                                                        .OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
																}
																else
																{
																	Step = Convert.ToInt32(Conversion.Val(PayString));
																}
																return this.Continue<MoveEmployeeStruct>();
															});
													}
													async3.Append(() =>
														{

															//       06/02/2015 Per Peggy D. When Upgrade to 4001B: Firefighter +5% +5%
															//       calculated step should be the same
															if ( modGlobal.Shared.gPayType == "4001B" )
															{
																if ( JobCode != "40010" )
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																}
																else
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
																}
															}

															//10/8/2002 Per Peggy A. Upgrade to Fire Lieutenant FCC or 40hr keeps Step
															//        If gPayType = "4002F" Then
                                                            if (modGlobal.Shared.gPayType == "4002F" || modGlobal.Shared.gPayType == "4002M" || modGlobal
                                                                    .Shared.gPayType == "41010" || modGlobal.Shared.gPayType == "4002P" || modGlobal.Shared.gPayType == "4002S")
															{
																if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) < 3 )
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																}
															}

															//1/14/2013 Per Peggy D. Upgrade For Tiller Pay is only 1%... so keep step
															if ( modGlobal.Shared.gPayType == "4001V" )
															{
																if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																}
																else
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
																}
															}

															if ( modGlobal.Shared.gPayType == "4001U" )
															{
																if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																}
																else
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
																}
															}

															//1/27/2014 Per Peggy D. Upgrade is only 2.5%... so need following logic
															if ( modGlobal.Shared.gPayType == "4001S" )
															{
																if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																}
																else
																{
																	Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
																}
															}

															//        If gPayType = "4001T" Then
															//            If GetStep(Empid) = 1 Then
															//                Step = GetStep(Empid)
															//            Else
															//                Step = GetStep(Empid) - 1
															//            End If
															//        End If
                                                        oCmd.CommandText = "spUpdateSchedulePay '" + Empid + "','" + ShiftDate + "',1,'" + modGlobal.Shared.
                                                                                    gPayType + "'," + Step.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
															oCmd.ExecuteNonQuery();
															if ( modGlobal.Shared.gFullShift != 0 )
															{
																if ( ShiftDate.Substring(Math.Max(ShiftDate.Length - 2, 0)) == "AM" )
																{
																	ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
																}
																else
																{
																	ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
																}

                                                                oCmd.CommandText = "spUpdateSchedulePay '" + Empid + "','" + ShiftDate + "',1,'" + modGlobal.Shared.
                                                                                        gPayType + "'," + Step.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
																oCmd.ExecuteNonQuery();
																modGlobal.Shared.gFullShift = 0;
															}
														});
												}
												return this.Continue<MoveEmployeeStruct>();
											});
									}
								}
								return this.Continue<MoveEmployeeStruct>();
							});

                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = true, ShiftDate = ShiftDate, Empid = Empid, });
					}
				}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                            return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

                return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmEMSDailySched.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
			}
		}

		public DeleteScheduleStruct DeleteSchedule(string Empid, string ShiftDate)
		{
				//Delete Schedule Record
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				try
				{
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.StoredProcedure;
					oCmd.CommandText = "spDeleteSchedule";
					oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate });
				}
				catch
				{
                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                    return new PTSProject.frmEMSDailySched.DeleteScheduleStruct()
                    { Empid = Empid, ShiftDate = ShiftDate, };
							}
				}

            return new PTSProject.frmEMSDailySched.DeleteScheduleStruct()
            { Empid = Empid, ShiftDate = ShiftDate, };
			}

		public int FindUnit(int Pos)
		{
			//FindUnit function returns:
			//integer value representing
			//approprite Unit Array Index for
			//requested position

			int result = 0;
			if ( Pos >= 0 && Pos <= 3 )
			{
				result = 0;
			}
			else if ( Pos >= 4 && Pos <= 7 )
			{
				result = 1;
			}
			else if ( Pos >= 8 && Pos <= 11 )
			{
				result = 2;
			}
			else if ( Pos >= 12 && Pos <= 15 )
			{
				result = 3;
			}
			else if ( Pos >= 16 && Pos <= 19 )
			{
				result = 4;
			}
			else if ( Pos >= 20 && Pos <= 23 )
			{
				result = 5;
			}
			else if ( Pos >= 24 && Pos <= 27 )
			{
				result = 6;
			}
			else if ( Pos >= 28 && Pos <= 31 )
			{
				result = 7;
			}
			else if ( Pos >= 32 && Pos <= 35 )
			{
				result = 8;
			}
			else if ( Pos >= 36 && Pos <= 39 )
			{
				result = 9;
			}

			return result;
		}


		public void ClearSchedule()
		{
			//Clear all Schedule controls to load new Battalion


			for ( int i = 0; i <= 39; i++ )
			{
				ViewModel.lbPosam[i].Text = "";
				ViewModel.lbPosam[i].Tag = "";
				ViewModel.lbPosam[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPosam[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPospm[i].Text = "";
				ViewModel.lbPospm[i].Tag = "";
				ViewModel.lbPospm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPospm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.shpPayUpAM[i].Visible = false;
				ViewModel.shpPayUpPM[i].Visible = false;
			}

		}

		public void GetSchedule()
		{
				string SaveSecurity = "";
				//Fill Schedule , Query eliminates all employees scheduled for Leave
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string ShiftDate = "";
				string SignOffDate = "";
				PTSProject.clsFireUpload cPayroll = Container.Resolve<clsFireUpload>();

				try
				{
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					SaveSecurity = modGlobal.Shared.gSecurity;
					if ( SaveSecurity != "ADM" )
					{
						if ( SaveSecurity != "BAT" )
						{
							if ( SaveSecurity != "AID" )
							{
								SaveSecurity = "RO";
							}
						}
					}

					oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						modGlobal.Shared.gPayrollYear = Convert.ToInt32(oRec["calendar_year"]);
						modGlobal.Shared.gPayPeriod = Convert.ToInt32(oRec["pay_period"]);
					}
					ViewModel.cmdPayroll.Enabled = false;

					if ( cPayroll.CheckPayRollStatus(modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0 )
					{
						if ( Convert.ToString(cPayroll.PayrollReconciliation["PayrollStatus"]) == "Open" )
						{
							if ( modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "AID" )
							{
								ViewModel.cmdPayroll.Enabled = true;
							}
						}
					}

					ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
					SignOffDate = ShiftDate;
					//    CheckSignOff SignOffDate

					//Get Shift for this Date
					oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						ViewModel.lbShift.Text = Convert.ToString(oRec["shift_code"]).Trim();
					}

					//Select all AM staff and fill form AM label array
					oCmd.CommandText = "sp_GetEMSDailySchedule '" + ShiftDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					if ( oRec.EOF )
					{
						ViewManager.ShowMessage("There are no Schedule records for this date", "Schedule Info", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}


					while ( !oRec.EOF )
					{
						for ( int u = 0; u <= 9; u++ )
						{
							if ( Convert.ToString(oRec["unit_code"]).Trim() == ViewModel.lbUnit[u].Text )
							{
								for ( int P = u * 4; P <= (u * 4) + 3; P++ )
								{
									if ( P > 39 )
									{
										break;
									}
									if ( Convert.ToString(oRec["position_code"]).Trim() == ViewModel.lbPosition[P].Text )
									{
                                    ViewModel.lbPosam[P].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
										ViewModel.lbPosam[P].Tag = Convert.ToString(oRec["employee_id"]);
										if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
										{
											ViewModel.lbPosam[P].Text = ViewModel.lbPosam[P].Text + Convert.ToString(oRec["CSR_flag"]);
										}
										if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
										{
											ViewModel.shpPayUpAM[P].Visible = true;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
										{
											ViewModel.lbPosam[P].ForeColor = modGlobal.Shared.RED;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
										{
											ViewModel.lbPosam[P].ForeColor = modGlobal.Shared.BLUE;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
										{
											ViewModel.lbPosam[P].ForeColor = modGlobal.Shared.GREEN;
										}
										break;
									}
								}
								break;
							}
						}
						oRec.MoveNext();
					}
					;

					//Select all PM staff and fill form PM label array
					ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
					oCmd.CommandText = "sp_GetEMSDailySchedule '" + ShiftDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");


					while ( !oRec.EOF )
					{
						for ( int u = 0; u <= 9; u++ )
						{
							if ( Convert.ToString(oRec["unit_code"]).Trim() == ViewModel.lbUnit[u].Text )
							{
								for ( int P = u * 4; P <= (u * 4) + 3; P++ )
								{
									if ( P > 39 )
									{
										break;
									}
									if ( Convert.ToString(oRec["position_code"]).Trim() == ViewModel.lbPositionPM[P].Text )
									{
                                    ViewModel.lbPospm[P].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
										ViewModel.lbPospm[P].Tag = Convert.ToString(oRec["employee_id"]);
										if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
										{
											ViewModel.lbPospm[P].Text = ViewModel.lbPospm[P].Text + Convert.ToString(oRec["CSR_flag"]);
										}
										if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
										{
											ViewModel.shpPayUpPM[P].Visible = true;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
										{
											ViewModel.lbPospm[P].ForeColor = modGlobal.Shared.RED;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
										{
											ViewModel.lbPospm[P].ForeColor = modGlobal.Shared.BLUE;
										}
										if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
										{
											ViewModel.lbPospm[P].ForeColor = modGlobal.Shared.GREEN;
										}
									}
								}
							}
						}
						oRec.MoveNext();
					}
					;

				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void FillSelectList()
		{
				//Fill Selection Name List with employees of Selected type

				string strName = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_FillEMSList ";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Select all Employees of specific type
					ViewModel.cboSelectName.Items.Clear();


					while ( !oRec.EOF )
					{
                    strName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".    :" + Convert.ToString(oRec["employee_id"]);
						ViewModel.cboSelectName.AddItem(strName);
						oRec.MoveNext();
            };
					}
				catch
				{

            if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void calSchedDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//New date selected
				//Reload Schedule for new date
				//int Response = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				modGlobal.Shared.gCurrentYear = ViewModel.calSchedDate.Value.Date.Year;
				ClearSchedule();
						GetSchedule();
						FillLists();

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboSelectName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Place Selected Employee in DragDrop panel for Scheduling

			//Test to make sure that a name was selected
			if ( ViewModel.cboSelectName.SelectedIndex < 0 )
			{
				return ;
			}
			//Check Security
			if ( !SecurityOK() )
			{
				return ;
			}
			ViewModel.pnSelected.Text = ViewModel.cboSelectName.Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboSelectName.Text) - 10, ViewModel.cboSelectName.Text.Length));
			//Come Here - for employee id change
			ViewModel.pnSelected.Tag = ViewModel.cboSelectName.Text.Substring(Math.Max(ViewModel.cboSelectName.Text.Length - 5, 0));
			ViewModel.pnSelected.Visible = true;

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Refresh Displayed Schedule Data
				ClearSchedule();
						GetSchedule();
						FillLists();
			}

		internal void frmEMSDailySched_Activated(Object eventSender, System.EventArgs eventArgs)
		{
				if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
				{
					UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
							//Call Global Refresh Form subroutine
							//to refresh displayed data on open forms

							modGlobal.RefreshActiveForm();

				}
			}

		//UPGRADE_WARNING: (2065) Form event frmEMSDailySched.Deactivate has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
		[UpgradeHelpers.Events.Handler]
		internal void frmEMSDailySched_Deactivate(Object eventSender, System.EventArgs eventArgs)
		{
						//Call Global Refresh Form subroutine
						//to refresh displayed data on open forms

						modGlobal.RefreshActiveForm();
			}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{

				try
				{

						if ( modGlobal.Shared.gSecurity != "ADM" )
						{
							ViewModel.mnu_transfer_req.Enabled = false;
						}

						if ( modGlobal.Shared.gSecurity == "RO" || modGlobal.Shared.gSecurity == "CPT" )
						{
							ViewModel.mnupayrollreports.Enabled = false;
							ViewModel.mnuImmune.Enabled = false;
						}
						ViewModel.pnSelected.Text = "";
						ViewModel.pnSelected.Tag = "";


								FillSelectList();
									ClearSchedule();
											GetSchedule();
											FillLists();
											ViewModel.cmdPayroll.Enabled = modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID";


											if ( modGlobal.Shared.gDaysWorking < 366 && modGlobal.Shared.gSecurity == "RO" )
											{
												ViewModel.mnuTraining.Enabled = true;
												ViewModel.mnu_trainingtracker.Enabled = false;
											}
											else
											{
												ViewModel.mnuTraining.Enabled = true;
												ViewModel.mnu_trainingtracker.Enabled = true;
											}
								}
				catch
				{

							//If error occurs during Form Load
							//Unload form

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
							{
								ViewManager.DisposeView(this);
								return ;
							}
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Unload Weekly Scheduler form
			//This triggers Form Unload event
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
			modGlobal.Shared.gPayPeriod = 0;
            ViewManager.NavigateToView(
                frmPMRoverPayroll.DefInstance);
			/*            frmPMRoverPayroll.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters

            modGlobal
                .Shared.gRType = "PM";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		private void lbPosam_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPosam.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			string SaveSecurity = "";
			//Detect if Right Mouse Button pressed
			//If so Display Popup Menu

			if ( SaveSecurity == "RO" )
			{
				return ;
			}
			//Check for Paramedic Staff labels
			if ( ViewModel.lbPosam[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
			{
				ViewManager.ShowMessage("You do not have appropriate Security to Schedule on this date", "Paramedic Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPosam[Index];
				if ( ViewModel.lbPosam[Index].Text == "" )
				{
					//blank spot
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuSendTo183.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
				}
				else
				{
					if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.GREEN) )
					{ //Trade

						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = true;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuSendTo183.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
				}

				if ( ViewModel.shpPayUpPM[Index].Visible )
				{
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = true;
				}
				else
				{
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = false;
				}
				ViewModel.Ctx_mnuEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

			}

		}

		private void lbPospm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPospm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			string SaveSecurity = "";
			//Detect if Right Mouse Button pressed
			//If so Display Popup Menu

			if ( SaveSecurity == "RO" )
			{
				return ;
			}
			//Check for Paramedic Staff labels
			if ( ViewModel.lbPospm[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
			{
				ViewManager.ShowMessage("You do not have appropriate Security to Schedule on this date", "Paramedic Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPospm[Index];
				if ( ViewModel.lbPospm[Index].Text == "" )
				{
					//blank spot
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuSendTo183.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
				}
				else
				{
					if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.GREEN) )
					{ //Trade

						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = true;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuSendTo183.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
				}

				if ( ViewModel.shpPayUpPM[Index].Visible )
				{
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = true;
				}
				else
				{
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = false;
				}
				ViewModel.Ctx_mnuEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_emp_facility_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmEmployeeListByStation.DefInstance);
			/*            frmEmployeeListByStation.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndivPayrollSO_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgSignOff.DefInstance);
			/*            dlgSignOff.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndPMRecert_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndPMRecertReport.DefInstance);
			/*            frmIndPMRecertReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndTrainReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndTrainReport.DefInstance);
			/*            frmIndTrainReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_OTEPReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainAnnualOTEP.DefInstance);
			/*            frmTrainAnnualOTEP.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMRecertReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainPMRecert.DefInstance);
			/*            frmTrainPMRecert.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Paramedic Vacation Scheduler 3/2012
            ViewManager.NavigateToView(
                //Display new Paramedic Vacation Scheduler 3/2012
frmPMVacationScheduler.DefInstance);
			/*            frmPMVacationScheduler.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_ReadingAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainReqReading.DefInstance);
			/*            frmTrainReqReading.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_sa_report_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSpecialAssignReport.DefInstance);
			/*            frmSpecialAssignReport.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_transfer_req_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!", vbOKOnly, "Posted Positions / Transfer Request Mgmt"
            ViewManager.NavigateToView(
                //    MsgBox "This Feature is coming soon!", vbOKOnly, "Posted Positions / Transfer Request Mgmt"
frmTransferRequest.DefInstance);
			/*            frmTransferRequest.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_Vacation_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new TFD Vacation Scheduler 9/2004
            ViewManager.NavigateToView(
                //Display new TFD Vacation Scheduler 9/2004
frmVacationScheduler.DefInstance);
			/*            frmVacationScheduler.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_watch_duty_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmWatchDutyAssignment.DefInstance);
			/*            frmWatchDutyAssignment.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;

		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu183_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display TimeCard Worksheet Report form
            modGlobal
                .Shared.gRBatt = "3";
            ViewManager.NavigateToView(
                frmTimeCard3.DefInstance);
            /*            frmTimeCard3.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion4_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            //Display Battalion 5 Scheduler
            ViewManager.NavigateToView(
                //Display Battalion 5 Scheduler
 frmBattSched4.DefInstance);
            /*            frmBattSched4.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattStaff_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display Weekly Scheduler form
 //First Unload it in case it is displayed for different group
            ViewManager.DisposeView(
                //Display Weekly Scheduler form
                //First Unload it in case it is displayed for different group

 frmWeekly.DefInstance);

							modGlobal.Shared.gType = "BAT";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
							;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCascade_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Cascade visible child windows

            MDIForm1.DefInstance.LayoutMdi(Stubs._System.Windows.Forms.MdiLayout.Cascade);

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuClose_Click(Object eventSender, System.EventArgs eventArgs)
		{

			//Close Paramedic Scheduler form
			//This triggers form Unload event
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatch_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display Weekly Scheduler form
 //First Unload it in case it is displayed for different group
            ViewManager.DisposeView(
                //Display Weekly Scheduler form
                //First Unload it in case it is displayed for different group

 frmWeekly.DefInstance);

							modGlobal.Shared.gType = "FCC";
            ViewManager.NavigateToView(
                frmDispatchScheduler.DefInstance);
            /*            frmDispatchScheduler.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
							;
		//    frmWeekly.Show
		//    frmWeekly.Move 0, 0
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatchLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDispatchLeave.DefInstance);
			/*            frmDispatchLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEmpInfo_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display Update Employee Info form
            ViewManager.NavigateToView(

                //Display Update Employee Info form

 frmUpdate.DefInstance);
            /*            frmUpdate.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEMS_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display EMS Weekly Scheduler form
            ViewManager.NavigateToView(
                //Display EMS Weekly Scheduler form
 frmNewEMS.DefInstance);
            /*            frmNewEMS.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuImmune_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Manage Employee Immunizations"
			PTSProject.clsEMSInformation cEMSSecurity = Container.Resolve<clsEMSInformation>();

			if ( cEMSSecurity.GetEMSForSecurity(modGlobal.Shared.gUser) != 0 )
			{
                ViewManager.NavigateToView(
                    frmImmunization.DefInstance);
				/*                frmImmunization.DefInstance.SetBounds(0, 0,                	0, 0, Stubs._System.Windows.                	Forms.BoundsSpecified.X | Stubs.                	_System.Windows.Forms.BoundsSpecified.Y)*/
				;
			//        'MDIForm1.Arrange vbCascade
			}
			else
			{
				ViewManager.ShowMessage("You are not authorized to view/edit this information.", "Manage Employee Immunizations", UpgradeHelpers.Helpers.BoxButtons.OK);
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuindannualpayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndAnnualPayroll.DefInstance);
			/*            frmIndAnnualPayroll.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndSchedule_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display Individual Leave Scheduling form
            ViewManager.NavigateToView(
                //Display Individual Leave Scheduling form

 frmIndSched.DefInstance);
            /*            frmIndSched.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndTimeCard2_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewBatt3_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            //Display new Battalion 3 Scheduler
            ViewManager.NavigateToView(
                //Display new Battalion 3 Scheduler
 frmNewBattSched3.DefInstance);
            ViewManager.SetCurrentView(
                frmNewBattSched3.DefInstance.ViewModel);
            /*            frmNewBattSched3.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnupersonnelsignoff_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPayrollSignOff.DefInstance);
			/*            frmPayrollSignOff.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmNewPPEWDL.DefInstance);
            /*            frmNewPPEWDL.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintPayPeriodReport_Click(Object eventSender, System.EventArgs eventArgs)
		{

			modGlobal.Shared.gRType = "PM";
            ViewManager.HideView(
            frmTimeCardX.DefInstance);

            //Print Timecard Worksheet

 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCardX.DefInstance.ViewModel.sprWeek.setPrintAbortMsg("Printing EMS Pay Period Report - Click Cancel to quit");
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCardX.DefInstance.ViewModel.sprWeek.setPrintBorder(false);
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprWeek.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCardX.DefInstance.ViewModel.sprWeek.setPrintColor(true);
            //    frmTimeCardX.sprWeek.PrintOrientation = 1
            frmTimeCardX.DefInstance.ViewModel.sprWeek.PrintSheet(null);
            //frmTimeCardX.DefInstance.ViewModel.sprWeek.Action = (FarPoint.ViewModels.FPActionConstants)32;
            ViewManager.DisposeView(

 frmTimeCardX.DefInstance);


			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintScreen_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Screen Print Any Form"

			ViewModel.mnuPrintScreen.Enabled = false;
			Stubs._Microsoft.Office.Interop.Word.Application wdApp = new Stubs._Microsoft.Office.Interop.Word.Application();
			int lOrigTop = wdApp.Top;
			wdApp.WindowState = Stubs._Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateNormal;

			// Create a new document.
			object tempRefParam = Type.Missing;
			object tempRefParam2 = Type.Missing;
			object tempRefParam3 = Type.Missing;
			object tempRefParam4 = Type.Missing;
			Stubs._Microsoft.Office.Interop.Word.Document docNew = wdApp.Documents.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4);
			Stubs._Microsoft.Office.Interop.Word.PageSetup withVar = null;
			withVar = docNew.PageSetup;
			withVar.LineNumbering.Active = 0;
			withVar.Orientation = Stubs._Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
			withVar.TopMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
			withVar.BottomMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
			withVar.LeftMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
			withVar.RightMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.2f);
			withVar.Gutter = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
			withVar.HeaderDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
			withVar.FooterDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
			withVar.PageWidth = UpgradeSupport.Word_Global_definst.InchesToPoints(11);
			withVar.PageHeight = UpgradeSupport.Word_Global_definst.InchesToPoints(8.5f);
			withVar.FirstPageTray = Stubs._Microsoft.Office.Interop.Word.WdPaperTray.wdPrinterDefaultBin;
			withVar.OtherPagesTray = Stubs._Microsoft.Office.Interop.Word.WdPaperTray.wdPrinterDefaultBin;
			withVar.SectionStart = Stubs._Microsoft.Office.Interop.Word.WdSectionStart.wdSectionNewPage;
			withVar.OddAndEvenPagesHeaderFooter = 0;
			withVar.DifferentFirstPageHeaderFooter = 0;
			withVar.VerticalAlignment = Stubs._Microsoft.Office.Interop.Word.WdVerticalAlignment.wdAlignVerticalTop;
			withVar.SuppressEndnotes = 0;
			withVar.MirrorMargins = 0;
			withVar.TwoPagesOnOne = false;
			withVar.GutterPos = Stubs._Microsoft.Office.Interop.Word.WdGutterStyle.wdGutterPosLeft;

			//print screen
			wdApp.Selection.Paste();
			//    docNew.PrintPreview
			//    docNew.PrintOut
			//    docNew.ClosePrintPreview

			//    For i = 1 To 150000   ' Start loop.
			//        If i = 1000 = 0 Then
			//            DoEvents   ' Yield to operating system.
			//        End If
			//    Next i   ' Increment loop counter.

			object tempRefParam5 = true;
			object tempRefParam6 = null;
			object tempRefParam7 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintAllDocument;
			object tempRefParam8 = null;
			object tempRefParam9 = null;
			object tempRefParam10 = null;
			object tempRefParam11 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutItem.wdPrintDocumentContent;
			object tempRefParam12 = 1;
			object tempRefParam13 = "";
			object tempRefParam14 = Stubs._Microsoft.Office.Interop.Word.WdPrintOutPages.wdPrintAllPages;
			object tempRefParam15 = false;
			object tempRefParam16 = true;
			object tempRefParam17 = "";
			object tempRefParam18 = null;
			object tempRefParam19 = null;
			object tempRefParam20 = 0;
			object tempRefParam21 = 0;
			object tempRefParam22 = 0;
			object tempRefParam23 = 0;
            wdApp.PrintOut(ref tempRefParam5, ref tempRefParam6, ref tempRefParam7, ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13, ref tempRefParam14, ref tempRefParam15, ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21, ref tempRefParam22, ref tempRefParam23);
			UpgradeSolution1Support.PInvoke.SafeNative.kernel32.Sleep(7000);

			//    For i = 1 To 150000   ' Start loop.
			//        If i = 1000 = 0 Then
			//            DoEvents   ' Yield to operating system.
			//        End If
			//    Next i   ' Increment loop counter.


			object tempRefParam24 = Stubs._Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
			object tempRefParam25 = Type.Missing;
			object tempRefParam26 = Type.Missing;
			wdApp.Quit(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26);
			wdApp = null;
			ViewModel.mnuPrintScreen.Enabled = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSendTo183_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Selected from PopUp Menu
				//Update Schedule to change assignment_id to Batt 2 Rover or Debit
				//Based on current KOT

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				//string StartDate = "", EndDate = "";
				string Empid = "";
				string JobCode = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper orec2 = null;
				string SqlString = "";

				try
				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

						ocmd2.Connection = modGlobal.oConn;
						ocmd2.CommandType = CommandType.Text;

						SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
						SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
						ocmd2.CommandText = SqlString;
						orec2 = ADORecordSetHelper.Open(ocmd2, "");

						modGlobal.Shared.gLeaveType = "";
						if ( !orec2.EOF )
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
						}


						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								modGlobal.Shared.gTradeEmp = "AM";
							}
						}
						else if ( ViewModel.SelectedLabel.Name == "lbPospm" )
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								modGlobal.Shared.gTradeEmp = "PM";
							}
						}
						else
						{
							ViewManager.ShowMessage("Unable to Send to Batt 3 from selected Control", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}
						modGlobal.Shared.gAssignment = 0;
						modGlobal.Shared.gGoToBatt = "3";
						modGlobal.Shared.gBatt = "1";
						async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgSendRover.DefInstance, true);
							});
						async1.Append(() =>
							{

									//If Request canceled - get out
									if ( modGlobal.Shared.gLeaveType == "" )
									{
										this.Return();
										return ;
									}

									JobCode = modGlobal.GetJobCode(Empid);

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.StoredProcedure;
									oCmd.CommandText = "spUpdateSchedule";
									oCmd.ExecuteNonQuery(new object[] { Empid, modGlobal.Shared.gStartTrans, modGlobal.Shared.gEndTrans,
                                    modGlobal.Shared.gAssignment, modGlobal.Shared.gLeaveType, 0, JobCode, DateTime.Now, modGlobal.Shared.gUser });

									modGlobal.Shared.gLeaveType = "";
									modGlobal.Shared.gPayType = "";

									ClearSchedule();
									GetSchedule();
									FillLists();
									});
								}
					}
				catch
				{

                                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSeniorityInq_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Show Seniority Ranking Form
            ViewManager.NavigateToView(
                //Show Seniority Ranking Form
 frmSenority.DefInstance);
            /*            frmSenority.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnutimecard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTrainCodeHelp_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgTrainingCodes.DefInstance);
			/*            dlgTrainingCodes.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuViewDetail_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//    MsgBox "This is being worked on", vbOKOnly, "Work In Progress"
				if ( modGlobal.Clean(ViewModel.SelectedSA) == "" )
				{
					ViewModel.SelectedSA = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
					ViewModel.SelectedSAName = ViewModel.SelectedLabel.Text;
				}
				if ( ViewModel.ClickedLeave )
				{
					async1.Append<System.Int32>(() => modGlobal.ViewLeaveDetail(ViewModel.SelectedSA, ViewModel.SelectedSAName, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")));
					async1.Append<System.Int32, System.Int32>(tempNormalized0 => tempNormalized0);
					async1.Append<System.Int32>(tempNormalized1 =>
						{
							if ( tempNormalized1 != 0 )
							{
							}
						});
				}
				else
				{
					async1.Append<System.Int32>(() => modGlobal.ViewScheduleDetail(ViewModel.SelectedSA, ViewModel.SelectedSAName, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")));
					async1.Append<System.Int32, System.Int32>(tempNormalized2 => tempNormalized2);
					async1.Append<System.Int32>(tempNormalized3 =>
						{
							if ( tempNormalized3 != 0 )
							{
							}
						});
				}
				async1.Append(() =>
					{
						ViewModel.SelectedSA = "";
						ViewModel.SelectedSAName = "";
						ViewModel.ClickedLeave = false;
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void picTrash_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				string SaveSecurity = "";
				//Determine which control has been dropped
				//If it's a schedule label delete schedule record
				//If it's the drag/drop panel replace name in list

				string Empid = "";
				string AMPM = "";
				int SourceIndex = 0;
				string ShiftDate = "";
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				if ( SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				//Do Not allow Trades to be trashed
				if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
				{
					ViewManager.ShowMessage("You can NOT Trash Trades, use Cancel Trade from the Short Cut Menu", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				if ( Source.Name == "pnSelected" )
				{
					ViewModel.pnSelected.Text = "";
					ViewModel.pnSelected.Tag = "";
					ViewModel.pnSelected.Visible = false;
							FillLists();
				}
				else
				{
					Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)).Trim();
					SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
					AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();
					if ( AMPM == "AM" )
					{
						OtherShift = ViewModel.lbPospm[SourceIndex];
					}
					else if ( AMPM == "PM" )
					{
						OtherShift = ViewModel.lbPosam[SourceIndex];
					}
					else
					{
						this.Return();
						return ;
					}

					if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
					{
						ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
					}

					if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
					{
                        async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage
                        ("Send both AM and PM to Trash?", "Remove employee from Schedule", UpgradeHelpers.Helpers.BoxButtons.YesNo));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{
								Response = tempNormalized1;
							});
						async1.Append(() =>
							{
								if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
								{
									modGlobal.Shared.gFullShift = -1;
								}
								else
								{
									modGlobal.Shared.gFullShift = 0;
								}
							});
					}
					async1.Append(() =>
						{
							using ( var async2 = this.Async() )
							{

								//logic for User to add a PersonnelScheduleNote
                                modGlobal
                                    .Shared.gReportUser = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
								modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								modGlobal.Shared.gEndTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
                                async2.Append(() =>
									{
                                        ViewManager.NavigateToView(
                                            frmIndivSchedNote.DefInstance, true);
									});
								async2.Append(() =>
									{

											ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
                                        var returningMetodValue620 = DeleteSchedule(Empid, ShiftDate);
														Empid = returningMetodValue620.Empid;
														ShiftDate = returningMetodValue620.ShiftDate;

														if ( modGlobal.Shared.gFullShift != 0 )
														{
															if ( AMPM == "AM" )
															{
																AMPM = "PM";
															}
															else
															{
																AMPM = "AM";
															}
															ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
                                            var returningMetodValue622 = DeleteSchedule(Empid, ShiftDate);
																	Empid = returningMetodValue622.Empid;
																	ShiftDate = returningMetodValue622.ShiftDate;
																	Source.Text = "";
																	OtherShift.Text = "";
																	UpgradeHelpers.Helpers.ControlHelper.SetTag(Source, "");
																	UpgradeHelpers.Helpers.ControlHelper.SetTag(OtherShift, "");
																	Source.ForeColor = modGlobal.Shared.BLACK;
																	OtherShift.ForeColor = modGlobal.Shared.BLACK;
																	ViewModel.shpPayUpAM[SourceIndex].Visible = false;
																	ViewModel.shpPayUpPM[SourceIndex].Visible = false;
																	modGlobal.Shared.gFullShift = 0;
														}
														else
														{
															Source.Text = "";
															UpgradeHelpers.Helpers.ControlHelper.SetTag(Source, "");
															Source.ForeColor = modGlobal.Shared.BLACK;
															if ( Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper() == "AM" )
															{
																ViewModel.shpPayUpAM[SourceIndex].Visible = false;
															}
															else
															{
																ViewModel.shpPayUpPM[SourceIndex].Visible = false;
															}
														}
												});
										}
									});

							}
				}

			}

		[UpgradeHelpers.Events.Handler]
		internal void lbPosam_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPosam.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				string SaveSecurity = "";
				//Determine Source of Drop:
				//Source could be pnSelected panel containing name from
				//one of the listboxes
				//Or Source could a name from another position in the schedule
				//------------------------------------------
				//Test to make sure that the time slot is open
				//Add or Update Schedule Record

				string ShiftDate = "";
				int SourceIndex = 0;
				string AMPM = "";
				string Empid = "";
				int UnitID = 0;
				//UpgradeHelpers.Helpers.ControlViewModel ThisControl = null;

				if ( Source.ToString() == ViewModel.lbPosam[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				//Check for Battalion Staff labels
				if ( ViewModel.lbPosam[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
				{
					ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				else if ( Source.BackColor.Equals(modGlobal.Shared.MED_GRAY) )
				{
					ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				if ( ViewModel.lbPosam[Index].Text == "" )
				{
					//Time Slot open
					UnitID = FindUnit(Index);
					//Determine if Add or Update Schedule record
					ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
					if ( Source.Name == "pnSelected" )
					{
						//Can both AM & PM be scheduled ?
						//What if employee is already scheduled for pm ?
						if ( ViewModel.lbPospm[Index].Text == "" )
						{
							modGlobal.Shared.gTradeEmp = "";
							if ( CheckFullShift(Source, ShiftDate, "AM") != 0 )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								if ( modGlobal.Shared.gTradeEmp == "PM" )
								{
									ViewManager.ShowMessage("This Trade Employee may only be scheduled for a PM time slot", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
									this.Return();
									return ;
								}
								else
								{
									modGlobal.Shared.gFullShift = 0;
								}
							}
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
						}
						string tempRefParam = Convert.ToString(ViewModel.pnSelected.Tag);
						async1.Append<PTSProject.frmEMSDailySched.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam, ViewModel.lbPosition[Index].Text));
						async1.Append<PTSProject.frmEMSDailySched.ScheduleEmployeeStruct>(tempNormalized1 =>
							{
								var returningMetodValue641 = tempNormalized1;
							
						if ( returningMetodValue641.returnValue )
						{


							ShiftDate = returningMetodValue641.ShiftDate;
							tempRefParam = returningMetodValue641.Empid;
							ViewModel.lbPosam[Index].Text = ViewModel.pnSelected.Text;
							ViewModel.lbPosam[Index].Tag = Convert.ToString(ViewModel.pnSelected.Tag);
							if ( modGlobal.Shared.gFullShift != 0 )
							{
								ViewModel.lbPospm[Index].Text = ViewModel.lbPosam[Index].Text;
								ViewModel.lbPospm[Index].Tag = Convert.ToString(ViewModel.lbPosam[Index].Tag);
							}

							if ( modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "OTP" )
							{
								ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.RED;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.RED;
								}
							}
							else if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
							{
								ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.BLUE;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.BLUE;
								}
							}
							else if ( modGlobal.Shared.gLeaveType == "TRD" )
							{
								ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.GREEN;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.GREEN;
								}
							}

							if ( modGlobal.Shared.gPayType != "" )
							{
								ViewModel.shpPayUpAM[Index].Visible = true;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.shpPayUpPM[Index].Visible = true;
									modGlobal.Shared.gFullShift = 0;
								}
							}
							ViewModel.pnSelected.Text = "";
							ViewModel.pnSelected.Tag = "";
							ViewModel.pnSelected.Visible = false;
									FillLists();
                            }
								});
						}
					else
					{
						//Move employee from current position to this position
						AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();

						if ( AMPM == "AM" )
						{
							SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
							ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
							Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
							//Can both AM & PM be scheduled?
							if ( Convert.ToString(ViewModel.lbPospm[SourceIndex].Tag) == Empid && ViewModel.lbPospm[Index].Text == "" )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
							string tempRefParam2 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
							async1.Append<PTSProject.frmEMSDailySched.MoveEmployeeStruct>(() => MoveEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam2, ViewModel.lbPosition[Index].Text));
							async1.Append<PTSProject.frmEMSDailySched.MoveEmployeeStruct>(tempNormalized3 =>
								{
									var returningMetodValue655 = tempNormalized3;
								
										if ( returningMetodValue655.returnValue )
										{


											ShiftDate = returningMetodValue655.ShiftDate;
											tempRefParam2 = returningMetodValue655.Empid;
											ViewModel.lbPosam[Index].Text = Source.Text;
											ViewModel.lbPosam[Index].Tag = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
											if ( Source.ForeColor.Equals(modGlobal.Shared.BLUE) )
											{
												ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.BLUE;
											}
											else if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
											{
												ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.GREEN;
											}

											if ( ViewModel.shpPayUpAM[SourceIndex].Visible )
											{
												ViewModel.shpPayUpAM[Index].Visible = true;
											}

											if ( modGlobal.Shared.gFullShift != 0 )
											{
												ViewModel.lbPospm[Index].Text = ViewModel.lbPospm[SourceIndex].Text;
												ViewModel.lbPospm[Index].Tag = Convert.ToString(ViewModel.lbPospm[SourceIndex].Tag);
												if ( ViewModel.lbPospm[SourceIndex].ForeColor.Equals(modGlobal.Shared.BLUE) )
												{
													ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.BLUE;
												}
												else if ( ViewModel.lbPospm[SourceIndex].ForeColor.Equals(modGlobal.Shared.GREEN) )
												{
													ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.GREEN;
												}

												if ( ViewModel.shpPayUpPM[SourceIndex].Visible )
												{
													ViewModel.shpPayUpPM[Index].Visible = true;
												}
												ViewModel.lbPospm[SourceIndex].Text = "";
												ViewModel.lbPospm[SourceIndex].Tag = "";
												ViewModel.lbPospm[SourceIndex].ForeColor = modGlobal.Shared.BLACK;
												ViewModel.shpPayUpPM[SourceIndex].Visible = false;
											}

											Source.Text = "";
											UpgradeHelpers.Helpers.ControlHelper.SetTag(Source, "");
											Source.ForeColor = modGlobal.Shared.BLACK;
											ViewModel.shpPayUpAM[SourceIndex].Visible = false;
										}
												cmdRefresh_Click(ViewModel.cmdRefresh, new System.EventArgs());
											});
									}
						else
						{
							//Attempt was made to move a PM to this AM time slot
							ViewManager.ShowMessage("You can only move an AM schedule to this time slot", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							modGlobal.Shared.gLeaveType = "";
							modGlobal.Shared.gPayType = "";
							modGlobal.Shared.gFullShift = 0;
							this.Return();
							return ;
						}
					}
				}
				else
				{
					//Attempt was made to move to a filled position
					ViewManager.ShowMessage("This Time Slot is already scheduled", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				async1.Append(() =>
					{
						modGlobal.Shared.gLeaveType = "";
						modGlobal.Shared.gPayType = "";
						modGlobal.Shared.gFullShift = 0;
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPospm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPospm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				string SaveSecurity = "";
				//Determine Source of Drop:
				//Source could be pnSelected panel containing name from
				//one of the listboxes
				//Or Source could a name from another position in the schedule
				//------------------------------------------
				//Test to make sure that the time slot is open
				//Add or Update Schedule Record

				string ShiftDate = "";
				int SourceIndex = 0;
				string AMPM = "";
				string Empid = "";
				int UnitID = 0;

				if ( Source.ToString() == ViewModel.lbPospm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}


				//Check for Battalion Staff labels
				if ( ViewModel.lbPospm[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
				{
					ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				else if ( Source.BackColor.Equals(modGlobal.Shared.MED_GRAY) )
				{
					ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				//Test to make sure time slot is open
				if ( ViewModel.lbPospm[Index].Text == "" )
				{
					UnitID = FindUnit(Index);
					//Determine if Add or Update schedule record
					ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
					if ( Source.Name == "pnSelected" )
					{
						//Can both AM & PM be scheduled?
						if ( ViewModel.lbPosam[Index].Text == "" )
						{
							modGlobal.Shared.gTradeEmp = "";
							if ( CheckFullShift(Source, ShiftDate, "PM") != 0 )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								if ( modGlobal.Shared.gTradeEmp == "AM" )
								{
									ViewManager.ShowMessage("This Trade Employee may only be scheduled for an AM time slot", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
									this.Return();
									return ;
								}
								else
								{
									modGlobal.Shared.gFullShift = 0;
								}
							}
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
						}
						string tempRefParam = Convert.ToString(ViewModel.pnSelected.Tag);
						async1.Append<PTSProject.frmEMSDailySched.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam, ViewModel.lbPositionPM[Index].Text));
						async1.Append<PTSProject.frmEMSDailySched.ScheduleEmployeeStruct>(tempNormalized1 =>
							{
								var returningMetodValue679 = tempNormalized1;
							
						if ( returningMetodValue679.returnValue )
						{


							ShiftDate = returningMetodValue679.ShiftDate;
							tempRefParam = returningMetodValue679.Empid;
							ViewModel.lbPospm[Index].Text = ViewModel.pnSelected.Text;
							ViewModel.lbPospm[Index].Tag = Convert.ToString(ViewModel.pnSelected.Tag);
							if ( modGlobal.Shared.gFullShift != 0 )
							{
								ViewModel.lbPosam[Index].Text = ViewModel.lbPospm[Index].Text;
								ViewModel.lbPosam[Index].Tag = Convert.ToString(ViewModel.lbPospm[Index].Tag);
							}

							if ( modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "OTP" )
							{
								ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.RED;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.RED;
								}
							}
							else if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
							{
								ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.BLUE;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.BLUE;
								}
							}
							else if ( modGlobal.Shared.gLeaveType == "TRD" )
							{
								ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.GREEN;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.GREEN;
								}
							}

							if ( modGlobal.Shared.gPayType != "" )
							{
								ViewModel.shpPayUpPM[Index].Visible = true;
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									ViewModel.shpPayUpAM[Index].Visible = true;
									modGlobal.Shared.gFullShift = 0;
								}
							}
							ViewModel.pnSelected.Text = "";
							ViewModel.pnSelected.Tag = "";
							ViewModel.pnSelected.Visible = false;
									FillLists();
                            }
								});

						}
					else
					{
						//Move requested
						AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();
						if ( Source.ForeColor.Equals(modGlobal.Shared.BLUE) )
						{
							modGlobal.Shared.gDebitDefault = -1;
						}
						else
						{
							modGlobal.Shared.gDebitDefault = 0;
						}
						if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
						{
							modGlobal.Shared.gTradeDefault = -1;
							modGlobal.Shared.gLeaveType = "TRD";
						}
						else
						{
							modGlobal.Shared.gTradeDefault = 0;
						}
						if ( AMPM == "PM" )
						{
							ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
							Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
							SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
							//Can both AM & PM be scheduled?
							if ( Convert.ToString(ViewModel.lbPosam[SourceIndex].Tag) == Empid && ViewModel.lbPosam[Index].Text == "" )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
							string tempRefParam2 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
							async1.Append<PTSProject.frmEMSDailySched.MoveEmployeeStruct>(() => MoveEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam2, ViewModel.lbPosition[Index].Text));
							async1.Append<PTSProject.frmEMSDailySched.MoveEmployeeStruct>(tempNormalized3 =>
								{
									var returningMetodValue695 = tempNormalized3;
									if ( returningMetodValue695.returnValue )
										{


											ShiftDate = returningMetodValue695.ShiftDate;
											tempRefParam2 = returningMetodValue695.Empid;
											ViewModel.lbPospm[Index].Text = Source.Text;
											ViewModel.lbPospm[Index].Tag = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
											if ( Source.ForeColor.Equals(modGlobal.Shared.BLUE) )
											{
												ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.BLUE;
											}
											else if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
											{
												ViewModel.lbPospm[Index].ForeColor = modGlobal.Shared.GREEN;
											}

											if ( ViewModel.shpPayUpPM[SourceIndex].Visible )
											{
												ViewModel.shpPayUpPM[Index].Visible = true;
											}

											if ( modGlobal.Shared.gFullShift != 0 )
											{
												ViewModel.lbPosam[Index].Text = ViewModel.lbPosam[SourceIndex].Text;
												ViewModel.lbPosam[Index].Tag = Convert.ToString(ViewModel.lbPosam[SourceIndex].Tag);
												if ( ViewModel.lbPosam[SourceIndex].ForeColor.Equals(modGlobal.Shared.BLUE) )
												{
													ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.BLUE;
												}
												else if ( ViewModel.lbPosam[SourceIndex].ForeColor.Equals(modGlobal.Shared.GREEN) )
												{
													ViewModel.lbPosam[Index].ForeColor = modGlobal.Shared.GREEN;
												}

												if ( ViewModel.shpPayUpAM[SourceIndex].Visible )
												{
													ViewModel.shpPayUpAM[Index].Visible = true;
												}
												ViewModel.lbPosam[SourceIndex].Text = "";
												ViewModel.lbPosam[SourceIndex].Tag = "";
												ViewModel.lbPosam[SourceIndex].ForeColor = modGlobal.Shared.BLACK;
												ViewModel.shpPayUpAM[SourceIndex].Visible = false;
											}

											Source.Text = "";
											UpgradeHelpers.Helpers.ControlHelper.SetTag(Source, "");
											Source.ForeColor = modGlobal.Shared.BLACK;
											ViewModel.shpPayUpPM[SourceIndex].Visible = false;
										}
												cmdRefresh_Click(ViewModel.cmdRefresh, new System.EventArgs());
											});
									}
						else
						{
							//Attempt was made to move an AM to this PM time slot
							ViewManager.ShowMessage("You can only move an PM schedule to this time slot", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							modGlobal.Shared.gLeaveType = "";
							modGlobal.Shared.gPayType = "";
							modGlobal.Shared.gFullShift = 0;
							this.Return();
							return ;
						}
					}
				}
				else
				{
					//Attempt was made to schedule a filled time slot
					ViewManager.ShowMessage("This Time Slot is already scheduled", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				async1.Append(() =>
					{
						modGlobal.Shared.gLeaveType = "";
						modGlobal.Shared.gPayType = "";
						modGlobal.Shared.gFullShift = 0;
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion1_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            //Display Battalion 1 Scheduler
            ViewManager.NavigateToView(
                //Display Battalion 1 Scheduler
 frmNewBattSched.DefInstance);
            /*            frmNewBattSched.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
            ViewManager.SetCurrentView(
                frmNewBattSched.DefInstance.ViewModel);
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion2_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            //Display Battalion 2 Scheduler
            ViewManager.NavigateToView(
                //Display Battalion 2 Scheduler
 frmNewBattSched2.DefInstance);
            ViewManager.SetCurrentView(
                frmNewBattSched2.DefInstance.ViewModel);
            /*            frmNewBattSched2.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion3_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            //Display Battalion 4 Scheduler
            ViewManager.NavigateToView(
                //Display Battalion 4 Scheduler
 frmBattSched3.DefInstance);
            /*            frmBattSched3.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuHazmat_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display Weekly Scheduler form
 //First Unload it in case it is displayed for different group
            ViewManager.DisposeView(
                //Display Weekly Scheduler form
                //First Unload it in case it is displayed for different group

 frmWeekly.DefInstance);

							modGlobal.Shared.gType = "HZM";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
							;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuMarine_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Display Weekly Scheduler form
 //First Unload it in case it is displayed for different group
            ViewManager.DisposeView(
                //Display Weekly Scheduler form
                //First Unload it in case it is displayed for different group

 frmWeekly.DefInstance);

							modGlobal.Shared.gType = "MRN";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
							;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_dailysickleave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDailySCKLeaveReport.DefInstance);
			/*            frmDailySCKLeaveReport.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_DDGroups_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDebitReport.DefInstance);
			/*            frmDebitReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndLegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgIndSchedLegend.DefInstance);
			/*            dlgIndSchedLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_legend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgBattLegend.DefInstance);
			/*            dlgBattLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payrolllegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgPayRollLegend.DefInstance);
			/*            dlgPayRollLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payup_calc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgEmployeePayCalc.DefInstance);
			/*            dlgEmployeePayCalc.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmParamedicLeave.DefInstance);
			/*            frmParamedicLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_timecodes_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgTimeCodes.DefInstance);
			/*            dlgTimeCodes.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_trainingtracker_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "TFD Training Tracker"
            ViewManager.NavigateToView(
                //    MsgBox "This Feature is coming soon!!", vbOKOnly, "TFD Training Tracker"
frmPTSTrain.DefInstance);
			/*            frmPTSTrain.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_viewtimecard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = modGlobal.Clean(ViewModel.SelectedSA);
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu181_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display TimeCard Worksheet Report form
            modGlobal
                .Shared.gRBatt = "1";
            ViewManager.NavigateToView(
                frmTimeCard1.DefInstance);
            /*            frmTimeCard1.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu182_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display TimeCard Worksheet Report form
            modGlobal
                .Shared.gRBatt = "2";
            ViewManager.NavigateToView(
                frmTimeCard2.DefInstance);
            /*            frmTimeCard2.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAbout_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Displays About form
            ViewManager.NavigateToView(
                //Displays About form
frmAbout.DefInstance);
			/*            frmAbout.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAnnual_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Processes and Displays Annual Leave Report
			// ***Note  Annual Leave report prints for the current year!!
            modGlobal
                .Shared.gYearReport = DateTime.Now.Year.ToString();
            ViewManager.NavigateToView(
                frmAnnualLeave.DefInstance);
			/*            frmAnnualLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//   'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmAssignReport.DefInstance);
			/*            frmAssignReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters
            modGlobal
                .Shared.gRType = "BAT";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBenefit_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmCF1Report.DefInstance);
			/*            frmCF1Report.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDailyLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Displays Daily Leave Report
            ViewManager.NavigateToView(

                //Displays Daily Leave Report

 frmLeave.DefInstance);
            /*            frmLeave.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDailyStaff_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Daily Staffing Report Form
            ViewManager.NavigateToView(
                //Display Daily Staffing Report Form

frmDailyStaffing.DefInstance);
			/*            frmDailyStaffing.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDisPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters
            modGlobal
                .Shared.gRType = "FCC";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuEMSPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters
            modGlobal
                .Shared.gRType = "PM";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuHazPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters

            modGlobal
                .Shared.gRType = "HZM";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display frmIndivReport
			//There will be no Current Employee Displayed
            ViewManager.NavigateToView(
                //Display frmIndivReport
//There will be no Current Employee Displayed

frmIndivReport.DefInstance);
			/*            frmIndivReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndYearSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gReportYear = DateTime.Now.Year;
            ViewManager.NavigateToView(
                frmIndivSchedReport.DefInstance);
			/*            frmIndivSchedReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuKOT_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Update KOT for Selected Employee
				string Empid = "";
				string ShiftDate = "";
				string AMPM = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
						ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;

						if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of changing KOT for both shifts
						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
						}
						else
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
						}

						//Display Leave request Dialog
                    modGlobal
                            .Shared.gLType = "K";
						modGlobal.Shared.gPayType = "";
						modGlobal.Shared.gLeaveType = "";
						modGlobal.Shared.gVacBank = 0;
						modGlobal.Shared.gSCKFlag = 0;
						modGlobal.Shared.gEmployeeId = Empid;
                        async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgTime.DefInstance, true);
							});
						async1.Append(() =>
							{
								if ( modGlobal.Shared.gLeaveType == "" )
								{
									this.Return();
									return ;
								}

								//Update Schedule time_code
								oCmd.Connection = modGlobal.oConn;
								oCmd.CommandType = CommandType.StoredProcedure;
								oCmd.CommandText = "spUpdateScheduleTime";
								oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, modGlobal.Shared.gLeaveType, DateTime.Now, modGlobal.Shared.gUser });

								if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
								{
									ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLUE;
								}
								else if ( modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "OTP" )
								{
									ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.RED;
								}
								else
								{
									ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
								}

								if ( modGlobal.Shared.gFullShift != 0 )
								{
									if ( AMPM == "AM" )
									{
										AMPM = "PM";
									}
									else
									{
										AMPM = "AM";
									}
									ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
									oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, modGlobal.Shared.gLeaveType, DateTime.Now, modGlobal.Shared.gUser });

									if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
									{
										if ( AMPM == "PM" )
										{
											ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLUE;
										}
										else
										{
											ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLUE;
										}
									}
									else if ( modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "OTP" )
									{
										if ( AMPM == "PM" )
										{
											ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.RED;
										}
										else
										{
											ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.RED;
										}
									}
									else
									{
										if ( AMPM == "PM" )
										{
											ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLACK;
										}
										else
										{
											ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLACK;
										}
									}

								}
							});
					}
				}
				catch
				{

                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Schedule Leave for Selected Employee
				int Response = 0;

				modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");
				modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
				string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

				if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
				{
					ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

				//Determine whether to offer option of scheduling leave for both shifts
				if ( ViewModel.SelectedLabel.Name == "lbPosam" )
				{
					if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
					}
				}
				else
				{
					if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
					}
				}

				modGlobal.Shared.GivingUpShift = false;

				//Display Leave request Dialog
				//Add LEFF 1/2 Code
            modGlobal
                    .Shared.gLType = "L";
				modGlobal.Shared.gPayType = "";
				modGlobal.Shared.gLeaveType = "";
				modGlobal.Shared.gVacBank = 0;
				modGlobal.Shared.gSCKFlag = 0;
				modGlobal.Shared.gEmployeeId = Empid;
                async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            dlgTime.DefInstance, true);
					});
				async1.Append(() =>
					{
						using ( var async2 = this.Async() )
						{
							if ( modGlobal.Shared.gLeaveType == "" )
							{
								this.Return();
								return ;
							}

							//If NOT ExtendLeave - Use Battalion Schedule Date
							//Call ScheduleLeave function
							//Returns True if leave scheduled successfully
							//False if leave request was canceled
							//Else Get Employee Schedule for Start/End Dates and
							//loop - Calling ScheduleLeave Function for every date
							//Returns True if leave scheduled successfully
							//False if leave request was canceled

							if ( ~modGlobal.Shared.gExtendLeave != 0 )
							{
								if ( ViewModel.SelectedLabel.Name == "lbPosam" )
								{
									string tempRefParam = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
									async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, tempRefParam));
                                    async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized1 =>
										{
                                            var returningMetodValue = tempNormalized1;
										

											Response = returningMetodValue.returnValue;

											Empid = returningMetodValue.Empid;

											tempRefParam = returningMetodValue.LeaveDate;
										});
								}
								else
								{
									string tempRefParam2 = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
									async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, tempRefParam2));
                                    async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized3 =>
										{
                                            var returningMetodValue = tempNormalized3;
										

											Response = returningMetodValue.returnValue;

											Empid = returningMetodValue.Empid;

											tempRefParam2 = returningMetodValue.LeaveDate;
										});
								}
								async2.Append(() =>
									{
										using ( var async3 = this.Async() )
										{
											if ( Response != 0 )
											{
												ViewModel.SelectedLabel.Text = "";
												UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
												ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
												if ( ViewModel.SelectedLabel.Name == "lbPosam" )
												{
													ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
												}
												else
												{
													ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
												}
											}

											//If requested to schedule leave for both shifts
											if ( modGlobal.Shared.gFullShift != 0 )
											{
												if ( ViewModel.SelectedLabel.Name == "lbPosam" )
												{
													string tempRefParam3 = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
													async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, tempRefParam3));
                                                    async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized5 =>
														{
                                                            var returningMetodValue = tempNormalized5;
														

															Response = returningMetodValue.returnValue;

															Empid = returningMetodValue.Empid;

															tempRefParam3 = returningMetodValue.LeaveDate;
														});
												}
												else
												{
													string tempRefParam4 = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
													async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, tempRefParam4));
                                                    async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized7 =>
														{
                                                            var returningMetodValue = tempNormalized7;
														
															Response = returningMetodValue.returnValue;

															Empid = returningMetodValue.Empid;

															tempRefParam4 = returningMetodValue.LeaveDate;
														});
												}
												async3.Append(() =>
													{
														if ( Response != 0 )
														{
															if ( ViewModel.SelectedLabel.Name == "lbPosam" )
															{
																ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text = "";
																ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag = "";
																ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLACK;
																ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
															}
															else
															{
																ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text = "";
																ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag = "";
																ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].ForeColor = modGlobal.Shared.BLACK;
																ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
															}
														}
													});
											}
										}
									});
							}
							else
							{
								var ExtendLeaveReturningValue = default(PTSProject.modGlobal.ExtendLeaveStruct);
								async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(() => modGlobal.ExtendLeave(Empid));
                                async2.Append<PTSProject.modGlobal.ExtendLeaveStruct, PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized8 => tempNormalized8);
                                async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized9 =>
									{
                                        ExtendLeaveReturningValue = tempNormalized9;
									});
								async2.Append(() =>
									{

										Response = ExtendLeaveReturningValue.returnValue;

										Empid = ExtendLeaveReturningValue.Empid;
										if ( Response != 0 )
										{
										}
										else
										{
										}
									});
							}
						}
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuMarPay_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Dialog box to select report parameters

            modGlobal
                .Shared.gRType = "MRN";
            ViewManager.NavigateToView(
                frmTimeCardX.DefInstance);
            /*            frmTimeCardX.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("This feature is coming soon!!", "Schedule Employee", UpgradeHelpers.Helpers.BoxButtons.OK);

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuOvertime_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmOvertime.DefInstance);
			/*            frmOvertime.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPayDown_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Remove PayUpgrade from Selected Employees schedule record

				string Empid = "";
				string ShiftDate = "";
				string AMPM = "";
				string JobCode = "";
				int Step = 0;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
						ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;

						if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of removing Pay Upgrade for both shifts
						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible )
							{
								if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
								{
									if ( ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible )
									{
										modGlobal.Shared.gFullShift = -1;
									}
									else
									{
										modGlobal.Shared.gFullShift = 0;
									}
								}
								else
								{
									modGlobal.Shared.gFullShift = 0;
								}
							}
							else
							{
								ViewManager.ShowMessage("No AM Pay Upgrade to Remove, Request Canceled", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
								this.Return();
								return ;
							}
						}
						else
						{
							if ( ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible )
							{
								if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
								{
									if ( ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible )
									{
										modGlobal.Shared.gFullShift = -1;
									}
									else
									{
										modGlobal.Shared.gFullShift = 0;
									}
								}
								else
								{
									modGlobal.Shared.gFullShift = 0;
								}
							}
							else
							{
								ViewManager.ShowMessage("No PM Pay Upgrade to Remove, Request Canceled", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
								this.Return();
								return ;
							}

						}


						//Display Leave request Dialog
						if ( modGlobal.Shared.gFullShift != 0 )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(()
									=> ViewManager.ShowMessage("Would You Like to Remove Pay Upgrade from both AM and PM shifts?", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async1.Append(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.Cancel )
									{
										this.Return();
										return ;
									}
									if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										modGlobal.Shared.gFullShift = -1;
									}
									else
									{
										modGlobal.Shared.gFullShift = 0;
									}
								});
						}
						async1.Append(() =>
							{

								JobCode = modGlobal.GetJobCode(Empid);
								Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

								oCmd.Connection = modGlobal.oConn;
								oCmd.CommandType = CommandType.StoredProcedure;
								oCmd.CommandText = "spUpdateSchedulePay";
								oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

								if ( AMPM == "AM" )
								{
									ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
								}
								else
								{
									ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
								}

								if ( modGlobal.Shared.gFullShift != 0 )
								{
									if ( AMPM == "AM" )
									{
										AMPM = "PM";
									}
									else
									{
										AMPM = "AM";
									}
									ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
									oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

									if ( AMPM == "AM" )
									{
										ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
									}
									else
									{
										ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = false;
									}
									modGlobal.Shared.gFullShift = 0;
								}
							});
					}
				}
				catch
				{

                            if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPayUp_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Determine if new payup or change current payup jobcode
				//Determine if AM, PM or both shifts should be updated
				//if new payup display dlgTime to capture jobcode
				//update Schedule Record

				string Empid = "";
				string ShiftDate = "";
				string AMPM = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string JobCode = "";
				int Step = 0;
				decimal PayRate = 0;
				decimal NewPayRate = 0;
				decimal LastRate = 0;
				string PayString = "";

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
						ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;

						if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of Pay Upgrade for both shifts
						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
						}
						else
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
						}


						//Display Leave request Dialog
                    modGlobal
                            .Shared.gPayType = "";
						modGlobal.Shared.gLeaveType = "";
						modGlobal.Shared.gVacBank = 0;
						modGlobal.Shared.gSCKFlag = 0;
						modGlobal.Shared.gEmployeeId = Empid;
						modGlobal.Shared.gLType = "P";
                        async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgTime.DefInstance, true);
							});
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{
									if ( modGlobal.Shared.gPayType == "" )
									{
										this.Return();
										return ;
									}

									JobCode = modGlobal.GetJobCode(Empid);
									Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;

									//Determine Step for PayUp
									oCmd.CommandText = "sp_FindPayRate '" + JobCode + "'," + Step.ToString();
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if ( !oRec.EOF )
									{
										PayRate = Convert.ToDecimal(oRec["pay_rate"]);
										NewPayRate = (decimal)Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
										for ( int i = 1; i <= 11; i++ )
										{
											oCmd.CommandText = "sp_FindPayRate '" + modGlobal.Shared.gPayType + "'," + i.ToString();
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( oRec.EOF )
											{
												if ( LastRate > PayRate )
												{
													Step = i - 1;
													break;
												}
												else
												{
                                                    ViewManager.ShowMessage("The Selected Job does not constitute a Pay Upgrade. Please try a different Job Code.", "Pay Upgrade Error", UpgradeHelpers
                                                        .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
													this.Return();
													return ;
												}
											}
											else
											{
												if ( ((double)NewPayRate) <= Convert.ToDouble(oRec["pay_rate"]) )
												{
													Step = i;
													break;
												}
												else
												{
													LastRate = Convert.ToDecimal(oRec["pay_rate"]);
												}
											}
										}
									}
									else
									{
										async2.Append<System.String>(() => ViewManager.InputBox("Unable to Calculate New Step. Please Enter Step for this Pay Upgrade.", "Pay Upgrade Step", "1"));
                                        async2.Append<System.String, System.String>(tempNormalized0 => tempNormalized0);
                                        async2.Append<System.String>(tempNormalized1 =>
											{
                                                PayString = tempNormalized1;
											});
										async2.Append(() =>
											{
												if ( PayString == "" )
												{
													this.Return();
													return ;
												}
												double dbNumericTemp = 0;
												if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
												{
													ViewManager.ShowMessage("Invalid Step, Please try Pay Upgrade again", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
													this.Return();
													return ;
												}
												else
												{
													Step = Convert.ToInt32(Conversion.Val(PayString));
												}
											});
									}
									async2.Append(() =>
										{

											//   06/02/2015 Per Peggy D. When Upgrade to 4001B: Firefighter +5% +5%
											//   calculated step should be the same
											if ( modGlobal.Shared.gPayType == "4001B" )
											{
												if ( JobCode != "40010" )
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
												}
												else
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
												}
											}

											//10/8/2002 Per Peggy A. Upgrade to Fire Lieutenant FCC or 40hr keeps Step
											//    If gPayType = "4002F" Then
                                            if (modGlobal.Shared.gPayType == "4002F" || modGlobal.Shared.gPayType == "4002M" || modGlobal
                                                    .Shared.gPayType == "41010" || modGlobal.Shared.gPayType == "4002P" || modGlobal.Shared.gPayType == "4002S")
											{
												if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) < 3 )
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
												}
											}

											//1/14/2013 Per Peggy D. Upgrade For Tiller Pay is only 1%... so keep step
											if ( modGlobal.Shared.gPayType == "4001V" )
											{
												if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
												}
												else
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
												}
											}

											if ( modGlobal.Shared.gPayType == "4001U" )
											{
												if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
												}
												else
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
												}
											}

											//1/27/2014 Per Peggy D. Upgrade is only 2.5%... so need following logic
											if ( modGlobal.Shared.gPayType == "4001S" )
											{
												if ( UpgradeHelpers.Helpers.StringsHelper.ToDoubleSafe(modGlobal.GetStep(Empid)) == 1 )
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
												}
												else
												{
													Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)) - 1);
												}
											}

											//    If gPayType = "4001T" Then
											//        If GetStep(Empid) = 1 Then
											//            Step = GetStep(Empid)
											//        Else
											//            Step = GetStep(Empid) - 1
											//        End If
											//    End If

                                        oCmd.CommandText = "spUpdateSchedulePay '" + Empid + "','" + ShiftDate + "',1,'" + modGlobal.Shared.gPayType + "'," + Step.
                                                        ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
											oCmd.ExecuteNonQuery();

											if ( AMPM == "AM" )
											{
												ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = true;
											}
											else
											{
												ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = true;
											}

											if ( modGlobal.Shared.gFullShift != 0 )
											{
												if ( AMPM == "AM" )
												{
													AMPM = "PM";
												}
												else
												{
													AMPM = "AM";
												}
												ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
                                                oCmd.CommandText = "spUpdateSchedulePay '" + Empid + "','" + ShiftDate + "',1,'" + modGlobal.Shared.
                                                                        gPayType + "'," + Step.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
												oCmd.ExecuteNonQuery();
												if ( AMPM == "AM" )
												{
													ViewModel.shpPayUpAM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = true;
												}
												else
												{
													ViewModel.shpPayUpPM[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Visible = true;
												}
												modGlobal.Shared.gFullShift = 0;
											}
										});
								}
							});
					}
				}
				catch
				{

                                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuProlist_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPromoReport.DefInstance);
			/*            frmPromoReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuRemove_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Remove Selected Employee from Schedule
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;



				string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)).Trim();
				int SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel);
				string AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
				if ( AMPM == "AM" )
				{
					OtherShift = ViewModel.lbPospm[SourceIndex];
				}
				else if ( AMPM == "PM" )
				{
					OtherShift = ViewModel.lbPosam[SourceIndex];
				}
				else
				{
					this.Return();
					return ;
				}

				if ( modPTSPayroll.CheckPayrollForDate(Empid, ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy")) != 0 )
				{
					ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
				{
                    async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager
                            .ShowMessage("Remove both AM and PM Schedule Slots?", "Remove employee from Schedule", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
							}
						});
				}
				async1.Append(() =>
					{
							string ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
                        var returningMetodValue980 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue980.Empid;
										ShiftDate = returningMetodValue980.ShiftDate;

										if ( modGlobal.Shared.gFullShift != 0 )
										{
											if ( AMPM == "AM" )
											{
												AMPM = "PM";
											}
											else
											{
												AMPM = "AM";
											}
											ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
                            var returningMetodValue982 = DeleteSchedule(Empid, ShiftDate);
													Empid = returningMetodValue982.Empid;
													ShiftDate = returningMetodValue982.ShiftDate;
													ViewModel.SelectedLabel.Text = "";
													OtherShift.Text = "";
													UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
													UpgradeHelpers.Helpers.ControlHelper.SetTag(OtherShift, "");
													ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
													OtherShift.ForeColor = modGlobal.Shared.BLACK;
													ViewModel.shpPayUpAM[SourceIndex].Visible = false;
													ViewModel.shpPayUpPM[SourceIndex].Visible = false;
													modGlobal.Shared.gFullShift = 0;
										}
										else
										{
											ViewModel.SelectedLabel.Text = "";
											UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
											ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
											if ( ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper() == "AM" )
											{
												ViewModel.shpPayUpAM[SourceIndex].Visible = false;
											}
											else
											{
												ViewModel.shpPayUpPM[SourceIndex].Visible = false;
											}
										}
								});
						}


			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Load global ReportUser with Selected EmpID
			//open frmIndivReport
            modGlobal
                .Shared.gReportUser = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
			modGlobal.Shared.gReportYear = modGlobal.Shared.gCurrentYear;
            ViewManager.NavigateToView(
                frmIndivReport.DefInstance);
			/*            frmIndivReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuRoster_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmRoster.DefInstance);
			/*            frmRoster.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSendTo181_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Selected from PopUp Menu
				//Update Schedule to change assignment_id to Batt 1 Rover or Debit
				//Based on current KOT

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				//string StartDate = "", EndDate = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();


				modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
				modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
				string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

				ocmd2.Connection = modGlobal.oConn;
				ocmd2.CommandType = CommandType.Text;

				string SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
				SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
				ocmd2.CommandText = SqlString;
				ADORecordSetHelper orec2 = ADORecordSetHelper.Open(ocmd2, "");

				modGlobal.Shared.gLeaveType = "";
				if ( !orec2.EOF )
				{
					modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
				}

				if ( ViewModel.SelectedLabel.Name == "lbPosam" )
				{
					if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
						modGlobal.Shared.gTradeEmp = "AM";
					}
				}
				else if ( ViewModel.SelectedLabel.Name == "lbPospm" )
				{
					if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
						modGlobal.Shared.gTradeEmp = "PM";
					}
				}
				else
				{
					ViewManager.ShowMessage("Unable to Send to Batt 2 from selected Control", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				modGlobal.Shared.gAssignment = 0;
				modGlobal.Shared.gGoToBatt = "1";
				modGlobal.Shared.gBatt = "2";
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            dlgSendRover.DefInstance, true);
					});
				async1.Append(() =>
					{

							//If Request canceled - get out
							if ( modGlobal.Shared.gLeaveType == "" )
							{
								this.Return();
								return ;
							}

							string JobCode = modGlobal.GetJobCode(Empid);

							oCmd.Connection = modGlobal.oConn;
							oCmd.CommandType = CommandType.StoredProcedure;
							oCmd.CommandText = "spUpdateSchedule";
							oCmd.ExecuteNonQuery(new object[] { Empid, modGlobal.Shared.gStartTrans, modGlobal.Shared.gEndTrans,
                            modGlobal.Shared.gAssignment, modGlobal.Shared.gLeaveType, 0, JobCode, DateTime.Now, modGlobal.Shared.gUser });

							modGlobal.Shared.gLeaveType = "";
							modGlobal.Shared.gPayType = "";

							ClearSchedule();
							GetSchedule();
							FillLists();
							});
				this.Return();
				return ;


     //                   if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSendTo182_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Selected from PopUp Menu
				//Update Schedule to change assignment_id to Batt 2 Rover or Debit
				//Based on current KOT

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				//string StartDate = "", EndDate = "";
				string Empid = "";
				string JobCode = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper orec2 = null;
				string SqlString = "";

				try
				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

						ocmd2.Connection = modGlobal.oConn;
						ocmd2.CommandType = CommandType.Text;

						SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
						SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
						ocmd2.CommandText = SqlString;
						orec2 = ADORecordSetHelper.Open(ocmd2, "");

						modGlobal.Shared.gLeaveType = "";
						if ( !orec2.EOF )
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
						}

						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								modGlobal.Shared.gTradeEmp = "AM";
							}
						}
						else if ( ViewModel.SelectedLabel.Name == "lbPospm" )
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								modGlobal.Shared.gTradeEmp = "PM";
							}
						}
						else
						{
							ViewManager.ShowMessage("Unable to Send to Batt 2 from selected Control", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}
						modGlobal.Shared.gAssignment = 0;
						modGlobal.Shared.gGoToBatt = "2";
						modGlobal.Shared.gBatt = "1";
						async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgSendRover.DefInstance, true);
							});
						async1.Append(() =>
							{

									//If Request canceled - get out
									if ( modGlobal.Shared.gLeaveType == "" )
									{
										this.Return();
										return ;
									}

									JobCode = modGlobal.GetJobCode(Empid);

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.StoredProcedure;
									oCmd.CommandText = "spUpdateSchedule";
									oCmd.ExecuteNonQuery(new object[] { Empid, modGlobal.Shared.gStartTrans, modGlobal.Shared.gEndTrans,
                                    modGlobal.Shared.gAssignment, modGlobal.Shared.gLeaveType, 0, JobCode, DateTime.Now, modGlobal.Shared.gUser });

									modGlobal.Shared.gLeaveType = "";
									modGlobal.Shared.gPayType = "";

									ClearSchedule();
									GetSchedule();
									FillLists();
									});
								}
					}
				catch
				{

                                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								this.Return();
								return ;
							}
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSenior_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSrReport.DefInstance);
			/*            frmSrReport.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuShiftCal_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Year Selection dialog box
			//for Shift Calendar report
            ViewManager.NavigateToView(
                //Display Year Selection dialog box
//for Shift Calendar report

frmShiftCal.DefInstance);
			/*            frmShiftCal.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTrainQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
            ViewManager.NavigateToView(
                //    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
frmNewQClass.DefInstance);
			/*            frmNewQClass.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTransfer_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Year Selection dialog box
			//for Transfer Schedule report
            ViewManager.NavigateToView(
                //Display Year Selection dialog box
//for Transfer Schedule report

frmTransReport.DefInstance);
			/*            frmTransReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		private void sprLeave_CellClick(object eventSender, Stubs._FarPoint.Win.Spread.CellClickEventArgs eventArgs)
		{
			int Col = eventArgs.Column;
			int Row = eventArgs.Row;
			if ( Row < 1 )
			{
				return ;
			}
			ViewModel.sprLeave.Row = Row;
			ViewModel.sprLeave.Col = 1;
			if ( modGlobal.Clean(ViewModel.sprLeave.Text) == "" )
			{
				return ;
			}
			else
			{
				ViewModel.SelectedSAName = ViewModel.sprLeave.Text;
			}
			ViewModel.sprLeave.Col = 4;
			ViewModel.SelectedSA = ViewModel.sprLeave.Text;
			ViewModel.ClickedLeave = true;
			ViewModel.mnuViewDetail.Available = true;
			ViewModel.mnuLeave.Available = false;
			ViewModel.mnuPayUp.Available = false;
			ViewModel.mnuPayDown.Available = false;
			ViewModel.mnuKOT.Available = false;
			ViewModel.mnuTrade.Available = false;
			ViewModel.mnuRemove.Available = false;
			ViewModel.mnuSendTo181.Available = false;
			ViewModel.mnuSendTo182.Available = false;
			ViewModel.mnuSendTo183.Available = false;
			ViewModel.mnuReport.Available = false;
			ViewModel.Ctx_mnuEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_QuarterlyMinimumDrill_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainQuarterlyReport.DefInstance);
			/*            frmTrainQuarterlyReport.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_TrainingQuerynew_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
            ViewManager.NavigateToView(
                //    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
frmTrainQuery.DefInstance);
			/*            frmTrainQuery.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public struct ScheduleEmployeeStruct
		{
			public bool returnValue;
			public string ShiftDate;
			public string Empid;
		}

		public struct MoveEmployeeStruct
		{
			public bool returnValue;
			public string ShiftDate;
			public string Empid;
		}

		public struct DeleteScheduleStruct
		{
			public string Empid;
			public string ShiftDate;
		}

		public static frmEMSDailySched DefInstance
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

		public static frmEMSDailySched CreateInstance()
		{
				PTSProject.frmEMSDailySched theInstance = Shared.Container.Resolve<frmEMSDailySched>();
						theInstance.Form_Load();
            return theInstance;
			}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnuEMSPopup_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			ViewModel.Ctx_mnuEMSPopup.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.mnuEMSPopup.Get_DropDownItems())
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.Ctx_mnuEMSPopup.Items.Add(item);
			}
			e.Cancel = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnuEMSPopup_Closing(object sender, Stubs._System.Windows.Forms.ToolStripDropDownClosingEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.Ctx_mnuEMSPopup.Items )
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.mnuEMSPopup.Get_DropDownItems().Add(item);
			}
		}

		void ReLoadForm(bool addEvents)
		{
            ViewManager.NavigateToView(
                PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
            ViewModel.boxUnit[6].LifeCycleStartup();
            ViewModel.shpPayUpPM[35].LifeCycleStartup();
            ViewModel.shpPayUpPM[34].LifeCycleStartup();
            ViewModel.shpPayUpPM[33].LifeCycleStartup();
            ViewModel.shpPayUpPM[32].LifeCycleStartup();
            ViewModel.shpPayUpPM[31].LifeCycleStartup();
            ViewModel.shpPayUpPM[30].LifeCycleStartup();
            ViewModel.shpPayUpPM[29].LifeCycleStartup();
            ViewModel.shpPayUpPM[28].LifeCycleStartup();
            ViewModel.shpPayUpPM[27].LifeCycleStartup();
            ViewModel.shpPayUpPM[26].LifeCycleStartup();
            ViewModel.shpPayUpPM[25].LifeCycleStartup();
            ViewModel.shpPayUpPM[24].LifeCycleStartup();
            ViewModel.shpPayUpPM[23].LifeCycleStartup();
            ViewModel.shpPayUpPM[22].LifeCycleStartup();
            ViewModel.shpPayUpPM[21].LifeCycleStartup();
            ViewModel.shpPayUpPM[20].LifeCycleStartup();
            ViewModel.shpPayUpPM[19].LifeCycleStartup();
            ViewModel.shpPayUpPM[18].LifeCycleStartup();
            ViewModel.shpPayUpPM[17].LifeCycleStartup();
            ViewModel.shpPayUpPM[16].LifeCycleStartup();
            ViewModel.shpPayUpPM[15].LifeCycleStartup();
            ViewModel.shpPayUpPM[14].LifeCycleStartup();
            ViewModel.shpPayUpPM[13].LifeCycleStartup();
            ViewModel.shpPayUpPM[12].LifeCycleStartup();
            ViewModel.shpPayUpPM[11].LifeCycleStartup();
            ViewModel.shpPayUpPM[10].LifeCycleStartup();
            ViewModel.shpPayUpPM[9].LifeCycleStartup();
            ViewModel.shpPayUpPM[8].LifeCycleStartup();
            ViewModel.shpPayUpPM[7].LifeCycleStartup();
            ViewModel.shpPayUpPM[6].LifeCycleStartup();
            ViewModel.shpPayUpPM[5].LifeCycleStartup();
            ViewModel.shpPayUpPM[4].LifeCycleStartup();
            ViewModel.shpPayUpPM[3].LifeCycleStartup();
            ViewModel.shpPayUpPM[2].LifeCycleStartup();
            ViewModel.shpPayUpPM[1].LifeCycleStartup();
            ViewModel.shpPayUpAM[35].LifeCycleStartup();
            ViewModel.shpPayUpAM[34].LifeCycleStartup();
            ViewModel.shpPayUpAM[33].LifeCycleStartup();
            ViewModel.shpPayUpAM[32].LifeCycleStartup();
            ViewModel.shpPayUpAM[31].LifeCycleStartup();
            ViewModel.shpPayUpAM[30].LifeCycleStartup();
            ViewModel.shpPayUpAM[29].LifeCycleStartup();
            ViewModel.shpPayUpAM[28].LifeCycleStartup();
            ViewModel.shpPayUpAM[27].LifeCycleStartup();
            ViewModel.shpPayUpAM[26].LifeCycleStartup();
            ViewModel.shpPayUpAM[25].LifeCycleStartup();
            ViewModel.shpPayUpAM[24].LifeCycleStartup();
            ViewModel.shpPayUpAM[23].LifeCycleStartup();
            ViewModel.shpPayUpAM[22].LifeCycleStartup();
            ViewModel.shpPayUpAM[21].LifeCycleStartup();
            ViewModel.shpPayUpAM[20].LifeCycleStartup();
            ViewModel.shpPayUpAM[19].LifeCycleStartup();
            ViewModel.shpPayUpAM[18].LifeCycleStartup();
            ViewModel.shpPayUpAM[17].LifeCycleStartup();
            ViewModel.shpPayUpAM[16].LifeCycleStartup();
            ViewModel.shpPayUpAM[15].LifeCycleStartup();
            ViewModel.shpPayUpAM[14].LifeCycleStartup();
            ViewModel.shpPayUpAM[13].LifeCycleStartup();
            ViewModel.shpPayUpAM[12].LifeCycleStartup();
            ViewModel.shpPayUpAM[11].LifeCycleStartup();
            ViewModel.shpPayUpAM[10].LifeCycleStartup();
            ViewModel.shpPayUpAM[9].LifeCycleStartup();
            ViewModel.shpPayUpAM[8].LifeCycleStartup();
            ViewModel.shpPayUpAM[7].LifeCycleStartup();
            ViewModel.shpPayUpAM[6].LifeCycleStartup();
            ViewModel.shpPayUpAM[5].LifeCycleStartup();
            ViewModel.shpPayUpAM[4].LifeCycleStartup();
            ViewModel.shpPayUpAM[3].LifeCycleStartup();
            ViewModel.shpPayUpAM[2].LifeCycleStartup();
            ViewModel.shpPayUpAM[1].LifeCycleStartup();
            ViewModel.shpPayUpPM[0].LifeCycleStartup();
            ViewModel.shpPayUpAM[0].LifeCycleStartup();
            ViewModel.boxUnit[1].LifeCycleStartup();
            ViewModel.boxUnit[2].LifeCycleStartup();
            ViewModel.boxUnit[8].LifeCycleStartup();
            ViewModel.boxUnit[7].LifeCycleStartup();
            ViewModel.boxUnit[4].LifeCycleStartup();
            ViewModel.boxUnit[3].LifeCycleStartup();
            ViewModel.boxUnit[0].LifeCycleStartup();
            ViewModel.boxUnit[5].LifeCycleStartup();
            ViewModel.boxUnit[9].LifeCycleStartup();
            ViewModel.shpPayUpAM[36].LifeCycleStartup();
            ViewModel.shpPayUpAM[37].LifeCycleStartup();
            ViewModel.shpPayUpAM[38].LifeCycleStartup();
            ViewModel.shpPayUpAM[39].LifeCycleStartup();
            ViewModel.shpPayUpPM[36].LifeCycleStartup();
            ViewModel.shpPayUpPM[37].LifeCycleStartup();
            ViewModel.shpPayUpPM[38].LifeCycleStartup();
            ViewModel.shpPayUpPM[39].LifeCycleStartup();
			ViewModel.sprLeave.LifeCycleStartup();
			ViewModel.mnuEMSPopup.LifeCycleStartup();
			ViewModel.mnuHelp.LifeCycleStartup();
			ViewModel.mnuWindow.LifeCycleStartup();
			ViewModel.mnuTraining.LifeCycleStartup();
			ViewModel.mnu_Queries.LifeCycleStartup();
			ViewModel.MnuTrnReports.LifeCycleStartup();
			ViewModel.mnuReports.LifeCycleStartup();
			ViewModel.mnu_TrainingReports.LifeCycleStartup();
			ViewModel.mnupayrollreports.LifeCycleStartup();
			ViewModel.mnuLeaveReports.LifeCycleStartup();
			ViewModel.mnuSchedul.LifeCycleStartup();
			ViewModel.mnupayroll.LifeCycleStartup();
			ViewModel.mnuBDWork.LifeCycleStartup();
			ViewModel.mnuperson.LifeCycleStartup();
			ViewModel.mnuSchedule.LifeCycleStartup();
			ViewModel.mnupersonnel.LifeCycleStartup();
			ViewModel.mnuSystem.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
            ViewModel.boxUnit[6].LifeCycleShutdown();
            ViewModel.shpPayUpPM[35].LifeCycleShutdown();
            ViewModel.shpPayUpPM[34].LifeCycleShutdown();
            ViewModel.shpPayUpPM[33].LifeCycleShutdown();
            ViewModel.shpPayUpPM[32].LifeCycleShutdown();
            ViewModel.shpPayUpPM[31].LifeCycleShutdown();
            ViewModel.shpPayUpPM[30].LifeCycleShutdown();
            ViewModel.shpPayUpPM[29].LifeCycleShutdown();
            ViewModel.shpPayUpPM[28].LifeCycleShutdown();
            ViewModel.shpPayUpPM[27].LifeCycleShutdown();
            ViewModel.shpPayUpPM[26].LifeCycleShutdown();
            ViewModel.shpPayUpPM[25].LifeCycleShutdown();
            ViewModel.shpPayUpPM[24].LifeCycleShutdown();
            ViewModel.shpPayUpPM[23].LifeCycleShutdown();
            ViewModel.shpPayUpPM[22].LifeCycleShutdown();
            ViewModel.shpPayUpPM[21].LifeCycleShutdown();
            ViewModel.shpPayUpPM[20].LifeCycleShutdown();
            ViewModel.shpPayUpPM[19].LifeCycleShutdown();
            ViewModel.shpPayUpPM[18].LifeCycleShutdown();
            ViewModel.shpPayUpPM[17].LifeCycleShutdown();
            ViewModel.shpPayUpPM[16].LifeCycleShutdown();
            ViewModel.shpPayUpPM[15].LifeCycleShutdown();
            ViewModel.shpPayUpPM[14].LifeCycleShutdown();
            ViewModel.shpPayUpPM[13].LifeCycleShutdown();
            ViewModel.shpPayUpPM[12].LifeCycleShutdown();
            ViewModel.shpPayUpPM[11].LifeCycleShutdown();
            ViewModel.shpPayUpPM[10].LifeCycleShutdown();
            ViewModel.shpPayUpPM[9].LifeCycleShutdown();
            ViewModel.shpPayUpPM[8].LifeCycleShutdown();
            ViewModel.shpPayUpPM[7].LifeCycleShutdown();
            ViewModel.shpPayUpPM[6].LifeCycleShutdown();
            ViewModel.shpPayUpPM[5].LifeCycleShutdown();
            ViewModel.shpPayUpPM[4].LifeCycleShutdown();
            ViewModel.shpPayUpPM[3].LifeCycleShutdown();
            ViewModel.shpPayUpPM[2].LifeCycleShutdown();
            ViewModel.shpPayUpPM[1].LifeCycleShutdown();
            ViewModel.shpPayUpAM[35].LifeCycleShutdown();
            ViewModel.shpPayUpAM[34].LifeCycleShutdown();
            ViewModel.shpPayUpAM[33].LifeCycleShutdown();
            ViewModel.shpPayUpAM[32].LifeCycleShutdown();
            ViewModel.shpPayUpAM[31].LifeCycleShutdown();
            ViewModel.shpPayUpAM[30].LifeCycleShutdown();
            ViewModel.shpPayUpAM[29].LifeCycleShutdown();
            ViewModel.shpPayUpAM[28].LifeCycleShutdown();
            ViewModel.shpPayUpAM[27].LifeCycleShutdown();
            ViewModel.shpPayUpAM[26].LifeCycleShutdown();
            ViewModel.shpPayUpAM[25].LifeCycleShutdown();
            ViewModel.shpPayUpAM[24].LifeCycleShutdown();
            ViewModel.shpPayUpAM[23].LifeCycleShutdown();
            ViewModel.shpPayUpAM[22].LifeCycleShutdown();
            ViewModel.shpPayUpAM[21].LifeCycleShutdown();
            ViewModel.shpPayUpAM[20].LifeCycleShutdown();
            ViewModel.shpPayUpAM[19].LifeCycleShutdown();
            ViewModel.shpPayUpAM[18].LifeCycleShutdown();
            ViewModel.shpPayUpAM[17].LifeCycleShutdown();
            ViewModel.shpPayUpAM[16].LifeCycleShutdown();
            ViewModel.shpPayUpAM[15].LifeCycleShutdown();
            ViewModel.shpPayUpAM[14].LifeCycleShutdown();
            ViewModel.shpPayUpAM[13].LifeCycleShutdown();
            ViewModel.shpPayUpAM[12].LifeCycleShutdown();
            ViewModel.shpPayUpAM[11].LifeCycleShutdown();
            ViewModel.shpPayUpAM[10].LifeCycleShutdown();
            ViewModel.shpPayUpAM[9].LifeCycleShutdown();
            ViewModel.shpPayUpAM[8].LifeCycleShutdown();
            ViewModel.shpPayUpAM[7].LifeCycleShutdown();
            ViewModel.shpPayUpAM[6].LifeCycleShutdown();
            ViewModel.shpPayUpAM[5].LifeCycleShutdown();
            ViewModel.shpPayUpAM[4].LifeCycleShutdown();
            ViewModel.shpPayUpAM[3].LifeCycleShutdown();
            ViewModel.shpPayUpAM[2].LifeCycleShutdown();
            ViewModel.shpPayUpAM[1].LifeCycleShutdown();
            ViewModel.shpPayUpPM[0].LifeCycleShutdown();
            ViewModel.shpPayUpAM[0].LifeCycleShutdown();
            ViewModel.boxUnit[1].LifeCycleShutdown();
            ViewModel.boxUnit[2].LifeCycleShutdown();
            ViewModel.boxUnit[8].LifeCycleShutdown();
            ViewModel.boxUnit[7].LifeCycleShutdown();
            ViewModel.boxUnit[4].LifeCycleShutdown();
            ViewModel.boxUnit[3].LifeCycleShutdown();
            ViewModel.boxUnit[0].LifeCycleShutdown();
            ViewModel.boxUnit[5].LifeCycleShutdown();
            ViewModel.boxUnit[9].LifeCycleShutdown();
            ViewModel.shpPayUpAM[36].LifeCycleShutdown();
            ViewModel.shpPayUpAM[37].LifeCycleShutdown();
            ViewModel.shpPayUpAM[38].LifeCycleShutdown();
            ViewModel.shpPayUpAM[39].LifeCycleShutdown();
            ViewModel.shpPayUpPM[36].LifeCycleShutdown();
            ViewModel.shpPayUpPM[37].LifeCycleShutdown();
            ViewModel.shpPayUpPM[38].LifeCycleShutdown();
            ViewModel.shpPayUpPM[39].LifeCycleShutdown();
			ViewModel.sprLeave.LifeCycleShutdown();
			ViewModel.mnuEMSPopup.LifeCycleShutdown();
			ViewModel.mnuHelp.LifeCycleShutdown();
			ViewModel.mnuWindow.LifeCycleShutdown();
			ViewModel.mnuTraining.LifeCycleShutdown();
			ViewModel.mnu_Queries.LifeCycleShutdown();
			ViewModel.MnuTrnReports.LifeCycleShutdown();
			ViewModel.mnuReports.LifeCycleShutdown();
			ViewModel.mnu_TrainingReports.LifeCycleShutdown();
			ViewModel.mnupayrollreports.LifeCycleShutdown();
			ViewModel.mnuLeaveReports.LifeCycleShutdown();
			ViewModel.mnuSchedul.LifeCycleShutdown();
			ViewModel.mnupayroll.LifeCycleShutdown();
			ViewModel.mnuBDWork.LifeCycleShutdown();
			ViewModel.mnuperson.LifeCycleShutdown();
			ViewModel.mnuSchedule.LifeCycleShutdown();
			ViewModel.mnupersonnel.LifeCycleShutdown();
			ViewModel.mnuSystem.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmEMSDailySched
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmEMSDailySchedViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmEMSDailySched m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}