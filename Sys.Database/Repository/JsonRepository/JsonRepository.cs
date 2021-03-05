using Sys.Database.Model.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sys.Database.Repository.JsonRepository
{
    public class JsonRepository : IJsonRepository
    {
        public JsonRepository()
        {

        }

        public AppSettings ConfigFileToModel()
        {
            return JsonSerializer.Deserialize<AppSettings>(System.IO.File.ReadAllText($"{Common.ConfigureConstants.Path}{Common.ConfigureConstants.FileName}"));
        }

        public string ReadConfigFile()
        {
            return System.IO.File.ReadAllText($"{Common.ConfigureConstants.Path}{Common.ConfigureConstants.FileName}");
        }
    }
}
