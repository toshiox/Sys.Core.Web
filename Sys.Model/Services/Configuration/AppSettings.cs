using System;
using System.Collections.Generic;

namespace Sys.Model.Services.Configuration
{
    public partial class AppSettings
    {
        public List<Client> Clients { get; set; }
    }

    public partial class Client
    {
        public string Name { get; set; }

        public Guid ClientId { get; set; }
    }
}
