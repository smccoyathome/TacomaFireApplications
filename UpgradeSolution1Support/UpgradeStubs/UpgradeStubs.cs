using System;
using System.Data.Common;
using UpgradeHelpers.Interfaces;
using UpgradeHelpers.Extensions;
using UpgradeHelpers.BasicViewModels.Extensions;

namespace UpgradeStubs
{
	public class FPSpread_PrintOrientationConstants
	{

		public static UpgradeStubs.FPSpread_PrintOrientationConstantsEnum getPrintOrientationDefault()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.PrintOrientationConstants.PrintOrientationDefault");
			return (UpgradeStubs.FPSpread_PrintOrientationConstantsEnum)FPSpread_PrintOrientationConstantsEnum.PrintOrientationDefault;
		}
		public static UpgradeStubs.FPSpread_PrintOrientationConstantsEnum getPrintOrientationLandscape()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.PrintOrientationConstants.PrintOrientationLandscape");
			return (UpgradeStubs.FPSpread_PrintOrientationConstantsEnum)FPSpread_PrintOrientationConstantsEnum.PrintOrientationLandscape;
		}
		public static UpgradeStubs.FPSpread_PrintOrientationConstantsEnum getPrintOrientationPortrait()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.PrintOrientationConstants.PrintOrientationPortrait");
			return (UpgradeStubs.FPSpread_PrintOrientationConstantsEnum)FPSpread_PrintOrientationConstantsEnum.PrintOrientationPortrait;
		}
	}
	public class MSComDlg_CommonDialog
		: UpgradeHelpers.Helpers.ControlViewModel
	{

		public void setPrinterDefault(bool PrinterDefault)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.PrinterDefault");
		}
	}
	public class SSCalendarWidgets_A_Constants_SelectionType
	{

		public static UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionTypeEnum getssSelectionTypeMultiSelect()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.Constants_SelectionType.ssSelectionTypeMultiSelect");
			return (UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionTypeEnum)SSCalendarWidgets_A_Constants_SelectionTypeEnum.ssSelectionTypeMultiSelect;
		}
		public static UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionTypeEnum getssSelectionTypeSingleSelect()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.Constants_SelectionType.ssSelectionTypeSingleSelect");
			return (UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionTypeEnum)SSCalendarWidgets_A_Constants_SelectionTypeEnum.ssSelectionTypeSingleSelect;
		}
	}
	public static class System_Data_Common_DbCommand
	{

		public static int getState(this DbCommand instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Command.State");
			return 0;
		}
	}
	public static class System_Windows_Forms_ComboBox
	{

		public static void setLocked(this UpgradeHelpers.BasicViewModels.ComboBoxViewModel instance, bool Locked)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.ComboBox.Locked");
		}
	}
	public static class System_Windows_Forms_Control
	{

		public static int getHelpContextID(this UpgradeHelpers.Helpers.ControlViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Control.HelpContextID");
			return 0;
		}
	}
	public static class System_Windows_Forms_DateTimePicker
	{

		public static dynamic getX(this WNFRMS.Viewmodels.DateTimePickerViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.SSDateCombo.x");
			return null;
		}
	}
	public static class System_Windows_Forms_ListBox
	{

		public static int getNewIndex(this UpgradeHelpers.BasicViewModels.ListBoxViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpListAdo.NewIndex");
			return 0;
		}
		public static int ItemData(this UpgradeHelpers.BasicViewModels.ListBoxViewModel instance, object Row)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpListAdo.ItemData");
			return 0;
		}
		public static void setItemData(this UpgradeHelpers.BasicViewModels.ListBoxViewModel instance, int ItemData, object Row)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpListAdo.ItemData");
		}
	}
	public static class System_Windows_Forms_MaskedTextBox
	{

		public static int getHelpContextID(this UpgradeHelpers.BasicViewModels.MaskedTextBoxViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSMask.MaskEdBox.HelpContextID");
			return 0;
		}
	}
	public static class System_Windows_Forms_MonthCalendar
	{

		public static dynamic getX(this UpgradeHelpers.BasicViewModels.MonthCalendarViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.SSYear.x");
			return null;
		}
		public static void setDayCaptionStyleSet(this UpgradeHelpers.BasicViewModels.MonthCalendarViewModel instance, string DayCaptionStyleSet)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.SSYear.DayCaptionStyleSet");
		}
		public static void setSelectionType(this UpgradeHelpers.BasicViewModels.MonthCalendarViewModel instance, UpgradeStubs.SSCalendarWidgets_A_Constants_SelectionTypeEnum SelectionType)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SSCalendarWidgets_A.SSYear.SelectionType");
		}
	}
	public static class UpgradeHelpers_Gui_ComboBoxHelper
	{

		public static int getNewIndex(this UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpComboAdo.NewIndex");
			return 0;
		}
		public static int ItemData(this UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper instance, object Row)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpComboAdo.ItemData");
			return 0;
		}
		public static void setItemData(this UpgradeHelpers.DoubleJumpSupport.ComboBoxHelper instance, int ItemData, object Row)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("LpADOLib.fpComboAdo.ItemData");
		}
	}
	public static class UpgradeHelpers_Spread_FpSpread
	{

		public static bool AddCellSpan(this FarPoint.ViewModels.FpSpreadViewModel instance, int lCol, int lRow, int lNumCols, int lNumRows)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.AddCellSpan");
			return false;
		}
		public static bool ExportRangeToHTML(this FarPoint.ViewModels.FpSpreadViewModel instance, int Col, int Row, int Col2, int Row2, string FileName, bool AppendFlag, string LogFile)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.ExportRangeToHTML");
			return false;
		}
		public static bool ExportToExcel(this FarPoint.ViewModels.FpSpreadViewModel instance, string FileName, string SheetName, string LogFileName)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.ExportToExcel");
			return false;
		}
		public static double getMaxTextCellHeight(this FarPoint.ViewModels.FpSpreadViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.MaxTextCellHeight");
			return 0;
		}
		public static double getMaxTextCellWidth(this FarPoint.ViewModels.FpSpreadViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.MaxTextCellWidth");
			return 0;
		}
		public static string getTypeCheckText(this FarPoint.ViewModels.FpSpreadViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.TypeCheckText");
			return "";
		}
		public static bool IsFetchCellNote(this FarPoint.ViewModels.FpSpreadViewModel instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.IsFetchCellNote");
			return false;
		}
		public static void RemoveCellSpan(this FarPoint.ViewModels.FpSpreadViewModel instance, int lCol, int lRow)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.RemoveCellSpan");
		}
		public static void setAllowCellOverflow(this FarPoint.ViewModels.FpSpreadViewModel instance, bool AllowCellOverflow)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.AllowCellOverflow");
		}
		public static void SetCellBorder(this FarPoint.ViewModels.FpSpreadViewModel instance, int lCol, int lRow, int
			lCol2, int lRow2, short nIndex, UpgradeHelpers.Helpers.Color crColor, object nStyle)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.SetCellBorder");
		}
		public static void setGridShowHoriz(this FarPoint.ViewModels.FpSpreadViewModel instance, bool GridShowHoriz)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.GridShowHoriz");
		}
		public static void setGridShowVert(this FarPoint.ViewModels.FpSpreadViewModel instance, bool GridShowVert)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.GridShowVert");
		}
		public static void setPrintAbortMsg(this FarPoint.ViewModels.FpSpreadViewModel instance, string PrintAbortMsg)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintAbortMsg");
		}
		public static void setPrintBorder(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintBorder)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintBorder");
		}
		public static void setPrintColHeaders(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintColHeaders)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintColHeaders");
		}
		public static void setPrintColor(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintColor)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintColor");
		}
		public static void setPrintFooter(this FarPoint.ViewModels.FpSpreadViewModel instance, string PrintFooter)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintFooter");
		}
		public static void setPrintGrid(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintGrid)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintGrid");
		}
		public static void setPrintHeader(this FarPoint.ViewModels.FpSpreadViewModel instance, string PrintHeader)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintHeader");
		}
		public static void setPrintJobName(this FarPoint.ViewModels.FpSpreadViewModel instance, string PrintJobName)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintJobName");
		}
		public static void setPrintMarginLeft(this FarPoint.ViewModels.FpSpreadViewModel instance, int PrintMarginLeft)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.PrintMarginLeft");
		}
		public static void setPrintMarginRight(this FarPoint.ViewModels.FpSpreadViewModel instance, int PrintMarginRight)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.PrintMarginRight");
		}
		public static void setPrintMarginTop(this FarPoint.ViewModels.FpSpreadViewModel instance, int PrintMarginTop)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.PrintMarginTop");
		}
		//public static void setPrintOrientation(this UpgradeHelpers.Spread.FpSpread instance, FPSpreadADO.PrintOrientationConstants PrintOrientation)
		//{
		//	UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintOrientation");
		//}
		public static void setPrintOrientation(this FarPoint.ViewModels.FpSpreadViewModel instance, UpgradeStubs.FPSpread_PrintOrientationConstantsEnum PrintOrientation)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.PrintOrientation");
		}
		public static void setPrintRowHeaders(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintRowHeaders)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.PrintRowHeaders");
		}
		public static void setPrintSmartPrint(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintSmartPrint)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintSmartPrint");
		}
		public static void setPrintUseDataMax(this FarPoint.ViewModels.FpSpreadViewModel instance, bool PrintUseDataMax)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.PrintUseDataMax");
		}
		public static void setRowPageBreak(this FarPoint.ViewModels.FpSpreadViewModel instance, bool RowPageBreak)
		{
            ///TODO: Check this
			//UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.RowPageBreak");
		}
		public static bool SetTextTipAppearance(this FarPoint.ViewModels.FpSpreadViewModel instance, string FontName, short FontSize, bool FontBold, bool FontItalic, int BackColor_Renamed, int ForeColor_Renamed)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.SetTextTipAppearance");
			return false;
		}
		public static void setTypeCheckText(this FarPoint.ViewModels.FpSpreadViewModel instance, string TypeCheckText)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.TypeCheckText");
		}
		public static void setVirtualMode(this FarPoint.ViewModels.FpSpreadViewModel instance, bool VirtualMode)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpread.vaSpread.VirtualMode");
		}
		public static bool Sort(this FarPoint.ViewModels.FpSpreadViewModel instance, int lCol, int lRow, int lCol2, int lRow2, FarPoint.ViewModels.SortByConstants nSortBy, object SortKeys, object SortKeyOrders)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.Sort");
			return false;
		}
		public static void TypeComboBoxClear(this FarPoint.ViewModels.FpSpreadViewModel instance, int lCol, int lRow)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("FPSpreadADO.fpSpread.TypeComboBoxClear");
		}
	}
	public enum FPSpread_PrintOrientationConstantsEnum
	{
		PrintOrientationDefault = 0,
	PrintOrientationPortrait = 1,
		PrintOrientationLandscape = 2
	}
	public enum SSCalendarWidgets_A_Constants_SelectionTypeEnum
	{
		ssSelectionTypeSingleSelect = 0,
		ssSelectionTypeMultiSelect = 1
	}
}