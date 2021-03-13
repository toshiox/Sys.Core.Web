using Sys.Model.Database.Negocios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.DataBase.Negocios.Empr
{
    public interface IEmprRepository
    {
        Empresa Insert(Sys.Model.Database.Negocios.Empresa model);
        List<Empresa> List();
        Empresa ListById(Sys.Model.Database.Negocios.Empresa model);
        List<Empresa> LoopDataReaderRows(SqlDataReader sqlDataReader);
    }
}