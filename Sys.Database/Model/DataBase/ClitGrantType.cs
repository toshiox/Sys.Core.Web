﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Database.Model.DataBase
{
    public class ClitGrantType
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int GrantTypeId { get; set; }
        public DateTime DataRegister { get; set; }
    }
}
