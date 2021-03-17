using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Authenticate")]
    public class AuthenticationController : Services.Common.BaseController<Model.Services.Authentication.Token>
    {

        public AuthenticationController(
                Sys.Services.Abstract.ITokenManegerService tokenManegerService,
                ILogger<Model.Services.Authentication.Token> logger
            ) :base(logger, tokenManegerService)
        {
        }

        [HttpGet]
        [Route("GenerateToken")]
        [SwaggerOperation("Gerar Token", "Cria token de segurança para autenticar nas demais aplicações", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<ActionResult<Model.Services.Authentication.Token>> GenerateToken([FromBody]Model.Services.Authentication.RequestToken requestToken)
        {
            return await _tokenManegerService.CreateToken(requestToken);
        }

        [HttpGet]
        [Route("ValidateToken")]
        [Authorize]
        [SwaggerOperation("Validar Token", "Valida se o Token é válido", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.RequestToken))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.RequestToken))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<ActionResult<Model.Services.Authentication.ValidateToken>> ValidateToken()
        {
            return await  _tokenManegerService.ValidateToken(HttpContext);
        }
    }
}
