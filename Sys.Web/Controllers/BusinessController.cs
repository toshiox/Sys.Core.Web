using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Business")]
    public class BusinessController : Services.Common.BaseController<Model.Services.Business.Flow>
    {
        private readonly Services.Abstract.IBusinessService _businessService;
        public BusinessController(
                Services.Abstract.IBusinessService businessService,
                Sys.Services.Abstract.ITokenManegerService tokenManegerService,
                ILogger<Model.Services.Business.Flow> logger
            ) : base(logger, tokenManegerService)
        {
            _businessService = businessService;
        }

        [HttpPost]
        [Route("FlowRegister")]
        [SwaggerOperation("Cadastrar Fluxo de Caixa", "Cadastro fluxo de caixa de empresa", Tags = new string[1] { "Business" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> FlowRegister([FromBody] Model.Services.Business.FlowRequest model)
        {
            var Validate = _tokenManegerService.ValidateToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _businessService.RegisterFlow(model);

                    result.Success = true;
                    result.ResultMessage = "Fluxo cadastrado com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação. Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token invalido. Erro: {Validate.ResultMessage}"
                };
            }
        }

    }
}
