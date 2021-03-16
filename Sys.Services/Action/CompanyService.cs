using Sys.Model.Database.Negocios;
using Sys.Model.Services.Company;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Services.Action
{
    public class CompanyService : Abstract.ICompanyService
    {
        private readonly Database.Repository.Scheme.Negocios.Empr.IEmprRepository _emprRepository;
        public CompanyService(
            Database.Repository.Scheme.Negocios.Empr.IEmprRepository emprRepository
            )
        {
            _emprRepository = emprRepository;
        }

        public Task<Model.Services.Company.CompanyRequest> RegisterCompany(Empresa empresa)
        {
            Model.Services.Company.CompanyRequest companyRequest = new Model.Services.Company.CompanyRequest();
            companyRequest.Result = new Model.Services.Common.Result();

            try
            {
                var model = _emprRepository.Insert(empresa);

                companyRequest.Result.Success = true;
                companyRequest.Result.ResultMessage = "Empresa cadastrada com sucesso.";
            }
            catch(Exception ex)
            {
                companyRequest.Result.Success = false;
                companyRequest.Result.ResultMessage = $"Ocorreu um erro ao cadastrar empresa. Descrição: {ex.Message}";
            }
            return Task.FromResult(companyRequest);
        }

        public Task<CompanyRequest> UpdateCompany(Empresa empresa)
        {
            CompanyRequest companyRequest = new CompanyRequest();
            companyRequest.Result = new Model.Services.Common.Result();

            try
            {
                _emprRepository.Update(empresa);

                companyRequest.Result.Success = true;
                companyRequest.Result.ResultMessage = "Dados da empresa atualizados com sucesso";
            }
            catch (Exception ex)
            {
                companyRequest.Result.Success = false;
                companyRequest.Result.ResultMessage = $"Ocorreu um erro ao atualizar as informações da empresa. Descrição: {ex.Message}";
            }
            return Task.FromResult(companyRequest);
        }
    }
}
