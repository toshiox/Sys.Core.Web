using Sys.Services.Model.Authentication;

namespace Sys.Services.Abstract
{
    public interface IGenerateToken
    {
        Token CreateToken(RequestToken requestToken);
    }
}