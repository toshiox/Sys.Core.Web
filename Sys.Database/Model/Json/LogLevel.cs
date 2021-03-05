using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Model.Json
{
    public class LogLevel
    {
        //[JsonProperty("Default")]
        public string Default { get; set; }

        //[JsonProperty("Microsoft")]
        public string Microsoft { get; set; }

        //[JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }
}
