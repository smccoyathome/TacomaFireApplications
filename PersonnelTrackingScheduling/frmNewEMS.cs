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

	public partial class frmNewEMS
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewEMSViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(frmNewEMS));
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
		internal void lbPos16pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos16am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
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
		internal void lbPos9pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos9am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos10pm_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos10am_DragOver(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
			int X = eventArgs.X;
			int Y = eventArgs.Y;
			eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos16am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos16am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos15am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos15am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void pnSelected_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel.pnSelected.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos14am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos14am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos13am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos13am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos1pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos1pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos2pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos2pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos3pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos3pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos4pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos4pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos5pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos5pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos6pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos6pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos8pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos8pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos9pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos9pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos10pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos10pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos7am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos7am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos11pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos11pm_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_0_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_0.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12am_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12am_6.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_1_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_1.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_2_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_2.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_3_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_3.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_4_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_4.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_5_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_5.BeginDrag();
		}

		[UpgradeHelpers.Events.Handler]
		internal void _lbPos12pm_6_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			
			
			
			ViewModel._lbPos12pm_6.BeginDrag();
		}
		//**************************************************************
		//Weekly Schedule form used for Scheduling
		//EMS, HazMat, Marine, Dispatch and  Battalion Staff
		//Display's One Weeks Schedule and Leave for the selected type
		//of Employee.  Form provides combo box with names of all
		//employees of the selected type
		//Form allows both Regular and Leave Scheduling
		//**************************************************************
		//ADODB

		public void LockSchedule()
		{
			//If everyday of the current Schedule Week
			//Is locked disable all edit controls

			if ( ViewModel.SchedLock != 0 )
			{
				ViewModel.cboSelectName.Enabled = false;
				ViewModel.lbLocked.Visible = true;
				for ( int i = 0; i <= 6; i++ )
				{
					ViewModel.lbPos1am[i].Enabled = false;
					ViewModel.lbPos1am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos1pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos1pm[i].Enabled = false;
					ViewModel.lbPos2am[i].Enabled = false;
					ViewModel.lbPos2pm[i].Enabled = false;
					ViewModel.lbPos2am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos2pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos3am[i].Enabled = false;
					ViewModel.lbPos3pm[i].Enabled = false;
					ViewModel.lbPos3am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos3pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos4am[i].Enabled = false;
					ViewModel.lbPos4pm[i].Enabled = false;
					ViewModel.lbPos4am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos4pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos5am[i].Enabled = false;
					ViewModel.lbPos5pm[i].Enabled = false;
					ViewModel.lbPos5am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos5pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos6am[i].Enabled = false;
					ViewModel.lbPos6pm[i].Enabled = false;
					ViewModel.lbPos6am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos6pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos7am[i].Enabled = false;
					ViewModel.lbPos7pm[i].Enabled = false;
					ViewModel.lbPos7am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos7pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos8am[i].Enabled = false;
					ViewModel.lbPos8pm[i].Enabled = false;
					ViewModel.lbPos8am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos8pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos9am[i].Enabled = false;
					ViewModel.lbPos9pm[i].Enabled = false;
					ViewModel.lbPos9am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos9pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos10am[i].Enabled = false;
					ViewModel.lbPos10pm[i].Enabled = false;
					ViewModel.lbPos10am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos10pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos11am[i].Enabled = false;
					ViewModel.lbPos11pm[i].Enabled = false;
					ViewModel.lbPos11am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos11pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12am[i].Enabled = false;
					ViewModel.lbPos12am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12pm[i].Enabled = false;
					ViewModel.lbPos13am[i].Enabled = false;
					ViewModel.lbPos13am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos13pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos13pm[i].Enabled = false;
					ViewModel.lbPos14am[i].Enabled = false;
					ViewModel.lbPos14am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos14pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos14pm[i].Enabled = false;
					//M06
					ViewModel.lbPos15am[i].Enabled = false;
					ViewModel.lbPos15am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos15pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos15pm[i].Enabled = false;
					ViewModel.lbPos16am[i].Enabled = false;
					ViewModel.lbPos16am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos16pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos16pm[i].Enabled = false;
				}
			}
			else
			{
				ViewModel.cboSelectName.Enabled = true;
				ViewModel.lbLocked.Visible = false;
			}

			//Disable unfilled Controls on locked Days
			for ( int i = 0; i <= 6; i++ )
			{
				if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
				{
					ViewModel.lbPos1am[i].Enabled = false;
					ViewModel.lbPos1am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos1pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos1pm[i].Enabled = false;
					ViewModel.lbPos2am[i].Enabled = false;
					ViewModel.lbPos2pm[i].Enabled = false;
					ViewModel.lbPos2am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos2pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos3am[i].Enabled = false;
					ViewModel.lbPos3pm[i].Enabled = false;
					ViewModel.lbPos3am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos3pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos4am[i].Enabled = false;
					ViewModel.lbPos4pm[i].Enabled = false;
					ViewModel.lbPos4am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos4pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos5am[i].Enabled = false;
					ViewModel.lbPos5pm[i].Enabled = false;
					ViewModel.lbPos5am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos5pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos6am[i].Enabled = false;
					ViewModel.lbPos6pm[i].Enabled = false;
					ViewModel.lbPos6am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos6pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos7am[i].Enabled = false;
					ViewModel.lbPos7pm[i].Enabled = false;
					ViewModel.lbPos7am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos7pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos8am[i].Enabled = false;
					ViewModel.lbPos8pm[i].Enabled = false;
					ViewModel.lbPos8am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos8pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos9am[i].Enabled = false;
					ViewModel.lbPos9pm[i].Enabled = false;
					ViewModel.lbPos9am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos9pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos10am[i].Enabled = false;
					ViewModel.lbPos10pm[i].Enabled = false;
					ViewModel.lbPos10am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos10pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos11am[i].Enabled = false;
					ViewModel.lbPos11pm[i].Enabled = false;
					ViewModel.lbPos11am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos11pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12am[i].Enabled = false;
					ViewModel.lbPos12am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos12pm[i].Enabled = false;
					ViewModel.lbPos13am[i].Enabled = false;
					ViewModel.lbPos13am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos13pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos13pm[i].Enabled = false;
					ViewModel.lbPos14am[i].Enabled = false;
					ViewModel.lbPos14am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos14pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos14pm[i].Enabled = false;

					//M06
					ViewModel.lbPos15am[i].Enabled = false;
					ViewModel.lbPos15am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos15pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos15pm[i].Enabled = false;
					ViewModel.lbPos16am[i].Enabled = false;
					ViewModel.lbPos16am[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos16pm[i].BackColor = modGlobal.Shared.LT_GRAY;
					ViewModel.lbPos16pm[i].Enabled = false;
				}
			}

		}


		public bool CheckSignOff(ref string CheckDate)
		{
			//Check if Date is Locked
			bool result = false;
			DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

			oCmd.Connection = modGlobal.oConn;
			oCmd.CommandType = CommandType.Text;

			CheckDate = CheckDate + " 7:00AM";
			oCmd.CommandText = "sp_GetSignOff '" + CheckDate + "','1'";
			ADORecordSetHelper oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				if ( Convert.ToBoolean(oRec["shift_status"]) )
				{
					result = true;
				}
			}
			oCmd.CommandText = "sp_GetSignOff '" + CheckDate + "','2'";
			oRec = ADORecordSetHelper.Open(oCmd, "");
			if ( !oRec.EOF )
			{
				if ( Convert.ToBoolean(oRec["shift_status"]) )
				{
					result = true;
				}
			}


			return result;
		}

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

		public UpgradeHelpers.Helpers.ControlViewModel GetFullShift(UpgradeHelpers.Helpers.ControlViewModel DropCntrl)
		{
			UpgradeHelpers.Helpers.ControlViewModel result = null;
			switch ( DropCntrl.Name )
			{
				case "lbPos1am":
					result = ViewModel.lbPos1pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos1pm":
					result = ViewModel.lbPos1am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos2am":
					result = ViewModel.lbPos2pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos2pm":
					result = ViewModel.lbPos2am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos3am":
					result = ViewModel.lbPos3pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos3pm":
					result = ViewModel.lbPos3am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos4am":
					result = ViewModel.lbPos4pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos4pm":
					result = ViewModel.lbPos4am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos5am":
					result = ViewModel.lbPos5pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos5pm":
					result = ViewModel.lbPos5am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos6am":
					result = ViewModel.lbPos6pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos6pm":
					result = ViewModel.lbPos6am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos7am":
					result = ViewModel.lbPos7pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos7pm":
					result = ViewModel.lbPos7am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos8am":
					result = ViewModel.lbPos8pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos8pm":
					result = ViewModel.lbPos8am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos9am":
					result = ViewModel.lbPos9pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos9pm":
					result = ViewModel.lbPos9am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos10am":
					result = ViewModel.lbPos10pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos10pm":
					result = ViewModel.lbPos10am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos11am":
					result = ViewModel.lbPos11pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos11pm":
					result = ViewModel.lbPos11am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos12am":
					result = ViewModel.lbPos12pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos12pm":
					result = ViewModel.lbPos12am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos13am":
					result = ViewModel.lbPos13pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos13pm":
					result = ViewModel.lbPos13am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos14am":
					result = ViewModel.lbPos14pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos14pm":
					result = ViewModel.lbPos14am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];

					break;
				case "lbPos15am":
					result = ViewModel.lbPos15pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos15pm":
					result = ViewModel.lbPos15am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos16am":
					result = ViewModel.lbPos16pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
				case "lbPos16pm":
					result = ViewModel.lbPos16am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)];
					break;
			}

			return result;
		}

		public UpgradeHelpers.Helpers.ControlViewModel GetShape(UpgradeHelpers.Helpers.ControlViewModel Source)
		{
			UpgradeHelpers.Helpers.ControlViewModel result = null;
			switch ( Source.Name )
			{
				case "lbPos1am":
					result = ViewModel.shpP1am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos1pm":
					result = ViewModel.shpP1pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos2am":
					result = ViewModel.shpP2am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos2pm":
					result = ViewModel.shpP2pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos3am":
					result = ViewModel.shpP3am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos3pm":
					result = ViewModel.shpP3pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos4am":
					result = ViewModel.shpP4am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos4pm":
					result = ViewModel.shpP4pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos5am":
					result = ViewModel.shpP5am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos5pm":
					result = ViewModel.shpP5pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos6am":
					result = ViewModel.shpP6am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos6pm":
					result = ViewModel.shpP6pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos7am":
					result = ViewModel.shpP7am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos7pm":
					result = ViewModel.shpP7pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos8am":
					result = ViewModel.shpP8am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos8pm":
					result = ViewModel.shpP8pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos9am":
					result = ViewModel.shpP9am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos9pm":
					result = ViewModel.shpP9pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos10am":
					result = ViewModel.shpP10am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos10pm":
					result = ViewModel.shpP10pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos11am":
					result = ViewModel.shpP11am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos11pm":
					result = ViewModel.shpP11pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos12am":
					result = ViewModel.shpP12am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos12pm":
					result = ViewModel.shpP12pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos13am":
					result = ViewModel.shpP13am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos13pm":
					result = ViewModel.shpP13pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos14am":
					result = ViewModel.shpP14am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos14pm":
					result = ViewModel.shpP14pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];

					break;
				case "lbPos15am":
					result = ViewModel.shpP15am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
				//case "lbPos13pm" : 
				//result = shpP15pm[ControlArrayHelper.GetControlIndex(Source)]; 
				//break;
				case "lbPos16am":
					result = ViewModel.shpP16am[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
				case "lbPos16pm":
					result = ViewModel.shpP16pm[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source)];
					break;
			}

			return result;
		}

		public void LabelDragDrop(UpgradeHelpers.Helpers.ControlViewModel DropCntrl, UpgradeHelpers.Helpers.ControlViewModel SourceCntrl)
		{
			using ( var async1 = this.Async(true) )
			{
				//This subroutine executes whenever an Employee Schedule Label
				//has a dragable control droped on it
				//Origin of Droped control is established
				//Determination of Schedule, Reschedule or Move Employee action is made
				//Schedule is updated

				string OldDate = "";
				int ControlID = 0;

				//Determine if this Schedule Date is locked
				if ( ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].ForeColor.Equals(modGlobal.Shared.RED) )
				{
					ViewManager.ShowMessage("The Schedule for this date has been locked", "EMS Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}

				//Determine Which Control is calling this subroutine
				//and it's counterpart shift control
				switch ( DropCntrl.Name )
				{
					case "lbPos1am":
						ControlID = 0;
						break;
					case "lbPos1pm":
						ControlID = 1;
						break;
					case "lbPos2am":
						ControlID = 2;
						break;
					case "lbPos2pm":
						ControlID = 3;
						break;
					case "lbPos3am":
						ControlID = 4;
						break;
					case "lbPos3pm":
						ControlID = 5;
						break;
					case "lbPos4am":
						ControlID = 6;
						break;
					case "lbPos4pm":
						ControlID = 7;
						break;
					case "lbPos5am":
						ControlID = 8;
						break;
					case "lbPos5pm":
						ControlID = 9;
						break;
					case "lbPos6am":
						ControlID = 10;
						break;
					case "lbPos6pm":
						ControlID = 11;
						break;
					case "lbPos7am":
						ControlID = 12;
						break;
					case "lbPos7pm":
						ControlID = 13;
						break;
					case "lbPos8am":
						ControlID = 14;
						break;
					case "lbPos8pm":
						ControlID = 15;
						break;
					case "lbPos9am":
						ControlID = 16;
						break;
					case "lbPos9pm":
						ControlID = 17;
						break;
					case "lbPos10am":
						ControlID = 18;
						break;
					case "lbPos10pm":
						ControlID = 19;
						break;
					case "lbPos11am":
						ControlID = 20;
						break;
					case "lbPos11pm":
						ControlID = 21;
						break;
					case "lbPos12am":
						ControlID = 22;
						break;
					case "lbPos12pm":
						ControlID = 23;
						break;
					case "lbPos13am":
						ControlID = 24;
						break;
					case "lbPos13pm":
						ControlID = 25;
						break;
					case "lbPos14am":
						ControlID = 26;
						break;
					case "lbPos14pm":
						ControlID = 27;

						break;
					case "lbPos15am":
						ControlID = 28;
						break;
					case "lbPos15pm":
						ControlID = 29;
						break;
					case "lbPos16am":
						ControlID = 30;
						break;
					case "lbPos16pm":
						ControlID = 31;
						break;
				}


				string dropAMPM = DropCntrl.Name.Substring(Math.Max(DropCntrl.Name.Length - 2, 0)).ToUpper();
				string srcAMPM = SourceCntrl.Name.Substring(Math.Max(SourceCntrl.Name.Length - 2, 0)).ToUpper();
				string ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].Text + " 7:00" + dropAMPM;

				//Test to make sure time slot is open
				if ( DropCntrl.Text != "" )
				{
					ViewManager.ShowMessage("This Time Slot is already scheduled", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel ShiftControl = GetFullShift(DropCntrl);
				if ( ShiftControl.Text == "" )
				{
					modGlobal.Shared.gFullShift = -1;
				}
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}

				//Add or adjust schedule as requested
				if ( SourceCntrl.Name == "pnSelected" )
				{
					if ( ViewModel.IsAvailable )
					{
						string tempRefParam = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(SourceCntrl));
                        async1.Append<PTSProject.frmNewEMS.MoveEmployeeStruct>(() => MoveEmployee(ControlID, ShiftDate,
                                tempRefParam, ViewModel.lbShiftArray[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].Text));
						async1.Append<PTSProject.frmNewEMS.MoveEmployeeStruct>(tempNormalized1 =>
							{
								var returningMetodValue347 = tempNormalized1;
							
								ShiftDate = returningMetodValue347.ShiftDate;
								tempRefParam = returningMetodValue347.Empid;
								SourceCntrl.Text = "";
								UpgradeHelpers.Helpers.ControlHelper.SetTag(SourceCntrl, "");
								UpgradeHelpers.Helpers.ControlHelper.SetVisible(SourceCntrl, false);
							});
					}
					else
					{
						//Add Schedule record
						string tempRefParam2 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(SourceCntrl));
                        async1.Append<PTSProject.frmNewEMS.ScheduleEmployeeStruct>(() => ScheduleEmployee(ControlID, ShiftDate,
                                tempRefParam2, ViewModel.lbShiftArray[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].Text));
						async1.Append<PTSProject.frmNewEMS.ScheduleEmployeeStruct>(tempNormalized3 =>
							{
								var returningMetodValue353 = tempNormalized3;
							
								ShiftDate = returningMetodValue353.ShiftDate;
								tempRefParam2 = returningMetodValue353.Empid;
								SourceCntrl.Text = "";
								UpgradeHelpers.Helpers.ControlHelper.SetTag(SourceCntrl, "");
								UpgradeHelpers.Helpers.ControlHelper.SetVisible(SourceCntrl, false);
							});
					}
				}
				else
				{
					//Move Employee - make sure AM/PM slots are the same
					if ( dropAMPM == srcAMPM )
					{
						if ( UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl) == UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(SourceCntrl) )
						{
							//Source and Target on same calendar date
							string tempRefParam3 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(SourceCntrl));
                            async1.Append<PTSProject.frmNewEMS.MoveEmployeeStruct>(() => MoveEmployee(ControlID, ShiftDate,
                                    tempRefParam3, ViewModel.lbShiftArray[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].Text));
							async1.Append<PTSProject.frmNewEMS.MoveEmployeeStruct>(tempNormalized5 =>
								{
									var returningMetodValue361 = tempNormalized5;
								
									ShiftDate = returningMetodValue361.ShiftDate;
									tempRefParam3 = returningMetodValue361.Empid;
								});
						}
						else
						{
							//Source and Target on different calendar dates
							//Test for Trade
							if ( SourceCntrl.ForeColor.Equals(modGlobal.Shared.GREEN) )
							{
								ViewManager.ShowMessage("You can not move Trades to a different date", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
								this.Return();
								return ;
							}
							OldDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(SourceCntrl)].Text + " 7:00" + srcAMPM;
							string tempRefParam4 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(SourceCntrl));
                            async1.Append<PTSProject.frmNewEMS.ReScheduleEmployeeStruct>(() => ReScheduleEmployee(
                                        ControlID, ShiftDate, tempRefParam4, ViewModel.lbShiftArray[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(DropCntrl)].Text, OldDate));
							async1.Append<PTSProject.frmNewEMS.ReScheduleEmployeeStruct>(tempNormalized7 =>
								{
									var returningMetodValue368 = tempNormalized7;
								
									if ( returningMetodValue368.returnValue )
									{


										ShiftDate = returningMetodValue368.ShiftDate;
										tempRefParam4 = returningMetodValue368.Empid;
										OldDate = returningMetodValue368.OldDate;
										SourceCntrl.Text = "";
										UpgradeHelpers.Helpers.ControlHelper.SetTag(SourceCntrl, "");
										SourceCntrl.ForeColor = modGlobal.Shared.BLACK;
									}
								});
						}
					}
					else
					{
                        ViewManager.ShowMessage("You can only move a " + dropAMPM + " schedule to this time slot", "Weekly Scheduler", UpgradeHelpers.
                            Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
						this.Return();
						return ;
					}
				}
				async1.Append(() =>
					{

						modGlobal.Shared.gFullShift = 0;
					});
			}

		}

		public MoveEmployeeStruct MoveEmployee(int Pos, string ShiftDate, string Empid, string ShiftCode)
		{
			using ( var async1 = this.Async<MoveEmployeeStruct>(true) )
			{
				string BattCode = "";
				decimal LastRate = 0;
				double NewPayRate = 0;
				string strSQL = "";
				//***************************************************
				//Employee moved to a different position on same day
				//***************************************************
				//Gather information for Schedule Record
				//(employee_id, date, assignment, update date,updater)
				//Update Assignment info in Schedule record
				//Call GetSchedule to requery schedule data for Form
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;
				int AssignID = 0;
				int PayUp = 0;
				string JobCode = "";
				decimal PayRate = 0;
				string PayString = "";
				int Step = 0;
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
										return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                            { ShiftDate = ShiftDate, Empid = Empid, });
									}
									return this.Continue<MoveEmployeeStruct>();
								});
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
						}
                        async1.Append< MoveEmployeeStruct>(() =>
							{
								using ( var async2 = this.Async() )
								{

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;
									//Find assignment_id value for selected position
									oCmd.CommandText = "sp_GetAssign '" + ViewModel.lbUnitArray[Pos].Text + "','" + ViewModel.lbPositionArray[Pos].Text + "','" + ShiftCode + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									AssignID = Convert.ToInt32(oRec["assignment_id"]);
									modGlobal.Shared.gPayType = Convert.ToString(oRec["job_code"]);
									BattCode = Convert.ToString(oRec["battalion_code"]);
											//Check to see if someone is scheduled in this spot ~ non-Paramedic
											//Employees would not be displayed on this screen
                                    if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
											{
												//If true, then reschedule them to appropriate ROV/Debit Position
												if ( BattCode == "3" )
												{
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
													strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
													strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
												}
												else if ( BattCode == "2" )
												{
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
													strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
													strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
												}
												else if ( BattCode == "4" )
												{
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN184ROV.ToString() + " ";
													strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
													strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
												}
												else
												{
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
													strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
													strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
													strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
													strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
													strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
													strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
													oCmd.CommandText = strSQL;
													oRec = ADORecordSetHelper.Open(oCmd, "");
												}
												ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
											}

												//Add new Schedule Record
												oCmdUpdate.Connection = modGlobal.oConn;
												oCmdUpdate.CommandType = CommandType.StoredProcedure;
												oCmdUpdate.CommandText = "spUpdateScheduleAssign";
												oCmdUpdate.ExecuteNonQuery(new object[] { Empid, ShiftDate, AssignID, DateTime.Now, modGlobal.Shared.gUser });

												//If Scheduling for both AM and PM then Add second record
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

															//Check to see if someone is scheduled in this spot ~ non-Paramedic
															//Employees would not be displayed on this screen
                                        if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
															{
																//If true, then reschedule them to appropriate ROV/Debit Position
																if ( BattCode == "3" )
																{
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
																	strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
																	strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																}
																else if ( BattCode == "2" )
																{
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
																	strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
																	strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																}
																else if ( BattCode == "4" )
																{
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN184ROV.ToString() + " ";
																	strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
																	strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																}
																else
																{
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
																	strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																	strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
																	strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																	strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																	strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																	strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																	oCmd.CommandText = strSQL;
																	oRec = ADORecordSetHelper.Open(oCmd, "");
																}
																ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
															}
															oCmdUpdate.ExecuteNonQuery(new object[] { Empid, ShiftDate, AssignID, DateTime.Now, modGlobal.Shared.gUser });
												}

														GetSchedule();
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
																		NewPayRate = Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
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
																					return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                                                { ShiftDate = ShiftDate, Empid = Empid, });
																				}
																			}
																			else
																			{
																				if ( NewPayRate <= Convert.ToDouble(oRec["pay_rate"]) )
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
                                        async2.Append< MoveEmployeeStruct>(() =>
																	{
                                                using ( var async3 = this.Async() )
																		{
																			if ( modGlobal.Shared.gPayType == "" )
																			{
																				return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                                            { ShiftDate = ShiftDate, Empid = Empid, });
																			}

																			//Determine Step for PayUp
																			JobCode = modGlobal.GetJobCode(Empid);
																			Step = Convert.ToInt32(Double.Parse(modGlobal.GetStep(Empid)));
																			oCmd.CommandText = "sp_FindPayRate '" + JobCode + "'," + Step.ToString();
																			oRec = ADORecordSetHelper.Open(oCmd, "");
																			if ( !oRec.EOF )
																			{
																				PayRate = Convert.ToDecimal(oRec["pay_rate"]);
																				NewPayRate = Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
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
																							return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                                                        { ShiftDate = ShiftDate, Empid = Empid, });
																						}
																					}
																					else
																					{
																						if ( NewPayRate <= Convert.ToDouble(oRec["pay_rate"]) )
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
                                                        async3.Append< MoveEmployeeStruct>(() =>
																					{
																						if ( PayString == "" )
																						{
																							return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                                                        { ShiftDate = ShiftDate, Empid = Empid, });
																						}

																						double dbNumericTemp = 0;
																						if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
																						{
                                                                    ViewManager.ShowMessage("Invalid Step, Please try Pay Upgrade again", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons
                                                                        .OK, UpgradeHelpers.Helpers.BoxIcons.Error);
																							return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                                                                        { ShiftDate = ShiftDate, Empid = Empid, });
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
																					if ( modGlobal.Shared.gPayType == "4002F" || modGlobal.Shared.gPayType == "4002M" || modGlobal
																							.Shared.gPayType == "41010" || modGlobal.Shared.gPayType == "4002P" || modGlobal.Shared.gPayType == "4002S" )
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

																					//            If gPayType = "4001T" Then
																					//                If GetStep(Empid) = 1 Then
																					//                    Step = GetStep(Empid)
																					//                Else
																					//                    Step = GetStep(Empid) - 1
																					//                End If
																					//            End If
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
                                    async2.Append(() =>
																{

																	GetSchedule();
																});
														}
														return this.Continue<MoveEmployeeStruct>();
													});
											}
								}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                            { ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

				return this.Return<MoveEmployeeStruct>(() => new PTSProject.frmNewEMS.MoveEmployeeStruct()
                    { ShiftDate = ShiftDate, Empid = Empid, });
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
					//Delete Schedule record
					oCmd.CommandText = "spDeleteSchedule";
					oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate });
				}
				catch
				{
                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                    return new PTSProject.frmNewEMS.DeleteScheduleStruct()
                    { Empid = Empid, ShiftDate = ShiftDate, };
							}
				}

            return new PTSProject.frmNewEMS.DeleteScheduleStruct()
            { Empid = Empid, ShiftDate = ShiftDate, };
			}

		public void ClearSchedule()
		{
			//Re-initialize Employee Schedule labels

			for ( int i = 0; i <= 6; i++ )
			{
				ViewModel.lbPos1am[i].Text = "";
				ViewModel.lbPos1am[i].Tag = "";
				ViewModel.lbPos1am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos1am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos1am[i].Enabled = true;
				ViewModel.shpP1am[i].Visible = false;
				ViewModel.lbPos1pm[i].Text = "";
				ViewModel.lbPos1pm[i].Tag = "";
				ViewModel.lbPos1pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos1pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos1pm[i].Enabled = true;
				ViewModel.shpP1pm[i].Visible = false;
				ViewModel.lbPos2am[i].Text = "";
				ViewModel.lbPos2am[i].Tag = "";
				ViewModel.lbPos2am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos2am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos2am[i].Enabled = true;
				ViewModel.shpP2am[i].Visible = false;
				ViewModel.lbPos2pm[i].Text = "";
				ViewModel.lbPos2pm[i].Tag = "";
				ViewModel.lbPos2pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos2pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos2pm[i].Enabled = true;
				ViewModel.shpP2pm[i].Visible = false;
				ViewModel.lbPos3am[i].Text = "";
				ViewModel.lbPos3am[i].Tag = "";
				ViewModel.lbPos3am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos3am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos3am[i].Enabled = true;
				ViewModel.shpP3am[i].Visible = false;
				ViewModel.lbPos3pm[i].Text = "";
				ViewModel.lbPos3pm[i].Tag = "";
				ViewModel.lbPos3pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos3pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos3pm[i].Enabled = true;
				ViewModel.shpP3pm[i].Visible = false;
				ViewModel.lbPos4am[i].Text = "";
				ViewModel.lbPos4am[i].Tag = "";
				ViewModel.lbPos4am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos4am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos4am[i].Enabled = true;
				ViewModel.shpP4am[i].Visible = false;
				ViewModel.lbPos4pm[i].Text = "";
				ViewModel.lbPos4pm[i].Tag = "";
				ViewModel.lbPos4pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos4pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos4pm[i].Enabled = true;
				ViewModel.shpP4pm[i].Visible = false;
				ViewModel.lbPos5am[i].Text = "";
				ViewModel.lbPos5am[i].Tag = "";
				ViewModel.lbPos5am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos5am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos5am[i].Enabled = true;
				ViewModel.shpP5am[i].Visible = false;
				ViewModel.lbPos5pm[i].Text = "";
				ViewModel.lbPos5pm[i].Tag = "";
				ViewModel.lbPos5pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos5pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos5pm[i].Enabled = true;
				ViewModel.shpP5pm[i].Visible = false;
				ViewModel.lbPos6am[i].Text = "";
				ViewModel.lbPos6am[i].Tag = "";
				ViewModel.lbPos6am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos6am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos6am[i].Enabled = true;
				ViewModel.shpP6am[i].Visible = false;
				ViewModel.lbPos6pm[i].Text = "";
				ViewModel.lbPos6pm[i].Tag = "";
				ViewModel.lbPos6pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos6pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos6pm[i].Enabled = true;
				ViewModel.shpP6pm[i].Visible = false;
				ViewModel.lbPos7am[i].Text = "";
				ViewModel.lbPos7am[i].Tag = "";
				ViewModel.lbPos7am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos7am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos7am[i].Enabled = true;
				ViewModel.shpP7am[i].Visible = false;
				ViewModel.lbPos7pm[i].Text = "";
				ViewModel.lbPos7pm[i].Tag = "";
				ViewModel.lbPos7pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos7pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos7pm[i].Enabled = true;
				ViewModel.shpP7pm[i].Visible = false;
				ViewModel.lbPos8am[i].Text = "";
				ViewModel.lbPos8am[i].Tag = "";
				ViewModel.lbPos8am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos8am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos8am[i].Enabled = true;
				ViewModel.shpP8am[i].Visible = false;
				ViewModel.lbPos8pm[i].Text = "";
				ViewModel.lbPos8pm[i].Tag = "";
				ViewModel.lbPos8pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos8pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos8pm[i].Enabled = true;
				ViewModel.shpP8pm[i].Visible = false;
				ViewModel.lbPos9am[i].Text = "";
				ViewModel.lbPos9am[i].Tag = "";
				ViewModel.lbPos9am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos9am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos9am[i].Enabled = true;
				ViewModel.shpP9am[i].Visible = false;
				ViewModel.lbPos9pm[i].Text = "";
				ViewModel.lbPos9pm[i].Tag = "";
				ViewModel.lbPos9pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos9pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos9pm[i].Enabled = true;
				ViewModel.shpP9pm[i].Visible = false;
				ViewModel.lbPos10am[i].Text = "";
				ViewModel.lbPos10am[i].Tag = "";
				ViewModel.lbPos10am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos10am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos10am[i].Enabled = true;
				ViewModel.shpP10am[i].Visible = false;
				ViewModel.lbPos10pm[i].Text = "";
				ViewModel.lbPos10pm[i].Tag = "";
				ViewModel.lbPos10pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos10pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos10pm[i].Enabled = true;
				ViewModel.shpP10pm[i].Visible = false;
				ViewModel.lbPos11am[i].Text = "";
				ViewModel.lbPos11am[i].Tag = "";
				ViewModel.lbPos11am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos11am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos11am[i].Enabled = true;
				ViewModel.shpP11am[i].Visible = false;
				ViewModel.lbPos11pm[i].Text = "";
				ViewModel.lbPos11pm[i].Tag = "";
				ViewModel.lbPos11pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos11pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos11pm[i].Enabled = true;
				ViewModel.shpP11pm[i].Visible = false;
				ViewModel.lbPos12am[i].Text = "";
				ViewModel.lbPos12am[i].Tag = "";
				ViewModel.lbPos12am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos12am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos12am[i].Enabled = true;
				ViewModel.shpP12am[i].Visible = false;
				ViewModel.lbPos12pm[i].Text = "";
				ViewModel.lbPos12pm[i].Tag = "";
				ViewModel.lbPos12pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos12pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos12pm[i].Enabled = true;
				ViewModel.shpP12pm[i].Visible = false;
				ViewModel.lbPos13am[i].Text = "";
				ViewModel.lbPos13am[i].Tag = "";
				ViewModel.lbPos13am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos13am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos13am[i].Enabled = true;
				ViewModel.shpP13am[i].Visible = false;
				ViewModel.lbPos13pm[i].Text = "";
				ViewModel.lbPos13pm[i].Tag = "";
				ViewModel.lbPos13pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos13pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos13pm[i].Enabled = true;
				ViewModel.shpP13pm[i].Visible = false;
				ViewModel.lbPos14am[i].Text = "";
				ViewModel.lbPos14am[i].Tag = "";
				ViewModel.lbPos14am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos14am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos14am[i].Enabled = true;
				ViewModel.shpP14am[i].Visible = false;
				ViewModel.lbPos14pm[i].Text = "";
				ViewModel.lbPos14pm[i].Tag = "";
				ViewModel.lbPos14pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos14pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos14pm[i].Enabled = true;
				ViewModel.shpP14pm[i].Visible = false;
				ViewModel.lbPos15am[i].Text = "";
				ViewModel.lbPos15am[i].Tag = "";
				ViewModel.lbPos15am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos15am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos15am[i].Enabled = true;
				ViewModel.shpP15am[i].Visible = false;
				ViewModel.lbPos15pm[i].Text = "";
				ViewModel.lbPos15pm[i].Tag = "";
				ViewModel.lbPos15pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos15pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos15pm[i].Enabled = true;
				ViewModel.shpP15pm[i].Visible = false;
				ViewModel.lbPos16am[i].Text = "";
				ViewModel.lbPos16am[i].Tag = "";
				ViewModel.lbPos16am[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos16am[i].BackColor = modGlobal.Shared.WHITE;
				ViewModel.lbPos16am[i].Enabled = true;
				ViewModel.shpP16am[i].Visible = false;
				ViewModel.lbPos16pm[i].Text = "";
				ViewModel.lbPos16pm[i].Tag = "";
				ViewModel.lbPos16pm[i].ForeColor = modGlobal.Shared.BLACK;
				ViewModel.lbPos16pm[i].BackColor = modGlobal.Shared.PARCHMENT;
				ViewModel.lbPos16pm[i].Enabled = true;
				ViewModel.shpP16pm[i].Visible = false;

			}

		}

		public ScheduleEmployeeStruct ScheduleEmployee(int Pos, string ShiftDate, string Empid, string ShiftCode)
		{
			using ( var async1 = this.Async<ScheduleEmployeeStruct>(true) )
			{
				//Gather information for Schedule Record
				//(date, employee_id, assignment, time code, pay upgrade info)
				//Insert new Schedule record
				//Requery schedule data for form
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
				string BattCode = "";
				string strSQL = "";
				try
				{
					{
						//Determine if Employee is already scheduled for this date
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
							ViewManager.ShowMessage("This Employee is already scheduled for this date", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
							return this.Return<ScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ScheduleEmployeeStruct()
                                { ShiftDate = ShiftDate, Empid = Empid, });
						}

						//Determine assignment_id of selected position
						oCmd.CommandText = "sp_GetAssign '" + ViewModel.lbUnitArray[Pos].Text + "','" + ViewModel.lbPositionArray[Pos].Text + "','" + ShiftCode + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						AssignID = Convert.ToInt32(oRec["assignment_id"]);
						modGlobal.Shared.gAssignID = Convert.ToString(oRec["job_code"]);
						BattCode = Convert.ToString(oRec["battalion_code"]);
								//Check to see if someone is scheduled in this spot ~ non-Paramedic
								//Employees would not be displayed on this screen
                        if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
								{
									//If true, then reschedule them to appropriate ROV/Debit Position
									if ( BattCode == "3" )
									{
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									else if ( BattCode == "2" )
									{
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									else
									{
										// Batt = 1
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
								}

									//Display Time Code selection Dialog
                        modGlobal
                            .Shared.gLType = "S";
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
                        async1.Append< ScheduleEmployeeStruct>(() =>
										{
                                using ( var async2 = this.Async() )
											{
												if ( modGlobal.Shared.gLeaveType == "" )
												{
													return this.Return<ScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ScheduleEmployeeStruct()
                                            { ShiftDate = ShiftDate, Empid = Empid, });
												}

												TimeCode = modGlobal.Shared.gLeaveType;
												modGlobal.Shared.gLeaveType = "";
												//Determine Paycode
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
																}
																else if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
																{
																	ViewManager.ShowMessage("Invalid Step, Pay Upgrade Canceled", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons.OK);
																	PayUp = 0;
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

															//Add new Schedule record
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

															//If Scheduling for both AM and PM then Add second record
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
																	if ( Convert.ToDouble(oRec["assignment_id"]) == AssignID )
																	{
                                                        ViewManager.ShowMessage("Unable to schedule " + ShiftDate + " time slot", "Weekly Scheduler", UpgradeHelpers.
                                                            Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
																	}
																	else
																	{
                                                                    var returningMetodValue603 = DeleteSchedule(Empid, ShiftDate);
																	Empid = returningMetodValue603.Empid;
																	ShiftDate = returningMetodValue603.ShiftDate;
																	oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
																	}
																}
																else
																{
																			//Check to see if someone is scheduled in this spot ~ non-Paramedic
																			//Employees would not be displayed on this screen
                                                    if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
																			{
																				//If true, then reschedule them to appropriate ROV/Debit Position
																				if ( BattCode == "3" )
																				{
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
																				else if ( BattCode == "2" )
																				{
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
																				else
																				{
																					// Batt = 1
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
                                                                                ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel",
                                                                                UpgradeHelpers.Helpers.BoxButtons.OK);
																			}
																			oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
																}
															}

																	GetSchedule();
																});
														}
											return this.Continue<ScheduleEmployeeStruct>();
										});
								}
					}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return this.Return<ScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ScheduleEmployeeStruct()
                            { ShiftDate = ShiftDate, Empid = Empid, });
							}
				}

				return this.Return<ScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ScheduleEmployeeStruct()
                    { ShiftDate = ShiftDate, Empid = Empid, });
			}
		}

		public ReScheduleEmployeeStruct ReScheduleEmployee(int Pos, string ShiftDate, string Empid, string ShiftCode, string OldDate)
		{
			using ( var async1 = this.Async<ReScheduleEmployeeStruct>(true) )
			{
				string strSQL = "";
				//****************************************
				//Employee Moved to different day
				//****************************************
				//Delete Current Schedule Record
				//Insert New schedule record
				//Call GetSchedule to refresh Form data
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
				string BattCode = "";
				try
				{
					{
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;
						oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						if ( !oRec.EOF )
						{
							ViewManager.ShowMessage("This Employee is already scheduled for this date", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
                            return this.Return< ReScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ReScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, OldDate = OldDate, });
						}

						//Determine assignment_id of new position
						oCmd.CommandText = "sp_GetAssign '" + ViewModel.lbUnitArray[Pos].Text + "','" + ViewModel.lbPositionArray[Pos].Text + "','" + ShiftCode + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						AssignID = Convert.ToInt32(oRec["assignment_id"]);
						modGlobal.Shared.gAssignID = Convert.ToString(oRec["job_code"]);
						BattCode = Convert.ToString(oRec["battalion_code"]);
								//Check to see if someone is scheduled in this spot ~ non-Paramedic
								//Employees would not be displayed on this screen
                        if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
								{
									//If true, then reschedule them to appropriate ROV/Debit Position
									if ( BattCode == "3" )
									{
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									else if ( BattCode == "2" )
									{
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									else
									{
										//Batt = 1
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
										strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
										strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
										strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
										strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
										strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
										strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
										oCmd.CommandText = strSQL;
										oRec = ADORecordSetHelper.Open(oCmd, "");
									}
									ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel", UpgradeHelpers.Helpers.BoxButtons.OK);
								}

									//Display Time Code selection Dialog
                        modGlobal
                            .Shared.gLType = "S";
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
                        async1.Append< ReScheduleEmployeeStruct>(() =>
										{
                                using ( var async2 = this.Async() )
											{
												if ( modGlobal.Shared.gLeaveType == "" )
												{
                                        return this.Return< ReScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ReScheduleEmployeeStruct() {
                                            returnValue = false, ShiftDate = ShiftDate, Empid = Empid, OldDate = OldDate, });
												}

												TimeCode = modGlobal.Shared.gLeaveType;
												modGlobal.Shared.gLeaveType = "";
												//Determine Paycode
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
																}
																else if ( !Double.TryParse(PayString, NumberStyles.Float, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) )
																{
																	ViewManager.ShowMessage("Invalid Step, Pay Upgrade Canceled", "Pay Upgrade Error", UpgradeHelpers.Helpers.BoxButtons.OK);
																	PayUp = 0;
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

                                            var returningMetodValue684 = //Delete old Schedule record
                                            DeleteSchedule(Empid, OldDate);
											Empid = returningMetodValue684.Empid;
											OldDate = returningMetodValue684.ShiftDate;
											//Add new schedule record
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

												//If Scheduling for both AM and PM then Add second record
												if ( modGlobal.Shared.gFullShift != 0 )
												{
													if ( ShiftDate.Substring(Math.Max(ShiftDate.Length - 2, 0)) == "AM" )
													{
														ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "PM";
														OldDate = OldDate.Substring(0, Math.Min(Strings.Len(OldDate) - 2, OldDate.Length)) + "PM";
													}
													else
													{
														ShiftDate = ShiftDate.Substring(0, Math.Min(Strings.Len(ShiftDate) - 2, ShiftDate.Length)) + "AM";
														OldDate = OldDate.Substring(0, Math.Min(Strings.Len(OldDate) - 2, OldDate.Length)) + "AM";
													}

													//Test to make sure employee not already scheduled
													oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
													oRec = ADORecordSetHelper.Open(oCmd, "");
													if ( !oRec.EOF )
													{
                                                    ViewManager.ShowMessage("Unable to schedule" + ShiftDate.Substring(Math.Max(ShiftDate.Length
                                                        - 2, 0)) + " shift" + ShiftDate + " time slot", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
																	modGlobal.Shared.gFullShift = 0;
																}
																else
																{
																			//Check to see if someone is scheduled in this spot ~ non-Paramedic
																			//Employees would not be displayed on this screen
                                                    if (modGlobal.DuplicateAssignment(Empid, AssignID, ShiftDate))
																			{
																				//If true, then reschedule them to appropriate ROV/Debit Position
																				if ( BattCode == "3" )
																				{
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN183DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
																				else if ( BattCode == "2" )
																				{
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN182DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
																				else
																				{
																					// Batt = 1
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181ROV.ToString() + " ";
																					strSQL = strSQL + "Where shift_start  = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id not in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																					strSQL = "Update Schedule set assignment_id = " + modGlobal.ASGN181DBT.ToString() + " ";
																					strSQL = strSQL + "Where shift_start = '" + ShiftDate + "' and ";
																					strSQL = strSQL + "assignment_id = " + AssignID.ToString() + " and ";
																					strSQL = strSQL + "employee_id <> '" + Empid + "' and ";
																					strSQL = strSQL + "time_code_id in ('DDF','UDD') ";
																					oCmd.CommandText = strSQL;
																					oRec = ADORecordSetHelper.Open(oCmd, "");
																				}
                                                        ViewManager.ShowMessage("FYI. This position was filled, but person has been reassigned to ROV/DBT.", "Reschedule Non-Paramedic Personnel",
                                                            UpgradeHelpers.Helpers.BoxButtons.OK);
																			}

                                                    var returningMetodValue728 = DeleteSchedule(Empid, OldDate);
													Empid = returningMetodValue728.Empid;
													OldDate = returningMetodValue728.ShiftDate;
													oCmdInsert.ExecuteNonQuery(new object[] { ShiftDate, Empid, AssignID, TimeCode, PayUp, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
																}
															}

																	GetSchedule();
																});
														}
											return this.Continue<ReScheduleEmployeeStruct>();
										});
                        return this.Return< ReScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ReScheduleEmployeeStruct() { returnValue = true, ShiftDate = ShiftDate, Empid = Empid, OldDate = OldDate, });
								}
					}
				catch
				{
                        if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
                            return this.Return< ReScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ReScheduleEmployeeStruct() {
                            returnValue = false, ShiftDate = ShiftDate, Empid = Empid, OldDate = OldDate, });
							}
				}

            return this.Return< ReScheduleEmployeeStruct>(() => new PTSProject.frmNewEMS.ReScheduleEmployeeStruct() { returnValue = false, ShiftDate = ShiftDate, Empid = Empid, OldDate = OldDate, });
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
						if ( Convert.ToString(oRec["unit_code"]).StartsWith("CSR") )
						{
                        strName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".*   :" + Convert.ToString(oRec["employee_id"]);
						}
						else
						{
                        strName = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".    :" + Convert.ToString(oRec["employee_id"]);
						}
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

		public void GetAvailable()
		{
				//Fill Available dropdown array with On Leave staff
				//for each day in schedule

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string StartDate = "";
				string EndDate = "";
				string WorkDate = "";
				string AMPM = "";
				int i = 0;

				try
				{
					ViewModel.FirstTime = true;

					StartDate = ViewModel.calWeek.Value.Date.ToString("M/d/yyyy");
					EndDate = DateTime.Parse(StartDate).AddDays(7).ToString("M/d/yyyy");

					//Select all leave records from specified type of employee
					//for the selected weeks schedule
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_GetEMSAvailable '" + StartDate + "','" + EndDate + "' ";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Clear Leave listbox control array
					for ( i = 0; i <= 6; i++ )
					{
						//        lstLeave(i).Enabled = True
						//        lstLeave(i).Clear
						ViewModel.cboAvailable[i].Enabled = true;
						ViewModel.cboAvailable[i].Items.Clear();
					}

					//Load available dropdown

					while ( !oRec.EOF )
					{
					WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
                    AMPM = Convert.ToDateTime(oRec["shift_start"]).ToString("tt");
                    //AMPM = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["shift_start"], "AM/PM");
						for ( i = 0; i <= 6; i++ )
						{
							if ( ViewModel.lbWeekDay[i].Text == WorkDate )
							{
								break;
							}
						}
                    ViewModel.cboAvailable[i].AddItem(Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ". : " + AMPM);
						ViewModel.cboAvailable[i].SetItemData(ViewModel.cboAvailable[i].GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["per_sys_id"]))));
						oRec.MoveNext();
					}
					;

					for ( i = 0; i <= 6; i++ )
					{
						if ( ViewModel.cboAvailable[i].Items.Count > 0 )
						{
							ViewModel.cboAvailable[i].SelectedIndex = 0;
						}
					}
					ViewModel.FirstTime = false;
				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public void GetLeave()
		{
				//Fill Leave dropdown array with On Leave staff
				//for each day in schedule

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string StartDate = "";
				string EndDate = "";
				string WorkDate = "";
				string AMPM = "";
				int i = 0;

				try
				{
					ViewModel.FirstTime = true;

					StartDate = ViewModel.calWeek.Value.Date.ToString("M/d/yyyy");
					EndDate = DateTime.Parse(StartDate).AddDays(7).ToString("M/d/yyyy");

					//Select all leave records from specified type of employee
					//for the selected weeks schedule
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_GetXLeave '" + StartDate + "','" + EndDate + "','PM'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Clear Leave listbox control array
					for ( i = 0; i <= 6; i++ )
					{
						//        lstLeave(i).Enabled = True
						//        lstLeave(i).Clear
						ViewModel.cboLeave[i].Enabled = true;
						ViewModel.cboLeave[i].Items.Clear();
					}

					//Load leave listboxes

					while ( !oRec.EOF )
					{
						WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
                        AMPM = Convert.ToDateTime(oRec["shift_start"]).ToString("tt");
                    //AMPM = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["shift_start"], "AM/PM");
						for ( i = 0; i <= 6; i++ )
						{
							if ( ViewModel.lbWeekDay[i].Text == WorkDate )
							{
								break;
							}
						}

						//        lstLeave(i).ADDItem Trim$(orec("name_last"]) & " " _
						//'          & Left$(orec("name_first"), 1) & ". : " & AMPM
						//        lstLeave(i).ItemData(lstLeave(i).NewIndex) = Val(orec("employee_id"])
                    ViewModel.cboLeave[i].AddItem(Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ". : " + AMPM);
						ViewModel.cboLeave[i].SetItemData(ViewModel.cboLeave[i].GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(oRec["per_sys_id"]))));
						oRec.MoveNext();
					}
					;

					//Check for Locked Leave Dates
					for ( i = 0; i <= 6; i++ )
					{
						if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
						{
							//            lstLeave(i).Enabled = False
							ViewModel.cboLeave[i].Enabled = false;
						}
					}

					for ( i = 0; i <= 6; i++ )
					{
						if ( ViewModel.cboLeave[i].Items.Count > 0 )
						{
							ViewModel.cboLeave[i].SelectedIndex = 0;
						}
					}
					ViewModel.FirstTime = false;
				}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}
			}

		public void GetSchedule()
		{
				//Fill Weekly Schedule Employee Label arrays
				//Call GetLeave subroutine to load Leave listbox array

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string WorkDate = "", AMPM = "";
				int i = 0;
				string StartDate = "";
				string EndDate = "";
				PTSProject.clsFireUpload cPayroll = Container.Resolve<clsFireUpload>();

				try
				{

						ViewModel.IsAvailable = false;
						StartDate = ViewModel.calWeek.Value.Date.ToString("M/d/yyyy");
						EndDate = DateTime.Parse(StartDate).AddDays(7).ToString("M/d/yyyy");

						//Clear Employee Label Array
						ClearSchedule();

						//Select Schedule for selected Week
						oCmd.Connection = modGlobal.oConn;
						oCmd.CommandType = CommandType.Text;

						System.DateTime TempDate = DateTime.FromOADate(0);
						oCmd.CommandText = "spSelect_PayRollYearPayPeriod '" + ((DateTime.TryParse(StartDate, out TempDate)) ? TempDate.ToString("M/d/yyyy") : StartDate) + "' ";
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


						//    ocmd.CommandText = "sp_GetXSchedule '" & StartDate & "','" & EndDate & "','PM'"
						oCmd.CommandText = "sp_GetEMSSchedule '" + StartDate + "','" + EndDate + "','PM'";
						oRec = ADORecordSetHelper.Open(oCmd, "");


						//Load Employee Schedule label arrays

						while ( !oRec.EOF )
						{
							WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
                            AMPM = Convert.ToDateTime(oRec["shift_start"]).ToString("tt");
                    //AMPM = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["shift_start"], "AM/PM");
							//Find WeekDay
							for ( i = 0; i <= 6; i++ )
							{
								if ( ViewModel.lbWeekDay[i].Text == WorkDate )
								{
									break;
								}
							}
							//Find Unit/Position
							for ( int u = 8; u <= 31; u++ )
							{
								if ( modGlobal.Clean(ViewModel.lbUnitArray[u].Text) == modGlobal.Clean(oRec["unit_code"]) )
								{
									if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) == modGlobal.Clean(oRec["position_code"]) )
									{
										if ( ViewModel.lbAMPM[u].Text == AMPM )
										{
											switch ( u )
											{
												case 8:
                                            ViewModel.lbPos5am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos5am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos5am[i].Text = ViewModel.lbPos5am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos5am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos5am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos5am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP5am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos5am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos5am[i].Enabled = false;
													}
													break;
												case 9:
                                            ViewModel.lbPos5pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos5pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos5pm[i].Text = ViewModel.lbPos5pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos5pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos5pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos5pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP5pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos5pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos5pm[i].Enabled = false;
													}
													break;
												case 10:
                                            ViewModel.lbPos6am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos6am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos6am[i].Text = ViewModel.lbPos6am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos6am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos6am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos6am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP6am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos6am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos6am[i].Enabled = false;
													}
													break;
												case 11:
                                            ViewModel.lbPos6pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos6pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos6pm[i].Text = ViewModel.lbPos6pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos6pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos6pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos6pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP6pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos6pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos6pm[i].Enabled = false;
													}
													break;
												case 12:
                                            ViewModel.lbPos7am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos7am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos7am[i].Text = ViewModel.lbPos7am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos7am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos7am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos7am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP7am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos7am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos7am[i].Enabled = false;
													}
													break;
												case 13:
                                            ViewModel.lbPos7pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos7pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos7pm[i].Text = ViewModel.lbPos7pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos7pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos7pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos7pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP7pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos7pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos7pm[i].Enabled = false;
													}
													break;
												case 14:
                                            ViewModel.lbPos8am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos8am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos8am[i].Text = ViewModel.lbPos8am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos8am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos8am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos8am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP8am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos8am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos8am[i].Enabled = false;
													}
													break;
												case 15:
                                            ViewModel.lbPos8pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos8pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos8pm[i].Text = ViewModel.lbPos8pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos8pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos8pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos8pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP8pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos8pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos8pm[i].Enabled = false;
													}
													break;
												case 16:
                                            ViewModel.lbPos9am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos9am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos9am[i].Text = ViewModel.lbPos9am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos9am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos9am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos9am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP9am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos9am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos9am[i].Enabled = false;
													}
													break;
												case 17:
                                            ViewModel.lbPos9pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos9pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos9pm[i].Text = ViewModel.lbPos9pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos9pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos9pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos9pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP9pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos9pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos9pm[i].Enabled = false;
													}
													break;
												case 18:
                                            ViewModel.lbPos10am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos10am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos10am[i].Text = ViewModel.lbPos10am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos10am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos10am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos10am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP10am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos10am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos10am[i].Enabled = false;
													}
													break;
												case 19:
                                            ViewModel.lbPos10pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos10pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos10pm[i].Text = ViewModel.lbPos10pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos10pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos10pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos10pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP10pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos10pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos10pm[i].Enabled = false;
													}
													break;
												case 20:
                                            ViewModel.lbPos11am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos11am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos11am[i].Text = ViewModel.lbPos11am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos11am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos11am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos11am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP11am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos11am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos11am[i].Enabled = false;
													}
													break;
												case 21:
                                            ViewModel.lbPos11pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos11pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos11pm[i].Text = ViewModel.lbPos11pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos11pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos11pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos11pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP11pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos11pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos11pm[i].Enabled = false;
													}
													break;
												case 22:
                                            ViewModel.lbPos12am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos12am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos12am[i].Text = ViewModel.lbPos12am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos12am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos12am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos12am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP12am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos12am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos12am[i].Enabled = false;
													}
													break;
												case 23:
                                            ViewModel.lbPos12pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos12pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos12pm[i].Text = ViewModel.lbPos12pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos12pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos12pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos12pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP12pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos12pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos12pm[i].Enabled = false;
													}
													break;
												case 24:
                                            ViewModel.lbPos13am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos13am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos13am[i].Text = ViewModel.lbPos13am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos13am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos13am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos13am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP13am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos13am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos13am[i].Enabled = false;
													}
													break;
												case 25:
                                            ViewModel.lbPos13pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos13pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos13pm[i].Text = ViewModel.lbPos13pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos13pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos13pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos13pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP13pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos13pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos13pm[i].Enabled = false;
													}
													break;
												case 26:
                                            ViewModel.lbPos14am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos14am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos14am[i].Text = ViewModel.lbPos14am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos14am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos14am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos14am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP14am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos14am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos14am[i].Enabled = false;
													}
													break;
												case 27:
                                            ViewModel.lbPos14pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos14pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos14pm[i].Text = ViewModel.lbPos14pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos14pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos14pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos14pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP14pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos14pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos14pm[i].Enabled = false;
													}


													break;
												case 28:
                                            ViewModel.lbPos15am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos15am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos15am[i].Text = ViewModel.lbPos15am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos15am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos15am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos15am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP15am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos15am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos15am[i].Enabled = false;
													}
													break;
												case 29:
                                            ViewModel.lbPos15pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos15pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos15pm[i].Text = ViewModel.lbPos15pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos15pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos15pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos15pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP15pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos15pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos15pm[i].Enabled = false;
													}
													break;
												case 30:
                                            ViewModel.lbPos16am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos16am[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos16am[i].Text = ViewModel.lbPos16am[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos16am[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos16am[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos16am[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP16am[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos16am[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos16am[i].Enabled = false;
													}
													break;
												case 31:
                                            ViewModel.lbPos16pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
													ViewModel.lbPos16pm[i].Tag = Convert.ToString(oRec["employee_id"]);
													if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
													{
														ViewModel.lbPos16pm[i].Text = ViewModel.lbPos16pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
													{
														ViewModel.lbPos16pm[i].ForeColor = modGlobal.Shared.RED;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
													{
														ViewModel.lbPos16pm[i].ForeColor = modGlobal.Shared.BLUE;
													}
													if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
													{
														ViewModel.lbPos16pm[i].ForeColor = modGlobal.Shared.GREEN;
													}
													if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
													{
														ViewModel.shpP16pm[i].Visible = true;
													}
													if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
													{
														ViewModel.lbPos16pm[i].BackColor = modGlobal.Shared.LT_GRAY;
														ViewModel.lbPos16pm[i].Enabled = false;
													}


													break;
											}
										}
									}
								}
							}
							oRec.MoveNext();
						}
						;

						oCmd.CommandText = "sp_GetPMEngineSchedule '" + StartDate + "','" + EndDate + "' ";
						oRec = ADORecordSetHelper.Open(oCmd, "");


						//Load Employee Schedule label arrays

						while ( !oRec.EOF )
						{
							WorkDate = Convert.ToDateTime(oRec["shift_start"]).ToString("M/d/yyyy");
                            AMPM = Convert.ToDateTime(oRec["shift_start"]).ToString("tt");
                    //AMPM = UpgradeHelpers.Helpers.StringsHelper.Format(oRec["shift_start"], "AM/PM");
							//Find WeekDay
							for ( i = 0; i <= 6; i++ )
							{
								if ( ViewModel.lbWeekDay[i].Text == WorkDate )
								{
									break;
								}
							}
							//Find Unit/Position
							for ( int u = 0; u <= 7; u++ )
							{
								if ( modGlobal.Clean(ViewModel.lbUnitArray[u].Text) == modGlobal.Clean(oRec["unit_code"]) )
								{
									//                If Clean(lbPositionArray(u).Caption) = Clean(orec("position_code"]) Then
									if ( ViewModel.lbAMPM[u].Text == AMPM )
									{
										switch ( u )
										{
											case 0:
                                        ViewModel.lbPos1am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos1am[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos1am[i].Text = ViewModel.lbPos1am[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos1am[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos1am[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos1am[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP1am[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos1am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos1am[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos1am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos1am[i].Enabled = false;
												}
												break;
											case 1:
                                        ViewModel.lbPos1pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos1pm[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos1pm[i].Text = ViewModel.lbPos1pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos1pm[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos1pm[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos1pm[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP1pm[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos1pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos1pm[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos1pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos1pm[i].Enabled = false;
												}
												break;
											case 2:
                                        ViewModel.lbPos2am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos2am[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos2am[i].Text = ViewModel.lbPos2am[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos2am[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos2am[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos2am[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP2am[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos2am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos2am[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos2am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos2am[i].Enabled = false;
												}
												break;
											case 3:
                                        ViewModel.lbPos2pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos2pm[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos2pm[i].Text = ViewModel.lbPos2pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos2pm[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos2pm[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos2pm[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP2pm[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos2pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos2pm[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos2pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos2pm[i].Enabled = false;
												}
												break;
											case 4:
                                        ViewModel.lbPos3am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos3am[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos3am[i].Text = ViewModel.lbPos3am[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos3am[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos3am[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos3am[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP3am[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos3am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos3am[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos3am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos3am[i].Enabled = false;
												}
												break;
											case 5:
                                        ViewModel.lbPos3pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos3pm[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos3pm[i].Text = ViewModel.lbPos3pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos3pm[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos3pm[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos3pm[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP3pm[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos3pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos3pm[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos3pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos3pm[i].Enabled = false;
												}
												break;
											case 6:
                                        ViewModel.lbPos4am[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos4am[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos4am[i].Text = ViewModel.lbPos4am[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos4am[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos4am[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos4am[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP4am[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos4am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos4am[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos4am[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos4am[i].Enabled = false;
												}
												break;
											case 7:
                                        ViewModel.lbPos4pm[i].Text = Convert.ToString(oRec["name_last"]).Trim() + " " + Convert.ToString(oRec["name_first"]).Substring(0, Math.Min(1, Convert.ToString(oRec["name_first"]).Length)) + ".";
												ViewModel.lbPos4pm[i].Tag = Convert.ToString(oRec["employee_id"]);
												if ( Convert.ToString(oRec["CSR_flag"]) != "No" )
												{
													ViewModel.lbPos4pm[i].Text = ViewModel.lbPos4pm[i].Text + Convert.ToString(oRec["CSR_flag"]);
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "EDO" || modGlobal.Clean(oRec["time_code_id"]) == "OTP" )
												{
													ViewModel.lbPos4pm[i].ForeColor = modGlobal.Shared.RED;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "DDF" || modGlobal.Clean(oRec["time_code_id"]) == "UDD" )
												{
													ViewModel.lbPos4pm[i].ForeColor = modGlobal.Shared.BLUE;
												}
												if ( modGlobal.Clean(oRec["time_code_id"]) == "TRD" )
												{
													ViewModel.lbPos4pm[i].ForeColor = modGlobal.Shared.GREEN;
												}
												if ( Convert.ToBoolean(oRec["pay_upgrade"]) )
												{
													ViewModel.shpP4pm[i].Visible = true;
												}
												if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "Locked" )
												{
													ViewModel.lbPos4pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos4pm[i].Enabled = false;
												}
												if ( modGlobal.Clean(ViewModel.lbPositionArray[u].Text) != modGlobal.Clean(oRec["position_code"]) )
												{
													ViewModel.lbPos4pm[i].BackColor = modGlobal.Shared.LT_GRAY;
													ViewModel.lbPos4pm[i].Enabled = false;
												}
												break;
										}
									}
								//                End If
								}
							}
							oRec.MoveNext();
						}
						;

								GetLeave();
								GetAvailable();

					}
				catch
				{

                if (modGlobal.ErrorControl() == modGlobal.eFATALERROR)
						{
								return ;
							}
				}

			}

		public void DisplayPositions(int Position)
		{
			//Display Employee Name Labels for desired position

			switch ( Position )
			{
				case 1:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos1am[i].Visible = true;
						ViewModel.lbPos1pm[i].Visible = true;
						ViewModel.lbPos1am[i].Text = "";
						ViewModel.lbPos1pm[i].Text = "";
					}
					break;
				case 3:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos2am[i].Visible = true;
						ViewModel.lbPos2pm[i].Visible = true;
						ViewModel.lbPos2am[i].Text = "";
						ViewModel.lbPos2pm[i].Text = "";
					}
					break;
				case 5:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos3am[i].Visible = true;
						ViewModel.lbPos3pm[i].Visible = true;
						ViewModel.lbPos3am[i].Text = "";
						ViewModel.lbPos3pm[i].Text = "";
					}
					break;
				case 7:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos4am[i].Visible = true;
						ViewModel.lbPos4pm[i].Visible = true;
						ViewModel.lbPos4am[i].Text = "";
						ViewModel.lbPos4pm[i].Text = "";
					}
					break;
				case 9:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos5am[i].Visible = true;
						ViewModel.lbPos5pm[i].Visible = true;
						ViewModel.lbPos5am[i].Text = "";
						ViewModel.lbPos5pm[i].Text = "";
					}
					break;
				case 11:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos6am[i].Visible = true;
						ViewModel.lbPos6pm[i].Visible = true;
						ViewModel.lbPos6am[i].Text = "";
						ViewModel.lbPos6pm[i].Text = "";
					}
					break;
				case 13:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos7am[i].Visible = true;
						ViewModel.lbPos7pm[i].Visible = true;
						ViewModel.lbPos7am[i].Text = "";
						ViewModel.lbPos7pm[i].Text = "";
					}
					break;
				case 15:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos8am[i].Visible = true;
						ViewModel.lbPos8pm[i].Visible = true;
						ViewModel.lbPos8am[i].Text = "";
						ViewModel.lbPos8pm[i].Text = "";
					}
					break;
				case 17:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos9am[i].Visible = true;
						ViewModel.lbPos9pm[i].Visible = true;
						ViewModel.lbPos9am[i].Text = "";
						ViewModel.lbPos9pm[i].Text = "";
					}
					break;
				case 19:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos10am[i].Visible = true;
						ViewModel.lbPos10pm[i].Visible = true;
						ViewModel.lbPos10am[i].Text = "";
						ViewModel.lbPos10pm[i].Text = "";
					}
					break;
				case 21:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos11am[i].Visible = true;
						ViewModel.lbPos11pm[i].Visible = true;
						ViewModel.lbPos11am[i].Text = "";
						ViewModel.lbPos11pm[i].Text = "";
					}
					break;
				case 23:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos12am[i].Visible = true;
						ViewModel.lbPos12pm[i].Visible = true;
						ViewModel.lbPos12am[i].Text = "";
						ViewModel.lbPos12pm[i].Text = "";
					}
					break;
				case 25:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos13am[i].Visible = true;
						ViewModel.lbPos13pm[i].Visible = true;
						ViewModel.lbPos13am[i].Text = "";
						ViewModel.lbPos13pm[i].Text = "";
					}
					break;
				case 27:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos14am[i].Visible = true;
						ViewModel.lbPos14pm[i].Visible = true;
						ViewModel.lbPos14am[i].Text = "";
						ViewModel.lbPos14pm[i].Text = "";
					}
					break;
				case 29:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos15am[i].Visible = true;
						ViewModel.lbPos15pm[i].Visible = true;
						ViewModel.lbPos15am[i].Text = "";
						ViewModel.lbPos15pm[i].Text = "";
					}
					break;
				case 31:
					for ( int i = 0; i <= 6; i++ )
					{
						ViewModel.lbPos16am[i].Visible = true;
						ViewModel.lbPos16pm[i].Visible = true;
						ViewModel.lbPos16am[i].Text = "";
						ViewModel.lbPos16pm[i].Text = "";
					}

					break;
			}
		}

		public void GetUnits()
		{
				//Fill Unit, Position Label Arrays

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string CurrUnit = "";
				int i = 0;

				try
				{

					//Select list of Units and Positions for specified Employee Type
					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;
					oCmd.CommandText = "sp_GetXUnits 'PM'";
					oRec = ADORecordSetHelper.Open(oCmd, "");

					//Fill Unit & Position Label arrays
					//Display any filled labels along with
					//Associated AMPM labels, Unit divider lines
					//Call DisplayPositions to display associated Employee Name labels
					//for any filled Position Array labels

					i = 0;
					CurrUnit = "";

					while ( !oRec.EOF )
					{
						ViewModel.lbUnitArray[i].Text = Convert.ToString(oRec["unit_code"]);
						ViewModel.lbPositionArray[i].Text = Convert.ToString(oRec["position_code"]);
						ViewModel.lbPositionArray[i].Visible = true;
						ViewModel.lbAMPM[i].Visible = true;

						if ( ViewModel.lbUnitArray[i].Text != CurrUnit )
						{
							ViewModel.lbUnitArray[i].Visible = true;
							CurrUnit = ViewModel.lbUnitArray[i].Text;
							switch ( i )
							{
								case 2:
									ViewModel.Line1[0].Visible = true;
									break;
								case 4:
									ViewModel.Line1[1].Visible = true;
									break;
								case 6:
									ViewModel.Line1[2].Visible = true;
									break;
								case 8:
									ViewModel.Line1[3].Visible = true;
									break;
								case 10:
									ViewModel.Line1[4].Visible = true;
									break;
								case 12:
									ViewModel.Line1[5].Visible = true;
									break;
								case 14:
									ViewModel.Line1[6].Visible = true;
									break;
								case 16:
									ViewModel.Line1[7].Visible = true;
									break;
								case 18:
									ViewModel.Line1[8].Visible = true;
									break;
								case 20:
									ViewModel.Line1[9].Visible = true;
									break;
								case 22:
								case 24:
									ViewModel.Line1[10].Visible = true;
									break;
							}
						}
						i++;
						ViewModel.lbUnitArray[i].Text = Convert.ToString(oRec["unit_code"]);
						ViewModel.lbPositionArray[i].Text = Convert.ToString(oRec["position_code"]);
						ViewModel.lbPositionArray[i].Visible = true;
						ViewModel.lbAMPM[i].Visible = true;
						DisplayPositions(i);

						i++;

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

		public void FillWeekLabels()
		{
				//Fill WeekDay Label array and Shift Label Array

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				System.DateTime WorkDate = DateTime.FromOADate(0);
				string ShiftDate = "";
				int i = 0;


				try
				{

					oCmd.Connection = modGlobal.oConn;
					oCmd.CommandType = CommandType.Text;

					WorkDate = ViewModel.calWeek.Value.Date;
					i = 0;

					//Load Weekday and Shift label arrays
					ShiftDate = WorkDate.ToString("M/d/yyyy") + " 7:00AM";
					oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
					oRec = ADORecordSetHelper.Open(oCmd, "");
					ViewModel.lbWeekDay[i].Text = WorkDate.ToString("M/d/yyyy");
					ViewModel.lbLeaveDay[i].Text = ViewModel.lbWeekDay[i].Text;
					ViewModel.lbShiftArray[i].Text = Convert.ToString(oRec["shift_code"]);
					string tempRefParam = WorkDate.ToString("M/d/yyyy");
					if ( CheckSignOff(ref tempRefParam) )
					{
						ViewModel.lbWeekDay[i].Tag = "Locked";
						ViewModel.lbWeekDay[i].ForeColor = modGlobal.Shared.RED;
						ViewModel.lbLeaveDay[i].ForeColor = modGlobal.Shared.RED;
					}
					else
					{
						ViewModel.lbWeekDay[i].Tag = "";
						ViewModel.lbWeekDay[i].ForeColor = modGlobal.Shared.BLACK;
						ViewModel.lbLeaveDay[i].ForeColor = modGlobal.Shared.BLACK;
					}
					for ( i = 1; i <= 6; i++ )
					{
						WorkDate = WorkDate.AddDays(1);
						ViewModel.lbWeekDay[i].Text = WorkDate.ToString("M/d/yyyy");
						ViewModel.lbLeaveDay[i].Text = ViewModel.lbWeekDay[i].Text;
						ShiftDate = WorkDate.ToString("M/d/yyyy") + " 7:00AM";
						oCmd.CommandText = "sp_GetShift '" + ShiftDate + "'";
						oRec = ADORecordSetHelper.Open(oCmd, "");
						ViewModel.lbShiftArray[i].Text = Convert.ToString(oRec["shift_code"]);
						string tempRefParam2 = WorkDate.ToString("M/d/yyyy");
						if ( CheckSignOff(ref tempRefParam2) )
						{
							ViewModel.lbWeekDay[i].Tag = "Locked";
							ViewModel.lbWeekDay[i].ForeColor = modGlobal.Shared.RED;
							ViewModel.lbLeaveDay[i].ForeColor = modGlobal.Shared.RED;
						}
						else
						{
							ViewModel.lbWeekDay[i].Tag = "";
							ViewModel.lbWeekDay[i].ForeColor = modGlobal.Shared.BLACK;
							ViewModel.lbLeaveDay[i].ForeColor = modGlobal.Shared.BLACK;
						}
					}

					//Check if every day on Schedule Locked
					ViewModel.SchedLock = -1;
					for ( i = 0; i <= 6; i++ )
					{
						if ( Convert.ToString(ViewModel.lbWeekDay[i].Tag) == "" )
						{
							ViewModel.SchedLock = 0;
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

		[UpgradeHelpers.Events.Handler]
		internal void calWeek_Click(Object eventSender, System.EventArgs eventArgs)
		{
				//New Week Selected - Refresh Form Schedule controls
            modGlobal
                .Shared.gCurrentYear = ViewModel.calWeek.Value.Date.Year;
						FillWeekLabels();
						GetSchedule();
						LockSchedule();

			}

		[UpgradeHelpers.Events.Handler]
		internal void cboAvailable_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			int Index = this.ViewModel.cboAvailable.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
			//Place Selected Employee in DragDrop panel for Scheduling
			PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
			string Empid = "";
			ViewModel.IsAvailable = false;
			//Test to make sure that a name was selected
			if ( ViewModel.cboAvailable[Index].SelectedIndex < 0 )
			{
				return ;
			}
			if ( !SecurityOK() )
			{
				return ;
			}
			if ( ViewModel.FirstTime )
			{
				return ;
			}
			ViewModel.pnSelected.Text = ViewModel.cboAvailable[Index].Text.Substring(0, Math.Min(Strings.Len(ViewModel.cboAvailable[Index].Text) - 4, ViewModel.cboAvailable[Index].Text.Length));

			//Find EmpID by using PerSysID
			int PerSysID = ViewModel.cboAvailable[Index].GetItemData(ViewModel.cboAvailable[Index].SelectedIndex);

			if ( ~cSched.GetEmployeeIDByPerSysID(PerSysID) != 0 )
			{
				ViewManager.ShowMessage("Oooops!  Something is wrong!  Could not located Employee ID.", "Get Employee ID)", UpgradeHelpers.Helpers.BoxButtons.OK);
				return ;
			}
			else
			{
				Empid = modGlobal.Clean(cSched.PersonnelRecord["employee_id"]);
			}

			//    Empid = Trim$(Str$(cboAvailable(Index).ItemData(cboAvailable(Index).ListIndex)))
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
			ViewModel.pnSelected.Tag = Empid;
			ViewModel.pnSelected.Visible = true;
			ViewModel.IsAvailable = true;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cboLeave_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				int Index = this.ViewModel.cboLeave.IndexOf((UpgradeHelpers.BasicViewModels.ComboBoxViewModel)eventSender);
				string sMessage = "";
				//Leave Leave dropdown doubleclicked
				//Delete leave record requested
				//Determine schedule slot and
				//Check to ensure that no one else is already scheduled
				//Determine if Leave record exists
				//Delete leave record
				PTSProject.clsScheduler cSched = Container.Resolve<clsScheduler>();
				int PerSysID = 0;
				//string sName = "";
				string Empid = "";
				string ShiftDate = "";
				int AssignID = 0;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string Msg = "";
				string KOT = "";
				UpgradeHelpers.Helpers.DialogResult resp = (UpgradeHelpers.Helpers.DialogResult)0;

				try
				{
					{
						ViewModel.IsAvailable = false;
						if ( !SecurityOK() )
						{
							this.Return();
							return ;
						}
						if ( ViewModel.FirstTime )
						{
							this.Return();
							return ;
						}

						//Find EmpID by using PerSysID
						PerSysID = ViewModel.cboLeave[Index].GetItemData(ViewModel.cboLeave[Index].SelectedIndex);

						if ( ~cSched.GetEmployeeIDByPerSysID(PerSysID) != 0 )
						{
							ViewManager.ShowMessage("Oooops!  Something is wrong!  Could not located Employee ID.", "Get Employee ID)", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
						}
						else
						{
							Empid = modGlobal.Clean(cSched.PersonnelRecord["employee_id"]);
						}
                        async1.Append<UpgradeHelpers.Helpers.DialogResult>(()
                                => ViewManager.ShowMessage("Did you want to delete this employee's leave record?", "Delete Employee Leave Record", UpgradeHelpers.Helpers.BoxButtons.YesNoCancel));
						async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
						async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
							{

								//    'Format EmpID parameter
								//    Empid = Trim$(Str$(cboLeave(Index).ItemData(cboLeave(Index).ListIndex)))
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

								resp = tempNormalized1;
							});
						async1.Append(() =>
							{
									if ( resp != UpgradeHelpers.Helpers.DialogResult.Yes )
									{
										this.Return();
										return ;
									}

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.Text;

									ShiftDate = ViewModel.lbWeekDay[Index].Text + " 7:00" + ViewModel.cboLeave[Index].Text.Substring(Math.Max(ViewModel.cboLeave[Index].Text.Length - 2, 0));

									//Check Schedule to determine if employee is scheduled
									//for this date, if so store assignment_id
									//and check that no one else is also scheduled
									oCmd.CommandText = "sp_GetSchedAssign '" + Empid + "','" + ShiftDate + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");

									if ( !oRec.EOF )
									{
										AssignID = Convert.ToInt32(oRec["assignment_id"]);
                                    if (AssignID != modGlobal.ASGN181ROV && AssignID != modGlobal.ASGN182ROV && AssignID != modGlobal.ASGN183ROV && AssignID != modGlobal.ASGN184ROV && AssignID != modGlobal.ASGN181DBT && AssignID != modGlobal.ASGN182DBT && AssignID != modGlobal.ASGN183DBT)
										{
                                        Msg = "Unable to Reschedule Employee, You must first clear Employee's current schedule: " + "\n" + Convert.ToString(oRec["unit_code"]).Trim() +
                                                    " - " + Convert.ToString(oRec["position_code"]).Trim() + " " + ViewModel.cboLeave[Index].Text.Substring(Math.Max(ViewModel.cboLeave[Index].Text.Length - 2, 0));
											oCmd.CommandText = "sp_GetSchedEmp '" + ShiftDate + "'," + AssignID.ToString() + ",'" + Empid + "'";
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( !oRec.EOF )
											{
												ViewManager.ShowMessage(Msg, "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
												this.Return();
												return ;
											}
										}
									}

									oCmd.CommandText = "sp_GetIndLeave '" + ShiftDate + "','" + Empid + "'";
									oRec = ADORecordSetHelper.Open(oCmd, "");
									if ( oRec.EOF )
									{
										ViewManager.ShowMessage("Delete Leave Record Error - No Leave record found!", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Exclamation);
										this.Return();
										return ;
									}
									else
									{
										KOT = modGlobal.Clean(oRec["time_code_id"]);
									}

									//ADD PAYROLL LOGIC HERE
                                System
                                    .DateTime TempDate = DateTime.FromOADate(0);
									if ( ~modPTSPayroll.CheckPayrollForLeaveDelete(Empid, (DateTime.TryParse(ShiftDate, out TempDate)) ? TempDate.ToString("MM/dd/yyyy") : ShiftDate, KOT) != 0 )
									{
										sMessage = "Ooops!! Payroll may have been Uploaded.  Delete payroll record first.  If you " + "experience any problems, please call Debra Lewandowsky x5068... Thanks";
										ViewManager.ShowMessage(sMessage, "Deleting Payroll for Leave", UpgradeHelpers.Helpers.BoxButtons.OK);

									}
									else
									{
										//Delete Leave
										oCmd.CommandText = "spDeleteLeave '" + Empid + "','" + ShiftDate + "'";
										oCmd.ExecuteNonQuery();

									//        'Make VacationRequest Active... if exist
									//        'Commenting out this code fore now...
									//        ocmd.CommandType = adCmdText
									//        ocmd.CommandText = "Select * From VacationRequest where " & _
									//'            "req_shift_start = '" & ShiftDate & "' And employee_id = '" & _
									//'            Empid & "' "
									//        Set orec = ocmd.Execute
									//        If Not orec.EOF Then
									//            ocmd.CommandType = adCmdText
									//            ocmd.CommandText = "Update VacationRequest set granted_by = Null, " & _
									//'                "granted_date = Null where " & _
									//'                "req_shift_start = '" & ShiftDate & "' And employee_id = '" & _
									//'                Empid & "' "
									//            Set orec = ocmd.Execute
									//        End If
									}

											//Refresh Schedule
											GetSchedule();
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

		//Private Sub cboLeave_DblClick(Index As Integer)
		//
		//    If FirstTime Then Exit Sub
		//    SelectedSAName = cboLeave(Index).Text
		//    If Clean(SelectedSAName) = "" Then Exit Sub
		//
		//    SelectedSA = Trim$(Str$(cboLeave(Index).ItemData(cboLeave(Index).ListIndex)))
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
		//    SelectedDate = Format$(lbWeekDay(Index), "mm/dd/yyyy")
		//
		//    mnuViewDetail.Visible = True
		//    mnuLeave.Visible = False
		//    mnuPayUp.Visible = False
		//    mnuPayDown.Visible = False
		//    mnuKOT.Visible = False
		//    mnuTrade.Visible = False
		//    mnuRemove.Visible = False
		//    mnuSendTo181.Visible = False
		//    mnuSendTo182.Visible = False
		//    mnuReport.Visible = False
		//
		//    PopupMenu mnuNewEMSPopup
		//
		//End Sub
		[UpgradeHelpers.Events.Handler]
		internal void cboSelectName_SelectionChangeCommitted(Object eventSender, System.EventArgs eventArgs)
		{
			//Place Selected Employee in DragDrop panel for Scheduling
			ViewModel.IsAvailable = false;
			//Test to make sure that a name was selected
			if ( ViewModel.cboSelectName.SelectedIndex < 0 )
			{
				return ;
			}
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
		internal void cmdClose_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//Unload Weekly Scheduler form
			//This triggers Form Unload event
			ViewManager.DisposeView(this);

		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdCSRCalc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgCalcPMCSR.DefInstance);
			/*            dlgCalcPMCSR.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
		}

		[UpgradeHelpers.Events.Handler]
		internal void cmdPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gStartTrans = ViewModel.calWeek.Value.Date.ToString("M/d/yyyy") + " 7:00AM";
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

		internal void frmNewEMS_Activated(Object eventSender, System.EventArgs eventArgs)
		{
				if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender )
				{
					UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>)eventSender;
							//Call Global Refresh Form subroutine
							//to refresh displayed data on open forms

							modGlobal.RefreshActiveForm();

				}
			}

		//UPGRADE_WARNING: (2065) Form event frmNewEMS.Deactivate has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2065.aspx
		[UpgradeHelpers.Events.Handler]
		internal void frmNewEMS_Deactivate(Object eventSender, System.EventArgs eventArgs)
		{
						//Call Global Refresh Form subroutine
						//to refresh displayed data on open forms

						modGlobal.RefreshActiveForm();
			}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
				//Set Form Caption to reflect Type Selected from Main Menu
				//Format Date control
				//Call FillSelectList,GetUnits,FillWeekLabels and GetSchedule
				//subroutines to load Form Schedule controls

				int UDays = 0;

				try
				{

                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 2 }), "Enabled", false);
                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 3 }), "Enabled", false);
                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 4 }), "Enabled", false);
                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 5 }), "Enabled", false);
                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 6 }), "Enabled", false);
                //UPGRADE_ISSUE: (2064) SSCalendarWidgets_A.SSDateCombo property calWeek.x was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2064.aspx
                UpgradeHelpers.Helpers.ReflectionHelper.LetMember(UpgradeHelpers.Helpers.ReflectionHelper.Invoke(ViewModel.calWeek.getX(), "DayOfWeek", new object[] { 7 }), "Enabled", false);


						if ( DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Sunday) == 1 )
						{
							UDays = -6;
						}
						else
						{
							UDays = (DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Sunday) - 2) * -1;
						}
						ViewModel.calWeek.Value = DateTime.Parse(DateTime.Now.AddDays(UDays).ToString("MM/dd/yyyy"));

						if ( modGlobal.Shared.gSecurity == "RO" && modGlobal.Shared.gSecurity == "CPT" )
						{
							ViewModel.mnuEmpInfo.Enabled = false;
							ViewModel.mnuRoster.Enabled = false;
							ViewModel.mnuIndTimeCard.Enabled = false;
							ViewModel.mnuPPE.Enabled = false;
							ViewModel.mnuPayrollReports.Enabled = false;
							ViewModel.mnuImmune.Enabled = false;
						}

						if ( modGlobal.Shared.gSecurity != "ADM" )
						{
							ViewModel.mnu_transfer_req.Enabled = false;
							ViewModel.mnuPMCerts.Enabled = false;
							ViewModel.mnuFRoster.Enabled = false;
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

								FillSelectList();
								//    GetUnits
								FillWeekLabels();
								GetSchedule();
								ViewModel.cmdPayroll.Enabled = modGlobal.Shared.gSecurity == "ADM" || modGlobal.Shared.gSecurity == "BAT" || modGlobal.Shared.gSecurity == "AID";
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
		internal void lbPos10am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos10am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos10am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos10am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos10am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos10am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos10am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos10am[Index];
				if ( ViewModel.lbPos10am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos10am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos10am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos10am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos10pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos10pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos10pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos10pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos10pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos10pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos10pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos10pm[Index];
				if ( ViewModel.lbPos10pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos10pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos10pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos10pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos11am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos11am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos11am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos11am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos11am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos11am[Index];
				if ( ViewModel.lbPos11am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos11am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos11am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos11am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos11pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos11pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos11pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos11pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos11pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos11pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos11pm[Index];
				if ( ViewModel.lbPos11pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos11pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos11pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos11pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos12am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos12am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos12am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos12am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos12am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos12am[Index];
				if ( ViewModel.lbPos12am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos12am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos12am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos12am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos12pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos12pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos12pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos12pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos12pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos12pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos12pm[Index];
				if ( ViewModel.lbPos12pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos12pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos12pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos12pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos13am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos13am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos13am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos13am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos13am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos13am[Index];
				if ( ViewModel.lbPos13am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos13am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos13am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos13am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos13pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos13pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos13pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos13pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos13pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos13pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos13pm[Index];
				if ( ViewModel.lbPos13pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos13pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos13pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos13pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos14am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos14am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos14am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos14am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos14am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos14am[Index];
				if ( ViewModel.lbPos14am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos14am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos14am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos14am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos14pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos14pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos14pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos14pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos14pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos14pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos14pm[Index];
				if ( ViewModel.lbPos14pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos14pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos14pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos14pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos1am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos1am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos1am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos1am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos1am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos1am[Index];
				if ( ViewModel.lbPos1am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos1am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos1am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos1am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos1pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos1pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos1pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos1pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos1pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos1pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos1pm[Index];
				if ( ViewModel.lbPos1pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos1pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos1pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos1pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos2am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos2am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos2am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos2am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos2am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos2am[Index];
				if ( ViewModel.lbPos2am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos2am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos2am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos2am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos2pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos2pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos2pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos2pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos2pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos2pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos2pm[Index];
				if ( ViewModel.lbPos2pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos2pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos2pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos2pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos3am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos3am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos3am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos3am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos3am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos3am[Index];
				if ( ViewModel.lbPos3am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos3am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos3am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos3am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos3pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos3pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos3pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos3pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos3pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos3pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos3pm[Index];
				if ( ViewModel.lbPos3pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos3pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos3pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos3pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos4am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos4am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos4am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos4am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos4am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos4am[Index];
				if ( ViewModel.lbPos4am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos4am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
				else
				{
					if ( ViewModel.lbPos4am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos4am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos4pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos4pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos4pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos4pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos4pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos4pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos4pm[Index];
				if ( ViewModel.lbPos4pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos4pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
				else
				{
					if ( ViewModel.lbPos4pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos4pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos5am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos5am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos5am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos5am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos5am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos5am[Index];
				if ( ViewModel.lbPos5am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos5am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos5am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos5am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos5pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos5pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos5pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos5pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos5pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos5pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos5pm[Index];
				if ( ViewModel.lbPos5pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos5pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos5pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos5pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos6am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos6am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos6am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos6am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos6am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos6am[Index];
				if ( ViewModel.lbPos6am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos6am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
				else
				{
					if ( ViewModel.lbPos6am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos6am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos6pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos6pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos6pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos6pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos6pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos6pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos6pm[Index];
				if ( ViewModel.lbPos6pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos6pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
				else
				{
					if ( ViewModel.lbPos6pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos6pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos7am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos7am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos7am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos7am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos7am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos7am[Index];
				if ( ViewModel.lbPos7am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos7am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos7am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos7am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos7pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos7pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos7pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos7pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos7pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos7pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos7pm[Index];
				if ( ViewModel.lbPos7pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos7pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos7pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos7pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos8am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos8am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos8am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos8am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos8am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos8am[Index];
				if ( ViewModel.lbPos8am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos8am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos8am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos8am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos8pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos8pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos8pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos8pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos8pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos8pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos8pm[Index];
				if ( ViewModel.lbPos8pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos8pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos8pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos8pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos9am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos9am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos9am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos9am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos9am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos9am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos9am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos9am[Index];
				if ( ViewModel.lbPos9am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos9am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos9am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos9am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos9pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos9pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos9pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos9pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos9pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos9pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos9pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos9pm[Index];
				if ( ViewModel.lbPos9pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos9pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos9pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos9pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);
				}
			}

		}

		//Private Sub lstLeave_DblClick(Index As Integer)
		//    'Leave Listbox doubleclicked
		//    'Delete leave record requested
		//    'Determine schedule slot and
		//    'Check to ensure that no one else is already scheduled
		//    'Determine if Leave record exists
		//    'Delete leave record
		//
		//    Dim sName As String
		//    Dim Empid As String
		//    Dim ShiftDate As String
		//    Dim AssignID As Long
		//    Dim ocmd As New ADODB.Command
		//    Dim orec As ADODB.Recordset
		//    Dim BankOpen As Long
		//    Dim Msg As String
		//    Dim KOT As String
		//
		//    On Error GoTo ErrHandler
		//    If Not SecurityOK Then Exit Sub
		//
		//    'Format EmpID parameter
		//    Empid = Trim$(Str$(lstLeave(Index).ItemData(lstLeave(Index).ListIndex)))
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
		//
		//    ocmd.ActiveConnection = oConn
		//    ocmd.CommandType = adCmdText
		//
		//    ShiftDate = lbWeekDay(Index) & " 7:00" & Right$(lstLeave(Index).Text, 2)
		//
		//    'Check Schedule to determine if employee is scheduled
		//    'for this date, if so store assignment_id
		//    'and check that no one else is also scheduled
		//    ocmd.CommandText = "sp_GetSchedAssign '" & Empid & "','" & ShiftDate & "'"
		//    Set orec = ocmd.Execute
		//
		//    If Not orec.EOF Then
		//        AssignID = orec("assignment_id")
		//        If AssignID <> ASGN181ROV And _
		//'            AssignID <> ASGN182ROV And _
		//'            AssignID <> ASGN181DBT And _
		//'            AssignID <> ASGN182DBT Then
		//            Msg = "Unable to Reschedule Employee, You must first clear Employee's current schedule: " & Chr(10) & Trim$(orec("unit_code"]) & " - " & Trim$(orec("position_code"]) & " " & Right$(lstLeave(Index).Text, 2)
        //            ocmd.CommandText = "sp_GetSchedEmp '" & ShiftDate & "'," & AssignID & ",'" & Empid & "'"
        //            Set orec = ocmd.Execute
		//            If Not orec.EOF Then
		//                MsgBox Msg, vbOKOnly, "Weekly Scheduler"
		//                Exit Sub
		//            End If
		//        End If
		//     End If
		//
		//    ocmd.CommandText = "sp_GetIndLeave '" & ShiftDate & "','" & Empid & "'"
		//    Set orec = ocmd.Execute
		//    If orec.EOF Then
		//        MsgBox "Delete Leave Record Error - No Leave record found!", _
		//'            vbExclamation, "Weekly Scheduler"
		//        Exit Sub
		//    Else
		//        KOT = Clean(oRec("time_code_id"])
		//    End If
		//
		//    'ADD PAYROLL LOGIC HERE
		//    If Not CheckPayrollForLeaveDelete(Empid, Format(ShiftDate, "mm/dd/yyyy"), KOT) Then
		//        sMessage = "Ooops!! Payroll may have been Uploaded.  Delete payroll record first.  If you " _
		//'                        & "experience any problems, please call Debra Lewandowsky x5068... Thanks"
		//        MsgBox sMessage, vbOKOnly, "Deleting Payroll for Leave"
		//
		//    Else
		//        'Delete Leave
		//        ocmd.CommandText = "spDeleteLeave '" & Empid & "','" & ShiftDate & "'"
		//        ocmd.Execute
		//
		//        'Make VacationRequest Active... if exist
		//        ocmd.CommandType = adCmdText
		//        ocmd.CommandText = "Select * From VacationRequest where " & _
		//'            "req_shift_start = '" & ShiftDate & "' And employee_id = '" & _
		//'            Empid & "' "
		//        Set orec = ocmd.Execute
		//        If Not orec.EOF Then
		//            ocmd.CommandType = adCmdText
		//            ocmd.CommandText = "Update VacationRequest set granted_by = Null, " & _
		//'                "granted_date = Null where " & _
		//'                "req_shift_start = '" & ShiftDate & "' And employee_id = '" & _
		//'                Empid & "' "
		//            Set orec = ocmd.Execute
		//        End If
		//    End If
		//
		//    'Refresh Schedule
		//    GetSchedule
		//
		//    Exit Sub
		//
		//ErrHandler:
		//    If ErrorControl() = eFATALERROR Then
		//        Exit Sub
		//    End If
		//
		//End Sub
		//
		//Private Sub lstLeave_LostFocus(Index As Integer)
		//    Dim i As Integer
		//
		//    For i = 0 To lstLeave(Index).ListCount - 1
		//        lstLeave(Index).Selected(i) = False
		//    Next i
		//End Sub
		//
		//Private Sub lstLeave_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
		//
		//    If Button = vbRightButton Then
		//        ClickedLeave = True
		//
		//        SelectedSAName = lstLeave(Index).Text
		//        If Clean(SelectedSAName) = "" Then Exit Sub
		//        SelectedSA = Trim$(Str$(lstLeave(Index).ItemData(lstLeave(Index).ListIndex)))
		//        If Len(SelectedSA) < 5 Then
		//            If Len(SelectedSA) = 4 Then
		//                SelectedSA = "0" & SelectedSA
		//            ElseIf Len(SelectedSA) = 3 Then
		//                SelectedSA = "00" & SelectedSA
		//            ElseIf Len(SelectedSA) = 2 Then
		//                SelectedSA = "000" & SelectedSA
		//            Else
		//                SelectedSA = "0000" & SelectedSA
		//            End If
		//        End If
		//        SelectedDate = Format$(lbWeekDay(Index), "mm/dd/yyyy")
		//
		//        mnuViewDetail.Visible = True
		//        mnuLeave.Visible = False
		//        mnuPayUp.Visible = False
		//        mnuPayDown.Visible = False
		//        mnuKOT.Visible = False
		//        mnuTrade.Visible = False
		//        mnuRemove.Visible = False
		//        mnuSendTo181.Visible = False
		//        mnuSendTo182.Visible = False
		//        mnuReport.Visible = False
		//
		//
		//        PopupMenu mnuNewEMSPopup
		//
		//    End If
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
		internal void mnu_DDGroups_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmDebitReport.DefInstance);
			/*            frmDebitReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnu_HelpPrntScrn_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPrintScreenHelp.DefInstance);
			/*            frmPrintScreenHelp.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
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
		internal void mnu_legend_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                dlgBattLegend.DefInstance);
			/*            dlgBattLegend.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnu_PMBaseStaReport_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmTrnBaseStation.DefInstance);
			/*            frmTrnBaseStation.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
			;
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
		//MDIForm1.Arrange vbCascade
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
		internal void mnu_sick_usage_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmSickLeaveUsage.DefInstance);
			/*            frmSickLeaveUsage.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnu_watch_duty_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmWatchDutyAssignment.DefInstance);
			/*            frmWatchDutyAssignment.DefInstance.SetBounds(0, 0            	, 0, 0, Stubs._System.Windows.            	Forms.BoundsSpecified.X | Stubs.            	_System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnuALSProc_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndALSProcReport.DefInstance);
			/*            frmIndALSProcReport.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnuBattalion1_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display Battalion 1 Scheduler
            ViewManager.NavigateToView(

                //Display Battalion 1 Scheduler
 frmNewBattSched.DefInstance);
            ViewManager.SetCurrentView(
                frmNewBattSched.DefInstance.ViewModel);
            /*            frmNewBattSched.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion2_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display Battalion 2 Scheduler
            ViewManager.NavigateToView(

                //Display Battalion 2 Scheduler
 frmNewBattSched2.DefInstance);
            ViewManager.SetCurrentView(
                frmNewBattSched2.DefInstance.ViewModel);
            /*            frmNewBattSched2.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;

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

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuBattalion4_Click(Object eventSender, System.EventArgs eventArgs)
		{
				ViewManager.DisposeView(this);
            ViewManager.NavigateToView(

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
		internal void mnuBenefit_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmCF1Report.DefInstance);
			/*            frmCF1Report.DefInstance.SetBounds(0, 0, 0            	, 0, Stubs._System.Windows.Forms.            	BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnuEMSDaily_Click(Object eventSender, System.EventArgs eventArgs)
		{

            //Display EMS Daily Weekly Scheduler form
            ViewManager.NavigateToView(

                //Display EMS Daily Weekly Scheduler form
 frmEMSDailySched.DefInstance);
            /*            frmEMSDailySched.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnuImmune_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//   MsgBox "This feature is coming soon!", vbOKOnly, "Manage Employee Immunizations"
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
		internal void mnuIndAnnualPayroll_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmIndAnnualPayroll.DefInstance);
			/*            frmIndAnnualPayroll.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
				UpgradeHelpers.Helpers.ControlViewModel AltShift = null;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
						ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;

                        if (modPTSPayroll.CheckPayrollForDate(Empid, DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy")) != 0)
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of changing KOT for both shifts
						AltShift = GetFullShift(ViewModel.SelectedLabel);
						if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) )
						{
							modGlobal.Shared.gFullShift = -1;
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
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

								oCmd.Connection = modGlobal.oConn;
								oCmd.CommandType = CommandType.StoredProcedure;

								//Update Schedule time_code
								oCmd.CommandText = "spUpdateScheduleTime";
								oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, modGlobal.Shared.gLeaveType, DateTime.Now, modGlobal.Shared.gUser });

								if ( modGlobal.Shared.gLeaveType == "EDO" || modGlobal.Shared.gLeaveType == "OTP" )
								{
									ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.RED;
								}
								else if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
								{
									ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLUE;
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
									ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
									oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, modGlobal.Shared.gLeaveType, DateTime.Now, modGlobal.Shared.gUser });

									if ( modGlobal.Shared.gLeaveType == "OTP" || modGlobal.Shared.gLeaveType == "EDO" )
									{
										AltShift.ForeColor = modGlobal.Shared.RED;
									}
									else if ( modGlobal.Shared.gLeaveType == "DDF" || modGlobal.Shared.gLeaveType == "UDD" )
									{
										AltShift.ForeColor = modGlobal.Shared.BLUE;
									}
									else
									{
										AltShift.ForeColor = modGlobal.Shared.BLACK;
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
				string Empid = "";
				//Leave Request
				//This subroutine executes whenever a Employee Schedule Label
				//has been double clicked to request Leave

				int Response = 0;
				int VacBankFlag = 0;
				UpgradeHelpers.Helpers.ControlViewModel shpControl = null;

				modGlobal.Shared.gStartTrans = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy");
				modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
				UpgradeHelpers.Helpers.ControlViewModel AltShift = GetFullShift(ViewModel.SelectedLabel);
				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) )
				{
					modGlobal.Shared.gFullShift = -1;
				}
				else
				{
					modGlobal.Shared.gFullShift = 0;
				}

				modGlobal.Shared.GivingUpShift = false;
				//Display Leave Dialog
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

							if ( modGlobal.Shared.gVacBank != 0 )
							{
								VacBankFlag = -1;
							}
							string AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();

							if ( modPTSPayroll.CheckPayrollForDate(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel
												.SelectedLabel)), DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy")) != 0 )
							{
								ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
							}

							if ( ~modGlobal.Shared.gExtendLeave != 0 )
							{
								//Call ScheduleLeave Function, returns True if successfull
								string tempRefParam = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
								string tempRefParam2 = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
								async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(tempRefParam, tempRefParam2));
                                async2.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized1 =>
									{
                                        var returningMetodValue = tempNormalized1;
									
										using ( var async3 = this.Async() )
										{


											Response = returningMetodValue.returnValue;

											tempRefParam = returningMetodValue.Empid;

											tempRefParam2 = returningMetodValue.LeaveDate;
											if ( Response != 0 )
											{
												//            lstLeave(SelectedLabel.Index).ADDItem SelectedLabel.Caption & " : " & AMPM
												//            lstLeave(SelectedLabel.Index).ItemData(lstLeave(SelectedLabel.Index).NewIndex) = Val(SelectedLabel.Tag)
												ViewModel.cboLeave[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].AddItem(ViewModel.SelectedLabel.Text + " : " + AMPM);
                                                ViewModel.cboLeave[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)]
                                                            .SetItemData(ViewModel.cboLeave[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)]
                                                                    .GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)))));
												ViewModel.SelectedLabel.Text = "";
												UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
												ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
												shpControl = GetShape(ViewModel.SelectedLabel);
												UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);
											}

											if ( modGlobal.Shared.gFullShift != 0 )
											{
												AMPM = AltShift.Name.Substring(Math.Max(AltShift.Name.Length - 2, 0)).ToUpper();
												if ( VacBankFlag != 0 )
												{
													modGlobal.Shared.gVacBank = -1;
												}
												else
												{
													modGlobal.Shared.gVacBank = 0;
												}
												string tempRefParam3 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift));
												string tempRefParam4 = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(AltShift)].Text + " 7:00" + AMPM;
												async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(() => modGlobal.ScheduleLeave(tempRefParam3, tempRefParam4));
                                                async3.Append<PTSProject.modGlobal.ScheduleLeaveStruct>(tempNormalized3 =>
													{
                                                        var returningMetodValue2 = tempNormalized3;
													


														Response = returningMetodValue2.returnValue;

														tempRefParam3 = returningMetodValue2.Empid;

														tempRefParam4 = returningMetodValue2.LeaveDate;
														if ( Response != 0 )
														{
															//                lstLeave(AltShift.Index).ADDItem AltShift.Caption & " : " & AMPM
															//                lstLeave(AltShift.Index).ItemData(lstLeave(AltShift.Index).NewIndex) = Val(AltShift.Tag)
															ViewModel.cboLeave[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(AltShift)].AddItem(AltShift.Text + " : " + AMPM);
                                                            ViewModel.cboLeave[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(AltShift)].SetItemData(ViewModel.cboLeave[UpgradeHelpers
                                                                        .Helpers.ControlArrayHelper.GetControlIndex(AltShift)].GetNewIndex(), Convert.ToInt32(Conversion.Val(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)))));
															AltShift.Text = "";
															UpgradeHelpers.Helpers.ControlHelper.SetTag(AltShift, "");
															AltShift.ForeColor = modGlobal.Shared.BLACK;
															shpControl = GetShape(AltShift);
															UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);
														}
													});
											}
										}
									});
							}
							else
							{
								// Call ExtendLeave Function
								string tempRefParam5 = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift));
								var ExtendLeaveReturningValue = default(PTSProject.modGlobal.ExtendLeaveStruct);
								async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(() => modGlobal.ExtendLeave(tempRefParam5));
                                async2.Append<PTSProject.modGlobal.ExtendLeaveStruct, PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized4 => tempNormalized4);
                                async2.Append<PTSProject.modGlobal.ExtendLeaveStruct>(tempNormalized5 =>
									{
                                        ExtendLeaveReturningValue = tempNormalized5;
									});
								async2.Append(() =>
									{

										Response = ExtendLeaveReturningValue.returnValue;

										tempRefParam5 = ExtendLeaveReturningValue.Empid;
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
		internal void mnuNewBatt1_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmBattSchedNew.DefInstance);
            ViewManager.SetCurrentView(
                frmBattSchedNew.DefInstance.ViewModel);
            /*            frmBattSchedNew.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
				;
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
		internal void mnuNewBatt3_Click(Object eventSender, System.EventArgs eventArgs)
		{
            //    Unload Me
 //Display Battalion 3 Scheduler
            ViewManager.NavigateToView(
                //    Unload Me
                //Display Battalion 3 Scheduler
 frmNewBattSched3.DefInstance);
            ViewManager.SetCurrentView(
                frmNewBattSched3.DefInstance.ViewModel);
            /*            frmNewBattSched3.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
				UpgradeHelpers.Helpers.ControlViewModel AltShift = null;
				UpgradeHelpers.Helpers.ControlViewModel shpControl = null;
				UpgradeHelpers.Helpers.ControlViewModel AltshpControl = null;
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
						ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;

                        if (modPTSPayroll.CheckPayrollForDate(Empid, DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy")) != 0)
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of removing Pay Upgrade for both shifts
						AltShift = GetFullShift(ViewModel.SelectedLabel);
						shpControl = GetShape(ViewModel.SelectedLabel);
						AltshpControl = GetShape(AltShift);

						if ( UpgradeHelpers.Helpers.ControlHelper.GetVisible(shpControl) )
						{
							if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) )
							{
								if ( UpgradeHelpers.Helpers.ControlHelper.GetVisible(AltshpControl) )
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
							ViewManager.ShowMessage("No " + AMPM + " Pay Upgrade to Remove, Request Canceled", "Paramedic Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
							this.Return();
							return ;
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
								UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);

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
									ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
									oCmd.ExecuteNonQuery(new object[] { Empid, ShiftDate, 0, JobCode, Step, DateTime.Now, modGlobal.Shared.gUser });
									UpgradeHelpers.Helpers.ControlHelper.SetVisible(AltshpControl, false);
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
				UpgradeHelpers.Helpers.ControlViewModel AltShift = null;
				UpgradeHelpers.Helpers.ControlViewModel shpControl = null;
				UpgradeHelpers.Helpers.ControlViewModel AltshpControl = null;
				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper oRec = null;
				string JobCode = "";
				int Step = 0;
				decimal PayRate = 0;
				string PayString = "";

				try
				{
					{

						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();
						ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;

                        if (modPTSPayroll.CheckPayrollForDate(Empid, DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy")) != 0)
						{
							ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
						}

						//Determine whether to offer option of Pay Upgrade for both shifts
						AltShift = GetFullShift(ViewModel.SelectedLabel);
						shpControl = GetShape(ViewModel.SelectedLabel);
						AltshpControl = GetShape(AltShift);

						if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) )
						{
							modGlobal.Shared.gFullShift = -1;
						}
						else
						{
							modGlobal.Shared.gFullShift = 0;
						}


						//Display Leave request Dialog
                        modGlobal
                            .Shared.gLType = "P";
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
										PayRate = (decimal)Math.Round((double)(PayRate + ((decimal)(((double)PayRate) * 0.05d))), 2);
										for ( int i = 1; i <= 11; i++ )
										{
											oCmd.CommandText = "sp_FindPayRate '" + modGlobal.Shared.gPayType + "'," + i.ToString();
											oRec = ADORecordSetHelper.Open(oCmd, "");
											if ( oRec.EOF )
											{
                                                ViewManager.ShowMessage("The Selected Job does not constitute a Pay Upgrade. Please try a different Job Code.", "Pay Upgrade Error", UpgradeHelpers
                                                    .Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
												this.Return();
												return ;
											}
											else
											{
												if ( ((double)PayRate) <= Convert.ToDouble(oRec["pay_rate"]) )
												{
													Step = i;
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
											UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, true);

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
												ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
                                                oCmd.CommandText = "spUpdateSchedulePay '" + Empid + "','" + ShiftDate + "',1,'" + modGlobal.Shared.
                                                                        gPayType + "'," + Step.ToString() + ",'" + UpgradeHelpers.Helpers.DateTimeHelper.ToString(DateTime.Now) + "','" + modGlobal.Shared.gUser + "'";
												oCmd.ExecuteNonQuery();
												UpgradeHelpers.Helpers.ControlHelper.SetVisible(AltshpControl, true);
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
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPMCerts_Click(Object eventSender, System.EventArgs eventArgs)
		{
            ViewManager.NavigateToView(
                frmPMCertification.DefInstance);
			/*            frmPMCertification.DefInstance.SetBounds(0, 0,            	0, 0, Stubs._System.Windows.Forms            	.BoundsSpecified.X | Stubs._System.Windows.Forms.BoundsSpecified.Y)*/
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
		internal void mnuPrintPayReport_Click(Object eventSender, System.EventArgs eventArgs)
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
            ViewManager.DisposeView(frmTimeCardX.DefInstance);

			}

		[UpgradeHelpers.Events.Handler]
		internal void mnuPrintScreen_Click(Object eventSender, System.EventArgs eventArgs)
		{
			//    MsgBox "This feature is coming soon!", vbOKOnly, "Screen Print Any Form"

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
			withVar.TopMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.7f);
			withVar.BottomMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.7f);
			withVar.LeftMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.7f);
			withVar.RightMargin = UpgradeSupport.Word_Global_definst.InchesToPoints(0.7f);
			withVar.Gutter = UpgradeSupport.Word_Global_definst.InchesToPoints(0);
			withVar.HeaderDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0.5f);
			withVar.FooterDistance = UpgradeSupport.Word_Global_definst.InchesToPoints(0.5f);
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
				UpgradeHelpers.Helpers.ControlViewModel shpControl = null;
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult)0;

				string Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)).Trim();
				string AMPM = ViewModel.SelectedLabel.Name.Substring(Math.Max(ViewModel.SelectedLabel.Name.Length - 2, 0)).ToUpper();

                if (modPTSPayroll.CheckPayrollForDate(Empid, DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("M/d/yyyy")) != 0)
				{
					ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
				}

				//Determine whether to offer to Remove both Shifts
				UpgradeHelpers.Helpers.ControlViewModel AltShift = GetFullShift(ViewModel.SelectedLabel);

				if ( Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)) == Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(AltShift)) )
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
							string ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
                        var returningMetodValue2679 = DeleteSchedule(Empid, ShiftDate);
										Empid = returningMetodValue2679.Empid;
										ShiftDate = returningMetodValue2679.ShiftDate;

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
											ShiftDate = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00" + AMPM;
                            var returningMetodValue2681 = DeleteSchedule(Empid, ShiftDate);
													Empid = returningMetodValue2681.Empid;
													ShiftDate = returningMetodValue2681.ShiftDate;
													ViewModel.SelectedLabel.Text = "";
													AltShift.Text = "";
													UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
													UpgradeHelpers.Helpers.ControlHelper.SetTag(AltShift, "");
													ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
													AltShift.ForeColor = modGlobal.Shared.BLACK;
													shpControl = GetShape(ViewModel.SelectedLabel);
													UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);
													shpControl = GetShape(AltShift);
													UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);
													modGlobal.Shared.gFullShift = 0;
										}
										else
										{
											ViewModel.SelectedLabel.Text = "";
											UpgradeHelpers.Helpers.ControlHelper.SetTag(ViewModel.SelectedLabel, "");
											ViewModel.SelectedLabel.ForeColor = modGlobal.Shared.BLACK;
											shpControl = GetShape(ViewModel.SelectedLabel);
											UpgradeHelpers.Helpers.ControlHelper.SetVisible(shpControl, false);
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
				string Empid = "";
				string JobCode = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper orec2 = null;
				string SqlString = "";
				//    Dim AltShift As Control
				//    Dim shpControl As Control

				try

				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						modGlobal.Shared.gLeaveType = "";
						//    Set AltShift = GetFullShift(SelectedLabel)
						ocmd2.Connection = modGlobal.oConn;
						ocmd2.CommandType = CommandType.Text;

						SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
						SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
						ocmd2.CommandText = SqlString;
						orec2 = ADORecordSetHelper.Open(ocmd2, "");

						if ( !orec2.EOF )
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
						}

						modGlobal.Shared.gFullShift = -1;
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

									JobCode = modGlobal.GetJobCode(Empid);

									oCmd.Connection = modGlobal.oConn;
									oCmd.CommandType = CommandType.StoredProcedure;
									oCmd.CommandText = "spUpdateSchedule";
									oCmd.ExecuteNonQuery(new object[] { Empid, modGlobal.Shared.gStartTrans, modGlobal.Shared.gEndTrans,
                                    modGlobal.Shared.gAssignment, modGlobal.Shared.gLeaveType, 0, JobCode, DateTime.Now, modGlobal.Shared.gUser });

											GetSchedule();
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
				//    Dim AltShift As Control
				//    Dim shpControl As Control

				try

				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						modGlobal.Shared.gLeaveType = "";

						ocmd2.Connection = modGlobal.oConn;
						ocmd2.CommandType = CommandType.Text;

						SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
						SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
						ocmd2.CommandText = SqlString;
						orec2 = ADORecordSetHelper.Open(ocmd2, "");

						if ( !orec2.EOF )
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
						}

						//    Set AltShift = GetFullShift(SelectedLabel)


                        modGlobal
                            .Shared.gFullShift = -1;
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

											GetSchedule();
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
		internal void mnuSendTo183_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Selected from PopUp Menu
				//Update Schedule to change assignment_id to Batt 3 Rover or Debit
				//Based on current KOT

				DbCommand oCmd = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				//ADORecordSetHelper oRec = null;
				//string StartDate = "", EndDate = "";
				string Empid = "";
				string JobCode = "";
				DbCommand ocmd2 = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				ADORecordSetHelper orec2 = null;
				string SqlString = "";
				//    Dim AltShift As Control
				//    Dim shpControl As Control

				try

				{
					{

						modGlobal.Shared.gStartTrans = ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text + " 7:00AM";
						modGlobal.Shared.gEndTrans = DateTime.Parse(modGlobal.Shared.gStartTrans).AddDays(1).ToString("M/d/yyyy");
						Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel));
						modGlobal.Shared.gLeaveType = "";

						ocmd2.Connection = modGlobal.oConn;
						ocmd2.CommandType = CommandType.Text;

						SqlString = "Select time_code_id From Schedule Where employee_id = '" + Empid + "' ";
						SqlString = SqlString + "and shift_start = '" + modGlobal.Shared.gStartTrans + "' ";
						ocmd2.CommandText = SqlString;
						orec2 = ADORecordSetHelper.Open(ocmd2, "");

						if ( !orec2.EOF )
						{
							modGlobal.Shared.gLeaveType = modGlobal.Clean(orec2["time_code_id"]);
						}

						//    Set AltShift = GetFullShift(SelectedLabel)


                        modGlobal
                            .Shared.gFullShift = -1;
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

											GetSchedule();
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
		internal void mnuSeniorInq_Click(Object eventSender, System.EventArgs eventArgs)
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
		//    'MDIForm1.Arrange vbCascade
		}

		[UpgradeHelpers.Events.Handler]
		internal void mnuTimeCard_Click(Object eventSender, System.EventArgs eventArgs)
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
		internal void mnuTrade_Click(Object eventSender, System.EventArgs eventArgs)
		{
			ViewManager.ShowMessage("This feature only works on the Battalion Schedulers for now...", "Scheduling a Trade", UpgradeHelpers.Helpers.BoxButtons.OK);
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
		//'MDIForm1.Arrange vbCascade
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

		[UpgradeHelpers.Events.Handler]
		internal void mnuViewDetail_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{

				if ( ViewModel.ClickedLeave )
				{
					async1.Append<System.Int32>(() => modGlobal.ViewLeaveDetail(ViewModel.SelectedSA, ViewModel.SelectedSAName, ViewModel.SelectedDate));
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
					async1.Append<System.Int32>(() => modGlobal.ViewScheduleDetail(ViewModel.SelectedSA, ViewModel.SelectedSAName, ViewModel.SelectedDate));
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
						ViewModel.SelectedDate = "";
						ViewModel.ClickedLeave = false;
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void picTrash_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				//Determine which control has been dropped
				//If it's a schedule label delete schedule record
				//and refresh form schedule data
				//If it's the drag/drop panel clear panel data

				string Empid = "";
				string AMPM = "";
				int Index = 0;
				string ShiftDate = "";

				if ( Source.Name == "pnSelected" )
				{
					ViewModel.pnSelected.Text = "";
					ViewModel.pnSelected.Tag = "";
					ViewModel.pnSelected.Visible = false;
				}
				else if ( Source.ForeColor.Equals(modGlobal.Shared.GREEN) )
				{
					ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
					return ;
				}
				else
				{
					Empid = Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(Source)).Trim();
					AMPM = Source.Name.Substring(Math.Max(Source.Name.Length - 2, 0));
					Index = UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(Source);
					ShiftDate = ViewModel.lbWeekDay[Index].Text + " 7:00" + AMPM.ToUpper();
					if ( modPTSPayroll.CheckPayrollForDate(Empid, DateTime.Parse(ViewModel.lbWeekDay[Index].Text).ToString("M/d/yyyy")) != 0 )
					{
						ViewManager.ShowMessage("WARNING!!  Payroll Records Exists for this Employee!", "Check for Payroll", UpgradeHelpers.Helpers.BoxButtons.OK);
					}
                var returningMetodValue2786 = DeleteSchedule(Empid, ShiftDate);
								Empid = returningMetodValue2786.Empid;
								ShiftDate = returningMetodValue2786.ShiftDate;
										GetSchedule();
							}

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

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos15am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos15am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos15am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos15am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos15am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos15am[Index];
				if ( ViewModel.lbPos15am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos15am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos15am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos15am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos15pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos15pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos15pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos15pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos15pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos15pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos15pm[Index];
				if ( ViewModel.lbPos15pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos15pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos15pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos15pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos16am_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos16am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos16am[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos16am[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos16am_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos16am.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos16am(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos16am[Index];
				if ( ViewModel.lbPos16am[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos16am(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos16am[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos16am[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos16pm_DragDrop(Object eventSender, UpgradeHelpers.Events.DragEventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				UpgradeHelpers.Helpers.ControlViewModel Source = eventArgs.GetSource();
				int x = eventArgs.X;
				int Y = eventArgs.Y;
				eventArgs.Effect = UpgradeHelpers.Helpers.DragDropEffects.All;
				int Index = this.ViewModel.lbPos16pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
				//Call LabelDragDrop subroutine

				//    IsAvailable = False
				if ( Source.ToString() == ViewModel.lbPos16pm[Index].Text )
				{
					this.Return();
					return ;
				}
				if ( !SecurityOK() )
				{
					this.Return();
					return ;
				}
				UpgradeHelpers.Helpers.ControlViewModel DropCntrl = ViewModel.lbPos16pm[Index];
				async1.Append(() =>
					{
						LabelDragDrop(DropCntrl, Source);
					});
			}

		}

		[UpgradeHelpers.Events.Handler]
		internal void lbPos16pm_MouseDown(Object eventSender, UpgradeHelpers.Events.MouseEventArgs eventArgs)
		{
			int Button = (int)eventArgs.Button;
			//WEBMAP_UPGRADE_ISSUE: (1101) System.Windows.Forms.Control.ModifierKeys was not upgraded
			int Shift = ((int)Stubs._System.Windows.Forms.Control.Shared.ModifierKeys) / 65536;
			
			
			int Index = this.ViewModel.lbPos16pm.IndexOf((UpgradeHelpers.BasicViewModels.LabelViewModel)eventSender);
			//Detect if Right Mouse Button pressed
			//If so Display Popup Window

			if ( !SecurityOK() )
			{
				return ;
			}
			//    If lbPos16pm(Index).Caption = "" Then Exit Sub

			if ( Button == ((int)UpgradeHelpers.Helpers.MouseButtons.Right) )
			{
				ViewModel.SelectedLabel = ViewModel.lbPos16pm[Index];
				if ( ViewModel.lbPos16pm[Index].Text == "" )
				{
					//blank spot
					//            Set SelectedLabel = lbPos16pm(Index)
					//            SelectedSA = Clean(SelectedLabel.Tag)
					//            SelectedSAName = Clean(SelectedLabel.Caption)
					//            SelectedDate = Format$(lbWeekDay(SelectedLabel.Index), "mm/dd/yyyy")
					ViewModel.mnuNewSched.Available = true;
					ViewModel.mnuLeave.Available = false;
					ViewModel.mnuPayUp.Available = false;
					ViewModel.mnuPayDown.Available = false;
					ViewModel.mnuKOT.Available = false;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = false;
					ViewModel.mnuSendTo181.Available = false;
					ViewModel.mnuSendTo182.Available = false;
					ViewModel.mnuReport.Available = false;
					ViewModel.mnuViewDetail.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
				else
				{
					if ( ViewModel.lbPos16pm[Index].ForeColor.Equals(modGlobal.Shared.GREEN) )
					{
						ViewManager.ShowMessage("Trades can only be altered on the Battalion Scheduler", "Weekly Scheduler", UpgradeHelpers.Helpers.BoxButtons.OK);
						return ;
					}
					ViewModel.SelectedLabel = ViewModel.lbPos16pm[Index];
					ViewModel.SelectedSA = modGlobal.Clean(Convert.ToString(UpgradeHelpers.Helpers.ControlHelper.GetTag(ViewModel.SelectedLabel)));
					ViewModel.SelectedSAName = modGlobal.Clean(ViewModel.SelectedLabel.Text);
					ViewModel.SelectedDate = DateTime.Parse(ViewModel.lbWeekDay[UpgradeHelpers.Helpers.ControlArrayHelper.GetControlIndex(ViewModel.SelectedLabel)].Text).ToString("MM/dd/yyyy");
					ViewModel.mnuLeave.Available = true;
					ViewModel.mnuPayUp.Available = true;
					ViewModel.mnuPayDown.Available = true;
					ViewModel.mnuKOT.Available = true;
					ViewModel.mnuTrade.Available = false;
					ViewModel.mnuRemove.Available = true;
					ViewModel.mnuSendTo181.Available = true;
					ViewModel.mnuSendTo182.Available = true;
					ViewModel.mnuReport.Available = true;
					ViewModel.mnuViewDetail.Available = true;
					ViewModel.mnuNewSched.Available = false;
					ViewModel.Ctx_mnuNewEMSPopup.Show(this, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).X, (int)ViewModel.PointToClient(UpgradeHelpers.Helpers.Cursor.Position).Y);

				}
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public struct MoveEmployeeStruct
		{
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
			public string ShiftDate;
			public string Empid;
		}

		public struct ReScheduleEmployeeStruct
		{
			public bool returnValue;
			public string ShiftDate;
			public string Empid;
			public string OldDate;
		}

		public static frmNewEMS DefInstance
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

		public static frmNewEMS CreateInstance()
		{
				PTSProject.frmNewEMS theInstance = Shared.Container.Resolve<frmNewEMS>();
						theInstance.Form_Load();
            return theInstance;
			}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnuNewEMSPopup_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			ViewModel.Ctx_mnuNewEMSPopup.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.mnuNewEMSPopup.Get_DropDownItems())
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.Ctx_mnuNewEMSPopup.Items.Add(item);
			}
			e.Cancel = false;
		}

		[UpgradeHelpers.Events.Handler]
		internal void Ctx_mnuNewEMSPopup_Closing(object sender, Stubs._System.Windows.Forms.ToolStripDropDownClosingEventArgs e)
		{
			System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel> list = new System.Collections.Generic.List<UpgradeHelpers.BasicViewModels.ToolStripItemViewModel>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in ViewModel.Ctx_mnuNewEMSPopup.Items )
			{
				list.Add(item);
			}
			foreach ( UpgradeHelpers.BasicViewModels.ToolStripItemViewModel item in list )
			{
				ViewModel.mnuNewEMSPopup.Get_DropDownItems().Add(item);
			}
		}

		void ReLoadForm(bool addEvents)
		{
            ViewManager.NavigateToView(
                PTSProject.MDIForm1.DefInstance);
			}

		protected override void ExecuteControlsStartup()
		{
            ViewModel.shpP1am[0].LifeCycleStartup();
            ViewModel.shpP1am[1].LifeCycleStartup();
            ViewModel.shpP1am[2].LifeCycleStartup();
            ViewModel.shpP1am[3].LifeCycleStartup();
            ViewModel.shpP1am[4].LifeCycleStartup();
            ViewModel.shpP1am[5].LifeCycleStartup();
            ViewModel.shpP1am[6].LifeCycleStartup();
            ViewModel.shpP1pm[0].LifeCycleStartup();
            ViewModel.shpP1pm[1].LifeCycleStartup();
            ViewModel.shpP1pm[2].LifeCycleStartup();
            ViewModel.shpP1pm[3].LifeCycleStartup();
            ViewModel.shpP1pm[4].LifeCycleStartup();
            ViewModel.shpP1pm[5].LifeCycleStartup();
            ViewModel.shpP1pm[6].LifeCycleStartup();
            ViewModel.shpP2am[0].LifeCycleStartup();
            ViewModel.shpP2am[1].LifeCycleStartup();
            ViewModel.shpP2am[2].LifeCycleStartup();
            ViewModel.shpP2am[3].LifeCycleStartup();
            ViewModel.shpP2am[4].LifeCycleStartup();
            ViewModel.shpP2am[5].LifeCycleStartup();
            ViewModel.shpP2am[6].LifeCycleStartup();
            ViewModel.shpP2pm[0].LifeCycleStartup();
            ViewModel.shpP2pm[1].LifeCycleStartup();
            ViewModel.shpP2pm[2].LifeCycleStartup();
            ViewModel.shpP2pm[3].LifeCycleStartup();
            ViewModel.shpP2pm[4].LifeCycleStartup();
            ViewModel.shpP2pm[5].LifeCycleStartup();
            ViewModel.shpP2pm[6].LifeCycleStartup();
            ViewModel.shpP3am[0].LifeCycleStartup();
            ViewModel.shpP3am[1].LifeCycleStartup();
            ViewModel.shpP3am[2].LifeCycleStartup();
            ViewModel.shpP3am[3].LifeCycleStartup();
            ViewModel.shpP3am[4].LifeCycleStartup();
            ViewModel.shpP3am[5].LifeCycleStartup();
            ViewModel.shpP3am[6].LifeCycleStartup();
            ViewModel.shpP3pm[0].LifeCycleStartup();
            ViewModel.shpP3pm[1].LifeCycleStartup();
            ViewModel.shpP3pm[2].LifeCycleStartup();
            ViewModel.shpP3pm[3].LifeCycleStartup();
            ViewModel.shpP3pm[4].LifeCycleStartup();
            ViewModel.shpP3pm[5].LifeCycleStartup();
            ViewModel.shpP3pm[6].LifeCycleStartup();
            ViewModel.shpP4am[0].LifeCycleStartup();
            ViewModel.shpP4am[1].LifeCycleStartup();
            ViewModel.shpP4am[2].LifeCycleStartup();
            ViewModel.shpP4am[3].LifeCycleStartup();
            ViewModel.shpP4am[4].LifeCycleStartup();
            ViewModel.shpP4am[5].LifeCycleStartup();
            ViewModel.shpP4am[6].LifeCycleStartup();
            ViewModel.shpP4pm[0].LifeCycleStartup();
            ViewModel.shpP4pm[1].LifeCycleStartup();
            ViewModel.shpP4pm[2].LifeCycleStartup();
            ViewModel.shpP4pm[3].LifeCycleStartup();
            ViewModel.shpP4pm[4].LifeCycleStartup();
            ViewModel.shpP4pm[5].LifeCycleStartup();
            ViewModel.shpP4pm[6].LifeCycleStartup();
            ViewModel.shpP5am[0].LifeCycleStartup();
            ViewModel.shpP5am[1].LifeCycleStartup();
            ViewModel.shpP5am[2].LifeCycleStartup();
            ViewModel.shpP5am[3].LifeCycleStartup();
            ViewModel.shpP5am[4].LifeCycleStartup();
            ViewModel.shpP5am[5].LifeCycleStartup();
            ViewModel.shpP5am[6].LifeCycleStartup();
            ViewModel.shpP6am[0].LifeCycleStartup();
            ViewModel.shpP6am[1].LifeCycleStartup();
            ViewModel.shpP6am[2].LifeCycleStartup();
            ViewModel.shpP6am[3].LifeCycleStartup();
            ViewModel.shpP6am[4].LifeCycleStartup();
            ViewModel.shpP6am[5].LifeCycleStartup();
            ViewModel.shpP6am[6].LifeCycleStartup();
            ViewModel.shpP5pm[0].LifeCycleStartup();
            ViewModel.shpP5pm[1].LifeCycleStartup();
            ViewModel.shpP5pm[2].LifeCycleStartup();
            ViewModel.shpP5pm[3].LifeCycleStartup();
            ViewModel.shpP5pm[4].LifeCycleStartup();
            ViewModel.shpP5pm[5].LifeCycleStartup();
            ViewModel.shpP5pm[6].LifeCycleStartup();
            ViewModel.shpP6pm[0].LifeCycleStartup();
            ViewModel.shpP6pm[1].LifeCycleStartup();
            ViewModel.shpP6pm[2].LifeCycleStartup();
            ViewModel.shpP6pm[3].LifeCycleStartup();
            ViewModel.shpP6pm[4].LifeCycleStartup();
            ViewModel.shpP6pm[5].LifeCycleStartup();
            ViewModel.shpP6pm[6].LifeCycleStartup();
            ViewModel.shpP7am[0].LifeCycleStartup();
            ViewModel.shpP7am[1].LifeCycleStartup();
            ViewModel.shpP7am[2].LifeCycleStartup();
            ViewModel.shpP7am[3].LifeCycleStartup();
            ViewModel.shpP7am[4].LifeCycleStartup();
            ViewModel.shpP7am[5].LifeCycleStartup();
            ViewModel.shpP7am[6].LifeCycleStartup();
            ViewModel.shpP7pm[0].LifeCycleStartup();
            ViewModel.shpP7pm[1].LifeCycleStartup();
            ViewModel.shpP7pm[2].LifeCycleStartup();
            ViewModel.shpP7pm[3].LifeCycleStartup();
            ViewModel.shpP7pm[4].LifeCycleStartup();
            ViewModel.shpP7pm[5].LifeCycleStartup();
            ViewModel.shpP7pm[6].LifeCycleStartup();
            ViewModel.shpP8am[0].LifeCycleStartup();
            ViewModel.shpP8am[1].LifeCycleStartup();
            ViewModel.shpP8am[2].LifeCycleStartup();
            ViewModel.shpP8am[3].LifeCycleStartup();
            ViewModel.shpP8am[4].LifeCycleStartup();
            ViewModel.shpP8am[5].LifeCycleStartup();
            ViewModel.shpP8am[6].LifeCycleStartup();
            ViewModel.shpP8pm[0].LifeCycleStartup();
            ViewModel.shpP8pm[1].LifeCycleStartup();
            ViewModel.shpP8pm[2].LifeCycleStartup();
            ViewModel.shpP8pm[3].LifeCycleStartup();
            ViewModel.shpP8pm[4].LifeCycleStartup();
            ViewModel.shpP8pm[5].LifeCycleStartup();
            ViewModel.shpP8pm[6].LifeCycleStartup();
            ViewModel.shpP9am[0].LifeCycleStartup();
            ViewModel.shpP9am[1].LifeCycleStartup();
            ViewModel.shpP9am[2].LifeCycleStartup();
            ViewModel.shpP9am[3].LifeCycleStartup();
            ViewModel.shpP9am[4].LifeCycleStartup();
            ViewModel.shpP9am[5].LifeCycleStartup();
            ViewModel.shpP9am[6].LifeCycleStartup();
            ViewModel.shpP9pm[0].LifeCycleStartup();
            ViewModel.shpP9pm[1].LifeCycleStartup();
            ViewModel.shpP9pm[2].LifeCycleStartup();
            ViewModel.shpP9pm[3].LifeCycleStartup();
            ViewModel.shpP9pm[4].LifeCycleStartup();
            ViewModel.shpP9pm[5].LifeCycleStartup();
            ViewModel.shpP9pm[6].LifeCycleStartup();
            ViewModel.shpP10am[0].LifeCycleStartup();
            ViewModel.shpP10am[1].LifeCycleStartup();
            ViewModel.shpP10am[2].LifeCycleStartup();
            ViewModel.shpP10am[3].LifeCycleStartup();
            ViewModel.shpP10am[4].LifeCycleStartup();
            ViewModel.shpP10am[5].LifeCycleStartup();
            ViewModel.shpP10am[6].LifeCycleStartup();
            ViewModel.shpP10pm[0].LifeCycleStartup();
            ViewModel.shpP10pm[1].LifeCycleStartup();
            ViewModel.shpP10pm[2].LifeCycleStartup();
            ViewModel.shpP10pm[3].LifeCycleStartup();
            ViewModel.shpP10pm[4].LifeCycleStartup();
            ViewModel.shpP10pm[5].LifeCycleStartup();
            ViewModel.shpP10pm[6].LifeCycleStartup();
            ViewModel.shpP11am[0].LifeCycleStartup();
            ViewModel.shpP11am[1].LifeCycleStartup();
            ViewModel.shpP11am[2].LifeCycleStartup();
            ViewModel.shpP11am[3].LifeCycleStartup();
            ViewModel.shpP11am[4].LifeCycleStartup();
            ViewModel.shpP11am[5].LifeCycleStartup();
            ViewModel.shpP11am[6].LifeCycleStartup();
            ViewModel.shpP11pm[0].LifeCycleStartup();
            ViewModel.shpP11pm[1].LifeCycleStartup();
            ViewModel.shpP11pm[2].LifeCycleStartup();
            ViewModel.shpP11pm[3].LifeCycleStartup();
            ViewModel.shpP11pm[4].LifeCycleStartup();
            ViewModel.shpP11pm[5].LifeCycleStartup();
            ViewModel.shpP11pm[6].LifeCycleStartup();
            ViewModel.shpP12am[0].LifeCycleStartup();
            ViewModel.shpP12pm[0].LifeCycleStartup();
            ViewModel.shpP12am[1].LifeCycleStartup();
            ViewModel.shpP12am[2].LifeCycleStartup();
            ViewModel.shpP12am[3].LifeCycleStartup();
            ViewModel.shpP12am[4].LifeCycleStartup();
            ViewModel.shpP12am[5].LifeCycleStartup();
            ViewModel.shpP12am[6].LifeCycleStartup();
            ViewModel.shpP12pm[1].LifeCycleStartup();
            ViewModel.shpP12pm[2].LifeCycleStartup();
            ViewModel.shpP12pm[3].LifeCycleStartup();
            ViewModel.shpP12pm[4].LifeCycleStartup();
            ViewModel.shpP12pm[5].LifeCycleStartup();
            ViewModel.shpP12pm[6].LifeCycleStartup();
            ViewModel.shpP13pm[6].LifeCycleStartup();
            ViewModel.shpP13pm[5].LifeCycleStartup();
            ViewModel.shpP13pm[4].LifeCycleStartup();
            ViewModel.shpP13pm[3].LifeCycleStartup();
            ViewModel.shpP13pm[2].LifeCycleStartup();
            ViewModel.shpP13pm[1].LifeCycleStartup();
            ViewModel.shpP13am[6].LifeCycleStartup();
            ViewModel.shpP13am[5].LifeCycleStartup();
            ViewModel.shpP13am[4].LifeCycleStartup();
            ViewModel.shpP13am[3].LifeCycleStartup();
            ViewModel.shpP13am[2].LifeCycleStartup();
            ViewModel.shpP13am[1].LifeCycleStartup();
            ViewModel.shpP13pm[0].LifeCycleStartup();
            ViewModel.shpP13am[0].LifeCycleStartup();
            ViewModel.shpP14pm[6].LifeCycleStartup();
            ViewModel.shpP14pm[5].LifeCycleStartup();
            ViewModel.shpP14pm[4].LifeCycleStartup();
            ViewModel.shpP14pm[3].LifeCycleStartup();
            ViewModel.shpP14pm[2].LifeCycleStartup();
            ViewModel.shpP14pm[1].LifeCycleStartup();
            ViewModel.shpP14am[6].LifeCycleStartup();
            ViewModel.shpP14am[5].LifeCycleStartup();
            ViewModel.shpP14am[4].LifeCycleStartup();
            ViewModel.shpP14am[3].LifeCycleStartup();
            ViewModel.shpP14am[2].LifeCycleStartup();
            ViewModel.shpP14am[1].LifeCycleStartup();
            ViewModel.shpP14pm[0].LifeCycleStartup();
            ViewModel.shpP14am[0].LifeCycleStartup();
            ViewModel.shpP16am[0].LifeCycleStartup();
            ViewModel.shpP16pm[0].LifeCycleStartup();
            ViewModel.shpP16am[1].LifeCycleStartup();
            ViewModel.shpP16am[2].LifeCycleStartup();
            ViewModel.shpP16am[3].LifeCycleStartup();
            ViewModel.shpP16am[4].LifeCycleStartup();
            ViewModel.shpP16am[5].LifeCycleStartup();
            ViewModel.shpP16am[6].LifeCycleStartup();
            ViewModel.shpP16pm[1].LifeCycleStartup();
            ViewModel.shpP16pm[2].LifeCycleStartup();
            ViewModel.shpP16pm[3].LifeCycleStartup();
            ViewModel.shpP16pm[4].LifeCycleStartup();
            ViewModel.shpP16pm[5].LifeCycleStartup();
            ViewModel.shpP16pm[6].LifeCycleStartup();
            ViewModel.shpP15am[0].LifeCycleStartup();
            ViewModel.shpP15pm[0].LifeCycleStartup();
            ViewModel.shpP15am[1].LifeCycleStartup();
            ViewModel.shpP15am[2].LifeCycleStartup();
            ViewModel.shpP15am[3].LifeCycleStartup();
            ViewModel.shpP15am[4].LifeCycleStartup();
            ViewModel.shpP15am[5].LifeCycleStartup();
            ViewModel.shpP15am[6].LifeCycleStartup();
            ViewModel.shpP15pm[1].LifeCycleStartup();
            ViewModel.shpP15pm[2].LifeCycleStartup();
            ViewModel.shpP15pm[3].LifeCycleStartup();
            ViewModel.shpP15pm[4].LifeCycleStartup();
            ViewModel.shpP15pm[5].LifeCycleStartup();
            ViewModel.shpP15pm[6].LifeCycleStartup();
			ViewModel.mnuNewEMSPopup.LifeCycleStartup();
			ViewModel.mnuHelp.LifeCycleStartup();
			ViewModel.mnuWindow.LifeCycleStartup();
			ViewModel.mnuTraining.LifeCycleStartup();
			ViewModel.mnu_Queries.LifeCycleStartup();
			ViewModel.mnuTrnReports.LifeCycleStartup();
			ViewModel.mnuReports.LifeCycleStartup();
			ViewModel.mnu_TrainingReports.LifeCycleStartup();
			ViewModel.mnuPayrollReports.LifeCycleStartup();
			ViewModel.mnuLeaveReports.LifeCycleStartup();
			ViewModel.mnuSchedul.LifeCycleStartup();
			ViewModel.mnuPayroll.LifeCycleStartup();
			ViewModel.mnuBDWork.LifeCycleStartup();
			ViewModel.mnuperson.LifeCycleStartup();
			ViewModel.mnuSchedule.LifeCycleStartup();
			ViewModel.mnu_old.LifeCycleStartup();
			ViewModel.mnupersonnel.LifeCycleStartup();
			ViewModel.mnuSystem.LifeCycleStartup();
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void ExecuteControlsShutdown()
		{
            ViewModel.shpP1am[0].LifeCycleShutdown();
            ViewModel.shpP1am[1].LifeCycleShutdown();
            ViewModel.shpP1am[2].LifeCycleShutdown();
            ViewModel.shpP1am[3].LifeCycleShutdown();
            ViewModel.shpP1am[4].LifeCycleShutdown();
            ViewModel.shpP1am[5].LifeCycleShutdown();
            ViewModel.shpP1am[6].LifeCycleShutdown();
            ViewModel.shpP1pm[0].LifeCycleShutdown();
            ViewModel.shpP1pm[1].LifeCycleShutdown();
            ViewModel.shpP1pm[2].LifeCycleShutdown();
            ViewModel.shpP1pm[3].LifeCycleShutdown();
            ViewModel.shpP1pm[4].LifeCycleShutdown();
            ViewModel.shpP1pm[5].LifeCycleShutdown();
            ViewModel.shpP1pm[6].LifeCycleShutdown();
            ViewModel.shpP2am[0].LifeCycleShutdown();
            ViewModel.shpP2am[1].LifeCycleShutdown();
            ViewModel.shpP2am[2].LifeCycleShutdown();
            ViewModel.shpP2am[3].LifeCycleShutdown();
            ViewModel.shpP2am[4].LifeCycleShutdown();
            ViewModel.shpP2am[5].LifeCycleShutdown();
            ViewModel.shpP2am[6].LifeCycleShutdown();
            ViewModel.shpP2pm[0].LifeCycleShutdown();
            ViewModel.shpP2pm[1].LifeCycleShutdown();
            ViewModel.shpP2pm[2].LifeCycleShutdown();
            ViewModel.shpP2pm[3].LifeCycleShutdown();
            ViewModel.shpP2pm[4].LifeCycleShutdown();
            ViewModel.shpP2pm[5].LifeCycleShutdown();
            ViewModel.shpP2pm[6].LifeCycleShutdown();
            ViewModel.shpP3am[0].LifeCycleShutdown();
            ViewModel.shpP3am[1].LifeCycleShutdown();
            ViewModel.shpP3am[2].LifeCycleShutdown();
            ViewModel.shpP3am[3].LifeCycleShutdown();
            ViewModel.shpP3am[4].LifeCycleShutdown();
            ViewModel.shpP3am[5].LifeCycleShutdown();
            ViewModel.shpP3am[6].LifeCycleShutdown();
            ViewModel.shpP3pm[0].LifeCycleShutdown();
            ViewModel.shpP3pm[1].LifeCycleShutdown();
            ViewModel.shpP3pm[2].LifeCycleShutdown();
            ViewModel.shpP3pm[3].LifeCycleShutdown();
            ViewModel.shpP3pm[4].LifeCycleShutdown();
            ViewModel.shpP3pm[5].LifeCycleShutdown();
            ViewModel.shpP3pm[6].LifeCycleShutdown();
            ViewModel.shpP4am[0].LifeCycleShutdown();
            ViewModel.shpP4am[1].LifeCycleShutdown();
            ViewModel.shpP4am[2].LifeCycleShutdown();
            ViewModel.shpP4am[3].LifeCycleShutdown();
            ViewModel.shpP4am[4].LifeCycleShutdown();
            ViewModel.shpP4am[5].LifeCycleShutdown();
            ViewModel.shpP4am[6].LifeCycleShutdown();
            ViewModel.shpP4pm[0].LifeCycleShutdown();
            ViewModel.shpP4pm[1].LifeCycleShutdown();
            ViewModel.shpP4pm[2].LifeCycleShutdown();
            ViewModel.shpP4pm[3].LifeCycleShutdown();
            ViewModel.shpP4pm[4].LifeCycleShutdown();
            ViewModel.shpP4pm[5].LifeCycleShutdown();
            ViewModel.shpP4pm[6].LifeCycleShutdown();
            ViewModel.shpP5am[0].LifeCycleShutdown();
            ViewModel.shpP5am[1].LifeCycleShutdown();
            ViewModel.shpP5am[2].LifeCycleShutdown();
            ViewModel.shpP5am[3].LifeCycleShutdown();
            ViewModel.shpP5am[4].LifeCycleShutdown();
            ViewModel.shpP5am[5].LifeCycleShutdown();
            ViewModel.shpP5am[6].LifeCycleShutdown();
            ViewModel.shpP6am[0].LifeCycleShutdown();
            ViewModel.shpP6am[1].LifeCycleShutdown();
            ViewModel.shpP6am[2].LifeCycleShutdown();
            ViewModel.shpP6am[3].LifeCycleShutdown();
            ViewModel.shpP6am[4].LifeCycleShutdown();
            ViewModel.shpP6am[5].LifeCycleShutdown();
            ViewModel.shpP6am[6].LifeCycleShutdown();
            ViewModel.shpP5pm[0].LifeCycleShutdown();
            ViewModel.shpP5pm[1].LifeCycleShutdown();
            ViewModel.shpP5pm[2].LifeCycleShutdown();
            ViewModel.shpP5pm[3].LifeCycleShutdown();
            ViewModel.shpP5pm[4].LifeCycleShutdown();
            ViewModel.shpP5pm[5].LifeCycleShutdown();
            ViewModel.shpP5pm[6].LifeCycleShutdown();
            ViewModel.shpP6pm[0].LifeCycleShutdown();
            ViewModel.shpP6pm[1].LifeCycleShutdown();
            ViewModel.shpP6pm[2].LifeCycleShutdown();
            ViewModel.shpP6pm[3].LifeCycleShutdown();
            ViewModel.shpP6pm[4].LifeCycleShutdown();
            ViewModel.shpP6pm[5].LifeCycleShutdown();
            ViewModel.shpP6pm[6].LifeCycleShutdown();
            ViewModel.shpP7am[0].LifeCycleShutdown();
            ViewModel.shpP7am[1].LifeCycleShutdown();
            ViewModel.shpP7am[2].LifeCycleShutdown();
            ViewModel.shpP7am[3].LifeCycleShutdown();
            ViewModel.shpP7am[4].LifeCycleShutdown();
            ViewModel.shpP7am[5].LifeCycleShutdown();
            ViewModel.shpP7am[6].LifeCycleShutdown();
            ViewModel.shpP7pm[0].LifeCycleShutdown();
            ViewModel.shpP7pm[1].LifeCycleShutdown();
            ViewModel.shpP7pm[2].LifeCycleShutdown();
            ViewModel.shpP7pm[3].LifeCycleShutdown();
            ViewModel.shpP7pm[4].LifeCycleShutdown();
            ViewModel.shpP7pm[5].LifeCycleShutdown();
            ViewModel.shpP7pm[6].LifeCycleShutdown();
            ViewModel.shpP8am[0].LifeCycleShutdown();
            ViewModel.shpP8am[1].LifeCycleShutdown();
            ViewModel.shpP8am[2].LifeCycleShutdown();
            ViewModel.shpP8am[3].LifeCycleShutdown();
            ViewModel.shpP8am[4].LifeCycleShutdown();
            ViewModel.shpP8am[5].LifeCycleShutdown();
            ViewModel.shpP8am[6].LifeCycleShutdown();
            ViewModel.shpP8pm[0].LifeCycleShutdown();
            ViewModel.shpP8pm[1].LifeCycleShutdown();
            ViewModel.shpP8pm[2].LifeCycleShutdown();
            ViewModel.shpP8pm[3].LifeCycleShutdown();
            ViewModel.shpP8pm[4].LifeCycleShutdown();
            ViewModel.shpP8pm[5].LifeCycleShutdown();
            ViewModel.shpP8pm[6].LifeCycleShutdown();
            ViewModel.shpP9am[0].LifeCycleShutdown();
            ViewModel.shpP9am[1].LifeCycleShutdown();
            ViewModel.shpP9am[2].LifeCycleShutdown();
            ViewModel.shpP9am[3].LifeCycleShutdown();
            ViewModel.shpP9am[4].LifeCycleShutdown();
            ViewModel.shpP9am[5].LifeCycleShutdown();
            ViewModel.shpP9am[6].LifeCycleShutdown();
            ViewModel.shpP9pm[0].LifeCycleShutdown();
            ViewModel.shpP9pm[1].LifeCycleShutdown();
            ViewModel.shpP9pm[2].LifeCycleShutdown();
            ViewModel.shpP9pm[3].LifeCycleShutdown();
            ViewModel.shpP9pm[4].LifeCycleShutdown();
            ViewModel.shpP9pm[5].LifeCycleShutdown();
            ViewModel.shpP9pm[6].LifeCycleShutdown();
            ViewModel.shpP10am[0].LifeCycleShutdown();
            ViewModel.shpP10am[1].LifeCycleShutdown();
            ViewModel.shpP10am[2].LifeCycleShutdown();
            ViewModel.shpP10am[3].LifeCycleShutdown();
            ViewModel.shpP10am[4].LifeCycleShutdown();
            ViewModel.shpP10am[5].LifeCycleShutdown();
            ViewModel.shpP10am[6].LifeCycleShutdown();
            ViewModel.shpP10pm[0].LifeCycleShutdown();
            ViewModel.shpP10pm[1].LifeCycleShutdown();
            ViewModel.shpP10pm[2].LifeCycleShutdown();
            ViewModel.shpP10pm[3].LifeCycleShutdown();
            ViewModel.shpP10pm[4].LifeCycleShutdown();
            ViewModel.shpP10pm[5].LifeCycleShutdown();
            ViewModel.shpP10pm[6].LifeCycleShutdown();
            ViewModel.shpP11am[0].LifeCycleShutdown();
            ViewModel.shpP11am[1].LifeCycleShutdown();
            ViewModel.shpP11am[2].LifeCycleShutdown();
            ViewModel.shpP11am[3].LifeCycleShutdown();
            ViewModel.shpP11am[4].LifeCycleShutdown();
            ViewModel.shpP11am[5].LifeCycleShutdown();
            ViewModel.shpP11am[6].LifeCycleShutdown();
            ViewModel.shpP11pm[0].LifeCycleShutdown();
            ViewModel.shpP11pm[1].LifeCycleShutdown();
            ViewModel.shpP11pm[2].LifeCycleShutdown();
            ViewModel.shpP11pm[3].LifeCycleShutdown();
            ViewModel.shpP11pm[4].LifeCycleShutdown();
            ViewModel.shpP11pm[5].LifeCycleShutdown();
            ViewModel.shpP11pm[6].LifeCycleShutdown();
            ViewModel.shpP12am[0].LifeCycleShutdown();
            ViewModel.shpP12pm[0].LifeCycleShutdown();
            ViewModel.shpP12am[1].LifeCycleShutdown();
            ViewModel.shpP12am[2].LifeCycleShutdown();
            ViewModel.shpP12am[3].LifeCycleShutdown();
            ViewModel.shpP12am[4].LifeCycleShutdown();
            ViewModel.shpP12am[5].LifeCycleShutdown();
            ViewModel.shpP12am[6].LifeCycleShutdown();
            ViewModel.shpP12pm[1].LifeCycleShutdown();
            ViewModel.shpP12pm[2].LifeCycleShutdown();
            ViewModel.shpP12pm[3].LifeCycleShutdown();
            ViewModel.shpP12pm[4].LifeCycleShutdown();
            ViewModel.shpP12pm[5].LifeCycleShutdown();
            ViewModel.shpP12pm[6].LifeCycleShutdown();
            ViewModel.shpP13pm[6].LifeCycleShutdown();
            ViewModel.shpP13pm[5].LifeCycleShutdown();
            ViewModel.shpP13pm[4].LifeCycleShutdown();
            ViewModel.shpP13pm[3].LifeCycleShutdown();
            ViewModel.shpP13pm[2].LifeCycleShutdown();
            ViewModel.shpP13pm[1].LifeCycleShutdown();
            ViewModel.shpP13am[6].LifeCycleShutdown();
            ViewModel.shpP13am[5].LifeCycleShutdown();
            ViewModel.shpP13am[4].LifeCycleShutdown();
            ViewModel.shpP13am[3].LifeCycleShutdown();
            ViewModel.shpP13am[2].LifeCycleShutdown();
            ViewModel.shpP13am[1].LifeCycleShutdown();
            ViewModel.shpP13pm[0].LifeCycleShutdown();
            ViewModel.shpP13am[0].LifeCycleShutdown();
            ViewModel.shpP14pm[6].LifeCycleShutdown();
            ViewModel.shpP14pm[5].LifeCycleShutdown();
            ViewModel.shpP14pm[4].LifeCycleShutdown();
            ViewModel.shpP14pm[3].LifeCycleShutdown();
            ViewModel.shpP14pm[2].LifeCycleShutdown();
            ViewModel.shpP14pm[1].LifeCycleShutdown();
            ViewModel.shpP14am[6].LifeCycleShutdown();
            ViewModel.shpP14am[5].LifeCycleShutdown();
            ViewModel.shpP14am[4].LifeCycleShutdown();
            ViewModel.shpP14am[3].LifeCycleShutdown();
            ViewModel.shpP14am[2].LifeCycleShutdown();
            ViewModel.shpP14am[1].LifeCycleShutdown();
            ViewModel.shpP14pm[0].LifeCycleShutdown();
            ViewModel.shpP14am[0].LifeCycleShutdown();
            ViewModel.shpP16am[0].LifeCycleShutdown();
            ViewModel.shpP16pm[0].LifeCycleShutdown();
            ViewModel.shpP16am[1].LifeCycleShutdown();
            ViewModel.shpP16am[2].LifeCycleShutdown();
            ViewModel.shpP16am[3].LifeCycleShutdown();
            ViewModel.shpP16am[4].LifeCycleShutdown();
            ViewModel.shpP16am[5].LifeCycleShutdown();
            ViewModel.shpP16am[6].LifeCycleShutdown();
            ViewModel.shpP16pm[1].LifeCycleShutdown();
            ViewModel.shpP16pm[2].LifeCycleShutdown();
            ViewModel.shpP16pm[3].LifeCycleShutdown();
            ViewModel.shpP16pm[4].LifeCycleShutdown();
            ViewModel.shpP16pm[5].LifeCycleShutdown();
            ViewModel.shpP16pm[6].LifeCycleShutdown();
            ViewModel.shpP15am[0].LifeCycleShutdown();
            ViewModel.shpP15pm[0].LifeCycleShutdown();
            ViewModel.shpP15am[1].LifeCycleShutdown();
            ViewModel.shpP15am[2].LifeCycleShutdown();
            ViewModel.shpP15am[3].LifeCycleShutdown();
            ViewModel.shpP15am[4].LifeCycleShutdown();
            ViewModel.shpP15am[5].LifeCycleShutdown();
            ViewModel.shpP15am[6].LifeCycleShutdown();
            ViewModel.shpP15pm[1].LifeCycleShutdown();
            ViewModel.shpP15pm[2].LifeCycleShutdown();
            ViewModel.shpP15pm[3].LifeCycleShutdown();
            ViewModel.shpP15pm[4].LifeCycleShutdown();
            ViewModel.shpP15pm[5].LifeCycleShutdown();
            ViewModel.shpP15pm[6].LifeCycleShutdown();
			ViewModel.mnuNewEMSPopup.LifeCycleShutdown();
			ViewModel.mnuHelp.LifeCycleShutdown();
			ViewModel.mnuWindow.LifeCycleShutdown();
			ViewModel.mnuTraining.LifeCycleShutdown();
			ViewModel.mnu_Queries.LifeCycleShutdown();
			ViewModel.mnuTrnReports.LifeCycleShutdown();
			ViewModel.mnuReports.LifeCycleShutdown();
			ViewModel.mnu_TrainingReports.LifeCycleShutdown();
			ViewModel.mnuPayrollReports.LifeCycleShutdown();
			ViewModel.mnuLeaveReports.LifeCycleShutdown();
			ViewModel.mnuSchedul.LifeCycleShutdown();
			ViewModel.mnuPayroll.LifeCycleShutdown();
			ViewModel.mnuBDWork.LifeCycleShutdown();
			ViewModel.mnuperson.LifeCycleShutdown();
			ViewModel.mnuSchedule.LifeCycleShutdown();
			ViewModel.mnu_old.LifeCycleShutdown();
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

	public partial class frmNewEMS
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.frmNewEMSViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual frmNewEMS m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}