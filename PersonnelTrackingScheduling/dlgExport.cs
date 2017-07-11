using System;
using System.IO;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace PTSProject
{

	public partial class dlgExport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgExportViewModel>, UpgradeHelpers.Interfaces.IInitializable
	{

		void UpgradeHelpers.Interfaces.IInitializable.Init()
		{
			this.CallBaseInit(typeof(dlgExport));
			if ( Shared.m_vb6FormDefInstance == null)
			{
				if ( Shared.m_InitializingDefInstance)
				{
					Shared.
						m_vb6FormDefInstance = this;
				}
			}
		}


		private void dlgExport_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if ( UpgradeHelpers.Helpers.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Helpers.ActivateHelper.myActiveForm = (UpgradeHelpers.Interfaces.ILogicView<UpgradeHelpers.Interfaces.IViewModel>) eventSender;
			}
		}

		[UpgradeHelpers.Events.Handler]
		internal void CancelButton_Renamed_Click(Object eventSender, System.EventArgs eventArgs)
		{
			modGlobal.Shared.gExcelPath = "";
			ViewManager.DisposeView(this);
		}

		private void Dir1_Change(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.File1.Path = ViewModel.Dir1.Path;
		}

		private void Drive1_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.Dir1.Path = ViewModel.Drive1.Drive;
		}

		private void File1_SelectedIndexChanged(Object eventSender, System.EventArgs eventArgs)
		{
			ViewModel.txtFileName.Text = ViewModel.File1.FileName;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx

		private void Form_Load()
		{
			//Configure Dir/Directory/File Controls
			ViewModel.Drive1.Drive = "h:";
			ViewModel.Dir1.Path = "h:\\";
		}

		[UpgradeHelpers.Events.Handler]
		internal void OKButton_Click(Object eventSender, System.EventArgs eventArgs)
		{
			using ( var async1 = this.Async(true) )
			{
				//Store filename & path in global variable gExcelPath
				UpgradeHelpers.Helpers.DialogResult Response = (UpgradeHelpers.Helpers.DialogResult) 0;

				string FilePath = modGlobal.Clean(ViewModel.txtFileName.Text);
				if (FilePath == "" || FilePath == "*.xls")
				{
					ViewManager.ShowMessage("Please indicate FileName", "Error Message", UpgradeHelpers.Helpers.BoxButtons.OK, UpgradeHelpers.Helpers.BoxIcons.Error);
					ViewManager.SetCurrent(ViewModel.txtFileName);
					this.Return();
					return ;
				}

				//Load File Path
				if ( ViewModel.Dir1.Path.Substring(Math.Max(ViewModel.Dir1.Path.Length - 1, 0)) == "\\")
				{
					FilePath = ViewModel.Dir1.Path + FilePath;
				}
				else
				{
					FilePath = ViewModel.Dir1.Path + "\\" + FilePath;
				}

				//Check for existing file with selected name
				Object FSO = new System.Object();
				if (File.Exists(FilePath))
				{
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(() => ViewManager.ShowMessage("File exists - Overwrite?", "TFD Stats - Excel Export", UpgradeHelpers.Helpers.BoxButtons.YesNo));
					async1.Append<UpgradeHelpers.Helpers.DialogResult, UpgradeHelpers.Helpers.DialogResult>(tempNormalized0 => tempNormalized0);
					async1.Append<UpgradeHelpers.Helpers.DialogResult>(tempNormalized1 =>
						{
							Response = tempNormalized1;
						});
					async1.Append(() =>
						{
							if (Response == UpgradeHelpers.Helpers.DialogResult.No)
							{
								this.Return();
								return ;
							}
							else
							{
								File.Delete(FilePath);
								FSO = null;
							}
						});
						}
				async1.Append(() =>
					{
						modGlobal.Shared.gExcelPath = FilePath;
						ViewManager.DisposeView(this);
					});
			}

		}

		internal void Closed(UpgradeHelpers.Events.CloseReason closeReasonParam)
		{
		}

		public static dlgExport DefInstance
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

		public static dlgExport CreateInstance()
		{
			PTSProject.dlgExport theInstance = Shared.Container.Resolve< dlgExport>();
			theInstance.Form_Load();
			return theInstance;
		}

		protected override void ExecuteControlsStartup()
		{
			base.ExecuteControlsStartup();
			this.DynamicControlsStartup();
		}

		protected override void OnClosed(System.EventArgs eventArgs)
		{
			base.OnClosed(eventArgs);
			Closed(UpgradeHelpers.Events.CloseReason.UserClosing);
		}

	}

	public partial class dlgExport
		: UpgradeHelpers.Helpers.FormBase<PTSProject.ViewModels.dlgExportViewModel>, UpgradeHelpers.Interfaces.IInitializable
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

			public virtual dlgExport m_vb6FormDefInstance { get; set; }

			public virtual bool m_InitializingDefInstance { get; set; }

			void UpgradeHelpers.Interfaces.IInitializable.Init()
			{
				this.CallBaseInit(typeof(SharedState));
			}

		}

	}
}