using System;
using System.Configuration;
using System.Data;
using System.Data.Common;


namespace DataTable.Core.Database
{
    /// <summary>
    /// This class implements ORACLE based database context
    /// </summary>
    public class SqlDatabaseContext : IDatabaseContext, IDisposable
    {
        private const string ProviderName = "System.Data.SqlClient";

        /// <summary>
        /// ConnectionString property
        /// </summary>
        protected readonly string _connectionString;

        /// <summary>
        /// Connection to database
        /// </summary>
        protected DbConnection _connection;

        /// <summary>
        /// Get connection string inside constructor.
        /// So when the class will be initialized then connection string will be automatically get from web.config
        /// </summary>
        public SqlDatabaseContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SqlDatabaseConnection"].ConnectionString;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    var factory = DbProviderFactories.GetFactory(ProviderName);
                    _connection = factory.CreateConnection();
                    _connection.ConnectionString = _connectionString;
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        /// <summary>
        /// Dispose Connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
