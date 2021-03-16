using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Services.Abstract
{
    public interface ICompanyService
    {
        Task<Model.Services.Company.CompanyRequest> RegisterCompany(Model.Database.Negocios.Empresa empresa);

        Task<Model.Services.Company.CompanyRequest> UpdateCompany(Model.Database.Negocios.Empresa empresa);
    }
}
