using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.GrantType
{
    public interface IGrantTypeRepository
    {
        Model.DataBase.GrantType Insert(Model.DataBase.GrantType model);
        Task<Model.DataBase.GrantType> InsertAsync(Model.DataBase.GrantType model);
        List<Model.DataBase.GrantType> List();
        Model.DataBase.GrantType ListById(Model.DataBase.GrantType model);
        Model.DataBase.GrantType ListByName(Model.DataBase.GrantType model);
    }
}