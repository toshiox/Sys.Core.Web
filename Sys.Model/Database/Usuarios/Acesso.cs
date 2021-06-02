using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Usuarios
{
    public class Acesso
    {
        public decimal Id { get; set; }
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
