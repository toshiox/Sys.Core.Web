using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Negocios
{
    public class AssDig
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public string DigitalAssignature { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
