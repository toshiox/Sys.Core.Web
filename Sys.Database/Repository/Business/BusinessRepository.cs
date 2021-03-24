using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Repository.Business
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly Scheme.Negocios.Empr.IEmprRepository _emprRepository;
        private readonly Scheme.Negocios.Finac.IFinacRepository _finacRepository;
        private readonly Scheme.Negocios.Tax.ITaxRepository _taxRepository;
        private readonly Scheme.Negocios.AssDig.IAssDigRepository _assDigRepository;
        private readonly Scheme.Negocios.TypFlx.ITypFlxRepository _typFlxRepository;

        public BusinessRepository(
            Scheme.Negocios.Empr.IEmprRepository emprRepository,
            Scheme.Negocios.Finac.IFinacRepository finacRepository,
            Scheme.Negocios.Tax.ITaxRepository taxRepository,
            Scheme.Negocios.AssDig.IAssDigRepository assDigRepository,
            Scheme.Negocios.TypFlx.ITypFlxRepository typFlxRepository
            )
        {
            _emprRepository = emprRepository;
            _finacRepository = finacRepository;
            _taxRepository = taxRepository;
            _assDigRepository = assDigRepository;
            _typFlxRepository = typFlxRepository;
        }

        public Sys.Model.Database.Negocios.Finac RegisterFlow(Sys.Model.Database.Negocios.Finac model)
        {
            if (model.Value <= 0)
                throw new Exception("Valor não pode ser menor ou igual a zero");

            if (string.IsNullOrEmpty(model.Description))
                throw new Exception("A descrição não pode ser nula");

            if (model.IdFlowType == 0)
                throw new Exception("O tipo do fluxo de caixa não foi definido");

            return _finacRepository.Insert(model);
        }

        public Sys.Model.Database.Negocios.TypFlx RegisterFlowType(Sys.Model.Database.Negocios.TypFlx model)
        {
            var list = _typFlxRepository.List();

            if (!list.Exists(flow => flow.TypeFlow == model.TypeFlow))
                _typFlxRepository.Insert(model);

            return list.Find(flow => flow.TypeFlow == model.TypeFlow);
        }

        public Sys.Model.Database.Negocios.AssDig RegisterDigitalAssignature(Sys.Model.Database.Negocios.AssDig model)
        {
            if (string.IsNullOrEmpty(model.DigitalAssignature))
                throw new Exception("A Assinatura Digital não pode ser nula");

            return _assDigRepository.Insert(model);
        }

        public Sys.Model.Database.Negocios.Empresa GetEmpresa(Sys.Model.Database.Negocios.Empresa model)
        {
            return _emprRepository.ListByCnpj(model);
        }

        public Sys.Model.Database.Negocios.TypFlx GetFlowType(Sys.Model.Database.Negocios.TypFlx model)
        {
            var flw = _typFlxRepository.ListByName(model);
            
            if (flw == null)
                throw new Exception("Tipo de fluxo não encontrado."); 

            return flw;
        }
    }
}
