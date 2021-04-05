using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Gen { get; set; }
        public DateTime DataBirth { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
    }
}
