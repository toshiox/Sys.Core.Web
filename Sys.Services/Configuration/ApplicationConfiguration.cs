using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sys.Services.Configuration
{
    public class ApplicationConfiguration
    {
        private readonly Sys.Model.Configuration.AppSettings _configuration;

        public ApplicationConfiguration()
        {
            _configuration = JsonSerializer.Deserialize<Sys.Model.Configuration.AppSettings>(System.IO.File.ReadAllText(Sys.Model.Struct.Configuration.JsonConfiguration.Path));
        }

        public string GetClientID()
        {
            
            return _configuration.Clients. Find(cl => cl.Name == "Application").ClientId.ToString();
        }
    }
}
