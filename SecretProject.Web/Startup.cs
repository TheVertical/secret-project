using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
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
        private AuthenticationOptions AuthenticationOptions { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<AppIdentityDbContext>(options => 
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SecretIdentityDbLocal"));
            //});

            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>()
            //    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<IdentityUser>>()
            //    .AddUserValidator<CustomUserValidator<IdentityUser>>()
            //    .AddDefaultTokenProviders();

            //services.AddLogging();
            var mvcBuilder = services.AddRazorPages();

            #if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
            #endif

            dependencyResolver.ResolveDependencies(services);

            services.AddControllers();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
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

            #if !DEBUG
            #endif

            IncludeStaticFiles(app, env);

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void IncludeStaticFiles(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IncludeDirectory("Scripts", "Scripts", app, env);
            IncludeDirectory("Images", "Images", app, env);
            IncludeDirectory("Styles", "Styles", app, env);
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
    public class IpMiddleware
    {
        private RequestDelegate nextDelegate;
        private readonly ILogger<IpMiddleware> logger;

        public IpMiddleware(RequestDelegate next, Microsoft.Extensions.Logging.ILogger<IpMiddleware> logger)
        {
            nextDelegate = next;
            this.logger = logger;
        }
        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            logger.LogDebug("Remote User Ip:" + context.Connection.RemoteIpAddress);
            logger.LogDebug("Local User Ip:" + context.Connection.LocalIpAddress);
            await nextDelegate.Invoke(context);
        }
    }
}
