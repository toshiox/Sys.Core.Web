using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Front.Group
{
    public interface IGroupRepository
    {
        List<Sys.Model.Database.Front.Group> List();
        Sys.Model.Database.Front.Group ListById(Sys.Model.Database.Front.Group model);
    }
}