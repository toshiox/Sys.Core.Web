using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Negocios.Finac
{
    public interface IFinacRepository
    {
        Sys.Model.Database.Negocios.Finac Insert(Sys.Model.Database.Negocios.Finac model);
        List<Sys.Model.Database.Negocios.Finac> List();
        Sys.Model.Database.Negocios.Finac ListByCompany(Sys.Model.Database.Negocios.Finac model);
        Sys.Model.Database.Negocios.Finac ListById(Sys.Model.Database.Negocios.Finac model);
    }
}