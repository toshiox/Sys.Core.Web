using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Authentication
{
    public class ValidateToken
    {
        public HttpContext httpContext { get; set; }
        public string ClientId { get; set; }
    }
}
