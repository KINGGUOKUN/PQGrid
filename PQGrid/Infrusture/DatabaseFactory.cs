using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace PQGrid.Infrusture
{
    public class DatabaseFactory
    {
        #region Private Fields

        private static readonly ConcurrentDictionary<string, IDatabase> _databases = new ConcurrentDictionary<string, IDatabase>();

        #endregion

        #region Public Methods

        public static IDatabase CreateDatabase()
        {
            return CreateDatabase("default");
        }

        public static IDatabase CreateDatabase(string connectionName)
        {
            if (_databases.ContainsKey(connectionName))
            {
                return _databases[connectionName];
            }
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            IDatabase database = new Database(new MySql.Data.MySqlClient.MySqlConnection(connectionString),
                new SqlGeneratorImpl(new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new MySqlDialect())));
            _databases.TryAdd(connectionName, database);

            return database;
        }

        #endregion
    }
}