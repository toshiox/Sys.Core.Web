using Microsoft.AspNetCore.Http;
using Sys.Model.Services.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface ITokenManegerService
    {
        Task<Token> CreateServiceToken(RequestToken requestToken);
        Task<ValidateToken> ValidateToken(HttpContext httpContext);
    }
}