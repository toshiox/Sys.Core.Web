using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Client
{
    public interface IClientRepository
    {
        Sys.Model.Database.Aplicativos.Client Insert(Sys.Model.Database.Aplicativos.Client model);
        Task<Sys.Model.Database.Aplicativos.Client> InsertAsync(Sys.Model.Database.Aplicativos.Client model);
        List<Sys.Model.Database.Aplicativos.Client> List();
        Sys.Model.Database.Aplicativos.Client ListById(Sys.Model.Database.Aplicativos.Client model);
        Sys.Model.Database.Aplicativos.Client ListByUniqueKey(Sys.Model.Database.Aplicativos.Client model);
    }
}