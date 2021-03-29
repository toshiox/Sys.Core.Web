using Sys.Model.Database.Usuarios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Usuarios.Users
{
    public interface IUsersRepository
    {
        User Delete(User model);
        User Insert(User model);
        List<User> List();
        User ListByCPF(User model);
        User ListById(User model);
        List<User> LoopDataReaderRows(SqlDataReader sqlDataReader);
        User Update(User model);
    }
}