using System.Collections.Generic;

namespace Sys.Model.Application
{
    public class Application
    {
        public string UniqueKey { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string SecretValue { get; set; }
        public List<Scopes> Scopes { get; set; }
        public string GrantType { get; set; }
    }
}
