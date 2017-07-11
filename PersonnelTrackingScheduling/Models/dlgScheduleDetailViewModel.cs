using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgScheduleDetail))]
	public class dlgScheduleDetailViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 3;
			this.txtComment.Text = "txtComment";
			this.sprDetail = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprDetail.TabIndex = 1;
			this.sprDetail.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
			this.lbTitle = ctx.Resolve<UpgradeHelpers.BasicViewModels.LabelViewModel>();
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lbTitle.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = UpgradeHelpers.Helpers.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "Schedule Detail";
			this.sprDetail_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprDetail_Sheet1.SheetName = "Sheet1";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 0].Value = "Created/Updated By";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date Created";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 2].Value = "Shift";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 3].Value = "KOT";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 4].Value = "Job Code";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 5].Value = "Step";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 6].Value = "Unit";
			this.sprDetail_Sheet1.ColumnHeader.Cells[0, 7].Value = "Position";
			this.sprDetail_Sheet1.Columns.Get(0).Label = "Created/Updated By";
			this.sprDetail_Sheet1.Columns.Get(0).Width = 126F;
			this.sprDetail_Sheet1.Columns.Get(1).Label = "Date Created";
			this.sprDetail_Sheet1.Columns.Get(1).Width = 119F;
			this.sprDetail_Sheet1.Columns.Get(2).Label = "Shift";
			this.sprDetail_Sheet1.Columns.Get(2).StyleName = "Static773636234659384844771";
			this.sprDetail_Sheet1.Columns.Get(2).Width = 38F;
			this.sprDetail_Sheet1.Columns.Get(3).Label = "KOT";
			this.sprDetail_Sheet1.Columns.Get(3).StyleName = "Static773636234659384844771";
			this.sprDetail_Sheet1.Columns.Get(3).Width = 34F;
			this.sprDetail_Sheet1.Columns.Get(4).Label = "Job Code";
			this.sprDetail_Sheet1.Columns.Get(4).StyleName = "Static773636234659384844771";
			this.sprDetail_Sheet1.Columns.Get(5).Label = "Step";
			this.sprDetail_Sheet1.Columns.Get(5).StyleName = "Static773636234659384844771";
			this.sprDetail_Sheet1.Columns.Get(5).Width = 38F;
			this.sprDetail_Sheet1.Columns.Get(6).Label = "Unit";
			this.sprDetail_Sheet1.Columns.Get(6).StyleName = "Static773636234659384844771";
			this.sprDetail_Sheet1.Columns.Get(6).Width = 40F;
			this.sprDetail_Sheet1.Columns.Get(7).Label = "Position";
			this.sprDetail_Sheet1.Columns.Get(7).Width = 54F;
			this.sprDetail_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F, UpgradeHelpers.Helpers.FontStyle.Bold, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "Close";
			this.Text = "Schedule Detail";
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234659384825241", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text340636234659384825241", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Microsoft Sans Serif", 7F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static773636234659384844771");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1313636234659384883831");
			namedStyle4.CellType = textCellType3;
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Renderer = textCellType3;
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.dlgScheduleDetail";
			this.sprDetail.NamedStyles.Add(namedStyle1);
			this.sprDetail.NamedStyles.Add(namedStyle2);
			this.sprDetail.NamedStyles.Add(namedStyle3);
			this.sprDetail.NamedStyles.Add(namedStyle4);
			this.sprDetail.Sheets.Add(this.sprDetail_Sheet1);
		}

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprDetail { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.LabelViewModel lbTitle { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprDetail_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}