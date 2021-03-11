using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface IApplicationService
    {
        Task<Database.Model.Application.Application> CreateApplication(Sys.Model.Application.Application application);
    }
}
