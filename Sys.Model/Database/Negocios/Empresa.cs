using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Negocios
{
    public class Empresa
    {
        public decimal id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }
        public string CCM { get; set; }
        public string MainOccupation { get; set; }
        public string MainActivity { get; set; }
        public string PublicPlace { get; set; }
        public string HouseNumber { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public DateTime? DataRegister { get; set; }
    }
}
