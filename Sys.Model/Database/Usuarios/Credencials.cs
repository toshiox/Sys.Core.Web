using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Usuarios
{
    public class Credencials
    {
        public decimal Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
