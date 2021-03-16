using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.Authentication
{
    public class ValidateToken : Model.Services.Common.Result
    {
        public Guid ClientId { get; set; }
        public string Secret { get; set; }
        public List<string> ClientScope { get; set; }
        public string ClientGrantType { get; set; }
    }
}
