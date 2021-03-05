using Sys.Database.Model.DataBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.ClitGranType
{
    public interface IClitGranTypeRepository
    {
        ClitGrantType Insert(ClitGrantType model);
        Task<ClitGrantType> InsertAsync(ClitGrantType model);
        List<ClitGrantType> List();
        ClitGrantType ListById(ClitGrantType model);
    }
}