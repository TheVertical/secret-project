using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.Services;
using SecretProject.VisualElements;
using SecretProject.WebApi.Services;
using System.Text.Json;

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
            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbRemote")));
            services.AddScoped<sBaseContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbRemote")));
            services.AddScoped<IRepository, SqlRepository>();
            services.AddControllers().AddJsonOptions(options =>
            {

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
