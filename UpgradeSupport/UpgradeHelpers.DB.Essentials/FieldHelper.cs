using System;
using System.Data;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// It simulates a VB6 Field, contains the Value and FieldMetadata
    /// </summary>
    public class FieldHelper
    {
        private readonly DataSet _rs;
        private readonly object _column;
        private readonly bool _columnTypeNumeric;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs">The recordset for this Field.</param>
        /// <param name="column">The column index or column string to get the Field in the recordset.</param>
        /// <param name="columnTypeNumeric">Indicates if column is an index or string value.</param>
        public FieldHelper(DataSet rs, object column, bool columnTypeNumeric)
        {
            _rs = rs;
            _column = column;
            _columnTypeNumeric = columnTypeNumeric;
        }
        /*
        /// <summary>
        /// Value for this Field
        /// </summary>
        public virtual object Value
        {
            get
            {
                if (_columnTypeNumeric)
                    return _rs.Tables[0].Rows[(int)_column];
                return _rs.Tables[0].Rows[_column];
            }
            set
            {
                if (_columnTypeNumeric)
                    _rs[(int)_column] = value;
                else
                    _rs[(int)_column] = value;
            }
            return null;
        }

        /// <summary>
        /// Metadata for this Field
        /// </summary>
        public virtual DataColumn FieldMetadata
        {
            get
            {
                if (_columnTypeNumeric)
                    return _rs.FieldsMetadata[(int)_column];
                return _rs.FieldsMetadata[(String)_column];
            }
        }
            return null;
        }
         * */
    }
}
