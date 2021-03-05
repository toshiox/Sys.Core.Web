using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Scope
{
    public interface IScopeRepository
    {
        Model.DataBase.Scope Insert(Model.DataBase.Scope model);
        Task<Model.DataBase.Scope> InsertAsync(Model.DataBase.Scope model);
        List<Model.DataBase.Scope> List();
        Model.DataBase.Scope ListById(Model.DataBase.Scope model);
        Model.DataBase.Scope ListByName(Model.DataBase.Scope model);
    }
}