using System.Data;

namespace Sys.Database.Repository.Scheme
{
    public interface IConfiguration
    {
        IDbCommand CreateStoredProcedure(IDbConnection connection, string commandName);
        object ExecuteNonQuery(string commandText, string connectionStringName = null);
        IDataReader ExecuteQuery(string commandText, string connectionStringName = null);
        IDbConnection GetConnection(string connectionStringName);
    }
}