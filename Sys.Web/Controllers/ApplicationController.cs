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
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Database.Model.Application.ApplicationRepository))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Database.Model.Application.ApplicationRepository))]
        public async Task<ActionResult<Database.Model.Application.ApplicationRepository>> GenerateToken([FromBody] Model.Services.Application.Application modelApplication)
        {
            var Validate = _tokenManegerService.ValidateToken(HttpContext).Result;

            if (Validate.Success)
            {
                return await _applicationServices.CreateApplication(modelApplication);
            }
            else
            {
                return new Database.Model.Application.ApplicationRepository()
                {
                    Success = false,
                    ResultMessage = $"Token invalido. Erro: {Validate.ResultMessage}"
                };
            }
        }
    }
}
