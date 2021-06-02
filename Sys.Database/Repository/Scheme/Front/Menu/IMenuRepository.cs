using Sys.Model.Database.Front;
using System.Collections.Generic;

namespace Sys.Database.Repository.Scheme.Front.Menu
{
    public interface IMenuRepository
    {
        Sys.Model.Database.Front.Menu Delete(Sys.Model.Database.Front.Menu model);
        Sys.Model.Database.Front.Menu Insert(Sys.Model.Database.Front.Menu model);
        List<Sys.Model.Database.Front.Menu> List();
        Sys.Model.Database.Front.Menu ListByName(Sys.Model.Database.Front.Menu model);
        Sys.Model.Database.Front.Menu ListById(Sys.Model.Database.Front.Menu model);
        void Update(Sys.Model.Database.Front.Menu model);
    }
}
