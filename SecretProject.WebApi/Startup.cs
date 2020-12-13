using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.Services;
using SecretProject.VisualElements;
using SecretProject.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddControllers();
            //TODO Это мок опции
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<IVisualRedactor, VisualRedactor>();
            //Configuration.
            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            services.AddScoped<sBaseContext,sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            services.AddScoped<IRepository,SqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
