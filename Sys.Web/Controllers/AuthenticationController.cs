using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly Sys.Services.Abstract.IGenerateToken _generateToken;
        public AuthenticationController(
                Sys.Services.Abstract.IGenerateToken generateToken
            )
        {
            _generateToken = generateToken;
        }

        [HttpPost]
        [Route("GenerateToken")]
        public Sys.Services.Model.Authentication.Token GenerateToken(Sys.Services.Model.Authentication.RequestToken requestToken)
        {
            return _generateToken.CreateToken(requestToken);
        }
    }
}
