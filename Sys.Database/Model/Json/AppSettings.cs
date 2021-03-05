using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sys.Database.Model.Json
{
    public class AppSettings
    {
        public Logging Logging { get; set; }

        public ConnectionStrings ConnectionString { get; set; }

        public string AllowedHosts { get; set; }
    }
}
