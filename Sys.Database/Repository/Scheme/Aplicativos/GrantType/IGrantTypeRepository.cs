using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.Scheme.Aplicativos.GrantType
{
    public interface IGrantTypeRepository
    {
        Sys.Model.Database.Aplicativos.GrantType Insert(Sys.Model.Database.Aplicativos.GrantType model);
        Task<Sys.Model.Database.Aplicativos.GrantType> InsertAsync(Sys.Model.Database.Aplicativos.GrantType model);
        List<Sys.Model.Database.Aplicativos.GrantType> List();
        Sys.Model.Database.Aplicativos.GrantType ListById(Sys.Model.Database.Aplicativos.GrantType model);
        Sys.Model.Database.Aplicativos.GrantType ListByName(Sys.Model.Database.Aplicativos.GrantType model);
    }
}