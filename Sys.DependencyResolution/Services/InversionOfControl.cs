using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.DependencyResolution.Services
{
    public class InversionOfControl : Dependency.IDependencyRegister
    {
        public void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Sys.Services.Abstract.IGenerateToken, Sys.Services.Authentication.GenerateToken>();
        }
    }
}
