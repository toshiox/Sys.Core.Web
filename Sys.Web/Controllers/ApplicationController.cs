using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Application")]
    public class ApplicationController : Controller
    {
        private readonly Services.Abstract.IApplicationService _applicationServices;
        private readonly Services.Abstract.ITokenManegerService _tokenManegerService;

        public ApplicationController(
                Services.Abstract.IApplicationService applicationServices,
                Services.Abstract.ITokenManegerService tokenManegerService
            )
        {
            _applicationServices = applicationServices;
            _tokenManegerService = tokenManegerService;
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        [SwaggerOperation("Criar Aplicação", "API responsável por criar novas aplicações", Tags = new string[1] { "Application" })]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Database.Model.Application.Application))]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Authentication.Token))]
        [SwaggerResponse(Model.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Database.Model.Application.Application))]
        public async Task<ActionResult<Database.Model.Application.Application>> GenerateToken([FromBody] Model.Application.Application modelApplication)
        {
            var Validate = _tokenManegerService.ValidateToken(
                    new Model.Authentication.ValidateToken() 
                    { 
                        httpContext= HttpContext, 
                        ClientId = "6f632e95-c0fd-4073-8add-cb622010d053"
                    }).Result;

            if (Validate.Result.Success)
            {
                return await _applicationServices.CreateApplication(modelApplication);
            }
            else
            {
                return new Database.Model.Application.Application()
                {
                    Result = new Database.Model.Application.Result()
                    {
                        Success = false,
                        ResultMessage = $"Token invalido. Erro: {Validate.Result.ResultMessage}"
                    }
                };
            }
        }
    }
}
