using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml;
using UpgradeHelpers.DB.ADO.Events;

namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    ///     Support class for the ADO.Recorset the object that represents the records in a base table or the records that result from running a query.
    /// </summary>
    [Serializable]
    public class ADORecordSetHelper : RecordSetHelper, ISerializable
    {
        #region Class Variables

        #region Events declarations

        /// <summary>Occurs when EOF/BOF hit.</summary>
        public event EndOfRecordsetEventHandler EndOfRecordset;

        /// <summary>Occurs before a field change.</summary>
        public event FieldChangeEventHandler WillChangeField;

        /// <summary>Occurs after a field change.</summary>
        public event FieldChangeCompleteEventHandler FieldChangeComplete;

        /// <summary>Occurs before a record change.</summary>
        public event RecordChangeEventHandler WillChangeRecord;

        /// <summary>Occurs after a record change.</summary>
        public event RecordChangeCompleteEventHandler RecordChangeComplete;

        /// <summary>Occurs before a recordset change.</summary>
        public event RecordSetChangeEventHandler WillChangeRecordset;

        /// <summary>Occurs after a recordset change.</summary>
        public event RecordSetChangeCompleteEventHandler RecordsetChangeComplete;

        /// <summary>Occurs before a different row becomes the current row.</summary>
        public event MoveEventHandler WillMove;

        /// <summary>Occurs after a row becomes the current row.</summary>
        public event MoveCompleteEventHandler MoveComplete;

        #endregion

        private const string TITLE_DIALOG_RecordSetError = "RecordSet error";
        private const string NotAllowedOperation = "Operation is not allowed when the object is closed.";

        private DbConnection _activeConnection;

        /// <summary>
        ///     auto increment column name
        /// </summary>
        private string _autoIncrementCol = String.Empty;

        /// <summary>
        /// </summary>
        private bool _cachingAdapter;

        private Queue<DbCommand> _commands;

        /// <summary>
        ///     actual Connection State
        /// </summary>
        private ConnectionState _connectionStateAtEntry = ConnectionState.Closed;

        /// <summary>
        ///     Connection String
        /// </summary>
        private String _connectionString = string.Empty;


        private CursorLocationEnum _cursorLocation = CursorLocationEnum.adUseClient;
        private CursorTypeEnum _cursorType = CursorTypeEnum.adOpenUnspecified;

        private Dictionary<KeyValuePair<DbConnection, string>, DbDataAdapter> _dataAdaptersCached =
            new Dictionary<KeyValuePair<DbConnection, string>, DbDataAdapter>();

        /// <summary>
        ///     New Datarow view when adding to a sorted or filtered collection
        /// </summary>
        private DataRowView _dbvRow;

        private List<KeyValuePair<bool, object>> _defaultValues;

        /// <summary>
        ///     Internal variable added to indicate that the recordset is disconnected
        /// </summary>
        private bool _disconnected;

        private EditModeEnum _editMode = EditModeEnum.EditNone;

        /// <summary>
        ///     is filtered?
        /// </summary>
        private bool _filtered;

        /// <summary>
        ///     is first change?
        /// </summary>
        private bool _firstChange = true;

        /// <summary>
        ///     has auto increment columns
        /// </summary>
        protected bool _hasAutoincrementCols = false;

        /// <summary>
        ///     Flag that indicates if the current recordset is a cloned one
        /// </summary>
        private bool _isClone;

        /// <summary>
        ///     has auto increment columns
        /// </summary>
        private bool _isDefaultSerializationInProgress = true;

        /// <summary>
        ///     is deserilized
        /// </summary>
        protected bool _isDeserialized;

        private LockTypeEnum _lockType = LockTypeEnum.LockOptimistic;

        /// <summary>
        ///     operation finished state
        /// </summary>
        protected bool _operationFinished;

        /// <summary>
        ///     page size
        /// </summary>
        private int _pagesize;

        private bool _requiresDefaultValues;
        private String _sort = "";

        private String _sqlDeleteQuery;
        /// <summary>
        ///     string for delete query
        /// </summary>
        public String SqlDeleteQuery
        {
            get
            {
                return _sqlDeleteQuery;
            }
            set
            {
                _sqlDeleteQuery = value;
            }
        }

        private String _sqlInsertQuery;
        /// <summary>
        ///     string for insert query
        /// </summary>
        public String SqlInsertQuery
        {
            get
            {
                return _sqlInsertQuery;
            }
            set
            {
                _sqlInsertQuery = value;
            }
        }

        /// <summary>
        ///     string for select query
        /// </summary>
        public String SqlSelectQuery
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


        private String _sqlUpdateQuery;
        /// <summary>
        ///     string for update query
        /// </summary>
        public String SqlUpdateQuery
        {
            get
            {
                return _sqlUpdateQuery;
            }
            set
            {
                _sqlUpdateQuery = value;
            }
        }


        private ConnectionState _state = ConnectionState.Closed;
        internal Hashtable SerializationInfo;

        #endregion

        #region paging

        /// <summary>
        ///     actual filter object
        /// </summary>
        protected object filter;

        /// <summary>
        ///     Gets/Sets the number of rows per page.
        /// </summary>
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        /// <summary>
        ///     Gets the number of pages.
        /// </summary>
        public int PageCount
        {
            get
            {
                int pageCount = 0;
                if (Opened)
                {
                    if (PageSize == 0)
                    {
                        pageCount = 0;
                    }
                    pageCount = (int)Math.Ceiling(RecordCount / (float)PageSize);
                }
                return pageCount;
            }
        }

        #endregion

        #region  properties

        /// <summary>
        ///     This flag is used to stop the propagation of events while performing a delete.
        ///     It was found that deleting a DataRow raised several events on the binding source
        ///     and these events update the current row which must remain the same until the update logic is executed
        /// </summary>
        internal bool DisableEventsWhileDeleting = false;

        private int _currentRecordSet = 0;
        /// <summary>
        /// Pointer to current recordset data table
        /// </summary>
        public override int CurrentRecordSet
        {
            get
            {
                return _currentRecordSet;
            }
            set
            {
                _currentRecordSet = value;
            }
        }

        /// <summary>
        ///     Gets a DataRow with the information of the current record on the RecordsetHelper.
        /// </summary>
        public override DataRow CurrentRow
        {
            get
            {
                DataRow theRow = null;
                if (UsingView)
                {
                    _dbvRow = _currentView[_index];
                    theRow = _dbvRow.Row;
                }
                else
                {
                    if (_index >= 0 && Tables.Count > 0 &&_index  < Tables[CurrentRecordSet].Rows.Count)
                    {
                        theRow = Tables[CurrentRecordSet].Rows[_index];
                    }
                }
                return theRow;
            }
        }

        /// <summary>
        ///     Gets or sets the connection string being use by this RecordsetHelper object.
        /// </summary>
        public override String ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                if (_providerFactory != null && _connectionString.Length > 0)
                {
                    try
                    {
                        Validate();
#if DBTrace
                        DbConnection connection = DBTrace.CreateConnectionWithTrace(providerFactory);
#else
                        DbConnection connection = _providerFactory.CreateConnection();
#endif
                        Debug.Assert(connection != null, "connection != null");
                        connection.ConnectionString = value;
                        ActiveConnection = connection;
#if DBTrace
                        DBTrace.OpenWithTrace(ActiveConnection);
#else
                        ActiveConnection.Open();
#endif
                    } // try
                    catch (Exception ex)
                    {
                        String message = string.Format(
                            "Problem while trying to set the active connection. Please verify ConnectionString {0} and Factory {1} settings. Error details {2}",
                            _connectionString,
                            _providerFactory,
                            ex.Message);
#if WINFORMS
                        if (Process.GetCurrentProcess().ProcessName == "devenv")
						{
							System.Windows.Forms.MessageBox.Show(message,TITLE_DIALOG_RecordSetError);
						} // if
#else
                        Trace.TraceError(message);
#endif
                        if (!_disconnected)
                            throw;
                    } // catch
                }
                else
                {
                    _activeConnection = null;
                }
                _defaultValues = null;
            }
        }

        /// <summary>
        ///     Return true if the recordsethelper is caching the adapters
        /// </summary>
        public bool IsCachingAdapter
        {
            get { return _cachingAdapter; }
        }

        /// <summary>
        ///     Property to indicate the editing status of the current record
        /// </summary>
        public EditModeEnum EditMode
        {
            get
            {
                return _editMode;
            }
        }

        /// <summary>
        ///     Property to handle the Status of the recordset
        /// </summary>
        public DataRowState Status
        {
            get
            {
                DataRowState state = DataRowState.Unchanged;
                if (FieldsValues != null)
                {
                    state = FieldsValues.RowState;
                }
                return state;
            }
        }

        /// <summary>
        ///     Gets a DataRow object containing the field values of the current record.
        /// </summary>
        public DataRow FieldsValues
        {
            get
            {
                DataRow row = null;
                if (UsingView)
                {
                    if (_currentView != null && _index >= 0)
                    {
                        row = _currentView[_index].Row;
                    }
                }
                else
                {
                    if (Tables.Count > 0 && _index >= 0)
                    {
                        row = Tables[CurrentRecordSet].Rows[_index];
                    }
                }
                return row;
            }
        }

        /// <summary>
        ///     Property used to determine if the data needs to be get from a dataview or the table directly
        /// </summary>
        protected override bool UsingView
        {
            get { return _filtered || !String.IsNullOrEmpty(_sort) || _isClone; }
        }

        /// <summary>
        ///     Gets the current total number of records on the RecordsetHelper.
        /// </summary>
        public override int RecordCount
        {
            get
            {
                int count = 0;
                if (Opened)
                {
                    count = Tables[CurrentRecordSet].DefaultView.Count;
                }
                return count;
            }
        }

        /// <summary>
        ///     Property to get and set the order of the recordset
        /// </summary>
        public String Sort
        {
            get { return _sort; }
            set
            {
                if (_isDefaultSerializationInProgress) return;
                _sort = value;
                if (_sort.Length > 0 && Tables.Count > 0)
                {
                    _currentView = _currentView == null ? Tables[CurrentRecordSet].DefaultView : _currentView;
                    _currentView.Sort = _sort;
                    if (_opened)
                    {
                        MoveFirst(EventReasonEnum.adRsnRequery);
                    }
                }
            }
        }

        /// <summary>
        ///     Property to handle the state of the recordset
        /// </summary>
        public ConnectionState State
        {
            //Changes for remove memory leak
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        ///     This is an override to wire the event necesary to handle the proper state of the recordset
        /// </summary>
        public override DbConnection ActiveConnection
        {
            get { return _activeConnection; }
            set
            {
                //base.ActiveConnection = value;
                if (_activeCommand != null)
                {
                    _activeCommand.Connection = value;
                }
                _activeConnection = value;

                //Validate provider 
                ValidateProvider();

                _connectionString = ActiveConnection != null ? ActiveConnection.ConnectionString : String.Empty;
                _connectionStateAtEntry = ActiveConnection != null ? ActiveConnection.State : ConnectionState.Closed;
                // end of base class setter

            }
        }

        /// <summary>
        ///     Returns a value that indicates whether the current record position is before the first record in an ADORecordsetHelper object. Read-only Boolean.
        /// </summary>
        public override bool BOF
        {
            get
            {
                bool bof = true;
                if (Opened)
                {
                    if (UsingView)
                        bof = _index < 0 || _currentView.Count == 0;
                    else if (Tables.Count > 0)
                        bof = _index < 0 || Tables[CurrentRecordSet].Rows.Count == 0;
                }
                return bof;
            }
        }

        /// <summary>
        ///     Sets the Filter to by applied to the this ADORecordsetHelper. (valid objects are: string, DataViewRowState and DataRow[]).
        /// </summary>
        public Object Filter
        {
            get { return filter; }
            set
            {
                //base.Filter = value;
                //base class setter

                filter = value;
                _filtered = _opened && filter != null && !String.IsNullOrEmpty(filter.ToString());
                if (_opened)
                {
                    string s = filter as string;
                    if (s != null)
                    {
                        SetFilter(s);
                    }
                    else if (filter is DataViewRowState)
                    {
                        SetFilter((DataViewRowState)filter);
                    }
                    else
                    {
                        DataRow[] rows = filter as DataRow[];
                        if (rows != null)
                        {
                            SetFilter(rows);
                        }
                        else
                        {
                            throw new ArgumentException("Filter value not allowed");
                        }
                    }
                }

                // end of base class setter

                if (_opened)
                {
                    //First reset the index and eof
                    //When the user filters, the current row goes to the
                    //first row if there is one.
                    //Also there might be no rows at all.
                    //AIS-TODO try not setting index to -1 and not eof
                    _index = -1;
                    _eof = IsEof();
                    if (RecordCount > 0)
                    {
                        MoveFirst(EventReasonEnum.adRsnRequery);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets/Sets the LockType for this object.
        /// </summary>
        public LockTypeEnum LockType
        {
            get { return _lockType; }
            set { _lockType = value; }
        }

        /// <summary>
        ///     Gets/Sets the CursorType for this object.
        /// </summary>
        public CursorTypeEnum CursorType
        {
            get { return _cursorType; }
            set { _cursorType = value; }
        }

        /// <summary>
        ///     Gets/Sets the CursorLocation for this object.
        /// </summary>
        public CursorLocationEnum CursorLocation
        {
            get { return _cursorLocation; }
            set { _cursorLocation = value; }
        }


        /// <summary>
        ///     Gets and Sets the position of the current record on the recordset instance.
        /// </summary>
        public int AbsolutePosition
        {
            get
            {
                int absolutePosition = 0;
                if (Opened)
                {
                    absolutePosition = _index + 1;
                }
                return absolutePosition;
            }
            set
            {
                BasicMove(value - 1, EventReasonEnum.adRsnMove);
            }
        }

        /// <summary>
        ///     Gets the specified version of the column.
        /// </summary>
        /// <param name="columnName">Name of the column to look for.</param>
        /// <param name="rowVersion">The version of the row.</param>
        /// <returns>The value at the given index.</returns>
        public virtual Object this[String columnName, DataRowVersion rowVersion]
        {
            get
            {
                if (CurrentRow.HasVersion(rowVersion))
                    return CurrentRow[columnName, rowVersion];
                else if (rowVersion == DataRowVersion.Original && CurrentRow.RowState == DataRowState.Added)
                    return DBNull.Value;
                else
                    return CurrentRow[columnName];
            }
        }

        /// <summary>
        ///     Gets the specified version of the column.
        /// </summary>
        /// <param name="columnIndex">Index of the column to look for.</param>
        /// <param name="rowVersion">The version of the row.</param>
        /// <returns>The value at the given index.</returns>
        public virtual Object this[int columnIndex, DataRowVersion rowVersion]
        {
            get
            {
                if (CurrentRow.HasVersion(rowVersion))
                    return CurrentRow[columnIndex, rowVersion];
                else
                    return CurrentRow[columnIndex];
            }
        }


        /// <summary>
        ///     Array access by column name to set the object
        /// </summary>
        /// <param name="columnName">string column name</param>
        /// <returns>object</returns>
        public Object this[String columnName]
        {
            get { return CurrentRow[columnName]; }
            set
            {
                //base[columnName] = value;
                //base class definition
                int columnIndex = GetColumnIndexByName(columnName);
                if (columnIndex > -1)
                {
                    SetNewValue(columnIndex, value);
                }
                else
                {
                    throw new Exception(string.Format("Column {0} not found", columnName));
                }

                //end of base class definition

                if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
                {
                    _editMode = EditModeEnum.EditInProgress;
                }
                _firstChange = !_firstChange && _firstChange;
            }
        }

        /// <summary>
        ///     Array access by index
        /// </summary>
        /// <param name="columnIndex">index value</param>
        /// <returns>object</returns>
        public Object this[int columnIndex]
        {
            get { return CurrentRow[columnIndex]; }
            set
            {
                //base[columnIndex] = value;
                SetNewValue(columnIndex, value);

                if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
                {
                    _editMode = EditModeEnum.EditInProgress;
                }
                _firstChange = !_firstChange && _firstChange;
            }
        }

        /// <summary>
        ///     Sets a bookmark to an specific record inside the ADORecordsetHelper.
        /// </summary>
        public DataRow Bookmark
        {
            set
            {
                if (Opened)
                {
                    _index = findBookmarkIndex(value);
                    if (_index >= 0) BasicMove(_index, EventReasonEnum.adRsnMove);

                    EventStatusEnum status = EventStatusEnum.adStatusOK;
                    OnWillMove(EventReasonEnum.adRsnMove, ref status);
                    string[] errors = null;
                    try
                    {
                        if (!isBatchEnabled())
                            Update();
                    }
                    catch (Exception e)
                    {
                        errors = new string[] { e.Message };
                    }
                    OnMoveComplete(EventReasonEnum.adRsnMove, ref status, errors);
                }
            }
            get
            {
                if (Opened)
                {
                    return UsingView ? _currentView[_index].Row : Tables[CurrentRecordSet].Rows[_index];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets/Sets the current page number.
        /// </summary>
        public int AbsolutePage
        {
            get
            {
                if (_isDefaultSerializationInProgress) return 0;
                if (Opened)
                {
                    EventStatusEnum status = EventStatusEnum.adStatusOK;
                    OnWillMove(EventReasonEnum.adRsnMove, ref status);
                    OnMoveComplete(EventReasonEnum.adRsnMove, ref status, null);
                    if (BOF)
                    {
                        return (int)PositionEnum.adPosBOF;
                    }
                    if (EOF)
                    {
                        return (int)PositionEnum.adPosEOF;
                    }
                    if (PageSize != 0)
                    {
                        return (int)Math.Ceiling((double)AbsolutePosition / PageSize);
                    }
                }
                return 0;
            }
            set
            {
                if (_isDefaultSerializationInProgress) return;
                if (!Opened)
                {
                    throw new InvalidOperationException(NotAllowedOperation);
                }
                if (value > 0)
                {
                    _index = (value - 1) * PageSize;
                }
            }
        }

        /// <summary>
        /// </summary>
        public object DataSource
        {
            get
            {
                object result = null;
                if (State != ConnectionState.Closed)
                {
                    if (UsingView)
                    {
                        result = _currentView;
                    }
                    else
                    {
                        result = Tables[CurrentRecordSet].DefaultView;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// </summary>
        public String DataMember
        {
            get
            {
                string result = string.Empty;
                if (State != ConnectionState.Closed)
                {
                    result = UsingView ? _currentView.Table.TableName : Tables[CurrentRecordSet].TableName;
                }
                return result;
            }
        }

        /// <summary>
        ///     Gets a DataColumnCollection object that contains the information of all columns on the RecordsetHelper.
        /// </summary>
        public DataColumnCollection FieldsMetadata
        {
            get
            {
                if (UsingView)
                {
                    return _currentView.Table.Columns;
                }
                if (Tables.Count <= 0)
                {
                    Tables.Add();
                }
                return Tables[CurrentRecordSet].Columns;
            }
        }

        /// <summary>
        ///     Sets the filter for the RecordsetHelper.
        /// </summary>
        /// <param name="filter">The filter to apply to this RecordsetHelper.</param>
        protected void SetFilter(String filter)
        {
            try
            {
                _currentView.RowFilter = filter;
            }
            catch (EvaluateException)
            {
            }
        }

        /// <summary>
        ///     Sets the filter for the RecordsetHelper.
        /// </summary>
        /// <param name="filter">The filter to apply to this RecordsetHelper.</param>
        protected virtual void SetFilter(DataRow[] filter)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Sets the filter for the RecordsetHelper.
        /// </summary>
        /// <param name="filter">The filter to apply to this RecordsetHelper.</param>
        protected virtual void SetFilter(DataViewRowState filter)
        {
            _currentView.RowStateFilter = filter;
        }

        /// <summary>
        ///     Returns the table according to the status View/Table of the RecordSet
        /// </summary>
        public DataTable GetTable()
        {
            return (UsingView ? _currentView.Table : Tables[CurrentRecordSet]);
        }

        /// <summary>
        ///     Makes sure that the current ADO.NET provider is set
        ///     and if it is compatible with the current
        /// </summary>
        private void ValidateProvider()
        {
            if (_activeConnection == null) return;
            if (_providerFactory != null)
            {
                Debug.Assert(
                    _providerFactory.GetType().Namespace
                    == _activeConnection.GetType().Namespace,
                    "The Factory provider does not seem to be compatible with the actual connection");
            }
            else
            {
                string nm = _activeConnection.GetType().Namespace;
                _providerFactory = DbProviderFactories.GetFactory(nm);
            }
        }

        /// <summary>
        ///     Loads the schema of the ADORecordSetHelper
        /// </summary>
        public void FillSchema()
        {
            using (DbDataAdapter dbAdapter = CreateAdapter(ActiveConnection, false))
            {
                DataTable schema = new DataTable("schema");
                dbAdapter.FillSchema(schema, SchemaType.Source);
                Tables.Add(schema);
            }
        }

        /// <summary>
        ///     Finds the index in the RecordsetHelper for the “value”.
        /// </summary>
        /// <param name="value">The DataRow to look for.</param>
        /// <returns>The index number if is found, otherwise -1.</returns>
        protected int findBookmarkIndex(DataRow value)
        {
            if (!UsingView)
            {
                return Tables[CurrentRecordSet].Rows.IndexOf(value);
            }
            int result = -1;
            for (int i = 0; i < _currentView.Count; i++)
            {
                if (_currentView[i].Row == value)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        #endregion

        #region constructors

        /// <summary>
        ///     Creates a new ADORecordsetHelper instance using the default factory specified on the configuration xml.
        /// </summary>
        public ADORecordSetHelper()
        {
            _isDefaultSerializationInProgress = false;
            _index = -1;
            _newRow = false;
            ProviderFactory = AdoFactoryManager.GetFactory("");
            DatabaseType = AdoFactoryManager.GetFactoryDbType(AdoFactoryManager.Default.Name);
        }


        private string _factoryName = "";

        /// <summary>
        ///     Creates a new ADORecordsetHelper
        /// </summary>
        /// <param name="factory"></param>
        protected ADORecordSetHelper(DbProviderFactory factory)
        {
            _isDefaultSerializationInProgress = false;
            _providerFactory = factory;
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper instance using the factory specified on the “factoryName” parameter.
        /// </summary>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        public ADORecordSetHelper(String factoryName)
            : this(AdoFactoryManager.GetFactory(factoryName))
        {
            if (string.IsNullOrEmpty(factoryName))
            {
                _factoryName = AdoFactoryManager.Default.Name;
            }
            else
            {
                _factoryName = factoryName;
            }
            DatabaseType = AdoFactoryManager.GetFactoryDbType(_factoryName);
            _isDefaultSerializationInProgress = false;
            _index = -1;
            _newRow = false;
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper instance using provided parameters.
        /// </summary>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        /// <param name="connString">The connection string to be used by this ADORecordsetHelper.</param>
        public ADORecordSetHelper(String factoryName, String connString)
            : this(factoryName)
        {
            _isDefaultSerializationInProgress = false;
            _connectionString = connString;
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper instance using provided parameters.
        /// </summary>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        /// <param name="connString">The connection string to be used by this ADORecordsetHelper.</param>
        /// <param name="sqlSelectString">A string containing the SQL Query to be loaded on the ADORecordsetHelper.</param>
        public ADORecordSetHelper(String factoryName, String connString, String sqlSelectString)
            : this(factoryName, connString)
        {
            _isDefaultSerializationInProgress = false;
            SqlSelectQuery = sqlSelectString;
            Open();
        }

        #endregion

        #region Serialization machinery

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo, all the data needed to load and store an object.</param>
        /// <param name="context">
        ///     System.Runtime.Serialization.StreamingContext, describes the source and destination of
        ///     a given serialized stream , and provides an additional caller-defined context.
        /// </param>
        protected ADORecordSetHelper(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Sort = info.GetString("Sort");
            LockType = (LockTypeEnum)info.GetInt32("LockType");
            _connectionString = info.GetString("ConnectionString");
            _index = info.GetInt16("Index");
            _factoryName = info.GetString("Factory");
            _newRow = info.GetBoolean("NewRow");
            _currentRecordSet = info.GetInt32("CurrentRecordSet");
            _eof = info.GetBoolean("Eof");
					            if (Tables.Count > 0)
            {
                _currentView = Tables[CurrentRecordSet].DefaultView;
            }
        }

        /// <summary>
        ///     Gets Object Data
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Sort", Sort);
            info.AddValue("LockType", (int)LockType);
            info.AddValue("ConnectionString", _connectionString);
            info.AddValue("Index", _index);
            info.AddValue("Factory", _factoryName);
            info.AddValue("NewRow", _newRow);
            info.AddValue("CurrentRecordSet", _currentRecordSet);
            info.AddValue("Eof", _eof);
        }

        #endregion

        #region Open Operations

        /// <summary>
        ///     Performs a check to determine if the recordset is working disconnected
        /// </summary>
        /// <returns></returns>
        private bool SupportsDisconnectedRecordsetOperations
        {
            get
            {
                return (ActiveConnection == null && _activeCommand == null) ||
                       (ActiveConnection == null && _activeCommand != null &&
                        _activeCommand.Connection == null);
            }
        }

        /// <summary>
        ///     Opens the connection and initialize the RecordsetHelper object.
        /// </summary>
        public override void Open()
        {
            try
            {
                Open(false);
            } // try
            catch
            {
#if WINFORMS
                if (Process.GetCurrentProcess().ProcessName == "devenv")
				{
					System.Windows.Forms.MessageBox.Show("There was a problem opening the recordset. Please verify connection string", TITLE_DIALOG_RecordSetError);
				}
#endif
            } // catch
        }


        /// <summary>
        ///     Opens the ADORecordsetHelper and requeries according to the value of “requery” parameter.
        /// </summary>
        /// <param name="requery">Indicates if a requery most be done.</param>
        public void Open(bool requery)
        {
            // This is done to support disconnected recordSet operations.
            if (SupportsDisconnectedRecordsetOperations)
            {
                //According to tests, in VB6 a disconnected recordset changes its state to LockBatchOptimistic when opened
                if (ActiveConnection == null && _activeCommand == null)
                {
                    LockType = LockTypeEnum.LockBatchOptimistic;
                }
            }

            // base.Open(requery);

            if (!requery)
            {
                Validate();
            }
            if (_activeCommand == null && (_source is String))
            {
                List<DbParameter> parameters;
                CommandType commandType = getCommandType((string)_source, out parameters);
                _activeCommand = CreateCommand((string)_source, commandType, parameters);
            }
            if (ActiveConnection == null && _activeCommand != null)
            {
                if (_activeCommand.Connection == null)
                    _activeCommand.Connection = GetConnection(ConnectionString);
                ActiveConnection = _activeCommand.Connection;
            }

            OpenRecordset(requery);
        }

        /// <summary>
        ///     Opens the ADORecordsetHelper using an object Source.
        /// </summary>
        /// <param name="source">An object containing a Source of Data. It can be a DataSet, another ADORecordSetHelper or a string path.</param>
        public void Open(object source)
        {
            if (source is DataTable)
            {
                Tables.Clear();
                Tables.Add((DataTable)source);
                ResetVars();
            }
            else if (source is ADORecordSetHelper)
            {
                CloneIt((ADORecordSetHelper)source, this);
            }
            else if (source == null)
            {
                Tables.Clear();
                Tables.Add(new DataTable());
                ResetVars();
            
            }
            else if (source is string)
            {
                Tables.Clear();
                this.ReadXml((string)source, XmlReadMode.InferSchema);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Creates a DBCommand object using de provided parameters.
        /// </summary>
        /// <param name="commandText">A string containing the SQL query.</param>
        /// <param name="commandType">The desire type for the command.</param>
        /// <param name="parameters">A list with the parameters to be included on the DBCommand object.</param>
        /// <returns>A new DBCommand object.</returns>
        protected override DbCommand CreateCommand(String commandText, CommandType commandType, List<DbParameter> parameters)
        {
            Debug.Assert(_providerFactory != null, "Providerfactory must not be null");
            DbCommand command = _providerFactory.CreateCommand();
            switch (commandType)
            {
                case CommandType.StoredProcedure:
                    string[] commandParts = commandText.Split(' ', ',');
                    if (command != null)
                    {
                        command.CommandType = commandType;
                        command.CommandText = commandParts[0];
                        if (parameters != null && (parameters.Count == commandParts.Length - 1))
                        {
                            for (int i = 1; i < commandParts.Length; i++)
                            {
                                DbParameter parameter = parameters[i - 1];
                                object value = commandParts[i];
                                //conversions might be needed for various types
                                //currently there is only a convertion for Guid types. New convertions will be added as needed
                                if (parameter.DbType == DbType.Guid)
                                {
                                    //Remove single quotes if present to avoid exception in Guid constructor
                                    string strValue = commandParts[i].Replace("'", "");
                                    value = new Guid(strValue);
                                }
                                parameter.Value = value;
                            }
                            command.Parameters.AddRange(parameters.ToArray());
                        }
                    }
                    break;
                case CommandType.TableDirect:
                    //ODBC and SQL Client providers do not support table direct commands
                    string providerType = _providerFactory.GetType().ToString();
                    if (providerType.StartsWith("System.Data.Odbc") || providerType.StartsWith("System.Data.SqlClient"))
                    {
                        if (command != null)
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = "Select * from " + commandText;
                        }
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                default:
                    if (command != null)
                    {
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                    }
                    break;
            }
            return command;
        }

        /// <summary>
        ///     Infers the command type from an SQL string getting the schema metadata from the database.
        /// </summary>
        /// <param name="sqlCommand">The sql string to be analyzed.</param>
        /// <param name="parameters">List of DbParameters</param>
        /// <returns>The command type</returns>
        internal override CommandType getCommandType(String sqlCommand, out List<DbParameter> parameters)
        {
            CommandType commandType = CommandType.Text;
            parameters = null;
            sqlCommand = sqlCommand.Trim();
            if (sqlCommand.StartsWith("select", StringComparison.InvariantCultureIgnoreCase) ||
                sqlCommand.StartsWith("insert", StringComparison.InvariantCultureIgnoreCase) ||
                sqlCommand.StartsWith("update", StringComparison.InvariantCultureIgnoreCase) ||
                sqlCommand.StartsWith("delete", StringComparison.InvariantCultureIgnoreCase) ||
                sqlCommand.StartsWith("exec", StringComparison.InvariantCultureIgnoreCase) ||
                sqlCommand.StartsWith("begin", StringComparison.InvariantCultureIgnoreCase) ||
                Regex.IsMatch(sqlCommand, @"^\s*\{\s*call ", RegexOptions.IgnoreCase))
            {
                commandType = CommandType.Text;
                return commandType;
            }
            string[] completeCommandParts = sqlCommand.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            sqlCommand = completeCommandParts[0];
            String[] commandParts = sqlCommand.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            String objectQuery = String.Empty;
            DbConnection connection = GetConnection(_connectionString);
            if (connection.State != ConnectionState.Open)
            {
#if DBTrace
                    DBTrace.OpenWithTrace(connection);
#else
                connection.Open();
#endif
            }
            DataRow[] existingObjects;
            DataTable dbObjects = connection.GetSchema("Tables");
            if (dbObjects.Rows.Count > 0)
            {
                //this is an sql server connection
                if (dbObjects.Columns.Contains("table_catalog") && dbObjects.Columns.Contains("table_schema"))
                {
                    if (commandParts.Length == 3)
                    {
                        objectQuery = "table_catalog = \'" + commandParts[0] + "\' AND table_schema = \'" + commandParts[1] +
                                      "\' AND table_name = \'" + commandParts[2] + "\'";
                    }
                    else if (commandParts.Length == 2)
                    {
                        objectQuery = "table_schema = \'" + commandParts[0] + "\' AND table_name = \'" + commandParts[1] + "\'";
                    }
                    else
                    {
                        objectQuery = "table_name = \'" + commandParts[0] + "\'";
                    }
                }
                else if (dbObjects.Columns.Contains("OWNER"))
                {
                    if (commandParts.Length == 2)
                    {
                        objectQuery = "OWNER = \'" + commandParts[0] + "\' AND TABLE_NAME = \'" + commandParts[1] + "\'";
                    }
                    else
                    {
                        objectQuery = "TABLE_NAME = \'" + commandParts[0] + "\'";
                    }
                }
                existingObjects = dbObjects.Select(objectQuery);
                if (existingObjects.Length > 0)
                {
                    commandType = CommandType.TableDirect;
                    return commandType;
                }
            }
            dbObjects = connection.GetSchema("Procedures");
            // The query for looking for stored procedures information is version sensitive.
            // The database version can be verified in SQLServer using a query like "Select @@version"
            // That version can be mapped to the specific SQL Server Product Version with a table like the provided here: http://www.sqlsecurity.com/FAQs/SQLServerVersionDatabase/tabid/63/Default.aspx 
            // The following code verifies columns for SQL Server version 2003, other versions might have a different schema and require changes
            if (dbObjects.Columns.Contains("procedure_catalog") && dbObjects.Columns.Contains("procedure_schema"))
            {
                if (commandParts.Length == 3)
                {
                    objectQuery = "procedure_catalog = \'" + commandParts[0] + "\' AND procedure_schema = \'" + commandParts[1] +
                                  " AND procedure_name = " + commandParts[2] +
                                  "\'";
                }
                else if (commandParts.Length == 2)
                {
                    objectQuery = "procedure_schema = \'" + commandParts[0] + "\' AND procedure_name = \'" + commandParts[1] + "\'";
                }
                else
                {
                    objectQuery = "procedure_name = \'" + commandParts[0] + "\'";
                }
            }
            else if (dbObjects.Rows.Count > 0)
            {
                //this is an sql server connection
                if (dbObjects.Columns.Contains("specific_catalog") && dbObjects.Columns.Contains("specific_schema"))
                {
                    if (commandParts.Length == 3)
                    {
                        objectQuery = "specific_catalog = \'" + commandParts[0] + "\' AND specific_schema = \'" + commandParts[1] +
                                      " AND specific_name = " + commandParts[2] +
                                      "\'";
                    }
                    else if (commandParts.Length == 2)
                    {
                        objectQuery = "specific_schema = \'" + commandParts[0] + "\' AND specific_name = \'" + commandParts[1] + "\'";
                    }
                    else
                    {
                        objectQuery = "specific_name = \'" + commandParts[0] + "\'";
                    }
                }
                else if (dbObjects.Columns.Contains("OWNER"))
                {
                    if (commandParts.Length == 2)
                    {
                        objectQuery = "OWNER = \'" + commandParts[0] + "\' AND OBJECT_NAME = \'" + commandParts[1] + "\'";
                    }
                    else
                    {
                        objectQuery = "OBJECT_NAME = \'" + commandParts[0] + "\'";
                    }
                }
                existingObjects = dbObjects.Select(objectQuery);
                if (existingObjects.Length > 0)
                {
                    commandType = CommandType.StoredProcedure;
                    if (dbObjects.Columns.Contains("specific_catalog") && dbObjects.Columns.Contains("specific_schema"))
                    {
                        DataTable procedureParameters = connection.GetSchema("ProcedureParameters");
                        DataRow[] theparameters =
                            procedureParameters.Select(
                                "specific_catalog = \'" + existingObjects[0]["specific_catalog"] + "\' AND specific_schema = \'" +
                                existingObjects[0]["specific_schema"] +
                                "' AND specific_name = '" + existingObjects[0]["specific_name"] + "\'",
                                "ordinal_position ASC");
                        if (theparameters.Length > 0)
                        {
                            parameters = new List<DbParameter>(theparameters.Length);
                            foreach (DataRow paraminfo in theparameters)
                            {
                                DbParameter theParameter = _providerFactory.CreateParameter();
#if CLR_AT_LEAST_3_5 
                                    theParameter.ParameterName = paraminfo.Field<string>("parameter_name");
                                    theParameter.DbType = MapToDbType(paraminfo.Field<string>("data_type"));
#else
                                Debug.Assert(theParameter != null, "theParameter != null");
                                theParameter.ParameterName = paraminfo["parameter_name"] as string;
                                theParameter.DbType = MapToDbType(paraminfo["data_type"] as string);
#endif
                                parameters.Add(theParameter);
                            }
                        }
                    }
                }
            }
            return commandType;
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        public void Open(LockTypeEnum lockType)
        {
            Validate();
            _lockType = lockType;
            Open();
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
        public void Open(DbCommand command)
        {
            Open(command, _lockType);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper</param>
        public void Open(DbConnection connection)
        {
            Open(connection, _lockType);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="str">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="type">StringParameterType of the str.</param>
        public void Open(String str, StringParameterType type)
        {
            Validate();
            if (type == StringParameterType.Source)
            {
                if (File.Exists(str))
                {
                    Open(str, PersistFormatEnum.adPersistBinary);
                }
                else
                {
                    List<DbParameter> parameters;
                    CommandType commandType = getCommandType(str, out parameters);
                    Open(CreateCommand(str, commandType, parameters), _lockType);
                }
            }
            else
            {
                Open(GetConnection(str), _lockType);
            }
        }

        /// <summary>
        ///     Open the information on the RecordsetHelper from a file.
        /// </summary>
        /// <param name="fullName">The full path name where to open the file.</param>
        /// <param name="persistFormat">The format type to open the file.</param>
        public void Open(string fullName, PersistFormatEnum persistFormat)
        {
            FileStream fs = new FileStream(fullName, FileMode.Open);
            Close();
            switch (persistFormat)
            {
                case (PersistFormatEnum.adPersistXML):
                    {
                        XmlReader xmlRead = XmlReader.Create(fs);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.ReadNode(xmlRead);
                        break;
                    }
                case (PersistFormatEnum.adPersistBinary):
                    {
                        RemotingFormat = SerializationFormat.Binary;
                        BinaryFormatter binformat = new BinaryFormatter();
                        Tables.Add((DataTable)binformat.Deserialize(fs));
                        Tables[CurrentRecordSet].RemotingFormat = SerializationFormat.Binary;
                        break;
                    }
            }
            ResetVars();
            fs.Close();
        }


        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        public void Open(DbCommand command, LockTypeEnum lockType)
        {
            Validate();
            _source = command;
            _activeCommand = command;
            Open(lockType);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        public void Open(DbConnection connection, LockTypeEnum lockType)
        {
            ActiveConnection = connection;
            Open(lockType);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="str">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        /// <param name="type">StringParameterType of the str.</param>
        public void Open(String str, LockTypeEnum lockType, StringParameterType type)
        {
            Validate();
            if (type == StringParameterType.Source)
            {
                List<DbParameter> parameters;
                CommandType commandType = getCommandType(str, out parameters);
                Open(CreateCommand(str, commandType, parameters), lockType);
            }
            else
            {
                Open(GetConnection(str), lockType);
            }
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        public void Open(String sqLstr, DbConnection connection)
        {
            ActiveConnection = connection;
            List<DbParameter> parameters;
            CommandType commandType = getCommandType(sqLstr, out parameters);
            Open(CreateCommand(sqLstr, commandType, parameters));
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connString">Strings that contains information about how to connect to the database.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        public void Open(String sqLstr, String connString, LockTypeEnum lockType)
        {
            Open(sqLstr, GetConnection(connString), lockType);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connString">Strings that contains information about how to connect to the database.</param>
        public void Open(String sqLstr, String connString)
        {
            Open(sqLstr, connString, LockTypeEnum.LockBatchOptimistic);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        ///     NOTE: It is better to provide the CommandType when executing the command
        ///     If the command type is not given, performance would be affected due to several
        ///     request to the DB schema
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        public void Open(String sqLstr, DbConnection connection, LockTypeEnum lockType)
        {
            ActiveConnection = connection;
            List<DbParameter> parameters;
            CommandType commandType = getCommandType(sqLstr, out parameters);
            Open(sqLstr, connection, lockType, commandType, parameters);
        }

        /// <summary>
        ///     Opens this ADORecordsetHelper using the provided parameters.
        ///     This is the preferred Open method for performance reasons. However this call might required
        ///     some extra parameters like CommandType and ParameterList.
        ///     For most scenerios just provide a null parameter for the parameter list;
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="lockType">The LockTypeEnum of this ADORecordsetHelper object.</param>
        /// <param name="commandType">The CommandType of this ADORecordsetHelper object.</param>
        /// <param name="parameters">The list of parameters.</param>
        public void Open(String sqLstr, DbConnection connection, LockTypeEnum lockType, CommandType commandType,
                         List<DbParameter> parameters)
        {
            // A RecordSet can be openned with a series of staments separated by ;. However each type an open is done, this collection is reseted */
            _commands = null;
            ActiveConnection = connection;
            Open(CreateCommand(sqLstr, commandType, parameters), lockType);
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="recordsAffected">Out parameter indicating the amount of records affected by the execution of the “SQLstr” query.</param>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        /// <returns>The new ADORecordsetHelper object.</returns>
        public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, out long recordsAffected,
                                              String factoryName)
        {
            ADORecordSetHelper result = new ADORecordSetHelper(factoryName);
            result.Open(sqLstr, connection);
            recordsAffected = result.RecordCount;
            return result;
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        /// <returns>The new ADORecordsetHelper object.</returns>
        public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, String factoryName)
        {
            long recordsAffected;
            return Open(sqLstr, connection, out recordsAffected, factoryName);
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="sqLstr">The string containing the SQL query to be loaded into this ADORecodsetHelper object.</param>
        /// <param name="connection">Connection object to be use by this ADORecordsetHelper.</param>
        /// <param name="factory">The DBProviderFactory to be used on the ADORecordsetHelper.</param>
        /// <returns>The new ADORecordsetHelper object.</returns>
        public static ADORecordSetHelper Open(String sqLstr, DbConnection connection, DbProviderFactory factory)
        {
            return Open(sqLstr, connection, factory);
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="command">A command containing the query to be execute to load the ADORecordsetHelper object.</param>
        /// <param name="factoryName">The name of the factory to by use by this ADORecordsetHelper object (the name most exist on the configuration xml file).</param>
        /// <returns></returns>
        public static ADORecordSetHelper Open(DbCommand command, String factoryName)
        {
            long recordsAffected;
            return Open(command, out recordsAffected, factoryName);
        }

        /// <summary>
        ///     Creates a new ADORecordsetHelper using the provided parameters.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="recordsAffected"></param>
        /// <param name="factoryName"></param>
        /// <returns></returns>
        public static ADORecordSetHelper Open(DbCommand command, out long recordsAffected, string factoryName)
        {
            ADORecordSetHelper recordSet = new ADORecordSetHelper(factoryName);
            recordSet.Open(command);
            recordsAffected = recordSet.RecordCount;
            return recordSet;
        }


        /// <summary>
        /// Populates a recordsetHelper with the information defined in a XmlDocument.
        /// </summary>
        /// <param name="document">XmlDocument to load into the RecordsetHelper.</param>
        public void Open(XmlDocument document)
        {
            StringReader sreader = null;
            XmlTextReader reader = null;
            try
            {
                _disconnected = true;
                sreader = new StringReader(document.OuterXml);
                reader = new XmlTextReader(sreader);
                ReadXml(reader, XmlReadMode.InferTypedSchema);
                _opened = true;
                ResetVars();
                MoveFirst();
                AcceptChanges();

            }
            catch
            {
            }
            finally
            {
                if (sreader != null)
                {
                    sreader.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }


        /// <summary>
        ///     Converts from DbType to System.Type.
        /// </summary>
        /// <param name="dbType">The DBType to be converted.</param>
        /// <returns>The equivalent System.Type.</returns>
        public static Type GetType(DbType dbType)
        {
            Type result = Type.GetType("System.String");
            switch (dbType)
            {
                case DbType.Byte:
                    result = Type.GetType("System.Byte");
                    break;
                case DbType.Binary:
                    result = Type.GetType("System.Byte[]");
                    break;
                case DbType.Boolean:
                    result = Type.GetType("System.Boolean");
                    break;
                case DbType.DateTime:
                    result = Type.GetType("System.DateTime");
                    break;
                case DbType.Decimal:
                    result = Type.GetType("System.Decimal");
                    break;
                case DbType.Double:
                    result = Type.GetType("System.Double");
                    break;
                case DbType.Guid:
                    result = Type.GetType("System.Guid");
                    break;
                case DbType.Int16:
                    result = Type.GetType("System.Int16");
                    break;
                case DbType.Int32:
                    result = Type.GetType("System.Int32");
                    break;
                case DbType.Int64:
                    result = Type.GetType("System.Int64");
                    break;
                case DbType.Object:
                    result = Type.GetType("System.Object");
                    break;
                case DbType.SByte:
                    result = Type.GetType("System.SByte");
                    break;
                case DbType.Single:
                    result = Type.GetType("System.Single");
                    break;
                case DbType.String:
                    result = Type.GetType("System.String");
                    break;
                case DbType.UInt16:
                    result = Type.GetType("System.UInt16");
                    break;
                case DbType.UInt32:
                    result = Type.GetType("System.UInt32");
                    break;
                case DbType.UInt64:
                    result = Type.GetType("System.UInt64");
                    break;
            }

            return result;
        }

        #endregion

        #region private methods

        /// <summary>
        ///     Sets the primary key to a DataTable object.
        /// </summary>
        /// <param name="dataTable">The DataTable that holds the currently loaded data.</param>
        private void FixAutoincrementColumns(DataTable dataTable)
        {
            if (ActiveConnection is SqlConnection)
            {
                foreach (DataColumn col in dataTable.PrimaryKey)
                {
                    if (col.AutoIncrement)
                    {
                        col.AutoIncrementSeed = 0;
                        col.AutoIncrementStep = -1;
                        col.ReadOnly = false;
                        _hasAutoincrementCols = true;
                        // todo check multiple autoincrement cases
                        _autoIncrementCol = col.ColumnName;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewRecord()
        {
            if (NewRecord != null)
            {
                NewRecord(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Determines if we should be at the end of file (EOF) based on the current index.
        /// </summary>
        /// <returns>Returns true if based on the index variable EOF is true; otherwise false.</returns>
        private bool IsEof()
        {
            bool isEof = _index < 0;
            if (UsingView)
            {
                isEof = (_index < 0) || (_index >= _currentView.Count);
            }
            else if (Tables.Count > 0)
            {
                isEof = (_index >= Tables[CurrentRecordSet].Rows.Count);
            }
            return isEof;
        }

        /// <summary>
        ///     Verifies that no more data is pending on the ADORecordsetHelper.
        /// </summary>
        private void EndOfRecordsetLogic()
        {
            bool moredata = false;
            OnEndOfRecordset(ref moredata, EventStatusEnum.adStatusOK);
            if (!moredata)
            {
                _eof = true;
                _index = UsingView ? _currentView.Count - 1 : Tables[CurrentRecordSet].Rows.Count - 1;
            }
            else
            {
                _eof = false;
            }
        }

        /// <summary>
        ///     Move the current record according to the value of “records”.
        /// </summary>
        /// <param name="records">The number of records to move forward (if positive), backwards (if negative).</param>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        private void Move(int records, EventReasonEnum reason, EventStatusEnum status)
        {
            OnWillMove(reason, ref status);
            if (BeforeMove != null)
                BeforeMove(this, new EventArgs());
            string[] errors = null;
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    if (records != 0 && _index >= 0 && !isBatchEnabled())
                    {
                        Update(false);
                    }
                    BasicMove(_index + records, reason);
                    if (_eof && reason != EventReasonEnum.adRsnMoveFirst && reason != EventReasonEnum.adRsnMovePrevious)
                    {
                        EndOfRecordsetLogic();
                    }
                    //else
                    //{
                    //    eof = false;
                    //}
                }
                catch (Exception e)
                {
                    errors = new string[] { e.Message };
                    status = EventStatusEnum.adStatusErrorsOccurred;
                }
                OnMoveComplete(reason, ref status, errors);
            }
        }

        /// <summary>
        ///     Move the current record to the beginning of the ADORecordsetHelper object.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        private void MoveFirst(EventReasonEnum reason)
        {
            if (_index == -1)
            {
                _index = 0;
            }
            Move((-1 * _index), reason, EventStatusEnum.adStatusOK);
        }

        /// <summary>
        ///     Saves the current content of the ADORecordsetHelper to the database.
        /// </summary>
        /// <param name="reportMove">Bool flag that indicates if this operation will notify others process raising an event or not.</param>
        private void Update(bool reportMove)
        {
            Exception exceptionToThrow = null;
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            string[] errors = null;
            OnWillChangeRecordset(EventReasonEnum.adRsnMove, ref status);
            if (status != EventStatusEnum.adStatusCancel)
            {
                DataRow theRow = CurrentRow;
                if (_newRow)
                {
                    _newRow = false;
                }
                theRow.EndEdit();
                if (theRow.RowState != DataRowState.Unchanged)
                {
                    if (!isBatchEnabled())
                    {
                        if (UsingView)
                        {
                            _currentView.Table.DataSet.EnforceConstraints = true;
                            _dbvRow.EndEdit();
                            _index = findBookmarkIndex(_dbvRow.Row);
                        }
                        status = EventStatusEnum.adStatusOK;
                        OnWillChangeRecord(EventReasonEnum.adRsnUpdate, ref status, 1);
                        if (status != EventStatusEnum.adStatusCancel)
                        {
                            try
                            {
                                UpdateWithNoEvents(theRow);
                                _editMode = EditModeEnum.EditNone;
                            }
                            catch (Exception e)
                            {
                                errors = new string[] { e.Message };
                                exceptionToThrow = e;
                            }
                            OnRecordChangeComplete(EventReasonEnum.adRsnUpdate, ref status, 1, errors);
                        }
                    }
                }
                OnRecordsetChangeComplete(EventReasonEnum.adRsnMove, ref status, errors);
                if (exceptionToThrow != null)
                {
                    throw exceptionToThrow;
                }
                if (reportMove)
                {
                    Move(0, EventReasonEnum.adRsnMove, EventStatusEnum.adStatusOK);
                }
            }
        }

        /// <summary>
        ///     Sets default values to a fields to avoid insert null in the DB when the field does not accept it.
        /// </summary>
        private void AssignDefaultValues(DataRow dbRow)
        {
            DbDataAdapter adapter = null;
            try
            {
                _requiresDefaultValues = false;
                if (_defaultValues == null) //no default values loaded for this table
                {
                    DataTable schemaTable;
                    try
                    {
                        adapter = CreateAdapter(GetConnection(ConnectionString), true);
                        string tablename = getTableName(adapter.SelectCommand.CommandText, true).Replace("dbo.", string.Empty);
                        schemaTable = ActiveConnection.GetSchema("Columns", new string[] { null, null, tablename, null });
                    }
                    catch (Exception)
                    {
                        return;
                        //throw e;
                    }

                    //Preloaded with the number  of elements required
                    _defaultValues = new List<KeyValuePair<bool, object>>();
                    DataColumnCollection columnInfo = UsingView ? _currentView.Table.Columns : Tables[CurrentRecordSet].Columns;
                    for (int i = 0; i < columnInfo.Count; i++)
                    {
                        _defaultValues.Add(new KeyValuePair<bool, object>());
                    }
                    string defaultValue = String.Empty;
                    bool isComputed = false;
                    bool isUnknown = false;
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        int thisColumnIndex = columnInfo.IndexOf(Convert.ToString(schemaTable.Rows[i]["COLUMN_NAME"]));
                        if (thisColumnIndex < 0) continue;

                        //13 Maximun length
                        if (columnInfo[thisColumnIndex].DataType == typeof(string))
                        {
                            int maxLength = 255;
                            if (schemaTable.Rows[i]["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                            {
                                if (!int.TryParse(schemaTable.Rows[i]["CHARACTER_MAXIMUM_LENGTH"].ToString(), out maxLength))
                                {
                                    maxLength = int.MaxValue;
                                }
                                if (maxLength == 0)
                                {
                                    maxLength = int.MaxValue;
                                }
                            }
                            columnInfo[thisColumnIndex].MaxLength = maxLength;
                        }

                        object originalValue = dbRow[thisColumnIndex];
                        if (schemaTable.Rows[i]["COLUMN_DEFAULT"] != DBNull.Value) //Has default value
                        {
                            defaultValue = (string)schemaTable.Rows[i]["COLUMN_DEFAULT"]; //8 Default Value
                            if (columnInfo[thisColumnIndex].DataType == typeof(bool))
                            {
                                defaultValue = defaultValue.Trim(new char[] { '=', '(', ')', '\'' });
                                bool defaultvalue;
                                bool.TryParse(defaultValue, out defaultvalue);
                                dbRow[thisColumnIndex] = defaultvalue;
                            }
                            else
                            {
                                try
                                {
                                    string partialResult = (defaultValue.Trim(new char[] { '(', ')', '\'' }));
                                    if (columnInfo[thisColumnIndex].MaxLength != -1) //is string
                                        dbRow[thisColumnIndex] = partialResult.Length > columnInfo[thisColumnIndex].MaxLength
                                                                     ? partialResult.Substring(0, columnInfo[thisColumnIndex].MaxLength)
                                                                     : partialResult;
                                    else
                                        dbRow[thisColumnIndex] = partialResult;
                                }
                                catch
                                {
                                    try
                                    {
                                        dbRow[thisColumnIndex] = ComputeValue(defaultValue);
                                        isComputed = true;
                                    }
                                    catch
                                    {
                                        isUnknown = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            object isNullable = schemaTable.Rows[i]["IS_NULLABLE"];
                            bool tmpRes;
                            if (!columnInfo[thisColumnIndex].AllowDBNull ||
                                (isNullable != null && (string.Equals(Convert.ToString(isNullable), "No", StringComparison.InvariantCultureIgnoreCase)
                                || (bool.TryParse(Convert.ToString(isNullable), out tmpRes) && !tmpRes))))
                            //Not Allow Null and has not default value
                            {
                                //Add more if necesary
                                if (columnInfo[thisColumnIndex].DataType == typeof(string))
                                    dbRow[thisColumnIndex] = string.Empty;
                                else if (columnInfo[thisColumnIndex].DataType == typeof(Int16))
                                    dbRow[thisColumnIndex] = default(Int16);
                                else if (columnInfo[thisColumnIndex].DataType == typeof(Int32))
                                    dbRow[thisColumnIndex] = default(Int32);
                                else if (columnInfo[thisColumnIndex].DataType == typeof(bool))
                                    dbRow[thisColumnIndex] = default(bool);
                                else if (columnInfo[thisColumnIndex].DataType == typeof(decimal))
                                    dbRow[thisColumnIndex] = default(decimal);
                                else if (columnInfo[thisColumnIndex].DataType == typeof(byte))
                                    dbRow[thisColumnIndex] = default(byte);
                                else if (columnInfo[thisColumnIndex].DataType == typeof(char))
                                    dbRow[thisColumnIndex] = default(char);
                            }
                            else
                                dbRow[thisColumnIndex] = DBNull.Value;
                        }
                        if (isComputed)
                        {
                            _defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(true, defaultValue);
                            isComputed = false;
                        }
                        else if (isUnknown)
                        {
                            _defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(false, DBNull.Value);
                            isUnknown = false;
                        }
                        else
                            _defaultValues[thisColumnIndex] = new KeyValuePair<bool, object>(false, dbRow[thisColumnIndex]);

                        if (originalValue != DBNull.Value)
                            dbRow[thisColumnIndex] = originalValue;
                    }
                }
                else //already _defaultValues has been created
                {
                    try
                    {
                        dbRow.BeginEdit();
                        for (int i = 0; i < _defaultValues.Count; i++)
                        {
                            if (dbRow[i] == DBNull.Value)
                            {
                                if (!_defaultValues[i].Key)
                                    dbRow[i] = _defaultValues[i].Value;
                                else
                                    dbRow[i] = ComputeValue((string)_defaultValues[i].Value);
                            }
                        }
                    }
                    finally
                    {
                        dbRow.EndEdit();
                    }
                }
            }
            finally
            {
                if (!IsCachingAdapter && adapter != null)
                    adapter.Dispose();
            }
        }

        private void ProcessCompoundStatement()
        {
            if (_activeCommand != null)
            {
                string[] commandTexts = _activeCommand.CommandText.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandTexts.Length > 1)
                {
                    foreach (string commandText in commandTexts)
                    {
                        if (commandText == null || string.IsNullOrEmpty(commandText.Trim()))
                        {
                            continue;
                        }
                        DbCommand tempcommand = ActiveConnection.CreateCommand();
                        tempcommand.Transaction = _activeCommand.Transaction;
                        tempcommand.CommandText = commandText;
                        if (_commands == null)
                        {
                            _commands = new Queue<DbCommand>(commandTexts.Length);
                        }
                        _commands.Enqueue(tempcommand);
                    }
                    _activeCommand = _commands.Dequeue();
                }
            }
        }

        #endregion

        #region protected methods

        /// <summary>
        ///     iterate fields, to assign current row the values for each specific fields
        /// </summary>
        /// <param name="fields">array of fields</param>
        /// <param name="values">array of values</param>
        /// <param name="isString">is string the field items</param>
        /// <param name="currentValues">has the current values</param>
        /// <returns>the row with the assigned values on each field</returns>
        protected object[] iterateFields(object[] fields, object[] values, bool isString, bool currentValues)
        {
            object[] thevalues = values;
            for (int i = 0; i < fields.Length; i++)
            {
                if (!currentValues)
                {
                    if (isString)
                    {
                        CurrentRow[(String)fields[i]] = values[i];
                    }
                    else
                    {
                        CurrentRow[(int)fields[i]] = values[i];
                    }
                }
                else
                {
                    thevalues = new object[fields.Length];
                    if (isString)
                    {
                        thevalues[i] = CurrentRow[(String)fields[i]];
                    }
                    else
                    {
                        thevalues[i] = CurrentRow[(int)fields[i]];
                    }
                }
            }
            return thevalues;
        }

        /// <summary>
        ///     Indicates if the ADORecordsetHelper is in batch mode.
        /// </summary>
        /// <returns>True if the ADORecordsetHelper is in batch mode, otherwise false.</returns>
        protected bool isBatchEnabled()
        {
            return _lockType == LockTypeEnum.LockBatchOptimistic && _cursorLocation == CursorLocationEnum.adUseClient;
        }

        /// <summary>
        ///     Verifies if the ADORecordset object have been open.
        /// </summary>
        protected void Validate()
        {
            if (_opened)
            {
                if (SupportsDisconnectedRecordsetOperations)
                {
                    /* OK */
                }
                else if (!_isClone)
                {
                    throw new InvalidOperationException("The recordSet is already open");
                }
            }
        }


        /// <summary>
        ///     The EndOfRecordset event is called when there is an attempt to move to a row past the end of the Recordset.
        /// </summary>
        /// <param name="moredata">Bool value that indicates if more data have been added to the ADORecordsetHelper.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        protected void OnEndOfRecordset(ref bool moredata, EventStatusEnum status)
        {
            if (EndOfRecordset != null)
            {
                EndOfRecordsetEventArgs eor = new EndOfRecordsetEventArgs(moredata, status);
                EndOfRecordset(this, eor);
                moredata = eor.MoreData;
            }
        }

        /// <summary>
        ///     The WillChangeField event is called before a pending operation changes the value of one or more Field objects in the ADORecordsetHelper.
        /// </summary>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="numfields">Indicates the number of fields objects contained in the “fieldvalues” array.</param>
        /// <param name="fieldvalues">Array with the new values of the modified fields.</param>
        protected void OnWillChangeField(ref EventStatusEnum status, int numfields, object[] fieldvalues)
        {
            if (WillChangeField != null)
            {
                FieldChangeEventArgs args = new FieldChangeEventArgs(numfields, fieldvalues, status);
                WillChangeField(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     The FieldChangeComplete event is called after the value of one or more Field objects has changed.
        /// </summary>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="numfields">Indicates the number of fields objects contained in the “fieldvalues” array.</param>
        /// <param name="fieldvalues">Array with the new values of the modified fields.</param>
        /// <param name="errors">Array containing all the errors occurred during the field change.</param>
        protected void OnFieldChangeComplete(ref EventStatusEnum status, int numfields, object[] fieldvalues, string[] errors)
        {
            if (FieldChangeComplete != null)
            {
                FieldChangeCompleteEventArgs args = new FieldChangeCompleteEventArgs(numfields, fieldvalues, errors, status);
                FieldChangeComplete(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     The OnWillChangeRecord event is called before one or more records (rows) in the Recordset change.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="numRecords">Value indicating the number of records changed (affected).</param>
        protected void OnWillChangeRecord(EventReasonEnum reason, ref EventStatusEnum status, int numRecords)
        {
            if (WillChangeRecord != null)
            {
                RecordChangeEventArgs args = new RecordChangeEventArgs(reason, numRecords, status);
                WillChangeRecord(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     OnRecordChangeComplete event is called after one or more records change.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="numRecords">Value indicating the number of records changed (affected).</param>
        /// <param name="errors">Array containing all the errors occurred during the field change.</param>
        protected void OnRecordChangeComplete(EventReasonEnum reason, ref EventStatusEnum status, int numRecords,
                                              string[] errors)
        {
            if (RecordChangeComplete != null)
            {
                RecordChangeCompleteEventArgs args = new RecordChangeCompleteEventArgs(reason, numRecords, errors, status);
                RecordChangeComplete(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     OnWillChangeRecordset event is called before a pending operation changes the ADORecordsetHelper.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        protected void OnWillChangeRecordset(EventReasonEnum reason, ref EventStatusEnum status)
        {
            if (WillChangeRecordset != null)
            {
                RecordSetChangeEventArgs args = new RecordSetChangeEventArgs(reason, status);
                WillChangeRecordset(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     OnRecordsetChangeComplete event is called after the ADORecordsetHelper has changed.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="errors">Array containing all the errors occurred during the field change.</param>
        protected void OnRecordsetChangeComplete(EventReasonEnum reason, ref EventStatusEnum status, string[] errors)
        {
            if (RecordsetChangeComplete != null)
            {
                RecordSetChangeCompleteEventArgs args = new RecordSetChangeCompleteEventArgs(reason, errors, status);
                RecordsetChangeComplete(this, args);
                status = args.Status;
            }
        }

        /// <summary>
        ///     OnWillMove event is called before a pending operation changes the current position in the ADORecordsetHelper.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        protected void OnWillMove(EventReasonEnum reason, ref EventStatusEnum status)
        {
            _firstChange = true;
            if (WillMove != null)
            {
                MoveEventArgs args = new MoveEventArgs(reason, status);
                WillMove(this, args);
                status = args.Status;
                _firstChange = status != EventStatusEnum.adStatusCancel;
            }
        }

        /// <summary>
        ///     OnMoveComplete event is called after the current position in the ADORecordsetHelper changes.
        /// </summary>
        /// <param name="reason">The reason of the change.</param>
        /// <param name="status">An EventStatusEnum value that indicates the state of the ADORecordsetHelper in the moment that the event rose.</param>
        /// <param name="errors">Array containing all the errors occurred during the field change.</param>
        protected void OnMoveComplete(EventReasonEnum reason, ref EventStatusEnum status, string[] errors)
        {
            if (MoveComplete != null)
            {
                MoveCompleteEventArgs args = new MoveCompleteEventArgs(reason, errors, status);
                MoveComplete(this, args);
                status = args.Status;
            }
        }


        /// <summary>
        ///     Performs the basic move operation on the ADORecordsetHelper, moving the current record forward or backwards.
        /// </summary>
        /// <param name="newIndex">The index of the new position for the current record.</param>
        /// <param name="reason">The type of Move to perform.</param>
        protected void BasicMove(int newIndex, EventReasonEnum reason)
        {
            _index = newIndex;
            if (!BOF && !IsEof() && (CurrentRow.RowState == DataRowState.Deleted || CurrentRow.RowState == DataRowState.Detached))
            {
                bool rowFound = false;
                if (reason != EventReasonEnum.adRsnMovePrevious)
                {
                    for (int i = _index + 1; i < Tables[CurrentRecordSet].Rows.Count; i++)
                    {
                        if (Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Deleted && Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Detached)
                        {
                            _index = i;
                            rowFound = true;
                            break;
                        }
                    }
                    if (!rowFound) _index = Tables[CurrentRecordSet].Rows.Count;
                }
                else
                {
                    for (int i = _index - 1; i >= 0; i--)
                    {
                        if (Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Deleted && Tables[CurrentRecordSet].Rows[i].RowState != DataRowState.Detached)
                        {
                            _index = i;
                            rowFound = true;
                            break;
                        }
                    }
                    if (!rowFound) _index = -1;
                }
            }
            else
            {
                OnAfterMove();
            }
            _eof = IsEof();
        }


        /// <summary>
        ///     Saves any changes made to the DataRow recieved as parameter.
        /// </summary>
        /// <param name="theRow">The row to be save on the Database.</param>
        protected void UpdateWithNoEvents(DataRow theRow)
        {
            if (theRow.RowState != DataRowState.Unchanged)
            {
                if (!isBatchEnabled())
                {
                    DbConnection connection = GetConnection(ConnectionString);
                    DbDataAdapter dbAdapter = null;
                    try
                    {
                        dbAdapter = CreateAdapter(connection, true);
                        if (_requiresDefaultValues)
                            AssignDefaultValues(theRow);

                        dbAdapter.Update(new DataRow[] { theRow });
                    }
                    finally
                    {
                        if (!IsCachingAdapter)
                            if (dbAdapter != null) dbAdapter.Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the ActiveConnection object if it has been initialized otherwise creates a new DBConnection object.
        /// </summary>
        /// <param name="connectionString">The connection string to be used by the connection.</param>
        /// <returns>A DBConnection containing with the connection string set. </returns>
        protected virtual DbConnection GetConnection(String connectionString)
        {
            if (ActiveConnection != null &&
                ActiveConnection.ConnectionString.Equals(connectionString, StringComparison.InvariantCultureIgnoreCase))
            {
                return ActiveConnection;
            }
#if DBTrace
            DbConnection connection = DBTrace.CreateConnectionWithTrace(providerFactory);
#else
            DbConnection connection = null;

            if (_providerFactory == null)
            {
                Debug.WriteLine("No provider factory was given, getting default");
                _providerFactory = AdoFactoryManager.GetFactory(null);
            }

            connection = _providerFactory.CreateConnection();
#endif
            if (connection != null)
            {
                connection.ConnectionString = connectionString;
                return connection;
            }
            return null;
        }

        /// <summary>
        ///     Using connection parameter creates a Database Data Adapter
        /// </summary>
        /// <param name="connection">DbConnection parameter</param>
        /// <param name="updating">if updating creates all internal query strings</param>
        /// <returns></returns>
        protected virtual DbDataAdapter CreateAdapter(DbConnection connection, bool updating)
        {
            Debug.Assert(connection != null, "Error during CreateAdapter call. Connection String must never be null");
            DbDataAdapter realAdapter = ProviderFactory.CreateDataAdapter();
            DbDataAdapter adapter = ProviderFactory.CreateDataAdapter();
            bool isOracleProvider = ProviderFactory.GetType().FullName.Equals("Oracle.DataAccess.Client.OracleClientFactory");
            DbCommandBuilder cmdBuilder = null;
            KeyValuePair<DbConnection, string> key = new KeyValuePair<DbConnection, string>();
            try
            {
                cmdBuilder = ProviderFactory.CreateCommandBuilder();
                if (_activeCommand != null)
                {
                    if (_activeCommand.Connection == null || _activeCommand.Connection.ConnectionString.Equals(""))
                    {
                        //What should we use here. ActiveConnection or the connection we are sending as parameter
                        //it seams more valid to use the parameter
                        _activeCommand.Connection = connection;
                    }
                    if (String.IsNullOrEmpty(_activeCommand.CommandText))
                    {
                        _activeCommand.CommandText = SqlSelectQuery;
                    }
                    DbTransaction transaction = TransactionManager.GetTransaction(connection);
                    if (transaction != null)
                    {
                        _activeCommand.Transaction = transaction;
                    }

                    if (_cachingAdapter)
                    {
                        key = new KeyValuePair<DbConnection, string>(_activeCommand.Connection, _activeCommand.CommandText);
                        if (_dataAdaptersCached.ContainsKey(key))
                        {
                            return _dataAdaptersCached[key];
                        }
                    }

                    if (adapter != null)
                    {
                        adapter.SelectCommand = _activeCommand;
                        realAdapter.SelectCommand = adapter.SelectCommand;
                        cmdBuilder.DataAdapter = adapter;
                        if (updating)
                        {
                            if (DatabaseType == DatabaseType.Access || DatabaseType == DatabaseType.SQLServer ||
                                getTableName(_activeCommand.CommandText, false).Contains(" "))
                            {
                                cmdBuilder.QuotePrefix = "[";
                                cmdBuilder.QuoteSuffix = "]";
                            }
                            CreateUpdateCommand(adapter, cmdBuilder);
                            try
                            {
                                if (string.IsNullOrEmpty(SqlInsertQuery))
                                {
                                    adapter.InsertCommand = cmdBuilder.GetInsertCommand(true);
                                }
                                else
                                {
                                    adapter.InsertCommand = CreateCommand(SqlInsertQuery, CommandType.Text, null);
                                    adapter.InsertCommand.Connection = this.ActiveConnection;
                                    AddParametersToCommand(adapter.InsertCommand);
                                }
                            }
                            catch (Exception)
                            {
                                adapter.InsertCommand = CreateInsertCommandFromMetaData();
                            }
                            try
                            {
                                if (string.IsNullOrEmpty(SqlDeleteQuery))
                                {
                                    adapter.DeleteCommand = cmdBuilder.GetDeleteCommand(true);
                                }
                                else
                                {
                                    adapter.DeleteCommand = CreateCommand(SqlDeleteQuery, CommandType.Text);
                                    adapter.DeleteCommand.Connection = this.ActiveConnection;
                                    AddParametersToCommand(adapter.DeleteCommand);
                                }
                            }
                            catch (Exception)
                            {
                                adapter.DeleteCommand = CreateDeleteCommandFromMetaData();
                            }

#if SUPPORT_OBSOLETE_ORACLECLIENT
                        if ((ProviderFactory is SqlClientFactory) || isOracleProvider)
#else
                            if ((ProviderFactory is SqlClientFactory))
#endif
                            {
#if SUPPORT_OBSOLETE_ORACLECLIENT                            
	//EVG20080326: Oracle.DataAccess Version 10.102.2.20 Bug. It returns "::" instead ":" before each parameter name, wich is invalid.
			                if (isOracleProvider)
			                {
			                    adapter.InsertCommand.CommandText = adapter.InsertCommand.CommandText.Replace("::", ":");
			                    adapter.DeleteCommand.CommandText = adapter.DeleteCommand.CommandText.Replace("::", ":");
			                    adapter.UpdateCommand.CommandText = adapter.UpdateCommand.CommandText.Replace("::", ":");
			                }
#endif
                                CompleteInsertCommand(adapter);
                            }
                            else if (ProviderFactory is OleDbFactory)
                            {
                                ((OleDbDataAdapter)realAdapter).RowUpdated += RecordSetHelper_RowUpdatedOleDb;
                            }
                            realAdapter.InsertCommand = CloneCommand(adapter.InsertCommand);
                            realAdapter.DeleteCommand = CloneCommand(adapter.DeleteCommand);
                            realAdapter.UpdateCommand = CloneCommand(adapter.UpdateCommand);
                            if (realAdapter.InsertCommand != null)
                            {
                                realAdapter.InsertCommand.Transaction = realAdapter.SelectCommand.Transaction;
                            }
                            if (realAdapter.DeleteCommand != null)
                            {
                                realAdapter.DeleteCommand.Transaction = realAdapter.SelectCommand.Transaction;
                            }
                            if (realAdapter.UpdateCommand != null)
                            {
                                realAdapter.UpdateCommand.Transaction = realAdapter.SelectCommand.Transaction;
                            }
                        }
                    }

                    if (_cachingAdapter)
                    {
                        _dataAdaptersCached.Add(key, realAdapter);
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (adapter != null) adapter.Dispose();
                if (cmdBuilder != null)
                {
                    cmdBuilder.Dispose();
                }
            }
            return realAdapter;
        }


        /// <summary>
        ///     Opens the ADORecordsetHelper using the object public information.
        /// </summary>
        /// <param name="requery">Flag that indicates if a requery is necessary.</param>
        protected void OpenRecordset(bool requery)
        {
            EventStatusEnum status = requery ? EventStatusEnum.adStatusOK : EventStatusEnum.adStatusCantDeny;
            OnWillMove(requery ? EventReasonEnum.adRsnRequery : EventReasonEnum.adRsnMove, ref status);
            if (requery)
            {
                OnMoveComplete(EventReasonEnum.adRsnRequery, ref status, null);
            }
            string[] errors = null;
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    ProcessCompoundStatement();

                    //base.OpenRecordset(requery);
                    // base declaration

                    if (ActiveConnection != null && _activeCommand != null)
                    {
                        DbDataAdapter dbAdapter = null;
                        try
                        {
                            dbAdapter = CreateAdapter(ActiveConnection, false);
                            SqlSelectQuery = _activeCommand.CommandText;
                            _operationFinished = false;
                            this.Tables.Clear();
                            CurrentRecordSet = 0;
                            if (LoadSchema || LoadSchemaOnly)
                            {
                                dbAdapter.FillSchema(this, SchemaType.Source);
                            }
                            if (!LoadSchemaOnly)
                            {
                                dbAdapter.Fill(this);
                            }
                        }
                        finally
                        {
                            if (!IsCachingAdapter)
                                if (dbAdapter != null) dbAdapter.Dispose();
                        }
                    }
                    ResetVars();
                    OnAfterQuery();
                    status = EventStatusEnum.adStatusOK;
                    if (UsingView && _currentView != null)
                    {
                        _currentView.ListChanged += DataView_ListChanged;
                    }
                }
                catch (Exception e)
                {
                    if (RecordsetChangeComplete != null || MoveComplete != null)
                    {
                        status = EventStatusEnum.adStatusErrorsOccurred;
                        errors = new string[] { e.Message };
                    }
                    else
                    {
                        throw;
                    }
                }
                if (!requery)
                {
                    OnMoveComplete(EventReasonEnum.adRsnMove, ref status, errors);
                }
                else
                {
                    MoveFirst(EventReasonEnum.adRsnMove);
                }
            }
        }

        /// <summary>
        ///     Resets Vars according to current status
        /// </summary>
        private void ResetVars()
        {
            if (Tables.Count > 0)
            {
                FixAutoincrementColumns(UsingView ? _currentView.Table : Tables[CurrentRecordSet]);
                _operationFinished = true;
                _currentView = Tables[CurrentRecordSet].DefaultView;
                _currentView.AllowDelete = AllowDelete;
                _currentView.AllowEdit = AllowEdit;
                _currentView.AllowNew = AllowNew;
                if ((UsingView ? _currentView.Table : Tables[CurrentRecordSet]).Rows.Count == 0)
                {
                    _index = -1;
                    _eof = true;
                }
                else
                {
                    _index = 0;
                    _eof = false;
                }
            }
            else
            {
                _index = -1;
                _eof = true;
            }
            _newRow = false;
            _opened = true;
            _isClone = false;

            if ((UsingView && _currentView.Table.Columns.Count > 0) ||
                (Tables.Count == 1 && Tables[CurrentRecordSet].Columns.Count > 0))
            {
                State = ConnectionState.Open;
            }
        }

        /// <summary>
        /// When the RecordSet is Sorted and a value in the column(s) used in the sort criteria is changed, the rows in the
        /// DataView could be resorted making the index pointing to the CurrentRow invalid. This method handles rows moved
        /// to a new position and updates the index used for the CurrentRow. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void DataView_ListChanged(Object sender, ListChangedEventArgs args)
        {
            if (args.ListChangedType == ListChangedType.ItemMoved && !String.IsNullOrEmpty(_currentView.Sort))
            {
                if (args.OldIndex == this._index)
                {
                    this._index = args.NewIndex;
                }
            }
            else if (args.ListChangedType == ListChangedType.ItemAdded)
            {
                this._index = args.NewIndex;
            }
        }

        /// <summary>
        ///     Overrides the IDisposable.Dispose to cleanup
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_opened)
            {
                Close();
            }
        }

        /// <summary>
        ///     Creates the update command for the database update operations of the recordset
        /// </summary>
        /// <param name="adapter">The data adapter that will contain the update command</param>
        /// <param name="cmdBuilder">The command builder to get the update command from.</param>
        protected void CreateUpdateCommand(DbDataAdapter adapter, DbCommandBuilder cmdBuilder)
        {
            try
            {
                if (string.IsNullOrEmpty(SqlUpdateQuery))
                {
                    adapter.UpdateCommand = cmdBuilder.GetUpdateCommand(true);
                }
                else
                {
                    adapter.UpdateCommand = CreateCommand(SqlUpdateQuery, CommandType.Text);
                    adapter.UpdateCommand.Connection = this.ActiveConnection;
                    AddParametersToCommand(adapter.UpdateCommand);
                }
            }
            catch (Exception)
            {
                adapter.UpdateCommand = CreateUpdateCommandFromMetaData();
            }
        }

        private void AddParametersToCommand(DbCommand command)
        {
            foreach (DataColumn col in this.Tables[CurrentRecordSet].Columns)
            {
                DbParameter param = command.CreateParameter();
                param.ParameterName = ":" + col.ColumnName;
                param.SourceColumn = col.ColumnName;
                command.Parameters.Add(param);
            }
        }

        /// <summary>
        ///     Creates an update command using the information contained in the RecordsetHelper.
        /// </summary>
        /// <returns>A DBCommand object containing an update command.</returns>
        protected DbCommand CreateUpdateCommandFromMetaData()
        {
            int i = 0, j = 0;
            DbCommand result = null;
            String tableName = getTableName(_activeCommand.CommandText, false);
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    string updatePart = "";
                    string wherePart = "";
                    string sql = "";
                    List<DbParameter> listGeneral = new List<DbParameter>();
                    List<DbParameter> listWhere = new List<DbParameter>();

                    DataTable table = GetTable();
                    foreach (DataColumn dColumn in table.Columns)
                    {
                        if (table.PrimaryKey != null &&
                            !(Array.Exists(
                                table.PrimaryKey,
                                delegate(DataColumn col)
                                {
                                    return col.ColumnName.Equals(dColumn.ColumnName, StringComparison.InvariantCultureIgnoreCase);
                                }) || dColumn.ReadOnly))
                        {
                            if (updatePart.Length > 0)
                            {
                                updatePart += " , ";
                            }

                            updatePart += dColumn.ColumnName + " = ?";
                            listGeneral.Add(CreateParameterFromColumn("p" + (++i), dColumn));
                        }
                        // Filter binary columns for wherePart
                        if (dColumn.DataType == typeof(Byte[]))
                            continue;
                        if (wherePart.Length > 0)
                        {
                            wherePart += " AND ";
                        }
                        DbParameter param;
                        if (dColumn.AllowDBNull)
                        {
                            wherePart += "((? = 1 AND " + dColumn.ColumnName + " IS NULL) OR (" + dColumn.ColumnName + " = ?))";
                            param = CreateParameterFromColumn("q" + (++j), dColumn);
                            param.DbType = DbType.Int32;
                            param.SourceVersion = DataRowVersion.Original;
                            param.SourceColumnNullMapping = true;
                            param.Value = 1;
                            listWhere.Add(param);
                            param = CreateParameterFromColumn("q" + (++j), dColumn);
                            param.SourceVersion = DataRowVersion.Original;
                            listWhere.Add(param);
                        }
                        else
                        {
                            wherePart += "(" + dColumn.ColumnName + " = ?)";
                            param = CreateParameterFromColumn("q" + (++j), dColumn);
                            param.SourceVersion = DataRowVersion.Original;
                            listWhere.Add(param);
                        }
                    }
                    listGeneral.AddRange(listWhere);
                    sql = "UPDATE " + tableName + " SET " + updatePart + " WHERE " + wherePart;
                    result = ProviderFactory.CreateCommand();
                    if (result != null)
                    {
                        result.CommandText = sql;
                        listGeneral.ForEach(delegate(DbParameter p) { result.Parameters.Add(p); });
                        result.Connection = _activeCommand.Connection;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        ///     Creates a delete command using the information contained in the RecordsetHelper.
        /// </summary>
        /// <returns>A DBCommand object containing a delete command.</returns>
        protected DbCommand CreateDeleteCommandFromMetaData()
        {
            DbCommand result = null;
            String tableName = getTableName(_activeCommand.CommandText, false);
            int j = 0;
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    string wherePart = "";
                    List<DbParameter> listGeneral = new List<DbParameter>();

                    foreach (DataColumn dColumn in GetTable().Columns)
                    {
                        if (wherePart.Length > 0)
                        {
                            wherePart += " AND ";
                        }

                        DbParameter pInfo;
                        if (dColumn.AllowDBNull)
                        {
                            wherePart += "((? = 1 AND " + dColumn.ColumnName + " IS NULL) OR (" + dColumn.ColumnName + " = ?))";

                            pInfo = CreateParameterFromColumn("p" + (++j), dColumn);
                            pInfo.DbType = DbType.Int32;
                            pInfo.SourceVersion = DataRowVersion.Original;
                            pInfo.SourceColumnNullMapping = true;
                            pInfo.Value = 1;
                            listGeneral.Add(pInfo);

                            pInfo = CreateParameterFromColumn("p" + (++j), dColumn);
                            pInfo.SourceVersion = DataRowVersion.Original;
                            listGeneral.Add(pInfo);
                        }
                        else
                        {
                            wherePart += "(" + dColumn.ColumnName + " = ?)";
                            pInfo = CreateParameterFromColumn("q" + (++j), dColumn);
                            pInfo.SourceVersion = DataRowVersion.Original;
                            listGeneral.Add(pInfo);
                        }
                    }
                    string sql = "DELETE FROM " + tableName + " WHERE (" + wherePart + ")";
                    result = ProviderFactory.CreateCommand();
                    if (result != null)
                    {
                        result.CommandText = sql;
                        listGeneral.ForEach(delegate(DbParameter p) { result.Parameters.Add(p); });
                        result.Connection = _activeCommand.Connection;
                    }
                }
            }
            catch
            {
            }
            return result;
        }


        /// <summary>
        ///     Creates an insert command using the information contained in the RecordsetHelper.
        /// </summary>
        /// <returns>A DBCommand object containing an insert command.</returns>
        protected DbCommand CreateInsertCommandFromMetaData()
        {
            DbCommand result = null;
            int i = 0;
            String tableName = getTableName(_activeCommand.CommandText, false);
            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    List<DbParameter> parameters = new List<DbParameter>();
                    string fieldsPart = "";
                    string valuesPart = "";
                    string sql;
                    foreach (DataColumn dColumn in GetTable().Columns)
                    {
                        if (!dColumn.ReadOnly)
                        {
                            if (fieldsPart.Length > 0)
                            {
                                fieldsPart += ", ";
                                valuesPart += ", ";
                            }

                            fieldsPart += dColumn.ColumnName;
                            valuesPart += "?";
                            parameters.Add(CreateParameterFromColumn("p" + (++i), dColumn));
                        }
                    }
                    sql = "INSERT INTO " + tableName + " (" + fieldsPart + ") VALUES (" + valuesPart + ")";
                    result = ProviderFactory.CreateCommand();
                    if (result != null)
                    {
                        result.CommandText = sql;
                        parameters.ForEach(delegate(DbParameter p) { result.Parameters.Add(p); });
                        result.Connection = _activeCommand.Connection;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        ///     Assigns the InsertCommand to the adaptar parameter
        /// </summary>
        /// <param name="adapter">DbDataAdapter</param>
        protected void CompleteInsertCommand(DbDataAdapter adapter)
        {
            String extraCommandText = "";
            String extraCommandText1 = "";

            string tablename = getTableName(_activeCommand.CommandText, false);
            Dictionary<String, String> identities = null;
            if (!LoadSchema && !LoadSchemaOnly)
            {
                identities = IdentityColumnsManager.GetIndentityInformation(tablename);
            }
            else if (DatabaseType != DB.DatabaseType.Oracle)
            {
                identities = new Dictionary<string, string>();
                foreach (DataColumn col in GetTable().PrimaryKey)
                {
                    if (col.Unique && col.AutoIncrement)
                    {
                        identities.Add(col.ColumnName, String.Empty);
                    }
                }
            }

            if (identities != null)
            {
                foreach (KeyValuePair<String, String> identityInfo in identities)
                {
                    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
                    //outPar.ParameterName = (isOracle ? ":" : "@") + identityInfo.Key;

                    if (DatabaseType == DatabaseType.Oracle)
                    {
                        DbParameter outPar = adapter.InsertCommand.Parameters[":" + identityInfo.Key];
                        //todo: check for null
                        outPar.Direction = ParameterDirection.Output;
                        outPar.DbType = GetDBType(GetTable().Columns[identityInfo.Key].DataType);

                        if (String.IsNullOrEmpty(extraCommandText))
                        {
                            extraCommandText = " RETURNING " + identityInfo.Key;
                            extraCommandText1 = " INTO :" + identityInfo.Key;
                        }
                        else
                        {
                            extraCommandText += ", " + identityInfo.Key;
                            extraCommandText1 += ", :" + identityInfo.Key;
                        }
                    }
                    else if (DatabaseType != DatabaseType.Undefined)
                    {
                        extraCommandText = MsInsertCommandCompletion(adapter, identityInfo.Key, extraCommandText);
                    }
                }
            }
            else
            {
                extraCommandText = MsInsertCommandCompletion(adapter, _autoIncrementCol, extraCommandText);
            }
            adapter.InsertCommand.CommandText += extraCommandText + extraCommandText1;
        }

        /// <summary>
        ///     SqlServer Identity value for last insert execution.
        /// </summary>
        /// <param name="adapter">DbDataAdapter to set</param>
        /// <param name="identityInfo">Name of Identity field</param>
        /// <param name="extraCommandText">used to set the query to get the identity value</param>
        /// <returns>returns the entire query in the adapter</returns>
        protected string MsInsertCommandCompletion(DbDataAdapter adapter, String identityInfo, string extraCommandText)
        {
            if (!String.IsNullOrEmpty(identityInfo))
            {
                DbParameter outPar = _providerFactory.CreateParameter();
                if (outPar != null)
                {
                    outPar.ParameterName = "@" + identityInfo;
                    outPar.DbType = GetDBType(GetTable().Columns[identityInfo].DataType);
                    outPar.Direction = ParameterDirection.Output;
                    outPar.SourceColumn = identityInfo;
                }
                extraCommandText += " SELECT @" + identityInfo + " = SCOPE_IDENTITY()";
                adapter.InsertCommand.Parameters.Add(outPar);
            }
            return extraCommandText;
        }

        private int _lastIdentity;
        /// <summary>
        /// Returns the last identity value inserted into an identity column
        /// </summary>
        public int LastIdentity
        {
            get
            {
                return _lastIdentity;
            }
            protected set
            {
                _lastIdentity = value;
            }
        }

        /// <summary>
        ///     OleDb Row Updated event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Row updated event args</param>
        protected void RecordSetHelper_RowUpdatedOleDb(object sender, OleDbRowUpdatedEventArgs e)
        {
            //This behavior depends on the database we are interacting with
            if (e.StatementType == StatementType.Insert && e.Status == UpdateStatus.Continue)
            {
                string tablename = getTableName(_activeCommand.CommandText, false);
                Dictionary<String, String> identities = null;
                if (!LoadSchema && !LoadSchemaOnly)
                {
                    identities = IdentityColumnsManager.GetIndentityInformation(tablename);
                }
                else if (DatabaseType != DB.DatabaseType.Oracle)
                {
                    identities = new Dictionary<string, string>();
                    foreach (DataColumn col in GetTable().PrimaryKey)
                    {
                        if (col.Unique && col.AutoIncrement)
                        {
                            identities.Add(col.ColumnName, String.Empty);
                        }
                    }
                }

                if (identities != null)
                {
                    DbCommand oCmd = e.Command.Connection.CreateCommand();
                    oCmd.Transaction = e.Command.Transaction;
                    object lastIdentity = null;
                    foreach (KeyValuePair<String, String> identityInfo in identities)
                    {
                        switch (DatabaseType)
                        {
                            case DatabaseType.Oracle:
                                oCmd.CommandText = "Select " + identityInfo.Value + ".Currval from dual";
                                break;
                            case DatabaseType.SQLServer:
                                oCmd.CommandText = "SELECT @@IDENTITY";
                                break;
                            case DatabaseType.Access:
                                oCmd.CommandText = "SELECT @@IDENTITY";
                                break;
                        }
                        lastIdentity = oCmd.ExecuteScalar();
                        this.LastIdentity = Convert.IsDBNull(lastIdentity) ? -1 : Convert.ToInt32(lastIdentity);
                        e.Row[identityInfo.Key] = lastIdentity;
                    }
                    e.Row.AcceptChanges();
                }
            }
        }

        /// <summary>
        ///     Executes the atomic addNew Operation creating the new row and setting the newRow flag.
        /// </summary>
        protected void doAddNew()
        {
            if (UsingView)
            {
                DataRowView _dbvRow = _currentView.AddNew();
                DataRow _dbRow = _dbvRow.Row;
                _newRow = true;
                _dbvRow.EndEdit();
                foreach (DataColumn col in _currentView.Table.Columns)
                {
                    if (!col.AllowDBNull)
                    {
                        try
                        {
                            _dbRow[col.ColumnName] = Convert.ChangeType(DBNull.Value, col.DataType);
                        }
                        catch
                        {
                        }
                    }
                }
                _currentView.Table.DataSet.EnforceConstraints = false;
                _currentView.Table.Rows.Add(_dbRow);
            }
            else
            {
                DataRow dbRow = GetTable().NewRow();
                _newRow = true;
                _requiresDefaultValues = true;
                AssignDefaultValues(dbRow);
                Tables[CurrentRecordSet].Rows.Add(dbRow);
                _index = Tables[CurrentRecordSet].Rows.Count - 1;
                OnNewRecord();
            }
            _eof = false;
        }

        #endregion

        #region public methods

        /// <summary>
        ///     Looks in all records for a field that matches the “criteria”.
        /// </summary>
        /// <param name="criteria">A String used to locate the record. It is like the WHERE clause in an SQL statement, but without the word WHERE.</param>
        public void Find(String criteria)
        {
            DataView result = Tables[CurrentRecordSet].DefaultView;
            string savedFilter = result.RowFilter;
            if (!(string.IsNullOrEmpty(savedFilter) || savedFilter.Trim().Length == 0))
                result.RowFilter = "(" + savedFilter + ") AND (" + criteria + ")";
            else
                result.RowFilter = criteria;
            result.RowFilter = criteria;
            object[] values = result.Count > 0 ? result[0].Row.ItemArray : null;
            result.RowFilter = savedFilter;
            if (values != null)
            {
                bool bfound = false;
                MoveFirst();
                while ((!bfound) && !EOF)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        bfound = (CurrentRow.ItemArray[i].Equals(values[i]));
                        if (!bfound)
                        {
                            break;
                        }
                    }
                    if (!bfound)
                    {
                        MoveNext();
                    }
                }
            }
            else
            {
                _eof = true;
            }
        }

        /// <summary>
        ///     Looks in all records for a field that matches the “criteria”.
        /// </summary>
        /// <param name="rowName">A String used to locate the row from the record.</param>
        /// <param name="pCriteria">A String used to locate the record. It is like the WHERE clause in an SQL statement, but without the word WHERE.</param>
        public void Find(String rowName, String pCriteria)
        {
            DataTable table = GetTable();
            if (table.Rows.Count > 0)
            {
                bool bfound = false;
                MoveFirst();
                int i = 0;
                while ((!bfound) && !EOF)
                {
                    if (i < table.Rows.Count)
                    {
                        bfound = (table.Rows[i][rowName].Equals(pCriteria));
                    }
                    if (!bfound)
                    {
                        MoveNext();
                    }
                    i++;
                }
            }
        }

        /// <summary>
        ///     Start caching the adapters used for connections. Use carefully because it needs an explicit call to StopCachingAdapter
        /// </summary>
        public void StartCachingAdapter()
        {
            ClearDataAdaptersCached();
            _cachingAdapter = true;
        }

        /// <summary>
        ///     Stop caching the adapters used for connections
        /// </summary>
        public void StopCachingAdapter()
        {
            ClearDataAdaptersCached();
            _cachingAdapter = false;
        }

        /// <summary>
        ///     Clear data adapters cached
        /// </summary>
        private void ClearDataAdaptersCached()
        {
            try
            {
                foreach (KeyValuePair<DbConnection, string> key in new List<KeyValuePair<DbConnection, string>>(_dataAdaptersCached.Keys))
                {
                    try
                    {
                        DbDataAdapter dbDataAdapter = _dataAdaptersCached[key];
                        if (dbDataAdapter != null) dbDataAdapter.Dispose();
                        _dataAdaptersCached[key] = null;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                _dataAdaptersCached.Clear();
            }
        }

        /// <summary>
        ///     Saves the information on the RecordsetHelper to a XML document.
        /// </summary>
        /// <param name="document">The XML document to save the data to.</param>
        public void Save(XmlDocument document)
        {
            using (StringWriter writer = new StringWriter())
            {
                GetTable().WriteXml(writer, XmlWriteMode.WriteSchema);
                document.LoadXml(writer.ToString());
                writer.Close();
            }
        }

        /// <summary>
        ///     Saves the information on the RecordsetHelper to a file.
        /// </summary>
        /// <param name="fullName">The full path name where to save the file.</param>
        /// <param name="persistFormat">The format type to save the file.</param>
        public void Save(string fullName, PersistFormatEnum persistFormat)
        {
            FileStream fs = new FileStream(fullName, FileMode.Create);
            switch (persistFormat)
            {
                case (PersistFormatEnum.adPersistXML):
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        Save(xmlDoc);
                        xmlDoc.Save(fs);
                        break;
                    }
                case (PersistFormatEnum.adPersistBinary):
                    {
                        BinaryFormatter binformat = new BinaryFormatter();
                        binformat.Serialize(fs, GetTable());
                        break;
                    }
            }
            fs.Close();
        }

        /// <summary>
        ///     Returns the ColumnCollection corresponding to this RecordSet.
        /// </summary>
        /// <returns>An collection containing a number of columns.</returns>
        public DataColumnCollection GetColumns()
        {
            if (UsingView)
            {
                return _currentView.Table.Columns;
            }
            if (Tables.Count == 0)
            {
                Tables.Add(new DataTable());
            }
            return Tables[CurrentRecordSet].Columns;
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows()
        {
            return GetRows(-1, null, (int[])null);
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be retrieved.</param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows)
        {
            return GetRows(numrows, null, (int[])null);
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be retrieved.</param>
        /// <param name="startfrom">A bookmark representing the row to begin from</param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows, object startfrom)
        {
            return GetRows(numrows, startfrom, new int[] { });
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be retrieved.</param>
        /// <param name="startfrom">A bookmark representing the row to begin from</param>
        /// <param name="fieldname">The field name to be get from the row</param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows, object startfrom, string fieldname)
        {
            return GetRows(numrows, startfrom, new string[] { fieldname });
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be r    etrieved.</param>
        /// <param name="startfrom">A bookmark representing the row to begin from</param>
        /// <param name="fieldnames">An array of field names to be get from the recordset</param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows, object startfrom, string[] fieldnames)
        {
            DataTable table = GetTable();
            int[] fieldpositions = new int[fieldnames.Length];
            for (int i = 0; i < fieldnames.Length; i++)
            {
                fieldpositions[i] = table.Columns.IndexOf(fieldnames[i]);
            }
            return GetRows(numrows, startfrom, fieldpositions);
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be retrieved.</param>
        /// <param name="startfrom">A bookmark representing the row to begin from</param>
        /// <param name="fieldposition">The field index to be get from the recordset </param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows, object startfrom, int fieldposition)
        {
            return GetRows(numrows, startfrom, new int[] { fieldposition });
        }

        /// <summary>
        ///     Returns a two dimmension array representing 'n' rows in a result set.
        /// </summary>
        /// <param name="numrows">Number of rows to be retrieved.</param>
        /// <param name="startfrom">A bookmark representing the row to begin from</param>
        /// <param name="fieldpositions">The field indexes to be get from the recordset</param>
        /// <returns>An array containing a number of rows.</returns>
        public object[,] GetRows(int numrows, object startfrom, int[] fieldpositions)
        {
            object[,] buffer;
            if (startfrom != null)
            {
                DataRow row = startfrom as DataRow;
                if (row != null)
                {
                    Bookmark = row;
                }
                else if (startfrom is BookmarkEnum)
                {
                    switch ((BookmarkEnum)startfrom)
                    {
                        case BookmarkEnum.adBookmarkFirst:
                            MoveFirst();
                            break;
                        case BookmarkEnum.adBookmarkLast:
                            MoveLast();
                            break;
                    }
                }
                else if (startfrom is string)
                {
                    throw new InvalidOperationException("String parameter not supported on the GetRows method");
                }
            }
            DataTable table = GetTable();
            numrows = numrows == -1 ? RecordCount - _index : numrows;
            if (!(fieldpositions == null || fieldpositions.Length <= 0))
            {
                buffer = new object[fieldpositions.Length, numrows];
            }
            else
            {
                buffer = new object[table.Columns.Count, numrows];
            }

            int i = _index, colindex = 0, rowindex = 0;
            for (; !EOF && rowindex < numrows; MoveNext())
            {
                if (!(fieldpositions == null || fieldpositions.Length <= 0))
                {
                    foreach (int fieldposition in fieldpositions)
                    {
                        buffer[colindex, rowindex] = CurrentRow[fieldposition];
                        colindex++;
                    }
                }
                else
                {
                    foreach (Object data in CurrentRow.ItemArray)
                    {
                        buffer[colindex, rowindex] = data;
                        colindex++;
                    }
                }
                colindex = 0;
                rowindex++;
            }
            _index = _eof ? (!UsingView ? table.Rows.Count - 1 : _currentView.Count - 1) : _index;
            object[,] result = new object[buffer.GetLength(0), rowindex];
            for (int rindex = 0; rindex < rowindex; rindex++)
            {
                for (int cindex = 0; cindex < result.GetLength(0); cindex++)
                {
                    result[cindex, rindex] = buffer[cindex, rindex];
                }
            }
            return result;
        }

        /// <summary>
        ///     Moves the position of the currentRecord in a RecordSet.
        /// </summary>
        /// <param name="records">Amount of records positive or negative to move from the current record.</param>
        public void Move(int records)
        {
            Move(records, EventReasonEnum.adRsnMove, EventStatusEnum.adStatusOK);
        }

        /// <summary>
        ///     Moves the current record to the beginning of the ADORecordsetHelper.
        /// </summary>
        public override void MoveFirst()
        {
            MoveFirst(EventReasonEnum.adRsnMoveFirst);
        }

        /// <summary>
        ///     Moves the current record to the end of the ADORecordsetHelper.
        /// </summary>
        /// <param name="options"></param>
        public void MoveLast(int options)
        {
            //TODO: ToBeImplemented where Options != 0
            if (options == 0)
            {
                MoveLast();
            }
        }

        /// <summary>
        ///     Moves the current record to the end of the ADORecordsetHelper.
        /// </summary>
        public override void MoveLast()
        {
            Move((UsingView ? _currentView.Count - 1 : Tables[CurrentRecordSet].Rows.Count - 1) - _index, EventReasonEnum.adRsnMoveLast,
                 EventStatusEnum.adStatusOK);
        }

        /// <summary>
        ///     Moves the current record forward one position.
        /// </summary>
        public override void MoveNext()
        {
            Move(1, EventReasonEnum.adRsnMoveNext, EventStatusEnum.adStatusOK);
        }

        /// <summary>
        ///     Moves the current record backwards one position.
        /// </summary>
        public override void MovePrevious()
        {
            Move(-1, EventReasonEnum.adRsnMovePrevious, EventStatusEnum.adStatusOK);
        }

        /// <summary>
        ///     Creates a new record for an updatable Recordset.
        /// </summary>
        /// <param name="cols">Array containing the names of the columns to be added to the ADORecordsetHelper.</param>
        /// <param name="values">Array containing the values for the rows to be inserted on the ADORecordsetHelper.</param>
        public void AddNew(object[] cols, object[] values)
        {
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            OnWillMove(EventReasonEnum.adRsnAddNew, ref status);
            if (status != EventStatusEnum.adStatusCancel)
            {
                OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
                if (status != EventStatusEnum.adStatusCancel)
                {
                    if (cols != null && values != null)
                    {
                        doAddNew();
                        OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, null);
                        for (int i = 0; i < cols.Length; i++)
                        {
                            if (i == 0)
                            {
                                OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
                            }
                            CurrentRow[cols[i].ToString()] = values[i];
                            if (i == 0)
                            {
                                OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, null);
                            }
                        }
                        if (!isBatchEnabled())
                            Update();
                    }
                }
                OnMoveComplete(EventReasonEnum.adRsnAddNew, ref status, null);
            }
        }


        /// <summary>
        ///     Creates a new record for an updatable Recordset.
        /// </summary>
        public override void AddNew()
        {
            //Validations. AddNew is not allowed for Recordset with ReadOnly LockType
            if (LockType == LockTypeEnum.LockReadOnly)
            {
                throw new NotSupportedException("AddNew is not supported for RecordSets with a LockType " + LockType);
            }
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            OnWillMove(EventReasonEnum.adRsnMove, ref status);
            string[] errors = null;
            if (status != EventStatusEnum.adStatusCancel)
            {
                OnWillChangeRecord(EventReasonEnum.adRsnAddNew, ref status, 1);
                if (status != EventStatusEnum.adStatusCancel)
                {
                    try
                    {
                        if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
                        {
                            _editMode = EditModeEnum.EditAdd;
                        }
                        doAddNew();
                    }
                    catch (Exception e)
                    {
                        errors = (new string[] { e.Message });
                        status = EventStatusEnum.adStatusErrorsOccurred;
                    }
                    OnRecordChangeComplete(EventReasonEnum.adRsnAddNew, ref status, 1, errors);
                }
                OnMoveComplete(EventReasonEnum.adRsnMove, ref status, errors);
            }
        }

        /// <summary>
        ///     Deletes the current record or a group of records.
        /// </summary>
        /// <param name="deleteBehavior">AffectEnum value indicating if the deletion applies to the current group or a group.</param>
        public void Delete(int deleteBehavior)
        {
            Exception exceptionToThrow = null;
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            OnWillChangeRecord(EventReasonEnum.adRsnDelete, ref status, 1);
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
                    {
                        _editMode = EditModeEnum.EditDelete;
                    }
                    DataRow deletingRow;
                    switch (deleteBehavior)
                    {
                        case (int)AffectEnum.adAffectCurrent:
                            deletingRow = _currentView[_index].Row;
                            break;
                        case (int)AffectEnum.adAffectGroup:
                            deletingRow = GetTable().Rows[_index];
                            break;
                        default:
                            throw new ArgumentException("Value not allowed to delete.");
                    }
                    deletingRow.Delete();
                    if (UsingView)
                    {
                        _index = -1;
                    }
                    if (!isBatchEnabled())
                        Update();
                }
                catch (Exception e)
                {
                    if (!isBatchEnabled() || _editMode != EditModeEnum.EditNone)
                    {
                        _editMode = EditModeEnum.EditInProgress;
                    }
                    exceptionToThrow = e;
                }
                if (exceptionToThrow != null)
                {
                    throw exceptionToThrow;
                }
                OnRecordChangeComplete(EventReasonEnum.adRsnDelete, ref status, 1, null);
            }
        }

        /// <summary>
        ///     Deletes the current record.
        /// </summary>
        public void Delete()
        {
            Delete((int)AffectEnum.adAffectCurrent);
        }

        /// <summary>
        ///     Not implemented yet.
        /// </summary>
        public void Edit()
        {
            //TODO: ToBeImplemented
            //throw new System.Exception("Method or Property not implemented yet!");
        }

        /// <summary>
        ///     Saves any changes you make to the current row of an ADORecordsetHelper object.
        /// </summary>
        public override void Update()
        {
            // This is done to support disconnected recordSet operations.
            if (SupportsDisconnectedRecordsetOperations)
            {
                if (UsingView && _dbvRow != null)
                {
                    _currentView.Table.DataSet.EnforceConstraints = true;
                    _dbvRow.EndEdit();
                    _index = findBookmarkIndex(_dbvRow.Row);
                }
                AcceptChanges();
            }
            else
            {
                Update(true);
            }
        }

        /// <summary>
        ///     Saves the current content of the ADORecordsetHelper to the database.
        /// </summary>
        /// <param name="updateType">>The UpdateType to be use by this update.</param>
        /// <param name="force">A Boolean value indicating whether or not to force the changes into the database.</param>
        public void Update(int updateType, bool force)
        {
            //note: No case has been found to use the specialization parameters. 
            //if (UpdateType == 1)
            Update();
        }

        /// <summary>
        ///     Updates the provided “Fields” with the “values” received has parameter.
        /// </summary>
        /// <param name="fields">Array containing the fields to be updated.</param>
        /// <param name="values">Array containing the values to be used to update the fields.</param>
        public void Update(object[] fields, object[] values)
        {
            if (fields == null)
            {
                throw new ArgumentException("RecordSetHelper.Update fields parameter cannot be null ");
            }
            if (fields.Length == 0)
            {
                throw new ArgumentException("RecordSetHelper.Update fields parameter lenght cannot be zero ");
            }
            if (values == null)
            {
                throw new ArgumentException("RecordSetHelper.Update values parameter cannot be null ");
            }
            if (values.Length == 0)
            {
                throw new ArgumentException("RecordSetHelper.Update values parameter lenght cannot be zero ");
            }
            if (values.Length != fields.Length)
            {
                throw new ArgumentException("RecordSetHelper.Update fields and values arrays have to be of the same lenght");
            }

            Type elementType = fields[0].GetType();
            bool isString = elementType.Equals(Type.GetType("System.String"));
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            OnWillChangeField(ref status, fields.Length, iterateFields(fields, values, isString, true));
            if (status != EventStatusEnum.adStatusCancel)
            {
                OnFieldChangeComplete(ref status, fields.Length, iterateFields(fields, values, isString, false), new string[] { });
                Update();
            }
        }


        /// <summary>
        ///     Writes all pending batch updates to disk.
        /// </summary>
        public void UpdateBatch()
        {
            Exception exceptionToThrow = null;
            if (UsingView)
            {
                _currentView.Table.DataSet.EnforceConstraints = true;
                _dbvRow.EndEdit();
                _index = findBookmarkIndex(_dbvRow.Row);
            }
            if (isBatchEnabled())
            {
                DbConnection connection = GetConnection(_connectionString);
                using (DbDataAdapter dbAdapter = CreateAdapter(connection, true))
                {
                    DataTable changes = UsingView ? _currentView.Table.GetChanges() : Tables[CurrentRecordSet].GetChanges();
                    if (changes != null)
                    {
                        EventStatusEnum status = EventStatusEnum.adStatusOK;
                        string[] errors = null;
                        OnWillChangeRecord(EventReasonEnum.adRsnUpdate, ref status, 1);
                        if (status != EventStatusEnum.adStatusCancel)
                        {
                            try
                            {
                                UpdateByRowState(dbAdapter);
                                _editMode = EditModeEnum.EditNone;
                            }
                            catch (Exception e)
                            {
                                errors = (new string[] { e.Message });
                                exceptionToThrow = e;
                            }
                            OnRecordChangeComplete(EventReasonEnum.adRsnUpdate, ref status, 1, errors);
                            if (exceptionToThrow != null)
                            {
                                throw exceptionToThrow;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateByRowState(DbDataAdapter dbAdapter)
        {
            DataSet table = _isClone ? _currentView.Table.DataSet : this;

            for (int j = table.Tables[CurrentRecordSet].Rows.Count - 1; j >= 0; j--)
            {
                if (table.Tables[CurrentRecordSet].Rows[j].RowState != DataRowState.Added)
                {
                    dbAdapter.Update(new DataRow[] { table.Tables[CurrentRecordSet].Rows[j] });
                }
            }

            for (int j = table.Tables[CurrentRecordSet].Rows.Count - 1; j >= 0; j--)
            {
                if (table.Tables[CurrentRecordSet].Rows[j].RowState == DataRowState.Added)
                {
                    dbAdapter.Update(new DataRow[] { table.Tables[CurrentRecordSet].Rows[j] });
                }
            }
            return;
        }

        /// <summary>
        ///     Cancels a pending batch update.
        /// </summary>
        public void CancelBatch()
        {
            bool wasNewRow = _newRow;
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            string[] errors = null;
            OnWillChangeRecord(wasNewRow ? EventReasonEnum.adRsnUndoAddNew : EventReasonEnum.adRsnUndoUpdate, ref status, 1);
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    //base.CancelBatch();
                    GetTable().RejectChanges();
                    _newRow = false;

                    _index = -1;
                    _editMode = EditModeEnum.EditNone;
                }
                catch (Exception e)
                {
                    errors = (new string[] { e.Message });
                }
                OnRecordChangeComplete(wasNewRow ? EventReasonEnum.adRsnUndoAddNew : EventReasonEnum.adRsnUndoUpdate, ref status, 1,
                                       errors);
            }
        }


        /// <summary>
        ///     Cancels execution of any pending process.
        /// </summary>
        public void Cancel()
        {
            if (_index >= 0 && (CurrentRow.RowState != DataRowState.Unchanged))
            {
                try
                {
                    //  base.Cancel();
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        ///     Updates the provided "field" with the "value" recieved has parameter.
        /// </summary>
        /// <param name="field">The field to be updated.</param>
        /// <param name="value">The value to update the field with.</param>
        public void Update(object field, object value)
        {
            if (field == null)
            {
                throw new ArgumentException("RecordSetHelper.Update field parameter cannot be null ");
            }
            if (value == null)
            {
                throw new ArgumentException("RecordSetHelper.Update value parameter cannot be null ");
            }
            Type elementType = field.GetType();
            bool isString = elementType == Type.GetType("System.String");
            bool isInt = elementType == Type.GetType("System.Int16") || elementType.Equals(Type.GetType("System.Int32")) ||
                         elementType == Type.GetType("System.Int64");
            if (isString)
            {
                this[(String)field] = value;
            }
            else if (isInt)
            {
                this[(int)field] = value;
            }
            try
            {
                UpdateWithNoEvents(CurrentRow);
            }
            catch
            {
            }
        }

        /// <summary>
        ///     Cancels any changes made to the current or new row of a ADORecordsetHelper object.
        /// </summary>
        public void CancelUpdate()
        {
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            string[] errors = null;
            OnWillChangeRecord(EventReasonEnum.adRsnUndoUpdate, ref status, 1);
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    // base.CancelUpdate();
                    DoCancelUpdate();
                    _editMode = EditModeEnum.EditNone;
                }
                catch (Exception e)
                {
                    errors = (new string[] { e.Message });
                }
                OnRecordChangeComplete(EventReasonEnum.adRsnUndoUpdate, ref status, 1, errors);
            }
        }

        /// <summary>
        ///     Closes an open object and any dependent objects.
        /// </summary>
        public override void Close()
        {
            if (HasChanges() && !isBatchEnabled())
            {
                // throw new InvalidOperationException("Cancel or update required");
                Cancel();
            }
            //base.Close();
            try
            {
                if (Tables.Count > 0)
                {
                    Tables[CurrentRecordSet].Rows.Clear();
                    Tables.Clear();
                }
                if (_activeCommand != null)
                {
                    _activeCommand.Connection = null;
                    _activeCommand.Dispose();
                }
                if (ActiveConnection != null)
                {
                    if (ActiveConnection.State == ConnectionState.Open && _connectionStateAtEntry == ConnectionState.Closed)
                    {
                        ActiveConnection.Close();
                    }
                }
                _opened = false;


                _isClone = false;
                State = ConnectionState.Closed;
                EventStatusEnum status = EventStatusEnum.adStatusOK;
                OnRecordsetChangeComplete(EventReasonEnum.adRsnClose, ref status, null);
            }
            catch (Exception)
            {
            }
            Dispose();
        }

        /// <summary>
        ///     This method clones the recordset instance
        /// </summary>
        /// <returns>The cloned recordset</returns>
        public new ADORecordSetHelper Clone()
        {
            return Clone(LockType);
        }

        /// <summary>
        ///     This method clones the recordset instance
        /// </summary>
        /// <param name="lockType">The lock type to be used by the cloned recorset</param>
        /// <returns>The cloned recordset</returns>
        public ADORecordSetHelper Clone(LockTypeEnum lockType)
        {
            ADORecordSetHelper result = new ADORecordSetHelper();
            if (CurrentRow != null)
                CurrentRow.EndEdit();
            CloneIt(this, result);
            result.LockType = lockType;
            return result;
        }

        /// <summary>
        ///     Clone a source ADORecordSetHelper through a target ADORecordSetHelper
        /// </summary>
        /// <param name="source">The source ADORecordSetHelper</param>
        /// <param name="target">The target ADORecordSetHelper</param>
        private void CloneIt(ADORecordSetHelper source, ADORecordSetHelper target)
        {
            target.DatabaseType = source.DatabaseType;
            target.ProviderFactory = source.ProviderFactory;
            target._opened = true;
            target._isClone = true;
            target.ActiveConnection = source.ActiveConnection;
            target._activeCommand = source._activeCommand;
            if (source.Tables.Count > 0)
            {
                target._currentView = new DataView(source.GetTable());
                target._currentView.ListChanged += DataView_ListChanged;
                foreach (DataTable sourceTable in Tables)
                {
                    target.Tables.Add(sourceTable.Copy());
                }
            }
            else if (source.UsingView)
            {
                target._currentView = source._currentView;
            }
            target.State = source.State;
            target.CursorLocation = source.CursorLocation;
            if (source.FieldChangeComplete != null)
            {
                target.FieldChangeComplete = source.FieldChangeComplete;
            }
            if (source.RecordChangeComplete != null)
            {
                target.RecordChangeComplete = source.RecordChangeComplete;
            }
            if (source.WillChangeField != null)
            {
                target.WillChangeField = source.WillChangeField;
            }
            if (source.WillChangeRecord != null)
            {
                target.WillChangeRecord = source.WillChangeRecord;
            }
            if (target._currentView != null && target._currentView.Count > 0)
            {
                target._index = 0;
                target._eof = false;
            }
        }

        /// <summary>
        ///     Updates the data in a Recordset object by re-executing the query on which the object is based.
        /// </summary>
        public void Refresh()
        {
            Requery();
        }


        /// <summary>
        ///     Returns a new recordset according to the compound statement on the current recordset
        /// </summary>
        /// <returns>A new open recordset</returns>
        public ADORecordSetHelper NextRecordSet()
        {
            ADORecordSetHelper result = null;
            if (CurrentRecordSet < Tables.Count - 1)
            {
                CurrentRecordSet++;
                result = this;
            }
            else
            {
                this.Close();
                if (_commands != null && _commands.Count > 0)
                {
                    this.Open(_commands.Dequeue());
                    result = this;
                }
            }
            return result;
        }


        /// <summary>
        ///     Updates the data in a Recordset object by re-executing the query on which the object is based.
        /// </summary>
        public override void Requery()
        {
            Open(true);
        }


        /// <summary>
        ///     Sets the “value” to the column at index “ColumnIndex”.
        /// </summary>
        /// <param name="columnIndex">Index of the column to update.</param>
        /// <param name="value">The new value for the column.</param>
        public void SetNewValue(int columnIndex, object value)
        {
            EventStatusEnum status = EventStatusEnum.adStatusOK;
            string[] errors = null;
            if (_firstChange)
            {
                OnWillChangeRecord(EventReasonEnum.adRsnFirstChange, ref status, 1);
            }
            OnWillChangeField(ref status, 1, (new Object[] { CurrentRow[columnIndex] }));
            if (status != EventStatusEnum.adStatusCancel)
            {
                try
                {
                    // base.SetNewValue(columnIndex, value);
                    CurrentRow[columnIndex] = value;
                }
                catch (Exception e)
                {
                    status = EventStatusEnum.adStatusErrorsOccurred;
                    errors = new string[] { e.Message };
                }
                OnFieldChangeComplete(ref status, 1, (new Object[] { CurrentRow[columnIndex] }), errors);
                if (_firstChange)
                {
                    OnRecordChangeComplete(EventReasonEnum.adRsnFirstChange, ref status, 1, errors);
                }
            }
        }

	    public FieldsHelper Fields
	    {
		    get { return new FieldsHelper(this); }
	    }

	    /// <summary>
        ///     Gets or sets the row value at “ColumnName” index.
        /// </summary>
        /// <param name="columnName">Name of the column to look for.</param>
        /// <returns>The value at the given index.</returns>
        public ADOFieldHelper GetField(String columnName)
        {
            int i;
            ADOFieldHelper newField = new ADOFieldHelper(this, columnName, int.TryParse(columnName, out i));
            return newField;
        }

        /// <summary>
        ///     Gets or sets the row value at “ColumnIndex” index.
        /// </summary>
        /// <param name="columnIndex">index of the column to look for.</param>
        /// <returns>The value at the given index.</returns>
        public ADOFieldHelper GetField(int columnIndex)
        {
            ADOFieldHelper newField = new ADOFieldHelper(this, columnIndex, true);
            return newField;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override RecordSetHelper CreateInstance()
        {
            return new ADORecordSetHelper();
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanMovePrevious
        {
            get
            {
                return _index > 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanMoveNext
        {
            get
            {
                bool res = false;
                if (this.Tables.Count > 0)
                {
                    res = _index < this.Tables[CurrentRecordSet].Rows.Count - 1;
                }
                return res;
            }
        }



    }
}
