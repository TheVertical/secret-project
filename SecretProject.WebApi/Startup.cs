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
using SecretProject.BusinessProject.DataAccess;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataAccess;
using SecretProject.Services;
using SecretProject.VisualElements;
using SecretProject.WebApi.Infrastructure;
using SecretProject.WebApi.Services;
using System;
using System.IO;
using System.Text.Json;
using SecretProject.WebApi.Infrastructure.Authetication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SecretProject.BusinessProject.Services.Encription;

namespace SecretProject.WebApi
{
    public class Startup
    {
        private string myAllowedOrigins = "user_policy";
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
            services.AddScoped<IdentityBasicAuthenticationHandler>();
            services.AddScoped<JsonSerializerOptions>(f => new JsonSerializerOptions() { WriteIndented = true, });
            services.AddScoped<IVisualRedactor, VisualRedactor>();
            services.AddScoped<EncriptionService>();
            services.AddTransient<DbContext, sBaseContext>(fac => new sBaseContextFactory().CreateDbContext(Configuration.GetConnectionString("SecretDbLocal")));
            services.AddScoped<IRepository, SqlRepository>();
            services.AddTransient<SessionHelper>(sp => SessionHelper.GetHelper(sp));
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddLogging();
            services.AddRazorPages();
            services.AddControllers().AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowedOrigins, builder =>
                 {
                     builder.WithOrigins("http://31.134.135.98").AllowCredentials();
                     builder.WithOrigins("http://localhost").AllowCredentials();
                     builder.WithOrigins("http://localhost:3000").AllowCredentials();
                 });
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
            app.UseCors(myAllowedOrigins);
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
