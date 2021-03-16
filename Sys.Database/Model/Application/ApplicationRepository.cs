using System.Collections.Generic;
using Sys.Model.Database.Aplicativos;

namespace Sys.Database.Model.Application
{
    public class ApplicationRepository : Sys.Model.Services.Common.Result
    {
        public string UniqueKey { get; set; }
        public Client Client { get; set; }
        public Secret Secret { get; set; }
        public List<ClitScopes> ListScope { get; set; }
        public ClitGrantType ListGrantType { get; set; }
        public GrantType GrantType { get; set; }
        public List<Scope> Scope { get; set; }
    }
}
