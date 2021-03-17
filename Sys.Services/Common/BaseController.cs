using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Services.Common
{
    public class BaseController<TController> : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected readonly Abstract.ITokenManegerService _tokenManegerService;
        protected readonly ILogger<TController> _logger;
        protected BaseController(
            ILogger<TController> logger,
            Abstract.ITokenManegerService tokenManegerService
            )
        {
            this._logger = logger;
            this._tokenManegerService = tokenManegerService;
        }
    }
}
