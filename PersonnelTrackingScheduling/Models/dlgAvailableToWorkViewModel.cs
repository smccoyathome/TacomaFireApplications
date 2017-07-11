using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;
using UpgradeHelpers.Events;

namespace PTSProject.ViewModels
{

	[UpgradeHelpers.Helpers.Logic(Type = typeof(PTSProject.dlgAvailableToWork))]
	public class dlgAvailableToWorkViewModel
		: UpgradeHelpers.Helpers.FormBaseViewModel
	{

		public override void Build(UpgradeHelpers.Interfaces.IIocContainer ctx)
		{
			base.Build(ctx);
			var textCellType5 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle7;
			var textCellType4 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle6;
			var textCellType3 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle5;
			FarPoint.ViewModels.NamedStyle namedStyle4;
			var textCellType2 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle3;
			var textCellType1 = ctx.Resolve<FarPoint.ViewModels.TextCellType>();
			FarPoint.ViewModels.NamedStyle namedStyle2;
			FarPoint.ViewModels.NamedStyle namedStyle1;
			this.sprReport = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprReport.BorderStyle = UpgradeHelpers.Helpers.BorderStyle.None;
			this.sprReport.Get_HorizontalScrollBar().Name = "";
			this.sprReport.Get_HorizontalScrollBar().TabIndex = 1;
			this.sprReport.TabIndex = 5;
			this.sprReport.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.sprReport.Get_VerticalScrollBar().Name = "";
			this.sprReport.Get_VerticalScrollBar().TabIndex = 2;
			this.sprReport.Visible = false;
			this.sprPhoneList = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprPhoneList.MaxRows = 10;
			this.sprPhoneList.TabIndex = 3;
			this.sprPhoneList.TextTip = FarPoint.ViewModels.TextTipPolicy.Off;
			this.txtComment = ctx.Resolve<UpgradeHelpers.BasicViewModels.TextBoxViewModel>();
			this.txtComment.BackColor = UpgradeHelpers.Helpers.SystemColors.Window;
			this.txtComment.Enabled = false;
			this.txtComment.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9.75F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.txtComment.ForeColor = UpgradeHelpers.Helpers.SystemColors.WindowText;
			this.txtComment.Name = "txtComment";
			this.txtComment.TabIndex = 0;
			this.txtComment.Text = "txtComment";
			this.sprAvailable = ctx.Resolve<FarPoint.ViewModels.FpSpreadViewModel>();
			this.sprAvailable.TabIndex = 1;
			this.sprAvailable.TextTip = FarPoint.ViewModels.TextTipPolicy.Floating;
			this.sprAvailable_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprAvailable_Sheet1.SheetName = "Sheet1";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 0].Value = "Employee Name";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 1].Value = "Date/Shift Available";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 2].Value = "Record Created On";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 3].Value = "Last Date/Shift Scheduled";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 4].Value = "Next Date/Shift Scheduled";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 5].Value = "ID";
			this.sprAvailable_Sheet1.ColumnHeader.Cells[0, 6].Value = "EmpID";
			this.sprAvailable_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
			this.sprAvailable_Sheet1.Columns.Get(0).Label = "Employee Name";
			this.sprAvailable_Sheet1.Columns.Get(0).Width = 126F;
			this.sprAvailable_Sheet1.Columns.Get(1).Label = "Date/Shift Available";
			this.sprAvailable_Sheet1.Columns.Get(1).Width = 98F;
			this.sprAvailable_Sheet1.Columns.Get(2).Label = "Record Created On";
			this.sprAvailable_Sheet1.Columns.Get(2).StyleName = "Static798636234643762104757";
			this.sprAvailable_Sheet1.Columns.Get(2).Width = 98F;
			this.sprAvailable_Sheet1.Columns.Get(3).Label = "Last Date/Shift Scheduled";
			this.sprAvailable_Sheet1.Columns.Get(3).StyleName = "Static798636234643762104757";
			this.sprAvailable_Sheet1.Columns.Get(3).Width = 98F;
			this.sprAvailable_Sheet1.Columns.Get(4).Label = "Next Date/Shift Scheduled";
			this.sprAvailable_Sheet1.Columns.Get(4).StyleName = "Static798636234643762104757";
			this.sprAvailable_Sheet1.Columns.Get(4).Width = 98F;
			this.sprAvailable_Sheet1.Columns.Get(5).Label = "ID";
			this.sprAvailable_Sheet1.Columns.Get(5).StyleName = "Static798636234643762104757";
			this.sprAvailable_Sheet1.Columns.Get(5).Visible = false;
			this.sprAvailable_Sheet1.Columns.Get(5).Width = 0F;
			this.sprAvailable_Sheet1.Columns.Get(6).Label = "EmpID";
			this.sprAvailable_Sheet1.Columns.Get(6).Visible = false;
			this.sprAvailable_Sheet1.Columns.Get(6).Width = 0F;
			this.sprAvailable_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprPhoneList_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprPhoneList_Sheet1.SheetName = "Sheet1";
			this.sprPhoneList_Sheet1.ColumnHeader.Cells[0, 0].Value = "Phone Type";
			this.sprPhoneList_Sheet1.ColumnHeader.Cells[0, 1].Value = "Phone Number";
			this.sprPhoneList_Sheet1.ColumnHeader.Rows.Get(0).Height = 21F;
			this.sprPhoneList_Sheet1.Columns.Get(0).Label = "Phone Type";
			this.sprPhoneList_Sheet1.Columns.Get(0).StyleName = "Static646636234643847129669";
			this.sprPhoneList_Sheet1.Columns.Get(0).Width = 105F;
			this.sprPhoneList_Sheet1.Columns.Get(1).Label = "Phone Number";
			this.sprPhoneList_Sheet1.Columns.Get(1).StyleName = "Static646636234643847129669";
			this.sprPhoneList_Sheet1.Columns.Get(1).Width = 110F;
			this.sprPhoneList_Sheet1.RowHeader.Columns.Get(0).Width = 0F;
			this.sprReport_Sheet1 = ctx.Resolve<FarPoint.ViewModels.SheetViewModel>();
			this.sprReport_Sheet1.SheetName = "Sheet1";
			this.cmdPrint = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.cmdPrint.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.cmdPrint.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.TabIndex = 4;
			this.cmdPrint.Text = "Print";
			this.OKButton = ctx.Resolve<UpgradeHelpers.BasicViewModels.ButtonViewModel>();
			// 
			// OKButton
			// 
			this.OKButton.BackColor = UpgradeHelpers.Helpers.SystemColors.Control;
			this.OKButton.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 12F, UpgradeHelpers.Helpers.FontStyle.Regular, UpgradeHelpers.Helpers.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.ForeColor = UpgradeHelpers.Helpers.SystemColors.ControlText;
			this.OKButton.Name = "OKButton";
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "Close";
			this.Text = "Employees Available To Work";
			this.CurrDate = "";
			this.CurrRow = 0;
			this.CurrEmpID = "";
			this.CurrRecord = 0;
			namedStyle1 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color50636234643847100377", "DataAreaDefault");
			namedStyle1.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle1.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle1.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle1.Parent = "DataAreaDefault";
			namedStyle1.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle2 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text299636234643847110141", "DataAreaDefault");
			namedStyle2.CellType = textCellType1;
			namedStyle2.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle2.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle2.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle2.Parent = "DataAreaDefault";
			namedStyle2.Renderer = textCellType1;
			namedStyle2.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle3 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static646636234643847129669");
			namedStyle3.CellType = textCellType2;
			namedStyle3.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle3.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle3.Renderer = textCellType2;
			namedStyle3.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle4 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Color59636234643762075465", "DataAreaDefault");
			namedStyle4.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle4.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle4.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle4.Parent = "DataAreaDefault";
			namedStyle4.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle5 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Text340636234643762085229", "DataAreaDefault");
			namedStyle5.CellType = textCellType3;
			namedStyle5.Font = ctx.Resolve<UpgradeHelpers.Helpers.Font>("Arial", 9F);
			namedStyle5.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle5.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle5.Parent = "DataAreaDefault";
			namedStyle5.Renderer = textCellType3;
			namedStyle5.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.General;
			namedStyle6 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static798636234643762104757");
			namedStyle6.CellType = textCellType4;
			namedStyle6.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Center;
			namedStyle6.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle6.Renderer = textCellType4;
			namedStyle6.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Center;
			namedStyle7 = ctx.Resolve<FarPoint.ViewModels.NamedStyle>("Static1407636234643762163341");
			namedStyle7.CellType = textCellType5;
			namedStyle7.HorizontalAlignment = FarPoint.ViewModels.CellHorizontalAlignment.Left;
			namedStyle7.NoteIndicatorColor = UpgradeHelpers.Helpers.Color.Red;
			namedStyle7.Renderer = textCellType5;
			namedStyle7.VerticalAlignment = FarPoint.ViewModels.CellVerticalAlignment.Top;
			this.Name = "PTSProject.dlgAvailableToWork";
			this.sprReport.Sheets.Add(this.sprReport_Sheet1);
			this.sprPhoneList.NamedStyles.Add(namedStyle1);
			this.sprPhoneList.NamedStyles.Add(namedStyle2);
			this.sprPhoneList.NamedStyles.Add(namedStyle3);
			this.sprPhoneList.Sheets.Add(this.sprPhoneList_Sheet1);
			this.sprAvailable.NamedStyles.Add(namedStyle4);
			this.sprAvailable.NamedStyles.Add(namedStyle5);
			this.sprAvailable.NamedStyles.Add(namedStyle6);
			this.sprAvailable.NamedStyles.Add(namedStyle7);
			this.sprAvailable.Sheets.Add(this.sprAvailable_Sheet1);
		}

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprReport { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprPhoneList { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.TextBoxViewModel txtComment { get; set; }

		public virtual FarPoint.ViewModels.FpSpreadViewModel sprAvailable { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprAvailable_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprPhoneList_Sheet1 { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual FarPoint.ViewModels.SheetViewModel sprReport_Sheet1 { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel cmdPrint { get; set; }

		public virtual UpgradeHelpers.BasicViewModels.ButtonViewModel OKButton { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrDate { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRow { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.String CurrEmpID { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Int32 CurrRecord { get; set; }

		[UpgradeHelpers.Helpers.StateManagement(UpgradeHelpers.Helpers.StateManagementValues.ServerOnly)]
		public virtual System.Boolean IsDisposed { get; set; }

	}

}