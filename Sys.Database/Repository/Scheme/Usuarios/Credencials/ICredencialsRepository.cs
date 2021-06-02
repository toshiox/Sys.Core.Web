using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sys.Database.Repository.Scheme.Usuarios.Credencials
{
    public interface ICredencialsRepository
    {
        Sys.Model.Database.Usuarios.Credencials Delete(Sys.Model.Database.Usuarios.Credencials model);
        Sys.Model.Database.Usuarios.Credencials Insert(Sys.Model.Database.Usuarios.Credencials model);
        List<Sys.Model.Database.Usuarios.Credencials> List();
        Sys.Model.Database.Usuarios.Credencials ListByLogin(Sys.Model.Database.Usuarios.Credencials model);
        Sys.Model.Database.Usuarios.Credencials ListByUserId(Sys.Model.Database.Usuarios.Credencials model);
        List<Sys.Model.Database.Usuarios.Credencials> LoopDataReaderRows(SqlDataReader sqlDataReader);
        Sys.Model.Database.Usuarios.Credencials Update(Sys.Model.Database.Usuarios.Credencials model);
    }
}