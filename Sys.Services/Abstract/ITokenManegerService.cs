using Microsoft.AspNetCore.Http;
using Sys.Model.Services.Authentication;
using Sys.Model.Services.User;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface ITokenManegerService
    {
        Task<Token> CreateServiceToken(RequestToken requestToken);
        Task<Token> CreateUserToken(UserRequest userRequest);
        Task<ValidateToken> ValidateServiceToken(HttpContext httpContext);
    }
}