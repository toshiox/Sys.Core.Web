using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sys.Database
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region application
            services.AddTransient<Repository.Application.IApplicationRepository, Repository.Application.ApplicationRepository>();
            services.AddTransient<Repository.JsonRepository.IJsonRepository, Repository.JsonRepository.JsonRepository>();
            #endregion

            #region DataBase
            services.AddTransient<Repository.DataBase.IConfiguration, Repository.DataBase.Configuration>();
            services.AddTransient<Repository.DataBase.Client.IClientRepository, Repository.DataBase.Client.ClientRepository>();
            services.AddTransient<Repository.DataBase.Secret.ISecretRepository, Repository.DataBase.Secret.SecretRepository>();
            services.AddTransient<Repository.DataBase.Scope.IScopeRepository, Repository.DataBase.Scope.ScopeRepository>();
            services.AddTransient<Repository.DataBase.GrantType.IGrantTypeRepository, Repository.DataBase.GrantType.GrantTypeRepository>();
            services.AddTransient<Repository.DataBase.ClitScopes.IClitScopesRepository, Repository.DataBase.ClitScopes.ClitScopesRepository>();
            services.AddTransient<Repository.DataBase.ClitGranType.IClitGranTypeRepository, Repository.DataBase.ClitGranType.ClitGranTypeRepository>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //#region Criar Aplicacao
            //Model.DataBase.Client client = new Model.DataBase.Client()
            //{
            //    Active = true,
            //    DateRegister = DateTime.Now,
            //    Name = "Listar serviços cadastrados",
            //    Descrition = "Lista todos os serviços na base de dados",
            //    UniqueKey = Guid.NewGuid().ToString(),
            //};

            //client = serviceProvider.GetService<Repository.Application.IApplicationRepository>().CreateApplication(client);
            //#endregion

            //#region Criar Segredo da Aplicação
            //Model.DataBase.Secret secret = new Model.DataBase.Secret()
            //{
            //    DataRegister = DateTime.Now,
            //    SecretValue = "HGeAD5eMKeRfD39f3P7EFjean2ERupX8QsFfmTybztyHBH6ZQHTXVVAdcfrenK7H",
            //    FK_UniqueKeyApp = client.UniqueKey
            //};

            //secret = serviceProvider.GetService<Repository.Application.IApplicationRepository>().CreateSecret(secret);
            //#endregion

            //#region Criar Escopos
            //List<Model.DataBase.Scope> listScopesCreate = new List<Model.DataBase.Scope>();
            //List<Model.DataBase.Scope> listScopeResult = new List<Model.DataBase.Scope>();

            //listScopesCreate.Add(
            //    new Model.DataBase.Scope()
            //    {
            //        Name = "Sys.Database.Clit.Read",
            //        Description = "Permissao de consulta no banco dados para as aplicações client",
            //        DataRegister = System.DateTime.Now
            //    }
            //);

            //listScopesCreate.Add(
            //    new Model.DataBase.Scope()
            //    {
            //        Name = "Sys.Database.Clit.Write",
            //        Description = "Permissao de escrita no banco dados para as aplicações client",
            //        DataRegister = System.DateTime.Now
            //    }
            //);

            //foreach (var scope in listScopesCreate)
            //{
            //    listScopeResult = serviceProvider.GetService<Repository.Application.IApplicationRepository>().CreateScopes(scope);
            //}

            //#endregion

            //#region Criar GrantType
            //List<Model.DataBase.GrantType> grantTypesCreate = new List<Model.DataBase.GrantType>();
            //List<Model.DataBase.GrantType> listGrantTypeResult = new List<Model.DataBase.GrantType>();

            //grantTypesCreate.Add(new Model.DataBase.GrantType()
            //{
            //    DataRegister = System.DateTime.Now,
            //    Type = "implicit"
            //});

            //grantTypesCreate.Add(new Model.DataBase.GrantType()
            //{
            //    DataRegister = System.DateTime.Now,
            //    Type = "authorization_code"
            //});

            //grantTypesCreate.Add(new Model.DataBase.GrantType()
            //{
            //    DataRegister = System.DateTime.Now,
            //    Type = "client_credentials"
            //});
            
            //grantTypesCreate.Add(new Model.DataBase.GrantType()
            //{
            //    DataRegister = System.DateTime.Now,
            //    Type = "password"
            //});

            //grantTypesCreate.Add(new Model.DataBase.GrantType()
            //{
            //    DataRegister = System.DateTime.Now,
            //    Type = "refresh_token"
            //});

            //foreach (var grantType in grantTypesCreate)
            //{
            //    listGrantTypeResult = serviceProvider.GetService<Repository.Application.IApplicationRepository>().CreateGrantType(grantType);
            //}
            //#endregion

            //#region Configurar Escopos da Aplicação
            //List<Model.DataBase.ClitScopes> listClitScopesCreate = new List<Model.DataBase.ClitScopes>();

            //listClitScopesCreate.Add(
            //    new Model.DataBase.ClitScopes
            //    {
            //        DataRegister = System.DateTime.Now,
            //        ClientId = client.UniqueKey,
            //        ScopeId = listScopeResult.Find(scope => scope.Name == "Sys.Database.Clit.Read").Id
            //    });

            //foreach(var item in listClitScopesCreate)
            //{
            //    serviceProvider.GetService<Repository.Application.IApplicationRepository>().ConfigClientScop(item);
            //}
            //#endregion

            //#region Configurar GrantType da Aplicação
            //List<Model.DataBase.ClitGrantType> listClitGrantTypeCreate = new List<Model.DataBase.ClitGrantType>();

            //listClitGrantTypeCreate.Add(
            //        new Model.DataBase.ClitGrantType()
            //        {
            //            ClientId = client.UniqueKey,
            //            DataRegister = System.DateTime.Now,
            //            GrantTypeId = listGrantTypeResult.Find(grt => grt.Type == "client_credentials").Id
            //        });

            //foreach(var item in listClitGrantTypeCreate)
            //{
            //    serviceProvider.GetService<Repository.Application.IApplicationRepository>().ConfigClientGrantType(item);
            //}

            //#endregion
        }
    }
}
