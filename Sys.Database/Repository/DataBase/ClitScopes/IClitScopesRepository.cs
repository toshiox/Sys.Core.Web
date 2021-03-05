using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.ClitScopes
{
    public interface IClitScopesRepository
    {
        Model.DataBase.ClitScopes Insert(Model.DataBase.ClitScopes model);
        Task<Model.DataBase.ClitScopes> InsertAsync(Model.DataBase.ClitScopes model);
        List<Model.DataBase.ClitScopes> List();
        List<Model.DataBase.ClitScopes> ListById(Model.DataBase.ClitScopes model);
    }
}