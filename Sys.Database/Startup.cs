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
            services.AddScoped<Sys.Database.Repository.Business.IBusinessRepository, Sys.Database.Repository.Business.BusinessRepository>();
            services.AddScoped<Sys.Database.Repository.JsonRepository.IJsonRepository, Sys.Database.Repository.JsonRepository.JsonRepository>();

            services.AddScoped<Sys.Database.Repository.Scheme.Negocios.Empr.IEmprRepository, Sys.Database.Repository.Scheme.Negocios.Empr.EmprRepository>();
            services.AddScoped<Sys.Database.Repository.Scheme.Negocios.Finac.IFinacRepository, Sys.Database.Repository.Scheme.Negocios.Finac.FinacRepository>();
            services.AddScoped<Sys.Database.Repository.Scheme.Negocios.Tax.ITaxRepository, Sys.Database.Repository.Scheme.Negocios.Tax.TaxRepository>();
            services.AddScoped<Sys.Database.Repository.Scheme.Negocios.AssDig.IAssDigRepository, Sys.Database.Repository.Scheme.Negocios.AssDig.AssDigRepository>();
            services.AddScoped<Sys.Database.Repository.Scheme.Negocios.TypFlx.ITypFlxRepository, Sys.Database.Repository.Scheme.Negocios.TypFlx.TypFlxRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


        }
    }
}
