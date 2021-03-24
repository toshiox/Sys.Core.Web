using Sys.Model.Database.Negocios;
using Sys.Model.Services.Common;
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
        private readonly Database.Repository.Scheme.Negocios.Tax.ITaxRepository _taxRepository;
        public CompanyService(
            Database.Repository.Scheme.Negocios.Empr.IEmprRepository emprRepository,
            Database.Repository.Scheme.Negocios.Tax.ITaxRepository taxRepository
            )
        {
            _taxRepository = taxRepository;
            _emprRepository = emprRepository;
        }

        public Task<Model.Services.Company.CompanyRequest> RegisterCompany(Empresa empresa)
        {
            CompanyRequest companyRequest = new CompanyRequest();

            try
            {
                var model = _emprRepository.Insert(empresa);

                companyRequest.Success = true;
                companyRequest.ResultMessage = "Empresa cadastrada com sucesso.";
            }
            catch (Exception ex)
            {
                companyRequest.Success = false;
                companyRequest.ResultMessage = $"Ocorreu um erro ao cadastrar empresa. Descrição: {ex.Message}";
            }
            return Task.FromResult(companyRequest);
        }

        public Task<CompanyRequest> UpdateCompany(Empresa empresa)
        {
            CompanyRequest companyRequest = new CompanyRequest();

            try
            {
                _emprRepository.Update(empresa);

                companyRequest.Success = true;
                companyRequest.ResultMessage = "Dados da empresa atualizados com sucesso";
            }
            catch (Exception ex)
            {
                companyRequest.Success = false;
                companyRequest.ResultMessage = $"Ocorreu um erro ao atualizar as informações da empresa. Descrição: {ex.Message}";
            }
            return Task.FromResult(companyRequest);
        }

        public Task<List<CompanyRequest>> ListCompany()
        {
            List<CompanyRequest> companyRequest = new List<CompanyRequest>();
            var model = new CompanyRequest();
            try
            {
                var listCompany = _emprRepository.List();

                foreach (var item in listCompany)
                {
                    companyRequest.Add(new CompanyRequest() { 
                        Empresa = new Empresa()
                        {
                            CCM = item.CCM,
                            CEP = item.CEP,
                            CNPJ = item.CNPJ,
                            CompanyName = item.CompanyName,
                            County = item.County,
                            DataRegister = item.DataRegister,
                            District = item.District,
                            FantasyName = item.FantasyName,
                            HouseNumber = item.HouseNumber,
                            id = item.id,
                            MainActivity = item.MainActivity,
                            MainOccupation = item.MainOccupation,
                            PublicPlace = item.PublicPlace,
                            State = item.State,
                        }
                    });
                }

                for(int i = 0; i < companyRequest.Count; i++)
                {
                    var taxes = _taxRepository.ListByCompany(new Tax() { IdCompany = Convert.ToInt32(companyRequest[i].Empresa.id) });

                    if (taxes != null)
                    {
                        companyRequest[i].Taxas = new Tax()
                        {
                            COFINS = taxes.COFINS,
                            CSLL = taxes.CSLL,
                            DataRegister = taxes.DataRegister,
                            Id = taxes.Id,
                            IdCompany = taxes.IdCompany,
                            INSS = taxes.INSS,
                            IRRF = taxes.IRRF,
                            ISS = taxes.ISS,
                            PIS = taxes.PIS,
                            SimpleRate = taxes.SimpleRate
                        };
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Task.FromResult(companyRequest);
        }
    }
}
