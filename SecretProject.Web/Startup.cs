using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.FileProviders;
using SecretProject.WebApi.Infrastructure.Dependecies;

namespace SecretProject.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration;
        private readonly DependencyResolver dependencyResolver;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            dependencyResolver = new DependencyResolver(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            dependencyResolver.ResolveContexts(services);
            dependencyResolver.ResolveDependencies(services);
            dependencyResolver.ResolveIdentity(services);
            dependencyResolver.ResolveSpaServices(services);

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
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

            IncludeSpaStaticFiles(app, env);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(builder =>
            {
                var options = builder.Options;
                options.SourcePath = env.ContentRootPath + "/ClientApp";
                options.DefaultPage = "/main.html";
            });
        }

        private void IncludeSpaStaticFiles(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IncludeDirectory("ClientApp/Scripts", "Scripts", app, env);
            IncludeDirectory("ClientApp/Images", "Images", app, env);
            IncludeDirectory("ClientApp/Styles", "Styles", app, env);
    
            IncludeDirectory("ClientApp/Resources", "Resources", app, env);
            IncludeDirectory("ClientApp/Resources/Fonts", "Resources/Fonts", app, env);
            IncludeDirectory("ClientApp/Resources/Fonts/FontAwesome/Solid", "Resources/Fonts/FontAwesome/Solid", app, env);
        }

        private void IncludeDirectory(string path, string accessPath, IApplicationBuilder app, IWebHostEnvironment env)
        {
            path = Path.Combine(env.ContentRootPath, path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            app.UseSpaStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, path)),
                RequestPath = "/" + accessPath
            });
        }
    }
}
