using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Negocios
{
    public class Finac
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdFlowType { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
