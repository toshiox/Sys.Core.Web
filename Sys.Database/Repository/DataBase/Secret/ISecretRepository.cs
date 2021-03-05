using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.DataBase.Secret
{
    public interface ISecretRepository
    {
        Model.DataBase.Secret Insert(Model.DataBase.Secret model);
        List<Model.DataBase.Secret> List();
        Model.DataBase.Secret ListById(Model.DataBase.Secret model);
        List<Model.DataBase.Secret> LoopDataReaderRows(SqlDataReader sqlDataReader);
    }
}