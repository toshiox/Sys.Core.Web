using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.Company
{
    public class CompanyRequest : Common.Result
    {
        public Model.Database.Negocios.Empresa Empresa { get; set; }

        public Model.Database.Negocios.Tax Taxas { get; set; }
    }
}
