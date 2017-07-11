using System;
using System.Collections.Generic;
using System.Data.Common;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// This is the base class to administrate multiple connections under the same structure with the possibility to use a transactional model for all the connections.
    /// </summary>
    public class ConnectionContainers<T> where T : ConnectionContainer, new()
    {
        private readonly List<T> _connections;
        private DbProviderFactory _factory;

        /// <summary>
        /// Creates a new ConnectionContainers object.
        /// </summary>
        protected ConnectionContainers()
        {
            _connections = new List<T>();
        }

        /// <summary>
        /// Creates a new ConnectionContainers object and set the DBProviderFactory to “factory”.
        /// </summary>
        /// <param name="factory">The factory to be used by the connections created with this ConnectionContainers object.</param>
        protected ConnectionContainers(DbProviderFactory factory)
            : this()
        {
            _factory = factory;
        }

        /// <summary>
        /// Sets the DBProviderFactory to be use in the connections created with this ConnectionContainers object.
        /// </summary>
        public DbProviderFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        /// <summary>
        /// Gets the list of all connections contained in this object.
        /// </summary>
        public List<T> Connections
        {
            get { return _connections; }
        }

        /// <summary>
        /// Begins a transaction for a specific connection.
        /// </summary>
        /// <param name="connection">The connection where the transaction will be initiated.</param>
        private void BeginTransaction(T connection)
        {
            TransactionManager.Enlist(connection.Connection);
        }

        /// <summary>
        /// Begins a transaction for all connections contained in this object.
        /// </summary>
        public void BeginTransaction()
        {
            _connections.ForEach(BeginTransaction);
        }

        /// <summary>
        /// Closes a transaction for a specific connection.
        /// </summary>
        /// <param name="connection">The connection where the transaction will be close.</param>
        private void Close(T connection)
        {
            TransactionManager.DeEnlist(connection.Connection);
            connection.Connection.Close();
        }

        /// <summary>
        /// Closes a transaction for all connections contained in this object.
        /// </summary>
        public void Close()
        {
            _connections.ForEach(Close);
        }

        /// <summary>
        /// Commits a transaction for a specific connection.
        /// </summary>
        /// <param name="connection">The connection where the transaction will be committed.</param>
        private void CommitTransaction(T connection)
        {
            TransactionManager.Commit(connection.Connection);
        }

        /// <summary>
        /// Commits a transaction for all connections contained in this object.
        /// </summary>
        public void CommitTransaction()
        {
            _connections.ForEach(CommitTransaction);
        }

        /// <summary>
        /// Rollbacks a transaction for a specific connection.
        /// </summary>
        /// <param name="connection">The connection to work on.</param>
        private void Rollback(T connection)
        {
            TransactionManager.Rollback(connection.Connection);
        }

        /// <summary>
        /// Rollbacks a transaction for all connections contained in this object.
        /// </summary>
        public void Rollback()
        {
            _connections.ForEach(Rollback);
        }


        /// <summary>
        /// Creates a new connection and opens it using the provided connection string.
        /// </summary>
        /// <param name="connectionString">The connection string with the information to connect to a database.</param>
        /// <returns>The newly created DBConnection object.</returns>
        protected ConnectionContainer Open(String connectionString)
        {
            DbConnection result = _factory.CreateConnection();
            if (result != null)
            {
                result.ConnectionString = connectionString;
                result.Open();
                T connectionContainer = new T();
                connectionContainer.Connection = result;
                _connections.Add(connectionContainer);
                result.StateChange += result_StateChange;
                return connectionContainer;
            }
            return null;
        }

        /// <summary>
        /// Event that notifies the current state of a change.
        /// </summary>
        /// <param name="sender">The object where the event was raised.</param>
        /// <param name="e">Additional event information.</param>
        void result_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (e.CurrentState == System.Data.ConnectionState.Closed)
            {
                foreach (T connectionContainer in _connections)
                {
                    if (connectionContainer.Connection == sender)
                    {
                        _connections.Remove(connectionContainer);
                        break;
                    }
                }
            }
        }
    }
}
