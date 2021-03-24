using Sys.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Services.Action
{
    public class BusinessService : IBusinessService
    {
        private readonly Database.Repository.Business.IBusinessRepository _businessRepository;

        public BusinessService(
                Database.Repository.Business.IBusinessRepository businessRepository
            )
        {
            _businessRepository = businessRepository;
        }

        public Task<Model.Services.Business.Flow> RegisterFlow(Model.Services.Business.FlowRequest model)
        {
            Model.Services.Business.Flow flow = new Model.Services.Business.Flow()
            {
                CNPJ = model.CNPJ,
                Description = model.Description,
                FlowType = model.FlowType,
                Value = model.Value
            };

            try
            {
                Model.Database.Negocios.Empresa empresa = _businessRepository.GetEmpresa(
                    new Model.Database.Negocios.Empresa()
                    {
                        CNPJ = model.CNPJ
                    });

                Model.Database.Negocios.TypFlx typFlx = _businessRepository.GetFlowType(
                    new Model.Database.Negocios.TypFlx()
                    {
                        TypeFlow = model.FlowType
                    });

                Model.Database.Negocios.Finac finac = _businessRepository.RegisterFlow(
                    new Model.Database.Negocios.Finac()
                    {
                        IdCompany = empresa.id,
                        IdFlowType = typFlx.Id,
                        Description = model.Description,
                        Value = model.Value,
                        DataRegister = System.DateTime.Now
                    });

                flow.IdFlow = finac.Id;
                flow.Success = true;
                flow.ResultMessage = "Fluxo cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Model.Services.Business.Flow()
                {
                    Success = false,
                    ResultMessage = $"Ocorreu um erro ao cadastrar o fluxo, descrição: {ex.Message}"
                });
            }

            return Task.FromResult(flow);
        }


    }
}
