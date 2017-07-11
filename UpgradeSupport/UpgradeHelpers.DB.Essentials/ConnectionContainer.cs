using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace UpgradeHelpers.DB
{
    /// <summary>
    /// Class that contains a DbConnection.
    /// </summary>
    public class ConnectionContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public ConnectionContainer()
        {
        }

        DbConnection _connection;
        /// <summary>
        /// The DbConnection contained by this class.
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
    }
}
