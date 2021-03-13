using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Scope
{
    public interface IScopeRepository
    {
        Sys.Model.Database.Aplicativos.Scope Insert(Sys.Model.Database.Aplicativos.Scope model);
        Task<Sys.Model.Database.Aplicativos.Scope> InsertAsync(Sys.Model.Database.Aplicativos.Scope model);
        List<Sys.Model.Database.Aplicativos.Scope> List();
        Sys.Model.Database.Aplicativos.Scope ListById(Sys.Model.Database.Aplicativos.Scope model);
        Sys.Model.Database.Aplicativos.Scope ListByName(Sys.Model.Database.Aplicativos.Scope model);
    }
}