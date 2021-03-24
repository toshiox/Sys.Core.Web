using System;

namespace Sys.Model.Database.Negocios
{
    public class Tax
    {
        public decimal Id { get; set; }
        public int IdCompany { get; set; }
        public double ISS { get; set; }
        public double IRRF { get; set; }
        public double PIS { get; set; }
        public double COFINS { get; set; }
        public double CSLL { get; set; }
        public double INSS { get; set; }
        public double SimpleRate { get; set; }
        public DateTime DataRegister { get; set; }
    }
}