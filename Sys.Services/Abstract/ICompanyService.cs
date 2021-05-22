using Sys.Model.Database.Negocios;
using Sys.Model.Services.Company;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface ICompanyService
    {
        Task<Empresa> RegisterCompany(Model.Database.Negocios.Empresa empresa);
        Task<Empresa> UpdateCompany(Model.Database.Negocios.Empresa empresa);
        Task<List<CompanyRequest>> ListCompany();
        Task<CompanyRequest> ListByName(FantasyName FantasyName);
    }
}
