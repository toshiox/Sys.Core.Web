using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Client
{
    public interface IClientRepository
    {
        Model.DataBase.Client Insert(Model.DataBase.Client model);
        Task<Model.DataBase.Client> InsertAsync(Model.DataBase.Client model);
        List<Model.DataBase.Client> List();
        Model.DataBase.Client ListById(Model.DataBase.Client model);
        Model.DataBase.Client ListByUniqueKey(Model.DataBase.Client model);
    }
}