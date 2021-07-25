using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecretProject.DAL.Contexts;
using System;
using System.IO;
using SecretProject.WebApi.Infrastructure.Authetication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using SecretProject.WebApi.Infrastructure.Dependecies;

namespace SecretProject.WebApi
{
    public class Startup
    {
        private readonly DependencyResolver dependencyResolver;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            dependencyResolver = new DependencyResolver();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            dependencyResolver.ResolveDependencies(services);

            var mvcBuilder = services.AddRazorPages();
#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif
            services.AddMvc();
            services.AddControllers();
        }

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

            IncludeStaticFiles(app, env);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void IncludeStaticFiles(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IncludeDirectory("Scripts", "Scripts", app, env);
            IncludeDirectory("Images", "Images", app, env);
            IncludeDirectory("Styles", "Styles", app, env);
    
            IncludeDirectory("Resources", "Resources", app, env);
            IncludeDirectory("Resources/Fonts", "Resources/Fonts", app, env);
        }

        private void IncludeDirectory(string path, string accessPath, IApplicationBuilder app, IWebHostEnvironment env)
        {
            path = Path.Combine(env.ContentRootPath, path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, path)),
                RequestPath = "/" + accessPath
            });
        }
    }
}
