using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Negocios.TypFlx
{
    public interface ITypFlxRepository
    {
        Sys.Model.Database.Negocios.TypFlx Insert(Sys.Model.Database.Negocios.TypFlx model);
        List<Sys.Model.Database.Negocios.TypFlx> List();
        Sys.Model.Database.Negocios.TypFlx ListById(Sys.Model.Database.Negocios.TypFlx model);
        Sys.Model.Database.Negocios.TypFlx ListByName(Sys.Model.Database.Negocios.TypFlx model);
    }
}