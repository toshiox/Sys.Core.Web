using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Database.Front
{
    public class Menu
    {
        public decimal Id { get; set; }
        public decimal GroupId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
