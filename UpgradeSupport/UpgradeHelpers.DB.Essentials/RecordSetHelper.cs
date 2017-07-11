using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class RecordSetHelper : DataSet, ISerializable
    {
        /// <summary>
        /// 
        /// </summary>
        public RecordSetHelper()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetName"></param>
        public RecordSetHelper(string dataSetName) : base(dataSetName) 
        { 
        }

        #region ISerializable Members
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected RecordSetHelper(SerializationInfo info, StreamingContext context)
        {
            AdoNetHelper.DeserializeDataSet(this, (byte[])info.GetValue("_", typeof(byte[])));
            _opened = info.GetBoolean("Opened");
            _dbType = (DatabaseType)info.GetUInt16("DatabaseType");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_", AdoNetHelper.SerializeDataSet(this));
            info.AddValue("Opened", _opened);
            info.AddValue("DatabaseType", _dbType);
        }
        #endregion

        EventHandler _beforeMove = null;
        /// <summary>
        /// 
        /// </summary>
        public virtual EventHandler BeforeMove
        {
            get
            {
                return _beforeMove;
            }
            set
            {
                _beforeMove = value;
            }
        }
        private EventHandler _newRecord = null;
        /// <summary>
        /// Fires event when a new record is been created.
        /// </summary>
        public virtual EventHandler NewRecord
        {
            get
            {
                return _newRecord;
            }
            set
            {
                _newRecord = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract RecordSetHelper CreateInstance();
        /// <summary>
        /// open state
        /// </summary>
        internal bool _opened = false;
        /// <summary>
        /// Indicates if this RecordsetHelper have been open.
        /// </summary>
        public bool Opened
        {
            get
            {
                return _opened;
            }
            set
            {
                _opened = value;
            }
        }
        /// <summary>
        /// string for select query
        /// </summary>
        internal String _sqlSelectQuery = string.Empty;
        /// <summary>
        /// Gets or sets the SQL query used for select operations in this RecordsetHelper.
        /// </summary>
        public String SqlQuery
        {
            get
            {
                return _sqlSelectQuery;
            }
            set
            {
                _sqlSelectQuery = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract DbConnection ActiveConnection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract string ConnectionString { get; set; }
        internal DbProviderFactory _providerFactory;
        /// <summary>
        /// Gets or sets the DBProviderFactory to be use by this object.
        /// </summary>
        public DbProviderFactory ProviderFactory
        {
            get
            {
                return _providerFactory;
            }
            set
            {
                _providerFactory = value;
            }
        }
        /// <summary>
        ///     Infers the command type from an sql string getting the schema metadata from the database.
        /// </summary>
        /// <param name="sql">The sql string to be analyzed</param>
        public CommandType getCommandType(String sql)
        {
            List<DbParameter> parameters;
            return getCommandType(sql, out parameters);
        }

        internal abstract CommandType getCommandType(String sqlCommand, out List<DbParameter> parameters);

        private EventHandler _afterMove;
        /// <summary>
        /// Handler for AfterMove Event
        /// </summary>
        public EventHandler AfterMove
        {
            get
            {
                return _afterMove;
            }
            set
            {
                _afterMove = value;
            }
        }
        private EventHandler _afterQuery;
        /// <summary>
        /// Handler for After Query Event
        /// </summary>
        public EventHandler AfterQuery
        {
            get
            {
                return _afterQuery;
            }
            set
            {
                _afterQuery = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract void Close();
        /// <summary>
        /// 
        /// </summary>
        public abstract int RecordCount { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract void MoveFirst();
        /// <summary>
        /// 
        /// </summary>
        public abstract bool BOF { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract void MovePrevious();

        /// <summary>
        ///     is end of file
        /// </summary>
        internal bool _eof = true;
        /// <summary>
        ///     Gets a bool value indicating if the current record is the last one in the RecordsetHelper object.
        /// </summary>
        public bool EOF
        {
            get
            {
                return _eof;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract void AddNew();
        /// <summary>
        /// 
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// 
        /// </summary>
        public abstract void MoveLast();
        /// <summary>
        /// 
        /// </summary>
        public abstract void MoveNext();
        /// <summary>
        /// 
        /// </summary>
        public abstract bool CanMovePrevious { get; }
        /// <summary>
        /// 
        /// </summary>
        public abstract void Requery();
        /// <summary>
        /// actual index
        /// </summary>
        internal int _index = -1;
        /// <summary>
        /// Gets or Sets the current Record position inside the RecordsetHelper.
        /// </summary>
        public int CurrentPosition
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract DataRow CurrentRow { get; }

        /// <summary>
        /// Pointer to CurrentRecordset when there are multiple recordset request or response;
        /// </summary>
        public abstract int CurrentRecordSet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Open();
        /// <summary>
        /// 
        /// </summary>
        public abstract bool CanMoveNext { get; }

        /// <summary>
        ///     actual object source
        /// </summary>
        internal Object _source;
        /// <summary>
        ///     Sets or gets the source to obtain the necessary queries. Can be DBCommand or String.
        /// </summary>
        public Object Source
        {
            get
            {
                return _source;
            }
            set
            {
                DbCommand command = value as DbCommand;
                if (command != null)
                {
                    if (command.Connection != null && ActiveConnection != command.Connection)
                    {
                        ActiveConnection = command.Connection;
                    }
                    _activeCommand = command;
                }
                else
                {
                    string s = value as string;
                    if (s != null)
                    {
                        List<DbParameter> parameters;
                        CommandType commandType = getCommandType(s, out parameters);
                        _activeCommand = CreateCommand(s, commandType, parameters);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid type for the Source property");
                    }
                }
                _source = value;
            }
        }
        private bool _allowEdit = true;
        /// <summary>
        /// 
        /// </summary>
        public virtual bool AllowEdit
        {
            get
            {
                return _allowEdit;
            }
            set
            {
                _allowEdit = value;
            }
        }

        private bool _allowNew = true;
        /// <summary>
        /// 
        /// </summary>
        public virtual bool AllowNew
        {
            get
            {
                return _allowNew;
            }
            set
            {
                _allowNew = value;
            }
        }

        private bool _allowDelete = true;
        /// <summary>
        /// 
        /// </summary>
        public virtual bool AllowDelete
        {
            get
            {
                return _allowDelete;
            }
            set
            {
                _allowDelete = value;
            }
        }

        /// <summary>
        /// Clone a command
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        protected DbCommand CloneCommand(DbCommand dbCommand)
        {

            DbCommand res = ProviderFactory.CreateCommand();
            if (res != null)
            {
                res.CommandText = dbCommand.CommandText;
                res.CommandTimeout = dbCommand.CommandTimeout;
                res.CommandType = dbCommand.CommandType;
                res.Connection = dbCommand.Connection;
                res.Transaction = dbCommand.Transaction;

                foreach (DbParameter param in dbCommand.Parameters)
                {
                    DbParameter newParam = res.CreateParameter();
                    newParam.DbType = param.DbType;
                    newParam.Direction = param.Direction;
                    newParam.ParameterName = param.ParameterName;
                    newParam.Size = param.Size;
                    newParam.SourceColumn = param.SourceColumn;
                    newParam.SourceColumnNullMapping = param.SourceColumnNullMapping;
                    newParam.SourceVersion = param.SourceVersion;
                    newParam.Value = param.Value;

                    res.Parameters.Add(newParam);
                }

                return res;
            }
            return null;
        }

        /// <summary>
        ///  Send to DB query to compute.
        /// </summary>
        /// <param name="expression">The query to compute</param>
        /// <returns>The value computed</returns>
        protected object ComputeValue(string expression)
        {
            object result;
            using (DbCommand cmd = ActiveConnection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"Select " + expression;
                cmd.Transaction = TransactionManager.GetTransaction(ActiveConnection);
                result = cmd.ExecuteScalar();
            }
            return result;
        }

        /// <summary>
        /// Creates a DBCommand object using de provided parameters.
        /// </summary>
        /// <param name="commandText">A string containing the SQL query.</param>
        /// <param name="commandType">The desire type for the command.</param>
        /// <returns>A new DBCommand object containing the SLQ code received has parameter.</returns>
        public DbCommand CreateCommand(String commandText, CommandType commandType)
        {
            return CreateCommand(commandText, commandType, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected abstract DbCommand CreateCommand(String commandText, CommandType commandType, List<DbParameter> parameters);

        /// <summary>
        /// Creates a Dbparameter obtaining the information from a DataColumn object.
        /// </summary>
        /// <param name="paramName">The name for the parameter.</param>
        /// <param name="dColumn">The DataColumn object to extract the information from.</param>
        /// <returns>A new DBParameter object containing the desired configuration.</returns>
        protected DbParameter CreateParameterFromColumn(string paramName, DataColumn dColumn)
        {
            DbParameter parameter = ProviderFactory.CreateParameter();
            if (parameter != null)
            {
                parameter.ParameterName = paramName;
                parameter.DbType = GetDBType(dColumn.DataType);
                parameter.SourceColumn = dColumn.ColumnName;
                parameter.SourceVersion = DataRowVersion.Current;
                return parameter;
            }
            return null;
        }

        private DatabaseType _dbType;
        /// <summary>
        /// Gets or sets the DatabaseType being use by this object. 
        /// </summary>
        public virtual DatabaseType DatabaseType
        {
            get
            {
                return _dbType;
            }
            set
            {
                _dbType = value;
            }
        }

        private bool _disableEventsWhileDeleting = false;
        /// <summary>
        /// This flag is used to stop the propagation of events while performing a delete.
        /// It was found that deleting a DataRow raised several events on the binding source
        /// and these events update the current row which must remain the same until the update logic is executed
        /// </summary>
        public bool disableEventsWhileDeleting
        {
            get
            {
                return _disableEventsWhileDeleting;
            }
            set
            {
                _disableEventsWhileDeleting = value;
            }
        }

        /// <summary>
        /// Looks for a column with the given name and returns the column index
        /// or -1 if not found
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public int GetColumnIndexByName(String columnName)
        {
            if (UsingView)
            {
                return _currentView.Table.Columns.IndexOf(columnName);
            }
            if (Tables.Count > 0)
            {
                return Tables[0].Columns.IndexOf(columnName);
            }
            return -1;
        }

        /// <summary>
        /// current view
        /// </summary>
        internal DataView _currentView;

        /// <summary>
        /// Property used to determine if the data needs to be get from a dataview or the table directly
        /// </summary>
        protected abstract bool UsingView
        {
            get;
        }

        /// <summary>
        /// Gets a value that indicates whether the named column contains a null value.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        /// <returns>true if the column contains a null value; otherwise, false.</returns>
        public bool IsNull(string columnName)
        {
            if (CurrentRow == null)
            {
                throw new InvalidOperationException("No current row selected.");
            }
            return CurrentRow.IsNull(columnName);
        }

        private static bool _loadSchema = true;
        /// <summary>
        /// This is property is used when the record set uses more than one table,
        /// uses CommandBuilder, primary keys or, any other metadata information.
        /// </summary>
        public static bool LoadSchema
        {
            get
            {
                return _loadSchema;
            }
            set
            {
                _loadSchema = value;
            }
        }

        private bool _loadSchemaOnly;
        /// <summary>
        /// Used to signal to load only the schema and not fill any data, useful to retrieve meta information
        /// </summary>
        public bool LoadSchemaOnly
        {
            get
            {
                return _loadSchemaOnly;
            }
            set
            {
                _loadSchemaOnly = value;
            }
        }

        /// <summary>
        /// Sets the AfterMove EventHandler.
        /// </summary>
        internal void OnAfterMove()
        {
            if (AfterMove != null)
            {
                AfterMove(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Sets the AfterQuery eventHandler.
        /// </summary>
        internal void OnAfterQuery()
        {
            if (AfterQuery != null)
            {
                AfterQuery(this, new EventArgs());
            }
        }

        /// <summary>
        /// active command
        /// </summary>
        internal DbCommand _activeCommand;

        /// <summary>
        /// Returns a copy of the current ActiveCommand of this RecordsetHelper.
        /// </summary>
        /// <returns>A copy of the current ActiveCommand.</returns>
        public DbCommand CopySourceCommand()
        {
            if (_opened)
            {
                DbCommand result = ActiveConnection.CreateCommand();
                result.CommandText = _activeCommand.CommandText;
                result.CommandType = _activeCommand.CommandType;
                DbParameter[] paramArray = new DbParameter[_activeCommand.Parameters.Count];
                _activeCommand.Parameters.CopyTo(paramArray, 0);
                result.Parameters.AddRange(paramArray);
                return result;
            }
            throw new InvalidOperationException("The recordSet has to be opened to perform this operation");
        }

        /// <summary>
        /// new row state
        /// </summary>
        internal bool _newRow;
        /// <summary>
        /// Cancels any changes made to the current or new row of a ADORecordsetHelper object.
        /// </summary>
        internal void DoCancelUpdate()
        {
            DataRow theRow = CurrentRow;
            if (theRow.RowState != DataRowState.Unchanged)
            {
                theRow.RejectChanges();
                if (theRow.RowState == DataRowState.Detached && RecordCount > 0)
                {
                    _index = 0;
                }
            }
            _newRow = false;
        }

        /// <summary>
        /// Analyzes an SQL Query and obtain the name of the table.
        /// </summary>
        /// <param name="sqlSelectQuery">The SQL query containing the name of the table.</param>
        /// <param name="useParam"> When use the first table name in the query, by default is false.</param>
        /// <returns>The SQL query containing the name of the table.</returns>
        protected string getTableName(string sqlSelectQuery, bool useParam)
        {
            String query = _activeCommand.CommandText;
            if (!string.IsNullOrEmpty(query))
            {
                if (_activeCommand.CommandType == CommandType.Text)
                {
                    Match mtch;
                    if (useParam)
                        mtch = Regex.Match(query.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' '), @"FROM\s+([^ ,]+)(?:\s*,\s*([^ ,]+))*\s+", RegexOptions.IgnoreCase);
                    else
                        mtch = Regex.Match(query.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' '), @"^.+[ \t]+FROM[ \t]+(\w+)[ \t]*.*$", RegexOptions.IgnoreCase);

                    if (mtch != Match.Empty)
                    {
                        return mtch.Groups[1].Value.Trim();
                    }
                    if (useParam)
                    {
                        mtch = Regex.Match(query.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' '), @"^.+[ \t]+FROM[ \t]+(\w+)[ \t]*.*$", RegexOptions.IgnoreCase);
                        if (mtch != Match.Empty)
                            return mtch.Groups[1].Value.Trim();
                    }
                }
                else if (_activeCommand.CommandType == CommandType.TableDirect)
                {
                    return query;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Analyzes an SQL Query and obtain the name of the table.
        /// </summary>
        /// <param name="sqlSelectQuery">The SQL query containing the name of the table.</param>
        /// 
        /// <returns>The SQL query containing the name of the table.</returns>
        protected string getTableName(string sqlSelectQuery)
        {
            return getTableName(sqlSelectQuery, false);
        }

        #region static methods

        /// <summary>
        ///     Converts from System.Type to DbType.
        /// </summary>
        /// <param name="type">The System.Type to be converted.</param>
        /// <returns>The equivalent DBType.</returns>
        public static DbType GetDBType(Type type)
        {
            DbType result = DbType.String;
            switch (type.Name)
            {
                case "Byte":
                    result = DbType.Byte;
                    break;
                case "Byte[]":
                    result = DbType.Binary;
                    break;
                case "Boolean":
                    result = DbType.Boolean;
                    break;
                case "DateTime":
                    result = DbType.DateTime;
                    break;
                case "Decimal":
                    result = DbType.Decimal;
                    break;
                case "Double":
                    result = DbType.Double;
                    break;
                case "Guid":
                    result = DbType.Guid;
                    break;
                case "Int16":
                    result = DbType.Int16;
                    break;
                case "Int32":
                    result = DbType.Int32;
                    break;
                case "Int64":
                    result = DbType.Int64;
                    break;
                case "Object":
                    result = DbType.Object;
                    break;
                case "SByte":
                    result = DbType.SByte;
                    break;
                case "Single":
                    result = DbType.Single;
                    break;
                case "String":
                    result = DbType.String;
                    break;
                case "UInt16":
                    result = DbType.UInt16;
                    break;
                case "UInt32":
                    result = DbType.UInt32;
                    break;
                case "UInt64":
                    result = DbType.UInt64;
                    break;
            }

            return result;
        }

        /// <summary>
        ///     Turns the DB type string to corresponding CLR type string.
        /// </summary>
        /// <param name="strDbType"></param>
        /// <returns></returns>
        public static DbType MapToDbType(string strDbType)
        {
            switch (strDbType)
            {
                case "xml":
                    return DbType.Xml;

                case "nvarchar":
                case "varchar":
                case "sysname":
                case "nchar":
                case "char":
                case "ntext":
                case "text":
                    return DbType.String;

                case "int":
                    return DbType.Int32;

                case "bigint":
                    return DbType.Int64;

                case "bit":
                    return DbType.Boolean;

                case "long":
                    return DbType.Int32;

                case "real":
                case "float":
                    return DbType.Double;

                case "datetime":
                case "datetime2":
                case "date":
                    return DbType.DateTime;

                case "datetimeoffset":
                    return DbType.DateTimeOffset;

                case "time":
                case "timespan":
                    return DbType.Time;

                case "tinyint":
                    return DbType.Byte;

                case "smallint":
                    return DbType.Int16;

                case "uniqueidentifier":
                    return DbType.Guid;

                case "numeric":
                case "decimal":
                    return DbType.Decimal;

                case "binary":
                case "image":
                case "varbinary":
                    return DbType.Binary;

                case "sql_variant":
                    return DbType.Object;
            }
            throw new ArgumentException("Given DB type does not map to any known types.", "strDbType");
        }

        /// <summary>
        ///     Verifies if a parameter with the provided name exists on the command received, otherwise a new parameter using the specified name.
        /// </summary>
        /// <param name="command">The command object to look into.</param>
        /// <param name="name">The name of the parameter to look for.</param>
        /// <returns>The parameter named with “name”.</returns>
        public static DbParameter commandParameterBinding(DbCommand command, string name)
        {
            if (!command.Parameters.Contains(name))
            {
                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = name;
                command.Parameters.Add(parameter);
            }
            return command.Parameters[name];
        }

        #endregion

    }
}
