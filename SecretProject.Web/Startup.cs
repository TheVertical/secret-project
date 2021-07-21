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

namespace SecretProject.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private AuthenticationOptions AuthenticationOptions { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<AppIdentityDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("SecretIdentityDbLocal"));
            });
            services.AddScoped<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<IdentityUser>>()
                .AddUserValidator<CustomUserValidator<IdentityUser>>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(confOptions =>
                {
                    confOptions.AddScheme("Basic", builder =>
                    {
                        builder.HandlerType = typeof(IdentityBasicAuthenticationHandler);
                        builder.Build();
                    });
                })
                .AddCookie("SECRET_ONEC_EXCHANGE");
            
            services.AddLogging();
            var mvcBuilder = services.AddRazorPages();

            #if DEBUG
            //mvcBuilder.AddRuntim
            #endif

            services.AddControllersWithViews().AddSessionStateTempDataProvider();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
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

            app.UseHttpsRedirection();

            includeStaticFiles(app, env);

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

        private void includeStaticFiles(IApplicationBuilder app, IWebHostEnvironment env)
        {
            includeDirectory("Scripts", "Scripts", app, env);
            includeDirectory("Images", "Images", app, env);
            includeDirectory("Styles", "Styles", app, env);
        }
        private void includeDirectory(string path, string accessPath, IApplicationBuilder app, IWebHostEnvironment env)
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
