using Sys.Services.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Authentication
{
    public class RequestToken
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public List<string> ClientScope { get; set; }
        public string ClientGrantType { get; set; }
        public Result Result { get; set; }
    }
}
