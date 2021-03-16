using Microsoft.Extensions.Configuration;
using Sys.Model.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sys.Services.Configuration
{
    public class ApplicationConfiguration
    {
        private readonly Model.Services.Configuration.AppSettings _configuration;

        public ApplicationConfiguration()
        {
            _configuration = JsonSerializer.Deserialize<Model.Services.Configuration.AppSettings>(System.IO.File.ReadAllText(Model.Services.Struct.Configuration.JsonConfiguration.Path));
        }

        public bool GetClientID(Guid Id)
        {
            if (_configuration.Clients.Exists(cl => cl.ClientId == Id))
                return true;
            else
                return false;
        }

    }
}
