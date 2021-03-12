using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Authenticate")]
    public class AuthenticationController : ControllerBase
    {
        private readonly Services.Abstract.ITokenManegerService _tokenManegerService;

        public AuthenticationController(
                Sys.Services.Abstract.ITokenManegerService tokenManegerService
            )
        {
            _tokenManegerService = tokenManegerService;
        }

        [HttpPost]
        [Route("GenerateToken")]
        [SwaggerOperation("Gerar Token", "Consulta lista valores do onboarding", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Authentication.Token))]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Authentication.Token))]
        public async Task<ActionResult<Model.Authentication.Token>> GenerateToken([FromBody]Model.Authentication.RequestToken requestToken)
        {
            return await _tokenManegerService.CreateToken(requestToken);
        }

        [HttpGet]
        [Route("ValidateToken")]
        [SwaggerOperation("Validar Token", "Valida se o Token é válido", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Authentication.RequestToken))]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Authentication.RequestToken))]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Authentication.Token))]
        public async Task<ActionResult<Model.Authentication.RequestToken>> ValidateToken()
        {
            return await  _tokenManegerService.ValidateToken(
                    new Model.Authentication.ValidateToken()
                        {   
                            httpContext = HttpContext,
                            ClientId = ""
                        });
        }
    }
}
