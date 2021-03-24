using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model.Services.Business
{
    public class FlowRequest
    {
        public string CNPJ { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public string FlowType { get; set; }
    }
}
