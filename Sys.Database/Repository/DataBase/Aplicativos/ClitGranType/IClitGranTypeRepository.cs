using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.ClitGranType
{
    public interface IClitGranTypeRepository
    {
        Sys.Model.Database.Aplicativos.ClitGrantType Insert(Sys.Model.Database.Aplicativos.ClitGrantType model);
        Task<Sys.Model.Database.Aplicativos.ClitGrantType> InsertAsync(Sys.Model.Database.Aplicativos.ClitGrantType model);
        List<Sys.Model.Database.Aplicativos.ClitGrantType> List();
        Sys.Model.Database.Aplicativos.ClitGrantType ListById(Sys.Model.Database.Aplicativos.ClitGrantType model);
    }
}