using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace UpgradeHelpers.Helpers
{
    public enum ResourceScope
    {
        None = 0,
        Machine = 1,
        Process = 2,
        AppDomain = 4,
        Library = 8,
        Private = 16,
        Assembly = 32,
    }

    public enum StringAlignment
    {
        Near,
        Center,
        Far,
    }
    public enum HotkeyPrefix
    {
        None,
        Show,
        Hide,
    }

    [Flags]
    public enum StringFormatFlags
    {
        DirectionRightToLeft = 1,
        DirectionVertical = 2,
        FitBlackBox = 4,
        DisplayFormatControl = 32,
        NoFontFallback = 1024,
        MeasureTrailingSpaces = 2048,
        NoWrap = 4096,
        LineLimit = 8192,
        NoClip = 16384,
    }

    public class StringFormat : IDisposable
    {
        internal IntPtr nativeFormat;

        public StringFormatFlags FormatFlags
        {
            get
            {
                StringFormatFlags result;
                int stringFormatFlags = SafeNativeMethods.Gdip.GdipGetStringFormatFlags(new HandleRef((object)this, this.nativeFormat), out result);
                if (stringFormatFlags != 0)
                    throw SafeNativeMethods.Gdip.StatusException(stringFormatFlags);
                return result;
            }
            set
            {
                int status = SafeNativeMethods.Gdip.GdipSetStringFormatFlags(new HandleRef((object)this, this.nativeFormat), value);
                if (status != 0)
                    throw SafeNativeMethods.Gdip.StatusException(status);
            }
        }

        public StringAlignment Alignment
        {
            get
            {
                StringAlignment align = StringAlignment.Near;
                int stringFormatAlign = SafeNativeMethods.Gdip.GdipGetStringFormatAlign(new HandleRef((object)this, this.nativeFormat), out align);
                if (stringFormatAlign != 0)
                    throw SafeNativeMethods.Gdip.StatusException(stringFormatAlign);
                return align;
            }
            set
            {
                if (!IsEnumValid((Enum)value, (int)value, 0, 2))
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(StringAlignment));
                int status = SafeNativeMethods.Gdip.GdipSetStringFormatAlign(new HandleRef((object)this, this.nativeFormat), value);
                if (status != 0)
                    throw SafeNativeMethods.Gdip.StatusException(status);
            }
        }

        public StringAlignment LineAlignment
        {
            get
            {
                StringAlignment align = StringAlignment.Near;
                int stringFormatLineAlign = SafeNativeMethods.Gdip.GdipGetStringFormatLineAlign(new HandleRef((object)this, this.nativeFormat), out align);
                if (stringFormatLineAlign != 0)
                    throw SafeNativeMethods.Gdip.StatusException(stringFormatLineAlign);
                return align;
            }
            set
            {
                if (value < StringAlignment.Near || value > StringAlignment.Far)
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(StringAlignment));
                int status = SafeNativeMethods.Gdip.GdipSetStringFormatLineAlign(new HandleRef((object)this, this.nativeFormat), value);
                if (status != 0)
                    throw SafeNativeMethods.Gdip.StatusException(status);
            }
        }
        public StringFormat()
            : this((StringFormatFlags)0, 0)
        {
        }

        public StringFormat(StringFormatFlags options, int language)
        {
            int stringFormat = SafeNativeMethods.Gdip.GdipCreateStringFormat(options, language, out this.nativeFormat);
            if (stringFormat != 0)
                throw SafeNativeMethods.Gdip.StatusException(stringFormat);
        }

        public StringFormat(StringFormat format)
        {
            if (format == null)
                throw new ArgumentNullException("format");
            int status = SafeNativeMethods.Gdip.GdipCloneStringFormat(new HandleRef((object)format, format.nativeFormat), out this.nativeFormat);
            if (status != 0)
                throw SafeNativeMethods.Gdip.StatusException(status);
        }

        public StringFormat(StringFormatFlags options)
            : this(options, 0)
        {

        }

        public static bool IsEnumValid(Enum enumValue, int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        public override string ToString()
        {
            return "[StringFormat, FormatFlags=" + this.FormatFlags.ToString() + "]";
        }

        public HotkeyPrefix HotkeyPrefix
        {
            get
            {
                HotkeyPrefix hotkeyPrefix;
                int formatHotkeyPrefix = SafeNativeMethods.Gdip.GdipGetStringFormatHotkeyPrefix(new HandleRef((object)this, this.nativeFormat), out hotkeyPrefix);
                if (formatHotkeyPrefix != 0)
                    throw SafeNativeMethods.Gdip.StatusException(formatHotkeyPrefix);
                return hotkeyPrefix;
            }
            set
            {
                if (!IsEnumValid((Enum)value, (int)value, 0, 2))
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(HotkeyPrefix));
                int status = SafeNativeMethods.Gdip.GdipSetStringFormatHotkeyPrefix(new HandleRef((object)this, this.nativeFormat), value);
                if (status != 0)
                    throw SafeNativeMethods.Gdip.StatusException(status);
            }
        }


        public StringTrimming Trimming { get; set; }

        public static object GenericTypographic { get; set; }

        public void Dispose()
        {
            /*Dispose method has no implementation*/
	        System.Diagnostics.Debugger.Break();
		}

        public static StringFormat GenericDefault { get; set; }

        public void SetMeasurableCharacterRanges(CharacterRange[] ranges)
        {
            throw new NotImplementedException();
        }
    }

    public class CharacterRange
    {
        public CharacterRange(int First, int Length)
        {
            {
                throw new NotImplementedException();
            }
        }

    }

    public class HandleRef
    {
        internal object m_wrapper;
        internal IntPtr m_handle;

        public object Wrapper
        {
            get
            {
                return this.m_wrapper;
            }
        }

        public IntPtr Handle
        {
            get
            {
                return this.m_handle;
            }
        }

        public HandleRef(object wrapper, IntPtr handle)
        {
            this.m_wrapper = wrapper;
            this.m_handle = handle;
        }

    }

    public class SafeNativeMethods
    {
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetSysColor(int nIndex);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(HandleRef hInst, int iconId);

        internal class Gdip
        {

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetGenericFontFamilySansSerif(out IntPtr fontfamily);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipCreateFontFamilyFromName(string name, HandleRef fontCollection, out IntPtr FontFamily);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetLineSpacing(HandleRef family, FontStyle style, out int LineSpaceing);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetEmHeight(HandleRef family, FontStyle style, out int EmHeight);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetFamilyName(HandleRef family, StringBuilder name, int language);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetStringFormatFlags(HandleRef format, out StringFormatFlags result);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipSetStringFormatFlags(HandleRef format, StringFormatFlags options);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetStringFormatAlign(HandleRef format, out StringAlignment align);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipSetStringFormatAlign(HandleRef format, StringAlignment align);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipCloneStringFormat(HandleRef format, out IntPtr newFormat);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetStringFormatLineAlign(HandleRef format, out StringAlignment align);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipSetStringFormatLineAlign(HandleRef format, StringAlignment align);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipCreatePen1(int argb, float width, int unit, out IntPtr pen);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipCreateStringFormat(StringFormatFlags options, int language, out IntPtr format);

            [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetSysColor(int nIndex);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipAddPathArc(HandleRef path, float x, float y, float width, float height, float startAngle, float sweepAngle);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipAddPathLineI(HandleRef path, int x1, int y1, int x2, int y2);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetStringFormatHotkeyPrefix(HandleRef format, out HotkeyPrefix hotkeyPrefix);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipSetStringFormatHotkeyPrefix(HandleRef format, HotkeyPrefix hotkeyPrefix);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetFontHeightGivenDPI(HandleRef font, float dpi, out float size);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipGetFontHeight(HandleRef font, HandleRef graphics, out float size);

            [DllImport(ExternDll.Gdiplus, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int GdipCreateFromHDC(HandleRef hdc, out IntPtr graphics);



            internal static Exception StatusException(int status)
            {
                switch (status)
                {
                    case 1:
                        return (Exception)new ExternalException(SR.GetString("GdiplusGenericError"), -2147467259);
                    case 2:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusInvalidParameter"));
                    case 3:
                        return (Exception)new OutOfMemoryException(SR.GetString("GdiplusOutOfMemory"));
                    case 4:
                        return (Exception)new InvalidOperationException(SR.GetString("GdiplusObjectBusy"));
                    case 5:
                        return (Exception)new OutOfMemoryException(SR.GetString("GdiplusInsufficientBuffer"));
                    case 6:
                        return (Exception)new NotImplementedException(SR.GetString("GdiplusNotImplemented"));
                    case 7:
                        return (Exception)new ExternalException(SR.GetString("GdiplusGenericError"), -2147467259);
                    case 8:
                        return (Exception)new InvalidOperationException(SR.GetString("GdiplusWrongState"));
                    case 9:
                        return (Exception)new ExternalException(SR.GetString("GdiplusAborted"), -2147467260);
                    case 10:
                        return (Exception)new FileNotFoundException(SR.GetString("GdiplusFileNotFound"));
                    case 11:
                        return (Exception)new OverflowException(SR.GetString("GdiplusOverflow"));
                    case 12:
                        return (Exception)new ExternalException(SR.GetString("GdiplusAccessDenied"), -2147024891);
                    case 13:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusUnknownImageFormat"));
                    case 14:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusFontFamilyNotFound", new object[1]
            {
              (object) "?"
            }));
                    case 15:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusFontStyleNotFound", (object)"?", (object)"?"));
                    case 16:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusNotTrueTypeFont_NoName"));
                    case 17:
                        return (Exception)new ExternalException(SR.GetString("GdiplusUnsupportedGdiplusVersion"), -2147467259);
                    case 18:
                        return (Exception)new ExternalException(SR.GetString("GdiplusNotInitialized"), -2147467259);
                    case 19:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusPropertyNotFoundError"));
                    case 20:
                        return (Exception)new ArgumentException(SR.GetString("GdiplusPropertyNotSupportedError"));
                    default:
                        return (Exception)new ExternalException(SR.GetString("GdiplusUnknown"), -2147418113);
                }
            }

            internal static IDictionary ThreadData
            {
                get
                {
                    LocalDataStoreSlot namedDataSlot = Thread.GetNamedDataSlot("UpgradeHelpers.Helpers.threaddata");
                    IDictionary dictionary = (IDictionary)Thread.GetData(namedDataSlot);
                    if (dictionary == null)
                    {
                        dictionary = (IDictionary)new Hashtable();
                        Thread.SetData(namedDataSlot, (object)dictionary);
                    }
                    return dictionary;
                }
            }

        }

        public sealed class SR
        {
            internal const string CantTellPrinterName = "CantTellPrinterName";
            internal const string CantChangeImmutableObjects = "CantChangeImmutableObjects";
            internal const string CantMakeIconTransparent = "CantMakeIconTransparent";
            internal const string ColorNotSystemColor = "ColorNotSystemColor";
            internal const string DotNET_ComponentType = "DotNET_ComponentType";
            internal const string GdiplusAborted = "GdiplusAborted";
            internal const string GdiplusAccessDenied = "GdiplusAccessDenied";
            internal const string GdiplusCannotCreateGraphicsFromIndexedPixelFormat = "GdiplusCannotCreateGraphicsFromIndexedPixelFormat";
            internal const string GdiplusCannotSetPixelFromIndexedPixelFormat = "GdiplusCannotSetPixelFromIndexedPixelFormat";
            internal const string GdiplusDestPointsInvalidParallelogram = "GdiplusDestPointsInvalidParallelogram";
            internal const string GdiplusDestPointsInvalidLength = "GdiplusDestPointsInvalidLength";
            internal const string GdiplusFileNotFound = "GdiplusFileNotFound";
            internal const string GdiplusFontFamilyNotFound = "GdiplusFontFamilyNotFound";
            internal const string GdiplusFontStyleNotFound = "GdiplusFontStyleNotFound";
            internal const string GdiplusGenericError = "GdiplusGenericError";
            internal const string GdiplusInsufficientBuffer = "GdiplusInsufficientBuffer";
            internal const string GdiplusInvalidParameter = "GdiplusInvalidParameter";
            internal const string GdiplusInvalidRectangle = "GdiplusInvalidRectangle";
            internal const string GdiplusInvalidSize = "GdiplusInvalidSize";
            internal const string GdiplusOutOfMemory = "GdiplusOutOfMemory";
            internal const string GdiplusNotImplemented = "GdiplusNotImplemented";
            internal const string GdiplusNotInitialized = "GdiplusNotInitialized";
            internal const string GdiplusNotTrueTypeFont = "GdiplusNotTrueTypeFont";
            internal const string GdiplusNotTrueTypeFont_NoName = "GdiplusNotTrueTypeFont_NoName";
            internal const string GdiplusObjectBusy = "GdiplusObjectBusy";
            internal const string GdiplusOverflow = "GdiplusOverflow";
            internal const string GdiplusPropertyNotFoundError = "GdiplusPropertyNotFoundError";
            internal const string GdiplusPropertyNotSupportedError = "GdiplusPropertyNotSupportedError";
            internal const string GdiplusUnknown = "GdiplusUnknown";
            internal const string GdiplusUnknownImageFormat = "GdiplusUnknownImageFormat";
            internal const string GdiplusUnsupportedGdiplusVersion = "GdiplusUnsupportedGdiplusVersion";
            internal const string GdiplusWrongState = "GdiplusWrongState";
            internal const string GlobalAssemblyCache = "GlobalAssemblyCache";
            internal const string GraphicsBufferCurrentlyBusy = "GraphicsBufferCurrentlyBusy";
            internal const string GraphicsBufferQueryFail = "GraphicsBufferQueryFail";
            internal const string ToolboxItemLocked = "ToolboxItemLocked";
            internal const string ToolboxItemInvalidPropertyType = "ToolboxItemInvalidPropertyType";
            internal const string ToolboxItemValueNotSerializable = "ToolboxItemValueNotSerializable";
            internal const string ToolboxItemInvalidKey = "ToolboxItemInvalidKey";
            internal const string IllegalState = "IllegalState";
            internal const string InterpolationColorsColorBlendNotSet = "InterpolationColorsColorBlendNotSet";
            internal const string InterpolationColorsCommon = "InterpolationColorsCommon";
            internal const string InterpolationColorsInvalidColorBlendObject = "InterpolationColorsInvalidColorBlendObject";
            internal const string InterpolationColorsInvalidStartPosition = "InterpolationColorsInvalidStartPosition";
            internal const string InterpolationColorsInvalidEndPosition = "InterpolationColorsInvalidEndPosition";
            internal const string InterpolationColorsLength = "InterpolationColorsLength";
            internal const string InterpolationColorsLengthsDiffer = "InterpolationColorsLengthsDiffer";
            internal const string InvalidArgument = "InvalidArgument";
            internal const string InvalidBoundArgument = "InvalidBoundArgument";
            internal const string InvalidClassName = "InvalidClassName";
            internal const string InvalidColor = "InvalidColor";
            internal const string InvalidDashPattern = "InvalidDashPattern";
            internal const string InvalidEx2BoundArgument = "InvalidEx2BoundArgument";
            internal const string InvalidFrame = "InvalidFrame";
            internal const string InvalidGDIHandle = "InvalidGDIHandle";
            internal const string InvalidImage = "InvalidImage";
            internal const string InvalidLowBoundArgumentEx = "InvalidLowBoundArgumentEx";
            internal const string InvalidPermissionLevel = "InvalidPermissionLevel";
            internal const string InvalidPermissionState = "InvalidPermissionState";
            internal const string InvalidPictureType = "InvalidPictureType";
            internal const string InvalidPrinterException_InvalidPrinter = "InvalidPrinterException_InvalidPrinter";
            internal const string InvalidPrinterException_NoDefaultPrinter = "InvalidPrinterException_NoDefaultPrinter";
            internal const string InvalidPrinterHandle = "InvalidPrinterHandle";
            internal const string ValidRangeX = "ValidRangeX";
            internal const string ValidRangeY = "ValidRangeY";
            internal const string NativeHandle0 = "NativeHandle0";
            internal const string NoDefaultPrinter = "NoDefaultPrinter";
            internal const string NotImplemented = "NotImplemented";
            internal const string PDOCbeginPrintDescr = "PDOCbeginPrintDescr";
            internal const string PDOCdocumentNameDescr = "PDOCdocumentNameDescr";
            internal const string PDOCdocumentPageSettingsDescr = "PDOCdocumentPageSettingsDescr";
            internal const string PDOCendPrintDescr = "PDOCendPrintDescr";
            internal const string PDOCoriginAtMarginsDescr = "PDOCoriginAtMarginsDescr";
            internal const string PDOCprintControllerDescr = "PDOCprintControllerDescr";
            internal const string PDOCprintPageDescr = "PDOCprintPageDescr";
            internal const string PDOCprinterSettingsDescr = "PDOCprinterSettingsDescr";
            internal const string PDOCqueryPageSettingsDescr = "PDOCqueryPageSettingsDescr";
            internal const string PrintDocumentDesc = "PrintDocumentDesc";
            internal const string PrintingPermissionBadXml = "PrintingPermissionBadXml";
            internal const string PrintingPermissionAttributeInvalidPermissionLevel = "PrintingPermissionAttributeInvalidPermissionLevel";
            internal const string PropertyValueInvalidEntry = "PropertyValueInvalidEntry";
            internal const string PSizeNotCustom = "PSizeNotCustom";
            internal const string ResourceNotFound = "ResourceNotFound";
            internal const string TargetNotPrintingPermission = "TargetNotPrintingPermission";
            internal const string TextParseFailedFormat = "TextParseFailedFormat";
            internal const string TriStateCompareError = "TriStateCompareError";
            internal const string toStringIcon = "toStringIcon";
            internal const string toStringNone = "toStringNone";
            internal const string DCTypeInvalid = "DCTypeInvalid";
            internal const string CannotActivateControl = "CannotActivateControl";
            private static SR loader;
            private ResourceManager resources;

            private static CultureInfo Culture
            {
                get
                {
                    return (CultureInfo)null;
                }
            }

            private static SR GetLoader()
            {
                if (SR.loader == null)
                {
                    SR sr = new SR();
                    Interlocked.CompareExchange<SR>(ref SR.loader, sr, (SR)null);
                }
                return SR.loader;
            }

            public static string GetString(string name)
            {
                SR loader = SR.GetLoader();
                if (loader == null)
                    return (string)null;
                return loader.resources.GetString(name, CultureInfo.CurrentCulture);
            }

            public static string GetString(string name, params object[] args)
            {
                SR loader = SR.GetLoader();
                if (loader == null)
                    return (string)null;
                string @string = loader.resources.GetString(name, SR.Culture);
                if (args == null || args.Length <= 0)
                    return @string;
                for (int index = 0; index < args.Length; ++index)
                {
                    string str = args[index] as string;
                    if (str != null && str.Length > 1024)
                        args[index] = (object)(str.Substring(0, 1021) + "...");
                }
                return string.Format((IFormatProvider)CultureInfo.CurrentCulture, @string, args);
            }

        }

        public sealed class CommonHandles
        {
            public static readonly int Accelerator = 80;
            public static readonly int Cursor = 20;
            public static readonly int EMF = 20;
            public static readonly int Find = 0;
            public static readonly int GDI = 50;
            public static readonly int HDC = 100;
            public static readonly int Icon = 2;
            public static readonly int Kernel = 0;
            public static readonly int Menu = 30;
            public static readonly int Window = 5;
        }
    }

    internal static class ExternDll
    {
        public const string User32 = "user32.dll";
        public const string Gdiplus = "gdiplus.dll";
        public const string Gdi32 = "gdi32.dll";
    }

}
