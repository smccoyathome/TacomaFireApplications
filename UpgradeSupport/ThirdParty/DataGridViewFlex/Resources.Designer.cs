//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UpgradeHelpers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UpgradeHelpers.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap DownArrow {
            get {
                object obj = ResourceManager.GetObject("DownArrow", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FixedColumns must always be at least one less than ColumnsCount.
        /// </summary>
        public static string FixedColumnLessThanColumnsCount {
            get {
                return ResourceManager.GetString("FixedColumnLessThanColumnsCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FixedRows must always be at least one less than RowsCount.
        /// </summary>
        public static string FixedRowsLessThanRowsCount {
            get {
                return ResourceManager.GetString("FixedRowsLessThanRowsCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;TD valign=&quot;MIDDLE&quot; bgcolor=&quot;#D4D0C8&quot; width=&quot;#width#%&quot; NOWRAP&gt;&lt;font color=&quot;#000000&quot; face=&quot;MS Sans Serif&quot; size=&quot;-1&quot; weight=&quot;400&quot;&gt;#footer_Text#&lt;/TD&gt;.
        /// </summary>
        public static string HtmlTableFooterTemplate {
            get {
                return ResourceManager.GetString("HtmlTableFooterTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;TD valign=&quot;MIDDLE&quot; bgcolor=&quot;#D4D0C8&quot; width=&quot;#width#%&quot;&gt;&lt;font color=&quot;#000000&quot; face=&quot;MS Sans Serif&quot; size=&quot;-1&quot; weight=&quot;400&quot;&gt;#header_Text#&lt;/TD&gt;.
        /// </summary>
        public static string HtmlTableHeaderTemplate {
            get {
                return ResourceManager.GetString("HtmlTableHeaderTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;tr valign=&quot;TOP&quot;&gt;
        ///        #table_row_cells#
        ///&lt;/tr&gt;.
        /// </summary>
        public static string HtmlTableRowTemplate {
            get {
                return ResourceManager.GetString("HtmlTableRowTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to         &lt;TD valign=&quot;TOP&quot; bgcolor=&quot;#FFFFFF&quot; width=&quot;#width#%&quot; NOWRAP&gt;&lt;font color=&quot;#000000&quot; face=&quot;MS Sans Serif&quot; size=&quot;-1&quot; weight=&quot;400&quot;&gt;#cell_Text#&lt;/font&gt;&lt;/td&gt;.
        /// </summary>
        public static string HtmlTableRowTemplate_Cell {
            get {
                return ResourceManager.GetString("HtmlTableRowTemplate_Cell", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;table border  #table_width#&gt;
        ///&lt;tr&gt;
        ///&lt;/tr&gt;
        ///&lt;tr&gt;
        ///   #table_headers#
        ///&lt;/tr&gt;
        ///#table_rows#
        ///&lt;tr&gt;
        ///   #table_footers#
        ///&lt;/tr&gt;
        ///&lt;/table&gt;.
        /// </summary>
        public static string HtmlTableTemplate {
            get {
                return ResourceManager.GetString("HtmlTableTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Index must be between 0 and the RowsCount.
        /// </summary>
        public static string InvalidCurrentRowIndex {
            get {
                return ResourceManager.GetString("InvalidCurrentRowIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The column editor cannot be used to change an ExtendedDataGridView working in a FlexGrid Compatibility mode.
        /// </summary>
        public static string MSFlexGridColumnEditor {
            get {
                return ResourceManager.GetString("MSFlexGridColumnEditor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If there are rows it&apos;s imposible to remove all the columns.
        /// </summary>
        public static string NoRemoveColumnsWithRows {
            get {
                return ResourceManager.GetString("NoRemoveColumnsWithRows", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap ToolColumn {
            get {
                object obj = ResourceManager.GetObject("ToolColumn", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap ToolGrid {
            get {
                object obj = ResourceManager.GetObject("ToolGrid", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be greater than 0.
        /// </summary>
        public static string ValueGreaterThanZero {
            get {
                return ResourceManager.GetString("ValueGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be 0 or greater.
        /// </summary>
        public static string ValueZeroOrGreater {
            get {
                return ResourceManager.GetString("ValueZeroOrGreater", resourceCulture);
            }
        }
    }
}
