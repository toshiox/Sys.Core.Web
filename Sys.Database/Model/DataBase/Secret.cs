using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Model.DataBase
{
    public class Secret
    {
        public decimal id { get; set; }
        public string FK_UniqueKeyApp { get; set; }
        public string SecretValue { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
