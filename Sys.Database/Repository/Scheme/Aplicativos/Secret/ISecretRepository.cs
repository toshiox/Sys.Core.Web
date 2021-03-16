using System.Collections.Generic;
using System.Data.SqlClient;
using Sys.Model.Database.Aplicativos;

namespace Sys.Database.Repository.Scheme.Aplicativos.Secret
{
    public interface ISecretRepository
    {
        Sys.Model.Database.Aplicativos.Secret Insert(Sys.Model.Database.Aplicativos.Secret model);
        List<Sys.Model.Database.Aplicativos.Secret> List();
        Sys.Model.Database.Aplicativos.Secret ListById(Sys.Model.Database.Aplicativos.Secret model);
        List<Sys.Model.Database.Aplicativos.Secret> LoopDataReaderRows(SqlDataReader sqlDataReader);
    }
}