using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Authentication
{
    public class Token : Sys.Model.Common.Result
    {
        public string TokenAccess { get; set; }
        public DateTime? DateValidade { get; set; }
    }
}
