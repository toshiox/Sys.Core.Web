using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Negocios
{
    public class Finac
    {
        public decimal Id { get; set; }
        public decimal IdCompany { get; set; }
        public decimal IdFlowType { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string MonthReference { get; set; }
        public DateTime DataRegister { get; set; }
        public int ParcelAmount { get; set; }

    }
}
