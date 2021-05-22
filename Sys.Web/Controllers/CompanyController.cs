using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Sys.Model.Database.Negocios;
using Sys.Model.Services.Company;

namespace Sys.Web.Controllers
{
    [ApiController]
    [Route("Company")]
    public class CompanyController : Services.Common.BaseController<Empresa>
    {
        private readonly Services.Abstract.ICompanyService _companyService;

        public CompanyController(
            Services.Abstract.ICompanyService companyService,
            Services.Abstract.ITokenManegerService tokenManegerService,
            ILogger<Empresa> logger
            ) : base(logger, tokenManegerService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("Register")]
        [SwaggerOperation("Cadastrar Empresa", "Insere informações da empresa no banco de dados", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> RegisterCompany([FromBody] Empresa empresa)
        {
            var Validate = _tokenManegerService.ValidateServiceToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _companyService.RegisterCompany(empresa);
                    result.Success = true;
                    result.ResultMessage = "Empresa cadastrada com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {

                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token Inválido, Descrica: {Validate.ResultMessage}"
                };
            }
        }

        [HttpPut]
        [Route("Update")]
        [SwaggerOperation("Atualiza Informações Empresa", "Atualiza informações cadastadas da empresa", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> UpdateCompany([FromBody] Empresa empresa)
        {
            var Validate = _tokenManegerService.ValidateServiceToken(HttpContext).Result;

            if (Validate.Success)
            {
                try
                {
                    Model.Services.Common.Result result = new Model.Services.Common.Result();

                    result.Data = await _companyService.UpdateCompany(empresa);

                    result.Success = true;
                    result.ResultMessage = "Empresa Atualizada com sucesso";

                    return result;
                }
                catch (Exception ex)
                {
                    return new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                    };
                }
            }
            else
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Token Inválido, Descrica: {Validate.ResultMessage}"
                };
            }
        }

        [HttpGet]
        [Route("List")]
        [SwaggerOperation("Lista Todas Empresa", "Lista todas as empresas cadastradas no banco de dados", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> ListCompany()
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _companyService.ListCompany();

                result.Success = true;
                result.ResultMessage = "Empresas listadas com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                };
            }
        }

        [HttpPost]
        [Route("ListByName")]
        [SwaggerOperation("Lista por nome fantasia", "Lista empresa por nome fantasia", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<Model.Services.Common.Result> ListByName(FantasyName fantasyName)
        {
            try
            {
                Model.Services.Common.Result result = new Model.Services.Common.Result();

                result.Data = await _companyService.ListByName(fantasyName);

                result.Success = true;
                result.ResultMessage = "Empresas listadas com sucesso";

                return result;
            }
            catch (Exception ex)
            {
                return new Model.Services.Common.Result()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro durante a operação, Descricao: {ex.Message}"
                };
            }
        }
    }
}
