using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.DependencyResolution.Database
{
    public class InversionOfControl : Dependency.IDependencyRegister
    {
        public void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Sys.Database.Repository.Application.IApplicationRepository, Sys.Database.Repository.Application.ApplicationRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.JsonRepository.IJsonRepository, Sys.Database.Repository.JsonRepository.JsonRepository>();

            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.IConfiguration, Sys.Database.Repository.DataBase.Configuration>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.Client.IClientRepository, Sys.Database.Repository.DataBase.Client.ClientRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.Secret.ISecretRepository, Sys.Database.Repository.DataBase.Secret.SecretRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.Scope.IScopeRepository, Sys.Database.Repository.DataBase.Scope.ScopeRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.GrantType.IGrantTypeRepository, Sys.Database.Repository.DataBase.GrantType.GrantTypeRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.ClitScopes.IClitScopesRepository, Sys.Database.Repository.DataBase.ClitScopes.ClitScopesRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.ClitGranType.IClitGranTypeRepository, Sys.Database.Repository.DataBase.ClitGranType.ClitGranTypeRepository>();
            
            serviceCollection.AddScoped<Sys.Database.Repository.DataBase.Negocios.Empr.IEmprRepository, Sys.Database.Repository.DataBase.Negocios.Empr.EmprRepository>();
        }
    }
}
