using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Repository.JsonRepository
{
    public interface IJsonRepository
    {
        string ReadConfigFile();

        Model.Json.AppSettings ConfigFileToModel();
    }
}
