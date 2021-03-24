using Sys.Model.Database.Negocios;

namespace Sys.Database.Repository.Business
{
    public interface IBusinessRepository
    {
        AssDig RegisterDigitalAssignature(AssDig model);
        Finac RegisterFlow(Finac model);
        TypFlx RegisterFlowType(TypFlx model);
        Sys.Model.Database.Negocios.Empresa GetEmpresa(Sys.Model.Database.Negocios.Empresa model);
        Sys.Model.Database.Negocios.TypFlx GetFlowType(Sys.Model.Database.Negocios.TypFlx model);
    }
}