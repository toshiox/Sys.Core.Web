using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.Business
{
    public class Flow 
    {
        public decimal IdFlow{get;set;}
        public string CNPJ { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public string FlowType { get; set; }
    }
}
