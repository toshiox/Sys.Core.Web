using Sys.Model.Database.Negocios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Negocios.Empr
{
    public interface IEmprRepository
    {
        Empresa Insert(Sys.Model.Database.Negocios.Empresa model);
        List<Empresa> List();
        Empresa ListById(Sys.Model.Database.Negocios.Empresa model);

        void Update(Sys.Model.Database.Negocios.Empresa model);
    }
}