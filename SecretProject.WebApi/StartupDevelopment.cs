using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.VisualElements;
using SecretProject.WebApi.Services;
using System;
using System.Text.Json;

namespace SecretProject.WebApi
{
    public class StartupDevelopment
    {
        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //TODO Это мок опции
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<IVisualRedactor, MockJsonVisualRedactor>();
            //Configuration.
            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            services.AddScoped<sBaseContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            services.AddScoped<IRepository, SqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.Use(async (context, next) =>
                {
                    Console.WriteLine($"{nameof(env.ApplicationName)}:{env.ApplicationName}");
                    Console.WriteLine($"{nameof(env.EnvironmentName)}:{env.EnvironmentName}");
                    Console.WriteLine($"{nameof(env.ContentRootPath)}:{env.ContentRootPath}");
                    Console.WriteLine($"{nameof(env.WebRootPath)}:{env.WebRootPath}");
                    Console.WriteLine($"{nameof(env.ContentRootFileProvider)}:{env.ContentRootFileProvider}");
                    Console.WriteLine($"{nameof(env.WebRootFileProvider)}:{env.WebRootFileProvider}");
                    await next.Invoke();
                });
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
