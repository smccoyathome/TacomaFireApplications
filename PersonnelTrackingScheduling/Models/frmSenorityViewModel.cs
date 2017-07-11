using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.frmSenority))]
	public class frmSenorityViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var customCell1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.DataGridViewCellViewModel>();
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprSeniority = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprSeniority.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.None;
            this.sprSeniority.Get_HorizontalScrollBar().Name = "";
			this.sprSeniority.Get_HorizontalScrollBar().TabIndex = 1;
			this.sprSeniority.TabIndex = 6;
			this.sprSeniority.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
            this.sprSeniority.Get_VerticalScrollBar().Name = "";
			this.sprSeniority.Get_VerticalScrollBar().TabIndex = 2;
			this.sprSeniority.Visible = false;
			this.sprGrid = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprGrid.MaxRows = 50;
			this.sprGrid.TabIndex = 8;
			this.sprGrid.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprGrid.Visible = false;
			this.grdSenority = ctx.Resolve<UpgradeHelpers.BasicViewModels.DataGridViewFlexViewModel>();
			this.grdSenority.ColumnsCount = 1;
			this.grdSenority.FixedRows = 0;
			this.grdSenority.Name = "grdSenority";
			this.grdSenority.RowsCount = 1;
			this.grdSenority.TabIndex = 5;
			this.grdSenority.Visible = false;
			this.cboName = ctx.Resolve<UpgradeHelpers.BasicViewModels.ComboBoxViewModel>();
			// 
			// cboName
			// 
			this.cboName.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.cboName.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 11.25F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cboName.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.cboName.Name = "cboName";
			this.cboName.TabIndex = 0;
			this.cboName.Text = "cboName";
			this.Label2 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label2
			// 
			this.Label2.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label2.Name = "Label2";
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Seniority Ranking ";
			this.Label1 = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// Label1
			// 
			this.Label1.BackColor = UpgradeHelpers.Helpers.Color.Transparent;
			this.Label1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 10.5F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Label1.Name = "Label1";
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Select Employee";
			this.sprGrid_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprGrid_Sheet1.SheetName = "Sheet1";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee";
			this.sprGrid_Sheet1.ColumnHeader.Cells[0, 1].Value = "Adjusted Date";
			this.sprGrid_Sheet1.Columns.Get(0).Label = "Employee";
			this.sprGrid_Sheet1.Columns.Get(0).Width = 221F;
			this.sprGrid_Sheet1.Columns.Get(1).Label = "Adjusted Date";
			this.sprGrid_Sheet1.Columns.Get(1).Width = 127F;
			this.sprGrid_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprGrid_Sheet1.Rows.Get(0).Height = 17F;
			this.sprSeniority_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprSeniority_Sheet1.SheetName = "Sheet1";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 7;
			this.cmdPrint.Text = "&Print List";
			this.cmdClose = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClose.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClose.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.TabIndex = 2;
			this.cmdClose.Text = "&Close";
			this.cmdClear = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdClear.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdClear.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.TabIndex = 1;
			this.cmdClear.Text = "C&lear";
			this.Text = "TFD Seniority Ranking ";
			this.SelectedName = UpgradeHelpers.Helpers.ArraysHelper.InitializeArray<string>(501);
			this.TotalNames = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234766006663911", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text273636234766006673676", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			this.Name = "PTSProject.frmSenority";
			IsMdiChild = true;
			this.sprSeniority.Sheets.Add(this.sprSeniority_Sheet1);
			this.sprGrid.NamedStyles.Add(namedStyle1);
			this.sprGrid.NamedStyles.Add(namedStyle2);
			this.sprGrid.Sheets.Add(this.sprGrid_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprSeniority { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprGrid { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.DataGridViewFlexViewModel grdSenority { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ComboBoxViewModel cboName { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label2 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel Label1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprGrid_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprSeniority_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClose { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdClear { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String[] SelectedName { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 TotalNames { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

		public virtual bool IsMdiChild { get; set; }

	}

}