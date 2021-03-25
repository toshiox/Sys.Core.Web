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
            serviceCollection.AddScoped<Sys.Services.Abstract.ITokenManegerService, Sys.Services.Action.TokenManegerService>();
            serviceCollection.AddScoped<Sys.Services.Abstract.IApplicationService, Sys.Services.Action.ApplicationService>();
            serviceCollection.AddScoped<Sys.Services.Abstract.ICompanyService, Sys.Services.Action.CompanyService>();
            serviceCollection.AddScoped<Sys.Services.Abstract.IBusinessService, Sys.Services.Action.BusinessService>();
            serviceCollection.AddScoped<Sys.Services.Abstract.ICryptographyService, Sys.Services.Action.CryptographyService>();
        }
    }
}
