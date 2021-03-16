using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.Scheme.Aplicativos.ClitScopes
{
    public interface IClitScopesRepository
    {
        Sys.Model.Database.Aplicativos.ClitScopes Insert(Sys.Model.Database.Aplicativos.ClitScopes model);
        Task<Sys.Model.Database.Aplicativos.ClitScopes> InsertAsync(Sys.Model.Database.Aplicativos.ClitScopes model);
        List<Sys.Model.Database.Aplicativos.ClitScopes> List();
        List<Sys.Model.Database.Aplicativos.ClitScopes> ListById(Sys.Model.Database.Aplicativos.ClitScopes model);
        List<Sys.Model.Database.Aplicativos.ClitScopes> ListByScopeId(Sys.Model.Database.Aplicativos.ClitScopes model);
    }
}