using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmQclass))]
	public class frmQclassViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			FarPoint.ViewModels.NamedStyle namedStyle7;
			FarPoint.ViewModels.NamedStyle namedStyle6;
			FarPoint.ViewModels.NamedStyle namedStyle5;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprQ1 = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprQ1.TabIndex = 1;
			this.sprQ1.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this._optParam_1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this._optParam_0 = ctx.Resolve<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>();
			this.frmParam1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.PanelViewModel>();
			// 
			// frmParam1
			// 
			this.frmParam1.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.frmParam1.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.frmParam1.Name = "frmParam1";
			this.frmParam1.TabIndex = 12;
			this.calStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calStart.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calStart.MinDate = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
			this.calStart.Name = "calStart";
			this.calStart.TabIndex = 11;
			this.cboPersonnel = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboPersonnel
			// 
			this.cboPersonnel.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboPersonnel.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboPersonnel.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboPersonnel.Name = "cboPersonnel";
			this.cboPersonnel.TabIndex = 10;
			this.cboClass = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboClass
			// 
			this.cboClass.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboClass.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 7.5F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboClass.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboClass.Name = "cboClass";
			this.cboClass.TabIndex = 2;
			this.calEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calEnd.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calEnd.MinDate = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
			this.calEnd.Name = "calEnd";
			this.calEnd.TabIndex = 16;
			this.calClassStart = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calClassStart.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calClassStart.MinDate = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
			this.calClassStart.Name = "calClassStart";
			this.calClassStart.TabIndex = 19;
			this.calClassEnd = ctx.Resolve<WNFRMS.Viewmodels.DateTimePickerViewModel>();
			this.calClassEnd.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
			this.calClassEnd.MinDate = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
			this.calClassEnd.Name = "calClassEnd";
			this.calClassEnd.TabIndex = 20;
			this.Label7 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label7
			// 
			this.Label7.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label7.Name = "Label7";
			this.Label7.TabIndex = 18;
			this.Label7.Text = "Select End Date for Next Classes";
			this.Label6 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label6
			// 
			this.Label6.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label6.Name = "Label6";
			this.Label6.TabIndex = 17;
			this.Label6.Text = "Select Start Date for Next Classes";
			this.Label5 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label5
			// 
			this.Label5.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label5.Name = "Label5";
			this.Label5.TabIndex = 15;
			this.Label5.Text = "Select Query Type";
			this.Label4 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label4
			// 
			this.Label4.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label4.Name = "Label4";
			this.Label4.TabIndex = 9;
			this.Label4.Text = "Select Personnel";
			this.Label3 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label3
			// 
			this.Label3.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label3.Name = "Label3";
			this.Label3.TabIndex = 8;
			this.Label3.Text = "Select Query End Date";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 7;
			this.Label2.Text = "Select Query Start Date";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 6;
			this.Label1.Text = "Select Class";
			this.sprQ1_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprQ1_Sheet1.SheetName = "Sheet1";
			this.sprQ1_Sheet1.Cells.Get(0, 0).Value = "Tacoma Fire Department";
			this.sprQ1_Sheet1.Cells.Get(1, 0).Value = "Training - Class Participation Query Results";
			this.sprQ1_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
			this.sprQ1_Sheet1.Columns.Get(0).Width = 151F;
			this.sprQ1_Sheet1.Columns.Get(1).Width = 541F;
			this.sprQ1_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 5;
			this.cmdClear.Text = "C&lear";
			this.cmdQuery = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdQuery
			// 
			this.cmdQuery.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdQuery.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdQuery.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdQuery.Name = "cmdQuery";
			this.cmdQuery.TabIndex = 4;
			this.cmdQuery.Text = "&Query";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 3;
			this.cmdPrint.Text = "&Print";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 0;
			this.cmdClose.Text = "&Close";
			this.Text = "Old Class Participation Query (Historical Data)";
			this.TotalRows = 0;
			optParam = ctx.Resolve<System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel>>(2);
			optParam[1] = _optParam_1;
			optParam[0] = _optParam_0;
			optParam[1].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optParam[1].Checked = true;
			optParam[1].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optParam[1].ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			optParam[1].Name = "_optParam_1";
			optParam[1].TabIndex = 14;
			optParam[1].Text = "All Personnel who have NOT Attended";
			optParam[0].BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			optParam[0].Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			optParam[0].ForeColor = UpgradeHelpers.Helpers.Color.Green;
			optParam[0].Name = "_optParam_0";
			optParam[0].TabIndex = 13;
			optParam[0].Text = "All Personnel who have Attended";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color65636234759888969531", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text450636234759888979296", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font909636234759888998826");
			namedStyle3.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static927636234759889008591");
			namedStyle4.CellType = textCellType2;
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType2;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1095636234759889057416");
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Italic);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1149636234759889106241");
			namedStyle6.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F);
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Font1181636234759889135536");
			namedStyle7.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmQclass";
			IsMdiChild = true;
			cboPersonnel.Items.Add("All TFD Personnel");
			cboPersonnel.Items.Add("Operations Staff");
			cboPersonnel.Items.Add("Civilian Staff");
			cboPersonnel.Items.Add("Firefighers");
			cboPersonnel.Items.Add("Paramedics");
			cboPersonnel.Items.Add("Dispatchers");
			cboPersonnel.Items.Add("Prevention");
			cboPersonnel.Items.Add("Officers");
			cboPersonnel.Items.Add("Command Staff");
			this.sprQ1.NamedStyles.Add(namedStyle1);
			this.sprQ1.NamedStyles.Add(namedStyle2);
			this.sprQ1.NamedStyles.Add(namedStyle3);
			this.sprQ1.NamedStyles.Add(namedStyle4);
			this.sprQ1.NamedStyles.Add(namedStyle5);
			this.sprQ1.NamedStyles.Add(namedStyle6);
			this.sprQ1.NamedStyles.Add(namedStyle7);
			this.sprQ1.Sheets.Add(this.sprQ1_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprQ1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optParam_1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.RadioButtonViewModel _optParam_0 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.PanelViewModel frmParam1 { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calStart { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboPersonnel { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboClass { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calEnd { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calClassStart { get; set; }

		public virtual WNFRMS.Viewmodels.DateTimePickerViewModel calClassEnd { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label7 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label6 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label5 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label4 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label3 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprQ1_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdQuery { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalRows { get; set; }

		public virtual System.Collections.Generic.IList<UpgradeHelpers.BasicViewModels.RadioButtonViewModel> optParam { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}