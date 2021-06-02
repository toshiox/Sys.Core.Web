using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Repository.Scheme.Usuarios.Acesso
{
    public interface IAcessRepository
    {
        List<Sys.Model.Database.Usuarios.Acesso> List();
        List<Sys.Model.Database.Usuarios.Acesso> ListByUser(Sys.Model.Database.Usuarios.Acesso acesso);
        Sys.Model.Database.Usuarios.Acesso Insert(Sys.Model.Database.Usuarios.Acesso acesso);
    }
}
