using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Aplicativos
{
    public class Client
    {
        public int Id { get; set; }
        public string UniqueKey { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public bool Active { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateExclusion { get; set; }
    }
}



