using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Usuarios
{
    public class User
    {
        public decimal Id { get; set; }
        public string UniqueKey { get; set; } 
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Gen { get; set; }
        public DateTime DataBirth { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
