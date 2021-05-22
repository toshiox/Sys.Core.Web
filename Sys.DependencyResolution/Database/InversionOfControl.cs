using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Sys.Database.Repository.Scheme.Aplicativos;

namespace Sys.DependencyResolution.Database
{
    public class InversionOfControl : Dependency.IDependencyRegister
    {
        public void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Sys.Database.Repository.Application.IApplicationRepository, Sys.Database.Repository.Application.ApplicationRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Business.IBusinessRepository, Sys.Database.Repository.Business.BusinessRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.JsonRepository.IJsonRepository, Sys.Database.Repository.JsonRepository.JsonRepository>();

            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.IConfiguration, Sys.Database.Repository.Scheme.Configuration>();

            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.Client.IClientRepository, Sys.Database.Repository.Scheme.Aplicativos.Client.ClientRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.Secret.ISecretRepository, Sys.Database.Repository.Scheme.Aplicativos.Secret.SecretRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.Scope.IScopeRepository, Sys.Database.Repository.Scheme.Aplicativos.Scope.ScopeRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.GrantType.IGrantTypeRepository, Sys.Database.Repository.Scheme.Aplicativos.GrantType.GrantTypeRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.ClitScopes.IClitScopesRepository, Sys.Database.Repository.Scheme.Aplicativos.ClitScopes.ClitScopesRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Aplicativos.ClitGranType.IClitGranTypeRepository, Sys.Database.Repository.Scheme.Aplicativos.ClitGranType.ClitGranTypeRepository>();
                                                                
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Negocios.Empr.IEmprRepository, Sys.Database.Repository.Scheme.Negocios.Empr.EmprRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Negocios.Finac.IFinacRepository, Sys.Database.Repository.Scheme.Negocios.Finac.FinacRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Negocios.Tax.ITaxRepository, Sys.Database.Repository.Scheme.Negocios.Tax.TaxRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Negocios.AssDig.IAssDigRepository, Sys.Database.Repository.Scheme.Negocios.AssDig.AssDigRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Negocios.TypFlx.ITypFlxRepository, Sys.Database.Repository.Scheme.Negocios.TypFlx.TypFlxRepository>();
         
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Usuarios.Users.IUsersRepository, Sys.Database.Repository.Scheme.Usuarios.Users.UsersRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Usuarios.Credencials.ICredencialsRepository, Sys.Database.Repository.Scheme.Usuarios.Credencials.CredencialsRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Usuarios.Acesso.IAcessRepository, Sys.Database.Repository.Scheme.Usuarios.Acesso.AcessRepository>();

            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Front.Menu.IMenuRepository, Sys.Database.Repository.Scheme.Front.Menu.MenuRepository>();
            serviceCollection.AddScoped<Sys.Database.Repository.Scheme.Front.Group.IGroupRepository, Sys.Database.Repository.Scheme.Front.Group.GroupRepository>();
        }
    }
}
