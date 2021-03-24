using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Negocios.Tax
{
    public interface ITaxRepository
    {
        Sys.Model.Database.Negocios.Tax Insert(Sys.Model.Database.Negocios.Tax model);
        List<Sys.Model.Database.Negocios.Tax> List();
        Sys.Model.Database.Negocios.Tax ListByCompany(Sys.Model.Database.Negocios.Tax model);
    }
}