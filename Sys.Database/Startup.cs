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
            services.AddTransient<Repository.Scheme.IConfiguration, Repository.Scheme.Configuration>();
            services.AddTransient<Repository.Scheme.Aplicativos.Client.IClientRepository, Repository.Scheme.Aplicativos.Client.ClientRepository>();
            services.AddTransient<Repository.Scheme.Aplicativos.Secret.ISecretRepository, Repository.Scheme.Aplicativos.Secret.SecretRepository>();
            services.AddTransient<Repository.Scheme.Aplicativos.Scope.IScopeRepository, Repository.Scheme.Aplicativos.Scope.ScopeRepository>();
            services.AddTransient<Repository.Scheme.Aplicativos.GrantType.IGrantTypeRepository, Repository.Scheme.Aplicativos.GrantType.GrantTypeRepository>();
            services.AddTransient<Repository.Scheme.Aplicativos.ClitScopes.IClitScopesRepository, Repository.Scheme.Aplicativos.ClitScopes.ClitScopesRepository>();
            services.AddTransient<Repository.Scheme.Aplicativos.ClitGranType.IClitGranTypeRepository, Repository.Scheme.Aplicativos.ClitGranType.ClitGranTypeRepository>();
            services.AddTransient<Repository.Scheme.Negocios.Empr.IEmprRepository, Repository.Scheme.Negocios.Empr.EmprRepository>();
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
