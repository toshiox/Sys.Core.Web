using Sys.Model.Database.Negocios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Negocios.AssDig
{
    public interface IAssDigRepository
    {
        Sys.Model.Database.Negocios.AssDig Insert(Sys.Model.Database.Negocios.AssDig model);
        List<Sys.Model.Database.Negocios.AssDig> List();
        Sys.Model.Database.Negocios.AssDig ListByCompany(Sys.Model.Database.Negocios.AssDig model);
    }
}