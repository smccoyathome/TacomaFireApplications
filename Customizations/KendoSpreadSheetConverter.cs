// // *************************************************************************************
// // <copyright company="Mobilize.Net" file="KendoSpreadSheetConverter.cs" >
// //      Copyright (c) 2017 Mobilize, Inc. All Rights Reserved.
// //      All classes are provided for customer use only,
// //      all other use is prohibited without prior written consent from Mobilize.Net.
// //      no warranty express or implied,
// //      use at own risk.
// // </copyright>
// // <summary></summary>
// // ************************************************************************************* 

namespace FarPoint.Converters
{
    using System;
    using System.Linq;

    using FarPoint.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// JSON converter for Kendo SpreadSheet
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class KendoSpreadSheetConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            var expectedType = typeof(FpSpreadViewModel);
            return expectedType.IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var model = (FpSpreadViewModel)value;
            JObject o = new JObject
                            {
                                { "Name", model.Name },
                                { "activeSheet", model.ActiveSheet.SheetName },
                                { "sheets", GetSheetsToken(model) }
                            };

            o.WriteTo(writer);
        }

        /// <summary>
        /// Gets the rowModel.
        /// </summary>
        /// <param name="rowModel">The rowModel.</param>
        /// <returns></returns>
        private static JToken GetRow(Row rowModel, SheetViewModel sheetModel)
        {
            var rowJObject = new JObject { { "height", rowModel.Height }, { "index", rowModel.Index } };
            var cells = new JArray();
            foreach (var cell in rowModel.RowCells)
            {
                GetCell(cell, cells, sheetModel);
            }
            rowJObject.Add("cells", cells);
            return rowJObject;
        }

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="cells">The cells.</param>
        private static void GetCell(Cell cell, JArray cells, SheetViewModel sheetModel)
        {
            var column = sheetModel.Columns[cell.Column];
            var row = sheetModel.Rows[cell.Row];
            var cellJObject = new JObject
                                  {
                                      { "value", cell.Value },
                                      { "index", cell.Column }
                                  };

            CellAlignment(cell, cellJObject);
            CellLock(cell, cellJObject);
            CellColor(cell, cellJObject);
            CellFont(cell, cellJObject);
            cells.Add(cellJObject);
        }
        
        private static void CellLock(Cell cell, JObject cellJObject)
        {
            if (cell.Locked)
            {
                cellJObject.Add("enable", !cell.Locked);
            }
        }

        private static void CellFont(Cell cell, JObject cellJObject)
        {
            var font = cell.Font;
            if (font != null)
            {
                if (font.FontFamily != null && !string.IsNullOrEmpty(font.FontFamily.Name))
                {
                    cellJObject.Add("fontFamily", font.FontFamily.Name);
                }
                if (font.SizeInPoints > 0)
                {
                    cellJObject.Add("fontSize", (int)font.SizeInPoints);
                }
                if (font.Size > 0 && font.SizeInPoints != font.Size)
                {
                    cellJObject.Add("fontSize", (int)font.Size);
                }
                if (font.Bold)
                {
                    cellJObject.Add("bold",font.Bold);
                }
                if (font.Italic)
                {
                    cellJObject.Add("italic", font.Italic);
                }
            }
        }

        private static void CellColor(Cell cell, JObject cellJObject)
        {
            if (cell.BackColor != null)
            {
                cellJObject.Add("background", cell.BackColor.Value.ToString());
            }
            if (cell.ForeColor != null)
            {
                cellJObject.Add("color", cell.ForeColor.Value.ToString());
            }
        }

        private static void CellAlignment(Cell cell, JObject cellJObject)
        {
            if (cell.HorizontalAlignment > 0)
            {
                cellJObject.Add("textAlign", cell.HorizontalAlignment.ToString());
            }
            if (cell.VerticalAlignment > 0)
            {
                cellJObject.Add("verticalAlign", cell.VerticalAlignment.ToString());
            }
        }

        /// <summary>
        /// Gets the JToken that represent the rows of the SheetViewModel.
        /// </summary>
        /// <param name="sheetModel">The sheet model.</param>
        /// <returns>return the JToken that represents the sheet view model</returns>
        private static JToken GetRows(SheetViewModel sheetModel)
        {
            var rows = new JArray();
            var sheetRows = sheetModel.Rows;
            foreach (var row in sheetRows)
            {
                rows.Add(GetRow(row, sheetModel));
            }

            return rows;
        }

        /// <summary>
        /// Gets the sheets token.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns a JToken that represents the Collection of sheets of the FarPoint SpreadViewModel</returns>
        private static JToken GetSheetsToken(FpSpreadViewModel model)
        {
            var sheets = new JArray();
            foreach (var sheet in model.Sheets)
            {
                sheets.Add(GetSheetToken(sheet));
            }

            return sheets;
        }

        /// <summary>
        /// Gets the sheet token.
        /// </summary>
        /// <param name="sheetModel">The sheet model.</param>
        /// <returns>return a JToken that represents the SheetViewModel</returns>
        private static JToken GetSheetToken(SheetViewModel sheetModel)
        {
            var sheet = new JObject { { "name", sheetModel.SheetName },
                                      { "rows", GetRows(sheetModel) },
                                      { "columns", GetColumns(sheetModel) } };
            return sheet;
        }

        private static JToken GetColumns(SheetViewModel sheetModel)
        {
            var columns = new JArray();
            var sheetColumns = sheetModel.Columns;
            foreach (var column in sheetColumns)
            {
                var columnJObject = new JObject { { "index", column.Index }, { "width", column.Width } };
                columns.Add(columnJObject);
            }

            return columns;
        }
    }
}