using Sys.Model.Services.Business;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface IBusinessService
    {
        Task<Model.Services.Business.Flow> RegisterFlow(FlowRequest model);
    }
}