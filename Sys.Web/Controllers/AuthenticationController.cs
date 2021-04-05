using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Sys.Model.Services.User;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Authenticate")]
    public class AuthenticationController : Services.Common.BaseController<Model.Services.Authentication.Token>
    {
        public AuthenticationController(
                Sys.Services.Abstract.ITokenManegerService tokenManegerService,
                ILogger<Model.Services.Authentication.Token> logger
            ) : base(logger, tokenManegerService)
        {
        }

        [HttpGet]
        [Route("ServiceToken")]
        [SwaggerOperation("Gerar Token", "Cria token de segurança para autenticar nas demais aplicações", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> GenerateToken([FromBody] Model.Services.Authentication.RequestToken requestToken)
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _tokenManegerService.CreateServiceToken(requestToken);
                result.Success = true;
                result.ResultMessage = "Token gerado com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage= $"Ocorreu um erro durante a operação: Descrição {ex.Message}"
                };
            }
        }

        [HttpGet]
        [Route("ValidateToken")]
        [Authorize]
        [SwaggerOperation("Validar Token", "Valida se o Token é válido", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.RequestToken))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.RequestToken))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> ValidateToken()
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _tokenManegerService.ValidateServiceToken(HttpContext);

                result.Success = true;
                result.ResultMessage = "Token validado com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Authentication.ValidateToken()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro durante a operação: Descrição {ex.Message}"
                };
            }
            
        }

        [HttpGet]
        [Route("UserToken")]
        [SwaggerOperation("Gerar Token", "Cria token de segurança para segregação de acesso dos usuarios", Tags = new string[1] { "Authentication" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> GenerateUserToken(UserRequest userRequest)
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _tokenManegerService.CreateUserToken(userRequest);

                result.Success = true;
                result.ResultMessage = "Token gerado com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro durante a operação: Descrição {ex.Message}"
                };
            }
        }
    }
}
