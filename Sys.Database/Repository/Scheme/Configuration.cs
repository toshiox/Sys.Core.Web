using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace Sys.Database.Repository.Scheme
{
    public class Configuration : IConfiguration
    {
        private readonly Model.Json.AppSettings _config;
        private IDbConnection _connection = null;

        public Configuration()
        {
            _config = JsonSerializer.Deserialize<Model.Json.AppSettings>
                    (System.IO.File.ReadAllText($"{Sys.Model.Services.Struct.Database.ConfigureConstants.Path}"));
        }

        public IDbConnection GetConnection(string connectionStringName)
        {
            if (_connection != null)
                return _connection;

            this._connection = new SqlConnection(_config.ConnectionString.dbSys);

            _connection.Open();
            return _connection;
        }


        public IDbCommand CreateStoredProcedure(IDbConnection connection, string commandName)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandName;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }


        public IDataReader ExecuteQuery(string commandText, string connectionStringName = null)
        {
            IDbCommand command = CreateStoredProcedure(GetConnection(connectionStringName), commandText);
            IDataReader reader = command.ExecuteReader();

            return reader;
        }


        public object ExecuteNonQuery(string commandText, string connectionStringName = null)
        {
            IDbCommand command = null;

            try
            {
                command = CreateStoredProcedure(GetConnection(connectionStringName), commandText);

                int returnValue = command.ExecuteNonQuery();

                return returnValue;
            }
            finally
            {
                command?.Dispose();
            }
        }

        public IDataReader ExecuteQuery(string commandText, IEnumerable<IDbDataParameter> paramCollection, string connectionStringName = null)
        {
            IDbCommand command = CreateStoredProcedure(GetConnection(connectionStringName), commandText);

            foreach (IDbDataParameter dbDataParameter in paramCollection)
            {
                command.Parameters.Add(dbDataParameter);
            }

            IDataReader reader = command.ExecuteReader();

            return reader;
        }

    }
}
