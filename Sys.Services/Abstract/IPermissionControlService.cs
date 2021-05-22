using Microsoft.AspNetCore.Http;
using Sys.Model.Database.Front;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface IPermissionControlService
    {
        Task<List<Sys.Model.Services.PermissionControl.MenuResponse>> GetMenu(HttpContext httpContext);
    }
}