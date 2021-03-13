using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

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
            services.AddTransient<Repository.DataBase.Negocios.Empr.IEmprRepository, Repository.DataBase.Negocios.Empr.EmprRepository>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //byte[] imageArray = System.IO.File.ReadAllBytes(@"D:\Toshio Soft\Informações Empresa\WhatsApp Image 2021-02-12 at 13.34.11.PNG");
            //string base64ImageRepresentation = Convert.ToBase64String(imageArray);

        }
    }
}
