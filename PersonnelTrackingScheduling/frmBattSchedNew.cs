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

	public partial class frmBattSchedNew
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmBattSchedNewViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmBattSchedNew));
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
		internal void picTrash_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		private void lstSA_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbTo182_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
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
		internal void cboRovers_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDebit_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_78_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_78.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_78_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_78.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_16_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_16.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_16_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_16.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_17_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_17.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_18_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_18.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_18_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_18.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_32_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_32.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_33_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_33.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_52_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_52.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_52_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_52.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_53_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_53.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_53_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_53.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_54_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_54.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_54_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_54.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_55_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_55.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_55_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_55.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_33_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_33.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_34_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_34.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_34_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_34.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_35_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_35.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_35_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_35.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_32_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_32.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_13_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_13.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_13_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_13.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_14_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_14.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_14_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_14.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_15_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_15.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_15_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_15.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_12_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_12.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_12_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_12.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_19_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_19.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_19_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_19.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_17_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_17.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_76_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_76.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_76_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_76.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_75_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_75.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_75_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_75.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_74_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_74.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_74_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_74.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_73_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_73.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_73_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_73.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_72_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_72.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_72_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_72.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_69_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_69.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_70_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_70.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_70_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_70.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_71_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_71.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_71_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_71.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_69_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_69.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_68_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_68.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_77_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_77.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_77_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_77.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_68_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_68.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_48_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_48.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_49_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_49.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_49_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_49.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_50_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_50.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_50_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_50.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_51_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_51.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_51_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_51.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_48_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_48.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_28_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_28.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_28_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_28.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_29_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_29.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_29_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_29.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_30_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_30.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_30_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_30.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_31_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_31.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_31_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_31.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_10_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_10.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_10_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_10.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_11_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_11.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_11_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_11.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_8_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_8.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_9_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_9.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_9_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_9.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_8_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_8.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_7_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_7.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_7_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_7.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_26_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_26.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_25_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_25.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_25_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_25.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_24_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_24.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_24_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_24.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_26_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_26.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_27_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_27.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_27_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_27.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_46_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_46.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_45_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_45.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_45_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_45.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_44_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_44.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_44_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_44.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_47_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_47.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_47_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_47.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_46_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_46.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_3.BeginDrag();
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
		internal void _lbPosam_21_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_21.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_21_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_21.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_22_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_22.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_22_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_22.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_23_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_23.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_23_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_23.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_40_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_40.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_40_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_40.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_41_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_41.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_41_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_41.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_42_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_42.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_42_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_42.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_43_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_43.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_43_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_43.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_60_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_60.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_60_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_60.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_61_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_61.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_62_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_62.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_61_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_61.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_62_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_62.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_63_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_63.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_63_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_63.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_36_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_36.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_36_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_36.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_37_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_37.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_37_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_37.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_38_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_38.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_38_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_38.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_39_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_39.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_39_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_39.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void pnSelected_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel.pnSelected.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_59_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_59.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_58_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_58.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_57_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_57.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_56_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_56.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_59_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_59.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_58_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_58.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_57_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_57.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_56_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_56.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_64_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_64.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_65_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_65.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_66_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_66.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_67_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_67.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_64_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_64.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_65_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_65.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_66_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_66.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_67_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_67.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_79_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_79.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_79_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_79.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPosam_80_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPosam_80.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPospm_80_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPospm_80.BeginDrag();
		}
		//*****************************************
		//New Battalion 1 Scheduler Since Getting
		//Rid of Battalion 3
		//Form Defaults to Today's Date
		//*****************************************
		//ADODB

		public void FindUnitMinMax(int Unit)
		{

			switch ( Unit )
			{
				case 0: //BC01 

					ViewModel.MinUnitPos = 0;
					ViewModel.MaxUnitPos = 3;
					break;
				case 1: //E01 

					ViewModel.MinUnitPos = 4;
					ViewModel.MaxUnitPos = 7;
					break;
				case 2: //L01 

					ViewModel.MinUnitPos = 8;
					ViewModel.MaxUnitPos = 11;
					break;
				case 3: //E04 

					ViewModel.MinUnitPos = 12;
					ViewModel.MaxUnitPos = 15;
					break;
				case 4: //E09 

					ViewModel.MinUnitPos = 16;
					ViewModel.MaxUnitPos = 19;
					break;
				case 5: //E13 

					ViewModel.MinUnitPos = 20;
					ViewModel.MaxUnitPos = 23;
					break;
				case 6: //E14 

					ViewModel.MinUnitPos = 24;
					ViewModel.MaxUnitPos = 27;
					break;
				case 7: //E16 

					ViewModel.MinUnitPos = 28;
					ViewModel.MaxUnitPos = 31;
					break;
				case 8: //E17 

					ViewModel.MinUnitPos = 32;
					ViewModel.MaxUnitPos = 35;
					break;
				case 9: //SQ13 

					ViewModel.MinUnitPos = 36;
					ViewModel.MaxUnitPos = 39;
					break;
				case 10: //L03 

					ViewModel.MinUnitPos = 40;
					ViewModel.MaxUnitPos = 43;
					break;
				case 11: //M01 

					ViewModel.MinUnitPos = 44;
					ViewModel.MaxUnitPos = 47;
					break;
				case 12: //M04 

					ViewModel.MinUnitPos = 48;
					ViewModel.MaxUnitPos = 51;
					break;
				case 13: // 

					ViewModel.MinUnitPos = 52;
					ViewModel.MaxUnitPos = 55;
					break;
				case 14: // 

					ViewModel.MinUnitPos = 56;
					ViewModel.MaxUnitPos = 59;
					break;
				case 15: //SAF03 

					ViewModel.MinUnitPos = 60;
					ViewModel.MaxUnitPos = 63;
					break;
				case 16: //BC03 

					ViewModel.MinUnitPos = 64;
					ViewModel.MaxUnitPos = 67;
					break;
				case 17: //FCC 

					ViewModel.MinUnitPos = 68;
					ViewModel.MaxUnitPos = 80;
					break;
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

		public void CheckSignOff(string CheckDate)
		{
			//Check Locked/Unlocked status for this date
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			if ( !ViewModel.SignOffAuthority )
			{
				return ;
			}

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetSignOff '" + CheckDate + "','1'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				ViewModel.PayPeriodClosed = Convert.ToInt32(oRec["payroll_status"]);
				ViewModel.CurrPayPeriod = Convert.ToInt32(oRec["pay_period"]);
				ViewModel.CurrSignOff = Convert.ToInt32(oRec["signoff_id"]);
				if ( ViewModel.PayPeriodClosed != 0 )
				{
					if ( modGlobal.Shared.gSecurity == "ADM" )
					{
						if ( Convert.ToBoolean(oRec["shift_status"]) )
						{
							ViewModel.SaveSecurity = "RO";
							ViewModel.cmdSignOff.Text = "&Unlock Schedule";
							ViewModel.cmdSignOff.Enabled = true;
							ViewModel.cmdSignOff.Tag = "2";
							ViewModel.lbLocked.Visible = false;
							ViewModel.lbPeriodClosed.Visible = true;
						}
						else
						{
							ViewModel.cmdSignOff.Text = "&Lock Schedule";
							ViewModel.cmdSignOff.Enabled = true;
							ViewModel.cmdSignOff.Tag = "1";
							ViewModel.lbLocked.Visible = false;
							ViewModel.lbPeriodClosed.Visible = true;
						}
					}
					else
					{
						ViewModel.SaveSecurity = "RO";
						ViewModel.cmdSignOff.Enabled = false;
						ViewModel.cmdSignOff.Text = "&Unlock Schedule";
						ViewModel.cmdSignOff.Tag = "2";
						ViewModel.lbLocked.Visible = false;
						ViewModel.lbPeriodClosed.Visible = true;
					}
				}
				else if ( Convert.ToBoolean(oRec["shift_status"]) )
				{
					ViewModel.SaveSecurity = "RO";
					ViewModel.cmdSignOff.Text = "&Unlock Schedule";
					ViewModel.cmdSignOff.Enabled = true;
					ViewModel.cmdSignOff.Tag = "2";
					ViewModel.lbLocked.Visible = true;
					ViewModel.lbPeriodClosed.Visible = false;
				}
				else
				{
					ViewModel.cmdSignOff.Text = "&Lock Schedule";
					ViewModel.cmdSignOff.Enabled = true;
					ViewModel.cmdSignOff.Tag = "1";
					ViewModel.lbLocked.Visible = false;
					ViewModel.lbPeriodClosed.Visible = false;
				}
			}
			else
			{
				ViewModel.CurrSignOff = 0;
				ViewManager.ShowMessage("There is no existing SignOff record for this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
			}

		}

		public bool ScheduleSA(UpgradeHelpers.Helpers.ControlViewModel Source)
		{
			using ( var async1 = this.Async<bool>(true) )
			{
				//Schedule Special Assignments
				//Determine if one time, for timespan on this shift
				//or 40hr type of SA

				string AMPM = "";
				string Empid = "";
				int AssignID = 0;
				int PayUp = 0;
				string JobCode = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				int FullShiftHolder = 0;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				string DateHold = "";

				try
				{
					{

						//Determine if Drag-Drop from pnSelected Control
						if ( Source.Name == "pnSelected" )
						{
							modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
							modGlobal.Shared.gEndTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
							if ( CheckFullShift(Source, modGlobal.Shared.gStartTrans, "AM") != 0 )
							{
								async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Schedule Both AM & PM?", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
											modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
										}
										else
										{
											modGlobal.Shared.gFullShift = 0;
										}
									});
							}
							else
							{
								if ( modGlobal.Shared.gTradeEmp == "PM" )
								{
									DateHold = modGlobal.Shared.gStartTrans;
									modGlobal.Shared.gStartTrans = modGlobal.Shared.gEndTrans;
									modGlobal.Shared.gEndTrans = DateTime.Parse(DateHold).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
									modGlobal.Shared.gFullShift = 0;
								}
							}
						}
						else
						{

							//Initialize Begin & End dates for Special Assignment to This Date only
							AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();
							if ( AMPM == "AM" )
							{
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
									modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
								}
								else
								{
									modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
									modGlobal.Shared.gEndTrans = modGlobal.Shared.gStartTrans.Substring(0, Math.Min(Strings.Len(modGlobal.Shared.gStartTrans) - 7, modGlobal.Shared.gStartTrans.Length)) + " 7:00PM";
								}
							}
							else
							{
								modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
								modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy") + " 7:00AM";
							}
							async1.Append(() =>
								{

									//Display Special Assignment Dialog, exit sub if cancel selected
                                    ViewManager.NavigateToView(

                                        //Display Special Assignment Dialog, exit sub if cancel selected
dlgSpecialAssign.DefInstance, true);
								});
							async1.Append<bool>(() =>
								{
									if ( modGlobal.Shared.gStartTrans == "" )
									{
										return this.Return<bool>(() => false);
									}
									return this.Continue<bool>();
								});
						}
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{

									//Display Schedule Time dialog for Time Type and Pay Code
                                    modGlobal
                                        .Shared.gReportUser = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
									FullShiftHolder = modGlobal.Shared.gFullShift;
									modGlobal.Shared.gFullShift = 0;
									modGlobal.Shared.gLType = "T";
									modGlobal.Shared.gPayType = "";
									modGlobal.Shared.gLeaveType = "";
									modGlobal.Shared.gVacBank = 0;
									modGlobal.Shared.gSCKFlag = 0;
									modGlobal.Shared.gEmployeeId = Empid;
                                    async2.Append(() =>
										{
                                            ViewManager.NavigateToView(
                                                dlgTime.DefInstance, true);
										});
									async2.Append(() =>
										{
												modGlobal.Shared.gFullShift = FullShiftHolder;

												Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));

												//Set Pay Type variable
												if ( modGlobal.Shared.gPayType == "" )
												{
													//Get current JobCode
													JobCode = modGlobal.GetJobCode(Empid);
													PayUp = 0;
												}
												else
												{
													PayUp = -1;
													JobCode = modGlobal.Shared.gPayType.Trim();
												}

												//Select Special Assignment assignment_id for current Shift
												switch ( ViewModel.lbShift.Text )
												{
													case "A":
														AssignID = 575;
														break;
													case "B":
														AssignID = 576;
														break;
													case "C":
														AssignID = 577;
														break;
													case "D":
														AssignID = 578;
														break;
												}

												oCmd.Connection = modGlobal.oConn;
												oCmd.CommandType = CommandType.StoredProcedure;

												//Update Schedule records
												oCmd.CommandText = "spUpdateScheduleSA";
												oCmd.ExecuteNonQuery(new object[] { Empid, modGlobal.Shared.gStartTrans, modGlobal.Shared.gEndTrans, AssignID, PayUp, JobCode, DateTime.Now, modGlobal.Shared.gUser });

												//Insert Personnel Schedule Note if needed
												if ( modGlobal.Clean(modGlobal.Shared.gLeaveNotes) != "" )
												{
                                                oCmd.CommandText = "spInsertPersonnelScheduleNotes '" + Empid + "','" + modGlobal.Shared.gStartTrans + "','"
                                                            + modGlobal.Clean(modGlobal.Shared.gLeaveNotes) + "','" + modGlobal.Shared.gUser + "' ";
													oCmd.CommandType = CommandType.Text;
													oCmd.ExecuteNonQuery();
													modGlobal.Shared.gLeaveNotes = "";
												}

												//Refresh Displayed Schedule Data
												ClearSchedule();
														GetBattSchedule();
														FillLists();
													});
											}
										});


						return this.Return<bool>(() => true);
					}
				}
				catch
				{

                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return this.Return<bool>(() => false);
							}
				}
				return this.Return<bool>(() => false);
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
                                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                                                            return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct(
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
                                                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
																}

																double dbNumericTemp = 0;
																if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
																{
                                                                    ViewManager.ShowMessage("Invalid Step, Please try Pay Upgrade again", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons
                                                                        .OK, UpgradeHelpers.Helpers.BoxIcons.Error);
                                                                    return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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

															//
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

                        return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = true, ShiftDate = ShiftDate, Empid = Empid, });
					}
				}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                            return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

                return this.Return< MoveEmployeeStruct>(() => new PTSProject.frmBattSchedNew.MoveEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                    return new PTSProject.frmBattSchedNew.DeleteScheduleStruct()
                    { Empid = Empid, ShiftDate = ShiftDate, };
							}
				}

            return new PTSProject.frmBattSchedNew.DeleteScheduleStruct()
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
			else if ( Pos >= 40 && Pos <= 43 )
			{
				result = 10;
			}
			else if ( Pos >= 44 && Pos <= 47 )
			{
				result = 11;
			}
			else if ( Pos >= 48 && Pos <= 51 )
			{
				result = 12;
			}
			else if ( Pos >= 52 && Pos <= 55 )
			{
				result = 13;
			}
			else if ( Pos >= 56 && Pos <= 59 )
			{
				result = 14;
			}
			else if ( Pos >= 60 && Pos <= 63 )
			{
				result = 15;
			}
			else if ( Pos >= 54 && Pos <= 67 )
			{
				result = 16;
			}
			else if ( Pos >= 68 && Pos <= 80 )
			{
				result = 17;
			}

			return result;
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
                            if ((Convert.ToDouble(oRec["assignment_id"]) >= 559 && Convert.ToDouble(oRec["assignment_id"]) < 563) || (Convert.ToDouble(oRec["assignment_id"]) == 1167) || (Convert.ToDouble(oRec["assignment_id"]) == 1283) || (Convert.ToDouble(oRec["assignment_id"]) == 1284))
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
                            else if (modGlobal.Clean(oRec["position_code"]) == "T1" || modGlobal.Clean(oRec["position_code"]) == "T2" || modGlobal.Clean(oRec["position_code"]) == "T3" || modGlobal.Clean(oRec["position_code"]) == "T4")
							{
								UpdateFlag = -1;
							}
							else
							{
								ViewManager.ShowMessage("This Employee is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
                                return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                                        return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
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
                                                var returningMetodValue420 = //Delete old Schedule record
                                             DeleteSchedule(Empid, ShiftDate);
												Empid = returningMetodValue420.Empid;
												ShiftDate = returningMetodValue420.ShiftDate;
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
                                                    else if (modGlobal.Clean(oRec["position_code"]) == "T1" || modGlobal.Clean(oRec["position_code"]) == "T2" || modGlobal.Clean(oRec["position_code"]) == "T3" || modGlobal.Clean(oRec["position_code"]) == "T4")
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
                                                        var returningMetodValue450 = DeleteSchedule(Empid, ShiftDate);
														Empid = returningMetodValue450.Empid;
														ShiftDate = returningMetodValue450.ShiftDate;
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

                        return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = true, ShiftDate = ShiftDate, Empid = Empid, });
					}
				}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

            return this.Return< ScheduleEmployeeStruct>(() => new PTSProject.frmBattSchedNew.ScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, });
			}
		}

		public void FillLists()
		{
				//Fill Rover and Debit combo boxes with appropriate employees

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

					//Fill Rover list box
					oCmd.CommandText = "sp_SpecialList '" + ShiftStart + "','" + ShiftEnd + "'," + modGlobal.ASGN181ROV.ToString();
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.cboRovers.Items.Clear();


					while ( !oRec.EOF )
					{
                    sName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ". -" + Convert.ToString(oRec["rank_code"]).Trim();
						ViewModel.cboRovers.AddItem(sName);
						ViewModel.cboRovers.SetItemData(ViewModel.cboRovers.GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["per_sys_id"]))));
						oRec.MoveNext();
					}
					;
					ViewModel.RovNoClick = -1;
					if ( ViewModel.cboRovers.Items.Count > 0 )
					{
						ViewModel.cboRovers.SelectedIndex = 0;
					}

					//Fill Debit Staff list box
					oCmd.CommandText = "sp_SpecialList '" + ShiftStart + "','" + ShiftEnd + "'," + modGlobal.ASGN181DBT.ToString();
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.cboDebit.Items.Clear();


					while ( !oRec.EOF )
					{
                    sName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ". -" + Convert.ToString(oRec["unit_code"]).Trim();
						ViewModel.cboDebit.AddItem(sName);
						ViewModel.cboDebit.SetItemData(ViewModel.cboDebit.GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["per_sys_id"]))));
						oRec.MoveNext();
					}
					;
					ViewModel.DebNoClick = -1;
					if ( ViewModel.cboDebit.Items.Count > 0 )
					{
						ViewModel.cboDebit.SelectedIndex = 0;
					}

					//Fill Special Assignment Listbox
					oCmd.CommandText = "sp_GetSASchedule '" + ShiftStart + "','" + ShiftEnd + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.lstSA.Items.Clear();

					while ( !oRec.EOF )
					{
						sName = Convert.ToString(oRec["name_last"]).Trim() + ", " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
						ViewModel.lstSA.AddItem(sName);
						ViewModel.lstSA.SetItemData(ViewModel.lstSA.GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["per_sys_id"]))));
						oRec.MoveNext();
					}
					;

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

					oCmd.CommandText = "spReport_GetDailySchLv '" + StartDate + "','" + EndDate + "','1'";
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
					}
					;
					oCmd.CommandText = "spReport_GetDailySckLv '" + StartDate + "','" + EndDate + "','1'";
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

		public void GetBattSchedule()
		{
				//Fill Schedule , Query eliminates all employees scheduled for Leave
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string ShiftDate = "";
				string SignOffDate = "";
				PTSProject.clsFireUpload cPayroll = Container.Resolve<clsFireUpload>();
				//bool bSickLeaveReportDone = false;

				try
				{

					//bSickLeaveReportDone = false;

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					ViewModel.SaveSecurity = modGlobal.Shared.gSecurity;
					if ( ViewModel.SaveSecurity != "ADM" )
					{
						if ( ViewModel.SaveSecurity != "BAT" )
						{
							if ( ViewModel.SaveSecurity != "AID" )
							{
								ViewModel.SaveSecurity = "RO";
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
					ViewModel.cmdPayRoll.Enabled = false;

					if ( cPayroll.CheckPayRollStatus(modGlobal.Shared.gPayrollYear, modGlobal.Shared.gPayPeriod) != 0 )
					{
						if ( Convert.ToString(cPayroll.PayrollReconciliation["PayrollStatus"]) == "Open" )
						{
							if ( ViewModel.SaveSecurity == "BAT" || ViewModel.SaveSecurity == "ADM" || ViewModel.SaveSecurity == "AID" )
							{
								ViewModel.cmdPayRoll.Enabled = true;

							}
						}
					}

					ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
					SignOffDate = ShiftDate;
					CheckSignOff(SignOffDate);

					//Check for Leave Report Update
					oCmd.CommandText = "spReport_CheckLeaveReportUpdate '" + ShiftDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						//bSickLeaveReportDone = true;
					}

					//Get Shift for this Date
					oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					if ( !oRec.EOF )
					{
						ViewModel.lbShift.Text = Convert.ToString(oRec["shift_code"]).Trim();
						modGlobal.Shared.gPayRollShift = Convert.ToString(oRec["shift_code"]).Trim();
						ViewModel.lbDebitGroup.Text = modGlobal.Clean(oRec["debit_group_code"]).Trim();
					}

					//Select Unit / Drill Group for specific Batt
					oCmd.CommandText = "spSelect_UnitDrillGroup ";
					oRec = ADORecordSetHelper.Open(oCmd, "");


					while ( !oRec.EOF )
					{
						for ( int u = 0; u <= 17; u++ )
						{
							if ( Convert.ToString(oRec["unit_code"]).Trim() == ViewModel.lbUnit[u].Text )
							{
								ViewModel.lbDrillGroup[u].Text = "Grp:  " + modGlobal.Clean(oRec["drill_group"]);
								ViewModel.lbDrillGroup[u].Visible = true;
							}
						}
						oRec.MoveNext();
					}
					;


					//Select all AM staff and fill form AM label array
					oCmd.CommandText = "sp_GetBattScheduleNew '" + ShiftDate + "','1'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					if ( oRec.EOF )
					{

						ViewManager.ShowMessage("There are no Schedule records for this date", "Schedule Info", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}


					while ( !oRec.EOF )
					{
						for ( int u = 0; u <= 17; u++ )
						{
							if ( Convert.ToString(oRec["unit_code"]).Trim() == ViewModel.lbUnit[u].Text )
							{
								FindUnitMinMax(u);
								for ( int P = ViewModel.MinUnitPos; P <= ViewModel.MaxUnitPos; P++ )
								{
									//                For P = u * 4 To (u * 4) + 3
									if ( P > 80 )
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
										if ( modGlobal.Clean(oRec["still_gone"]) == "Yes" )
										{
											ViewModel.lbPosam[P].ForeColor = modGlobal.Shared.GRAY;
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
					oCmd.CommandText = "sp_GetBattScheduleNew '" + ShiftDate + "','1'";
					oRec = ADORecordSetHelper.Open(oCmd, "");


					while ( !oRec.EOF )
					{
						for ( int u = 0; u <= 17; u++ )
						{
							if ( Convert.ToString(oRec["unit_code"]).Trim() == ViewModel.lbUnit[u].Text )
							{
								FindUnitMinMax(u);
								for ( int P = ViewModel.MinUnitPos; P <= ViewModel.MaxUnitPos; P++ )
								{
									//                For P = u * 4 To (u * 4) + 3
									if ( P > 80 )
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
										if ( modGlobal.Clean(oRec["still_gone"]) == "Yes" )
										{
											ViewModel.lbPospm[P].ForeColor = modGlobal.Shared.GRAY;
										}
									}
								}
							}
						}
						oRec.MoveNext();
					}
					;

					if ( ViewModel.SaveSecurity != "ADM" )
					{
						if ( ViewModel.SaveSecurity != "BAT" )
						{
						//            lbPosam(0).BackColor = MED_GRAY
						//            lbPosam(1).BackColor = MED_GRAY
						//            lbPospm(0).BackColor = MED_GRAY
						//            lbPospm(1).BackColor = MED_GRAY
						}
                    else if ( ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") != DateTime.Now.ToString("M/d/yyyy") && ViewModel.calSchedDate
                                .Value.Date.ToString("M/d/yyyy") != DateTime.Now.AddDays(-1).ToString("M/d/yyyy") && ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") != DateTime.Now.AddDays(1).ToString("M/d/yyyy"))
						{
						//            lbPosam(0).BackColor = MED_GRAY
						//            lbPospm(0).BackColor = MED_GRAY
						//added this per T.Henderson... ISO leave only scheduled day of...
						//            lbPosam(1).BackColor = MED_GRAY
						//            lbPospm(1).BackColor = MED_GRAY
						}
						else
						{
							ViewModel.lbPosam[0].BackColor = modGlobal.Shared.WHITE;
							ViewModel.lbPospm[0].BackColor = modGlobal.Shared.PARCHMENT;
						}
					}

				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void ClearSchedule()
		{

			for ( int i = 0; i <= 57; i++ )
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
			ViewModel.pnSelected.Text = "";
			ViewModel.pnSelected.Tag = "";
			ViewModel.pnSelected.Visible = false;

		}

		public void GetSchedule()
		{
						//Load Schedule for selected date
						//Fill Rover and Debit listboxes

						GetBattSchedule();
						FillLists();

			}

		[UpgradeHelpers.Events.Handler]
		internal void calSchedDate_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//New date selected
				//Reload Schedule for new date
				//int Response = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();


				if ( ViewModel.FirstTime )
				{
					return ;
				}
				modGlobal.Shared.gCurrentYear = ViewModel.calSchedDate.Value.Date.Year;
				ClearSchedule();
						GetBattSchedule();
						FillLists();

							modGlobal.Shared.gBattSwitchDate = ViewModel.calSchedDate.Value.Date.ToString("MM/dd/yyyy");
							if ( modGlobal.Shared.BattDateChange == 0 )
							{
								modGlobal.Shared.BattDateChange = 1;
							}
            for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
								{
										if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched2" && modGlobal.Shared.BattDateChange != 2 )
										{
                    if ( UpgradeHelpers.Helpers.DateTimeHelper.ToString(frmNewBattSched2.DefInstance.ViewModel.calSchedDate.Value.Date) != modGlobal.Shared.gBattSwitchDate)
												{
                        frmNewBattSched2.DefInstance.ViewModel.calSchedDate.Value = DateTime.Parse(modGlobal.Shared.gBattSwitchDate);
														}
													}
										else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched3" && modGlobal.Shared.BattDateChange != 3 )
										{
                    if ( UpgradeHelpers.Helpers.DateTimeHelper.ToString(frmNewBattSched3.DefInstance.ViewModel.calSchedDate.Value.Date) != modGlobal.Shared.gBattSwitchDate)
												{
                        frmNewBattSched3.DefInstance.ViewModel.calSchedDate.Value = DateTime.Parse(modGlobal.Shared.gBattSwitchDate);
														}
													}
										else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched3" && modGlobal.Shared.BattDateChange != 4 )
										{
                    if ( UpgradeHelpers.Helpers.DateTimeHelper.ToString(frmBattSched3.DefInstance.ViewModel.calSchedDate.Value.Date) != modGlobal.Shared.gBattSwitchDate)
												{
                        frmBattSched3.DefInstance.ViewModel.calSchedDate.Value = DateTime.Parse(modGlobal.Shared.gBattSwitchDate);
														}
													}
										else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmBattSched4" && modGlobal.Shared.BattDateChange != 5 )
										{
                    if ( UpgradeHelpers.Helpers.DateTimeHelper.ToString(frmBattSched4.DefInstance.ViewModel.calSchedDate.Value.Date) != modGlobal.Shared.gBattSwitchDate)
												{
                        frmBattSched4.DefInstance.ViewModel.calSchedDate.Value = DateTime.Parse(modGlobal.Shared.gBattSwitchDate);
														}
													}
										}
									modGlobal.Shared.BattDateChange = 0;

						}

		[UpgradeHelpers.Events.Handler]
		internal void cboDebit_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			//Place selected employee in drag/drop panel
			//and remove from Debit Listbox
			//If drag/drop panel already contains a name display msg and exit

			//Test for no selection made
			if ( ViewModel.cboDebit.SelectedIndex < 0 )
			{
				return ;
			}
			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}
			if ( ViewModel.DebNoClick != 0 )
			{
				ViewModel.DebNoClick = 0;
				return ;
			}

			if ( ViewModel.pnSelected.Text != "" )
			{
				ViewManager.ShowMessage("You must first schedule previously selected employee!", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
				return ;
			}

			string Empid = "";


			//Format EmpID from integer to 5 char field
			int PerSysID = ViewModel.cboDebit.GetItemData(ViewModel.cboDebit.SelectedIndex);

			if ( ~cSched.GetEmployeeIDByPerSysID(PerSysID) != 0 )
			{
				ViewManager.ShowMessage("Oooops!  Something is wrong!  Could not located Employee ID.", "Get Employee ID)", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				Empid = modGlobal.Clean(cSched.PersonnelRecord["employee_id"]);
			}
			//    If Len(Empid) < 5 Then
			//        If Len(Empid) = 4 Then
			//            Empid = "0" & Empid
			//        ElseIf Len(Empid) = 3 Then
			//            Empid = "00" & Empid
			//        ElseIf Len(Empid) = 2 Then
			//            Empid = "000" & Empid
			//        Else
			//            Empid = "0000" & Empid
			//        End If
			//    End If

			//Fill pnSelected panel with data
			//Remove employee from debit list box

			string sName = ViewModel.cboDebit.Text;
			ViewModel.pnSelected.Text = sName;
			ViewModel.pnSelected.Tag = Empid;
			ViewModel.pnSelected.Visible = true;
			modGlobal.Shared.gDebitDefault = -1;

			if ( cSched.CheckForUnscheduledDebit(Empid, modGlobal.Shared.gBattSwitchDate) != 0 )
			{
				modGlobal.Shared.gLeaveType = "UDD";
				modGlobal.Shared.UnschedDebit = true;
			}
			else
			{
				modGlobal.Shared.gLeaveType = "DDF";
				modGlobal.Shared.UnschedDebit = false;
			}

			//Come Here
			//    gLeaveType = "DDF"
			int i = ViewModel.cboDebit.SelectedIndex;
			ViewModel.cboDebit.RemoveItem(i);
			if ( ViewModel.cboDebit.Items.Count > 0 )
			{
				ViewModel.DebNoClick = -1;
				ViewModel.cboDebit.SelectedIndex = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboDebit_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				//Schedule Slot has been dropped on Debit Listbox
				//Delete existing Schedule record and
				//Schedule employee as generic Debit
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;

				if ( ViewModel.SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				//If Drag originated from Selected Panel or
				//Trade Employee exit sub
				if ( Source.Name == "pnSelected" )
				{
					this.Return();
					return ;
				}
				if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
				{
					ViewManager.ShowMessage("You cannot move a TRADE to the Debit List.", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}


				//Determine if full shift to be transfered to Debit
				int SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
				string AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();
				if ( AMPM == "AM" )
				{
					OtherShift = ViewModel.lbPospm[SourceIndex];
				}
				else
				{
					OtherShift = ViewModel.lbPosam[SourceIndex];
				}
				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Replace both AM and PM in Debit List?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}
				async1.Append(() =>
					{

							string ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
							string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
                        var returningMetodValue689 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue689.Empid;
										ShiftDate = returningMetodValue689.ShiftDate;

										string JobCode = modGlobal.GetJobCode(Empid);
										int Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

										oCmd.Connection = modGlobal.oConn;
										oCmd.CommandType = CommandType.StoredProcedure;
										oCmd.CommandText = "spInsertSchedule";
										//Come Here
										oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181DBT, "DDF", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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
                            var returningMetodValue697 = DeleteSchedule(Empid, ShiftDate);
													Empid = returningMetodValue697.Empid;
													ShiftDate = returningMetodValue697.ShiftDate;
													//Come Here
													oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181DBT, "DDF", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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

												FillLists();
											});
				this.Return();
				return ;


     //           if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRovers_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			//Place selected employee in drag/drop panel and remove from Rover Listbox
			//If drag/drop panel already contains a name display msg and exit

			//Test for no selection made
			if ( ViewModel.cboRovers.SelectedIndex < 0 )
			{
				return ;
			}
			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}
			if ( ViewModel.RovNoClick != 0 )
			{
				ViewModel.RovNoClick = 0;
				return ;
			}

			if ( ViewModel.pnSelected.Text != "" )
			{
				ViewManager.ShowMessage("You must first schedule previously selected employee!", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
				return ;
			}

			string Empid = "";

			//Format EmpID from integer to 5 char
			int PerSysID = ViewModel.cboRovers.GetItemData(ViewModel.cboRovers.SelectedIndex);

			if ( ~cSched.GetEmployeeIDByPerSysID(PerSysID) != 0 )
			{
				ViewManager.ShowMessage("Oooops!  Something is wrong!  Could not located Employee ID.", "Get Employee ID)", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				Empid = modGlobal.Clean(cSched.PersonnelRecord["employee_id"]);
			}

			//    If Len(Empid) < 5 Then
			//        If Len(Empid) = 4 Then
			//            Empid = "0" & Empid
			//        ElseIf Len(Empid) = 3 Then
			//            Empid = "00" & Empid
			//        ElseIf Len(Empid) = 2 Then
			//            Empid = "000" & Empid
			//        Else
			//            Empid = "0000" & Empid
			//        End If
			//    End If

			//Fill pnSelected panel with data
			//Remove employee from Rover list box

			string sName = ViewModel.cboRovers.Text;
			ViewModel.pnSelected.Text = sName;
			ViewModel.pnSelected.Tag = Empid;
			ViewModel.pnSelected.Visible = true;
			modGlobal.Shared.gDebitDefault = 0;
			int i = ViewModel.cboRovers.SelectedIndex;
			ViewModel.cboRovers.RemoveItem(i);
			if ( ViewModel.cboRovers.Items.Count > 0 )
			{
				ViewModel.RovNoClick = -1;
				ViewModel.cboRovers.SelectedIndex = 0;
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cboRovers_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				//Schedule Slot has been dropped on Rover Listbox
				//Delete existing Schedule record and
				//Schedule employee as generic Rover
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				string KOT = "";

				if ( ViewModel.SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				//If Drag originated from Selected Panel or
				//Trade Employee exit sub
				if ( Source.Name == "pnSelected" )
				{
					this.Return();
					return ;
				}
				if ( Source.ForeColor.Equals(modGlobal.Shared.BLUE) )
				{
					ViewManager.ShowMessage("You cannot move a DEBIT to the Rover List.", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
				{
					KOT = "TRD";
				//        MsgBox "You cannot move a TRADE to the Rover List.", vbOKOnly, "Battalion Scheduler"
				//        Exit Sub
				//    End If
				}
				else if ( Source.ForeColor.Equals(modGlobal.Shared.RED) )
				{
					KOT = "OTP";
				}
				else
				{
					KOT = "REG";
				}

				//Determine if full shift to be transfered to Rover
				int SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
				string AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0)).ToUpper();
				if ( AMPM == "AM" )
				{
					OtherShift = ViewModel.lbPospm[SourceIndex];
				}
				else
				{
					OtherShift = ViewModel.lbPosam[SourceIndex];
				}
				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Replace both AM and PM in Rover List?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}
				async1.Append(() =>
					{

							string ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
							string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));
                        var returningMetodValue734 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue734.Empid;
										ShiftDate = returningMetodValue734.ShiftDate;

										string JobCode = modGlobal.GetJobCode(Empid);
										int Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

										oCmd.Connection = modGlobal.oConn;
										oCmd.CommandType = CommandType.StoredProcedure;
										oCmd.CommandText = "spInsertSchedule";
										oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181ROV, KOT, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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
                                            var returningMetodValue742 = DeleteSchedule(Empid, ShiftDate);
											Empid = returningMetodValue742.Empid;
											ShiftDate = returningMetodValue742.ShiftDate;
											oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181ROV, KOT, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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

												FillLists();
											});
				this.Return();
				return ;


     //           if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdAvailToWork_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            dlgAvailableToWork.DefInstance, true);
					});
				async1.Append(() =>
					{

							//Refresh Displayed Schedule Data
							ClearSchedule();
									GetBattSchedule();
									FillLists();
								});
						}

			}

		//UPGRADE_NOTE: (7001) The following declaration (cmdBatt3_Click) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private void cmdBatt3_Click()
		//{
		//
		//frmNewBattSched3.DefInstance.Show();
		//frmNewBattSched3.DefInstance.Activate();
		//    frmNewBattSched3.Move 0, 0
		//    'MDIForm1.Arrange vbCascade
		//
		//}
		[UpgradeHelpers.Events.Handler]
		internal void cmdBattWorkSheet_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gBatt = "1";
            ViewManager.NavigateToView(
                frmDailyBattWorksheet.DefInstance);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdListGray_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
            ViewManager.NavigateToView(
                frmGrayListByDate.DefInstance);
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdMissing_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");
				modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
				modGlobal.Shared.gBatt = "1";
				async1.Append(() =>
					{
                        ViewManager.NavigateToView(
                            frmMissingFromSchedule.DefInstance, true);
					});
				async1.Append(() =>
					{

							//Refresh Displayed Schedule Data
							ClearSchedule();
									GetBattSchedule();
									FillLists();
								});
						}

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Battalion Notes Form
				if ( ViewModel.SaveSecurity == "RO" )
				{
					if ( modGlobal.Shared.gSecurity == "CPT" )
					{
					//continue
					}
					else
					{
						return ;
					}
				}

				modGlobal.Shared.gNoteDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmNote.DefInstance);
            /*            frmNote.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPayRoll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayRollBatt = "1";
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
            ViewManager.NavigateToView(
                frmBCPayRoll.DefInstance);
			/*            frmBCPayRoll.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdRefresh_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Refresh Displayed Schedule Data
            modGlobal
                .Shared.gBattSwitchDate = ViewModel.calSchedDate.Value.Date.ToString("MM/dd/yyyy");
				ClearSchedule();
						GetBattSchedule();
						FillLists();

            //    If BattDateChange = 0 Then
            //        BattDateChange = 1
            //    End If

            for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
					{
							if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched2" )
							{
                    frmNewBattSched2.DefInstance.ClearSchedule();
                    frmNewBattSched2.DefInstance.GetBattSchedule();
                    frmNewBattSched2.DefInstance.FillLists();
							}
							else if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched3" )
							{
                    frmNewBattSched3.DefInstance.ClearSchedule();
                    frmNewBattSched3.DefInstance.GetBattSchedule();
                    frmNewBattSched3.DefInstance.FillLists();
							}
						}
						modGlobal.Shared.BattDateChange = 0;

			}

		//Private Sub cmdSetLineUp_Click()
		//    Dim cSchedule As New clsScheduler
		//    Dim sDate As String
		//    Dim sBatt As String
		//    Dim iResponse As Integer
		//
		//    sDate = Format$(calSchedDate.Date, "m/d/yyyy")
		//    sBatt = "1"
		//
		//    If cSchedule.GetBattLineupCompleteByBattDate(sBatt, sDate) Then
		//    'Update or Delete
		//        cSchedule.BattLineupUpdatedDate = Format$(Now(), "mm/dd/yyyy hh:nn:ss")
		//        cSchedule.BattLineupUpdatedBy = gUser
		//        If cSchedule.UpdateBattalionLineUpComplete Then
		//            'successful
		//            iResponse = MsgBox("Did you want to DELETE the Lineup Complete Record?", vbYesNo, "Undo or Redo Lineup Complete")
		//            If iResponse = vbYes Then
		//                'Delete Record
		//                If cSchedule.DeleteBattalionLineUpComplete Then
		//                    'successful
		//                Else
		//                    MsgBox "Oooops! Something went wrong with the BattalionLineUpComplete delete!", vbOKOnly, "Delete Lineup"
		//                End If
		//            End If
		//        Else
		//            MsgBox "Oooops! Something went wrong with the BattalionLineUpComplete update!", vbOKOnly, "Update Lineup"
		//        End If
		//    Else
		//    'Insert
		//        cSchedule.BattLineupBattCode = sBatt
		//        cSchedule.BattLineupDate = sDate
		//        cSchedule.BattLineupUpdatedDate = Format$(Now(), "mm/dd/yyyy hh:nn:ss")
		//        cSchedule.BattLineupUpdatedBy = gUser
		//        If cSchedule.InsertBattalionLineUpComplete Then
		//            'successful
		//        Else
		//            MsgBox "Oooops! Something went wrong with the BattalionLineUpComplete insert!", vbOKOnly, "Insert Lineup"
		//        End If
		//    End If
		//
		//    CheckLineup
		//
		//End Sub
		[UpgradeHelpers.Events.Handler]
		internal void cmdSignOff_Click(Object eventSender, System.EventArgs eventArgs)
		{

				//Sign off on this dates schedule
				//Or Unlock this dates schedule
				//Create Signoff and Signoff Log records as needed

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//int Response = 0;

				oCmd.Connection = modGlobal.oConn;
				oCmd.CommandType = CommandType.Text;

				//Logic to create Signoff records
				if ( Convert.ToString(ViewModel.cmdSignOff.Tag) == "1" )
				{ //Lock Schedule

					ViewModel.cmdSignOff.Text = "&Unlock Schedule";
					ViewModel.cmdSignOff.Tag = "2";
					oCmd.CommandText = "spUpdateSignOff " + ViewModel.CurrSignOff.ToString() + ",1";
					oCmd.ExecuteNonQuery();
					oCmd.CommandText = "spInsert_ActivityLog " + ViewModel.CurrSignOff.ToString() + ",'" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',1";
					oCmd.ExecuteNonQuery();
					ViewManager.ShowMessage("Battalion 1 Schedule for this date" + "\n" + "Logged as Locked by " + modGlobal.Shared.gUserName, "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
				}
				else
				{
					if ( ViewModel.PayPeriodClosed != 0 )
					{
						//            If SaveSecurity = "ADM" Or SaveSecurity = "PER" Then
						if ( ViewModel.SaveSecurity == "ADM" )
						{
							ViewModel.cmdSignOff.Tag = "1";
							oCmd.CommandText = "spUpdateSignOff " + ViewModel.CurrSignOff.ToString() + ",0";
							oCmd.ExecuteNonQuery();
							oCmd.CommandText = "spInsert_ActivityLog " + ViewModel.CurrSignOff.ToString() + ",'" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',2";
							oCmd.ExecuteNonQuery();
							ViewManager.ShowMessage("Battalion 1 Schedule for this date" + "\n" + "Logged as Unlocked by " + modGlobal.Shared.gUserName, "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						}
						else
						{
                        ViewManager.ShowMessage("This date is within a Closed PayRoll Period" + "\n" + "Please Contact HQ to make a PayRoll Correction", "Battalion Scheduler"
                            , UpgradeHelpers.Helpers.BoxButtons.OK);
							return ;
						}
					}
					else
					{
						ViewModel.cmdSignOff.Text = "&Lock Schedule"; //Unlock Schedule

						ViewModel.cmdSignOff.Tag = "1";
						oCmd.CommandText = "spUpdateSignOff " + ViewModel.CurrSignOff.ToString() + ",0";
						oCmd.ExecuteNonQuery();
						oCmd.CommandText = "spInsert_ActivityLog " + ViewModel.CurrSignOff.ToString() + ",'" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "',2";
						oCmd.ExecuteNonQuery();
						ViewManager.ShowMessage("Battalion 1 Schedule for this date" + "\n" + "Logged as Unlocked by " + modGlobal.Shared.gUserName, "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
				}

				ClearSchedule();
						GetBattSchedule();

			}

		[UpgradeHelpers.Events.Handler]
		internal void cmdBatt2_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(

 frmBatt2SchedNew.DefInstance);
            //    frmBatt2SchedNew.Move 0, 0
            ViewManager.SetCurrentView(
                //    frmBatt2SchedNew.Move 0, 0
                frmBatt2SchedNew.DefInstance.ViewModel);
		//    'MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdToday_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.calSchedDate.Value = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
		}

		internal void frmBattSchedNew_Activated(Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
			//Call Global Refresh Form subroutine
			//to refresh displayed data on open forms

			//    RefreshActiveForm
			}
		}

		//UPGRADE_WARNING: (2065) Form event frmBattSchedNew.Deactivate has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
		[UpgradeHelpers.Events.Handler]
		internal void frmBattSchedNew_Deactivate(Object eventSender, System.EventArgs eventArgs)
		{
		//Call Global Refresh Form subroutine
		//to refresh displayed data on open forms

		//    RefreshActiveForm

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
				//int i = 0;
				ViewModel.FirstTime = true;
				ViewModel.calSchedDate.Value = DateTime.Parse(modGlobal.Shared.gBattSwitchDate);
				ViewModel.pnSelected.Text = "";
				ViewModel.pnSelected.Tag = "";
				ViewModel.RovNoClick = -1;
				ViewModel.DebNoClick = -1;
				ViewModel.SignOffAuthority = false;
				ViewModel.SaveSecurity = modGlobal.Shared.gSecurity;

				if ( ViewModel.SaveSecurity != "ADM" && ViewModel.SaveSecurity != "BAT" && ViewModel.SaveSecurity != "AID" )
				{
					ViewModel.SaveSecurity = "RO";
					ViewModel.mnuPPE.Enabled = false;
					ViewModel.mnupayrollreports.Enabled = false;
					ViewModel.mnu_Battalion.Enabled = false;
					ViewModel.mnuImmune.Enabled = false;
				}

				if ( modGlobal.Shared.gSecurity != "ADM" )
				{
					ViewModel.mnu_transfer_req.Enabled = false;
					ViewModel.mnuPMCerts.Enabled = false;
					ViewModel.mnuFRoster.Enabled = false;
				}

				if ( ViewModel.SaveSecurity == "RO" )
				{
					if ( modGlobal.Shared.gSecurity == "PER" )
					{
						ViewModel.mnuEmpInfo.Enabled = true;
						ViewModel.mnuPMCerts.Enabled = true;
					}
					else
					{
						ViewModel.mnuEmpInfo.Enabled = false;
					}
					ViewModel.mnuRoster.Enabled = false;
					ViewModel.mnuIndTimeCard.Enabled = false;
					ViewModel.cmdNotes.Enabled = modGlobal.Shared.gSecurity == "CPT";
					ViewModel.cmdSignOff.Enabled = false;
					//        cmdSetLineUp.Enabled = False
					ViewModel.cmdPayRoll.Enabled = false;
					ViewModel.cmdMissing.Enabled = false;
				}
				else if ( ViewModel.SaveSecurity == "BAT" )
				{
					ViewModel.mnuEmpInfo.Enabled = true;
					ViewModel.mnuRoster.Enabled = true;
					ViewModel.mnuIndTimeCard.Enabled = true;
					ViewModel.cmdPayRoll.Enabled = true;
					ViewModel.cmdMissing.Enabled = true;
					ViewModel.cmdSignOff.Enabled = true;
					ViewModel.cmdNotes.Enabled = true;
					ViewModel.SignOffAuthority = true;
				}
				else if ( ViewModel.SaveSecurity == "AID" )
				{
					ViewModel.cmdPayRoll.Enabled = true;
					ViewModel.mnuEmpInfo.Enabled = true;
					ViewModel.mnuRoster.Enabled = true;
					ViewModel.mnuIndTimeCard.Enabled = true;
					ViewModel.cmdNotes.Enabled = true;
					ViewModel.cmdMissing.Enabled = true;
					ViewModel.cmdSignOff.Enabled = true;
					ViewModel.SignOffAuthority = true;
				}
				else if ( modGlobal.Shared.gSecurity == "ADM" )
				{
					ViewModel.mnuEmpInfo.Enabled = true;
					ViewModel.mnuRoster.Enabled = true;
					ViewModel.mnuIndTimeCard.Enabled = true;
					ViewModel.cmdNotes.Enabled = true;
					ViewModel.cmdSignOff.Enabled = true;
					ViewModel.cmdPayRoll.Enabled = true;
					ViewModel.cmdMissing.Enabled = true;
					ViewModel.SignOffAuthority = true;
				}
				else
				{
					ViewModel.mnuEmpInfo.Enabled = true;
					ViewModel.mnuRoster.Enabled = true;
					ViewModel.mnuIndTimeCard.Enabled = true;
					ViewModel.cmdNotes.Enabled = modGlobal.Shared.gSecurity == "CPT";
					ViewModel.cmdPayRoll.Enabled = false;
					ViewModel.cmdMissing.Enabled = false;
					ViewModel.cmdSignOff.Enabled = false;
					//        cmdSetLineUp.Enabled = False
					ViewModel.mnuPMCerts.Enabled = false;
				}

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

				ClearSchedule();
				ViewModel.FirstTime = false;

						GetSchedule();

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
				if ( ViewModel.SaveSecurity == "RO" )
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
						async1.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam, ViewModel.lbPosition[Index].Text));
						async1.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(tempNormalized1 =>
							{
								var returningMetodValue829 = tempNormalized1;
						
						if ( returningMetodValue829.returnValue )
						{


							ShiftDate = returningMetodValue829.ShiftDate;
							tempRefParam = returningMetodValue829.Empid;
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
							async1.Append<PTSProject.frmBattSchedNew.MoveEmployeeStruct>(() => MoveEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam2, ViewModel.lbPosition[Index].Text));
							async1.Append<PTSProject.frmBattSchedNew.MoveEmployeeStruct>(tempNormalized3 =>
								{
									var returningMetodValue843 = tempNormalized3;
								
										if ( returningMetodValue843.returnValue )
										{


											ShiftDate = returningMetodValue843.ShiftDate;
											tempRefParam2 = returningMetodValue843.Empid;
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

		private void lbPosam_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPosam.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Menu
			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}

			//Check for Battalion Staff labels
			if ( ViewModel.lbPosam[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
			{
				ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
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
					ViewModel.mnuRover.Available = false;
					ViewModel.mnuDebit.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuCancelTrade.Available = false;
					ViewModel.mnuTradeDetail.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					//            mnuSendTo183.Visible = False
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuSADetail.Available = false;
					ViewModel.mnuReschedSA.Available = false;
				}
				else
				{
					if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						//Trade
						ViewModel.mnuCancelTrade.Available = true;
						ViewModel.mnuTradeDetail.Available = true;
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = false;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = false;
						ViewModel.mnuTrade.Available = false;
						ViewModel.mnuRemove.Available = false;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuSADetail.Available = false;
						ViewModel.mnuReschedSA.Available = false;
					}
					else if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.BLUE) )
					{
						//Debit
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = false;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = true;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
					}
					else if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.RED) )
					{
						//Overtime
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = true;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = false;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
					}
					else
					{
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = true;
						ViewModel.mnuRover.Available = true;
						ViewModel.mnuDebit.Available = true;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = true;
						//                mnuSendTo183.Visible = True
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
					}
					if ( ViewModel.shpPayUpAM[Index].Visible )
					{
						ViewModel.mnuPayUp.Available = false;
						ViewModel.mnuPayDown.Available = true;
					}
					else
					{
						ViewModel.mnuPayUp.Available = true;
						ViewModel.mnuPayDown.Available = false;
					}
				}
				ViewModel.Ctx_mnu181PopUp.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
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
				if ( ViewModel.SaveSecurity == "RO" )
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
						async1.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam, ViewModel.lbPositionPM[Index].Text));
						async1.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(tempNormalized1 =>
							{
								var returningMetodValue876 = tempNormalized1;
						
						if ( returningMetodValue876.returnValue )
						{


							ShiftDate = returningMetodValue876.ShiftDate;
							tempRefParam = returningMetodValue876.Empid;
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
							async1.Append<PTSProject.frmBattSchedNew.MoveEmployeeStruct>(() => MoveEmployee(ViewModel.lbUnit[UnitID].Text, ShiftDate, tempRefParam2, ViewModel.lbPosition[Index].Text));
							async1.Append<PTSProject.frmBattSchedNew.MoveEmployeeStruct>(tempNormalized3 =>
								{
									var returningMetodValue892 = tempNormalized3;
								
										if ( returningMetodValue892.returnValue )
										{


											ShiftDate = returningMetodValue892.ShiftDate;
											tempRefParam2 = returningMetodValue892.Empid;
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

		private void lbPospm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPospm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Menu

			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}
			//Check for Battalion Staff labels
			if ( ViewModel.lbPospm[Index].BackColor.Equals(modGlobal.Shared.MED_GRAY) )
			{
				ViewManager.ShowMessage("You do not have appropriate Security to Schedule Battalion Staff on this date", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
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
					ViewModel.mnuRover.Available = false;
					ViewModel.mnuDebit.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuCancelTrade.Available = false;
					ViewModel.mnuTradeDetail.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					//            mnuSendTo183.Visible = False
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuSADetail.Available = false;
					ViewModel.mnuReschedSA.Available = false;
				}
				else
				{
					if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						//Trade
						ViewModel.mnuCancelTrade.Available = true;
						ViewModel.mnuTradeDetail.Available = true;
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = false;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = false;
						ViewModel.mnuTrade.Available = false;
						ViewModel.mnuRemove.Available = false;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuSADetail.Available = false;
						ViewModel.mnuReschedSA.Available = false;
					}
					else if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.BLUE) )
					{
						//Debit
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = false;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = true;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
					}
					else if ( ViewModel.SelectedLabel.ForeColor.Equals(modGlobal.Shared.RED) )
					{
						//Overtime
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = true;
						ViewModel.mnuRover.Available = false;
						ViewModel.mnuDebit.Available = false;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = false;
						//                mnuSendTo183.Visible = False
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
					}
					else
					{
						ViewModel.mnuLeave.Available = true;
						ViewModel.mnuNewSched.Available = false;
						ViewModel.mnuKOT.Available = true;
						ViewModel.mnuRover.Available = true;
						ViewModel.mnuDebit.Available = true;
						ViewModel.mnuTrade.Available = true;
						ViewModel.mnuCancelTrade.Available = false;
						ViewModel.mnuTradeDetail.Available = false;
						ViewModel.mnuRemove.Available = true;
						ViewModel.mnuSendTo182.Available = true;
						//                mnuSendTo183.Visible = True
						ViewModel.mnuReport.Available = true;
						ViewModel.mnuSADetail.Available = true;
						ViewModel.mnuReschedSA.Available = false;
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
				}
				ViewModel.Ctx_mnu181PopUp.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbTo182_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				//Control Droped on this box
				//Update Schedule to change assignment_id to Batt 2 Rover or Debit
				//Based on current KOT
				//Refill Lists or empty time slot label (determined by Source Control)

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				//string StartDate = "", EndDate = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				if ( ViewModel.SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
				modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
				string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source));

				ocmd2.Connection = modGlobal.oConn;
				ocmd2.CommandType = CommandType.Text;

				string SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
				SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
				ocmd2.CommandText = SqlString;
				ADORecordSetHelper orec2 = ADORecordSetHelper.Open(ocmd2, "");

				if ( orec2.EOF )
				{
					modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";

					SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
					SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
					ocmd2.CommandText = SqlString;
					orec2 = ADORecordSetHelper.Open(ocmd2, "");

				}

				if ( !orec2.EOF )
				{
					if ( modGlobal.Clean(orec2["time_code_id"]) == "REG" )
					{
						Source.ForeColor = modGlobal.Shared.BLACK;
						modGlobal.Shared.gLeaveType = "";
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "TRD" )
					{
						Source.ForeColor = modGlobal.Shared.GREEN;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "DDF" )
					{
						Source.ForeColor = modGlobal.Shared.BLUE;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "UDD" )
					{
						Source.ForeColor = modGlobal.Shared.BLUE;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "OTP" )
					{
						Source.ForeColor = modGlobal.Shared.RED;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "DOT" )
					{
						Source.ForeColor = modGlobal.Shared.RED;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "EDO" )
					{
						Source.ForeColor = modGlobal.Shared.RED;
					}
					else if ( modGlobal.Clean(orec2["time_code_id"]) == "EDT" )
					{
						Source.ForeColor = modGlobal.Shared.RED;
					}
				}

				modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);

				//Test for Trade Employee, if so do not change KOT
				//Test for Trade/Debit Employee, if so do not change KOT
				if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
				{
				//        gLeaveType = "TRD"
				}
				else if ( Source.ForeColor.Equals(modGlobal.Shared.BLUE) )
				{
				//Come Here
				//        gLeaveType = "DDF"
				}
				else if ( Source.ForeColor.Equals(modGlobal.Shared.RED) )
				{
				//        gLeaveType = "OTP"
				}
				else if ( modGlobal.Shared.gLeaveType == "" )
				{
					modGlobal.Shared.gLeaveType = "REG";
				}

				modGlobal.Shared.gAssignment = 0;
				modGlobal.Shared.gBatt = "1";
				modGlobal.Shared.gGoToBatt = "2";

				if ( Source.Name == "lbPosam" )
				{
					if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
						modGlobal.Shared.gTradeEmp = "AM";
					}
				}
				else if ( Source.Name == "lbPospm" )
				{
					if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)].Tag) == Empid )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
						modGlobal.Shared.gTradeEmp = "PM";
					}
				}
				else if ( Source.Name == "pnSelected" )
				{
					//assume full shift
                    modGlobal
                        .Shared.gFullShift = -1;
				}
				else
				{
					ViewManager.ShowMessage("Unable to Send to Batt 2 from selected Control", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
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

							if ( Source.Name == "pnSelected" )
							{
								ViewModel.pnSelected.Text = "";
								ViewModel.pnSelected.Tag = "";
								ViewModel.pnSelected.Visible = false;
							}


                        //    frmNewBattSched2.FillLists
                        for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
								{
										if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmNewBattSched2" )
										{
                                frmNewBattSched2.DefInstance.FillLists();
										}
									}

										modGlobal.Shared.gLeaveType = "";
										modGlobal.Shared.gPayType = "";
										modGlobal.Shared.gFullShift = 0;

										ClearSchedule();
												GetBattSchedule();
												FillLists();
											});
				this.Return();
				return ;


     //           if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		//Private Sub lbTo183_DragDrop(Source As Control, x As Single, Y As Single)
		//    'Control Droped on this box
		//    'Update Schedule to change assignment_id to Batt 3 Rover or Debit
		//    'Based on current KOT
		//    'Refill Lists or empty time slot label (determined by Source Control)
		//
		//    Dim oCmd As New ADODB.Command
		//    Dim oRec As ADODB.Recordset
		//    Dim StartDate As String, EndDate As String
		//    Dim Empid As String
		//    Dim JobCode As String
		//    Dim ocmd2 As New ADODB.Command
		//    Dim orec2 As ADODB.Recordset
		//    Dim SqlString As String
		//
		//    If SaveSecurity = "RO" Then Exit Sub
		//
		//    gStartTrans = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00AM"
		//    gEndTrans = Format$(DateAdd("d", 1, gStartTrans), "m/d/yyyy")
		//    Empid = Source.Tag
		//
		//    ocmd2.ActiveConnection = oConn
		//    ocmd2.CommandType = adCmdText
		//
		//    SqlString = "Select time_code_id From Schedule Where employee_id = '" & Empid & "' "
		//    SqlString = SqlString & "and shift_start = '" & gStartTrans & "' "
		//    ocmd2.CommandText = SqlString
		//    Set orec2 = ocmd2.Execute
		//
		//    If orec2.EOF Then
		//        gStartTrans = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00PM"
		//
		//        SqlString = "Select time_code_id From Schedule Where employee_id = '" & Empid & "' "
		//        SqlString = SqlString & "and shift_start = '" & gStartTrans & "' "
		//        ocmd2.CommandText = SqlString
		//        Set orec2 = ocmd2.Execute
		//
		//    End If
		//
		//    If Not orec2.EOF Then
		//        If Clean(orec2("time_code_id"]) = "REG" Then
		//            Source.ForeColor = BLACK
		//            gLeaveType = ""
		//        ElseIf Clean(orec2("time_code_id"]) = "TRD" Then
		//            Source.ForeColor = GREEN
		//        ElseIf Clean(orec2("time_code_id"]) = "DDF" Then
		//            Source.ForeColor = BLUE
		//        ElseIf Clean(orec2("time_code_id"]) = "UDD" Then
		//            Source.ForeColor = BLUE
		//        ElseIf Clean(orec2("time_code_id"]) = "OTP" Then
		//            Source.ForeColor = RED
		//        ElseIf Clean(orec2("time_code_id"]) = "DOT" Then
		//            Source.ForeColor = RED
		//        ElseIf Clean(orec2("time_code_id"]) = "EDO" Then
		//            Source.ForeColor = RED
		//        ElseIf Clean(orec2("time_code_id"]) = "EDT" Then
		//            Source.ForeColor = RED
		//        End If
		//    End If
		//
		//    gLeaveType = Clean(orec2("time_code_id"])
		//
		//    'Test for Trade Employee, if so do not change KOT
		//    'Test for Trade/Debit Employee, if so do not change KOT
		//    If Source.ForeColor = GREEN Then
		//'        gLeaveType = "TRD"
		//    ElseIf Source.ForeColor = BLUE Then
		//        'Come Here
		//'        gLeaveType = "DDF"
		//    ElseIf Source.ForeColor = RED Then
		//'        gLeaveType = "OTP"
		//    ElseIf gLeaveType = "" Then
		//        gLeaveType = "REG"
		//    End If
		//
		//    gAssignment = 0
		//    gBatt = "1"
		//    gGoToBatt = "3"
		//
		//    If Source.Name = "lbPosam" Then
		//        If lbPospm(Source.Index).Tag = Empid Then
		//            gFullShift = True
		//        Else
		//            gFullShift = False
		//            gTradeEmp = "AM"
		//        End If
		//    ElseIf Source.Name = "lbPospm" Then
		//        If lbPosam(Source.Index).Tag = Empid Then
		//            gFullShift = True
		//        Else
		//            gFullShift = False
		//            gTradeEmp = "PM"
		//        End If
		//    ElseIf Source.Name = "pnSelected" Then
		//        'assume full shift
		//        gFullShift = True
		//    Else
		//        MsgBox "Unable to Send to Batt 2 from selected Control", vbOKOnly, "Battalion Scheduler"
		//        Exit Sub
		//    End If
		//
		//    dlgSendRover.Show 1
		//
		//    'If Request canceled - get out
		//    If gLeaveType = "" Then Exit Sub
		//
		//
		//    JobCode = GetJobCode(Empid)
		//
		//    oCmd.ActiveConnection = oConn
		//    oCmd.CommandType = adCmdStoredProc
		//    oCmd.CommandText = "spUpdateSchedule"
		//    oCmd.Execute , Array(Empid, gStartTrans, gEndTrans, gAssignment, gLeaveType, 0, JobCode, Now(), gUser)
		//
		//    If Source.Name = "pnSelected" Then
		//        pnSelected.Caption = ""
		//        pnSelected.Tag = ""
		//        pnSelected.Visible = False
		//    End If
		//
		//'    frmNewBattSched3.FillLists
		//    Dim i As Integer
		//    For i = 0 To Forms.Count - 1
		//        If Forms(i).Name = "frmNewBattSched3" Then
		//            frmNewBattSched3.FillLists
		//        End If
		//    Next i
		//
		//    gLeaveType = ""
		//    gPayType = ""
		//    gFullShift = False
		//
		//    ClearSchedule
		//    GetBattSchedule
		//    FillLists
		//
		//    Exit Sub
		//
		//ErrHandler:
		//    If ErrorControl() = eFATALERROR Then
		//        Exit Sub
		//    End If
		//End Sub
		[UpgradeHelpers.Events.Handler]
		internal void lstSA_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			//Test for no selection made
			if ( ViewModel.lstSA.SelectedIndex < 0 )
			{
				return ;
			}
			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}
			ViewModel.SelectedSAName = ViewModel.lstSA.Text;

			//Find EmpID by using PerSysID
			int PerSysID = ViewModel.lstSA.GetItemData(ViewModel.lstSA.SelectedIndex);

			if ( ~cSched.GetEmployeeIDByPerSysID(PerSysID) != 0 )
			{
				ViewManager.ShowMessage("Oooops!  Something is wrong!  Could not located Employee ID.", "Get Employee ID)", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				ViewModel.SelectedSA = modGlobal.Clean(cSched.PersonnelRecord["employee_id"]);
			}

			//    'Format EmpID from integer to 5 char
			//    SelectedSA = Trim$(Str$(lstSA.ItemData(lstSA.ListIndex)))

			//    If Len(SelectedSA) < 5 Then
			//        If Len(SelectedSA) = 4 Then
			//            SelectedSA = "0" & SelectedSA
			//        ElseIf Len(SelectedSA) = 3 Then
			//            SelectedSA = "00" & SelectedSA
			//        ElseIf Len(SelectedSA) = 2 Then
			//            SelectedSA = "000" & SelectedSA
			//        Else
			//            SelectedSA = "0000" & SelectedSA
			//        End If
			//    End If
			ViewModel.SARow = ViewModel.lstSA.SelectedIndex;
			ViewModel.mnuSADetail.Available = true;
			ViewModel.mnuReschedSA.Available = true;
			ViewModel.mnuLeave.Available = false;
			ViewModel.mnuNewSched.Available = false;
			ViewModel.mnuKOT.Available = false;
			ViewModel.mnuRover.Available = false;
			ViewModel.mnuDebit.Available = false;
			ViewModel.mnuTrade.Available = false;
			ViewModel.mnuCancelTrade.Available = false;
			ViewModel.mnuTradeDetail.Available = false;
			ViewModel.mnuRemove.Available = false;
			ViewModel.mnuSendTo182.Available = false;
			//    mnuSendTo183.Visible = False
			ViewModel.mnuReport.Available = false;
			ViewModel.mnuPayUp.Available = false;
			ViewModel.mnuPayDown.Available = false;
			ViewModel.Ctx_mnu181PopUp.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);


		}

		private void lstSA_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				//Determine Source of Drop:
				//Source could be pnSelected panel containing name from
				//one of the listboxes
				//Or Source could a name from another position in the schedule
				//------------------------------------------
				//Add or Update Schedule Record

				//string ShiftDate = "";
				int SourceIndex = 0;
				string AMPM = "";
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				//string Empid = "";
				//int UnitID = 0;
				//UpgradeHelpers.Helpers.ControlViewModel ThisControl = null;

				if ( ViewModel.SaveSecurity == "RO" )
				{
					this.Return();
					return ;
				}

				//Determine if Add or Update Schedule record
				if ( Source.Name == "pnSelected" )
				{
					modGlobal.Shared.gFullShift = -1;
					async1.Append<System.Boolean>(() => ScheduleSA(Source));
					async1.Append<System.Boolean>(tempNormalized0 =>
						{
							if ( tempNormalized0 )
							{
								ViewModel.pnSelected.Text = "";
								ViewModel.pnSelected.Tag = "";
								ViewModel.pnSelected.Visible = false;
							}
						});
					this.Return();
					return ;
				}
				else
				{
					//Move employee from current position to this position
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
					}
					else
					{
						modGlobal.Shared.gTradeDefault = 0;
					}
					SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
					//Can both AM & PM be scheduled?
					if ( AMPM == "AM" )
					{
						OtherShift = ViewModel.lbPospm[SourceIndex];
					}
					else
					{
						OtherShift = ViewModel.lbPosam[SourceIndex];
					}
					if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
					{
						modGlobal.Shared.gFullShift = -1;
					}
					else
					{
						modGlobal.Shared.gFullShift = 0;
					}
					async1.Append<System.Boolean>(() => ScheduleSA(Source));
					async1.Append<System.Boolean>(tempNormalized1 =>
						{
							if ( tempNormalized1 )
							{
								if ( modGlobal.Shared.gFullShift != 0 )
								{
									OtherShift.Text = "";
									UpgradeHelpers.Helpers.ControlHelper.SetTag(OtherShift, "");
									OtherShift.ForeColor = modGlobal.Shared.BLACK;
									ViewModel.shpPayUpAM[SourceIndex].Visible = false;
									ViewModel.shpPayUpPM[SourceIndex].Visible = false;
									modGlobal.Shared.gFullShift = 0;
								}
								else
								{
									if ( AMPM == "AM" )
									{
										ViewModel.shpPayUpAM[SourceIndex].Visible = false;
									}
									else
									{
										ViewModel.shpPayUpPM[SourceIndex].Visible = false;
									}
								}
								Source.Text = "";
								UpgradeHelpers.Helpers.ControlHelper.SetTag(Source, "");
								Source.ForeColor = modGlobal.Shared.BLACK;
							}
						});
				}
				async1.Append(() =>
					{

						FillLists();
					});
			}

		}

		//Private Sub lstSA_DragDrop(Source As Control, X As Single, Y As Single)
		//    'Determine Source of Drop:
		//    'Source could be pnSelected panel containing name from
		//    'one of the listboxes
		//    'Or Source could a name from another position in the schedule
		//    '------------------------------------------
		//    'Add or Update Schedule Record
		//
		//    Dim ShiftDate As String
		//    Dim SourceIndex As Integer
		//    Dim AMPM As String
		//    Dim OtherShift As Control
		//    Dim EmpID As String
		//    Dim UnitID As Integer
		//    Dim ThisControl As Control
		//
		//    If SaveSecurity = "RO" Then Exit Sub
		//
		//    'Determine if Add or Update Schedule record
		//    If Source.Name = "pnSelected" Then
		//        gFullShift = True
		//        If ScheduleSA(Source) Then
		//            pnSelected.Caption = ""
		//            pnSelected.Tag = ""
		//            pnSelected.Visible = False
		//        End If
		//        Exit Sub
		//    Else
		//        'Move employee from current position to this position
		//        AMPM = UCase(Right$(Source.Name, 2))
		//        If Source.ForeColor = BLUE Then
		//            gDebitDefault = True
		//        Else
		//            gDebitDefault = False
		//        End If
		//        If Source.ForeColor = GREEN Then
		//            gTradeDefault = True
		//        Else
		//            gTradeDefault = False
		//        End If
		//        SourceIndex = Source.Index
		//        'Can both AM & PM be scheduled?
		//        If AMPM = "AM" Then
		//            Set OtherShift = lbPospm(SourceIndex)
		//        Else
		//            Set OtherShift = lbPosam(SourceIndex)
		//        End If
		//        If Source.Tag = OtherShift.Tag Then
		//            gFullShift = True
		//        Else
		//            gFullShift = False
		//        End If
		//        If ScheduleSA(Source) Then
		//            If gFullShift Then
		//                OtherShift.Caption = ""
		//                OtherShift.Tag = ""
		//                OtherShift.ForeColor = BLACK
		//                shpPayUpAM(SourceIndex).Visible = False
		//                shpPayUpPM(SourceIndex).Visible = False
		//                gFullShift = False
		//            Else
		//                If AMPM = "AM" Then
		//                    shpPayUpAM(SourceIndex).Visible = False
		//                Else
		//                    shpPayUpPM(SourceIndex).Visible = False
		//                End If
		//            End If
		//            Source.Caption = ""
		//            Source.Tag = ""
		//            Source.ForeColor = BLACK
		//        End If
		//    End If
		//
		//    FillLists
		//
		//End Sub
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
		internal void mnu_emp_facility_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmEmployeeListByStation.DefInstance);
			/*            frmEmployeeListByStation.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_FCCMinDrills_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainFCCQuarterly.DefInstance);
			/*            frmTrainFCCQuarterly.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_FCCVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Dispatch Vacation Scheduler 5/2013
            ViewManager.NavigateToView(
                //Display new Dispatch Vacation Scheduler 5/2013
frmFCCVacationScheduler.DefInstance);
			/*            frmFCCVacationScheduler.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HelpPrntScrn_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPrintScreenHelp.DefInstance);
			/*            frmPrintScreenHelp.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HZMLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmHazmatLeave.DefInstance);
			/*            frmHazmatLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_HZMVacationSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new Hazmat Vacation Scheduler 3/2012
            ViewManager.NavigateToView(
                //Display new Hazmat Vacation Scheduler 3/2012
frmHZMVacationScheduler.DefInstance);
			/*            frmHZMVacationScheduler.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
		internal void mnu_IndLegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgIndSchedLegend.DefInstance);
			/*            dlgIndSchedLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndPMRecert_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
            ViewManager.NavigateToView(
                //    MsgBox "This feature is under construction... coming soon!", vbOKOnly, "Coming Soon!"
frmIndPMRecertReport.DefInstance);
			/*            frmIndPMRecertReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_IndTrainReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndTrainReport.DefInstance);
			/*            frmIndTrainReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_LeaveNoSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmLeaveNoSched.DefInstance);
			/*            frmLeaveNoSched.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_legend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgBattLegend.DefInstance);
			/*            dlgBattLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_OTEPReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainAnnualOTEP.DefInstance);
			/*            frmTrainAnnualOTEP.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payrolllegend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgPayRollLegend.DefInstance);
			/*            dlgPayRollLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_payup_calc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgEmployeePayCalc.DefInstance);
			/*            dlgEmployeePayCalc.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMBaseStaReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrnBaseStation.DefInstance);
			/*            frmTrnBaseStation.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMCSRCalc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgCalcPMCSR.DefInstance);
			/*            dlgCalcPMCSR.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmParamedicLeave.DefInstance);
			/*            frmParamedicLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PMRecertReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainPMRecert.DefInstance);
			/*            frmTrainPMRecert.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_PPEQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPPEInspQuery.DefInstance);
			/*            frmPPEInspQuery.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_QuarterlyMinimumDrill_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainQuarterlyReport.DefInstance);
			/*            frmTrainQuarterlyReport.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_ReadingAssign_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrainReqReading.DefInstance);
			/*            frmTrainReqReading.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_sa_report_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSpecialAssignReport.DefInstance);
			/*            frmSpecialAssignReport.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_SchedNotes_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSchedNoteQuery.DefInstance);
			/*            frmSchedNoteQuery.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_sick_usage_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSickLeaveUsage.DefInstance);
			/*            frmSickLeaveUsage.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_staffdiscrepancy_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmStaffingDiscrepancy.DefInstance);
			/*            frmStaffingDiscrepancy.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_timecard_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = "";
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_timecodes_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgTimeCodes.DefInstance);
			/*            dlgTimeCodes.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_Vacation_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display new TFD Vacation Scheduler 12/2004
            ViewManager.NavigateToView(
                //Display new TFD Vacation Scheduler 12/2004
frmVacationScheduler.DefInstance);
			/*            frmVacationScheduler.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_viewtimecard_Click(Object eventSender, System.EventArgs eventArgs)
		{

			if ( modGlobal.Clean(ViewModel.SelectedSA) == "" )
			{
				ViewModel.SelectedSA = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
			}

			modGlobal.Shared.gPayPeriod = 0;
			modGlobal.Shared.gReportUser = modGlobal.Clean(ViewModel.SelectedSA);
			modGlobal.Shared.gStartTrans = DateTime.Now.ToString("M/d/yyyy");
            ViewManager.NavigateToView(
                frmIndTimeCard.DefInstance);
			/*            frmIndTimeCard.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
			//MDIForm1.Arrange vbCascade
			ViewModel.SelectedSA = "";

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnu_watch_duty_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmWatchDutyAssignment.DefInstance);
			/*            frmWatchDutyAssignment.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
			;

		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuALSProc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndALSProcReport.DefInstance);
			/*            frmIndALSProcReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

		//MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAnnual_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Processes and Displays Annual Leave Report
			//***Note  Annual Leave report prints for the current year!!
            modGlobal
                .Shared.gYearReport = DateTime.Now.Year.ToString();
            ViewManager.NavigateToView(
                frmAnnualLeave.DefInstance);
			/*            frmAnnualLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuAssignReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmAssignReport.DefInstance);
			/*            frmAssignReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void MnuAuditDDHOL_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Debit/Holiday Audit form
            ViewManager.NavigateToView(
                //Display Debit/Holiday Audit form
frmDebitHoliday.DefInstance);
			/*            frmDebitHoliday.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion3_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display Batt 4 Battalion Scheduler
            ViewManager.NavigateToView(

                //Display Batt 4 Battalion Scheduler
 frmBattSched3.DefInstance);
            /*            frmBattSched3.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion4_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display Batt 5 Battalion Scheduler
            ViewManager.NavigateToView(

                //Display Batt 5 Battalion Scheduler
 frmBattSched4.DefInstance);
            /*            frmBattSched4.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattStaff_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Weekly Scheduler form

            modGlobal
                .Shared.gType = "BAT";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuCancelTrade_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Cancel Trade
				//Delete Working Employees Trade Schedule record
				//Delete Original Employees Trade Leave record
				string Empid = "";
				//string OldEmp = "";
				string StartDate = "";
				string EndDate = "";
				int AssignID = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								EndDate = "";
								modGlobal.Shared.gFullShift = 0;
							}
						}
						else
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
								modGlobal.Shared.gFullShift = -1;
							}
							else
							{
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
								EndDate = "";
								modGlobal.Shared.gFullShift = 0;
							}
						}

						//StartDate Transactions
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						//Determine Current Assignment
						oCmd.CommandText = "sp_GetAssignID '" + Empid + "','" + StartDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
							AssignID = Convert.ToInt32(oRec["assignment_id"]);
						}
						else
						{
							ViewManager.ShowMessage("Error attempting to cancel trade", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							this.Return();
							return ;
						}
						//Retrieve Trade History Record
						oCmd.CommandText = "sp_GetTradeHistory '" + Empid + "','" + StartDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( oRec.EOF )
						{
							ViewManager.ShowMessage("Error attempting to cancel trade", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							this.Return();
							return ;
						}

						//Delete Current Trade Schedule record
						oCmd.CommandText = "spDeleteSchedule '" + Convert.ToString(oRec["working_emp"]) + "','" + StartDate + "'";
						oCmd.ExecuteNonQuery();

						//Delete Original Employees Trade Leave Record
						oCmd.CommandText = "spDeleteLeave '" + Convert.ToString(oRec["scheduled_emp"]) + "','" + StartDate + "'";
						oCmd.ExecuteNonQuery();

						//If Trade Employee was moved, update Original Employees Assignment
						if ( AssignID != Convert.ToDouble(oRec["assignment_id"]) )
						{
                            oCmd.CommandText = "spUpdateScheduleAssign '" + Convert.ToString(oRec["scheduled_emp"]) + "','" + StartDate + "'," + AssignID.
                                        ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
							oCmd.ExecuteNonQuery();
						}

						//Delete TradeHistory Record
						oCmd.CommandText = "spDeleteTradeHistory " + Convert.ToString(oRec["trade_id"]);
						oCmd.ExecuteNonQuery();

						if ( modGlobal.Shared.gFullShift != 0 )
						{
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Cancel both AM and PM Trades?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNo));
							async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
							async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
								{
									Response = tempNormalized1;
								});
							async1.Append(() =>
								{
									if ( Response == UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										//Repeat Cancel Trade Steps for EndDate shift
										//Retrieve Trade History Record
										oCmd.CommandText = "sp_GetTradeHistory '" + Empid + "','" + EndDate + "'";
										oRec = ADORecordSetHelper.Open(oCmd, "");
										if ( oRec.EOF )
										{
											ViewManager.ShowMessage("Error attempting to cancel PM trade", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
											this.Return();
											return ;
										}

										//Delete Current Trade Schedule record
										oCmd.CommandText = "spDeleteSchedule '" + Convert.ToString(oRec["working_emp"]) + "','" + EndDate + "'";
										oCmd.ExecuteNonQuery();

										//Delete Original Employees Trade Leave Record
										oCmd.CommandText = "spDeleteLeave '" + Convert.ToString(oRec["scheduled_emp"]) + "','" + EndDate + "'";
										oCmd.ExecuteNonQuery();

										//If Trade Employee was moved, update Original Employees Assignment
										if ( AssignID != Convert.ToDouble(oRec["assignment_id"]) )
										{
											//                oCmdUpdate.Execute , Array(oRec("scheduled_emp"), EndDate, AssignID, Now(), gUser)
                                            oCmd.CommandText = "spUpdateScheduleAssign '" + Convert.ToString(oRec["scheduled_emp"]) + "','" +
                                                                    EndDate + "'," + AssignID.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
											oCmd.ExecuteNonQuery();
										}

										//Delete TradeHistory Record
										oCmd.CommandText = "spDeleteTradeHistory " + Convert.ToString(oRec["trade_id"]);
										oCmd.ExecuteNonQuery();
									}
								});
						}
						async1.Append(() =>
							{

									modGlobal.Shared.gFullShift = 0;

									ClearSchedule();
											GetBattSchedule();
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
		internal void mnuCascade_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Cascade visible child windows

            MDIForm1.DefInstance.LayoutMdi(Stubs._System.Windows.Forms.MdiLayout.Cascade);

			}

		[UpgradeHelpers.Events.Handler]
		internal void MnuCBStaffing_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display TFD Staffing To Determine Callbacks
            ViewManager.NavigateToView(
                //Display TFD Staffing To Determine Callbacks
frmStaffingReport.DefInstance);
			/*            frmStaffingReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.DisposeView(this);

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
		//MDIForm1.Arrange vbCascade
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
		internal void mnuDebit_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Delete existing Schedule record and
				//Schedule employee as generic Debit
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;

				//Determine if full shift to be transfered to Debit
				int SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel);
				string AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
				if ( AMPM == "AM" )
				{
					OtherShift = ViewModel.lbPospm[SourceIndex];
				}
				else
				{
					OtherShift = ViewModel.lbPosam[SourceIndex];
				}
				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Replace both AM and PM in Debit List?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}
				async1.Append(() =>
					{

							string ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
							string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
                        var returningMetodValue1160 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue1160.Empid;
										ShiftDate = returningMetodValue1160.ShiftDate;

										string JobCode = modGlobal.GetJobCode(Empid);
										int Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

										oCmd.Connection = modGlobal.oConn;
										oCmd.CommandType = CommandType.StoredProcedure;
										oCmd.CommandText = "spInsertSchedule";
										//Checked out... this is okay			
										oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181DBT, "DDF", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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
                                            var returningMetodValue1168 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue1168.Empid;
										ShiftDate = returningMetodValue1168.ShiftDate;
										//Checked out... this is okay
										oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181DBT, "DDF", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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

												FillLists();
											});
				this.Return();
				return ;


     //           if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDebitReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDebitReport.DefInstance);
			/*            frmDebitReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatch_Click(Object eventSender, System.EventArgs eventArgs)
		{

				modGlobal.Shared.gType = "FCC";
            ViewManager.NavigateToView(
                frmDispatchScheduler.DefInstance);
            /*            frmDispatchScheduler.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuDispatchLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDispatchLeave.DefInstance);
			/*            frmDispatchLeave.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;

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
		//MDIForm1.Arrange vbCascade

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
		//MDIForm1.Arrange vbCascade

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuException_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Determine if frmException1 is already open
				//If so set to Currently selected date
				//Print Exception Report

				int OpenFlag = 0;

            for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
					{
							if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmException1" )
							{
                    //Timestamp report and print
 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmException1.DefInstance.ViewModel.sprExcept.setPrintAbortMsg("Printing Battalion 1 Exception Report - Click Cancel to quit");
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmException1.DefInstance.ViewModel.sprExcept.setPrintBorder(false);
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmException1.DefInstance.ViewModel.sprExcept.setPrintColor(true);
                    //            frmException1.sprExcept.PrintOrientation = 1
                    frmException1.DefInstance.ViewModel.sprExcept.PrintSheet(null);
                    //frmException1.DefInstance.ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants)32;
										OpenFlag = -1;
								return ;
							}
							else
							{
								OpenFlag = 0;
							}
						}

				if ( ~OpenFlag != 0 )
				{
                ViewManager.HideView(
 frmException1.DefInstance);
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmException1.DefInstance.ViewModel.sprExcept.setPrintAbortMsg("Printing Battalion 1 Exception Report - Click Cancel to quit");
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmException1.DefInstance.ViewModel.sprExcept.setPrintBorder(false);
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmException1.DefInstance.ViewModel.sprExcept.setPrintColor(true);
                //        frmException1.sprExcept.PrintOrientation = 1
                frmException1.DefInstance.ViewModel.sprExcept.PrintSheet(null);
                //frmException1.DefInstance.ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants)32;
                ViewManager.DisposeView(
 frmException1.DefInstance);
				}
			}

		[UpgradeHelpers.Events.Handler]
		internal void MnuExtraOff_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Display Unplanned Days Off Report form
            ViewManager.NavigateToView(
                //Display Unplanned Days Off Report form
frmExtraDaysOff.DefInstance);
			/*            frmExtraDaysOff.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuFRoster_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmRosterFiltered.DefInstance);
			/*            frmRosterFiltered.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuHazmat_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Weekly Scheduler form

            modGlobal
                .Shared.gType = "HZM";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

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
		//MDIForm1.Arrange vbCascade
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
			//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuIndYearSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gReportYear = DateTime.Now.Year;
            ViewManager.NavigateToView(
                frmIndivSchedReport.DefInstance);
			/*            frmIndivSchedReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
		internal void mnuMarine_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Display Weekly Scheduler form

            modGlobal
                .Shared.gType = "MRN";
            ViewManager.NavigateToView(
                frmWeekly.DefInstance);
            /*            frmWeekly.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewBatt2_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmBatt2SchedNew.DefInstance);
            ViewManager.SetCurrentView(
                frmBatt2SchedNew.DefInstance.ViewModel);
            /*            frmBatt2SchedNew.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuNewSched_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Display dlgTrade to obtain Employee Name
				//Test to make sure employee is not already scheduled
				//Display dialog time to determine KOT and Pay Up
				//Create New Schedule Record

				string Empid = "";
				string StartDate = "";
				string EndDate = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string UnitID = "";
				int Response = 0;

				try
				{
					{

						modGlobal.Shared.gFullShift = 0;
						modGlobal.Shared.gTradeEmp = "";
						modGlobal.Shared.gLeaveType = "";
						modGlobal.Shared.gTradeDefault = 0;

						modGlobal.Shared.gSType = "New";
						async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgTrade.DefInstance, true);
							});
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{
									modGlobal.Shared.gSType = "";
									if ( modGlobal.Shared.gTradeEmp == "" )
									{
										modGlobal.Shared.gFullShift = 0;
										this.Return();
										return ;
									}
									else
									{
										Empid = modGlobal.Shared.gTradeEmp;
										modGlobal.Shared.gTradeEmp = "";
									}

									if ( ViewModel.SelectedLabel.Name == "lbPosam" )
									{
										if ( ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text == "" )
										{
											async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Schedule both AM and PM?", "Schedule Employee", UpgradeHelpers.Helpers.BoxButtons.YesNo));
											async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
											async2.Append<UpgradeHelpers.Helpers.DialogResult, System.Int32>(tempNormalized1 => (int)tempNormalized1);
											async2.Append<System.Int32>(tempNormalized2 =>
												{
													Response = tempNormalized2;
												});
											async2.Append(() =>
												{
													if ( Response == ((int)UpgradeHelpers.Helpers.DialogResult.Yes) )
													{
														modGlobal.Shared.gFullShift = -1;
														StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
														EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
													}
													else
													{
														modGlobal.Shared.gFullShift = 0;
														StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
														EndDate = "";
													}
												});
										}
										else
										{
											modGlobal.Shared.gFullShift = 0;
											StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
											EndDate = "";
										}
									}
									else
									{
										if ( ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text == "" )
										{
											async2.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Schedule both AM and PM?", "Schedule Employee", UpgradeHelpers.Helpers.BoxButtons.YesNo));
											async2.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized3 => tempNormalized3);
											async2.Append<UpgradeHelpers.Helpers.DialogResult, System.Int32>(tempNormalized4 => (int)tempNormalized4);
											async2.Append<System.Int32>(tempNormalized5 =>
												{
													Response = tempNormalized5;
												});
											async2.Append(() =>
												{
													if ( Response == ((int)UpgradeHelpers.Helpers.DialogResult.Yes) )
													{
														modGlobal.Shared.gFullShift = -1;
														StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
														EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
													}
													else
													{
														modGlobal.Shared.gFullShift = 0;
														StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
														EndDate = "";
													}
												});
										}
										else
										{
											modGlobal.Shared.gFullShift = 0;
											StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
											EndDate = "";
										}
									}
									async2.Append(() =>
										{
											using ( var async3 = this.Async() )
											{

												//    If SelectedLabel.Name = "lbPosam" Then
												//        If lbPospm(SelectedLabel.Index).Caption = "" Then
												//            gFullShift = True
												//            StartDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00AM"
												//            EndDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00PM"
												//        Else
												//            gFullShift = False
												//            StartDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00AM"
												//            EndDate = ""
												//        End If
												//    Else
												//        If lbPosam(SelectedLabel.Index).Caption = "" Then
												//            gFullShift = True
												//            StartDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00AM"
												//            EndDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00PM"
												//        Else
												//            gFullShift = False
												//            StartDate = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00PM"
												//            EndDate = ""
												//        End If
												//    End If

												//Determine if New Employee already scheduled for this date
												oCmd.Connection = modGlobal.oConn;
												oCmd.CommandType = CommandType.Text;
												oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + StartDate + "'";
												oRec = ADORecordSetHelper.Open(oCmd, "");
												if ( !oRec.EOF )
												{
                                                    ViewManager.ShowMessage("Employee selected to work is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers
                                                        .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
													modGlobal.Shared.gFullShift = 0;
													this.Return();
													return ;
												}
												if ( modGlobal.Shared.gFullShift != 0 )
												{
													oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + EndDate + "'";
													oRec = ADORecordSetHelper.Open(oCmd, "");
													if ( !oRec.EOF )
													{
                                                        ViewManager.ShowMessage("Employee selected to work is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers
                                                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
														modGlobal.Shared.gFullShift = 0;
														this.Return();
														return ;
													}
												}

												UnitID = FindUnit(UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)).ToString();
                                                async3.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[Convert
                                                        .ToInt32(Double.Parse(UnitID))].Text, StartDate, Empid, ViewModel.lbPosition[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text));
												async3.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(tempNormalized7 =>
													{
														var returningMetodValue1318 = tempNormalized7;
													
															Response = (returningMetodValue1318.returnValue) ? -1 : 0;
															StartDate = returningMetodValue1318.ShiftDate;
															Empid = returningMetodValue1318.Empid;

															modGlobal.Shared.gFullShift = 0;
															modGlobal.Shared.gTradeEmp = "";
															modGlobal.Shared.gLeaveType = "";


															ClearSchedule();
																	GetBattSchedule();
																});
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
		internal void mnuOvertime_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmOvertime.DefInstance);
			/*            frmOvertime.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
				//int iResponse = 0;

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
						modGlobal.Shared.gLType = "P";
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
													//The commented out logic was a test, but could be added everywhere
													//                    If LastRate = PayRate Then
													//                        iResponse = MsgBox("This is not an upgrade in pay.  Did you want to change the Job Code anyway?", vbYesNoCancel, "Not a Pay Upgrade")
													//                        If iResponse <> vbYes Then
													//                            Exit Sub
													//                        Else
													//                            Exit For
													//                        End If
													//                    Else
                                                    ViewManager.ShowMessage("The Selected Job does not constitute a Pay Upgrade. Please try a different Job Code.", "Pay Upgrade Error", UpgradeHelpers
                                                        .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
													this.Return();
													return ;
												//                    End If
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
		internal void mnupersonnelsignoff_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPayrollSignOff.DefInstance);
			/*            frmPayrollSignOff.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPMCerts_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPMCertification.DefInstance);
			/*            frmPMCertification.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPPE_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmNewPPEWDL.DefInstance);
            /*            frmNewPPEWDL.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintAll_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Test to determine if Report Forms are already open
				//If not open TimeCard, Exception and Leave forms hidden
				//Print TimeCard, Exception and Leave Spreads
				//Close Report Forms


				int OpenFlag = -1;

				//     Disabling frmTimeCard1 for now DKL 8/2010
				//Test for frmTimeCard1 already open
				for ( int i = 0; i <= ViewManager.OpenFormsCount - 1; i++ )
				{
					if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmTimeCard1" )
					{
						OpenFlag = -1;
					}
					else
					{
						OpenFlag = 0;
					}
				}

				if ( ~OpenFlag != 0 )
				{
                ViewManager.HideView(
                    frmTimeCard1.DefInstance);
				}

            //Timestamp report and print
            frmTimeCard1.DefInstance.ViewModel.sprBatt.Col = 22;
            frmTimeCard1.DefInstance.ViewModel.sprBatt.Row = 41;
            frmTimeCard1.DefInstance.ViewModel.sprBatt.Text = DateTime.Now.ToString("M/d/yy HH:mm");

            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintAbortMsg("Printing Battalion 1 Time Card Worksheet - Click Cancel to quit");
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintBorder(false);
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintColor(true);
            //    frmTimeCard1.sprBatt.PrintOrientation = 2
            frmTimeCard1.DefInstance.ViewModel.sprBatt.PrintSheet(null);
            //frmTimeCard1.DefInstance.ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants)32;

				//If frmTimeCard1 was just openned by this procedure, unload it
				if ( ~OpenFlag != 0 )
				{
                ViewManager.DisposeView(
                    frmTimeCard1.DefInstance);
							OpenFlag = -1;
				}

							//Test for frmException1 already open
							for ( int i = 0; i <= ViewManager.OpenFormsCount - 1; i++ )
							{
								if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmException1" )
								{
									OpenFlag = -1;
								}
								else
								{
									OpenFlag = 0;
								}
							}

							if ( ~OpenFlag != 0 )
							{
                ViewManager.HideView(
                    frmException1.DefInstance);
							}

            //Print Exception Report
 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmException1.DefInstance.ViewModel.sprExcept.setPrintAbortMsg("Printing Exception Report - Click Cancel to quit");
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmException1.DefInstance.ViewModel.sprExcept.setPrintBorder(false);
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprExcept.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmException1.DefInstance.ViewModel.sprExcept.setPrintColor(true);
            //    frmException1.sprExcept.PrintOrientation = 1
            frmException1.DefInstance.ViewModel.sprExcept.PrintSheet(null);
            //frmException1.DefInstance.ViewModel.sprExcept.Action = (FarPoint.ViewModels.FPActionConstants)32;

							//If this procedure openned frmException1, unload it
							if ( ~OpenFlag != 0 )
							{
                ViewManager.DisposeView(
                    frmException1.DefInstance);
										OpenFlag = -1;
							}

										//Test for frmLeave already open
										for ( int i = 0; i <= ViewManager.OpenFormsCount - 1; i++ )
										{
											if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmLeave" )
											{
												OpenFlag = -1;
											}
											else
											{
												OpenFlag = 0;
											}
										}

										if ( ~OpenFlag != 0 )
										{
                ViewManager.HideView(
                    frmLeave.DefInstance);
										}

            //Print Leave Report
 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmLeave.DefInstance.ViewModel.sprLeave.setPrintAbortMsg("Printing Daily Leave Report - Click Cancel to quit");
            //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
            frmLeave.DefInstance.ViewModel.sprLeave.setPrintBorder(false);
            //    frmLeave.sprLeave.PrintOrientation = 1
            //frmLeave.DefInstance.ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants)13;

										//If This procedure openned frmLeave, unload it
										if ( ~OpenFlag != 0 )
										{
                ViewManager.DisposeView(
                    frmLeave.DefInstance);
										}

									}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintDailyLeave_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Determine if frmLeave is already open
				//If so print current data
				//Otherwise open hidden and Print Daily Leave Report

				int OpenFlag = 0;

            for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
					{
							if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmLeave" )
							{
                    //Print Daily Leave Report
 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmLeave.DefInstance.ViewModel.sprLeave.setPrintAbortMsg("Printing Daily Leave Report - Click Cancel to quit");
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmLeave.DefInstance.ViewModel.sprLeave.setPrintBorder(false);
                    //            frmLeave.sprLeave.PrintOrientation = 1
                    //frmLeave.DefInstance.ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants)13;
										OpenFlag = -1;
								return ;
							}
							else
							{
								OpenFlag = 0;
							}
						}

				if ( ~OpenFlag != 0 )
				{
                ViewManager.HideView(
                    frmLeave.DefInstance);
                //Print Daily Leave Report
 //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmLeave.DefInstance.ViewModel.sprLeave.setPrintAbortMsg("Printing Daily Leave Report - Click Cancel to quit");
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprLeave.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmLeave.DefInstance.ViewModel.sprLeave.setPrintBorder(false);
                //        frmLeave.sprLeave.PrintOrientation = 1
                //frmLeave.DefInstance.ViewModel.sprLeave.Action = (FarPoint.ViewModels.FPActionConstants)13;
                ViewManager.DisposeView(
 frmLeave.DefInstance);
				}


			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintScreen_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//object i = null;
		
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

			//    DoEvents
			//    Sleep 10000

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
		internal void mnuProlist_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPromoReport.DefInstance);
			/*            frmPromoReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
                        var returningMetodValue1504 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue1504.Empid;
										ShiftDate = returningMetodValue1504.ShiftDate;

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
                            var returningMetodValue1506 = DeleteSchedule(Empid, ShiftDate);
													Empid = returningMetodValue1506.Empid;
													ShiftDate = returningMetodValue1506.ShiftDate;
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
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuReschedSA_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This is being worked on", vbOKOnly, "Work In Progress"

			if ( ViewModel.SaveSecurity == "RO" )
			{
				return ;
			}

			if ( ViewModel.pnSelected.Text != "" )
			{
				ViewManager.ShowMessage("You must first schedule previously selected employee!", "Battalion Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
				return ;
			}
			ViewModel.pnSelected.Text = ViewModel.SelectedSAName;
			ViewModel.pnSelected.Tag = ViewModel.SelectedSA;
			ViewModel.pnSelected.Visible = true;
			modGlobal.Shared.gDebitDefault = 0;
			modGlobal.Shared.gTradeDefault = 0;
			ViewModel.lstSA.RemoveItem(ViewModel.SARow);

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
		internal void mnuRover_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Delete existing Schedule record and
				//Schedule employee as generic Rover
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;

				//Determine if full shift to be transfered to Rover
				int SourceIndex = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel);
				string AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
				if ( AMPM == "AM" )
				{
					OtherShift = ViewModel.lbPospm[SourceIndex];
				}
				else
				{
					OtherShift = ViewModel.lbPosam[SourceIndex];
				}
				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(OtherShift)) )
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("Replace both AM and PM in Rover List?", "Reschedule Rover", UpgradeHelpers.Helpers.BoxButtons.YesNo));
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
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}
				async1.Append(() =>
					{

							string ShiftDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00" + AMPM;
							string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
                        var returningMetodValue1535 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue1535.Empid;
										ShiftDate = returningMetodValue1535.ShiftDate;

										string JobCode = modGlobal.GetJobCode(Empid);
										int Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));

										oCmd.Connection = modGlobal.oConn;
										oCmd.CommandType = CommandType.StoredProcedure;
										oCmd.CommandText = "spInsertSchedule";
										oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181ROV, "REG", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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
                                            var returningMetodValue1543 = DeleteSchedule(Empid, ShiftDate);
											Empid = returningMetodValue1543.Empid;
											ShiftDate = returningMetodValue1543.ShiftDate;
											oCmd.ExecuteNonQuery(new object[] { ShiftDate, Empid, modGlobal.ASGN181ROV, "REG", 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });

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

												FillLists();
											});
				this.Return();
				return ;


     //           if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
					//{
					//		this.Return();
					//		return ;
					//	}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSADetail_Click(Object eventSender, System.EventArgs eventArgs)
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

				try
				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));

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
						modGlobal.Shared.gBatt = "1";
						modGlobal.Shared.gGoToBatt = "2";
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
									modGlobal.Shared.gFullShift = 0;

									ClearSchedule();
											GetBattSchedule();
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

		//Private Sub mnuSendTo183_Click()
		//    'Selected from PopUp Menu
		//    'Update Schedule to change assignment_id to Batt 3 Rover or Debit
		//    'Based on current KOT
		//
		//    Dim oCmd As New ADODB.Command
		//    Dim oRec As ADODB.Recordset
		//    Dim StartDate As String, EndDate As String
		//    Dim Empid As String
		//    Dim JobCode As String
		//
		//    On Error GoTo ErrHandler
		//
		//    gStartTrans = Format$(calSchedDate.Date, "m/d/yyyy") & " 7:00AM"
		//    gEndTrans = Format$(DateAdd("d", 1, gStartTrans), "m/d/yyyy")
		//    Empid = SelectedLabel.Tag
		//
		//    If SelectedLabel.Name = "lbPosam" Then
		//        If lbPospm(SelectedLabel.Index).Tag = Empid Then
		//            gFullShift = True
		//        Else
		//            gFullShift = False
		//            gTradeEmp = "AM"
		//        End If
		//    ElseIf SelectedLabel.Name = "lbPospm" Then
		//        If lbPosam(SelectedLabel.Index).Tag = Empid Then
		//            gFullShift = True
		//        Else
		//            gFullShift = False
		//            gTradeEmp = "PM"
		//        End If
		//    Else
		//        MsgBox "Unable to Send to Batt 3 from selected Control", vbOKOnly, "Battalion Scheduler"
		//        Exit Sub
		//    End If
		//    gAssignment = 0
		//    gBatt = "1"
		//    gGoToBatt = "3"
		//    dlgSendRover.Show 1
		//
		//    'If Request canceled - get out
		//    If gLeaveType = "" Then Exit Sub
		//
		//    JobCode = GetJobCode(Empid)
		//
		//    oCmd.ActiveConnection = oConn
		//    oCmd.CommandType = adCmdStoredProc
		//    oCmd.CommandText = "spUpdateSchedule"
		//    oCmd.Execute , Array(Empid, gStartTrans, gEndTrans, gAssignment, gLeaveType, 0, JobCode, Now(), gUser)
		//
		//    gLeaveType = ""
		//    gPayType = ""
		//    gFullShift = False
		//
		//    ClearSchedule
		//    GetBattSchedule
		//    FillLists
		//
		//    Exit Sub
		//
		//ErrHandler:
		//    If ErrorControl() = eFATALERROR Then
		//        Exit Sub
		//    End If
		//End Sub
		[UpgradeHelpers.Events.Handler]
		internal void mnuSenior_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSrReport.DefInstance);
			/*            frmSrReport.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuSenoirInq_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //Show Seniority Ranking Form
            ViewManager.NavigateToView(
                //Show Seniority Ranking Form
 frmSenority.DefInstance);
            /*            frmSenority.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
		//MDIForm1.Arrange vbCascade
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
		internal void mnuTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//Determine if frmTimeCard1 is already open
				//If so set to Currently selected date
				//Print TimeCard Report

				int OpenFlag = 0;

            for (int i = 0; i <= ViewManager.OpenFormsCount - 1; i++)
					{
							if ( ViewManager.GetOpenFormAt(i).ViewModel.Name == "frmTimeCard1" )
							{
                    //Timestamp report and print
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.Col = 22;
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.Row = 41;
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.Text = DateTime.Now.ToString("M/d/yy HH:mm");
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintAbortMsg("Printing Battalion 1 Time Card Worksheet - Click Cancel to quit");
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintBorder(false);
                    //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintColor(true);
                    //            frmTimeCard1.sprBatt.PrintOrientation = 2
                    frmTimeCard1.DefInstance.ViewModel.sprBatt.PrintSheet(null);
                    //frmTimeCard1.DefInstance.ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants)32;
										OpenFlag = -1;
								return ;
							}
							else
							{
								OpenFlag = 0;
							}
						}

				if ( ~OpenFlag != 0 )
				{
                ViewManager.HideView(
 frmTimeCard1.DefInstance);
                //Timestamp report and print
                frmTimeCard1.DefInstance.ViewModel.sprBatt.Col = 22;
                frmTimeCard1.DefInstance.ViewModel.sprBatt.Row = 41;
                frmTimeCard1.DefInstance.ViewModel.sprBatt.Text = DateTime.Now.ToString("M/d/yy HH:mm");

                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintAbortMsg was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintAbortMsg("Printing Battalion 1 Time Card Worksheet - Click Cancel to quit");
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintBorder was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintBorder(false);
                //UPGRADE_ISSUE: (2064) FPSpreadADO.fpSpread property sprBatt.PrintColor was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                frmTimeCard1.DefInstance.ViewModel.sprBatt.setPrintColor(true);
                //        frmTimeCard1.sprBatt.PrintOrientation = 2
                frmTimeCard1.DefInstance.ViewModel.sprBatt.PrintSheet(null);
                //frmTimeCard1.DefInstance.ViewModel.sprBatt.Action = (FarPoint.ViewModels.FPActionConstants)32;
                ViewManager.DisposeView(
 frmTimeCard1.DefInstance);
				}


			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTrade_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Enact a Trade
				//Add Trade Leave Record for current employee
				//Identify Employee that will be working
				//Create Schedule record for working employee
				//Log Trade Info to TradeHistory

				string Empid = "";
				int Response = 0;
				string UnitID = "";
				string StartDate = "";
				string EndDate = "";
				string AssignID = "";
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;

				try
				{
					{

						modGlobal.Shared.gTradeEmp = "";
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						if ( ViewModel.SelectedLabel.Name == "lbPosam" )
						{
							if ( Convert.ToString(ViewModel.lbPospm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								EndDate = "";
							}
						}
						else
						{
							if ( Convert.ToString(ViewModel.lbPosam[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Tag) == Empid )
							{
								modGlobal.Shared.gFullShift = -1;
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
								EndDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
							}
							else
							{
								modGlobal.Shared.gFullShift = 0;
								StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
								EndDate = "";
							}
						}


						//Schedule Trade Leave Record for current employee
                modGlobal
                            .Shared.gSType = "Trade";
						async1.Append(() =>
							{
                                ViewManager.NavigateToView(
                                    dlgTrade.DefInstance, true);
							});
						async1.Append(() =>
							{
								using ( var async2 = this.Async() )
								{
									modGlobal.Shared.gSType = "";
									if ( modGlobal.Shared.gTradeEmp == "" )
									{
										modGlobal.Shared.gFullShift = 0;
										this.Return();
										return ;
									}

									if ( ~modGlobal.Shared.gFullShift != 0 )
									{
										if ( ViewModel.SelectedLabel.Name == "lbPosam" )
										{
											StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
											EndDate = "";
										}
										else
										{
											StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy") + " 7:00PM";
											EndDate = "";
										}
									}

									//Determine if New Employee already scheduled for this date
									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;
									oCmd.CommandText = "sp_GetSchedAssign '" + modGlobal.Shared.gTradeEmp + "','" + StartDate + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if ( !oRec.EOF )
									{
                                        ViewManager.ShowMessage("Employee selected to work trade is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers
                                            .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
										this.Return();
										return ;
									}
									if ( modGlobal.Shared.gFullShift != 0 )
									{
										oCmd.CommandText = "sp_GetSchedAssign '" + modGlobal.Shared.gTradeEmp + "','" + EndDate + "'";
										oRec = ADORecordSetHelper.Open(oCmd, "");
										if ( !oRec.EOF )
										{
                                            ViewManager.ShowMessage("Employee selected to work trade is already scheduled for this date", "Battalion Scheduler", UpgradeHelpers.Helpers
                                                .BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
											this.Return();
											return ;
										}
									}

									modGlobal.Shared.GivingUpShift = false;

									modGlobal.Shared.gLeaveType = "TRD";
									modGlobal.Shared.gPayType = "";
									modGlobal.Shared.gSCKFlag = 0;
									async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, StartDate));
									async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized1 =>
										{
											var returningMetodValue = tempNormalized1;
										
											using ( var async3 = this.Async() )
											{


												Response = returningMetodValue.returnValue;

												Empid = returningMetodValue.Empid;

												StartDate = returningMetodValue.LeaveDate;

												if ( Response != (-1) )
												{
													modGlobal.Shared.gTradeEmp = "";
													modGlobal.Shared.gFullShift = 0;
													modGlobal.Shared.gLeaveType = "";
													this.Return();
													return ;
												}

												if ( modGlobal.Shared.gFullShift != 0 )
												{
													async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(Empid, EndDate));
													async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized3 =>
														{
															var returningMetodValue2 = tempNormalized3;
														

															Response = returningMetodValue2.returnValue;

															Empid = returningMetodValue2.Empid;

															EndDate = returningMetodValue2.LeaveDate;
														});
												}
												async3.Append(() =>
													{
														using ( var async4 = this.Async() )
														{

															if ( Response != (-1) )
															{
																//Remove first Trade Leave Record
                                                                modGlobal
                                                                    .Shared.gTradeEmp = "";
																modGlobal.Shared.gFullShift = 0;
																modGlobal.Shared.gLeaveType = "";
																this.Return();
																return ;
															}
															else
															{
																//Create TradeHistory Record
																UnitID = FindUnit(UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)).ToString();
                                                                oCmd.CommandText = "sp_GetAssign '" + ViewModel.lbUnit[Convert.ToInt32(Double.Parse(UnitID
                                                                                        ))].Text + "','" + ViewModel.lbPosition[UpgradeHelpers.Helpers.ControlArrayHelper.
                                                                            GetControlIndex(ViewModel.SelectedLabel)].Text + "','" + ViewModel.lbShift.Text + "'";
																oRec = ADORecordSetHelper.Open(oCmd, "");
																AssignID = Convert.ToString(oRec["assignment_id"]);
                                                                oCmd.CommandText = "spInsertTradeHistory '" + Empid + "','" + modGlobal.Shared.gTradeEmp + "','"
                                                                                    + StartDate + "','" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'," + AssignID;
																oCmd.ExecuteNonQuery();
																if ( modGlobal.Shared.gFullShift != 0 )
																{
                                                                    oCmd.CommandText = "spInsertTradeHistory '" + Empid + "','" + modGlobal.Shared.gTradeEmp + "','"
                                                                                        + EndDate + "','" + modGlobal.Shared.gUser + "','" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "'," + AssignID;
																	oCmd.ExecuteNonQuery();
																}
															}

															//Schedule Trade Schedule Record for New Working Employee
															UnitID = FindUnit(UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)).ToString();
                                                            async4.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(() => ScheduleEmployee(ViewModel.lbUnit[
                                                                    Convert.ToInt32(Double.Parse(UnitID))].Text, StartDate, modGlobal.
                                                                        Shared.gTradeEmp, ViewModel.lbPosition[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text));
															async4.Append<PTSProject.frmBattSchedNew.ScheduleEmployeeStruct>(tempNormalized5 =>
																{
																	var returningMetodValue1636 = tempNormalized5;
																
																		Response = (returningMetodValue1636.returnValue) ? -1 : 0;
																		StartDate = returningMetodValue1636.ShiftDate;
																		modGlobal.Shared.gTradeEmp = returningMetodValue1636.Empid;

																		if ( Response != (-1) )
																		{
																			this.Return();
																			return ;
																		}

																		modGlobal.Shared.gFullShift = 0;
																		modGlobal.Shared.gTradeEmp = "";
																		modGlobal.Shared.gLeaveType = "";

																		ClearSchedule();
																				GetBattSchedule();
																				FillLists();
																			});
																	}
																});
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
		internal void mnuTradeDetail_Click(Object eventSender, System.EventArgs eventArgs)
		{

			string sMessage = "";
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
			string StartDate = ViewModel.calSchedDate.Value.Date.ToString("M/d/yyyy");

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;
			oCmd.CommandText = "sp_GetTradeDetail '" + Empid + "','" + StartDate + "'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");

			while ( !oRec.EOF )
			{

                sMessage = sMessage + ("\r") + ("\n") + Convert.ToString(oRec["WorkingEmployee"]).Trim() + " is working for " + Convert.ToString(oRec["ScheduledEmployee"]).Trim() + " - " + Convert.ToString(oRec["ShiftTime"]).Trim();
				sMessage = sMessage + ("\r") + ("\n") + "(Updated By: " + Convert.ToString(oRec["UpdatedBy"]).Trim() + " on " + Convert.ToString(oRec["UpdatedOn"]).Trim() + ")";
				sMessage = sMessage + ("\r") + ("\n");
				oRec.MoveNext();
            };
			ViewManager.ShowMessage(sMessage, "Trade Detail", UpgradeHelpers.Helpers.BoxButtons.OK);

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
		internal void mnuTrainQuery_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
            ViewManager.NavigateToView(
                //    MsgBox "This Feature is coming soon!!", vbOKOnly, "New Training Query"
frmNewQClass.DefInstance);
			/*            frmNewQClass.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		//MDIForm1.Arrange vbCascade
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
		//MDIForm1.Arrange vbCascade
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
				//Determine which control has been dropped
				//If it's a schedule label delete schedule record
				//If it's the drag/drop panel replace name in list

				string Empid = "";
				string AMPM = "";
				int SourceIndex = 0;
				string ShiftDate = "";
				UpgradeHelpers.Helpers.ControlViewModel OtherShift = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				if ( ViewModel.SaveSecurity == "RO" )
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
                                        var returningMetodValue1693 = DeleteSchedule(Empid, ShiftDate);
														Empid = returningMetodValue1693.Empid;
														ShiftDate = returningMetodValue1693.ShiftDate;

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
                                            var returningMetodValue1695 = DeleteSchedule(Empid, ShiftDate);
																	Empid = returningMetodValue1695.Empid;
																	ShiftDate = returningMetodValue1695.ShiftDate;
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
			ViewModel.mnuSADetail.Available = true;
			ViewModel.mnuLeave.Available = false;
			ViewModel.mnuNewSched.Available = false;
			ViewModel.mnuKOT.Available = false;
			ViewModel.mnuRover.Available = false;
			ViewModel.mnuDebit.Available = false;
			ViewModel.mnuTrade.Available = false;
			ViewModel.mnuCancelTrade.Available = false;
			ViewModel.mnuTradeDetail.Available = false;
			ViewModel.mnuRemove.Available = false;
			ViewModel.mnuSendTo182.Available = false;
			//    mnuSendTo183.Visible = False
			ViewModel.mnuReport.Available = false;
			ViewModel.mnuReschedSA.Available = false;
			ViewModel.mnuPayUp.Available = false;
			ViewModel.mnuPayDown.Available = false;
			ViewModel.Ctx_mnu181PopUp.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
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

		public struct ScheduleEmployeeStruct
		{
			public bool returnValue;
			public string ShiftDate;
			public string Empid;
		}

		public static frmBattSchedNew DefInstance
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

		public static frmBattSchedNew CreateInstance()
		{
				PTSProject.frmBattSchedNew theInstance = Shared.Container.Resolve<frmBattSchedNew>();
						theInstance.Form_Load();
            return theInstance;
			}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnu181PopUp_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			ViewModel.Ctx_mnu181PopUp.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.mnu181PopUp.Get_DropDownItems())
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.Ctx_mnu181PopUp.Items.Add(item);
			}
			e.Cancel = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnu181PopUp_Closing(object sender, Stubs._System.Windows.Forms.ToolStripDropDownClosingEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.Ctx_mnu181PopUp.Items )
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.mnu181PopUp.Get_DropDownItems().Add(item);
			}
		}

		void ReLoadForm(bool addEvents)
		{
            ViewManager.NavigateToView(
                PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
            ViewModel.boxUnit[8].LifeCycleStartup();
            ViewModel.boxUnit[12].LifeCycleStartup();
            ViewModel.shpPayUpPM[72].LifeCycleStartup();
            ViewModel.shpPayUpAM[72].LifeCycleStartup();
			ViewModel.boxFCC.LifeCycleStartup();
            ViewModel.shpPayUpAM[68].LifeCycleStartup();
            ViewModel.shpPayUpAM[69].LifeCycleStartup();
            ViewModel.shpPayUpAM[70].LifeCycleStartup();
            ViewModel.shpPayUpPM[68].LifeCycleStartup();
            ViewModel.shpPayUpPM[69].LifeCycleStartup();
            ViewModel.shpPayUpPM[70].LifeCycleStartup();
            ViewModel.shpPayUpAM[71].LifeCycleStartup();
            ViewModel.shpPayUpPM[71].LifeCycleStartup();
            ViewModel.shpPayUpAM[73].LifeCycleStartup();
            ViewModel.shpPayUpPM[73].LifeCycleStartup();
            ViewModel.shpPayUpAM[74].LifeCycleStartup();
            ViewModel.shpPayUpPM[74].LifeCycleStartup();
            ViewModel.shpPayUpPM[77].LifeCycleStartup();
            ViewModel.shpPayUpAM[77].LifeCycleStartup();
            ViewModel.shpPayUpPM[76].LifeCycleStartup();
            ViewModel.shpPayUpAM[76].LifeCycleStartup();
            ViewModel.shpPayUpAM[75].LifeCycleStartup();
            ViewModel.shpPayUpPM[75].LifeCycleStartup();
            ViewModel.shpPayUpPM[61].LifeCycleStartup();
            ViewModel.shpPayUpPM[60].LifeCycleStartup();
            ViewModel.shpPayUpPM[63].LifeCycleStartup();
            ViewModel.shpPayUpPM[62].LifeCycleStartup();
            ViewModel.shpPayUpPM[39].LifeCycleStartup();
            ViewModel.shpPayUpPM[38].LifeCycleStartup();
            ViewModel.shpPayUpPM[37].LifeCycleStartup();
            ViewModel.shpPayUpPM[36].LifeCycleStartup();
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
            ViewModel.shpPayUpAM[61].LifeCycleStartup();
            ViewModel.shpPayUpAM[60].LifeCycleStartup();
            ViewModel.shpPayUpAM[63].LifeCycleStartup();
            ViewModel.shpPayUpAM[62].LifeCycleStartup();
            ViewModel.shpPayUpAM[39].LifeCycleStartup();
            ViewModel.shpPayUpAM[38].LifeCycleStartup();
            ViewModel.shpPayUpAM[37].LifeCycleStartup();
            ViewModel.shpPayUpAM[36].LifeCycleStartup();
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
            ViewModel.boxUnit[13].LifeCycleStartup();
            ViewModel.boxUnit[11].LifeCycleStartup();
            ViewModel.boxUnit[10].LifeCycleStartup();
            ViewModel.boxUnit[9].LifeCycleStartup();
            ViewModel.boxUnit[7].LifeCycleStartup();
            ViewModel.boxUnit[6].LifeCycleStartup();
            ViewModel.boxUnit[5].LifeCycleStartup();
            ViewModel.boxUnit[4].LifeCycleStartup();
            ViewModel.boxUnit[3].LifeCycleStartup();
            ViewModel.boxUnit[0].LifeCycleStartup();
            ViewModel.shpPayUpPM[55].LifeCycleStartup();
            ViewModel.shpPayUpPM[54].LifeCycleStartup();
            ViewModel.shpPayUpPM[53].LifeCycleStartup();
            ViewModel.shpPayUpPM[52].LifeCycleStartup();
            ViewModel.shpPayUpPM[51].LifeCycleStartup();
            ViewModel.shpPayUpPM[50].LifeCycleStartup();
            ViewModel.shpPayUpPM[49].LifeCycleStartup();
            ViewModel.shpPayUpPM[48].LifeCycleStartup();
            ViewModel.shpPayUpPM[47].LifeCycleStartup();
            ViewModel.shpPayUpPM[46].LifeCycleStartup();
            ViewModel.shpPayUpPM[45].LifeCycleStartup();
            ViewModel.shpPayUpPM[44].LifeCycleStartup();
            ViewModel.shpPayUpPM[43].LifeCycleStartup();
            ViewModel.shpPayUpPM[42].LifeCycleStartup();
            ViewModel.shpPayUpPM[41].LifeCycleStartup();
            ViewModel.shpPayUpPM[40].LifeCycleStartup();
            ViewModel.shpPayUpAM[55].LifeCycleStartup();
            ViewModel.shpPayUpAM[54].LifeCycleStartup();
            ViewModel.shpPayUpAM[53].LifeCycleStartup();
            ViewModel.shpPayUpAM[52].LifeCycleStartup();
            ViewModel.shpPayUpAM[51].LifeCycleStartup();
            ViewModel.shpPayUpAM[50].LifeCycleStartup();
            ViewModel.shpPayUpAM[49].LifeCycleStartup();
            ViewModel.shpPayUpAM[48].LifeCycleStartup();
            ViewModel.shpPayUpAM[47].LifeCycleStartup();
            ViewModel.shpPayUpAM[46].LifeCycleStartup();
            ViewModel.shpPayUpAM[45].LifeCycleStartup();
            ViewModel.shpPayUpAM[44].LifeCycleStartup();
            ViewModel.shpPayUpAM[43].LifeCycleStartup();
            ViewModel.shpPayUpAM[42].LifeCycleStartup();
            ViewModel.shpPayUpAM[41].LifeCycleStartup();
            ViewModel.shpPayUpAM[40].LifeCycleStartup();
            ViewModel.boxUnit[14].LifeCycleStartup();
            ViewModel.boxUnit[15].LifeCycleStartup();
            ViewModel.boxUnit[16].LifeCycleStartup();
            ViewModel.boxUnit[17].LifeCycleStartup();
            ViewModel.boxUnit[18].LifeCycleStartup();
            ViewModel.shpPayUpPM[59].LifeCycleStartup();
            ViewModel.shpPayUpPM[58].LifeCycleStartup();
            ViewModel.shpPayUpPM[57].LifeCycleStartup();
            ViewModel.shpPayUpPM[56].LifeCycleStartup();
            ViewModel.shpPayUpAM[59].LifeCycleStartup();
            ViewModel.shpPayUpAM[58].LifeCycleStartup();
            ViewModel.shpPayUpAM[57].LifeCycleStartup();
            ViewModel.shpPayUpAM[56].LifeCycleStartup();
            ViewModel.shpPayUpAM[66].LifeCycleStartup();
            ViewModel.shpPayUpAM[67].LifeCycleStartup();
            ViewModel.shpPayUpAM[64].LifeCycleStartup();
            ViewModel.shpPayUpAM[65].LifeCycleStartup();
            ViewModel.shpPayUpPM[66].LifeCycleStartup();
            ViewModel.shpPayUpPM[64].LifeCycleStartup();
            ViewModel.shpPayUpPM[65].LifeCycleStartup();
            ViewModel.shpPayUpAM[78].LifeCycleStartup();
            ViewModel.shpPayUpPM[78].LifeCycleStartup();
            ViewModel.shpPayUpAM[79].LifeCycleStartup();
            ViewModel.shpPayUpPM[79].LifeCycleStartup();
            ViewModel.shpPayUpAM[80].LifeCycleStartup();
            ViewModel.shpPayUpPM[80].LifeCycleStartup();
			ViewModel.sprLeave.LifeCycleStartup();
			ViewModel.mnu181PopUp.LifeCycleStartup();
			ViewModel.mnuHelp.LifeCycleStartup();
			ViewModel.mnuContents.LifeCycleStartup();
			ViewModel.mnuWindow.LifeCycleStartup();
			ViewModel.mnuTraining.LifeCycleStartup();
			ViewModel.mnu_Queries.LifeCycleStartup();
			ViewModel.mnuTrnReports.LifeCycleStartup();
			ViewModel.mnuReports.LifeCycleStartup();
			ViewModel.mnu_TrainingReports.LifeCycleStartup();
			ViewModel.mnupayrollreports.LifeCycleStartup();
			ViewModel.mnu_Battalion.LifeCycleStartup();
			ViewModel.mnuLeaveReports.LifeCycleStartup();
			ViewModel.mnuSchedul.LifeCycleStartup();
			ViewModel.mnupayroll.LifeCycleStartup();
			ViewModel.mnuBDWork.LifeCycleStartup();
			ViewModel.mnuPersonnelReports.LifeCycleStartup();
			ViewModel.mnuSchedule.LifeCycleStartup();
			ViewModel.mnuPersonnel.LifeCycleStartup();
			ViewModel.mnuSystem.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
            ViewModel.boxUnit[8].LifeCycleShutdown();
            ViewModel.boxUnit[12].LifeCycleShutdown();
            ViewModel.shpPayUpPM[72].LifeCycleShutdown();
            ViewModel.shpPayUpAM[72].LifeCycleShutdown();
			ViewModel.boxFCC.LifeCycleShutdown();
            ViewModel.shpPayUpAM[68].LifeCycleShutdown();
            ViewModel.shpPayUpAM[69].LifeCycleShutdown();
            ViewModel.shpPayUpAM[70].LifeCycleShutdown();
            ViewModel.shpPayUpPM[68].LifeCycleShutdown();
            ViewModel.shpPayUpPM[69].LifeCycleShutdown();
            ViewModel.shpPayUpPM[70].LifeCycleShutdown();
            ViewModel.shpPayUpAM[71].LifeCycleShutdown();
            ViewModel.shpPayUpPM[71].LifeCycleShutdown();
            ViewModel.shpPayUpAM[73].LifeCycleShutdown();
            ViewModel.shpPayUpPM[73].LifeCycleShutdown();
            ViewModel.shpPayUpAM[74].LifeCycleShutdown();
            ViewModel.shpPayUpPM[74].LifeCycleShutdown();
            ViewModel.shpPayUpPM[77].LifeCycleShutdown();
            ViewModel.shpPayUpAM[77].LifeCycleShutdown();
            ViewModel.shpPayUpPM[76].LifeCycleShutdown();
            ViewModel.shpPayUpAM[76].LifeCycleShutdown();
            ViewModel.shpPayUpAM[75].LifeCycleShutdown();
            ViewModel.shpPayUpPM[75].LifeCycleShutdown();
            ViewModel.shpPayUpPM[61].LifeCycleShutdown();
            ViewModel.shpPayUpPM[60].LifeCycleShutdown();
            ViewModel.shpPayUpPM[63].LifeCycleShutdown();
            ViewModel.shpPayUpPM[62].LifeCycleShutdown();
            ViewModel.shpPayUpPM[39].LifeCycleShutdown();
            ViewModel.shpPayUpPM[38].LifeCycleShutdown();
            ViewModel.shpPayUpPM[37].LifeCycleShutdown();
            ViewModel.shpPayUpPM[36].LifeCycleShutdown();
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
            ViewModel.shpPayUpAM[61].LifeCycleShutdown();
            ViewModel.shpPayUpAM[60].LifeCycleShutdown();
            ViewModel.shpPayUpAM[63].LifeCycleShutdown();
            ViewModel.shpPayUpAM[62].LifeCycleShutdown();
            ViewModel.shpPayUpAM[39].LifeCycleShutdown();
            ViewModel.shpPayUpAM[38].LifeCycleShutdown();
            ViewModel.shpPayUpAM[37].LifeCycleShutdown();
            ViewModel.shpPayUpAM[36].LifeCycleShutdown();
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
            ViewModel.boxUnit[13].LifeCycleShutdown();
            ViewModel.boxUnit[11].LifeCycleShutdown();
            ViewModel.boxUnit[10].LifeCycleShutdown();
            ViewModel.boxUnit[9].LifeCycleShutdown();
            ViewModel.boxUnit[7].LifeCycleShutdown();
            ViewModel.boxUnit[6].LifeCycleShutdown();
            ViewModel.boxUnit[5].LifeCycleShutdown();
            ViewModel.boxUnit[4].LifeCycleShutdown();
            ViewModel.boxUnit[3].LifeCycleShutdown();
            ViewModel.boxUnit[0].LifeCycleShutdown();
            ViewModel.shpPayUpPM[55].LifeCycleShutdown();
            ViewModel.shpPayUpPM[54].LifeCycleShutdown();
            ViewModel.shpPayUpPM[53].LifeCycleShutdown();
            ViewModel.shpPayUpPM[52].LifeCycleShutdown();
            ViewModel.shpPayUpPM[51].LifeCycleShutdown();
            ViewModel.shpPayUpPM[50].LifeCycleShutdown();
            ViewModel.shpPayUpPM[49].LifeCycleShutdown();
            ViewModel.shpPayUpPM[48].LifeCycleShutdown();
            ViewModel.shpPayUpPM[47].LifeCycleShutdown();
            ViewModel.shpPayUpPM[46].LifeCycleShutdown();
            ViewModel.shpPayUpPM[45].LifeCycleShutdown();
            ViewModel.shpPayUpPM[44].LifeCycleShutdown();
            ViewModel.shpPayUpPM[43].LifeCycleShutdown();
            ViewModel.shpPayUpPM[42].LifeCycleShutdown();
            ViewModel.shpPayUpPM[41].LifeCycleShutdown();
            ViewModel.shpPayUpPM[40].LifeCycleShutdown();
            ViewModel.shpPayUpAM[55].LifeCycleShutdown();
            ViewModel.shpPayUpAM[54].LifeCycleShutdown();
            ViewModel.shpPayUpAM[53].LifeCycleShutdown();
            ViewModel.shpPayUpAM[52].LifeCycleShutdown();
            ViewModel.shpPayUpAM[51].LifeCycleShutdown();
            ViewModel.shpPayUpAM[50].LifeCycleShutdown();
            ViewModel.shpPayUpAM[49].LifeCycleShutdown();
            ViewModel.shpPayUpAM[48].LifeCycleShutdown();
            ViewModel.shpPayUpAM[47].LifeCycleShutdown();
            ViewModel.shpPayUpAM[46].LifeCycleShutdown();
            ViewModel.shpPayUpAM[45].LifeCycleShutdown();
            ViewModel.shpPayUpAM[44].LifeCycleShutdown();
            ViewModel.shpPayUpAM[43].LifeCycleShutdown();
            ViewModel.shpPayUpAM[42].LifeCycleShutdown();
            ViewModel.shpPayUpAM[41].LifeCycleShutdown();
            ViewModel.shpPayUpAM[40].LifeCycleShutdown();
            ViewModel.boxUnit[14].LifeCycleShutdown();
            ViewModel.boxUnit[15].LifeCycleShutdown();
            ViewModel.boxUnit[16].LifeCycleShutdown();
            ViewModel.boxUnit[17].LifeCycleShutdown();
            ViewModel.boxUnit[18].LifeCycleShutdown();
            ViewModel.shpPayUpPM[59].LifeCycleShutdown();
            ViewModel.shpPayUpPM[58].LifeCycleShutdown();
            ViewModel.shpPayUpPM[57].LifeCycleShutdown();
            ViewModel.shpPayUpPM[56].LifeCycleShutdown();
            ViewModel.shpPayUpAM[59].LifeCycleShutdown();
            ViewModel.shpPayUpAM[58].LifeCycleShutdown();
            ViewModel.shpPayUpAM[57].LifeCycleShutdown();
            ViewModel.shpPayUpAM[56].LifeCycleShutdown();
            ViewModel.shpPayUpAM[66].LifeCycleShutdown();
            ViewModel.shpPayUpAM[67].LifeCycleShutdown();
            ViewModel.shpPayUpAM[64].LifeCycleShutdown();
            ViewModel.shpPayUpAM[65].LifeCycleShutdown();
            ViewModel.shpPayUpPM[66].LifeCycleShutdown();
            ViewModel.shpPayUpPM[64].LifeCycleShutdown();
            ViewModel.shpPayUpPM[65].LifeCycleShutdown();
            ViewModel.shpPayUpAM[78].LifeCycleShutdown();
            ViewModel.shpPayUpPM[78].LifeCycleShutdown();
            ViewModel.shpPayUpAM[79].LifeCycleShutdown();
            ViewModel.shpPayUpPM[79].LifeCycleShutdown();
            ViewModel.shpPayUpAM[80].LifeCycleShutdown();
            ViewModel.shpPayUpPM[80].LifeCycleShutdown();
			ViewModel.sprLeave.LifeCycleShutdown();
			ViewModel.mnu181PopUp.LifeCycleShutdown();
			ViewModel.mnuHelp.LifeCycleShutdown();
			ViewModel.mnuContents.LifeCycleShutdown();
			ViewModel.mnuWindow.LifeCycleShutdown();
			ViewModel.mnuTraining.LifeCycleShutdown();
			ViewModel.mnu_Queries.LifeCycleShutdown();
			ViewModel.mnuTrnReports.LifeCycleShutdown();
			ViewModel.mnuReports.LifeCycleShutdown();
			ViewModel.mnu_TrainingReports.LifeCycleShutdown();
			ViewModel.mnupayrollreports.LifeCycleShutdown();
			ViewModel.mnu_Battalion.LifeCycleShutdown();
			ViewModel.mnuLeaveReports.LifeCycleShutdown();
			ViewModel.mnuSchedul.LifeCycleShutdown();
			ViewModel.mnupayroll.LifeCycleShutdown();
			ViewModel.mnuBDWork.LifeCycleShutdown();
			ViewModel.mnuPersonnelReports.LifeCycleShutdown();
			ViewModel.mnuSchedule.LifeCycleShutdown();
			ViewModel.mnuPersonnel.LifeCycleShutdown();
			ViewModel.mnuSystem.LifeCycleShutdown();
			base.ExecuteControlsShutdown();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class frmBattSchedNew
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmBattSchedNewViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmBattSchedNew m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}