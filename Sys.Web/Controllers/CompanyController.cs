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
            ) :base(logger, tokenManegerService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("Register")]
        [SwaggerOperation("Cadastrar Empresa", "Insere informações da empresa no banco de dados", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<CompanyRequest> RegisterCompany([FromBody] Empresa empresa)
        {
            var Validate = _tokenManegerService.ValidateToken(HttpContext).Result;

            if (Validate.Success)
            {
                return await _companyService.RegisterCompany(empresa);
            }
            else
            {
                return new CompanyRequest()
                {
                    Result = new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Erro Durante a operação. Erro: {Validate.ResultMessage}"
                    }
                };
            }
        }

        [HttpPost]
        [Route("Update")]
        [SwaggerOperation("Atualiza Informações Empresa", "Atualiza informações cadastadas da empresa", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<CompanyRequest> UpdateCompany([FromBody] Empresa empresa)
        {
            var Validate = _tokenManegerService.ValidateToken(HttpContext).Result;

            if (Validate.Success)
            {
                return await _companyService.UpdateCompany(empresa);
            }
            else
            {
                return new CompanyRequest()
                {
                    Result = new Model.Services.Common.Result()
                    {
                        Success = false,
                        ResultMessage = $"Erro Durante a operação. Erro: {Validate.ResultMessage}"
                    }
                };
            }
        }

        [HttpGet]
        [Route("List")]
        [SwaggerOperation("Lista Todas Empresa", "Lista todas as empresas cadastradas no banco de dados", Tags = new string[1] { "Company" })]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status200OK, "Processado com sucesso", typeof(CompanyRequest))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status401Unauthorized, "Não Autorizado", typeof(Model.Services.Authentication.Token))]
        [SwaggerResponse(Model.Services.Struct.WebStatus.WebStatusCode.Status500InternalServerError, "Ocorreu um erro não tratado no processamento da requisição", typeof(Model.Services.Authentication.Token))]
        public async Task<List<CompanyRequest>> ListCompany()
        {
            var Validate = _tokenManegerService.ValidateToken(HttpContext).Result;
            List<CompanyRequest> companyRequest = new List<CompanyRequest>();

            if (Validate.Success)
            {
                return await _companyService.ListCompany();
            }
            else
            {
                companyRequest.Add(new CompanyRequest()
                {
                    Result = new Model.Services.Common.Result()
                    {
                        Success = true,
                        ResultMessage = $"Erro Durante a operação. Erro: {Validate.ResultMessage}"
                    }
                });

                return companyRequest;
            }
        }
    }
}
