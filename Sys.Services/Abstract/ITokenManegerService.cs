using Microsoft.AspNetCore.Http;
using Sys.Model.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface ITokenManegerService
    {
        Task<Token> CreateToken(RequestToken requestToken);
        Task<RequestToken> ValidateToken(ValidateToken validateToken);
    }
}