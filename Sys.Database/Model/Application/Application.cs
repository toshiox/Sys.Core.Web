using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Model.Application
{
    public class Application
    {
        public string UniqueKey { get; set; }
        public Database.Model.DataBase.Client Client { get; set; }
        public Database.Model.DataBase.Secret Secret { get; set; }
        public List<Database.Model.DataBase.ClitScopes> ListScope { get; set; }
        public Database.Model.DataBase.ClitGrantType ListGrantType { get; set; }
        public Database.Model.DataBase.GrantType GrantType { get; set; }
        public List<Database.Model.DataBase.Scope> Scope { get; set; }
        public Result Result { get; set; }
    }
}
