using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Services.Model.Authentication
{
    public class Token
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TokenAccess { get; set; }
        public DateTime? DateValidade { get; set; }
    }
}
