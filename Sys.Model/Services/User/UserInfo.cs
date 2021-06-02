using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.User
{
    public class UserInfo
    {
        public decimal Id { get; set; }
        public string UniqueKey { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Gen { get; set; }
        public DateTime DataBirth { get; set; }
        public DateTime DataRegister { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
    }
}
