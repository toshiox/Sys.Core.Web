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
                //FlowType = model.FlowType,
                Value = model.Value
            };

            //Model.Database.Negocios.Empresa empresa = _businessRepository.GetEmpresa(
            //    new Model.Database.Negocios.Empresa()
            //    {
            //        CNPJ = model.CNPJ
            //    });

            //Model.Database.Negocios.TypFlx typFlx = _businessRepository.GetFlowType(
            //    new Model.Database.Negocios.TypFlx()
            //    {
            //        TypeFlow = model.FlowType
            //    });

            //Model.Database.Negocios.Finac finac = _businessRepository.RegisterFlow(
            //    new Model.Database.Negocios.Finac()
            //    {
            //        MonthReference = model.MonthReference,
            //        IdCompany = empresa.id,
            //        IdFlowType = typFlx.Id,
            //        Description = model.Description,
            //        Value = model.Value,
            //        DataRegister = System.DateTime.Now
            //    });

            //flow.IdFlow = finac.Id;

            return Task.FromResult(flow);
        }


    }
}
