using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.PermissionControl
{
    public class MenuResponse
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Model.Database.Front.Menu> menus { get; set; }
    }
}
