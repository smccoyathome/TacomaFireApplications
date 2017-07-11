using System;
using System.Data;

namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    /// It simulates a VB6 Field, contains the Value and FieldMetadata
    /// </summary>
    public class ADOFieldHelper
    {
        private readonly ADORecordSetHelper _rs;
        private readonly object _column;
        private readonly bool _columnTypeNumeric;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs">The recordset for this Field.</param>
        /// <param name="column">The column index or column string to get the Field in the recordset.</param>
        /// <param name="columnTypeNumeric">Indicates if column is an index or string value.</param>
        public ADOFieldHelper(ADORecordSetHelper rs, object column, bool columnTypeNumeric)
        {
            _rs = rs;
            _column = column;
            _columnTypeNumeric = columnTypeNumeric;
        }

        /// <summary>
        /// Value for this Field
        /// </summary>
        public virtual object Value
        {
            get
            {
                if (_columnTypeNumeric)
                    return _rs.Tables[0].Rows[(int)_column];
                return _rs[(String)_column];
            }
            set
            {
                if (_columnTypeNumeric)
                    _rs[(int)_column] = value;
                else
                    _rs[(String)_column] = value;
            }
        }

        /// <summary>
        /// Metadata for this Field
        /// </summary>
        public virtual DataColumn FieldMetadata
        {
            get
            {
                if (_columnTypeNumeric)
                    return _rs.FieldsMetadata[Convert.ToInt32(_column)];
                return _rs.FieldsMetadata[(String)_column];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <returns></returns>
        public int DefinedSize
        {
            get
            {
                return FieldMetadata.MaxLength;
            }
        }

    }
}
