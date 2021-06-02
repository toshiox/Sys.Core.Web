using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.Authentication
{
    public class Token 
    {
        public string TokenAccess { get; set; }
        public DateTime? DateValidade { get; set; }
    }
}
